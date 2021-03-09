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

        [FindsBy(How = How.XPath, Using = "//div[@id='SearchVehicleOrCustomerTitle']")]
        public IWebElement SearchVehiclePageTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@placeholder='Select Dealer'])[2]")]
        public IWebElement SelectDealers { get; set; }

        string AppointmentDealerDropDown = "(//mat-option[@name='advSearchDealer']/span/span)";

        public void ClickCreateAppointment()
        {
            CustomWait.WaitFortheLoadingIconDisappear3000();
            CustomWait.FluentWaitbyXPath("AppointmentButton");
            AppointmentButton.Click();
            CustomWait.WaitFortheLoadingIconDisappear2000();
            Console.WriteLine(SearchVehiclePageTitle.Text);
        }

        string WorkOrder1 = "(//label[contains(text(),'";
        string WorkOrder2 = "')])";

        public void AppointmentSelectWorkOrder(string Work_Order)
        {
            string WorkOrderFinal = WorkOrder1 + Work_Order + WorkOrder2;
            IWebElement WorkOrderType = Drive.driver.FindElement(By.XPath(WorkOrderFinal));
            WorkOrderType.Click();
            CustomWait.WaitFortheLoadingIconDisappear3000();

        }

        public void AppointmentSelectDealer(string RandomNumberofActualDealerNumber = null, string ActualDealerNumber = null)
        {
            SelectDealers.Clear();
            CustomWait.WaitFortheLoadingIconDisappear2000();
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

        string search = "Search";
        string advSearch = "AdvanceSearch";


        public void AppointmentSearchVehicle(string SearchOption, string Vehicle = null, string Advlabel = null)
        {

            if (SearchOption == search)
            {
                AppointmentGlobalSearch.Clear();
                AppointmentGlobalSearch.SendKeys(Vehicle);
                CustomWait.WaitFortheLoadingIconDisappear3000();
                searchVehicleBtn.Clicks();
                CustomWait.WaitFortheLoadingIconDisappear3000();
            }
            else if (SearchOption == advSearch)
            {
                string MainLabel = labelPartone + Advlabel + labelParttwo;
                IWebElement GetLabel = Drive.driver.FindElement(By.XPath(MainLabel));
                
                advVehicleSearch.Click();
                CustomWait.WaitFortheLoadingIconDisappear1000();
                if (GetLabel.Text == Advlabel)
                {
                    VehicleLicensePlate.SendKeys(Vehicle);
                }
                else if (GetLabel.Text == Advlabel)
                {
                    VehicleChassisNo.SendKeys(Vehicle);
                }
                else if (GetLabel.Text == Advlabel)
                {
                    VehiclePartNo.SendKeys(Vehicle);
                }
                else if (GetLabel.Text == Advlabel)
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

        [FindsBy(How = How.XPath, Using = "//*[@id='existingWorkOrdersTable']/tbody/tr[1]/td[15]/div/a")]
        public IWebElement SelectExistBooking { get; set; }
        
        [FindsBy(How = How.XPath, Using = "(//div[@id='ExistingWorkOrderDetailsPopup']//a)[1]")]
        public IWebElement CloseActiveBooking { get; set; }

        string VehicleTableCount = "(//div[@class='vehicle-customer-box'])[2]//table/tbody/tr";

        string active = "Active";
        string New = "New";


        public void AppointmentCreateOrSelectBooking(string SelectOption,string NewLPNo = null)
        {
            if (SelectOption == active)
            {
                CustomWait.WaitFortheLoadingIconDisappear5000();
                Console.WriteLine(OpenActiveModalTitle.Text);
                int ActiveRowCount = Drive.driver.FindElements(By.XPath(OpenActiveBookingCount)).Count();
                Console.WriteLine(OpenActiveModalTitle.Text + ':' + ActiveRowCount);
                CustomWait.WaitFortheLoadingIconDisappear3000();
                SelectExistBooking.Click();
            }
            else if (SelectOption == New)
            {
                CustomWait.WaitFortheLoadingIconDisappear3000();
                CloseActiveBooking.Click();
                int VehicleRowCount = Drive.driver.FindElements(By.XPath(VehicleTableCount)).Count();
                string BeforeVehicle = "((//div[contains(text(),'";
                string AfterVehicle = "')])/parent::td[contains(@data-th,'License')])/parent::*/td[@data-th='Actions']";
                for (int i = 1; i<= VehicleRowCount; i++)
                {
                    string ActualRowData = BeforeVehicle + NewLPNo + AfterVehicle;
                    IWebElement FinalVehicleData = Drive.driver.FindElement(By.XPath(ActualRowData));
                    ((IJavaScriptExecutor)Drive.driver).ExecuteScript("arguments[0].scrollIntoView(true);", FinalVehicleData);
                    CustomWait.WaitFortheLoadingIconDisappear2000();
                    FinalVehicleData.Click();
                    CustomLib.AlertMessage();
                }

            }

        }

        [FindsBy(How = How.XPath, Using = "(//*[@id='addAppointmentDetails'])[2]/div[1]/div[1]/div[1]")]
        public IWebElement EditAppointmentDetailScreen { get; set; }

        [FindsBy(How = How.XPath, Using = "((//div[@id='addAppointmentDetails'])[2]//div/span)[1]")]
        public IWebElement EditAppointmentDetailScreenID { get; set; }

        [FindsBy(How = How.XPath, Using = "((//div[@id='addAppointmentDetails'])[2]//div/span)[2]")]
        public IWebElement EditAppointmentDetailScreenVIN { get; set; }

        [FindsBy(How = How.XPath, Using = "((//div[@id='addAppointmentDetails'])[2]//div/span)[3]")]
        public IWebElement EditAppointmentDetailScreenLP { get; set; }

        [FindsBy(How = How.XPath, Using = "(//*[@id='addAppointmentDetails'])[1]/div[1]/div[1]/div[1]")]
        public IWebElement CreateAppointmentDetailScreen { get; set; }

        [FindsBy(How = How.XPath, Using = "((//div[@id='addAppointmentDetails'])[1]//div/span)[1]")]
        public IWebElement CreateAppointmentDetailScreenID { get; set; }

        [FindsBy(How = How.XPath, Using = "((//div[@id='addAppointmentDetails'])[1]//div/span)[2]")]
        public IWebElement CreateAppointmentDetailScreenVIN { get; set; }

        [FindsBy(How = How.XPath, Using = "((//div[@id='addAppointmentDetails'])[1]//div/span)[3]")]
        public IWebElement CreateAppointmentDetailScreenLP { get; set; }


        public void AppointmentDetailscreen(string SelectOption)
        {
            if (SelectOption == active)
            {
                CustomWait.WaitFortheLoadingIconDisappear5000();
                CustomWait.WaitFortheLoadingIconDisappear2000();
                CustomWait.FluentWaitbyXPath("EditAppointmentDetailScreen");
                Console.WriteLine(EditAppointmentDetailScreen.Text);
                Console.WriteLine(EditAppointmentDetailScreenID.Text);
                Console.WriteLine(EditAppointmentDetailScreenVIN.Text);
                Console.WriteLine(EditAppointmentDetailScreenLP.Text);
            }
            else if (SelectOption == New)
            {
                CustomWait.WaitFortheLoadingIconDisappear5000();
                CustomWait.WaitFortheLoadingIconDisappear2000();
                CustomWait.FluentWaitbyXPath("CreateAppointmentDetailScreen");
                Console.WriteLine(CreateAppointmentDetailScreen.Text);
                Console.WriteLine(CreateAppointmentDetailScreenID.Text);
                Console.WriteLine(CreateAppointmentDetailScreenVIN.Text);
                Console.WriteLine(CreateAppointmentDetailScreenLP.Text);
            }
        }

        [FindsBy(How = How.XPath, Using = "(//div[@id='appointmentGeneralInfo']//button[@id='addDemandButton'])[1]")]
        public IWebElement NewAddNewDemand { get; set; }
        
        [FindsBy(How = How.XPath, Using = "(//div[@id='appointmentGeneralInfo']//button[@id='addDemandButton'])[2]")]
        public IWebElement ActiveAddNewDemand { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='AppointmentDemandServiceTable']/tbody/tr/td[contains(text(), 'No Record Found')]")]
        public IWebElement NRFinDemands { get; set; }



        public void CreateNewDemand(string SelectOption)
        {
            if (SelectOption == active)
            {
                if (NRFinDemands.Displayed)
                {
                    CustomWait.WaitFortheLoadingIconDisappear2000();
                    ActiveAddNewDemand.Click();
                }
            }
            else if (SelectOption == New)
            {
                CustomWait.WaitFortheLoadingIconDisappear2000();
                NewAddNewDemand.Click();

            }
        }

        [FindsBy(How = How.XPath, Using = "(//a[contains(@title,'Add Package')])[1]")]
        public IWebElement NewSDCR { get; set; }

        [FindsBy(How = How.XPath, Using = "(//a[contains(@title,'Add Package')])[2]")]
        public IWebElement ActiveSDCR { get; set; }

        public void ValidateSDCR(string SelectOption)
        {
            if (SelectOption == active)
            {
                CustomWait.WaitFortheLoadingIconDisappear2000();
                ActiveSDCR.Click();
                CustomLib.MultipleAlertMessages();
            }
            else if (SelectOption == New)
            {
                CustomWait.WaitFortheLoadingIconDisappear2000();
                NewSDCR.Click();
                CustomLib.MultipleAlertMessages();

            }

        }

        string BeforeNewShortDescription = "(//td[@class='csttextareasize']//*[@id='ShortDescriptions";
        string AfterNewShortDescription = "'])[1]";

        string BeforeActiveShortDescription = "(//td[@class='csttextareasize']//*[@id='ShortDescriptions";
        string AfterActiveShortDescription = "'])[2]";
     
        public void EnterShortDescription(string SelectOption , int Row ,  string ShortDescription)
        {
            string ActualNewShortDescription = BeforeNewShortDescription + Row + AfterNewShortDescription;
            IWebElement FinalNewShortDescription = Drive.driver.FindElement(By.XPath(ActualNewShortDescription));

            string ActualActiveShortDescription = BeforeActiveShortDescription + Row + AfterActiveShortDescription;
            IWebElement FinalActiveShortDescription = Drive.driver.FindElement(By.XPath(ActualActiveShortDescription));

            if (SelectOption == active)
            {
                FinalActiveShortDescription.SendKeys(ShortDescription);
            }
            else if (SelectOption == New)
            {
                FinalNewShortDescription.SendKeys(ShortDescription);

            }
        }

        string BeforeNewCustomerRequirement = "(//td[@data-th='Customer Requirement']//*[@id='CustomerRequirement";
        string AfterNewCustomerRequirement = "'])[1]";

        string BeforeActiveCustomerRequirement = "(//td[@data-th='Customer Requirement']//*[@id='CustomerRequirement";
        string AfterActiveCustomerRequirement = "'])[2]";

        public void EnterCustomerRequirement(string SelectOption, int Row, string CustomerRequirement)
        {
            string ActualNewCustomerRequirement = BeforeNewCustomerRequirement + Row + AfterNewCustomerRequirement;
            IWebElement FinalNewCustomerRequirement = Drive.driver.FindElement(By.XPath(ActualNewCustomerRequirement));

            string ActualActiveCustomerRequirement = BeforeActiveCustomerRequirement + Row + AfterActiveCustomerRequirement;
            IWebElement FinalActiveCustomerRequirement = Drive.driver.FindElement(By.XPath(ActualActiveCustomerRequirement));



            if (SelectOption == active)
            {
                FinalActiveCustomerRequirement.Clear();
                FinalActiveCustomerRequirement.SendKeys(CustomerRequirement);
            }
            else if (SelectOption == New)
            {
                FinalNewCustomerRequirement.Clear();
                FinalNewCustomerRequirement.SendKeys(CustomerRequirement);

            }
        }


        string BeforeActiveAddActions = "(//*[@id='AppointmentSelectedJobTable']/tbody/tr[";
        string MiddileActiveAddActions = "]/td[11]/div/ul/li/a[contains(@title,'";
        string AfterActiveAddActions = "')])[2]";

        string BeforeNewAddActions = "(//*[@id='AppointmentSelectedJobTable']/tbody/tr[";
        string MiddileNewAddActions = "]/td[11]/div/ul/li/a[contains(@title,'";
        string AfterNewAddActions = "')])[1]";

        public void AddActions(string SelectOption, int Row, string Actions)
        {
            string ActualActiveAddActions = BeforeActiveAddActions + Row + MiddileActiveAddActions + Actions + AfterActiveAddActions;
            IWebElement FinalActiveAddActions = Drive.driver.FindElement(By.XPath(ActualActiveAddActions));

            string ActualNewAddActions = BeforeNewAddActions + Row + MiddileNewAddActions + Actions + AfterNewAddActions;
            IWebElement FinalNewAddActions = Drive.driver.FindElement(By.XPath(ActualNewAddActions));

            if (SelectOption == active)
            {
                FinalActiveAddActions.Click();
            }
            else if (SelectOption == New)
            {
                FinalNewAddActions.Click();

            }

        }












        [FindsBy(How = How.XPath, Using = "//*[@id='addPackagePopup']/div/div[1]")]
        public IWebElement AddPackageTitle { get; set; }

        public void ValidateAddPackageTitle()
        {
            Console.WriteLine(AddPackageTitle.Text);
        }


        [FindsBy(How = How.XPath, Using = "//*[@id='ProfileKey']")]
        public IWebElement AddOperationGroup { get; set; }

        string operationgroup = "(//mat-option[@role='option']/span)";


        [FindsBy(How = How.XPath, Using = "(//*[@id='AppointmentJobTable']/tbody/tr/td[2]//label)[1]")]
        public IWebElement selectJobFromTable { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='addPackage']")]
        public IWebElement AddPackageOkBtn { get; set; }

        public void AddingOperationGroup()
        {
            AddOperationGroup.Click();
            CustomLib.DropDownbyName(" Forrige søk ", operationgroup);
            selectJobFromTable.Click();
            AddPackageOkBtn.Click();

        }





        //Click on Add Services (//a[contains(@title,'Add Service')])[2]
        // Validate title of Add service Modal //span[@id="servicePopupTitle"]
        // count of services and name all the labels  //div[@id="bosBillServices"]/ul/li/label
        // from this only we have to select any one option but validate with selecting two option that what error shows.
        //Validate Add Operation //*[@id="addPackagePopup"]/div/div[1]
        // Enter Description in Add Operation //input[@id="operationDescription"]
        //Add Quantity //input[@id="Time"]
        // Add with plus button //a[@title = "Add Row"]
        // delete that add row //a[@title="Delete Row"]
        // save operation //button[@id="saveOperation"]







    }
}
