using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Mnm.Ctr.Ptr;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00077 : BaseForm ,IMNMVEW00077
    {
        #region Properties

        private string formName = string.Empty;
        public string FormName
        {
            get { return this.formName; }
            set { this.formName = value; }
        }

        public DateTime RequiredDate
        {
            get { return this.dtpRequiredDate.Value; }
            set { this.dtpRequiredDate.Text = value.ToString(); }
        }
        public string BranchCode
        {
            get
            {
                return this.cboBranch.Text.ToString();
            }
            set
            {
                this.cboBranch.Text = value;
                this.cboBranch.SelectedValue = value;
            }
        }

       // public bool IsTransactionDate { get; set; }
        public bool IsTransactionDate
        {
            get 
            {
                if (rdoTransactionDate.Checked)
                    return true;
                else
                    return false;
            }
            set
            {
                this.rdoTransactionDate.Checked = value;
            }
        }
        public bool IsSettlementDate
        {
            get
            {
                if (rdoSettlementDate.Checked)
                    return true;
                else
                    return false;
            }
            set
            {
                this.rdoSettlementDate.Checked = value;
            }
        }
    
        IList<BranchDTO> BranchList { get; set; }

        #region controller
        private IMNMCTL00077 RDandREListByBranchController;
        public IMNMCTL00077 Controller
        {
            get
            {
                return this.RDandREListByBranchController;
            }
            set
            {
                this.RDandREListByBranchController = value;
                this.RDandREListByBranchController.View = this;
            }
        }
        #endregion

        #endregion

        #region Constructor
        public MNMVEW00077()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        public void BindBranchCode()
        {
            string sourceBranchCode = CXCOM00007.Instance.BranchCode;            
            
            BranchList = CXCLE00002.Instance.GetListByCustomHQL<BranchDTO>("BranchCodeAndBranchDesp.SelectAllOthersBranch", new Dictionary<string, object>() { { "sourcebranchcode", sourceBranchCode } });

            cboBranch.ValueMember = "BranchCode";
            cboBranch.DisplayMember = "BranchCode";
            cboBranch.DataSource = BranchList;
        }

        private void InitializeControls()
        {
            //Enable Disable Menu Controls
            
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.BindBranchCode();
            this.rdoTransactionDate.Checked = true;
            this.dtpRequiredDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            this.cboBranch.SelectedIndex = -1;
        }

        public bool CheckDate()
        {
            // Check dtpStartDate Date Time
            if (this.dtpRequiredDate.Value.Date > DateTime.Now.Date)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00160, this.dtpRequiredDate.Value.ToString("dd/MM/yyyy"));//Datetime cannot be greater than today date.
                this.dtpRequiredDate.Focus();
                return false;
            }
            return true;
        }

        public string GetFormName()
        {
            string name = string.Empty;
            if (this.FormName == "Daily Drawing Remittance Listing")
            {
                name = "RD List By Branch";
            }
            else if (this.FormName == "Daily Encashment Remittance Listing")
            {
                name = "RE List By Branch";
            }
            return name;
        }

        #endregion

        #region Events
        private void MNMVEW00077_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.InitializeControls();
            this.Text = this.GetFormName();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (this.CheckDate())
            {
                this.Controller.Print();
            }
        }
      
        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
        }
        #endregion
    }
}
