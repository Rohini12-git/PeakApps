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
    class PatientAnswer
    {
        By PolicyList = By.ClassName("row-container");
        By PolicyColumn = By.ClassName("column-group");
        By EditButton = By.TagName("button");
        By policyname = By.ClassName("column-flex");      
        By facility = By.Id("facility");
        

        static List<string> list;
        public void Editpolicy()
        {
            
            string policyName = DataModal.activePolicy;
            IList<IWebElement> policy = null;
            policy = ObjectRepository.driver.FindElements(PolicyList);
           // Thread.Sleep(5000);

            int count = policy.Count;
            for (int i = 1; i < count; i++)
            {
                Thread.Sleep(2000);
                string actualvalue = policy[i].Text;
                List<IWebElement> Policyname = policy[i].FindElements(policyname).ToList();
                string text = Policyname[0].Text;

                Console.WriteLine(actualvalue);
                List<IWebElement> columns = policy[i].FindElements(PolicyColumn).ToList();
                var buttons = columns[0].FindElements(EditButton);
                if (text.Equals(policyName))
                {
                    buttons.Last().Click();
                    break;
                }
                else
                {
                    Console.WriteLine(policyName + "not found");
                }
            }
        }
        public void Policy3N()
        {
            ObjectRepository.driver.FindElement(By.XPath("//button[contains(text(),'Next')]")).Click();
            ObjectRepository.driver.FindElement(By.XPath("//button[contains(text(),'Next')]")).Click();
            ObjectRepository.driver.FindElement(By.XPath("//button[contains(text(),'Next')]")).Click();
            ObjectRepository.driver.FindElement(By.XPath("//button[contains(text(),'Next')]")).Click();
            IList<IWebElement> summaryList = ObjectRepository.driver.FindElements(By.XPath("//div[@class='response-label']//div"));


            Console.WriteLine(summaryList);
            if (DataModal.policy.PolicyQuestions.Count > 0)
            {
                DataModal.policy.PolicyQuestions.Clear();
            }
            int summaryCount = summaryList.Count;
            for (int i = 0; i < summaryCount; i++)
            {
                var summaryText = summaryList[i].Text;
                DataModal.policy.PolicyQuestions.Add(summaryText);

            }
            ObjectRepository.driver.FindElement(By.XPath("//button[@class='close-button']")).Click();
           
        }
        public void Copypolicy()
        {
            while (true)
            {
                var elementbtn = ObjectRepository.driver.FindElements(By.XPath("//div[@class='button-group']//button"));


                if (elementbtn.Count == 2)
                {
                    ObjectRepository.driver.FindElement(By.XPath("//button[contains(text(),'Next')]")).Click();
                } 
                else
                {
                    IList<IWebElement> summaryList = ObjectRepository.driver.FindElements(By.XPath("//div[@class='response-label']//div"));


                    Console.WriteLine(summaryList);
                    if (DataModal.policy.PolicyQuestions.Count > 0)
                    {
                        DataModal.policy.PolicyQuestions.Clear();
                    }
                    int summaryCount = summaryList.Count;
                    for (int i = 0; i < summaryCount; i++)
                    {
                        var summaryText = summaryList[i].Text;
                        DataModal.policy.PolicyQuestions.Add(summaryText);

                    }
                    ObjectRepository.driver.FindElement(By.XPath("//button[@class='close-button']")).Click();
                    break;
                }


            }


        }

        public void storedPolicy()
        {
            List<string> policyAns = DataModal.policy.PolicyQuestions;
            Console.WriteLine(policyAns);

        }
        public void fetch3DPolicy()
        {
            
            string ActivePolicy = DataModal.policy.PolicyName;
            ReadExcelClass.DataEntryExcel();
            ReadExcelClass.DataEntry3DPolicy();
            ReadExcelClass.excelQuit();


        }
        public void SelectFacilityForDataEntry()
        {
            IWebElement element = ObjectRepository.driver.FindElement(facility);
            SelectElement oSelect = new SelectElement(element);
            oSelect.SelectByText(ObjectRepository.config.GetFacilityNameForDataEntry());
            Thread.Sleep(3000);

        }
        public void CustomQuestionAnswer()
        {
            List<IWebElement> allColumnsInRow = new List<IWebElement>(ObjectRepository.driver.FindElements(By.XPath("//*[@id='Comprenhensive']/thead/tr[2]/td ")));
            foreach (IWebElement Row in allColumnsInRow)
            {

                list.Add(Row.Text);
            }
        }
        public void DEQs()
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
            string activePolicy = DataModal.activePolicy;
            var compareList = DataModal.dataentryQs.Except(list).ToList();
            if (compareList.Count==0)
            {
              
             int count = 1;
            List<IWebElement> secondRows = new List<IWebElement>(ObjectRepository.driver.FindElements(By.XPath("//*[@id='Comprenhensive']/tbody/tr/td")));
            foreach (IWebElement Coloumn in secondRows)
            {
                foreach (var ele in list)
                {
                    var policyansqs = DataModal.dataentryAns;
                    
                    if (policyansqs == null)
                        continue;
                    if (policyansqs == "Yes/No")
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


                        if (ele.Equals("Reference Info", StringComparison.OrdinalIgnoreCase))
                              
                        {
                            textXpath = "//*[@id='Comprenhensive'   ]/tbody/tr/td[" + count + "]/div/textarea";
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

            var next = ObjectRepository.driver.FindElement(By.XPath("//button[contains(text(),'Next')]"));

            if (next.Enabled)
            {
                next.Click();
                   
            }
            else
            {
                 Thread.Sleep(3000);
                var endAudit = ObjectRepository.driver.FindElement(By.XPath("//button[@name='EndAudit']"));
                endAudit.Click();
            }

            }
        }

       

        

    }
}
