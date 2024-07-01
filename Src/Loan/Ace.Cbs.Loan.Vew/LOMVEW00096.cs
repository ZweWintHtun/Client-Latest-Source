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
    public partial class LOMVEW00096 : BaseForm, ILOMVEW00096
    {
        public string sourceBr;
        public bool status;

        public LOMVEW00096()
        {
            InitializeComponent();
        }

        #region

        public LOMVEW00096(bool isMainMenu, string parentFormId)
        {
            InitializeComponent();

            this.IsMainMenu = isMainMenu;
            this.ParentFormId = parentFormId;
        }
        #endregion

        #region Controls Input Output

        private bool isMainMenu = true;
        public bool IsMainMenu
        {
            get { return this.isMainMenu; }
            set { this.isMainMenu = value; }
        }
        private string parentFormId = string.Empty;
        public string ParentFormId
        {
            get { return this.parentFormId; }
            set { this.parentFormId = value; }
        }

        public DateTime StartDate
        {
            get { return this.dtpStartDate.Value; }
            set { this.dtpStartDate.Value = value; }
        }

        public DateTime EndDate
        {
            get { return this.dtpEndDate.Value; }
            set { this.dtpEndDate.Value = value; }
        }

        public string SourceBr
        {
            get
            {
                if (this.cboBranch.SelectedValue == null)
                {
                    if (!CurrentUserEntity.IsHOUser)
                    {
                        sourceBr = CurrentUserEntity.BranchCode;
                        return sourceBr;
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

        public string StockGroup;
        #endregion

        #region Controller
        private ILOMCTL00096 controller;
        public ILOMCTL00096 Controller
        {
            get { return controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        #endregion

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

        private void BindStockGroup()
        {
            IList<LOMDTO00068> lstStockGroup = CXCLE00002.Instance.GetListObject<LOMDTO00068>("LOMORM00068.SelectAllStockGroup", new object[] { true });
            LOMDTO00068 dtostockGroup = new LOMDTO00068();
            dtostockGroup.Description = " -- SELECT --";
            lstStockGroup.Insert(0, dtostockGroup);
            cboProductGroup.DataSource = lstStockGroup;
            cboProductGroup.ValueMember = "GroupCode";
            cboProductGroup.DisplayMember = "Description";
            status = false;
        }

        #region Initialize
        private void InitailizeControl()
        {
            this.BindCurrency();
            this.BindSourceBranch();
            this.SourceBr = CurrentUserEntity.BranchCode;
            if (!CurrentUserEntity.IsHOUser)
            {
                this.cboBranch.Enabled = false;
            }
            else
            {
                this.cboBranch.Enabled = true;
            }

            this.OptByProductType.Checked = false;
            cboProductGroup.Enabled = false;
            cboProductGroup.SelectedIndex = 0;
            this.StockGroup = "";
        }
        #endregion
        #region Validation
        public bool ValidationControls()
        {
            if (cboCurrency.SelectedIndex == -1)
            {
                errorProvider1.SetError(cboCurrency, "Currency");
            }

            if (cboBranch.SelectedIndex == -1)
            {
                errorProvider1.SetError(cboBranch, "Branch");
            }
            if (cboCurrency.SelectedIndex == -1 || cboBranch.SelectedIndex == -1)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90067);
                errorProvider1.Clear();
                return false;
            }
            else return true;
        }
        #endregion
        private void LOMVEW00096_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            BindSourceBranch();
            BindCurrency();
            BindStockGroup();   
            this.InitailizeControl();         
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            string rptName = "HPRegListing";
            this.controller.Print(rptName,SourceBr,Currency,StartDate,EndDate,StockGroup);
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitailizeControl();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OptALL_Click(object sender, EventArgs e)
        {
            this.OptByProductType.Checked = false;
            cboProductGroup.Enabled = false;
            cboProductGroup.SelectedIndex =0;
            this.StockGroup = "";
        }

        private void OptByProductType_Click(object sender, EventArgs e)
        {
            this.OptALL.Checked = false;
            cboProductGroup.Enabled = true;
            cboProductGroup.SelectedIndex = 0;
            this.StockGroup = "''";
        }

        private void cboProductGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (status == false) //&& cboProductGroup.SelectedIndex>-1)
                this.StockGroup = (cboProductGroup.SelectedValue == null) ? "" : cboProductGroup.SelectedValue.ToString();
        }
    }
}
