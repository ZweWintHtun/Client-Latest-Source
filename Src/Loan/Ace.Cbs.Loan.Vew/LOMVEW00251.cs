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
    public partial class LOMVEW00251 : BaseForm
    {
        IList<LOMDTO00336> DataList { get; set; }
        string LoanAmtInWords { get; set; }
        string LoanAmtInWords2 { get; set; }
        string DateFromView { get; set; }
        string Reason { get; set; }
        public virtual string startYear { get; set; }
        public virtual string startMonth { get; set; }
        public virtual string startDay { get; set; }
        public virtual string endYear { get; set; }
        public virtual string endMonth { get; set; }
        public virtual string endDay { get; set; }
        public virtual string initY { get; set; }
        public virtual string initM { get; set; }
        public virtual string initD { get; set; }

        public LOMVEW00251()
        {
            InitializeComponent();
        }

        private void LOMVEW00251_Load(object sender, EventArgs e)
        {
            PrintPersonalLoansContract();
        }

        public LOMVEW00251(IList<LOMDTO00336> dataList, DateTime dateFromView, string reason
                            ,string sYear,string sMonth,string sDay,string eYear,string eMonth,string eDay
                            , string iniYear, string iniMonth, string iniDay)
        {
            InitializeComponent();
            this.DataList = dataList;
            this.LoanAmtInWords = "Kyats " + FormatString(NumberToWordsRecursive(Convert.ToInt64(dataList[0].LoanAmount))) + " Only";
            this.LoanAmtInWords2 = "Kyats " + FormatString(NumberToWordsRecursive(Convert.ToInt64(dataList[0].LoanAmount))) + " Only";
            //this.DateFromView = dateFromView.ToString("dd/MM/yyyy");
            this.DateFromView = dateFromView.ToString("MM/dd/yyyy");
            this.Reason = reason;
            startYear = sYear;
            startMonth =sMonth;
            startDay =sDay;
            endYear = eYear;
            endMonth = eMonth;
            endDay = eDay;
            initY = iniYear;
            initM = iniMonth;
            initD = iniDay;          
        }

        private string[] SplitWords(string str,int splitPoint)
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

        //public static DataTable ToDataTable<T>(IList<T> iList = null)
        //{
        //    DataTable dataTable = new DataTable();
        //    PropertyDescriptorCollection propertyDescriptorCollection =
        //        TypeDescriptor.GetProperties(typeof(T));
        //    for (int i = 0; i < propertyDescriptorCollection.Count; i++)
        //    {
        //        PropertyDescriptor propertyDescriptor = propertyDescriptorCollection[i];
        //        Type type = propertyDescriptor.PropertyType;

        //        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
        //            type = Nullable.GetUnderlyingType(type);


        //        dataTable.Columns.Add(propertyDescriptor.Name, type);
        //    }
        //    object[] values = new object[propertyDescriptorCollection.Count];
        //    foreach (T iListItem in iList)
        //    {
        //        for (int i = 0; i < values.Length; i++)
        //        {
        //            values[i] = propertyDescriptorCollection[i].GetValue(iListItem);
        //        }
        //        dataTable.Rows.Add(values);
        //    }
        //    return dataTable;
        //}

        private void PrintPersonalLoansContract()
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField paramField;
            ParameterDiscreteValue paramDiscreteValue;

            DateTime dateForMyanmarStr;
            dateForMyanmarStr = Convert.ToDateTime(this.DateFromView);

            Ace.Cbs.Loan.Vew.RDLC.RptPLContractPrinting report = new Ace.Cbs.Loan.Vew.RDLC.RptPLContractPrinting();
            
            #region ParameterField Only
            
            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "CustName";
            paramDiscreteValue.Value =this.DataList[0].CustName.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "CustNRC";
            paramDiscreteValue.Value = this.DataList[0].CustNRC.ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            string[] inwordsArrCAdd = SplitWordsForCustAddress(this.DataList[0].CustAddress.ToString(), 2);
            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "CustAddress";
            paramDiscreteValue.Value = inwordsArrCAdd[0];
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "CustAddress2";
            paramDiscreteValue.Value = inwordsArrCAdd[1];
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            //For Repayment Schedule Page,Page no 3.
            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "CustAddress3";
            paramDiscreteValue.Value = this.DataList[0].CustAddress.ToString();
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
            paramField.Name = "DateFromView";
            paramDiscreteValue.Value = this.DateFromView;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "InitY";
            paramDiscreteValue.Value = initY;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "InitM";
            paramDiscreteValue.Value = initM;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "InitD";
            paramDiscreteValue.Value = initD;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "EndYear";
            paramDiscreteValue.Value = endYear;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "EndMonth";
            paramDiscreteValue.Value = endMonth;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "EndDay";
            paramDiscreteValue.Value = endDay;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "StartYear";
            paramDiscreteValue.Value = startYear;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "StartMonth";
            paramDiscreteValue.Value = startMonth;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "StartDay";
            paramDiscreteValue.Value = startDay;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            string[] inwordsArr = SplitWords(LoanAmtInWords,3);
            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "LoanAmtInWords";
            paramDiscreteValue.Value = inwordsArr[0];
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "LoanAmtInWords2";
            paramDiscreteValue.Value = inwordsArr[1]; 
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "Reason";
            paramDiscreteValue.Value = Reason;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "DateFromViewMyanmar";
            //paramDiscreteValue.Value = this.DateFromView;
            paramDiscreteValue.Value = GetMyanmarString(dateForMyanmarStr.Year.ToString()) + "ခုႏွစ္၊ " + monthArr[dateForMyanmarStr.Month - 1] + "လ၊ " + "(" + GetMyanmarString(dateForMyanmarStr.Day.ToString()) + ")ရက္။";
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

        #region Adding new functions 
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
        #endregion
    }
}
