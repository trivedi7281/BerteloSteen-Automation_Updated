using BerteloSteen_Automation_.BOS_GETSET;
using BerteloSteen_Automation_.BOS_Test_Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using Protractor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BerteloSteen_Automation_.BOS_PageObjects
{
    class Mechanics
    {
        [Obsolete]
        public Mechanics()
        {
            PageFactory.InitElements(Drive.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='engli']")]
        public IWebElement engLanguage { get; set; }


        [FindsBy(How = How.CssSelector, Using = "#darsdealer\\  > a")]
        public IWebElement clickonDARS { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='darsdealer-submenu ']/ul[2]/li[2]/a")]
        public IWebElement clickonMechanicsTab { get; set; }

        CustomLib Stop = new CustomLib();
        /// <summary>
        /// Navigate to Mechanics
        /// :Click on DARS Tab>> Click on Mechanics Tab in Workshop setting
        /// </summary>
        public void ClickonDARS()
        {
            Stop.WaitFortheLoadingIconDisappear20000();
            Drive.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            engLanguage.Clicks();
            //Click on DARS Tab
            Stop.WaitFortheLoadingIconDisappear15000();
            clickonDARS.Click();
            Drive.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Stop.WaitFortheLoadingIconDisappear20000();
            clickonMechanicsTab.Click();
            
        }
        /// <summary>
        /// Verify the Page Title
        /// : As module wise we entered into the different modules 
        /// so we can verify its title's.
        /// </summary>
        public void GetPageTitle()
        {
            Stop.WaitFortheLoadingIconDisappear15000();
            String title = Drive.driver.Title;
            if (title == "Mechanics")
            {
                Console.WriteLine("Title is:" + title);
                Assert.AreEqual("Mechanics", title);
            }
            else
            {
                Console.WriteLine("Title is:" + title);
                Assert.AreEqual("Mekanikere", title);
            }
        }


        [FindsBy(How = How.XPath, Using = "//input[@id = 'mat-input-5']")]
        public IWebElement selectDealers { get; set; }

        //Here this xpath have been changed as per we select any other dealer
        [FindsBy(How = How.XPath, Using = "//*[@id='1']")]
        public IWebElement EnteredselectedDealer { get; set; }

        //Again Verify with another Dealer ID
        [FindsBy(How = How.XPath, Using = "//*[@id='109']")]
        public IWebElement EnteredselectedDealer2 { get; set; }

        


        /// <summary>
        /// Select Dealer
        /// : here we can check the functionality that once we click on 
        /// dealer dropdown and then enter entry on it and select that dealer.
        /// </summary>
        /// <param name="dealerName"></param>
        public void SelectDealer(string dealerName)
        {
            Stop.WaitFortheLoadingIconDisappear10000();
            selectDealers.Clear();
            Thread.Sleep(2000);
            selectDealers.SendKeys(dealerName);
            EnteredselectedDealer.Clicks();
            Stop.WaitFortheLoadingIconDisappear2000();
            selectDealers.Clear();
            Stop.WaitFortheLoadingIconDisappear2000();
            selectDealers.SendKeys(dealerName);
            Stop.WaitFortheLoadingIconDisappear5000();
            EnteredselectedDealer2.Clicks();

        }

        
        [FindsBy(How = How.XPath, Using = "//*[@id='mat - input - 10']")]
        public IWebElement ClickOnSearchBar { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='searchButton']")]
        public IWebElement ClickOnSearchBtn { get; set; }
        
        public void SearchBar(String SearchItem)
        {
            ClickOnSearchBar.SendKeys(SearchItem);
            ClickOnSearchBtn.Click();
            ClickOnSearchBar.Clear();
        }
    }
}
