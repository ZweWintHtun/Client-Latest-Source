using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using System.Windows.Forms;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Cx.Cle;
using System.IO;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using System.Drawing.Imaging;

namespace Ace.Cbs.Mnm.Ptr
{
    public class MNMCTL00030 : AbstractPresenter, IMNMCTL00030
    {
        #region Properties

        //For Direct Print
        private int m_currentPageIndex;
        private IList<Stream> m_streams;
        //..End..

        private bool isPrintValidate = false;

        private IMNMVEW00030 view;
        public IMNMVEW00030 View
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }
        #endregion

        #region Methods
        private void WireTo(IMNMVEW00030 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetViewData());
            }
        }

        public PFMDTO00042 GetViewData()
        {
            PFMDTO00042 ViewData = new PFMDTO00042();
            ViewData.StartDate = this.view.Date;
            //ViewData.WorkStationId = 6;//CurrentUserEntity.WorkStationId
            ViewData.CreatedUserId = CurrentUserEntity.CurrentUserID;
            ViewData.SourceBranch = CurrentUserEntity.BranchCode;
            return ViewData;
        }

        public string DateString(DateTime date)
        {
            string Day = string.Empty;
            string Month = string.Empty;
            int day = date.Day;
            int month = date.Month;


            if (day == 1 || day == 21 || day == 31)
            { Day = (day < 10) ? "0" + Convert.ToString(day) + "st" : Convert.ToString(day) + "st"; }
            else if (day == 2 || day == 22)
            { Day = (day < 10) ? "0" + Convert.ToString(day) + "nd" : Convert.ToString(day) + "nd"; }
            else if (day == 3 || day == 23)
            { Day = (day < 10) ? "0" + Convert.ToString(day) + "rd" : Convert.ToString(day) + "rd"; }
            else
            { Day = (day < 10) ? "0" + Convert.ToString(day) + "th" : Convert.ToString(day) + "th"; }

            switch (month)
            {
                case 1: Month = "January"; break;
                case 2: Month = "February"; break;
                case 3: Month = "March"; break;
                case 4: Month = "April"; break;
                case 5: Month = "May"; break;
                case 6: Month = "June"; break;
                case 7: Month = "July"; break;
                case 8: Month = "August"; break;
                case 9: Month = "September"; break;
                case 10: Month = "October"; break;
                case 11: Month = "November"; break;
                case 12: Month = "December"; break;

            }
            string Date = Day + " " + "day of" + " " + Month;
            return Date;

        }

        public string CurrencyString(string currency)
        {
            string cur = string.Empty;
            if (currency == "KYT")
            { cur = "kyats"; }
            else if (currency == "EUR")
            { cur = "euros"; }
            else if (currency == "USD")
            { cur = "us dollars"; }
            else if (currency == "SGD")
            { cur = "singapore dollars"; }
            return cur;
        }

        public string NumberToText(int n)
        {
            if (n < 0)
                return "Minus " + NumberToText(-n);
            else if (n == 0)
                return "";
            else if (n <= 19)
                return new string[] {"One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", 
         "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", 
         "Seventeen", "Eighteen", "Nineteen"}[n - 1] + " ";
            else if (n <= 99)
                return new string[] {"Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", 
         "Eighty", "Ninety"}[n / 10 - 2] + " " + NumberToText(n % 10);
            else if (n <= 199)
                return "One Hundred " + NumberToText(n % 100);
            else if (n <= 999)
                return NumberToText(n / 100) + "Hundreds " + NumberToText(n % 100);
            else if (n <= 1999)
                return "One Thousand " + NumberToText(n % 1000);
            else if (n <= 999999)
                return NumberToText(n / 1000) + "Thousands " + NumberToText(n % 1000);
            else if (n <= 1999999)
                return "One Million " + NumberToText(n % 1000000);
            else if (n <= 999999999)
                return NumberToText(n / 1000000) + "Millions " + NumberToText(n % 1000000);
            else if (n <= 1999999999)
                return "One Billion " + NumberToText(n % 1000000000);
            else
                return NumberToText(n / 1000000000) + "Billions " + NumberToText(n % 1000000000);
        }

        private IList<string[]> GetPrintingFixedDepositReceiptList(PFMDTO00032 printList)
        {
            IList<string[]> printingList = new List<string[]>();

            // Are you sure to print?
            //if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC00002) == DialogResult.Yes)
            //{
            //IList<MNMDTO00039> FixedDepositLists = new List<MNMDTO00039>();
            //if (printLists.Count > 0)
            //{
            //    for (int i = 0; i < printLists.Count; i++)
            //    {
            MNMDTO00039 data = new MNMDTO00039();

            data.AccountNo = printList.AccountNo;
            data.ReceiptNo = printList.ReceiptNo;
            data.Amount = printList.Amount;
            data.ReceiptDate = this.DateString(Convert.ToDateTime(printList.RDate));//20th day of January
            data.Name = printList.Name;
            data.Nrc = printList.Nrc;
            data.TownShipDesp = printList.Address;
            //CurrencyDTO currecy = CXCLE00002.Instance.GetScalarObject<CurrencyDTO>("Cur.DescriptioninWords.Select", new object[] { PrintLists[i].CurrencyCode, true });
            data.Cur = this.CurrencyString(printList.CurrencyCode);//to change
            int amount = Convert.ToInt32(data.Amount);
            data.WordAmount = this.NumberToText(amount) + " " + "Only";
            data.Duration = printList.DurationTime;
            decimal duration = printList.Duration;
            decimal rate = Math.Round(printList.InterestRate, 2);
            data.InterestRate = Convert.ToInt32(rate);
            data.OpenDate = printList.MatureDate;
            if (printList.ReceiptNo.Contains('D'))
            {
                string noOfDays = printList.ReceiptNo.Substring(0, printList.ReceiptNo.IndexOf('D'));
                data.MaturityDate = printList.MatureDate.AddDays(Int32.Parse(noOfDays));
            }
            else if (printList.ReceiptNo.Contains('M'))
            {
                string noOfMonths = printList.ReceiptNo.Substring(0, printList.ReceiptNo.IndexOf('M'));
                data.MaturityDate = printList.MatureDate.AddMonths(Int32.Parse(noOfMonths));
            }
            else if (printList.ReceiptNo.Contains('Y'))
            {
                string noOfYears = printList.ReceiptNo.Substring(0, printList.ReceiptNo.IndexOf('Y'));
                data.MaturityDate = printList.MatureDate.AddYears(Int32.Parse(noOfYears));
            }

            data.SourceBr = printList.SourceBranchCode;

            printingList.Add(new string[] { DateTime.Now.ToString("dd/MM/yyyy") });// 1
            printingList.Add(new string[] { DateTime.Now.ToString("dd/MM/yyyy") });// 2
            printingList.Add(new string[] { data.Name }); // 3
            printingList.Add(new string[] { data.Name }); // 4
            printingList.Add(new string[] { data.Duration }); // 5
            printingList.Add(new string[] { DateTime.Now.ToString("dd/MM/yyyy"), data.SourceBr, data.AccountNo, data.Duration, data.InterestRate.ToString() + " %", data.MaturityDate.ToString("dd/MM/yyyy") });// 6
            printingList.Add(new string[] { data.InterestRate.ToString() + " %" }); // 7
            printingList.Add(new string[] { data.MaturityDate.ToString("dd/MM/yyyy") }); // 8
            printingList.Add(new string[] { data.WordAmount + " -" }); // 9
            printingList.Add(new string[] { data.WordAmount + " -" }); // 10
            printingList.Add(new string[] { String.Format("{0:n0}", data.Amount) + " /-" }); // 11
            printingList.Add(new string[] { String.Format("{0:n0}", data.Amount) + " /-" }); //12
            //FixedDepositLists.Add(data);
            //    }
            //}

            //FixedDepositLists = FixedDepositLists.OrderBy(f => f.AccountNo).ToList(); // Sorted by AccountNo ascending

            //int count = FixedDepositLists.Count;
            //int k = 0;
            //do
            //{
            //    if(FixedDepositLists.Count > 0)
            //    {
            //        //string[] str
            //        printingList.Add(new string[] { DateTime.Now.ToString("dd/MM/yyyy"), // 1
            //                             DateTime.Now.ToString("dd/MM/yyyy"), // 2
            //                             FixedDepositLists[k].Name, // 3
            //                             FixedDepositLists[k].Name, // 4
            //                             FixedDepositLists[k].Duration, // 5
            //                             DateTime.Now.ToString("dd/MM/yyyy"), // 6
            //                             FixedDepositLists[k].SourceBr, // 6
            //                             FixedDepositLists[k].AccountNo, // 6
            //                             FixedDepositLists[k].Duration, // 6
            //                             FixedDepositLists[k].InterestRate.ToString() + " %", // 6
            //                             FixedDepositLists[k].MaturityDate.ToString("dd/MM/yyyy"), // 6
            //                             FixedDepositLists[k].InterestRate.ToString() + " %", // 7
            //                             FixedDepositLists[k].MaturityDate.ToString("dd/MM/yyyy"), // 8
            //                             FixedDepositLists[k].WordAmount + " -", // 9
            //                             FixedDepositLists[k].WordAmount + " -", // 10
            //                             String.Format("{0:n0}",FixedDepositLists[k].Amount) + " /-", // 11
            //                             String.Format("{0:n0}",FixedDepositLists[k].Amount) + " /-" // 12
            //                           });
            //            //printingList.Add(str);                        
            //    }
            //    //else
            //    //{
            //    //    string[] str = { };
            //    //    printingList.Add(str);
            //    //}
            //    k++;
            //} while (k != count);//stop k == count
            //}
            return printingList;
        }

        #region For Direct Print

        private void Run(IList<MNMDTO00039> printData)
        {
            LocalReport report = new LocalReport();
            report.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "MNMRDLC00093.rdlc";
            ReportDataSource dataset = new ReportDataSource("DSMNMRDLC00093", printData);
            report.DataSources.Add(dataset);
            dataset.Value = printData;
            //report.DataSources.Add(new ReportDataSource("DSMNMRDLC00039", printData));

            Export(report);

            m_currentPageIndex = 0;
            Print();
        }

        private void Export(LocalReport report)
        {
            string deviceInfo =
              "<DeviceInfo>" +
              "  <OutputFormat>EMF</OutputFormat>" +
              "  <PageWidth>20in</PageWidth>" +
              "  <PageHeight>50in</PageHeight>" +
              "  <MarginTop>0.25in</MarginTop>" +
              "  <MarginLeft>0.25in</MarginLeft>" +
              "  <MarginRight>0.25in</MarginRight>" +
              "  <MarginBottom>0.25in</MarginBottom>" +
              "</DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream, out warnings);

            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }

        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding,
                              string mimeType, bool willSeek)
        {
            Stream stream = new FileStream(name + "." + fileNameExtension, FileMode.Create);
            m_streams.Add(stream);
            return stream;
        }

        private void Print()
        {
            PrintDialog printDialog = new PrintDialog();
            string printerName = printDialog.PrinterSettings.PrinterName;

            if (m_streams == null || m_streams.Count == 0)
                return;

            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = printerName;
            if (!printDoc.PrinterSettings.IsValid)
            {
                string msg = String.Format("Can't find printer \"{0}\".", printerName);
                Console.WriteLine(msg);
                return;
            }
            printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
            printDoc.Print();
        }

        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);
            ev.Graphics.DrawImage(pageImage, 0, 0);

            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        #endregion

        #endregion

        #region Main Methods
        public IList<PFMDTO00032> SelectFReceiptData()
        {
            //if (!CXCOM00006.Instance.IsExceedTodayDate(this.view.Date))
            //{
            IList<PFMDTO00032> FReceiptData = new List<PFMDTO00032>();
            PFMDTO00042 DataDTO = this.GetViewData();
            FReceiptData = CXClientWrapper.Instance.Invoke<IMNMSVE00030, IList<PFMDTO00032>>(x => x.GetFReceiptData(DataDTO));
            return FReceiptData;
            //}
            //else
            //{
            //    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00160, this.view.Date);//Require Date is not greater than today.
            //    return null;
            //}
        }

        //Added By HWKO (27-Apr-2017)
        public void DirectPrint(IList<PFMDTO00032> printLists)
        {
            this.isPrintValidate = true;

            if (printLists.Count > 0)
            {
                //int result = 0;
                //for (int j = 0; j < printList.Count; j++)
                //{
                //    CXCLE00005.Instance.PrintingLine("PrintFixedDepositCode", "Heading",j+1, "PrintFixedDepositPrinting", printList[j], false);
                //}
                IList<string[]> printList = new List<string[]>();
                for (int i = 0; i < printLists.Count; i++)
                {
                    printList = this.GetPrintingFixedDepositReceiptList(printLists[i]);
                    CXCLE00005.Instance.PrintingList("PrintFixedDepositCode", "Heading", "PrintFixedDepositPrinting", printList, false, false);
                }
                //Get Printed Lists of fixed deposit
                IList<PFMDTO00032> printedList = new List<PFMDTO00032>();

                for (int i = 0; i < printList.Count; i++)
                {
                    PFMDTO00032 printFixedDeposit = new PFMDTO00032();
                    string[] printline = printList[i];
                    printFixedDeposit.Name = printline[2];
                    printFixedDeposit.DurationTime = printline[4];
                    printFixedDeposit.SourceBranchCode = printline[6];
                    printFixedDeposit.AccountNo = printline[7];
                    printedList.Add(printFixedDeposit);
                }

                //Save the printed data here


                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
                else
                {
                    this.View.Successful(CXMessage.MI00012); // Printing successful.
                }
            }
            this.isPrintValidate = false;
        }

        public void DirectPrintUsingRDLC(IList<PFMDTO00032> printLists)
        {
            IList<MNMDTO00039> lists = new List<MNMDTO00039>();

            if (printLists.Count > 0)
            {
                for (int i = 0; i < printLists.Count; i++)
                {
                    MNMDTO00039 data = new MNMDTO00039();

                    data.AccountNo = printLists[i].AccountNo;
                    data.ReceiptNo = printLists[i].ReceiptNo;
                    data.Amount = printLists[i].Amount;
                    data.ReceiptDate = this.DateString(Convert.ToDateTime(printLists[i].RDate));//20th day of January
                    data.Name = printLists[i].Name;
                    data.Nrc = printLists[i].Nrc;
                    data.TownShipDesp = printLists[i].Address;
                    //CurrencyDTO currecy = CXCLE00002.Instance.GetScalarObject<CurrencyDTO>("Cur.DescriptioninWords.Select", new object[] { PrintLists[i].CurrencyCode, true });
                    data.Cur = this.CurrencyString(printLists[i].CurrencyCode);//to change
                    int amount = Convert.ToInt32(data.Amount);
                    data.WordAmount = this.NumberToText(amount) + " " + "Only";
                    data.Duration = printLists[i].DurationTime;
                    decimal duration = printLists[i].Duration;
                    decimal rate = Math.Round(printLists[i].InterestRate, 2);
                    data.InterestRate = Convert.ToInt32(rate);
                    data.OpenDate = printLists[i].MatureDate;
                    if (printLists[i].ReceiptNo.Contains('D'))
                    {
                        string noOfDays = printLists[i].ReceiptNo.Substring(0, printLists[i].ReceiptNo.IndexOf('D'));
                        data.MaturityDate = printLists[i].MatureDate.AddDays(Int32.Parse(noOfDays));
                    }
                    else if (printLists[i].ReceiptNo.Contains('M'))
                    {
                        string noOfMonths = printLists[i].ReceiptNo.Substring(0, printLists[i].ReceiptNo.IndexOf('M'));
                        data.MaturityDate = printLists[i].MatureDate.AddMonths(Int32.Parse(noOfMonths));
                    }
                    else if (printLists[i].ReceiptNo.Contains('Y'))
                    {
                        string noOfYears = printLists[i].ReceiptNo.Substring(0, printLists[i].ReceiptNo.IndexOf('Y'));
                        data.MaturityDate = printLists[i].MatureDate.AddYears(Int32.Parse(noOfYears));
                    }

                    data.SourceBr = printLists[i].SourceBranchCode;

                    lists.Add(data);
                }

                if (lists.Count > 0)
                {
                    //for (int j = 0; j < lists.Count; j++)
                    //{
                    //    this.Run(lists[j]);
                    //}
                    this.Run(lists);
                }
            }
        }

        #endregion


    }
}
