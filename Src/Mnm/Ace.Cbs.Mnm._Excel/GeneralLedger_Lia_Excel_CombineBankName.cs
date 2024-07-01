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
    public class GeneralLedger_Lia_Excel_CombineBankName
    {
        public GeneralLedger_Lia_Excel_CombineBankName()
        {

        }
        Excel.Application myexcelapp;
        Excel.Workbook myworkbook;
        Excel.Worksheet myworksheet;
        public DataGridView _dgvCashControlReport = null;
        object misValue = System.Reflection.Missing.Value;  //Miss Value Declaration
        string CounterNo = string.Empty;
        Excel.Worksheet myworksheet2;

        int pageNo = 2;
        int startRowNo = 8;
        int startCellNo = 1;
        string titleName;
        int titleCount = 1;
        int subtitleCount = 1;
        int startCount = 0;
        string sumTotalColumn_For_C = "=SUM(";
        string sumTotalColumn_For_D = "=SUM(";
        string sumTotalColumn_For_E = "=SUM(";
        string sumTotalColumn_For_F = "=SUM(";

        double _sumTotalColumn_For_C = 0;
        double _sumTotalColumn_For_D = 0;
        double _sumTotalColumn_For_E = 0;
        double _sumTotalColumn_For_F = 0;

        private double sheet1_SumSubTotal_C;
        private double sheet1_SumSubTotal_D;
        private double sheet1_SumSubTotal_E;
        private double sheet1_SumSubTotal_F;

        private double sheet2_SumSubTotal_C;
        private double sheet2_SumSubTotal_D;
        private double sheet2_SumSubTotal_E;
        private double sheet2_SumSubTotal_F;

        public string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }

        public void ExportToExcel_General_Ledger(IList<GLMDTO00023> list1, IList<GLMDTO00023> list2, string exportFileName, string bankDesp, string address,
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
                startRowNo = 7;
                startCellNo = 1;
                titleName = string.Empty;
                titleCount = 1;
                subtitleCount = 1;
                startCount = 0;
                sumTotalColumn_For_C = "=SUM(";
                sumTotalColumn_For_D = "=SUM(";
                sumTotalColumn_For_E = "=SUM(";
                sumTotalColumn_For_F = "=SUM(";

                string FileName = Path.GetTempPath() + exportFileName + ".xls";
                FileInfo fileinfo = new FileInfo(@FileName);
                if (fileinfo.Exists)
                {
                    fileinfo.Attributes = FileAttributes.Normal;
                    fileinfo.Delete();
                }

                myworksheet.Select();
                #region Sheet1_Setting
                myworksheet.PageSetup.Orientation = Excel.XlPageOrientation.xlPortrait;
                myworksheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4;
                myworksheet.PageSetup.Zoom = false;
                myworksheet.PageSetup.FitToPagesWide = 1;
                myworksheet.PageSetup.LeftMargin = 0.3;
                myworksheet.PageSetup.RightMargin = 0.3;
                myworkbook.Windows.get_Item(1).DisplayGridlines = false;
                Range range = myworksheet.Cells as Range;
                range.EntireRow.Font.Name = "Calibri";
                range.EntireRow.Font.Size = 11;


                myworksheet.Name = "Assets";
                #endregion
                Range rng01;

                #region Sheet1_Header
                rng01 = myworksheet.get_Range("A1:F1");
                rng01.MergeCells = true;
                rng01.Value = "Pristine Global Finance Company Limited.";
                rng01.Font.Size = 12;
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet.get_Range("A2:F2");
                rng01.MergeCells = true;
                //rng01.Value = bankDesp + " (" + address + ")";
                //rng01.Value = result_Income_sheet1_3Line_Title;
                rng01.Value = "General Ledger Statement";
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet.get_Range("A3:F3");
                rng01.MergeCells = true;
                //rng01.Value = "INCOME ACCOUNT FOR THE MONTH OF " + DateTime.Now.ToString("MMMM").ToUpper() + " " + DateTime.Now.ToString("yyyy");
                rng01.Value = result_Income_sheet1_4Line_Title;
                rng01.Value = "For the month of " + requiredDate.ToString("MMMM") + "' " + requiredDate.ToString("yyyy");
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet.get_Range("A4:F4");
                rng01.MergeCells = true;
                rng01.Value = "ASSETS";
                rng01.Font.Bold = true;
                rng01.Font.Size = 12;
                rng01.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet.get_Range("A1:F3");
                rng01.Font.Bold = true;
                rng01.Font.Size = 12;

                rng01 = myworksheet.get_Range("A5:A6");
                rng01.MergeCells = true;
                rng01.Value = "Sr. " + Environment.NewLine + "No";

                rng01 = myworksheet.get_Range("B5:B6");
                rng01.MergeCells = true;
                rng01.Value = "Assets";

                rng01 = myworksheet.get_Range("C5:C6");
                rng01.MergeCells = true;
                rng01.Value = "Opening " + Environment.NewLine + "Balance";

                rng01 = myworksheet.get_Range("D5:D6");
                rng01.MergeCells = true;
                rng01.Value = "Total Debit " + Environment.NewLine + "for the month";

                rng01 = myworksheet.get_Range("E5:E6");
                rng01.MergeCells = true;
                rng01.Value = "Total Credit " + Environment.NewLine + "for the month";

                rng01 = myworksheet.get_Range("F5:F6");
                rng01.MergeCells = true;
                rng01.Value = "Closing " + Environment.NewLine + "Balance";

                rng01 = myworksheet.get_Range("B:E");
                rng01.ColumnWidth = 18;

                rng01 = myworksheet.get_Range("A5:F6");
                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                //for (int i = 1; i <= 5; i++)
                //{
                //    rng01 = (Range)myworksheet.Cells[7, i];
                //    rng01.Value = i;
                //    rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                //}

                rng01 = myworksheet.get_Range("A5:F6");
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng01.Font.Size = 13;
                rng01.Font.Bold = true;
                #endregion

                #region ForSheet1_Rows_Processing
                double oB = 0;
                double tDFTM = 0;
                double tCFTM = 0;
                double cB = 0;

                titleName = ""; string title_Name = ""; string bank_Name = ""; string bankName = "";
                for (int i = 0; i < list1.Count; i++)
                {
                    title_Name = list1[i].TITLE;
                    bank_Name = getBetween(list1[i].SUBTITLE.ToString(), "(", ")");
                    if (_ReplaceAllString(title_Name) == _ReplaceAllString(titleName))
                    {



                        rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo];
                        rng01.NumberFormat = "0";
                        rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        bankName = getBetween(list1[i].SUBTITLE.ToString(), "(", ")");
                        if (string.IsNullOrEmpty(bankName.Trim()))
                        {
                            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo];
                            rng01.NumberFormat = "0";
                            rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                            string subtitle_Name = list1[i].SUBTITLE;
                            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 1];
                            rng01.Value = subtitle_Name;
                            rng01.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                            rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                            rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 2];
                            //rng01.NumberFormat = "#,##0.00.00";
                            rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                            rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                            rng01.Value = IsEqualZero(list1[i].Opening_bal.ToString());
                            rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                            rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                            _sumTotalColumn_For_C += IsEqual_ReturnZero(rng01.Value);
                            sumTotalColumn_For_C += rng01.Address + ",";

                            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 3];
                            //rng01.NumberFormat = "#,##0.00.00";
                            rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                            rng01.Value = IsEqualZero(list1[i].Debit_Amount.ToString());
                            rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                            rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                            rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                            _sumTotalColumn_For_D += IsEqual_ReturnZero(rng01.Value);
                            sumTotalColumn_For_D += rng01.Address + ",";


                            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 4];
                            //rng01.NumberFormat = "#,##0.00.00";
                            rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                            rng01.Value = IsEqualZero(list1[i].Credit_Amount.ToString());
                            rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                            rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                            rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                            _sumTotalColumn_For_E += IsEqual_ReturnZero(rng01.Value);
                            sumTotalColumn_For_E += rng01.Address + ",";


                            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 5];
                            //rng01.NumberFormat = "#,##0.00.00";
                            rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                            rng01.Value = IsEqualZero(list1[i].Closing_bal.ToString());
                            rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                            rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                            rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                            _sumTotalColumn_For_F += IsEqual_ReturnZero(rng01.Value);
                            sumTotalColumn_For_F += rng01.Address + ",";


                            startCount++;
                        }

                        else if (bankName == bank_Name)
                        {
                            oB += Convert.ToDouble(list1[i].Opening_bal);
                            tDFTM += Convert.ToDouble(list1[i].Debit_Amount);
                            tCFTM += Convert.ToDouble(list1[i].Credit_Amount);
                            cB += Convert.ToDouble(list1[i].Closing_bal);
                        }

                        //else
                        //{

                        //    //string subtitle_Name = list1[i].SUBTITLE;
                        //    int subtitle_Name_End = list1[i].SUBTITLE.ToString().IndexOf(')', 0);
                        //    string subtitle_Name = list1[i].SUBTITLE.ToString().Substring(0, subtitle_Name_End);
                           

                        //    rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 1];
                        //    rng01.Value = subtitle_Name;
                        //    rng01.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                        //    rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        //    rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        //    rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 2];
                        //    //rng01.NumberFormat = "#,##0.00.00";
                        //    rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        //    rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        //    //rng01.Value = IsEqualZero(list1[i].Opening_bal.ToString());
                        //    rng01.Value = IsEqualZero(oB.ToString());
                        //    rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                        //    rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        //    _sumTotalColumn_For_C += IsEqual_ReturnZero(rng01.Value);
                        //    sumTotalColumn_For_C += rng01.Address + ",";

                        //    rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 3];
                        //    //rng01.NumberFormat = "#,##0.00.00";
                        //    rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        //    //rng01.Value = IsEqualZero(list1[i].Debit_Amount.ToString());
                        //    rng01.Value = IsEqualZero(tDFTM.ToString());
                        //    rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                        //    rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        //    rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        //    _sumTotalColumn_For_D += IsEqual_ReturnZero(rng01.Value);
                        //    sumTotalColumn_For_D += rng01.Address + ",";


                        //    rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 4];
                        //    //rng01.NumberFormat = "#,##0.00.00";
                        //    rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        //    //rng01.Value = IsEqualZero(list1[i].Credit_Amount.ToString());
                        //    rng01.Value = IsEqualZero(tCFTM.ToString());
                        //    rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                        //    rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        //    rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        //    _sumTotalColumn_For_E += IsEqual_ReturnZero(rng01.Value);
                        //    sumTotalColumn_For_E += rng01.Address + ",";


                        //    rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 5];
                        //    //rng01.NumberFormat = "#,##0.00.00";
                        //    rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        //    //rng01.Value = IsEqualZero(list1[i].Closing_bal.ToString());
                        //    rng01.Value = IsEqualZero(cB.ToString());
                        //    rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                        //    rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        //    rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        //    _sumTotalColumn_For_F += IsEqual_ReturnZero(rng01.Value);
                        //    sumTotalColumn_For_F += rng01.Address + ",";

                        //    oB = 0;
                        //    tDFTM = 0;
                        //    tCFTM = 0;
                        //    cB = 0;

                        //    oB += Convert.ToDouble(list1[i].Opening_bal);
                        //    tDFTM += Convert.ToDouble(list1[i].Debit_Amount);
                        //    tCFTM += Convert.ToDouble(list1[i].Credit_Amount);
                        //    cB += Convert.ToDouble(list1[i].Closing_bal);

                        //    startCount++;
                        //}
                    }
                    else
                    {

                        if (i > 0)
                        {
                            if (bankName == bank_Name)
                            {
                                //string subtitle_Name = list1[i].SUBTITLE;
                                int subtitle_Name_End = list1[i - 1].SUBTITLE.ToString().IndexOf(')', 0) + 1;
                                string subtitle_Name = list1[i - 1].SUBTITLE.ToString().Substring(0, subtitle_Name_End);


                                rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 1];
                                rng01.Value = subtitle_Name;
                                rng01.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                                rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 2];
                                //rng01.NumberFormat = "#,##0.00.00";
                                rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                                //rng01.Value = IsEqualZero(list1[i].Opening_bal.ToString());
                                rng01.Value = IsEqualZero(oB.ToString());
                                rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                                _sumTotalColumn_For_C += IsEqual_ReturnZero(rng01.Value);
                                sumTotalColumn_For_C += rng01.Address + ",";

                                rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 3];
                                //rng01.NumberFormat = "#,##0.00.00";
                                rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                                //rng01.Value = IsEqualZero(list1[i].Debit_Amount.ToString());
                                rng01.Value = IsEqualZero(tDFTM.ToString());
                                rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                                _sumTotalColumn_For_D += IsEqual_ReturnZero(rng01.Value);
                                sumTotalColumn_For_D += rng01.Address + ",";


                                rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 4];
                                //rng01.NumberFormat = "#,##0.00.00";
                                rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                                //rng01.Value = IsEqualZero(list1[i].Credit_Amount.ToString());
                                rng01.Value = IsEqualZero(tCFTM.ToString());
                                rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                                _sumTotalColumn_For_E += IsEqual_ReturnZero(rng01.Value);
                                sumTotalColumn_For_E += rng01.Address + ",";


                                rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 5];
                                //rng01.NumberFormat = "#,##0.00.00";
                                rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                                //rng01.Value = IsEqualZero(list1[i].Closing_bal.ToString());
                                rng01.Value = IsEqualZero(cB.ToString());
                                rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                                _sumTotalColumn_For_F += IsEqual_ReturnZero(rng01.Value);
                                sumTotalColumn_For_F += rng01.Address + ",";

                                oB = 0;
                                tDFTM = 0;
                                tCFTM = 0;
                                cB = 0;

                                oB += Convert.ToDouble(list1[i].Opening_bal);
                                tDFTM += Convert.ToDouble(list1[i].Debit_Amount);
                                tCFTM += Convert.ToDouble(list1[i].Credit_Amount);
                                cB += Convert.ToDouble(list1[i].Closing_bal);

                                startCount++;

                            }
                            #region AddBlankRow
                            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo];
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
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
                            rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 5];
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

                            startCount++;
                            #endregion
                        }
                        titleName = _ReplaceAllString(list1[i].TITLE);

                        rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo];
                        rng01.NumberFormat = "0";
                        rng01.Value = subtitleCount; subtitleCount++;
                        rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 1];
                        title_Name = list1[i].TITLE;
                        titleCount = Convert.ToInt32(list1[i].ITEM);
                        rng01.Value = title_Name;
                        rng01.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                        rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        rng01.Font.Size = 12;
                        rng01.Font.Bold = true;
                        rng01.Font.Underline = true;


                        rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 2];
                        rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                        rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 3];
                        rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                        rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 4];
                        rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                        rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        rng01 = myworksheet.Cells[startRowNo + startCount, startCellNo + 5];
                        rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                        rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        startCount++;
                    }
                }

                #region AddFooter_ForSheet1

                sumTotalColumn_For_C = sumTotalColumn_For_C.Remove(sumTotalColumn_For_C.Length - 1).ToString() + ")";
                sumTotalColumn_For_D = sumTotalColumn_For_D.Remove(sumTotalColumn_For_D.Length - 1).ToString() + ")";
                sumTotalColumn_For_E = sumTotalColumn_For_E.Remove(sumTotalColumn_For_E.Length - 1).ToString() + ")";
                sumTotalColumn_For_F = sumTotalColumn_For_F.Remove(sumTotalColumn_For_F.Length - 1).ToString() + ")";

                Range rngSubTotal = myworksheet.get_Range(GetExcelColumnName(startCellNo) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 1) + (startRowNo + startCount));
                rngSubTotal.MergeCells = true;
                rngSubTotal.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rngSubTotal.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rngSubTotal.Value = "Total Assets";
                rngSubTotal.Font.Bold = true;

                rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Font.Size = 11;
                rngSubTotal.Font.Bold = true;
                rngSubTotal.Font.Bold = true;

                rngSubTotal = myworksheet.get_Range(GetExcelColumnName(startCellNo + 2) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 2) + (startRowNo + startCount));
                //rngSubTotal.NumberFormat = "#,##0.00.00";
                rngSubTotal.NumberFormat = "#,##0.00;(#,##0.00)";
                rngSubTotal.Value = IsEqualZero(_sumTotalColumn_For_C);
                rngSubTotal.Formula = sumTotalColumn_For_C;
                rngSubTotal.Font.Bold = true;

                rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

                rngSubTotal = myworksheet.get_Range(GetExcelColumnName(startCellNo + 3) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 3) + (startRowNo + startCount));
                //rngSubTotal.NumberFormat = "#,##0.00.00";
                rngSubTotal.NumberFormat = "#,##0.00;(#,##0.00)";
                rngSubTotal.Value = IsEqualZero(_sumTotalColumn_For_D);
                rngSubTotal.Formula = sumTotalColumn_For_D;
                rngSubTotal.Font.Bold = true;

                rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

                rngSubTotal = myworksheet.get_Range(GetExcelColumnName(startCellNo + 4) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 4) + (startRowNo + startCount));
                //rngSubTotal.NumberFormat = "#,##0.00.00";
                rngSubTotal.NumberFormat = "#,##0.00;(#,##0.00)";
                rngSubTotal.Value = IsEqualZero(_sumTotalColumn_For_E);
                rngSubTotal.Formula = sumTotalColumn_For_E;
                rngSubTotal.Font.Bold = true;

                rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

                rngSubTotal = myworksheet.get_Range(GetExcelColumnName(startCellNo + 5) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 5) + (startRowNo + startCount));
                //rngSubTotal.NumberFormat = "#,##0.00.00";
                rngSubTotal.NumberFormat = "#,##0.00;(#,##0.00)";
                rngSubTotal.Value = IsEqualZero(_sumTotalColumn_For_F);
                rngSubTotal.Formula = sumTotalColumn_For_F;
                rngSubTotal.Font.Bold = true;

                rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

                rngSubTotal = myworksheet.get_Range(GetExcelColumnName(1) + ":" + GetExcelColumnName(6));
                rngSubTotal.EntireColumn.AutoFit();

                rngSubTotal = myworksheet.get_Range("A:B");
                rngSubTotal.EntireColumn.AutoFit();

                sumTotalColumn_For_C = "=SUM(";
                sumTotalColumn_For_D = "=SUM(";
                sumTotalColumn_For_E = "=SUM(";
                sumTotalColumn_For_F = "=SUM(";


                #endregion

                #endregion

                _sumTotalColumn_For_C = 0;
                _sumTotalColumn_For_D = 0;
                _sumTotalColumn_For_E = 0;
                _sumTotalColumn_For_F = 0;

                int lastColumn = myworksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Column;
                int lastRow = myworksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;

                rng01 = myworksheet.get_Range("A" + lastRow + ":" + GetExcelColumnName(lastColumn) + lastRow);
                rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

                Range rng_For_C_column = myworksheet.get_Range("C:C");
                rng_For_C_column.ColumnWidth = 20;

                Range rng_For_D_column = myworksheet.get_Range("D:D");
                rng_For_D_column.ColumnWidth = 20;

                Range rng_For_E_column = myworksheet.get_Range("E:E");
                rng_For_E_column.ColumnWidth = 20;

                Range rng_For_F_column = myworksheet.get_Range("F:F");
                rng_For_F_column.ColumnWidth = 20;

                #region Sheet2_Setting
                pageNo = 2;
                startRowNo = 7;
                startCellNo = 1;
                titleName = string.Empty;
                titleCount = 1;
                subtitleCount = 1;
                startCount = 0;
                sumTotalColumn_For_C = "=SUM(";
                sumTotalColumn_For_D = "=SUM(";
                sumTotalColumn_For_E = "=SUM(";
                sumTotalColumn_For_F = "=SUM(";

                myworksheet2 = myworkbook.Worksheets.Add(misValue);
                myworksheet2.Select();
                myworksheet2.PageSetup.Orientation = Excel.XlPageOrientation.xlPortrait;
                myworksheet2.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4;
                myworksheet2.PageSetup.Zoom = false;
                myworksheet2.PageSetup.FitToPagesWide = 1;
                myworksheet2.PageSetup.LeftMargin = 0.3;
                myworksheet2.PageSetup.RightMargin = 0.3;
                myworkbook.Windows.get_Item(1).DisplayGridlines = false;
                range = myworksheet2.Cells as Range;
                range.EntireRow.Font.Name = "Calibri";
                range.EntireRow.Font.Size = 11;

                myworksheet2.Name = "Liabilities";
                #region Sheet2_Header old
                //rng01 = myworksheet2.get_Range("A1:F1");
                //rng01.MergeCells = true;
                //rng01.Value = "Pristine Global Finance Company Limited.";
                //rng01.Font.Size = 12;
                //rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                //rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                //rng01 = myworksheet2.get_Range("A2:F2");
                //rng01.MergeCells = true;
                ////rng01.Value = bankDesp + " (" + address + ")";
                //rng01.Value = result_Income_sheet2_3Line_Title; 
                //rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                //rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                //rng01 = myworksheet2.get_Range("A3:F3");
                //rng01.MergeCells = true;
                ////rng01.Value = "INCOME ACCOUNT FOR THE MONTH OF " + DateTime.Now.ToString("MMMM").ToUpper() + " " + DateTime.Now.ToString("yyyy");
                //rng01.Value = result_Income_sheet2_4Line_Title;
                //rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                //rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;


                //rng01 = myworksheet2.get_Range("A5:F6");
                //rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                //rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                //rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                //rng01.Font.Size = 10;
                //rng01.Font.Bold = true;

                rng01 = myworksheet2.get_Range("A1:F1");
                rng01.MergeCells = true;
                rng01.Value = "Pristine Global Finance Company Limited.";
                rng01.Font.Size = 12;
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet2.get_Range("A2:F2");
                rng01.MergeCells = true;
                //rng01.Value = bankDesp + " (" + address + ")";
                //rng01.Value = result_Income_sheet1_3Line_Title;
                rng01.Value = "General Ledger Statement";
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet2.get_Range("A3:F3");
                rng01.MergeCells = true;
                //rng01.Value = "INCOME ACCOUNT FOR THE MONTH OF " + DateTime.Now.ToString("MMMM").ToUpper() + " " + DateTime.Now.ToString("yyyy");
                rng01.Value = result_Income_sheet1_4Line_Title;
                rng01.Value = "For the month of " + requiredDate.ToString("MMMM") + "' " + requiredDate.ToString("yyyy");
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet2.get_Range("A4:F4");
                rng01.MergeCells = true;
                rng01.Value = "LIABILITIES";
                rng01.Font.Bold = true;
                rng01.Font.Size = 12;
                rng01.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                //rng01 = myworksheet2.get_Range("A1:F1");
                //rng01.MergeCells = true;
                //rng01.Value = "LIABILITIES";
                //rng01.Font.Size = 12;
                //rng01.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                //rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet2.get_Range("A1:F3");
                rng01.Font.Bold = true;
                rng01.Font.Size = 12;

                rng01 = myworksheet2.get_Range("A5:A6");
                rng01.MergeCells = true;
                rng01.Value = "Sr. " + Environment.NewLine + "No";

                rng01 = myworksheet2.get_Range("B5:B6");
                rng01.MergeCells = true;
                rng01.Value = "Liabilities";

                rng01 = myworksheet2.get_Range("C5:C6");
                rng01.MergeCells = true;
                rng01.Value = "Opening " + Environment.NewLine + "Balance";

                rng01 = myworksheet2.get_Range("D5:D6");
                rng01.MergeCells = true;
                rng01.Value = "Total Debit " + Environment.NewLine + "for the month";

                rng01 = myworksheet2.get_Range("E5:E6");
                rng01.MergeCells = true;
                rng01.Value = "Total Credit " + Environment.NewLine + "for the month";

                rng01 = myworksheet2.get_Range("F5:F6");
                rng01.MergeCells = true;
                rng01.Value = "Closing " + Environment.NewLine + "Balance";

                rng01 = myworksheet2.get_Range("A5:F6");
                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng01 = myworksheet2.get_Range("B:F");
                rng01.ColumnWidth = 18;


                rng01 = myworksheet2.get_Range("A5:F6");
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng01.Font.Size = 13;
                rng01.Font.Bold = true;
                rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                #endregion

                #endregion

                #region Sheet2_Processing

                titleName = "";
                for (int i = 0; i < list2.Count; i++)
                {
                    title_Name = list2[i].TITLE;
                    if (_ReplaceAllString(title_Name) == _ReplaceAllString(titleName))
                    {
                        rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo];
                        rng01.NumberFormat = "0";
                        rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        string subtitle_Name = list2[i].SUBTITLE;
                        rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 1];
                        rng01.Value = subtitle_Name;
                        rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

                        rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 2];
                        rng01.Value = list2[i].Opening_bal.ToString().Replace("-", "");
                        //rng01.NumberFormat = "#,##0.00.00";
                        rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                        _sumTotalColumn_For_C += rng01.Value;
                        sumTotalColumn_For_C += rng01.Address + ",";

                        rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 3];
                        rng01.Value = list2[i].Debit_Amount.ToString().Replace("-", "");
                        //rng01.NumberFormat = "#,##0.00.00";
                        rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                        _sumTotalColumn_For_D += rng01.Value;
                        sumTotalColumn_For_D += rng01.Address + ",";

                        rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 4];
                        rng01.Value = list2[i].Credit_Amount.ToString().Replace("-", "");
                        //rng01.NumberFormat = "#,##0.00.00";
                        rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                        _sumTotalColumn_For_E += rng01.Value;
                        sumTotalColumn_For_E += rng01.Address + ",";

                        rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 5];
                        rng01.Value = list2[i].Closing_bal.ToString().Replace("-", "");
                        //rng01.NumberFormat = "#,##0.00.00";
                        rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                        _sumTotalColumn_For_F += rng01.Value;
                        sumTotalColumn_For_F += rng01.Address + ",";
                        startCount++;
                    }
                    else
                    {
                        if (i > 0)
                        {
                            #region AddBlankRow
                            rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo];
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 1];
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 2];
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 3];
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 4];
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 5];
                            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

                            startCount++;
                            #endregion
                        }
                        titleName = _ReplaceAllString(list2[i].TITLE);
                        rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo];
                        rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Value = subtitleCount; subtitleCount++;

                        rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 1];
                        title_Name = list2[i].TITLE;
                        rng01.Value = title_Name;
                        rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Font.Size = 12;
                        rng01.Font.Bold = true;
                        rng01.Font.Underline = true;


                        rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 2];
                        rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                        rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 3];
                        rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                        rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 4];
                        rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                        rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 5];
                        rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

                        startCount++;

                        string subtitle_Name = list2[i].SUBTITLE;
                        rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 1];
                        rng01.Value = subtitle_Name;
                        rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

                        rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 2];
                        rng01.Value = list2[i].Opening_bal.ToString().Replace("-", "");
                        //rng01.NumberFormat = "#,##0.00.00";
                        rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                        _sumTotalColumn_For_C += rng01.Value;
                        sumTotalColumn_For_C += rng01.Address + ",";

                        rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 3];
                        rng01.Value = list2[i].Debit_Amount.ToString().Replace("-", "");
                        //rng01.NumberFormat = "#,##0.00.00";
                        rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                        _sumTotalColumn_For_D += rng01.Value;
                        sumTotalColumn_For_D += rng01.Address + ",";

                        rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 4];
                        rng01.Value = list2[i].Credit_Amount.ToString().Replace("-", "");
                        //rng01.NumberFormat = "#,##0.00.00";
                        rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                        _sumTotalColumn_For_E += rng01.Value;
                        sumTotalColumn_For_E += rng01.Address + ",";

                        rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 5];
                        rng01.Value = list2[i].Closing_bal.ToString().Replace("-", "");
                        //rng01.NumberFormat = "#,##0.00.00";
                        rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                        rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                        _sumTotalColumn_For_F += rng01.Value;
                        sumTotalColumn_For_F += rng01.Address + ",";
                        startCount++;
                    }
                }

                #region AddFooter_ForSheet2

                sumTotalColumn_For_C = sumTotalColumn_For_C.Remove(sumTotalColumn_For_C.Length - 1).ToString() + ")";
                sumTotalColumn_For_D = sumTotalColumn_For_D.Remove(sumTotalColumn_For_D.Length - 1).ToString() + ")";
                sumTotalColumn_For_E = sumTotalColumn_For_E.Remove(sumTotalColumn_For_E.Length - 1).ToString() + ")";
                sumTotalColumn_For_F = sumTotalColumn_For_F.Remove(sumTotalColumn_For_F.Length - 1).ToString() + ")";

                rngSubTotal = myworksheet2.get_Range(GetExcelColumnName(startCellNo) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 1) + (startRowNo + startCount));
                rngSubTotal.MergeCells = true;
                rngSubTotal.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rngSubTotal.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rngSubTotal.Value = "Total Liabilities";
                rngSubTotal.Font.Bold = true;

                rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Font.Size = 11;
                rngSubTotal.Font.Bold = true;
                rngSubTotal.Font.Bold = true;

                rngSubTotal = myworksheet2.get_Range(GetExcelColumnName(startCellNo + 2) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 2) + (startRowNo + startCount));
                //rngSubTotal.NumberFormat = "#,##0.00.00";
                rngSubTotal.NumberFormat = "#,##0.00;(#,##0.00)";
                rngSubTotal.Value = IsEqualZero(_sumTotalColumn_For_C);
                rngSubTotal.Formula = sumTotalColumn_For_C;
                rngSubTotal.Font.Bold = true;

                rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

                rngSubTotal = myworksheet2.get_Range(GetExcelColumnName(startCellNo + 3) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 3) + (startRowNo + startCount));
                //rngSubTotal.NumberFormat = "#,##0.00.00";
                rngSubTotal.NumberFormat = "#,##0.00;(#,##0.00)";
                rngSubTotal.Value = IsEqualZero(_sumTotalColumn_For_D);
                rngSubTotal.Formula = sumTotalColumn_For_D;
                rngSubTotal.Font.Bold = true;

                rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

                rngSubTotal = myworksheet2.get_Range(GetExcelColumnName(startCellNo + 4) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 4) + (startRowNo + startCount));
                //rngSubTotal.NumberFormat = "#,##0.00.00";
                rngSubTotal.NumberFormat = "#,##0.00;(#,##0.00)";
                rngSubTotal.Value = IsEqualZero(_sumTotalColumn_For_E);
                rngSubTotal.Formula = sumTotalColumn_For_E;
                rngSubTotal.Font.Bold = true;

                rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

                rngSubTotal = myworksheet2.get_Range(GetExcelColumnName(startCellNo + 5) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 5) + (startRowNo + startCount));
                //rngSubTotal.NumberFormat = "#,##0.00.00";
                rngSubTotal.NumberFormat = "#,##0.00;(#,##0.00)";
                rngSubTotal.Value = IsEqualZero(_sumTotalColumn_For_F);
                rngSubTotal.Formula = sumTotalColumn_For_F;
                string lastRowslastColumsAddress = "";
                lastRowslastColumsAddress = rngSubTotal.Address;

                rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

                rngSubTotal = myworksheet2.get_Range(GetExcelColumnName(1) + ":" + GetExcelColumnName(6));
                rngSubTotal.EntireColumn.AutoFit();

                rngSubTotal = myworksheet2.get_Range("A:A");
                rngSubTotal.EntireColumn.AutoFit();

                sumTotalColumn_For_C = "=SUM(";
                sumTotalColumn_For_D = "=SUM(";
                sumTotalColumn_For_E = "=SUM(";
                sumTotalColumn_For_F = "=SUM(";


                #endregion

                #endregion

                //rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo];
                //rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                //rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 1];
                //rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                //rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 2];
                //rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                //rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 3];
                //rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                //rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 4];
                //rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                //rng01 = myworksheet2.Cells[startRowNo + startCount, startCellNo + 5];
                //rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;

                #region AllColumnsRowsToBorders
                Range AllColumn = myworksheet2.get_Range("A8:" + lastRowslastColumsAddress.Replace("$", "").Trim());
                Excel.Borders allBorders = AllColumn.Borders;
                allBorders.LineStyle = Excel.XlLineStyle.xlContinuous;
                allBorders.Weight = 2d;
                #endregion

                Range rng_For_C_column2 = myworksheet2.get_Range("C:C");
                rng_For_C_column2.ColumnWidth = 20;

                Range rng_For_D_column2 = myworksheet2.get_Range("D:D");
                rng_For_D_column2.ColumnWidth = 20;

                Range rng_For_E_column2 = myworksheet2.get_Range("E:E");
                rng_For_E_column2.ColumnWidth = 20;

                Range rng_For_F_column2 = myworksheet2.get_Range("F:F");
                rng_For_F_column2.ColumnWidth = 20;

                myexcelapp.ActiveWorkbook.Sheets[1].Activate();
                myworkbook.Sheets[1].Activate();

                myworksheet2.Move(misValue, myworkbook.Sheets[myworkbook.Sheets.Count]);

                myworkbook.SaveAs(FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                myworkbook.Close(true, misValue, misValue);
                myexcelapp.Quit();

                releaseObject(myworksheet2);
                releaseObject(myworksheet);
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
            //rng01.NumberFormat = "#,##0.00.00";
            rng01.NumberFormat = "#,##0.00;(#,##0.00)";
            rng01.Value = "0";
            rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

            rng01 = myworksheet2.Cells[startRowNo + startCount, 3];
            //rng01.NumberFormat = "#,##0.00.00";
            rng01.NumberFormat = "#,##0.00;(#,##0.00)";
            rng01.Value = "0";
            rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

            rng01 = myworksheet2.Cells[startRowNo + startCount, 4];
            //rng01.NumberFormat = "#,##0.00.00";
            rng01.NumberFormat = "#,##0.00;(#,##0.00)";
            rng01.Value = "0";
            rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

            rng01 = myworksheet2.Cells[startRowNo + startCount, 5];
            //rng01.NumberFormat = "#,##0.00.00";
            rng01.NumberFormat = "#,##0.00;(#,##0.00)";
            rng01.Value = "0";
            rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

            startCount++;
            startCount++;

            rng01 = myworksheet2.Cells[startRowNo + startCount, 1];
            //rng01.NumberFormat = "#,##0.00.00";
            rng01.NumberFormat = "#,##0.00;(#,##0.00)";
            rng01.Value = "TOTAL INCOME";
            rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
            rng01.Font.Bold = true;

            rng01 = myworksheet2.Cells[startRowNo + startCount, 2];
            //rng01.NumberFormat = "#,##0.00.00";
            rng01.NumberFormat = "#,##0.00;(#,##0.00)";
            rng01.Value = sheet1_SumSubTotal_C;
            rng01.Font.Color = Color.Red;
            rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

            rng01 = myworksheet2.Cells[startRowNo + startCount, 3];
            //rng01.NumberFormat = "#,##0.00.00";
            rng01.NumberFormat = "#,##0.00;(#,##0.00)";
            rng01.Font.Bold = true;
            rng01.Value = sheet1_SumSubTotal_D;
            rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            _EXPENDITURE_OVER_INCOME_3 = sheet1_SumSubTotal_D;

            rng01 = myworksheet2.Cells[startRowNo + startCount, 4];
            //rng01.NumberFormat = "#,##0.00.00";
            rng01.NumberFormat = "#,##0.00;(#,##0.00)";
            rng01.Value = sheet1_SumSubTotal_E;
            rng01.Font.Bold = true;
            rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            _EXPENDITURE_OVER_INCOME_4 = sheet1_SumSubTotal_E;

            rng01 = myworksheet2.Cells[startRowNo + startCount, 5];
            //rng01.NumberFormat = "#,##0.00.00";
            rng01.NumberFormat = "#,##0.00;(#,##0.00)";
            rng01.Value = sheet1_SumSubTotal_F;
            rng01.Font.Bold = true;
            rng01.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            _EXPENDITURE_OVER_INCOME_5 = sheet1_SumSubTotal_F;

            startCount--;

            rng01 = myworksheet2.Cells[startRowNo + startCount, 1];
            rng01.Value = "EXPENDITURE OVER INCOME";
            rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
            rng01.Font.Bold = true;

            rng01 = myworksheet2.Cells[startRowNo + startCount, 2];
            //rng01.NumberFormat = "#,##0.00.00";
            rng01.NumberFormat = "#,##0.00;(#,##0.00)";
            double result = sheet2_SumSubTotal_C - Convert.ToDouble(myworksheet2.get_Range(GetExcelColumnName(2) + (startRowNo + startCount + 1)).Value);
            rng01.Value = result;
            rng01.Font.Bold = true;
            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            _EXPENDITURE_OVER_INCOME_2 = result;

            rng01 = myworksheet2.Cells[startRowNo + startCount, 3];
            //rng01.NumberFormat = "#,##0.00.00";
            rng01.NumberFormat = "#,##0.00;(#,##0.00)";
            result = sheet1_SumSubTotal_D - Convert.ToDouble(myworksheet2.get_Range(GetExcelColumnName(2) + (startRowNo + startCount + 1)).Value);
            rng01.Value = result;
            rng01.Font.Bold = true;
            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            _EXPENDITURE_OVER_INCOME_3 = result;

            rng01 = myworksheet2.Cells[startRowNo + startCount, 4];
            rng01.NumberFormat ="#,##0.00;(#,##0.00)";
            result = sheet1_SumSubTotal_E - Convert.ToDouble(myworksheet2.get_Range(GetExcelColumnName(2) + (startRowNo + startCount + 1)).Value);
            rng01.Value = result;
            rng01.Font.Bold = true;
            rng01.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            rng01.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            _EXPENDITURE_OVER_INCOME_4 = result;


            rng01 = myworksheet2.Cells[startRowNo + startCount, 5];
            rng01.NumberFormat ="#,##0.00;(#,##0.00)";
            result = sheet1_SumSubTotal_F - Convert.ToDouble(myworksheet2.get_Range(GetExcelColumnName(2) + (startRowNo + startCount + 1)).Value);
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
            rng01.NumberFormat ="#,##0.00;(#,##0.00)";
            rng01.Value = _EXPENDITURE_OVER_INCOME_2;
            rng01.Font.Bold = true;

            //rng01 = myworksheet2.Cells[startRowNo + startCount, 3];
            rng01 = myworksheet2.get_Range(GetExcelColumnName(3) + (startRowNo + startCount) + ":" + GetExcelColumnName(4) + (startRowNo + startCount));
            rng01.MergeCells = true;
            rng01.Value = "   INCOME UP TO " + DateTime.Now.ToString("MMMM").ToUpper() + " " + DateTime.Now.ToString("yyyy");

            rng01 = myworksheet2.Cells[startRowNo + startCount, 5];
            rng01.NumberFormat ="#,##0.00;(#,##0.00)";
            rng01.Value = sheet1_SumSubTotal_C;
            rng01.Font.Bold = true;

            startCount++;

            rng01 = myworksheet2.Cells[startRowNo + startCount, 1];
            rng01.Value = "LOSS UPTO THE MONTH OF " + DateTime.Now.ToString("MMMM").ToUpper() + " " + DateTime.Now.ToString("yyyy");

            rng01 = myworksheet2.Cells[startRowNo + startCount, 2];
            rng01.NumberFormat ="#,##0.00;(#,##0.00)";
            rng01.Value = _EXPENDITURE_OVER_INCOME_4;
            rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            rng01.Font.Bold = true;

            rng01 = myworksheet2.get_Range(GetExcelColumnName(3) + (startRowNo + startCount) + ":" + GetExcelColumnName(4) + (startRowNo + startCount));
            rng01.MergeCells = true;
            rng01.Value = "   EXPENDITURE UP TO " + DateTime.Now.ToString("MMMM").ToUpper() + " " + DateTime.Now.ToString("yyyy");

            rng01 = myworksheet2.Cells[startRowNo + startCount, 5];
            rng01.NumberFormat ="#,##0.00;(#,##0.00)";
            rng01.Value = sheet1_SumSubTotal_F;
            rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            rng01.Font.Bold = true;

            startCount++;

            rng01 = myworksheet2.Cells[startRowNo + startCount, 1];
            rng01.Value = "TOTAL LOSS UPTO THE MONTH (" + DateTime.Now.ToString("MM") + "/" + DateTime.Now.ToString("yyyy") + ")";

            rng01 = myworksheet2.Cells[startRowNo + startCount, 2];
            rng01.NumberFormat ="#,##0.00;(#,##0.00)";
            rng01.Value = _EXPENDITURE_OVER_INCOME_5;
            rng01.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDouble;
            rng01.Font.Bold = true;

            rng01 = myworksheet2.get_Range(GetExcelColumnName(3) + (startRowNo + startCount) + ":" + GetExcelColumnName(4) + (startRowNo + startCount));
            rng01.MergeCells = true;
            rng01.Value = "   NET LOSS UP TO " + DateTime.Now.ToString("MMMM").ToUpper() + " " + DateTime.Now.ToString("yyyy");

            rng01 = myworksheet2.Cells[startRowNo + startCount, 5];
            rng01.NumberFormat ="#,##0.00;(#,##0.00)";
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

        private void AddSubTotal(int sheet)
        {
            if (sheet == 1)
            {
                #region sheet1

                Range rngSubTotal = myworksheet.get_Range(GetExcelColumnName(startCellNo) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo) + (startRowNo + startCount));
                rngSubTotal.HorizontalAlignment = XlHAlign.xlHAlignRight;
                rngSubTotal.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rngSubTotal.Value = "SUB - TOTAL";

                rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Font.Size = 10;
                rngSubTotal.Font.Bold = true;
                rngSubTotal = myworksheet.get_Range(GetExcelColumnName(startCellNo + 1) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 1) + (startRowNo + startCount));
                rngSubTotal.Value = _sumTotalColumn_For_C;

                rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                sheet1_SumSubTotal_C += rngSubTotal.Value;

                rngSubTotal = myworksheet.get_Range(GetExcelColumnName(startCellNo + 2) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 2) + (startRowNo + startCount));
                rngSubTotal.Value = _sumTotalColumn_For_D;

                rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                sheet1_SumSubTotal_D += rngSubTotal.Value;

                rngSubTotal = myworksheet.get_Range(GetExcelColumnName(startCellNo + 3) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 3) + (startRowNo + startCount));
                rngSubTotal.Value = _sumTotalColumn_For_E;

                rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                sheet1_SumSubTotal_E += rngSubTotal.Value;

                rngSubTotal = myworksheet.get_Range(GetExcelColumnName(startCellNo + 4) + (startRowNo + startCount) + ":" + GetExcelColumnName(startCellNo + 4) + (startRowNo + startCount));
                rngSubTotal.Value = _sumTotalColumn_For_F;

                rngSubTotal.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                rngSubTotal.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                sheet1_SumSubTotal_F += rngSubTotal.Value;


                startCount++;
                #endregion
            }
            else if (sheet == 2)
            {
                #region sheet2

                sheet2_SumSubTotal_C += _sumTotalColumn_For_C;
                sheet2_SumSubTotal_D += _sumTotalColumn_For_D;
                sheet2_SumSubTotal_E += _sumTotalColumn_For_E;
                sheet2_SumSubTotal_F += _sumTotalColumn_For_F;

                #endregion
            }
        }
    }
}
