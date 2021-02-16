using BerteloSteen_Automation_.BOS_GETSET;
using BerteloSteen_Automation_.BOS_Test_Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;


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


        [FindsBy(How = How.XPath, Using = "//a[@href='/en-US/Administration/Mechanics/List']")]
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
            Stop.WaitFortheLoadingIconDisappear10000();
            clickonDARS.Click();
            Drive.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Stop.WaitFortheLoadingIconDisappear10000();
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
            string title = Drive.driver.Title;
            Console.WriteLine("Title is:" + title);
            Assert.AreEqual("Mechanics", title);
        }


        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Select Dealer']")]
        public IWebElement selectDealers { get; set; }

        //Here this xpath have been changed as per we select any other dealer
        [FindsBy(How = How.XPath, Using = "//*[@id='1']")]
        public IWebElement EnteredselectedDealer { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='109']")]
        public IWebElement SelectAnotherDealer { get; set; }

        /// <summary>
        /// Select Dealer
        /// : here we can check the functionality that once we click on 
        /// dealer dropdown and then enter entry on it and select that dealer.
        /// </summary>
        /// <param name="DealerName"></param>
        public void SelectDealer(string DealerName , string DealerName2)
        {
            Stop.WaitFortheLoadingIconDisappear2000();
            selectDealers.Clear();
            Stop.WaitFortheLoadingIconDisappear5000();
            selectDealers.SendKeys(DealerName);
            Stop.WaitFortheLoadingIconDisappear5000();
            EnteredselectedDealer.Click();

            Stop.WaitFortheLoadingIconDisappear2000();
            selectDealers.Clear();
            Stop.WaitFortheLoadingIconDisappear5000();
            selectDealers.SendKeys(DealerName2);
            Stop.WaitFortheLoadingIconDisappear5000();
            SelectAnotherDealer.Click();
            
            selectDealers.Clear();
            Stop.WaitFortheLoadingIconDisappear5000();
            selectDealers.SendKeys(DealerName);
            Stop.WaitFortheLoadingIconDisappear5000();
            EnteredselectedDealer.Click();

        }


        [FindsBy(How = How.XPath, Using = "//input[@data-placeholder='Search']")]
        public IWebElement ClickOnSearchBar { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@title='Search']")]
        public IWebElement ClickOnSearchBtn { get; set; }

        /// <summary>
        /// Click on Search Bar and check its working fine or Not.
        /// </summary>
        /// <param name="SearchItem"></param>
        public void SearchBar(string SearchItem)
        {
            Stop.WaitFortheLoadingIconDisappear5000();
            ClickOnSearchBar.SendKeys(SearchItem);
            ClickOnSearchBtn.Click();
            Stop.WaitFortheLoadingIconDisappear5000();
            ClickOnSearchBar.Clear();
            ClickOnSearchBtn.Click();
        }


        [FindsBy(How = How.XPath, Using = "//*[@id='pdfExportButton']")]
        public IWebElement PDF { get; set; }


        public void clickToCreatePDF()
        {
            Stop.WaitFortheLoadingIconDisappear10000();
            PDF.Clicks();
            //Here we have to compare PDF Data with our Page Source Data.
        }



        [FindsBy(How = How.XPath, Using = "//*[@id='excelExportButton']")]
        public IWebElement Excel { get; set; }


        public void clickToCreateExcel()
        {
            Stop.WaitFortheLoadingIconDisappear10000();
            Excel.Clicks();
            Stop.WaitFortheLoadingIconDisappear15000();
            //Here we have to compare Excel Data with our Page Source Data.
        }




    }
}
