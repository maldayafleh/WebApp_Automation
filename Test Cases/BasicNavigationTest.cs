using NUnit.Framework;
using OpenQA.Selenium;
using WebApp_Automation.Common;
using WebApp_Automation.Lib;
using WebApp_Automation.Locators;

namespace WebApp_Automation.Test_Cases
{
    public class BasicNavigationTest
    {
        [SetUp]
        public void Setup()
        {
            DriverFactory.InitDriver();// Intitialize the WebDriver and navigates to the URL
        }

        [Test]
        public void ClickOnImageLink()
        {
            var driver = DriverFactory.GetDriver();

            //Click on the image
            UiHelper.Click("imageClick");

            //Assert that the URL changed
            Assert.IsTrue(driver.Url.Contains("https://www.inmotionhosting.com/"));
        }

        [TearDown]
        public void Cleanup()
        {
            DriverFactory.QuitDriver(); //Close the browser after the test
        }
    }
}
