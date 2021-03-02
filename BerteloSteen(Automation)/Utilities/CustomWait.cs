using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DARS.Automation_.Utilities
{
   public static class CustomWait
    {
        public static void WaitFortheLoadingIconDisappear10000()
        {
            System.Threading.Thread.Sleep(10000);
        }

        public static void WaitFortheLoadingIconDisappear5000()
        {
            System.Threading.Thread.Sleep(5000);
        }
        public static void WaitFortheLoadingIconDisappear3000()
        {
            System.Threading.Thread.Sleep(3000);
        }

        public static void WaitFortheLoadingIconDisappear2000()
        {
            System.Threading.Thread.Sleep(2000);
        }

        public static void WaitFortheLoadingIconDisappear1000()
        {
            System.Threading.Thread.Sleep(1000);
        }


        public static void WaitforcompletePageLoad()
        {
            Boolean ele = Drive.driver.FindElement(By.XPath("//*[@class='d-block fade modal show']//div[@class='loading_wrp']//img")).Displayed;
            IJavaScriptExecutor js = (IJavaScriptExecutor)Drive.driver;
            for (int i=1; i<=60; i++)
            {
                try
                {
                    System.Threading.Thread.Sleep(1000);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
                if (js.ExecuteScript("return document.readyState").ToString().Equals("complete"))
                {
                    Console.WriteLine("Page is loaded Completely");
                    
                }
                else if(!ele)
                {
                    Console.WriteLine("PageLoader is loaded Completely");
                    break;
                }
                else
                {
                    Console.WriteLine("Page loader is Running" + i);
                }
            }
            
        }







     

        public static IWebElement FluentWaitbyXPath(this string element)
        {
            try
            {
                DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(Drive.driver);
                fluentWait.Timeout = TimeSpan.FromSeconds(1.5);
                fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
                fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                fluentWait.IgnoreExceptionTypes(typeof(ElementNotVisibleException));
                IWebElement searchElementbyXPath = fluentWait.Until(x => x.FindElement(By.XPath(element)));
                return searchElementbyXPath;

            }
            catch (Exception e)
            {
                Debug.WriteLine("Some Error:" + e.Message);
                return null;

            }
        }

      
        public static IWebElement FluentWaitbyName(this string elementName)
        {
            try
            {
                Drive.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(Drive.driver);
                fluentWait.Timeout = TimeSpan.FromSeconds(1.5);

                fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
                fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                fluentWait.IgnoreExceptionTypes(typeof(ElementNotVisibleException));
                IWebElement searchElementbyName = fluentWait.Until(x => x.FindElement(By.Name(elementName)));
                return searchElementbyName;

            }
            catch (Exception e)
            {
                Debug.WriteLine("Some Error:" + e.Message);
                return null;
            }
        }


        public static IWebElement FluentWaitbyCSS(this string elementName)
        {
            try
            {
                Drive.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(Drive.driver);
                fluentWait.Timeout = TimeSpan.FromSeconds(1.5);
                fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
                fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                fluentWait.IgnoreExceptionTypes(typeof(ElementNotVisibleException));
                IWebElement searchElementbyCSS = fluentWait.Until(x => x.FindElement(By.CssSelector(elementName)));
                return searchElementbyCSS;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Some Error:" + e.Message);
                return null;
            }
        }

    }
}
