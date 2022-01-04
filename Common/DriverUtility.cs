using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using PeakApps.Configuration;
using PeakApps.Custom_Exception;
using PeakApps.Settings;
using System;

namespace PeakApps.Common
{
    class DriverUtility
    {
        private static IWebDriver GetFirefoxDriver()
        {
            IWebDriver driver = new FirefoxDriver();
            return driver;
        }
        private static IWebDriver GetChromeDriver()
        {
            IWebDriver driver = new ChromeDriver();
            return driver;
        }
        private static IWebDriver GetIExplorerDriver()
        {
            IWebDriver driver = new InternetExplorerDriver();
            return driver;
        }

        public static void OpenDriver()
        {
            //ObjectRepository.config = new AppConfigReader();
            switch (ObjectRepository.config.GetBrowser())
            {
                case BrowserType.Firefox:
                    ObjectRepository.driver = GetFirefoxDriver();
                    break;
                case BrowserType.Chrome:
                    ObjectRepository.driver = GetChromeDriver();
                    break;
                case BrowserType.IExplorer:
                    ObjectRepository.driver = GetIExplorerDriver();
                    break;
                default:
                    throw new NoSuitableDriverFound("Driver not found :" + ObjectRepository.config.GetBrowser().ToString());
            }
            ObjectRepository.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ObjectRepository.config.GetLoadTimeOut());
            ObjectRepository.driver.Manage().Window.Maximize();

        } 

       



    }
}
