using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.IE;

namespace AppTest
{
    public class CommonMethods

    {      
        //the method below takes 2 strings, the second one should be the end of first one (e.g. "automobile" and "mobile"). The method returns the difference ("auto")
        public static string StringTrim(string string1, string string2)
        {
            string trimmedString = string1.Remove(string1.Length - string2.Length);
            return trimmedString;
        }
    }
}
