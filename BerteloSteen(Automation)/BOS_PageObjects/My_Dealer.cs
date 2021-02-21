using BerteloSteen_Automation_.BOS_GETSET;
using BerteloSteen_Automation_.BOS_Test_Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerteloSteen_Automation_.BOS_PageObjects
{
    class My_Dealer
    {
        [Obsolete]
        public My_Dealer()
        {
            PageFactory.InitElements(Drive.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//li[@id='engli']")]
        public IWebElement engLanguage { get; set; }


        [FindsBy(How = How.CssSelector, Using = "#darsdealer\\  > a")]
        public IWebElement clickonDARS { get; set; }


        [FindsBy(How = How.XPath, Using = "//li[@id='darsdealer ']")]
        public IWebElement DARSHighlight { get; set; }



        [FindsBy(How = How.XPath, Using = "//a[@href='/en-US/Workplace/MyDealer/Index']")]
        public IWebElement clickonMyDealerTab { get; set; }


        /// <summary>
        /// Navigate to Mechanics
        /// :Click on DARS Tab>> Click on Mechanics Tab in Workshop setting
        /// </summary>

        public void ClickonDARS()
        {
            Drive.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            CustomLib.FluentWaitbyXPath(Drive.driver, "engLanguage");
            CustomLib.Highlightelement(engLanguage);
            engLanguage.Clicks();
            //Click on DARS Tab
            CustomLib.Highlightelement(DARSHighlight);
            CustomLib.FluentWaitbyXPath(Drive.driver, "clickonDARS");
            clickonDARS.Click();
            CustomLib.FluentWaitbyXPath(Drive.driver, "clickonMyDealerTab");
            CustomLib.Highlightelement(clickonMyDealerTab);
            clickonMyDealerTab.Click();

        }
        /// <summary>
        /// Verify the Page Title
        /// : As module wise we entered into the different modules 
        /// so we can verify its title's.
        /// </summary>
        public void GetPageTitle()
        {
            CustomLib.FluentWaitbyXPath(Drive.driver, "clickonMyDealerTab");
            string title = Drive.driver.Title;
            Console.WriteLine("Title is:" + title);
            Assert.AreEqual("My Dealer", title);
        }

        
      

        [FindsBy(How = How.XPath, Using = "//input[@data-placeholder='Select Dealer']")]
        public IWebElement selectDealers { get; set; }

        //Here this xpath have been changed as per we select any other dealer
        [FindsBy(How = How.XPath, Using = "//mat-option[@id='1']")]
        public IWebElement EnteredselectedDealer { get; set; }

        /// <summary>
        /// Select Dealer
        /// : here we can check the functionality that once we click on 
        /// dealer dropdown and then enter entry on it and select that dealer.
        /// </summary>
        /// <param name="DealerName"></param>
        public void SelectDealer(string DealerName, string DealerName2 = null)
        {
            CustomLib.FluentWaitbyXPath(Drive.driver, "selectDealers");
            selectDealers.Clear();
            selectDealers.SendKeys(DealerName);
            CustomLib.FluentWaitbyXPath(Drive.driver, "EnteredselectedDealer");
            EnteredselectedDealer.Click();
        
        }


     }
 }
