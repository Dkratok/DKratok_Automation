using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriver_Task2.Utils
{
    public class CommonMethods
    {
        public static string StringTrim(string string1, string string2)
        {
            string trimmedString = string1.Remove(string1.Length - string2.Length);
            return trimmedString;
        }
    }
}
