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
    public partial class LOMVEW00346 : BaseForm
    {

        IList<LOMDTO00338> DataList { get; set; }
        IList<LOMDTO00339> CustomerList { get; set; }
        string LoanAmtInWords { get; set; }
        string DateFromView { get; set; }

        string Reference_VW { get; set; }
        string Description_VW { get; set; }
        string Place_VW { get; set; }
        decimal Amount_VW { get; set; }
        string InsuranceDetail { get; set; }

        string P1Name { get; set; }
        string P1NRC { get; set; }
        string P1Address { get; set; }
        string P2Name { get; set; }
        string P2NRC { get; set; }
        string P2Address { get; set; }
        string CustNameCustNRCConcat { get; set; }

        string BudgetYear { get; set; }

        public string ReportAmountInword;

        public LOMVEW00346()
        {
            InitializeComponent();
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
                if (words != "") // HMW Update
                    words += " and ";
                else
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
            words = words.Trim();
            return words;
        }

        public LOMVEW00346(IList<LOMDTO00338> dataList, IList<LOMDTO00334> customerList, DateTime dateFromView, string reference, string desp, string place, decimal amount, string insuranceDetail,
            string budgetYear,string custNameCustNRCConcat)
        {
            InitializeComponent();
            this.DataList = dataList;
            this.CustomerList = this.GetCustomerList(customerList);
            //this.LoanAmtInWords = this.AmountToWords(dataList[0].LoanAmount.ToString());
            this.LoanAmtInWords = this.NumberToWordsRecursive(Convert.ToInt64(dataList[0].LoanAmount)); 
            this.DateFromView = dateFromView.ToString("MM/dd/yyyy");
            this.Reference_VW = reference;
            this.Description_VW = desp;
            this.Place_VW = place;
            this.Amount_VW = amount;
            this.InsuranceDetail = insuranceDetail;
            if (customerList.Count > 1)
            {
                this.P1Name = customerList[0].CustName;
                this.P1NRC = customerList[0].CustNRC;
                this.P1Address = customerList[0].CustAddress;

                this.P2Name = customerList[1].CustName;
                this.P2NRC = customerList[1].CustNRC;
                this.P2Address = customerList[1].CustAddress;
            }
            else            
            {
                this.P1Name = customerList[0].CustName;
                this.P1NRC = customerList[0].CustNRC;
                this.P1Address = customerList[0].CustAddress;

                this.P2Name = " ";
                this.P2NRC = " ";
                this.P2Address = " ";
            }
            this.BudgetYear = budgetYear;
            this.CustNameCustNRCConcat = custNameCustNRCConcat;
        }

        public LOMVEW00346(IList<LOMDTO00338> dataList, IList<LOMDTO00338> customerList, DateTime dateFromView, string reference, string desp, string place, decimal amount, string insuranceDetail,
            string budgetYear, string custNameCustNRCConcat)
        {
            InitializeComponent();
            this.DataList = dataList;
            this.CustomerList = this.GetCustomerList(customerList);
            //this.LoanAmtInWords = this.AmountToWords(dataList[0].LoanAmount.ToString());
            this.LoanAmtInWords = this.NumberToWordsRecursive(Convert.ToInt64(dataList[0].LoanAmount));
            this.DateFromView = dateFromView.ToString("MM/dd/yyyy");
            this.Reference_VW = reference;
            this.Description_VW = desp;
            this.Place_VW = place;
            this.Amount_VW = amount;
            this.InsuranceDetail = insuranceDetail;
            if (customerList.Count > 1)
            {
                this.P1Name = customerList[0].CustName;
                this.P1NRC = customerList[0].CustNRC;
                this.P1Address = customerList[0].CustAddress;

                this.P2Name = customerList[1].CustName;
                this.P2NRC = customerList[1].CustNRC;
                this.P2Address = customerList[1].CustAddress;
            }
            else
            {
                this.P1Name = customerList[0].CustName;
                this.P1NRC = customerList[0].CustNRC;
                this.P1Address = customerList[0].CustAddress;

                this.P2Name = " ";
                this.P2NRC = " ";
                this.P2Address = " ";
            }
            this.BudgetYear = budgetYear;
            this.CustNameCustNRCConcat = custNameCustNRCConcat;
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
                else
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

        private IList<LOMDTO00339> GetCustomerList(IList<LOMDTO00334> inputList)
        {
            IList<LOMDTO00339> outputList = new List<LOMDTO00339>();
            foreach (LOMDTO00334 dto in inputList)
            {
                LOMDTO00339 outputDto = new LOMDTO00339();
                outputDto.CustomerName = dto.CustName;
                outputDto.CustomerNRC = dto.CustNRC;
                outputDto.CustomerAddress = dto.CustAddress;
                outputDto.CustNameCustNRC = dto.CustNameCustNRC;
                outputList.Add(outputDto);
            }
            return outputList;
        }

        private IList<LOMDTO00339> GetCustomerList(IList<LOMDTO00338> inputList)
        {
            IList<LOMDTO00339> outputList = new List<LOMDTO00339>();
            foreach (LOMDTO00338 dto in inputList)
            {
                LOMDTO00339 outputDto = new LOMDTO00339();
                outputDto.CustomerName = dto.CustName;
                outputDto.CustomerNRC = dto.CustNRC;
                outputDto.CustomerAddress = dto.CustAddress;
                outputDto.CustNameCustNRC = dto.CustNameCustNRC;
                outputList.Add(outputDto);
            }
            return outputList;
        }

        private void LOMVEW00346_Load(object sender, EventArgs e)
        {
            PrintBusinessLoansContractHypothecation();
        }

        private void PrintBusinessLoansContractHypothecation()
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField paramField;
            ParameterDiscreteValue paramDiscreteValue;

            DateTime dateForMyanmarStr;
            dateForMyanmarStr = Convert.ToDateTime(this.DateFromView);

            Ace.Cbs.Loan.Vew.RDLC.RptBLContractPrintingHYPO report = new Ace.Cbs.Loan.Vew.RDLC.RptBLContractPrintingHYPO();

            #region ParameterField Only

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "CustNameConcat";
            paramDiscreteValue.Value = this.DataList[0].AcctNo.Substring(5, 1) == "3" ? this.DataList[0].CustCompanyName.ToString() + " (on behalf of) " + this.DataList[0].CustName.ToString() : this.DataList[0].CustName.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "CustNameCustNRCConcat";
            paramDiscreteValue.Value = this.DataList[0].AcctNo.Substring(5, 1) == "3" ? this.DataList[0].CustCompanyName.ToString() + " (on behalf of) " + this.CustNameCustNRCConcat.ToString() : this.CustNameCustNRCConcat.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "CompanyNameOnly";
            paramDiscreteValue.Value = this.DataList[0].AcctNo.Substring(5, 1) == "3" ? this.DataList[0].CustCompanyName.ToString()  : this.DataList[0].CustName.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            
            //string[] inwordsArr = SplitWords(LoanAmtInWords, 3);
            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "LoanAmtInWords";
            //paramDiscreteValue.Value = inwordsArr[0];
            paramDiscreteValue.Value = this.LoanAmtInWords.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            
            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "DateFromView";
            paramDiscreteValue.Value = Convert.ToDateTime(this.DateFromView).ToString();
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
            paramField.Name = "Reference_VW";
            paramDiscreteValue.Value = this.Reference_VW.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "Description_VW";
            paramDiscreteValue.Value = this.Description_VW.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "Place_VW";
            paramDiscreteValue.Value = this.Place_VW.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            
            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "Amount_VW";
            //paramDiscreteValue.Value = this.Amount_VW.ToString("N2");
            paramDiscreteValue.Value = this.Amount_VW.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "P1Name";
            paramDiscreteValue.Value = this.P1Name.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "P1NRC";
            paramDiscreteValue.Value = this.P1NRC.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "P1Address";
            paramDiscreteValue.Value = this.P1Address.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "P2Name";
            paramDiscreteValue.Value = this.P2Name.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "P2NRC";
            paramDiscreteValue.Value = this.P2NRC.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "P2Address";
            paramDiscreteValue.Value = this.P2Address.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "InsuranceDetail";
            paramDiscreteValue.Value = this.InsuranceDetail.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "BudgetYear"; //####-##
            //paramDiscreteValue.Value = this.BudgetYear.Replace("/", "-").Remove(5,2).ToString();
            paramDiscreteValue.Value = this.BudgetYear.Replace("/", "-").ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "DateFromViewMyanmar";
            paramDiscreteValue.Value = GetMyanmarString(dateForMyanmarStr.Year.ToString()) + "ခုႏွစ္၊ " + monthArr[dateForMyanmarStr.Month - 1] + "လ၊ " + "(" + GetMyanmarString(dateForMyanmarStr.Day.ToString()) + ")ရက္။";
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "RChgRate";
            paramDiscreteValue.Value = this.DataList[0].RChgRate.ToString() ;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "LoanAmountWithFormat";
            paramDiscreteValue.Value = "-" + string.Format("{0:n0}", this.DataList[0].LoanAmount).ToString() + "/-";
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "CustNameSelectedConcat";
            paramDiscreteValue.Value = this.DataList[0].AcctNo.Substring(5, 1) == "3" ? this.DataList[0].CustCompanyName.ToString() + " (on behalf of) " + this.CustomerList[0].CustomerName.ToString() : this.CustomerList[0].CustomerName.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "CompanyNameConcat";
            paramDiscreteValue.Value = this.DataList[0].AcctNo.Substring(5, 1) == "3" ? this.DataList[0].CustCompanyName.ToString() + " (on behalf of)" : string.Empty;//this.DataList[0].CustCompanyName.ToString() + " (on behalf of)";
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
    }
}
