using OpenQA.Selenium;
using WebApp_Automation.Common;
using WebApp_Automation.Locators;

namespace WebApp_Automation.Lib
{
    public class UiHelper
    {
        private static IWebDriver driver => DriverFactory.GetDriver();

        public static void Click(string elementName)
        {
            FindElementByName(elementName).Click();
        }

        public static void EnterText(string elementName, string text)

        {
            var element = FindElementByName(elementName);
            element.Clear();
            element.SendKeys(text);
        }

        public static string GetText(string elementName)
        {
            return FindElementByName(elementName).Text;
        }

        public static bool IsElementVisible(string elementName)
        {
            try
            {
                return FindElementByName(elementName).Displayed;
            }
            catch
            {
                return false;
            }
        }

        private static IWebElement FindElementByName(string elementName)
        {
            ElementIdentifier identifier = ElementLocator.GetElement(elementName);
            By by = GetBy(identifier);
            return driver.FindElement(by);
        }

        private static By GetBy(ElementIdentifier identifier)
        {
            return identifier.By.ToLower() switch
            {
                "id" => By.Id(identifier.Value),
                "name" => By.Name(identifier.Value),
                "classname" => By.ClassName(identifier.Value),
                "tagname" => By.TagName(identifier.Value),
                "linktext" => By.LinkText(identifier.Value),
                "partiallinktext" => By.PartialLinkText(identifier.Value),
                "cssselector" => By.CssSelector(identifier.Value),
                "xpath" => By.XPath(identifier.Value),
                _ => throw new Exception($"Unsupported locator strategy: {identifier.By}")
            };
        }
    }
}
