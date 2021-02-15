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

        
        CustomLib Stop = new CustomLib();
        [Obsolete]
        public void GetDetails()
        {
            Stop.WaitFortheLoadingIconDisappear20000();
            Drive.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            engLanguage.Clicks();
            Stop.WaitFortheLoadingIconDisappear10000();
            Drive.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            String title = Drive.driver.Title;
            if (title == "Appointment")
            {
                Console.WriteLine("Title is:" + title);
                Assert.AreEqual("Appointment", title);
                Assert.That(Drive.driver.PageSource.Contains(title),Is.EqualTo("Appointment"), "Bug: The title is not correct! Priority:Medium & Severity:Medium");
            }
            else
            {
                Console.WriteLine("Title is:" + title);
                Assert.AreEqual("Verkstedordre", title);
            }
            String Url = Drive.driver.Url;
            Console.WriteLine("URL is:" + Url);
            //String pageSource = Drive.driver.PageSource;
            //Console.WriteLine("PageSource is:" + pageSource);

        }

    }
}
