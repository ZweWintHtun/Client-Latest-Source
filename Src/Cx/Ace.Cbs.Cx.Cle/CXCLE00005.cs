using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Cx.Cle
{
    /// <summary>
    /// Printing Document Controller
    /// </summary>
    public class CXCLE00005
    {
        #region Variable
        string printerName = string.Empty;
        PrintDocument printDocument;
        PrintDialog printDialog;
        public string[] PrintLine { get; set; }
        public IList<string[]> PrintList { get; set; }
        public bool IsPrintMultiLine { get; set; }
        public bool IsPrintMultiPage { get; set; }
        public int MaximumLinesPerPage   { get; set; }
        public int LastPrintedLine { get; set; }
        public IList<PFMDTO00034> PrintLocationItems { get; set; }
        public PFMDTO00038 PrintLocationHeader { get; set; }
        
        private Font printFont;        
        private static CXCLE00005 instance;
        public static CXCLE00005 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = SpringApplicationContext.Instance.Resolve<CXCLE00005>("CXPrintingController");
                    instance.printDocument = new PrintDocument();
                    instance.printDialog = new PrintDialog();
                }
                else
                {
                    instance.LastPrintedLine = 0;
                    instance.printDocument = new PrintDocument();
                    instance.printDialog = new PrintDialog();
                }

                return instance;
            }

        }        
        public string Font
        {
            get { return CXCOM00007.Instance.GetValueByKeyName("PrintingFont"); }

        }
        #endregion

        #region Constractor
        public CXCLE00005()
        {
            
        }
        #endregion

        #region Properties
        private List<string[]> printedList = new List<string[]>();
        public List<string[]> PrintedList
        {
            get
            {
                return this.printedList; 
            }
        }

        private int startLineNo = 1;
        public int StartLineNo
        {
            get
            {
                return startLineNo;
            }
            set
            {
                startLineNo = value;
            }
        }
        #endregion

        #region Method
        private bool IsValidInputParameter(string str)
        {
            if (string.IsNullOrEmpty(str.Trim()))
                return false;
            else
                return true;
        }

        public void PrintingLine(string code, string position, int printLineNo, string printDocumentName, string[] dataRow, bool isValidateDataLength)
        {
            using (WindowsImpersonationContext wic = WindowsIdentity.Impersonate(IntPtr.Zero))
            {
                //To check input param is valid or empty
                if (this.IsValidInputParameter(code) && this.IsValidInputParameter(position) && this.IsValidInputParameter(printDocumentName))
                {
                    if (dataRow.Count() > 0)
                    {
                        PFMDTO00038 header = CXCLE00006.Instance.SelectPrintLocationHeaderByCodeAndPosition(code, position);
                        if (header != null && header.Id != 0)
                        {
                            this.PrintLocationHeader = header;
                            IList<PFMDTO00034> items = CXCLE00006.Instance.SelectPrintLocationItemByPrintLocationHeaderId(this.PrintLocationHeader.Id, printLineNo);
                            if (items.Count > 0)
                            {
                                this.PrintLocationItems = items;
                                if (dataRow.Count() == this.PrintLocationItems.Count())
                                {
                                    if (isValidateDataLength)
                                    {
                                        if (!this.IsValidDataLength(dataRow, this.PrintLocationItems))
                                        {
                                            throw new Exception(CXMessage.ME90029);
                                        }
                                    }

                                    this.IsPrintMultiLine = false;
                                    this.PrintLine = dataRow;

                                    printDocument.DocumentName = printDocumentName;

                                    if (this.PrintLocationHeader.PrinterName == null || this.PrintLocationHeader.PrinterName.Trim().Equals(string.Empty))
                                    {
                                        printDocument.PrinterSettings.PrinterName = printDialog.PrinterSettings.PrinterName;
                                    }
                                    else
                                    {
                                        printDocument.PrinterSettings.PrinterName = this.PrintLocationHeader.PrinterName;
                                    }

                                    printDocument.PrintPage += new PrintPageEventHandler(this.PrintDocument_PrintPage);

                                    printDocument.Print();
                                }
                                else
                                {
                                    throw new Exception(CXMessage.ME90030);
                                }
                            }
                            else
                            {
                                throw new Exception(CXMessage.ME90031);
                            }
                        }
                        else
                        {
                            throw new Exception(CXMessage.ME90032);
                        }
                    }
                    else
                    {
                        throw new Exception(CXMessage.MI00039);
                    }
                }
                else
                {
                    throw new Exception(CXMessage.ME90034);
                }
            }
        }

        public void PrintingList(string code, string position, string printDocumentName, IList<string[]> dataList, bool isValidateDataLength, bool isMultiplePage)
        {            
            using (WindowsImpersonationContext wic = WindowsIdentity.Impersonate(IntPtr.Zero))
            {
                // define multiple page or not.
                this.IsPrintMultiPage = isMultiplePage;
                this.LastPrintedLine = 0;

                //To check input param is valid or empty
                if (this.IsValidInputParameter(code) && this.IsValidInputParameter(position) && this.IsValidInputParameter(printDocumentName))
                {
                    if (dataList != null)
                    {
                        PFMDTO00038 header = CXCLE00006.Instance.SelectPrintLocationHeaderByCodeAndPosition(code, position);
                        if (header.Id != 0)
                        {
                            this.PrintLocationHeader = header;
                            IList<PFMDTO00034> items = CXCLE00006.Instance.SelectPrintLocationItemByPrintLocationHeaderId(this.PrintLocationHeader.Id);
                            if (items.Count > 0)
                            {
                                this.PrintLocationItems = items;
                                this.MaximumLinesPerPage = (this.PrintLocationItems.GroupBy(x => x.LineNumber)).ToList().Count;
                                if (this.PrintLocationHeader.MaximumLine > this.MaximumLinesPerPage)
                                {
                                    if (CXUIMessageUtilities.ShowMessageByCode("MC00002") == DialogResult.No)
                                        return;
                                }
                                else if (this.PrintLocationHeader.MaximumLine < this.MaximumLinesPerPage)
                                {
                                    if (CXUIMessageUtilities.ShowMessageByCode("MC00002") == DialogResult.No)
                                        return;
                                    else
                                    {
                                        this.MaximumLinesPerPage = this.PrintLocationHeader.MaximumLine;
                                    }
                                }

                                int lineNo = this.startLineNo;

                                for (int rowIndex = 0; rowIndex < dataList.Count; rowIndex++)
                                {
                                    if (rowIndex >= this.MaximumLinesPerPage && isMultiplePage == false)
                                    {
                                        break;
                                    }

                                    var result = from value in this.PrintLocationItems
                                                 where value.LineNumber == lineNo
                                                 select value;

                                    IList<PFMDTO00034> colLists = result.ToList();
                                    
                                    if (dataList[rowIndex].Count() != colLists.Count())
                                    {
                                        throw new Exception(CXMessage.ME90035);
                                    }

                                    if (isValidateDataLength)
                                    {
                                        if (!this.IsValidDataLength(dataList[rowIndex], colLists))
                                        {
                                            throw new Exception(CXMessage.ME90029);
                                        }
                                    }

                                    if (lineNo < this.MaximumLinesPerPage)
                                    {
                                        lineNo++;
                                    }
                                    else
                                    {
                                        lineNo = 1;
                                    }
                                }

                                this.IsPrintMultiLine = true;
                                this.PrintList = dataList;
                                this.LastPrintedLine = 0;

                                printDocument.DocumentName = printDocumentName;
                                if (this.PrintLocationHeader.PrinterName == null || this.PrintLocationHeader.PrinterName.Trim().Equals(string.Empty))
                                {
                                    printDocument.PrinterSettings.PrinterName = printDialog.PrinterSettings.PrinterName;
                                }
                                else
                                {
                                    printDocument.PrinterSettings.PrinterName = this.PrintLocationHeader.PrinterName;// "\\192.168.1.29\\Cannon LBP29000";//+
                                }

                                printDocument.PrintPage += new PrintPageEventHandler(this.PrintDocument_PrintPage);

                                printDocument.Print();

                            }
                            else
                            {
                                throw new Exception(CXMessage.ME90032);
                            }
                        }

                        else
                        {
                            throw new Exception(CXMessage.ME90032);
                        }
                    }
                    else
                    {
                        throw new Exception(CXMessage.MI00039);
                    }
                }
                else
                {
                    throw new Exception(CXMessage.ME90034);
                }
            }
        }

        public void PrintingList(string code, string position, string printDocumentName, IList<string[]> dataList, bool isValidateDataLength, bool isMultiplePage,out int lastLintNo)
        {
            using (WindowsImpersonationContext wic = WindowsIdentity.Impersonate(IntPtr.Zero))
            {
                // define multiple page or not.
                this.IsPrintMultiPage = isMultiplePage;
                this.LastPrintedLine = 0;
                lastLintNo = 0;
                //To check input param is valid or empty
                if (this.IsValidInputParameter(code) && this.IsValidInputParameter(position) && this.IsValidInputParameter(printDocumentName))
                {
                    if (dataList != null)
                    {
                        PFMDTO00038 header = CXCLE00006.Instance.SelectPrintLocationHeaderByCodeAndPosition(code, position);
                        if (header.Id != 0)
                        {
                            this.PrintLocationHeader = header;
                            IList<PFMDTO00034> items = CXCLE00006.Instance.SelectPrintLocationItemByPrintLocationHeaderId(this.PrintLocationHeader.Id);
                            if (items.Count > 0)
                            {
                                this.PrintLocationItems = items;
                                this.MaximumLinesPerPage = (this.PrintLocationItems.GroupBy(x => x.LineNumber)).ToList().Count;
                                if (this.PrintLocationHeader.MaximumLine > this.MaximumLinesPerPage)
                                {
                                    if (CXUIMessageUtilities.ShowMessageByCode("MC00002") == DialogResult.No)
                                        return;
                                }
                                else if (this.PrintLocationHeader.MaximumLine < this.MaximumLinesPerPage)
                                {
                                    if (CXUIMessageUtilities.ShowMessageByCode("MC00002") == DialogResult.No)
                                        return;
                                    else
                                    {
                                        this.MaximumLinesPerPage = this.PrintLocationHeader.MaximumLine;
                                    }
                                }

                                int lineNo = startLineNo = this.MaximumLinesPerPage < this.startLineNo ? 1 : this.startLineNo;

                                for (int rowIndex = 0; rowIndex < dataList.Count; rowIndex++)
                                {
                                    if (rowIndex >= this.MaximumLinesPerPage && isMultiplePage == false)
                                    {
                                        break;
                                    }

                                    var result = from value in this.PrintLocationItems
                                                 where value.LineNumber == lineNo
                                                 select value;

                                    IList<PFMDTO00034> colLists = result.ToList();
                                    if (dataList[rowIndex].Count() != colLists.Count())
                                    {
                                        throw new Exception(CXMessage.ME90035);
                                    }

                                    if (isValidateDataLength)
                                    {
                                        if (!this.IsValidDataLength(dataList[rowIndex], colLists))
                                        {
                                            throw new Exception(CXMessage.ME90029);
                                        }
                                    }

                                    if (lineNo < this.MaximumLinesPerPage)
                                    {
                                        lineNo++;
                                    }
                                    else
                                    {
                                        lineNo = 1;
                                    }
                                }

                                lastLintNo = lineNo;
                                this.IsPrintMultiLine = true;
                                this.PrintList = dataList;
                                this.LastPrintedLine = 0;

                                printDocument.DocumentName = printDocumentName;
                                if (this.PrintLocationHeader.PrinterName == null || this.PrintLocationHeader.PrinterName.Trim().Equals(string.Empty))
                                {
                                    printDocument.PrinterSettings.PrinterName = printDialog.PrinterSettings.PrinterName;
                                }
                                else
                                {
                                    printDocument.PrinterSettings.PrinterName = this.PrintLocationHeader.PrinterName;// "\\192.168.1.29\\Cannon LBP29000";//+
                                }

                                printDocument.PrintPage += new PrintPageEventHandler(this.PrintDocument_PrintPage);

                                printDocument.Print();

                            }
                            else
                            {
                                throw new Exception(CXMessage.ME90032);
                            }
                        }

                        else
                        {
                            throw new Exception(CXMessage.ME90032);
                        }
                    }
                    else
                    {
                        throw new Exception(CXMessage.MI00039);
                    }
                }
                else
                {
                    throw new Exception(CXMessage.ME90034);
                }
            }
        }

        public void PrintingList(string code, string position, string printDocumentName, IList<string[]> dataList, bool isValidateDataLength, bool isMultiplePage,bool isMultipleLine)
        {
            using (WindowsImpersonationContext wic = WindowsIdentity.Impersonate(IntPtr.Zero))
            {
                // define multiple page or not.
                this.IsPrintMultiPage = isMultiplePage;
                this.LastPrintedLine = 0;

                //To check input param is valid or empty
                if (this.IsValidInputParameter(code) && this.IsValidInputParameter(position) && this.IsValidInputParameter(printDocumentName))
                {
                    if (dataList != null)
                    {
                        PFMDTO00038 header = CXCLE00006.Instance.SelectPrintLocationHeaderByCodeAndPosition(code, position);
                        if (header.Id != 0)
                        {
                            this.PrintLocationHeader = header;

                            IList<PFMDTO00034> items = CXCLE00006.Instance.SelectPrintLocationItemByPrintLocationHeaderId(this.PrintLocationHeader.Id);
                            if (items.Count > 0)
                            {
                                this.PrintLocationItems = items;
                                this.MaximumLinesPerPage = (this.PrintLocationItems.GroupBy(x => x.LineNumber)).ToList().Count;
                                if (this.PrintLocationHeader.MaximumLine > this.MaximumLinesPerPage)
                                {
                                    if (CXUIMessageUtilities.ShowMessageByCode("MC00002") == DialogResult.No)
                                        return;
                                }
                                else if (this.PrintLocationHeader.MaximumLine < this.MaximumLinesPerPage)
                                {
                                    if (CXUIMessageUtilities.ShowMessageByCode("MC00002") == DialogResult.No)
                                        return;
                                    else
                                    {
                                        this.MaximumLinesPerPage = this.PrintLocationHeader.MaximumLine;
                                    }
                                }

                                int lineNo = this.startLineNo;

                                for (int rowIndex = 0; rowIndex < items.Count; rowIndex++)
                                {
                                    if (rowIndex >= this.MaximumLinesPerPage && isMultiplePage == false)
                                    {
                                        break;
                                    }

                                    var result = from value in this.PrintLocationItems
                                                 where value.LineNumber == lineNo
                                                 select value;

                                    IList<PFMDTO00034> colLists = result.ToList();
                                    
                                    //int xx = dataList[rowIndex].Count();

                                    //if (items[rowIndex].Count() != colLists.Count())
                                    //{
                                    //    throw new Exception(CXMessage.ME90035);
                                    //}

                                    if (isValidateDataLength)
                                    {
                                        if (!this.IsValidDataLength(dataList[rowIndex], colLists))
                                        {
                                            throw new Exception(CXMessage.ME90029);
                                        }
                                    }

                                    if (lineNo < this.MaximumLinesPerPage)
                                    {
                                        lineNo++;
                                    }
                                    else
                                    {
                                        lineNo = 1;
                                    }
                                }

                                this.IsPrintMultiLine = isMultipleLine;
                                this.PrintList = dataList;
                                this.LastPrintedLine = 0;

                                printDocument.DocumentName = printDocumentName;
                                if (this.PrintLocationHeader.PrinterName == null || this.PrintLocationHeader.PrinterName.Trim().Equals(string.Empty))
                                {
                                    printDocument.PrinterSettings.PrinterName = printDialog.PrinterSettings.PrinterName;
                                }
                                else
                                {
                                    printDocument.PrinterSettings.PrinterName = this.PrintLocationHeader.PrinterName;// "\\192.168.1.29\\Cannon LBP29000";//+
                                }

                                printDocument.PrintPage += new PrintPageEventHandler(this.PrintDocument_PrintPage);

                                printDocument.Print();

                            }
                            else
                            {
                                throw new Exception(CXMessage.ME90032);
                            }
                        }

                        else
                        {
                            throw new Exception(CXMessage.ME90032);
                        }
                    }
                    else
                    {
                        throw new Exception(CXMessage.MI00039);
                    }
                }
                else
                {
                    throw new Exception(CXMessage.ME90034);
                }
            }
        }


        public void ClearPrintedList()
        {
            this.printedList.Clear();
        }

        private StringFormat AlignString(int alignment)
        {
            StringFormat stringFormat = new StringFormat();           
            switch (alignment)
            {               
                case 1: stringFormat.Alignment = StringAlignment.Near;// left alignment
                    break;
                case 2: stringFormat.Alignment = StringAlignment.Far;// right alignment
                    break;
                case 3: stringFormat.Alignment = StringAlignment.Center;// Center alignment
                    break;
            }
            return stringFormat;

        }
        private bool IsValidDataLength(string[] row, IList<PFMDTO00034> colList)
        {
            int colIndex = 0;
            foreach (PFMDTO00034 item in colList)
            {                
                if (row[colIndex] == null)
                    return false;
                else if (row[colIndex].Trim().Length > item.Length)
                {
                    return false;
                }
                colIndex++;
            }
            return true;
        }     
       
        #endregion

        #region Event
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                StringFormat stringFormat = new StringFormat();
                float leftMargin = e.MarginBounds.Left;
                float topMargin = e.MarginBounds.Top;
                int lineNo = this.startLineNo;
                string line = null;
                if (IsPrintMultiLine)
                {
                    while (lineNo <= this.MaximumLinesPerPage && (this.LastPrintedLine < PrintList.Count()))
                    {
                        var colList = (from value in this.PrintLocationItems
                                      where value.LineNumber == lineNo
                                       select value).ToList < PFMDTO00034>();

                        this.PrintLine = this.PrintList[this.LastPrintedLine];
                        for (int i = 0; i < this.PrintLine.Length; i++)
                        {
                            this.printFont = new Font(this.Font, (float)Convert.ToDecimal(colList[i].FontSize));
                            stringFormat = AlignString(colList[i].Alignment);
                            line = this.PrintLine[i].Trim().Length > colList[i].Length ? this.PrintLine[i].Substring(0, colList[i].Length) : this.PrintLine[i];//string.length must less than Length
                            e.Graphics.DrawString(line, printFont, Brushes.Black, (float)Convert.ToDecimal(colList[i].XLocation.ToString()), (float)Convert.ToDecimal(colList[i].YLocation.ToString()), stringFormat);
                        }

                        this.printedList.Add(this.PrintLine);

                        this.LastPrintedLine++;

                        if (lineNo == this.MaximumLinesPerPage)
                        {
                            this.startLineNo = 1;
                        }
                        
                        lineNo++;
                    }

                    if (this.IsPrintMultiPage && this.LastPrintedLine < this.PrintList.Count)
                    {
                        e.HasMorePages = true;
                    }
                    else
                        e.HasMorePages = false;

                }
                else
                {
                    int colIndex = 0;
                    foreach (PFMDTO00034 printLocationItem in PrintLocationItems)
                    {
                        this.printFont = new Font(this.Font, (float)Convert.ToDecimal(printLocationItem.FontSize));
                        stringFormat = AlignString(printLocationItem.Alignment);
                        line = this.PrintLine[colIndex].Trim().Length > printLocationItem.Length ? this.PrintLine[colIndex].Substring(0, printLocationItem.Length) : this.PrintLine[colIndex];//string.length must less than Length
                        e.Graphics.DrawString(line, printFont, Brushes.Black, (float)Convert.ToDecimal(printLocationItem.XLocation.ToString()), (float)Convert.ToDecimal(printLocationItem.YLocation.ToString()), stringFormat);
                        colIndex++;
                    }

                    e.HasMorePages = false;
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }
        
        #endregion
    }
}
