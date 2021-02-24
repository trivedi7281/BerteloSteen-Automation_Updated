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
        //-------------------------Highlight the Element--------------------------------------//
       
        public static void Highlightelement(this IWebElement element)
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)Drive.driver;
                js.ExecuteScript("arguments[0].setAttribute('style','border:2px solid transparent;border-image:linear-gradient(-45deg,red,yellow);border-image-slice:1;');", element);
                Thread.Sleep(1000);
                js.ExecuteScript("arguments[0].style.border='border:2px solid Grey;'", element);
                Thread.Sleep(500);
                js.ExecuteScript("arguments[0].style.border=''", element , "");

            }
            catch (Exception e)
            {
                Debug.WriteLine("Some Error:" + e.Message);
            }
        }

        //-------------------------Highlight the Element--------------------------------------//

        //-------------------------------------Handle Calender------------------------------------------//
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
                

            }
            for (int i = 1; i <= 31; i++)
            {
                string ActualXpath = Beforedate + i + AfterDate;
                IWebElement element = Drive.driver.FindElement(By.XPath(ActualXpath));
                Console.WriteLine(element.Text);
                if (element.Text.Equals(selectdate))
                {
                    Actions action = new Actions(Drive.driver);
                    Thread.Sleep(1000);
                    action.MoveToElement(element).Click(element).Build().Perform();
                    
                }
            }


        }

        //-------------------------------------Handle Calender------------------------------------------//

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
        //-------------------------------------ScreenShots------------------------------------------//

        public static void ScreenShots()
        {
            string PathToFolder = "C:\\Users\\akash.trivedi\\Source\\Repos\\BerteloSteen-Automation\\BerteloSteen(Automation)\\ScreenPrints\\";
            string fileName = PathToFolder + DateTime.Now.ToString("HHmmss") + ".jpeg";
            ITakesScreenshot ts = Drive.driver as ITakesScreenshot;
            Screenshot screenshot = ts.GetScreenshot();
            screenshot.SaveAsFile(fileName, ScreenshotImageFormat.Jpeg);

        }

        //-------------------------------------ScreenShots------------------------------------------//

        //-------------------------------------ExtentReport----------------------------------------//






        //-------------------------------------ExtentReport--------------------------------------//

    }
}
