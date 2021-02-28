using DARS.Automation_.Helper;
using DARS.Automation_.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace DARS.Automation_.PageObjectsModels.Login
{
    class LoginPageObjects
    {
        [Obsolete]
        public LoginPageObjects()
        {
            PageFactory.InitElements(Drive.driver, this);
           
        }


        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Email, phone, or Skype']")]
        public IWebElement TxtUserName { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='inline-block']/input[@value='Next']")]
        public IWebElement submitBtn { get; set; }

        public void EnterUserName(string userName)
        {
            Drive.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            //Enter UserName
            CustomLib.Highlightelement(TxtUserName);
            CustomWait.FluentWaitbyXPath("txtUserName");
            TxtUserName.SendKeys(userName);
            //Click on LoginBtn
            CustomLib.Highlightelement(submitBtn);
            CustomWait.FluentWaitbyXPath("submitBtn");
            submitBtn.Clicks();

        }


        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Password']")]
        public IWebElement txtPassword { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@class='inline-block']/input[@value='Sign in']")]
        public IWebElement signIn { get; set; }

        public void EnterPassword(string password)
        {
            CustomLib.Highlightelement(txtPassword);
            CustomWait.FluentWaitbyXPath( "txtPassword");
            txtPassword.SendKeys(password);//Enter Password
            CustomLib.Highlightelement(signIn);
            //Click on LoginBtn
            CustomWait.FluentWaitbyXPath("signIn");
            signIn.Clicks();

        }


        [FindsBy(How = How.XPath, Using = "//input[contains(@value,'true')]")]
        public IWebElement staySignedIn { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@class='inline-block']/input[@value='Yes']")]
        public IWebElement yes { get; set; }

        [Obsolete]
        public GetPropertiesObjects StaySignedIN()
        {
            CustomLib.Highlightelement(staySignedIn);
            CustomWait.FluentWaitbyXPath("staySignedIn");
            staySignedIn.Clicks();
            CustomLib.Highlightelement(yes);
            CustomWait.FluentWaitbyXPath("yes");
            yes.Clicks();
            //Return to the GetProperties
            return new GetPropertiesObjects();




        }
    }
}
