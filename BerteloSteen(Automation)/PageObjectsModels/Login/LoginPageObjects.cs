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
        public IWebElement SubmitBtn { get; set; }

        public void EnterUserName(string userName)
        {
            Drive.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //Enter UserName
            CustomLib.Highlightelement(TxtUserName);
            CustomWait.FluentWaitbyXPath("txtUserName");
            TxtUserName.SendKeys(userName);
            //Click on LoginBtn
            CustomLib.Highlightelement(SubmitBtn);
            CustomWait.FluentWaitbyXPath("submitBtn");
            SubmitBtn.Clicks();

        }


        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Password']")]
        public IWebElement TxtPassword { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@class='inline-block']/input[@value='Sign in']")]
        public IWebElement SignIn { get; set; }

        public void EnterPassword(string password)
        {
            CustomLib.Highlightelement(TxtPassword);
            CustomWait.FluentWaitbyXPath( "txtPassword");
            TxtPassword.SendKeys(password);//Enter Password
            CustomLib.Highlightelement(SignIn);
            //Click on LoginBtn
            CustomWait.FluentWaitbyXPath("signIn");
            SignIn.Clicks();

        }


        [FindsBy(How = How.XPath, Using = "//input[contains(@value,'true')]")]
        public IWebElement StaySignedIn { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@class='inline-block']/input[@value='Yes']")]
        public IWebElement Yes { get; set; }

        [Obsolete]
        public GetPropertiesObjects StaySignedIN()
        {
            CustomLib.Highlightelement(StaySignedIn);
            CustomWait.FluentWaitbyXPath("staySignedIn");
            StaySignedIn.Clicks();
            CustomLib.Highlightelement(Yes);
            CustomWait.FluentWaitbyXPath("yes");
            Yes.Clicks();
            //Return to the GetProperties
            return new GetPropertiesObjects();




        }
    }
}
