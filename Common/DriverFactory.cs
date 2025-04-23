using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebApp_Automation.Common;

namespace WebApp_Automation.Common
{
    public static class DriverFactory
    {
        private static IWebDriver _driver;

        public static void InitDriver()
        {
            if (_driver != null) return;

            string browser = Config.Settings.Browser;

            switch (browser)
            {
                case "edge":
                    var edgeOptions = new EdgeOptions();
                    if (Config.Settings.Headless)
                        edgeOptions.AddArgument("headless");
                    _driver = new EdgeDriver(edgeOptions);
                    break;

                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    if (Config.Settings.Headless)
                        chromeOptions.AddArgument("headless");
                    _driver = new ChromeDriver(chromeOptions);
                    break;

                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    if (Config.Settings.Headless)
                        firefoxOptions.AddArgument("--headless");
                    _driver = new FirefoxDriver(firefoxOptions);
                    break;

                default:
                    throw new Exception($"Unsupported browser '{browser}' in config.json.");
            }

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Config.Settings.ImplicitWait);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(Config.Settings.AppUrl); // Go to base URL from config
        }

        public static IWebDriver GetDriver()
        {
            if (_driver == null)
                throw new Exception("WebDriver is not initialized. Call InitDriver() first.");

            return _driver;
        }

        public static void QuitDriver()
        {
            _driver?.Quit();
            _driver = null;
        }
    }
}
