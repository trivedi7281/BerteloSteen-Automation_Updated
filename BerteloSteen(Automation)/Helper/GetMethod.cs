using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DARS.Automation_.Helper
{
    public static class GetMethod
    {
        public static string GetText(this IWebElement element)
        {

            return element.GetAttribute("value");

        }

        public static string GetDropDownValue(this IWebElement element)
        {

            return new SelectElement(element).AllSelectedOptions.SingleOrDefault().Text;

        }

    }
}
