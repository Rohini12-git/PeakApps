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
    class CommonUtility
    {
        By CloseButton = By.XPath("//button[text()='Cancel']");
        By EditText = By.XPath("//span[text()='Edit']");
        By FacilityDropdown = By.XPath("//section[@class='facility-selector']//span");
        By FacilityList = By.XPath("//span[@class='facility-options-text']");
        public string GenerateRandomString()
        {
            Random RNG = new Random();
            int length = 6;
            var rString = "";
            for (var i = 0; i < length; i++)
            {
                rString += ((char)(RNG.Next(1, 26) + 64)).ToString().ToLower();
            }
            Console.WriteLine(rString);
            return rString;
        }
        
        public void ClickCancel()
        {
            ObjectRepository.driver.FindElement(CloseButton).Click();                    
        }
        public string GetEditText()
        {
            Thread.Sleep(5000);
            string actualvalue = ObjectRepository.driver.FindElement(EditText).Text;
            return actualvalue;
        }

        public void SelectFacility()
        {
            Thread.Sleep(3000);
            ObjectRepository.driver.FindElement(FacilityDropdown).Click();
            IList<IWebElement> storeFacility = null;
            storeFacility = ObjectRepository.driver.FindElements(FacilityList);
            int countFacility = storeFacility.Count;
           

            for (int i = 0; i <= countFacility; i++)
            {

                string SelectFacility = storeFacility[i].Text;
                if (SelectFacility.Contains(ObjectRepository.config.GetFacilityName()))
                {
                    storeFacility[i].Click();
                    break;
                }
            }

        }

        public void SelectFacilityForDataEntry()
        {
            Thread.Sleep(3000);
            ObjectRepository.driver.FindElement(FacilityDropdown).Click();
            IList<IWebElement> storeFacility = null;
            storeFacility = ObjectRepository.driver.FindElements(FacilityList);
            int countFacility = storeFacility.Count;


            for (int i = 0; i <= countFacility; i++)
            {
                Thread.Sleep(2000);
                string SelectFacility = storeFacility[i].Text;
                if (SelectFacility.Contains(ObjectRepository.config.GetFacilityNameForDataEntry()))
                {
                    storeFacility[i].Click();
                    break;
                }
                
            }

        }

        public void SelectFacilityForHealthSystem()
        {
            Thread.Sleep(3000);
            ObjectRepository.driver.FindElement(FacilityDropdown).Click();
            IList<IWebElement> storeFacility = null;
            storeFacility = ObjectRepository.driver.FindElements(FacilityList);
            int countFacility = storeFacility.Count;


            for (int i = 0; i <= countFacility; i++)
            {

                string SelectFacility = storeFacility[i].Text;
                if (SelectFacility.Contains(ObjectRepository.config.GetFacilityNameForHealthSystem()))
                {
                    storeFacility[i].Click();
                    break;
                }

            }

        }


    }
}
