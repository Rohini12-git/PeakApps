using PeakApps.Custom_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace PeakApps.Common
{
    class ReadExcelClass
    {
        static Excel.Workbook w1;
        static Excel.Workbook x1;
        public static Excel.Range r1;


        public static void excelOf21Days()
        {
            Excel.Application x1 = new Excel.Application();
            w1 = x1.Workbooks.Open(@"C:\Users\Rohini\source\repos\PeakApps\Features\Audit.xlsx");
            Excel._Worksheet s1 = w1.Sheets[7];
            r1 = s1.UsedRange;
        }
        public static void excel()
        {
            Excel.Application x1 = new Excel.Application();
            w1 = x1.Workbooks.Open(@"C:\Users\Rohini\source\repos\PeakApps\Features\Audit.xlsx");
            Excel._Worksheet s1 = w1.Sheets[1];
            r1 = s1.UsedRange;
        }
        public static void excel_1()
        {
            Excel.Application x1 = new Excel.Application();
            w1 = x1.Workbooks.Open(@"C:\Users\Rohini\source\repos\PeakApps\Features\Audit.xlsx");
            Excel._Worksheet s1 = w1.Sheets[2];
            r1 = s1.UsedRange;
        }
        public static void DataEntryExcel()
        {
            Excel.Application x1 = new Excel.Application();
            w1 = x1.Workbooks.Open(@"C:\Users\Rohini\source\repos\PeakApps\Features\Audit.xlsx");
            Excel._Worksheet s1 = w1.Sheets[8];
            r1 = s1.UsedRange;
        }
        public static void excelClose()
        {

            w1.Close(0);
        }
        public static void excelQuit()
        {

            w1.Application.Quit();
        }
        public static string getdata(int row)
        {
            var value = r1.Cells[2][row].Value;
            string final = value.ToString();
            return final;
        }
        public static string Facilityprotocoldata(int row)
        {
            var value = r1.Cells[4][row].Value;
            string final = value.ToString();
            return final;
        }
        public static string SubQsDetail3(int row)
        {
            var value = r1.Cells[4][row].Value;
            string final = value.ToString();
            return final;
        }

        public static string getdoubledata(int row)
        {
            var value = r1.Cells[4][row].Value;

            string final = value.ToString();
            return final;
        }
        public static string get_multidata4(int row)
        {
            var value = r1.Cells[4][row].Value;
            string final = value.ToString();
            return final;
        }
        public static string get_multidata5(int row)
        {
            var value = r1.Cells[8][row].Value;
            string final = value.ToString();
            return final;
        }

        public static string get_multidata6(int row)
        {
            var value = r1.Cells[12][row].Value;
            string final = value.ToString();
            return final;
        }
        public static string get_multidata11(int row)
        {
            var value = r1.Cells[16][row].Value;
            string final = value.ToString();
            return final;
        }

        public static string get_multidata7(int row)
        {
            var value = r1.Cells[4][row].Value;
            string final = value.ToString();
            return final;
        }
        public static string get_multidata8(int row)
        {
            var value = r1.Cells[8][row].Value;
            string final = value.ToString();
            return final;
        }
        public static string get_multidata9(int row)
        {
            var value = r1.Cells[4][row].Value;
            string final = value.ToString();
            return final;
        }
        public static string get_multidata10(int row)
        {
            var value = r1.Cells[8][row].Value;
            string final = value.ToString();
            return final;
        }
        public static void DataEntry3DPolicy()
        {
            List<string> policyQs = DataModal.policy.PolicyQuestions;
            if (DataModal.dataentryQs.Count > 0)
            {
                DataModal.dataentryQs.Clear();
            }
            int policyQsCount = policyQs.Count;
                //string QuestionAppearingonDataEntry = "";
            for(int k = 2; k <= 15; k++) { 
            var value = r1.Cells[2][k].Value;
                Thread.Sleep(2000);
            string AuditSetupQuestionDisplayed = value;
            //string str = AuditSetupQuestionDisplayed;
            List<string> result = Regex.Split(AuditSetupQuestionDisplayed, "\n\\s*").ToList();
                var compareList = policyQs.Except(result).ToList();

                //for (int i = 0; i < result.Count; i++) {

                //for (int j = 1; j < policyQsCount; j++)
                //{
                
                        if (compareList.Count == 0)
                    {
                        int count = 3;
                        var dataEntryQs = r1.Cells[count][k].Value;
                        string dataEntryQsValue = dataEntryQs;
                        List<string> QuestionAppearingonDataEntry = Regex.Split(dataEntryQsValue, "\n\\s*").ToList();
                         for(int l=0;l< QuestionAppearingonDataEntry.Count; l++) { 
                            
                            // QuestionAppearingonDataEntry = dataEntryQs.ToString();
                            
                            if (!DataModal.dataentryQs.Contains(QuestionAppearingonDataEntry[l]))
                               DataModal.dataentryQs.Add(QuestionAppearingonDataEntry[l]);
                            }
                            var dataEntryAns = r1.Cells[count + 1][k].Value;
                            DataModal.dataentryAns=dataEntryAns;
                       
                    }
                //}
            //}
                
            }
            
           // return QuestionAppearingonDataEntry;

        }

    }
}
