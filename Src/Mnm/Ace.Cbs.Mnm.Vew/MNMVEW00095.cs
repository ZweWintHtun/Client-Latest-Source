using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Microsoft.Reporting.WinForms;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;
using System.IO;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Mnm.Dmd.DTO;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00095 : BaseForm
    {
        #region Property
        public bool IsReversal { get; set; }
        public bool IsSourceCurrency { get; set; }
        IList<PFMDTO00001> balanceConfirmList { get; set; }
        PFMDTO00001 balconfirmdto { get; set; }
        public string FormName { get; set; }
        public int count = 0;
        public string AccountNo { get; set; }
        #endregion

        #region constructors
        public MNMVEW00095()
        {
            InitializeComponent();
        }

        public MNMVEW00095(PFMDTO00001 custinfo,string formname)
        {
            InitializeComponent();
            this.balconfirmdto = custinfo;
            this.FormName = formname;
        }
        #endregion


        private void MNMVEW00095_Load(object sender, EventArgs e)
        {
            this.Text = "Balance Confirmation " + this.FormName + " Listing";
            if (string.IsNullOrEmpty(balconfirmdto.Name))
                balconfirmdto.Name = "Unknown";
            else if (string.IsNullOrEmpty(balconfirmdto.NRC))
                balconfirmdto.NRC = "Unknown";
            else if (string.IsNullOrEmpty(balconfirmdto.Address))
                balconfirmdto.Address = "Unknown";
            count = 1;

            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

            rpvBalanceConfirmation.LocalReport.DataSources.Clear();
            ReportParameter[] para = new ReportParameter[15];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[13] = new ReportParameter("BrCode", Branch.BranchCode);
            para[14] = new ReportParameter("Br_Alias", Branch.Bank_Alias);



            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);

                img.Save(tempFilePath);
            }

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
           // para[5] = new ReportParameter("Head", this.Text);
            para[5] = new ReportParameter("TotalRecords", count.ToString());
            para[6] = new ReportParameter("AccountNo", balconfirmdto.AccountNo);
            para[7] = new ReportParameter("name",balconfirmdto.Name);
            para[8] = new ReportParameter("nrc", balconfirmdto.NRC);
            para[9] = new ReportParameter("address",balconfirmdto.Address);
            //para[10] = new ReportParameter("amount",balconfirmdto.Amount.ToString());
            //para[10] = new ReportParameter("amount", balconfirmdto.Amount.ToString());
            int amt = Convert.ToInt32(balconfirmdto.Amount);
            string amtwords = this.NumberToWords(amt);

            para[10] = new ReportParameter("amount", this.ThousandSeparator(balconfirmdto.Amount.ToString()) + " " +"("+ amtwords + ")");
            para[11] = new ReportParameter("cur", balconfirmdto.CurrencyCode);  
            para[12] = new ReportParameter("DateTime",balconfirmdto.DATE_TIME.ToString("dd/MM/yyyy"));

            this.rpvBalanceConfirmation.LocalReport.EnableExternalImages = true;
            rpvBalanceConfirmation.LocalReport.SetParameters(para);

            this.rpvBalanceConfirmation.RefreshReport();
            this.rpvBalanceConfirmation.RefreshReport();
        }
        public string ThousandSeparator(string myNumber)
        {
            string number = myNumber.ToString().Substring(0, myNumber.Length -3);
            var myResult = "";
            for (var i = number.Length - 1; i >= 0; i--)
            {
                myResult = number[i] + myResult;
                if ((number.Length - i) % 3 == 0 & i > 0)
                    myResult = "," + myResult;
            }

            return myResult + ".00";
        }
        //To Conver Number to Letter
        private string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";
            if ((number / 100000000) > 0)
            {
                words += NumberToWords(number / 100000000) + " Trillion ";
                number %= 100000000;
            }
            if ((number / 10000000) > 0)
            {
                words += NumberToWords(number / 10000000) + " Billion ";
                number %= 10000000;
            }

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " Million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " Thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " Hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

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
