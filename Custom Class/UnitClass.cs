using Microsoft.Graph;
using NUnit.Framework;
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
    class UnitClass
    {
        public UnitClass(IWebDriver driver)
        {
           
            ObjectRepository.driver = driver;

        }
        string searchText = "Test";
        By UnitTab = By.XPath("//p[text()='Units']");      
        By Inactive = By.XPath("//span[text()='Inactive Units']");       
        By Active = By.XPath("//span[text()='Active Units']");
        By MakeInactive = By.XPath("//span[text()='Make Inactive']");
        By MakeActive = By.XPath("//span[text()='Make Active']");
        By Search = By.XPath("//input[@id='search']");
        By UnitsList= By.XPath("//ul/li//div//div//span[contains(text(),'test')]");
        By InactiveButton =By.XPath("//li//div//div[2]");
        By sucess_message = By.XPath("//div[@class='message']");
        By EditButton = By.XPath("//li//div//div[@class='column-fixed'][2]");
        By UnitText = By.XPath("//div[@class='header']");
        By CloseButton= By.XPath("//button[text()='Cancel']");
        By EditText = By.XPath("//span[text()='Edit']");
        By UnitNameInput = By.XPath("//input[@id='unitName' and @name='unitName']");
        By SaveButton= By.XPath("//button[text()='Save']");       
        By CreateUnitButton = By.XPath("//button//span[text()='Create Unit']");
        By CreateButton = By.XPath("//button[@type='submit' and text()='Create']");


        public void RedirectToUnits()
        {
            ObjectRepository.driver.FindElement(UnitTab).Click();
        }

        
        public void RedirectToInactiveUnits()
        {
            ObjectRepository.driver.FindElement(Inactive).Click();
        }

        
        public void RedirectToActiveUnits()
        {
            ObjectRepository.driver.FindElement(Active).Click();
            
        }
        public string GetTextOfMakeInactive()
        {
            string text=ObjectRepository.driver.FindElement(MakeInactive).Text;
            return text;
        }
        public string GetTextOfMakeActive()
        {
           
            string text = ObjectRepository.driver.FindElement(MakeActive).Text;
            return text;
        }
       public void InputSearchText()
        {
            
            ObjectRepository.driver.FindElement(Search).SendKeys(searchText);
           
            
        }

        public void VerifySearch()
        {
            IList<IWebElement> collection_units = ObjectRepository.driver.FindElements(UnitsList);

            for (int i = 0; i < collection_units.Count; i++)
            {
                string temp = collection_units[i].Text;
                Assert.IsTrue(true, temp + " is displayed on  Units List ");


                if ((temp.ToLower().Contains(searchText.ToLower())))
                {
                    Assert.IsTrue(true, searchText + " is displayed on Units List " + temp);
                }
                else
                {
                    Assert.IsTrue(false, searchText + " is not displayed on Units List " + temp);

                }
            }

            ObjectRepository.driver.FindElement(Search).Clear();
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
            InactiveButtons[count-1].Click();
            string alertMessage = ObjectRepository.driver.FindElement(sucess_message).Text;
            return alertMessage;
            
        }
     
        public void MessageOnButtonClick( )
        {
            
            string SucessMessage = ClickInactiveButton();
            string actualText = SucessMessage;
            string expectText = "The unit was modified successfully.";
            Assert.AreEqual(actualText, expectText);

            
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
         public string GetUnitText()
        {
            Thread.Sleep(5000);
            string actualvalue = ObjectRepository.driver.FindElement(UnitText).Text;
            return actualvalue;
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
        public void InputUnit()
        {
            CommonUtility random = new CommonUtility();
            string UnitName= "Unit" + random.GenerateRandomString();
            IWebElement Unit = ObjectRepository.driver.FindElement(UnitNameInput);
             
            string textInsideInputBox = Unit.GetAttribute("value");

            // Check whether input field is blank
            if (textInsideInputBox==null|| textInsideInputBox =="")
            {
                Unit.SendKeys(UnitName);
            }else
            {
                Unit.Clear();
                Unit.SendKeys(UnitName);
            }
            
        }
        public void ClickSave()
        {
            ObjectRepository.driver.FindElement(SaveButton).Click();
        }
        public bool EnableUnitButton()
        {
         var enableUnit= ObjectRepository.driver.FindElement(CreateUnitButton).Enabled;
            return enableUnit;


        }
        public void ClickCreateUnit()
        {
            ObjectRepository.driver.FindElement(CreateUnitButton).Click();
        }
        public void ClickCreate()
        {
            ObjectRepository.driver.FindElement(CreateButton).Click();
        }
        public string AlertMessage()
        {

            string alertMessage = ObjectRepository.driver.FindElement(sucess_message).Text;
            return alertMessage;


        }


       

    }

}
