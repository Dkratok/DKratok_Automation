using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using System.Xml;

namespace AppTest
{
    [TestFixture]
    public class LoginPage : WebControl
    {
        
      
        public By UserNameField = By.Id("mailbox__login");
        public By PasswordField = By.Name("Password");
        public By DomainCombo = By.XPath(".//*[@id='mailbox__login__domain']");
        public By SignInBtn = By.Id("mailbox__auth__button");
        public By UserMail = By.Id("PH_user-email");
        public By UserNameLink = By.Id("PH_user-email");

        //public IWebDriver driver = new InternetExplorerDriver();
        //public IWebDriver driver = new ChromeDriver();
        public IWebDriver driver = new FirefoxDriver();
      

        public void Login()
        {
            
            driver.Navigate().GoToUrl(TestData.BaseURL);
            driver.Manage().Window.Maximize();

            GetElement(driver, UserNameField).Clear();
            GetElement(driver, UserNameField).SendKeys(TestData.UserName);
            GetElement(driver, PasswordField).Clear();
            GetElement(driver, PasswordField).SendKeys(TestData.Password);

            IWebElement dropDownListBox = GetElement(driver, DomainCombo);
            SelectElement clickThis = new SelectElement(dropDownListBox);
            clickThis.SelectByText("@inbox.ru");

            var signin = GetElement(driver, SignInBtn);
            if (signin != null)
                signin.Click();
            else
                Console.WriteLine("Link is not found");
        }

        [Test]
        public void isLogin()
        {
            Login();
            GetElement(driver, UserNameLink).Click();
            Assert.AreEqual(GetElement(driver, UserNameLink).Text, TestData.UserNameLink, "User Name Link is not found");
        }
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {

            }
        }
    }
}

