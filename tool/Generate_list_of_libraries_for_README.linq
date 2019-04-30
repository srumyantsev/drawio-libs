<Query Kind="Program" />

void Main()
{
	Directory.SetCurrentDirectory(Path.GetDirectoryName(Util.CurrentQueryPath));
	IEnumerable<string> libFilePaths = Directory.EnumerateFiles("../libs/", "*.xml", SearchOption.AllDirectories).Select(filePath => Path.GetFileName(filePath));
	string fileContent = $"# Libs  {Environment.NewLine}";
	fileContent += string.Join(Environment.NewLine, libFilePaths.Select(fileName => $"* **{fileName}** https://www.draw.io/?splash=0&clibs=U" + Uri.EscapeDataString($"https://raw.githubusercontent.com/srumyantsev/drawio-libs/master/libs/{fileName}")));
	File.WriteAllText("../Libs.md", fileContent);
}

// Define other methods and classes here