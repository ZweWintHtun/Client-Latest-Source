using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Win_DataTable = System.Data.DataTable;
using Range_Excel = Microsoft.Office.Interop.Excel.Range;
//using Ace.Cbs.Cx.Com.Utt;
using Application = System.Windows.Forms.Application;
using System.Globalization;
using Ace.Cbs.Gl.Dmd;
using Ace.Windows.Core;


namespace Ace.Cbs.Mnm._Excel
{
    public class CashControlReport_Excel
    {
        String[] alphaStr = { "A", "B", "C", "D", "E",
                              "F", "G", "H", "I", "J",
                              "K", "L", "M", "N", "O",
                              "P", "Q", "R", "S", "T",
                              "U", "V", "W", "X", "Y",
                              "Z" };
        Excel.Application myexcelapp;
        Excel.Workbook myworkbook;
        Excel.Worksheet myworksheet;
        public DataGridView _dgvCashControlReport = null;
        object misValue = System.Reflection.Missing.Value;  //Miss Value Declaration
        string CounterNo = string.Empty;
        Excel.Worksheet myworksheet2;

        public CashControlReport_Excel()
        {

        }

        private string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }

        public void ExportToExcel_LoanRecord(string ReportTitle,string BranchName, string BranchAddress, string BranchPhoneNo, string BranchFaxNo, string exportFileName, DateTime ReportDateTime, DataGridView dgv)
        {
            try
            {
                object misValue = System.Reflection.Missing.Value;

                string FileName = Path.GetTempPath() + ReportTitle + ".xlsx";
                FileInfo fileinfo = new FileInfo(@FileName);
                if (fileinfo.Exists)
                {
                    fileinfo.Attributes = FileAttributes.Normal;
                    fileinfo.Delete();
                }
                myexcelapp = new Excel.Application();
                myworkbook = myexcelapp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                myworksheet = (Excel.Worksheet)myworkbook.ActiveSheet;
                myworksheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                myworksheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperLegal;
                myworksheet.PageSetup.Zoom = false;
                myworksheet.PageSetup.FitToPagesWide = 1;
                myworksheet.PageSetup.LeftMargin = 0.3;
                myworksheet.PageSetup.RightMargin = 0.3;
                myworkbook.Windows.get_Item(1).DisplayGridlines = false;
                myworksheet.Name = "Sheet1";

                #region Header

                myworksheet.Cells.NumberFormat = "@";
                Range rng01;
                rng01 = myworksheet.get_Range("D:D");
                rng01.NumberFormat = "dd-MM-yyyy";
                rng01 = myworksheet.get_Range("E:E");
                rng01.NumberFormat = "#,##0.00";
                rng01 = myworksheet.get_Range("F:F");
                rng01.NumberFormat = "dd-MM-yyyy";
                string dateFormat = GetExcelColumnName(dgv.ColumnCount - 1) + ":" + GetExcelColumnName(dgv.ColumnCount - 1);
                rng01 = myworksheet.get_Range(dateFormat);
                rng01.NumberFormat = "dd-MM-yyyy";
                rng01 = myworksheet.get_Range(GetExcelColumnName(dgv.ColumnCount + 1) + ":" + GetExcelColumnName(dgv.ColumnCount + 1)); //For Refund Total Amount
                rng01.NumberFormat = "#,##0.00";
                rng01 = myworksheet.get_Range(GetExcelColumnName(dgv.ColumnCount + 1 - 3) + ":" + GetExcelColumnName(dgv.ColumnCount + 1 - 3)); //For Refund Total Amount
                rng01.NumberFormat = "#,##0.00";
                Range range0001 = myworksheet.get_Range("A10");
                range0001.Select();

                dgv.SelectAll();
                DataObject d = dgv.GetClipboardContent();
                Clipboard.SetDataObject(d);

                range0001.PasteSpecial(XlPasteType.xlPasteAll);
                Range range0002 = myworksheet.get_Range("A:A");
                range0002.Delete(misValue);

                Image img = null;
                string tempFilePath = System.Windows.Forms.Application.StartupPath + "\\banklogo.jpg";
                myworksheet.Shapes.AddPicture(tempFilePath, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 420, 6, 50, 45);
                myworksheet.Cells[1, 10] = BranchName;
                myworksheet.Cells[2, 10] = BranchAddress;
                myworksheet.Cells[3, 10] = BranchPhoneNo;
                myworksheet.Cells[4, 10] = BranchFaxNo;
                myworksheet.Cells[5, 10] = "";
                myworksheet.Cells[6, 10] = ReportTitle;
                myworksheet.Cells[8, 10] = "";

                Range lastFor = myworksheet.get_Range("A:ZZ").Find(dgv.Columns[dgv.Columns.Count - 1].Name, Type.Missing,
                      Excel.XlFindLookIn.xlFormulas, Excel.XlLookAt.xlPart, Excel.XlSearchOrder.xlByRows,
                      Excel.XlSearchDirection.xlNext, false, false, false);

                string[] LastColumn = lastFor.Address.Split(new String[] { "$", "", string.Empty, null }, StringSplitOptions.None);

                Range last = myworksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);


                int lastUsedRow = last.Row -1;
                int lastUsedColumn = last.Column;

                rng01 = myworksheet.get_Range("J1:" + LastColumn[1] + 1);
                rng01.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng01.MergeCells = true;
                rng01.Font.Bold = true;

                rng01 = myworksheet.get_Range("J2:" + LastColumn[1] + 2);
                rng01.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng01.MergeCells = true;
                rng01.Font.Bold = true;

                rng01 = myworksheet.get_Range("J3:" + LastColumn[1] + 3);
                rng01.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng01.MergeCells = true;
                rng01.Font.Bold = true;

                rng01 = myworksheet.get_Range("J4:" + LastColumn[1] + 4);
                rng01.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng01.MergeCells = true;
                rng01.Font.Bold = true;

                rng01 = myworksheet.get_Range("J6:" + LastColumn[1] + 6);
                rng01.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng01.MergeCells = true;
                rng01.Font.Bold = true;

                #endregion Header

                #region Columns Header

                rng01 = myworksheet.get_Range("A10:A12");
                rng01.EntireColumn.AutoFit();
                rng01.Cells.MergeCells = true;
                rng01.Cells.Orientation = 90;

                rng01 = myworksheet.get_Range("B10:B12");
                rng01.EntireColumn.AutoFit();
                rng01.Cells.MergeCells = true;

                rng01 = myworksheet.get_Range("C10:D10");
                rng01.Cells.MergeCells = true;
                rng01.Value = "Advance";

                rng01 = myworksheet.get_Range("C11:C12");
                rng01.EntireColumn.AutoFit();
                rng01.Cells.MergeCells = true;

                rng01 = myworksheet.get_Range("D11:D12");
                rng01.EntireColumn.AutoFit();
                rng01.Cells.MergeCells = true;

                rng01 = myworksheet.get_Range("E11:E12");
                rng01.EntireColumn.AutoFit();
                rng01.Cells.MergeCells = true;

                rng01 = myworksheet.Range[myworksheet.Cells[13, 5], myworksheet.Cells[10, dgv.ColumnCount - 3]];
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;

                rng01 = myworksheet.Range[myworksheet.Cells[10, 5], myworksheet.Cells[10, dgv.ColumnCount - 3]];
                rng01.Cells.MergeCells = true;
                rng01.Value = "Actual Disbursement";

                rng01 = myworksheet.Range[myworksheet.Cells[10, dgv.ColumnCount - 2], myworksheet.Cells[10, dgv.ColumnCount]];
                rng01.Cells.MergeCells = true;
                rng01.Value = "Refund";

                rng01 = myworksheet.Range[myworksheet.Cells[11, 6], myworksheet.Cells[11, dgv.ColumnCount - 4]];
                rng01.Cells.MergeCells = true;
                rng01.Value = "Acre/Unit";

                rng01 = myworksheet.Range[myworksheet.Cells[11, dgv.ColumnCount - 3], myworksheet.Cells[12, dgv.ColumnCount - 3]];
                rng01.Cells.MergeCells = true;

                rng01 = myworksheet.Range[myworksheet.Cells[11, dgv.ColumnCount - 2], myworksheet.Cells[12, dgv.ColumnCount - 2]];
                rng01.Cells.MergeCells = true;

                rng01 = myworksheet.Range[myworksheet.Cells[11, dgv.ColumnCount - 1], myworksheet.Cells[12, dgv.ColumnCount - 1]];
                rng01.Cells.MergeCells = true;

                rng01 = myworksheet.Range[myworksheet.Cells[11, dgv.ColumnCount], myworksheet.Cells[12, dgv.ColumnCount]];
                rng01.Cells.MergeCells = true;
                #endregion Columns Header

                #region Row Data



                #endregion Row Data

                rng01 = myworksheet.get_Range("A10:" + GetExcelColumnName(dgv.ColumnCount) + 12);
                rng01.Font.Bold = true;

                rng01 = myworksheet.get_Range("A10:" + GetExcelColumnName(dgv.ColumnCount) + lastUsedRow);
                rng01.EntireColumn.AutoFit();

                rng01 = myworksheet.get_Range("A10:" + GetExcelColumnName(dgv.ColumnCount) + lastUsedRow);
                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng01 = myworksheet.get_Range("D13:D" + lastUsedRow);
                rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet.get_Range("A10:" + GetExcelColumnName(dgv.ColumnCount) + 12); //For Header To Text Align Center 
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet.get_Range("F13:" + GetExcelColumnName(dgv.ColumnCount - 3) + lastUsedRow);
                //FormatCondition cond = rng01.FormatConditions.Add(XlFormatConditionType.xlCellValue, XlFormatConditionOperator.xlEqual, string.Empty);
                //cond.Text = "0.00";

                rng01 = myworksheet.get_Range("F13:" + GetExcelColumnName(dgv.ColumnCount - 3) + lastUsedRow); //For BusinessTypeUM (Values) To Text Align Right
                rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet.get_Range(GetExcelColumnName(dgv.ColumnCount - 2) + "13:" + GetExcelColumnName(dgv.ColumnCount - 1) + lastUsedRow); //For Refund Date And Payslip No
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet.get_Range(GetExcelColumnName(dgv.ColumnCount) + "13:" + GetExcelColumnName(dgv.ColumnCount) + lastUsedRow); //For Refund Total Amount
                rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet.get_Range("A13:C" + lastUsedRow); //For Serial, Village, Advance Date (Values) To Text Align Right
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;


                myworksheet.Cells.Locked = true;
                myexcelapp.StandardFont = "Times New Roman";
                myexcelapp.StandardFontSize = 12;
                myworksheet.Protect(Type.Missing, true, true, true, true, true, true, true, true, false, false, false, false, true, true, true);


                //Save Excel File To Location
                myworkbook.SaveAs(FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, true, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, true);
                //Close Work Book
                myworkbook.Close(true, misValue, misValue);
                //Quit That Excel Apps
                myexcelapp.Quit();


                //Release That Excel
                releaseObject(myworksheet);
                releaseObject(myworkbook);
                releaseObject(myexcelapp);

                FileInfo FInfo = new FileInfo(FileName);
                FInfo.Attributes = FileAttributes.ReadOnly;

                Process.Start(FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoanRecordReport_ExcelGrid(string BranchName, string BranchAddress, string BranchPhoneNo, string BranchFaxNo, string ReportTitle, DateTime ReportDateTime, DataGridView dgv)
        {
            try
            {
                object misValue = System.Reflection.Missing.Value;
               
                string FileName = Path.GetTempPath() + ReportTitle + ".xlsx";
                FileInfo fileinfo = new FileInfo(@FileName);
                if (fileinfo.Exists)
                {
                    fileinfo.Attributes = FileAttributes.Normal;
                    fileinfo.Delete();
                }
                myexcelapp = new Excel.Application();
                myworkbook = myexcelapp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                myworksheet = (Excel.Worksheet)myworkbook.ActiveSheet;
                myworksheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                myworksheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperLegal;
                myworksheet.PageSetup.Zoom = false;
                myworksheet.PageSetup.FitToPagesWide = 1;
                myworksheet.PageSetup.LeftMargin = 0.3;
                myworksheet.PageSetup.RightMargin = 0.3;
                myworkbook.Windows.get_Item(1).DisplayGridlines = false;
                myworksheet.Name = "Sheet1";

                #region Header

                myworksheet.Cells.NumberFormat = "@";

                Range range0001 = myworksheet.get_Range("A10");
                range0001.Select();

                dgv.SelectAll();
                DataObject d = dgv.GetClipboardContent();
                Clipboard.SetDataObject(d);

                range0001.PasteSpecial(XlPasteType.xlPasteAll);
                Range range0002 = myworksheet.get_Range("A:A");
                range0002.Delete(misValue);

                Image img = null;
                string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                myworksheet.Shapes.AddPicture(tempFilePath, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 420, 6, 50, 45);
                myworksheet.Cells[1, 10] = BranchName;
                myworksheet.Cells[2, 10] = BranchAddress;
                myworksheet.Cells[3, 10] = BranchPhoneNo;
                myworksheet.Cells[4, 10] = BranchFaxNo;
                myworksheet.Cells[5, 10] = "";
                myworksheet.Cells[6, 10] = ReportTitle;
                myworksheet.Cells[8, 10] = "";

                Range lastFor = myworksheet.get_Range("A:ZZ").Find(dgv.Columns[dgv.Columns.Count - 1].Name, Type.Missing,
                      Excel.XlFindLookIn.xlFormulas, Excel.XlLookAt.xlPart, Excel.XlSearchOrder.xlByRows,
                      Excel.XlSearchDirection.xlNext, false, false, false);

                string[] LastColumn = lastFor.Address.Split(new String[] { "$", "", string.Empty, null }, StringSplitOptions.None);

                Range last = myworksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);



                int lastUsedRow = last.Row - 1;
                int lastUsedColumn = last.Column;

                Range rng16 = myworksheet.get_Range("J1:" + LastColumn[1] + 1);
                rng16.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rng16.Cells.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng16.MergeCells = true;
                rng16.Font.Bold = true;

                Range rng17 = myworksheet.get_Range("J2:" + LastColumn[1] + 2);
                rng17.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rng17.Cells.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng17.MergeCells = true;
                rng17.Font.Bold = true;

                Range rng18 = myworksheet.get_Range("J3:" + LastColumn[1] + 3);
                rng18.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rng18.Cells.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng18.MergeCells = true;
                rng18.Font.Bold = true;

                Range rng19 = myworksheet.get_Range("J4:" + LastColumn[1] + 4);
                rng19.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rng19.Cells.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng19.MergeCells = true;
                rng19.Font.Bold = true;

                Range rng20 = myworksheet.get_Range("J6:" + LastColumn[1] + 6);
                rng20.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rng20.Cells.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng20.MergeCells = true;
                rng20.Font.Bold = true;

                #endregion Header

                #region Columns Header

                Range rng01 = myworksheet.get_Range("A10:A12");
                rng01.EntireColumn.AutoFit();
                rng01.Cells.MergeCells = true;
                rng01.Cells.Orientation = 90;

                rng01 = myworksheet.get_Range("B10:B12");
                rng01.EntireColumn.AutoFit();
                rng01.Cells.MergeCells = true;

                rng01 = myworksheet.get_Range("C10:D10");
                rng01.Cells.MergeCells = true;
                rng01.Value = "Advance";

                rng01 = myworksheet.get_Range("C11:C12");
                rng01.EntireColumn.AutoFit();
                rng01.Cells.MergeCells = true;

                rng01 = myworksheet.get_Range("D11:D12");
                rng01.EntireColumn.AutoFit();
                rng01.Cells.MergeCells = true;

                rng01 = myworksheet.get_Range("E11:E12");
                rng01.EntireColumn.AutoFit();
                rng01.Cells.MergeCells = true;


                rng01 = myworksheet.Range[myworksheet.Cells[13, 5], myworksheet.Cells[10, dgv.ColumnCount - 3]];
                rng01.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter;

                rng01 = myworksheet.Range[myworksheet.Cells[10, 5], myworksheet.Cells[10, dgv.ColumnCount - 3]];
                rng01.Cells.MergeCells = true;
                rng01.Value = "Actual Disbursement";

                rng01 = myworksheet.Range[myworksheet.Cells[10, dgv.ColumnCount - 2], myworksheet.Cells[10, dgv.ColumnCount]];
                rng01.Cells.MergeCells = true;
                rng01.Value = "Refund";

                rng01 = myworksheet.Range[myworksheet.Cells[11, 6], myworksheet.Cells[11, dgv.ColumnCount - 4]];
                rng01.Cells.MergeCells = true;
                rng01.Value = "Acre/Unit";

                rng01 = myworksheet.Range[myworksheet.Cells[11, dgv.ColumnCount - 3], myworksheet.Cells[12, dgv.ColumnCount - 3]];
                rng01.Cells.MergeCells = true;

                rng01 = myworksheet.Range[myworksheet.Cells[11, dgv.ColumnCount - 2], myworksheet.Cells[12, dgv.ColumnCount - 2]];
                rng01.Cells.MergeCells = true;

                rng01 = myworksheet.Range[myworksheet.Cells[11, dgv.ColumnCount - 1], myworksheet.Cells[12, dgv.ColumnCount - 1]];
                rng01.Cells.MergeCells = true;

                rng01 = myworksheet.Range[myworksheet.Cells[11, dgv.ColumnCount], myworksheet.Cells[12, dgv.ColumnCount]];
                rng01.Cells.MergeCells = true;

                #endregion Columns Header

                #region Row Data
                


                #endregion Row Data


                

                rng01 = myworksheet.get_Range("A:B");
                //rng01.EntireRow.Style = "Comma";
                rng01.NumberFormat = "#,##0.00";
                rng01 = myworksheet.get_Range("C:C");
                rng01.NumberFormat = "dd-MM-yyyy";
                rng01 = myworksheet.get_Range("D:D");
                rng01.NumberFormat = "#,##0.00";
                rng01 = myworksheet.Range[myworksheet.Cells[Type.Missing, 6], myworksheet.Cells[Type.Missing, dgv.ColumnCount - 3]];
                rng01.NumberFormat = "#,##0.00";
                rng01 = myworksheet.get_Range(LastColumn[1] + ":" + LastColumn[1]);
                rng01.NumberFormat = "#,##0.00";

                rng01 = myworksheet.get_Range("A10:" + LastColumn[1] + 12);
                rng01.Font.Bold = true;

                rng01 = myworksheet.get_Range("A10:" + LastColumn[1] + lastUsedRow);
                rng01.EntireColumn.AutoFit();

                rng01 = myworksheet.get_Range("A10:" + LastColumn[1] + lastUsedRow);
                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();


                //for (int i = 6; i < dgv.Rows.Count - 5; i++)
                //{
                //    myworksheet.Range[myworksheet.Cells[13, dgv.Rows.Count - 4], myworksheet.Cells[13, dgv.ColumnCount - 4]].Formula = "";
                //}

                myworksheet.Range[myworksheet.Cells[10, 1], myworksheet.Cells[lastUsedRow, dgv.ColumnCount]].Cells.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;
                //myworksheet.Range[myworksheet.Cells[10, 1], myworksheet.Cells[lastUsedRow, dgv.ColumnCount]].Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter;

                rng01 = myworksheet.Range[myworksheet.Cells[10, 1], myworksheet.Cells[12, dgv.ColumnCount]];
                rng01.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter;

                //TextCenter(myworksheet.Range[myworksheet.Cells[10, 1], myworksheet.Cells[lastUsedRow, dgv.ColumnCount]]);

                rng01 = myworksheet.Range[myworksheet.Cells[Type.Missing, 6], myworksheet.Cells[Type.Missing, dgv.ColumnCount - 3]];
                rng01.NumberFormat = "#,##0.00";

                myworksheet.Cells.Locked = true;
                myexcelapp.StandardFont = "Times New Roman";
                myexcelapp.StandardFontSize = 12;
                myworksheet.Protect(Type.Missing, true, true, true, true, true, true, true, true, false, false, false, false, true, true, true);


                //Save Excel File To Location
                myworkbook.SaveAs(FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, true, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, true);
                //Close Work Book
                myworkbook.Close(true, misValue, misValue);
                //Quit That Excel Apps
                myexcelapp.Quit();


                //Release That Excel
                releaseObject(myworksheet);
                releaseObject(myworkbook);
                releaseObject(myexcelapp);

                FileInfo FInfo = new FileInfo(FileName);
                FInfo.Attributes = FileAttributes.ReadOnly;

                Process.Start(FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void CashControlReport_ExcelGrid(bool isVault, bool isRCounter, bool isCounter, string BranchName, string BranchAddress, string BranchPhoneNo, string BranchFaxNo, string ReportTitle, DateTime ReportDateTime, DataGridView dgv) //, List<string> ColumnListString, List<string[]> VaultListString, List<string[]> FooterValueListString
        {
            try
            {
                object misValue = System.Reflection.Missing.Value;
                //if (ColumnListString.Count <= 0)
                //{
                //    throw new Exception("Invalid Parameter");
                //}
                //if (FooterValueListString.Count <= 0)
                //{
                //    throw new Exception("Invalid Parameter");
                //}
                string FileName = Path.GetTempPath() + "Cash Control Report.xlsx";
                //Excel.Range range;                      //Excel Range File
                FileInfo fileinfo = new FileInfo(@FileName);
                if (fileinfo.Exists)
                {
                    fileinfo.Attributes = FileAttributes.Normal;
                    fileinfo.Delete();
                }
                myexcelapp = new Excel.Application();
                myworkbook = myexcelapp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                myworksheet = (Excel.Worksheet)myworkbook.ActiveSheet;
                myworksheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                myworksheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperLegal;
                myworksheet.PageSetup.Zoom = false;
                myworksheet.PageSetup.FitToPagesWide = 1;
                myworksheet.PageSetup.LeftMargin = 0.3;
                myworksheet.PageSetup.RightMargin = 0.3;
                myworkbook.Windows.get_Item(1).DisplayGridlines = false;
                myworksheet.Name = "Sheet1";

                #region Header



                Range range0001 = myworksheet.get_Range("A10");
                range0001.Select();

                dgv.SelectAll();
                DataObject d = dgv.GetClipboardContent();
                Clipboard.SetDataObject(d);

                range0001.PasteSpecial(XlPasteType.xlPasteAll);
                Range range0002 = myworksheet.get_Range("A:A");
                range0002.Delete(misValue);

                Image img = null;
                string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                //{
                //    img = System.Drawing.Image.FromStream(stream);
                //    img.Save(tempFilePath);
                //}
                // For Bank Logo --> Cash Control Report                                                                                      //left,top,width,height
                myworksheet.Shapes.AddPicture(tempFilePath, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 420, 6, 50, 45);
                myworksheet.Cells[1, 10] = BranchName;
                myworksheet.Cells[2, 10] = BranchAddress;
                myworksheet.Cells[3, 10] = BranchPhoneNo;
                myworksheet.Cells[4, 10] = BranchFaxNo;
                myworksheet.Cells[5, 10] = "";
                myworksheet.Cells[6, 10] = ReportTitle;
                myworksheet.Cells[8, 10] = "";

                #endregion Header

                #region Columns Header

                #endregion Columns Header

                #region Row Data
                int SerialNo = 0;
                Range lastFor = myworksheet.get_Range("A:ZZ").Find(dgv.Columns[dgv.Columns.Count - 1].Name, Type.Missing,
                       Excel.XlFindLookIn.xlFormulas, Excel.XlLookAt.xlPart, Excel.XlSearchOrder.xlByRows,
                       Excel.XlSearchDirection.xlNext, false, false, false);
                string[] LastColumn = lastFor.Address.Split(new String[] { "$", "", string.Empty, null }, StringSplitOptions.None);

                Range last = myworksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);

                int lastUsedRow = last.Row - 1;
                int lastUsedColumn = last.Column;


                Range range0003 = myworksheet.get_Range("A9:" + LastColumn[1] + lastUsedRow);
                range0003.Borders.Color = System.Drawing.Color.Black.ToArgb();

                string str_rng15 = "E11:" + LastColumn[1] + lastUsedColumn;
                Range rngForAmount = myworksheet.get_Range(str_rng15);
                rngForAmount.NumberFormat = "#,##0";


                rngForAmount.Style.HorizontalAlignment = XlHAlign.xlHAlignRight;

                Range rng16 = myworksheet.get_Range("J1:" + LastColumn[1] + 1);
                rng16.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rng16.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng16.MergeCells = true;
                rng16.Font.Bold = true;

                Range rng17 = myworksheet.get_Range("J2:" + LastColumn[1] + 2);
                rng17.MergeCells = true;
                rng17.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rng17.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng17.Font.Bold = true;

                Range rng18 = myworksheet.get_Range("J3:" + LastColumn[1] + 3);
                rng18.MergeCells = true;
                rng18.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rng18.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng18.Font.Bold = true;

                Range rng19 = myworksheet.get_Range("J4:" + LastColumn[1] + 4);
                rng19.MergeCells = true;
                rng19.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rng19.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng19.Font.Bold = true;

                Range rng20 = myworksheet.get_Range("J6:" + LastColumn[1] + 6);
                rng20.MergeCells = true;
                rng20.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rng20.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng20.Font.Bold = true;

                //Range rng01 = myworksheet.get_Range("A9:" + LastColumn[1] + 10);
                //rng01.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter;

                Range rng02 = myworksheet.get_Range("A9:A10");
                rng02.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng02.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng02.MergeCells = true;

                Range rng03 = myworksheet.get_Range("B9:B10");
                rng03.MergeCells = true;
                //rng03.ColumnWidth = 13.50;
                rng03.Columns.AutoFit();
                rng03.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng03.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;

                Range rng04 = myworksheet.get_Range("C9:C10");
                rng04.MergeCells = true;
                //rng04.ColumnWidth = 17.25;
                rng04.Columns.AutoFit();
                rng04.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng04.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;

                Range range0003_1 = myworksheet.get_Range("D9:D10");
                range0003_1.MergeCells = true;
                //range0003_1.ColumnWidth = 12.50;
                range0003_1.Columns.AutoFit();

                Range rng9 = myworksheet.get_Range("E:" + LastColumn[1]);
                //rng9.ColumnWidth = 11;
                rng9.Columns.AutoFit();

                string columnName;
                columnName = "A" + LastColumn[2];
                Range rng10 = myworksheet.get_Range(columnName);
                rng10.MergeCells = true;
                //rng10.ColumnWidth = 15.38;
                rng10.Columns.AutoFit();
                columnName = "A" + (Convert.ToInt32(LastColumn[2]) - 1);
                Range rng11 = myworksheet.get_Range(columnName);
                rng11.MergeCells = true;
                //rng11.ColumnWidth = 13.88;
                rng11.Columns.AutoFit();
                columnName = "A" + (Convert.ToInt32(LastColumn[2]) - 2);
                Range rng12 = myworksheet.get_Range(columnName);
                rng12.MergeCells = true;
                //rng12.ColumnWidth = 5;
                rng12.Columns.AutoFit();
                columnName = "A" + (Convert.ToInt32(LastColumn[2]) - 3);
                Range rng13 = myworksheet.get_Range(columnName);
                rng13.MergeCells = true;
                //rng13.ColumnWidth = 19.50;
                rng13.Columns.AutoFit();

                Range rng22 = myworksheet.get_Range("B:D");
                rng22.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng22.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;

                Range rng05 = myworksheet.get_Range(LastColumn[1] + 9 + ":" + LastColumn[1] + 10);
                Range rng_05 = myworksheet.get_Range(LastColumn[1] + ":" + LastColumn[1]);
                rng_05.NumberFormat = "#,##0.00";
                //rng05.ColumnWidth = 16;
                rng05.Columns.AutoFit();
                rng05.MergeCells = true;
                string alpha = FindReverseIndexInAlpha(LastColumn[1]);
                Range rng06 = myworksheet.get_Range(alpha + 9 + ":" + alpha + 10);
                Range rng_06 = myworksheet.get_Range(alpha + ":" + alpha);
                rng_06.NumberFormat = "#,##0.00";
                //rng06.ColumnWidth = 15;
                rng06.Columns.AutoFit();
                rng06.MergeCells = true;
                alpha = FindReverseIndexInAlpha(startAlpha);
                Range rng07 = myworksheet.get_Range(alpha + 9 + ":" + alpha + 10);
                //Range rng_07 = myworksheet.get_Range(alpha + ":" + alpha);
                //rng_07.NumberFormat = "#,##0.00";
                //rng07.ColumnWidth = 5;
                rng07.Columns.AutoFit();
                rng07.MergeCells = true;
                alpha = FindReverseIndexInAlpha(startAlpha);
                Range rng08 = myworksheet.get_Range(alpha + 9 + ":" + alpha + 10);
                //Range rng_08 = myworksheet.get_Range(alpha + ":" + alpha);
                //rng_08.NumberFormat = "#,##0.00";
                //rng08.ColumnWidth = 21;
                rng08.Columns.AutoFit();
                rng08.MergeCells = true;

                Range range0004 = myworksheet.get_Range("E9:" + FindReverseIndexInAlpha(startAlpha) + 9);
                range0004.MergeCells = true;
                range0004.Font.Bold = true;
                range0004.Value = "DENOMINATION OF NOTES";
                range0004.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                range0004.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;

                Range range0010 = myworksheet.get_Range("A" + (lastUsedRow + 1) + ":" + "D" + (lastUsedRow + 1));
                range0010.MergeCells = true;
                range0010.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;

                if (isRCounter)
                {
                    range0010 = myworksheet.get_Range("A" + (lastUsedRow - 5) + ":" + "D" + (lastUsedRow - 5));
                    range0010.NumberFormat = "@";
                    range0010.MergeCells = true;
                    range0010.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                }

                else if (!isVault)
                {
                    range0010 = myworksheet.get_Range("A" + (lastUsedRow - 4) + ":" + "D" + (lastUsedRow - 4));
                    range0010.NumberFormat = "@";
                    range0010.MergeCells = true;
                    range0010.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                }

                if (isCounter)
                {
                    range0010 = myworksheet.get_Range("A" + (lastUsedRow - 4) + ":" + "D" + (lastUsedRow - 4));
                    range0010.NumberFormat = "@";
                    range0010.MergeCells = true;
                    range0010.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                }

                Range range0009 = myworksheet.get_Range("A" + (lastUsedRow - 3) + ":" + "D" + (lastUsedRow - 3));
                range0009.MergeCells = true;
                range0009.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;

                Range range0008 = myworksheet.get_Range("A" + (lastUsedRow - 2) + ":" + "D" + (lastUsedRow - 2));
                range0008.MergeCells = true;
                range0008.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;

                Range range0007 = myworksheet.get_Range("A" + (lastUsedRow - 1) + ":" + "D" + (lastUsedRow - 1));
                range0007.MergeCells = true;
                range0007.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;

                Range range0006 = myworksheet.get_Range("A" + lastUsedRow + ":" + "D" + lastUsedRow);
                range0006.MergeCells = true;
                range0006.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;

                Range range0005 = myworksheet.get_Range("A9:" + LastColumn[1] + 10);
                range0005.Font.Bold = true;
                range0005.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                range0005.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;

                Range rngForAmount2 = myworksheet.get_Range(str_rng15);
                CashControlReportHeaderDateCell(rngForAmount2);

                Range rng_For_A_column = myworksheet.get_Range("A:A");
                rng_For_A_column.ColumnWidth = 8;

                Range rng04_2 = myworksheet.get_Range("B:B");
                rng04_2.Columns.AutoFit();

                Range rng04_3 = myworksheet.get_Range("D:D");
                rng04_3.Columns.AutoFit();

                Range rngForAll;

                string bold_ForLastTwoRows = "A" + (lastUsedRow - 1) + ":" + LastColumn[1] + (lastUsedRow);
                rngForAll = myworksheet.get_Range(bold_ForLastTwoRows);
                rngForAll.Font.Bold = true;

                rngForAll = myworksheet.get_Range("E9:" + LastColumn[1] + 10);
                rngForAll.EntireColumn.AutoFit();

                rngForAll = myworksheet.get_Range("A11:A" + (lastUsedRow - 4));
                CashControlReportTextRight(rngForAll);

                rngForAll = myworksheet.get_Range("C11:C" + (lastUsedRow - 4));
                rngForAll.EntireColumn.AutoFit();
                CashControlReportTextLeft(rngForAll);
                Marshal.FinalReleaseComObject(rngForAll);

                string columnForDate = FindReverseIndexInAlpha(LastColumn[1]);
                Range rng14 = myworksheet.get_Range(columnForDate + "7:" + LastColumn[1] + 7);
                rng14.Style.HorizontalAlignment = XlHAlign.xlHAlignRight;
                rng14.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng14.MergeCells = true;
                rng14.Value = "Date : " + ReportDateTime.Date.ToString("dd MMMM yyyy");
                rng14.Font.Bold = true;

                rngForAll = myworksheet.get_Range("C11", "C" + (lastUsedRow - 4));
                rngForAll.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;

                rngForAll = myworksheet.get_Range("A11", "A" + (lastUsedRow - 4));
                rngForAll.Style = "Comma [0]";
                #endregion Row Data

                myworksheet.Cells.Locked = true;
                myexcelapp.StandardFont = "Times New Roman";
                myexcelapp.StandardFontSize = 12;
                myworksheet.Protect(Type.Missing, true, true, true, true, true, true, true, true, false, false, false, false, true, true, true);


                //Save Excel File To Location
                myworkbook.SaveAs(FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, true, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, true);
                //Close Work Book
                myworkbook.Close(true, misValue, misValue);
                //Quit That Excel Apps
                myexcelapp.Quit();


                //Release That Excel
                releaseObject(myworksheet);
                releaseObject(myworkbook);
                releaseObject(myexcelapp);

                FileInfo FInfo = new FileInfo(FileName);
                FInfo.Attributes = FileAttributes.ReadOnly;

                Process.Start(FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void CashControlReportByCounter_ExcelGrid(string BranchName, string BranchAddress, string BranchPhoneNo, string BranchFaxNo, string ReportTitle, DateTime ReportDateTime, DataGridView dgv, string _counterType)
        {
            try
            {
                int _countForCounterType = 4;
                object misValue = System.Reflection.Missing.Value;
                string FileName = Path.GetTempPath() + "Cash Control Report By Counter.xlsx";
                FileInfo fileinfo = new FileInfo(@FileName);
                if (fileinfo.Exists)
                {
                    fileinfo.Attributes = FileAttributes.Normal;
                    fileinfo.Delete();
                }
                myexcelapp = new Excel.Application();
                myworkbook = myexcelapp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                myworksheet = (Excel.Worksheet)myworkbook.ActiveSheet;
                myworksheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                myworksheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperLegal;
                myworksheet.PageSetup.Zoom = false;
                myworksheet.PageSetup.FitToPagesWide = 1;
                myworksheet.PageSetup.LeftMargin = 0.3;
                myworksheet.PageSetup.RightMargin = 0.3;
                myworkbook.Windows.get_Item(1).DisplayGridlines = false;
                myworksheet.Name = "Sheet1";

                #region Header



                Range range0001 = myworksheet.get_Range("A10");
                range0001.Select();

                dgv.SelectAll();
                DataObject d = dgv.GetClipboardContent();
                Clipboard.SetDataObject(d);

                range0001.PasteSpecial(XlPasteType.xlPasteAll);
                Range range0002 = myworksheet.get_Range("A:A");
                range0002.Delete(misValue);

                Image img = null;
                string tempFilePath = Application.StartupPath + "\\banklogo.jpg";                                                                                   //left,top,width,height
                myworksheet.Shapes.AddPicture(tempFilePath, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 420, 6, 50, 45);
                myworksheet.Cells[1, 10] = BranchName;
                myworksheet.Cells[2, 10] = BranchAddress;
                myworksheet.Cells[3, 10] = BranchPhoneNo;
                myworksheet.Cells[4, 10] = BranchFaxNo;
                myworksheet.Cells[5, 10] = "";
                myworksheet.Cells[6, 10] = ReportTitle;
                myworksheet.Cells[8, 10] = "";

                #endregion Header

                #region Columns Header

                #endregion Columns Header

                #region Row Data
                int SerialNo = 0;
                Range lastFor = myworksheet.get_Range("A:ZZ").Find(dgv.Columns[dgv.Columns.Count - 1].Name, Type.Missing,
                       Excel.XlFindLookIn.xlFormulas, Excel.XlLookAt.xlPart, Excel.XlSearchOrder.xlByRows,
                       Excel.XlSearchDirection.xlNext, false, false, false);
                string[] LastColumn = lastFor.Address.Split(new String[] { "$", "", string.Empty, null }, StringSplitOptions.None);

                Range last = myworksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);

                int lastUsedRow = last.Row - 1;
                int lastUsedColumn = last.Column;


                Range range0003 = myworksheet.get_Range("A9:" + LastColumn[1] + lastUsedRow);
                range0003.Borders.Color = System.Drawing.Color.Black.ToArgb();

                string str_rng15 = "E11:" + LastColumn[1] + lastUsedColumn;
                Range rngForAmount = myworksheet.get_Range(str_rng15);
                rngForAmount.NumberFormat = "#,##0";


                rngForAmount.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignRight;

                Range rng16 = myworksheet.get_Range("J1:" + LastColumn[1] + 1);
                rng16.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rng16.Cells.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng16.MergeCells = true;
                rng16.Font.Bold = true;

                Range rng17 = myworksheet.get_Range("J2:" + LastColumn[1] + 2);
                rng17.MergeCells = true;
                rng17.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rng17.Cells.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng17.Font.Bold = true;

                Range rng18 = myworksheet.get_Range("J3:" + LastColumn[1] + 3);
                rng18.MergeCells = true;
                rng18.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rng18.Cells.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng18.Font.Bold = true;

                Range rng19 = myworksheet.get_Range("J4:" + LastColumn[1] + 4);
                rng19.MergeCells = true;
                rng19.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rng19.Cells.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng19.Font.Bold = true;

                Range rng20 = myworksheet.get_Range("J6:" + LastColumn[1] + 6);
                rng20.MergeCells = true;
                rng20.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rng20.Cells.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng20.Font.Bold = true;

                Range rng02 = myworksheet.get_Range("A9:A10");
                rng02.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng02.Cells.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng02.MergeCells = true;

                Range rng03 = myworksheet.get_Range("B9:B10");
                rng03.MergeCells = true;
                rng03.ColumnWidth = 13.50;
                rng03.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng03.Cells.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;

                Range rng04 = myworksheet.get_Range("C9:C10");
                rng04.MergeCells = true;
                rng04.ColumnWidth = 17.25;
                rng04.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng04.Cells.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;

                Range range0003_1 = myworksheet.get_Range("D9:D10");
                range0003_1.MergeCells = true;
                range0003_1.ColumnWidth = 12.50;

                Range rng9 = myworksheet.get_Range("E:" + LastColumn[1]);
                rng9.ColumnWidth = 11;

                string columnName;
                columnName = "A" + LastColumn[2];
                Range rng10 = myworksheet.get_Range(columnName);
                rng10.MergeCells = true;
                rng10.ColumnWidth = 15.38;
                columnName = "A" + (Convert.ToInt32(LastColumn[2]) - 1);
                Range rng11 = myworksheet.get_Range(columnName);
                rng11.MergeCells = true;
                //rng11.ColumnWidth = 13.88;
                rng11.Columns.AutoFit();
                columnName = "A" + (Convert.ToInt32(LastColumn[2]) - 2);
                Range rng12 = myworksheet.get_Range(columnName);
                rng12.MergeCells = true;
                //rng12.ColumnWidth = 5;
                rng12.Columns.AutoFit();
                columnName = "A" + (Convert.ToInt32(LastColumn[2]) - 3);
                Range rng13 = myworksheet.get_Range(columnName);
                rng13.MergeCells = true;
                //rng13.ColumnWidth = 19.50;
                rng13.Columns.AutoFit();
                Range rng22 = myworksheet.get_Range("B:D");
                rng22.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng22.Cells.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;

                Range rng05 = myworksheet.get_Range(LastColumn[1] + 9 + ":" + LastColumn[1] + 10);
                Range rng_05 = myworksheet.get_Range(LastColumn[1] + ":" + LastColumn[1]);
                rng_05.NumberFormat = "#,##0.00";
                //rng05.ColumnWidth = 16;
                rng05.Columns.AutoFit();
                rng05.MergeCells = true;
                string alpha = FindReverseIndexInAlpha(LastColumn[1]);
                Range rng06 = myworksheet.get_Range(alpha + 9 + ":" + alpha + 10);
                Range rng_06 = myworksheet.get_Range(alpha + ":" + alpha);
                rng_06.NumberFormat = "#,##0.00";
                //rng06.ColumnWidth = 15;
                rng06.Columns.AutoFit();
                rng06.MergeCells = true;
                alpha = FindReverseIndexInAlpha(startAlpha);
                Range rng07 = myworksheet.get_Range(alpha + 9 + ":" + alpha + 10);
                //rng07.ColumnWidth = 5;
                rng07.Columns.AutoFit();
                rng07.MergeCells = true;
                alpha = FindReverseIndexInAlpha(startAlpha);

                Range rng08 = myworksheet.get_Range(alpha + 9 + ":" + alpha + 10);
                //rng08.ColumnWidth = 21;
                rng08.Columns.AutoFit();
                rng08.MergeCells = true;

                Range range0004 = myworksheet.get_Range("E9:" + FindReverseIndexInAlpha(startAlpha) + 9);
                range0004.MergeCells = true;
                range0004.Font.Bold = true;
                range0004.Value = "DENOMINATION OF NOTES";
                range0004.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                range0004.Cells.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;


                //if (_counterType.ToLower() == "r")
                //{
                //    _countForCounterType = 5;
                //    range0009_0 = myworksheet.get_Range("A" + (lastUsedRow - 5) + ":" + "D" + (lastUsedRow - 5));
                //    range0009_0.MergeCells = true;
                //    range0009_0.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;

                //    //range0009_0 = myworksheet.get_Range("A" + (lastUsedRow - 4) + ":" + "D" + (lastUsedRow - 4));
                //    //range0009_0.MergeCells = true;
                //    //range0009_0.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                //}

                Range range0009 = myworksheet.get_Range("A" + (lastUsedRow - 3) + ":" + "D" + (lastUsedRow - 3));
                range0009.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                range0009.MergeCells = true;

                Range range0008 = myworksheet.get_Range("A" + (lastUsedRow - 2) + ":" + "D" + (lastUsedRow - 2));
                range0008.MergeCells = true;
                range0008.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;

                Range range0007 = myworksheet.get_Range("A" + (lastUsedRow - 1) + ":" + "D" + (lastUsedRow - 1));
                range0007.MergeCells = true;
                range0007.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;

                Range range0006 = myworksheet.get_Range("A" + lastUsedRow + ":" + "D" + lastUsedRow);
                range0006.MergeCells = true;
                range0006.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;

                Range range0009_0;
                range0009_0 = myworksheet.get_Range("A" + (lastUsedRow - 4) + ":" + "D" + (lastUsedRow - 4));
                range0009_0.MergeCells = true;
                range0009_0.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;

                Range range0005 = myworksheet.get_Range("A9:" + LastColumn[1] + 10);
                range0005.Font.Bold = true;
                range0005.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                range0005.Cells.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;

                Range rngForAmount2 = myworksheet.get_Range(str_rng15);
                CashControlReportHeaderDateCell(rngForAmount2);

                Range rng_For_A_column = myworksheet.get_Range("A:A");
                rng_For_A_column.ColumnWidth = 8;

                Range rng04_2 = myworksheet.get_Range("B:B");
                rng04_2.Columns.AutoFit();

                Range rng04_3 = myworksheet.get_Range("D:D");
                rng04_3.Columns.AutoFit();

                Range rngForAll;

                string bold_ForLastTwoRows = "A" + (lastUsedRow - 1) + ":" + LastColumn[1] + (lastUsedRow);
                rngForAll = myworksheet.get_Range(bold_ForLastTwoRows);
                rngForAll.Font.Bold = true;

                rngForAll = myworksheet.get_Range("E9:" + LastColumn[1] + 10);
                rngForAll.EntireColumn.AutoFit();

                rngForAll = myworksheet.get_Range("A11:A" + (lastUsedRow - _countForCounterType));
                CashControlReportTextRight(rngForAll);

                rngForAll = myworksheet.get_Range("A" + (lastUsedRow - 3));
                CashControlReportTextRight(rngForAll);

                rngForAll = myworksheet.get_Range("C11:C" + (lastUsedRow - _countForCounterType));
                rngForAll.EntireColumn.AutoFit();
                CashControlReportTextLeft(rngForAll);

                string columnForDate = FindReverseIndexInAlpha(LastColumn[1]);
                Range rng14 = myworksheet.get_Range(columnForDate + "7:" + LastColumn[1] + 7);
                rng14.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignRight;
                rng14.Cells.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng14.MergeCells = true;
                rng14.Value = "Date : " + ReportDateTime.Date.ToString("dd MMMM yyyy");
                rng14.Font.Bold = true;

                //rngForAll = myworksheet.get_Range("C11", "C" + (lastUsedRow - 4));
                //rngForAll.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;

                rngForAll = myworksheet.get_Range("A11", "A" + (lastUsedRow - _countForCounterType+ 1));
                //rngForAll = myworksheet.get_Range("A11", "A" + (lastUsedRow - _countForCounterType));
                rngForAll.Style = "Comma [0]";

                rngForAll = myworksheet.get_Range("E9:" + LastColumn[1] + 10);
                rngForAll.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rngForAll.Cells.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rngForAll.EntireColumn.AutoFit();

                rngForAll = myworksheet.get_Range("C11", "C" + (lastUsedRow - _countForCounterType));
                rngForAll.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;

                rng14 = myworksheet.get_Range("E9:" + LastColumn[1] + 10);
                rng14.EntireColumn.AutoFit();

                if (_counterType.ToLower() == "r")
                {
                    _countForCounterType = 5;
                    range0009_0 = myworksheet.get_Range("A" + (lastUsedRow - 5) + ":" + "D" + (lastUsedRow - _countForCounterType));
                    //range0009_0.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    range0009_0.MergeCells = true;
                    range0009_0 = myworksheet.get_Range("A" + (lastUsedRow - _countForCounterType));
                    range0009_0.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;

                    //range0009_0 = myworksheet.get_Range("A" + (lastUsedRow - 4) + ":" + "D" + (lastUsedRow - 4));
                    //range0009_0.MergeCells = true;
                    //range0009_0.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                }
                string columnName_New = string.Empty;
                string alphaRow = "10";
                string alphaColumn = "D";
                string reverseColumn = LastColumn[1];
                for (int i = 0; i < 3; i++)
                {
                    reverseColumn = FindReverseIndexInAlpha(reverseColumn);
                }
                while (true)
                {
                    string new_alpha = FindIndexInAlpha(alphaColumn) + alphaRow;
                    alphaColumn = FindIndexInAlpha(alphaColumn);
                    if (reverseColumn == alphaColumn)
                    {
                        columnName_New += new_alpha;
                        break;
                    }
                    columnName_New += new_alpha + ",";
                }
                //rngForAll = myworksheet.get_Range(columnName_New);
                //rngForAll.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter;

                //rngForAll = myworksheet.get_Range("A" + (lastUsedRow - 5));
                //rngForAll.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                alphaColumn = string.Empty;
                //if (_counterType.ToLower() == "r")
                //{
                //    for (int j = 5; j >= 0; j--)
                //    {
                //        alphaColumn += "A" + (lastUsedRow - j) + ",";
                //    }
                //    //alphaColumn = alphaColumn.Substring(0, alphaColumn.Length - 1);
                //    //rngForAll = myworksheet.get_Range(alphaColumn);
                //    //rngForAll.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                //}
                //else
                //{
                //    for (int j = 4; j >= 0; j--)
                //    {
                //        alphaColumn += "A" + (lastUsedRow - j) + ",";
                //    }
                //    alphaColumn = alphaColumn.Substring(0, alphaColumn.Length - 1);
                //    rngForAll = myworksheet.get_Range(alphaColumn);
                //    rngForAll.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                //}
                rngForAll = myworksheet.get_Range(columnName_New);
                rngForAll.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter;

                rngForAll = myworksheet.get_Range("A" + (lastUsedRow - _countForCounterType), "A" + lastUsedRow);
                //rngForAll = myworksheet.get_Range("A11", "A" + (lastUsedRow - _countForCounterType));
                //rngForAll.Style = "Normal";
                rngForAll.Cells.NumberFormat = "@";
                //rngForAll.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;

                rngForAll = myworksheet.get_Range("A12");
                rngForAll.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                Marshal.FinalReleaseComObject(rngForAll);

                #endregion Row Data

                myworksheet.Cells.Locked = true;
                myexcelapp.StandardFont = "Times New Roman";
                myexcelapp.StandardFontSize = 12;
                myworksheet.Protect(Type.Missing, true, true, true, true, true, true, true, true, false, false, false, false, true, true, true);


                //Save Excel File To Location
                myworkbook.SaveAs(FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, true, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, true);
                //Close Work Book
                myworkbook.Close(true, misValue, misValue);
                //Quit That Excel Apps
                myexcelapp.Quit();


                //Release That Excel
                releaseObject(myworksheet);
                releaseObject(myworkbook);
                releaseObject(myexcelapp);

                FileInfo FInfo = new FileInfo(FileName);
                FInfo.Attributes = FileAttributes.ReadOnly;

                Process.Start(FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void CashDenominationListing_ExcelGrid(string BranchName, string BranchAddress, string BranchPhoneNo, string BranchFaxNo, string ReportTitle, DateTime ReportDateTime, DataGridView dgv) //, List<string> ColumnListString, List<string[]> VaultListString, List<string[]> FooterValueListString
        {
            try
            {
                object misValue = System.Reflection.Missing.Value;
                string FileName = Path.GetTempPath() + "Cash Denomination Listing.xlsx";
                FileInfo fileinfo = new FileInfo(@FileName);
                if (fileinfo.Exists)
                {
                    fileinfo.Attributes = FileAttributes.Normal;
                    fileinfo.Delete();
                }
                myexcelapp = new Excel.Application();
                myworkbook = myexcelapp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                myworksheet = (Excel.Worksheet)myworkbook.ActiveSheet;
                myworksheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                myworksheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperLegal;
                myworksheet.PageSetup.Zoom = false;
                myworksheet.PageSetup.FitToPagesWide = 1;
                myworksheet.PageSetup.LeftMargin = 0.3;
                myworksheet.PageSetup.RightMargin = 0.3;
                myworkbook.Windows.get_Item(1).DisplayGridlines = false;
                myworksheet.Name = "Sheet1";

                #region Header

                Range range0000 = myworksheet.get_Range("C:C");
                range0000.NumberFormat = "@";

                Range range0001 = myworksheet.get_Range("A10");
                range0001.Select();

                dgv.SelectAll();
                DataObject d = dgv.GetClipboardContent();
                Clipboard.SetDataObject(d);

                range0001.PasteSpecial(XlPasteType.xlPasteAll);
                Range range0002 = myworksheet.get_Range("A:A");
                range0002.Delete(misValue);

                Image img = null;
                string tempFilePath = Application.StartupPath + "\\banklogo.jpg";                                                                                  //left,top,width,height
                myworksheet.Shapes.AddPicture(tempFilePath, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 420, 6, 50, 45);
                myworksheet.Cells[1, 10] = BranchName;
                myworksheet.Cells[2, 10] = BranchAddress;
                myworksheet.Cells[3, 10] = BranchPhoneNo;
                myworksheet.Cells[4, 10] = BranchFaxNo;
                myworksheet.Cells[5, 10] = "";
                myworksheet.Cells[6, 10] = ReportTitle;
                myworksheet.Cells[8, 10] = "";

                #endregion Header

                #region Columns Header

                #endregion Columns Header

                #region Row Data
                int SerialNo = 0;
                Range lastFor = myworksheet.get_Range("A:ZZ").Find(dgv.Columns[dgv.Columns.Count - 1].Name, Type.Missing,
                       Excel.XlFindLookIn.xlFormulas, Excel.XlLookAt.xlPart, Excel.XlSearchOrder.xlByRows,
                       Excel.XlSearchDirection.xlNext, false, false, false);
                string[] LastColumn = lastFor.Address.Split(new String[] { "$", "", string.Empty, null }, StringSplitOptions.None);

                Range last = myworksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);

                int lastUsedRow = last.Row - 1;
                int lastUsedColumn = last.Column;


                Range range0003 = myworksheet.get_Range("A9:" + LastColumn[1] + lastUsedRow);
                range0003.Borders.Color = System.Drawing.Color.Black.ToArgb();

                string str_rng15 = "E11:" + LastColumn[1] + lastUsedColumn;
                Range rngForAmount = myworksheet.get_Range(str_rng15);
                rngForAmount.NumberFormat = "#,##0";


                rngForAmount.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignRight;

                Range rng16 = myworksheet.get_Range("J1:" + LastColumn[1] + 1);
                rng16.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rng16.Cells.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng16.MergeCells = true;
                rng16.Font.Bold = true;

                Range rng17 = myworksheet.get_Range("J2:" + LastColumn[1] + 2);
                rng17.MergeCells = true;
                rng17.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rng17.Cells.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng17.Font.Bold = true;

                Range rng18 = myworksheet.get_Range("J3:" + LastColumn[1] + 3);
                rng18.MergeCells = true;
                rng18.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rng18.Cells.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng18.Font.Bold = true;

                Range rng19 = myworksheet.get_Range("J4:" + LastColumn[1] + 4);
                rng19.MergeCells = true;
                rng19.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rng19.Cells.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng19.Font.Bold = true;

                Range rng20 = myworksheet.get_Range("J6:" + LastColumn[1] + 6);
                rng20.MergeCells = true;
                rng20.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rng20.Cells.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng20.Font.Bold = true;

                Range rng02 = myworksheet.get_Range("A9:A10");
                rng02.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng02.Cells.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng02.MergeCells = true;

                Range rng03 = myworksheet.get_Range("B9:B10");
                rng03.MergeCells = true;
                rng03.ColumnWidth = 13.50;
                rng03.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng03.Cells.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;

                Range rng04 = myworksheet.get_Range("C9:C10");
                rng04.MergeCells = true;
                rng04.ColumnWidth = 17.25;
                rng04.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng04.Cells.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;

                Range range0003_1 = myworksheet.get_Range("D9:D10");
                range0003_1.MergeCells = true;
                range0003_1.ColumnWidth = 12.50;

                Range rng9 = myworksheet.get_Range("E:" + LastColumn[1]);
                rng9.ColumnWidth = 11;

                string columnName;
                columnName = "A" + LastColumn[2];
                Range rng10 = myworksheet.get_Range(columnName);
                rng10.MergeCells = true;
                rng10.ColumnWidth = 15.38;
                //columnName = "A" + (Convert.ToInt32(LastColumn[2]) - 1);
                //Range rng11 = myworksheet.get_Range(columnName);
                //rng11.MergeCells = true;
                //rng11.ColumnWidth = 13.88;
                //columnName = "A" + (Convert.ToInt32(LastColumn[2]) - 2);
                //Range rng12 = myworksheet.get_Range(columnName);
                //rng12.MergeCells = true;
                //rng12.ColumnWidth = 5;
                //columnName = "A" + (Convert.ToInt32(LastColumn[2]) - 3);
                //Range rng13 = myworksheet.get_Range(columnName);
                //rng13.MergeCells = true;
                //rng13.ColumnWidth = 19.50;

                Range rng22 = myworksheet.get_Range("B:D");
                rng22.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng22.Cells.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;

                Range rng05 = myworksheet.get_Range(LastColumn[1] + 9 + ":" + LastColumn[1] + 10);
                Range rng_05 = myworksheet.get_Range(LastColumn[1] + ":" + LastColumn[1]);
                rng_05.NumberFormat = "#,##0.00";
                rng05.ColumnWidth = 16;
                rng05.MergeCells = true;
                string alpha = FindReverseIndexInAlpha(LastColumn[1]);
                Range rng06 = myworksheet.get_Range(alpha + 9 + ":" + alpha + 10);
                Range rng_06 = myworksheet.get_Range(alpha + ":" + alpha);
                rng_06.NumberFormat = "#,##0.00";
                rng06.ColumnWidth = 15;
                rng06.MergeCells = true;
                alpha = FindReverseIndexInAlpha(startAlpha);
                Range rng07 = myworksheet.get_Range(alpha + 9 + ":" + alpha + 10);
                rng07.ColumnWidth = 5;
                rng07.MergeCells = true;
                alpha = FindReverseIndexInAlpha(startAlpha);
                Range rng08 = myworksheet.get_Range(alpha + 9 + ":" + alpha + 10);
                rng08.ColumnWidth = 21;
                rng08.MergeCells = true;

                Range range0004 = myworksheet.get_Range("E9:" + FindReverseIndexInAlpha(startAlpha) + 9);
                range0004.MergeCells = true;
                range0004.Font.Bold = true;
                range0004.Value = "DENOMINATION OF NOTES";
                range0004.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                range0004.Cells.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;

                Range range0006 = myworksheet.get_Range("A" + lastUsedRow + ":" + "D" + lastUsedRow);
                range0006.MergeCells = true;
                range0006.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;

                Range range0005 = myworksheet.get_Range("A9:" + LastColumn[1] + 10);
                range0005.Font.Bold = true;
                range0005.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                range0005.Cells.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;

                Range rngForAmount2 = myworksheet.get_Range(str_rng15);
                CashControlReportHeaderDateCell(rngForAmount2);

                Range rng_For_A_column = myworksheet.get_Range("A:A");
                rng_For_A_column.ColumnWidth = 8;

                Range rng04_2 = myworksheet.get_Range("B:B");
                rng04_2.Columns.AutoFit();
                rng04_2.NumberFormat = "@";

                Range rng04_3 = myworksheet.get_Range("D:D");
                rng04_3.Columns.AutoFit();

                rng04_3 = myworksheet.get_Range("C:C");
                rng04_3.Columns.AutoFit();

                Range rngForAll;

                string bold_ForLastTwoRows = "A" + (lastUsedRow) + ":" + LastColumn[1] + (lastUsedRow);
                rngForAll = myworksheet.get_Range(bold_ForLastTwoRows);
                rngForAll.Font.Bold = true;

                rngForAll = myworksheet.get_Range("E9:" + LastColumn[1] + 10);
                rngForAll.EntireColumn.AutoFit();

                rngForAll = myworksheet.get_Range("A11:A" + (lastUsedRow - 4));
                CashControlReportTextRight(rngForAll);

                rngForAll = myworksheet.get_Range("C11:C" + (lastUsedRow - 4));
                rngForAll.EntireColumn.AutoFit();
                CashControlReportTextLeft(rngForAll);
                Marshal.FinalReleaseComObject(rngForAll);


                string columnForDate = FindReverseIndexInAlpha(LastColumn[1]);
                Range rng14 = myworksheet.get_Range(columnForDate + "7:" + LastColumn[1] + 7);
                rng14.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignRight;
                rng14.Cells.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng14.MergeCells = true;
                rng14.Value = "Date : " + ReportDateTime.Date.ToString("dd MMMM yyyy");
                rng14.Font.Bold = true;


                string _alpha = FindIndexInAlpha("C");
                while (true)
                {
                    if (_alpha == LastColumn[1])
                        break;
                    _alpha = FindIndexInAlpha(_alpha);
                    String Expr = "=SUM(" + _alpha + "12:" + _alpha + (lastUsedRow - 1) + ")";
                    myworksheet.get_Range(_alpha + lastUsedRow).Value = Expr;
                }

                rngForAll = myworksheet.get_Range("A12", LastColumn[1] + (lastUsedRow));
                rngForAll.Style = "Comma [0]";

                rngForAll = myworksheet.get_Range("A11", LastColumn[1] + (lastUsedRow));
                rngForAll.Borders.Color = System.Drawing.Color.Black.ToArgb();

                #region Modified by HMW
                //rngForAll = myworksheet.get_Range("E12", LastColumn[1] + (lastUsedRow));
                //rngForAll.NumberFormat = "#,##0";

                rngForAll = myworksheet.get_Range("E12", LastColumn[1] + (lastUsedRow));
                rngForAll.NumberFormat = "#,##0";

                rngForAll = myworksheet.get_Range("Y12", LastColumn[1] + (lastUsedRow)); 
                rngForAll.NumberFormat = "#,##0.00";

                #endregion

                rngForAll = myworksheet.get_Range("A11", LastColumn[1] + 11);
                rngForAll.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rngForAll.MergeCells = true;
                rngForAll.Interior.Color = Color.LightBlue;

                rng04_3 = myworksheet.get_Range("D:D");
                rng04_3.Columns.AutoFit();


                #endregion Row Data

                myworksheet.Cells.Locked = true;
                myexcelapp.StandardFont = "Times New Roman";
                myexcelapp.StandardFontSize = 12;
                myworksheet.Protect(Type.Missing, true, true, true, true, true, true, true, true, false, false, false, false, true, true, true);


                //Save Excel File To Location
                myworkbook.SaveAs(FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, true, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, true);
                //Close Work Book
                myworkbook.Close(true, misValue, misValue);
                //Quit That Excel Apps
                myexcelapp.Quit();


                //Release That Excel
                releaseObject(myworksheet);
                releaseObject(myworkbook);
                releaseObject(myexcelapp);

                FileInfo FInfo = new FileInfo(FileName);
                FInfo.Attributes = FileAttributes.ReadOnly;

                Process.Start(FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public CashControlReport_Excel(DataGridView dgv)
        {
            _dgvCashControlReport = dgv;
            //misValue = System.Reflection.Missing.Value; 

        }

        private void CashControlReportTextLeft(Excel.Range range)
        {
            if (range == null)
            {
                throw new Exception("Invalid Parameter");
            }
            range.Select();
            range.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;

        }

        private void TextCenter(Excel.Range range)
        {
            if (range == null)
            {
                throw new Exception("Invalid Parameter");
            }
            range.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter;

        }

        private void CashControlReportTextRight(Excel.Range range)
        {
            if (range == null)
            {
                throw new Exception("Invalid Parameter");
            }
            range.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignRight;

        }

        private void CashControlReportTextLeftAndAutoFit(Excel.Range range)
        {
            if (range == null)
            {
                throw new Exception("Invalid Parameter");
            }
            range.Cells.Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            range.Columns.AutoFit();

        }

        //For Header String Cell
        private void CashControlReportHeaderMergeCells(Excel.Range range)
        {
            if (range == null)
            {
                throw new Exception("Invalid Parameter");
            }
            range.Merge(2);
            range.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            range.Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            range.Font.Bold = true;
        }

        //For Header Date Cell
        private void CashControlReportHeaderDateCell(Excel.Range range)
        {
            if (range == null)
            {
                throw new Exception("Invalid Parameter");
            }
            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            //range.Merge(misValue);
            //range.Font.Bold = true;
        }

        //For Column Border
        private void CashControlReportHeaderColumnMarge(Excel.Range range)
        {
            if (range == null)
            {
                throw new Exception("Invalid Parameter");
            }
            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            range.Borders[Excel.XlBordersIndex.xlEdgeRight].Color = Color.Black;
            range.Borders[Excel.XlBordersIndex.xlEdgeLeft].Color = Color.Black;
            range.Borders[Excel.XlBordersIndex.xlEdgeTop].Color = Color.Black;
            range.Borders[Excel.XlBordersIndex.xlEdgeBottom].Color = Color.Black;
            range.Font.Bold = true;
            range.Columns.AutoFit();
            // range.Columns.ColumnWidth = 25;
            range.EntireColumn.AutoFit();
            range.Merge(misValue);
        }

        //For Row Item Data
        private void CashControlReportRowRangeItemData(Excel.Range range, string Type, bool IsFooter, bool isDecimal)
        {
            if (range == null)
            {
                throw new Exception("Invalid Parameter");
            }
            if (string.IsNullOrEmpty(Type))
            {
                throw new Exception("Invalid Parameter");
            }

            if (Type == "Item")
            {
                range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                range.NumberFormat = "@";//-------------------------------------------
            }
            else if (Type == "Decimal")
            {
                if (isDecimal)
                {
                    range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    // range.NumberFormat = "#0.00";//"#,##0.00"
                    range.NumberFormat = "#,##0.00";
                }
                else
                {
                    range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    range.NumberFormat = "#,##0";
                }
            }
            //For COlor or not 
            //if (IsFooter)
            //{
            //    range.Interior.Color = Color.LightBlue;
            //}

            range.Borders[Excel.XlBordersIndex.xlEdgeRight].Color = Color.Black;
            range.Borders[Excel.XlBordersIndex.xlEdgeLeft].Color = Color.Black;
            range.Borders[Excel.XlBordersIndex.xlEdgeTop].Color = Color.Black;
            range.Borders[Excel.XlBordersIndex.xlEdgeBottom].Color = Color.Black;

            range.Columns.AutoFit();
            //range.Columns.ColumnWidth = 25;
            range.EntireColumn.AutoFit();
            range.Merge(misValue);
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        string startAlpha;
        public string FindReverseIndexInAlpha(string str)
        {
            int index1;
            if (str == "Z")
            {
                str = "AA";
                startAlpha = str;
                return str;
            }
            else
            {
                if (str.Length == 1)
                {
                    if (str == "A")
                    {
                        startAlpha = str;
                        return str;
                    }
                    index1 = Array.FindIndex(alphaStr, x => x == str);
                    str = alphaStr[index1 - 1].ToString();
                }
                else if (str.Length > 1)
                {
                    index1 = Array.FindIndex(alphaStr, x => x == str.Substring(1, 1));
                    if (index1 == 0)
                    {
                        index1 = Array.FindIndex(alphaStr, x => x == str.Substring(0, 1));
                        if (index1 == 0)
                        {
                            str = "Z";
                            startAlpha = str;
                            return str;
                        }
                        str = alphaStr[index1 - 1].ToString() + "Z";
                        startAlpha = str;
                        return str;
                    }
                    //if (index1 == 25)
                    //{
                    //    index1 = Array.FindIndex(alphaStr, x => x == str.Substring(0, 1));
                    //    str = alphaStr[index1 + 1].ToString() + "A";
                    //}
                    else
                    {
                        str = str.Substring(0, 1) + alphaStr[index1 - 1].ToString();
                    }
                }
                startAlpha = str;
                return str;
            }
            //var results = Array.FindAll(alphaStr, s => s.Equals(str));

        }

        private string FindIndexInAlpha(string str)
        {
            int index1;
            if (str == "Z")
            {
                str = "AA";
                startAlpha = str;
                return str;
            }
            else
            {
                if (str.Length == 1)
                {
                    index1 = Array.FindIndex(alphaStr, x => x == str);
                    str = alphaStr[index1 + 1].ToString();
                }
                else if (str.Length > 1)
                {
                    index1 = Array.FindIndex(alphaStr, x => x == str.Substring(1, 1));
                    if (index1 == 25)
                    {
                        index1 = Array.FindIndex(alphaStr, x => x == str.Substring(0, 1));
                        str = alphaStr[index1 + 1].ToString() + "A";
                    }
                    else
                    {
                        str = str.Substring(0, 1) + alphaStr[index1 + 1].ToString();
                    }
                }
                startAlpha = str;
                return str;
            }
            //var results = Array.FindAll(alphaStr, s => s.Equals(str));

        }

        int pageNo = 2;
        int startRowNo = 8;
        int startCellNo = 1;
        string titleName;
        int titleCount = 1;
        int subtitleCount = 1;
        int startCount = 0;
        string sumTotalColumn_For_B = "=SUM(";
        string sumTotalColumn_For_C = "=SUM(";
        string sumTotalColumn_For_D = "=SUM(";
        string sumTotalColumn_For_E = "=SUM(";

        double _sumTotalColumn_For_B = 0;
        double _sumTotalColumn_For_C = 0;
        double _sumTotalColumn_For_D = 0;
        double _sumTotalColumn_For_E = 0;
       
        
        public void ExportToExcel_Expenditure(DataGridView dgv, DataGridView dgv2, string exportFileName, string bankDesp, string address, 
            string result_Income_sheet1_3Line_Title,
            string result_Income_sheet1_4Line_Title,
            string result_Income_sheet2_3Line_Title,
            string result_Income_sheet2_4Line_Title
            )
        {
            try
            {
                object misValue = System.Reflection.Missing.Value;

                myexcelapp = new Excel.Application();
                //myexcelapp.Visible = true;
                myworkbook = myexcelapp.Workbooks.Add(misValue);
                myworksheet = myworkbook.Worksheets[1];
                //_ProcessForIncomeAndExpenditure("Sheet1", dgv);

                //Image img = null;
                //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";                                                                                   //left,top,width,height
                //myworksheet.Shapes.AddPicture(tempFilePath, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 420, 6, 50, 45);
                //myworksheet.Cells[1, 10] = bankDesp;
                //myworksheet.Cells[2, 10] = address;
                ////myworksheet.Cells[3, 10] = BranchPhoneNo;
                ////myworksheet.Cells[4, 10] = BranchFaxNo;
                //myworksheet.Cells[5, 10] = "";
                //myworksheet.Cells[6, 10] = exportFileName;
                //myworksheet.Cells[8, 10] = "";

                pageNo = 2;
                startRowNo = 8;
                startCellNo = 1;
                titleName = string.Empty;
                titleCount = 1;
                subtitleCount = 1;
                startCount = 0;
                sumTotalColumn_For_B = "=SUM(";
                sumTotalColumn_For_C = "=SUM(";
                sumTotalColumn_For_D = "=SUM(";
                sumTotalColumn_For_E = "=SUM(";

                string FileName = Path.GetTempPath() + exportFileName + ".xls";
                FileInfo fileinfo = new FileInfo(@FileName);
                if (fileinfo.Exists)
                {
                    fileinfo.Attributes = FileAttributes.Normal;
                    fileinfo.Delete();
                }

                myworksheet.Select();
                #region Sheet1_Setting
                myworksheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                myworksheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperLegal;
                myworksheet.PageSetup.Zoom = false;
                myworksheet.PageSetup.FitToPagesWide = 1;
                myworksheet.PageSetup.LeftMargin = 0.3;
                myworksheet.PageSetup.RightMargin = 0.3;
                myworkbook.Windows.get_Item(1).DisplayGridlines = false;
                Range range = myworksheet.Cells as Range;
                range.EntireRow.Font.Name = "Calibri";
                range.EntireRow.Font.Size = 11;
                #endregion
                Range rng01;

                #region Sheet1_Header
                rng01 = myworksheet.get_Range("A1:E1");
                rng01.MergeCells = true;
                rng01.Value = "Page 1";
                rng01.Font.Size = 12;
                rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet.get_Range("A2:E2");
                rng01.MergeCells = true;
                //rng01.Value = bankDesp + " (" + address + ")";
                rng01.Value = result_Income_sheet1_3Line_Title;
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet.get_Range("A3:E3");
                rng01.MergeCells = true;
                //rng01.Value = "INCOME ACCOUNT FOR THE MONTH OF " + DateTime.Now.ToString("MMMM").ToUpper() + " " + DateTime.Now.ToString("yyyy");
                rng01.Value = result_Income_sheet1_4Line_Title;
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet.get_Range("A4:E4");
                rng01.MergeCells = true;
                rng01.Value = "REVISED";
                rng01.Font.Bold = true;
                rng01.Font.Size = 12;
                rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet.get_Range("A1:E3");
                rng01.Font.Bold = true;
                rng01.Font.Size = 12;

                rng01 = myworksheet.get_Range("A5:A6");
                rng01.MergeCells = true;
                rng01.Value = "INCOME";

                rng01 = myworksheet.get_Range("B5");
                rng01.Value = "OPENING";

                rng01 = myworksheet.get_Range("B6,E6");
                rng01.Value = "BALANCE";

                rng01 = myworksheet.get_Range("C5");
                rng01.Value = "TOTAL DEBIT";

                rng01 = myworksheet.get_Range("C6,D6");
                rng01.Value = "FOR THE MONTH";

                rng01 = myworksheet.get_Range("D5");
                rng01.Value = "TOTAL CREDIT";

                rng01 = myworksheet.get_Range("E5");
                rng01.Value = "CLOSING";

                rng01 = myworksheet.get_Range("B:E");
                rng01.ColumnWidth = 16;

                rng01 = myworksheet.get_Range("A5:E7");
                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                //rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                //rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                //rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                //rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;


                for (int i = 1; i <= 5; i++)
                {
                    rng01 = (Range)myworksheet.Cells[7, i];
                    rng01.Value = i;
                    rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                }

                rng01 = myworksheet.get_Range("A5:E7");
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng01.Font.Size = 10;
                rng01.Font.Bold = true;
                #endregion

                #region ForSheet1_Rows_Processing
                if (dgv.Columns.Contains("TITLE"))
                {
                    titleName = ""; string title_Name = "";
                    //int COUNT_For_Loop = (dgv.Rows.Count - (dgv.Rows.Count - 35)) - (1 + 7);
                    for (int i = 0; i < dgv.Rows.Count - 1; i++)
                    {
                        CheckRange(myworksheet.Cells[startRowNo + startCount, startCellNo], 1);
                        title_Name = dgv.Rows[i].Cells["TITLE"].Value.ToString();
                        if (_ReplaceAllString(title_Name) == _ReplaceAllString(titleName))
                        {
                            string subtitle_Name = "(" + subtitleCount + ")" + dgv.Rows[i].Cells["SUBTITLE"].Value.ToString(); subtitleCount++;
                            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo];
                            rng01.Value = subtitle_Name;
                            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 1];
                            rng01.NumberFormat = "#,##0.00";
                            rng01.Value = dgv.Rows[i].Cells["Opening_Bal"].Value.ToString();
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            sumTotalColumn_For_B += rng01.Address + ",";
                            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 2];
                            rng01.Value = dgv.Rows[i].Cells["Debit_Amount"].Value.ToString();
                            rng01.NumberFormat = "#,##0.00";
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            sumTotalColumn_For_C += rng01.Address + ",";
                            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 3];
                            rng01.Value = dgv.Rows[i].Cells["Credit_Amount"].Value.ToString();
                            rng01.NumberFormat = "#,##0.00";
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            sumTotalColumn_For_D += rng01.Address + ",";
                            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 4];
                            rng01.Value = dgv.Rows[i].Cells["Closing_Bal"].Value.ToString();
                            rng01.NumberFormat = "#,##0.00";
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            sumTotalColumn_For_E += rng01.Address + ",";
                            startCount++;
                        }
                        else
                        {
                            if (dgv.Rows[i].Index > 0) { AddSubTotal(1); }
                            titleName = _ReplaceAllString(dgv.Rows[i].Cells["TITLE"].Value.ToString());
                            subtitleCount = 1;
                            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo];
                            title_Name = dgv.Rows[i].Cells["TITLE"].Value.ToString();
                            titleCount = Convert.ToInt32(dgv.Rows[i].Cells["ITEM"].Value.ToString());
                            rng01.Value = "I." + titleCount + " " + title_Name; //titleCount++;
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Font.Size = 10;
                            rng01.Font.Bold = true;
                            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 1];
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 2];
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 3];
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 4];
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            startCount++;
                            string subtitle_Name = "(" + subtitleCount + ")" + dgv.Rows[i].Cells["SUBTITLE"].Value.ToString(); subtitleCount++;
                            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo];
                            rng01.Value = subtitle_Name;
                            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 1];
                            rng01.Value = dgv.Rows[i].Cells["Opening_Bal"].Value.ToString().Replace("-", "");
                            rng01.NumberFormat = "#,##0.00";
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            sumTotalColumn_For_B += rng01.Address + ",";
                            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 2];
                            rng01.Value = dgv.Rows[i].Cells["Debit_Amount"].Value.ToString().Replace("-", "");
                            rng01.NumberFormat = "#,##0.00";
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            sumTotalColumn_For_C += rng01.Address + ",";
                            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 3];
                            rng01.Value = dgv.Rows[i].Cells["Credit_Amount"].Value.ToString().Replace("-", "");
                            rng01.NumberFormat = "#,##0.00";
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            sumTotalColumn_For_D += rng01.Address + ",";
                            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 4];
                            rng01.Value = dgv.Rows[i].Cells["Closing_Bal"].Value.ToString().Replace("-", "");
                            rng01.NumberFormat = "#,##0.00";
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            sumTotalColumn_For_E += rng01.Address + ",";
                            startCount++;
                        }
                    }
                    AddSubTotal(1);
                }
                #endregion

                rng01 = myworksheet.get_Range("A:A");
                rng01.ColumnWidth = 50;

                int lastColumn = myworksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Column;
                int lastRow = myworksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;

                rng01 = myworksheet.get_Range("A" + lastRow + ":" + GetExcelColumnName(lastColumn) + lastRow);
                rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

                #region Sheet2_Setting
                pageNo = 2;
                startRowNo = 8;
                startCellNo = 1;
                titleName = string.Empty;
                titleCount = 1;
                subtitleCount = 1;
                startCount = 0;
                sumTotalColumn_For_B = "=SUM(";
                sumTotalColumn_For_C = "=SUM(";
                sumTotalColumn_For_D = "=SUM(";
                sumTotalColumn_For_E = "=SUM(";

                //myworkbook = myexcelapp.Workbooks.Add(misValue);
                //myworkbook.Sheets.Add(misValue);
                myworksheet2 = myworkbook.Worksheets.Add(misValue);
                myworksheet2.Select();
                myworksheet2.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                myworksheet2.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperLegal;
                myworksheet2.PageSetup.Zoom = false;
                myworksheet2.PageSetup.FitToPagesWide = 1;
                myworksheet2.PageSetup.LeftMargin = 0.3;
                myworksheet2.PageSetup.RightMargin = 0.3;
                myworkbook.Windows.get_Item(1).DisplayGridlines = false;
                range = myworksheet2.Cells as Range;
                range.EntireRow.Font.Name = "Calibri";
                range.EntireRow.Font.Size = 11;

                rng01 = myworksheet2.get_Range("A1:E1");
                rng01.MergeCells = true;
                rng01.Value = "Page 1";
                rng01.Font.Size = 12;
                rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet2.get_Range("A2:E2");
                rng01.MergeCells = true;
                //rng01.Value = bankDesp + " (" + address + ")";
                rng01.Value = result_Income_sheet2_3Line_Title;
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet2.get_Range("A3:E3");
                rng01.MergeCells = true;
                //rng01.Value = "INCOME ACCOUNT FOR THE MONTH OF " + DateTime.Now.ToString("MMMM").ToUpper() + " " + DateTime.Now.ToString("yyyy");
                rng01.Value = result_Income_sheet2_4Line_Title;
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet2.get_Range("A4:E4");
                rng01.MergeCells = true;
                rng01.Value = "REVISED";
                rng01.Font.Bold = true;
                rng01.Font.Size = 12;
                rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet2.get_Range("A1:E3");
                rng01.Font.Bold = true;
                rng01.Font.Size = 12;

                rng01 = myworksheet2.get_Range("A5:A6");
                rng01.MergeCells = true;
                rng01.Value = "INCOME";

                rng01 = myworksheet2.get_Range("B5");
                rng01.Value = "OPENING";

                rng01 = myworksheet2.get_Range("B6,E6");
                rng01.Value = "BALANCE";

                rng01 = myworksheet2.get_Range("C5");
                rng01.Value = "TOTAL DEBIT";

                rng01 = myworksheet2.get_Range("C6,D6");
                rng01.Value = "FOR THE MONTH";

                rng01 = myworksheet2.get_Range("D5");
                rng01.Value = "TOTAL CREDIT";

                rng01 = myworksheet2.get_Range("E5");
                rng01.Value = "CLOSING";

                rng01 = myworksheet2.get_Range("A5:E7");
                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng01 = myworksheet2.get_Range("B:E");
                rng01.ColumnWidth = 16;

                for (int i = 1; i <= 5; i++)
                {
                    rng01 = (Range)myworksheet2.Cells[7, i];
                    rng01.Value = i;
                    rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                }

                rng01 = myworksheet2.get_Range("A5:E7");
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng01.Font.Size = 10;
                rng01.Font.Bold = true;
                rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                #endregion

                if (dgv2.Columns.Contains("TITLE"))
                {
                    titleName = ""; string title_Name = "";
                    for (int i = 0; i < dgv2.Rows.Count - 1; i++)
                    {
                        //CheckRange(myworksheet2.Cells[startRowNo + startCount, startCellNo], 2);
                        title_Name = dgv2.Rows[i].Cells["TITLE"].Value.ToString();
                        if (_ReplaceAllString(title_Name) == _ReplaceAllString(titleName))
                        {
                            string subtitle_Name = "(" + subtitleCount + ")" + dgv2.Rows[i].Cells["SUBTITLE"].Value.ToString(); subtitleCount++;
                            rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo];
                            rng01.Value = subtitle_Name;
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 1];
                            rng01.Value = dgv2.Rows[i].Cells["Opening_Bal"].Value.ToString().Replace("-", "");
                            rng01.NumberFormat = "#,##0.00";
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            sumTotalColumn_For_B += rng01.Address + ",";
                            rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 2];
                            rng01.Value = dgv2.Rows[i].Cells["Debit_Amount"].Value.ToString().Replace("-", "");
                            rng01.NumberFormat = "#,##0.00";
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            sumTotalColumn_For_C += rng01.Address + ",";
                            rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 3];
                            rng01.Value = dgv2.Rows[i].Cells["Credit_Amount"].Value.ToString().Replace("-", "");
                            rng01.NumberFormat = "#,##0.00";
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            sumTotalColumn_For_D += rng01.Address + ",";
                            rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 4];
                            rng01.Value = dgv2.Rows[i].Cells["Closing_Bal"].Value.ToString().Replace("-", "");
                            rng01.NumberFormat = "#,##0.00";
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            sumTotalColumn_For_E += rng01.Address + ",";
                            startCount++;
                        }
                        else
                        {
                            if (dgv2.Rows[i].Index > 0) { AddSubTotal(2); }
                            titleName = _ReplaceAllString(dgv2.Rows[i].Cells["TITLE"].Value.ToString());
                            subtitleCount = 1;
                            rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo];
                            title_Name = dgv2.Rows[i].Cells["TITLE"].Value.ToString();
                            titleCount = Convert.ToInt32(dgv2.Rows[i].Cells["ITEM"].Value.ToString());
                            rng01.Value = "I." + titleCount + " " + title_Name; //titleCount++;
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Font.Size = 10;
                            rng01.Font.Bold = true;
                            rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 2];
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 3];
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 4];
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 5];
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            //rng01 = myworksheet.Cells[startRowNo + startCount, 2];
                            //rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            //rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            //rng01 = myworksheet.Cells[startRowNo + startCount, 3];
                            //rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            //rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            //rng01 = myworksheet.Cells[startRowNo + startCount, 4];
                            //rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            //rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            //rng01 = myworksheet.Cells[startRowNo + startCount, 5];
                            //rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            //rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            startCount++;
                            string subtitle_Name = "(" + subtitleCount + ")" + dgv2.Rows[i].Cells["SUBTITLE"].Value.ToString(); subtitleCount++;
                            rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo];
                            rng01.Value = subtitle_Name;

                            //rng01 = myworksheet.Cells[startRowNo + startCount, (startCellNo + 1)];
                            //rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            //rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            //rng01 = myworksheet.Cells[startRowNo + startCount, (startCellNo + 2)];
                            //rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            //rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            //rng01 = myworksheet.Cells[startRowNo + startCount, (startCellNo + 3)];
                            //rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            //rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            //rng01 = myworksheet.Cells[startRowNo + startCount, (startCellNo + 4)];
                            //rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            //rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

                            rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 1];
                            rng01.Value = dgv2.Rows[i].Cells["Opening_Bal"].Value.ToString();
                            rng01.NumberFormat = "#,##0.00";
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            sumTotalColumn_For_B += rng01.Address + ",";
                            rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 2];
                            rng01.Value = dgv2.Rows[i].Cells["Debit_Amount"].Value.ToString();
                            rng01.NumberFormat = "#,##0.00";
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            sumTotalColumn_For_C += rng01.Address + ",";
                            rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 3];
                            rng01.Value = dgv2.Rows[i].Cells["Credit_Amount"].Value.ToString();
                            rng01.NumberFormat = "#,##0.00";
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            sumTotalColumn_For_D += rng01.Address + ",";
                            rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 4];
                            rng01.Value = dgv2.Rows[i].Cells["Closing_Bal"].Value.ToString();
                            rng01.NumberFormat = "#,##0.00";
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            sumTotalColumn_For_E += rng01.Address + ",";
                            startCount++;
                        }
                    }
                    AddSubTotal(2);
                }

                CheckRange(myworksheet2.Cells[startRowNo + startCount, startCellNo], 2);
                rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo];
                rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 1];
                rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 2];
                rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 3];
                rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 4];
                rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;



                CheckRange(myworksheet2.Cells[startRowNo + startCount, startCellNo], 2);
                AddFooter();

                rng01 = myworksheet2.get_Range("A:A");
                rng01.ColumnWidth = 50;

                //string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + exportFileName + ".xls";
                ////KillSpecificExcelFileProcess(exportFileName);
                //if (File.Exists(path))
                //{
                //    try
                //    {
                //        File.Delete(path);
                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show(ex.Message);
                //    }
                //}

                myexcelapp.ActiveWorkbook.Sheets[1].Activate();
                myworkbook.Sheets[1].Activate();
                //myworksheet.Activate();

                //myworkbook.Sheets.Move(After: myworkbook.Sheets.Count);
                myworksheet2.Move(misValue, myworkbook.Sheets[myworkbook.Sheets.Count]);

                myworkbook.SaveAs(FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                myworkbook.Close(true, misValue, misValue);
                myexcelapp.Quit();

                releaseObject(myworksheet2);
                releaseObject(myworksheet);
                releaseObject(myworkbook);
                releaseObject(myexcelapp);
                //MessageBox.Show(path);

                if (!File.Exists(FileName)) return;
                Process.Start(FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ExportToExcel_General_Ledger(IList<GLMDTO00023> list1, IList<GLMDTO00023> list2, string exportFileName, string bankDesp, string address,
        string result_Income_sheet1_3Line_Title,
        string result_Income_sheet1_4Line_Title,
        string result_Income_sheet2_3Line_Title,
        string result_Income_sheet2_4Line_Title
        )
        {
            try
            {
                object misValue = System.Reflection.Missing.Value;

                myexcelapp = new Excel.Application();
                //myexcelapp.Visible = true;
                myworkbook = myexcelapp.Workbooks.Add(misValue);
                myworksheet = myworkbook.Worksheets[1];
                //_ProcessForIncomeAndExpenditure("Sheet1", dgv);

                //Image img = null;
                //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";                                                                                   //left,top,width,height
                //myworksheet.Shapes.AddPicture(tempFilePath, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 420, 6, 50, 45);
                //myworksheet.Cells[1, 10] = bankDesp;
                //myworksheet.Cells[2, 10] = address;
                ////myworksheet.Cells[3, 10] = BranchPhoneNo;
                ////myworksheet.Cells[4, 10] = BranchFaxNo;
                //myworksheet.Cells[5, 10] = "";
                //myworksheet.Cells[6, 10] = exportFileName;
                //myworksheet.Cells[8, 10] = "";

                pageNo = 2;
                startRowNo = 8;
                startCellNo = 1;
                titleName = string.Empty;
                titleCount = 1;
                subtitleCount = 1;
                startCount = 0;
                sumTotalColumn_For_B = "=SUM(";
                sumTotalColumn_For_C = "=SUM(";
                sumTotalColumn_For_D = "=SUM(";
                sumTotalColumn_For_E = "=SUM(";

                string FileName = Path.GetTempPath() + exportFileName + ".xls";
                FileInfo fileinfo = new FileInfo(@FileName);
                if (fileinfo.Exists)
                {
                    fileinfo.Attributes = FileAttributes.Normal;
                    fileinfo.Delete();
                }

                myworksheet.Select();
                #region Sheet1_Setting
                myworksheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                myworksheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperLegal;
                myworksheet.PageSetup.Zoom = false;
                myworksheet.PageSetup.FitToPagesWide = 1;
                myworksheet.PageSetup.LeftMargin = 0.3;
                myworksheet.PageSetup.RightMargin = 0.3;
                myworkbook.Windows.get_Item(1).DisplayGridlines = false;
                Range range = myworksheet.Cells as Range;
                range.EntireRow.Font.Name = "Calibri";
                range.EntireRow.Font.Size = 11;
                #endregion
                Range rng01;

                #region Sheet1_Header
                rng01 = myworksheet.get_Range("A1:E1");
                rng01.MergeCells = true;
                rng01.Value = "Page 1";
                rng01.Font.Size = 12;
                rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet.get_Range("A2:E2");
                rng01.MergeCells = true;
                //rng01.Value = bankDesp + " (" + address + ")";
                rng01.Value = result_Income_sheet1_3Line_Title;
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet.get_Range("A3:E3");
                rng01.MergeCells = true;
                //rng01.Value = "INCOME ACCOUNT FOR THE MONTH OF " + DateTime.Now.ToString("MMMM").ToUpper() + " " + DateTime.Now.ToString("yyyy");
                rng01.Value = result_Income_sheet1_4Line_Title;
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet.get_Range("A4:E4");
                rng01.MergeCells = true;
                rng01.Value = "REVISED";
                rng01.Font.Bold = true;
                rng01.Font.Size = 12;
                rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet.get_Range("A1:E3");
                rng01.Font.Bold = true;
                rng01.Font.Size = 12;

                rng01 = myworksheet.get_Range("A5:A6");
                rng01.MergeCells = true;
                rng01.Value = "INCOME";

                rng01 = myworksheet.get_Range("B5");
                rng01.Value = "OPENING";

                rng01 = myworksheet.get_Range("B6,E6");
                rng01.Value = "BALANCE";

                rng01 = myworksheet.get_Range("C5");
                rng01.Value = "TOTAL DEBIT";

                rng01 = myworksheet.get_Range("C6,D6");
                rng01.Value = "FOR THE MONTH";

                rng01 = myworksheet.get_Range("D5");
                rng01.Value = "TOTAL CREDIT";

                rng01 = myworksheet.get_Range("E5");
                rng01.Value = "CLOSING";

                rng01 = myworksheet.get_Range("B:E");
                rng01.ColumnWidth = 16;

                rng01 = myworksheet.get_Range("A5:E7");
                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                //rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                //rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                //rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                //rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;


                for (int i = 1; i <= 5; i++)
                {
                    rng01 = (Range)myworksheet.Cells[7, i];
                    rng01.Value = i;
                    rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                }

                rng01 = myworksheet.get_Range("A5:E7");
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng01.Font.Size = 10;
                rng01.Font.Bold = true;
                #endregion

                //#region ForSheet1_Rows_Processing
                //if (dgv.Columns.Contains("TITLE"))
                //{
                //    titleName = ""; string title_Name = "";
                //    //int COUNT_For_Loop = (dgv.Rows.Count - (dgv.Rows.Count - 35)) - (1 + 7);
                //    for (int i = 0; i < dgv.Rows.Count - 1; i++)
                //    {
                //        CheckRange(myworksheet.Cells[startRowNo + startCount, startCellNo], 1);
                //        title_Name = dgv.Rows[i].Cells["TITLE"].Value.ToString();
                //        if (_ReplaceAllString(title_Name) == _ReplaceAllString(titleName))
                //        {
                //            string subtitle_Name = "(" + subtitleCount + ")" + dgv.Rows[i].Cells["SUBTITLE"].Value.ToString(); subtitleCount++;
                //            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo];
                //            rng01.Value = subtitle_Name;
                //            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 1];
                //            rng01.NumberFormat = "#,##0.00";
                //            rng01.Value = dgv.Rows[i].Cells["Opening_Bal"].Value.ToString();
                //            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                //            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                //            sumTotalColumn_For_B += rng01.Address + ",";
                //            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 2];
                //            rng01.Value = dgv.Rows[i].Cells["Debit_Amount"].Value.ToString();
                //            rng01.NumberFormat = "#,##0.00";
                //            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                //            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                //            sumTotalColumn_For_C += rng01.Address + ",";
                //            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 3];
                //            rng01.Value = dgv.Rows[i].Cells["Credit_Amount"].Value.ToString();
                //            rng01.NumberFormat = "#,##0.00";
                //            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                //            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                //            sumTotalColumn_For_D += rng01.Address + ",";
                //            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 4];
                //            rng01.Value = dgv.Rows[i].Cells["Closing_Bal"].Value.ToString();
                //            rng01.NumberFormat = "#,##0.00";
                //            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                //            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                //            sumTotalColumn_For_E += rng01.Address + ",";
                //            startCount++;
                //        }
                //        else
                //        {
                //            if (dgv.Rows[i].Index > 0) { AddSubTotal(1); }
                //            titleName = _ReplaceAllString(dgv.Rows[i].Cells["TITLE"].Value.ToString());
                //            subtitleCount = 1;
                //            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo];
                //            title_Name = dgv.Rows[i].Cells["TITLE"].Value.ToString();
                //            titleCount = Convert.ToInt32(dgv.Rows[i].Cells["ITEM"].Value.ToString());
                //            rng01.Value = "I." + titleCount + " " + title_Name; //titleCount++;
                //            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                //            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                //            rng01.Font.Size = 10;
                //            rng01.Font.Bold = true;
                //            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 1];
                //            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                //            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                //            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 2];
                //            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                //            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                //            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 3];
                //            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                //            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                //            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 4];
                //            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                //            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                //            startCount++;
                //            string subtitle_Name = "(" + subtitleCount + ")" + dgv.Rows[i].Cells["SUBTITLE"].Value.ToString(); subtitleCount++;
                //            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo];
                //            rng01.Value = subtitle_Name;
                //            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 1];
                //            rng01.Value = dgv.Rows[i].Cells["Opening_Bal"].Value.ToString().Replace("-", "");
                //            rng01.NumberFormat = "#,##0.00";
                //            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                //            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                //            sumTotalColumn_For_B += rng01.Address + ",";
                //            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 2];
                //            rng01.Value = dgv.Rows[i].Cells["Debit_Amount"].Value.ToString().Replace("-", "");
                //            rng01.NumberFormat = "#,##0.00";
                //            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                //            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                //            sumTotalColumn_For_C += rng01.Address + ",";
                //            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 3];
                //            rng01.Value = dgv.Rows[i].Cells["Credit_Amount"].Value.ToString().Replace("-", "");
                //            rng01.NumberFormat = "#,##0.00";
                //            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                //            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                //            sumTotalColumn_For_D += rng01.Address + ",";
                //            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 4];
                //            rng01.Value = dgv.Rows[i].Cells["Closing_Bal"].Value.ToString().Replace("-", "");
                //            rng01.NumberFormat = "#,##0.00";
                //            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                //            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                //            sumTotalColumn_For_E += rng01.Address + ",";
                //            startCount++;
                //        }
                //    }
                //    AddSubTotal(1);
                //}
                //#endregion

                #region ForSheet1_Rows_Processing
                //if (list1[0].TITLE)
                //{
                    titleName = ""; string title_Name = "";
                    //int COUNT_For_Loop = (dgv.Rows.Count - (dgv.Rows.Count - 35)) - (1 + 7);
                    for (int i = 0; i < list1.Count; i++)
                    {
                        //CheckRange(myworksheet.Cells[startRowNo + startCount, startCellNo], 1);
                        title_Name = list1[i].TITLE;
                        if (_ReplaceAllString(title_Name) == _ReplaceAllString(titleName))
                        {
                            string subtitle_Name = "(" + subtitleCount + ")" + list1[i].SUBTITLE; subtitleCount++;
                            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo];
                            rng01.Value = subtitle_Name;
                            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 1];
                            rng01.NumberFormat = "#,##0.00";
                            rng01.Value = list1[i].Opening_bal.ToString();
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            _sumTotalColumn_For_B += rng01.Value;
                            //sumTotalColumn_For_B += rng01.Address + ",";
                            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 2];
                            rng01.Value = list1[i].Debit_Amount.ToString();
                            rng01.NumberFormat = "#,##0.00";
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            _sumTotalColumn_For_C += rng01.Value;
                            //sumTotalColumn_For_C += rng01.Address + ",";
                            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 3];
                            rng01.Value = list1[i].Credit_Amount.ToString();
                            rng01.NumberFormat = "#,##0.00";
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            _sumTotalColumn_For_D += rng01.Value;
                            //sumTotalColumn_For_D += rng01.Address + ",";
                            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 4];
                            rng01.Value = list1[i].Closing_bal.ToString();
                            rng01.NumberFormat = "#,##0.00";
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            _sumTotalColumn_For_E += rng01.Value;
                            //sumTotalColumn_For_E += rng01.Address + ",";
                            startCount++;
                        }
                        else
                        {
                            //if (i > 0) 
                            //{ AddSubTotal(1); }
                            titleName = _ReplaceAllString(list1[i].TITLE);
                            subtitleCount = 1;
                            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo];
                            title_Name = list1[i].TITLE;
                            titleCount = Convert.ToInt32(list1[i].ITEM);
                            rng01.Value = "I." + titleCount + " " + title_Name; //titleCount++;
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Font.Size = 10;
                            rng01.Font.Bold = true;
                            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 1];
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 2];
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 3];
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 4];
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            startCount++;
                            string subtitle_Name = "(" + subtitleCount + ")" + list1[i].SUBTITLE; subtitleCount++;
                            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo];
                            rng01.Value = subtitle_Name;
                            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 1];
                            rng01.Value = list1[i].Opening_bal.ToString().Replace("-", "");
                            rng01.NumberFormat = "#,##0.00";
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            _sumTotalColumn_For_B += rng01.Value;
                            //sumTotalColumn_For_B += rng01.Address + ",";
                            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 2];
                            rng01.Value = list1[i].Debit_Amount.ToString().Replace("-", "");
                            rng01.NumberFormat = "#,##0.00";
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            _sumTotalColumn_For_C += rng01.Value;
                            //sumTotalColumn_For_C += rng01.Address + ",";
                            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 3];
                            rng01.Value = list1[i].Credit_Amount.ToString().Replace("-", "");
                            rng01.NumberFormat = "#,##0.00";
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            _sumTotalColumn_For_D += rng01.Value;
                            //sumTotalColumn_For_D += rng01.Address + ",";
                            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 4];
                            rng01.Value = list1[i].Closing_bal.ToString().Replace("-", "");
                            rng01.NumberFormat = "#,##0.00";
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            _sumTotalColumn_For_E += rng01.Value;
                            //sumTotalColumn_For_E += rng01.Address + ",";
                            startCount++;
                        }
                    }
                    AddSubTotal(1);
                //}
                #endregion

                _sumTotalColumn_For_B = 0;
                _sumTotalColumn_For_C = 0;
                _sumTotalColumn_For_D = 0;
                _sumTotalColumn_For_E = 0;

                rng01 = myworksheet.get_Range("A:A");
                rng01.ColumnWidth = 50;

                int lastColumn = myworksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Column;
                int lastRow = myworksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;

                rng01 = myworksheet.get_Range("A" + lastRow + ":" + GetExcelColumnName(lastColumn) + lastRow);
                rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

                #region Sheet2_Setting
                pageNo = 2;
                startRowNo = 8;
                startCellNo = 1;
                titleName = string.Empty;
                titleCount = 1;
                subtitleCount = 1;
                startCount = 0;
                sumTotalColumn_For_B = "=SUM(";
                sumTotalColumn_For_C = "=SUM(";
                sumTotalColumn_For_D = "=SUM(";
                sumTotalColumn_For_E = "=SUM(";

                //myworkbook = myexcelapp.Workbooks.Add(misValue);
                //myworkbook.Sheets.Add(misValue);
                myworksheet2 = myworkbook.Worksheets.Add(misValue);
                myworksheet2.Select();
                myworksheet2.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                myworksheet2.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperLegal;
                myworksheet2.PageSetup.Zoom = false;
                myworksheet2.PageSetup.FitToPagesWide = 1;
                myworksheet2.PageSetup.LeftMargin = 0.3;
                myworksheet2.PageSetup.RightMargin = 0.3;
                myworkbook.Windows.get_Item(1).DisplayGridlines = false;
                range = myworksheet2.Cells as Range;
                range.EntireRow.Font.Name = "Calibri";
                range.EntireRow.Font.Size = 11;

                rng01 = myworksheet2.get_Range("A1:E1");
                rng01.MergeCells = true;
                rng01.Value = "Page 1";
                rng01.Font.Size = 12;
                rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet2.get_Range("A2:E2");
                rng01.MergeCells = true;
                //rng01.Value = bankDesp + " (" + address + ")";
                rng01.Value = result_Income_sheet2_3Line_Title;
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet2.get_Range("A3:E3");
                rng01.MergeCells = true;
                //rng01.Value = "INCOME ACCOUNT FOR THE MONTH OF " + DateTime.Now.ToString("MMMM").ToUpper() + " " + DateTime.Now.ToString("yyyy");
                rng01.Value = result_Income_sheet2_4Line_Title;
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet2.get_Range("A4:E4");
                rng01.MergeCells = true;
                rng01.Value = "REVISED";
                rng01.Font.Bold = true;
                rng01.Font.Size = 12;
                rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet2.get_Range("A1:E3");
                rng01.Font.Bold = true;
                rng01.Font.Size = 12;

                rng01 = myworksheet2.get_Range("A5:A6");
                rng01.MergeCells = true;
                rng01.Value = "EXPENDITURE";

                rng01 = myworksheet2.get_Range("B5");
                rng01.Value = "OPENING";

                rng01 = myworksheet2.get_Range("B6,E6");
                rng01.Value = "BALANCE";

                rng01 = myworksheet2.get_Range("C5");
                rng01.Value = "TOTAL DEBIT";

                rng01 = myworksheet2.get_Range("C6,D6");
                rng01.Value = "FOR THE MONTH";

                rng01 = myworksheet2.get_Range("D5");
                rng01.Value = "TOTAL CREDIT";

                rng01 = myworksheet2.get_Range("E5");
                rng01.Value = "CLOSING";

                rng01 = myworksheet2.get_Range("A5:E7");
                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng01 = myworksheet2.get_Range("B:E");
                rng01.ColumnWidth = 16;

                for (int i = 1; i <= 5; i++)
                {
                    rng01 = (Range)myworksheet2.Cells[7, i];
                    rng01.Value = i;
                    rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                }

                rng01 = myworksheet2.get_Range("A5:E7");
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng01.Font.Size = 10;
                rng01.Font.Bold = true;
                rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                #endregion

                #region Sheet2_Processing
                //if (dgv2.Columns.Contains("TITLE"))
                //{
                    titleName = ""; 
                //string title_Name = "";
                    for (int i = 0; i < list2.Count; i++)
                    {
                        //CheckRange(myworksheet2.Cells[startRowNo + startCount, startCellNo], 2);
                        title_Name = list2[i].TITLE;
                        if (_ReplaceAllString(title_Name) == _ReplaceAllString(titleName))
                        {
                            string subtitle_Name = "(" + subtitleCount + ")" + list2[i].SUBTITLE; subtitleCount++;
                            rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo];
                            rng01.Value = subtitle_Name;
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 1];
                            rng01.Value = list2[i].Opening_bal.ToString().Replace("-", "");
                            rng01.NumberFormat = "#,##0.00";
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            _sumTotalColumn_For_B += rng01.Value;
                            //sumTotalColumn_For_B += rng01.Address + ",";
                            rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 2];
                            rng01.Value = list2[i].Debit_Amount.ToString().Replace("-", "");
                            rng01.NumberFormat = "#,##0.00";
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            _sumTotalColumn_For_C += rng01.Value;
                            //sumTotalColumn_For_C += rng01.Address + ",";
                            rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 3];
                            rng01.Value = list2[i].Credit_Amount.ToString().Replace("-", "");
                            rng01.NumberFormat = "#,##0.00";
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            _sumTotalColumn_For_D += rng01.Value;
                            //sumTotalColumn_For_D += rng01.Address + ",";
                            rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 4];
                            rng01.Value = list2[i].Closing_bal.ToString().Replace("-", "");
                            rng01.NumberFormat = "#,##0.00";
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            _sumTotalColumn_For_E += rng01.Value;
                            //sumTotalColumn_For_E += rng01.Address + ",";
                            startCount++;
                        }
                        else
                        {
                            if (i > 0) { AddSubTotal(2); }
                            titleName = _ReplaceAllString(list2[i].TITLE);
                            subtitleCount = 1;
                            rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo];
                            title_Name = list2[i].TITLE;
                            titleCount = Convert.ToInt32(list2[i].ITEM);
                            rng01.Value = "E." + titleCount + " " + title_Name; //titleCount++;
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Font.Size = 10;
                            rng01.Font.Bold = true;
                            rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 2];
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 3];
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 4];
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 5];
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            //rng01 = myworksheet.Cells[startRowNo + startCount, 2];
                            //rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            //rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            //rng01 = myworksheet.Cells[startRowNo + startCount, 3];
                            //rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            //rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            //rng01 = myworksheet.Cells[startRowNo + startCount, 4];
                            //rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            //rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            //rng01 = myworksheet.Cells[startRowNo + startCount, 5];
                            //rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            //rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            startCount++;
                            string subtitle_Name = "(" + subtitleCount + ")" + list2[i].SUBTITLE; subtitleCount++;
                            rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo];
                            rng01.Value = subtitle_Name;

                            //rng01 = myworksheet.Cells[startRowNo + startCount, (startCellNo + 1)];
                            //rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            //rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            //rng01 = myworksheet.Cells[startRowNo + startCount, (startCellNo + 2)];
                            //rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            //rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            //rng01 = myworksheet.Cells[startRowNo + startCount, (startCellNo + 3)];
                            //rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            //rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            //rng01 = myworksheet.Cells[startRowNo + startCount, (startCellNo + 4)];
                            //rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            //rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

                            rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 1];
                            rng01.Value = list2[i].Opening_bal.ToString();
                            rng01.NumberFormat = "#,##0.00";
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            _sumTotalColumn_For_B += rng01.Value;
                            //sumTotalColumn_For_B += rng01.Address + ",";
                            rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 2];
                            rng01.Value = list2[i].Debit_Amount;
                            rng01.NumberFormat = "#,##0.00";
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            _sumTotalColumn_For_C += rng01.Value;
                            //sumTotalColumn_For_C += rng01.Address + ",";
                            rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 3];
                            rng01.Value =list2[i].Credit_Amount;
                            rng01.NumberFormat = "#,##0.00";
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            _sumTotalColumn_For_D += rng01.Value;
                            //sumTotalColumn_For_D += rng01.Address + ",";
                            rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 4];
                            rng01.Value = list2[i].Closing_bal;
                            rng01.NumberFormat = "#,##0.00";
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            _sumTotalColumn_For_E += rng01.Value;
                            //sumTotalColumn_For_E += rng01.Address + ",";
                            startCount++;
                        }
                    }
                    AddSubTotal(2);
                    //}
                #endregion

                //CheckRange(myworksheet2.Cells[startRowNo + startCount, startCellNo], 2);
                rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo];
                rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 1];
                rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 2];
                rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 3];
                rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 4];
                rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;



                //CheckRange(myworksheet2.Cells[startRowNo + startCount, startCellNo], 2);
                AddFooter();

                rng01 = myworksheet2.get_Range("A:A");
                rng01.ColumnWidth = 50;

                //string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + exportFileName + ".xls";
                ////KillSpecificExcelFileProcess(exportFileName);
                //if (File.Exists(path))
                //{
                //    try
                //    {
                //        File.Delete(path);
                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show(ex.Message);
                //    }
                //}

                myexcelapp.ActiveWorkbook.Sheets[1].Activate();
                myworkbook.Sheets[1].Activate();
                //myworksheet.Activate();

                //myworkbook.Sheets.Move(After: myworkbook.Sheets.Count);
                myworksheet2.Move(misValue, myworkbook.Sheets[myworkbook.Sheets.Count]);

                myworkbook.SaveAs(FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                myworkbook.Close(true, misValue, misValue);
                myexcelapp.Quit();

                releaseObject(myworksheet2);
                releaseObject(myworksheet);
                releaseObject(myworkbook);
                releaseObject(myexcelapp);
                //MessageBox.Show(path);

                if (!File.Exists(FileName)) return;
                Process.Start(FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CheckRange(Range rng01, int sheetNo)
        {
            if (sheetNo == 1)
            {
                string[] rng = rng01.Address.Split(new string[] { "$", string.Empty, null }, StringSplitOptions.None);
                double _numRng = Convert.ToInt32(rng[2]) % 35;
                if (_numRng == 0)
                {
                    sumTotalColumn_For_B = sumTotalColumn_For_B.Remove(sumTotalColumn_For_B.Length - 1).ToString() + ")";
                    sumTotalColumn_For_C = sumTotalColumn_For_C.Remove(sumTotalColumn_For_C.Length - 1).ToString() + ")";
                    sumTotalColumn_For_D = sumTotalColumn_For_D.Remove(sumTotalColumn_For_D.Length - 1).ToString() + ")";
                    sumTotalColumn_For_E = sumTotalColumn_For_E.Remove(sumTotalColumn_For_E.Length - 1).ToString() + ")";
                    rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo];
                    rng01.Value = "CARRIED OVER";
                    rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                    rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

                    rng01.Font.Size = 10;
                    rng01.Font.Bold = true;

                    rng01 = myworksheet.get_Range(FindIndexInAlpha("", startCellNo + 1) + (startRowNo + startCount) + ":" + FindIndexInAlpha("", startCellNo + 1) + (startRowNo + startCount));
                    rng01.NumberFormat = "#,##0.00";
                    rng01.Formula = sumTotalColumn_For_B;
                    rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

                    rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    rng01 = myworksheet.get_Range(FindIndexInAlpha("", startCellNo + 2) + (startRowNo + startCount) + ":" + FindIndexInAlpha("", startCellNo + 2) + (startRowNo + startCount));
                    rng01.NumberFormat = "#,##0.00";
                    rng01.Formula = sumTotalColumn_For_C;
                    rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

                    rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    rng01 = myworksheet.get_Range(FindIndexInAlpha("", startCellNo + 3) + (startRowNo + startCount) + ":" + FindIndexInAlpha("", startCellNo + 3) + (startRowNo + startCount));
                    rng01.NumberFormat = "#,##0.00";
                    rng01.Formula = sumTotalColumn_For_D;
                    rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

                    rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    rng01 = myworksheet.get_Range(FindIndexInAlpha("", startCellNo + 4) + (startRowNo + startCount) + ":" + FindIndexInAlpha("", startCellNo + 4) + (startRowNo + startCount));
                    rng01.NumberFormat = "#,##0.00";
                    rng01.Formula = sumTotalColumn_For_E;
                    rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

                    rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                    startCount++;
                    rng01 = myworksheet.get_Range("A" + (startRowNo + startCount) + ":E" + (startRowNo + startCount));
                    rng01.MergeCells = true;
                    rng01.Value = "Page " + pageNo; pageNo++;
                    rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                    rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                    rng01.Font.Size = 12;
                    rng01.Font.Bold = true;
                    rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    startCount++;
                    for (int i = 1; i <= 5; i++)
                    {
                        rng01 = (Range)myworksheet.Cells[startRowNo + startCount, i];
                        rng01.Value = i;

                        rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        rng01.Font.Size = 10;
                        rng01.Font.Bold = true;
                    }
                    startCount++;
                    rng01 = myworksheet.get_Range("A" + (startRowNo + startCount));
                    rng01.Value = "BROUGHT FORWARD";
                    rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                    rng01.Font.Size = 10;
                    rng01.Font.Bold = true;
                    rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                    rng01 = (Range)myworksheet.Cells[startRowNo + startCount, 2];
                    rng01.NumberFormat = "#,##0.00";
                    rng01.Value = (Range)myworksheet.Cells[(startRowNo + startCount) - 3, 2];
                    sumTotalColumn_For_B = "=SUM(" + rng01.Address + ",";
                    rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                    rng01 = (Range)myworksheet.Cells[startRowNo + startCount, 3]; 
                    rng01.NumberFormat = "#,##0.00";
                    rng01.Value = (Range)myworksheet.Cells[(startRowNo + startCount) - 3, 3];
                    sumTotalColumn_For_C = "=SUM(" + rng01.Address + ",";
                    rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                    rng01 = (Range)myworksheet.Cells[startRowNo + startCount, 4];
                    rng01.NumberFormat = "#,##0.00";
                    rng01.Value = (Range)myworksheet.Cells[(startRowNo + startCount) - 3, 4];
                    sumTotalColumn_For_D = "=SUM(" + rng01.Address + ",";
                    rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                    rng01 = (Range)myworksheet.Cells[startRowNo + startCount, 5];
                    rng01.NumberFormat = "#,##0.00";
                    rng01.Value = (Range)myworksheet.Cells[(startRowNo + startCount) - 3, 5];
                    sumTotalColumn_For_E = "=SUM(" + rng01.Address + ",";
                    rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                    rng01 = myworksheet.get_Range("B" + (startRowNo + startCount - 3) + ":E" + (startRowNo + startCount));
                    rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                    rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                    rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                    startCount++;
                }
            }
            else if (sheetNo == 2)
            {
                string[] rng = rng01.Address.Split(new string[] { "$", string.Empty, null }, StringSplitOptions.None);
                double _numRng = Convert.ToInt32(rng[2]) % 35;
                if (_numRng == 0)
                {
                    sumTotalColumn_For_B = sumTotalColumn_For_B.Remove(sumTotalColumn_For_B.Length - 1).ToString() + ")";
                    sumTotalColumn_For_C = sumTotalColumn_For_C.Remove(sumTotalColumn_For_C.Length - 1).ToString() + ")";
                    sumTotalColumn_For_D = sumTotalColumn_For_D.Remove(sumTotalColumn_For_D.Length - 1).ToString() + ")";
                    sumTotalColumn_For_E = sumTotalColumn_For_E.Remove(sumTotalColumn_For_E.Length - 1).ToString() + ")";
                    rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo];
                    rng01.Value = "CARRIED OVER";
                    rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                    rng01.Font.Size = 10;
                    rng01.Font.Bold = true;
                    rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

                    rng01 = myworksheet2.get_Range(FindIndexInAlpha("", startCellNo + 1) + (startRowNo + startCount) + ":" + FindIndexInAlpha("", startCellNo + 1) + (startRowNo + startCount));
                    rng01.NumberFormat = "#,##0.00";
                    rng01.Formula = sumTotalColumn_For_B;
                    rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

                    rng01 = myworksheet2.get_Range(FindIndexInAlpha("", startCellNo + 2) + (startRowNo + startCount) + ":" + FindIndexInAlpha("", startCellNo + 2) + (startRowNo + startCount));
                    rng01.NumberFormat = "#,##0.00";
                    rng01.Formula = sumTotalColumn_For_C;
                    rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

                    rng01 = myworksheet2.get_Range(FindIndexInAlpha("", startCellNo + 3) + (startRowNo + startCount) + ":" + FindIndexInAlpha("", startCellNo + 3) + (startRowNo + startCount));
                    rng01.NumberFormat = "#,##0.00";
                    rng01.Formula = sumTotalColumn_For_D;
                    rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

                    rng01 = myworksheet2.get_Range(FindIndexInAlpha("", startCellNo + 4) + (startRowNo + startCount) + ":" + FindIndexInAlpha("", startCellNo + 4) + (startRowNo + startCount));
                    rng01.NumberFormat = "#,##0.00";
                    rng01.Formula = sumTotalColumn_For_E;
                    rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;


                    startCount++;
                    rng01 = myworksheet2.get_Range("A" + (startRowNo + startCount) + ":E" + (startRowNo + startCount));
                    rng01.MergeCells = true;
                    rng01.Value = "Page " + pageNo; pageNo++;
                    rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                    rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                    rng01.Font.Size = 12;
                    rng01.Font.Bold = true;
                    startCount++;
                    for (int i = 1; i <= 5; i++)
                    {
                        rng01 = (Range)myworksheet2.Cells[startRowNo + startCount, i];
                        rng01.Value = i;
                        rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        rng01.Font.Size = 10;
                        rng01.Font.Bold = true;
                        rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

                    }
                    startCount++;
                    rng01 = myworksheet2.get_Range("A" + (startRowNo + startCount));
                    rng01.Value = "BROUGHT FORWARD";
                    rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                    rng01.Font.Size = 10;
                    rng01.Font.Bold = true;
                    rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

                    rng01 = (Range)myworksheet2.Cells[startRowNo + startCount, 2];
                    rng01.NumberFormat = "#,##0.00";
                    rng01.Value = (Range)myworksheet2.Cells[(startRowNo + startCount) - 3, 2];
                    rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    sumTotalColumn_For_B = "=SUM(" + rng01.Address + ",";

                    rng01 = (Range)myworksheet2.Cells[startRowNo + startCount, 3];
                    rng01.NumberFormat = "#,##0.00";
                    rng01.Value = (Range)myworksheet2.Cells[(startRowNo + startCount) - 3, 3];
                    rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    sumTotalColumn_For_C = "=SUM(" + rng01.Address + ",";

                    rng01 = (Range)myworksheet2.Cells[startRowNo + startCount, 4];
                    rng01.NumberFormat = "#,##0.00";
                    rng01.Value = (Range)myworksheet2.Cells[(startRowNo + startCount) - 3, 4];
                    rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    sumTotalColumn_For_D = "=SUM(" + rng01.Address + ",";

                    rng01 = (Range)myworksheet2.Cells[startRowNo + startCount, 5];
                    rng01.NumberFormat = "#,##0.00";
                    rng01.Value = (Range)myworksheet2.Cells[(startRowNo + startCount) - 3, 5];
                    rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    sumTotalColumn_For_E = "=SUM(" + rng01.Address + ",";

                    //rng01 = myworksheet2.get_Range("B" + (startRowNo + startCount - 5) + ":E" + (startRowNo + startCount));
                    //rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                    //rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                    startCount++;
                }
            }
        }


        private double sheet1_SumSubTotal_B;
        private double sheet1_SumSubTotal_C;
        private double sheet1_SumSubTotal_D;
        private double sheet1_SumSubTotal_E;

        private double sheet2_SumSubTotal_B;
        private double sheet2_SumSubTotal_C;
        private double sheet2_SumSubTotal_D;
        private double sheet2_SumSubTotal_E; 

        private void AddFooter()
        {
            double _EXPENDITURE_OVER_INCOME_2;
            double _EXPENDITURE_OVER_INCOME_3;
            double _EXPENDITURE_OVER_INCOME_4;
            double _EXPENDITURE_OVER_INCOME_5;
            startCount++;

            Range rng01;

            rng01 = myworksheet2.Cells[startRowNo + startCount, 1];
            rng01.Value = "EXCESS OF INCOME OVER EXPENDITURE";
            rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
            rng01.Font.Bold = true;

            rng01 = myworksheet2.Cells[startRowNo + startCount, 2];
            rng01.NumberFormat = "#,##0.00";
            rng01.Value = "0";
            rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

            rng01 = myworksheet2.Cells[startRowNo + startCount, 3];
            rng01.NumberFormat = "#,##0.00";
            rng01.Value = "0";
            rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

            rng01 = myworksheet2.Cells[startRowNo + startCount, 4];
            rng01.NumberFormat = "#,##0.00";
            rng01.Value = "0";
            rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

            rng01 = myworksheet2.Cells[startRowNo + startCount, 5];
            rng01.NumberFormat = "#,##0.00";
            rng01.Value = "0";
            rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

            startCount++;
            startCount++;

            rng01 = myworksheet2.Cells[startRowNo + startCount, 1];
            rng01.NumberFormat = "#,##0.00";
            rng01.Value = "TOTAL INCOME";
            rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
            rng01.Font.Bold = true;

            rng01 = myworksheet2.Cells[startRowNo + startCount, 2];
            rng01.NumberFormat = "#,##0.00";
            rng01.Value = sheet1_SumSubTotal_B;
            rng01.Font.Color = Color.Red;
            rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

            rng01 = myworksheet2.Cells[startRowNo + startCount, 3];
            rng01.NumberFormat = "#,##0.00";
            rng01.Font.Bold = true;
            rng01.Value = sheet1_SumSubTotal_C;
            rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            _EXPENDITURE_OVER_INCOME_3 = sheet1_SumSubTotal_C;

            rng01 = myworksheet2.Cells[startRowNo + startCount, 4];
            rng01.NumberFormat = "#,##0.00";
            rng01.Value = sheet1_SumSubTotal_D;
            rng01.Font.Bold = true;
            rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            _EXPENDITURE_OVER_INCOME_4 = sheet1_SumSubTotal_D;

            rng01 = myworksheet2.Cells[startRowNo + startCount, 5];
            rng01.NumberFormat = "#,##0.00";
            rng01.Value = sheet1_SumSubTotal_E;
            rng01.Font.Bold = true;
            rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            _EXPENDITURE_OVER_INCOME_5 = sheet1_SumSubTotal_E;

            startCount--;

            rng01 = myworksheet2.Cells[startRowNo + startCount, 1];
            rng01.Value = "EXPENDITURE OVER INCOME";
            rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
            rng01.Font.Bold = true;

            rng01 = myworksheet2.Cells[startRowNo + startCount, 2];
            rng01.NumberFormat = "#,##0.00";
            double result = sheet2_SumSubTotal_B - Convert.ToDouble(myworksheet2.get_Range(GetExcelColumnName(2) + (startRowNo + startCount + 1)).Value);
            rng01.Value = result;
            rng01.Font.Bold = true;
            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            _EXPENDITURE_OVER_INCOME_2 = result;

            rng01 = myworksheet2.Cells[startRowNo + startCount, 3];
            rng01.NumberFormat = "#,##0.00";
            result = sheet1_SumSubTotal_C - Convert.ToDouble(myworksheet2.get_Range(GetExcelColumnName(2) + (startRowNo + startCount + 1)).Value);
            rng01.Value = result;
            rng01.Font.Bold = true;
            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            _EXPENDITURE_OVER_INCOME_3 = result;

            rng01 = myworksheet2.Cells[startRowNo + startCount, 4];
            rng01.NumberFormat = "#,##0.00";
            result = sheet1_SumSubTotal_D - Convert.ToDouble(myworksheet2.get_Range(GetExcelColumnName(2) + (startRowNo + startCount + 1)).Value);
            rng01.Value = result;
            rng01.Font.Bold = true;
            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            _EXPENDITURE_OVER_INCOME_4 = result;


            rng01 = myworksheet2.Cells[startRowNo + startCount, 5];
            rng01.NumberFormat = "#,##0.00";
            result = sheet1_SumSubTotal_E - Convert.ToDouble(myworksheet2.get_Range(GetExcelColumnName(2) + (startRowNo + startCount + 1)).Value);
            rng01.Value = result;
            rng01.Font.Bold = true;
            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            _EXPENDITURE_OVER_INCOME_5 = result;

            startCount++;
            startCount++;
            startCount++;

            rng01 = myworksheet2.Cells[startRowNo + startCount, 1];
            rng01.Value = "LOSS UPTO THE MONTH OF " + DateTime.Now.AddMonths(-1).ToString("MMM") + DateTime.Now.ToString("yyyy");// "DECEMBER 2017";

            rng01 = myworksheet2.Cells[startRowNo + startCount, 2];
            rng01.NumberFormat = "#,##0.00";
            rng01.Value = _EXPENDITURE_OVER_INCOME_2;
            rng01.Font.Bold = true;

            //rng01 = myworksheet2.Cells[startRowNo + startCount, 3];
            rng01 = myworksheet2.get_Range(GetExcelColumnName(3) + (startRowNo + startCount) + ":" + GetExcelColumnName(4) + (startRowNo + startCount));
            rng01.MergeCells = true;
            rng01.Value = "   INCOME UP TO " + DateTime.Now.ToString("MMMM").ToUpper() + " " + DateTime.Now.ToString("yyyy");

            rng01 = myworksheet2.Cells[startRowNo + startCount, 5];
            rng01.NumberFormat = "#,##0.00";
            rng01.Value = sheet1_SumSubTotal_B;
            rng01.Font.Bold = true;

            startCount++;

            rng01 = myworksheet2.Cells[startRowNo + startCount, 1];
            rng01.Value = "LOSS UPTO THE MONTH OF " + DateTime.Now.ToString("MMMM").ToUpper() + " " + DateTime.Now.ToString("yyyy");

            rng01 = myworksheet2.Cells[startRowNo + startCount, 2];
            rng01.NumberFormat = "#,##0.00";
            rng01.Value = _EXPENDITURE_OVER_INCOME_4;
            rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            rng01.Font.Bold = true;

            rng01 = myworksheet2.get_Range(GetExcelColumnName(3) + (startRowNo + startCount) + ":" + GetExcelColumnName(4) + (startRowNo + startCount));
            rng01.MergeCells = true;
            rng01.Value = "   EXPENDITURE UP TO " + DateTime.Now.ToString("MMMM").ToUpper() + " " + DateTime.Now.ToString("yyyy");

            rng01 = myworksheet2.Cells[startRowNo + startCount, 5];
            rng01.NumberFormat = "#,##0.00";
            rng01.Value = sheet1_SumSubTotal_E;
            rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            rng01.Font.Bold = true;

            startCount++;

            rng01 = myworksheet2.Cells[startRowNo + startCount, 1];
            rng01.Value = "TOTAL LOSS UPTO THE MONTH (" + DateTime.Now.ToString("MM") +"/" + DateTime.Now.ToString("yyyy") + ")";

            rng01 = myworksheet2.Cells[startRowNo + startCount, 2];
            rng01.NumberFormat = "#,##0.00";
            rng01.Value = _EXPENDITURE_OVER_INCOME_5;
            rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDouble;
            rng01.Font.Bold = true;

            rng01 = myworksheet2.get_Range(GetExcelColumnName(3) + (startRowNo + startCount) + ":" + GetExcelColumnName(4) + (startRowNo + startCount));
            rng01.MergeCells = true;
            rng01.Value = "   NET LOSS UP TO " + DateTime.Now.ToString("MMMM").ToUpper() + " " + DateTime.Now.ToString("yyyy");

            rng01 = myworksheet2.Cells[startRowNo + startCount, 5];
            rng01.NumberFormat = "#,##0.00";
            rng01.Value = _EXPENDITURE_OVER_INCOME_5;
            rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDouble;
            rng01.Font.Bold = true;

        }

        private string _ReplaceAllString(string name)
        {
            string[] res = name.Split(new string[] { "", string.Empty, ":", ",", ";", " " }, StringSplitOptions.None);

            string lastString = "";
            for (int i = 0; i < res.Length; i++)
            {
                if (string.IsNullOrEmpty(res[i].Trim())) continue;
                lastString += res[i].Trim();
            }

            return lastString;
        }


        private void AddSubTotal(int sheet)
        {
            if (sheet == 1)
            {
                #region sheet1
                //sumTotalColumn_For_B = sumTotalColumn_For_B.Remove(sumTotalColumn_For_B.Length - 1).ToString() + ")";
                //sumTotalColumn_For_C = sumTotalColumn_For_C.Remove(sumTotalColumn_For_C.Length - 1).ToString() + ")";
                //sumTotalColumn_For_D = sumTotalColumn_For_D.Remove(sumTotalColumn_For_D.Length - 1).ToString() + ")";
                //sumTotalColumn_For_E = sumTotalColumn_For_E.Remove(sumTotalColumn_For_E.Length - 1).ToString() + ")";
                Range rngSubTotal = myworksheet.get_Range(FindIndexInAlpha("", startCellNo) + (startRowNo + startCount) + ":" + FindIndexInAlpha("", startCellNo) + (startRowNo + startCount));
                rngSubTotal.HorizontalAlignment = XlHAlign.xlHAlignRight;
                rngSubTotal.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rngSubTotal.Value = "SUB - TOTAL";

                rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

                rngSubTotal.Font.Size = 10;
                rngSubTotal.Font.Bold = true;
                rngSubTotal = myworksheet.get_Range(FindIndexInAlpha("", startCellNo + 1) + (startRowNo + startCount) + ":" + FindIndexInAlpha("", startCellNo + 1) + (startRowNo + startCount));
                //rngSubTotal.Formula = sumTotalColumn_For_B;
                rngSubTotal.Value = _sumTotalColumn_For_B;

                rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

                sheet1_SumSubTotal_B += rngSubTotal.Value;

                rngSubTotal = myworksheet.get_Range(FindIndexInAlpha("", startCellNo + 2) + (startRowNo + startCount) + ":" + FindIndexInAlpha("", startCellNo + 2) + (startRowNo + startCount));
                //rngSubTotal.Formula = sumTotalColumn_For_C;
                rngSubTotal.Value = _sumTotalColumn_For_C;

                rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

                sheet1_SumSubTotal_C += rngSubTotal.Value;

                rngSubTotal = myworksheet.get_Range(FindIndexInAlpha("", startCellNo + 3) + (startRowNo + startCount) + ":" + FindIndexInAlpha("", startCellNo + 3) + (startRowNo + startCount));
                //rngSubTotal.Formula = sumTotalColumn_For_D;
                rngSubTotal.Value = _sumTotalColumn_For_D;
                sheet1_SumSubTotal_D += rngSubTotal.Value;

                rngSubTotal = myworksheet.get_Range(FindIndexInAlpha("", startCellNo + 4) + (startRowNo + startCount) + ":" + FindIndexInAlpha("", startCellNo + 4) + (startRowNo + startCount));
                //rngSubTotal.Formula = sumTotalColumn_For_E;
                rngSubTotal.Value = _sumTotalColumn_For_E;

                rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

                sheet1_SumSubTotal_E += rngSubTotal.Value;

                //sumTotalColumn_For_B = "=SUM(";
                //sumTotalColumn_For_C = "=SUM(";
                //sumTotalColumn_For_D = "=SUM(";
                //sumTotalColumn_For_E = "=SUM(";
                startCount++;
                #endregion
            }
            else if (sheet == 2)
            {
                #region sheet2
                //sumTotalColumn_For_B = sumTotalColumn_For_B.Remove(sumTotalColumn_For_B.Length - 1).ToString() + ")";
                //sumTotalColumn_For_C = sumTotalColumn_For_C.Remove(sumTotalColumn_For_C.Length - 1).ToString() + ")";
                //sumTotalColumn_For_D = sumTotalColumn_For_D.Remove(sumTotalColumn_For_D.Length - 1).ToString() + ")";
                //sumTotalColumn_For_E = sumTotalColumn_For_E.Remove(sumTotalColumn_For_E.Length - 1).ToString() + ")";


                //Range rngSubTotal = myworksheet2.get_Range(FindIndexInAlpha("", startCellNo) + (startRowNo + startCount) + ":" + FindIndexInAlpha("", startCellNo) + (startRowNo + startCount));
                //rngSubTotal.HorizontalAlignment = XlHAlign.xlHAlignRight;
                //rngSubTotal.VerticalAlignment = XlVAlign.xlVAlignCenter;
                //rngSubTotal.Value = "SUB - TOTAL";
                //rngSubTotal.Font.Size = 10;
                //rngSubTotal.Font.Bold = true;
                //rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                //rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                ////rngSubTotal.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                ////rngSubTotal.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

                //rngSubTotal = myworksheet2.get_Range(FindIndexInAlpha("", startCellNo + 1) + (startRowNo + startCount) + ":" + FindIndexInAlpha("", startCellNo + 1) + (startRowNo + startCount));
                //rngSubTotal.Formula = sumTotalColumn_For_B;
                //rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                //rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                ////rngSubTotal.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                ////rngSubTotal.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                //sheet2_SumSubTotal_B += rngSubTotal.Value;
                sheet2_SumSubTotal_B += _sumTotalColumn_For_B;

                //rngSubTotal = myworksheet2.get_Range(FindIndexInAlpha("", startCellNo + 2) + (startRowNo + startCount) + ":" + FindIndexInAlpha("", startCellNo + 2) + (startRowNo + startCount));
                //rngSubTotal.Formula = sumTotalColumn_For_C;
                //rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                //rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                ////rngSubTotal.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                ////rngSubTotal.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                //sheet2_SumSubTotal_C += rngSubTotal.Value;
                sheet2_SumSubTotal_C += _sumTotalColumn_For_C;

                //rngSubTotal = myworksheet2.get_Range(FindIndexInAlpha("", startCellNo + 3) + (startRowNo + startCount) + ":" + FindIndexInAlpha("", startCellNo + 3) + (startRowNo + startCount));
                //rngSubTotal.Formula = sumTotalColumn_For_D;
                //rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                //rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                ////rngSubTotal.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                ////rngSubTotal.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                //sheet2_SumSubTotal_D += rngSubTotal.Value;
                sheet2_SumSubTotal_D += _sumTotalColumn_For_D;

                //rngSubTotal = myworksheet2.get_Range(FindIndexInAlpha("", startCellNo + 4) + (startRowNo + startCount) + ":" + FindIndexInAlpha("", startCellNo + 4) + (startRowNo + startCount));
                //rngSubTotal.Formula = sumTotalColumn_For_E;
                //rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                //rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                ////rngSubTotal.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                ////rngSubTotal.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                //sheet2_SumSubTotal_E += rngSubTotal.Value;
                sheet2_SumSubTotal_E += _sumTotalColumn_For_E;

                //sumTotalColumn_For_B = "=SUM(";
                //sumTotalColumn_For_C = "=SUM(";
                //sumTotalColumn_For_D = "=SUM(";
                //sumTotalColumn_For_E = "=SUM(";
                //startCount++;
                #endregion
            }
        }

        //private string FindIndexInAlpha(string str)
        //{
        //    int index1;
        //    if (str == "Z")
        //    {
        //        str = "AA";
        //        startAlpha = str;
        //        return str;
        //    }
        //    else
        //    {
        //        if (str.Length == 1)
        //        {
        //            if (str == "A")
        //            {
        //                return str;
        //            }
        //            index1 = Array.FindIndex(alphaStr, x => x == str);
        //            str = alphaStr[index1 - 1].ToString();
        //        }
        //        else if (str.Length > 1)
        //        {
        //            index1 = Array.FindIndex(alphaStr, x => x == str.Substring(1, 1));
        //            if (index1 == 0)
        //            {
        //                index1 = Array.FindIndex(alphaStr, x => x == str.Substring(0, 1));
        //                str = alphaStr[index1 - 1].ToString() + "Z";
        //            }
        //            //if (index1 == 25)
        //            //{
        //            //    index1 = Array.FindIndex(alphaStr, x => x == str.Substring(0, 1));
        //            //    str = alphaStr[index1 + 1].ToString() + "A";
        //            //}
        //            else
        //            {
        //                str = str.Substring(0, 1) + alphaStr[index1 - 1].ToString();
        //            }
        //        }
        //        startAlpha = str;
        //        return str;
        //    }
        //    //var results = Array.FindAll(alphaStr, s => s.Equals(str));

        //}

        private string FindIndexInAlpha(string str, int str1)
        {
            return str = alphaStr[str1 - 1].ToString();
        }



    }


}
