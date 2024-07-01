using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Windows.Core.Presenter;
using Ace.Windows.CXClient;
using Ace.Cbs.CBM.Ctr.Ptr;
using Ace.Cbs.CBM.Ctr.Sve;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace Ace.Cbs.CBM.Ptr
{
    class CBMCTL00001 : AbstractPresenter, ICBMCTL00001
    {

        #region Properties
        object misValue = System.Reflection.Missing.Value;  //Miss Value Declaration
        ICBMVEW00001 view;
        public ICBMVEW00001 View
        {
            set { this.wireTo(value); }
            get { return this.view; }
        }

        private void wireTo(ICBMVEW00001 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }

        #endregion

        #region Main Methods

        public void Print(string fname)
        {
            IList<PFMDTO00042> list = new List<PFMDTO00042>();
            if (fname.Contains("CashInHand"))
            {
                list = CXClientWrapper.Instance.Invoke<ICBMSVE00001, IList<PFMDTO00042>>(x => x.GetAll_CBMDataByDateAndName(this.view.Date,fname,this.view.Currency));
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred || list.Count == 0 || list == null)
                    CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                else

                    this.CashInHandPositionExportToExcel(list);
            }
            else if (fname.Contains("Flow"))
            {
                PFMDTO00042 Dto = new PFMDTO00042();
                Dto = CXClientWrapper.Instance.Invoke<ICBMSVE00001, PFMDTO00042>(x => x.GetAllData_CBM(this.view.Date, fname, this.view.Currency));
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred || Dto == null)
                    CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                else
                    this.CashFlowExport(Dto);
            }
            else if (fname.Contains("Position"))
            {
                list = CXClientWrapper.Instance.Invoke<ICBMSVE00001, IList<PFMDTO00042>>(x => x.GetAll_CBMDataByDateAndName(this.view.Date, fname, this.view.Currency));
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred || list.Count==0)
                    CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                else
                    this.DailyPositionExport(list);
            }
            else if (fname.Contains("Improvement"))
            {
                list = CXClientWrapper.Instance.Invoke<ICBMSVE00001, IList<PFMDTO00042>>(x => x.GetAll_CBMDataByDateAndName(this.view.Date, fname, this.view.Currency));
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred ||list.Count == 0)
                    CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                else
                    this.DailyImprovementExport(list);
            }
            else if (fname.Contains("FinancialStatement"))
            {
                list = CXClientWrapper.Instance.Invoke<ICBMSVE00001, IList<PFMDTO00042>>(x => x.GetAll_CBMDataByDateAndName(this.view.Date, fname, this.view.Currency));
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred || list.Count == 0)
                    CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                else
                    this.FinancialStatementExport(list);
            }
            else if (fname.Contains("Progress"))
            {
                list = CXClientWrapper.Instance.Invoke<ICBMSVE00001, IList<PFMDTO00042>>(x => x.GetAll_CBMDataByDateAndName(this.view.Date, fname, this.view.Currency));
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred || list.Count == 0)
                    CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                else
                    this.DailyProgressExport(list);
            }
            else if (fname.Contains("LiquidityRatio"))
            {
                PFMDTO00042 Dto = new PFMDTO00042();
                Dto = CXClientWrapper.Instance.Invoke<ICBMSVE00001, PFMDTO00042>(x => x.GetAllData_CBM(this.view.Date, fname, this.view.Currency));
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred || Dto == null)
                    CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                else
                    this.Liquidity_RatioExport(Dto);
            }

        }

        #endregion

        #region Cash In Hand Position Export To Excel

        //Export Excel By List
        public void CashInHandPositionExportToExcel(IList<PFMDTO00042> list)
        {
            try
            {
                string FileName = Path.GetTempPath() + "Cash In Hand Position Report.xlsx";
                Excel.Range range;                      //Excel Range File
                int RowCounter = 6;
               
                FileInfo fileinfo = new FileInfo(@FileName);
                if (fileinfo.Exists)
                {
                    fileinfo.Attributes = FileAttributes.Normal;
                    fileinfo.Delete();
                }
                Excel.Application myexcelapp = new Excel.Application();
                Excel.Workbook myworkbook = myexcelapp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                Excel.Worksheet myworksheet = (Excel.Worksheet)myworkbook.ActiveSheet;
                myworksheet.PageSetup.Orientation = Excel.XlPageOrientation.xlPortrait;
                myworksheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4;
                myworksheet.PageSetup.Zoom = false;
                myworksheet.PageSetup.FitToPagesWide = 1;
                myworksheet.PageSetup.LeftMargin = 0.3;
                myworksheet.PageSetup.RightMargin = 0.3;
                //Show Off the Grid Line of Excel
                myworkbook.Windows.get_Item(1).DisplayGridlines = false;
                //Sheet Name
                myworksheet.Name = "Sheet1";
                myexcelapp.StandardFontSize = 12;                
                myexcelapp.StandardFont = "Times New Roman";
                

                #region Header

                Image img = null;
                string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                {
                    img = System.Drawing.Image.FromStream(stream);
                    img.Save(tempFilePath);
                }
                // For Bank Logo --> Cash Control Report                                                                                      //left,top,width,height
                myworksheet.Shapes.AddPicture(tempFilePath, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 100, 2, 30, 30);
               
                //First Header                
                range = (Excel.Range)myworksheet.Cells[1, 3];// (Excel.Range)myworksheet.get_Range("B1", "D1");
                ReportHeaderMergeCells(range,false,false);
                range.Value = "Farmers Development Public Bank Limited";                

                //Second Header             
                range = (Excel.Range)myworksheet.Cells[2, 3]; //(Excel.Range)myworksheet.get_Range("B2", "D2");
                ReportHeaderMergeCells(range, false,false);
                range.Value = "Account Department(Head Office)";
                
                //Third Header  
                //range = (Excel.Range)myworksheet.Cells[3, 4];
                range = (Excel.Range)myworksheet.get_Range("A4", "D4");
                ReportHeaderMergeCells(range, false,true);
                range.Value = "Cash in Hand Position All Branches as on " + this.view.Date.ToString("dd/MM/yyyy");
                
                //Fourth Header  
                range = (Excel.Range)myworksheet.Cells[5, 4];  //(Excel.Range)myworksheet.get_Range("B4", "D4");
                ReportHeaderMergeCells(range, true, false);
                range.Value = "(Kyats in Million)" ; 
                #endregion Header

                #region Columns Header
                //For Sr No.    
                range = (Excel.Range)myworksheet.Cells[6, 1]; //(Excel.Range)myworksheet.get_Range("A5", Type.Missing);
                range.Value = "Sr No.";
                range.ColumnWidth = 10;
                ReportHeaderColumnMarge(range);

                //For Branch Code                
                range = (Excel.Range)myworksheet.Cells[6, 2];//(Excel.Range)myworksheet.get_Range("B5", Type.Missing);
                range.Value = "Branch Code";
                range.ColumnWidth = 18;
                ReportHeaderColumnMarge(range);

                //For Branch Name                
                range = (Excel.Range)myworksheet.Cells[6, 3]; //(Excel.Range)myworksheet.get_Range("C5", Type.Missing);
                range.Value = "Branch Name";
                range.ColumnWidth = 25;
                ReportHeaderColumnMarge(range);

                //For Amount                
                range = (Excel.Range)myworksheet.Cells[6, 4]; //(Excel.Range)myworksheet.get_Range("D5", Type.Missing);
                range.Value = "Amount";
                range.ColumnWidth = 25;
                ReportHeaderColumnMarge(range);
                

                #endregion Columns Header

                #region Row Data

                int SerialNo = 1;
                decimal totalamount = 0;
                #region ReportBody

                RowCounter = 7;
                foreach (PFMDTO00042 dto in list)
                {                    
                    range = (Excel.Range)myworksheet.Cells[RowCounter, 1];
                    range.Value = SerialNo;
                    range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    ReportItemColumnMarge(range);

                    range = (Excel.Range)myworksheet.Cells[RowCounter, 2];
                    range.NumberFormat = "@";
                    range.Value = dto.SourceBranch;
                    range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    ReportItemColumnMarge(range);
                   

                    range = (Excel.Range)myworksheet.Cells[RowCounter, 3] ;
                    range.Value = dto.BranchName;
                    range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    ReportItemColumnMarge(range);

                    range = (Excel.Range)myworksheet.Cells[RowCounter, 4];
                    range.Value = dto.Amount;
                    range.NumberFormat = "#,##0.00";
                    range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    ReportItemColumnMarge(range);

                    totalamount += Convert.ToDecimal(dto.Amount);
                    RowCounter++;
                    SerialNo++;
                }

              

                #endregion ReportBody

                #region ReportFooter
                //For Grand Total
                range = myworksheet.get_Range("A" + RowCounter.ToString(), "C" + RowCounter.ToString());                
                ReportHeaderColumnMarge(range);
                range.Value = "Grand Total : "; 

                //For Grand Total Amount
                range = myworksheet.get_Range("D" + RowCounter.ToString(),Type.Missing);
                range.Value = totalamount;
                range.NumberFormat = "#,##0.00";
                ReportHeaderColumnMarge(range);
                range.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;

                #endregion ReportFooter

                #endregion Row Data                

                myworksheet.Cells.Locked = true;
                myworksheet.Protect(Type.Missing, true, true, true, true, true, true, true, true, false, false, false, false, true, true, true);

                //Save Excel File To Location
                myworkbook.SaveAs(FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
                //Close Work Book
                myworkbook.Close(true, Type.Missing, Type.Missing);
                //Quit That Excel Apps
                myexcelapp.Quit();
                //Release That Excel
                Marshal.ReleaseComObject(myexcelapp);

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
                
                Process.Start(FileName);
            }
            catch (Exception ex)
            {

            }
        }

        //For Header String Cell
        private void ReportHeaderMergeCells(Excel.Range range,bool flag,bool isHeader)
        {
            if (range == null)
            {
                throw new Exception("Invalid Parameter");
            }
            range.Merge(misValue);
            range.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            range.Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            range.Font.Bold = true;
            if (isHeader)
            {
                range.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            }
            if (flag)
            {
                range.Font.Size = 10;
                range.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            }
            
        }

        //For Column Border
        private void ReportHeaderColumnMarge(Excel.Range range)
        {
            if (range == null)
            {
                throw new Exception("Invalid Parameter");
            }
            range.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            range.Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            range.Borders[Excel.XlBordersIndex.xlEdgeRight].Color = Color.Black;
            range.Borders[Excel.XlBordersIndex.xlEdgeLeft].Color = Color.Black;
            range.Borders[Excel.XlBordersIndex.xlEdgeTop].Color = Color.Black;
            range.Borders[Excel.XlBordersIndex.xlEdgeBottom].Color = Color.Black;
            range.Font.Bold = true;
            range.Cells.RowHeight = 15;
            range.Font.Size = 10;
            range.Merge(misValue);
        }

        //For Row Data
        private void ReportItemColumnMarge(Excel.Range range)
        {
            if (range == null)
            {
                throw new Exception("Invalid Parameter");
            }            
            range.Borders[Excel.XlBordersIndex.xlEdgeRight].Color = Color.Black;
            range.Borders[Excel.XlBordersIndex.xlEdgeLeft].Color = Color.Black;
            range.Borders[Excel.XlBordersIndex.xlEdgeTop].Color = Color.Black;
            range.Borders[Excel.XlBordersIndex.xlEdgeBottom].Color = Color.Black;
            range.Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            range.Cells.RowHeight = 15;
            range.Font.Size = 10;
        }

        #endregion CashInHandPosition

        #region Cash Flow Export To Excel

        public void CashFlowExport(PFMDTO00042 dto)
        {

            #region Old Code
            //try
            //{
            //    string FileName = Path.GetTempPath() + "Cash Flow Report.xlsx";
            //    Excel.Range range;                      //Excel Range File
            //    int RowCounter = 6;

            //    FileInfo fileinfo = new FileInfo(@FileName);
            //    if (fileinfo.Exists)
            //    {
            //        fileinfo.Attributes = FileAttributes.Normal;
            //        fileinfo.Delete();
            //    }
            //    Excel.Application myexcelapp = new Excel.Application();
            //    Excel.Workbook myworkbook = myexcelapp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            //    Excel.Worksheet myworksheet = (Excel.Worksheet)myworkbook.ActiveSheet;
            //    myworksheet.PageSetup.Orientation = Excel.XlPageOrientation.xlPortrait;
            //    myworksheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4;
            //    myworksheet.PageSetup.Zoom = false;
            //    myworksheet.PageSetup.FitToPagesWide = 1;
            //    myworksheet.PageSetup.LeftMargin = 0.3;
            //    myworksheet.PageSetup.RightMargin = 0.3;
            //    //Show Off the Grid Line of Excel
            //    myworkbook.Windows.get_Item(1).DisplayGridlines = false;
            //    //Sheet Name
            //    myworksheet.Name = "Sheet1";
            //    myexcelapp.StandardFontSize = 12;
            //    myexcelapp.StandardFont = "Zawgyi-One";


            //    #region Header

            //    Image img = null;
            //    string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            //    using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            //    {
            //        img = System.Drawing.Image.FromStream(stream);
            //        img.Save(tempFilePath);
            //    }
            //    // For Bank Logo --> Cash Control Report                                                                                      //left,top,width,height
            //    myworksheet.Shapes.AddPicture(tempFilePath, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 53, 2, 30, 30);

            //    //First Header                
            //    range = (Excel.Range)myworksheet.Cells[1, 2];// (Excel.Range)myworksheet.get_Range("B1", "D1");
            //    ReportHeaderMergeCells(range, false, false);
            //    range.Value = "Farmers Development Public Bank Limited";

            //    //Second Header             
            //    range = (Excel.Range)myworksheet.Cells[2, 2]; //(Excel.Range)myworksheet.get_Range("B2", "D2");
            //    ReportHeaderMergeCells(range, false, false);
            //    range.Value = "Account Department(Head Office)";

            //    //Third Header  
            //    range = (Excel.Range)myworksheet.Cells[3, 1]; //(Excel.Range)myworksheet.get_Range("B3", "D3");
            //    ReportHeaderMergeCells(range, false,true);
            //    range.Value = "ေငြသားရေငြ နွင့့္ ေငြသားထုတ္ေပးေငြ စာရင္း" ;

            //    //Fourth Header  
            //    range = (Excel.Range)myworksheet.Cells[5, 4];  //(Excel.Range)myworksheet.get_Range("B4", "D4");
            //    ReportHeaderMergeCells(range, true, false);
            //    range.Value = "(Kyats in Million)";
            //    #endregion Header

            //    #region Columns Header
            //    //For Sr No.    
            //    range = (Excel.Range)myworksheet.Cells[6, 1]; //(Excel.Range)myworksheet.get_Range("A5", Type.Missing);
            //    range.Value = "Sr No.";
            //    range.ColumnWidth = 15;
            //    ReportHeaderColumnMarge(range);

            //    //For Branch Code                
            //    range = (Excel.Range)myworksheet.Cells[6, 2];//(Excel.Range)myworksheet.get_Range("B5", Type.Missing);
            //    range.Value = "Branch Code";
            //    range.ColumnWidth = 18;
            //    ReportHeaderColumnMarge(range);

            //    //For Branch Name                
            //    range = (Excel.Range)myworksheet.Cells[6, 3]; //(Excel.Range)myworksheet.get_Range("C5", Type.Missing);
            //    range.Value = "Branch Name";
            //    range.ColumnWidth = 25;
            //    ReportHeaderColumnMarge(range);

            //    //For Amount                
            //    range = (Excel.Range)myworksheet.Cells[6, 4]; //(Excel.Range)myworksheet.get_Range("D5", Type.Missing);
            //    range.Value = "Amount";
            //    range.ColumnWidth = 20;
            //    ReportHeaderColumnMarge(range);


            //    #endregion Columns Header

            //    #region Row Data

            //    int SerialNo = 1;
            //    decimal totalamount = 0;
            //    #region ReportBody

            //    RowCounter = 7;
            //    foreach (PFMDTO00042 dto in list)
            //    {
            //        range = (Excel.Range)myworksheet.Cells[RowCounter, 1];
            //        range.Value = SerialNo;
            //        range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //        ReportItemColumnMarge(range);

            //        range = (Excel.Range)myworksheet.Cells[RowCounter, 2];
            //        range.NumberFormat = "@";
            //        range.Value = dto.SourceBranch;
            //        range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            //        ReportItemColumnMarge(range);


            //        range = (Excel.Range)myworksheet.Cells[RowCounter, 3];
            //        range.Value = dto.BranchName;
            //        range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            //        ReportItemColumnMarge(range);

            //        range = (Excel.Range)myworksheet.Cells[RowCounter, 4];
            //        range.Value = dto.Amount;
            //        range.NumberFormat = "#,##0.00";
            //        range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            //        ReportItemColumnMarge(range);

            //        totalamount += Convert.ToDecimal(dto.Amount);
            //        RowCounter++;
            //        SerialNo++;
            //    }



            //    #endregion ReportBody

            //    #region ReportFooter
            //    //For Grand Total
            //    range = myworksheet.get_Range("A" + RowCounter.ToString(), "C" + RowCounter.ToString());
            //    ReportHeaderColumnMarge(range);
            //    range.Value = "Grand Total : ";

            //    //For Grand Total Amount
            //    range = myworksheet.get_Range("D" + RowCounter.ToString(), Type.Missing);
            //    range.Value = totalamount;
            //    range.NumberFormat = "#,##0.00";
            //    ReportHeaderColumnMarge(range);
            //    range.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;

            //    #endregion ReportFooter

            //    #endregion Row Data

            //    myworksheet.Cells.Locked = true;
            //    myworksheet.Protect(Type.Missing, true, true, true, true, true, true, true, true, false, false, false, false, true, true, true);

            //    //Save Excel File To Location
            //    myworkbook.SaveAs(FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            //    //Close Work Book
            //    myworkbook.Close(true, Type.Missing, Type.Missing);
            //    //Quit That Excel Apps
            //    myexcelapp.Quit();
            //    //Release That Excel
            //    Marshal.ReleaseComObject(myexcelapp);

            //    #region Get Excel Processes and Kill it Immediately
            //    Process[] Processes;
            //    Processes = System.Diagnostics.Process.GetProcessesByName("EXCEL");
            //    //Check that Process is null or not
            //    if (Processes.Length > 0)
            //    {
            //        foreach (System.Diagnostics.Process p in Processes)
            //        {
            //            if (p.MainWindowTitle.Trim() == "")
            //                p.Kill();
            //        }
            //    }
            //    #endregion Get Excel Processes and Kill it Immediately

            //    Process.Start(FileName);
            //}
            //catch (Exception ex)
            //{

            //}

            #endregion
            dto.IDate = this.view.Date;
            CXUIScreenTransit.Transit("frmCBMVEW00002CashFlowRptViewer", true, new object[] { dto });
        }

        #endregion Cash Flow

        #region Daily Position Export To Excel
        //Export Excel By List
        public void DailyPositionExport(IList<PFMDTO00042> dto)
        {
            #region Old Code
            //try
            //{
            //    string FileName = Path.GetTempPath() + "Cash Flow Report.xlsx";
            //    Excel.Range range;                      //Excel Range File
            //    int RowCounter = 6;

            //    FileInfo fileinfo = new FileInfo(@FileName);
            //    if (fileinfo.Exists)
            //    {
            //        fileinfo.Attributes = FileAttributes.Normal;
            //        fileinfo.Delete();
            //    }
            //    Excel.Application myexcelapp = new Excel.Application();
            //    Excel.Workbook myworkbook = myexcelapp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            //    Excel.Worksheet myworksheet = (Excel.Worksheet)myworkbook.ActiveSheet;
            //    myworksheet.PageSetup.Orientation = Excel.XlPageOrientation.xlPortrait;
            //    myworksheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4;
            //    myworksheet.PageSetup.Zoom = false;
            //    myworksheet.PageSetup.FitToPagesWide = 1;
            //    myworksheet.PageSetup.LeftMargin = 0.3;
            //    myworksheet.PageSetup.RightMargin = 0.3;
            //    //Show Off the Grid Line of Excel
            //    myworkbook.Windows.get_Item(1).DisplayGridlines = false;
            //    //Sheet Name
            //    myworksheet.Name = "Sheet1";
            //    myexcelapp.StandardFontSize = 12;
            //    myexcelapp.StandardFont = "Zawgyi-One";


            //    #region Header

            //    Image img = null;
            //    string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            //    using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            //    {
            //        img = System.Drawing.Image.FromStream(stream);
            //        img.Save(tempFilePath);
            //    }
            //    // For Bank Logo --> Cash Control Report                                                                                      //left,top,width,height
            //    myworksheet.Shapes.AddPicture(tempFilePath, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 53, 2, 30, 30);

            //    //First Header                
            //    range = (Excel.Range)myworksheet.Cells[1, 2];// (Excel.Range)myworksheet.get_Range("B1", "D1");
            //    ReportHeaderMergeCells(range, false, false);
            //    range.Value = "Farmers Development Public Bank Limited";

            //    //Second Header             
            //    range = (Excel.Range)myworksheet.Cells[2, 2]; //(Excel.Range)myworksheet.get_Range("B2", "D2");
            //    ReportHeaderMergeCells(range, false, false);
            //    range.Value = "Account Department(Head Office)";

            //    //Third Header  
            //    range = (Excel.Range)myworksheet.Cells[3, 1]; //(Excel.Range)myworksheet.get_Range("B3", "D3");
            //    ReportHeaderMergeCells(range, false,true);
            //    range.Value = "ေငြသားရေငြ နွင့့္ ေငြသားထုတ္ေပးေငြ စာရင္း" ;

            //    //Fourth Header  
            //    range = (Excel.Range)myworksheet.Cells[5, 4];  //(Excel.Range)myworksheet.get_Range("B4", "D4");
            //    ReportHeaderMergeCells(range, true, false);
            //    range.Value = "(Kyats in Million)";
            //    #endregion Header

            //    #region Columns Header
            //    //For Sr No.    
            //    range = (Excel.Range)myworksheet.Cells[6, 1]; //(Excel.Range)myworksheet.get_Range("A5", Type.Missing);
            //    range.Value = "Sr No.";
            //    range.ColumnWidth = 15;
            //    ReportHeaderColumnMarge(range);

            //    //For Branch Code                
            //    range = (Excel.Range)myworksheet.Cells[6, 2];//(Excel.Range)myworksheet.get_Range("B5", Type.Missing);
            //    range.Value = "Branch Code";
            //    range.ColumnWidth = 18;
            //    ReportHeaderColumnMarge(range);

            //    //For Branch Name                
            //    range = (Excel.Range)myworksheet.Cells[6, 3]; //(Excel.Range)myworksheet.get_Range("C5", Type.Missing);
            //    range.Value = "Branch Name";
            //    range.ColumnWidth = 25;
            //    ReportHeaderColumnMarge(range);

            //    //For Amount                
            //    range = (Excel.Range)myworksheet.Cells[6, 4]; //(Excel.Range)myworksheet.get_Range("D5", Type.Missing);
            //    range.Value = "Amount";
            //    range.ColumnWidth = 20;
            //    ReportHeaderColumnMarge(range);


            //    #endregion Columns Header

            //    #region Row Data

            //    int SerialNo = 1;
            //    decimal totalamount = 0;
            //    #region ReportBody

            //    RowCounter = 7;
            //    foreach (PFMDTO00042 dto in list)
            //    {
            //        range = (Excel.Range)myworksheet.Cells[RowCounter, 1];
            //        range.Value = SerialNo;
            //        range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //        ReportItemColumnMarge(range);

            //        range = (Excel.Range)myworksheet.Cells[RowCounter, 2];
            //        range.NumberFormat = "@";
            //        range.Value = dto.SourceBranch;
            //        range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            //        ReportItemColumnMarge(range);


            //        range = (Excel.Range)myworksheet.Cells[RowCounter, 3];
            //        range.Value = dto.BranchName;
            //        range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            //        ReportItemColumnMarge(range);

            //        range = (Excel.Range)myworksheet.Cells[RowCounter, 4];
            //        range.Value = dto.Amount;
            //        range.NumberFormat = "#,##0.00";
            //        range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            //        ReportItemColumnMarge(range);

            //        totalamount += Convert.ToDecimal(dto.Amount);
            //        RowCounter++;
            //        SerialNo++;
            //    }



            //    #endregion ReportBody

            //    #region ReportFooter
            //    //For Grand Total
            //    range = myworksheet.get_Range("A" + RowCounter.ToString(), "C" + RowCounter.ToString());
            //    ReportHeaderColumnMarge(range);
            //    range.Value = "Grand Total : ";

            //    //For Grand Total Amount
            //    range = myworksheet.get_Range("D" + RowCounter.ToString(), Type.Missing);
            //    range.Value = totalamount;
            //    range.NumberFormat = "#,##0.00";
            //    ReportHeaderColumnMarge(range);
            //    range.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;

            //    #endregion ReportFooter

            //    #endregion Row Data

            //    myworksheet.Cells.Locked = true;
            //    myworksheet.Protect(Type.Missing, true, true, true, true, true, true, true, true, false, false, false, false, true, true, true);

            //    //Save Excel File To Location
            //    myworkbook.SaveAs(FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            //    //Close Work Book
            //    myworkbook.Close(true, Type.Missing, Type.Missing);
            //    //Quit That Excel Apps
            //    myexcelapp.Quit();
            //    //Release That Excel
            //    Marshal.ReleaseComObject(myexcelapp);

            //    #region Get Excel Processes and Kill it Immediately
            //    Process[] Processes;
            //    Processes = System.Diagnostics.Process.GetProcessesByName("EXCEL");
            //    //Check that Process is null or not
            //    if (Processes.Length > 0)
            //    {
            //        foreach (System.Diagnostics.Process p in Processes)
            //        {
            //            if (p.MainWindowTitle.Trim() == "")
            //                p.Kill();
            //        }
            //    }
            //    #endregion Get Excel Processes and Kill it Immediately

            //    Process.Start(FileName);
            //}
            //catch (Exception ex)
            //{

            //}

            #endregion
            CXUIScreenTransit.Transit("frmCBMVEW00003_DailyPositionRptViewer", true, new object[] { dto, this.view.Date });
        }

        #endregion DailyPosition

        #region Financial Statement Export To Excel
        //Export Excel By List
        public void FinancialStatementExport(IList<PFMDTO00042> dto)
        {
            CXUIScreenTransit.Transit("frmCBMVEW00005_FinancialRptViewer", true, new object[] { dto, this.view.Date });
        }

        #endregion Financial Statement

        #region Daily Improvement Export To Excel
        //Export Excel By List
        public void DailyImprovementExport(IList<PFMDTO00042> dtolist)
        {
            CXUIScreenTransit.Transit("frmCBMVEW00004_ImprovementRptViewer", true, new object[] { dtolist, this.view.Date });
        }

        #endregion Daily Improvement

        #region Daily Progress Export To Excel
        //Export Excel By List
        public void DailyProgressExport(IList<PFMDTO00042> dtolist)
        {
            CXUIScreenTransit.Transit("frmCBMVEW00006_DailyProgressRptViewer", true, new object[] { dtolist, this.view.Date });
        }

        #endregion Daily Improvement

        #region Liquidity Ratio Export To Excel

        public void Liquidity_RatioExport(PFMDTO00042 dto)
        {
            dto.IDate = this.view.Date;
            CXUIScreenTransit.Transit("frmCBMVEW00007_LR_RptViewer", true, new object[] { dto });
        }

        #endregion Liquidity Ratio

    }
}
