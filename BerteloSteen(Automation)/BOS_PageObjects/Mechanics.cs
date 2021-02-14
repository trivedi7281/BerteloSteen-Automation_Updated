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


        [FindsBy(How = How.XPath, Using = "//*[@id='darsdealer ']")]
        public IWebElement clickonDARS { get; set; }

        

        [FindsBy(How = How.CssSelector, Using = "#darsdealer-submenu\\  > ul:nth-child(2) > li:nth-child(2) > a")]
        public IWebElement clickonMechanicsTab { get; set; }

        public void ClickonDARS()
        {
            Thread.Sleep(20000);
            Drive.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            engLanguage.Clicks();
            //Click on DARS Tab
            Thread.Sleep(15000);
            clickonDARS.Clicks();
            Drive.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            clickonMechanicsTab.Clicks();
            
        }

        public void GetPageTitle()
        {
            Thread.Sleep(15000);
            String title = Drive.driver.Title;
            Console.WriteLine("Page Title is:" + title);
            Assert.AreEqual("Mechanics", title);
        }



        [FindsBy(How = How.XPath, Using = "//input[@id = 'mat-input-5']")]
        public IWebElement selectDealers { get; set; }

        //Here this xpath have been changed as per we select any other dealer
        [FindsBy(How = How.XPath, Using = "//*[@id='1']")]
        public IWebElement clickonselectedDealer { get; set; }

        


        public void SelectDealer(string dealerName)
        {
            Thread.Sleep(15000);
            Actions action = new Actions(Drive.driver);
            action.KeyDown(selectDealers, Keys.Control).SendKeys("A")
            .KeyUp(selectDealers, Keys.Delete).Build().Perform();
            Thread.Sleep(2000);
            selectDealers.EnterText(dealerName);
            clickonselectedDealer.Clicks();

        }
    }
}
