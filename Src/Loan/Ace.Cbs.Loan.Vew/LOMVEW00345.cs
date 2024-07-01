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
    public partial class LOMVEW00345 : BaseForm
    {

        IList<LOMDTO00338> DataList { get; set; }

        IList<LOMDTO00334> CustNameList { get; set; }
        IList<LOMDTO00338> CustNameList38 { get; set; }

        string LoanAmtInWords { get; set; }
        string DateFromView { get; set; }

        string P1Name { get; set; }
        string P1FatherName { get; set; }
        string P1NRC { get; set; }
        string P1Address { get; set; }
        string P2Name { get; set; }
        string P2FatherName { get; set; }
        string P2NRC { get; set; }
        string P2Address { get; set; }

        string BudgetYear { get; set; }
        string InsuranceDesp { get; set; }
        string PartA { get; set; }
        string PartB { get; set; }
        string CustNameCustNRCConcat { get; set; }
        string CustNameCustNRCConcatWithEnter { get; set; }
        string CustNameConcat { get; set; }
        string CustNameConcatWithEnter { get; set; }
        string CustNRCConcat { get; set; }
        string CustFatherNameConcat { get; set; }
        string CustAddressForOneConcat { get; set; }
        string CompanyName { get; set; }



        public LOMVEW00345()
        {
            InitializeComponent();
        }

        public LOMVEW00345(IList<LOMDTO00338> dataList,IList<LOMDTO00334> custNameList, DateTime dateFromView,string budgetYear,
            string insurancedesp,string partA,string partB,
            string strCustName, string strCustNameConcatWithEnter, string strCustNRC, string strCustFatherName, string strCustNameCustNRC, string strCustAddressForOne, string strCustNameCustNRCConcatWithEnter)
        {
            InitializeComponent();
            this.DataList = dataList;
            if (custNameList.Count > 1)
            {
                this.P1Name = custNameList[0].CustName;
                this.P1NRC = custNameList[0].CustNRC;
                this.P1FatherName = custNameList[0].CustFatherName;
                this.P1Address = custNameList[0].CustAddress;

                this.P2Name = custNameList[1].CustName;
                this.P2NRC = custNameList[1].CustNRC;
                this.P2FatherName = custNameList[1].CustFatherName;
                this.P2Address = custNameList[1].CustAddress;
            }
            else
            {
                this.P1Name = custNameList[0].CustName;
                this.P1NRC = custNameList[0].CustNRC;
                this.P1FatherName = custNameList[0].CustFatherName;
                this.P1Address = custNameList[0].CustAddress;

                this.P2Name = " ";
                this.P2NRC = " ";
                this.P2FatherName = " ";
                this.P2Address = " ";
            }

            this.CustNameList = custNameList;            
            //this.LoanAmtInWords = this.AmountToWords(dataList[0].LoanAmount.ToString());
            this.LoanAmtInWords = this.NumberToWordsRecursive(Convert.ToInt64(dataList[0].LoanAmount));
            //this.DateFromView = dateFromView.ToString("dd/MM/yyyy");
            this.DateFromView = dateFromView.ToString("MM/dd/yyyy");
            this.BudgetYear = budgetYear;
            this.InsuranceDesp = insurancedesp;
            this.PartA = partA;
            this.PartB = partB;
            
            //string strCustName, string strCustNameConcatWithEnter, string strCustNRC, string strCustFatherName, string strCustNameCustNRC
            this.CustNameCustNRCConcat = strCustNameCustNRC;
            this.CustNameConcat = strCustName;
            this.CustNRCConcat = strCustNRC;
            this.CustFatherNameConcat = strCustFatherName;
            this.CustAddressForOneConcat = strCustAddressForOne;
            this.CustNameConcatWithEnter = strCustNameConcatWithEnter;
            this.CustNameCustNRCConcatWithEnter = strCustNameCustNRCConcatWithEnter;
            this.CompanyName = null;
        }

        
        public LOMVEW00345(IList<LOMDTO00338> dataList,IList<LOMDTO00338> custNameList, DateTime dateFromView,string budgetYear,
            string insurancedesp,string partA,string partB,
            string custNameCustNRCConcat, string custNameConcat, string custNRCConcat, string custFatherNameConcat,
            string custAddressForOneConcat, string companyName, string custNameConcatWithEnter, string custNameCustNRCConcatWithEnter)
        {
            InitializeComponent();
            this.DataList = dataList;
            if (custNameList.Count > 1)
            {
                this.P1Name = custNameList[0].CustName;
                this.P1NRC = custNameList[0].CustNRC;
                this.P1FatherName = custNameList[0].CustFatherName;
                this.P1Address = custNameList[0].CustAddress;

                this.P2Name = custNameList[1].CustName;
                this.P2NRC = custNameList[1].CustNRC;
                this.P2FatherName = custNameList[1].CustFatherName;
                this.P2Address = custNameList[1].CustAddress;
            }
            else
            {
                this.P1Name = custNameList[0].CustName;
                this.P1NRC = custNameList[0].CustNRC;
                this.P1FatherName = custNameList[0].CustFatherName;
                this.P1Address = custNameList[0].CustAddress;

                this.P2Name = " ";
                this.P2NRC = " ";
                this.P2FatherName = " ";
                this.P2Address = " ";
            }

            this.CustNameList38 = custNameList;            
            //this.LoanAmtInWords = this.AmountToWords(dataList[0].LoanAmount.ToString());
            this.LoanAmtInWords = this.NumberToWordsRecursive(Convert.ToInt64(dataList[0].LoanAmount));
            
            //this.DateFromView = dateFromView.ToString("dd/MM/yyyy");
            this.DateFromView = dateFromView.ToString("MM/dd/yyyy");
            this.BudgetYear = budgetYear;
            this.InsuranceDesp = insurancedesp;
            this.PartA = partA;
            this.PartB = partB;
            this.CustNameCustNRCConcat = custNameCustNRCConcat;
            this.CustNameConcat = custNameConcat;
            this.CustNameConcatWithEnter = custNameConcatWithEnter;
            this.CustNRCConcat =  custNRCConcat;
            this.CustFatherNameConcat = custFatherNameConcat;
            this.CustAddressForOneConcat =  custAddressForOneConcat;
            this.CustNameCustNRCConcatWithEnter = custNameCustNRCConcatWithEnter;
            this.CompanyName = companyName;
        }

        private string NumberToWordsRecursive(Int64 number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";
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

        public string ReportAmountInword;

        //To Convert Number to Letter
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

        private void LOMVEW00345_Load(object sender, EventArgs e)
        {
            PrintBusinessLoansContractLandBuilding();
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

        private void PrintBusinessLoansContractLandBuilding()
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField paramField;
            ParameterDiscreteValue paramDiscreteValue;

            DateTime dateForMyanmarStr;
            dateForMyanmarStr = Convert.ToDateTime(this.DateFromView);

            Ace.Cbs.Loan.Vew.RDLC.RptBLContractPrintingLB report = new Ace.Cbs.Loan.Vew.RDLC.RptBLContractPrintingLB();


            #region ParameterField Only

            //CompanyName, CustNameConcat, CustNameCustNRCConcat, CustFatherNameConcat, CustNRCConcat, CustAddressForOneConcat

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "CompanyName";
            paramDiscreteValue.Value = this.DataList[0].AcctNo.Substring(5, 1) == "3" ? this.CompanyName.ToString() : "";
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "CustNameConcat";
            paramDiscreteValue.Value = this.DataList[0].AcctNo.Substring(5, 1) == "3" ? this.CompanyName + " (on behalf of) " + this.CustNameConcat.ToString() : this.CustNameConcat.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "CustNameConcatWithEnter";
            paramDiscreteValue.Value = this.DataList[0].AcctNo.Substring(5, 1) == "3" ? this.CompanyName + " (on behalf of) " + "\r\n" + this.CustNameConcatWithEnter.ToString() : this.CustNameConcatWithEnter.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "CustNameCustNRCConcat";
            //paramDiscreteValue.Value = this.CustNameList[0].CustNameCustNRC.ToString();
            paramDiscreteValue.Value = this.DataList[0].AcctNo.Substring(5, 1) == "3" ? this.CompanyName + " (on behalf of) " + this.CustNameCustNRCConcat.ToString() : this.CustNameCustNRCConcat.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "CustNameCustNRCConcatWithEnter";
            paramDiscreteValue.Value = this.DataList[0].AcctNo.Substring(5, 1) == "3" ? this.CompanyName + " (on behalf of) \r\n" + this.CustNameCustNRCConcatWithEnter.ToString() : this.CustNameCustNRCConcatWithEnter.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "CustFatherNameConcat";
            //paramDiscreteValue.Value = this.CustNameList[0].CustNameCustNRC.ToString();
            paramDiscreteValue.Value = this.CustFatherNameConcat.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "CustNRCConcat";
            //paramDiscreteValue.Value = this.CustNameList[0].CustNameCustNRC.ToString();
            paramDiscreteValue.Value = this.CustNRCConcat.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "CustAddressForOneConcat";
            //paramDiscreteValue.Value = this.CustNameList[0].CustNameCustNRC.ToString();
            paramDiscreteValue.Value = this.CustAddressForOneConcat.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            //----------------------------------------

            /*
            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "CustNameCustNRC";
            paramDiscreteValue.Value = this.CustNameList[0].CustNameCustNRC.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);*/

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
            paramField.Name = "P1FatherName";
            paramDiscreteValue.Value = this.P1FatherName.ToString();
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
            paramField.Name = "P2FatherName";
            paramDiscreteValue.Value = this.P2FatherName.ToString();
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
            paramField.Name = "InsuranceDesp";
            paramDiscreteValue.Value = this.InsuranceDesp.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "PartA";
            paramDiscreteValue.Value = this.PartA.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "PartB";
            paramDiscreteValue.Value = this.PartB.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            //string[] inwordsArr = SplitWords(LoanAmtInWords, 3);
            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "LoanAmtInWords";
            //paramDiscreteValue.Value = inwordsArr[0];
            paramDiscreteValue.Value = this.LoanAmtInWords;
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
            paramField.Name = "AcctNo";
            paramDiscreteValue.Value = this.DataList[0].AcctNo.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "DownPayment";
            paramDiscreteValue.Value = this.DataList[0].AcctNo.Substring(5,1) == "3"? this.CustNameList38[0].DownPayment : this.CustNameList[0].DownPayment;;
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
            paramField.Name = "LoanNo";
            paramDiscreteValue.Value = this.DataList[0].Lno.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "BudgetYear";
            paramDiscreteValue.Value = this.BudgetYear.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "DateFromViewMyanmar";
            //paramDiscreteValue.Value = this.DateFromView;
            paramDiscreteValue.Value = GetMyanmarString(dateForMyanmarStr.Year.ToString()) + "ခုႏွစ္၊ " + monthArr[dateForMyanmarStr.Month - 1] + "လ၊ " + "(" + GetMyanmarString(dateForMyanmarStr.Day.ToString()) + ")ရက္။";
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            //paramField = new ParameterField();
            //paramDiscreteValue = new ParameterDiscreteValue();
            //paramField.Name = "CustNameCustNRCAll";
            ////paramDiscreteValue.Value = this.CustNameList[0].CustNameCustNRCAll.ToString();
            //paramDiscreteValue.Value = this.DataList[0].CustNameCustNRC.ToString();
            //paramField.CurrentValues.Add(paramDiscreteValue);
            //paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "BudgetYearDash";
            paramDiscreteValue.Value = this.BudgetYear.Replace("/","-");
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "LoanAmountForAlignment";
            paramDiscreteValue.Value = this.DataList[0].LoanAmount.ToString() + "/-";
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);



            crReportViewer1.ParameterFieldInfo = paramFields;

            #endregion


            report.SetDataSource(DataList);

            crReportViewer1.ReportSource = report;
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


    }
}
