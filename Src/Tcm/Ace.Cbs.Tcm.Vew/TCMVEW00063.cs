
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00063 : BaseDockingForm, ITCMVEW00063
    {
        #region Properties
        private ITCMCTL00063 controller;
        public ITCMCTL00063 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }

        public string Status { get; set; }

        public string  AccountNo 
        {
            get { return this.mtxtAccountNo.Text.Replace("-", "").Trim(); }
            set { this.mtxtAccountNo.Text = value; }
        }

        public string AccountName
        {
            get { return this.lblAccountName.Text; }
            set { this.lblAccountName.Text = value; }
        }

        public string DepositCode
        {
            get { return this.cboDepositCode.SelectedValue == null ? string.Empty : this.cboDepositCode.SelectedValue.ToString(); }
            set { this.cboDepositCode.SelectedValue = value; }
        }

        public string DepositCodeDesp
        {
            get { return this.lblDepositCodeDesp.Text; }
            set { this.lblDepositCodeDesp.Text = value; }
        }

        public int SrNo { get; set; }

        public string CustomerName
        {
            get { return this.txtName.Text; }
            set { this.txtName.Text = value; }
        }

        public decimal Quota
        {
            get { return Convert.ToDecimal(this.txtQuota.Text); }
            set { txtQuota.Text =Convert.ToString(value); }
        }

        public decimal Quantity
        {
            get { return Convert.ToDecimal(txtQuantity.Text); }
            set { txtQuantity.Text = Convert.ToString(value); }
        }

        public decimal Amount
        {
            get { return Convert.ToDecimal(this.txtAmount.Text); }
            set { this.txtAmount.Text = Convert.ToString(value); }
        }

        public decimal AccumulateAmount
        {
            get { return Convert.ToDecimal(this.txtAccumulateAmount.Text); }
            set { this.txtAccumulateAmount.Text = Convert.ToString(value); }
        }

        public decimal TotalAccumulateAmount
        {
            get { return Convert.ToDecimal(this.txtTotalAccumulateAmount.Text); }
            set { this.txtTotalAccumulateAmount.Text = Convert.ToString(value); }
        }

        public string CurrencyCode
        {
            get
            {
                if (this.cboCurrency.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboCurrency.Text.ToString();
                }
            }
            set { this.cboCurrency.Text = value; }
        }

        private TLMDTO00008 dep_TlFEntity;
        public TLMDTO00008 Dep_TlFEntity
        {
            get
            {
                //if (this.dep_TlFEntity == null)    //comment by ASDA
                    this.dep_TlFEntity = new TLMDTO00008();
                this.dep_TlFEntity.CurrencyCode = this.CurrencyCode;                
                this.dep_TlFEntity.AccountNo = this.AccountNo;
                this.dep_TlFEntity.DepositCode = this.DepositCode;
                this.dep_TlFEntity.NAME = this.CustomerName;
                this.dep_TlFEntity.QUOTANO = this.Quota;
                this.dep_TlFEntity.Quantity = this.Quantity;
                this.dep_TlFEntity.AMOUNT = this.Amount;
                this.dep_TlFEntity.AccumulateAmount = this.AccumulateAmount;
                //this.dep_TlFEntity.SrNo = this.SrNo + 1;   //comment by ASDA
                if (this.Status == "Update")
                {
                    this.dep_TlFEntity.SrNo = serialNo + 1;
                }         
                else
                    this.dep_TlFEntity.SrNo = count;
                this.dep_TlFEntity.SourceBranchCode = this.SourceBranchCode;
                return dep_TlFEntity;
            }
            set { this.dep_TlFEntity = value; }
        }

        private IList<TLMDTO00008> dep_TLFCollection;
        public IList<TLMDTO00008> Dep_TLFCollection
        {
            get
            {
                if (this.dep_TLFCollection == null)
                    this.dep_TLFCollection = new List<TLMDTO00008>();
                return this.dep_TLFCollection;
            }
            set { this.dep_TLFCollection = value; }
        }

        public CXDTO00001 DenoInfo { get; set; }

        private bool OnStarted { get; set; }

        public string SourceBranchCode { get; set; }

        public decimal initialAmount { get; set; }

        int count = 0;  //Added by ASDA
        int serialNo = 0;

        #endregion Properties

        #region Constructor
        public TCMVEW00063()
        {
            InitializeComponent();
        }
        #endregion Constructor

        #region Methods
        private void InitializeControls()
        {
            BindComboBoxes();
            this.cboCurrency.Select();
            initialAmount = 0;
        }

        private void BindComboBoxes()
        {
            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Symbol";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
            cboCurrency.SelectedIndex = 0;

            IList<TLMDTO00020> DepositCodeList = CXCLE00002.Instance.GetListObject<TLMDTO00020>("DepositCode.Client.Select", new object[] { CurrentUserEntity.BranchCode, true });
            cboDepositCode.ValueMember = "DepositCode";
            cboDepositCode.DisplayMember = "Description";            
            cboDepositCode.DataSource = DepositCodeList;
            OnStarted = false;
            cboDepositCode.SelectedIndex = -1;
        }

        public void EnableControlsforView(string name)
        {
            this.EnableControls(name);
        }

        public void DisableControlsforView(string name)
        {
            this.DisableControls(name);
        }

        public void BindData()
        {
            if (Dep_TLFCollection.Count > 0)
            {
                this.dgvDep_TLFInformation.DataSource = null;
                this.dgvDep_TLFInformation.AutoGenerateColumns = false;
                this.dgvDep_TLFInformation.DataSource = this.Dep_TLFCollection;
            }
            else
            {
                this.dgvDep_TLFInformation.DataSource = null;
                this.EnableControls("Curreny.Enable");
            }
          
        }
        public void BindgvMultiData(IList<TLMDTO00008> dep_TLFCollection)
        {
            if (Dep_TLFCollection.Count > 0)
            {
                this.dgvDep_TLFInformation.DataSource = null;
                this.dgvDep_TLFInformation.AutoGenerateColumns = false;
                this.dgvDep_TLFInformation.DataSource = this.Dep_TLFCollection;
            }
            else
            {
                this.dgvDep_TLFInformation.DataSource = null;
                this.EnableControls("Curreny.Enable");
            }
           
            //this.Status = "Add";

        }

        public void SetCursor(string txt)
        {
            if (txt == "Currency")
                cboCurrency.Focus();
            else if (txt == "Amount")
                txtAmount.Focus();
        }

        public void Successful(string message, string name, string VoucherNo)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, new object[] { name, VoucherNo });
            this.cboCurrency.Focus();
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }
      
        #endregion Methods

        #region Event
        private void TCMVEW00063_Load(object sender, EventArgs e)
        {
            try
            {
                //Enable Disable for tool strip bar for Update/Delete/Insert/Select Operation
                this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
                this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
                OnStarted = true;
                this.InitializeControls();
            }
            catch(Exception ex)
            {
                //Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME900043, new object[] { name, VoucherNo });
            }
        }

        private void cboDepositCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDepositCode.SelectedIndex != -1 && !OnStarted)
            {
                lblDepositCodeDesp.Text = Convert.ToString(cboDepositCode.SelectedValue);
            }
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            //if (this.Controller.ValidateAdd())
            //{
                this.AddData();
                //this.Controller.CalculateTotalAmount();                
                this.Controller.ClearControls(false);
            
                 //count++;                                       //Added by ASDA                 
            //this.Dep_TLFCollection.Add(this.Dep_TlFEntity);                
            //    this.BindData();
            //    this.Controller.ClearControls(false);
                //this.cboDepositCode.Select();
            //}
        }

        private void AddData()
        {
            if (this.Status == "Update")
            {
                int i = 0;
                decimal j = 0;
                this.Dep_TLFCollection.RemoveAt(serialNo);
                foreach (TLMDTO00008 TlfInfo in Dep_TLFCollection)
                {
                    i++;
                    if (i <= serialNo)
                        j += TlfInfo.AMOUNT;
                    else
                        break;
                }
                this.AccumulateAmount = j + this.Amount;
                this.Dep_TLFCollection.Insert(serialNo, this.Dep_TlFEntity);
                this.dep_TLFCollection[dep_TLFCollection.Count - 1].AccumulateAmount = this.TotalAccumulateAmount;
            }
            else
            {
                count++;
                this.Dep_TLFCollection.Add(this.Dep_TlFEntity);
            }

            //else if (this.count == this.Dep_TLFCollection.Count)
            //{
              //  CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00210);
                //return;
            //}

            //this.Dep_TLFCollection.Add(this.Dep_TlFEntity);
            this.initialAmount = this.TotalAccumulateAmount;  //friday
            this.BindData();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (Controller.Save())
            {
                this.InitializeControls();
                this.Controller.ClearControls(true);
            }
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.Controller.ClearControls(true);
            this.count = 0;
        }
        #endregion Event        

        public void CalculateTotalAmount(IList<TLMDTO00008> deno_TLFEntityList)
        {
            this.TotalAccumulateAmount = 0;
            //this.TotalCharges = 0;

            foreach (TLMDTO00008 entity in deno_TLFEntityList)
            {
                this.TotalAccumulateAmount += entity.AMOUNT;
                    //this.TotalAmount += entity.Amount + entity.Commission + entity.CommunicationCharges;
                    //this.TotalCharges += entity.Commission + entity.CommunicationCharges;               
            }
        }

        private void dgvDep_TLFInformation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)  //Delete
            {
                if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC90001) == DialogResult.Yes)
                {
                    this.Dep_TLFCollection.RemoveAt(e.RowIndex);
                    //this.CalculateTotalAmount(this.dep_TLFCollection);
                    //this.BindgvMultiData(this.dep_TLFCollection);
                    this.TotalAccumulateAmount = 0;
                    this.CalculateTotalAmount(this.dep_TLFCollection);
                    if (this.dep_TLFCollection.Count > 0)
                    {
                        this.dep_TLFCollection[dep_TLFCollection.Count - 1].AccumulateAmount = this.TotalAccumulateAmount;
                    }
                   //this.BindgvMultiData(this.dep_TLFCollection);
                    //this.Controller.CalculateTotalAmount();
                    this.initialAmount = this.TotalAccumulateAmount;
                    this.BindData(); 
                    this.Status = "Add";
                }
            }
            else if (e.ColumnIndex == 0)  //Update
            {
                TLMDTO00008 dep_TlFEntity = this.dgvDep_TLFInformation.Rows[e.RowIndex].DataBoundItem as TLMDTO00008;
                this.serialNo = e.RowIndex;
                //this.initialAmount = this.TotalAccumulateAmount;
                //this.AccountNo = depositEntity.AccountNo;
                this.CustomerName = dep_TlFEntity.NAME;
                this.Quota = dep_TlFEntity.QUOTANO;
                this.Quantity = dep_TlFEntity.Quantity;
                this.Amount = dep_TlFEntity.AMOUNT;
                this.AccumulateAmount = dep_TlFEntity.AccumulateAmount;
                this.TotalAccumulateAmount = this.TotalAccumulateAmount;
                //this.TotalAccumulateAmount = this.TotalAccumulateAmount - Amount;
                this.DepositCode = dep_TlFEntity.DepositCode;
                this.initialAmount = this.TotalAccumulateAmount - Amount;
                this.Status = "Update";
            }
        }

        private void dgvDep_TLFInformation_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
