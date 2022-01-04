using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PeakApps.Common;
using PeakApps.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PeakApps.Custom_Class
{
    class FacilityClass
    {
        By FacilityTab = By.XPath("//p[text()='Facilities']");
        By Inactive = By.XPath("//span[text()='Inactive Facilities']");
        By Active = By.XPath("//span[text()='Active Facilities']");
        By MakeInactive = By.XPath("//span[text()='Make Inactive']");
        By MakeActive = By.XPath("//span[text()='Make Active']");
        By Search = By.XPath("//input[@id='search']");
        By UnitsList = By.XPath("//ul/li//div//div//span[contains(text(),'test')]");
        By InactiveButton = By.XPath("//button[text()='Inactive']");
        By sucess_message = By.XPath("//div[@class='message']");
        By EditButton = By.XPath("//li//div//div[@class='column-fixed'][2]");
        By FacilityText = By.XPath("//div[@class='header']");
        By CloseButton = By.XPath("//button[text()='Cancel']");
        By EditHS = By.XPath("//div[text()='Edit Health System']");
        
        By SaveButton = By.XPath("//button[text()='Save']");
        By FacilityDropdown = By.XPath("//section[@class='facility-selector']//span");
        By FacilityList = By.XPath("//span[@class='facility-options-text']");
        By FacilityCreateAndEditButton = By.XPath("//span[text()='Create and Edit']");
        By FacilityCreateFacility = By.XPath("//div[text()='Create Facility']");
        By FacilityCreateHS = By.XPath("//div[text()='Create Health System']");
        By HSNameInput = By.XPath("//input[@id='healthSystemName' and @name='healthSystemName']");
        By FacilityCreateButton = By.XPath("//button[@type='submit' and @name='save']");
        By FacilityName = By.XPath("//input[@id='name']");
        By FacilitySap = By.XPath("//input[@id='sap']");
        By FacilityAddressLine1 = By.XPath("//input[@id='addressLine1']");
        By FacilityAddressLine2 = By.XPath("//input[@id='addressLine2']");
        By FacilityCity = By.Id("cityInput");
        By FacilityState = By.Id("state");
        By FacilityZip = By.XPath("//input[@id='zipCode']");
        By SelectHealthSystem = By.Id("healthSystem");
        By Save=By.XPath("//button[@name='save']");
        By facilityhs = By.XPath("//span[contains(text(),'TestAutoHS')]");

        public void RedirectToFacility()
        {
            ObjectRepository.driver.FindElement(FacilityTab).Click();
        }
        public string ClickInactiveButton()
        {
            Thread.Sleep(5000);
            IList<IWebElement> InactiveButtons = null;
            InactiveButtons = ObjectRepository.driver.FindElements(InactiveButton);

            int count = InactiveButtons.Count;
            //WebDriverWait wait = new WebDriverWait(ObjectRepository.driver, TimeSpan.FromSeconds(10));
            //IWebElement firstResult = wait.Until(e => e.FindElement(By.XPath("//a/h3")));

            //Console.WriteLine(firstResult.Text);
            InactiveButtons[count - 1].Click();
            string alertMessage = ObjectRepository.driver.FindElement(sucess_message).Text;
            return alertMessage;

        }
        public string MessageOnButtonClick()
        {

            string actualText = ClickInactiveButton();
            return actualText;

        }
        public void RedirectToInactiveFacilities()
        {
            ObjectRepository.driver.FindElement(Inactive).Click();
        }
        public void RedirectToActiveFacilities()
        {
            ObjectRepository.driver.FindElement(Active).Click();

        }
        public string GetTextOfMakeInactive()
        {
            string text = ObjectRepository.driver.FindElement(MakeInactive).Text;
            return text;
        }
        public string GetTextOfMakeActive()
        {

            string text = ObjectRepository.driver.FindElement(MakeActive).Text;
            return text;
        }
        public void InputSearchText(string searchText)
        {

            ObjectRepository.driver.FindElement(Search).SendKeys(searchText);


        }

        public void VerifySearch(string searchText)
        {
            IList<IWebElement> collection_units = ObjectRepository.driver.FindElements(UnitsList);

            for (int i = 0; i < collection_units.Count; i++)
            {
                string temp = collection_units[i].Text;
                Assert.IsTrue(true, temp + " is displayed on  Facility List ");


                if ((temp.ToLower().Contains(searchText.ToLower())))
                {
                    Assert.IsTrue(true, searchText + " is displayed on Facility List " + temp);
                }
                else
                {
                    Assert.IsTrue(false, searchText + " is not displayed on Facility List " + temp);

                }
            }

            ObjectRepository.driver.FindElement(Search).Clear();
        }

        public void ClickEdit()
        {
            Thread.Sleep(5000);
            IList<IWebElement> EditList = null;
            EditList = ObjectRepository.driver.FindElements(EditButton);

            int count = EditList.Count;
            //WebDriverWait wait = new WebDriverWait(ObjectRepository.driver, TimeSpan.FromSeconds(10));
            //IWebElement firstResult = wait.Until(e => e.FindElement(By.XPath("//a/h3")));

            //Console.WriteLine(firstResult.Text);
            EditList[count - 1].Click();
        }
        public string GetFacilityText()
        {
            Thread.Sleep(5000);
            string actualvalue = ObjectRepository.driver.FindElement(FacilityText).Text;
            return actualvalue;
        }
        public void CreateOrEditFacility(string Name, string FacilitySAP, string AddressLine1, string AddressLine2, string City, string State, string ZipCode)
        {
            CommonUtility random = new CommonUtility();
            string randomValue =  random.GenerateRandomString();
            IWebElement name= ObjectRepository.driver.FindElement(FacilityName);
            IWebElement sap = ObjectRepository.driver.FindElement(FacilitySap);
            IWebElement add1 = ObjectRepository.driver.FindElement(FacilityAddressLine1);
            IWebElement add2 = ObjectRepository.driver.FindElement(FacilityAddressLine2);
            IWebElement city = ObjectRepository.driver.FindElement(FacilityCity);
            IWebElement zip = ObjectRepository.driver.FindElement(FacilityZip);
            IWebElement comboBox = ObjectRepository.driver.FindElement(SelectHealthSystem);
            SelectElement selectedValue = new SelectElement(comboBox);
            //string wantedText = selectedValue.SelectedOption.GetAttribute("value");
            
            string Facname = name.GetAttribute("value");
            string FacSap = sap.GetAttribute("value");
            string FacAdd1 = add1.GetAttribute("value");
            string FacAdd2 = add2.GetAttribute("value");
            string FacCity = city.GetAttribute("value");
            string FacZip = zip.GetAttribute("value");


            Thread.Sleep(3000);
            // Check whether input field is blank
            if (Facname == "" || FacSap == ""|| FacAdd1==""|| FacAdd2==""|| FacCity==""|| FacZip=="")
            {
                name.SendKeys(Name + randomValue);
                sap.SendKeys(FacilitySAP + randomValue);
                add1.SendKeys(AddressLine1+ randomValue);
                add2.SendKeys(AddressLine2 + randomValue);
                city.SendKeys(City);
                zip.SendKeys(ZipCode);  
                var stateselect = ObjectRepository.driver.FindElement(FacilityState);

                var selectElement = new SelectElement(stateselect);
                //selectElement.SelectByText(State);
                selectElement.SelectByIndex(2);
                //Health System Drop Down
                selectedValue.SelectByIndex(1);

            }
            else
            {
                name.Clear();
                name.SendKeys(Name + randomValue);
                sap.Clear();
                sap.SendKeys(FacilitySAP + randomValue);
                add1.Clear();
                add1.SendKeys(AddressLine1 + randomValue);
                add2.Clear();
                add2.SendKeys(AddressLine2 + randomValue);
                city.Clear();
                city.SendKeys(City);
                zip.SendKeys(ZipCode);
                var stateselect = ObjectRepository.driver.FindElement(FacilityState);

                var selectElement = new SelectElement(stateselect);
                selectElement.SelectByIndex(2);
                //health system
                string HealthSystemValue= selectedValue.SelectedOption.Text;
                selectedValue.SelectByIndex(1);
            }
            
            
        }
        
        public void SaveFacilityAndHS()
        {
            ObjectRepository.driver.FindElement(Save).Click();
        }
        public string AlertMessage()
        {

            string alertMessage = ObjectRepository.driver.FindElement(sucess_message).Text;
            return alertMessage;


        }
        public void CreateAndEditButton()
        {
            ObjectRepository.driver.FindElement(FacilityCreateAndEditButton).Click();
        }
        public void CreateFacility()
        {
            ObjectRepository.driver.FindElement(FacilityCreateFacility).Click();
        }
        public void CreateHealthSystem()
        {
            ObjectRepository.driver.FindElement(FacilityCreateHS).Click();
            
        }
        public void InputHealthSystem()
        {
            CommonUtility random = new CommonUtility();
            string randomValue = "HS_" + random.GenerateRandomString();

            IWebElement healthSystem=ObjectRepository.driver.FindElement(HSNameInput);
            healthSystem.SendKeys("HS_" + randomValue);
            

        }
        public void InputEditHealthSystem()
        {
            CommonUtility random = new CommonUtility();
            string randomValue = "HS_" + random.GenerateRandomString();

            IWebElement healthSystem = ObjectRepository.driver.FindElement(HSNameInput);
            healthSystem.SendKeys("HS_" + randomValue);
            IWebElement HSBox = ObjectRepository.driver.FindElement(SelectHealthSystem);
            SelectElement selectedValue = new SelectElement(HSBox);
            selectedValue.SelectByIndex(2);

        }
        public void EditHealthSystem()
        {
            ObjectRepository.driver.FindElement(EditHS).Click();
        }
        public void CreateButton()
        {
            ObjectRepository.driver.FindElement(FacilityCreateButton).Click();
        }
        public void facilityOfHs()
        {
            IList<IWebElement> hsFacility = ObjectRepository.driver.FindElements(facilityhs);
            for (int i = 0; i < hsFacility.Count; i++) {
                string hsFacilityName = hsFacility[i].Text;
                DataModal.healthSystemFacility.Add(hsFacilityName);
              }
        }
    }
}
