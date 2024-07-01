 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Ace.Cbs.Cx.Com.Utt;
using Win_DataTable = System.Data.DataTable;
using Range_Excel = Microsoft.Office.Interop.Excel.Range;

namespace Ace.Cbs.Cx.Cle
{
    public class CXCLE00004
    {
        object misValue = System.Reflection.Missing.Value;  //Miss Value Declaration
        string CounterNo = string.Empty;
        //Constructor
        public CXCLE00004()
        {

        }

        #region Cash Control Report
        //Export Excel By List
        public void CashControlReportExportToExcel(string BranchName, string BranchAddress, string BranchPhoneNo, string BranchFaxNo, string ReportTitle, DateTime ReportDateTime, List<string> ColumnListString, List<string[]> VaultListString, List<string[]> FooterValueListString)
        {
            try
            {
                if (ColumnListString.Count <= 0)
                {
                    throw new Exception("Invalid Parameter");
                }
                if (FooterValueListString.Count <= 0)
                {
                    throw new Exception("Invalid Parameter");
                }
                string FileName = Path.GetTempPath() + "Cash Control Report.xlsx";
                Excel.Range range;                      //Excel Range File

                //SaveFileDialog svdialog = new SaveFileDialog();
                //svdialog.Filter = "Excel File (*.xls)|*.xls";
                //if (DialogResult.OK == svdialog.ShowDialog())
                //{
                //    FileName = svdialog.FileName;
                //}
                //else
                //{
                //    return;
                //}
                FileInfo fileinfo = new FileInfo(@FileName);
                if (fileinfo.Exists)
                {
                    fileinfo.Attributes = FileAttributes.Normal;
                    fileinfo.Delete();
                }
                Excel.Application myexcelapp = new Excel.Application();
                Excel.Workbook myworkbook = myexcelapp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                Excel.Worksheet myworksheet = (Excel.Worksheet)myworkbook.ActiveSheet;
                myworksheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                myworksheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperLegal;
                myworksheet.PageSetup.Zoom = false;
                myworksheet.PageSetup.FitToPagesWide = 1;
                myworksheet.PageSetup.LeftMargin = 0.3;
                myworksheet.PageSetup.RightMargin = 0.3;
                //Show Off the Grid Line of Excel
                myworkbook.Windows.get_Item(1).DisplayGridlines = false;
                //Sheet Name
                myworksheet.Name = "Sheet1";
                //fileinfo.IsReadOnly = true;

                //myworksheet.Cells.Locked = true;
                //myexcelapp.StandardFont = "Times New Roman";
                //myexcelapp.StandardFontSize = 12;

                #region Header

                Image img = null;
                string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                {
                    img = System.Drawing.Image.FromStream(stream);
                    img.Save(tempFilePath);
                }
                // For Bank Logo --> Cash Control Report                                                                                      //left,top,width,height
                myworksheet.Shapes.AddPicture(tempFilePath, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 420, 6, 50, 45);
                //First Header
                myworksheet.Cells[1, 1] = BranchName;
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[1, 1], (object)myworksheet.Cells[1, 4 + ColumnListString.Count + 4]);
                //CashControlReportHeaderMergeCells(range);
                //Second Header
                myworksheet.Cells[2, 1] = BranchAddress;
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[2, 1], (object)myworksheet.Cells[2, 4 + ColumnListString.Count + 4]);
                //CashControlReportHeaderMergeCells(range);
                //Third Header
                myworksheet.Cells[3, 1] = BranchPhoneNo;
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[3, 1], (object)myworksheet.Cells[3, 4 + ColumnListString.Count + 4]);
                //CashControlReportHeaderMergeCells(range);
                //Fourth Header
                myworksheet.Cells[4, 1] = BranchFaxNo;
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[4, 1], (object)myworksheet.Cells[4, 4 + ColumnListString.Count + 4]);
                //CashControlReportHeaderMergeCells(range);
                //Fifth Header
                myworksheet.Cells[5, 1] = "";
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[5, 1], (object)myworksheet.Cells[5, 4 + ColumnListString.Count + 4]);
                //CashControlReportHeaderMergeCells(range);
                //Sixth Header
                myworksheet.Cells[6, 1] = ReportTitle;
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[6, 1], (object)myworksheet.Cells[6, 4 + ColumnListString.Count + 4]);
                //CashControlReportHeaderMergeCells(range);
                //Seventh Header
                myworksheet.Cells[7, 1] = "Date : " + ReportDateTime.Date.ToString("dd MMMM yyyy");
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[7, 1], (object)myworksheet.Cells[7, 4 + ColumnListString.Count + 4]);
                CashControlReportHeaderDateCell(range);
                //Eight Header
                myworksheet.Cells[8, 1] = "";
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[8, 1], (object)myworksheet.Cells[8, 4 + ColumnListString.Count + 4]);
                //CashControlReportHeaderMergeCells(range);

                #endregion Header

                #region Columns Header
                //For Sr No.
                myworksheet.Cells[9, 1] = "Sr No.";
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[9, 1], (object)myworksheet.Cells[10, 1]);
                range.ColumnWidth = 7;
                CashControlReportHeaderColumnMarge(range);

                //For Entry No.
                myworksheet.Cells[9, 2] = "Entry No.";
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[9, 2], (object)myworksheet.Cells[10, 2]);
                CashControlReportHeaderColumnMarge(range);

                //For Description
                myworksheet.Cells[9, 3] = "Description";
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[9, 3], (object)myworksheet.Cells[10, 3]);
                CashControlReportHeaderColumnMarge(range);

                //For Cashier
                myworksheet.Cells[9, 4] = "Cashier";
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[9, 4], (object)myworksheet.Cells[10, 4]);
                CashControlReportHeaderColumnMarge(range);

                //For DENOMINATION OF NOTES
                myworksheet.Cells[9, 5] = "DENOMINATION OF NOTES";
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[9, 5], (object)myworksheet.Cells[9, 4 + ColumnListString.Count]);
                CashControlReportHeaderColumnMarge(range);

                for (int j = 0; j <= ColumnListString.Count - 1; j++)
                {
                    myworksheet.Cells[10, j + 5] = ColumnListString[j].ToString();
                    //myworksheet.Cells[10, j + 5] ="1020 Kyat adhasjkdhajkhfjkashfjkshfjkshjkfhsjkf";
                    range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[10, j + 5], (object)myworksheet.Cells[10, j + 5]);
                    //range = (Excel.Range)myworksheet.get_Range("A14", "D14");
                    CashControlReportHeaderColumnMarge(range);
                }

                //For Total Amount of Notes
                myworksheet.Cells[9, 4 + ColumnListString.Count + 1] = "Total Amount of Notes";
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[9, 4 + ColumnListString.Count + 1], (object)myworksheet.Cells[10, 4 + ColumnListString.Count + 1]);
                CashControlReportHeaderColumnMarge(range);

                //For Coins
                myworksheet.Cells[9, 4 + ColumnListString.Count + 2] = "Coins";
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[9, 4 + ColumnListString.Count + 2], (object)myworksheet.Cells[10, 4 + ColumnListString.Count + 2]);
                CashControlReportHeaderColumnMarge(range);

                //For Deposit Amount
                myworksheet.Cells[9, 4 + ColumnListString.Count + 3] = "Deposit Amount";
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[9, 4 + ColumnListString.Count + 3], (object)myworksheet.Cells[10, 4 + ColumnListString.Count + 3]);
                CashControlReportHeaderColumnMarge(range);


                //For Withdraw Amount
                myworksheet.Cells[9, 4 + ColumnListString.Count + 4] = "Withdraw Amount";
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[9, 4 + ColumnListString.Count + 4], (object)myworksheet.Cells[10, 4 + ColumnListString.Count + 4]);
                CashControlReportHeaderColumnMarge(range);

                #endregion Columns Header

                #region Row Data
                int SerialNo = 0;

                #region ReportBody
                if (VaultListString.Count > 0)
                {
                    for (int i = 0; i <= VaultListString.Count - 1; i++)
                    {
                        for (int j = -1; j <= (1 + 4 + ColumnListString.Count + 4 - 2) - 1; j++)
                        {
                            if (j == -1)
                            {
                                SerialNo++;
                                myworksheet.Cells[i + 11, j + 2] = SerialNo;
                                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[i + 11, 1], (object)myworksheet.Cells[i + 11, 1]);
                                CashControlReportRowRangeItemData(range, "Decimal", false,false);
                            }
                            else if (j == 0 || j == 1 || j == 2)
                            {

                                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[i + 11, j + 2], (object)myworksheet.Cells[i + 11, j + 2]);
                                CashControlReportRowRangeItemData(range, "Item", false,true);
                                myworksheet.Cells[i + 11, j + 2] = VaultListString[i][j].ToString();
                            }
                            else
                            {
                                myworksheet.Cells[i + 11, j + 2] = VaultListString[i][j].ToString();
                                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[i + 11, j + 2], (object)myworksheet.Cells[i + 11, j + 2]);
                                if ((j == (1 + 4 + ColumnListString.Count + 4 - 2) - 1) || j == (1 + 4 + ColumnListString.Count + 4 - 2) - 2 || j == (1 + 4 + ColumnListString.Count + 4 - 2) - 4)
                                {
                                    CashControlReportRowRangeItemData(range, "Decimal", false, true);
                                }
                                else
                                {
                                    CashControlReportRowRangeItemData(range, "Decimal", false,false);
                                }
                            }
                        }
                    }
                }
                #endregion ReportBody

                #region ReportFooter
                for (int i = 0; i <= FooterValueListString.Count - 1; i++)
                {
                    for (int j = 0; j <= (1 + ColumnListString.Count + 4) - 1; j++)
                    {
                        if (j == 0)
                        {
                            
                            range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[i + 11 + VaultListString.Count, 1], (object)myworksheet.Cells[i + 11 + VaultListString.Count, 4]);
                            CashControlReportRowRangeItemData(range, "Item", true,false);
                            myworksheet.Cells[i + 11 + VaultListString.Count, j + 1] = FooterValueListString[i][j].ToString();
                        }
                        else
                        {
                            myworksheet.Cells[i + 11 + VaultListString.Count, j + 4] = FooterValueListString[i][j].ToString();
                            range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[i + 11 + VaultListString.Count, j + 4], (object)myworksheet.Cells[i + 11 + VaultListString.Count, j + 4]);
                            if ((j == (1 + ColumnListString.Count + 4) - 1) || j == (1 + ColumnListString.Count + 4) - 2 || j == (1 + ColumnListString.Count + 4) - 4)
                            {
                                CashControlReportRowRangeItemData(range, "Decimal", true, true);
                            }
                            else
                            {
                                CashControlReportRowRangeItemData(range, "Decimal", true, false);
                            }
                        }
                    }
                }
                #endregion ReportFooter

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
                Marshal.ReleaseComObject(myexcelapp);

                myexcelapp = null;

                #region Get Excel Processes and Kill it Immediately
                Process[] Processes;
                Processes = System.Diagnostics.Process.GetProcessesByName("EXCEL");
                //Check that Process is null or not
                if (Processes.Length > 0)
                {
                    foreach (System.Diagnostics.Process p in Processes)
                    {
                        if (p.MainWindowTitle.Trim() == "")
                            p.Kill();
                    }
                }
                #endregion Get Excel Processes and Kill it Immediately

                FileInfo FInfo = new FileInfo(FileName);
                FInfo.Attributes = FileAttributes.ReadOnly;

                Process.Start(FileName);

                //Excel.Workbook myExcelWorkbooks = myexcelapp.Workbooks.Open(FileName, ReadOnly: false);
            }
            catch (Exception ex)
            {

            }
        }

        public void CashControlReportExportTo_ExcelNew(string BranchName, string BranchAddress, string BranchPhoneNo, string BranchFaxNo, string ReportTitle, DateTime ReportDateTime, List<string> ColumnListString, List<string[]> VaultListString, List<string[]> FooterValueListString, DataGridView dgv)
        {
            try
            {
                if (ColumnListString.Count <= 0)
                {
                    throw new Exception("Invalid Parameter");
                }
                if (FooterValueListString.Count <= 0)
                {
                    throw new Exception("Invalid Parameter");
                }
                string FileName = Path.GetTempPath() + "Cash Control Report.xlsx";
                Excel.Range range;                      //Excel Range File

                //SaveFileDialog svdialog = new SaveFileDialog();
                //svdialog.Filter = "Excel File (*.xls)|*.xls";
                //if (DialogResult.OK == svdialog.ShowDialog())
                //{
                //    FileName = svdialog.FileName;
                //}
                //else
                //{
                //    return;
                //}
                FileInfo fileinfo = new FileInfo(@FileName);
                if (fileinfo.Exists)
                {
                    fileinfo.Attributes = FileAttributes.Normal;
                    fileinfo.Delete();
                }
                Excel.Application myexcelapp = new Excel.Application();
                Excel.Workbook myworkbook = myexcelapp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                Excel.Worksheet myworksheet = (Excel.Worksheet)myworkbook.ActiveSheet;
                myworksheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                myworksheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperLegal;
                myworksheet.PageSetup.Zoom = false;
                myworksheet.PageSetup.FitToPagesWide = 1;
                myworksheet.PageSetup.LeftMargin = 0.3;
                myworksheet.PageSetup.RightMargin = 0.3;
                //Show Off the Grid Line of Excel
                myworkbook.Windows.get_Item(1).DisplayGridlines = false;
                //Sheet Name
                myworksheet.Name = "Sheet1";
                //fileinfo.IsReadOnly = true;

                //myworksheet.Cells.Locked = true;
                //myexcelapp.StandardFont = "Times New Roman";
                //myexcelapp.StandardFontSize = 12;

                #region Header

                Image img = null;
                string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                {
                    img = System.Drawing.Image.FromStream(stream);
                    img.Save(tempFilePath);
                }
                // For Bank Logo --> Cash Control Report                                                                                      //left,top,width,height
                myworksheet.Shapes.AddPicture(tempFilePath, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 420, 6, 50, 45);
                //First Header
                myworksheet.Cells[1, 1] = BranchName;
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[1, 1], (object)myworksheet.Cells[1, 4 + ColumnListString.Count + 4]);
                //CashControlReportHeaderMergeCells(range);
                //Second Header
                myworksheet.Cells[2, 1] = BranchAddress;
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[2, 1], (object)myworksheet.Cells[2, 4 + ColumnListString.Count + 4]);
                //CashControlReportHeaderMergeCells(range);
                //Third Header
                myworksheet.Cells[3, 1] = BranchPhoneNo;
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[3, 1], (object)myworksheet.Cells[3, 4 + ColumnListString.Count + 4]);
                //CashControlReportHeaderMergeCells(range);
                //Fourth Header
                myworksheet.Cells[4, 1] = BranchFaxNo;
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[4, 1], (object)myworksheet.Cells[4, 4 + ColumnListString.Count + 4]);
                //CashControlReportHeaderMergeCells(range);
                //Fifth Header
                myworksheet.Cells[5, 1] = "";
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[5, 1], (object)myworksheet.Cells[5, 4 + ColumnListString.Count + 4]);
                //CashControlReportHeaderMergeCells(range);
                //Sixth Header
                myworksheet.Cells[6, 1] = ReportTitle;
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[6, 1], (object)myworksheet.Cells[6, 4 + ColumnListString.Count + 4]);
                //CashControlReportHeaderMergeCells(range);
                //Seventh Header
                myworksheet.Cells[7, 1] = "Date : " + ReportDateTime.Date.ToString("dd MMMM yyyy");
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[7, 1], (object)myworksheet.Cells[7, 4 + ColumnListString.Count + 4]);
                CashControlReportHeaderDateCell(range);
                //Eight Header
                myworksheet.Cells[8, 1] = "";
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[8, 1], (object)myworksheet.Cells[8, 4 + ColumnListString.Count + 4]);
                //CashControlReportHeaderMergeCells(range);

                #endregion Header

                #region Columns Header
                //For Sr No.
                myworksheet.Cells[9, 1] = "Sr No.";
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[9, 1], (object)myworksheet.Cells[10, 1]);
                range.ColumnWidth = 7;
                CashControlReportHeaderColumnMarge(range);

                //For Entry No.
                myworksheet.Cells[9, 2] = "Entry No.";
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[9, 2], (object)myworksheet.Cells[10, 2]);
                CashControlReportHeaderColumnMarge(range);

                //For Description
                myworksheet.Cells[9, 3] = "Description";
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[9, 3], (object)myworksheet.Cells[10, 3]);
                CashControlReportHeaderColumnMarge(range);

                //For Cashier
                myworksheet.Cells[9, 4] = "Cashier";
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[9, 4], (object)myworksheet.Cells[10, 4]);
                CashControlReportHeaderColumnMarge(range);

                //For DENOMINATION OF NOTES
                myworksheet.Cells[9, 5] = "DENOMINATION OF NOTES";
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[9, 5], (object)myworksheet.Cells[9, 4 + ColumnListString.Count]);
                CashControlReportHeaderColumnMarge(range);

                for (int j = 0; j <= ColumnListString.Count - 1; j++)
                {
                    myworksheet.Cells[10, j + 5] = ColumnListString[j].ToString();
                    //myworksheet.Cells[10, j + 5] ="1020 Kyat adhasjkdhajkhfjkashfjkshfjkshjkfhsjkf";
                    range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[10, j + 5], (object)myworksheet.Cells[10, j + 5]);
                    //range = (Excel.Range)myworksheet.get_Range("A14", "D14");
                    CashControlReportHeaderColumnMarge(range);
                }

                //For Total Amount of Notes
                myworksheet.Cells[9, 4 + ColumnListString.Count + 1] = "Total Amount of Notes";
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[9, 4 + ColumnListString.Count + 1], (object)myworksheet.Cells[10, 4 + ColumnListString.Count + 1]);
                CashControlReportHeaderColumnMarge(range);

                //For Coins
                myworksheet.Cells[9, 4 + ColumnListString.Count + 2] = "Coins";
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[9, 4 + ColumnListString.Count + 2], (object)myworksheet.Cells[10, 4 + ColumnListString.Count + 2]);
                CashControlReportHeaderColumnMarge(range);

                //For Deposit Amount
                myworksheet.Cells[9, 4 + ColumnListString.Count + 3] = "Deposit Amount";
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[9, 4 + ColumnListString.Count + 3], (object)myworksheet.Cells[10, 4 + ColumnListString.Count + 3]);
                CashControlReportHeaderColumnMarge(range);


                //For Withdraw Amount
                myworksheet.Cells[9, 4 + ColumnListString.Count + 4] = "Withdraw Amount";
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[9, 4 + ColumnListString.Count + 4], (object)myworksheet.Cells[10, 4 + ColumnListString.Count + 4]);
                CashControlReportHeaderColumnMarge(range);

                #endregion Columns Header

                #region Row Data
                int SerialNo = 0;

                //if (VaultListString.Count > 0)
                //{
                //    Win_DataTable dt = new Win_DataTable();

                //    for (int i = 0; i < ColumnListString.Count; i++)
                //    {
                //        dt.Columns.Add(ColumnListString[i].ToString());
                //    }
                //    dt.Columns.Add("Total Amount of Notes");
                //    dt.Columns.Add("Coins");
                //    dt.Columns.Add("Deposit Amount");
                //    dt.Columns.Add("Withdraw Amount");
                //    for (int i = 0; i < VaultListString.Count; i++)
                //    {
                //        object[] vault = { 
                //                             VaultListString[i][3],
                //                             VaultListString[i][4],
                //                             VaultListString[i][5],
                //                             VaultListString[i][6],
                //                             VaultListString[i][7],
                //                             VaultListString[i][8],
                //                             VaultListString[i][9],
                //                             VaultListString[i][10],
                //                             VaultListString[i][11],
                //                             VaultListString[i][12],
                //                             VaultListString[i][13],
                //                             VaultListString[i][14],
                //                             VaultListString[i][15],
                //                             VaultListString[i][16],
                //                             VaultListString[i][17],
                //                             VaultListString[i][18],
                //                             VaultListString[i][19],
                //                             VaultListString[i][20],
                //                             VaultListString[i][21],
                //                             VaultListString[i][22]
                //                         };
                //        dt.Rows.Add(vault);
                //    }
                //    for (int i = 0; i < FooterValueListString.Count; i++)
                //    {
                //        object[] FooterValue = { 
                                            
                //                             FooterValueListString[i][1],
                //                             FooterValueListString[i][2],
                //                             FooterValueListString[i][3],
                //                             FooterValueListString[i][4],
                //                             FooterValueListString[i][5],
                //                             FooterValueListString[i][6],
                //                             FooterValueListString[i][7],
                //                             FooterValueListString[i][8],
                //                             FooterValueListString[i][9],
                //                             FooterValueListString[i][10],
                //                             FooterValueListString[i][11],
                //                             FooterValueListString[i][12],
                //                             FooterValueListString[i][13],
                //                             FooterValueListString[i][14],
                //                             FooterValueListString[i][15],
                //                             FooterValueListString[i][16],
                //                             FooterValueListString[i][17],
                //                             FooterValueListString[i][18],
                //                             FooterValueListString[i][19],
                //                             FooterValueListString[i][20]
                //                         };
                //        dt.Rows.Add(FooterValue);
                //    }

                    dgv.SelectAll();
                    DataObject dataObj = dgv.GetClipboardContent();
                    Clipboard.SetDataObject(dataObj);
                    //for (int i = 0; i < dt.Rows.Count; i++)
                    //{
                    //    Range_Excel rng00 = myworksheet.get_Range("B" + (11 + i));
                    //    rng00.Value = dt.Rows[i].ToString();
                    //}

                    Range_Excel rng01 = myworksheet.get_Range("B11");
                    rng01.Select();
                    rng01.PasteSpecial(Excel.XlPasteType.xlPasteAll,
    Excel.XlPasteSpecialOperation.xlPasteSpecialOperationAdd, false, false);

                



                //#region ReportBody
                //if (VaultListString.Count > 0)
                //{
                //    for (int i = 0; i <= VaultListString.Count - 1; i++)
                //    {
                //        for (int j = -1; j <= (1 + 4 + ColumnListString.Count + 4 - 2) - 1; j++)
                //        {
                //            if (j == -1)
                //            {
                //                SerialNo++;
                //                myworksheet.Cells[i + 11, j + 2] = SerialNo;
                //                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[i + 11, 1], (object)myworksheet.Cells[i + 11, 1]);
                //                CashControlReportRowRangeItemData(range, "Decimal", false, false);
                //            }
                //            else if (j == 0 || j == 1 || j == 2)
                //            {

                //                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[i + 11, j + 2], (object)myworksheet.Cells[i + 11, j + 2]);
                //                CashControlReportRowRangeItemData(range, "Item", false, true);
                //                myworksheet.Cells[i + 11, j + 2] = VaultListString[i][j].ToString();
                //            }
                //            else
                //            {
                //                myworksheet.Cells[i + 11, j + 2] = VaultListString[i][j].ToString();
                //                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[i + 11, j + 2], (object)myworksheet.Cells[i + 11, j + 2]);
                //                if ((j == (1 + 4 + ColumnListString.Count + 4 - 2) - 1) || j == (1 + 4 + ColumnListString.Count + 4 - 2) - 2 || j == (1 + 4 + ColumnListString.Count + 4 - 2) - 4)
                //                {
                //                    CashControlReportRowRangeItemData(range, "Decimal", false, true);
                //                }
                //                else
                //                {
                //                    CashControlReportRowRangeItemData(range, "Decimal", false, false);
                //                }
                //            }
                //        }
                //    }
                //}
                //#endregion ReportBody

                //#region ReportFooter
                //for (int i = 0; i <= FooterValueListString.Count - 1; i++)
                //{
                //    for (int j = 0; j <= (1 + ColumnListString.Count + 4) - 1; j++)
                //    {
                //        if (j == 0)
                //        {

                //            range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[i + 11 + VaultListString.Count, 1], (object)myworksheet.Cells[i + 11 + VaultListString.Count, 4]);
                //            CashControlReportRowRangeItemData(range, "Item", true, false);
                //            myworksheet.Cells[i + 11 + VaultListString.Count, j + 1] = FooterValueListString[i][j].ToString();
                //        }
                //        else
                //        {
                //            myworksheet.Cells[i + 11 + VaultListString.Count, j + 4] = FooterValueListString[i][j].ToString();
                //            range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[i + 11 + VaultListString.Count, j + 4], (object)myworksheet.Cells[i + 11 + VaultListString.Count, j + 4]);
                //            if ((j == (1 + ColumnListString.Count + 4) - 1) || j == (1 + ColumnListString.Count + 4) - 2 || j == (1 + ColumnListString.Count + 4) - 4)
                //            {
                //                CashControlReportRowRangeItemData(range, "Decimal", true, true);
                //            }
                //            else
                //            {
                //                CashControlReportRowRangeItemData(range, "Decimal", true, false);
                //            }
                //        }
                //    }
                //}
                //#endregion ReportFooter

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
                Marshal.ReleaseComObject(myexcelapp);

                myexcelapp = null;

                #region Get Excel Processes and Kill it Immediately
                Process[] Processes;
                Processes = System.Diagnostics.Process.GetProcessesByName("EXCEL");
                //Check that Process is null or not
                if (Processes.Length > 0)
                {
                    foreach (System.Diagnostics.Process p in Processes)
                    {
                        if (p.MainWindowTitle.Trim() == "")
                            p.Kill();
                    }
                }
                #endregion Get Excel Processes and Kill it Immediately

                FileInfo FInfo = new FileInfo(FileName);
                FInfo.Attributes = FileAttributes.ReadOnly;

                Process.Start(FileName);

                //Excel.Workbook myExcelWorkbooks = myexcelapp.Workbooks.Open(FileName, ReadOnly: false);
            }
            catch (Exception ex)
            {

            }
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
            range.Merge(misValue);
            range.Font.Bold = true;
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
        private void CashControlReportRowRangeItemData(Excel.Range range, string Type, bool IsFooter,bool isDecimal)
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

        #endregion CashControlReport

        #region Cash Denomination Report
        //Export Excel By List
        public void CashDenominationReportExportToExcel(string BranchName, string BranchAddress, string BranchPhoneNo, string BranchFaxNo, string ReportTitle, DateTime ReportDateTime, List<string> ColumnListString, IList<string> CounterNoListWhichhasTransaction, IList<int> ListRowCountByCounter, IList<string[]> RowValueListString)
        {
            try
            {
                if (ColumnListString.Count <= 0)
                {
                    throw new Exception("Invalid Parameter");
                }
                if (RowValueListString.Count <= 0)
                {
                    throw new Exception("Invalid Parameter");
                }
                string FileName = Path.GetTempPath() + "Cash Denomination Report.xlsx";
                Excel.Range range;                      //Excel Range File

                //SaveFileDialog svdialog = new SaveFileDialog();
                
                //if (DialogResult.OK == svdialog.ShowDialog())
                //{
                //    FileName = svdialog.FileName;
                //}
                //else
                //{
                //    return;
                //}
                FileInfo fileinfo = new FileInfo(FileName);
                if (fileinfo.Exists)
                {
                    fileinfo.Attributes = FileAttributes.Normal;
                    fileinfo.Delete();
                }
                Excel.Application myexcelapp = new Excel.Application();
                Excel.Workbook myworkbook = myexcelapp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                Excel.Worksheet myworksheet = (Excel.Worksheet)myworkbook.ActiveSheet;
                myworksheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                myworksheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperLegal;
                myworksheet.PageSetup.Zoom = false;
                myworksheet.PageSetup.FitToPagesWide = 1;
                myworksheet.PageSetup.LeftMargin = 0.3;
                myworksheet.PageSetup.RightMargin = 0.3;
                //myworksheet.PageSetup.set_PrintQuality = 
                //Show Off the Grid Line of Excel
                myworkbook.Windows.get_Item(1).DisplayGridlines = false;
                //Sheet Name
                myworksheet.Name = "Sheet1";

                #region Old Header
                //First Header
                //myworksheet.Cells[1, 1] = BranchName;
                //range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[1, 1], (object)myworksheet.Cells[1, 5 + ColumnListString.Count + 5]);
                //CashDenominationReportHeaderMergeCells(range);
                ////Second Header
                //myworksheet.Cells[2, 1] = BranchAddress;
                //range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[2, 1], (object)myworksheet.Cells[2, 5 + ColumnListString.Count + 5]);
                //CashDenominationReportHeaderMergeCells(range);
                ////Third Header
                //myworksheet.Cells[3, 1] = BranchPhoneNo;
                //range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[3, 1], (object)myworksheet.Cells[3, 5 + ColumnListString.Count + 5]);
                //CashDenominationReportHeaderMergeCells(range);
                ////Fourth Header
                //myworksheet.Cells[4, 1] = BranchFaxNo;
                //range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[4, 1], (object)myworksheet.Cells[4, 5 + ColumnListString.Count + 5]);
                //CashDenominationReportHeaderMergeCells(range);
                ////Fifth Header
                //myworksheet.Cells[5, 1] = "";
                //range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[5, 1], (object)myworksheet.Cells[5, 5 + ColumnListString.Count + 5]);
                //CashDenominationReportHeaderMergeCells(range);
                ////Sixth Header
                //myworksheet.Cells[6, 1] = ReportTitle;
                //range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[6, 1], (object)myworksheet.Cells[6, 5 + ColumnListString.Count + 5]);
                //CashDenominationReportHeaderMergeCells(range);
                ////Seventh Header
                //myworksheet.Cells[7, 1] = "Date : " + ReportDateTime.Date.ToString("dd MMMM yyyy");
                //range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[7, 1], (object)myworksheet.Cells[7, 5 + ColumnListString.Count + 5]);
                //CashDenominationReportHeaderDateCell(range);
                ////Eight Header
                //myworksheet.Cells[8, 1] = "";
                //range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[8, 1], (object)myworksheet.Cells[8, 5 + ColumnListString.Count + 5]);
                //CashDenominationReportHeaderMergeCells(range);

                #endregion Header

                #region New Header 
                Image img = null;
                string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                {
                    img = System.Drawing.Image.FromStream(stream);
                    img.Save(tempFilePath);
                }
                // For Bank Logo --> Cash Denomination                                                                                        //left,top,width,height
                myworksheet.Shapes.AddPicture(tempFilePath, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 240, 6, 50, 45);
                //First Header            
                myworksheet.Cells[1, 1] = BranchName;
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[1, 1], (object)myworksheet.Cells[1, 5 + ColumnListString.Count + 5]);
                CashDenominationReportHeaderMergeCells(range);
                //Second Header
                myworksheet.Cells[2, 1] = BranchAddress;
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[2, 1], (object)myworksheet.Cells[2, 5 + ColumnListString.Count + 5]);
                CashDenominationReportHeaderMergeCells(range);
                //Third Header
                myworksheet.Cells[3, 1] = "PhoneNo : " + BranchPhoneNo;
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[3, 1], (object)myworksheet.Cells[3, 5 + ColumnListString.Count + 5]);
                CashDenominationReportHeaderMergeCells(range);
                //Fourth Header
                myworksheet.Cells[4, 1] = "Fax : " + BranchFaxNo;
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[4, 1], (object)myworksheet.Cells[4, 5 + ColumnListString.Count + 5]);
                CashDenominationReportHeaderMergeCells(range);
                //Fifth Header
                myworksheet.Cells[5, 1] = "";
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[5, 1], (object)myworksheet.Cells[5, 5 + ColumnListString.Count + 5]);
                CashDenominationReportHeaderMergeCells(range);
                //Sixth Header
                myworksheet.Cells[6, 1] = ReportTitle;
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[6, 1], (object)myworksheet.Cells[6, 5 + ColumnListString.Count + 5]);
                CashDenominationReportHeaderMergeCells(range);
                //Seventh Header
                myworksheet.Cells[7, 1] = "Date : " + ReportDateTime.Date.ToString("dd MMMM yyyy");
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[7, 1], (object)myworksheet.Cells[7, 5 + ColumnListString.Count + 5]);
                CashDenominationReportHeaderDateCell(range);
                //Eight Header
                myworksheet.Cells[8, 1] = "";
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[8, 1], (object)myworksheet.Cells[8, 5 + ColumnListString.Count + 5]);
                CashDenominationReportHeaderMergeCells(range);

                #endregion New Header
              
                #region Columns Header
                //For Sr No.
                myworksheet.Cells[9, 1] = "Sr No.";
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[9, 1], (object)myworksheet.Cells[10, 1]);
                range.ColumnWidth = 7;
                CashDenominationReportHeaderColumnMarge(range);

                //For Entry No.
                myworksheet.Cells[9, 2] = "Entry No.";
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[9, 2], (object)myworksheet.Cells[10, 2]);
                CashDenominationReportHeaderColumnMarge(range);

                //For A/C No
                myworksheet.Cells[9, 3] = "A/C No.";
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[9, 3], (object)myworksheet.Cells[10, 3]);
                CashDenominationReportHeaderColumnMarge(range);

                //For Received From
                myworksheet.Cells[9, 4] = "Received From";
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[9, 4], (object)myworksheet.Cells[10, 4]);
                CashDenominationReportHeaderColumnMarge(range);

                //For Cashier From
                myworksheet.Cells[9, 5] = "Cashier";
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[9, 5], (object)myworksheet.Cells[10, 5]);
                CashDenominationReportHeaderColumnMarge(range);

                ////For Cashier
                //myworksheet.Cells[9, 5] = "Branch Code";
                //range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[9, 5], (object)myworksheet.Cells[10, 6]);
                //CashDenominationReportHeaderColumnMarge(range);

                //For DENOMINATION OF NOTES
                myworksheet.Cells[9, 6] = "DENOMINATION OF NOTES";
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[9, 6], (object)myworksheet.Cells[9, 5 + ColumnListString.Count]);
                CashDenominationReportHeaderColumnMarge(range);

                for (int j = 0; j <= ColumnListString.Count - 1; j++)
                {
                    myworksheet.Cells[10, j + 6] = ColumnListString[j].ToString();
                    //myworksheet.Cells[10, j + 5] ="1020 Kyat adhasjkdhajkhfjkashfjkshfjkshjkfhsjkf";
                    range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[10, j + 6], (object)myworksheet.Cells[10, j + 6]);
                    //range = (Excel.Range)myworksheet.get_Range("A14", "D14");
                    CashDenominationReportHeaderColumnMarge(range);
                }

                //For Total Amount of Notes
                myworksheet.Cells[9, 5 + ColumnListString.Count + 1] = "Total Amount of Notes";
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[9, 5 + ColumnListString.Count + 1], (object)myworksheet.Cells[10, 5 + ColumnListString.Count + 1]);
                CashDenominationReportHeaderColumnMarge(range);

                //For Coins
                myworksheet.Cells[9, 5 + ColumnListString.Count + 2] = "Coins";
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[9, 5 + ColumnListString.Count + 2], (object)myworksheet.Cells[10, 5 + ColumnListString.Count + 2]);
                CashDenominationReportHeaderColumnMarge(range);

                //For Refund
                myworksheet.Cells[9, 5 + ColumnListString.Count + 3] = "Refund";
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[9, 5 + ColumnListString.Count + 3], (object)myworksheet.Cells[10, 5 + ColumnListString.Count + 3]);
                CashDenominationReportHeaderColumnMarge(range);


                //For + (Or) -
                myworksheet.Cells[9, 5 + ColumnListString.Count + 4] = "+ (Or) -";
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[9, 5 + ColumnListString.Count + 4], (object)myworksheet.Cells[10, 5 + ColumnListString.Count + 4]);
                CashDenominationReportHeaderColumnMarge(range);

                //For Transaction Amount
                myworksheet.Cells[9, 5 + ColumnListString.Count + 5] = "Transaction Amount";
                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[9, 5 + ColumnListString.Count + 5], (object)myworksheet.Cells[10, 5 + ColumnListString.Count + 5]);
                CashDenominationReportHeaderColumnMarge(range);

                #endregion Columns Header

                int CounterNoIndex = 0;
                int rowcount = -1;
                int SingleRowCountByCounter = 0;
                int SerialNoCount = 0;
                bool CheckCounterNo = false;
                bool IsSubTotal = false;
                List<Decimal> ListSumTotalDecimal = new List<decimal>();

                #region Row Data
                for (int i = 0; i <= RowValueListString.Count + (CounterNoListWhichhasTransaction.Count * 2) - 1; i++)
                {
                    if (CounterNoListWhichhasTransaction[CounterNoIndex] != CounterNo)
                    {
                        CounterNo = CounterNoListWhichhasTransaction[CounterNoIndex].ToString();
                        CheckCounterNo = true;
                        myworksheet.Cells[i + 11, 1] = "Counter No.:" + CounterNoListWhichhasTransaction[CounterNoIndex].ToString();
                        range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[i + 11, 1], (object)myworksheet.Cells[i + 11, 5 + ColumnListString.Count + 5]);
                        CashDenominationReportRowCounterData(range, "Counter");
                        IsSubTotal = false;
                        SingleRowCountByCounter = 0;
                    }
                    else if (ListRowCountByCounter[CounterNoIndex] == SingleRowCountByCounter)
                    {
                        myworksheet.Cells[i + 11, 1] = "Sub Total Counter No.: [" + CounterNoListWhichhasTransaction[CounterNoIndex].ToString() + "]";
                        range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[i + 11, 1], (object)myworksheet.Cells[i + 11, 5]);
                        CashDenominationReportRowCounterData(range, "SubTotalCounterNo.");
                        CounterNoIndex++;
                        CheckCounterNo = false;
                        IsSubTotal = true;

                        for (int k = 0; k <= (ColumnListString.Count + 5) - 1; k++)
                        {
                            myworksheet.Cells[i + 11, k + 6] = ListSumTotalDecimal[k].ToString();
                            range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[i + 11, k + 6], (object)myworksheet.Cells[i + 11, k + 6]);
                            if (k > ColumnListString.Count -1 )
                                CashDenominationReportRowRangeItemData(range, "SubDecimal",true);
                            else
                                CashDenominationReportRowRangeItemData(range, "SubDecimal", false);
                        }
                        ListSumTotalDecimal.Clear();
                    }
                    else
                    {
                        CheckCounterNo = false;
                        IsSubTotal = false;
                        SingleRowCountByCounter++;
                        rowcount++;
                    }
                    if (CheckCounterNo == false && IsSubTotal == false)
                    {
                        List<Decimal> ListTempDecimal = new List<decimal>();
                        for (int j = -1; j <= (5 + ColumnListString.Count + 5) - 2; j++)
                        {
                            if (j == -1)
                            {
                                SerialNoCount++;
                                myworksheet.Cells[i + 11, j + 2] = SerialNoCount.ToString();
                                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[i + 11, 1], (object)myworksheet.Cells[i + 11, 1]);
                                CashDenominationReportRowRangeItemData(range, "Decimal",false);
                            }
                            if (j == 0 || j == 1 || j == 2 || j == 3)
                            {                            
                               
                                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[i + 11, j + 2], (object)myworksheet.Cells[i + 11, j + 2]);
                                CashDenominationReportRowRangeItemData(range, "Item",false);
                                myworksheet.Cells[i + 11, j + 2] = RowValueListString[rowcount][j].ToString();
                            }
                            else if (j >= 4)
                            {
                                myworksheet.Cells[i + 11, j + 2] = RowValueListString[rowcount][j].ToString();
                                range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[i + 11, j + 2], (object)myworksheet.Cells[i + 11, j + 2]);
                                if (j > ( ColumnListString.Count + 5)-2) CashDenominationReportRowRangeItemData(range, "Decimal", true);
                                else CashDenominationReportRowRangeItemData(range, "Decimal", false);
                                ListTempDecimal.Add(Convert.ToDecimal(RowValueListString[rowcount][j].ToString()));
                            }
                            //else if (j > 4) 
                            //{
                            //    myworksheet.Cells[i + 11, j + 2] = RowValueListString[rowcount][j].ToString();
                            //    range = (Excel.Range)myworksheet.get_Range((object)myworksheet.Cells[i + 11, j + 2], (object)myworksheet.Cells[i + 11, j + 2]);
                            //    CashDenominationReportRowRangeItemData(range, "Decimal", false);
                            //    ListTempDecimal.Add(Convert.ToDecimal(RowValueListString[rowcount][j].ToString()));
                            //}
                        }
                        if (ListSumTotalDecimal.Count <= 0)
                        {
                            ListSumTotalDecimal = ListTempDecimal;
                        }
                        else
                        {
                            for (int l = 0; l <= ListSumTotalDecimal.Count - 1; l++)
                            {
                                //if (l==11)
                                ListSumTotalDecimal[l] = ListSumTotalDecimal[l] + ListTempDecimal[l];
                                if (l == 11)
                                    ListSumTotalDecimal[l] = Convert.ToDecimal(ListSumTotalDecimal[l].ToString().Split(".".ToCharArray())[0]);
                            }
                        }
                    }
                }
                #endregion Row Data

                //Save Excel File To Location
                myworkbook.SaveAs(FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, true, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, true);
                //Close Work Book
                myworkbook.Close(true, misValue, misValue);
                //Quit That Excel Apps
                myexcelapp.Quit();
                //Release That Excel
                Marshal.ReleaseComObject(myexcelapp);

                myexcelapp = null;

                #region Get Excel Processes and Kill it Immediately
                Process[] Processes;
                Processes = System.Diagnostics.Process.GetProcessesByName("EXCEL");
                //Check that Process is null or not
                if (Processes.Length > 0)
                {
                    foreach (System.Diagnostics.Process p in Processes)
                    {
                        if (p.MainWindowTitle.Trim() == "")
                            p.Kill();
                    }
                }
                #endregion Get Excel Processes and Kill it Immediately

                FileInfo FInfo = new FileInfo(FileName);
                FInfo.Attributes = FileAttributes.ReadOnly;

                Process.Start(FileName);
            }
            catch (Exception ex)
            {

            }
        }

        //For Header String Cell
        private void CashDenominationReportHeaderMergeCells(Excel.Range range)
        {
            if (range == null)
            {
                throw new Exception("Invalid Parameter");
            }
            range.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            range.Font.Bold = true;
            range.Merge(misValue);
        }

        //For Header Date Cell
        private void CashDenominationReportHeaderDateCell(Excel.Range range)
        {
            if (range == null)
            {
                throw new Exception("Invalid Parameter");
            }
            range.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            range.Font.Bold = true;
            range.Merge(misValue);
        }

        //For Column Border
        private void CashDenominationReportHeaderColumnMarge(Excel.Range range)
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
            //range.Columns.ColumnWidth = 25;
            range.EntireColumn.AutoFit();
            range.Merge(misValue);
        }

        //For Row Item Data
        private void CashDenominationReportRowRangeItemData(Excel.Range range, string Type,bool isDecimal)
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
                //range.Interior.Color = Color.LightBlue;
                range.NumberFormat = "@";
            }
            else if (Type == "Decimal")
            {
                if(isDecimal)
                    range.NumberFormat = "#,##0.00";
                range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                //range.Interior.Color = Color.LightBlue;
                
            }
            else if (Type == "SubDecimal")
            {
                if (isDecimal)
                    range.NumberFormat = "#,##0.00";
                range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                range.Interior.Color = Color.LightYellow;
            }

            range.Borders[Excel.XlBordersIndex.xlEdgeRight].Color = Color.Black;
            range.Borders[Excel.XlBordersIndex.xlEdgeLeft].Color = Color.Black;
            range.Borders[Excel.XlBordersIndex.xlEdgeTop].Color = Color.Black;
            range.Borders[Excel.XlBordersIndex.xlEdgeBottom].Color = Color.Black;

            range.Columns.AutoFit();
            //range.Columns.ColumnWidth = 25;
            range.EntireColumn.AutoFit();
            range.Merge(misValue);
        }

        //For Row Counter Data and Sub Counter Data
        private void CashDenominationReportRowCounterData(Excel.Range range, string Type)
        {
            if (range == null)
            {
                throw new Exception("Invalid Parameter");
            }
            if (string.IsNullOrEmpty(Type))
            {
                throw new Exception("Invalid Parameter");
            }
            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            range.Borders[Excel.XlBordersIndex.xlEdgeRight].Color = Color.Black;
            range.Borders[Excel.XlBordersIndex.xlEdgeLeft].Color = Color.Black;
            range.Borders[Excel.XlBordersIndex.xlEdgeTop].Color = Color.Black;
            range.Borders[Excel.XlBordersIndex.xlEdgeBottom].Color = Color.Black;
            if (Type == "Counter")
            {
                range.Interior.Color = Color.LightGreen;
            }
            else if (Type == "SubTotalCounterNo")
            {
                range.Interior.Color = Color.LightYellow;
            }
            range.Columns.AutoFit();
            //range.Columns.ColumnWidth = 25;
            range.EntireColumn.AutoFit();
            range.Merge(misValue);
        }

        #endregion CashDenominationReport
    }
}
