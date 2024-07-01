using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Ptr;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00438 : BaseForm , ILOMVEW00438
    {

        #region Constructor
        public LOMVEW00438()
        {
            InitializeComponent();
        }
        private ILOMCTL00438 controller;
        public ILOMCTL00438 Controller
        {
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
            get { return this.controller; }
        }
        #endregion


        #region Properties
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
        public string AccountType
        {
            get
            {
                if (this.cboACTypes.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboACTypes.SelectedValue.ToString();
                }
            }
            set { this.cboACTypes.SelectedValue = value; }
        }
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
        
        IList<LOMDTO00001> TypeOfBusinessList { get; set; }
        public string rptName { get; set; }
        #endregion

        #region Events
        private void LOMVEW00438_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            BindLoanType();
            BindSourceBranch();
            InitializeControls();
            cboBranch.Focus();
            GetRequireCustomerType();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            InitializeControls();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (CheckDate())
            {
                try
                {
                    if (cboACTypes.SelectedValue == null)
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MV90220");//Select Loans Type!
                        cboACTypes.Focus();
                        return;
                    }
                    
                    if (cboBranch.SelectedValue == null)
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MV90219");//Select Branch Code!
                        cboBranch.Focus();
                        return;
                    }
                    this.Controller.Print();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00123");
            }
        }
        
        #endregion

        #region Helper Methods
        private bool CheckDate()
        {
            bool date = CXCOM00006.Instance.IsValidStartDateEndDate(this.dtpStartDate.Value, this.dtpEndDate.Value);
            if (date == false)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00131");//Start Date must not be greater than End Date.
            }
            return date;
        }
        public void InitializeControls()
        {
            this.rptName = "rptInternalCustomer";
            cboACTypes.SelectedValue = "";
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now;
            cboBranch.SelectedValue = "";
        }
        private void BindSourceBranch()
        {
            IList<BranchDTO> BranchList = CXCLE00002.Instance.GetListObject<BranchDTO>("Branch.Client.SelectNotOtherBank", new object[] { false });
            cboBranch.ValueMember = "BranchCode";
            cboBranch.DisplayMember = "BranchCode";
            cboBranch.DataSource = BranchList;
            cboBranch.SelectedIndex = 0;
        }
        public void BindLoanType()
        {
            //TypeOfBusinessList = this.Controller.BindLoansBType();
            TypeOfBusinessList = new List<LOMDTO00001>();
            LOMDTO00001 item = new LOMDTO00001();
            item.Code = "All";
            item.Description = "All";
            TypeOfBusinessList.Add(item);

            item = new LOMDTO00001();
            item.Code = "BL";
            item.Description = "Business Loan";
            TypeOfBusinessList.Add(item);

            item = new LOMDTO00001();
            item.Code = "PL";
            item.Description = "Personal Loan";
            TypeOfBusinessList.Add(item);

            item = new LOMDTO00001();
            item.Code = "HP";
            item.Description = "HirePurchase";
            TypeOfBusinessList.Add(item);

            item = new LOMDTO00001();
            item.Code = "DL";
            item.Description = "Dealer";
            TypeOfBusinessList.Add(item);

            this.cboACTypes.ValueMember = "Code";
            this.cboACTypes.DisplayMember = "Description";
            this.cboACTypes.DataSource = TypeOfBusinessList;
            this.cboACTypes.SelectedIndex = -1;
        }
        public void GetRequireCustomerType()
        {
            this.cboACTypes.Enabled = true;
            this.cboACTypes.SelectedValue = "";
            this.rptName = "rptInternalCustomer";
        }
        #endregion

    }
}
