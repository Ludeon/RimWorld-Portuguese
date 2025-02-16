using System.Xml;

namespace DefsSearcher
{
    public static class Helpers
    {
        public static Dictionary<string, XmlDocument> XmlFileConverter(string[] xmlFilePaths)
        {
            Dictionary<string, XmlDocument> xmlDocuments = new Dictionary<string, XmlDocument>();

            for (int i = 0; i < xmlFilePaths.Length; i++)
            {
                XmlDocument xmlDoc = new XmlDocument();
                //Console.WriteLine(xmlFilePaths[i]);
                xmlDoc.Load(xmlFilePaths[i]);
                var filename = Path.GetFileName(xmlFilePaths[i]);
                xmlDocuments.Add(filename, xmlDoc);
            }

            Console.WriteLine($"Found {xmlDocuments.Count} XML files:\n");

            return xmlDocuments;
        }
    }
}
