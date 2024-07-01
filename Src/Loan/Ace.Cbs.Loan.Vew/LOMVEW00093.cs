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
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00093 : BaseForm, ILOMVEW00093
    {
        #region Contructor
        public LOMVEW00093()
        {
            InitializeComponent();
        }
        #endregion

        #region Controller
        private ILOMCTL00093 controller;
        public ILOMCTL00093 Controller
        {
            get { return controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        #endregion

        #region Properties
        public DateTime StartDate
        {
            get { return this.dtpStartDate.Value; }
            set { this.dtpStartDate.Text = value.ToString(); }
        }

        public DateTime EndDate
        {
            get { return this.dtpEndDate.Value; }
            set { this.dtpEndDate.Text = value.ToString(); }
        }

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

        public string SeasonType
        {
            get
            {
                if (this.cboSeasonType.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboSeasonType.SelectedValue.ToString();
                }
            }
            set { this.cboSeasonType.SelectedValue = value; }
        }

        public string CropType
        {
            get
            {
                if (this.cboCropType.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboCropType.SelectedValue.ToString();
                }
            }
            set { this.cboCropType.SelectedValue = value; }
        }

        private string reportType = string.Empty;
        public string ReportType
        {
            get { return this.reportType; }
            set { this.reportType = value; }
        }

        private string parentFormName = string.Empty;
        public string ParentFormName
        {
            get { return this.parentFormName; }
            set { this.parentFormName = value; }
        }

        #endregion

        #region Method
        #region Initialize
        private void InitailizeControl()
        {
            this.rdoAll.Checked = true;
            this.ReportType = "All";
            this.lblSeasonType.Visible = false;
            this.lblCropType.Visible = false;
            this.cboSeasonType.Visible = false;
            this.cboCropType.Visible = false;
            this.cboSeasonType.Enabled = false;
            this.cboCropType.Enabled = false;
            this.dtpStartDate.Value = DateTime.Now;
            this.dtpEndDate.Value = DateTime.Now;
            this.BindCurrency();
            this.BindSourceBranch();
            this.BindSeasonType();
            //this.BindCropType();
            this.dtpStartDate.Focus();
            // this.controller.ClearErrors();
        }
        #endregion

        #region BindComboBox

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
            cboBranch.SelectedIndex = -1;
        }

        public void BindSeasonType()
        {
            IList<LOMDTO00071> ListForSeasonType = CXCLE00002.Instance.GetListObject<LOMDTO00071>("LOMORM00071.SelectAllSeasonCode", new object[] { true });
            this.cboSeasonType.ValueMember = "Code";
            this.cboSeasonType.DisplayMember = "Description";
            this.cboSeasonType.DataSource = ListForSeasonType;
            this.cboSeasonType.SelectedIndex = -1;
        }

        public void BindCropType()
        {
            IList<LOMDTO00072> ListForCropType = CXCLE00002.Instance.GetListObject<LOMDTO00072>("LOMORM00072.SelectAllCropTypeCode", new object[] { true });
            this.cboCropType.ValueMember = "CropCode";
            this.cboCropType.DisplayMember = "Desp";
            this.cboCropType.DataSource = ListForCropType;
            this.cboCropType.SelectedIndex = -1;
        }

        public void BindLSBusinessType()
        {
            IList<LOMDTO00076> ListForLSBusinessType = CXCLE00002.Instance.GetListObject<LOMDTO00076>("LOMORM00076.SelectAllLSBusinessCode", new object[] { true });
            this.cboCropType.ValueMember = "Code";
            this.cboCropType.DisplayMember = "Description";
            this.cboCropType.DataSource = ListForLSBusinessType;
            this.cboCropType.SelectedIndex = -1;
        }
        
        #endregion 
        #endregion

        #region Events

        private void LOMVEW00093_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            
            if (this.FormName.Equals("AgricultureLoansReports"))
            {
                this.Text = "Agriculture Loans Reports";
                this.ParentFormName = "Agriculture Loans Reports";
                this.pnlRadio.Show();
                this.pnlCondition.Hide();
                this.rdoCropType.Visible = true;
                this.rdoCropType.Text = "By Crop Type";
                this.rdoSeasonType.Visible = true;
                this.lblCropType.Text = "Crop Type :";
                this.Height = 249;
                this.pnlRadio.Location = new Point(12, 42);
                this.pnlDefault.Location = new Point(12, 78);
                this.BindCropType();
            }
            else if (this.FormName.Equals("LiveStockLoansReports"))
            {
                this.Text = "Livestock Loans Reports";
                this.ParentFormName = "Livestock Loans Reports";
                this.pnlRadio.Show();
                this.pnlCondition.Hide();
                this.rdoCropType.Visible = true;
                this.rdoCropType.Text = "By Business Type";
                this.rdoSeasonType.Visible = false;
                this.lblCropType.Text = "Business Type :";
                this.Height = 249;
                this.pnlRadio.Location = new Point(12, 42);
                this.pnlDefault.Location = new Point(12, 78);
                this.BindLSBusinessType();
            }
            else if (this.FormName.Equals("FarmLoansReports"))
            {
                this.Text = "Farm Loans Reports";
                this.ParentFormName = "Farm Loans Reports";
                this.pnlRadio.Hide();
                this.pnlCondition.Hide();
                this.rdoAll.Visible = false;
                this.rdoSeasonType.Visible = false;
                this.rdoCropType.Visible = false;
                this.Height = 213;
                this.pnlDefault.Location = new Point(12,42);
            }
            this.InitailizeControl();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            this.controller.Print();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitailizeControl();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdoCropType_Click(object sender, EventArgs e)
        {
            this.Height = 288;
            this.pnlCondition.Show();  
            this.ReportType = "ByCropType";
            this.lblSeasonType.Visible = false;
            this.lblCropType.Visible = true;
            this.cboSeasonType.Visible = false;
            this.cboCropType.Visible = true;
            this.cboSeasonType.Enabled = false;
            this.cboCropType.Enabled = true;           
        }

        private void rdoSeasonType_Click(object sender, EventArgs e)
        {
            this.Height = 288;
            this.pnlCondition.Show();
            this.ReportType = "BySeasonType";
            this.lblSeasonType.Visible = true;
            this.lblCropType.Visible = false;
            this.cboSeasonType.Visible = true;
            this.cboCropType.Visible = false;
            this.cboSeasonType.Enabled = true;
            this.cboCropType.Enabled = false;
        }

        private void rdoAll_Click(object sender, EventArgs e)
        {
            this.Height = 249;
            this.pnlCondition.Hide();
            this.ReportType = "All";
            this.lblSeasonType.Visible = false;
            this.lblCropType.Visible = false;
            this.cboSeasonType.Enabled = false;
            this.cboCropType.Enabled = false;
            this.cboSeasonType.Visible = false;
            this.cboCropType.Visible = false;
        }

        #endregion
    }
}
