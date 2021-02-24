using DARS.Automation_.GetSet;
using DARS.Automation_.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Linq;

namespace DARS.Automation_.PageObjectsModels
{

    class MechanicsObjects
    {
        [Obsolete]
        public MechanicsObjects()
        {
            PageFactory.InitElements(Drive.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//li[@id='engli']")]
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
            CustomWait.FluentWaitbyXPath(Drive.driver, "engLanguage");
            CustomLib.Highlightelement(engLanguage);
            engLanguage.Clicks();
            //Click on DARS Tab
            CustomLib.Highlightelement(DARSHighlight);
            CustomWait.FluentWaitbyXPath(Drive.driver, "clickonDARS");
            clickonDARS.Click();
            CustomWait.FluentWaitbyXPath(Drive.driver, "clickonMechanicsTab");
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
            CustomWait.FluentWaitbyXPath(Drive.driver, "clickonMechanicsTab");
            string title = Drive.driver.Title;
            Console.WriteLine("Title is:" + title);
            Assert.AreEqual("Mechanics", title);
        }


        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Select Dealer']")]
        public IWebElement selectDealers { get; set; }

        //Here this xpath have been changed as per we select any other dealer
        [FindsBy(How = How.XPath, Using = "//mat-option[@id='1']")]
        public IWebElement EnteredselectedDealer { get; set; }


        [FindsBy(How = How.XPath, Using = "//mat-option[@id='109']")]
        public IWebElement SelectAnotherDealer { get; set; }

        /// <summary>
        /// Select Dealer
        /// : here we can check the functionality that once we click on 
        /// dealer dropdown and then enter entry on it and select that dealer.
        /// </summary>
        /// <param name="DealerName"></param>
        public void SelectDealer(string DealerName, string DealerName2 = null)
        {
            CustomWait.FluentWaitbyXPath(Drive.driver, "selectDealers");
            selectDealers.Clear();
            selectDealers.SendKeys(DealerName);
            CustomWait.FluentWaitbyXPath(Drive.driver, "EnteredselectedDealer");
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
            CustomWait.FluentWaitbyXPath(Drive.driver, "ClickOnSearchBar");
            ClickOnSearchBar.SendKeys(SearchItem);
            ClickOnSearchBtn.Click();

        }


        [FindsBy(How = How.XPath, Using = "//*[@id='pdfExportButton']")]
        public IWebElement PDF { get; set; }


        public void clickToCreatePDF()
        {
            CustomWait.FluentWaitbyXPath(Drive.driver, "PDF");
            PDF.Clicks();
            CustomWait.WaitFortheLoadingIconDisappear2000();
            //Here we have to compare PDF Data with our Page Source Data.
        }



        [FindsBy(How = How.XPath, Using = "//*[@id='excelExportButton']")]
        public IWebElement Excel { get; set; }


        public void clickToCreateExcel()
        {
            CustomWait.FluentWaitbyXPath(Drive.driver, "Excel");
            Excel.Clicks();
            CustomWait.WaitFortheLoadingIconDisappear5000();
            //Here we have to compare Excel Data with our Page Source Data.
        }

        //Xpath for the Mechanics Table 
        [FindsBy(How = How.XPath, Using = "//table[@matsortactive='name'][@matsortdirection='asc']")]
        public IWebElement Mechanicstable { get; set; }


        public void CheckTablefoundtheSearchData()
        {
            Drive.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);
            CustomWait.FluentWaitbyXPath(Drive.driver, "Mechanicstable");
            TableUtil.ReadTable(Mechanicstable);
            CustomWait.FluentWaitbyXPath(Drive.driver, "Mechanicstable");
            string VerifyName = TableUtil.ReadCell("Name", 1);
            Console.WriteLine("Name in Table cell : " + VerifyName);
            Assert.AreEqual("Alexander Almeland Jensen", VerifyName);
        }

        //Xpath for the Mechanics Table cell (Edit Button) 
        [FindsBy(How = How.XPath, Using = "//tbody[@role='rowgroup']/tr[1]/td[12]/div/a[1]")]
        public IWebElement EditButton { get; set; }


