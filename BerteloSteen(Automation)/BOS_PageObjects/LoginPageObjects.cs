﻿using BerteloSteen_Automation_.BOS_GETSET;
using BerteloSteen_Automation_.BOS_Test_Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace BerteloSteen_Automation_.BOS_PageObjects
{
    class LoginPageObjects
    {
        [Obsolete]
        public LoginPageObjects()
        {
            PageFactory.InitElements(Drive.driver, this);
            
        }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'i0116')]")]
        public IWebElement txtUserName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@value,'Next')]")]
        public IWebElement submitBtn { get; set; }

        
        CustomLib Stop = new CustomLib();
        [Obsolete]
        public void EnterUserName(String userName)
        {
            //Enter UserName
            txtUserName.SendKeys(userName);
            //Click on LoginBtn
            Stop.WaitFortheLoadingIconDisappear2000();
            submitBtn.Clicks();

        }


        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'i0118')]")]
        public IWebElement txtPassword { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@value,'Sign in')]")]
        public IWebElement signIn { get; set; }

        [Obsolete]
        public void EnterPassword(String password)
        {
            //Enter Password
            txtPassword.SendKeys(password);
            //Click on LoginBtn
            Stop.WaitFortheLoadingIconDisappear2000();
            signIn.Clicks();

        }


        [FindsBy(How = How.XPath, Using = "//input[contains(@value,'true')]")]
        public IWebElement staySignedIn { get; set; }


        [FindsBy(How = How.XPath, Using = "//input[contains(@value,'Yes')]")]
        public IWebElement yes { get; set; }

        [Obsolete]
        public GetProperties StaySignedIN()
        {

            staySignedIn.Clicks();
            yes.Clicks();
            
            //Return to the GetProperties
            return new GetProperties();




        }
    }
}
