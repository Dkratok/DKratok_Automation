using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;

namespace AppTest.Pages
{
    [TestFixture]
    class MailingPage : LoginPage
    {
        public By CreateEmailBtn = By.XPath(".//*[@id='b-toolbar__left']/div/div/div[2]/div/a/span");
        public By AdresseeField = By.XPath(".//*[@id='compose__header__content']/div[2]/div[2]/div[1]/textarea");
        public By SubjectField = By.Name("Subject");
        public By MailBodyFrame = By.XPath("//iframe[contains(@title,'{#aria.rich_text_area}')]");
        public By BodyField = By.Id("tinymce");
        public By SavetoDraftBtn = By.CssSelector("div[title='Сохранить']");
        public By DraftsLink = By.XPath(".//*[@id='b-nav_folders']/div/div[3]/a/span");
        public By DraftsEmail = By.XPath("//div[@class='b-datalists']/div[3]/div/div[2]/div[1]/div/a/div[4]/div[3]/div[2]");
        public By DraftsSubject = By.XPath("//div[@class='b-datalists']/div[3]/div/div[2]/div[1]/div/a/div[4]/div[3]/div[1]");
        public By DraftsMailBody = By.XPath("//div[@class='b-datalists']/div[3]/div/div[2]/div[1]/div/a/div[4]/div[3]/div[1]/Span");
        public By DraftsMail = By.XPath("//*[@class='b-datalist__item js-datalist-item'][1]//a");
        public By MailOpenAddress = By.XPath("//div[@class='compose__header__field__box']/div[1]/span[3]/span");
        public By MailOpenSubj = By.Name("Subject");
        public By MailOpenText = By.ClassName("mceContentBody");
        public By SendEmailBtn = By.CssSelector("div[title='Отправить']");
        public By SentMailsLink = By.XPath(".//*[@id='b-nav_folders']/div/div[2]/a/span");
        public By SentEmail = By.XPath("//div[@class='b-datalists']/div[3]/div/div[2]/div[1]/div/a/div[4]/div[3]/div[2]");
        public By SentSubject = By.XPath("//div[@class='b-datalists']/div[3]/div/div[2]/div[1]/div/a/div[4]/div[3]/div[1]");
        public By SentMailBody = By.XPath("//div[@class='b-datalists']/div[3]/div/div[2]/div[1]/div/a/div[4]/div[3]/div[1]/Span");
        public By LogOutLink = By.Id("PH_logoutLink");


        
      
        public void WriteNewMail ()
        {
            
            GetElement(driver, CreateEmailBtn).Click();
            GetElement(driver, AdresseeField).Clear();
            GetElement(driver, AdresseeField).SendKeys(TestData.EmailAddress);
            GetElement(driver, SubjectField).Clear();
            GetElement(driver, SubjectField).SendKeys(TestData.EmailSubject);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.SwitchTo().Frame(GetElement(driver, MailBodyFrame));
            GetElement(driver, BodyField).Clear();
            GetElement(driver, BodyField).SendKeys(TestData.EmailText);
            driver.SwitchTo().DefaultContent();
            GetElement(driver, SavetoDraftBtn).Click();
        }

        // Verification whether the email has been saved as draft
        [Test]
        public void IsSavedasDraft()
        {
            try
            {
                Login();
            }
            catch (NoSuchElementException)
            { }
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));  
            WriteNewMail();
            GetElement(driver, DraftsLink).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            Assert.That(TestData.EmailAddress.CompareTo(GetElement(driver, DraftsEmail).Text) == 0);
            string subj = CommonMethods.StringTrim(GetElement(driver, DraftsSubject).Text, GetElement(driver, DraftsMailBody).Text);
            Assert.AreEqual(TestData.EmailSubject, subj, "Subject is not found");
        }

        // Verification of opened email - it should contain all information that was input during creation
        [Test]
        public void MailOpen()
        {
            try
            {
                Login();
            }
            catch (NoSuchElementException)
            { }
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            WriteNewMail();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));    
            GetElement(driver, DraftsLink).Click();
            System.Threading.Thread.Sleep(3000);
            GetElement(driver, DraftsMail).Click();          
            Assert.That(TestData.EmailAddress.CompareTo(GetElement(driver, MailOpenAddress).Text) == 0);
            Console.WriteLine(GetElement(driver, MailOpenSubj).GetAttribute("value").ToString() + TestData.EmailSubject); //Displays values of both parts of the comparison below
            Assert.AreEqual(TestData.EmailSubject, GetElement(driver, MailOpenSubj).GetAttribute("Value").ToString(), "Subject is not found"); //Failed for some reasons
            driver.SwitchTo().Frame(GetElement(driver, MailBodyFrame));
            Console.WriteLine(GetElement(driver, MailOpenText).Text + TestData.EmailText); //Displays values of both parts of the comparison below
            Assert.That(TestData.EmailText.CompareTo(GetElement(driver, MailOpenText).GetAttribute("value").ToString()) == 0); //Failed for some reasons
            driver.SwitchTo().DefaultContent();
        }
        [Test]

        // Verification of sent email
        //Before test running all emails from previous tests should be deleted from Drafts.
        public void IsSent()
        {
            try
            {
                Login();
            }
            catch (NoSuchElementException)
            { }
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            WriteNewMail();         
            System.Threading.Thread.Sleep(3000);
            GetElement(driver, SendEmailBtn).Click();
            System.Threading.Thread.Sleep(8000);
            GetElement(driver, DraftsLink).Click();
            System.Threading.Thread.Sleep(3000);
            Assert.IsTrue((GetElement(driver, DraftsEmail).Text!=TestData.EmailAddress) && (GetElement(driver, DraftsSubject).Text!=TestData.EmailSubject));
            GetElement(driver, SentMailsLink).Click();         
            string sentSubj = CommonMethods.StringTrim(GetElement(driver, SentSubject).Text, GetElement(driver, SentMailBody).Text); //Failed because WD does nor find SentSubject and SentMailBody
            Console.WriteLine(GetElement(driver, SentEmail).Text + TestData.EmailAddress + "\r\n" + sentSubj + TestData.EmailSubject);
            Assert.IsTrue((GetElement(driver, SentEmail).Text == TestData.EmailAddress) && (sentSubj == TestData.EmailSubject));
            GetElement(driver, LogOutLink).Click();  
        }

        [TearDown]
        public void Teardown()
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
