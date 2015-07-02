using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;

namespace Module6_3.SpecFlow
{
    public class Steps
    {
        [FindsBy(How = How.Id, Using = "mailbox__login")]
        public IWebElement UserNameField;

        [FindsBy(How = How.Name, Using = "Password")]
        public IWebElement PasswordField;

        [FindsBy(How = How.XPath, Using = ".//*[@id='mailbox__login__domain']")]
        public IWebElement DomainCombo;

        [FindsBy(How = How.Id, Using = "mailbox__auth__button")]
        public IWebElement SignInBtn;

        [FindsBy(How = How.Id, Using = "PH_user-email")]
        public IWebElement UserNameLink;

        [FindsBy(How = How.XPath, Using = ".//div[@class='login-page__external__desc']/div[3]")]
        public IWebElement LoginErrorMessage;

        [FindsBy(How = How.XPath, Using = ".//*[@id='b-toolbar__left']/div/div/div[2]/div/a/span")]
        private IWebElement CreateEmailBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='compose__header__content']/div[2]/div[2]/div[1]/textarea")]
        private IWebElement AdresseeField;

        [FindsBy(How = How.Name, Using = "Subject")]
        private IWebElement SubjectField;

        [FindsBy(How = How.CssSelector, Using = "iframe[title='{#aria.rich_text_area}']")]
        public IWebElement ElementItemFrame;

        [FindsBy(How = How.Id, Using = "tinymce")]
        private IWebElement BodyField;

        [FindsBy(How = How.CssSelector, Using = "div[title='Сохранить']")]
        public IWebElement SavetoDraftBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='b-nav_folders']/div/div[3]/a/span")]
        public IWebElement DraftsLink;

        [FindsBy(How = How.XPath, Using = "//div[@class='b-datalists']/div[3]/div/div[2]/div[1]/div/a/div[4]/div[3]/div[2]")]
        public IWebElement DraftsEmail;

        [FindsBy(How = How.XPath, Using = "//div[@class='b-datalists']/div[3]/div/div[2]/div[1]/div/a/div[4]/div[3]/div[1]")]
        public IWebElement DraftsSubject;

        [FindsBy(How = How.XPath, Using = "//div[@class='b-datalists']/div[3]/div/div[2]/div[1]/div/a/div[4]/div[3]/div[1]/Span")]
        public IWebElement DraftsMailBody;

        [FindsBy(How = How.XPath, Using = "//*[@class='b-datalist__item js-datalist-item'][1]//a")]
        public IWebElement DraftsMail;

        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef
        public IWebDriver driver;

        public Steps(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl("https://mail.ru/");
        }
        
        public void InputLogin()
        {
            UserNameField.Clear();
            UserNameField.SendKeys(System.Configuration.ConfigurationSettings.AppSettings["UserName"]);
        }


        public void InputPW()
        {
            PasswordField.Clear();
            PasswordField.SendKeys(System.Configuration.ConfigurationSettings.AppSettings["Password"]);
        }

        public void InputPW_notCorrect()
        {
            PasswordField.Clear();
            PasswordField.SendKeys(System.Configuration.ConfigurationSettings.AppSettings["PasswordInv"]);
        }

        public void DomainSelect()
        {
            SelectElement clickThis = new SelectElement(DomainCombo);
            clickThis.SelectByText((System.Configuration.ConfigurationSettings.AppSettings["Domain"]));
        }


        public void SigninPress()
        {
            SignInBtn.Click();
        }


        public void MailPageOpened()
        {
            Assert.AreEqual((System.Configuration.ConfigurationSettings.AppSettings["UserNameLink"]), UserNameLink.Text, "User Name Link is not found");
        }

        public void MailPagenotOpened()
        {
            Assert.AreEqual((System.Configuration.ConfigurationSettings.AppSettings["LoginErrorMessage"]), LoginErrorMessage.Text, "User Name Link is not found");
        }

        public void NewEmailButtonClick()
        {
            System.Threading.Thread.Sleep(5000);
            CreateEmailBtn.Click();
        }

        public void Input_AddressField(string EmailAddress)
        {
            System.Threading.Thread.Sleep(5000);
            AdresseeField.Clear();
            AdresseeField.SendKeys(EmailAddress);
        }

        public void Input_Subject(string Subject)
        {
            System.Threading.Thread.Sleep(5000);
            SubjectField.Clear();
            SubjectField.SendKeys(Subject);
        }

        public void Input_Text(string Text)
        {
            
            BodyField.Clear();
            BodyField.SendKeys(Text);
            
        }

        public void SaveEmailButtonClick()
        {
            
            SavetoDraftBtn.Click();
            
        }

        public void DraftsMailsClick()
        {
            
            DraftsLink.Click();
        }

        public void IsEmailSaved()
        {
            Console.WriteLine((System.Configuration.ConfigurationSettings.AppSettings["EmailAddress"]) + " " + DraftsEmail.Text);
            Assert.That((System.Configuration.ConfigurationSettings.AppSettings["EmailAddress"]).CompareTo(DraftsEmail.Text) == 0);
            string subj = Utils.CommonMethods.StringTrim(DraftsSubject.Text, DraftsMailBody.Text);
            Assert.AreEqual((System.Configuration.ConfigurationSettings.AppSettings["EmailSubject"]), subj, "Subject is not found");
        }
    }
}
