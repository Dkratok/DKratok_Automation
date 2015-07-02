using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;

namespace Module6_3.SpecFlow
{
    [Binding]
    public class StepsBinding : Tests.BaseTest
    {


        static IWebDriver _driver = Init();
        Steps steps = new Steps(_driver);

        [Given(@"I have opened Login Page")]
        public void LoginPageOpen()
        {

            _driver.Navigate().GoToUrl("https://mail.ru/");
        }

        [Given(@"I have input Login")]
        public void InputLogin()
        {
            steps.InputLogin();
        }

        [Given(@"I have input Password")]
        public void InputPW()
        {
            steps.InputPW();
        }

        [Given(@"I have input Password not correct")]
        public void InputPW_notCorrect()
        {
            steps.InputPW_notCorrect();
        }

        [Given(@"I have selected domain")]
        public void DomainSelect()
        {
            steps.DomainSelect();
        }

        [When(@"I press Sign In button")]
        public void SigninPress()
        {
            steps.SigninPress();
        }

        [Then(@"Mailing Page is opened")]
        public void MailPageOpened()
        {

            steps.MailPageOpened();
        }

        [Then(@"Mailing Page is not opened")]
        public void MailPagenotOpened()
        {
            steps.MailPagenotOpened();
        }


        //***************************************************************

        [When(@"I have clicked ""(.*)"" button")]
        public void WhenIHaveClickedNewEmailButton(string p0)
        {
            steps.NewEmailButtonClick();
        }

        [When(@"I have filled Address_field with Email Address")]
        public void WhenIHaveFilledAddress_FieldWithEmailAddress(Table table)
        {
            foreach (var row in table.Rows)
            {
                var address = row["Email"];
                steps.Input_AddressField(address);
            }

        }


        [When(@"I have filled Subject field with Subject")]
        public void WhenIHaveFilledSubjectFieldWithSubject(Table table)
        {
            foreach (var row in table.Rows)
            {
                var subject = row["Subject"];
                steps.Input_Subject(subject);
            }
        }

        [When(@"I have filled Body field with Text")]
        public void WhenIHaveFilledBodyFieldWithText(Table table)
        {

            foreach (var row in table.Rows)
            {
                _driver.SwitchTo().Frame(_driver.FindElement(By.CssSelector("iframe[title='{#aria.rich_text_area}']")));
                var text = row["Text"];
                steps.Input_Text(text);
                _driver.SwitchTo().DefaultContent();
            }

        }

        [When(@"I have clicked ""(.*)"" button")]
        public void WhenIHaveClickedSaveButton()
        {
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));        
            steps.SaveEmailButtonClick();
            System.Threading.Thread.Sleep(5000);
        }


        [When(@"I have navigated to Drafts section")]
        public void WhenIHaveNavigatedToDraftsSection()
        {
            try { driver.SwitchTo().Alert().Accept(); }
            catch (Exception) { }
            steps.DraftsMailsClick();
        }

        [Then(@"created email is visible in Drafts section")]
        public void ThenCreatedEmailIsVisibleInDraftsSection()
        {
            steps.IsEmailSaved();
        }

    }
}

