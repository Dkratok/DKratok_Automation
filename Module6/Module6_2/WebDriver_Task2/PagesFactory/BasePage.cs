using OpenQA.Selenium;

namespace Module6_2.PagesFactory
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
