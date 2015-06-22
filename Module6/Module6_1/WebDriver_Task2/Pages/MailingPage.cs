using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Internal;

namespace WebDriver_Task2.Pages
{
    public class MailingPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "PH_user-email")] 
        public IWebElement UserNameLink;

        [FindsBy(How = How.XPath, Using = ".//*[@id='b-toolbar__left']/div/div/div[2]/div/a/span")]
        private IWebElement CreateEmailBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='compose__header__content']/div[2]/div[2]/div[1]/textarea")]
        private IWebElement AdresseeField;

        [FindsBy(How = How.Name, Using = "Subject")]
        private IWebElement SubjectField;

        [FindsBy(How = How.CssSelector, Using = "iframe[title='{#aria.rich_text_area}']")]
        public IWebElement elementItemFrame;
        

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

        [FindsBy(How = How.XPath, Using = "//div[@class='compose__header__field__box']/div[1]/span[3]/span")]
        public IWebElement MailOpenAddress;

        [FindsBy(How = How.Name, Using = "Subject")]
        public IWebElement MailOpenSubj;

        [FindsBy(How = How.ClassName, Using = "mceContentBody")]
        public IWebElement MailOpenText;

        [FindsBy(How = How.CssSelector, Using = "div[title='Отправить']")]
        public IWebElement SendEmailBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='b-nav_folders']/div/div[2]/a/span")]
        public IWebElement SentMailsLink;

        [FindsBy(How = How.XPath, Using = "//div[@class='b-datalists']/div[3]/div/div[2]/div[1]/div/a/div[4]/div[3]/div[2]")]
        public IWebElement SentEmail;

        [FindsBy(How = How.XPath, Using = "//div[@class='b-datalists']/div[3]/div/div[2]/div[1]/div/a/div[4]/div[3]/div[1]")]
        public IWebElement SentSubject;

        [FindsBy(How = How.XPath, Using = "//div[@class='b-datalists']/div[3]/div/div[2]/div[1]/div/a/div[4]/div[3]/div[1]/Span")]
        public IWebElement SentMailBody;

        [FindsBy(How = How.Id, Using = "PH_logoutLink")]
        public IWebElement LogOutLink;


        private IWebDriver driver;

        public MailingPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(System.Configuration.ConfigurationSettings.AppSettings["BaseURL"]);
            Console.WriteLine("Login Page opened");
        }

        public void WriteNewMail()
        {
            System.Threading.Thread.Sleep(5000);
            CreateEmailBtn.Click();
            System.Threading.Thread.Sleep(5000);
            AdresseeField.SendKeys(System.Configuration.ConfigurationSettings.AppSettings["EmailAddress"]);
            SubjectField.Clear();
            SubjectField.SendKeys(System.Configuration.ConfigurationSettings.AppSettings["EmailSubject"]);
            driver.SwitchTo().Frame(ElementItemFrame);
            BodyField.Clear();
            BodyField.SendKeys((System.Configuration.ConfigurationSettings.AppSettings["EmailText1"]) + "\r\n" + (System.Configuration.ConfigurationSettings.AppSettings["EmailText2"]) + "\r\n" + (System.Configuration.ConfigurationSettings.AppSettings["EmailText3"]));
            driver.SwitchTo().DefaultContent();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            SavetoDraftBtn.Click();
            System.Threading.Thread.Sleep(5000);
        }

        public void DraftsMailsClick()
        {
            DraftsLink.Click();
        }

        public void DraftsMailClick()
        {
            DraftsMail.Click();
        }

        public void SendEmailBtnClick()
        {
            SendEmailBtn.Click();
        }

        public IWebElement ElementItemFrame
        {
            get
            {
                IWrapsElement wrapper = this.elementItemFrame as IWrapsElement;
                if (wrapper != null)
                {
                    return wrapper.WrappedElement;
                }

                // You could return null, or throw an exception.
                return null;
            }
        }

    }
}
