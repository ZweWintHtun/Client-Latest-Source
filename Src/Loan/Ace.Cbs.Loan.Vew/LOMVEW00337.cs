using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Core.Utt;
using Microsoft.Reporting.WinForms;
using System.IO;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00337 : BaseForm
    {
        IList<LOMDTO00336> DataList { get; set; }
        string LoanAmtInWords { get; set; }
        string DateFromView { get; set; }
        string Reason { get; set; }
        //Added By AAM (06_Aug_2018)
        public virtual string startYear { get; set; }
        public virtual string startMonth { get; set; }
        public virtual string startDay { get; set; }
        public virtual string endYear { get; set; }
        public virtual string endMonth { get; set; }
        public virtual string endDay { get; set; }
        public virtual string initialYear { get; set; }
        public virtual string initialMonth { get; set; }
        public virtual string initialDay { get; set; }

        string[] monthArr = { "ဇန္န၀ါရီ", "ေဖေဖာ္၀ါရီ", "မတ္", "ဧၿပီ", "ေမ", "ဇြန္", "ဇူလိုင္",
                                "ၾသဂုတ္", "စက္တင္ဘာ", "ေအာက္တိုဘာ", "ႏို၀င္ဘာ", "ဒီဇင္ဘာ" };
        string[] yearDayArr = { "၀", "၁", "၂", "၃", "၄", "၅", "၆", "၇", "၈", "၉" };

        public LOMVEW00337()
        {
            InitializeComponent();
        }

        public LOMVEW00337(IList<LOMDTO00336> dataList, DateTime dateFromView, string reason
                            ,string sYear,string sMonth,string sDay,string eYear,string eMonth,string eDay
                            , string iniYear, string iniMonth, string iniDay)
        {
            InitializeComponent();
            this.DataList = dataList;
            this.LoanAmtInWords = this.AmountToWords(dataList[0].LoanAmount.ToString());
            this.DateFromView = dateFromView.ToString("dd/MM/yyyy");
            this.Reason = reason;
            startYear = sYear;
            startMonth =sMonth;
            startDay =sDay;
            endYear = eYear;
            endMonth = eMonth;
            endDay = eDay;
            initialYear = iniYear;
            initialMonth = iniMonth;
            initialDay = iniDay;
        }

        public string ReportAmountInword;

        //To Convert Number From Amount Textbox to Words
        private string AmountToWords(string inputStr)
        {
            string point = string.Empty;
            string firstamount = string.Empty;
            string[] answers = inputStr.Split(new string[] { ".", " " }, StringSplitOptions.RemoveEmptyEntries);

            if (answers.Length > 1)
            {
                firstamount = this.NumberToWords(Convert.ToInt64(answers[0]));
                if ((Convert.ToInt32(answers[1])) > 0)
                {
                    point = this.NumberToWords(Convert.ToInt64(answers[1]));
                }
            }
            else
            {
                firstamount = this.NumberToWords(Convert.ToInt64(answers[0]));
            }


            this.ReportAmountInword = "Kyats " + firstamount + " ";
            if (string.IsNullOrEmpty(point))
            {
                this.ReportAmountInword += " only";
            }
            else
            {
                this.ReportAmountInword += " " + point + " " + "Pyar only";
            }

            return ReportAmountInword;
        }

        //To Conver Number to Letter
        private string NumberToWords(Int64 number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";
            if ((number / 100000000) > 0)
            {
                if ((number / 10000000) > 0)
                {
                    if ((number / 1000000) > 0)
                    {
                        words += NumberToWords(number / 1000000) + " Million";
                        number %= 1000000;
                    }
                    else
                    {
                        words += NumberToWords(number / 10000000) + " Billion";
                        number %= 10000000;
                    }
                }
                else
                {
                    words += NumberToWords(number / 100000000) + " Trillion";
                    number %= 100000000;
                }
            }
            if ((number / 10000000) > 0)
            {
                if ((number / 1000000) > 0)
                {
                    words += NumberToWords(number / 1000000) + " Million";
                    number %= 1000000;
                }
                else
                {
                    words += NumberToWords(number / 10000000) + " Billion";
                    number %= 10000000;
                }
            }

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " Million";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " Thousand";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " Hundred";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += " and ";

                var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

        private void LOMVEW00337_Load(object sender, EventArgs e)
        {
            this.rpvPLContractPrint.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[14];

            string tempFilePath = Application.StartupPath + "\\pristinelogo.png";


            para[0] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[1] = new ReportParameter("LoanAmtInWords", this.LoanAmtInWords);
            para[2] = new ReportParameter("DateFromView", this.DateFromView);
            para[3] = new ReportParameter("Reason", this.Reason);
            para[4] = new ReportParameter("TermNo", this.DataList.Count.ToString());
            para[5] = new ReportParameter("StartYear", this.startYear);
            para[6] = new ReportParameter("StartMonth", this.startMonth);
            para[7] = new ReportParameter("StartDay", this.startDay);
            para[8] = new ReportParameter("EndYear", this.endYear);
            para[9] = new ReportParameter("EndMonth", this.endMonth);
            para[10] = new ReportParameter("EndDay", this.endDay);
            para[11] = new ReportParameter("InitialYear", this.initialYear);
            para[12] = new ReportParameter("InitialMonth", this.initialMonth);
            para[13] = new ReportParameter("InitialDay", this.initialDay);

            this.rpvPLContractPrint.LocalReport.EnableExternalImages = true;
            this.rpvPLContractPrint.LocalReport.SetParameters(para);
            this.rpvPLContractPrint.RefreshReport();

            ReportDataSource dataset = new ReportDataSource("DSLOMRDLC00076", this.DataList);
            this.rpvPLContractPrint.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.DataList;
            this.rpvPLContractPrint.LocalReport.Refresh();

            this.rpvPLContractPrint.SetDisplayMode(DisplayMode.PrintLayout);

            this.rpvPLContractPrint.RefreshReport();
        }
    }
}
