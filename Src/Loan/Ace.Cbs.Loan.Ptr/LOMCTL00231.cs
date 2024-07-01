using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Dmd.DTO;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using Range_Excel = Microsoft.Office.Interop.Excel.Range;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Globalization;
using Ace.Windows.Core;
using System.Drawing;
using System.Windows.Forms;

namespace Ace.Cbs.Loan.Ptr
{
    class LOMCTL00231 : AbstractPresenter, ILOMCTL00231
    {
        private ILOMVEW00231 view;
        public ILOMVEW00231 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00231 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }

        public void ExportToExcel(string rptName, DateTime date, string currency, string sourceBr,decimal curUnits,string curUnitsTitle)
        {
            IList<LOMDTO00228> dtoList = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00228>>(x => x.LOANS_SUMMARY_REPORT_ForBOM(date, currency, sourceBr));
            IList<LOMDTO00229> dtoList_LiveUnLive = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00229>>(x => x.LOANS_SUMMARY_REPORT_ForBOM_LiveUnLive(date, currency, sourceBr));
            this.PrintToExcel(rptName, dtoList, dtoList_LiveUnLive, date, curUnits, curUnitsTitle);
        }

        #region ExcelData
        Excel.Application myexcelapp;
        Excel.Workbook myworkbook;
        Excel.Worksheet myworksheet;
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

