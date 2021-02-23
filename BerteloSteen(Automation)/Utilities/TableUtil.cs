using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DARS.Automation_.Utilities
{
    class TableUtil
    {
        static List<TableDatacollection> _tableDatacollections = new List<TableDatacollection>();

        public static void ReadTable(IWebElement table)
        {
            //Get all the columns from the Table
            var columns = table.FindElements(By.TagName("th"));

            //Get all the rows
            var rows = table.FindElements(By.TagName("tr"));

            //Create Row Index
            var rowIndex = 0;

            foreach(var row in rows)
            {
                int colIndex = 0;

                var colDatas = row.FindElements(By.TagName("td"));

                foreach (var colValue in colDatas)
                {
                    _tableDatacollections.Add(new TableDatacollection
                    {
                        RowNumber = rowIndex,
                        ColumnName = columns[colIndex].Text != "" ?
                        columns[colIndex].Text : colIndex.ToString(),
                        ColumnValue = colValue.Text,
                        ColumnSpecialValue = colValue.Text != "" ? null :
                        colValue.FindElements(By.TagName("a"))
                    });;

                    //Move to Next Column
                    colIndex++;
                }
                rowIndex++;
            }

        }

        public static string ReadCell(string columnName , int rowNumber)
        {
            var data = (from e in _tableDatacollections
                        where e.ColumnName == columnName && e.RowNumber == rowNumber
                        select e.ColumnValue).SingleOrDefault();
            return data;
        }

        public static void PerformActiononCell(string columnIndex , string refColumnName , string refColumnValue , string ControltoOperate = null)
        {
            foreach(int rowNumber in GetDynamicRowNumber(refColumnName , refColumnValue))
            {
                var cell = (from e in _tableDatacollections
                            where e.ColumnName == columnIndex && e.RowNumber == rowNumber
                            select e.ColumnSpecialValue).SingleOrDefault();

                //Need to operate on the control
                if (ControltoOperate != null && cell != null)
                {
                    var returnedControl = (from c in cell
                                           where c.GetAttribute("title") == ControltoOperate
                                           select c).SingleOrDefault();

                    returnedControl?.Click();
                }
                else
                {
                    cell?.First().Click();
                }
            }

        }


        private static IEnumerable GetDynamicRowNumber(string columnName , string columnValue)
        {
            //take out a dynamic row number here...
            foreach(var table in _tableDatacollections)
            {
                if (table.ColumnName == columnName && table.ColumnValue == columnValue)
                    yield return table.RowNumber;
            }
        }


        
    }



    public class TableDatacollection
    {
        public int RowNumber { get; set; }
        public string ColumnName { get; set; }
        public string ColumnValue { get; set; }
        public IEnumerable<IWebElement> ColumnSpecialValue { get; set; }
    }
}
