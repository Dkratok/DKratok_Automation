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

namespace WebDriver_Task2.Tests
{
    [TestFixture]
    public class LoginPageTests : BaseTest
    {
        

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
        public void isLoginNegative()
        {

            Pages.LoginPage loginpage = new Pages.LoginPage(driver);
            loginpage.OpenPage();
            loginpage.Login(System.Configuration.ConfigurationSettings.AppSettings["UserName"], System.Configuration.ConfigurationSettings.AppSettings["PasswordInv"]);
            Assert.AreEqual(System.Configuration.ConfigurationSettings.AppSettings["LoginErrorMessage"], loginpage.LoginErrorMessage.Text, "ErrorMessage is not found");
        }
    }
}

