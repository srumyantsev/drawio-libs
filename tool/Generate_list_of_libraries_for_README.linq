<Query Kind="Program" />

void Main()
{
	Directory.SetCurrentDirectory(Path.GetDirectoryName(Util.CurrentQueryPath));
	Directory.EnumerateFiles("../libs/", "*.xml", SearchOption.AllDirectories).Select(filePath => Path.GetFileName(filePath)).Select(fileName =>  $"[{fileName}](./libs/{fileName}){Environment.NewLine}").Dump();
}

// Define other methods and classes here
