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
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Loan.Vew
{
    //Created by HWKO (08-Dec-2017)
    public partial class LOMVEW00334 : BaseForm, ILOMVEW00334
    {
        #region Constructor
        public LOMVEW00334()
        {
            InitializeComponent();
        }
        #endregion

        IList<LOMDTO00334> selectedCustList = new List<LOMDTO00334>();

        #region Controller
        private ILOMCTL00334 controller;
        public ILOMCTL00334 Controller
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

        public string ProductName
        {
            get { return this.txtProductName.Text; }
            set { this.txtProductName.Text = value.ToString(); }
        }

        public string CarNo
        {
            get { return this.txtCarNo.Text; }
            set { this.txtCarNo.Text = value.ToString(); }
        }

        public string CarBoardNo
        {
            get { return this.txtCarBoardNo.Text; }
            set { this.txtCarBoardNo.Text = value.ToString(); }
        }

        public string NoOfProduct
        {
            get { return this.txtNoOfProduct.Text; }
            set { this.txtNoOfProduct.Text = value.ToString(); }
        }

        public string CustNameConcat
        {
            get { return this.GetCustNameConcatData(); }
            set { this.BindCustomerCheckListBoxData(); }
        }

        public string CustNameCustNRCConcat
        {
            get { return this.GetCustNameCustNRCConcatData("comma"); }
            set { this.BindCustomerCheckListBoxData(); }
        }

        public string CustNameCustNRCConcatWithEnter
        {
            get { return this.GetCustNameCustNRCConcatData("enter"); }
            set { this.BindCustomerCheckListBoxData(); }
        }

        public string CustNRCConcat
        {
            get { return this.GetCustNRCConcatData(); }
            set { this.BindCustomerCheckListBoxData(); }
        }

        public string CustFatherNameConcat
        {
            get { return this.GetCustFatherNameConcatData(); }
            set { this.BindCustomerCheckListBoxData(); }
        }

        public string CustAddressForOneConcat
        {
            get { return this.GetCustAddressForOneConcatData(); }
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
            this.ProductName = string.Empty;
            this.CarNo = string.Empty;
            this.CarBoardNo = string.Empty;
            this.NoOfProduct = string.Empty;

            //remove all items from checklistbox
            ((ListBox)this.chklstCompanyInfo).DataSource = null;
            chklstCompanyInfo.Items.Clear();
            chklstCompanyInfo.Visible = false;
            lblCutomerName.Visible = false;
            

            //for (int index = chklstCompanyInfo.Items.Count; index > 0; index--)
            //{
            //    if (chklstCompanyInfo.CheckedItems.Contains(chklstCompanyInfo.Items[index - 1]))
            //        chklstCompanyInfo.Items.RemoveAt(index - 1);
            //}
            
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

        private void LOMVEW00334_Load(object sender, EventArgs e)
        {
            this.InitailizeControls();
            this.chklstCompanyInfo.Visible = false;
            this.lblCutomerName.Visible = false;
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitailizeControls();
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
            selectedCustList = new List<LOMDTO00334>();
            foreach (var item in chklstCompanyInfo.CheckedItems.OfType<LOMDTO00334>())
            {
                LOMDTO00334 customerInfo = new LOMDTO00334();
                customerInfo.AcctNo = item.AcctNo;
                customerInfo.CarBoardNoFromView = item.CarBoardNoFromView;
                customerInfo.CarNoFromView = item.CarNoFromView;
                customerInfo.Commission = item.Commission;
                customerInfo.ComRate = item.ComRate;
                customerInfo.CustAddress = item.CustAddress;
                customerInfo.CustAddressForOne = item.CustAddressForOne;
                customerInfo.CustFatherName = item.CustFatherName;
                customerInfo.CustName = item.CustName;
                customerInfo.CustNameConcatFromView = item.CustNameConcatFromView;
                customerInfo.CustNameCustNRC = item.CustNameCustNRC;
                customerInfo.CustNRC = item.CustNRC;
                customerInfo.DateFromView = item.DateFromView;
                customerInfo.DownPayment = item.DownPayment;
                customerInfo.DueDate = item.DueDate;
                customerInfo.FTDueDate = item.FTDueDate;
                customerInfo.GuaAddress = item.GuaAddress;
                customerInfo.GuaFatherName = item.GuaFatherName;
                customerInfo.GuaName = item.GuaName;
                customerInfo.GuaNRC = item.GuaNRC;
                customerInfo.HPNo = item.HPNo;
                customerInfo.InstallAmtPerTerm = item.InstallAmtPerTerm;
                customerInfo.LoanAmount = item.LoanAmount;
                customerInfo.LTDueDate = item.LTDueDate;
                customerInfo.NoOfProductFromView = item.NoOfProductFromView;
                customerInfo.ProductName = item.ProductName;
                customerInfo.ProductNameFromView = item.ProductNameFromView;
                customerInfo.RChgAmtPerTerm = item.RChgAmtPerTerm;
                customerInfo.RChgRate = item.RChgRate;
                customerInfo.SourceBr = item.SourceBr;
                customerInfo.TermNo = item.TermNo;
                customerInfo.TotalInstallmentAmt = item.TotalInstallmentAmt;
                customerInfo.CustNameCustNRCConcatFromView = item.CustNameCustNRCConcatFromView;
                customerInfo.CustNRCConcatFromView = item.CustNRCConcatFromView;
                customerInfo.CustFatherNameConcatFromView = item.CustFatherNameConcatFromView;               
                
                selectedCustList.Add(customerInfo);
            }
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
                if (!this.controller.CheckHPAccountNo(this.AcctNo))
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00046);
                    this.mtxtAccountNo.Focus();
                    return;
                }
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
            IList<LOMDTO00334> CustNameList = new List<LOMDTO00334>();
            CustNameList = this.Controller.BindCustomerList(this.SourceBranch);
            
            ((ListBox)this.chklstCompanyInfo).DataSource = CustNameList;
            ((ListBox)this.chklstCompanyInfo).DisplayMember = "CustName";
            ((ListBox)this.chklstCompanyInfo).ValueMember = "CustName";
            this.chklstCompanyInfo.Focus();
        }

        private string GetCustNameCustNRCConcatData(string strType)
        {
            string strCustNameCustNRCConcat = "";
            
            foreach (var item in chklstCompanyInfo.CheckedItems.OfType<LOMDTO00334>())
            {
                if (strType == "comma")
                    strCustNameCustNRCConcat += item.CustNameCustNRC + ", ";
                else
                    strCustNameCustNRCConcat += item.CustNameCustNRC + "\r\n";
            }

            if (strCustNameCustNRCConcat.Trim().Length > 0 && strType == "comma")
            {
                if (strType == "comma")
                {
                    //if(chklstCompanyInfo.CheckedItems.Count > 1)
                        strCustNameCustNRCConcat = strCustNameCustNRCConcat.Remove(strCustNameCustNRCConcat.Trim().Length - 1);    //remove last character ", "
                }
                else
                    strCustNameCustNRCConcat = strCustNameCustNRCConcat.Remove(strCustNameCustNRCConcat.Trim().Length - 1); 
            }
            return strCustNameCustNRCConcat;
        }


        private string GetCustNRCConcatData()
        {
            string strCustNRCConcat = "";
            
            foreach (var item in chklstCompanyInfo.CheckedItems.OfType<LOMDTO00334>())
            {
                strCustNRCConcat += item.CustNRC + ", ";
            }

            if (strCustNRCConcat.Trim().Length > 0) strCustNRCConcat = strCustNRCConcat.Remove(strCustNRCConcat.Trim().Length - 1);    //remove last character ", "
            return strCustNRCConcat;
        }

        private string GetCustFatherNameConcatData()
        {
            string strCustFatherNameConcat = "";
            
            foreach (var item in chklstCompanyInfo.CheckedItems.OfType<LOMDTO00334>())
            {
                strCustFatherNameConcat += item.CustFatherName + ", ";
            }

            if (strCustFatherNameConcat.Trim().Length > 0) strCustFatherNameConcat = strCustFatherNameConcat.Remove(strCustFatherNameConcat.Trim().Length - 1);    //remove last character ", "
            return strCustFatherNameConcat;
        }


        private string GetCustNameConcatData()
        {
            string strCustNameConcat = "";
            
            foreach (var item in chklstCompanyInfo.CheckedItems.OfType<LOMDTO00334>())
            {
                strCustNameConcat += item.CustName + ", ";
            }

            if (strCustNameConcat.Trim().Length > 0) strCustNameConcat = strCustNameConcat.Remove(strCustNameConcat.Trim().Length - 1);    //remove last character ", "
            return strCustNameConcat;
        }

        private string GetCustAddressForOneConcatData()
        {
            string strCustAddressForOneConcat = "";
            int i = 0;
            
            foreach (var item in chklstCompanyInfo.CheckedItems.OfType<LOMDTO00334>())
            {
                if (i == 0)
                {
                    strCustAddressForOneConcat = item.CustAddress + ", ";
                }
                
                i++;
            }

            if (strCustAddressForOneConcat.Trim().Length > 0) strCustAddressForOneConcat = strCustAddressForOneConcat.Remove(strCustAddressForOneConcat.Trim().Length - 1);    //remove last character ", "
            return strCustAddressForOneConcat;
        }


        #endregion

        private void chklstCompanyInfo_Leave(object sender, EventArgs e)
        {
            if (chklstCompanyInfo.CheckedIndices.Count < 1 && this.AcctNo != "" && this.AcctNo.Substring(5, 1) == "3")
            {
                //Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90228);
                CXUIMessageUtilities.ShowMessageByCode("MV90228"); //For Company Account, please select at least one customer!
                chklstCompanyInfo.Focus();
            }
        }

        private void txtNoOfProduct_Leave(object sender, EventArgs e)
        {
            tsbCRUD.butPrint.Focus();
        }

    }
}
