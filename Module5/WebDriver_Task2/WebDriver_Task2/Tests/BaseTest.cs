using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Firefox;

namespace WebDriver_Task2.Tests
{
    public class BaseTest
    {
        public IWebDriver driver;
        [TestFixtureSetUp]
        public void Init()
        {
            //XmlConfigurator.Configure();

            driver = Driver.DriverInstance.GetInstance();
            
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.Manage().Window.Maximize();
        }

        [TestFixtureTearDown]
        public static void Close()
        {
            Driver.DriverInstance.CloseBrowser();
        }

        [SetUp]
        public void Open()
        {
            driver.Navigate().GoToUrl(TestData.TestData.BaseURL);
        }

        [TearDown]
        public void CleanUp()
        {

            //driver.Manage().Cookies.DeleteAllCookies();
        }
    }
}
