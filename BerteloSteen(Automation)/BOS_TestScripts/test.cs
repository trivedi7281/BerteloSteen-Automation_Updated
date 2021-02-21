using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerteloSteen_Automation_.BOS_TestScripts
{
    class test
    {
        public WebDriverWait waitTime;
        public IWebDriver driver;



        [TestCase]
        public void NavigateToURL()
        {
            driver = new ChromeDriver();
            //naviate to Url
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            waitTime = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            driver.Navigate().GoToUrl("https://www.goibibo.com/flights/?utm_source=SVGMedia&utm_medium=DisplayAffiliate&utm_campaign=flights_72");
            Console.WriteLine("Navigated to the 'demo Home Page' URL Sucessfully");
            IWebElement table = driver.FindElement(By.XPath("//*[@id='departureCalendar']"));
            table.Click();

            while (!driver.FindElement(By.XPath("//div[@class='DayPicker DayPicker--en']/div[2]/div[@class='DayPicker-Caption']")).Text.Contains("June 2021"))
            {
                System.Threading.Thread.Sleep(2000);
                driver.FindElement(By.XPath("//div[@class='DayPicker-NavBar']/span[@class='DayPicker-NavButton DayPicker-NavButton--next']")).Click();

            }

            // converting webelement to list of webelement
            List<string> dates = new List<string>();
            ReadOnlyCollection<IWebElement> Datetable = driver.FindElements(By.ClassName("calDate"));
            
            foreach (IWebElement date in Datetable)
            {
                if (date.Text.Length > 0)
                {
                    if (date.Text.Contains("22"))
                    {
                        dates.Add(date.Text);
                        date.Click();

                    }
                  
                }

            }
          //  driver.Quit();

        }
    }
}
