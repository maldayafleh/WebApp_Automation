/*sing OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using WebApp_Automation.Common;
using WebApp_Automation.Test_Cases;

namespace WebApp_Automation
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Initialize the WebDriver from DriverFactory
                DriverFactory.InitDriver();

                //Run a test case manually
                var test = new BasicNavigationTest();
                test.Setup();
                test.ClickOnImageLink();

                Console.WriteLine("Test Finished");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured: {ex.Message}");
            }
            finally
            {
                DriverFactory.QuitDriver();
            }
        }
    }
}*/