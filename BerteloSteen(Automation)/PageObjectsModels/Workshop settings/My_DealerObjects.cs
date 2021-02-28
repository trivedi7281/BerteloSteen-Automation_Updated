using DARS.Automation_.Helper;
using DARS.Automation_.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DARS.Automation_.PageObjectsModels.Workshop_settings
{
    class My_DealerObjects
    {
        [Obsolete]
        public My_DealerObjects() => PageFactory.InitElements(Drive.driver, this);

        [FindsBy(How = How.XPath, Using = "//ul/li[@id='engli']/a")]
        public IWebElement engLanguage { get; set; }


        [FindsBy(How = How.CssSelector, Using = "#darsdealer\\  > a")]
        public IWebElement clickonDARS { get; set; }


        [FindsBy(How = How.XPath, Using = "//li[@id='darsdealer ']")]
        public IWebElement DARSHighlight { get; set; }


        [FindsBy(How = How.XPath, Using = "//a[@href='/en-US/Workplace/MyDealer/Index']")]
        public IWebElement clickonMyDealerTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='save']")]
        public IWebElement SaveBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='reset']")]
        public IWebElement ResetBtn { get; set; }

        /// <summary>
        /// Navigate to Mechanics
        /// :Click on DARS Tab>> Click on Mechanics Tab in Workshop setting
        /// </summary>

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
            CustomWait.FluentWaitbyXPath("clickonMyDealerTab");
            string title = Drive.driver.Title;
            Console.WriteLine("Title is:" + title);
            Assert.AreEqual("My Dealer", title);
        }


        [FindsBy(How = How.XPath, Using = "//input[@data-placeholder='Select Dealer']")]
        public IWebElement selectDealers { get; set; }


        string MyDealerDropDown = "(//mat-option[@name='searchDealer']/span/span)";

        /// <summary>
        /// Select Dealer
        /// : here we can check the functionality that once we click on 
        /// dealer dropdown and then enter entry on it and select that dealer.
        /// </summary>
        /// <param name="DealerName"></param>
        public void SelectDealer(string RandomNumber, string ActualDealerNumber)
        {
            CustomWait.FluentWaitbyXPath("selectDealers");
            selectDealers.Clear();
            selectDealers.SendKeys(RandomNumber);
            CustomLib.DealerDropDown(ActualDealerNumber, MyDealerDropDown);
            CustomWait.WaitFortheLoadingIconDisappear2000();

        }

        [FindsBy(How = How.XPath, Using = "//*[@id='isAddTax']")]
        public IWebElement AddTax { get; set; }

        [FindsBy(How = How.XPath, Using = " //*[@id='laborPercentage']")]
        public IWebElement laborPercentage { get; set; }



        [FindsBy(How = How.XPath, Using = "//mat-select[@id='defaultExternalRentalCarCompanyId']")]
        public IWebElement selectRCCDropdown { get; set; }


        string FirstPart = "(//div[@id = 'defaultExternalRentalCarCompanyId-panel']/mat-option[@role='option']/span)";


        [FindsBy(How = How.XPath, Using = "(//div[@id = 'defaultExternalRentalCarCompanyId-panel']/mat-option[@role='option']/span)[1]")]
        public IWebElement selectRentalCarDefaultDropdownValue { get; set; }


        public void SelectRentalCarComp_Dropdown(string value)
        {

            CustomWait.FluentWaitbyXPath("selectRCCDropdown");
            selectRCCDropdown.Click();
            CustomWait.WaitFortheLoadingIconDisappear3000();
            CustomLib.DropDownbyName(value, FirstPart);

        }


        [FindsBy(How = How.XPath, Using = "//*[@id='communicationNotificationBlock']")]
        public IWebElement NotificationsDetails { get; set; }

        public void EnterNotificationDetail()
        {
            CustomWait.WaitFortheLoadingIconDisappear2000();
            ((IJavaScriptExecutor)Drive.driver).ExecuteScript("arguments[0].scrollIntoView(true);", NotificationsDetails);
            NotificationsDetails.Click();

        }


        [FindsBy(How = How.XPath, Using = "//*[@id='dealerShiftDetailsBlock']")]
        public IWebElement DealerHours { get; set; }

        public void EnterDealerHours()
        {
            CustomWait.WaitFortheLoadingIconDisappear2000();
            ((IJavaScriptExecutor)Drive.driver).ExecuteScript("arguments[0].scrollIntoView(true);", DealerHours);
            DealerHours.Click();
            IList<IWebElement> els = Drive.driver.FindElements(By.XPath("(//*[@id='containerData']//input[@type='checkbox'])"));
            Console.WriteLine(els.Count());


        }

        



    }
}
