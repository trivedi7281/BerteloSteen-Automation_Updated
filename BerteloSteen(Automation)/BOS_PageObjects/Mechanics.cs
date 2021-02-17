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

            CustomLib.FluentWaitbyXPath(Drive.driver, "engLanguage");
            engLanguage.Clicks();
            //Click on DARS Tab
            CustomLib.FluentWaitbyXPath(Drive.driver, "clickonDARS");
            clickonDARS.Click();
            CustomLib.FluentWaitbyXPath(Drive.driver, "clickonMechanicsTab");
            clickonMechanicsTab.Click();
            
        }
        /// <summary>
        /// Verify the Page Title
        /// : As module wise we entered into the different modules 
        /// so we can verify its title's.
        /// </summary>
        public void GetPageTitle()
        {
            CustomLib.FluentWaitbyXPath(Drive.driver, "clickonMechanicsTab");
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
        public void SelectDealer(string DealerName , string DealerName2 = null)
        {
            CustomLib.FluentWaitbyXPath(Drive.driver, "selectDealers");
            selectDealers.Clear();
            selectDealers.SendKeys(DealerName);
            CustomLib.FluentWaitbyXPath(Drive.driver, "EnteredselectedDealer");
            EnteredselectedDealer.Click();

            
            //selectDealers.Clear();
            //selectDealers.SendKeys(DealerName2);
            //CustomLib.FluentWaitbyXPath(Drive.driver, "SelectAnotherDealer");
            //SelectAnotherDealer.Click();
            
            //selectDealers.Clear();
            //selectDealers.SendKeys(DealerName);
            //CustomLib.FluentWaitbyXPath(Drive.driver, "EnteredselectedDealer");
            //EnteredselectedDealer.Click();

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
            CustomLib.FluentWaitbyXPath(Drive.driver, "ClickOnSearchBar");
            ClickOnSearchBar.SendKeys(SearchItem);
            ClickOnSearchBtn.Click();
            
        }


        [FindsBy(How = How.XPath, Using = "//*[@id='pdfExportButton']")]
        public IWebElement PDF { get; set; }


        public void clickToCreatePDF()
        {
            CustomLib.FluentWaitbyXPath(Drive.driver, "PDF");
            PDF.Clicks();
            Stop.WaitFortheLoadingIconDisappear2000();
            //Here we have to compare PDF Data with our Page Source Data.
        }



        [FindsBy(How = How.XPath, Using = "//*[@id='excelExportButton']")]
        public IWebElement Excel { get; set; }


        public void clickToCreateExcel()
        {
            CustomLib.FluentWaitbyXPath(Drive.driver, "Excel");
            Excel.Clicks();
            Stop.WaitFortheLoadingIconDisappear5000();
            //Here we have to compare Excel Data with our Page Source Data.
        }

        //Xpath for the Mechanics Table 
        [FindsBy(How = How.XPath, Using = "//table[@matsortactive='name'][@matsortdirection='asc']")]
        public IWebElement Mechanicstable { get; set; }
        

        public void CheckTablefoundtheSearchData()
        {
            Drive.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);
            CustomLib.FluentWaitbyXPath(Drive.driver, "Mechanicstable");
            TableUtil.ReadTable(Mechanicstable);
            string VerifyName =TableUtil.ReadCell("Name", 1);
            Console.WriteLine("Name is : " + VerifyName);
            Assert.AreEqual("Alexander Almeland Jensen", VerifyName);
        }

        //Xpath for the Mechanics Table 
        [FindsBy(How = How.XPath, Using = "//tbody[@role='rowgroup']/tr[1]/td[12]/div/a[1]")]
        public IWebElement EditButton { get; set; }


        public void clickintoActionBtn()
        {
            EditButton.Click();
            Stop.WaitFortheLoadingIconDisappear5000();

        }

        //Xpath for the Mechanics Table 
        [FindsBy(How = How.XPath, Using = "//*[@id='addMechanicsDetails']/div[1]/p")]
        public IWebElement MechanicsAdditionalDetails { get; set; }

        //Xpath for the Mechanics Table 
        [FindsBy(How = How.XPath, Using = "//*[@id='addMechanicsDetails']/div[2]/ul/li/a[@aria-controls='generalInfo']")]
        public IWebElement GeneralInfo { get; set; }

        //Xpath for the Mechanics Table 
        [FindsBy(How = How.XPath, Using = "//*[@id='addMechanicsDetails']/div[2]/ul/li/a[@aria-controls='associatedBrands']")]
        public IWebElement AssociateBrands { get; set; }

        //Xpath for the Mechanics Table 
        [FindsBy(How = How.XPath, Using = "//*[@id='addMechanicsDetails']/div[2]/ul/li/a[@aria-controls = 'mechanicLeaves']")]
        public IWebElement MechanicLeaves { get; set; }

        //Xpath for the Mechanics Table 
        [FindsBy(How = How.XPath, Using = "//*[@id='addMechanicLeave']")]
        public IWebElement AddMechanicLeaves { get; set; }

        //Xpath for the Mechanics Table 
        [FindsBy(How = How.XPath, Using = "//div[@class='appointment-comment-title ng-tns-c468-44'][1]")]
        public IWebElement VerifyMechanicLeavesHeader { get; set; }

        //Xpath for the Mechanics Table 
        [FindsBy(How = How.XPath, Using = "//span[@id='mechanicName']")]
        public IWebElement VerifyMechanicName { get; set; }

        //Xpath for the Mechanics Table 
        [FindsBy(How = How.XPath, Using = "//li[@class='ng-tns-c468-44']/a[@class='pop-close-ico cancelMechanicLeaves ng-tns-c468-44']")]
        public IWebElement CancelMechanicLeavePage { get; set; }

        


        public void VerifytheTabsofMechanicAditionalDetails()
        {
            //CustomLib.FluentWaitbyXPath(Drive.driver, "MechanicsAdditionalDetails");
            //string PageHeader = MechanicsAdditionalDetails.GetText();
            //Assert.AreEqual("Mechanics", PageHeader);
            //Console.WriteLine("Page Header is :" + PageHeader);
            //Stop.WaitFortheLoadingIconDisappear5000();
            CustomLib.FluentWaitbyXPath(Drive.driver, "GeneralInfo");
            GeneralInfo.Click();

            Stop.WaitFortheLoadingIconDisappear2000();
            AssociateBrands.Click();

            CustomLib.FluentWaitbyXPath(Drive.driver, "MechanicLeaves");
            MechanicLeaves.Click();
            CustomLib.FluentWaitbyXPath(Drive.driver, "AddMechanicLeaves");

            AddMechanicLeaves.Click();
            //CustomLib.FluentWaitbyXPath(Drive.driver, "VerifyMechanicLeavesHeader");
            //string MechanicLeavePageHeader = VerifyMechanicLeavesHeader.GetText();
            //Assert.AreEqual("Mechanic Leave", MechanicLeavePageHeader);
            //Console.WriteLine("Page Header is :" + MechanicLeavePageHeader);

            CustomLib.FluentWaitbyXPath(Drive.driver, "VerifyMechanicName");
            string MechanicName = VerifyMechanicName.GetText();
            Assert.AreEqual("Alexander Almeland Jensen", MechanicName);
            Console.WriteLine("Mechanic Name is :" + MechanicName);

            CustomLib.FluentWaitbyXPath(Drive.driver, "CancelMechanicLeavePage");
            CancelMechanicLeavePage.Click();

        }

        //Xpath for the Mechanics Table 
        [FindsBy(How = How.XPath, Using = "//a[@id='closeButton']")]
        public IWebElement ExitFromMechanicAdditionalDetailsPage { get; set; }

        public void ExitFromMechanicDetailsPage()
        {
            CustomLib.FluentWaitbyXPath(Drive.driver, "ExitFromMechanicAdditionalDetailsPage");
            ExitFromMechanicAdditionalDetailsPage.Click();
        }

    }
}
