using System;
using OpenQA.Selenium;
using NUnit.Framework;

namespace AppTest
{
    public class WebControl
    {
        public IWebElement GetElement(IWebDriver Driver, By element)
        {
            try
            {
                return Driver.FindElement(element);
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
