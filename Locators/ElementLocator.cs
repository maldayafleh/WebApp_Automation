using System.Xml;

namespace WebApp_Automation.Locators
{
    public static class ElementLocator
    {
        private static readonly string locatorFile = "ElementMap.xml";

        public static ElementIdentifier GetElement(string name)
        {
            var doc = new XmlDocument();
            doc.LoadXml(locatorFile);

            XmlNode node = doc.SelectSingleNode($"/Elements/Elment[@name=' {name}']");

            if (node == null)
                throw new Exception($"Element with name '{name}' not found in XML.");

            string by = node["By"]?.InnerText;
            string value = node["Value"]?.InnerText;

            return new ElementIdentifier
            {
                By = by,
                Value = value
            };
        }
    }
}
