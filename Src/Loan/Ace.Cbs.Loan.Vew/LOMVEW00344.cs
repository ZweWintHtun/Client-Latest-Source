using System;
using CrystalDecisions.Shared;
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
    public partial class LOMVEW00344 : BaseForm
    {

        IList<LOMDTO00334> DataList { get; set; }
        string LoanAmtInWords { get; set; }
        decimal DPRate { get; set; }
        string DateFromView { get; set; }
        string ProductName { get; set; }
        string CarNo { get; set; }
        string CarBoardNo { get; set; }
        string NoOfProduct { get; set; }
        string CustNameConcat { get; set; }
        string CustNameCustNRCConcat { get; set; }
        string CustNameCustNRCConcatWithEnter { get; set; }
        string CustNRCConcat { get; set; }
        string CustFatherNameConcat { get; set; }
        string CustAddressForOneConcat { get; set; }

        string CompanyInfoName { get; set; }

        public string ReportAmountInword;

        public LOMVEW00344()
        {
            InitializeComponent();
        }

        public LOMVEW00344(IList<LOMDTO00334> dataList, DateTime dateFromView, string productName, string carNo, string carBoardNo, string noOfProduct)
        {
            InitializeComponent();
            this.DataList = dataList;
            //this.LoanAmtInWords = this.AmountToWords(dataList[0].LoanAmount.ToString());
            this.LoanAmtInWords = FormatString(NumberToWordsRecursive(Convert.ToInt64(dataList[0].LoanAmount)));
            this.DPRate = this.GetDownPaymentRate(dataList[0].LoanAmount, dataList[0].DownPayment);
            //this.DateFromView = dateFromView.ToString("dd/MM/yyyy");
            this.DateFromView = dateFromView.ToString("MM/dd/yyyy");
            this.ProductName = productName;
            this.CarNo = carNo;
            this.CarBoardNo = carBoardNo;
            this.NoOfProduct = noOfProduct;
            this.CustNameConcat = null;
            this.CustNameCustNRCConcat = null;
            this.CustNameCustNRCConcatWithEnter = null;
            this.CustNRCConcat = null;
            this.CustFatherNameConcat = null;
            this.CompanyInfoName = null;
            this.CustAddressForOneConcat = null;
        }

        public LOMVEW00344(IList<LOMDTO00334> dataList, DateTime dateFromView, string productName, string carNo, string carBoardNo, string noOfProduct, string custNameConcat, string custNameCustNRCConcat, string custNameCustNRCConcatWithEnter, string custNRCConcat, string custFatherNameConcat, string custAddressForOneConcat, string companyName)
        {
            InitializeComponent();
            this.DataList = dataList;
            //this.LoanAmtInWords = this.AmountToWords(dataList[0].LoanAmount.ToString());
            this.LoanAmtInWords = FormatString(NumberToWordsRecursive(Convert.ToInt64(dataList[0].LoanAmount)));
            this.DPRate = this.GetDownPaymentRate(dataList[0].LoanAmount, dataList[0].DownPayment);
            //this.DateFromView = dateFromView.ToString("dd/MM/yyyy");
            this.DateFromView = dateFromView.ToString("MM/dd/yyyy");
            this.ProductName = productName;
            this.CarNo = carNo;
            this.CarBoardNo = carBoardNo;
            this.NoOfProduct = noOfProduct;
            this.CustNameConcat = custNameConcat;
            this.CustNameCustNRCConcat = custNameCustNRCConcat;
            this.CustNameCustNRCConcatWithEnter = custNameCustNRCConcatWithEnter;
            this.CustNRCConcat = custNRCConcat;
            this.CustFatherNameConcat = custFatherNameConcat;
            this.CustAddressForOneConcat = custAddressForOneConcat;
            this.CompanyInfoName = companyName;
        }

        private string NumberToWordsRecursive(Int64 number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = " ";
            if ((number / 1000000000) > 0)
            {
                words += NumberToWords(number / 1000000000) + " Billion";
                number %= 1000000000;
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
                    words += " ";

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

        // Added two new function by AAM(13_Sep_2018),According to pristine requirements.
        private string FormatString(string str)
        {
            string result = "";
            string[] tokens = str.Split();
            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i].Trim().Length > 0)
                {
                    result += " " + tokens[i].Trim();
                }
            }
            if (result.Length > 0)
            {
                result = result.Substring(1);
            }
            return result;
        }

        public decimal GetDownPaymentRate(decimal loanAmt, decimal downPayment)
        {
            if (downPayment > 0)
            {
                return (downPayment / loanAmt) * 100;
            }
            return 0;
        }

        private void LOMVEW00344_Load(object sender, EventArgs e)
        {
            PrintHirePurchaseLoansContract();
        }

        private void PrintHirePurchaseLoansContract()
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField paramField;
            ParameterDiscreteValue paramDiscreteValue;

            Ace.Cbs.Loan.Vew.RDLC.RptHPContractPrinting report = new Ace.Cbs.Loan.Vew.RDLC.RptHPContractPrinting();

           DateTime dateForMyanmarStr;
            dateForMyanmarStr = Convert.ToDateTime(this.DateFromView);

            #region ParameterField Only

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "CustNameCustNRC";
            paramDiscreteValue.Value = this.DataList[0].CustNameCustNRC.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "CustNameConcat";
            paramDiscreteValue.Value = (CustNameConcat == "" || CustNameConcat == null) ? this.DataList[0].CustName.ToString().ToUpper() : CompanyInfoName.ToUpper() + " (on behalf of) " + this.CustNameConcat.ToString().ToUpper();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "CustNameCustNRCConcat";
            paramDiscreteValue.Value = (this.CustNameCustNRCConcat == "" || this.CustNameCustNRCConcat == null) ? this.DataList[0].CustName.Trim().ToString().ToUpper() : CompanyInfoName.ToUpper() + " (on behalf of) " + this.CustNameCustNRCConcat.ToUpper();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "CustNameCustNRCConcatWithEnter";
            paramDiscreteValue.Value = (this.CustNameCustNRCConcatWithEnter == "" || this.CustNameCustNRCConcatWithEnter == null) ? this.DataList[0].CustNameCustNRC.ToString().ToUpper() : CompanyInfoName.ToUpper() + " (on behalf of) " + "\r\n" + this.CustNameCustNRCConcatWithEnter.ToString().ToUpper();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "ProductName";
            //paramDiscreteValue.Value = this.DataList[0].ProductName.ToString();
            paramDiscreteValue.Value = this.ProductName.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "NoOfProduct";
            paramDiscreteValue.Value = this.NoOfProduct.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "CarNo";
            //paramDiscreteValue.Value = this.DataList[0].CarNoFromView.ToString();
            paramDiscreteValue.Value = this.CarNo.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "CarBoardNo";
            //paramDiscreteValue.Value = this.DataList[0].CarBoardNoFromView.ToString();
            paramDiscreteValue.Value = this.CarBoardNo.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            
            string[] inwordsArr = SplitWords(LoanAmtInWords, 3);
            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "LoanAmtInWords";
            //paramDiscreteValue.Value = inwordsArr[0];
            paramDiscreteValue.Value = this.LoanAmtInWords;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            
            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "CustNRC";
            //paramDiscreteValue.Value = this.DataList[0].CustNRC.ToString();
            paramDiscreteValue.Value = (this.CustNRCConcat == "" || this.CustNRCConcat == null) ? this.DataList[0].CustNRC.ToString() : this.CustNRCConcat.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            string[] inwordsArrCAdd = SplitWordsForCustAddress(this.DataList[0].CustAddress.ToString(), 2);
            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "CustAddress";
            //paramDiscreteValue.Value = inwordsArrCAdd[0];
            paramDiscreteValue.Value = (this.CustAddressForOneConcat == "" || this.CustAddressForOneConcat == null) ? this.DataList[0].CustAddressForOne.ToString() : this.CustAddressForOneConcat.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "LoanAmount";
            paramDiscreteValue.Value = this.DataList[0].LoanAmount.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "TotalInstallmentAmt";
            paramDiscreteValue.Value = this.DataList[0].TotalInstallmentAmt.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "TermNo";
            paramDiscreteValue.Value = this.DataList.Count.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "RChgRate";
            paramDiscreteValue.Value = this.DataList[0].RChgRate.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "AcctNo";
            paramDiscreteValue.Value = this.DataList[0].AcctNo.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "DownPayment";
            paramDiscreteValue.Value = this.DataList[0].DownPayment.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "Commission";
            paramDiscreteValue.Value = this.DataList[0].Commission.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "DateFromView";
            paramDiscreteValue.Value = this.DateFromView;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "CustFatherName";
            //paramDiscreteValue.Value = this.DataList[0].CustFatherName.ToString();
            paramDiscreteValue.Value = (this.CustFatherNameConcat == "" || this.CustFatherNameConcat == null) ? this.DataList[0].CustFatherName.ToString() : this.CustFatherNameConcat.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);            

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "LoanAmountForAlignment";
            paramDiscreteValue.Value = String.Format("{0:N}", Convert.ToDouble(this.DataList[0].LoanAmount.ToString())) + "/-";//Add thousand seperator
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "DateFromViewMyanmar";
            //paramDiscreteValue.Value = this.DateFromView;
            paramDiscreteValue.Value = GetMyanmarString(dateForMyanmarStr.Year.ToString()) + "ခုႏွစ္၊ " + monthArr[dateForMyanmarStr.Month - 1] + "လ၊ " + "(" + GetMyanmarString(dateForMyanmarStr.Day.ToString()) + ")ရက္။";
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "DPRate";
            paramDiscreteValue.Value = this.DataList[0].DownPaymentRate;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            crReportViewer1.ParameterFieldInfo = paramFields;
            
            #endregion


            report.SetDataSource(DataList);
            
            crReportViewer1.ReportSource = report;
        }

        string[] monthArr = { "ဇန္န၀ါရီ", "ေဖေဖာ္၀ါရီ", "မတ္", "ဧၿပီ", "ေမ", "ဇြန္", "ဇူလိုင္",
                                "ၾသဂုတ္", "စက္တင္ဘာ", "ေအာက္တိုဘာ", "ႏို၀င္ဘာ", "ဒီဇင္ဘာ" };
        string[] numArr = { "၀", "၁", "၂", "၃", "၄", "၅", "၆", "၇", "၈", "၉" };

        private string GetMyanmarString(string str)
        {
            string strMya = str;
            for (int i = 0; i < 10; i++)
            {
                strMya = strMya.Replace(i.ToString(), numArr[i]);
            }
            return strMya;
        }

        private string[] SplitWordsForCustAddress(string str, int splitPoint)
        {
            string[] strArr = { "", "" };
            string[] tokensArr = str.Split(',');
            string str1 = "";
            string str2 = "";

            for (int i = 0; i < tokensArr.Length; i++)
            {
                if (i < splitPoint)
                {
                    str1 += tokensArr[i] + " ,";
                }
                else str2 += tokensArr[i] + " ";
            }

            str1 = str1.Trim();
            str2 = str2.Trim();
            strArr[0] = str1;
            strArr[1] = str2;

            return strArr;
        }

        private string[] SplitWords(string str, int splitPoint)
        {
            string[] strArr = { "", "" };
            string[] tokensArr = str.Split();
            string str1 = "";
            string str2 = "";

            for (int i = 0; i < tokensArr.Length; i++)
            {
                if (i < splitPoint)
                {
                    str1 += tokensArr[i] + " ";
                }
                else str2 += tokensArr[i] + " ";
            }

            str1 = str1.Trim();
            str2 = str2.Trim();
            strArr[0] = str1;
            strArr[1] = str2;

            return strArr;
        }

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
                else //added by YMP
                    words += " "; //added by YMP

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
