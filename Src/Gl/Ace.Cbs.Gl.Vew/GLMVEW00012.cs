using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Gl.Ctr.Ptr;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Gl.Vew
{
    public partial class GLMVEW00012 : BaseDockingForm, IGLMVEW00012
    {
        public string PLAccount
        {
            get
            {
                if (this.cboPLA.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboPLA.SelectedValue.ToString();
                }
                
            }
            set
            {
                this.cboPLA.SelectedValue = value;
            }
        }

        public string PITAccount
        {
            get
            {
                if (this.cboPITA.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboPITA.SelectedValue.ToString();
                }

            }
            set
            {
                this.cboPITA.SelectedValue = value;
            }
        }

        #region Constructor
        public GLMVEW00012()
        {
            InitializeComponent();
        }
        #endregion

        private IGLMCTL00012 controller;
        public IGLMCTL00012 Controller
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

        #region Method
        public void BindPLACombo()
        {
            IList<ChargeOfAccountDTO> ChargeOfAccountList = this.controller.SelectCOAData();
            this.cboPLA.DisplayMember = "ACode";
            this.cboPLA.ValueMember = "ACode";
            this.cboPLA.ColumnNames = "ACode, DCODE";
            this.cboPLA.DataSource = ChargeOfAccountList;
            this.cboPLA.SelectedIndex = -1;
        }

        public void BindPITACombo()
        {
            IList<ChargeOfAccountDTO> ChargeOfAccountList = this.controller.SelectCOAData();
            this.cboPITA.DisplayMember = "ACode";
            this.cboPITA.ValueMember = "ACode";
            this.cboPITA.ColumnNames = "ACode, DCODE";
            this.cboPITA.DataSource = ChargeOfAccountList;
            this.cboPITA.SelectedIndex = -1;
        }

        public void BindDataGridView(string accountCode, string check)
        {
            IList<ChargeOfAccountDTO> ChargeOfAccountList = this.controller.SelectCOADataByAcode(accountCode);

            if (check == "PLA")
            {
                this.dgvPLA.AutoGenerateColumns = false;
                this.dgvPLA.DataSource = ChargeOfAccountList;
                this.dgvPLA.Refresh();
            }
            else if (check == "PITA")
            {
                this.dgvPITA.AutoGenerateColumns = false;
                this.dgvPITA.DataSource = ChargeOfAccountList;
                this.dgvPITA.Refresh();
            }
        }

        public void InitializeControl()
        {
            this.BindPLACombo();
            this.BindPITACombo();
            this.dgvPLA.DataSource = "";
            this.dgvPITA.DataSource = "";
            this.controller.ClearErrors();
        }
        #endregion

        private void GLMVEW00012_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, false, true);   
            this.Text = "Liabilities Account Code Accepted Form";
            this.InitializeControl();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
            this.controller.clickonOK();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            if (CXUIMessageUtilities.ShowMessageByCode("MC30007") == DialogResult.Yes)
            {
                this.InitializeControl();
                this.Close();
            }            
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboPLA_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindDataGridView(this.cboPLA.Text, "PLA");
        }

        private void cboPITA_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindDataGridView(this.cboPITA.Text, "PITA");
        }
    }
}
