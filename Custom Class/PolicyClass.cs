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
    class PolicyClass
    {
        static int rowCount = 2;
        By AuditTab = By.XPath("//p[text()='Audit Setup']");
        By Inactive = By.XPath("//span[text()='Inactive Facilities']");
        By Active = By.XPath("//span[text()='Active Facilities']");
        By MakeInactive = By.XPath("//span[text()='Make Inactive']");
        By MakeActive = By.XPath("//span[text()='Make Active']");
        By Search = By.XPath("//input[@id='search']");
        By CreatePolicyText = By.XPath("//form//div[@class='header horizontal-padding']");
        By InactiveButton = By.XPath("//button[text()='Inactive']");
        By sucess_message = By.XPath("//div[@class='message']");
        By EditButton = By.XPath("//li//div//div[@class='column-fixed'][2]");
        By CreatePolicyButton = By.XPath("//button//span[text()='Create Policy']");
        By AuditType = By.XPath("//select[@name='auditType']");
        By PolicyName=By.XPath("//input[@name='name']");
        By NextButton= By.XPath("//button[contains(text(),'Next')]");
        By yellowComplianceRate = By.XPath("//label[@class='showRate'][1]");
        By greenComplianceRate = By.XPath("//label[@class='showRate'][2]");
        By yellowComplianceInput = By.XPath("//input[@name='minimumComplianceRateYellow']");
        By greenComplianceInput = By.XPath("//input[@name='minimumComplianceRateGreen']");
        By AuditScopeText = By.XPath("//section//span[@class='question']");
        By AuditQ3 = By.XPath("//div//input[@type='checkbox' and @id='checkboxQ3.e']");
        By AuditQ3Text = By.XPath("//div//label[text()='IV tubing dating ']");
        By Summary = By.XPath("//div[@class='response-label']");
        By FinishAndActive = By.XPath("//button[@type='submit' and text()='Finish and Make Active']");
        By ActivePolicyName = By.XPath("//div//span[@class='option-label']");
        //By ActivePolicyText = By.XPath("//span[@class='option-label']");
        By QuestionHeader = By.XPath("//span[@class='question']");
        By Question21Days = By.XPath("//div//input[@id='checkboxDPP.Q1.b']");
        By QuestionRadio = By.ClassName("radio-group-answer");
        By switchtoggle = By.XPath("//label[text()='Health System Data']");
        By healthsystemName = By.XPath("//input[@name='healthSystemList']");
        By policiesNameList = By.XPath("//div[@class='column-flex']//span");
        By FacilityDropdown = By.XPath("//section[@class='facility-selector']//span");
        By FacilityList = By.XPath("//span[@class='facility-options-text']");




        // IList<IWebElement> AuditQs = null;


        string questionText { get; set; }
        string policyName { get; set; }
        string text { get; set; }
       string ActivePolicytext { get; set; }
       string HSName { get; set; }







        public void RedirectToPolicy()
        {
            String actualURL = ObjectRepository.driver.Url;
            string Url = "https://peakqa.3m.com/#/policy";
            string DEUrl = "https://peakqa.3m.com/#/data-entry";
            if (actualURL==Url)
            {
                Console.WriteLine("Don't click");
            }else if (actualURL==DEUrl)
            
            {
                WebDriverWait wait = new WebDriverWait(ObjectRepository.driver, TimeSpan.FromSeconds(10));
                IWebElement firstResult = wait.Until(e => e.FindElement(By.XPath("//p[text()='Audit Setup']")));
                Thread.Sleep(10000);

                
                ObjectRepository.driver.FindElement(By.XPath("//p[text()='Audit Setup']")).Click();
            }
            else
            {

                ObjectRepository.driver.FindElement(AuditTab).Click();
            }
        }
        public bool EnablePolicyButton()
        {
            var enablePolicy = ObjectRepository.driver.FindElement(CreatePolicyButton).Enabled;
            return enablePolicy;

        }
        public void ClickCreatePolicy()
        {
            ObjectRepository.driver.FindElement(CreatePolicyButton).Click();
        }
        public string GetText()
        {
            Thread.Sleep(2000);
            string text=ObjectRepository.driver.FindElement(CreatePolicyText).Text;
            return text;

        }
        public string SelectAuditType()
        {
            CommonUtility common = new CommonUtility();
            string policyName = "Audit" + common.GenerateRandomString();
            var selectAudit=ObjectRepository.driver.FindElement(AuditType);
            var selectElement = new SelectElement(selectAudit);           
            selectElement.SelectByText("Comprehensive Audit/Point Prevalence");
            ObjectRepository.driver.FindElement(PolicyName).SendKeys(policyName);
            return policyName;


        }
        public string Select21DayAuditType()
        {
            CommonUtility common = new CommonUtility();
            string policyName = "Audit" + common.GenerateRandomString();
            var selectAudit = ObjectRepository.driver.FindElement(AuditType);
            var selectElement = new SelectElement(selectAudit);
            selectElement.SelectByText("3M™ Curos™ Disinfecting Port Protectors 21 Day Challenge");
            ObjectRepository.driver.FindElement(PolicyName).SendKeys(policyName);
            return policyName;


        }
        public string setPolicyName()
        {
            return policyName;
        }
        public void ClickNext()
        {
            ObjectRepository.driver.FindElement(NextButton).Click();
        }
        public  void compliance_rate()

        {
            
            var yellowComplianceValue= Convert.ToInt32(ObjectRepository.driver.FindElement(yellowComplianceInput).GetAttribute("value"));
            var greenComplianceValue = Convert.ToInt32(ObjectRepository.driver.FindElement(greenComplianceInput).GetAttribute("value"));
             //int Convert.ToInt32(yellowComplianceValue);
            if (yellowComplianceValue > 75 && greenComplianceValue<85)
            {
                bool acb=ObjectRepository.driver.FindElement(NextButton).Enabled;
                if (acb)
                {
                    Assert.Fail();
                }
                
            }

        }

        public string AuditScope()
        {
            string text=ObjectRepository.driver.FindElement(AuditScopeText).Text;
            return text;
            
        }
        
        public string AuditScopeQ3()
        {
            
            
            questionText = ObjectRepository.driver.FindElement(AuditQ3Text).Text;
            ObjectRepository.driver.FindElement(AuditQ3Text).Click();
            ClickNext();

            return questionText;

        }
        
        public string SummaryPage()
        {
            string qsText = questionText;
            string summaryText= ObjectRepository.driver.FindElement(Summary).Text;
            if (summaryText.Contains(qsText))
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.Fail();
            }
            return summaryText;


        }
        public void FinishAndMakeActive()
        {
            ObjectRepository.driver.FindElement(FinishAndActive).Click();
        }
        
        public void ActivePolicy()
        {
             ActivePolicytext = ObjectRepository.driver.FindElement(ActivePolicyName).Text;
            DataModal.activePolicy=ActivePolicytext;

            DataModal.policy = new Common.PolicyDataModal()
            {
                IsActive = true,
                PolicyName = ActivePolicytext
            };

        }
        public string SetActivePolicy()
        {
            return ActivePolicytext;
            
        }

        public string  MatchQuestionHeader()
        {
            string header=ObjectRepository.driver.FindElement(QuestionHeader).Text;
            return header;
        }
        public static void Match21Daypolicy()
        {
            IList<IWebElement> products = null;
            products = ObjectRepository.driver.FindElements(By.ClassName("checkbox-option"));
            int count = products.Count;
            ReadExcelClass.excelOf21Days();
            for (int i = 0; i < count; i++)
            {
                var items = products[i];
                //Console.WriteLine(items.Text);
                string actualvalue = items.Text;
                if (rowCount == 11)
                {
                    rowCount++;
                    i--;
                    continue;

                }
                string Audi = ReadExcelClass.getdata(rowCount);
                Console.WriteLine(Audi);
                Console.WriteLine(actualvalue);

                Assert.IsTrue(actualvalue.Contains(Audi), actualvalue + " doesn't contains actual value'");

                rowCount++;

            }
            ReadExcelClass.excelQuit();
            //ReadExcelClass.excelClose();


        }

        public static void count_policy()
        {
            IList<IWebElement> products = null;
            products = ObjectRepository.driver.FindElements(By.ClassName("checkbox-option"));
            int count = products.Count;
            ReadExcelClass.excel();
            for (int i = 0; i < count; i++)
            {
                var items = products[i];
                //Console.WriteLine(items.Text);
                string actualvalue = items.Text;
                if (rowCount == 11)
                {
                    rowCount++;
                    i--;
                    continue;

                }
                string Audi = ReadExcelClass.getdata(rowCount);
                Console.WriteLine(Audi);
                Console.WriteLine(actualvalue);

                Assert.IsTrue(actualvalue.Contains(Audi), actualvalue + " doesn't contains actual value'");

                rowCount++;

            }
            ReadExcelClass.excelQuit();
            //ReadExcelClass.excelClose();
           

        }
        public void SelectRandomQs()
        {
            IList<IWebElement> products = null;
            products = ObjectRepository.driver.FindElements(By.ClassName("checkbox-option"));
            int count = products.Count;
            

            for (int i = 0; i < count; i++)
            {
                var items = products[i];
                //Console.WriteLine(items.Text);
                string actualvalue = items.Text;
            }
            products[2].Click();
        }
        public void NeedlelessConnectors21Day()
        {
            int rowCount = 2;
            var web_ele = ObjectRepository.driver.FindElement(QuestionHeader).Text;
            ReadExcelClass.excelOf21Days();
            string Audit = ReadExcelClass.r1.Cells[3][2].Value;
            if (web_ele == Audit)
            {
                Console.WriteLine("Element Matched");
            }
            else
            {
                Assert.Fail();
            }



            IList<IWebElement> products = null;
            products = ObjectRepository.driver.FindElements(QuestionRadio);
            int count = products.Count;
            Console.WriteLine(count);
            for (int i = 0; i < count; i++)
            {
                var items = products[i];
                Console.WriteLine(items.Text);
                string actualvalue = items.Text;
               
                string Audi1 = ReadExcelClass.SubQsDetail3(rowCount);
                Console.WriteLine(Audi1);

                if (Audi1.Contains(actualvalue) || actualvalue.Contains(Audi1))
                {
                    items.Click();
                    rowCount++;
                }
            }
            ReadExcelClass.excelQuit();
            //ReadExcelClass.excelClose();
           

        }

        public void toggleSwitch()
        {
            ObjectRepository.driver.FindElement(switchtoggle).Click();
           
        }

        public void VerifyHSName()
        {
             HSName = ObjectRepository.driver.FindElement(healthsystemName).GetAttribute("value");
            Console.WriteLine(HSName);
            if (ObjectRepository.config.GetFacilityNameForHealthSystem().Contains(HSName))
            {
                Assert.IsTrue(true, "Health system name exists");
            }

        }
         public void HSPolicy()
        {
            Thread.Sleep(3000);
            IList<IWebElement>policyList=ObjectRepository.driver.FindElements(policiesNameList).ToList();
            string activePolicyName = ObjectRepository.driver.FindElement(ActivePolicyName).Text; 
            string healthSystemName = HSName;

            string healthSystemPolicyName = string.Concat(activePolicyName ," - ", healthSystemName);
            string[] allPolicy = new string[policyList.Count];
            int i = 0;
            foreach (IWebElement element in policyList)
            {
                allPolicy[i++] = element.Text;
            }
            if (allPolicy.Contains(healthSystemPolicyName))
            {
                Assert.IsTrue(true, "Health System policy created sucessfully");
            }
            else
            {
                Assert.IsFalse(true);
            }
          
        }

        public void SelectFacilityForHealthSystemPolicy()
        {
            //Thread.Sleep(3000);
            ObjectRepository.driver.FindElement(FacilityDropdown).Click();
            IList<IWebElement> storeFacility = null;
            storeFacility = ObjectRepository.driver.FindElements(FacilityList);
            int countFacility = storeFacility.Count;
            List<string> hsFacility = DataModal.healthSystemFacility;


            for (int i = 0; i <= countFacility; i++)
            {

                string SelectFacility = storeFacility[i].Text;
                for (int j = 0; j <= hsFacility.Count; j++)
                {
                    if (SelectFacility.Contains(hsFacility[j]))
                    {
                        storeFacility[i].Click();
                        IList<IWebElement> policyList = ObjectRepository.driver.FindElements(policiesNameList).ToList();
                        
                        string[] allPolicy = new string[policyList.Count];
                        int k = 0;
                        foreach (IWebElement element in policyList)
                        {
                            allPolicy[k++] = element.Text;
                        }

                    }
                }

            }

        }



        public void HSFacilityPolicy()
        {

        }

         }
}
