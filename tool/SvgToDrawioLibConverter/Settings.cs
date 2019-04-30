using System.Collections.Generic;

namespace SvgToDrawioLibConverter
{
    public class Settings
    {
        public List<Library> Libs { get; set; }
        public string OutputFolder { get; set; }
    }

    public class Library
    {
        public string Title { get; set; }
        public string SvgsFolder { get; set; }
        public bool AddStyleElement { get; set; }
    }
}
