using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace AppTest
{
    public class BaseTest : WebControl
    {
        public IWebDriver Driver;
        //public string BaseURL;

        [SetUp]
        public void SetupTest()
        {
            Driver = new InternetExplorerDriver();
            //Driver = new FirefoxDriver();
            Driver.Manage().Window.Maximize();
            //Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(30));
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));           
            //BaseURL = "http://www.onliner.by/";
            Driver.Navigate().GoToUrl(TestData.BaseURL);
            
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                Driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
    }
}
