using BerteloSteen_Automation_.BOS_GETSET;
using BerteloSteen_Automation_.BOS_Test_Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;


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
        public IWebElement EngLanguage { get; set; }

        
       
        public void GetDetails()
        {
            CustomLib.FluentWaitbyXPath(Drive.driver , "EngLanguage");
            EngLanguage.Clicks();
            CustomLib.FluentWaitbyXPath(Drive.driver, "EngLanguage");
            string title = Drive.driver.Title;
            Console.WriteLine("Title is:" + title);
            Assert.AreEqual("Appointment", title);
            string Url = Drive.driver.Url;
            Console.WriteLine("URL is:" + Url);
            //string pageSource = Drive.driver.PageSource;
            //Console.WriteLine("PageSource is:" + pageSource);
        }

    }
}
