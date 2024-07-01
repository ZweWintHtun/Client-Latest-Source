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
    public partial class LOMVEW00341 : BaseForm
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

        string BudgetYear { get; set; }

        public LOMVEW00341()
        {
            InitializeComponent();
        }

        public LOMVEW00341(IList<LOMDTO00338> dataList,IList<LOMDTO00334> customerList, DateTime dateFromView,string reference,string desp,string place,decimal amount,string insuranceDetail,
            string budgetYear)
        {
            InitializeComponent();
            this.DataList = dataList;
            this.CustomerList = this.GetCustomerList(customerList);
            this.LoanAmtInWords = this.AmountToWords(dataList[0].LoanAmount.ToString());
            this.DateFromView = dateFromView.ToString("dd/MM/yyyy");
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
                outputList.Add(outputDto);
            }
            return outputList;
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

        private void LOMVEW00341_Load(object sender, EventArgs e)
        {
            this.rpvBLHPContractPrint.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[16];

            string tempFilePath = Application.StartupPath + "\\pristinelogo.png";


            para[0] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[1] = new ReportParameter("LoanAmtInWords", this.LoanAmtInWords);
            para[2] = new ReportParameter("DateFromView", this.DateFromView);
            para[3] = new ReportParameter("TermNo", this.DataList.Count.ToString());
            para[4] = new ReportParameter("Reference_VW", this.Reference_VW);
            para[5] = new ReportParameter("Description_VW", this.Description_VW);
            para[6] = new ReportParameter("Place_VW", this.Place_VW);
            para[7] = new ReportParameter("Amount_VW", this.Amount_VW.ToString("N2"));
            para[8] = new ReportParameter("P1Name", this.P1Name);
            para[9] = new ReportParameter("P1NRC", this.P1NRC);
            para[10] = new ReportParameter("P1Address", this.P1Address);
            para[11] = new ReportParameter("P2Name", this.P2Name);
            para[12] = new ReportParameter("P2NRC", this.P2NRC);
            para[13] = new ReportParameter("P2Address", this.P2Address);
            para[14] = new ReportParameter("InsuranceDetail", this.InsuranceDetail);
            para[15] = new ReportParameter("BudgetYear", this.BudgetYear);

            this.rpvBLHPContractPrint.LocalReport.EnableExternalImages = true;
            this.rpvBLHPContractPrint.LocalReport.SetParameters(para);
            this.rpvBLHPContractPrint.RefreshReport();

            ReportDataSource dataset = new ReportDataSource("DSLOMRDLC00078", this.DataList);
            this.rpvBLHPContractPrint.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.DataList;
            this.rpvBLHPContractPrint.LocalReport.Refresh();

            this.rpvBLHPContractPrint.SetDisplayMode(DisplayMode.PrintLayout);

            this.rpvBLHPContractPrint.RefreshReport();
        }
    }
}
