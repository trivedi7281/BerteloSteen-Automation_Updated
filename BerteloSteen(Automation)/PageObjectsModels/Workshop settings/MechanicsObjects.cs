using DARS.Automation_.Helper;
using DARS.Automation_.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Linq;
using System.Text;

namespace DARS.Automation_.PageObjectsModels.Workshop_settings
{

    class MechanicsObjects
    {

        [Obsolete]
        public MechanicsObjects()
        {
            PageFactory.InitElements(Drive.driver, this);

        }

        [FindsBy(How = How.XPath, Using = "//ul/li[@id='engli']/a")]
        public IWebElement engLanguage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#darsdealer\\  > a")]
        public IWebElement clickonDARS { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@id='darsdealer ']")]
        public IWebElement DARSHighlight { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='/en-US/Administration/Mechanics/List']")]
        public IWebElement clickonMechanicsTab { get; set; }


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
            CustomWait.FluentWaitbyXPath("clickonMechanicsTab");
            CustomLib.Highlightelement(clickonMechanicsTab);
            clickonMechanicsTab.Click();

        }
        /// <summary>
        /// Verify the Page Title
        /// : As module wise we entered into the different modules 
        /// so we can verify its title's.
        /// </summary>
        public void GetPageTitle()
        {
            CustomWait.FluentWaitbyXPath("clickonMechanicsTab");
            string title = Drive.driver.Title;
            Console.WriteLine("Title is:" + title);
            Assert.AreEqual("Mechanics", title);
        }


        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Select Dealer']")]
        public IWebElement SelectDealers { get; set; }


        string MechanicDealerDropDown = " (//mat-option[@name='advSearchDealer']/span/span)";



