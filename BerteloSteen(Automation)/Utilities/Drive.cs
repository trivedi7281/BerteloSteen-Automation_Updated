using OpenQA.Selenium;
using Protractor;


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


    
        
         
        
    
