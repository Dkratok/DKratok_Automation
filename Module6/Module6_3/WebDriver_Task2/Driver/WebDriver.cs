using System;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Module6_3.Driver
{
    public class DriverInstance
    {
        public static IWebDriver driver;

        private DriverInstance() { }

        public static IWebDriver GetInstance()
        {
            if (driver == null)
            {
                driver = CreateDriver();
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public static void CloseBrowser()
        {
            driver.Close();
            driver = null;
        }

      

        private static IWebDriver CreateDriver()
        {
            IWebDriver driver = null;
            switch ((System.Configuration.ConfigurationSettings.AppSettings["BrowserType"]))
            {
                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
                case "InternetExplorer":
                    driver = new InternetExplorerDriver();
                    break;
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "GoogleChrome":
                    driver = new ChromeDriver();
                    break;
                case "FF":
                    driver = new FirefoxDriver();
                    break;
                case "FireFox":
                    driver = new FirefoxDriver();
                    break;
            }

            return driver;
        }
    }
}
