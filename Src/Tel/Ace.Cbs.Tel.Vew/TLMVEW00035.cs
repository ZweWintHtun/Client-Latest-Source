//----------------------------------------------------------------------
// <copyright file="TLMVEW00035.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate> 2013-07-17 </CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tel.Vew
{
    /// <summary>
    /// Lisitng => Bank Cash Scroll View
    /// </summary>
    public partial class TLMVEW00035 : BaseForm, ITLMVEW00035
    {
        #region "Input Output Controls"

        public bool IsAllBranch
        {
            get { return chkBranch.Checked; }
            set { chkBranch.Checked = value; }
        }

        public string BranchNo
        {
            //get
            //{
            //    if (this.cboBranchNo.SelectedValue == null)
            //    {
            //        return null;
            //    }
            //    else
            //    {
            //        return this.cboBranchNo.SelectedValue.ToString();
            //    }
            //}
            //set { this.cboBranchNo.SelectedValue = value; }
            get
            {
                return this.lblBranchNo.Text.ToString();
            }
            set
            {
                this.lblBranchNo.Text = value;
            }
        }

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

        public DateTime RequiredDate
        {
            get { return this.dtpRequiredDate.Value; }
            set { this.dtpRequiredDate.Text = value.ToString(); }
        }

        //public bool IsAllBranches
        //{
        //    get { return chkAllBranches.Checked; }
        //    set { this.chkAllBranches.Checked = true; }
        //}

        public string CurrencyType
        {
            get
            {
                if (this.rdoSourceCur.Checked == true)
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
                    this.rdoSourceCur.Checked = true;
                }
                else
                {
                    this.rdoHomeCur.Checked = true;
                }
            }
        }

        public bool IsWithReversal
        {
            get { return chkReversal.Checked; }
            set { this.chkReversal.Checked = true; }
        }

        public bool IsHomeCurrency
        {
            get { return chkByHomeCur.Checked; }
            set { this.chkByHomeCur.Checked = true; }
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
            }
        }

        public string BranchCode
        {
            get
            {
                if (this.cboBranchNo.Text == null)
                {
                    return null;
                }
                else
                {
                    return this.cboBranchNo.Text;
                }
            }
            set
            {
                this.cboBranchNo.Text = value;
            }
        }
        #endregion

        #region "Controller"

        private ITLMCTL00035 bankCashScrollController;

        public ITLMCTL00035 BankCashScrollController
        {
            get
            {
                return this.bankCashScrollController;
            }
            set
            {
                this.bankCashScrollController = value;
                this.bankCashScrollController.BankCashScrollView = this;
            }
        }

        #endregion

        #region " Constructor "
        public TLMVEW00035()
        {
            InitializeComponent();
        }
        #endregion

        #region "Events"

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }


        private void TLMVEW00035_Load(object sender, EventArgs e)
        {
            this.InitializeControls();         
        }


        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {         
           this.bankCashScrollController.Print();
        }


        //private void chkAllBranches_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkAllBranches.Checked == true)
        //    {
        //        this.DisableControls("BankCashScroll.chkAllBranches.DisableControls");
        //    }

        //    else
        //    {
        //        this.EnableControls("BankCashScroll.chkAllBranches.EnableControls");
        //    }
        //}


        private void rdoHomeCur_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoHomeCur.Checked == true)
            {
                this.DisableControls("BankCashScroll.rdoHomeCur.DisableControls");
                this.IsHomeCurrency = true;            
                this.BindCurrencyComboBox();
            }

            else
            {
                this.EnableControls("BankCashScroll.rdoHomeCur.EnableControls");
                this.IsHomeCurrency = false;
            }
        }


        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.bankCashScrollController.ClearErrors();
        }

        #endregion

        #region " Methods"

        public void InitializeControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            if (CurrentUserEntity.IsHOUser)
            {
                this.cboBranchNo.Visible = true;
                this.chkBranch.Visible = true;
                this.BindBranchCode();//Edited by HOW
                this.BranchCode = CurrentUserEntity.BranchCode;
                this.lblBranchNo.Visible = false;
            }
            else
            {
                this.lblBranchNo.Visible = true;
                //this.lblBranchNo.Text = this.BankCashScrollController.GetViewData().SourceBranch + " (" + this.BankCashScrollController.GetViewData().BranchName + ")";
                this.lblBranchNo.Text = CurrentUserEntity.BranchCode ;/**/
                this.cboBranchNo.Visible = false;
                this.chkBranch.Visible = false;
            }
            this.BindCurrencyComboBox();
            this.rdoSourceCur.Checked = true;
            //this.chkAllBranches.Checked = false;
            this.dtpRequiredDate.Value = DateTime.Now;
        }

        // Edited by HOW (To remove other bank codes)
        private void BindBranchCode()
        {
            IList<BranchDTO> branches = CXCLE00001.Instance.SelectAllBranch();
            cboBranchNo.ValueMember = "BranchCode";
            cboBranchNo.DisplayMember = "BranchCode";
            cboBranchNo.DataSource = branches;
            cboBranchNo.SelectedIndex = 0;

        }

        //public void BindBranchNosComboBox()        {

        //    IList<BranchDTO> BranchNoList = CXCLE00002.Instance.GetListObject<BranchDTO>("Branch.Client.Select").Where(x => x.OtherBank == false).ToList();
        //    this.cboBranchNo.ValueMember="BranchCode";
        //    this.cboBranchNo.DisplayMember="BranchCode";
        //    this.cboBranchNo.DataSource = BranchNoList;
        //    this.cboBranchNo.SelectedIndex = -1;          
        //}
        // End of removing other bank codes)
        public void BindCurrencyComboBox()
        {
            IList<CurrencyDTO> CurrencyCodeList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            this.cboCurrency.ValueMember = "Cur";
            this.cboCurrency.DisplayMember = "Cur";
            this.cboCurrency.DataSource = CurrencyCodeList;
            this.cboCurrency.SelectedIndex = 0;
        }

        


        #endregion      

        private void chkBranch_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBranch.Checked) this.cboBranchNo.Enabled = false;
            else this.cboBranchNo.Enabled = true;
        }
    }
}
