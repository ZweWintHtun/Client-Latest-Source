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
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
using System.Windows.Forms;
///////////
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using Range_Excel = Microsoft.Office.Interop.Excel.Range;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Globalization;
using Ace.Windows.Core;
using System.Drawing;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00238 : AbstractPresenter, ILOMCTL00238
    {
        public string showDate;
        public string searchFilter;
        public string transType;
        public string orderBy;

        private ILOMVEW00240 view;
        public ILOMVEW00240 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00240 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }

        public IList<LOMDTO00238> Get_COA_Lists(string sourceBr)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00238>>(x => x.Get_COA_Lists(sourceBr));
        }

        public string Importing_Deposit_Voucher(string acWithOtherBnk, List<LOMDTO00238> lstImportData, string eno, int createdUserId
                                                , string sourceBr,string narration)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00096, string>(x => x.Importing_Deposit_Voucher(acWithOtherBnk, lstImportData, eno
                                                                            , createdUserId, sourceBr, narration));
        }

        public IList<LOMDTO00244> CheckAccountForAccountClosed(string acctNo,string sourceBr)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00244>>(x => x.CheckAccountForAccountClosed(acctNo,sourceBr));
        }

        public IList<LOMDTO00244> GetAccountInfoForAccountClosed(string acctNo, string sourceBr)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00244>>(x => x.GetAccountInfoForAccountClosed(acctNo,sourceBr));
        }

        public string Save_AccountClosed(LOMDTO00244 dto)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00096, string>(x => x.Save_AccountClosed(dto));
        }

        public IList<LOMDTO00244> AccountClosedListing(LOMDTO00244 dto)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00244>>(x => x.AccountClosedListing(dto));
        }

        public void ExportToExcel(LOMDTO00244 dto)
        {
            IList<LOMDTO00244> dtoList = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00244>>(x => x.AccountClosedListing(dto));

            if (dtoList.Count > 0)
            {
                string str = "";
                //if (dto.ACTypeFilter=="0")
                //{
                //    str="Account Closed Listing (By All)";
                //}
                if (dto.ACTypeFilter == "0")
                {
                    str = "Account Closed Listing (By Business Loans)";
                }
                else if (dto.ACTypeFilter == "1")
                {
                    str = "Account Closed Listing (By Hire Purchase)";
                }
                else if (dto.ACTypeFilter == "2")
                {
                    str = "Account Closed Listing (By Personal Loans)";
                }
                else str = "Account Closed Listing (All)"; ///0

                this.PrintToExcel(dtoList, dto.StartDate, dto.EndDate, str, dto.NAME, dto.Currency);
            }
            else
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data for Report.
            }
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

        public void PrintHeaderLine()
        {
            Range rng01;
            rng01 = myworksheet.get_Range("A13:A14");
            rng01.MergeCells = true;
            rng01.WrapText = true;
            rng01.Value = "Sr. No";
            rng01.Font.Size = 12;
            rng01.EntireRow.Font.Name = "Times New Roman";
            rng01.Font.Bold = true;

            rng01 = myworksheet.get_Range("B13:C14");
            rng01.MergeCells = true;
            rng01.Value = "Account No";
            rng01.Font.Size = 12;
            rng01.EntireRow.Font.Name = "Times New Roman";
            rng01.Font.Bold = true;

            rng01 = myworksheet.get_Range("D13:D14");
            rng01.MergeCells = true;
            rng01.WrapText = true;
            rng01.Value = "Name";
            rng01.Font.Size = 12;
            rng01.EntireRow.Font.Name = "Times New Roman";
            rng01.Font.Bold = true;

            rng01 = myworksheet.get_Range("E13:E14");
            rng01.MergeCells = true;
            rng01.WrapText = true;
            rng01.Value = "NRC";
            rng01.Font.Size = 12;
            rng01.EntireRow.Font.Name = "Times New Roman";
            rng01.Font.Bold = true;

            rng01 = myworksheet.get_Range("F13:F14");
            rng01.MergeCells = true;
            rng01.WrapText = true;
            rng01.Value = "Closed Date";
            rng01.Font.Size = 12;
            rng01.EntireRow.Font.Name = "Times New Roman";
            rng01.Font.Bold = true;
            rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

            rng01 = myworksheet.get_Range("G13:G14");
            rng01.MergeCells = true;
            rng01.WrapText = true;
            rng01.Value = "Balance";
            rng01.Font.Size = 12;
            rng01.EntireRow.Font.Name = "Times New Roman";
            rng01.Font.Bold = true;

            rng01 = myworksheet.get_Range("A12:G14");
            rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

            rng01 = myworksheet.get_Range("A12:G12");
            rng01.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

            rng01 = myworksheet.get_Range("F10:G10");
            rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
            rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

            rng01 = myworksheet.get_Range("F13:F14");
            rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

            rng01 = myworksheet.get_Range("A:A");
            rng01.ColumnWidth = 4;

            rng01 = myworksheet.get_Range("B:B");
            rng01.ColumnWidth = 10;

            rng01 = myworksheet.get_Range("C:C");
            rng01.ColumnWidth = 8;

            rng01 = myworksheet.get_Range("F:G");
            rng01.ColumnWidth = 18;

            rng01 = myworksheet.get_Range("D:E");
            rng01.ColumnWidth = 30;

            rng01 = myworksheet.get_Range("A12:G15");
            rng01.Borders.Color = System.Drawing.Color.Black.ToArgb(); 
        }
        
        public void PrintToExcel(IList<LOMDTO00244> dtoList,DateTime startDate,DateTime endDate,string rptTitle,string branch,string cur)
        {
            try
            {
                object misValue = System.Reflection.Missing.Value;

                myexcelapp = new Excel.Application();
                myworkbook = myexcelapp.Workbooks.Add(misValue);
                myworksheet = myworkbook.Worksheets[1];

                string FileName = Path.GetTempPath() + "AccountClosedListing" + ".xls";
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

                myworksheet.Name = "AccountClosedListing";
                #endregion

                Range rng01;

                #region Sheet1_Header
                rng01 = myworksheet.get_Range("A1:I1");
                rng01.MergeCells = true;
                rng01.Value = "Pristine Global Finance Company Limited.";
                rng01.Font.Size = 13;
                rng01.EntireRow.Font.Name = "Times New Roman";
                rng01.Font.Bold = true;
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet.get_Range("A2:I2");
                rng01.MergeCells = true;
                rng01.Value = "No.56, Grd Fl, Room 104, Maha Land Bld";
                rng01.Font.Size = 13;
                rng01.EntireRow.Font.Name = "Times New Roman";
                rng01.Font.Bold = true;
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet.get_Range("A3:I3");
                rng01.MergeCells = true;
                rng01.Value = "Ph : +95 1 9669 589";
                rng01.Font.Size = 13;
                rng01.EntireRow.Font.Name = "Times New Roman";
                rng01.Font.Bold = true;
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet.get_Range("A4:I4");
                rng01.MergeCells = true;
                rng01.Value = "Fax : +95 1 9669 556";
                rng01.Font.Size = 13;
                rng01.EntireRow.Font.Name = "Times New Roman";
                rng01.Font.Bold = true;
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet.get_Range("A6:I6");
                rng01.MergeCells = true;
                rng01.Value = rptTitle;
                rng01.Font.Size = 13;
                rng01.EntireRow.Font.Name = "Times New Roman";
                rng01.Font.Bold = true;
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet.get_Range("A7:I7");
                rng01.MergeCells = true;
                rng01.Value = "From " + startDate.ToString("dd/MM/yyyy") + " To " + endDate.ToString("dd/MM/yyyy");
                rng01.Font.Size = 12;
                rng01.EntireRow.Font.Name = "Times New Roman";
                rng01.Font.Bold = false;
                rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet.get_Range("A9:B9");
                rng01.MergeCells = true;
                rng01.WrapText = true;
                rng01.Value = "Branch";
                rng01.Font.Size = 12;
                rng01.EntireRow.Font.Name = "Times New Roman";
                rng01.Font.Bold = true;

                rng01 = myworksheet.get_Range("C9:D9");
                rng01.MergeCells = true;
                rng01.WrapText = true;
                rng01.Value = branch;
                rng01.Font.Size = 12;
                rng01.EntireRow.Font.Name = "Times New Roman";
                rng01.Font.Bold = true;

                rng01 = myworksheet.get_Range("A10:B10");
                rng01.MergeCells = true;
                rng01.WrapText = true;
                rng01.Value = "Currency";
                rng01.Font.Size = 12;
                rng01.EntireRow.Font.Name = "Times New Roman";
                rng01.Font.Bold = true;

                rng01 = myworksheet.get_Range("C10:C10");
                rng01.MergeCells = true;
                rng01.WrapText = true;
                rng01.Value = "(" + cur + ")";
                rng01.Font.Size = 12;
                rng01.EntireRow.Font.Name = "Times New Roman";
                rng01.Font.Bold = true;

                rng01 = myworksheet.get_Range("F10:G10");
                rng01.MergeCells = true;
                rng01.WrapText = true;
                rng01.Value = "Date :" + DateTime.Now.ToString("dd MMMM" + "," + "yyyy");
                rng01.Font.Size = 12;
                rng01.EntireRow.Font.Name = "Times New Roman";
                rng01.Font.Bold = true;

                #endregion //End of Sheet1_Header

                startRowNo = 15;
                startCount = 0;
                int startCellNo = 1;
                int srNo = 1;

                IList<LOMDTO00244> dtoBLLoansList = dtoList.Where(a => a.loanACType == "BL").ToList();
                IList<LOMDTO00244> dtoHPLoansList = dtoList.Where(a => a.loanACType == "HP").ToList();
                IList<LOMDTO00244> dtoPLLoansList = dtoList.Where(a => a.loanACType == "PL").ToList();

                if (dtoBLLoansList.Count != 0)
                {
                    rng01 = myworksheet.get_Range("A12:G12");
                    rng01.MergeCells = true;
                    rng01.WrapText = true;
                    rng01.Value = "Business Loans";
                    rng01.Font.Size = 12;
                    rng01.EntireRow.Font.Name = "Times New Roman";
                    rng01.Font.Bold = true;

                    PrintHeaderLine();

                    #region For Business Loans
                    for (int i = 0; i < dtoBLLoansList.Count; i++)
                    {
                        rng01 = myworksheet.Cells[startRowNo, startCellNo];
                        rng01.NumberFormat = "0";
                        rng01.Value = srNo++;
                        rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                        rng01 = myworksheet.get_Range("B" + startRowNo + ":C" + startRowNo);//Cells[startRowNo, startCellNo + 1];
                        rng01.NumberFormat = "@";
                        rng01.MergeCells = true;
                        rng01.WrapText = true;
                        rng01.Value = dtoBLLoansList[i].AcctNo;
                        rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        rng01 = myworksheet.Cells[startRowNo, startCellNo + 3];
                        rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        rng01.Value = dtoBLLoansList[i].NAME;
                        rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        rng01 = myworksheet.Cells[startRowNo, startCellNo + 4];
                        rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        rng01.Value = dtoBLLoansList[i].NRC;
                        rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        rng01 = myworksheet.Cells[startRowNo, startCellNo + 5];
                        //rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        rng01.NumberFormat = "dd/mm/yyyy";
                        rng01.Value = dtoBLLoansList[i].CloseDate.ToString("dd/MM/yyyy");
                        rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                        rng01 = myworksheet.Cells[startRowNo, startCellNo + 6];
                        rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        rng01.Value = dtoBLLoansList[i].CBal;
                        rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        startRowNo++;
                    }

                    decimal balance = dtoBLLoansList.Sum(a => a.CBal);

                    rng01 = myworksheet.get_Range("A" + startRowNo + ":F" + startRowNo);
                    rng01.MergeCells = true;
                    rng01.Value = "Sub Total";
                    rng01.Font.Bold = true;
                    rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                    rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                    rng01 = myworksheet.get_Range("G" + startRowNo + ":G" + startRowNo);
                    rng01.Value = balance;
                    rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                    rng01.Font.Bold = true;
                    rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                    rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                    #endregion
                }

                if (dtoPLLoansList.Count != 0)
                {
                    #region For Personal Loans

                    if (dtoBLLoansList.Count != 0)
                    {
                        startRowNo++;

                        rng01 = myworksheet.get_Range("A" + startRowNo + ":G" + startRowNo);//("A12:G12");
                        rng01.MergeCells = true;
                        rng01.WrapText = true;
                        rng01.Value = "Personal Loans";
                        rng01.Font.Size = 12;
                        rng01.EntireRow.Font.Name = "Times New Roman";
                        rng01.Font.Bold = true;
                        rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        startRowNo++;
                    }
                    else
                    {
                        rng01 = myworksheet.get_Range("A12:G12");
                        rng01.MergeCells = true;
                        rng01.WrapText = true;
                        rng01.Value = "Personal Loans";
                        rng01.Font.Size = 12;
                        rng01.EntireRow.Font.Name = "Times New Roman";
                        rng01.Font.Bold = true;
                        PrintHeaderLine();
                    }



                    for (int i = 0; i < dtoPLLoansList.Count; i++)
                    {
                        rng01 = myworksheet.Cells[startRowNo, startCellNo];
                        rng01.NumberFormat = "0";
                        rng01.Value = srNo++;
                        rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                        rng01 = myworksheet.get_Range("B" + startRowNo + ":C" + startRowNo);//Cells[startRowNo, startCellNo + 1];
                        rng01.NumberFormat = "@";
                        rng01.MergeCells = true;
                        rng01.WrapText = true;
                        rng01.Value = dtoPLLoansList[i].AcctNo;
                        rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        rng01 = myworksheet.Cells[startRowNo, startCellNo + 3];
                        rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        rng01.Value = dtoPLLoansList[i].NAME;
                        rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        rng01 = myworksheet.Cells[startRowNo, startCellNo + 4];
                        rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        rng01.Value = dtoPLLoansList[i].NRC;
                        rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        rng01 = myworksheet.Cells[startRowNo, startCellNo + 5];
                        //rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        rng01.NumberFormat = "dd/mm/yyyy";
                        rng01.Value = dtoPLLoansList[i].CloseDate.ToString("dd/MM/yyyy");
                        rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                        rng01 = myworksheet.Cells[startRowNo, startCellNo + 6];
                        rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        rng01.Value = dtoPLLoansList[i].CBal;
                        rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        startRowNo++;
                    }

                    decimal balancePL = dtoPLLoansList.Sum(a => a.CBal);


                    rng01 = myworksheet.get_Range("A" + startRowNo + ":F" + startRowNo);
                    rng01.MergeCells = true;
                    rng01.Value = "Sub Total";
                    rng01.Font.Bold = true;
                    rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                    rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                    rng01 = myworksheet.get_Range("G" + startRowNo + ":G" + startRowNo);
                    rng01.Value = balancePL;
                    rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                    rng01.Font.Bold = true;
                    rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                    rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                    #endregion
                }

                if (dtoHPLoansList.Count != 0)
                {
                    if (dtoBLLoansList.Count != 0)
                    {
                        startRowNo++;

                        rng01 = myworksheet.get_Range("A" + startRowNo + ":G" + startRowNo);//("A12:G12");
                        rng01.MergeCells = true;
                        rng01.WrapText = true;
                        rng01.Value = "HP";
                        rng01.Font.Size = 12;
                        rng01.EntireRow.Font.Name = "Times New Roman";
                        rng01.Font.Bold = true;
                        rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        startRowNo++;
                    }
                    else
                    {
                        rng01 = myworksheet.get_Range("A12:G12");
                        rng01.MergeCells = true;
                        rng01.WrapText = true;
                        rng01.Value = "HP";
                        rng01.Font.Size = 12;
                        rng01.EntireRow.Font.Name = "Times New Roman";
                        rng01.Font.Bold = true;
                        PrintHeaderLine();
                    }

                    #region For HP

                    for (int i = 0; i < dtoHPLoansList.Count; i++)
                    {
                        rng01 = myworksheet.Cells[startRowNo, startCellNo];
                        rng01.NumberFormat = "0";
                        rng01.Value = srNo++;
                        rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                        rng01 = myworksheet.get_Range("B" + startRowNo + ":C" + startRowNo);//Cells[startRowNo, startCellNo + 1];
                        rng01.NumberFormat = "@";
                        rng01.MergeCells = true;
                        rng01.WrapText = true;
                        rng01.Value = dtoHPLoansList[i].AcctNo;
                        rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        rng01 = myworksheet.Cells[startRowNo, startCellNo + 3];
                        rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        rng01.Value = dtoHPLoansList[i].NAME;
                        rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        rng01 = myworksheet.Cells[startRowNo, startCellNo + 4];
                        rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        rng01.Value = dtoHPLoansList[i].NRC;
                        rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        rng01 = myworksheet.Cells[startRowNo, startCellNo + 5];
                        //rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        rng01.NumberFormat = "dd/mm/yyyy";
                        rng01.Value = dtoHPLoansList[i].CloseDate.ToString("dd/MM/yyyy");
                        rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        rng01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                        rng01 = myworksheet.Cells[startRowNo, startCellNo + 6];
                        rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                        rng01.Value = dtoHPLoansList[i].CBal;
                        rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        startRowNo++;
                    }

                    decimal balanceHP = dtoHPLoansList.Sum(a => a.CBal);

                    rng01 = myworksheet.get_Range("A" + startRowNo + ":F" + startRowNo);
                    rng01.MergeCells = true;
                    rng01.Value = "Sub Total";
                    rng01.Font.Bold = true;
                    rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                    rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                    rng01 = myworksheet.get_Range("G" + startRowNo + ":G" + startRowNo);
                    rng01.Value = balanceHP;
                    rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                    rng01.Font.Bold = true;
                    rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                    rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                    #endregion
                }

                #region Footer Grand Total
                decimal grandTotal = dtoList.Sum(a => a.CBal);

                startRowNo++;
                rng01 = myworksheet.get_Range("A" + startRowNo + ":F" + startRowNo);
                rng01.MergeCells = true;
                rng01.Value = "Grand Total";
                rng01.Font.Bold = true;
                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rng01 = myworksheet.get_Range("G" + startRowNo + ":G" + startRowNo);
                rng01.Value = grandTotal;
                rng01.NumberFormat = "#,##0.00;(#,##0.00)";
                rng01.Font.Bold = true;
                rng01.Borders.Color = System.Drawing.Color.Black.ToArgb();
                rng01.HorizontalAlignment = XlHAlign.xlHAlignRight;
                rng01.VerticalAlignment = XlVAlign.xlVAlignCenter;

                #endregion

        #endregion // End of ExcelData

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


                //myworkbook.SaveAs(FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                //myworkbook.Close(true, misValue, misValue);
                //myexcelapp.Quit();

                //releaseObject(myworksheet);
                //releaseObject(myworkbook);
                //releaseObject(myexcelapp);
                //Process.Start(FileName);
            }
            catch(Exception ex)
            {
                CXUIMessageUtilities.ShowMessageByCode("MI90138");///Please close "AccountClosedListing.xls". If it is already open.
            }

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

        //public IList<LOMDTO00245> TransactionListing(LOMDTO00245 dto)
        //{
        //    return CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00245>>(x => x.TransactionListing(dto));
        //}
        public bool CheckDate(DateTime startDate, DateTime endDate)
        {
            bool date = CXCOM00006.Instance.IsValidStartDateEndDate(startDate, endDate);
            return date;
        }  
		public void Print(LOMDTO00245 dto)
        {
            string header ="";
            string rptName = "transferTransactionList";
            IList<LOMDTO00245> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00245>>(x => x.TransactionListing(dto));
            if (DTOList == null || DTOList.Count == 0)
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
            }
            else //if (DTOList.Count > 0)
            {                
                if (dto.StartDate.ToString("yyyyMMdd") == dto.EndDate.ToString("yyyyMMdd"))
                    showDate = "At " + dto.StartDate.ToString("dd/MM/yyyy");
                else
                    showDate = "From " + dto.StartDate.ToString("dd/MM/yyyy") + " To " + dto.EndDate.ToString("dd/MM/yyyy");
                if (dto.VoucherType == "CASH") searchFilter = "By Cash";
                else searchFilter = "By Transfer";
                
                if ( dto.VoucherStatus== "0") orderBy = "All";
                else if (dto.VoucherStatus == "1") orderBy = "Credit Only";
                else orderBy = "Debit Only";

                if ( dto.VoucherType == "TRANS" && dto.VoucherStatus == "CR")
                    header = "Transfer Credit Voucher Transaction listing By All Type " + showDate;
                else if (dto.VoucherType == "TRANS" && dto.VoucherStatus == "DR")
                    header = "Transfer Debit Voucher Transaction listing By All Type " + showDate;
                //else if (dto.VoucherType == "TRANS" && dto.VoucherStatus == "ALL")
                //    header = "Transfer ALL Voucher Transaction listing  By All Type " + showDate;
                else if (dto.VoucherType == "CASH" && dto.VoucherStatus == "CR")
                    header = "Domestic Cash Credit Voucher Transaction listing By All Type " + showDate;
                else if (dto.VoucherType == "CASH" && dto.VoucherStatus == "DR")
                    header = "Domestic Cash Debit Voucher Transaction listing By All Type " + showDate;
                //else if (dto.VoucherType == "CASH" && dto.VoucherStatus == "ALL")
                //    header = "Domestic Cash All Voucher Transaction listing  By All Type " + showDate;


                CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, dto.Currency, header, dto.SourceBr, showDate, searchFilter, orderBy, rptName });
            }
        }

    }
}
