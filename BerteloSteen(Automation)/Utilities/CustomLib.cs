using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;

namespace DARS.Automation_.Utilities
{
    public static class CustomLib
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

      
        public static void Highlightelement(this IWebElement element)
        {
           IJavaScriptExecutor js = (IJavaScriptExecutor)Drive.driver;
           js.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);",element, "color: #00FFFF; border:2px solid black;");
        }

        public static void HandleCalendar(this string month, string selectdate)
        {
            string Beforedate = "(//div[@class='xdsoft_calendar'])[1]/table/tbody[1]/tr/td[@data-date='+"; //Dates in Number
            string AfterDate = "+']/div";//Dates in Number
                                         // here we can make a dynamic month for search and select.
            string WantMonth = "(//div[@class ='xdsoft_label xdsoft_month'])[1]/span"; //Month in SpanTag
            string nextBtn = "(//button[@class ='xdsoft_next'])[1]";

            while (!Drive.driver.FindElement(By.XPath(WantMonth)).Text.Contains(month))
            {

                Drive.driver.FindElement(By.XPath(nextBtn)).Click();
                break;

            }
            for (int i = 0; i <= 31; i++)
            {
                string ActualXpath = Beforedate + i + AfterDate;
                IWebElement element = Drive.driver.FindElement(By.XPath(ActualXpath));
                Console.WriteLine(element.Text);
                if (element.Text.Equals(selectdate))
                {
                    Actions action = new Actions(Drive.driver);
                    Thread.Sleep(1000);
                    action.MoveToElement(element).Click(element).Build().Perform();
                    break;
                }
            }


        }


        public static void CheckBoxesList()
        {
            ReadOnlyCollection<IWebElement> Checklist = Drive.driver.FindElements(By.XPath("(//div[contains(@class,'input-field')]/input[@type='checkbox'])"));
            int checkcount = 0;
            int uncheckcount = 0;
            int disablecount = 0;


            foreach (var chklist in Checklist)
            {
                if (chklist.Selected == true)
                {
                    checkcount++;
                    System.Threading.Thread.Sleep(1000);
                }
                else
                {
                    uncheckcount++;
                    disablecount++;
                    System.Threading.Thread.Sleep(1000);

                }
                Console.WriteLine("Number of Checked Checkboxes are :" + checkcount);
                Console.WriteLine("Number of UnChecked Checkboxes are :" + uncheckcount);
                Console.WriteLine("Number of disable Checkboxes are :" + disablecount);

            }

        }
    }
}
