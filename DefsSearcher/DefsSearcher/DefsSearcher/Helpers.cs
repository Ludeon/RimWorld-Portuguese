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

        public static void NodeSearcher(XmlNode node, ref List<Tuple<string, string>> items)
        {
            string defName = string.Empty;
            string label = string.Empty;
            string description = string.Empty;
            foreach (XmlNode def in node.ChildNodes)
            {
                if (node.HasChildNodes)
                {
                    NodeSearcher(def, ref items);
                }

                if (def.Name == "defName")
                {
                    defName = def.InnerXml;
                }
                if (def.Name == "label")
                {
                    label = def.InnerXml;
                }
                if (def.Name == "description")
                {
                    description = def.InnerXml;
                }

            }

            if (!(label == string.Empty && description == string.Empty))
            {
                Console.WriteLine("defName: " + defName);
                items.Add(new("defName", defName));
                Console.WriteLine("label: " + label);
                items.Add(new("label", label));
                Console.WriteLine("description: " + description);
                items.Add(new("description", description));
                Console.WriteLine("\n");
            }
        }
    }
}
