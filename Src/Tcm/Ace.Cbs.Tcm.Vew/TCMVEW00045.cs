using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00045 : BaseDockingForm , ITCMVEW00045
    {
        #region Constructor

        public TCMVEW00045()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public string CustomerID
        {
            get 
            {
                if(this.txtCustomerID.Text=="")
                    return string.Empty;
                else
                    return this.txtCustomerID.Text;
            }
            set { this.txtCustomerID.Text = value; }
        }

        public string CustomerName
        {
            get { return this.txtName.Text; }
            set { this.txtName.Text = value; }
        }

        public string NRC
        {
            get { return this.txtNRC.Text; }
            set { this.txtNRC.Text = value; }
        }

        public string NumOfAccountOpened
        {
            get 
            { 
                return this.txtAcOpen.Text; 
            }
            set { this.txtAcOpen.Text = value; }
        }

        public string NumOfAccountClosed
        {
            get 
            {
                return this.txtAcClose.Text; 
            }
            set { this.txtAcClose.Text = value; }
        }

        public bool IsVIP
        {
            get { return this.lblVIP.Visible; }
            set { this.lblVIP.Visible = value; }
        }

        public PFMDTO00001 CustomerIdInfo { get; set; }

        #endregion

        #region Controller
        private ITCMCTL00045 controller;
        public ITCMCTL00045 Controller
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
        #endregion   
        
        #region Method

        private void InitializeControls()
        {
            //Enable Disable Menu Controls
            tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, false, true);
            txtCustomerID.Enabled = true;
            txtName.Enabled = false;
            txtNRC.Enabled = false;
            txtAcOpen.Enabled = false;
            txtAcClose.Enabled = false;
            lblVIP.Visible = false;
            gvAccountInfo.DataSource = null;
            gvGuaranteeLoans.DataSource = null;
            gvNumberofAccount.DataSource = null;
        }

        public void Successful(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        public void BindSAOFCAOFFAOFGridview(IList<TCMDTO00045> dtolist)
        {
            int closeAc = 0;
            this.gvAccountInfo.AutoGenerateColumns = false;
            this.gvAccountInfo.DataSource = null;
            if (dtolist != null && dtolist.Count > 0)
            { //ASDA {}
                this.gvAccountInfo.DataSource = dtolist;
                for (int i = 0; i < gvAccountInfo.Rows.Count; i++)
                {
                    if (gvAccountInfo.Rows[i].Cells["colAccountType"].Value != null && (gvAccountInfo.Rows[i].Cells["colAccountType"].Value.Equals("Current Account") || gvAccountInfo.Rows[i].Cells["colAccountType"].Value.Equals("Saving Account")
                        || gvAccountInfo.Rows[i].Cells["colAccountType"].Value.Equals("Fixed Deposit Account")))
                    {
                        gvAccountInfo.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.SkyBlue;

                    }

                    if (dtolist[i].CloseDate != null)
                    {
                        gvAccountInfo.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.OrangeRed;
                        closeAc += 1;
                    }
                } 
                this.txtAcClose.Text = closeAc.ToString();
            }//end
        }

        public void BindAccountCountGridview(IList<TCMDTO00045> dtolist)
        {
            this.gvNumberofAccount.AutoGenerateColumns = false;
            this.gvNumberofAccount.DataSource = null;
            if (dtolist != null && dtolist.Count > 0)
                this.gvNumberofAccount.DataSource = dtolist;
        }

        public void BindLoanGuaranteeGridView(IList<TLMDTO00018> dtolist)
        {
            this.gvGuaranteeLoans.AutoGenerateColumns = false;
            this.gvGuaranteeLoans.DataSource = null;
            if (dtolist != null && dtolist.Count > 0)
                this.gvGuaranteeLoans.DataSource = dtolist;
        }
        #endregion

        #region Events

        private void TCMVEW00045_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.txtCustomerID.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CustomerNoDisplayFormat);
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.Controller.ClearControls();
            this.txtCustomerID.Focus();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void butEnquiry_Click(object sender, EventArgs e)
        {
            this.Controller.SearchCustomerId();
        }

        private void gvAccountInfo_CellClick(object sender, DataGridViewCellEventArgs e)   //Added by ASDA
        {
            if (e.RowIndex.Equals(-1) || e.ColumnIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvAccountInfo.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colAccountNo"))
            {
                CXUIScreenTransit.Transit("frmTLMVEW00042", true, new object[] { this.Name, gvAccountInfo.CurrentRow.Cells["colAccountNo"].EditedFormattedValue.ToString() });                
            }
            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colAccountType") ||
                cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colAccountNo") || 
                cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colBalance"))
            {
                gvAccountInfo.EndEdit();
            }
        }

    }
}
