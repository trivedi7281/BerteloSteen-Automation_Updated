using BerteloSteen_Automation_.BOS_GETSET;
using BerteloSteen_Automation_.BOS_Test_Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BerteloSteen_Automation_.BOS_PageObjects
{
    class GetProperties
    {
        [Obsolete]
        public GetProperties()
        {
            PageFactory.InitElements(Drive.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='engli']")]
        public IWebElement engLanguage { get; set; }


        [Obsolete]
        public void GetDetails()
        {
            Thread.Sleep(20000);
            Drive.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            engLanguage.Clicks();
            Thread.Sleep(20000);
            String title = Drive.driver.Title;
            Console.WriteLine("Title is:" + title);
            Assert.AreEqual("Appointment", title);
            String Url = Drive.driver.Url;
            Console.WriteLine("URL is:" + Url);
            //String pageSource = Drive.driver.PageSource;
            //Console.WriteLine("PageSource is:" + pageSource);

        }

    }
}
