
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
    public class Income_Expense_Excel
    {
        public Income_Expense_Excel()
        {

        }
        Excel.Application myexcelapp;
        Excel.Workbook myworkbook;
        Excel.Worksheet myworksheet1;
        public DataGridView _dgvCashControlReport = null;
        object misValue = System.Reflection.Missing.Value;  //Miss Value Declaration
        string CounterNo = string.Empty;
        Excel.Worksheet Expenditure_sheet2;

        int pageNo = 2;
        int startRowNo = 8;
        int startCellNo = 1;
        string __titleName;
        int titleCount = 1;
        int subtitleCount = 1;
        int startCount = 0;
        string sumTotalColumn_For_C = "=SUM(";
        string sumTotalColumn_For_D = "=SUM(";
        string sumTotalColumn_For_E = "=SUM(";

        double AllAMountForC = 0;
        double AllAMountForD = 0;
        double AllAMountForE = 0;
        double AllAMountForF = 0;

        string AllSumSubTotalColumn_For_C = "=SUM(";
        string AllSumSubTotalColumn_For_D = "=SUM(";
        string AllSumSubTotalColumn_For_E = "=SUM(";
        string AllSumSubTotalColumn_For_F = "=SUM("; // Added By AAM (17-Jan-2018)

        string sumTotalColumn_For_F = "=SUM(";

        double _sumTotalColumn_For_C = 0;
        double _sumTotalColumn_For_D = 0;
        double _sumTotalColumn_For_E = 0;
        double _sumTotalColumn_For_F = 0;

        double _sumTotalColumn_For_C_All = 0;
        double _sumTotalColumn_For_D_All = 0;
        double _sumTotalColumn_For_E_All = 0;
        double _sumTotalColumn_For_F_All = 0; // Added By AAM (17-Jan-2018)

        private double sheet1_SumSubTotal_C;
        private double sheet1_SumSubTotal_D;
        private double sheet1_SumSubTotal_E;
        private double sheet1_SumSubTotal_F;

        private double sheet2_SumSubTotal_C;
        private double sheet2_SumSubTotal_D;
        private double sheet2_SumSubTotal_E;
        private double sheet2_SumSubTotal_F; 


        public void ExportToExcel_Income_Expense(IList<GLMDTO00023> list1, IList<GLMDTO00023> list2, string exportFileName, string bankDesp, string address,
          string result_Income_sheet1_3Line_Title,
          string result_Income_sheet1_4Line_Title,
          string result_Income_sheet2_3Line_Title,
          string result_Income_sheet2_4Line_Title, DateTime requiredDate
      )
        {
            try
            {
                object misValue = System.Reflection.Missing.Value;

                myexcelapp = new Excel.Application();
                //myexcelapp.Visible = true;
                myworkbook = myexcelapp.Workbooks.Add(misValue);
                myworksheet1 = myworkbook.Worksheets[1];
                myworksheet1.Name = "Income";
                pageNo = 2;
                startRowNo = 9;
                startCellNo = 1;
                __titleName = string.Empty;
                titleCount = 1;
                subtitleCount = 1;
                startCount = 0;
                sumTotalColumn_For_C = "=SUM(";
                sumTotalColumn_For_D = "=SUM(";
                sumTotalColumn_For_E = "=SUM(";
                //sumTotalColumn_For_F = "=SUM(";

                string FileName = Path.GetTempPath() + exportFileName + ".xls";
                FileInfo fileinfo = new FileInfo(@FileName);
                if (fileinfo.Exists)
                {
                    fileinfo.Attributes = FileAttributes.Normal;
                    fileinfo.Delete();
                }

                myworksheet1.Select();
                #region Sheet1_Setting
                myworksheet1.PageSetup.Orientation = Excel.XlPageOrientation.xlPortrait;
                myworksheet1.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4;
                myworksheet1.PageSetup.Zoom = false;
                myworksheet1.PageSetup.FitToPagesWide = 1;
                myworksheet1.PageSetup.LeftMargin = 0.3;
                myworksheet1.PageSetup.RightMargin = 0.3;
                myworkbook.Windows.get_Item(1).DisplayGridlines = false;
                Range range = myworksheet1.Cells as Range;
                range.EntireRow.Font.Name = "Times New Roman";
                range.EntireRow.Font.Size = 12;
                #endregion
                Range rng01;

                #region Sheet1_Header
                string tempFilePath = System.Windows.Forms.Application.StartupPath + "\\pristinelogo.png";
                myworksheet1.Shapes.AddPicture(tempFilePath, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 5, 6, 216, 54);

                rng01 = myworksheet1.get_Range("C2:E2");
                rng01.MergeCells = true;
                rng01.Value = "Pristine Global Finance Company Limited.";
                rng01.EntireRow.Font.Name = "Times New Roman";
                rng01.EntireRow.Font.Size = 13;
                rng01.EntireRow.Font.Bold = true;
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                //rng01 = myworksheet1.get_Range("A2:E2");
                //rng01.MergeCells = true;
                ////rng01.Value = bankDesp + " (" + address + ")";
                //rng01.Value = result_Income_sheet1_3Line_Title;
                //rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                //rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet1.get_Range("C3:E3");
                rng01.MergeCells = true;
                rng01.EntireRow.Font.Name = "Times New Roman";
                rng01.EntireRow.Font.Size = 13;
                rng01.EntireRow.Font.Bold = true;
                //rng01.Value = "INCOME ACCOUNT FOR THE MONTH OF " + DateTime.Now.ToString("MMMM").ToUpper() + " " + DateTime.Now.ToString("yyyy");
                // rng01.Value = result_Income_sheet1_4Line_Title;
                rng01.Value = "Statement of Income for the month of " + requiredDate.ToString("MMMM") + "' " + requiredDate.ToString("yyyy");
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet1.get_Range("A5:F5");
                rng01.MergeCells = true;
                rng01.Value = "(Kyats)";
                rng01.EntireRow.Font.Name = "Times New Roman";
                rng01.EntireRow.Font.Size = 13;
                rng01.EntireRow.Font.Bold = true;
                rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                //rng01 = myworksheet1.get_Range("C1:E3");
                //rng01.Font.Bold = true;
                //rng01.Font.Size = 12;

                rng01 = myworksheet1.get_Range("A6:A7");
                rng01.MergeCells = true;
                rng01.Value = "Sr. No";
                rng01.EntireRow.Font.Name = "Times New Roman";
                rng01.EntireRow.Font.Size = 12;
                rng01.EntireRow.Font.Bold = true;


                rng01 = myworksheet1.get_Range("B6:B7");
                rng01.MergeCells = true;
                rng01.Value = "Account Name";
                rng01.EntireRow.Font.Name = "Times New Roman";
                rng01.EntireRow.Font.Size = 12;
                rng01.EntireRow.Font.Bold = true;

                rng01 = myworksheet1.get_Range("C6:C7");
                rng01.MergeCells = true;
                rng01.Value = "Opening Balance";
                rng01.WrapText = true;
                rng01.EntireRow.Font.Name = "Times New Roman";
                rng01.EntireRow.Font.Size = 12;
                rng01.EntireRow.Font.Bold = true;

                rng01 = myworksheet1.get_Range("D6:D7");
                rng01.MergeCells = true;
                rng01.WrapText = true;
                rng01.Value = "Total Debit for the month";
                rng01.EntireRow.Font.Name = "Times New Roman";
                rng01.EntireRow.Font.Size = 12;
                rng01.EntireRow.Font.Bold = true;

                rng01 = myworksheet1.get_Range("E6:E7");
                rng01.MergeCells = true;
                rng01.WrapText = true;
                rng01.Value = "Total Credit for the month";
                rng01.EntireRow.Font.Name = "Times New Roman";
                rng01.EntireRow.Font.Size = 12;
                rng01.EntireRow.Font.Bold = true;

                rng01 = myworksheet1.get_Range("F6:F7");
                rng01.MergeCells = true;
                rng01.Value = "Closing Balance";
                rng01.WrapText = true;
                rng01.EntireRow.Font.Name = "Times New Roman";
                rng01.EntireRow.Font.Size = 12;
                rng01.EntireRow.Font.Bold = true;


                rng01 = myworksheet1.get_Range("B8:B8");
                rng01.Value = "Income A/C";
                rng01.Font.Italic = true;
                rng01.Font.Bold = true;
                rng01.Font.Underline = true;
                rng01.Font.Size = 12;

                rng01 = myworksheet1.get_Range("A8:F8"); rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng01 = myworksheet1.get_Range("A6:F7");
                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng01 = myworksheet1.get_Range("B:E");
                rng01.ColumnWidth = 18;

                rng01 = myworksheet1.get_Range("A6:F7");
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                
                #endregion

                #region ForSheet1_Rows_Processing
                __titleName = ""; string title_Name = "";
                for (int i = 0; i < list1.Count; i++)
                {
                    title_Name = list1[i].TITLE;
                    if (_ReplaceAllString(title_Name) == _ReplaceAllString(__titleName))
                    {

                        //rng01 = myworksheet1.Cells[startRowNo + startCount, startCellNo];
                        //rng01.NumberFormat = "0";
                        //rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        rng01 = myworksheet1.Cells[startRowNo + startCount, startCellNo];
                        rng01.NumberFormat = "0";
                        rng01.Value = subtitleCount; subtitleCount++;

                        string subtitle_Name = list1[i].SUBTITLE;
                        rng01 = myworksheet1.Cells[startRowNo + startCount, startCellNo + 1];
                        rng01.Value = subtitle_Name;
                        rng01.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                        rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        rng01 = myworksheet1.Cells[startRowNo + startCount, startCellNo + 2];
                        rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        rng01.Value = IsEqualZero(list1[i].Opening_bal.ToString());
                        rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                        rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        _sumTotalColumn_For_C += IsEqual_ReturnZero(rng01.Value);
                        sumTotalColumn_For_C += rng01.Address + ",";

                        rng01 = myworksheet1.Cells[startRowNo + startCount, startCellNo + 3];
                        rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        rng01.Value = IsEqualZero(list1[i].Debit_Amount.ToString());
                        rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                        rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        _sumTotalColumn_For_D += IsEqual_ReturnZero(rng01.Value);
                        sumTotalColumn_For_D += rng01.Address + ",";

                        rng01 = myworksheet1.Cells[startRowNo + startCount, startCellNo + 4];
                        rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        rng01.Value = IsEqualZero(list1[i].Credit_Amount.ToString());
                        rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                        rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        _sumTotalColumn_For_E += IsEqual_ReturnZero(rng01.Value);
                        sumTotalColumn_For_E += rng01.Address + ",";


                        rng01 = myworksheet1.Cells[startRowNo + startCount, startCellNo + 5];
                        rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        rng01.Value = IsEqualZero(list1[i].Closing_bal.ToString());
                        rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                        rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        _sumTotalColumn_For_F += IsEqual_ReturnZero(rng01.Value);
                        sumTotalColumn_For_F += rng01.Address + ",";


                        startCount++;
                    }
                    else
                    {
                        if (i > 0)
                        {
                            AddSubTotal(1, list1[i - 1].TITLE);
                        }
                        if (_ReplaceAllString(title_Name) != _ReplaceAllString(__titleName))
                        {
                            _sumTotalColumn_For_C = 0;
                            _sumTotalColumn_For_D = 0;
                            _sumTotalColumn_For_E = 0;
                            _sumTotalColumn_For_F = 0;
                        }
                        __titleName = _ReplaceAllString(list1[i].TITLE);


                        //rng01 = myworksheet1.Cells[startRowNo + startCount, startCellNo];
                        //rng01.NumberFormat = "0";
                        //rng01.Value = subtitleCount; subtitleCount++;
                        //rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        rng01 = myworksheet1.Cells[startRowNo + startCount, startCellNo + 1];
                        title_Name = list1[i].TITLE;
                        titleCount = Convert.ToInt32(list1[i].ITEM);
                        rng01.Value = title_Name;
                        rng01.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                        rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        rng01.Font.Bold = true;
                        rng01.Font.Underline = true;


                        rng01 = myworksheet1.Cells[startRowNo + startCount, startCellNo + 2];
                        rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                        rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        rng01 = myworksheet1.Cells[startRowNo + startCount, startCellNo + 3];
                        rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                        rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        rng01 = myworksheet1.Cells[startRowNo + startCount, startCellNo + 4];
                        rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                        rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        rng01 = myworksheet1.Cells[startRowNo + startCount, startCellNo + 5];
                        rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                        rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        startCount++;
                        // to show serial numbers
                        rng01 = myworksheet1.Cells[startRowNo + startCount, startCellNo];
                        rng01.NumberFormat = "0";
                        //rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Value = subtitleCount; subtitleCount++;

                        #region next_subtitile
                        string subtitle_Name = list1[i].SUBTITLE;
                        rng01 = myworksheet1.Cells[startRowNo + startCount, startCellNo + 1];
                        rng01.Value = subtitle_Name;
                        rng01.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                        rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

                        rng01 = myworksheet1.Cells[startRowNo + startCount, startCellNo + 2];
                        rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Value = IsEqualZero(list1[i].Opening_bal.ToString());
                        rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                        rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        _sumTotalColumn_For_C += IsEqual_ReturnZero(rng01.Value);
                        sumTotalColumn_For_C += rng01.Address + ",";

                        rng01 = myworksheet1.Cells[startRowNo + startCount, startCellNo + 3];
                        rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        rng01.Value = IsEqualZero(list1[i].Debit_Amount.ToString());
                        rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                        rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                        _sumTotalColumn_For_D += IsEqual_ReturnZero(rng01.Value);
                        sumTotalColumn_For_D += rng01.Address + ",";

                        rng01 = myworksheet1.Cells[startRowNo + startCount, startCellNo + 4];
                        rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        rng01.Value = IsEqualZero(list1[i].Credit_Amount.ToString());
                        rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                        rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                        _sumTotalColumn_For_E += IsEqual_ReturnZero(rng01.Value);
                        sumTotalColumn_For_E += rng01.Address + ",";


                        rng01 = myworksheet1.Cells[startRowNo + startCount, startCellNo + 5];
                        rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        rng01.Value = IsEqualZero(list1[i].Closing_bal.ToString());
                        rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                        rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                        _sumTotalColumn_For_F += IsEqual_ReturnZero(rng01.Value);
                        sumTotalColumn_For_F += rng01.Address + ",";


                        startCount++;
                        #endregion
                    }
                }
                AddSubTotal(1, title_Name);

                #region AddFooter_ForSheet1

                sumTotalColumn_For_C = sumTotalColumn_For_C.Remove(sumTotalColumn_For_C.Length - 1).ToString() + ")";
                sumTotalColumn_For_D = sumTotalColumn_For_D.Remove(sumTotalColumn_For_D.Length - 1).ToString() + ")";
                sumTotalColumn_For_E = sumTotalColumn_For_E.Remove(sumTotalColumn_For_E.Length - 1).ToString() + ")";
                sumTotalColumn_For_F = sumTotalColumn_For_F.Remove(sumTotalColumn_For_F.Length - 1).ToString() + ")";

                Range rngSubTotal = myworksheet1.get_Range(GetExcelColumnName(startCellNo) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 1) + (startRowNo + startCount));
                rngSubTotal.MergeCells = true;
                rngSubTotal.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rngSubTotal.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rngSubTotal.Value = "Total Income";

                rngSubTotal.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Font.Size = 12;
                rngSubTotal.Font.Bold = true;

                rngSubTotal = myworksheet1.get_Range(GetExcelColumnName(startCellNo + 2) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 2) + (startRowNo + startCount));
                rngSubTotal.NumberFormat = "#,##0.00;(#,##0.00)";
                rngSubTotal.Font.Size = 12;
                rngSubTotal.Font.Bold = true;
                //rngSubTotal.Value = IsEqualZero(_sumTotalColumn_For_C);
                rngSubTotal.Formula = sumTotalColumn_For_C;
                AllAMountForC += IsEqual_ReturnZero(rngSubTotal.Value);

                rngSubTotal.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

                rngSubTotal = myworksheet1.get_Range(GetExcelColumnName(startCellNo + 3) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 3) + (startRowNo + startCount));
                rngSubTotal.NumberFormat = "#,##0.00;(#,##0.00)";
                rngSubTotal.Font.Size = 12;
                rngSubTotal.Font.Bold = true;
                //rngSubTotal.Value = IsEqualZero(_sumTotalColumn_For_D);
                rngSubTotal.Formula = sumTotalColumn_For_D;
                AllAMountForD += IsEqual_ReturnZero(rngSubTotal.Value);

                rngSubTotal.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

                rngSubTotal = myworksheet1.get_Range(GetExcelColumnName(startCellNo + 4) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 4) + (startRowNo + startCount));
                rngSubTotal.NumberFormat = "#,##0.00;(#,##0.00)";
                rngSubTotal.Font.Size = 12;
                rngSubTotal.Font.Bold = true;
                //rngSubTotal.Value = IsEqualZero(_sumTotalColumn_For_E);
                //lastRowslastColumsAddress = rngSubTotal.Address;
                rngSubTotal.Formula = sumTotalColumn_For_E;
                AllAMountForE += IsEqual_ReturnZero(rngSubTotal.Value);

                rngSubTotal.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

                rngSubTotal = myworksheet1.get_Range(GetExcelColumnName(startCellNo + 5) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 5) + (startRowNo + startCount));
                rngSubTotal.NumberFormat = "#,##0.00;(#,##0.00)";
                rngSubTotal.Font.Size = 12;
                rngSubTotal.Font.Bold = true;
                string lastRowslastColumsAddress = "";
                lastRowslastColumsAddress = rngSubTotal.Address;
                rngSubTotal.Formula = sumTotalColumn_For_F;
                AllAMountForF += IsEqual_ReturnZero(rngSubTotal.Value);

                rngSubTotal.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

                //rngSubTotal = myworksheet.get_Range(GetExcelColumnName(startCellNo + 5) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 5) + (startRowNo + startCount));
                //rngSubTotal.NumberFormat = "#,##0.00;(#,##0.00)";
                //rngSubTotal.Value = IsEqualZero(_sumTotalColumn_For_F);
                //rngSubTotal.Formula = sumTotalColumn_For_F;

                //rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                //rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

                rngSubTotal = myworksheet1.get_Range(GetExcelColumnName(1) + ":" + GetExcelColumnName(6));
                rngSubTotal.EntireColumn.AutoFit();

                sumTotalColumn_For_C = "=SUM(";
                sumTotalColumn_For_D = "=SUM(";
                sumTotalColumn_For_E = "=SUM(";
                sumTotalColumn_For_F = "=SUM(";

                #region AllColumnsRowsToBorders
                Range AllColumn = myworksheet1.get_Range("A8:" + lastRowslastColumsAddress.Replace("$", "").Trim());
                Excel.Borders allBorders = AllColumn.Borders;
                allBorders.LineStyle = Excel.XlLineStyle.xlContinuous;
                allBorders.Weight = 2d;
                #endregion

                Range rng_For_C_column1 = myworksheet1.get_Range("C:C");
                rng_For_C_column1.ColumnWidth = 25;

                Range rng_For_D_column1 = myworksheet1.get_Range("D:D");
                rng_For_D_column1.ColumnWidth = 25;

                Range rng_For_E_column1 = myworksheet1.get_Range("E:E");
                rng_For_E_column1.ColumnWidth = 25;

                Range rng_For_F_column1 = myworksheet1.get_Range("F:F");
                rng_For_F_column1.ColumnWidth = 25;

                #endregion

                #endregion

                _sumTotalColumn_For_C = 0;
                _sumTotalColumn_For_D = 0;
                _sumTotalColumn_For_E = 0;
                _sumTotalColumn_For_F = 0;

                //int lastColumn = myworksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Column;
                //int lastRow = myworksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;

                //rng01 = myworksheet.get_Range("A" + lastRow + ":" + GetExcelColumnName(lastColumn) + lastRow);
                //rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                //rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                //rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                //rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

                #region Sheet2_Setting
                pageNo = 2;
                startRowNo = 9;
                startCellNo = 1;
                __titleName = string.Empty;
                titleCount = 1;
                subtitleCount = 1;
                startCount = 0;
                sumTotalColumn_For_C = "=SUM(";
                sumTotalColumn_For_D = "=SUM(";
                sumTotalColumn_For_E = "=SUM(";
                sumTotalColumn_For_F = "=SUM(";

                Expenditure_sheet2 = myworkbook.Worksheets.Add(misValue);
                Expenditure_sheet2.Select();
                Expenditure_sheet2.PageSetup.Orientation = Excel.XlPageOrientation.xlPortrait;
                Expenditure_sheet2.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4;
                Expenditure_sheet2.PageSetup.Zoom = false;
                Expenditure_sheet2.PageSetup.FitToPagesWide = 1;
                Expenditure_sheet2.PageSetup.LeftMargin = 0.3;
                Expenditure_sheet2.PageSetup.RightMargin = 0.3;
                myworkbook.Windows.get_Item(1).DisplayGridlines = false;
                range = Expenditure_sheet2.Cells as Range;
                range.EntireRow.Font.Name = "Times New Roman";
                range.EntireRow.Font.Size = 12;
                Expenditure_sheet2.Name = "Expenditure";
                #region Sheet2_Header
                //rng01 = Expenditure_sheet2.get_Range("C2:F2"); // Modified By AAM (17-Jan-2018) E2 to F2
                rng01 = Expenditure_sheet2.get_Range("C2:E2"); // Modified By AAM (02-Aug-2018) F2 to E2
                rng01.MergeCells = true;
                rng01.Value = "Pristine Global Finance Company Limited.";
                rng01.Font.Size = 13;
                rng01.EntireRow.Font.Name = "Times New Roman";
                rng01.EntireRow.Font.Bold = true;
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                //rng01 = myworksheet2.get_Range("A2:F2");
                //rng01.MergeCells = true;
                ////rng01.Value = bankDesp + " (" + address + ")";
                //rng01.Value = result_Income_sheet2_3Line_Title; 
                //rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                //rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                //rng01 = Expenditure_sheet2.get_Range("C3:F3");// Modified By AAM (17-Jan-2018) E3 to F3
                rng01 = Expenditure_sheet2.get_Range("C3:E3");// Modified By AAM (02-Aug-2018) F3 to E3
                rng01.MergeCells = true;
                rng01.Font.Size = 13;
                rng01.EntireRow.Font.Name = "Times New Roman";
                rng01.EntireRow.Font.Bold = true;
                rng01.Value = "Statement of Expenditure for the month of " + requiredDate.ToString("MMMM") + "' " + requiredDate.ToString("yyyy");
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;



                //rng01 = Expenditure_sheet2.get_Range("A6:F7");// Modified By AAM (17-Jan-2018) E7 to F7
                rng01 = Expenditure_sheet2.get_Range("A6:E7");// Modified By AAM (17-Jan-2018) F7 to E7
                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                
                #endregion

                //rng01 = myworksheet2.get_Range("A1:E1");
                //rng01.MergeCells = true;
                //rng01.Value = "LIABILITIES";
                //rng01.Font.Size = 12;
                //rng01.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                //rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                Expenditure_sheet2.Shapes.AddPicture(tempFilePath, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 5, 6, 216, 54);

                rng01 = Expenditure_sheet2.get_Range("A5:F5");// Modified By AAM (17-Jan-2018) E5 to F5
                rng01.MergeCells = true;
                rng01.Value = "(Kyats)";
                rng01.Font.Size = 13;
                rng01.EntireRow.Font.Name = "Times New Roman";
                rng01.EntireRow.Font.Bold = true;
                rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                //rng01 = Expenditure_sheet2.get_Range("C1:E3");
                //rng01.Font.Bold = true;
                //rng01.Font.Size = 12;

                rng01 = Expenditure_sheet2.get_Range("A6:A7");
                rng01.MergeCells = true;
                rng01.Value = "Sr. No";
                rng01.Font.Size = 12;
                rng01.EntireRow.Font.Name = "Times New Roman";
                rng01.EntireRow.Font.Bold = true;

                rng01 = Expenditure_sheet2.get_Range("B6:B7");
                rng01.MergeCells = true;
                rng01.Value = "Account Name";
                rng01.WrapText = true;
                rng01.Font.Size = 12;
                rng01.EntireRow.Font.Name = "Times New Roman";
                rng01.EntireRow.Font.Bold = true;

                rng01 = Expenditure_sheet2.get_Range("C6:C7");
                rng01.MergeCells = true;
                rng01.WrapText = true;
                rng01.Font.Size = 12;
                rng01.EntireRow.Font.Name = "Times New Roman";
                rng01.EntireRow.Font.Bold = true;
                rng01.Value = "Opening  Balance";

                rng01 = Expenditure_sheet2.get_Range("D6:D7");
                rng01.MergeCells = true;
                rng01.WrapText = true;
                rng01.Font.Size = 12;
                rng01.EntireRow.Font.Name = "Times New Roman";
                rng01.EntireRow.Font.Bold = true;
                rng01.Value = "Total Debit for the month";

                // Added By AAM (17-Jan-2018)
                rng01 = Expenditure_sheet2.get_Range("E6:E7");
                rng01.MergeCells = true;
                rng01.WrapText = true;
                rng01.Font.Size = 12;
                rng01.EntireRow.Font.Name = "Times New Roman";
                rng01.EntireRow.Font.Bold = true;
                rng01.Value = "Total Credit for the month";

                rng01 = Expenditure_sheet2.get_Range("F6:F7"); // Modified By AAM (17-Jan-2018)E6:E7 to F6:F7
                rng01.MergeCells = true;
                rng01.WrapText = true;
                rng01.Font.Size = 12;
                rng01.EntireRow.Font.Name = "Times New Roman";
                rng01.EntireRow.Font.Bold = true;
                rng01.Value = "Closing Balance";

                rng01 = Expenditure_sheet2.get_Range("B8:B8");
                rng01.Value = "Expenditure A/C";
                rng01.Font.Italic = true;
                rng01.Font.Bold = true;
                rng01.Font.Underline = true;
                rng01.Font.Size = 12;
                //For fill border in entire B row
                AllColumn = Expenditure_sheet2.get_Range("A8:F8");// Modified By AAM (17-Jan-2018)E8 to F8
                allBorders = AllColumn.Borders;
                allBorders.LineStyle = Excel.XlLineStyle.xlContinuous;
                allBorders.Weight = 2d;

                rng01 = Expenditure_sheet2.get_Range("A6:F7");// Modified By AAM (17-Jan-2018)E7 to F7
                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng01 = Expenditure_sheet2.get_Range("B:F");// Modified By AAM (17-Jan-2018)E to F
                rng01.ColumnWidth = 18;


                rng01 = Expenditure_sheet2.get_Range("A6:F7");// Modified By AAM (17-Jan-2018)E7 to F7
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                //rng01.Font.Size = 13;
                //rng01.Font.Bold = true;
                //rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                //rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                //rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                //rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                #endregion

                #region Sheet2_Processing


                __titleName = "";
                for (int i = 0; i < list2.Count; i++)
                {
                    title_Name = list2[i].TITLE;
                    if (_ReplaceAllString(title_Name) == _ReplaceAllString(__titleName))
                    {
                        rng01 = Expenditure_sheet2.Cells[startRowNo + startCount, startCellNo];
                        rng01.NumberFormat = "0";
                        rng01.Value = subtitleCount; subtitleCount++;
                        //rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

                        string subtitle_Name = list2[i].SUBTITLE;
                        rng01 = Expenditure_sheet2.Cells[startRowNo + startCount, startCellNo + 1];
                        rng01.Value = subtitle_Name;
                        //rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

                        rng01 = Expenditure_sheet2.Cells[startRowNo + startCount, startCellNo + 2];
                        rng01.Value = IsEqualZero(list2[i].Opening_bal.ToString().Replace("-", ""));
                        rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                        rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        //rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                        _sumTotalColumn_For_C += IsEqual_ReturnZero(rng01.Value);
                        sumTotalColumn_For_C += rng01.Address + ",";
                        //AllSumSubTotalColumn_For_C += rng01.Address + ",";

                        rng01 = Expenditure_sheet2.Cells[startRowNo + startCount, startCellNo + 3];
                        rng01.Value = IsEqualZero(list2[i].Debit_Amount.ToString().Replace("-", ""));
                        rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                        rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        //rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                        _sumTotalColumn_For_D += IsEqual_ReturnZero(rng01.Value);
                        sumTotalColumn_For_D += rng01.Address + ",";
                        //AllSumSubTotalColumn_For_D += rng01.Address + ",";

                        rng01 = Expenditure_sheet2.Cells[startRowNo + startCount, startCellNo + 4];
                        rng01.Value = IsEqualZero(list2[i].Credit_Amount.ToString().Replace("-", ""));
                        rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                        rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        //rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                        _sumTotalColumn_For_E += IsEqual_ReturnZero(rng01.Value);
                        sumTotalColumn_For_E += rng01.Address + ",";
                        //AllSumSubTotalColumn_For_D += rng01.Address + ",";


                        rng01 = Expenditure_sheet2.Cells[startRowNo + startCount, startCellNo + 5];
                        rng01.Value = IsEqualZero(list2[i].Closing_bal.ToString().Replace("-", ""));
                        rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                        rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        //rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                        _sumTotalColumn_For_F += IsEqual_ReturnZero(rng01.Value);
                        sumTotalColumn_For_F += rng01.Address + ",";
                        //AllSumSubTotalColumn_For_E += rng01.Address + ",";

                        startCount++;
                    }
                    else
                    {
                        if (i > 0)
                        {
                            AddSubTotal(2, list2[i - 1].TITLE);
                        }
                        //titleName = _ReplaceAllString(list2[i].TITLE);
                        //rng01 = Expenditure_sheet2.Cells[startRowNo + startCount, startCellNo];
                        //rng01.Value = subtitleCount; subtitleCount++;
                        if (_ReplaceAllString(title_Name) != _ReplaceAllString(__titleName))
                        {
                            _sumTotalColumn_For_C_All = _sumTotalColumn_For_C;
                            _sumTotalColumn_For_D_All = _sumTotalColumn_For_D;
                            _sumTotalColumn_For_E_All = _sumTotalColumn_For_E;
                            _sumTotalColumn_For_F_All = _sumTotalColumn_For_F; // Added By AAM (17-Jan-2018)
                            _sumTotalColumn_For_C = 0;
                            _sumTotalColumn_For_D = 0;
                            _sumTotalColumn_For_E = 0;
                            _sumTotalColumn_For_F = 0;// Added By AAM (17-Jan-2018)
                        }
                        rng01 = Expenditure_sheet2.Cells[startRowNo + startCount, startCellNo + 1];
                        __titleName = list2[i].TITLE;
                        rng01.Value = title_Name;
                        //rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Font.Size = 10;
                        rng01.Font.Bold = true;

                        ///don't open command
                        //rng01 = Expenditure_sheet2.Cells[startRowNo + startCount, startCellNo + 2];
                        //rngSubTotal.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        //rng01 = Expenditure_sheet2.Cells[startRowNo + startCount, startCellNo + 3];
                        //rngSubTotal.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        //rng01 = Expenditure_sheet2.Cells[startRowNo + startCount, startCellNo + 4];
                        //rngSubTotal.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        startCount++; //to show number

                        rng01 = Expenditure_sheet2.Cells[startRowNo + startCount, startCellNo];
                        rng01.NumberFormat = "0";
                        //rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Value = subtitleCount; subtitleCount++;


                        string subtitle_Name = list2[i].SUBTITLE;
                        rng01 = Expenditure_sheet2.Cells[startRowNo + startCount, startCellNo + 1];
                        rng01.Value = subtitle_Name;
                        //rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

                        rng01 = Expenditure_sheet2.Cells[startRowNo + startCount, startCellNo + 2];
                        rng01.Value = IsEqualZero(list2[i].Opening_bal.ToString().Replace("-", ""));
                        rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                        rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        //rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                        _sumTotalColumn_For_C += IsEqual_ReturnZero(rng01.Value);
                        sumTotalColumn_For_C += rng01.Address + ",";
                        //AllSumSubTotalColumn_For_C += rng01.Address + ",";

                        rng01 = Expenditure_sheet2.Cells[startRowNo + startCount, startCellNo + 3];
                        rng01.Value = IsEqualZero(list2[i].Debit_Amount.ToString().Replace("-", ""));
                        rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                        rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        //rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                        _sumTotalColumn_For_D += IsEqual_ReturnZero(rng01.Value);
                        sumTotalColumn_For_D += rng01.Address + ",";
                        //AllSumSubTotalColumn_For_D += rng01.Address + ",";

                        rng01 = Expenditure_sheet2.Cells[startRowNo + startCount, startCellNo + 4];
                        rng01.Value = IsEqualZero(list2[i].Credit_Amount.ToString().Replace("-", ""));
                        rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                        rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        //rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                        _sumTotalColumn_For_E += IsEqual_ReturnZero(rng01.Value);
                        sumTotalColumn_For_E += rng01.Address + ",";
                        //AllSumSubTotalColumn_For_D += rng01.Address + ",";


                        rng01 = Expenditure_sheet2.Cells[startRowNo + startCount, startCellNo + 5];
                        rng01.Value = IsEqualZero(list2[i].Closing_bal.ToString().Replace("-", ""));
                        rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                        rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        //rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                        //rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                        _sumTotalColumn_For_F += IsEqual_ReturnZero(rng01.Value);
                        sumTotalColumn_For_F += rng01.Address + ",";
                        //AllSumSubTotalColumn_For_E += rng01.Address + ",";

                        startCount++;
                    }
                }
                AddSubTotal(2, title_Name);

                #region AddFooter_ForSheet2

                AllSumSubTotalColumn_For_C = AllSumSubTotalColumn_For_C.Remove(AllSumSubTotalColumn_For_C.Length - 1).ToString() + ")";
                AllSumSubTotalColumn_For_D = AllSumSubTotalColumn_For_D.Remove(AllSumSubTotalColumn_For_D.Length - 1).ToString() + ")";
                AllSumSubTotalColumn_For_E = AllSumSubTotalColumn_For_E.Remove(AllSumSubTotalColumn_For_E.Length - 1).ToString() + ")";
                AllSumSubTotalColumn_For_F = AllSumSubTotalColumn_For_F.Remove(AllSumSubTotalColumn_For_F.Length - 1).ToString() + ")";

                rngSubTotal = Expenditure_sheet2.get_Range(GetExcelColumnName(startCellNo) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 1) + (startRowNo + startCount));
                rngSubTotal.MergeCells = true;
                rngSubTotal.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rngSubTotal.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rngSubTotal.Value = "Total Expenses";

                //rngSubTotal.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                //rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                //rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                //rngSubTotal.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                //rngSubTotal.Font.Size = 10;
                rngSubTotal.Font.Bold = true;

                rngSubTotal = Expenditure_sheet2.get_Range(GetExcelColumnName(startCellNo + 2) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 2) + (startRowNo + startCount));
                rngSubTotal.NumberFormat = "#,##0.00;(#,##0.00)";
                rngSubTotal.Font.Bold = true;
                //rngSubTotal.Value = IsEqualZero(_sumTotalColumn_For_C); //// Commented by ZMS (28-Jun-2018)
                rngSubTotal.Value = IsEqualZero(sheet2_SumSubTotal_C); // Upated by ZMS (28-Jun-2018)

                AllAMountForC -= IsEqual_ReturnZero(rngSubTotal.Value);
                //rngSubTotal.Formula = AllSumSubTotalColumn_For_C;
                if (_sumTotalColumn_For_C == 0)
                {
                    rngSubTotal.Value = "-";
                }

                //rngSubTotal.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                //rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                //rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                //rngSubTotal.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

                rngSubTotal = Expenditure_sheet2.get_Range(GetExcelColumnName(startCellNo + 3) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 3) + (startRowNo + startCount));
                rngSubTotal.NumberFormat = "#,##0.00;(#,##0.00)";
                rngSubTotal.Font.Bold = true;
                //rngSubTotal.Value = IsEqualZero(_sumTotalColumn_For_D);// Commented by ZMS (28-Jun-2018)
                rngSubTotal.Value = IsEqualZero(sheet2_SumSubTotal_D); // Upated by ZMS (28-Jun-2018)
                AllAMountForD += IsEqual_ReturnZero(rngSubTotal.Value); /// Updated by ZMS (21-Jun-2018)
                //rngSubTotal.Formula = AllSumSubTotalColumn_For_D;
                if (_sumTotalColumn_For_D == 0)
                {
                    rngSubTotal.Value = "-";
                }

                rngSubTotal = Expenditure_sheet2.get_Range(GetExcelColumnName(startCellNo + 4) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 4) + (startRowNo + startCount));
                rngSubTotal.NumberFormat = "#,##0.00;(#,##0.00)";
                rngSubTotal.Font.Bold = true;
                //rngSubTotal.Value = IsEqualZero(_sumTotalColumn_For_E);// Commented by ZMS (28-Jun-2018)
                rngSubTotal.Value = IsEqualZero(sheet2_SumSubTotal_E); // Upated by ZMS (28-Jun-2018)
                AllAMountForE += IsEqual_ReturnZero(rngSubTotal.Value); // Upated by ZMS (03-Dec-2018)
                //rngSubTotal.Formula = AllSumSubTotalColumn_For_D;
                if (_sumTotalColumn_For_E == 0)
                {
                    rngSubTotal.Value = "-";
                }

                //rngSubTotal.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                //rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                //rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                //rngSubTotal.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

                lastRowslastColumsAddress = "";//for all boder
                rngSubTotal = Expenditure_sheet2.get_Range(GetExcelColumnName(startCellNo + 5) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 5) + (startRowNo + startCount));
                rngSubTotal.NumberFormat = "#,##0.00;(#,##0.00)";                
                rngSubTotal.HorizontalAlignment = XlHAlign.xlHAlignRight;
                rngSubTotal.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rngSubTotal.Font.Bold = true;
                //rngSubTotal.Value = IsEqualZero(_sumTotalColumn_For_F);// Commented by ZMS (28-Jun-2018)
                rngSubTotal.Value = IsEqualZero(sheet2_SumSubTotal_F); // Upated by ZMS (28-Jun-2018)
                AllAMountForF -= IsEqual_ReturnZero(rngSubTotal.Value);
                //lastRowslastColumsAddress = rngSubTotal.Address;
                //rngSubTotal.Formula = AllSumSubTotalColumn_For_E;
                if (_sumTotalColumn_For_F == 0)
                {
                    rngSubTotal.Value = "-";
                }

                startCount++;

                rngSubTotal = Expenditure_sheet2.get_Range(GetExcelColumnName(startCellNo + 1) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 1) + (startRowNo + startCount));
                rngSubTotal.Value = "Gross Profit / (loss)";
                rngSubTotal.Font.Bold = true;
                rngSubTotal.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rngSubTotal.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rngSubTotal = Expenditure_sheet2.get_Range(GetExcelColumnName(startCellNo + 2) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 2) + (startRowNo + startCount));
                rngSubTotal.NumberFormat = "#,##0.00;(#,##0.00)";
                rngSubTotal.Font.Bold = true;
                rngSubTotal.Value = AllAMountForC;
                if (AllAMountForC == 0)
                {
                    rngSubTotal.Value = "-";
                }
                
                rngSubTotal = Expenditure_sheet2.get_Range(GetExcelColumnName(startCellNo + 3) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 3) + (startRowNo + startCount));
                rngSubTotal.NumberFormat = "#,##0.00;(#,##0.00)";
                rngSubTotal.Font.Bold = true;
                rngSubTotal.Value = AllAMountForD ;
                if (AllAMountForD == 0)
                {
                    rngSubTotal.Value = "-";
                }

                rngSubTotal = Expenditure_sheet2.get_Range(GetExcelColumnName(startCellNo + 4) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 4) + (startRowNo + startCount));
                rngSubTotal.NumberFormat = "#,##0.00;(#,##0.00)";
                rngSubTotal.Font.Bold = true;
                rngSubTotal.Value = AllAMountForE;
                if (AllAMountForE == 0)
                {
                    rngSubTotal.Value = "-";
                }

                rngSubTotal = Expenditure_sheet2.get_Range(GetExcelColumnName(startCellNo + 5) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 5) + (startRowNo + startCount));
                rngSubTotal.NumberFormat = "#,##0.00;(#,##0.00)";
                rngSubTotal.Font.Bold = true;
                //rngSubTotal.Value = AllAMountForF; // Comment By AAM (02_Aug_2018)
                
                // Modified By AAM (02_Aug_2018),Expenditure Gross Profit/Loss>> Closing Bal=OpeningBal+TotalCredit-TotalDebit
                rngSubTotal.Value = AllAMountForC + AllAMountForE - AllAMountForD;
                rngSubTotal.NumberFormat = "#,##0.00;(#,##0.00)";
                rngSubTotal.HorizontalAlignment = XlHAlign.xlHAlignRight;
                rngSubTotal.VerticalAlignment = XlVAlign.xlVAlignCenter;

                if (AllAMountForF == 0)
                {
                    rngSubTotal.Value = "-";
                }
                lastRowslastColumsAddress = rngSubTotal.Address;

                

                rngSubTotal = Expenditure_sheet2.get_Range(GetExcelColumnName(1) + ":" + GetExcelColumnName(7)); // Modified By AAM --> 6 to 7 
                rngSubTotal.EntireColumn.AutoFit();

                #region AllColumnsRowsToBorders
                AllColumn = Expenditure_sheet2.get_Range("A8:" + lastRowslastColumsAddress.Replace("$", "").Trim());
                allBorders = AllColumn.Borders;
                allBorders.LineStyle = Excel.XlLineStyle.xlContinuous;
                allBorders.Weight = 2d;
                #endregion

                #endregion

                #region to Expand Column Width
                Range rng_For_C_column2 = Expenditure_sheet2.get_Range("C:C");
                rng_For_C_column2.ColumnWidth = 25;

                Range rng_For_D_column2 = Expenditure_sheet2.get_Range("D:D");
                rng_For_D_column2.ColumnWidth = 25;

                Range rng_For_E_column2 = Expenditure_sheet2.get_Range("E:E");
                rng_For_E_column2.ColumnWidth = 25;

                Range rng_For_F_column2 = Expenditure_sheet2.get_Range("F:F");
                rng_For_F_column2.ColumnWidth = 25;

                #endregion

                #endregion

                myexcelapp.ActiveWorkbook.Sheets[1].Activate();
                myworkbook.Sheets[1].Activate();

                Expenditure_sheet2.Move(misValue, myworkbook.Sheets[myworkbook.Sheets.Count]);

                myworkbook.SaveAs(FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                myworkbook.Close(true, misValue, misValue);
                myexcelapp.Quit();

                releaseObject(Expenditure_sheet2);
                releaseObject(myworksheet1);
                releaseObject(myworkbook);
                releaseObject(myexcelapp);


                if (!File.Exists(FileName)) return;
                Process.Start(FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

        private string IsEqualZero(object obj)
        {
            if (Convert.ToDouble(obj) == 0)
            {
                return "-";
            }
            return obj.ToString();
        }

        private double IsEqual_ReturnZero(object obj)
        {
            if (Convert.ToString(obj) == "-")
            {
                return 0;
            }
            return Convert.ToDouble(obj);
        }

        private void AddSubTotal(int sheet, string para_TitleName)
        {
            if (sheet == 1)
            {
                #region sheet1
                Range rngSubTotal = myworksheet1.get_Range(GetExcelColumnName(startCellNo) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo) + (startRowNo + startCount));
                rngSubTotal.HorizontalAlignment = XlHAlign.xlHAlignRight;
                rngSubTotal.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rngSubTotal = myworksheet1.get_Range(GetExcelColumnName(startCellNo + 1) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 1) + (startRowNo + startCount));
                rngSubTotal.HorizontalAlignment = XlHAlign.xlHAlignRight;
                rngSubTotal.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rngSubTotal.Value = "Total " + para_TitleName;

                rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Font.Size = 12;
                rngSubTotal.Font.Bold = true;

                rngSubTotal = myworksheet1.get_Range(GetExcelColumnName(startCellNo + 2) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 2) + (startRowNo + startCount));
                rngSubTotal.Value = IsEqualZero(_sumTotalColumn_For_C);
                rngSubTotal.HorizontalAlignment = XlHAlign.xlHAlignRight;
                rngSubTotal.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rngSubTotal.NumberFormat = "#,##0.00;(#,##0.00)";
                rngSubTotal.Font.Size = 12;
                rngSubTotal.Font.Bold = true;

                rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                sheet1_SumSubTotal_C += IsEqual_ReturnZero(rngSubTotal.Value);

                rngSubTotal = myworksheet1.get_Range(GetExcelColumnName(startCellNo + 3) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 3) + (startRowNo + startCount));
                rngSubTotal.Value = IsEqualZero(_sumTotalColumn_For_D);
                rngSubTotal.HorizontalAlignment = XlHAlign.xlHAlignRight;
                rngSubTotal.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rngSubTotal.NumberFormat = "#,##0.00;(#,##0.00)";
                rngSubTotal.Font.Size = 12;
                rngSubTotal.Font.Bold = true;

                rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                sheet1_SumSubTotal_D += IsEqual_ReturnZero(rngSubTotal.Value);
                rngSubTotal.NumberFormat = "#,##0.00;(#,##0.00)";
                rngSubTotal.Font.Size = 12;
                rngSubTotal.Font.Bold = true;

                rngSubTotal = myworksheet1.get_Range(GetExcelColumnName(startCellNo + 4) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 4) + (startRowNo + startCount));
                rngSubTotal.Value = IsEqualZero(_sumTotalColumn_For_E);
                rngSubTotal.HorizontalAlignment = XlHAlign.xlHAlignRight;
                rngSubTotal.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rngSubTotal.NumberFormat = "#,##0.00;(#,##0.00)";
                rngSubTotal.Font.Size = 12;
                rngSubTotal.Font.Bold = true;

                rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                sheet1_SumSubTotal_E += IsEqual_ReturnZero(rngSubTotal.Value);
                rngSubTotal.NumberFormat = "#,##0.00;(#,##0.00)";
                rngSubTotal.Font.Size = 12;
                rngSubTotal.Font.Bold = true;

                rngSubTotal = myworksheet1.get_Range(GetExcelColumnName(startCellNo + 5) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 5) + (startRowNo + startCount));
                rngSubTotal.Value = IsEqualZero(_sumTotalColumn_For_F);
                rngSubTotal.HorizontalAlignment = XlHAlign.xlHAlignRight;
                rngSubTotal.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rngSubTotal.NumberFormat = "#,##0.00;(#,##0.00)";
                rngSubTotal.Font.Size = 12;
                rngSubTotal.Font.Bold = true;

                rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                sheet1_SumSubTotal_F += IsEqual_ReturnZero(rngSubTotal.Value);
                rngSubTotal.NumberFormat = "#,##0.00;(#,##0.00)";
                rngSubTotal.Font.Size = 12;
                rngSubTotal.Font.Bold = true;


                startCount++;
                #endregion
            }
            else if (sheet == 2)
            {
                #region sheet2

                sumTotalColumn_For_C = sumTotalColumn_For_C.Remove(sumTotalColumn_For_C.Length - 1).ToString() + ")";
                sumTotalColumn_For_D = sumTotalColumn_For_D.Remove(sumTotalColumn_For_D.Length - 1).ToString() + ")";
                sumTotalColumn_For_E = sumTotalColumn_For_E.Remove(sumTotalColumn_For_E.Length - 1).ToString() + ")";
                sumTotalColumn_For_F = sumTotalColumn_For_F.Remove(sumTotalColumn_For_F.Length - 1).ToString() + ")";

                Range rngSubTotal = Expenditure_sheet2.get_Range(GetExcelColumnName(startCellNo) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo) + (startRowNo + startCount));
                rngSubTotal.HorizontalAlignment = XlHAlign.xlHAlignRight;
                rngSubTotal.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rngSubTotal = Expenditure_sheet2.get_Range(GetExcelColumnName(startCellNo + 1) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 1) + (startRowNo + startCount));
                rngSubTotal.HorizontalAlignment = XlHAlign.xlHAlignRight;
                rngSubTotal.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rngSubTotal.Value = "Total " + para_TitleName;
                rngSubTotal.Font.Size = 12;
                rngSubTotal.Font.Bold = true;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

                rngSubTotal = Expenditure_sheet2.get_Range(GetExcelColumnName(startCellNo + 2) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 2) + (startRowNo + startCount));
                rngSubTotal.Formula = sumTotalColumn_For_C;
                if (rngSubTotal.Value == 0)
                {
                    rngSubTotal.Value = "-";
                }
                rngSubTotal.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                //_sumTotalColumn_For_C += IsEqual_ReturnZero(rngSubTotal.Value);
                _sumTotalColumn_For_C = IsEqual_ReturnZero(rngSubTotal.Value);//ZMS
                rngSubTotal.HorizontalAlignment = XlHAlign.xlHAlignRight;
                rngSubTotal.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rngSubTotal.Font.Size = 12;
                rngSubTotal.Font.Bold = true;
                sheet2_SumSubTotal_C += _sumTotalColumn_For_C;
                AllSumSubTotalColumn_For_C += rngSubTotal.Address + ", ";

                rngSubTotal = Expenditure_sheet2.get_Range(GetExcelColumnName(startCellNo + 3) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 3) + (startRowNo + startCount));
                rngSubTotal.Formula = sumTotalColumn_For_D;
                if (rngSubTotal.Value == 0)
                {
                    rngSubTotal.Value = "-";
                }
                rngSubTotal.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                _sumTotalColumn_For_D = IsEqual_ReturnZero(rngSubTotal.Value);
                rngSubTotal.HorizontalAlignment = XlHAlign.xlHAlignRight;
                rngSubTotal.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rngSubTotal.Font.Size = 12;
                rngSubTotal.Font.Bold = true;
                //sheet2_SumSubTotal_D += _sumTotalColumn_For_D;
                sheet2_SumSubTotal_D += _sumTotalColumn_For_D;//ZMS
                AllSumSubTotalColumn_For_D += rngSubTotal.Address + ", ";

                // Added By AAM (17-Jan-2018)
                rngSubTotal = Expenditure_sheet2.get_Range(GetExcelColumnName(startCellNo + 4) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 4) + (startRowNo + startCount));
                rngSubTotal.Formula = sumTotalColumn_For_E;
                if (rngSubTotal.Value == 0)
                {
                    rngSubTotal.Value = "-";
                }
                rngSubTotal.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                _sumTotalColumn_For_E = IsEqual_ReturnZero(rngSubTotal.Value);
                rngSubTotal.HorizontalAlignment = XlHAlign.xlHAlignRight;
                rngSubTotal.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rngSubTotal.Font.Size = 12;
                rngSubTotal.Font.Bold = true;
                sheet2_SumSubTotal_E += _sumTotalColumn_For_E;
                AllSumSubTotalColumn_For_E += rngSubTotal.Address + ", ";

                rngSubTotal = Expenditure_sheet2.get_Range(GetExcelColumnName(startCellNo + 5) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 5) + (startRowNo + startCount));
                rngSubTotal.Formula = sumTotalColumn_For_F;
                if (rngSubTotal.Value == 0)
                {
                    rngSubTotal.Value = "-";
                }
                rngSubTotal.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                _sumTotalColumn_For_F = IsEqual_ReturnZero(rngSubTotal.Value);
                rngSubTotal.HorizontalAlignment = XlHAlign.xlHAlignRight;
                rngSubTotal.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rngSubTotal.Font.Size = 12;
                rngSubTotal.Font.Bold = true;
                //sheet2_SumSubTotal_E += _sumTotalColumn_For_E;
                sheet2_SumSubTotal_F += _sumTotalColumn_For_F;//ZMS
                AllSumSubTotalColumn_For_F += rngSubTotal.Address + ", ";

                sumTotalColumn_For_C = "=SUM(";
                sumTotalColumn_For_D = "=SUM(";
                sumTotalColumn_For_E = "=SUM(";
                sumTotalColumn_For_F = "=SUM(";

                startCount++;
                #endregion
            }
        }
    }
}