        /// <summary>
        /// Select Dealer
        /// : here we can check the functionality that once we click on 
        /// dealer dropdown and then enter entry on it and select that dealer.
        /// </summary>
        /// <param name="DealerName"></param>
        public void SelectDealer(string RandomNumberofActualDealerNumber, string ActualDealerNumber)
        {
            CustomWait.FluentWaitbyXPath("selectDealers");
            SelectDealers.Clear();
            SelectDealers.SendKeys(RandomNumberofActualDealerNumber);
            CustomWait.WaitFortheLoadingIconDisappear2000();
            CustomLib.DealerDropDown(ActualDealerNumber, MechanicDealerDropDown);
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

        //Xpath for the Mechanics Table 
        [FindsBy(How = How.XPath, Using = "//table[@matsortactive='name'][@matsortdirection='asc']")]
        public IWebElement Mechanicstable { get; set; }


        public void CheckTablefoundtheSearchData()
        {

            CustomWait.FluentWaitbyXPath("Mechanicstable");
            TableUtil.ReadTable(Mechanicstable);
            CustomWait.FluentWaitbyXPath("Mechanicstable");
            string VerifyName = TableUtil.ReadCell("Name", 1);
            Console.WriteLine("Name in Table cell : " + VerifyName);
            Assert.AreEqual("Arvid Jensen", VerifyName);
        }

        //Xpath for the Mechanics Table cell (Edit Button) 
        [FindsBy(How = How.XPath, Using = "//tbody[@role='rowgroup']/tr[1]/td[12]/div/a[1]")]
        public IWebElement EditButton { get; set; }


        public void clickintoActionBtn()
        {
            CustomWait.FluentWaitbyXPath("EditButton");
            CustomLib.Highlightelement(EditButton);
            EditButton.Click();
            CustomWait.WaitFortheLoadingIconDisappear2000();

        }

        //Xpath for the Mechanics Slider Page Header
        [FindsBy(How = How.XPath, Using = "//*[@id='addMechanicsDetails']/div[1]/p")]
        public IWebElement MechanicsAdditionalDetails { get; set; }

        //Xpath for the General Info Tab
        [FindsBy(How = How.XPath, Using = "//*[@id='addMechanicsDetails']/div[2]/ul/li/a[@aria-controls='generalInfo']")]
        public IWebElement GeneralInfo { get; set; }

        //Xpath for the associatedBrands Info Tab
        [FindsBy(How = How.XPath, Using = "//*[@id='addMechanicsDetails']/div[2]/ul/li/a[@aria-controls='associatedBrands']")]
        public IWebElement AssociateBrands { get; set; }

        //Xpath for the mechanicLeaves Info Tab
        [FindsBy(How = How.XPath, Using = "//*[@id='addMechanicsDetails']/div[2]/ul/li/a[@aria-controls = 'mechanicLeaves']")]
        public IWebElement MechanicLeaves { get; set; }

        //Xpath for the addMechanicLeave button into mechanicLeaves Info Tab
        [FindsBy(How = How.XPath, Using = "//*[@id='addMechanicLeave']")]
        public IWebElement AddMechanicLeaves { get; set; }

        //Xpath for the Mechanics POP Page Header 
        [FindsBy(How = How.XPath, Using = "//*[@id='mechanicLeavePopup']/div[1]/div[1]")]
        public IWebElement VerifyMechanicLeavesHeader { get; set; }

        //Xpath for the Mechanics Name in Mechanic POP Page
        [FindsBy(How = How.XPath, Using = "//span[@id='mechanicName']")]
        public IWebElement VerifyMechanicName { get; set; }


        public void GeneralInfoTab()
        {
            CustomWait.FluentWaitbyXPath("MechanicsAdditionalDetails");
            string PageHeader = MechanicsAdditionalDetails.Text;
            Assert.AreEqual("Mechanics", PageHeader);
            Console.WriteLine("Page Header is :" + PageHeader);
            CustomWait.WaitFortheLoadingIconDisappear5000();
            CustomWait.FluentWaitbyXPath("GeneralInfo");
            GeneralInfo.Click();

        }

        public void AssociateBrandsTab()
        {
            CustomWait.WaitFortheLoadingIconDisappear2000();
            AssociateBrands.Click();
        }





        //<!--------------------------------------------------------------Mechanics Tab------------------------------------------------------------------------------->

        public void MechanicLeavesTab()
        {
            CustomWait.FluentWaitbyXPath("MechanicLeaves");
            MechanicLeaves.Click();
            CustomWait.FluentWaitbyXPath("AddMechanicLeaves");
        }

        public void AddMechanicLeavesTab()
        {

            AddMechanicLeaves.Click();
            CustomWait.FluentWaitbyXPath("VerifyMechanicLeavesHeader");
            string MechanicLeavePageHeader = VerifyMechanicLeavesHeader.Text;
            Assert.AreEqual("Mechanic Leave", MechanicLeavePageHeader);
            Console.WriteLine("Page Header is :" + MechanicLeavePageHeader);

            CustomWait.FluentWaitbyXPath("VerifyMechanicName");
            string MechanicName = VerifyMechanicName.Text;
            Assert.AreEqual("Arvid Jensen", MechanicName);
            Console.WriteLine("Mechanic Name is :" + MechanicName);
        }


        //Xpath for the DateRange 
        [FindsBy(How = How.XPath, Using = "//*[@id='TypeDateRange']")]
        public IWebElement DateRange { get; set; }


        //Xpath for the LeaveComment
        [FindsBy(How = How.XPath, Using = "//*[@id='mechanicLeaveComment']")]
        public IWebElement PassComment { get; set; }

        //Xpath for the StartDate Validation
        [FindsBy(How = How.XPath, Using = "//span[@id='LeaveStartDateRequired']")]
        public IWebElement StartDateError { get; set; }

        //Xpath for the EndDate Validation
        [FindsBy(How = How.XPath, Using = "//span[@id='LeaveEndDateRequired']")]
        public IWebElement EndDateError { get; set; }


        public void CheckMechanicLeavePageValidations()
        {
            CustomLib.Highlightelement(saveMechanicLeaveBtn);
            saveMechanicLeaveBtn.Click();
            CustomWait.FluentWaitbyXPath("StartDateError");
            string StartDateErrorText = StartDateError.Text;
            Assert.AreEqual("Start date is required", StartDateErrorText);
            Console.WriteLine("Start Date Error is :" + StartDateErrorText);
            CustomWait.FluentWaitbyXPath("EndDateError");
            string EndDateErrorText = EndDateError.Text;
            Assert.AreEqual("End date is required", EndDateErrorText);
            Console.WriteLine("End Date Error is :" + EndDateErrorText);
            CustomWait.FluentWaitbyXPath("CancelMechanicLeavePage");
            CustomLib.Highlightelement(CancelMechanicLeavePage);
            CancelMechanicLeavePage.Click();


        }

        //Xpath for the SaveBtn
        [FindsBy(How = How.CssSelector, Using = "#saveMechanicLeave")]
        public IWebElement saveMechanicLeaveBtn { get; set; }

        //Xpath for the CancelBtn
        [FindsBy(How = How.XPath, Using = "//*[@id='mechanicLeavePopup']/div/div[3]/div[8]/button[2]")]
        public IWebElement CancelMechanicLeavePage { get; set; }
        //Xpath for the StartDate
        [FindsBy(How = How.XPath, Using = "//label[@id='lblStartDate']/parent::*//input[@id='LeaveStartDate' and @name='StartDate']")]
        public IWebElement StartDate { get; set; }

        //Xpath for the EndDate
        [FindsBy(How = How.XPath, Using = "//label[@id='lblEndDate']/parent::*//input[@id='LeaveEndDate' and @name='EndDate']")]
        public IWebElement EndDate { get; set; }

        public void EnterStartDateMechanicLeaveDetails(int index, string selectMonth, string selectYear, string selectdate)
        {
            //CustomLib.FluentWaitbyXPath(Drive.driver, "AddMechanicLeaves");
            //AddMechanicLeaves.Click();
            if (DateRange.Selected)
            {
                CustomWait.WaitFortheLoadingIconDisappear2000();
                PassComment.SendKeys("Today I am Not feeling Well.");
                StartDate.Click();
                CustomWait.WaitFortheLoadingIconDisappear2000();
                CustomLib.HandleCalendar(index, selectMonth, selectYear, selectdate);
                CustomWait.WaitFortheLoadingIconDisappear5000();

            }

        }

        public void EnterEndDateMechanicLeaveDetails(int index, string selectMonth, string selectYear, string selectdate)
        {
            CustomWait.WaitFortheLoadingIconDisappear2000();
            EndDate.Click();
            CustomWait.WaitFortheLoadingIconDisappear2000();
            CustomLib.HandleCalendar(index, selectMonth, selectYear, selectdate);
            CustomWait.WaitFortheLoadingIconDisappear2000();
            saveMechanicLeaveBtn.Click();
            CustomWait.WaitFortheLoadingIconDisappear10000();
        }



        public void MechanicTablesLeaveDelete(int startDate, int endDate, int Month, int Year)
        {
            CustomLib.DeleteMechanicLeaves(startDate, endDate, Month, Year);

        }


        //Hardwareworking.Hover(saveMechanicLeaveBtn);
        //CustomWait.WaitFortheLoadingIconDisappear10000();
        //(//*[@id="toast-container"])//div[@role='alertdialog']
        //(//mat-option[@role='option']/span)[2]
        //(//div[@class = 'xdsoft_label xdsoft_month'])[1] click
        //(//div[@class = 'xdsoft_option ' and @data-value = 'Month_Number'])[1] found the month and click // here 0 to 11 months are there....
        // (//div[@class='xdsoft_option ' and @data-value='Year_Number'])[1] year selection
        //(//div[@class= 'xdsoft_calendar'])[1]/table/tbody/tr/td[@data-date ='Date_Number']
        //(//div[@class= 'xdsoft_calendar'])[1]/table/tbody/tr/td[contains(@class , 'disabled')]


        ////Xpath for the Close Mechanicspop Page 
        //[FindsBy(How = How.XPath, Using = "//*[@id='mechanicLeavePopup']/div/div[1]/div[1]/ul[1]/li[1]/a[1]")]
        //public IWebElement CancelMechanicLeavePage { get; set; }
        ////div[@class = 'button-container ng-tns-c468-230']/button[2]
        //public void CloseMechanicLeavePopupPage()
        //{
        //    CustomLib.FluentWaitbyXPath(Drive.driver, "CancelMechanicLeavePage");
        //    CancelMechanicLeavePage.Click();

        //}
        //<!----------------------********-------------------------------Mechanics Tab------------------------------------**********--------------------------------->





        //<!----------------------------------------------------------mechanicBusinessAbsenceTab------------------------------------------------------------->
        //Xpath for the mechanicBusinessAbsence Info Tab
        [FindsBy(How = How.XPath, Using = "//*[@id='addMechanicsDetails']/div[2]/ul/li/a[@aria-controls = 'mechanicBusinessAbsence']")]
        public IWebElement mechanicBusinessAbsence { get; set; }

        //Xpath for the mechanicCommunication Info Tab
        [FindsBy(How = How.XPath, Using = "//*[@id='addMechanicsDetails']/div[2]/ul/li/a[@aria-controls = 'mechanicCommunication']")]
        public IWebElement mechanicCommunication { get; set; }

        //Xpath for the addMechanicBusinessAbsenceBtn 
        [FindsBy(How = How.XPath, Using = "//button[@id='addMechanicBusinessAbsence']")]
        public IWebElement addMechanicBusinessAbsenceBtn { get; set; }

        //Xpath for the Mechanic Business Absence POP Page Header 
        [FindsBy(How = How.XPath, Using = "//*[@id='mechanicBusinessAbsencePopup']/div/div[1]")]
        public IWebElement VerifymechanicBusinessAbsenceHeader { get; set; }

        //Xpath for the Mechanics Name in Mechanic Business Absence POP Page
        [FindsBy(How = How.XPath, Using = "//span[@id='mechanicName']")]
        public IWebElement VerifyMechanicNameinMBAPOPPage { get; set; }

        //Xpath for the StartDate Validation
        [FindsBy(How = How.XPath, Using = "//*[@id='AbsenceStartDateRequired']")]
        public IWebElement StartDateValidation { get; set; }

        //Xpath for the EndDate Validation
        [FindsBy(How = How.XPath, Using = " //*[@id='AbsenceEndDateRequired']")]
        public IWebElement EndDateValidation { get; set; }

        //Xpath for the None in Mechanic absence Page 
        [FindsBy(How = How.XPath, Using = "//*[@id='TypeDateRange']")]
        public IWebElement NoneinMechanicAbsencePage { get; set; }

        //Xpath for the TypeWeeklyinMechanicAbsencePage 
        [FindsBy(How = How.XPath, Using = "//*[@id='TypeWeekly']")]
        public IWebElement TypeWeeklyinMechanicAbsencePage { get; set; }

        //Xpath for the DescriptionValidation 
        [FindsBy(How = How.XPath, Using = "//*[@id='AbsenceDescriptionRequired']")]
        public IWebElement DescriptionValidation { get; set; }

        //Xpath for the Description 
        [FindsBy(How = How.XPath, Using = "//*[@id='AbsenceDescription']")]
        public IWebElement AddDescription { get; set; }

        //Xpath for the saveMechanicBusinessAbsenceBtn
        [FindsBy(How = How.XPath, Using = "//*[@id='saveMechanicBusinessAbsence']")]
        public IWebElement saveMechanicBusinessAbsenceBtn { get; set; }

        //Xpath for the CancelMechanicBusinessAbsencePage
        [FindsBy(How = How.XPath, Using = "//*[@id='mechanicBusinessAbsencePopup']/div/div[3]/div[10]/button[2]")]
        public IWebElement CancelMechanicBusinessAbsencePage { get; set; }


        public void mechanicBusinessAbsenceTab()
        {
            CustomWait.FluentWaitbyXPath("mechanicBusinessAbsence");
            mechanicBusinessAbsence.Click();
            CustomWait.FluentWaitbyXPath("addMechanicBusinessAbsenceBtn");
        }

        public void addMechanicBusinessAbsenceTab()
        {

            addMechanicBusinessAbsenceBtn.Click();
            CustomWait.FluentWaitbyXPath("VerifymechanicBusinessAbsenceHeader");
            string MechanicBusinessAbsenceHeader = VerifymechanicBusinessAbsenceHeader.Text;
            Assert.AreEqual("Mechanic Business Absence", MechanicBusinessAbsenceHeader);
            Console.WriteLine("Page Header is :" + MechanicBusinessAbsenceHeader);

            CustomWait.FluentWaitbyXPath("VerifyMechanicNameinMBAPOPPage");
            string MBAPOPPageMechanicName = VerifyMechanicNameinMBAPOPPage.Text;
            Assert.AreEqual("Arvid Jensen", MBAPOPPageMechanicName);
            Console.WriteLine("Mechanic Name is :" + MBAPOPPageMechanicName);
        }



        public void CheckMechanicBusinessAbsencePageValidations()
        {
            CustomLib.Highlightelement(saveMechanicBusinessAbsenceBtn);
            saveMechanicBusinessAbsenceBtn.Click();
            CustomWait.FluentWaitbyXPath("StartDateValidation");
            string StartDateValidationText = StartDateValidation.Text;
            Assert.AreEqual("Start date is required", StartDateValidationText);
            Console.WriteLine("Start Date Error is :" + StartDateValidationText);

            CustomWait.FluentWaitbyXPath("EndDateValidation");
            string EndDateValidationText = EndDateValidation.Text;
            Assert.AreEqual("End date is required", EndDateValidationText);
            Console.WriteLine("End Date Error is :" + EndDateValidationText);

            CustomWait.FluentWaitbyXPath("DescriptionValidation");
            string DescriptionValidationText = DescriptionValidation.Text;
            Assert.AreEqual("Description is Required", DescriptionValidationText);
            Console.WriteLine("Description error text is :" + DescriptionValidationText);

            CustomWait.FluentWaitbyXPath("CancelMechanicBusinessAbsencePage");
            ((IJavaScriptExecutor)Drive.driver).ExecuteScript("window.scrollBy(0,200)");
            CustomLib.Highlightelement(CancelMechanicBusinessAbsencePage);
            CancelMechanicBusinessAbsencePage.Click();

        }

        public void EnterMechanicBusinessAbsenceDetails()
        {
            if (NoneinMechanicAbsencePage.Selected)
            {
                CustomWait.FluentWaitbyXPath("addMechanicBusinessAbsenceBtn");
                addMechanicBusinessAbsenceBtn.Click();
                IJavaScriptExecutor js = (IJavaScriptExecutor)Drive.driver;
                js.ExecuteScript("document.getElementById('AbsenceStartDate').value ='20.3.2021 20:25'"); // id has been mentioned into the code of Start date field
                CustomWait.WaitFortheLoadingIconDisappear2000();
                js.ExecuteScript("document.getElementById('AbsenceEndDate').value ='21.3.2021 20:25'"); // id has been mentioned into the code of End date field
                CustomWait.WaitFortheLoadingIconDisappear2000();
                AddDescription.SendKeys("Business absence at Monday and Wednesday");
                Hardwareworking.Hover(saveMechanicBusinessAbsenceBtn);
                CustomWait.WaitFortheLoadingIconDisappear2000();
            }
            //else if(TypeWeeklyinMechanicAbsencePage.Selected)
            //{


            //}

        }




        //<!-----------------------------*****---------------------------------mechanicBusinessAbsence Tab-----------------------------------------*****-------------------------------------->

        public void MechanicRecipientListTab(string value)
        {
            CustomWait.FluentWaitbyXPath("mechanicCommunication");
            mechanicCommunication.Click();

        }



        //Xpath for the Mechanics SliderPage Close Button 
        [FindsBy(How = How.XPath, Using = "//a[@id='closeButton']/i")]
        public IWebElement ExitFromMechanicAdditionalDetailsPage { get; set; }

        public void ExitFromMechanicDetailsPage()
        {
            CustomLib.Highlightelement(ExitFromMechanicAdditionalDetailsPage);
            CustomWait.WaitFortheLoadingIconDisappear2000();
            Hardwareworking.Hover(ExitFromMechanicAdditionalDetailsPage);

        }

    }
}