        public void clickintoActionBtn()
        {
            CustomWait.FluentWaitbyXPath(Drive.driver, "EditButton");
            CustomLib.Highlightelement(EditButton);
            EditButton.Click();
            CustomWait.WaitFortheLoadingIconDisappear5000();

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
            CustomWait.FluentWaitbyXPath(Drive.driver, "MechanicsAdditionalDetails");
            string PageHeader = MechanicsAdditionalDetails.Text;
            Assert.AreEqual("Mechanics", PageHeader);
            Console.WriteLine("Page Header is :" + PageHeader);
            CustomWait.WaitFortheLoadingIconDisappear5000();
            CustomWait.FluentWaitbyXPath(Drive.driver, "GeneralInfo");
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
            CustomWait.FluentWaitbyXPath(Drive.driver, "MechanicLeaves");
            MechanicLeaves.Click();
            CustomWait.FluentWaitbyXPath(Drive.driver, "AddMechanicLeaves");
        }

        public void AddMechanicLeavesTab()
        {

            AddMechanicLeaves.Click();
            CustomWait.FluentWaitbyXPath(Drive.driver, "VerifyMechanicLeavesHeader");
            string MechanicLeavePageHeader = VerifyMechanicLeavesHeader.Text;
            Assert.AreEqual("Mechanic Leave", MechanicLeavePageHeader);
            Console.WriteLine("Page Header is :" + MechanicLeavePageHeader);

            CustomWait.FluentWaitbyXPath(Drive.driver, "VerifyMechanicName");
            string MechanicName = VerifyMechanicName.Text;
            Assert.AreEqual("Alexander Almeland Jensen", MechanicName);
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

        //Xpath for the SaveBtn
        [FindsBy(How = How.CssSelector, Using = "#saveMechanicLeave")]
        public IWebElement saveMechanicLeaveBtn { get; set; }

        //Xpath for the CancelBtn
        [FindsBy(How = How.XPath, Using = "//*[@id='mechanicLeavePopup']/div/div[3]/div[8]/button[2]")]
        public IWebElement CancelMechanicLeavePage { get; set; }


        //Xpath for the StartDate
        [FindsBy(How = How.XPath, Using = "//input[@id='LeaveStartDate']")]
        public IWebElement StartDate { get; set; }


      


        public void CheckMechanicLeavePageValidations()
        {
            CustomLib.Highlightelement(saveMechanicLeaveBtn);
            saveMechanicLeaveBtn.Click();
            CustomWait.FluentWaitbyXPath(Drive.driver, "StartDateError");
            string StartDateErrorText = StartDateError.Text;
            Assert.AreEqual("Start date is required", StartDateErrorText);
            Console.WriteLine("Start Date Error is :" + StartDateErrorText);
            CustomWait.FluentWaitbyXPath(Drive.driver, "EndDateError");
            string EndDateErrorText = EndDateError.Text;
            Assert.AreEqual("End date is required", EndDateErrorText);
            Console.WriteLine("End Date Error is :" + EndDateErrorText);
            CustomWait.FluentWaitbyXPath(Drive.driver, "CancelMechanicLeavePage");
            CustomLib.Highlightelement(CancelMechanicLeavePage);
            CancelMechanicLeavePage.Click();


        }

        public void EnterMechanicLeaveDetails()
        {
             //CustomLib.FluentWaitbyXPath(Drive.driver, "AddMechanicLeaves");
             //AddMechanicLeaves.Click();
            if (DateRange.Selected)
            {
                CustomWait.WaitFortheLoadingIconDisappear2000();
                PassComment.SendKeys("Today I am Not feeling Well.");
                StartDate.Click();
                CustomWait.WaitFortheLoadingIconDisappear2000();
                //CustomLib.HandleCalendar("April","20");
                int RowNumbers = Drive.driver.FindElements(By.XPath("(//div[@class='xdsoft_calendar'])[1]/table/tbody/tr")).Count();
                Console.WriteLine("Rows are: " + RowNumbers);
                int ColumnNumbers = Drive.driver.FindElements(By.XPath(" (//div[@class='xdsoft_calendar'])[1]/table/tbody/tr[1]/td")).Count();
                Console.WriteLine("Columns are: " + ColumnNumbers);

                string firstPart = "(//div[@class='xdsoft_calendar'])[1]/table/tbody/tr[";
                string secondPart = "]/td[";
                string thirdPart = "]";

                for(int i=1;  i<=RowNumbers;  i++)
                {
                    for(int j=1;  j<=ColumnNumbers;  j++)
                    {
                        string finalPart = firstPart + i + secondPart + j + thirdPart;
                        Console.WriteLine(finalPart);
                        string dates = Drive.driver.FindElement(By.XPath(finalPart)).Text;
                        Console.WriteLine(dates);

                    }
                }


                string RowData = Drive.driver.FindElement(By.XPath(" (//div[@class='xdsoft_calendar'])[1]/table/tbody/tr[1]/td[4]")).Text;
                Console.WriteLine("RowData by Static Method is: " + RowData);
                string RowDatadynamic = Drive.driver.FindElement(By.XPath("(//td[@data-date='1'])[1]/div")).Text;
                Console.WriteLine("RowData by dynamic Method is: " + RowDatadynamic);

                
                //IJavaScriptExecutor js = (IJavaScriptExecutor)Drive.driver;
                //js.ExecuteScript("document.getElementById('LeaveStartDate').value ='22.3.2021'"); // id has been mentioned into the code of Start date field
                //CustomLib.WaitFortheLoadingIconDisappear2000();
                //js.ExecuteScript("document.getElementById('LeaveEndDate').value ='23.3.2021'"); // id has been mentioned into the code of End date field
                //CustomLib.WaitFortheLoadingIconDisappear5000();
                ((IJavaScriptExecutor)Drive.driver).ExecuteScript("window.scrollBy(0,500);");
                //saveMechanicLeaveBtn.Click();
                Hardwareworking.Hover(saveMechanicLeaveBtn);
                CustomWait.WaitFortheLoadingIconDisappear10000();
            }

        }
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
        //<!-------------------------------********-------------------------------Mechanics Tab------------------------------------------**********------------------------------------->





        //<!--------------------------------------------------------------mechanicBusinessAbsence Tab------------------------------------------------------------------------------->
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
            CustomWait.FluentWaitbyXPath(Drive.driver, "mechanicBusinessAbsence");
            mechanicBusinessAbsence.Click();
            CustomWait.FluentWaitbyXPath(Drive.driver, "addMechanicBusinessAbsenceBtn");
        }

