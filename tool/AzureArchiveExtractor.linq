<Query Kind="Program" />

void Main()
{
	Directory.SetCurrentDirectory(@"../input/Microsoft_CloudnEnterprise_Symbols_v2.7KP");
	IEnumerable<string> files = Directory.EnumerateFiles(".", "*.svg", SearchOption.AllDirectories);
	Dictionary<string, string> foldersMapping = files.Select(f => Path.GetDirectoryName(f)).Distinct().ToDictionary(f => "azure-" + f.Replace(".", "").Replace("\\", "-").Replace(" ", "-").Trim('-').ToLower(), f => f);
	
	const string outputRootFolder = "../";
	string azureLibsPath = Path.Combine(outputRootFolder, "azurelibs.txt");
	if (File.Exists(azureLibsPath))
	{
		File.Delete(azureLibsPath);
	}
	
	foreach (KeyValuePair<string, string> outputFolderMapping in foldersMapping)
	{
		File.AppendAllText(Path.Combine(outputRootFolder, "azurelibs.txt"), $"{{ \"Title\": \"{outputFolderMapping.Key}\", \"SvgsFolder\": \"./input/{outputFolderMapping.Key}/\", \"AddStyleElement\": false }},");
		
		Directory.CreateDirectory(Path.Combine(outputRootFolder, outputFolderMapping.Key));
		
		foreach (string filePath in files.Where(f => Path.GetDirectoryName(f).EndsWith(outputFolderMapping.Value)))
		{
			File.Copy(filePath, Path.Combine(outputRootFolder, outputFolderMapping.Key, Path.GetFileName(filePath)), true);
		}
	}
	
	foldersMapping.Dump();
}

// Define other methods and classes here
