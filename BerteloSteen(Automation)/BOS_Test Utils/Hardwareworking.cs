using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerteloSteen_Automation_.BOS_Test_Utils
{
    public static class Hardwareworking
    {

        public static void Hover(IWebElement element)
        {
            Actions action = new Actions(Drive.driver);
            System.Threading.Thread.Sleep(2000);
            action.MoveToElement(element).Click().Build().Perform();
            
        }
    }
}
