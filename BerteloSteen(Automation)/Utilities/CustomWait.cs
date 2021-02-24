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

        public static void WaitFortheLoadingIconDisappear2000()
        {
            System.Threading.Thread.Sleep(2000);
        }

        public static void WaitFortheLoadingIconDisappear1000()
        {
            System.Threading.Thread.Sleep(1000);
        }


        
        [FindsBy(How = How.XPath, Using = "//div[@class ='loading x32']")]
        public static List<IWebElement> PageLoading { get; set; }


        public static void waitforPageLoader(this int seconds)
        {
            int i = 0;
            while (PageLoading.Count()!= 0 && i < 10)
            {
                System.Threading.Thread.Sleep(seconds*500);
                i++;
            }
        }

        public static IWebElement FluentWaitbyXPath(IWebDriver driver, string elementName)
        {
            try
            {
                DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(Drive.driver);
                fluentWait.Timeout = TimeSpan.FromSeconds(1.5);
                fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
                fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                fluentWait.IgnoreExceptionTypes(typeof(ElementNotVisibleException));
                IWebElement searchElementbyXPath = fluentWait.Until(x => x.FindElement(By.XPath(elementName)));
                return searchElementbyXPath;

            }
            catch (Exception e)
            {
                Debug.WriteLine("Some Error:" + e.Message);
                return null;

            }
        }


        public static IWebElement FluentWaitbyName(IWebDriver driver, string elementName)
        {
            try
            {
                DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
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


        public static IWebElement FluentWaitbyCSS(IWebDriver driver, string elementName)
        {
            try
            {
                DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
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
