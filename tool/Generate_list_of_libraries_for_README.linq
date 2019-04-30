<Query Kind="Program" />

void Main()
{
	Directory.SetCurrentDirectory(Path.GetDirectoryName(Util.CurrentQueryPath));
	Directory.EnumerateFiles("../libs/", "*.xml", SearchOption.AllDirectories).Select(filePath => Path.GetFileName(filePath)).Select(fileName =>  $"https://raw.githubusercontent.com/srumyantsev/drawio-libs/master/libs/{fileName} File: [{fileName}](./libs/{fileName}){Environment.NewLine}").Dump();
}

// Define other methods and classes here
