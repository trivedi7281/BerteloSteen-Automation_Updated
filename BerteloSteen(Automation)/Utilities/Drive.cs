using OpenQA.Selenium;
using Protractor;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DARS.Automation_.Utilities
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


    
        
         
        
    
