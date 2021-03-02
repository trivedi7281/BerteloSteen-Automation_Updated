using DARS.Automation_.Helper;
using DARS.Automation_.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Linq;

namespace DARS.Automation_.PageObjectsModels.Workshop_settings
{
    class AppointmentObjects
    {
        [Obsolete]
        public AppointmentObjects() => PageFactory.InitElements(Drive.driver, this);

        [FindsBy(How = How.XPath, Using = "//ul/li[@id='engli']/a")]
        public IWebElement engLanguage { get; set; }


        public void ClickonLanguage()
        {
            CustomWait.WaitFortheLoadingIconDisappear5000();
            Drive.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            CustomWait.FluentWaitbyXPath("engLanguage");
            CustomLib.Highlightelement(engLanguage);
            engLanguage.Clicks();
        }


        public void GetPageTitle()
        {
            CustomWait.WaitFortheLoadingIconDisappear3000();
            CustomWait.FluentWaitbyXPath("engLanguage");
            string title = Drive.driver.Title;
            Console.WriteLine("Title is:" + title);
            Assert.AreEqual("Appointment", title);
        }


        [FindsBy(How = How.XPath, Using = "//mat-select[@id='changeAppointmentStatus']")]
        public IWebElement ClickAppointmentStatus { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='appointmentTable']/tbody/tr[1]/td[15]/div/div")]
        public IWebElement AssertGetStatus { get; set; }

        string Status = "(//div[@id='changeAppointmentStatus-panel']/mat-option/span)";

        public void AppointmentStatus(string value)
        {
            ClickAppointmentStatus.Click();
            CustomWait.WaitFortheLoadingIconDisappear3000();
            CustomWait.FluentWaitbyXPath("AssertGetStatus");
            CustomLib.DropDownbyName(value, Status);
            CustomWait.WaitFortheLoadingIconDisappear5000();
            string StatusInfo = AssertGetStatus.GetAttribute("title");
            Console.WriteLine("First Row Status is:" + StatusInfo);
            Assert.AreEqual(value, StatusInfo);

        }


        [FindsBy(How = How.XPath, Using = "//mat-select[@id='changeAppointmentType']")]
        public IWebElement ClickAppointmentType { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='appointmentTable']/tbody/tr[1]/td[2]/div/i")]
        public IWebElement AssertGetType { get; set; }

        string Types = "(//div[@id='changeAppointmentType-panel']/mat-option/span)";

        public void AppointmentType(string value)
        {
            ClickAppointmentType.Click();
            CustomWait.WaitFortheLoadingIconDisappear3000();
            CustomWait.FluentWaitbyXPath("AssertGetType");
            CustomLib.DropDownbyName(value, Types);
            CustomWait.WaitFortheLoadingIconDisappear5000();
            string TypeInfo = AssertGetType.GetAttribute("title");
            Console.WriteLine("First Row Type Name is:" + TypeInfo);
            Assert.AreEqual(value, TypeInfo);

        }

        string element = "(//div[@class='middle-container-data']//div//a[@class='link'])";

        public void StatusBarDtl()
        {
            string secondDDN = element + "[";
            string thirdDDN = "]/parent::*";

            int DDName = Drive.driver.FindElements(By.XPath(element)).Count();
            Console.WriteLine(DDName);
            for (int i = 1; i <= DDName; i++)
            {
                string ActualDDNpath = secondDDN + i + thirdDDN;
                IWebElement ActualPath = Drive.driver.FindElement(By.XPath(ActualDDNpath));
                ((IJavaScriptExecutor)Drive.driver).ExecuteScript("arguments[0].scrollIntoView(true);", ActualPath);
                Console.WriteLine("StatusBar Name is:" + ActualPath.Text);
            }



        }
    }
}
