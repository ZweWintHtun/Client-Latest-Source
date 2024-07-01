using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00244 : BaseForm, ILOMVEW00239
    {
        string eno;
        public LOMVEW00244()
        {
            InitializeComponent();
        }

        private ILOMCTL00237 controller;
        public ILOMCTL00237 Controller
        {
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
            get
            {
                return this.controller;
            }
        }

        public string ProfitandLossAC
        {
            get { return this.txtProfitandLossAC.Text; }
            set { this.txtProfitandLossAC.Text = value; }
        }

        public string SourceBr
        {
            get
            {
                if (this.cboBranch.SelectedValue == null)
                {
                    if (!CurrentUserEntity.IsHOUser)
                    {
                        SourceBr = CurrentUserEntity.BranchCode;
                        return CurrentUserEntity.BranchCode;
                    }
                    else return null;
                }
                else
                {
                    return this.cboBranch.SelectedValue.ToString();
                }

            }
            set { this.cboBranch.SelectedValue = value.ToString(); }
        }

        public string Currency
        {
            get
            {
                if (this.cboCurrency.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboCurrency.SelectedValue.ToString();
                }
            }
            set { this.cboCurrency.SelectedValue = value; }
        }

        public void ClearControls()
        {
            this.txtProfitandLossAC.Text = string.Empty;
            this.txtDesp.Text = string.Empty;
            this.lblRecordsCount.Text = "0";
        }

        public bool ValidationControls()
        {
            if (this.dgvExpnLists.DataSource == null)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90067);//Incomplete data to save !
                errorProvider1.SetError(dgvExpnLists, "Expense Amount");
                return false;
            }

            if (string.IsNullOrEmpty(this.ProfitandLossAC))
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90067);//Incomplete data to save !
                errorProvider1.SetError(txtProfitandLossAC, "ExpnAccount");                
                return false;
            }
            else return true;
        }

        private void BindCurrency()
        {
            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
            cboCurrency.SelectedIndex = 0;
        }

        private void BindSourceBranch()
        {
            IList<BranchDTO> BranchList = CXCLE00002.Instance.GetListObject<BranchDTO>("Branch.Client.SelectNotOtherBank", new object[] { false });

            cboBranch.ValueMember = "BranchCode";
            cboBranch.DisplayMember = "BranchCode";
            cboBranch.DataSource = BranchList;
            cboBranch.SelectedIndex = 0;
        }

        private void LOMVEW00244_Load(object sender, EventArgs e)
        {
            tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            //this.lblDatetime.Text = DateTime.Now.ToString("dd-MM-yyyy");
            this.BindSourceBranch();
            this.BindCurrency();
            this.dgvExpnLists.DataSource = null;

            #region Modified by HMW at 20-Sept-2019
            IList<LOMDTO00239> coaDTO;
            coaDTO = this.controller.Get_Expn_Zerorization_Expense_Info(CurrentUserEntity.BranchCode);
            this.dgvExpnLists.DataSource = coaDTO;
            this.dgvExpnLists.Columns[0].Width = 30;
            this.dgvExpnLists.Columns[1].Width = 80;
            this.dgvExpnLists.Columns[2].Width = 250;
            this.dgvExpnLists.Columns[3].Width = 115;
            int rowsCount = this.dgvExpnLists.Rows.Count;
            this.lblRecordsCount.Text = rowsCount.ToString();

            
            this.dgvExpnLists.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; //"No." Column
            this.dgvExpnLists.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//"Account Code" Column
            this.dgvExpnLists.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;//"Amount" Column
            this.dgvExpnLists.Columns[1].HeaderText = "Account Code";
            DateTime systemDate = this.Controller.GetSystemDate(CurrentUserEntity.BranchCode);
            lblDatetime.Text = systemDate.ToString("dd-MM-yyyy");
            this.dgvExpnLists.Columns[3].DefaultCellStyle.Format = "N2";

            decimal totalAmount = 0;
            for (int i = 0; i < coaDTO.Count; i++)
            {
                totalAmount = totalAmount + coaDTO[i].Amount;
            }
            lblTotalAmount.Text = "Total Amount =  " + Convert.ToDouble(totalAmount).ToString("N2");
            txtProfitandLossAC.Focus();
            #endregion
        }

        //private void txtExpnAC_Leave(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(ProfitandLossAC))
        //    {
        //        //Checking Zerorization for Income TXN already or not
        //        string message = this.controller.Check_AlreadyZerorizationForExpenseAC(ProfitandLossAC);
        //        if (message == "0")//No zerorization transaction for "Expense Accounts"
        //        {
        //            //Go
        //        }
        //        if (message == "-1") //Already exist zerorization transaction for "Expense Accounts"
        //        {
        //            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI30058);//Already finished Profit and Loss Balance Zerorization for 'Income Amount'!
        //            this.dgvExpnLists.DataSource = null;
        //        }
        //        else if (message == "-2")
        //        {
        //            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME90009);//Account No must not be blank.
        //            txtProfitandLossAC.Focus();
        //        }
        //        else if (message == "-3")
        //        {
        //            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00046);//Invalid Account No.
        //            txtProfitandLossAC.Focus();
        //        }

        //        //Getting COA Description
        //        if (message != "-3")
        //        {
        //            string desp = this.controller.Get_Info_For_Expn_Zerorization_Expense_ByExpnAC(ProfitandLossAC, CurrentUserEntity.BranchCode);
        //            if (!string.IsNullOrEmpty(desp))
        //                this.txtDesp.Text = desp;
        //            else
        //            {
        //                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00046);//Invalid Account No.
        //                txtProfitandLossAC.Focus();
        //            }
        //        }
        //    }            
        //}

        private void txtProfitandLossAC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 9 || e.KeyValue == 13)//Tab Key = 9, Enter Key = 13
            {
                if (!string.IsNullOrEmpty(ProfitandLossAC))
                {
                    //Checking Zerorization for Income TXN already or not
                    string message = this.controller.Check_AlreadyZerorizationForExpenseAC(ProfitandLossAC);
                    if (message == "0")//No zerorization transaction for "Expense Accounts"
                    {
                        //Go
                    }
                    if (message == "-1") //Already exist zerorization transaction for "Expense Accounts"
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI30058);//Already finished Profit and Loss Balance Zerorization for 'Income Amount'!
                        this.dgvExpnLists.DataSource = null;
                    }
                    else if (message == "-2")
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME90009);//Account No must not be blank.
                        txtProfitandLossAC.Focus();
                    }
                    else if (message == "-3")
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00046);//Invalid Account No.
                        txtProfitandLossAC.Focus();
                    }

                    //Getting COA Description
                    if (message != "-3")
                    {
                        string desp = this.controller.Get_Info_For_Expn_Zerorization_Expense_ByExpnAC(ProfitandLossAC, CurrentUserEntity.BranchCode);
                        if (!string.IsNullOrEmpty(desp))
                            this.txtDesp.Text = desp;
                        else
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00046);//Invalid Account No.
                            txtProfitandLossAC.Focus();
                        }
                    }
                }
            }
        }

        private void txtExpnAC_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {

            if (!this.ValidationControls())
                return;

            string retMsg = this.controller.Expn_Zerorization_Expense_Voucher(ProfitandLossAC,CurrentUserEntity.CurrentUserID
                                                                        ,CurrentUserEntity.BranchCode);

            if (retMsg == "0")
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90135);
                this.ClearControls();
                this.dgvExpnLists.DataSource = null;
                return;
            }
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.ClearControls();
        }
    }
}