        public void addMechanicBusinessAbsenceTab()
        {

            addMechanicBusinessAbsenceBtn.Click();
            CustomWait.FluentWaitbyXPath(Drive.driver, "VerifymechanicBusinessAbsenceHeader");
            string MechanicBusinessAbsenceHeader = VerifymechanicBusinessAbsenceHeader.Text;
            Assert.AreEqual("Mechanic Business Absence", MechanicBusinessAbsenceHeader);
            Console.WriteLine("Page Header is :" + MechanicBusinessAbsenceHeader);

            CustomWait.FluentWaitbyXPath(Drive.driver, "VerifyMechanicNameinMBAPOPPage");
            string MBAPOPPageMechanicName = VerifyMechanicNameinMBAPOPPage.Text;
            Assert.AreEqual("Alexander Almeland Jensen", MBAPOPPageMechanicName);
            Console.WriteLine("Mechanic Name is :" + MBAPOPPageMechanicName);
        }



        public void CheckMechanicBusinessAbsencePageValidations()
        {
            CustomLib.Highlightelement(saveMechanicBusinessAbsenceBtn);
            saveMechanicBusinessAbsenceBtn.Click();
            CustomWait.FluentWaitbyXPath(Drive.driver, "StartDateValidation");
            string StartDateValidationText = StartDateValidation.Text;
            Assert.AreEqual("Start date is required", StartDateValidationText);
            Console.WriteLine("Start Date Error is :" + StartDateValidationText);

            CustomWait.FluentWaitbyXPath(Drive.driver, "EndDateValidation");
            string EndDateValidationText = EndDateValidation.Text;
            Assert.AreEqual("End date is required", EndDateValidationText);
            Console.WriteLine("End Date Error is :" + EndDateValidationText);

            CustomWait.FluentWaitbyXPath(Drive.driver, "DescriptionValidation");
            string DescriptionValidationText = DescriptionValidation.Text;
            Assert.AreEqual("Description is Required", DescriptionValidationText);
            Console.WriteLine("Description error text is :" + DescriptionValidationText);

            CustomWait.FluentWaitbyXPath(Drive.driver, "CancelMechanicBusinessAbsencePage");
            ((IJavaScriptExecutor)Drive.driver).ExecuteScript("window.scrollBy(0,200)");
            CustomLib.Highlightelement(CancelMechanicBusinessAbsencePage);
            CancelMechanicBusinessAbsencePage.Click();

        }

        public void EnterMechanicBusinessAbsenceDetails()
        {
            if (NoneinMechanicAbsencePage.Selected)
            {
                CustomWait.FluentWaitbyXPath(Drive.driver, "addMechanicBusinessAbsenceBtn");
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

        public void MechanicRecipientListTab()
        {
            CustomWait.FluentWaitbyXPath(Drive.driver, "mechanicCommunication");
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
