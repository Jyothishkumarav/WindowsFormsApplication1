using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Model;
using Excel = Microsoft.Office.Interop.Excel;

namespace WindowsFormsApplication1.Utitity
{
    public static class IExcelReader
    {
        static Excel.Application xlApp;
        static Excel.Workbook xlWorkBook;
        static Excel.Worksheet xlWorkSheet;

        private static void InitializeComponents(string filePath)
        {
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(filePath);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

        }

        public static List<UserLogin> ReadExcelData(string fileName)
        {
            IList<UserLogin> loginData = new List<UserLogin>();
            InitializeComponents(fileName);
            int rows = xlWorkSheet.UsedRange.Rows.Count;
            Excel.Range xlRng;
            try {
                for (int i = 2; i <= rows; i++)
                {
                    xlRng = xlWorkSheet.UsedRange[1][i];
                    string userName = (string)xlRng.Value2.ToString();
                    xlRng = xlWorkSheet.UsedRange[2][i];
                    string password = (string)xlRng.Value2.ToString();
                    loginData.Add(new UserLogin(userName,password));

                }
            }
            catch (Exception ex)
            {
                Release();
            }
            
            Release();

            return loginData.ToList();
        } 

        public static void WriteToExcel(string filePath, IList<EfillingDetails> fillingStatus)
        {
            InitializeComponents(filePath);
            xlWorkSheet.UsedRange.ClearContents();
            int rowCount = 2;
            foreach (EfillingDetails status in fillingStatus)
            {
                xlWorkSheet.Cells[1][rowCount].value = status.user.userName;
                xlWorkSheet.Cells[2][rowCount].value = status.loginInfo;
                xlWorkSheet.Cells[3][rowCount].value = status.efillingStatus;
                xlWorkSheet.Cells[4][rowCount].value = status.initiatedList;
                rowCount++;
            }


            xlWorkBook.Save();
            Release();
        }
        
        private static void Release()
        {
            // xlWorkBook.Save();
            //xlWorkSheet.
            try
            {
                xlWorkBook.Close(true);
                xlApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
            }
            catch (Exception e)
            {

            }
        }      

    }
}
