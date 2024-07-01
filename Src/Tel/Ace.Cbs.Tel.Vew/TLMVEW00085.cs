using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Tel.Dmd;
using Microsoft.Reporting.WinForms;

namespace Ace.Cbs.Tel.Vew
{
    public partial class TLMVEW00085 : BaseForm
    {
        IList<TLMDTO00038> InputList { get; set; }
        string VoucherNo { get; set; }

        public TLMVEW00085()
        {
            InitializeComponent();
        }

        public TLMVEW00085(IList<TLMDTO00038> denolist,string voucherNo)
        {
            InitializeComponent();
            this.InputList = new List<TLMDTO00038>();
            foreach (TLMDTO00038 dto in denolist)
            {
                dto.AmountInWords = this.AmountToWords(dto.Amount.ToString());
                this.InputList.Add(dto);
            }
            this.VoucherNo = voucherNo;
        }

        private void TLMVEW00085_Load(object sender, EventArgs e)
        {
            this.rpvLoanDepositPrint.LocalReport.DataSources.Clear();

            string banklogoPath = Application.StartupPath + "\\pristinelogo.png";
            string forbankuseonlylogoPath = Application.StartupPath + "\\ForBankUseOnly.png";
            
            ReportParameter[] param = new ReportParameter[3];
            param[0] = new ReportParameter("BankLogo", "file:////" + banklogoPath);
            param[1] = new ReportParameter("VoucherNo", this.VoucherNo);
            param[2] = new ReportParameter("ForBankUseOnlyLogo", "file:////" + forbankuseonlylogoPath);

            this.rpvLoanDepositPrint.LocalReport.EnableExternalImages = true;
            this.rpvLoanDepositPrint.LocalReport.SetParameters(param);
            this.rpvLoanDepositPrint.RefreshReport();

            ReportDataSource dataset = new ReportDataSource("DSTLMRDLC00036", this.InputList);
            this.rpvLoanDepositPrint.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.InputList;
            this.rpvLoanDepositPrint.LocalReport.Refresh();

            this.rpvLoanDepositPrint.SetDisplayMode(DisplayMode.PrintLayout);

            this.rpvLoanDepositPrint.RefreshReport();

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
                this.ReportAmountInword += " Only.";
            }
            else
            {
                this.ReportAmountInword += " " + point + " " + "Pyar Only.";
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
