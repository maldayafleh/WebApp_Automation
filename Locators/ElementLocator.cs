using System.Xml;

namespace WebApp_Automation.Locators
{
    public static class ElementLocator
    {
        private static readonly string locatorFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Locators", "ElementMap.xml");

        public static ElementIdentifier GetElement(string name)
        {
            var doc = new XmlDocument();
            doc.Load(locatorFile);

            XmlNode node = doc.SelectSingleNode($"/Elements/Element[@name='{name}']");

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
