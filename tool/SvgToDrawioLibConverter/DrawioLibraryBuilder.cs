using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace SvgToDrawioLibConverter
{
    public static class DrawioLibraryBuilder
    {
        private const string StyleClassName = "drawio-style";

        public static string Build(Model model)
        {
            var mxLibrarySb = new StringBuilder();
            mxLibrarySb.Append($"<mxlibrary title=\"{model.LibraryTitle}\">[");

            foreach (string svgFilePath in model.SvgFilePaths)
            {
                Console.WriteLine($"Processing file {svgFilePath}");
                string svgFileName = Path.GetFileNameWithoutExtension(svgFilePath);

                mxLibrarySb.Append("{");
                //append common part
                mxLibrarySb.Append("\"data\":\"data:image/svg+xml;base64,");

                XDocument svgXml = XDocument.Load(svgFilePath);

                if (model.AddStyleElement)
                {
                    XElement styleElement = new XElement(XName.Get("style", svgXml.Root.Name.NamespaceName));
                    styleElement.Add(new XAttribute("type", "text/css"));
                    styleElement.Value = $".{StyleClassName}{{ fill:#000000; stroke:#000000; }}";
                    svgXml.Root.AddFirst(styleElement);
                    XElement pathElement = svgXml.Root.Element(XName.Get("path", svgXml.Root.Name.NamespaceName));
                    XAttribute classAttribute = pathElement.Attribute("class");
                    if (classAttribute != null)
                    {
                        classAttribute.Value += " " + StyleClassName;
                    }
                    else
                    {
                        pathElement.Add(new XAttribute("class", StyleClassName));
                    }
                }                

                byte[] svgXmlByteArray = Encoding.UTF8.GetBytes(svgXml.ToString());
                string base64encodedSvgXml = Convert.ToBase64String(svgXmlByteArray);
                mxLibrarySb.Append(base64encodedSvgXml);
                mxLibrarySb.Append("\",");

                mxLibrarySb.Append($"\"title\":\"{svgFileName}\",");
                //append common properties
                mxLibrarySb.Append("\"w\":320,\"h\":320,\"aspect\":\"fixed\"");
                mxLibrarySb.Append("},");
            }
            mxLibrarySb.Remove(mxLibrarySb.Length - 1, 1);

            mxLibrarySb.Append("]</mxlibrary>");

            return mxLibrarySb.ToString();
        }

        public class Model
        {
            public string LibraryTitle { get; set; } = "Undefined";
            public IEnumerable<string> SvgFilePaths { get; set; }
            public bool AddStyleElement { get; set; }
        }
    }
}
