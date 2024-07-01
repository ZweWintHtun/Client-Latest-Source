using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Admin.DataModel;
namespace Ace.Cbs.Pfm.Vew
{
    public partial class frmPFMVEW00021 : BaseDockingForm, IPFMVEW00021
    {
        #region Properties

        public string result;
        public string ReportAmountInword;
        public string FormName { get; set; }
        IList<ChargeOfAccountDTO> coadtoList { get; set; }

        #endregion

        #region Constructor

        public frmPFMVEW00021()
        {
            InitializeComponent();
        }

        public frmPFMVEW00021(int menuIdForPermission, string p)
        {
            InitializeComponent();
            this.FormName = p;
            CurrentUserEntity.CurrentMenuId = menuIdForPermission;
        }

        #endregion

        #region Properties

        public string NRC
        {
            get
            {
                return this.txtNRC.Text;
            }
            set
            {
                txtNRC.Text = value;
            }
        }

        public string Amount
        {
            get
            {
                return txtAmount.Text;
            }
            set
            {
                txtAmount.Text = value;
            }
        }

        public string Name
        {
            get
            {
                return this.txtName.Text;
            }
            set
            {
                txtName.Text = value;
            }
        }

        public string OLSACNo
        {
            get
            {
                return this.mtxtOLSAccountNo.Text.Replace("_", "");
            }
            set
            {
                this.mtxtOLSAccountNo.Text = value;
            }
        }

        public string AccountNo
        {
            get
            {
                return this.mtxtAccountNo.Text.Trim();
            }
            set
            {
                this.mtxtAccountNo.Text = value;
            }
        }

        public string AmountInWords
        {
            get
            {
                return this.ReportAmountInword;
            }
            set
            {
                this.ReportAmountInword = value;
            }
        }

        public string SourceBranchCode
        {
            get
            {
                return CXCOM00007.Instance.BranchCode;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        private IPFMCTL00021 savingWithdrawalController;
        public IPFMCTL00021 SavingWithdrawalController
        {
            set
            {
                this.savingWithdrawalController = value;
                savingWithdrawalController.SavingWithdrawalView = this;
            }
            get
            {
                return this.savingWithdrawalController;
            }
        }

        private PFMDTO00059 viewData;
        public PFMDTO00059 ViewData
        {
            get
            {
                if (this.viewData == null)
                    this.viewData = new PFMDTO00059();
                this.viewData.OLSACNo = this.OLSACNo;
                this.viewData.BranchName = this.SourceBranchCode;
                this.viewData.AccountNo = this.AccountNo;// Private Field for Saving Withdraw
                this.viewData.Amount = this.Amount.ToString();
                this.viewData.Name = this.Name;
                this.viewData.NRC = this.NRC;

                return this.viewData;
            }

            set { this.viewData = value; }
        }

        private IList<PFMDTO00059> SavingReportList = new List<PFMDTO00059>();
        PFMDTO00059 SavingReportEntity;
        public IList<PFMDTO00059> ViewDataList { get; set; }
        #endregion

        #region Method

        public void SetCursor(string txt)
        {
            if (txt == "OLSAccount")
                mtxtOLSAccountNo.Focus();
            else if (txt == "Account")
                mtxtAccountNo.Focus();
            else if (txt == "Amount")
                txtAmount.Focus();
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

        //To Bind PFMDTO00059 Entity
        private PFMDTO00059 BindDataToEntity()
        {
            SavingReportEntity = new PFMDTO00059();
             
                SavingReportEntity.OLSACNo = this.OLSACNo;
                SavingReportEntity.AccountNo = this.AccountNo;
                SavingReportEntity.Name = this.Name;
                SavingReportEntity.NRC = this.NRC;
                SavingReportEntity.Amount = this.Amount.ToString();
                SavingReportEntity.AmountinWords = this.ReportAmountInword;
                SavingReportEntity.BranchName = CurrentUserEntity.BranchDescription;
                SavingReportEntity.BankName = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.BankName);

             if (this.SavingReportEntity.AccountNo == string.Empty && SavingReportEntity.Amount != null)
             {
                 Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00037);
                 return null;
             }else
             {
                  this.ViewDataList = SavingReportList;
                  SavingReportList.Add(SavingReportEntity);
                  this.BindSavingWithdrawalGridView();
             }

                return SavingReportEntity;
        
        }

        //To  Initialized  Controls
        private void InitiallizeControls()
        {
            if (this.FormName == "Saving Withdrawal Form Offline")
            {
                this.mtxtAccountNo.Focus();
                this.mtxtOLSAccountNo.Visible = false;
                this.lblOLSAccountNo.Visible = false;
                this.txtName.ReadOnly = true;
                this.txtNRC.ReadOnly = true;
                this.gboWithdrawal.Text = "Saving Withdrawal Form Offline Enquiry";
                gvSavingWithdrawal.Columns["colOLSACNo"].Visible = false;
                this.Text = "Saving A/C Withdrawal Form Printing";
            }
            else    if (this.FormName == "Saving Withdrawal Form Online")
            {
                this.gboWithdrawal.Text = "Saving Withdrawal Form Online Enquiry";
                this.Text = "Saving A/C Withdrawal Form (Online) Printing";
                this.mtxtOLSAccountNo.Focus();
              
            }

            //mtxtOLSAccountNo.Text = "PCE";
            
            coadtoList = CXCLE00002.Instance.GetListObject<ChargeOfAccountDTO>("COADAO.SelectByBranchDetail", new object[] { CurrentUserEntity.BranchCode, true });
            
            IList<ChargeOfAccountDTO> coaForOLS = this.coadtoList.Where(x => x.AccountName.Contains("OLS")).ToList<ChargeOfAccountDTO>();

            if (coaForOLS.Count > 0)
            {
                mtxtOLSAccountNo.Text = coaForOLS[0].ACode.Substring(0, 3);
                mtxtAccountNo.Text = string.Empty;
                txtName.Text = string.Empty;
                txtNRC.Text = string.Empty;
                txtAmount.Text = "0.00";
            }
            else
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00076); // Invalid OLS Account No.
                return;
            }

        }

