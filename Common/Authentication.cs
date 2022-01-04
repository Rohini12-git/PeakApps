using OpenQA.Selenium;
using PeakApps.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PeakApps.Common
{
    class Authentication
    {
        
        // Constructor
        // Gets called when object of this page is created in MainClass.java
        public Authentication(IWebDriver driver)
        {
            
            ObjectRepository.driver = driver;

        }
        string userName = ObjectRepository.config.GetUserName();
        string password = ObjectRepository.config.GetPassword();
        public  void LaunchBrowser()
        {
            ObjectRepository.driver.Navigate().GoToUrl(ObjectRepository.config.GetWebUrl());
        }
        

       
        By EmailAddress = By.XPath("//input[@placeholder='Email']");       
        By Password = By.XPath("//input[@placeholder='Password']");
        By SignInButton = By.XPath("//button[@class='login-button button-primary']");
        By badge= By.XPath("//div[contains(@class,'badge')]");
        //section[@class='account-widget']
        By logout = By.XPath("//div[contains(text(),'Logout')]");



        public void typeEmailId()
        {
            ObjectRepository.driver.FindElement(EmailAddress).SendKeys(userName);
        }       
        public void typePassword()
        {
            ObjectRepository.driver.FindElement(Password).SendKeys(password);
        }
        public void clickSignIn()
        {
            ObjectRepository.driver.FindElement(SignInButton).Click();
        }
        public void clickLogout()
        {
            Thread.Sleep(5000);
            ObjectRepository.driver.FindElement(badge).Click();
            ObjectRepository.driver.FindElement(logout).Click();
        }

        public void dashboardVerify()
        {
            String actualURL = ObjectRepository.driver.Url;
            
            if (actualURL.Equals("https://peakqa.3m.com/#/dashboard"))
            {
                Console.WriteLine("True");

            }

        }


    }
}
