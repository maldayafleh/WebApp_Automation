using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;

namespace WebApp_Automation
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new EdgeDriver();
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            Console.WriteLine("Title: " + driver.Title);

            // Locate the element using the copied CSS selector
            var link = driver.FindElement(By.CssSelector("body > center > center > font > a > img"));
            link.Click();

            Thread.Sleep(2000);
            driver.Quit();

        }
    }
}