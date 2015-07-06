using OpenQA.Selenium;

namespace Module7_1.Pages
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
