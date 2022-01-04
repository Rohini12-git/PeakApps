using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PeakApps.Custom_Class
{
    class LoginClass
    {
        public static IWebDriver driver;
        public static IWebElement checkbox;
        public static readonly string baseURL = ConfigurationManager.AppSettings.Get("Webapp");
        public static void url()
        {
            //driver = new ChromeDriver();

            //string urls = "https://3mpeakqa.azurewebsites.net/";
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            driver.Navigate().GoToUrl(baseURL);
           //driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }
        public static void login(string username, string password)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            string emailXpath = "//input[@placeholder='Email']";
            //string email = "vikash.prasad@nathcorp.com";
            driver.FindElement(By.XPath(emailXpath)).SendKeys(username);
            string passwordXpath = "//input[@placeholder='Password']";
            // string password = "Nathcorp@123";
            driver.FindElement(By.XPath(passwordXpath)).SendKeys(password);
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[@class='login-button button-primary']")).Click();


        }
        public static void dashboardVerify()
        {
            String actualURL = driver.Url;
            //string expectedURL = "https://3mpeakqa.azurewebsites.net/#/dashboard";
            //Assert.Equals(actualURL, expectedURL);
            // Assert.AreEqual(actualURL, "https://3mpeakqa.azurewebsites.net/#/dashboard");
            if (actualURL.Equals("https://3mpeakqa.azurewebsites.net/#/dashboard"))
            {
                Console.WriteLine("True");

            }

        }
        public static void logout()
        {
            driver.FindElement(By.XPath("//div[@class='badge']")).Click();
            driver.FindElement(By.XPath("//div[@class='popup-menu-container']/div[2]")).Click();

        }
        public static void homePage()
        {

            String text = driver.FindElement(By.XPath("//h6[@class='login-header-text']")).Text;

            string actualText = "Log in to 3M Peak Assessment Tool";
            // Assert.AreEqual(actualText, text);
            Assert.IsTrue(actualText == text, "Error");
        }
        public static void rememberMe()
        {

            checkbox = driver.FindElement(By.XPath("//div[@class='remember-me-checkbox']"));
            if (!checkbox.Selected)
                checkbox.Click();

        }
        public static void verifyRememberMe()
        {
            if (checkbox.Selected)
            {
                Console.WriteLine("check box get checked");
            }
            else
            {
                Console.WriteLine("checkbox is Toggled Off");
            }

        }
        public static void forgotPassword()
        {
            // Store the parent window into a variable for further use 
            String parentWindowHandle = driver.CurrentWindowHandle;
            Console.WriteLine("Parent window's handle -> " + parentWindowHandle);


            IWebElement fpass = driver.FindElement(By.XPath("//span[@class='forgot-password-hyperlink']"));
            fpass.Click();





        }


        public static void verifyForgotLink()
        {
            /*
           * driver.WindowHandles is a ReadOnlycollection So i am using '.ToList()' and store into the 'List<string>'
           * Again using 'for loop' to traverse all window which are opened by the above loop 
           * then i use '.SwitchTo().Window'. Basically this is use to switch your control from parent window to current window
           **/


            var newTabHandle = driver.WindowHandles[1];
            Assert.AreEqual(driver.SwitchTo().Window(newTabHandle).Url, "https://enl.3m.com/enl/dontknow_password.jsp");

            driver.SwitchTo().Window(driver.WindowHandles[1]).Close();
            driver.SwitchTo().Window(driver.WindowHandles[0]);


            //string CurrentUrl = driver.Url;
            //string actualText = "https://enl.3m.com/enl/dontknow_password.jsp";
            //// Assert.AreEqual(actualText, text);
            //Assert.IsTrue(actualText == CurrentUrl, "Error");

        }
        public static void termCondition()
        {

            IWebElement term = driver.FindElement(By.XPath("//span[@class='terms-and-conditions-hyperlink']"));
            term.Click();

        }
        public static void verifyLicenceAggrement()
        {
            IWebElement verifyAggrement = driver.FindElement(By.XPath("//div[@class='terms-header']/div"));
            string aggrementtext = verifyAggrement.Text;
            string actualText = "3M™ PEAK™ ASSESSMENT TOOL END USER LICENSE AGREEMENT";

            Assert.IsTrue(actualText == aggrementtext, "Error");

        }
        public static void Accept()
        {
            IWebElement verifyterms = driver.FindElement(By.XPath("//div[@class='action-buttons-group']/button[1]"));
            verifyterms.Click();


        }
        public static void verifytermConditionLink()
        {

            string CurrentUrl = driver.Url;
            string actualUrl = "https://3mpeakqa.azurewebsites.net/#/";

            Assert.IsTrue(actualUrl == CurrentUrl, "Error");

        }

    }
}
