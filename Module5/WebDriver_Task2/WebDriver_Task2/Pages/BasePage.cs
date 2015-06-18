using OpenQA.Selenium;

namespace WebDriver_Task2.Pages
{
    public abstract class BasePage
    {
        public bool IsElementPresent(By locator)    
        {
            return Driver.DriverInstance.GetInstance().FindElements(locator).Count > 0;
        }

        public abstract void OpenPage();
    }
}
