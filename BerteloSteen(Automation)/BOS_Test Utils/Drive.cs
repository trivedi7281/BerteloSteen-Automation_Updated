using OpenQA.Selenium;
using Protractor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerteloSteen_Automation_.BOS_Test_Utils
{
     class Drive
    {

        public static IWebDriver driver { get; set; }

       public static NgWebDriver ngdriver { get; set; }






        enum LocatorType
        {
            Id,
            Name,
            LinkText,
            XPath,
            CssName,
            ClassName,
            Selector
            
        }
    }
}
