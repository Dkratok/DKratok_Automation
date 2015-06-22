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
    public class MailingPageTests : BaseTest
    {

        // Verification whether the email has been saved as draft
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

        // Verification of opened email - it should contain all information that was input during creation
        [Test]
        public void MailOpen()
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
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            mailingpage.DraftsLink.Click();
            System.Threading.Thread.Sleep(3000);
            mailingpage.DraftsMail.Click();
            Assert.That((System.Configuration.ConfigurationSettings.AppSettings["EmailAddress"]).CompareTo(mailingpage.MailOpenAddress.Text) == 0);
            Console.WriteLine(mailingpage.MailOpenSubj.GetAttribute("value").ToString() + (System.Configuration.ConfigurationSettings.AppSettings["EmailSubject"])); //Displays values of both parts of the comparison below
            Assert.AreEqual((System.Configuration.ConfigurationSettings.AppSettings["EmailSubject"]), mailingpage.MailOpenSubj.GetAttribute("Value").ToString(), "Subject is not found"); //Failed for some reasons
            driver.SwitchTo().Frame(mailingpage.ElementItemFrame);
            Console.WriteLine(mailingpage.MailOpenText.Text + (System.Configuration.ConfigurationSettings.AppSettings["EmailText"])); //Displays values of both parts of the comparison below
            Assert.That((System.Configuration.ConfigurationSettings.AppSettings["EmailText"]).CompareTo(mailingpage.MailOpenText.GetAttribute("value").ToString()) == 0); //Failed for some reasons
            driver.SwitchTo().DefaultContent();
        }
        [Test]

        // Verification of sent email
        //Before test running all emails from previous tests should be deleted from Drafts.
        public void IsSent()
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
            System.Threading.Thread.Sleep(3000);
            mailingpage.SendEmailBtn.Click();
            System.Threading.Thread.Sleep(8000);
            mailingpage.DraftsLink.Click();
            System.Threading.Thread.Sleep(3000);
            Assert.IsTrue((mailingpage.DraftsEmail.Text != (System.Configuration.ConfigurationSettings.AppSettings["EmailAddress"])) && (mailingpage.DraftsSubject.Text != (System.Configuration.ConfigurationSettings.AppSettings["EmailSubject"])));
            mailingpage.SentMailsLink.Click();
            Console.WriteLine(mailingpage.SentSubject.Text + " " + mailingpage.SentMailBody.Text);
            string sentSubj = Utils.CommonMethods.StringTrim(mailingpage.SentSubject.Text, mailingpage.SentMailBody.Text); //Failed because WD does not find SentSubject and SentMailBody
            Console.WriteLine(mailingpage.SentEmail.Text + (System.Configuration.ConfigurationSettings.AppSettings["EmailAddress"]) + "\r\n" + sentSubj + (System.Configuration.ConfigurationSettings.AppSettings["EmailSubject"]));
            Assert.IsTrue((mailingpage.SentEmail.Text == (System.Configuration.ConfigurationSettings.AppSettings["EmailAddress"])) && (sentSubj == (System.Configuration.ConfigurationSettings.AppSettings["EmailSubject"])));
            mailingpage.LogOutLink.Click();
        }
    }
}
