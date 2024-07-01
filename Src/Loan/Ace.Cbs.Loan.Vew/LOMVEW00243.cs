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
    public partial class LOMVEW00243 : BaseForm, ILOMVEW00239
    {
        string eno;
        public LOMVEW00243()
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

        public string PNLAC
        {
            get { return this.txtPNLAC.Text; }
            set { this.txtPNLAC.Text = value; }
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
            this.txtPNLAC.Text = string.Empty;
            this.txtDesp.Text = string.Empty;
            this.lblRecordsCount.Text = "0";
        }

        public bool ValidationControls()
        {
            if (this.dgvIncomeLists.DataSource == null)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90067);//Incomplete data to save !
                errorProvider1.SetError(dgvIncomeLists, "Income Amount");
                return false;
            }
            if (string.IsNullOrEmpty(this.PNLAC))
            {                
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90067);//Incomplete data to save !
                errorProvider1.SetError(txtPNLAC, "Profit and Loss Account");
                return false;
            }   
            return true;
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

        private void LOMVEW00243_Load(object sender, EventArgs e)
        {
            tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            //this.lblDatetime.Text = DateTime.Now.ToString("dd-MM-yyyy");
            this.BindSourceBranch();
            this.BindCurrency();
            this.dgvIncomeLists.DataSource = null;

            #region Modified by HMW at 19-Sept-2019
            IList<LOMDTO00239> coaDTO;
            coaDTO = this.controller.Get_PNL_Zerorization_Income_Info(CurrentUserEntity.BranchCode);

            this.dgvIncomeLists.DataSource = coaDTO;
            this.dgvIncomeLists.Columns[0].Width = 30;
            this.dgvIncomeLists.Columns[1].Width = 90;
            this.dgvIncomeLists.Columns[2].Width = 250;
            this.dgvIncomeLists.Columns[3].Width = 120;
            int rowsCount = this.dgvIncomeLists.Rows.Count;
            this.lblRecordsCount.Text = rowsCount.ToString();
                
            this.dgvIncomeLists.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; //"No." Column
            this.dgvIncomeLists.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//"Account Code" Column
            this.dgvIncomeLists.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;//"Description" Column
            this.dgvIncomeLists.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;//"Amount" Column
            this.dgvIncomeLists.Columns[1].HeaderText = "Account Code";
            DateTime systemDate = this.Controller.GetSystemDate(CurrentUserEntity.BranchCode);
            lblDatetime.Text = systemDate.ToString("dd-MM-yyyy");
            this.dgvIncomeLists.Columns[3].DefaultCellStyle.Format = "N2";

            decimal totalAmount=0;            
            for(int i=0;i<coaDTO.Count;i++)
            {
                totalAmount = totalAmount + coaDTO[i].Amount;
            }
            lblTotalAmount.Text = "Total Amount =  "+Convert.ToDouble(totalAmount).ToString("N2");            
            txtPNLAC.Focus();            
            #endregion
        }     

        
        private void txtPNLAC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 9 || e.KeyValue == 13)//Tab Key = 9, Enter Key = 13
            {
                if (!string.IsNullOrEmpty(PNLAC))
                {
                    //Checking Zerorization for Income TXN already or not
                    string message = this.controller.Check_AlreadyZerorizationForIncomeAC(PNLAC);
                    if (message == "0")//No zerorization transaction for "Expense Accounts"
                    {
                        //Go
                    }
                    if (message == "-1") //Already exist zerorization transaction for "Expense Accounts"
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI30058);//Already finished Profit and Loss Balance Zerorization for 'Income Amount'!
                        this.dgvIncomeLists.DataSource = null;
                    }
                    else if (message == "-2")
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME90009);//Account No must not be blank.
                        txtPNLAC.Focus();
                    }
                    else if (message == "-3")
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00046);//Invalid Account No.
                        txtPNLAC.Focus();
                    }

                    //Getting COA Description
                    if (message != "-3")
                    {
                        string desp = this.controller.Get_Info_For_PNL_Zerorization_Income_ByPLAC(PNLAC, CurrentUserEntity.BranchCode);
                        if (!string.IsNullOrEmpty(desp))
                            this.txtDesp.Text = desp;
                        else
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00046);//Invalid Account No.
                            txtPNLAC.Focus();
                        }
                    }
                }
            }
        }

        private void txtPNLAC_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);            
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (!this.ValidationControls())
                return;            

            string retMsg=this.controller.PNL_Zerorization_Income_Voucher(PNLAC, CurrentUserEntity.CurrentUserID,CurrentUserEntity.BranchCode);

            if (retMsg=="0")
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90134);
                this.ClearControls();
                this.dgvIncomeLists.DataSource = null;
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
