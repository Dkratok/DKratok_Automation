using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;

namespace WebDriver_Task2.Pages
{
    public class LoginPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "mailbox__login")]
        private IWebElement UserNameField;

        [FindsBy(How = How.Name, Using = "Password")]
        private IWebElement PasswordField;

        [FindsBy(How = How.XPath, Using = ".//*[@id='mailbox__login__domain']")]
        private IWebElement DomainCombo;

        [FindsBy(How = How.Id, Using = "mailbox__auth__button")]
        private IWebElement SignInBtn;

        [FindsBy(How = How.XPath, Using = ".//div[@class='login-page__external__desc']/div[3]")]
        public IWebElement LoginErrorMessage;


        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(TestData.TestData.BaseURL);
            Console.WriteLine("Login Page opened");
        }

        public void Login(string username, string password)
        { 
            UserNameField.Clear();
            UserNameField.SendKeys(username);
            PasswordField.Clear();
            PasswordField.SendKeys(password);
            SelectElement clickThis = new SelectElement(DomainCombo);
            clickThis.SelectByText(TestData.TestData.Domain);
            SignInBtn.Click();        
        }


    }
}
