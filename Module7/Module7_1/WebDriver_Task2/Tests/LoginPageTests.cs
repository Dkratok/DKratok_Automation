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
using log4net;
using log4net.Config;

namespace Module7_1.Tests
{
    [TestFixture]
    public class LoginPageTests : BaseTest
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(LoginPageTests));

        [Test]
        public void isLogin()
        {
            
            XmlConfigurator.Configure();
            Pages.LoginPage loginpage = new Pages.LoginPage(driver);
            loginpage.OpenPage();
            logger.Info("Login page is opening");
            loginpage.Login((System.Configuration.ConfigurationSettings.AppSettings["UserName"]), (System.Configuration.ConfigurationSettings.AppSettings["Password"]));
            logger.Info("Mailing page is opening");
            Pages.MailingPage mailpage = new Pages.MailingPage(driver);
            Assert.AreEqual(System.Configuration.ConfigurationSettings.AppSettings["UserNameLink"], mailpage.UserNameLink.Text, "User Name Link is not found");
            Utils.TakeScreenshot.Take_Screenshot(driver);
        }
        [Test]
        public void isLoginNegative()
        {
            XmlConfigurator.Configure();
            Pages.LoginPage loginpage = new Pages.LoginPage(driver);
            loginpage.OpenPage();
            loginpage.Login(System.Configuration.ConfigurationSettings.AppSettings["UserName"], System.Configuration.ConfigurationSettings.AppSettings["PasswordInv"]);
            Assert.AreEqual(System.Configuration.ConfigurationSettings.AppSettings["LoginErrorMessage"], loginpage.LoginErrorMessage.Text, "ErrorMessage is not found");
            Utils.TakeScreenshot.Take_Screenshot(driver);
            logger.Info("Login is Failed. Test is passed.");
        }
    }
}

