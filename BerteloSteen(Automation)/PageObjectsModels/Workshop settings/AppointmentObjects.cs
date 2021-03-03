using DARS.Automation_.Helper;
using DARS.Automation_.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Linq;
using System.Threading;

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
            CustomWait.WaitFortheLoadingIconDisappear5000();
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
            if (value == "All")
            {
                Console.WriteLine("All Status has been selected");
            }
            else
            {
                string StatusInfo = AssertGetStatus.GetAttribute("title");
                Console.WriteLine("First Row Status is:" + StatusInfo);
                Assert.AreEqual(value, StatusInfo);
            }

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
            if (value == "All")
            {
                Console.WriteLine("All Types has been selected");
            }
            else
            {
                string TypeInfo = AssertGetType.GetAttribute("title");
                Console.WriteLine("First Row Type Name is:" + TypeInfo);
                Assert.AreEqual(value, TypeInfo);
            }


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


        [FindsBy(How = How.XPath, Using = "//button[@id='appointmentAddButton']")]
        public IWebElement AppointmentButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='SearchVehicleOrCustomerTitle']")]
        public IWebElement SearchVehiclePageTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Select Dealer']")]
        public IWebElement SelectDealers { get; set; }

        string AppointmentDealerDropDown = " (//mat-option[@name='advSearchDealer']/span/span)";

        public void ClickCreateAppointment()
        {
            AppointmentButton.Click();
            Console.WriteLine(SearchVehiclePageTitle.Text);
        }

        string WorkOrder1 = "(//label[contains(text(),'";
        string WorkOrder2 = "')])";

        public void SelectWorkOrder(string Work_Order)
        {
            string WorkOrderFinal = WorkOrder1 + Work_Order + WorkOrder2;
            IWebElement WorkOrderType = Drive.driver.FindElement(By.XPath(WorkOrderFinal));
            WorkOrderType.Click();
            CustomWait.WaitFortheLoadingIconDisappear3000();

        }

        public void SelectDealer(string RandomNumberofActualDealerNumber = null, string ActualDealerNumber = null)
        {
            SelectDealers.Clear();
            SelectDealers.SendKeys(RandomNumberofActualDealerNumber);
            CustomWait.WaitFortheLoadingIconDisappear2000();
            CustomLib.DealerDropDown(ActualDealerNumber, AppointmentDealerDropDown);
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='globalSearchVehicle']")]
        public IWebElement AppointmentGlobalSearch { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@id='searchVehicleBtn']")]
        public IWebElement searchVehicleBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@id='advVehicleSearch']")]
        public IWebElement advVehicleSearch { get; set; }

        string labelPartone = "(//label[contains(text(),'";
        string labelParttwo = "')])[2]";

        [FindsBy(How = How.XPath, Using = "//*[@id='adv_Vehicle_LicensePlate']")]
        public IWebElement VehicleLicensePlate { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='adv_Vehicle_ChassisNo']")]
        public IWebElement VehicleChassisNo { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='adv_Vehicle_PartNo']")]
        public IWebElement VehiclePartNo { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='adv_Vehicle_SerialNo']")]
        public IWebElement VehicleSerialNo { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='advanceVehicleSearchBtn']")]
        public IWebElement advanceVehicleSearchBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='cancelVehicleSearch']")]
        public IWebElement cancelVehicleSearch { get; set; }


        public void AppointmentSearchVehicle(string SearchOption, string Vehicle = null, string Advlabel = null)
        {

            if (SearchOption == "Search")
            {
                AppointmentGlobalSearch.Clear();
                AppointmentGlobalSearch.SendKeys(Vehicle);
                searchVehicleBtn.Clicks();
                CustomWait.WaitFortheLoadingIconDisappear3000();
            }
            else if (SearchOption == "AdvanceSearch")
            {
                string MainLabel = labelPartone + Advlabel + labelParttwo;
                IWebElement GetLabel = Drive.driver.FindElement(By.XPath(MainLabel));
                string Label = GetLabel.Text;
                advVehicleSearch.Click();
                CustomWait.WaitFortheLoadingIconDisappear1000();
                if (Label == Advlabel)
                {
                    VehicleLicensePlate.SendKeys(Vehicle);
                }
                else if (Label == Advlabel)
                {
                    VehicleChassisNo.SendKeys(Vehicle);
                }
                else if (Label == Advlabel)
                {
                    VehiclePartNo.SendKeys(Vehicle);
                }
                else if (Label == Advlabel)
                {
                    VehicleSerialNo.SendKeys(Vehicle);
                }
                else
                {
                    Console.WriteLine("Please Enter Value in any one field");
                }
                advanceVehicleSearchBtn.Click();
            }
        }


        [FindsBy(How = How.XPath, Using = "//div[@id='ExistingWorkOrderDetailsPopup']//div[@class='appointment-comment-title']")]
        public IWebElement OpenActiveModalTitle { get; set; }


        string OpenActiveBookingCount = "//div[@id='appointmentListScroll']//table[@id='existingWorkOrdersTable']/tbody/tr";


        [FindsBy(How = How.XPath, Using = "(//div[@id='ExistingWorkOrderDetailsPopup']//a)[1]")]
        public IWebElement CloseActiveBooking { get; set; }

        string VehicleTableCount = "(//div[@class='vehicle-customer-box'])[2]//table/tbody/tr";

        public void CreateOrSelectBooking(string SelectOption, string ActiveId = null , string NewLPNo = null)
        {
            if (SelectOption == "Active")
            {
                Console.WriteLine(OpenActiveModalTitle.Text);
                int ActiveRowCount = Drive.driver.FindElements(By.XPath(OpenActiveBookingCount)).Count();
                Console.WriteLine(OpenActiveModalTitle.Text + ActiveRowCount);
                string BeforeRowData = "//td[contains(text(), '";
                string AfterRowData = "')]/parent::*//td[15]//a[@title = 'Edit']";
                for (int i = 1; i <= ActiveRowCount; i++)
                {
                    string ActualRowData = BeforeRowData + ActiveId + AfterRowData;
                    IWebElement FinalRowData = Drive.driver.FindElement(By.XPath(ActualRowData));
                    ((IJavaScriptExecutor)Drive.driver).ExecuteScript("arguments[0].scrollIntoView(true);", FinalRowData);
                    if (FinalRowData.Text.Contains(ActiveId))
                    {
                        FinalRowData.Click();
                        break;
                    }
                    
                }

            }
            else if (SelectOption == "New")
            {
                CustomWait.WaitFortheLoadingIconDisappear2000();
                CloseActiveBooking.Click();
                int VehicleRowCount = Drive.driver.FindElements(By.XPath(VehicleTableCount)).Count();
                string BeforeVehicle = "((//div[contains(text() , '";
                string AfterVehicle = "')])/parent::td[contains(@data-th ,'License')])/parent::*/td[@data-th = 'Actions']";

                for (int i = 1; i <= VehicleRowCount; i++)
                {
                    string ActualRowData = BeforeVehicle + NewLPNo + AfterVehicle;
                    IWebElement FinalVehicleData = Drive.driver.FindElement(By.XPath(ActualRowData));
                    ((IJavaScriptExecutor)Drive.driver).ExecuteScript("arguments[0].scrollIntoView(true);", FinalVehicleData);
                    if (FinalVehicleData.Text.Contains(NewLPNo))
                    {
                        FinalVehicleData.Click();
                        break;
                    }
                    
                }


            }

        }


        [FindsBy(How = How.Id, Using = "toast-container")]
        public IWebElement AlerttextMessage { get; set; }

        public void AlertMessage()
        {
            CustomWait.WaitFortheLoadingIconDisappear1000();
            string alerMessage = AlerttextMessage.Text;
            Console.WriteLine("Alert Message :" + alerMessage);
        }








    }
}
