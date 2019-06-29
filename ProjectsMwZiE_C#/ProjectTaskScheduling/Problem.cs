using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace ProjectTaskScheduling
{
    internal class Problem
    {
        private static readonly Excel.Application XlApp = new Excel.Application();
        private static readonly Excel.Workbook XlWorkbook = XlApp.Workbooks.Open(
            "C:\\Users\\kasia\\Documents\\Studia\\Semestr 8\\MwZiE\\Zadania\\" +
            "Metaheuristics_in_Management_and_Economy\\ProjectsMwZiE_C#\\" +
            "ProjectTaskScheduling\\bin\\Debug\\TaskScheduling.xlsx");
        private static readonly Excel._Worksheet XlWorksheet = XlWorkbook.Sheets[1];
        private static readonly Excel.Range XlRange = XlWorksheet.UsedRange;

        public static List<Base> ReadExcel()
        {
            var result = new List<Base>();

            for (var i = 1; i <= 80; i++)
            {
                var c1 = XlRange.Cells[i, 1].Value2.ToString();
                var c2 = XlRange.Cells[i, 2].Value2.ToString();
                var c3 = XlRange.Cells[i, 3].Value2.ToString();
                
                var content = new Base(int.Parse(c1), int.Parse(c2), int.Parse(c3));
                result.Add(content);
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Marshal.ReleaseComObject(XlRange);
            Marshal.ReleaseComObject(XlWorksheet);

            XlWorkbook.Close();
            Marshal.ReleaseComObject(XlWorkbook);

            XlApp.Quit();
            Marshal.ReleaseComObject(XlApp);

            return result;
        }
    }
}
