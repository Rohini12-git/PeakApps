using NUnit.Framework;
using OpenQA.Selenium;
using PeakApps.Common;
using PeakApps.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakApps.Custom_Class
{
    class AuditCompareClass
    {
        By closeButton = By.XPath("//button[@type='button' and @class='close-button']");
        By okButton = By.XPath("//button[@type='button' and text()='OK']");
        By chkOption = By.ClassName("checkbox-option");
        By NextButton = By.XPath("//button[contains(text(),'Next')]");
        By txtArea = By.TagName("textarea");
        By patientTypeCustom = By.XPath("//div//label[@class='custom-container'][1]");
        By questionSet = By.XPath("//span[@class='question']");
        By radioButton = By.ClassName("radio-group");
        By questionHeader = By.XPath("//label[contains(text(),'Define protocol for dressing application for each')]");
        By Inputvalue = By.XPath("//input[@name='answer.id']");
        By InputmatricRadio = By.XPath("@id='radioQ11.b'");
        By DisinfectingQs = By.XPath("//label[contains(text(),'Disinfecting cap')]");
        By RadioGroupAnswer = By.ClassName("radio-group-answer");



        By EndCapQs = By.XPath("//label[contains(text(),'End cap')]");
        public  void closePolicy()
        {
            ObjectRepository.driver.FindElement(closeButton).Click();
            ObjectRepository.driver.FindElement(okButton).Click();
        }
        public  void count_policy()
        {
            int rowCount = 2;
            IList<IWebElement> products = null;
            products = ObjectRepository.driver.FindElements(chkOption);
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

            ReadExcelClass.excelClose();

        }
        public  void single_data()
        {
            int single_val = 5;

            IList<IWebElement> products = null;
            products = ObjectRepository.driver.FindElements(chkOption);
            int count = products.Count;
            ReadExcelClass.excel();
            for (int i = 3; i < count; i++)
            {
                if (i == 6 && single_val == 8)
                {
                    single_val++;
                    continue;
                }

                if (i == 8 && single_val == 10)
                {
                    single_val++;
                    continue;
                }


                if (i == 9 && single_val == 11)
                {
                    single_val++;
                    continue;
                }

                if (single_val == 12)
                {
                    i--;
                    single_val++;
                    continue;
                }
                var items = products[i];

                string actualvalue = items.Text;
                
                
                string Audi = ReadExcelClass.getdata(single_val);
                Console.WriteLine(Audi);
                if (actualvalue == Audi)
                {
                   // DataModal.policy.PolicyQuestions.Add(actualvalue);
                    items.Click();
                    single_val++;

                }



            }

            ObjectRepository.driver.FindElement(NextButton).Click();
            ReadExcelClass.excelClose();

        }

        public  void CustomQs()
        {
            ObjectRepository.driver.FindElement(txtArea).SendKeys("custom ans for patient");
            ObjectRepository.driver.FindElement(patientTypeCustom).Click();
            ObjectRepository.driver.FindElement(NextButton).Click();
        }
        public  void double_data()
        {

            int double_val = 10;

            IList<IWebElement> products = null;
            products = ObjectRepository.driver.FindElements(chkOption);
            int count = products.Count;
            ReadExcelClass.excel();
            for (int i = 8; i < count - 1; i++)
            {
                var items = products[i];
                string actualvalue = items.Text;
                Console.WriteLine(actualvalue);
                if (double_val == 11)
                {
                    i--;
                    double_val++;
                    continue;
                }
                string Audi = ReadExcelClass.getdata(double_val);


                Console.WriteLine(Audi);
                if (actualvalue == Audi)
                {

                    items.Click();
                    double_val++;
                }
            }
            ObjectRepository.driver.FindElement(NextButton).Click();
            ReadExcelClass.excelClose();
        }
        public  void double_next()
        {
            int rowCount = 10;
            var web_ele = ObjectRepository.driver.FindElement(questionSet).Text;
            ReadExcelClass.excel();

            string Audi = ReadExcelClass.r1.Cells[3][10].Value;
            if (web_ele == Audi)
            {
                IList<IWebElement> products = null;
                products = ObjectRepository.driver.FindElements(radioButton);
                int count = products.Count;

                for (int i = 0; i < count; i++)
                {
                    var items = products[i];
                    Console.WriteLine(items.Text);
                    string actualvalue = items.Text;

                    string Audi1 = ReadExcelClass.getdoubledata(rowCount);
                    Console.WriteLine(Audi);




                    if (Audi1.Contains(actualvalue) || actualvalue.Contains(Audi1))
                    {
                        items.Click();
                        rowCount++;
                    }


                }

                ObjectRepository.driver.FindElement(NextButton).Click();

            }
            ReadExcelClass.excelClose();
        }

        public  void double_next1()
        {

            var web_ele = ObjectRepository.driver.FindElement(questionHeader).Text;
            ReadExcelClass.excel();

            string Audi = ReadExcelClass.r1.Cells[3][12].Value;

            if (web_ele == Audi)
            {
                ObjectRepository.driver.FindElement(By.XPath("//label[contains(text(),'Define protocol for dressing application for each ')]")).Click();
                ObjectRepository.driver.FindElement(By.XPath("//input[@name='answer.id']")).Click();
                ObjectRepository.driver.FindElement(By.XPath("//input[@name='answer.id']")).SendKeys("demo");
                ObjectRepository.driver.FindElement(By.XPath("/html/body/simple-modal-holder/simple-modal-wrapper/div/app-create-and-edit-policy-modal-dialog/div/div/div/button[2]")).Click();

            }
            else
            {
                Assert.Fail();
            }
            ReadExcelClass.excelClose();
        }
        public static void needleless_connectors()
        {
            ObjectRepository.driver.FindElement(By.XPath(" //label[contains(text(),'Disinfection and/or protection of needleless conne')]")).Click();
            ObjectRepository.driver.FindElement(By.XPath("/html/body/simple-modal-holder/simple-modal-wrapper/div/app-create-and-edit-policy-modal-dialog/div/div/div/button[2]")).Click();
        }
        public static void male_luers()
        {
            ObjectRepository.driver.FindElement(By.XPath(" //label[contains(text(),'Disinfection and/or protection of male luers (dist')]")).Click();
            ObjectRepository.driver.FindElement(By.XPath("/html/body/simple-modal-holder/simple-modal-wrapper/div/app-create-and-edit-policy-modal-dialog/div/div/div/button[2]")).Click();
        }
        public static void female_luers()
        {
            ObjectRepository.driver.FindElement(By.XPath("//label[contains(text(),'Disinfection and/or protection of open female luer')]")).Click();
            ObjectRepository.driver.FindElement(By.XPath("/html/body/simple-modal-holder/simple-modal-wrapper/div/app-create-and-edit-policy-modal-dialog/div/div/div/button[2]")).Click();
        }
        public  void needleless_connectors_4()
        {
            int rowCount = 2;
            var web_ele = ObjectRepository.driver.FindElement(questionSet).Text;
            ReadExcelClass.excel_1();
            string Audit = ReadExcelClass.r1.Cells[2][2].Value;
            if (web_ele == Audit)
            {
                Console.WriteLine("Element Matched");
            }
            else
            {
                Assert.Fail();
            }

            IList<IWebElement> products = null;
            products = ObjectRepository.driver.FindElements(chkOption);
            int count = products.Count;
            Console.WriteLine(count);
            for (int i = 0; i < count; i++)
            {
                var items = products[i];
                Console.WriteLine(items.Text);
                string actualvalue = items.Text;
               // ReadExcelClass.excel();
                if (rowCount == 3 || rowCount == 4 || rowCount == 5 || rowCount == 6 || rowCount == 7)
                {
                    i--;
                    rowCount++;
                    continue;
                }
                string Audi1 = ReadExcelClass.get_multidata4(rowCount);
                Console.WriteLine(Audi1);

                if (Audi1.Contains(actualvalue) || actualvalue.Contains(Audi1))
                {
                    items.Click();
                    rowCount++;
                }
            }
            ObjectRepository.driver.FindElement(Inputvalue).Click();
           ObjectRepository.driver.FindElement(Inputvalue).SendKeys("demo");

           ObjectRepository.driver.FindElement(NextButton).Click();
            ReadExcelClass.excelClose();

        }

        public  void needleless_connectors_5()
        {

            int rowCount = 2;
            var web_ele = ObjectRepository.driver.FindElement(questionSet).Text;

            ReadExcelClass.excel_1();
            string Audit = ReadExcelClass.r1.Cells[6][2].Value;

            if (Audit.Contains(web_ele))
            {

                IList<IWebElement> products = null;
                products = ObjectRepository.driver.FindElements(chkOption);
                int count = products.Count;

                for (int i = 0; i < count; i++)
                {
                    var items = products[i];
                    Console.WriteLine(items.Text);
                    string actualvalue = items.Text;

                    string Audi1 = ReadExcelClass.get_multidata5(rowCount);
                    Console.WriteLine(Audi1);

                    if (Audi1.Contains(actualvalue) || actualvalue.Contains(Audi1))
                    {
                        items.Click();
                        rowCount++;
                    }


                }
                ObjectRepository.driver.FindElement(Inputvalue).Click();
                ObjectRepository.driver.FindElement(Inputvalue).SendKeys("demo");
                ObjectRepository.driver.FindElement(NextButton).Click();
            }
            else
            {
                Assert.Fail();
            }
            ReadExcelClass.excelClose();
        }

        public  void needleless_connectors_6()
        {

            int rowCount = 2;
            var web_ele = ObjectRepository.driver.FindElement(questionSet).Text;
            ReadExcelClass.excel_1();

            string Audit = ReadExcelClass.r1.Cells[10][2].Value;

            if (web_ele == Audit)
            {

                IList<IWebElement> products = null;
                products = ObjectRepository.driver.FindElements(radioButton);
                int count = products.Count;

                for (int i = 0; i < count; i++)
                {
                    var items = products[i];
                    Console.WriteLine(items.Text);
                    string actualvalue = items.Text;

                    string Audi1 = ReadExcelClass.get_multidata6(rowCount);
                    Console.WriteLine(Audi1);

                    if (Audi1.Contains(actualvalue) || actualvalue.Contains(Audi1))
                    {
                        DataModal.policy.PolicyQuestions.Add(actualvalue);
                        items.Click();
                        rowCount++;
                    }


                }
                ObjectRepository.driver.FindElement(NextButton).Click();
            }
            else
            {
                Assert.Fail();
            }
            ReadExcelClass.excelClose();
        }
        public  void needleless_connectors_11()
        {

            int rowCount = 2;
            var web_ele = ObjectRepository.driver.FindElement(questionSet).Text;
            ReadExcelClass.excel_1();

            string Audit = ReadExcelClass.r1.Cells[14][2].Value;
            if (web_ele == Audit)
            {

                IList<IWebElement> products = null;
                products = ObjectRepository.driver.FindElements(RadioGroupAnswer);
                int count = products.Count;

                for (int i = 0; i < count; i++)
                {
                    var items = products[i];
                    Console.WriteLine(items.Text);
                    string actualvalue = items.Text;

                    string Audi1 = ReadExcelClass.get_multidata11(rowCount);
                    Console.WriteLine(Audi1);

                    if (Audi1.Contains(actualvalue) || actualvalue.Contains(Audi1))
                    {
                        //DataModal.policy.PolicyQuestions.Add(actualvalue);
                        items.Click();
                        rowCount++;
                    }


                }
                ObjectRepository.driver.FindElement(NextButton).Click();
            }

            else
            {
                Assert.Fail();
            }
            ReadExcelClass.excelClose();
        }


        public  void male_luers_7()
        {
            int rowCount = 11;
            var web_ele = ObjectRepository.driver.FindElement(questionSet).Text;
            ReadExcelClass.excel_1();

            string Audit = ReadExcelClass.r1.Cells[2][11].Value;

            if (web_ele == Audit)
            {

                IList<IWebElement> products = null;
                products = ObjectRepository.driver.FindElements(chkOption);
                int count = products.Count;

                for (int i = 0; i < count; i++)
                {
                    var items = products[i];
                    Console.WriteLine(items.Text);
                    string actualvalue = items.Text;
                    if (rowCount == 12 || rowCount == 13 || rowCount == 15)
                    {
                        i--;
                        rowCount++;
                        continue;
                    }
                    string Audi1 = ReadExcelClass.get_multidata7(rowCount);
                    Console.WriteLine(Audi1);

                    if (Audi1.Contains(actualvalue) || actualvalue.Contains(Audi1))
                    {

                        rowCount++;
                    }


                }
                ObjectRepository.driver.FindElement(DisinfectingQs).Click();
                ObjectRepository.driver.FindElement(NextButton).Click();
            }
            else
            {
                Assert.Fail();
            }
            ReadExcelClass.excelClose();
        }

        public  void male_luers_7B()
        {
            int rowCount = 11;
            var web_ele = ObjectRepository.driver.FindElement(questionSet).Text;
            ReadExcelClass.excel_1();
            //string Audi = ReadExcelClass.getdata(3,10);
            string Audit = ReadExcelClass.r1.Cells[2][11].Value;

            if (web_ele == Audit)
            {

                IList<IWebElement> products = null;
                products = ObjectRepository.driver.FindElements(chkOption);
                int count = products.Count;
                //ReadExcelClass.excel();
                for (int i = 0; i < count; i++)
                {
                    var items = products[i];
                    Console.WriteLine(items.Text);
                    string actualvalue = items.Text;
                    if (rowCount == 12 || rowCount == 13 || rowCount == 15)
                    {
                        i--;
                        rowCount++;
                        continue;
                    }
                    string Audi1 = ReadExcelClass.get_multidata7(rowCount);
                    Console.WriteLine(Audi1);

                    if (Audi1.Contains(actualvalue) || actualvalue.Contains(Audi1))
                    {
                        //items.Click();
                        rowCount++;
                    }


                }
                ObjectRepository.driver.FindElement(EndCapQs).Click();
                ObjectRepository.driver.FindElement(NextButton).Click();
            }
            else
            {
                Assert.Fail();
            }
            ReadExcelClass.excelClose();
        }

        public  void male_luers_8()
        {
            int rowCount = 11;
            var web_ele = ObjectRepository.driver.FindElement(questionSet).Text;
            ReadExcelClass.excel_1();

            string Audit = ReadExcelClass.r1.Cells[6][11].Value;

            if (web_ele == Audit)
            {

                IList<IWebElement> products = null;
                products = ObjectRepository.driver.FindElements(chkOption);
                int count = products.Count;
                //ReadExcelClass.excel();
                for (int i = 0; i < count; i++)
                {
                    var items = products[i];
                    Console.WriteLine(items.Text);
                    string actualvalue = items.Text;

                    string Audi1 = ReadExcelClass.get_multidata8(rowCount);
                    Console.WriteLine(Audi1);

                    if (Audi1.Contains(actualvalue) || actualvalue.Contains(Audi1))
                    {
                        items.Click();
                        rowCount++;
                    }


                }
                ObjectRepository.driver.FindElement(Inputvalue).Click();

                ObjectRepository.driver.FindElement(Inputvalue).SendKeys("demo");
                ObjectRepository.driver.FindElement(NextButton).Click();
            }
            else
            {
                Assert.Fail();
            }
            ReadExcelClass.excelClose();
        }

        public  void female_luers_9()
        {
            int rowCount = 19;
            var web_ele = ObjectRepository.driver.FindElement(questionSet).Text;
            ReadExcelClass.excel_1();

            string Audit = ReadExcelClass.r1.Cells[2][19].Value;

            if (web_ele == Audit)
            {

                IList<IWebElement> products = null;
                products = ObjectRepository.driver.FindElements(chkOption);
                int count = products.Count;

                for (int i = 0; i < count; i++)
                {
                    var items = products[i];
                    Console.WriteLine(items.Text);
                    string actualvalue = items.Text;
                    if (rowCount == 20)
                    {
                        i--;
                        rowCount++;
                        continue;
                    }
                    string Audi1 = ReadExcelClass.get_multidata9(rowCount);
                    Console.WriteLine(Audi1);

                    if (Audi1.Contains(actualvalue) || actualvalue.Contains(Audi1))
                    {
                        DataModal.policy.PolicyQuestions.Add(actualvalue);
                        rowCount++;
                    }


                }
                ObjectRepository.driver.FindElement(DisinfectingQs).Click();
                ObjectRepository.driver.FindElement(NextButton).Click();
            }
            else
            {
                Assert.Fail();
            }
            ReadExcelClass.excelClose();
        }

        public  void female_luers_10()
        {
            int rowCount = 19;
            var web_ele = ObjectRepository.driver.FindElement(questionSet).Text;
            ReadExcelClass.excel_1();

            string Audit = ReadExcelClass.r1.Cells[6][19].Value;

            if (web_ele == Audit)
            {

                IList<IWebElement> products = null;
                products = ObjectRepository.driver.FindElements(chkOption);
                int count = products.Count;

                for (int i = 0; i < count; i++)
                {
                    var items = products[i];
                    Console.WriteLine(items.Text);
                    string actualvalue = items.Text;

                    string Audi1 = ReadExcelClass.get_multidata10(rowCount);
                    Console.WriteLine(Audi1);

                    if (Audi1.Contains(actualvalue) || actualvalue.Contains(Audi1))
                    {
                        DataModal.policy.PolicyQuestions.Add(actualvalue);
                        items.Click();
                        rowCount++;
                    }


                }
                ObjectRepository.driver.FindElement(Inputvalue).Click();
                ObjectRepository.driver.FindElement(Inputvalue).SendKeys("demo");
                ObjectRepository.driver.FindElement(NextButton).Click();
            }
            else
            {
                Assert.Fail();
            }

            ReadExcelClass.excelClose();
        }

        
    }
}
