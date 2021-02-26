using DARS.Automation_.Helper;
using DARS.Automation_.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DARS.Automation_.PageObjectsModels.Workshop_settings
{
    class Dealer_Service
    {
        [Obsolete]
        public Dealer_Service() => PageFactory.InitElements(Drive.driver, this);

        [FindsBy(How = How.XPath, Using = "//ul/li[@id='engli']/a")]
        public IWebElement engLanguage { get; set; }


        [FindsBy(How = How.CssSelector, Using = "#darsdealer\\  > a")]
        public IWebElement clickonDARS { get; set; }


        [FindsBy(How = How.XPath, Using = "//li[@id='darsdealer ']")]
        public IWebElement DARSHighlight { get; set; }


        [FindsBy(How = How.XPath, Using = "//a[@href='/en-US/Administration/DealerService/List']")]
        public IWebElement clickonDealerServiceTab { get; set; }


        public void ClickonDARS()
        {
            Drive.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            CustomWait.FluentWaitbyXPath(Drive.driver, "engLanguage");
            CustomLib.Highlightelement(engLanguage);
            engLanguage.Clicks();
            //Click on DARS Tab
            CustomLib.Highlightelement(DARSHighlight);
            CustomWait.FluentWaitbyXPath(Drive.driver, "clickonDARS");
            clickonDARS.Click();
            CustomWait.FluentWaitbyXPath(Drive.driver, "clickonMyDealerTab");
            CustomLib.Highlightelement(clickonDealerServiceTab);
            clickonDealerServiceTab.Clicks();

        }
        /// <summary>
        /// Verify the Page Title
        /// : As module wise we entered into the different modules 
        /// so we can verify its title's.
        /// </summary>
        public void GetPageTitle()
        {
            CustomWait.FluentWaitbyXPath(Drive.driver, "clickonDealerServiceTab");
            string title = Drive.driver.Title;
            Console.WriteLine("Title is:" + title);
            Assert.AreEqual("Dealer service", title);
        }










    }
}
