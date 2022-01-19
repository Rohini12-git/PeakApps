using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PeakApps.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PeakApps.Custom_Class
{
    class DataEntry
    {
        static List<string> list;
        By DataEntryTab = By.XPath("//p[text()='Data Entry']");
        By selectedDate = By.XPath("//div//span[@class='selected-date-text']");
        By startButton = By.XPath("//div//button[@name='start' and @type='submit']");
        By cancelButton = By.XPath("//button[@name='Cancel' and @type='submit']");
        By yesButton = By.XPath("//button[text()='Yes' and @type='button']");
        By ActivePolicySelector = By.XPath("//div[@class='selector']");
        By ActivePolicyText = By.XPath("//span[@class='option-label']");
        By ActivePolicyList = By.XPath("//span[@class='dropdown-option-label']");
        By UnitName = By.XPath("//div[@class='text-start']");
        By facility = By.Id("facility");
        By shift = By.Id("shift");
        By unit = By.Id("unit");
        By QuestionHeader = By.XPath("//*[@id='Comprenhensive']/thead/tr[1]/th");
        By DataEntryQuestion = By.XPath("//*[@id='Comprenhensive']/thead/tr[2]/td ");
        By DataEntryAnswer = By.XPath("//*[@id='Comprenhensive']/tbody/tr/td");
        By textarea = By.XPath("//td//div//textarea[@type='text']");
        By NextButton = By.XPath("//button[contains(text(),'Next')]");
        By EndAudit = By.XPath("//button[@name='EndAudit']");
        By SelectQs = By.XPath("//td//div//select");
        By NextPatient = By.XPath("//button[@name='addpatient']");
        By AddCatheter = By.XPath("//button[@name='addcatheter']");
        By sucess_message = By.XPath("//div[@class='message']");
        By removeAudit = By.XPath("//button[@name='removeaudit']");
        By FacilityDropdown = By.XPath("//section[@class='facility-selector']//span");
        By FacilityList = By.XPath("//span[@class='facility-options-text']");




        public void RedirectToDataEntry()
        {
            String actualURL = ObjectRepository.driver.Url;
            string Url = "https://peakqa.3m.com/#/data-entry";
            if (actualURL == Url)
            {
                Console.WriteLine("Don't click");
            }
            else
            {
                WebDriverWait wait = new WebDriverWait(ObjectRepository.driver, TimeSpan.FromSeconds(10));
                IWebElement firstResult = wait.Until(e => e.FindElement(DataEntryTab));

                ObjectRepository.driver.FindElement(DataEntryTab).Click();
            }
            Thread.Sleep(3000);
        }
        public void SelectFacility()
        {
            IWebElement element = ObjectRepository.driver.FindElement(facility);
            SelectElement oSelect = new SelectElement(element);
            oSelect.SelectByText(ObjectRepository.config.GetFacilityName());

        }
        public void SelectHSFacility()
        {
            IWebElement element = ObjectRepository.driver.FindElement(facility);
            SelectElement oSelect = new SelectElement(element);
            
            string[] hsFacility= DataModal.healthSystemFacility[1].Split('-');
            string facilityName = hsFacility[0].TrimEnd();
            oSelect.SelectByText(facilityName);

        }
        public void SelectDate()
        {
          string date=  ObjectRepository.driver.FindElement(selectedDate).Text;
            Console.WriteLine(date);
        }
        public void SelectShift()
        {
            IWebElement element = ObjectRepository.driver.FindElement(shift);
            SelectElement oSelect = new SelectElement(element);
            oSelect.SelectByText("DAY");
        }
        string selectedoption { get; set; }
        public string SelectUnit()
        {
            Thread.Sleep(3000);
            IWebElement element = ObjectRepository.driver.FindElement(unit);
            WebDriverWait wait = new WebDriverWait(ObjectRepository.driver, TimeSpan.FromSeconds(10));
            

            SelectElement oSelect = new SelectElement(element);
            IWebElement firstResult = wait.Until(e => e.FindElement(unit));
            oSelect.SelectByIndex(0);
            IWebElement getText = oSelect.SelectedOption;
            selectedoption = getText.Text;
            return selectedoption;
        }
        public void EnableStart()
        {
            Thread.Sleep(5000);
            bool buttonEnable=ObjectRepository.driver.FindElement(startButton).Enabled;
            Assert.IsTrue(buttonEnable);

        }
        public void ClickStart()
        {
            Thread.Sleep(5000);
            ObjectRepository.driver.FindElement(startButton).Click();
            
        }
        public void verifyUnitName()
        {
            string getUnitText = ObjectRepository.driver.FindElement(UnitName).Text;
            string selectedUnit = selectedoption;

            if (getUnitText.Contains(selectedUnit))
            {
                ObjectRepository.driver.FindElement(cancelButton).Click();
                ObjectRepository.driver.FindElement(yesButton).Click();


            }
        }
        
        public void ActivePolicy(string policyName)
        {
            Thread.Sleep(10000);
            ObjectRepository.driver.FindElement(ActivePolicySelector).Click();

            IList<IWebElement> storeActivePolicy = null;
            storeActivePolicy = ObjectRepository.driver.FindElements(ActivePolicyList);
            int countActivePolicy = storeActivePolicy.Count;
            
            var wait = new WebDriverWait(ObjectRepository.driver, TimeSpan.FromSeconds(10));
            wait.Until((d) =>
            {
                var elements = d.FindElements(ActivePolicyList);
                return (elements.Count > 0)
                    ? elements
                    : null;
            });
           
            for (int i = 0; i <= countActivePolicy; i++)
            {
                
                string SelectPolicy = storeActivePolicy[i].Text;
                
                if (SelectPolicy.Equals(policyName))
                {
                    storeActivePolicy[i].Click();
                    
                    DataModal.activePolicy = ObjectRepository.driver.FindElement(ActivePolicyText).Text;
                    break;
                }
            }
            Thread.Sleep(12000);
        }

        public string FetchActivePolicyName()
        {
            string ActivePolicy=ObjectRepository.driver.FindElement(ActivePolicyText).Text;
            
            return ActivePolicy;
        }
        public void RemovePatient()
        {
            var endAudit = ObjectRepository.driver.FindElement(EndAudit);
            if (endAudit.Enabled)
            {
                ObjectRepository.driver.FindElement(removeAudit).Click();
            }
            else
            {
                AnsDataEntryQs();
                ObjectRepository.driver.FindElement(removeAudit).Click();
            }
        }
        public void clickYes()
        {
            ObjectRepository.driver.FindElement(yesButton).Click();
        }
        public void EditAndCreateDE()
        {
            var endAudit = ObjectRepository.driver.FindElement(EndAudit);
            if (endAudit.Enabled)
            {
                string message = " Found existing audit for the current selection.";
                //if(message)
                List<IWebElement> selectAnsNext = new List<IWebElement>(ObjectRepository.driver.FindElements(SelectQs));
                foreach (IWebElement element in selectAnsNext)
                {
                    var selectElement = new SelectElement(element);

                    selectElement.SelectByIndex(2);
                }
            }
            else
            {
                AnsDataEntryQs();
            }
        }
            public void AnsDataEntryQs()
        {
            

             ObjectRepository.driver.FindElement(textarea).SendKeys("demo");
            List<IWebElement> selectAns = new List<IWebElement>(ObjectRepository.driver.FindElements(SelectQs));
            foreach(IWebElement element in selectAns)
            {
                var selectElement = new SelectElement(element);
                
                selectElement.SelectByText("Yes");
            }

            //var next=ObjectRepository.driver.FindElement(NextButton).Click();
            var next = ObjectRepository.driver.FindElement(NextButton);

            if (next.Enabled)
            {
                next.Click();
                List<IWebElement> selectAnsNext = new List<IWebElement>(ObjectRepository.driver.FindElements(SelectQs));
                foreach (IWebElement element in selectAnsNext)
                {
                    var selectElement = new SelectElement(element);

                    selectElement.SelectByIndex(2);
                }

            }
            
            
        }
        public void AddCatheterforPatient()
        {
            List<IWebElement> selectAns = new List<IWebElement>(ObjectRepository.driver.FindElements(SelectQs));
            foreach (IWebElement element in selectAns)
            {
                var selectElement = new SelectElement(element);

                selectElement.SelectByIndex(1);
            }
        }
        public void clickNextPatient()
        {
            ObjectRepository.driver.FindElement(NextPatient).Click();
        }
        public void clickAddCatheter()
        {
            ObjectRepository.driver.FindElement(AddCatheter).Click();
        }
        public void clickEndAudit()
        {
            ObjectRepository.driver.FindElement(EndAudit).Click();
            
        }
        public string sucessMsg()
        {
            string text = ObjectRepository.driver.FindElement(sucess_message).Text;
            Console.WriteLine("Alert text is " + text);
            return text;
        }
        public void DEQs()
        {

            list = new List<string>();
            List<IWebElement> allHeadersOfTable = new List<IWebElement>(ObjectRepository.driver.FindElements(QuestionHeader));
            foreach (IWebElement header in allHeadersOfTable)
            {
                Console.WriteLine(header.Text);
            }
            List<IWebElement> allColumnsInRow = new List<IWebElement>(ObjectRepository.driver.FindElements(DataEntryQuestion));
            foreach (IWebElement Row in allColumnsInRow)
            {
                    
                list.Add(Row.Text);
            }
            
            
            int count = 1;
            List<IWebElement> secondRows = new List<IWebElement>(ObjectRepository.driver.FindElements(DataEntryAnswer));
            foreach (IWebElement Coloumn in secondRows)
            {
                //List<IWebElement> dataentryAns= new List<IWebElement>(ObjectRepository.driver.FindElements(DataEntryPolicyAnswer));
                //List<IWebElement> dataentryTextAreaAns = new List<IWebElement>(ObjectRepository.driver.FindElements(DataEntryTextArea));
                foreach (var ele in list)
                {
                    var policyansqs = ObjectRepository.driver.FindElement(By.XPath("//select[@name='abc']"));


                    
                    if (policyansqs.Displayed)
                    {
                        
                        string drop = "//table/tbody/tr/td[" + count + "]/div/select";

                        var ip = ObjectRepository.driver.FindElement(By.XPath(drop));
                        ip.Click();
                        string selectvalue = "//table/tbody/tr/td[" + count + "]/div/select/option[2]";

                        ObjectRepository.driver.FindElement(By.XPath(selectvalue)).Click();




                    }
                    else
                    {
                        string textXpath = "";


                        if (ele == "Reference info")
                        {
                            textXpath = "//*[@id='Comprenhensive']/tbody/tr/td[" + count + "]/div/textarea";
                        }
                        else
                        {
                            textXpath = "//*[@id='Comprenhensive']/tbody/tr/td[" + count + "]/div/td/input";
                        }

                        string text = "100";
                        ObjectRepository.driver.FindElement(By.XPath(textXpath)).SendKeys(text);
                        
                    }
                    count++;
                    break;
                }
                if (list.Count > 0)
                    list.RemoveAt(0);
                
                   

                
            }

            var next = ObjectRepository.driver.FindElement(NextButton);

            if (next.Displayed)
            {
                next.Click();
                DEQsEnd();
            }
            else
            {
                var endAudit = ObjectRepository.driver.FindElement(EndAudit);
                endAudit.Click();
            }

        }

        public static void DEQsEnd()
        {
            list = new List<string>();
            List<IWebElement> allHeadersOfTable = new List<IWebElement>(ObjectRepository.driver.FindElements(By.XPath("//*[@id='Comprenhensive']/thead/tr[1]/th")));
            foreach (IWebElement header in allHeadersOfTable)
            {
                Console.WriteLine(header.Text);
            }
            List<IWebElement> allColumnsInRow = new List<IWebElement>(ObjectRepository.driver.FindElements(By.XPath("//*[@id='Comprenhensive']/thead/tr[2]/td ")));
            foreach (IWebElement Row in allColumnsInRow)
            {

                list.Add(Row.Text);
            }


            int count = 1;
            List<IWebElement> secondRows = new List<IWebElement>(ObjectRepository.driver.FindElements(By.XPath("//*[@id='Comprenhensive']/tbody/tr/td")));
            foreach (IWebElement Coloumn in secondRows)
            {
                foreach (var ele in list)
                {

                    //_list.Contains(ele);
                    var policyansqs = ObjectRepository.driver.FindElement(By.XPath("//select[@name='abc']"));
                    //var policyansqs = policyqs.Where(x => x.title == ele).Select(x => x).FirstOrDefault();
                    if (policyansqs == null) continue;
                    if (policyansqs.Displayed)
                    {
                        // var selectvalue = AuditClass.driver.FindElement(By.XPath("//*[@id='Comprenhensive']/tbody/tr/td["+count+"]/div/app-selector/div")); //*[@id="Comprenhensive"]/tbody/tr/td[8]/div/app-selector/div
                        string drop = "//table/tbody/tr/td[" + count + "]/div/select";
                        var ip = ObjectRepository.driver.FindElement(By.XPath(drop));
                        ip.Click();
                        string selectvalue = "//table/tbody/tr/td[" + count + "]/div/select/option[2]";
                        ObjectRepository.driver.FindElement(By.XPath(selectvalue)).Click();




                    }
                    else if (policyansqs.Displayed)
                    {
                        string drop = "//table/tbody/tr/td[" + count + "]/div/select";

                        var ip = ObjectRepository.driver.FindElement(By.XPath(drop));
                        ip.Click();
                        string selectvalue = "//table/tbody/tr/td[" + count + "]/div/select/option[2]";
                        ObjectRepository.driver.FindElement(By.XPath(selectvalue)).Click();
                    }


                    else
                    {
                        string textXpath = "";


                        if (ele == "Reference info")
                        {
                            textXpath = "//*[@id='Comprenhensive']/tbody/tr/td[" + count + "]/div/input";
                        }
                        else
                        {
                            textXpath = "//*[@id='Comprenhensive']/tbody/tr/td[" + count + "]/div/td/input";
                        }

                        string text = "100";
                        ObjectRepository.driver.FindElement(By.XPath(textXpath)).SendKeys(text);

                    }
                    count++;
                    break;
                }
                if (list.Count > 0)
                    list.RemoveAt(0);
            }

            var endAudit = ObjectRepository.driver.FindElement(By.XPath("//button[@name='EndAudit']"));
            endAudit.Click();
        }

        public void clickCancel()
        {
            ObjectRepository.driver.FindElement(cancelButton).Click();
            ObjectRepository.driver.FindElement(yesButton).Click();

        }

        
        public void ActivepolicyOfHSFacility(string activePolicy)
        {
            Thread.Sleep(3000);
            ObjectRepository.driver.FindElement(FacilityDropdown).Click();
            IList<IWebElement> storeFacility = null;
            //storeFacility = ObjectRepository.driver.FindElements(FacilityList);
            List<string> FacilityTexts = ObjectRepository.driver.FindElements(FacilityList).Select(iw => iw.Text).ToList();
            int countFacility = ObjectRepository.driver.FindElements(FacilityList).Count;
            List<string> hsFacility = DataModal.healthSystemFacility;
            List<List<string>> masterList = new List<List<string>>();
            var sameHSFacility = FacilityTexts.Intersect(hsFacility).Count();

            for (int k = 0; k < sameHSFacility; k++)
            {
                if (k > 0)
                {
                    ObjectRepository.driver.FindElement(FacilityDropdown).Click();
                }
                storeFacility = ObjectRepository.driver.FindElements(FacilityList);
                int index = FacilityTexts.FindIndex(a => a.Contains(hsFacility[k]));
                ObjectRepository.driver.FindElements(FacilityList)[index].Click();
                

            }
            ActivePolicy(activePolicy);

            ObjectRepository.driver.FindElement(By.XPath("//body")).Click();
            
        }



    }
}
