﻿using System;
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
                Console.WriteLine($"Processing file '{svgFilePath}'");
                try
                {
                    mxLibrarySb.Append(PocessSvg(model, svgFilePath));
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Failed process '{svgFilePath}'");
                    Console.Error.WriteLine($"Exception: '{ex.Message}'");
                    Console.Error.WriteLine($"StackTrace: '{ex.StackTrace}'");
                }
            }
            mxLibrarySb.Remove(mxLibrarySb.Length - 1, 1);

            mxLibrarySb.Append("]</mxlibrary>");

            return mxLibrarySb.ToString();
        }

        private static StringBuilder PocessSvg(Model model, string svgFilePath)
        {
            string svgFileName = Path.GetFileNameWithoutExtension(svgFilePath);

            var processedSvgSb = new StringBuilder();
            processedSvgSb.Append("{");
            //append common part
            processedSvgSb.Append("\"data\":\"data:image/svg+xml;base64,");

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
            processedSvgSb.Append(base64encodedSvgXml);
            processedSvgSb.Append("\",");

            processedSvgSb.Append($"\"title\":\"{svgFileName}\"");

            XAttribute viewBoxAttribute = svgXml.Root.Attribute("viewBox");
            const double imageWidth = 100;
            double imageHeight = 100;
            if (viewBoxAttribute != null && !string.IsNullOrEmpty(viewBoxAttribute.Value))
            {
                string[] viewBoxAttributeValue = viewBoxAttribute.Value.Split(" ");
                if (viewBoxAttributeValue.Length == 4 && double.TryParse(viewBoxAttributeValue[2], out double originalImageWidth) && double.TryParse(viewBoxAttributeValue[3], out double originalImageHeight))
                {
                    double aspectRatio = originalImageWidth / originalImageHeight;
                    imageHeight = imageWidth / aspectRatio;
                }
            }

            //append common properties
            processedSvgSb.Append($", \"w\":{(int)imageWidth},\"h\":{(int)imageHeight}");
            processedSvgSb.Append("},");
            return processedSvgSb;
        }

        public class Model
        {
            public string LibraryTitle { get; set; } = "Undefined";
            public IEnumerable<string> SvgFilePaths { get; set; }
            public bool AddStyleElement { get; set; }
        }
    }
}
