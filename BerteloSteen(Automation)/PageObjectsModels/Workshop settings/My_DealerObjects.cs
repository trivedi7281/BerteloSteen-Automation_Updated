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
        public My_DealerObjects()
        {
            PageFactory.InitElements(Drive.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//ul/li[@id='engli']/a")]
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


        [FindsBy(How = How.XPath, Using = "//*[@id='dealerShiftDetailsBlock']")]
        public IWebElement DealerHours { get; set; }

        [FindsBy(How = How.XPath, Using = "(//*[@id='shiftStartHrs@(i)']//input[@name='startHours1'])")]
        public IWebElement StartSelectHour { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='containerData']//a[2]")]
        public IWebElement DealerHoursAddBtn { get; set; }



        public void EnterDealerHours()
        {
            CustomWait.WaitFortheLoadingIconDisappear2000();
            ((IJavaScriptExecutor)Drive.driver).ExecuteScript("arguments[0].scrollIntoView(true);", DealerHours);
            DealerHours.Click();
            CustomWait.WaitFortheLoadingIconDisappear2000();
            DealerHoursAddBtn.Click();
            int els = Drive.driver.FindElements(By.XPath("((//div[@id='containerData'])/div[2]//div[@class='dealer-day']/label)")).Count();
            Console.WriteLine("CheckBox Count is: " + els);
            string fistCheckPath = "((//div[@id='containerData'])/div[2]//div[@class='dealer-day']/label)[";
            string secondCheckPath = "]";
            for (int i = 1; i <= els; i++)
            {
                string ActualCheckPath = fistCheckPath + i + secondCheckPath;
                IWebElement ActualCheckedPath = Drive.driver.FindElement(By.XPath(ActualCheckPath));
                Console.WriteLine("Text is :" + ActualCheckedPath.Text);
                CustomWait.WaitFortheLoadingIconDisappear2000();
                if (i == 1)
                {
                    if (!ActualCheckedPath.Selected)
                    {
                        ActualCheckedPath.Click();
                    }
                }
                else if (i == 2)
                {
                    if (!ActualCheckedPath.Selected)
                    {
                        ActualCheckedPath.Click();
                    }
                }
                else if (i == 3)
                {
                    if (!ActualCheckedPath.Selected)
                    {
                        ActualCheckedPath.Click();
                    }
                }
                else if (i == 4)
                {
                    if (!ActualCheckedPath.Selected)
                    {
                        ActualCheckedPath.Click();
                    }
                }
                else if (i == 5)
                {
                    if (!ActualCheckedPath.Selected)
                    {
                        ActualCheckedPath.Click();
                    }
                }
                else if (i == 6)
                {
                    if (!ActualCheckedPath.Selected)
                    {
                        ActualCheckedPath.Click();
                    }
                }
                else if (i == 7)
                {
                    if (!ActualCheckedPath.Selected)
                    {
                        ActualCheckedPath.Click();
                    }
                }

            }
            StartSelectHour.Click();
            CustomWait.WaitFortheLoadingIconDisappear2000();
            int StartHours = Drive.driver.FindElements(By.XPath("((//div[@class='xdsoft_datetimepicker xdsoft_noselect xdsoft_'])[15]//div[@class='xdsoft_time '])")).Count();
            string firstStartPath = "((//div[@class='xdsoft_datetimepicker xdsoft_noselect xdsoft_'])[15]//div[@class='xdsoft_time '])[";
            string secondStartPath = "]";
            for (int i = 1; i <= StartHours; i++)
            {
                string finalStartPath = firstStartPath + i + secondStartPath;
                IWebElement SelectTime = Drive.driver.FindElement(By.XPath(finalStartPath));
                CustomWait.WaitFortheLoadingIconDisappear2000();
                ((IJavaScriptExecutor)Drive.driver).ExecuteScript("arguments[0].scrollIntoView(true);", SelectTime);
                Console.WriteLine("Text is :" + SelectTime.Text);
                if (SelectTime.Text.Contains("20:15"))
                {
                    SelectTime.Click();
                    break;
                }
            }


        }

        [FindsBy(How = How.XPath, Using = "//*[@id='communicationNotificationBlock']")]
        public IWebElement NotificationsDetails { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@id='communicationNotificationData']//a[@title ='Add Row'])")]
        public IWebElement NotificationsAddRow { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@id='communicationNotificationData']//a[@title ='Delete Row'])[2]")]
        public IWebElement NotificationsDelRow { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@id='communicationNotificationData']//div/mat-select)[4]")]
        public IWebElement NotificationRole { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='save']")]
        public IWebElement SaveBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='reset']")]
        public IWebElement ResetBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@id='toast-container'])//div[@role='alertdialog']")]
        public IWebElement DialogMessage { get; set; }



        public void EnterNotificationDetail()
        {
            ((IJavaScriptExecutor)Drive.driver).ExecuteScript("arguments[0].scrollIntoView(true);", PartsOrdering);
            PartsOrdering.Click();
            CustomWait.WaitFortheLoadingIconDisappear2000();
            NotificationsDetails.Click();
            CustomWait.WaitFortheLoadingIconDisappear2000();
            NotificationsAddRow.Click();
            CustomWait.WaitFortheLoadingIconDisappear2000();
            int RowsofNotificationDetail = Drive.driver.FindElements(By.XPath("(//div[@id='communicationNotificationData']//div/mat-select)")).Count();
            Console.WriteLine("Rows of NotificationDetail Count is" + RowsofNotificationDetail);
            NotificationRole.Click();
            CustomWait.WaitFortheLoadingIconDisappear2000();
            int Roles = Drive.driver.FindElements(By.XPath("(//div[@id='userType3-panel']/mat-option[@role='option']/span)")).Count();
            Console.WriteLine("Roles Count is" + Roles);
            string fistxpath = "(//div[@id = 'userType3-panel']/mat-option[@role='option']/span)[";
            string secondxpath = "]";
            for (int i = 1; i <= Roles; i++)
            {
                string Actualpath = fistxpath + i + secondxpath;
                IWebElement ActualXpath = Drive.driver.FindElement(By.XPath(Actualpath));
                ((IJavaScriptExecutor)Drive.driver).ExecuteScript("arguments[0].scrollIntoView(true);", ActualXpath);
                Console.WriteLine(ActualXpath.Text);
                CustomWait.WaitFortheLoadingIconDisappear1000();
                if (ActualXpath.Text.Contains("TT (Communication)"))
                {
                    ActualXpath.Click();
                    break;
                }
            }
            int inputsField = Drive.driver.FindElements(By.XPath("((//div[@id='communicationNotificationData']//div/mat-select)[4]/parent::*/following-sibling::*/input)")).Count();
            Console.WriteLine("InputsField are" + inputsField);
            string fistinputpath = "((//div[@id='communicationNotificationData']//div/mat-select)[4]/parent::*/following-sibling::*/input)[";
            string secondinputpath = "]";
            for (int i = 1; i <= inputsField; i++)
            {
                string Actualinputpath = fistinputpath + i + secondinputpath;
                IWebElement Actualfieldpath = Drive.driver.FindElement(By.XPath(Actualinputpath));
                CustomWait.WaitFortheLoadingIconDisappear2000();
                if (i == 1)
                {
                    Actualfieldpath.SendKeys("1");
                }
                else if (i == 2)
                {
                    Actualfieldpath.Click();
                    CustomWait.WaitFortheLoadingIconDisappear5000();
                    Actualfieldpath.Clear();
                    Actualfieldpath.SendKeys("7987156822");
                }
                else if (i == 3)
                {
                    Actualfieldpath.SendKeys("test@testing.com");
                }
                else if (i == 4)
                {
                    Actualfieldpath.SendKeys("Hey Taggi");
                    break;
                }

            }
            ((IJavaScriptExecutor)Drive.driver).ExecuteScript("arguments[0].scrollIntoView(true);", SaveBtn);
            SaveBtn.Click();

        }


        [FindsBy(How = How.XPath, Using = "//*[@id='dealerPartOrderingBlock']")]
        public IWebElement PartsOrdering { get; set; }







    }
}
