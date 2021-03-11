using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using DARS.Automation_.PageObjectsModels;
using DARS.Automation_.PageObjectsModels.Login;
using DARS.Automation_.Utilities;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading;

namespace DARS.Automation_.TestScripts.Base_Classes
{
    public class TestWiseLogin
    {
        protected ExtentReports _extent;
        protected ExtentTest _test;

        [OneTimeSetUp]
        [Obsolete]
        public void Login()
        {

            try
            {
                //To create report directory and add HTML report into it
                string currentTime = DateTime.Now.ToString("hhmmssstt");
                _extent = new ExtentReports();
                var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\Test_Execution_Reports");
                DirectoryInfo di = Directory.CreateDirectory(dir + "\\Test_Execution_Reports");
                var htmlReporter = new ExtentHtmlReporter(dir + "\\Test_Execution_Reports\\DARS_" + currentTime + ".html");
                htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
                _extent.AddSystemInfo("Application Name", "DARS");
                _extent.AddSystemInfo("Environment", "QA");
                _extent.AddSystemInfo("Machine", Environment.MachineName);
                _extent.AddSystemInfo("OS", Environment.OSVersion.VersionString);
                _extent.AddSystemInfo("Engineer Name", "Akash");
                _extent.AttachReporter(htmlReporter);
            }
            catch (Exception e)
            {
                throw (e);
            }


            try
            {
                EncryptDecrypt encrypt = new EncryptDecrypt();
                Info information = new Info();
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("no-sandbox");
                options.AddExcludedArgument("enable-automation");
                options.AddUserProfilePreference("credentials_enable_service", false);
                options.AddUserProfilePreference("profile.password_manager_enabled", false);
                options.AddAdditionalCapability("useAutomationExtension", false);
                Drive.driver = new ChromeDriver(@information.chrome, options, TimeSpan.FromMinutes(2));
                Drive.driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));
                //naviate to Url
                Drive.driver.Manage().Window.Maximize();
                Drive.driver.Manage().Cookies.DeleteAllCookies();
                Drive.driver.Navigate().GoToUrl(information.baseURL);
                Drive.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
                Console.WriteLine("Navigated to the 'demo Home Page' URL Sucessfully");
                //Intitialize the page by calling it reference
                LoginPageObjects loginpage = new LoginPageObjects();
                string UserName = encrypt.EncodingData(information.username);
                loginpage.EnterUserName(encrypt.DecodingData(UserName));
                Console.WriteLine("UserName Entered");
                string Password = encrypt.EncodingData(information.password);
                loginpage.EnterPassword(encrypt.DecodingData(Password));
                Console.WriteLine("Password Entered");
                Console.WriteLine("Stay Logged In");
                loginpage.StaySignedIN();
                Console.WriteLine("Logged In Sucessfully");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }


        }


        [SetUp]
        public void BeforeTest()
        {
            try
            {
                _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            }
            catch (Exception e)
            {
                throw (e);
            }
        }



        [TearDown]
        public void AfterTest()
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = "" + TestContext.CurrentContext.Result.StackTrace + "";
                var errorMessage = TestContext.CurrentContext.Result.Message;
                Status logstatus;
                switch (status)
                {
                    case TestStatus.Failed:
                        logstatus = Status.Fail;
                        string screenShotPath = Capturescreenshot(Drive.driver, TestContext.CurrentContext.Test.Name);
                        _test.Log(logstatus, "Test ended with" + logstatus + " – " + errorMessage);
                        _test.Log(logstatus, "Snapshot of Failed Test found below:" + _extent.CreateTest(TestContext.CurrentContext.Test.Name).AddScreenCaptureFromPath(screenShotPath));
                        break;
                    case TestStatus.Skipped:
                        logstatus = Status.Skip;
                        _test.Log(logstatus, "Test ended with" + logstatus);
                        break;
                    default:
                        logstatus = Status.Pass;
                        _test.Log(logstatus, "Test ended with" + logstatus);
                        break;
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
        }


        [OneTimeTearDown]
        public void Close()
        {
            try
            {
                _extent.Flush();
            }
            catch (Exception e)
            {
                throw (e);
            }
            (Drive.driver as IJavaScriptExecutor).ExecuteScript("sessionStorage.clear();");
            (Drive.driver as IJavaScriptExecutor).ExecuteScript("localStorage.clear();");
            Drive.driver.Manage().Cookies.DeleteAllCookies();
            Drive.driver.Close();
            Drive.driver.Quit();
            Console.WriteLine("Closed the Browser");
        }


        private string Capturescreenshot(IWebDriver driver, string screenShotName)
        {
            string localpath = "";
            try
            {
                Thread.Sleep(4000);
                ITakesScreenshot ts = (ITakesScreenshot)driver;
                Screenshot screenshot = ts.GetScreenshot();
                string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
                DirectoryInfo di = Directory.CreateDirectory(dir + "\\ScreenPrints\\Defect_Screenshots\\");
                string finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "\\ScreenPrints\\Defect_Screenshots\\" + screenShotName + ".png";
                localpath = new Uri(finalpth).LocalPath;
                screenshot.SaveAsFile(localpath);
            }
            catch (Exception e)
            {
                throw (e);
            }
            return localpath;
        }



    }
}