        public void PrintToExcel(string exportFileName, IList<LOMDTO00228> dtoList, IList<LOMDTO00229> dtoList_LiveUnLive, DateTime requiredDate, decimal curUnits, string curUnitsTitle)
        {
            object misValue = System.Reflection.Missing.Value;

            myexcelapp = new Excel.Application();
            myworkbook = myexcelapp.Workbooks.Add(misValue);
            myworksheet = myworkbook.Worksheets[1];

            string FileName = Path.GetTempPath() + exportFileName + ".xls";
            FileInfo fileinfo = new FileInfo(@FileName);
            if (fileinfo.Exists)
            {
                fileinfo.Attributes = FileAttributes.Normal;
                fileinfo.Delete();
            }

            string tempFilePath = System.Windows.Forms.Application.StartupPath + "\\pristinelogo.png";
            myworksheet.Shapes.AddPicture(tempFilePath, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 5, 6, 216, 54);
            myworksheet.Select();

            #region Sheet1_Setting
            myworksheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
            myworksheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4;
            myworksheet.PageSetup.Zoom = false;
            myworksheet.PageSetup.FitToPagesWide = 1;
            myworksheet.PageSetup.LeftMargin = 0.3;
            myworksheet.PageSetup.RightMargin = 0.3;
            myworkbook.Windows.get_Item(1).DisplayGridlines = false;
            Range range = myworksheet.Cells as Range;
            range.EntireRow.Font.Name = "Times New Roman";
            range.EntireRow.Font.Size = 12;

            myworksheet.Name = "LiveLoansStatusSummary";
            #endregion

            Range rng01;

            #region Sheet1_Header
            rng01 = myworksheet.get_Range("A1:H1");
            rng01.MergeCells = true;
            rng01.Value = "Pristine Global Finance Company Limited.";
            rng01.Font.Size = 13;
            rng01.EntireRow.Font.Name = "Times New Roman";
            rng01.Font.Bold = true;
            rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

            rng01 = myworksheet.get_Range("A2:H2");
            rng01.MergeCells = true;
            rng01.Value = "Live Loans Status Summary at " + requiredDate.ToString("dd MMMM yyyy");
            rng01.Font.Size = 13;
            rng01.EntireRow.Font.Name = "Times New Roman";
            rng01.Font.Bold = true;
            rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

            rng01 = myworksheet.get_Range("A5:H5");
            rng01.MergeCells = true;
            rng01.Value = curUnitsTitle;
            rng01.Font.Size = 13;
            rng01.EntireRow.Font.Name = "Times New Roman";
            rng01.Font.Bold = true;
            rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
            rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

            rng01 = myworksheet.get_Range("A6:A9");
            rng01.MergeCells = true;
            rng01.WrapText = true;
            rng01.Value = "Sr. No";
            rng01.Font.Size = 12;
            rng01.EntireRow.Font.Name = "Times New Roman";
            rng01.Font.Bold = true;

            rng01 = myworksheet.get_Range("B6:B9");
            rng01.MergeCells = true;
            rng01.Value = "Type Of Loans";
            rng01.Font.Size = 12;
            rng01.EntireRow.Font.Name = "Times New Roman";
            rng01.Font.Bold = true;

            rng01 = myworksheet.get_Range("C6:C9");
            rng01.MergeCells = true;
            rng01.WrapText = true;
            rng01.Value = "Total Live Disbursement Amount";
            rng01.Font.Size = 12;
            rng01.EntireRow.Font.Name = "Times New Roman";
            rng01.Font.Bold = true;

            rng01 = myworksheet.get_Range("D6:D9");
            rng01.MergeCells = true;
            rng01.WrapText = true;
            rng01.Value = "Total Live Interest Income Amount";
            rng01.Font.Size = 12;
            rng01.EntireRow.Font.Name = "Times New Roman";
            rng01.Font.Bold = true;

            rng01 = myworksheet.get_Range("E6:E9");
            rng01.MergeCells = true;
            rng01.WrapText = true;
            rng01.Value = "Total Live Principal Repayment Amount";
            rng01.Font.Size = 12;
            rng01.EntireRow.Font.Name = "Times New Roman";
            rng01.Font.Bold = true;

            rng01 = myworksheet.get_Range("F6:F9");
            rng01.MergeCells = true;
            rng01.WrapText = true;
            rng01.Value = "Total Live Interest Repayment Amount";
            rng01.Font.Size = 12;
            rng01.EntireRow.Font.Name = "Times New Roman";
            rng01.Font.Bold = true;

            rng01 = myworksheet.get_Range("G6:G9");
            rng01.MergeCells = true;
            rng01.WrapText = true;
            rng01.Value = "Total Live Principal Outstanding Amount";
            rng01.Font.Size = 12;
            rng01.EntireRow.Font.Name = "Times New Roman";
            rng01.Font.Bold = true;

            rng01 = myworksheet.get_Range("H6:H9");
            rng01.MergeCells = true;
            rng01.WrapText = true;
            rng01.Value = "Total Live Interest Outstanding Amount";
            rng01.Font.Size = 12;
            rng01.EntireRow.Font.Name = "Times New Roman";
            rng01.Font.Bold = true;

            rng01 = myworksheet.get_Range("A6:H9");
            rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

            rng01 = myworksheet.get_Range("A:A");
            rng01.ColumnWidth = 4;
            
            rng01 = myworksheet.get_Range("B:B");
            rng01.ColumnWidth = 30;

            rng01 = myworksheet.get_Range("C:H");
            rng01.ColumnWidth = 18;

            rng01 = myworksheet.get_Range("A6:H9");
            rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
            #endregion //End of Sheet1_Header

            startRowNo = 10;
            startCount = 0;
            int startCellNo = 1;
            int srNo = 1;

            IList<LOMDTO00228> dtoBLLoansList = dtoList.Where(a => a.LoansGroupCode == "LOAN" && a.LoansSubGroupCode == "BL").ToList();
            IList<LOMDTO00228> dtoSLLoansList = dtoList.Where(a => a.LoansGroupCode == "LOAN" && a.LoansSubGroupCode == "SL").ToList();
            IList<LOMDTO00228> dtoHPLoansList = dtoList.Where(a => a.LoansGroupCode == "HP").ToList();

            #region RowDataForBLLoans
            for (int i = 0; i <dtoBLLoansList.Count; i++)
            {
                rng01 = myworksheet.Cells[startRowNo , startCellNo];
                rng01.NumberFormat = "0";
                rng01.Value = srNo++;
                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                
                rng01 = myworksheet.Cells[startRowNo, startCellNo+1];
                rng01.Value = dtoBLLoansList[i].TypeOfLoans;
                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng01 = myworksheet.Cells[startRowNo, startCellNo+2];
                rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                rng01.Value = dtoBLLoansList[i].TotalLiveDisbusement/curUnits;
                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                
                rng01 = myworksheet.Cells[startRowNo, startCellNo+3];
                rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                rng01.Value = dtoBLLoansList[i].TotalLiveInterestIncome / curUnits;
                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng01 = myworksheet.Cells[startRowNo, startCellNo+4];
                rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                rng01.Value = dtoBLLoansList[i].TotalLivePrincipalRepayment / curUnits;
                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng01 = myworksheet.Cells[startRowNo, startCellNo+5];
                rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                rng01.Value = dtoBLLoansList[i].TotalLiveInterestRepayment / curUnits;
                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng01 = myworksheet.Cells[startRowNo, startCellNo + 6];
                rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                rng01.Value = dtoBLLoansList[i].TotalLivePricipalOutstanding / curUnits;
                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng01 = myworksheet.Cells[startRowNo, startCellNo + 7];
                rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                rng01.Value = dtoBLLoansList[i].TotalLiveInterestOutstanding / curUnits;
                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                startRowNo++;
            }
            #endregion // Endof RowDataForBLLoans

            #region SubTotalForBLLoans
            decimal totalLiveDisAmtBLLoans = dtoBLLoansList.Sum(a => a.TotalLiveDisbusement);
            decimal totalLiveInterestIncomBLLoans = dtoBLLoansList.Sum(a => a.TotalLiveInterestIncome);
            decimal totalLivePrincipalRepayBLLoans = dtoBLLoansList.Sum(a => a.TotalLivePrincipalRepayment);
            decimal totalLiveInterestRepayBLLoans = dtoBLLoansList.Sum(a => a.TotalLiveInterestRepayment);
            decimal totalLivePrincipalOutBLLoans = dtoBLLoansList.Sum(a => a.TotalLivePricipalOutstanding);
            decimal totalLiveInterestOutBLLoans = dtoBLLoansList.Sum(a => a.TotalLiveInterestOutstanding);

            rng01 = myworksheet.get_Range("A" + startRowNo + ":B" + startRowNo); 
            rng01.MergeCells = true;
            rng01.Value = "Total Business Loans";
            rng01.Font.Bold = true;
            rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng01 = myworksheet.Cells[startRowNo, startCellNo + 2];
            rng01.NumberFormat = "#,##0.00;(#,##0.00)";
            rng01.Font.Bold = true;
            rng01.Value = totalLiveDisAmtBLLoans / curUnits;
            rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng01 = myworksheet.Cells[startRowNo, startCellNo + 3];
            rng01.NumberFormat = "#,##0.00;(#,##0.00)";
            rng01.Font.Bold = true;
            rng01.Value = totalLiveInterestIncomBLLoans / curUnits;
            rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng01 = myworksheet.Cells[startRowNo, startCellNo + 4];
            rng01.NumberFormat = "#,##0.00;(#,##0.00)";
            rng01.Font.Bold = true;
            rng01.Value = totalLivePrincipalRepayBLLoans / curUnits;
            rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng01 = myworksheet.Cells[startRowNo, startCellNo + 5];
            rng01.NumberFormat = "#,##0.00;(#,##0.00)";
            rng01.Font.Bold = true;
            rng01.Value = totalLiveInterestRepayBLLoans / curUnits;
            rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng01 = myworksheet.Cells[startRowNo, startCellNo + 6];
            rng01.NumberFormat = "#,##0.00;(#,##0.00)";
            rng01.Font.Bold = true;
            rng01.Value = totalLivePrincipalOutBLLoans / curUnits;
            rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng01 = myworksheet.Cells[startRowNo, startCellNo + 7];
            rng01.NumberFormat = "#,##0.00;(#,##0.00)";
            rng01.Font.Bold = true;
            rng01.Value = totalLiveInterestOutBLLoans / curUnits;
            rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

            startRowNo++;
            #endregion // Endof SubTotalForBLLoans

            #region RowDataForSLLoans
            for (int i = 0; i < dtoSLLoansList.Count; i++)
            {
                rng01 = myworksheet.Cells[startRowNo, startCellNo];
                rng01.NumberFormat = "0";
                rng01.Value = srNo++;
                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet.Cells[startRowNo, startCellNo + 1];
                rng01.Value = dtoSLLoansList[i].TypeOfLoans;
                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng01 = myworksheet.Cells[startRowNo, startCellNo + 2];
                rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                rng01.Value = dtoSLLoansList[i].TotalLiveDisbusement / curUnits;
                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng01 = myworksheet.Cells[startRowNo, startCellNo + 3];
                rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                rng01.Value = dtoSLLoansList[i].TotalLiveInterestIncome / curUnits;
                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng01 = myworksheet.Cells[startRowNo, startCellNo + 4];
                rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                rng01.Value = dtoSLLoansList[i].TotalLivePrincipalRepayment / curUnits;
                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng01 = myworksheet.Cells[startRowNo, startCellNo + 5];
                rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                rng01.Value = dtoSLLoansList[i].TotalLiveInterestRepayment / curUnits;
                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng01 = myworksheet.Cells[startRowNo, startCellNo + 6];
                rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                rng01.Value = dtoSLLoansList[i].TotalLivePricipalOutstanding / curUnits;
                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng01 = myworksheet.Cells[startRowNo, startCellNo + 7];
                rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                rng01.Value = dtoSLLoansList[i].TotalLiveInterestOutstanding / curUnits;
                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                startRowNo++;
            }
            #endregion // Endof RowDataForSLLoans

            #region SubTotalForSLLoans

            decimal totalLiveDisAmtSLLoans = dtoSLLoansList.Sum(a => a.TotalLiveDisbusement);
            decimal totalLiveInterestIncomSLLoans = dtoSLLoansList.Sum(a => a.TotalLiveInterestIncome);
            decimal totalLivePrincipalRepaySLLoans = dtoSLLoansList.Sum(a => a.TotalLivePrincipalRepayment);
            decimal totalLiveInterestRepaySLLoans = dtoSLLoansList.Sum(a => a.TotalLiveInterestRepayment);
            decimal totalLivePrincipalOutSLLoans = dtoSLLoansList.Sum(a => a.TotalLivePricipalOutstanding);
            decimal totalLiveInterestOutSLLoans = dtoSLLoansList.Sum(a => a.TotalLiveInterestOutstanding);

            rng01 = myworksheet.get_Range("A" + startRowNo + ":B" + startRowNo);
            rng01.MergeCells = true;
            rng01.Value = "Total Staff Loans";
            rng01.Font.Bold = true;
            rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng01 = myworksheet.Cells[startRowNo, startCellNo + 2];
            rng01.NumberFormat = "#,##0.00;(#,##0.00)";
            rng01.Font.Bold = true;
            rng01.Value = totalLiveDisAmtSLLoans / curUnits;
            rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng01 = myworksheet.Cells[startRowNo, startCellNo + 3];
            rng01.NumberFormat = "#,##0.00;(#,##0.00)";
            rng01.Font.Bold = true;
            rng01.Value = totalLiveInterestIncomSLLoans / curUnits;
            rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng01 = myworksheet.Cells[startRowNo, startCellNo + 4];
            rng01.NumberFormat = "#,##0.00;(#,##0.00)";
            rng01.Font.Bold = true;
            rng01.Value = totalLivePrincipalRepaySLLoans / curUnits;
            rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng01 = myworksheet.Cells[startRowNo, startCellNo + 5];
            rng01.NumberFormat = "#,##0.00;(#,##0.00)";
            rng01.Font.Bold = true;
            rng01.Value = totalLiveInterestRepaySLLoans / curUnits;
            rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng01 = myworksheet.Cells[startRowNo, startCellNo + 6];
            rng01.NumberFormat = "#,##0.00;(#,##0.00)";
            rng01.Font.Bold = true;
            rng01.Value = totalLivePrincipalOutSLLoans / curUnits;
            rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng01 = myworksheet.Cells[startRowNo, startCellNo + 7];
            rng01.NumberFormat = "#,##0.00;(#,##0.00)";
            rng01.Font.Bold = true;
            rng01.Value = totalLiveInterestOutSLLoans / curUnits;
            rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

            startRowNo++;

            #endregion // Endof SubTotalForSLLoans

            #region RowDataForHPLoans
            for (int i = 0; i < dtoHPLoansList.Count; i++)
            {
                rng01 = myworksheet.Cells[startRowNo, startCellNo];
                rng01.NumberFormat = "0";
                rng01.Value = srNo++;
                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet.Cells[startRowNo, startCellNo + 1];
                rng01.Value = dtoHPLoansList[i].TypeOfLoans;
                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng01 = myworksheet.Cells[startRowNo, startCellNo + 2];
                rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                rng01.Value = dtoHPLoansList[i].TotalLiveDisbusement / curUnits;
                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng01 = myworksheet.Cells[startRowNo, startCellNo + 3];
                rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                rng01.Value = dtoHPLoansList[i].TotalLiveInterestIncome / curUnits;
                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng01 = myworksheet.Cells[startRowNo, startCellNo + 4];
                rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                rng01.Value = dtoHPLoansList[i].TotalLivePrincipalRepayment / curUnits;
                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng01 = myworksheet.Cells[startRowNo, startCellNo + 5];
                rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                rng01.Value = dtoHPLoansList[i].TotalLiveInterestRepayment / curUnits;
                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng01 = myworksheet.Cells[startRowNo, startCellNo + 6];
                rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                rng01.Value = dtoHPLoansList[i].TotalLivePricipalOutstanding / curUnits;
                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng01 = myworksheet.Cells[startRowNo, startCellNo + 7];
                rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                rng01.Value = dtoHPLoansList[i].TotalLiveInterestOutstanding / curUnits;
                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                startRowNo++;
            }
            #endregion // Endof RowDataForHPLoans

            #region SubTotalForHPLoans
            decimal totalLiveDisAmtHPLoans = dtoHPLoansList.Sum(a => a.TotalLiveDisbusement);
            decimal totalLiveInterestIncomHPLoans = dtoHPLoansList.Sum(a => a.TotalLiveInterestIncome);
            decimal totalLivePrincipalRepayHPLoans = dtoHPLoansList.Sum(a => a.TotalLivePrincipalRepayment);
            decimal totalLiveInterestRepayHPLoans = dtoHPLoansList.Sum(a => a.TotalLiveInterestRepayment);
            decimal totalLivePrincipalOutHPLoans = dtoHPLoansList.Sum(a => a.TotalLivePricipalOutstanding);
            decimal totalLiveInterestOutHPLoans = dtoHPLoansList.Sum(a => a.TotalLiveInterestOutstanding);

            rng01 = myworksheet.get_Range("A" + startRowNo + ":B" + startRowNo); 
            rng01.MergeCells = true;
            rng01.Value = "Total HP Loans";
            rng01.Font.Bold = true;
            rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng01 = myworksheet.Cells[startRowNo, startCellNo + 2];
            rng01.NumberFormat = "#,##0.00;(#,##0.00)";
            rng01.Font.Bold = true;
            rng01.Value = totalLiveDisAmtHPLoans / curUnits;
            rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng01 = myworksheet.Cells[startRowNo, startCellNo + 3];
            rng01.NumberFormat = "#,##0.00;(#,##0.00)";
            rng01.Font.Bold = true;
            rng01.Value = totalLiveInterestIncomHPLoans / curUnits;
            rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng01 = myworksheet.Cells[startRowNo, startCellNo + 4];
            rng01.NumberFormat = "#,##0.00;(#,##0.00)";
            rng01.Font.Bold = true;
            rng01.Value = totalLivePrincipalRepayHPLoans / curUnits;
            rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng01 = myworksheet.Cells[startRowNo, startCellNo + 5];
            rng01.NumberFormat = "#,##0.00;(#,##0.00)";
            rng01.Font.Bold = true;
            rng01.Value = totalLiveInterestRepayHPLoans / curUnits;
            rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng01 = myworksheet.Cells[startRowNo, startCellNo + 6];
            rng01.NumberFormat = "#,##0.00;(#,##0.00)";
            rng01.Font.Bold = true;
            rng01.Value = totalLivePrincipalOutHPLoans / curUnits;
            rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng01 = myworksheet.Cells[startRowNo, startCellNo + 7];
            rng01.NumberFormat = "#,##0.00;(#,##0.00)";
            rng01.Font.Bold = true;
            rng01.Value = totalLiveInterestOutHPLoans / curUnits;
            rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

            startRowNo++;

            #endregion // Endof SubTotalForHPLoans

            #region GrandTotalForALLLoans&HP

            decimal totalLoansAndHP_totalLiveDisAmt = dtoList.Sum(a => a.TotalLiveDisbusement);
            decimal totalLoansAndHP_totalLiveIntIncom = dtoList.Sum(a => a.TotalLiveInterestIncome);
            decimal totalLoansAndHP_totalLivePrinRepay = dtoList.Sum(a => a.TotalLivePrincipalRepayment);
            decimal totalLoansAndHP_totalLiveIntRepay = dtoList.Sum(a => a.TotalLiveInterestRepayment);
            decimal totalLoansAndHP_totalLivePrinOut = dtoList.Sum(a => a.TotalLivePricipalOutstanding);
            decimal totalLoansAndHP_totalLiveIntOut = dtoList.Sum(a => a.TotalLiveInterestOutstanding);

            rng01 = myworksheet.get_Range("A" + startRowNo + ":B"+ startRowNo); 
            rng01.MergeCells = true;
            rng01.Value = "Total Loans & HP ";
            rng01.Font.Bold = true;
            rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng01 = myworksheet.Cells[startRowNo, startCellNo + 2];
            rng01.NumberFormat = "#,##0.00;(#,##0.00)";
            rng01.Font.Bold = true;
            rng01.Value = totalLoansAndHP_totalLiveDisAmt / curUnits;
            rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng01 = myworksheet.Cells[startRowNo, startCellNo + 3];
            rng01.NumberFormat = "#,##0.00;(#,##0.00)";
            rng01.Font.Bold = true;
            rng01.Value = totalLoansAndHP_totalLiveIntIncom / curUnits;
            rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng01 = myworksheet.Cells[startRowNo, startCellNo + 4];
            rng01.NumberFormat = "#,##0.00;(#,##0.00)";
            rng01.Font.Bold = true;
            rng01.Value = totalLoansAndHP_totalLivePrinRepay / curUnits;
            rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng01 = myworksheet.Cells[startRowNo, startCellNo + 5];
            rng01.NumberFormat = "#,##0.00;(#,##0.00)";
            rng01.Font.Bold = true;
            rng01.Value = totalLoansAndHP_totalLiveIntRepay / curUnits;
            rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng01 = myworksheet.Cells[startRowNo, startCellNo + 6];
            rng01.NumberFormat = "#,##0.00;(#,##0.00)";
            rng01.Font.Bold = true;
            rng01.Value = totalLoansAndHP_totalLivePrinOut / curUnits;
            rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng01 = myworksheet.Cells[startRowNo, startCellNo + 7];
            rng01.NumberFormat = "#,##0.00;(#,##0.00)";
            rng01.Font.Bold = true;
            rng01.Value = totalLoansAndHP_totalLiveIntOut / curUnits;
            rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

            #endregion // Endof GrandTotalForALLLoans


            /////// Live+Unlive Loans Summary Report ////////
            myworksheet2 = myworkbook.Worksheets.Add(misValue);
            myworksheet2.Shapes.AddPicture(tempFilePath, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 5, 6, 216, 54);
            myworksheet2.Select();

            #region Sheet2_Setting
            myworksheet2.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
            myworksheet2.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperLegal;
            myworksheet2.PageSetup.Zoom = false;
            myworksheet2.PageSetup.FitToPagesWide = 1;
            myworksheet2.PageSetup.LeftMargin = 0.3;
            myworksheet2.PageSetup.RightMargin = 0.3;
            myworkbook.Windows.get_Item(1).DisplayGridlines = false;
            Range range1 = myworksheet2.Cells as Range;
            range1.EntireRow.Font.Name = "Times New Roman";
            range1.EntireRow.Font.Size = 12;

            myworksheet2.Name = "GrandTotalLoansStatusSummary";
            #endregion

            Range rng02;

            #region Sheet2_Header
            rng02 = myworksheet2.get_Range("A1:L1");
            rng02.MergeCells = true;
            rng02.Value = "Pristine Global Finance Company Limited.";
            rng02.Font.Size = 13;
            rng02.EntireRow.Font.Name = "Times New Roman";
            rng02.Font.Bold = true;
            rng02.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rng02.VerticalAlignment = XlVAlign.xlVAlignCenter;

            rng02 = myworksheet2.get_Range("A2:L2");
            rng02.MergeCells = true;
            rng02.Value = "Grand Total Loans Status Summary at " + requiredDate.ToString("dd MMMM yyyy");
            rng02.Font.Size = 13;
            rng02.EntireRow.Font.Name = "Times New Roman";
            rng02.Font.Bold = true;
            rng02.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rng02.VerticalAlignment = XlVAlign.xlVAlignCenter;

            rng02 = myworksheet2.get_Range("A5:L5");
            rng02.MergeCells = true;
            rng02.Value = curUnitsTitle;
            rng02.Font.Size = 13;
            rng02.EntireRow.Font.Name = "Times New Roman";
            rng02.Font.Bold = true;
            rng02.HorizontalAlignment = XlHAlign.xlHAlignRight;
            rng02.VerticalAlignment = XlVAlign.xlVAlignCenter;

            rng02 = myworksheet2.get_Range("A6:A9");
            rng02.MergeCells = true;
            rng02.WrapText = true;
            rng02.Value = "Sr. No";
            rng02.Font.Size = 12;
            rng02.EntireRow.Font.Name = "Times New Roman";
            rng02.Font.Bold = true;

            rng02 = myworksheet2.get_Range("B6:B9");
            rng02.MergeCells = true;
            rng02.WrapText = true;
            rng02.Value = "Type Of Loans";
            rng02.Font.Size = 12;
            rng02.EntireRow.Font.Name = "Times New Roman";
            rng02.Font.Bold = true;

            rng02 = myworksheet2.get_Range("C6:C9");
            rng02.MergeCells = true;
            rng02.WrapText = true;
            rng02.Value = "Grand Total Principal";
            rng02.Font.Size = 12;
            rng02.EntireRow.Font.Name = "Times New Roman";
            rng02.Font.Bold = true;

            rng02 = myworksheet2.get_Range("D6:D9");
            rng02.MergeCells = true;
            rng02.WrapText = true;
            rng02.Value = "Grand Total Interest Income";
            rng02.Font.Size = 12;
            rng02.EntireRow.Font.Name = "Times New Roman";
            rng02.Font.Bold = true;

            rng02 = myworksheet2.get_Range("E6:E9");
            rng02.MergeCells = true;
            rng02.WrapText = true;
            rng02.Value = "Total UnLive Principal";
            rng02.Font.Size = 12;
            rng02.EntireRow.Font.Name = "Times New Roman";
            rng02.Font.Bold = true;

            rng02 = myworksheet2.get_Range("F6:F9");
            rng02.MergeCells = true;
            rng02.WrapText = true;
            rng02.Value = "Total UnLive Interest Income";
            rng02.Font.Size = 12;
            rng02.EntireRow.Font.Name = "Times New Roman";
            rng02.Font.Bold = true;

            rng02 = myworksheet2.get_Range("G6:G9");
            rng02.MergeCells = true;
            rng02.WrapText = true;
            rng02.Value = "Total Live Disbursement Amount";
            rng02.Font.Size = 12;
            rng02.EntireRow.Font.Name = "Times New Roman";
            rng02.Font.Bold = true;

            rng02 = myworksheet2.get_Range("H6:H9");
            rng02.MergeCells = true;
            rng02.WrapText = true;
            rng02.Value = "Total Live Interest Income";
            rng02.Font.Size = 12;
            rng02.EntireRow.Font.Name = "Times New Roman";
            rng02.Font.Bold = true;

            rng02 = myworksheet2.get_Range("I6:I9");
            rng02.MergeCells = true;
            rng02.WrapText = true;
            rng02.Value = "Total Live Principal Repayment Amount";
            rng02.Font.Size = 12;
            rng02.EntireRow.Font.Name = "Times New Roman";
            rng02.Font.Bold = true;

            rng02 = myworksheet2.get_Range("J6:J9");
            rng02.MergeCells = true;
            rng02.WrapText = true;
            rng02.Value = "Total Amount Of Interest Repayment";
            rng02.Font.Size = 12;
            rng02.EntireRow.Font.Name = "Times New Roman";
            rng02.Font.Bold = true;

            rng02 = myworksheet2.get_Range("K6:K9");
            rng02.MergeCells = true;
            rng02.WrapText = true;
            rng02.Value = "Total Amount Of Principal Outstanding";
            rng02.Font.Size = 12;
            rng02.EntireRow.Font.Name = "Times New Roman";
            rng02.Font.Bold = true;

            rng02 = myworksheet2.get_Range("L6:L9");
            rng02.MergeCells = true;
            rng02.WrapText = true;
            rng02.Value = "Total Amount Of Interest Outstanding";
            rng02.Font.Size = 12;
            rng02.EntireRow.Font.Name = "Times New Roman";
            rng02.Font.Bold = true;

            rng02 = myworksheet2.get_Range("A6:L9");
            rng02.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rng02.VerticalAlignment = XlVAlign.xlVAlignCenter;

            rng02 = myworksheet2.get_Range("A:A");
            rng02.ColumnWidth = 4;

            rng02 = myworksheet2.get_Range("B:B");
            rng02.ColumnWidth = 30;

            rng02 = myworksheet2.get_Range("C:L");
            rng02.ColumnWidth = 18;

            rng02 = myworksheet2.get_Range("A6:L9");
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            #endregion //End of Sheet1_Header

            #region Sheet2RowData

            IList<LOMDTO00229> dtoBLLoansListSh2 = dtoList_LiveUnLive.Where(a => a.LoansGroupCode == "LOAN" && a.LoansSubGroupCode == "BL").ToList();
            IList<LOMDTO00229> dtoSLLoansListSh2 = dtoList_LiveUnLive.Where(a => a.LoansGroupCode == "LOAN" && a.LoansSubGroupCode == "SL").ToList();
            IList<LOMDTO00229> dtoHPLoansListSh2 = dtoList_LiveUnLive.Where(a => a.LoansGroupCode == "HP").ToList();

            #region RowDataForBLLoans
            
            startRowNo = 10;
            startCount = 0;
            startCellNo = 1;
            srNo = 1;

            for (int i = 0; i < dtoBLLoansListSh2.Count; i++)
            {
                rng02 = myworksheet2.Cells[startRowNo, startCellNo];
                rng02.NumberFormat = "0";
                rng02.Value = srNo++;
                rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();
                rng02.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng02.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng02 = myworksheet2.Cells[startRowNo, startCellNo + 1];
                rng02.Value = dtoBLLoansListSh2[i].TypeOfLoans;
                rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng02 = myworksheet2.Cells[startRowNo, startCellNo + 2];
                rng02.NumberFormat = "#,##0.00;(#,##0.00)";
                rng02.Value = dtoBLLoansListSh2[i].GrTotalPrinLiveUnlive / curUnits;
                rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng02 = myworksheet2.Cells[startRowNo, startCellNo + 3];
                rng02.NumberFormat = "#,##0.00;(#,##0.00)";
                rng02.Value = dtoBLLoansListSh2[i].GrTotalIntLiveUnlive / curUnits;
                rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng02 = myworksheet2.Cells[startRowNo, startCellNo + 4];
                rng02.NumberFormat = "#,##0.00;(#,##0.00)";
                rng02.Value = dtoBLLoansListSh2[i].TotalUnlivePrin / curUnits;
                rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng02 = myworksheet2.Cells[startRowNo, startCellNo + 5];
                rng02.NumberFormat = "#,##0.00;(#,##0.00)";
                rng02.Value = dtoBLLoansListSh2[i].TotalUnliveInt / curUnits;
                rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng02 = myworksheet2.Cells[startRowNo, startCellNo + 6];
                rng02.NumberFormat = "#,##0.00;(#,##0.00)";
                rng02.Value = dtoBLLoansListSh2[i].TotalLiveDisbusement / curUnits;
                rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng02 = myworksheet2.Cells[startRowNo, startCellNo + 7];
                rng02.NumberFormat = "#,##0.00;(#,##0.00)";
                rng02.Value = dtoBLLoansListSh2[i].TotalLiveInterestIncome / curUnits;
                rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng02 = myworksheet2.Cells[startRowNo, startCellNo + 8];
                rng02.NumberFormat = "#,##0.00;(#,##0.00)";
                rng02.Value = dtoBLLoansListSh2[i].TotalLivePrincipalRepayment / curUnits;
                rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng02 = myworksheet2.Cells[startRowNo, startCellNo + 9];
                rng02.NumberFormat = "#,##0.00;(#,##0.00)";
                rng02.Value = dtoBLLoansListSh2[i].TotalLiveInterestRepayment / curUnits;
                rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng02 = myworksheet2.Cells[startRowNo, startCellNo + 10];
                rng02.NumberFormat = "#,##0.00;(#,##0.00)";
                rng02.Value = dtoBLLoansListSh2[i].TotalLivePricipalOutstanding / curUnits;
                rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng02 = myworksheet2.Cells[startRowNo, startCellNo + 11];
                rng02.NumberFormat = "#,##0.00;(#,##0.00)";
                rng02.Value = dtoBLLoansListSh2[i].TotalLiveInterestOutstanding / curUnits;
                rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

                startRowNo++;
            }
            #endregion // Endof RowDataForBLLoans

            #region SubTotalForBLLoans

            decimal GrTotalPrinLiveUnliveBLSht2 = dtoBLLoansListSh2.Sum(a => a.GrTotalPrinLiveUnlive);
            decimal GrTotalIntLiveUnliveBLSht2 = dtoBLLoansListSh2.Sum(a => a.GrTotalIntLiveUnlive);
            decimal TotalUnlivePrinBLSht2 = dtoBLLoansListSh2.Sum(a => a.TotalUnlivePrin);
            decimal TotalUnliveIntBLSht2 = dtoBLLoansListSh2.Sum(a => a.TotalUnliveInt);

            decimal totalLiveDisAmtBLSht2 = dtoBLLoansListSh2.Sum(a => a.TotalLiveDisbusement);
            decimal totalLiveIntIncBLSht2 = dtoBLLoansListSh2.Sum(a => a.TotalLiveInterestIncome);
            decimal totalLivePrinRepayBLSht2 = dtoBLLoansListSh2.Sum(a => a.TotalLivePrincipalRepayment);
            decimal totalLiveIntRepayBLSht2 = dtoBLLoansListSh2.Sum(a => a.TotalLiveInterestRepayment);
            decimal totalLivePrinOutBLSht2 = dtoBLLoansListSh2.Sum(a => a.TotalLivePricipalOutstanding);
            decimal totalLiveIntOutBLSht2 = dtoBLLoansListSh2.Sum(a => a.TotalLiveInterestOutstanding);

            rng02 = myworksheet2.get_Range("A" + startRowNo + ":B" + startRowNo);
            rng02.MergeCells = true;
            rng02.Value = "Total Business Loans";
            rng02.Font.Bold = true;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 2];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = GrTotalPrinLiveUnliveBLSht2 / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 3];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = GrTotalIntLiveUnliveBLSht2 / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 4];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = TotalUnlivePrinBLSht2 / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 5];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = TotalUnliveIntBLSht2 / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 6];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = totalLiveDisAmtBLSht2 / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 7];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = totalLiveIntIncBLSht2 / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 8];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = totalLivePrinRepayBLSht2 / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 9];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = totalLiveIntRepayBLSht2 / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 10];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = totalLivePrinOutBLSht2 / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 11];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = totalLiveIntOutBLSht2 / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            startRowNo++;
            #endregion // Endof SubTotalForBLLoans

            #region RowDataForSLLoans

            for (int i = 0; i < dtoSLLoansListSh2.Count; i++)
            {
                rng02 = myworksheet2.Cells[startRowNo, startCellNo];
                rng02.NumberFormat = "0";
                rng02.Value = srNo++;
                rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();
                rng02.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng02.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng02 = myworksheet2.Cells[startRowNo, startCellNo + 1];
                rng02.Value = dtoSLLoansListSh2[i].TypeOfLoans;
                rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng02 = myworksheet2.Cells[startRowNo, startCellNo + 2];
                rng02.NumberFormat = "#,##0.00;(#,##0.00)";
                rng02.Value = dtoSLLoansListSh2[i].GrTotalPrinLiveUnlive / curUnits;
                rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng02 = myworksheet2.Cells[startRowNo, startCellNo + 3];
                rng02.NumberFormat = "#,##0.00;(#,##0.00)";
                rng02.Value = dtoSLLoansListSh2[i].GrTotalIntLiveUnlive / curUnits;
                rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng02 = myworksheet2.Cells[startRowNo, startCellNo + 4];
                rng02.NumberFormat = "#,##0.00;(#,##0.00)";
                rng02.Value = dtoSLLoansListSh2[i].TotalUnlivePrin / curUnits;
                rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng02 = myworksheet2.Cells[startRowNo, startCellNo + 5];
                rng02.NumberFormat = "#,##0.00;(#,##0.00)";
                rng02.Value = dtoSLLoansListSh2[i].TotalUnliveInt / curUnits;
                rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng02 = myworksheet2.Cells[startRowNo, startCellNo + 6];
                rng02.NumberFormat = "#,##0.00;(#,##0.00)";
                rng02.Value = dtoSLLoansListSh2[i].TotalLiveDisbusement / curUnits;
                rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng02 = myworksheet2.Cells[startRowNo, startCellNo + 7];
                rng02.NumberFormat = "#,##0.00;(#,##0.00)";
                rng02.Value = dtoSLLoansListSh2[i].TotalLiveInterestIncome / curUnits;
                rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng02 = myworksheet2.Cells[startRowNo, startCellNo + 8];
                rng02.NumberFormat = "#,##0.00;(#,##0.00)";
                rng02.Value = dtoSLLoansListSh2[i].TotalLivePrincipalRepayment / curUnits;
                rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng02 = myworksheet2.Cells[startRowNo, startCellNo + 9];
                rng02.NumberFormat = "#,##0.00;(#,##0.00)";
                rng02.Value = dtoSLLoansListSh2[i].TotalLiveInterestRepayment / curUnits;
                rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng02 = myworksheet2.Cells[startRowNo, startCellNo + 10];
                rng02.NumberFormat = "#,##0.00;(#,##0.00)";
                rng02.Value = dtoSLLoansListSh2[i].TotalLivePricipalOutstanding / curUnits;
                rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng02 = myworksheet2.Cells[startRowNo, startCellNo + 11];
                rng02.NumberFormat = "#,##0.00;(#,##0.00)";
                rng02.Value = dtoSLLoansListSh2[i].TotalLiveInterestOutstanding / curUnits;
                rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

                startRowNo++;
            }
            #endregion // Endof RowDataForSLLoans

            #region SubTotalForSLLoans

            decimal GrTotalPrinLiveUnliveSLSht2 = dtoSLLoansListSh2.Sum(a => a.GrTotalPrinLiveUnlive);
            decimal GrTotalIntLiveUnliveSLSht2 = dtoSLLoansListSh2.Sum(a => a.GrTotalIntLiveUnlive);
            decimal TotalUnlivePrinSLSht2 = dtoSLLoansListSh2.Sum(a => a.TotalUnlivePrin);
            decimal TotalUnliveIntSLSht2 = dtoSLLoansListSh2.Sum(a => a.TotalUnliveInt);

            decimal totalLiveDisAmtSLSht2 = dtoSLLoansListSh2.Sum(a => a.TotalLiveDisbusement);
            decimal totalLiveIntIncSLSht2 = dtoSLLoansListSh2.Sum(a => a.TotalLiveInterestIncome);
            decimal totalLivePrinRepaySLSht2 = dtoSLLoansListSh2.Sum(a => a.TotalLivePrincipalRepayment);
            decimal totalLiveIntRepaySLSht2 = dtoSLLoansListSh2.Sum(a => a.TotalLiveInterestRepayment);
            decimal totalLivePrinOutSLSht2 = dtoSLLoansListSh2.Sum(a => a.TotalLivePricipalOutstanding);
            decimal totalLiveIntOutSLSht2 = dtoSLLoansListSh2.Sum(a => a.TotalLiveInterestOutstanding);

            rng02 = myworksheet2.get_Range("A" + startRowNo + ":B" + startRowNo);
            rng02.MergeCells = true;
            rng02.Value = "Total Staff Loans";
            rng02.Font.Bold = true;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 2];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = GrTotalPrinLiveUnliveSLSht2 / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 3];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = GrTotalIntLiveUnliveSLSht2 / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 4];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = TotalUnlivePrinSLSht2 / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 5];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = TotalUnliveIntSLSht2 / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 6];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = totalLiveDisAmtSLSht2 / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 7];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = totalLiveIntIncSLSht2 / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 8];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = totalLivePrinRepaySLSht2 / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 9];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = totalLiveIntRepaySLSht2 / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 10];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = totalLivePrinOutSLSht2 / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 11];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = totalLiveIntOutSLSht2 / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            startRowNo++;
            #endregion // Endof SubTotalForSLLoans

            #region RowDataForHPLoans

            for (int i = 0; i < dtoHPLoansListSh2.Count; i++)
            {
                rng02 = myworksheet2.Cells[startRowNo, startCellNo];
                rng02.NumberFormat = "0";
                rng02.Value = srNo++;
                rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();
                rng02.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng02.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng02 = myworksheet2.Cells[startRowNo, startCellNo + 1];
                rng02.Value = dtoHPLoansListSh2[i].TypeOfLoans;
                rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng02 = myworksheet2.Cells[startRowNo, startCellNo + 2];
                rng02.NumberFormat = "#,##0.00;(#,##0.00)";
                rng02.Value = dtoHPLoansListSh2[i].GrTotalPrinLiveUnlive / curUnits;
                rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng02 = myworksheet2.Cells[startRowNo, startCellNo + 3];
                rng02.NumberFormat = "#,##0.00;(#,##0.00)";
                rng02.Value = dtoHPLoansListSh2[i].GrTotalIntLiveUnlive / curUnits;
                rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng02 = myworksheet2.Cells[startRowNo, startCellNo + 4];
                rng02.NumberFormat = "#,##0.00;(#,##0.00)";
                rng02.Value = dtoHPLoansListSh2[i].TotalUnlivePrin / curUnits;
                rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng02 = myworksheet2.Cells[startRowNo, startCellNo + 5];
                rng02.NumberFormat = "#,##0.00;(#,##0.00)";
                rng02.Value = dtoHPLoansListSh2[i].TotalUnliveInt / curUnits;
                rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng02 = myworksheet2.Cells[startRowNo, startCellNo + 6];
                rng02.NumberFormat = "#,##0.00;(#,##0.00)";
                rng02.Value = dtoHPLoansListSh2[i].TotalLiveDisbusement / curUnits;
                rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng02 = myworksheet2.Cells[startRowNo, startCellNo + 7];
                rng02.NumberFormat = "#,##0.00;(#,##0.00)";
                rng02.Value = dtoHPLoansListSh2[i].TotalLiveInterestIncome / curUnits;
                rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng02 = myworksheet2.Cells[startRowNo, startCellNo + 8];
                rng02.NumberFormat = "#,##0.00;(#,##0.00)";
                rng02.Value = dtoHPLoansListSh2[i].TotalLivePrincipalRepayment / curUnits;
                rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng02 = myworksheet2.Cells[startRowNo, startCellNo + 9];
                rng02.NumberFormat = "#,##0.00;(#,##0.00)";
                rng02.Value = dtoHPLoansListSh2[i].TotalLiveInterestRepayment / curUnits;
                rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng02 = myworksheet2.Cells[startRowNo, startCellNo + 10];
                rng02.NumberFormat = "#,##0.00;(#,##0.00)";
                rng02.Value = dtoHPLoansListSh2[i].TotalLivePricipalOutstanding / curUnits;
                rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

                rng02 = myworksheet2.Cells[startRowNo, startCellNo + 11];
                rng02.NumberFormat = "#,##0.00;(#,##0.00)";
                rng02.Value = dtoHPLoansListSh2[i].TotalLiveInterestOutstanding / curUnits;
                rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

                startRowNo++;
            }
            #endregion // Endof RowDataForHPLoans

            #region SubTotalForHPLoans

            decimal GrTotalPrinLiveUnliveHPSht2 = dtoHPLoansListSh2.Sum(a => a.GrTotalPrinLiveUnlive);
            decimal GrTotalIntLiveUnliveHPSht2 = dtoHPLoansListSh2.Sum(a => a.GrTotalIntLiveUnlive);
            decimal TotalUnlivePrinHPSht2 = dtoHPLoansListSh2.Sum(a => a.TotalUnlivePrin);
            decimal TotalUnliveIntHPSht2 = dtoHPLoansListSh2.Sum(a => a.TotalUnliveInt);

            decimal totalLiveDisAmtHPSht2 = dtoHPLoansListSh2.Sum(a => a.TotalLiveDisbusement);
            decimal totalLiveIntIncHPSht2 = dtoHPLoansListSh2.Sum(a => a.TotalLiveInterestIncome);
            decimal totalLivePrinRepayHPSht2 = dtoHPLoansListSh2.Sum(a => a.TotalLivePrincipalRepayment);
            decimal totalLiveIntRepayHPSht2 = dtoHPLoansListSh2.Sum(a => a.TotalLiveInterestRepayment);
            decimal totalLivePrinOutHPSht2 = dtoHPLoansListSh2.Sum(a => a.TotalLivePricipalOutstanding);
            decimal totalLiveIntOutHPSht2 = dtoHPLoansListSh2.Sum(a => a.TotalLiveInterestOutstanding);

            rng02 = myworksheet2.get_Range("A" + startRowNo + ":B" + startRowNo);
            rng02.MergeCells = true;
            rng02.Value = "Total HP Loans";
            rng02.Font.Bold = true;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 2];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = GrTotalPrinLiveUnliveHPSht2 / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 3];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = GrTotalIntLiveUnliveHPSht2 / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 4];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = TotalUnlivePrinHPSht2 / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 5];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = TotalUnliveIntHPSht2 / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 6];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = totalLiveDisAmtHPSht2 / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 7];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = totalLiveIntIncHPSht2 / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 8];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = totalLivePrinRepayHPSht2 / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 9];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = totalLiveIntRepayHPSht2 / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 10];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = totalLivePrinOutHPSht2 / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 11];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = totalLiveIntOutHPSht2 / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            startRowNo++;

            #endregion // Endof SubTotalForHPLoans

            #region GrandTotalForALLLoans&HP

            decimal GrTotalSht2_grtotalPrinLiveUnlive = dtoList_LiveUnLive.Sum(a => a.GrTotalPrinLiveUnlive);
            decimal GrTotalSht2_grtotalIntLiveUnlive = dtoList_LiveUnLive.Sum(a => a.GrTotalIntLiveUnlive);
            decimal GrTotalSht2_totalUnlivePrin = dtoList_LiveUnLive.Sum(a => a.TotalUnlivePrin);
            decimal GrTotalSht2_totalUnliveInt = dtoList_LiveUnLive.Sum(a => a.TotalUnliveInt);

            decimal GrTotalSht2_totalLiveDisAmt = dtoList_LiveUnLive.Sum(a => a.TotalLiveDisbusement);
            decimal GrTotalSht2_totalLiveIntIncom = dtoList_LiveUnLive.Sum(a => a.TotalLiveInterestIncome);
            decimal GrTotalSht2_totalLivePrinRepay = dtoList_LiveUnLive.Sum(a => a.TotalLivePrincipalRepayment);
            decimal GrTotalSht2_totalLiveIntRepay = dtoList_LiveUnLive.Sum(a => a.TotalLiveInterestRepayment);
            decimal GrTotalSht2_totalLivePrinOut = dtoList_LiveUnLive.Sum(a => a.TotalLivePricipalOutstanding);
            decimal GrTotalSht2_totalLiveIntOut = dtoList_LiveUnLive.Sum(a => a.TotalLiveInterestOutstanding);

            rng02 = myworksheet2.get_Range("A" + startRowNo + ":B" + startRowNo);
            rng02.MergeCells = true;
            rng02.Value = "Total Loans & HP ";
            rng02.Font.Bold = true;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 2];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = GrTotalSht2_grtotalPrinLiveUnlive / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 3];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = GrTotalSht2_grtotalIntLiveUnlive / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 4];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = GrTotalSht2_totalUnlivePrin / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 5];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = GrTotalSht2_totalUnliveInt / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 6];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = GrTotalSht2_totalLiveDisAmt / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 7];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = GrTotalSht2_totalLiveIntIncom / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 8];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = GrTotalSht2_totalLivePrinRepay / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 9];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = GrTotalSht2_totalLiveIntRepay / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 10];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = GrTotalSht2_totalLivePrinOut / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            rng02 = myworksheet2.Cells[startRowNo, startCellNo + 11];
            rng02.NumberFormat = "#,##0.00;(#,##0.00)";
            rng02.Font.Bold = true;
            rng02.Value = GrTotalSht2_totalLiveIntOut / curUnits;
            rng02.Borders.Color = System.Drawing.Color.Black.ToArgb();

            #endregion // Endof GrandTotalForALLLoans

            #endregion //End of Sheet2RowData

            // End of Live+Unlive Loans Summary Report

            myexcelapp.ActiveWorkbook.Sheets[1].Activate();
            myworkbook.Sheets[1].Activate();

            myworkbook.SaveAs(FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            myworkbook.Close(true, misValue, misValue);
            myexcelapp.Quit();

            releaseObject(myworksheet);
            releaseObject(myworkbook);
            releaseObject(myexcelapp);
            releaseObject(myworksheet2);

            if (!File.Exists(FileName)) return;
            Process.Start(FileName);

        #endregion // End of ExcelData
        
        }//End of Method PrintToExcel

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
                //MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
