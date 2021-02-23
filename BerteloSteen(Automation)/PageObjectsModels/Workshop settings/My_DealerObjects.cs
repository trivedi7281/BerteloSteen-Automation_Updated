using DARS.Automation_.GetSet;
using DARS.Automation_.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DARS.Automation_.PageObjectsModels
{
    class My_DealerObjects
    {
        [Obsolete]
        public My_DealerObjects() => PageFactory.InitElements(Drive.driver, this);

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
            CustomLib.WaitFortheLoadingIconDisappear2000();
        
        }





        //AddTax.Click();
        //CustomLib.WaitFortheLoadingIconDisappear5000();
        //*[@id="laborPercentage"]
        //*[@id="partsPercentage"]
        //*[@id="showPriceDiffPercentage"]
        //*[@id="minimumMarginForParts"]


        [FindsBy(How = How.XPath, Using = "//*[@id='isAddTax']")]
        public IWebElement AddTax { get; set; }

        [FindsBy(How = How.XPath, Using = " //*[@id='laborPercentage']")]
        public IWebElement laborPercentage { get; set; }



        [FindsBy(How = How.XPath, Using = "//mat-select[@id='defaultExternalRentalCarCompanyId']")]
        public IWebElement selectRCCDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='defaultExternalRentalCarCompanyId - panel']")]
        public IWebElement selectRCCDropdownPanel { get; set; }

        string BeforeXpath = "(//mat-option[@role='option']/span)[";
        string AfterXPathXpath = "]";

     

        public void SelectRentalCarComp_Dropdown(string startIndex , string EndIndex , string value)
        {
            
            CustomLib.FluentWaitbyXPath(Drive.driver, "selectRCCDropdown");
            selectRCCDropdown.Click();
            CustomLib.WaitFortheLoadingIconDisappear5000();
            for (int i=Int32.Parse(startIndex); i<=Int32.Parse(EndIndex); i++)
            {
                string ActualXpath = BeforeXpath + i + AfterXPathXpath;
                IWebElement element = Drive.driver.FindElement(By.XPath(ActualXpath));
                Console.WriteLine(element.Text);
                if(element.Text.Equals(value))
                {
                    element.Click();
                    break;
                }
                
            }
      
        }


        //[FindsBy(How = How.XPath, Using = "//div/input[@type ='checkbox']")]
        //public IWebElement AllCheckBoxes { get; set; }

        public void ValidateAllCheckBoxes()
        {
          

        }
    }
}
