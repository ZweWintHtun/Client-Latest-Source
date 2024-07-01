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
    public partial class LOMVEW00335 : BaseForm
    {
        IList<LOMDTO00334> DataList { get; set; }
        string LoanAmtInWords { get; set; }
        decimal DPRate { get; set; }
        string DateFromView { get; set; }
        string ProductName { get; set; }

        public LOMVEW00335()
        {
            InitializeComponent();
        }

        public LOMVEW00335(IList<LOMDTO00334> dataList, DateTime dateFromView, string productName)
        {
            InitializeComponent();
            this.DataList = dataList;
            this.LoanAmtInWords = this.AmountToWords(dataList[0].LoanAmount.ToString());
            this.DPRate = this.GetDownPaymentRate(dataList[0].LoanAmount, dataList[0].DownPayment);
            this.DateFromView = dateFromView.ToString("dd/MM/yyyy");
            this.ProductName = productName;
        }

        private void LOMVEW00335_Load(object sender, EventArgs e)
        {
            this.rpvHPContractPrint.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[5];

            string tempFilePath = Application.StartupPath + "\\pristinelogo.png";


            para[0] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[1] = new ReportParameter("LoanAmtInWords", this.LoanAmtInWords);
            para[2] = new ReportParameter("DPRate", this.DPRate.ToString());
            para[3] = new ReportParameter("DateFromView", this.DateFromView);
            para[4] = new ReportParameter("ProductName", this.ProductName);

            this.rpvHPContractPrint.LocalReport.EnableExternalImages = true;
            this.rpvHPContractPrint.LocalReport.SetParameters(para);
            this.rpvHPContractPrint.RefreshReport();

            ReportDataSource dataset = new ReportDataSource("DSLOMRDLC00075", this.DataList);
            this.rpvHPContractPrint.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.DataList;
            this.rpvHPContractPrint.LocalReport.Refresh();

            this.rpvHPContractPrint.SetDisplayMode(DisplayMode.PrintLayout);

            this.rpvHPContractPrint.RefreshReport();

        }

        public decimal GetDownPaymentRate(decimal loanAmt, decimal downPayment)
        {
            if (downPayment > 0)
            {
                return (downPayment / loanAmt) * 100;
            }
            return 0;
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


    }
}
