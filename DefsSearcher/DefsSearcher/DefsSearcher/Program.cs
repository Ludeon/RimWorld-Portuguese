using DefsSearcher;
using System.Xml;

Console.WriteLine("Analyzing all Defs folders...");
var rootDirectory = "F:\\SteamLibrary\\steamapps\\common\\RimWorld\\Data\\Biotech\\Defs";

try
{
    string[] xmlFilePaths = Directory.GetFiles(rootDirectory, "*.xml", SearchOption.AllDirectories);
    var xmlFiles = Helpers.XmlFileConverter(xmlFilePaths);


    foreach (var xmlFile in xmlFiles)
    {
        Console.WriteLine("Filename: " + xmlFile.Key);
        Console.WriteLine("\n");
        
        
        XmlNodeList labelNodes = xmlFile.Value.SelectNodes("//*[contains(name(), 'defName') or contains(name(), 'label') or contains(name(), 'description')]");


        Console.WriteLine($"Found {labelNodes.Count} elements with 'label' in their name:");
        foreach (XmlNode node in labelNodes)
        {
            Console.WriteLine($"Element: {node.Name}, Value: {node.InnerText}");
        }
            

        
        break; //REMOVE
    }

}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

//foreach (XmlNode DefsItems in DefsNode.ChildNodes)
//{
//    string defName = string.Empty;
//    string label = string.Empty;
//    string description = string.Empty;
//    foreach (XmlNode def in DefsItems.ChildNodes)
//    {
//        if (def.Name == "defName")
//        {
//            defName = def.InnerXml;
//        }
//        if (def.Name == "label")
//        {
//            label = def.InnerXml;
//        }
//        if (def.Name == "description")
//        {
//            description = def.InnerXml;
//        }

//    }

//    if (!(label == string.Empty || description == string.Empty))
//    {
//        Console.WriteLine("defName: " + defName);
//        Console.WriteLine("label: " + label);
//        Console.WriteLine("description: " + description);
//        Console.WriteLine("\n");
//    }

//    //Console.WriteLine("\n");
//    //break;
//}

