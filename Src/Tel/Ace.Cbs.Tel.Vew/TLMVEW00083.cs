﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Microsoft.Reporting.WinForms;

namespace Ace.Cbs.Tel.Vew
{
    public partial class TLMVEW00083 : BaseForm
    {
        string Account { get; set; }
        decimal Amount { get; set; }
        string AmtInWords { get; set; }
        string Naration { get; set; }
        string VoucherNo { get; set; }

        public TLMVEW00083()
        {
            InitializeComponent();
        }

        public TLMVEW00083(string account, decimal amount, string naration,string voucherNo)
        {
            InitializeComponent();
            this.Account = account;
            this.Amount = amount;
            this.Naration = naration;
            this.VoucherNo = voucherNo;
        }

        private void TLMVEW00083_Load(object sender, EventArgs e)
        {
            this.rpvDomesticDebitVoucher.LocalReport.DataSources.Clear();

            string drcashlogoPath = Application.StartupPath + "\\DebitCash.png";
            string banklogoPath = Application.StartupPath + "\\pristinelogo.png";
            string aclogoPath = Application.StartupPath + "\\Account.jpg";
            string inwordslogoPath = Application.StartupPath + "\\Inwords.jpg";
            string narationlogoPath = Application.StartupPath + "\\Naration.jpg";
            string refreglogoPath = Application.StartupPath + "\\RefReg.jpg";
            string cashReceivedBylogoPath = Application.StartupPath + "\\CashReceivedBy.jpg";
            string approvedbylogoPath = Application.StartupPath + "\\ApprovedBy.jpg";
            string datelogoPath = Application.StartupPath + "\\Date.png";

            ReportParameter[] param = new ReportParameter[15];
            param[0] = new ReportParameter("DebitCashLogo", "file:////" + drcashlogoPath);
            param[1] = new ReportParameter("BankLogo", "file:////" + banklogoPath);
            param[2] = new ReportParameter("CreditAC", this.Account.ToString());
            param[3] = new ReportParameter("CashInWords", this.AmountToWords(this.Amount.ToString()));
            param[4] = new ReportParameter("Amount", this.Amount.ToString("N2"));
            param[5] = new ReportParameter("AmountWithZawgyi", this.CashInZawGyiFont(this.Amount));
            param[6] = new ReportParameter("Naration", this.Naration.ToString());
            param[7] = new ReportParameter("ACLogo", "file:////" + aclogoPath);
            param[8] = new ReportParameter("InwordsLogo", "file:////" + inwordslogoPath);
            param[9] = new ReportParameter("NarationLogo", "file:////" + narationlogoPath);
            param[10] = new ReportParameter("RefRegLogo", "file:////" + refreglogoPath);
            param[11] = new ReportParameter("CashReceivedByLogo", "file:////" + cashReceivedBylogoPath);
            param[12] = new ReportParameter("ApprovedByLogo", "file:////" + approvedbylogoPath);
            param[13] = new ReportParameter("DateLogo", "file:////" + datelogoPath);
            param[14] = new ReportParameter("VoucherNo", this.VoucherNo);

            this.rpvDomesticDebitVoucher.LocalReport.EnableExternalImages = true;
            this.rpvDomesticDebitVoucher.LocalReport.SetParameters(param);
            this.rpvDomesticDebitVoucher.SetDisplayMode(DisplayMode.PrintLayout);
            this.rpvDomesticDebitVoucher.RefreshReport();
        }

        #region AmountInWords Added By AAM (16-Jan-2018)

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
                        words += " " + NumberToWords(number / 1000000) + " Million";
                        number %= 1000000;
                    }
                    else
                    {
                        words += " " + NumberToWords(number / 10000000) + " Billion";
                        number %= 10000000;
                    }
                }
                else
                {
                    words += " " + NumberToWords(number / 100000000) + " Trillion";
                    number %= 100000000;
                }
            }
            if ((number / 10000000) > 0)
            {
                if ((number / 1000000) > 0)
                {
                    words += " " + NumberToWords(number / 1000000) + " Million";
                    number %= 1000000;
                }
                else
                {
                    words += " " + NumberToWords(number / 10000000) + " Billion";
                    number %= 10000000;
                }
            }

            if ((number / 1000000) > 0)
            {
                words += " " + NumberToWords(number / 1000000) + " Million";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += " " + NumberToWords(number / 1000) + " Thousand";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += " " + NumberToWords(number / 100) + " Hundred";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += " " + " and ";

                var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                if (number < 20)
                    words += " " + unitsMap[number];
                else
                {
                    words += " " + tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += " " + "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

        private string CashInZawGyiFont(decimal amount)
        {
            //int stringCount = (amount.ToString().Length);
            string keyword = string.Empty;
            //for (int i = 0; i < stringCount; i++)
            //{
            //    keyword += (amount.ToString()).;
            //}
            //return keyword;

            char[] keys = (amount.ToString()).ToCharArray();
            foreach (char item in keys)
            {
                keyword += GetZawGyiFont(item);
            }
            return keyword;
        }

        private string GetZawGyiFont(char key)
        {
            switch (key)
            {
                case '1':
                    return "၁";
                case '2':
                    return "၂";
                case '3':
                    return "၃";
                case '4':
                    return "၄";
                case '5':
                    return "၅";
                case '6':
                    return "၆";
                case '7':
                    return "၇";
                case '8':
                    return "၈";
                case '9':
                    return "၉";
                default:
                    return "၀";
            }
        }
        #endregion
    }
}
