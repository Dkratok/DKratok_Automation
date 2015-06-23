using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace WebDriver_Task3.Tests
{


        [TestFixture(typeof(FirefoxDriver))]
        [TestFixture(typeof(ChromeDriver))]


       public class RemoteTests<TDriver> where TDriver : IWebDriver, new()
         {
        private string _hub = "http://localhost:4444/wd/hub";
        IWebDriver driver;


        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            if (typeof(TDriver).Name == "FirefoxDriver")
            {
                driver = new RemoteWebDriver(new Uri(_hub), DesiredCapabilities.Firefox());
            }
            else
            {
                driver = new RemoteWebDriver(new Uri(_hub), DesiredCapabilities.Chrome());
            }
        }

        //[SetUp]
        //public void Open()
        //{

        //    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
        //    driver.Manage().Window.Maximize();
        //    driver.Navigate().GoToUrl(System.Configuration.ConfigurationSettings.AppSettings["BaseURL"]);
        //}

        [TearDown]
        public void Cleanup()
        {
            Pages.MailingPage mailingpage = new Pages.MailingPage(driver);
            mailingpage.LogOutLink.Click();
        }

        [Test]
        public void isLogin()
        {

            Pages.LoginPage loginpage = new Pages.LoginPage(driver);
            loginpage.OpenPage();
            loginpage.Login((System.Configuration.ConfigurationSettings.AppSettings["UserName"]), (System.Configuration.ConfigurationSettings.AppSettings["Password"]));
            Pages.MailingPage mailpage = new Pages.MailingPage(driver);
            Assert.AreEqual(System.Configuration.ConfigurationSettings.AppSettings["UserNameLink"], mailpage.UserNameLink.Text, "User Name Link is not found");
        }
        [Test]
        [Ignore("Ignore a test")]
        public void isLoginNegative()
        {

            Pages.LoginPage loginpage = new Pages.LoginPage(driver);
            loginpage.OpenPage();
            loginpage.Login(System.Configuration.ConfigurationSettings.AppSettings["UserName"], System.Configuration.ConfigurationSettings.AppSettings["PasswordInv"]);
            Assert.AreEqual(System.Configuration.ConfigurationSettings.AppSettings["LoginErrorMessage"], loginpage.LoginErrorMessage.Text, "ErrorMessage is not found");
        }

        [Test]
        public void IsSavedasDraft()
        {
            Pages.LoginPage loginpage = new Pages.LoginPage(driver);
            Pages.MailingPage mailingpage = new Pages.MailingPage(driver);

            try
            {
                loginpage.OpenPage();
                loginpage.Login((System.Configuration.ConfigurationSettings.AppSettings["UserName"]), (System.Configuration.ConfigurationSettings.AppSettings["Password"]));
            }
            catch (NoSuchElementException)
            { }
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            mailingpage.WriteNewMail();

            mailingpage.DraftsLink.Click();

            Console.WriteLine((System.Configuration.ConfigurationSettings.AppSettings["EmailAddress"]) + " " + mailingpage.DraftsEmail.Text);
            Assert.That((System.Configuration.ConfigurationSettings.AppSettings["EmailAddress"]).CompareTo(mailingpage.DraftsEmail.Text) == 0);
            string subj = Utils.CommonMethods.StringTrim(mailingpage.DraftsSubject.Text, mailingpage.DraftsMailBody.Text);
            Assert.AreEqual((System.Configuration.ConfigurationSettings.AppSettings["EmailSubject"]), subj, "Subject is not found");

        }
    }
}
