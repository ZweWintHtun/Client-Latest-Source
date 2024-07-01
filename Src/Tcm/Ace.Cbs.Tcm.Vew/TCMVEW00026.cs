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
using Ace.Windows.Core.Utt;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Tcm.Ctr.Ptr;

namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00026 : BaseForm,ITCMVEW00026
    {
        #region Constructor
        public TCMVEW00026()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties

        public bool IsAllBranch
        {
            get { return chkBranch.Checked; }
            set { chkBranch.Checked = value; }
        }

        public string Branch
        {
            //get
            //{
            //    if (this.cboBranch.Text == null)
            //    {
            //        return null;
            //    }
            //    else
            //    {
            //        return this.cboBranch.Text.ToString();
            //    }
            //}
            //set
            //{
            //    this.cboBranch.Text = value;
            //    this.cboBranch.SelectedValue = value;
            //}
            get
            {
                return this.lblBranchNo.Text.ToString();
            }
            set
            {
                this.lblBranchNo.Text = value;
            }
        }

        public string BranchCode
        {
            get
            {
                if (this.cboBranch.Text == null)
                {
                    return null;
                }
                else
                {
                    return this.cboBranch.Text;
                }
            }
            set
            {
                this.cboBranch.Text = value;
            }
        }
        /*Requested By AMMK, Added by Prize.*/
        public string DateType
        {
            get
            {
                if (this.rdoSettlementDate.Checked == true)
                {
                    return "Settlement Date";
                }
                else
                {
                    return "Transaction Date";
                }
            }
            set
            {
                if (value == "Settlement Date")
                {
                    this.rdoSettlementDate.Checked = true;
                }
                else
                {
                    this.rdoTransactionDate.Checked = true;
                }
            }
        }

        public DateTime Date
        {
            get { return this.dtpDate.Value; }
            set { this.dtpDate.Text = value.ToString(); }
        }

        public string Currency
        {
            get
            {
                if (this.cboCurrency.Text == null)
                {
                    return null;
                }
                else
                {
                    return this.cboCurrency.Text.ToString();
                }
            }
            set
            {
                this.cboCurrency.Text = value;
                this.cboCurrency.SelectedValue = value;
            }
        }

        //public bool AllBranches
        //{
        //    get { return this.chkAllBranches.Checked; }
        //    set { this.chkAllBranches.Checked = true; }
        //}


        public bool IsWithReversal
        {
            get { return this.chkWithReversal.Checked; }
            set { this.chkWithReversal.Checked = true; }
        }

        public bool IsByHomeCurrency
        {
            get { return this.chkByHomeCurrency.Checked; }
            set { this.chkByHomeCurrency.Checked = true; }
        }

        public string CurrencyType
        {
            get
            {
                if (this.rdoSourceCurrency.Checked == true)
                {
                    return "Source Currency";
                }

                else
                {
                    return "Home Currency";

                }

            }

            set
            {
                if (value == "Source Currency")
                {
                    this.rdoSourceCurrency.Checked = true;
                }
                else
                {
                    this.rdoHomeCurrency.Checked = true;
                }

            }

        }
        #endregion

        #region Controller
        private ITCMCTL00026 controller;
        public ITCMCTL00026 Controller
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
        private void BindCurrencyCombobox()
        {
            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
            cboCurrency.SelectedIndex = 0;
            }

        public void BindBranchNosComboBox()
        {
            IList<BranchDTO> BranchNoList = CXCLE00001.Instance.SelectAllBranch();
            //IList<BranchDTO> BranchNoList = CXCLE00002.Instance.GetListObject<BranchDTO>("Branch.Client.Select").ToList();
            this.cboBranch.ValueMember = "BranchCode";
            this.cboBranch.DisplayMember = "BranchCode";
            this.cboBranch.DataSource = BranchNoList;
            this.cboBranch.SelectedIndex = 0;
        }

        private void InitializeControls()
        {
            //Enable Disable Menu Controls
            tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            if (CurrentUserEntity.IsHOUser)
            {
                this.cboBranch.Visible = true;
                this.chkBranch.Visible = true;
                this.BindBranchNosComboBox();
                this.BranchCode = CurrentUserEntity.BranchCode;
                this.lblBranchNo.Visible = false;
            }
            else
            {
                this.lblBranchNo.Visible = true;
                //this.lblBranchNo.Text = this.Controller.GetViewData().SourceBranch + " (" + this.Controller.GetViewData().BranchName + ")";
                this.lblBranchNo.Text = CurrentUserEntity.BranchCode;/**/
                this.cboBranch.Visible = false;
                this.chkBranch.Visible = false;
            }

            this.BindCurrencyCombobox();
            this.rdoSourceCurrency.Checked = true;
            this.dtpDate.Value = DateTime.Now;
            
        }

        #endregion

        #region Events
        private void TCMVEW00026_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.dtpDate.Value = DateTime.Now;
            this.InitializeControls();
            this.controller.ClearCustomErrorMessage();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            this.controller.Print();
        }

        //private void chkAllBranches_CheckedChanged(object sender, EventArgs e)
        //{
        //    //if (chkAllBranches.Checked == true)
        //    //{
        //    //    this.DisableControls("CleanCashScroll.chkAllBranches.DisableControls");
        //    //}

        //    //else
        //    //{
        //        this.EnableControls("CleanCashScroll.chkAllBranches.EnableControls");
        //    //}
        //}

        private void rdoHomeCurrency_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoHomeCurrency.Checked == true)
            {
                this.DisableControls("CleanCashScroll.rdoHomeCurrency.DisableControls");
                this.BindCurrencyCombobox();
            }

            else
            {
                this.EnableControls("CleanCashScroll.rdoHomeCurrency.EnableControls");
            }
        }        

        private void chkBranch_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBranch.Checked) this.cboBranch.Enabled = false;
            else this.cboBranch.Enabled = true;
        }
        #endregion
    }
}
