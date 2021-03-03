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
    class DealerServiceObjects
    {
        [Obsolete]
        public DealerServiceObjects() => PageFactory.InitElements(Drive.driver, this);

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
            CustomWait.FluentWaitbyXPath("engLanguage");
            CustomLib.Highlightelement(engLanguage);
            engLanguage.Clicks();
            //Click on DARS Tab
            CustomLib.Highlightelement(DARSHighlight);
            CustomWait.FluentWaitbyXPath("clickonDARS");
            clickonDARS.Click();
            CustomWait.FluentWaitbyXPath("clickonMyDealerTab");
            CustomLib.Highlightelement(clickonDealerServiceTab);
            clickonDealerServiceTab.Clicks();

        }
        

        public void GetPageTitle()
        {
            CustomWait.FluentWaitbyXPath("clickonDealerServiceTab");
            string title = Drive.driver.Title;
            Console.WriteLine("Title is:" + title);
            Assert.AreEqual("Dealer service", title);
        }



        [FindsBy(How = How.XPath, Using = "//input[@id='Dealer'and @name='dealerName']")]
        public IWebElement SelectDealers { get; set; }


        string DealerServiceDropDown = " (//mat-option[@name='dealerName']/span/span)";



        public void SelectDealer(string RandomNumberofActualDealerNumber, string ActualDealerNumber)
        {
            CustomWait.FluentWaitbyXPath("selectDealers");
            SelectDealers.Clear();
            SelectDealers.SendKeys(RandomNumberofActualDealerNumber);
            CustomWait.WaitFortheLoadingIconDisappear2000();
            CustomLib.DealerDropDown(ActualDealerNumber, DealerServiceDropDown);
        }


        [FindsBy(How = How.XPath, Using = "//input[@data-placeholder='Search']")]
        public IWebElement ClickOnSearchBar { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@title='Search']")]
        public IWebElement ClickOnSearchBtn { get; set; }

        
        public void SearchBar(string SearchItem)
        {
            CustomWait.FluentWaitbyXPath("ClickOnSearchBar");
            ClickOnSearchBar.SendKeys(SearchItem);
            ClickOnSearchBtn.Click();

        }


        [FindsBy(How = How.XPath, Using = "//*[@id='pdfExportButton']")]
        public IWebElement PDF { get; set; }


        public void clickToCreatePDF()
        {
            CustomWait.FluentWaitbyXPath("PDF");
            PDF.Clicks();
            CustomWait.WaitFortheLoadingIconDisappear2000();
            //Here we have to compare PDF Data with our Page Source Data.
        }



        [FindsBy(How = How.XPath, Using = "//*[@id='excelExportButton']")]
        public IWebElement Excel { get; set; }


        public void clickToCreateExcel()
        {
            CustomWait.FluentWaitbyXPath("Excel");
            Excel.Clicks();
            CustomWait.WaitFortheLoadingIconDisappear5000();
            //Here we have to compare Excel Data with our Page Source Data.
        }











    }
}
