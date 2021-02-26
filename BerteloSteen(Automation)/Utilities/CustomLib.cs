using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace DARS.Automation_.Utilities
{
    public static class CustomLib
    {
        //-------------------------Highlight the Element--------------------------------------//

        public static void Highlightelement(this IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Drive.driver;
            js.ExecuteScript("arguments[0].setAttribute('style','border:1px solid transparent;border-image:linear-gradient(-45deg,red,blue,green);border-image-slice:1;');", element);
            

        }

        //-------------------------Highlight the Element--------------------------------------//

        //-------------------------------------Handle Calender------------------------------------------//
        public static void HandleCalendar(this int index, string selectMonth, string selectYear, string selectdate)
        {   
            //click on month dd 
            CustomWait.WaitFortheLoadingIconDisappear2000();
            string firstPartMonth = "(//div[@class='xdsoft_label xdsoft_month'])[";
            string secondPartMonth = "]";
            string ActualMonthField = firstPartMonth + index + secondPartMonth;
            Drive.driver.FindElement(By.XPath(ActualMonthField)).Click();
            CustomWait.WaitFortheLoadingIconDisappear2000();
            // count of Months
            string firstCountPartMonth = "(//div[@class='xdsoft_label xdsoft_month'])[";
            string secondCountPartMonth = "]//div[contains(@class,'xdsoft_option ')]";
            string ActualcountMonthPart = firstCountPartMonth + index + secondCountPartMonth;
            int CalendarMonths = Drive.driver.FindElements(By.XPath(ActualcountMonthPart)).Count();
            //select month
            string firstmonthPart = "(//div[@class='xdsoft_label xdsoft_month'])[";
            string secondmonthPart = "]//div[contains(@class , 'xdsoft_option ')and @data-value='";
            string thirdmonthPart = "']";
            for (int i = 0; i <= CalendarMonths - 1; i++)
            {
                string finalPart = firstmonthPart + index + secondmonthPart + i + thirdmonthPart;
                IWebElement SelectMonth = Drive.driver.FindElement(By.XPath(finalPart));
                ((IJavaScriptExecutor)Drive.driver).ExecuteScript("arguments[0].scrollIntoView(true);", SelectMonth);
                if (SelectMonth.Text.Equals(selectMonth))
                {
                    SelectMonth.Click();
                    break;
                }
            }
            //click on year dd 
            CustomWait.WaitFortheLoadingIconDisappear2000();
            string firstPartYear = "(//div[@class='xdsoft_label xdsoft_year'])[";
            string secondPartYear = "]";
            string ActualYearField = firstPartYear + index + secondPartYear;
            Drive.driver.FindElement(By.XPath(ActualYearField)).Click();
            // count of years
            CustomWait.WaitFortheLoadingIconDisappear2000();
            string firstCountPartyear = "(//div[@class='xdsoft_label xdsoft_year'])[";
            string secondCountPartyear = "]//div[contains(@class,'xdsoft_option ')]";
            string ActualcountyearPart = firstCountPartyear + index + secondCountPartyear;
            int CalendarYear = Drive.driver.FindElements(By.XPath(ActualcountyearPart)).Count();
            Console.WriteLine("Calender Year counts is: " + CalendarYear);
            //select year
            string firstYearPart = "(//div[@class='xdsoft_label xdsoft_year'])[";
            string secondYearPart = "]//div[contains(@class,'xdsoft_option ')][";
            string thirdYearPart = "]";
            for (int i = 70; i <= CalendarYear; i++)
            {
                string finalPart = firstYearPart + index + secondYearPart + i + thirdYearPart;
                IWebElement SelectYear = Drive.driver.FindElement(By.XPath(finalPart));
                ((IJavaScriptExecutor)Drive.driver).ExecuteScript("arguments[0].scrollIntoView(true);", SelectYear);
                if (SelectYear.Text.Equals(selectYear))
                {
                    SelectYear.Click();
                    break;
                }
            }
            CustomWait.WaitFortheLoadingIconDisappear1000();
            string RowNumbers1 = "(//div[@class='xdsoft_calendar'])[";
            string RowNumbers2 = "]/table/tbody/tr";
            string ActualRowNumbers = RowNumbers1 + index + RowNumbers2;
            int RowNumbers = Drive.driver.FindElements(By.XPath(ActualRowNumbers)).Count();
            string ColumnNumbers1 = "(//div[@class='xdsoft_calendar'])[";
            string ColumnNumbers2 = "]/table/tbody/tr[1]/td";
            string ActualColumnNumbers = ColumnNumbers1 + index + ColumnNumbers2;
            int ColumnNumbers = Drive.driver.FindElements(By.XPath(ActualColumnNumbers)).Count();
            CustomWait.WaitFortheLoadingIconDisappear1000();
            string firstPart = "(//div[@class='xdsoft_calendar'])[";
            string secondPart = "]/table/tbody/tr[";
            string thirdPart = "]/td[";
            string fourthPart = "]";
            for (int i = 1; i <= RowNumbers; i++)
            {
                for (int j = 1; j <= ColumnNumbers; j++)
                {
                    string finalPart = firstPart + index + secondPart + i + thirdPart + j + fourthPart;
                    IWebElement dates = Drive.driver.FindElement(By.XPath(finalPart));
                    if (dates.Text.Equals(selectdate))
                    {
                        dates.Click();
                        break;
                    }

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

        //-------------------------------------DeleteRecordfromMechanicLeaves----------------------------------------//

        public static void DeleteMechanicLeaves(int startDate, int endDate, int Month, int Year)
        {
            int a = Year;
            int b = Month;
            int c = startDate;
            int d = endDate;
            string firstPartition = "(//tr/td[contains(text(),'";
            string secondPartition = "')])[1]";
            string thirdPartition = "/following-sibling::td[5]//a";
            string fourthPartition = "/following-sibling::td[2]//span";
            string delConfirmBtn = "//button[@id='btnSaveComments'and @type='button']";
            DateTime begindate = new DateTime(a, b, d);
            DateTime enddate = new DateTime(a, b, c);
            for (; begindate.Date >= enddate.Date; begindate = begindate.AddDays(-1))
            {
                string date = begindate.Date.ToString("dd.MM.yyyy");
                string finalPartition = firstPartition + date + secondPartition;
                IWebElement SelectStartDate = Drive.driver.FindElement(By.XPath(finalPartition));
                //((IJavaScriptExecutor)Drive.driver).ExecuteScript("arguments[0].scrollIntoView(true);", SelectStartDate);
                if (SelectStartDate.Text.Contains(date))
                {
                    CustomWait.WaitFortheLoadingIconDisappear2000();
                    string InsSource = firstPartition + date + secondPartition + fourthPartition;
                    IWebElement SourceVerify = Drive.driver.FindElement(By.XPath(InsSource));
                    Console.WriteLine(SourceVerify.Displayed);
                    Console.WriteLine(SourceVerify.Text);
                    CustomWait.WaitFortheLoadingIconDisappear2000();
                    string finalclick = firstPartition + date + secondPartition + thirdPartition;
                    IWebElement delPencilBtn = Drive.driver.FindElement(By.XPath(finalclick));
                    delPencilBtn.Click();
                    CustomWait.WaitFortheLoadingIconDisappear5000();
                    IWebElement DelYesBtn = Drive.driver.FindElement(By.XPath(delConfirmBtn));
                    DelYesBtn.Click();
                    CustomWait.WaitFortheLoadingIconDisappear5000();

                }
            }

        }
        //-------------------------------------DeleteRecordfromMechanicLeaves--------------------------------------//

    }
}
