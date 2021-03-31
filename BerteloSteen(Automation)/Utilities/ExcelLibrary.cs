using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using xl = Microsoft.Office.Interop.Excel;

namespace DARS.Automation_.Utilities
{
    class ExcelLibrary
    {
        xl.Application xlApp = null;
        xl.Workbooks workbooks = null;
        xl.Workbook workbook = null;
        Hashtable sheets;
        public string xlFilePath;

        public ExcelLibrary(string xlFilePath)
        {
            this.xlFilePath = xlFilePath;
        }

        public void OpenExcel()
        {
            xlApp = new xl.Application();
            workbooks = xlApp.Workbooks;
            workbook = workbooks.Open(xlFilePath);
            sheets = new Hashtable();
            int count = 1;
            //Storing worksheet naems in the Hastable
            foreach (xl.Worksheet sheet in workbook.Sheets)
            {
                sheets[count] = sheet.Name;
                count++;
            }
        }

        public void CloseExcel()
        {
            workbook.Close(false, xlFilePath, null);// Here it will close the connection with the workbook.
            Marshal.FinalReleaseComObject(workbook);// Here it will release all unmanaged Object Reference.
            workbook = null;

            workbooks.Close();
            Marshal.FinalReleaseComObject(workbooks);
            workbooks = null;

            xlApp.Quit();
            Marshal.FinalReleaseComObject(xlApp);
            xlApp = null;

        }

        public int GetRowCount(string SheetName)
        {
            OpenExcel();
            int rowCount = 0;
            int sheetValue = 0;

            if (sheets.ContainsValue(SheetName))
            {
                foreach (DictionaryEntry sheet in sheets)
                {
                    if (sheet.Value.Equals(SheetName))
                    {
                        sheetValue = (int)sheet.Key;
                    }
                }
                //Getting Particular worksheet using index/key from workbook
                xl.Worksheet worksheet = workbook.Worksheets[sheetValue] as xl.Worksheet;
                xl.Range range = worksheet.UsedRange; // Range of cell which is having a content.
                rowCount = range.Rows.Count;
            }
            CloseExcel();
            return rowCount;
        }

        public int GetColumnCount(string SheetName)
        {
            OpenExcel();
            int columnCount = 0;
            int sheetValue = 0;

            if (sheets.ContainsValue(SheetName))
            {
                foreach(DictionaryEntry sheet in sheets)
                {
                    if (sheet.Value.Equals(SheetName))
                    {
                        sheetValue = (int)sheet.Key;
                    }
                }
                xl.Worksheet worksheet = workbook.Worksheets[sheetValue] as xl.Worksheet;
                xl.Range range = worksheet.UsedRange; // Range of cell which is having a content.
                columnCount = range.Columns.Count;
            }
            CloseExcel();
            return columnCount;
        }



    }
    
}
