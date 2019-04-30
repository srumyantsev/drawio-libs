using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace SvgToDrawioLibConverter
{
    class Program
    {
        private static readonly Settings Settings = new Settings();
        private static string DrawioLibraryNameExtension = ".xml";
        private static string SvgExtension = "*.svg";

        static void Main(string[] args)
        {
            try
            {
                var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

                IConfigurationRoot configuration = builder.Build();
                configuration.GetSection("Settings").Bind(Settings);

                GenerateDrawioLibraries();
            } catch (Exception ex)
            {
                Console.WriteLine($"CRITICAL ERROR");
                Console.WriteLine($"Exception: '{ex.Message}'");
                Console.WriteLine($"StackTrace: '{ex.StackTrace}'");
            }
            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }

        private static void GenerateDrawioLibraries()
        {
            Console.WriteLine($"Generating drawio libraries");
            foreach (Library libraryInput in Settings.Libs)
            {
                Console.WriteLine($"Generating library '{libraryInput.Title}'");

                try
                {
                    string mxLibrary = DrawioLibraryBuilder.Build(new DrawioLibraryBuilder.Model
                    {
                        LibraryTitle = libraryInput.Title,
                        SvgFilePaths = Directory.EnumerateFiles(libraryInput.SvgsFolder, SvgExtension),
                        AddStyleElement = libraryInput.AddStyleElement
                    });

                    string drawioLibraryPath = Path.Combine(Settings.OutputFolder, $"{libraryInput.Title}{DrawioLibraryNameExtension}");
                    Console.WriteLine($"Writing library '{drawioLibraryPath}'");
                    if (!Directory.Exists(Path.GetDirectoryName(drawioLibraryPath)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(drawioLibraryPath));
                    }
                    File.WriteAllText(drawioLibraryPath, mxLibrary);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed process '{libraryInput.Title}'");
                    Console.WriteLine($"Exception: '{ex.Message}'");
                    Console.WriteLine($"StackTrace: '{ex.StackTrace}'");
                }                
            }
        }
    }
}
