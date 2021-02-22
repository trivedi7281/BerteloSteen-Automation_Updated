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
            ((IJavaScriptExecutor)Drive.driver).ExecuteScript("arguments[0].style.border ='1px solid black';", element);
            Thread.Sleep(2500);
            ((IJavaScriptExecutor)Drive.driver).ExecuteScript("arguments[0].style.border ='1px solid white';", element);
            ((IJavaScriptExecutor)Drive.driver).ExecuteScript("arguments[0].style.background ='Grey';", element);
        }
      
        public static void HandleCalendar(this string month , string selectdate)
        {
            //string MonthDDSelector = "(//div[@class = 'xdsoft_label xdsoft_month'])[1]";
            //string month_Selector = "(//div[@class = 'xdsoft_option ' and @data-value = 'month_Number'])[1]"; // month will be in Number
            //string year_Selector = "(//div[@class='xdsoft_option ' and @data-value='Year_Number'])[1]"; //year selection in Number
            string nextBtn = " (//button[@class = 'xdsoft_next'])[1]";
            string dateTable = "(//div[@class= 'xdsoft_calendar'])[1]/table/tbody/tr/td"; //Dates in Number
            // here we can make a dynamic month for search and select.
            string beforespanmonth = "(//div[@class = 'xdsoft_label xdsoft_month'])[1]/span"; //Month in SpanTag
            //string afterspanmonth = "')]";
            //string forMonth = beforespanmonth + month + afterspanmonth;
            // here we can make a dynamic year for search and select.
            //string beforespanyear = "(//div[@class = 'xdsoft_label xdsoft_year'])[1]/span"; //Month in SpanTag
            //string afterspanyear = "')]";
            //string foryear = beforespanyear + year + afterspanyear;


            while (Drive.driver.FindElement(By.XPath(beforespanmonth)).Text.Contains(month))
            {
                System.Threading.Thread.Sleep(2000);
                Drive.driver.FindElement(By.XPath(nextBtn)).Click();

            }

            // converting webelement to list of webelement
            List<string> dates = new List<string>();
            ReadOnlyCollection<IWebElement> Datetable = Drive.driver.FindElements(By.XPath(dateTable));

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
