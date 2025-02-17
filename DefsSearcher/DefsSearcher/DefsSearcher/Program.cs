using DefsSearcher;
using System.Xml;

Console.WriteLine("Analyzing all Defs folders...");
// var rootDirectory = "F:\\SteamLibrary\\steamapps\\common\\RimWorld\\Data\\Biotech\\Defs";
var rootDirectory = "/Users/titoferreira/Library/Application Support/Steam/steamapps/common/RimWorld/RimWorldMac.app/Data/Biotech/Defs";

try
{
    string[] xmlFilePaths = Directory.GetFiles(rootDirectory, "*.xml", SearchOption.AllDirectories);
    var xmlFiles = Helpers.XmlFileConverter(xmlFilePaths);


    foreach (var xmlFile in xmlFiles)
    {
        Console.WriteLine("Filename: " + xmlFile.Key);
        Console.WriteLine("\n");

        XmlNode DefsNode = xmlFile.Value.SelectSingleNode("Defs");

        List<Tuple<string, string>> items = new();
        Helpers.NodeSearcher(DefsNode, ref items);

        foreach (var item in items)
        {
            Console.WriteLine("key: " + item.Item1 + " Value: " + item.Item2);
        }



        break; //REMOVE
    }

}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