        //To bind SavingWithdrawal Gridview
        private void BindSavingWithdrawalGridView()
        {  
                this.gvSavingWithdrawal.DataSource = null;
                this.gvSavingWithdrawal.AutoGenerateColumns = false;
                this.gvSavingWithdrawal.DataSource = this.ViewDataList;
                int counter = 1;
                for (int i = 0; i < gvSavingWithdrawal.Rows.Count; i++)
                {
                    gvSavingWithdrawal.Rows[i].Cells["SrNo"].Value = (counter++).ToString();

                }
            
        }

        //To Convert Number From Amount Textbox to Words
        private void AmountToWords()
        {
            string point = string.Empty;
            string firstamount = string.Empty;
            string str = this.txtAmount.Text;
            string[] answers = str.Split(new string[] { ".", " " }, StringSplitOptions.RemoveEmptyEntries);

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


            this.ReportAmountInword = firstamount + " Kyats";
            if (string.IsNullOrEmpty(point))
            {
                this.ReportAmountInword += " Only.";
            }
            else
            {
                this.ReportAmountInword += " " + point + " " + "Pyar Only.";
            }
        }
        #endregion
        
        #region Event
        //When Saving Withdrawal Offline/Online SelectedIndex
        private void PFMVEW00021_Load(object sender, EventArgs e)
        {
            cxcliC0011.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.cxcliC0011.PrintButtonCauseValidation = false;

            // Set format for PCEAccountNo to Mask properties  
            this.mtxtOLSAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.DomesticAccountFormat);

            // Set format for AccountNo to Mask properties  
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.InitiallizeControls();
        }

        //To Delete SavingWithdrawal Gridview"s Row
        private void gvSavingWithdrawal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CurrentUserEntity.IsIgnoreDataValidating = true;

            BindingSource _source = new BindingSource();
            _source.DataSource = this.ViewDataList;
            gvSavingWithdrawal.DataSource = _source;

            if (gvSavingWithdrawal.Rows[e.RowIndex].Cells["ColDelete"].Value != null && e.ColumnIndex == gvSavingWithdrawal.Columns["ColDelete"].Index)
                ViewDataList.RemoveAt(e.RowIndex);
            gvSavingWithdrawal.DataSource = ViewDataList;
            int counter = 1;
            for (int i = 0; i < gvSavingWithdrawal.Rows.Count; i++)
            {
                gvSavingWithdrawal.Rows[i].Cells["SrNo"].Value = (counter++).ToString();

            }

            CurrentUserEntity.IsIgnoreDataValidating = false;
        }

        //When Cancel Button Click
        private void cxcliC0011_CancelButtonClick(object sender, EventArgs e)
        {
            SavingReportList.Clear();
            gvSavingWithdrawal.DataSource = null;
            this.InitiallizeControls();
            this.SavingWithdrawalController.ClearErrors();
        }

        //When Exit Button Click
        private void cxcliC0011_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        //When Print Button Click
        private void cxcliC0011_PrintButtonClick(object sender, EventArgs e)
        {
            CurrentUserEntity.IsIgnoreDataValidating = true;
            savingWithdrawalController.Print();
            CurrentUserEntity.IsIgnoreDataValidating = false;
        }

        //When AddtoList Button Click
        private void butAddtoList_Click(object sender, EventArgs e)
        {

            if (Convert.ToDecimal(Amount) < 1)
            {
                // Invalid Amount.
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00037);
                txtAmount.Focus();
                return;
            }
            this.AmountToWords();
            this.BindDataToEntity();
            this.InitiallizeControls();
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        #endregion
     
    }
}

