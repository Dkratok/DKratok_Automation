using OpenQA.Selenium;

namespace WebDriver_Task3.Pages
{
    public abstract class BasePage
    {
        IWebDriver driver;

        public bool IsElementPresent(By locator)    
        {
            return driver.FindElements(locator).Count > 0;
        }

        public abstract void OpenPage();
    }
}
