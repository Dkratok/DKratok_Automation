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
    public class MailingPageTests : BaseTest
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(MailingPageTests));
        // Verification whether the email has been saved as draft
        [Test]
        public void IsSavedasDraft()
        {
            XmlConfigurator.Configure();
            Pages.LoginPage loginpage = new Pages.LoginPage(driver);
            Pages.MailingPage mailingpage = new Pages.MailingPage(driver);

            try
            {
                loginpage.OpenPage();
                loginpage.Login((System.Configuration.ConfigurationSettings.AppSettings["UserName"]), (System.Configuration.ConfigurationSettings.AppSettings["Password"]));
                logger.Info("Login page is opening");

            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e.ToString());
                logger.Error(e.ToString());
            }
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            mailingpage.WriteNewMail();
            logger.Info("New email is writting");

            Utils.TakeScreenshot.Take_Screenshot(driver);

            mailingpage.DraftsLink.Click();
            logger.Info("DraftsLink is clicked");

            Utils.TakeScreenshot.Take_Screenshot(driver);
            Console.WriteLine((System.Configuration.ConfigurationSettings.AppSettings["EmailAddress"]) + " " + mailingpage.DraftsEmail.Text);
            Assert.That((System.Configuration.ConfigurationSettings.AppSettings["EmailAddress"]).CompareTo(mailingpage.DraftsEmail.Text) == 0);
            string subj = Utils.CommonMethods.StringTrim(mailingpage.DraftsSubject.Text, mailingpage.DraftsMailBody.Text);
            Assert.AreEqual((System.Configuration.ConfigurationSettings.AppSettings["EmailSubject"]), subj, "Subject is not found");
            Utils.TakeScreenshot.Take_Screenshot(driver);
            logger.Info("New email is created and saved as draft");
        }
      
    }
}
