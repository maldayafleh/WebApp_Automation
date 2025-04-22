using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace WebApp_Automation.Common
{
    public static class DriverFactory
    {
        public static IWebDriver GetDriver()
        {
            IWebDriver driver;

            switch (Config.Browser)
            {
                case "edge":
                    var edgeOptions = new EdgeOptions();
                    if (Config.Headless)
                        edgeOptions.AddArgument("headless");

                    driver = new EdgeDriver(edgeOptions);
                    break;

                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    if (Config.Headless)
                        chromeOptions.AddArgument("headless");

                    driver = new ChromeDriver(chromeOptions);
                    break;

                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    if (Config.Headless)
                        firefoxOptions.AddArgument("--headless");

                    driver = new FirefoxDriver(firefoxOptions);
                    break;

                default:
                    throw new Exception("Unsupported browser in config.json");
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Config.ImplicitWait);
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
