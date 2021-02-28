using DARS.Automation_.Helper;
using DARS.Automation_.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;


namespace DARS.Automation_.PageObjectsModels.Login
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
            CustomWait.FluentWaitbyXPath("EngLanguage");
            EngLanguage.Clicks();
            CustomWait.WaitFortheLoadingIconDisappear2000();
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
