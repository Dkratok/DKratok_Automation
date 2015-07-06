using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using log4net;
using log4net.Config;
using System.Runtime.InteropServices;

namespace Module7_1.Utils
{
    public class TakeScreenshot
    {

        public static void Take_Screenshot(IWebDriver driver)
        {
            string DT = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile("../../Screenshots/test_" + DT + ".png", ImageFormat.Png);
        }
        //public static void HighlightElement(IWebElement element)
        //{
        //    var bg = element.GetCssValue("backgroundColor");
        //    var jsExecutor = ((IJavaScriptExecutor)DriverInstance.GetInstance());
        //    jsExecutor.ExecuteScript("arguments[0].style.backgroundColor = 'red'", element);
        //    Take_Screenshot(IWebDriver driver);
        //    jsExecutor.ExecuteScript(("arguments[0].style.backgroundColor = " + "'" + bg + "'"), element);
        //}
    }
}
