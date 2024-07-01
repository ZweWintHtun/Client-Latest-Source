using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Cx.Cle;
using Microsoft.Reporting.WinForms;
using Ace.Windows.Core.Utt;
using System.IO;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00105 : BaseDockingForm
    {
        #region Properties
        public IList<PFMDTO00032> PrintLists { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        #endregion

        #region Constructor
        public MNMVEW00105()
        {
            InitializeComponent();
        }

        public MNMVEW00105(IList<PFMDTO00032> printLists)
        {
            this.PrintLists = printLists;
            InitializeComponent();
        }
        #endregion

        #region Methods

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

        #endregion

        private void MNMVEW00105_Load(object sender, EventArgs e)
        {
            IList<MNMDTO00039> lists = new List<MNMDTO00039>();

            if (this.PrintLists.Count > 0)
            {
                for (int i = 0; i < PrintLists.Count; i++)
                { 
                    MNMDTO00039 data = new MNMDTO00039();

                    data.AccountNo = PrintLists[i].AccountNo;
                    data.ReceiptNo = PrintLists[i].ReceiptNo;
                    data.Amount = PrintLists[i].Amount;
                    data.ReceiptDate = this.DateString(Convert.ToDateTime(PrintLists[i].RDate));//20th day of January
                    data.Name = PrintLists[i].Name;
                    data.Nrc = PrintLists[i].Nrc;
                    data.TownShipDesp = PrintLists[i].Address;
                    //CurrencyDTO currecy = CXCLE00002.Instance.GetScalarObject<CurrencyDTO>("Cur.DescriptioninWords.Select", new object[] { PrintLists[i].CurrencyCode, true });
                    data.Cur = this.CurrencyString(PrintLists[i].CurrencyCode);//to change
                    int amount = Convert.ToInt32(data.Amount);
                    data.WordAmount = this.NumberToText(amount) + " " + "Only";
                    data.Duration = PrintLists[i].DurationTime;
                    decimal duration = PrintLists[i].Duration;
                    decimal rate = Math.Round(PrintLists[i].InterestRate, 2);
                    data.InterestRate = Convert.ToInt32(rate);
                    data.OpenDate = PrintLists[i].MatureDate;
                    if (PrintLists[i].ReceiptNo.Contains('D'))
                    {
                        string noOfDays = PrintLists[i].ReceiptNo.Substring(0, PrintLists[i].ReceiptNo.IndexOf('D'));
                        data.MaturityDate = PrintLists[i].MatureDate.AddDays(Int32.Parse(noOfDays));
                    }
                    else if (PrintLists[i].ReceiptNo.Contains('M'))
                    {
                        string noOfMonths = PrintLists[i].ReceiptNo.Substring(0, PrintLists[i].ReceiptNo.IndexOf('M'));
                        data.MaturityDate = PrintLists[i].MatureDate.AddMonths(Int32.Parse(noOfMonths));
                    }
                    else if (PrintLists[i].ReceiptNo.Contains('Y'))
                    {
                        string noOfYears = PrintLists[i].ReceiptNo.Substring(0, PrintLists[i].ReceiptNo.IndexOf('Y'));
                        data.MaturityDate = PrintLists[i].MatureDate.AddYears(Int32.Parse(noOfYears));
                    }

                    data.SourceBr = PrintLists[i].SourceBranchCode;

                    lists.Add(data);
                }

                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rpvFixedDepositCertificatePrinting.LocalReport.DataSources.Clear();

                string bank = CurrentUserEntity.BranchDescription;
                string branch = Branch.Bank_Alias;

                BankName = bank + " " + "Limited";
                BranchName = bank + " " + "(" + branch + ")";

                ReportParameter[] para = new ReportParameter[3];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", BranchName);

                Image img = null;
                string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                {
                    img = System.Drawing.Image.FromStream(stream);
                    img.Save(tempFilePath);
                }

                para[2] = new ReportParameter("BankLogo", "file:////" + tempFilePath);

                rpvFixedDepositCertificatePrinting.LocalReport.EnableExternalImages = true;
                rpvFixedDepositCertificatePrinting.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("CertificateDataSet", lists);
                this.rpvFixedDepositCertificatePrinting.LocalReport.DataSources.Add(dataset);
                dataset.Value = lists;
                rpvFixedDepositCertificatePrinting.LocalReport.Refresh();
                this.rpvFixedDepositCertificatePrinting.RefreshReport();
            }
        }

        
    }
        
}
