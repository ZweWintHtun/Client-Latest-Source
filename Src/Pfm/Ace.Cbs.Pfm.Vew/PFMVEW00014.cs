using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Pfm.Vew
{
    public partial class frmPFMVEW00014 : BaseForm, IPFMVEW00014
    {
        //Stop Cheque Form
        #region"Constructor"
        public frmPFMVEW00014()
        {
            InitializeComponent();
        }
        #endregion

        #region"Properties"
        public int Id
        {
            get { throw new NotImplementedException(); }
        }

        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text.Replace("-","").Trim(); }
            set { this.mtxtAccountNo.Text = value; }
        }

        public string ChequeBookNo
        {
            get { return this.txtChequeBookNo.Text; }
            set { this.txtChequeBookNo.Text = value; }
        }

        public string StartSerialNo
        {
            get
            {
                return string.Format(CXCOM00007.Instance.GetValueByKeyName("ChequeNoDisplayFormat"), this.txtStartSerialNo.Text);
            }

            set { this.txtStartSerialNo.Text = Convert.ToString(value); }
        } 

        public string EndSerialNo
        {
            get
            {
                return string.Format(CXCOM00007.Instance.GetValueByKeyName("ChequeNoDisplayFormat"), this.txtEndSerialNo.Text);
            }
            set { this.txtEndSerialNo.Text =Convert.ToString(value); }
        }

        public string Remark
        {
            get { return this.txtRemark.Text; }
            set { this.txtRemark.Text = value; }
        }

        #endregion

        #region"Entity"

        private PFMDTO00011 stopChequeEntity;
        public PFMDTO00011 StopChequeEntity
        {
            get{
                 if (this.stopChequeEntity == null) this.stopChequeEntity = new PFMDTO00011();
                this.stopChequeEntity.AccountNo = this.AccountNo;
                this.stopChequeEntity.ChequeBookNo = this.ChequeBookNo;
                this.stopChequeEntity.StartNo = this.StartSerialNo;
                this.stopChequeEntity.EndNo = this.EndSerialNo;
                this.stopChequeEntity.Remark = this.Remark;
                this.stopChequeEntity.DATE_TIME = DateTime.Now;
                this.stopChequeEntity.SourceBranchCode = CXCOM00007.Instance.BranchCode;  
                
                this.stopChequeEntity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                this.stopChequeEntity.USERNO = CurrentUserEntity.CurrentUserID.ToString();
                
                return this.stopChequeEntity;            
            }
            set
            {
                this.stopChequeEntity = value;
            }
        
        }

        #endregion

        #region"Controller"
        private IPFMCTL00014 stopChequeController;
        public IPFMCTL00014 StopChequeController
        {
            set
            {
                this.stopChequeController = value;
                stopChequeController.StopChequeView = this;
            }
            get
            {
                return this.stopChequeController;
            }

        }

        #endregion

        #region"Methods"

        private void InitializeControls()
        {
            this.StopChequeController.ClearControls();
            this.gvCustomer.DataSource = null;
        }
       
        public void Successful(string message) 
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.InitializeControls();
            this.mtxtAccountNo.Focus();
        }
        
        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message, new object[] { message == "MV00091" ? CurrentUserEntity.BranchCode : null });
        }

        public void gvCustomer_DataBind(IList<PFMDTO00001> custList)
        {
            this.gvCustomer.DataSource = null;
            gvCustomer.AutoGenerateColumns = false;          
            this.gvCustomer.DataSource = custList;
        }

        #endregion

        #region "Event"
        private void frmPFMVEW00014_Load(object sender, EventArgs e)
        {
            this.cxcliC0011.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.InitializeControls();
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
        }       

        private void txtStartSerialNo_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.StartSerialNo))
            {
                this.StartSerialNo = CXCLE00007.GetFormatString(Convert.ToInt32(this.StartSerialNo), CXCOM00009.ChequeNoDisplayFormat);
            }
        }

        private void txtChequeBookNo_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.ChequeBookNo))
            {
                this.ChequeBookNo = CXCLE00007.GetFormatString(Convert.ToInt32(this.ChequeBookNo), CXCOM00009.ChequeBookNoDisplayFormat);                
            }
        }
        
        private void txtEndSerialNo_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.EndSerialNo))
            {
                this.EndSerialNo = CXCLE00007.GetFormatString(Convert.ToInt32(this.EndSerialNo), CXCOM00009.ChequeNoDisplayFormat);
            }
        }    

        private void txtChequeBookNo_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtStartSerialNo_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtEndSerialNo_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cxcliC0011_SaveButtonClick(object sender, EventArgs e)
        {
            this.StopChequeController.Save(this.StopChequeEntity);            
        }

        private void cxcliC0011_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cxcliC0011_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.mtxtAccountNo.Focus();
            this.StopChequeController.ClearErrors();
        }

        private void frmPFMVEW00014_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

        #endregion
    }
}

