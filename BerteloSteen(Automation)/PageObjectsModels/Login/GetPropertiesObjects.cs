using DARS.Automation_.GetSet;
using DARS.Automation_.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;


namespace DARS.Automation_.PageObjectsModels
{
    class GetPropertiesObjects
    {
        [Obsolete]
        public GetPropertiesObjects()
        {
            PageFactory.InitElements(Drive.driver, this);
        }



        [FindsBy(How = How.XPath, Using = "//*[@id='engli']")]
        public IWebElement EngLanguage { get; set; }



        public void GetDetails()
        {
            EngLanguage.Highlightelement();
            CustomWait.FluentWaitbyXPath(Drive.driver, "EngLanguage");
            EngLanguage.Clicks();
            CustomWait.FluentWaitbyXPath(Drive.driver, "EngLanguage");
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
