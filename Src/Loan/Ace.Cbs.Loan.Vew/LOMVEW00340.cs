using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Vew
{
    //Created by HWKO (14-Dec-2017)
    public partial class LOMVEW00340 : BaseForm, ILOMVEW00340
    {

        IList<LOMDTO00338> selectedCustList = new List<LOMDTO00338>();

        #region Constructor
        public LOMVEW00340()
        {
            InitializeComponent();
        }
        #endregion

        #region Controller
        private ILOMCTL00340 controller;
        public ILOMCTL00340 Controller
        {
            get { return this.controller; }
            set { this.controller = value; this.controller.View = this; }
        }
        #endregion

        #region Properties
        public string SourceBranch
        {
            get
            {
                if (this.cboBranch.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboBranch.SelectedValue.ToString();
                }

            }
            set { this.cboBranch.SelectedValue = value.ToString(); }
        }

        public string AcctNo
        {
            get { return this.mtxtAccountNo.Text.Trim(); }
            set { this.mtxtAccountNo.Text = value.Trim(); }
        }

        public DateTime DateFromView
        {
            get { return this.dtpPrintedDate.Value; }
            set { this.dtpPrintedDate.Text = value.ToString(); }
        }

        public string BudgetYear
        {
            get { return this.lblBudgetYear.Text; }
            set { this.lblBudgetYear.Text = value.ToString(); }
        }

        public string Reference_VW
        {
            get { return this.txtReference.Text; }
            set { this.txtReference.Text = value.ToString(); }
        }

        public string Description_VW
        {
            get { return this.txtDescription.Text; }
            set { this.txtDescription.Text = value.ToString(); }
        }

        public string Place_VW
        {
            get { return this.txtPlace.Text; }
            set { this.txtPlace.Text = value.ToString(); }
        }       

        public decimal Amount_VW
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtAmountVW.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtAmountVW.Text = value.ToString(); }
        }

        public string InsuranceDesp_VW
        {
            get { return this.txtInsuranceDesp.Text; }
            set { this.txtInsuranceDesp.Text = value.ToString(); }
        }

        public string CustNameCustNRCConcat
        {
            get { return this.GetCustNameCustNRCConcatData("bracket"); }
            set { this.BindCustomerCheckListBoxData(); }
        }

        #endregion

        #region Method

        #region Initialize

        private void InitailizeControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);

            this.BudgetYear = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);

            this.mtxtAccountNo.Text = string.Empty;
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            //this.BindCurrency();
            this.BindSourceBranch();
            //this.cboCurrency.Focus();
            this.cboBranch.Focus();
            this.SourceBranch = CurrentUserEntity.BranchCode;
            this.dtpPrintedDate.Value = DateTime.Now;
            this.txtReference.Text = string.Empty;
            this.txtDescription.Text = string.Empty;
            this.txtPlace.Text = string.Empty;
            this.txtInsuranceDesp.Text = string.Empty;
            this.txtAmountVW.Text = string.Empty;

            //remove all items from checklistbox
            ((ListBox)this.chklstCompanyInfo).DataSource = null;
            chklstCompanyInfo.Items.Clear();
            chklstCompanyInfo.Visible = false;
            lblCutomerName.Visible = false;

            if (!CurrentUserEntity.IsHOUser)
            {
                this.cboBranch.Enabled = false;
            }
            else
            {
                this.cboBranch.Enabled = true;
            }
        }

        #endregion

        #region BindComboBox

        //private void BindCurrency()
        //{
        //    IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
        //    cboCurrency.ValueMember = "Cur";
        //    cboCurrency.DisplayMember = "Cur";
        //    cboCurrency.DataSource = CurrencyList;
        //    cboCurrency.SelectedIndex = 0;
        //}

        private void BindSourceBranch()
        {
            IList<BranchDTO> BranchList = CXCLE00002.Instance.GetListObject<BranchDTO>("Branch.Client.SelectNotOtherBank", new object[] { false });
            cboBranch.ValueMember = "BranchCode";
            cboBranch.DisplayMember = "BranchCode";
            cboBranch.DataSource = BranchList;
            cboBranch.SelectedIndex = 0;
        }

        #endregion


        #endregion

        #region Events

        private void LOMVEW00340_Load(object sender, EventArgs e)
        {
            this.InitailizeControls();
            this.chklstCompanyInfo.Visible = false;
            this.lblCutomerName.Visible = false;
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (chklstCompanyInfo.CheckedIndices.Count < 1 && this.AcctNo != "" && this.AcctNo.Substring(5, 1) == "3") //if Account Sub Type is Company (3)
            {
                //Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90228);
                CXUIMessageUtilities.ShowMessageByCode("MV90228"); //For Company Account, please select at least one customer!
                chklstCompanyInfo.Focus();
                return;
            }

            if (this.AcctNo.Substring(5, 1) == "3")
            {
                BindSelectedCustomersFromCheckList();
                this.Controller.Print(selectedCustList);
            }
            else
                this.controller.Print();
        }

        private void BindSelectedCustomersFromCheckList()
        {
            selectedCustList = new List<LOMDTO00338>();
            foreach (var item in chklstCompanyInfo.CheckedItems.OfType<LOMDTO00338>())
            {
                LOMDTO00338 customerInfo = new LOMDTO00338();
                customerInfo.AcctNo = item.AcctNo;
                customerInfo.CustAddress = item.CustAddress;
                customerInfo.CustAddressForOneConcatFromView = item.CustAddressForOneConcatFromView;
                customerInfo.CustCompanyName = item.CustCompanyName;
                customerInfo.CustFatherName = item.CustFatherName;
                customerInfo.CustFatherNameConcatFromView = item.CustFatherNameConcatFromView;
                customerInfo.CustName = item.CustName;
                customerInfo.CustNameConcatFromView = item.CustNameConcatFromView;
                customerInfo.CustNameCustNRC = item.CustNameCustNRC;
                customerInfo.CustNameCustNRCConcatFromView = item.CustNameCustNRCConcatFromView;
                customerInfo.CustNRC = item.CustNRC;
                customerInfo.CustNRCConcatFromView = item.CustNRCConcatFromView;
                customerInfo.DateFromView = item.DateFromView;
                customerInfo.DownPayment = item.DownPayment;
                customerInfo.DueDate = item.DueDate;
                customerInfo.FTDueDate = item.FTDueDate;
                customerInfo.GuaAddress = item.GuaAddress;
                customerInfo.GuaName = item.GuaName;
                customerInfo.GuaNRC = item.GuaNRC;
                customerInfo.InstallAmtPerTerm = item.InstallAmtPerTerm;
                customerInfo.Lno = item.Lno;
                customerInfo.LoanAmount = item.LoanAmount;
                customerInfo.LTDueDate = item.LTDueDate;
                customerInfo.RChgAmtPerTerm = item.RChgAmtPerTerm;
                customerInfo.RChgRate = item.RChgRate;
                customerInfo.SourceBr = item.SourceBr;
                customerInfo.StockGroupDesp = item.StockGroupDesp;
                customerInfo.StockItemDesp = item.StockItemDesp;
                customerInfo.TermNo = item.TermNo;
                customerInfo.TotalInstallmentAmt = item.TotalInstallmentAmt;

                selectedCustList.Add(customerInfo);
            }
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitailizeControls();
        }

        private void mtxtAccountNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void mtxtAccountNo_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.AcctNo))
            {
                if (!this.controller.CheckBLAccountNo(this.AcctNo))
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00046);
                    this.mtxtAccountNo.Focus();
                    return;
                }
                //Passed Acctno
                if (this.AcctNo.Substring(5, 1) == "3") //if Account Sub Type is Company (3)
                {
                    this.chklstCompanyInfo.Visible = true;
                    this.lblCutomerName.Visible = true;
                    BindCustomerCheckListBoxData();
                }
                else
                {
                    this.chklstCompanyInfo.Visible = false;
                    this.lblCutomerName.Visible = false;
                }

            }
        }

        private void BindCustomerCheckListBoxData()
        {
            chklstCompanyInfo.Visible = true;
            lblCutomerName.Visible = true;
            IList<LOMDTO00338> CustNameList = new List<LOMDTO00338>();
            CustNameList = this.Controller.BindCustomerList(this.SourceBranch);

            ((ListBox)this.chklstCompanyInfo).DataSource = CustNameList;
            ((ListBox)this.chklstCompanyInfo).DisplayMember = "CustName";
            ((ListBox)this.chklstCompanyInfo).ValueMember = "CustName";
            this.chklstCompanyInfo.Focus();
        }

        private string GetCustNameCustNRCConcatData(string strType)
        {
            string strCustNameCustNRCConcat = "";

            foreach (var item in chklstCompanyInfo.CheckedItems.OfType<LOMDTO00338>())
            {
                //strCustNameCustNRCConcat += item.CustNameCustNRC + ", ";
                if (strType == "bracket")
                    strCustNameCustNRCConcat += item.CustName + " (" + item.CustNRC + "), ";
                else if (strType == "bracketwithenter")
                    strCustNameCustNRCConcat += item.CustName + " (" + item.CustNRC + ") ";
                else
                    strCustNameCustNRCConcat += item.CustName + " " + item.CustNRC + "\r\n";
            }

            if (strCustNameCustNRCConcat.Trim().Length > 0) strCustNameCustNRCConcat = strCustNameCustNRCConcat.Remove(strCustNameCustNRCConcat.Trim().Length - 1);    //remove last character ", "

            return strCustNameCustNRCConcat;
        }


        #endregion

    }
}
