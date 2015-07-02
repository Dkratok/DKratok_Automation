using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;


namespace Module6_3.Tests
{
    public class BaseTest
    {
        public static IWebDriver driver;
        [TestFixtureSetUp]
        public static IWebDriver Init()
        {
            //XmlConfigurator.Configure();

            driver = Driver.DriverInstance.GetInstance();
            
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.Manage().Window.Maximize();
            //driver.Navigate().GoToUrl(System.Configuration.ConfigurationSettings.AppSettings["BaseURL"]);
            return driver;
        }

        [TestFixtureTearDown]
        public static void Close()
        {
            Driver.DriverInstance.CloseBrowser();
        }

        [SetUp]
        public void Open()
        {
            driver.Navigate().GoToUrl(System.Configuration.ConfigurationSettings.AppSettings["BaseURL"]);
        }

        [TearDown]
        public void CleanUp()
        {

        }
    }
}
