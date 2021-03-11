using DARS.Automation_.Helper;
using DARS.Automation_.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
        public IWebElement EngLanguage { get; set; }


        public void ClickonLanguage()
        {
            CustomWait.WaitFortheLoadingIconDisappear5000();
            Drive.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            CustomWait.FluentWaitbyXPath("engLanguage");
            CustomLib.Highlightelement(EngLanguage);
            EngLanguage.Clicks();
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


        public void AppointmentCreateOrSelectBooking(string SelectOption, string NewLPNo = null)
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
                for (int i = 1; i <= VehicleRowCount; i++)
                {
                    string ActualRowData = BeforeVehicle + NewLPNo + AfterVehicle;
                    IWebElement FinalVehicleData = Drive.driver.FindElement(By.XPath(ActualRowData));
                    ((IJavaScriptExecutor)Drive.driver).ExecuteScript("arguments[0].scrollIntoView(true);", FinalVehicleData);
                    CustomWait.WaitFortheLoadingIconDisappear3000();
                    FinalVehicleData.Click();
                    CustomWait.WaitFortheLoadingIconDisappear2000();
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
                CustomWait.WaitFortheLoadingIconDisappear3000();
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

        [FindsBy(How = How.XPath, Using = "//table[@id='AppointmentDemandServiceTable']/tbody/tr/td[@data-th='Short Description']")]
        public IWebElement ForNewDemand { get; set; }

        public void CreateNewDemand(string SelectOption)
        {
            if (SelectOption == active)
            {
                CustomWait.WaitFortheLoadingIconDisappear2000();
                ActiveAddNewDemand.Click();
            }
            else if (SelectOption == New)
            {
                ((IJavaScriptExecutor)Drive.driver).ExecuteScript("arguments[0].scrollIntoView(true);", ForNewDemand);
                if (!ForNewDemand.Displayed)
                {
                    CustomWait.WaitFortheLoadingIconDisappear2000();
                    NewAddNewDemand.Click();
                }

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
                ((IJavaScriptExecutor)Drive.driver).ExecuteScript("arguments[0].scrollIntoView(true);", ActiveSDCR);
                CustomWait.WaitFortheLoadingIconDisappear2000();
                ActiveSDCR.Click();
                CustomLib.MultipleAlertMessages();
            }
            else if (SelectOption == New)
            {
                ((IJavaScriptExecutor)Drive.driver).ExecuteScript("arguments[0].scrollIntoView(true);", NewSDCR);
                CustomWait.WaitFortheLoadingIconDisappear2000();
                NewSDCR.Click();
                CustomWait.WaitFortheLoadingIconDisappear2000();
                CustomLib.MultipleAlertMessages();

            }

        }

        string BeforeNewShortDescription = "(//td[@class='csttextareasize']//*[@id='ShortDescriptions";
        string AfterNewShortDescription = "'])[1]";

        string BeforeActiveShortDescription = "(//td[@class='csttextareasize']//*[@id='ShortDescriptions";
        string AfterActiveShortDescription = "'])[2]";

        public void EnterShortDescription(string SelectOption, int Row, string ShortDescription)
        {
            if (SelectOption == active)
            {
                string ActualActiveShortDescription = BeforeActiveShortDescription + Row + AfterActiveShortDescription;
                IWebElement FinalActiveShortDescription = Drive.driver.FindElement(By.XPath(ActualActiveShortDescription));
                FinalActiveShortDescription.SendKeys(ShortDescription);
            }
            else if (SelectOption == New)
            {
                string ActualNewShortDescription = BeforeNewShortDescription + Row + AfterNewShortDescription;
                IWebElement FinalNewShortDescription = Drive.driver.FindElement(By.XPath(ActualNewShortDescription));
                FinalNewShortDescription.SendKeys(ShortDescription);

            }
        }

        string BeforeNewCustomerRequirement = "(//td[@data-th='Customer Requirement']//*[@id='CustomerRequirement";
        string AfterNewCustomerRequirement = "'])[1]";

        string BeforeActiveCustomerRequirement = "(//td[@data-th='Customer Requirement']//*[@id='CustomerRequirement";
        string AfterActiveCustomerRequirement = "'])[2]";

        public void EnterCustomerRequirement(string SelectOption, int Row, string CustomerRequirement)
        {
            if (SelectOption == active)
            {
                string ActualActiveCustomerRequirement = BeforeActiveCustomerRequirement + Row + AfterActiveCustomerRequirement;
                IWebElement FinalActiveCustomerRequirement = Drive.driver.FindElement(By.XPath(ActualActiveCustomerRequirement));
                CustomWait.WaitFortheLoadingIconDisappear2000();
                FinalActiveCustomerRequirement.SendKeys(Keys.Control);
                FinalActiveCustomerRequirement.SendKeys("A");
                FinalActiveCustomerRequirement.SendKeys(Keys.Delete);
                FinalActiveCustomerRequirement.SendKeys(CustomerRequirement);
            }
            else if (SelectOption == New)
            {
                string ActualNewCustomerRequirement = BeforeNewCustomerRequirement + Row + AfterNewCustomerRequirement;
                IWebElement FinalNewCustomerRequirement = Drive.driver.FindElement(By.XPath(ActualNewCustomerRequirement));
                CustomWait.WaitFortheLoadingIconDisappear2000();
                FinalNewCustomerRequirement.SendKeys(Keys.Control);
                FinalNewCustomerRequirement.SendKeys("A");
                FinalNewCustomerRequirement.SendKeys(Keys.Delete);
                FinalNewCustomerRequirement.Clear();
                FinalNewCustomerRequirement.SendKeys(CustomerRequirement);
            }
        }


        string BeforeActiveAddActions = "(//table[@id='AppointmentSelectedJobTable']/tbody/tr/td[contains(text(),'";
        string MiddileBefActiveAddActions = "')]/parent::*/td[contains(text(),'";
        string MiddileAfterActiveAddActions = "')]/parent::*/td[11]/div/ul/li/a[contains(@title,'";
        string AfterActiveAddActions = "')])[2]";

        string BeforeNewAddActions = "(//table[@id='AppointmentSelectedJobTable']/tbody/tr/td[contains(text(),'";
        string MiddileBefNewAddActions = "')]/parent::*/td[contains(text(),'";
        string MiddileAfterNewAddActions = "')]/parent::*/td[11]/div/ul/li/a[contains(@title,'";
        string AfterNewAddActions = "')])[1]";

        public void AddActions(string SelectOption, int Demand, int Job, string Actions)
        {
            if (SelectOption == active)
            {
                string ActualActiveAddActions = BeforeActiveAddActions + Demand + MiddileBefActiveAddActions + Job + MiddileAfterActiveAddActions + Actions + AfterActiveAddActions;
                IWebElement FinalActiveAddActions = Drive.driver.FindElement(By.XPath(ActualActiveAddActions));
                FinalActiveAddActions.Click();
            }
            else if (SelectOption == New)
            {
                string ActualNewAddActions = BeforeNewAddActions + Demand + MiddileBefNewAddActions + Job + MiddileAfterNewAddActions + Actions + AfterNewAddActions;
                IWebElement FinalNewAddActions = Drive.driver.FindElement(By.XPath(ActualNewAddActions));
                FinalNewAddActions.Click();
            }
        }


        [FindsBy(How = How.XPath, Using = "//*[@id='addPackagePopup']/div/div[1]")]
        public IWebElement AddPackageTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@id='servicePopupTitle']")]
        public IWebElement AddServiceTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='addPackagePopup']/div/div[1]")]
        public IWebElement AddOperationTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='appointmentPartsPopup']/div/div[1]")]
        public IWebElement AddMaterialTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='appointmentAopPopup']/div/div[1]")]
        public IWebElement AddAOPTitle { get; set; }


        public void ValidateAddPackageTitle(string ModalTitle)
        {
            if (ModalTitle == "Add Package")
            {
                Console.WriteLine(AddPackageTitle.Text);
            }
            else if (ModalTitle == "Add Service")
            {
                Console.WriteLine(AddServiceTitle.Text);
            }
            else if (ModalTitle == "Add Operation")
            {
                Console.WriteLine(AddOperationTitle.Text);
            }
            else if (ModalTitle == "Add Material")
            {
                Console.WriteLine(AddMaterialTitle.Text);
            }
            else if (ModalTitle == "Add AOP")
            {
                Console.WriteLine(AddAOPTitle.Text);
            }

        }


        [FindsBy(How = How.XPath, Using = "//*[@id='ProfileKey']")]
        public IWebElement AddOperationGroup { get; set; }

        string operationgroup = "(//mat-option[@role='option']/span)";

        [FindsBy(How = How.XPath, Using = "(//*[@id='AppointmentJobTable']/tbody/tr/td[2]//label)[1]")]
        public IWebElement selectJobFromTable { get; set; }

        public void AddingPackage(string selectOperation)
        {
            AddOperationGroup.Click();
            CustomLib.DropDownbyName(selectOperation, operationgroup);
            selectJobFromTable.Click();
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='addPackage']")]
        public IWebElement AddPackageOkBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='addManualService']")]
        public IWebElement AddServiceOkBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='saveOperation']")]
        public IWebElement AddOperationSaveBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='addMaterial']")]
        public IWebElement AddMaterialOkBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='addAopButton']")]
        public IWebElement AddAOPOkBtn { get; set; }

        public void AddModal(string ModalTitle)
        {
            if (ModalTitle == "Add Package")
            {
                AddPackageOkBtn.Click();
                CustomLib.AlertMessage();
            }
            else if (ModalTitle == "Add Service")
            {
                AddServiceOkBtn.Click();
                CustomLib.AlertMessage();
            }
            else if (ModalTitle == "Add Operation")
            {
                AddOperationSaveBtn.Click();
                CustomLib.AlertMessage();
            }
            else if (ModalTitle == "Add Material")
            {
                AddMaterialOkBtn.Click();
                CustomLib.AlertMessage();
            }
            else if (ModalTitle == "Add AOP")
            {
                AddAOPOkBtn.Click();
                CustomLib.AlertMessage();
            }

        }

        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'cancelPackage')]")]
        public IWebElement CancelPackageModalBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'cancelManualService')]")]
        public IWebElement CancelServiceModalBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'cancelOperation')]")]
        public IWebElement CancelOperationModalBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'cancelAopPopup')]")]
        public IWebElement CancelMaterialModalBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'cancelAopPopup')]")]
        public IWebElement CancelAOPModalBtn { get; set; }

        public void CancelModal(string ModalTitle)
        {
            if (ModalTitle == "Add Package")
            {
                CancelPackageModalBtn.Click();
            }
            else if (ModalTitle == "Add Service")
            {
                CancelServiceModalBtn.Click();
            }
            else if (ModalTitle == "Add Operation")
            {
                CancelOperationModalBtn.Click();
            }
            else if (ModalTitle == "Add Material")
            {
                CancelMaterialModalBtn.Click();
            }
            else if (ModalTitle == "Add AOP")
            {
                CancelAOPModalBtn.Click();
            }

        }

        string OtherServices = "(//div[@id='bosBillServices']/ul/li/label)";

        public void AddingService(string Service)
        {
            CustomLib.DropDownbyName(Service, OtherServices);
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='operationDescription']")]
        public IWebElement EnterDescription { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='Time']")]
        public IWebElement EnterQuantity { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='unitPrice']")]
        public IWebElement UnitPrice { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='salesPriceAmount']")]
        public IWebElement SalesPriceAmount { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@title='Add Row']")]
        public IWebElement AddRowInOperation { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@title='Delete Row']")]
        public IWebElement DeleteRowInOperation { get; set; }

        public void AddingOperation(string Description, string Quantity)
        {
            EnterDescription.SendKeys(Keys.Control + "A");
            EnterDescription.SendKeys(Keys.Delete);
            EnterDescription.SendKeys(Description);
            EnterQuantity.Clear();
            EnterQuantity.SendKeys(Quantity);
            EnterDescription.SendKeys(Keys.Tab);
            string unitPrice = UnitPrice.GetText();
            Console.WriteLine(unitPrice);
            CustomWait.WaitFortheLoadingIconDisappear2000();
            string salesPriceAmount = SalesPriceAmount.GetText();
            Console.WriteLine(salesPriceAmount);
            AddRowInOperation.Click();
            CustomWait.WaitFortheLoadingIconDisappear2000();
            DeleteRowInOperation.Click();
        }

        public void AgainAddingOperation(string Quantity)
        {
            EnterQuantity.Clear();
            EnterQuantity.SendKeys(Quantity);
            AddRowInOperation.Click();
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='adv_PartNo']")]
        public IWebElement EnterPartNo { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@id='partsSearchButton']")]
        public IWebElement EnterPartSearchBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='Quantity']")]
        public IWebElement Enterquantity { get; set; }

        public void AddingMaterial(string PartNo, string Quantity)
        {
            EnterPartNo.SendKeys(PartNo);
            EnterPartSearchBtn.Click();
            CustomWait.WaitFortheLoadingIconDisappear2000();
            Enterquantity.SendKeys(Keys.Control + "A");
            Enterquantity.SendKeys(Keys.Delete);
            Enterquantity.SendKeys(Quantity);
        }

        string BeforeAddAOPfromTable = "//table[@id='AppointmentAopTable']/tbody/tr/td[contains(text(),'";
        string AfterAddAOPfromTable = "')]/parent::*/td[1]/div/a";

        public void selectOperationGroup(string selectOperation)
        {
            AddOperationGroup.Click();
            CustomLib.DropDownbyName(selectOperation, operationgroup);
        }

        public void AddingAOP(string SalesPart)
        {
            string FinalAddAOPfromTable = BeforeAddAOPfromTable + SalesPart + AfterAddAOPfromTable;
            IWebElement MainAddAOPfromTable = Drive.driver.FindElement(By.XPath(FinalAddAOPfromTable));
            ((IJavaScriptExecutor)Drive.driver).ExecuteScript("arguments[0].scrollIntoView(true);", MainAddAOPfromTable);
            MainAddAOPfromTable.Click();
        }

        string BeforeDeleteAOPfromTable = "//table[@id='AppointmentAddedAopTable']/tbody/tr/td[contains(text(),'";
        string AfterDeleteAOPfromTable = "')]/parent::*/td[1]/div/a";

        public void DeletingAOP(string SalesPart)
        {
            CustomWait.WaitFortheLoadingIconDisappear2000();
            string FinalDeleteAOPfromTable = BeforeDeleteAOPfromTable + SalesPart + AfterDeleteAOPfromTable;
            IWebElement MainDeleteAOPfromTable = Drive.driver.FindElement(By.XPath(FinalDeleteAOPfromTable));
            ((IJavaScriptExecutor)Drive.driver).ExecuteScript("arguments[0].scrollIntoView(true);", MainDeleteAOPfromTable);
            MainDeleteAOPfromTable.Click();
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='WarrantyPreApproval']/div/div/label")]
        public IWebElement CustomerApprovalCheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//td/div[contains(@class,'dropdown-button')]")]
        public IWebElement Actions { get; set; }

        string ActionDropdown = "((//div[@class='divAppointmentDemandActions']/ul)[2]/li//span)";


        [FindsBy(How = How.XPath, Using = "//*[@id='AfConfirmationModalPopup']//div[@class='appointment-comment-title']")]
        public IWebElement ApproveBehalfCustomerTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='AfConfirmationModalPopup']/div/div[3]/div[1]/p")]
        public IWebElement ApproveBehalfCustomerText { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='AfConfirmationModalPopup']/div/div[3]/div[2]/input")]
        public IWebElement ApproveBehalfCustomerInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='btnSaveComments']")]
        public IWebElement ApproveBehalfCustomerSave { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'cancelGlobalComments')]")]
        public IWebElement ApproveBehalfCustomerCancel { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='WarrantyPreApproval']/div/span")]
        public IWebElement ApproveBehalfCustomerChecked { get; set; }

        public void GiveCustomerApproval(string DropDownAction, string Comment = null)
        {
            ((IJavaScriptExecutor)Drive.driver).ExecuteScript("arguments[0].scrollIntoView(true);", CustomerApprovalCheckBox);
            CustomerApprovalCheckBox.Click();
            ((IJavaScriptExecutor)Drive.driver).ExecuteScript("arguments[0].scrollIntoView(true);", Actions);
            Actions.Click();
            CustomWait.WaitFortheLoadingIconDisappear2000();
            CustomLib.DropDownbyName(DropDownAction, ActionDropdown);
            Console.WriteLine(ApproveBehalfCustomerTitle.Text);
            Console.WriteLine(ApproveBehalfCustomerText.Text);
            ApproveBehalfCustomerInput.SendKeys(Comment);
            ApproveBehalfCustomerSave.Click();
            CustomWait.WaitFortheLoadingIconDisappear3000();
            bool ValidateApproval = ApproveBehalfCustomerChecked.Displayed;
            Console.WriteLine("Approve Behalf of Customer is" + "_" + ValidateApproval);
        }

        [FindsBy(How = How.XPath, Using = "//td[@data-th='Warranty']//label")]
        public IWebElement WarrantyCheckBox { get; set; }

        public void GiveWarranty()
        {
            CustomWait.WaitFortheLoadingIconDisappear2000();
            WarrantyCheckBox.Click();
        }

        [FindsBy(How = How.XPath, Using = "(//tbody[@id='AppointmentJobDetailsBody']/tr/td[13]/input)[2]")]
        public IWebElement FixedPriceChange { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='priceCausePopup']//div[@class='appointment-comment-title']")]
        public IWebElement CauseCodesDeletionTitle { get; set; }

        string CodesDropDown = "(//div[@id='priceCausePopup']//div[contains(@class,'priceCausePopup')]//label)";

        [FindsBy(How = How.XPath, Using = "//textarea[@id='priceCauseComments']")]
        public IWebElement AddCommentInCauseCodeDeletion { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='savePriceCause']")]
        public IWebElement OKCauseComments { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'cancelPriceCause')]")]
        public IWebElement CancelPriceCause { get; set; }
        

        public void ChangingFixedPrice(string FixedPrice , string Code , string Comment = null )
        {
            Actions act = new Actions(Drive.driver);
            CustomWait.WaitFortheLoadingIconDisappear2000();
            ((IJavaScriptExecutor)Drive.driver).ExecuteScript("arguments[0].scrollIntoView(true);", FixedPriceChange);
            FixedPriceChange.Click();
            CustomWait.WaitFortheLoadingIconDisappear2000();
            act.KeyDown(FixedPriceChange ,Keys.Control).SendKeys("A").Build().Perform();
            CustomWait.WaitFortheLoadingIconDisappear2000();
            FixedPriceChange.SendKeys(FixedPrice);
            act.KeyDown(FixedPriceChange, Keys.Enter).Build().Perform();
            Console.WriteLine(CauseCodesDeletionTitle.Text);
            CustomWait.WaitFortheLoadingIconDisappear2000();
            CustomLib.DropDownbyName(Code, CodesDropDown);
            AddCommentInCauseCodeDeletion.SendKeys(Comment);
            OKCauseComments.Click();
            CustomLib.AlertMessage();
            CustomWait.WaitFortheLoadingIconDisappear2000();
        }

        [FindsBy(How = How.XPath, Using = "//button[@id='saveAppointment']")]
        public IWebElement SaveAppointment { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='deleteAppointment']")]
        public IWebElement DeleteAppointment { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'appointmentCloseButton')]")]
        public IWebElement AppointmentCloseButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='appointmentRefreshBtn']")]
        public IWebElement AppointmentRefreshBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='sendToDMS']")]
        public IWebElement SendToDMS { get; set; }

        public void AppointmentButtons(string ActionBtn)
        {
            if (ActionBtn == "Save")
            {
                SaveAppointment.Click();
            }
            else if (ActionBtn == "Delete")
            {
                DeleteAppointment.Click();
            }
            else if (ActionBtn == "Cancel")
            {
                AppointmentCloseButton.Click();
            }
            else if (ActionBtn == "DMS")
            {
                SendToDMS.Click();
            }
            else if (ActionBtn == "Refresh")
            {
                AppointmentRefreshBtn.Click();
            }
        }










    }
}
