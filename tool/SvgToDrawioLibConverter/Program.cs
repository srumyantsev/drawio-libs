using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SvgToDrawioLibConverter
{
    class Program
    {
        private static HttpClient HttpClient = new HttpClient();
        private static readonly Settings Settings = new Settings();
        private static readonly string ExtractedArchiveFolder = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        private static string[] SvgsFolders;
        private static string FontawesomeDrawioLibraryNamePrefix = $"{DateTime.Now.ToString("yyyy-MM-dd")}_fontawesome_";
        private static string DrawioLibraryNameExtension = ".xml";

        static async Task Main(string[] args)
        {
            try
            {
                var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

                IConfigurationRoot configuration = builder.Build();
                configuration.GetSection("Settings").Bind(Settings);

                await DownloadAndExtractArchive();
                GenerateDrawioLibraries();
                ClearTemporaryArtifacts();
            } catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
            }
            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }

        private static void GenerateDrawioLibraries()
        {
            Console.WriteLine($"Generating drawio libraries");
            foreach (string svgFolderPath in SvgsFolders)
            {
                string svgsFolderName = Path.GetFileName(svgFolderPath.TrimEnd(Path.DirectorySeparatorChar)); //Actually not file name, but directory name. Expected results are "regular", "solid", etc.
                string drawioLibraryName = $"{FontawesomeDrawioLibraryNamePrefix}{svgsFolderName}";
                string drawioLibraryFileName = $"{drawioLibraryName}{DrawioLibraryNameExtension}";
                string drawioLibraryPath = Path.Combine(Settings.DrawioLibrariesFolder, drawioLibraryFileName);
                Console.WriteLine($"Generating library {drawioLibraryPath}");

                string mxLibrary = DrawioLibraryBuilder.Build(new DrawioLibraryBuilder.Model
                {
                    LibraryTitle = drawioLibraryName,
                    SvgFilePaths = Directory.EnumerateFiles(svgFolderPath, "*.svg"),
                    AddStyleElement = true
                });
                
                Console.WriteLine($"Writing library {drawioLibraryPath}");
                if (!Directory.Exists(Path.GetDirectoryName(drawioLibraryPath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(drawioLibraryPath));
                }
                File.WriteAllText(drawioLibraryPath, mxLibrary);
            }
        }

        private static async Task DownloadAndExtractArchive()
        {
            string archiveTempFilePath = Path.GetTempFileName();

            Console.WriteLine($"Downloading archive {Settings.FontAwesomeArchiveUrl} to {archiveTempFilePath}");
            using (HttpResponseMessage response = await HttpClient.GetAsync(Settings.FontAwesomeArchiveUrl, HttpCompletionOption.ResponseHeadersRead))
            using (Stream streamToReadFrom = await response.Content.ReadAsStreamAsync())
            {
                using (Stream streamToWriteTo = File.Open(archiveTempFilePath, FileMode.Create))
                {
                    await streamToReadFrom.CopyToAsync(streamToWriteTo);
                }
            }

            Console.WriteLine($"Extracting archive {archiveTempFilePath} to {ExtractedArchiveFolder}");
            ZipFile.ExtractToDirectory(archiveTempFilePath, ExtractedArchiveFolder);

            Console.WriteLine($"Deleting temporary archive {archiveTempFilePath}");
            File.Delete(archiveTempFilePath);

            Console.WriteLine($"Finding svgs folders {ExtractedArchiveFolder}");
            string svgsFolder = Directory.EnumerateDirectories(ExtractedArchiveFolder, Settings.SvgsFolderSearchPattern, SearchOption.AllDirectories).Single();
            SvgsFolders = Directory.EnumerateDirectories(svgsFolder).ToArray();
        }

        private static void ClearTemporaryArtifacts()
        {
            Console.WriteLine($"Deleting temporary folder {ExtractedArchiveFolder}");
            Directory.Delete(ExtractedArchiveFolder, true);
        }
    }
}
