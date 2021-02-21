using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BerteloSteen_Automation_.BOS_Test_Utils
{
   public  static class CustomLib
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

        public static IWebElement FluentWaitbyXPath(IWebDriver driver , string elementName)
        {
            try{ 
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.IgnoreExceptionTypes(typeof(ElementNotVisibleException));
            IWebElement searchElementbyXPath = fluentWait.Until(x => x.FindElement(By.XPath(elementName)));
            return searchElementbyXPath;
                
            }
            catch(Exception e)
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
                fluentWait.Timeout = TimeSpan.FromSeconds(5);
                
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
                fluentWait.Timeout = TimeSpan.FromSeconds(5);
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

        public static void Highlightelement( this IWebElement element)
        {
            ((IJavaScriptExecutor)Drive.driver).ExecuteScript("arguments[0].style.border ='1px solid black'", element);
            Thread.Sleep(2500);
            ((IJavaScriptExecutor)Drive.driver).ExecuteScript("arguments[0].style.border ='1px solid white'", element);
            ((IJavaScriptExecutor)Drive.driver).ExecuteScript("arguments[0].style.background ='Grey'", element);
        }
      
        public static void HandleCalendar(this string month , string year , string selectdate)
        {
            string month_Selector = "body > div:nth-child(11) > div.xdsoft_datepicker.active > div.xdsoft_mounthpicker > div.xdsoft_label.xdsoft_month > span";
            string year_Selector = "body > div:nth-child(11) > div.xdsoft_datepicker.active > div.xdsoft_mounthpicker > div.xdsoft_label.xdsoft_year > span";
            string nextBtn = "body > div:nth-child(11) > div.xdsoft_datepicker.active > div.xdsoft_mounthpicker > button.xdsoft_next";
            string dateTable = "body > div:nth-child(11) > div.xdsoft_datepicker.active > div.xdsoft_calendar";
            
            while ( Drive.driver.FindElement(By.CssSelector(month_Selector)).Text.Contains(month) && Drive.driver.FindElement(By.CssSelector(year_Selector)).Text.Contains(year))
            {
                System.Threading.Thread.Sleep(2000);
                Drive.driver.FindElement(By.CssSelector(nextBtn)).Click();

            }

            // converting webelement to list of webelement
            List<string> dates = new List<string>();
            ReadOnlyCollection<IWebElement> Datetable = Drive.driver.FindElements(By.CssSelector(dateTable));

            foreach (IWebElement date in Datetable)
            {
                if (date.Text.Length > 0)
                {
                    if (date.Text.Contains(selectdate))
                    {
                        dates.Add(date.Text);
                        date.Click();

                    }

                }

            }
        }


    }
}
