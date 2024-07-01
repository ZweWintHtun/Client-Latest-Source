//----------------------------------------------------------------------
// <copyright file="MNMVEW00070.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Naing Naing Lin</CreatedUser>
// <CreatedDate>10/23/2013</CreatedDate>
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
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Admin.DataModel;


namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00070 : BaseForm, IMNMVEW00070
    {
        #region Constructor
        public MNMVEW00070()
        {
            InitializeComponent();
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

        public string Township
        {
            get
            {
                if (this.cboTownship.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboTownship.SelectedValue.ToString();
                }
            }
            set { this.cboTownship.SelectedValue = value; }
        }

        private string parentFormName = string.Empty;
        public string ParentFormName
        {
            get { return this.parentFormName; }
            set { this.parentFormName = value; }
        }
        #endregion

        #region Controller
        private IMNMCTL00070 controller;
        public IMNMCTL00070 Controller
        {
            get { return controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        #endregion

        #region Method
        #region Initialize
        private void InitailizeControl()
        {
            this.dtpStartDate.Value = DateTime.Now;
            this.dtpEndDate.Value = DateTime.Now;
            this.BindCurrency();
            this.BindTownship();
            this.BindSourceBranch();

            this.SourceBranch = CurrentUserEntity.BranchCode;
            if (!CurrentUserEntity.IsHOUser)
            {
                this.cboBranch.Enabled = false;
            }
            else
            {
                cboBranch.Enabled = true;
            }
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

        private void BindTownship()
        {
            IList<TownshipDTO> TownshipCodeList = CXCLE00002.Instance.GetListObject<TownshipDTO>("TownshipCode.Client.Select", new object[] { true });

            cboTownship.ValueMember = "Description";
            cboTownship.DisplayMember = "Description";
            cboTownship.DataSource = TownshipCodeList;
            cboTownship.SelectedIndex = -1;
        }

        private void BindSourceBranch()
        {
            IList<BranchDTO> BranchList = CXCLE00002.Instance.GetListObject<BranchDTO>("Branch.Client.SelectNotOtherBank", new object[] { false });

            cboBranch.ValueMember = "BranchCode";
            cboBranch.DisplayMember = "BranchCode";
            cboBranch.DataSource = BranchList;
            cboBranch.SelectedIndex = 0;
        }
        #endregion

        #region ComboBox Township (Disable/Enable)
        private void cboTownship_Visible(bool isVisible)
        {
            this.cboTownship.Visible = isVisible;
            this.lblTownship.Visible = isVisible;
        }
        #endregion
        #endregion

        #region Events
        private void MNMVEW00070_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            if (this.FormName.Equals("CustomerIDListing.ByDate"))
            {
                this.Text = "Customer ID Listing (By Date)";
                this.parentFormName = "CustomerIDListing(ByDate)";
                this.cboTownship_Visible(false);
            }
            else
            {
                this.Text = "Customer ID Listing (By Township)";
                this.ParentFormName = "CustomerIDListing(ByTownship)";
                this.cboTownship_Visible(true);
            }
            this.InitailizeControl();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            this.controller.Print();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboControls_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void tsbCRUD_CancelButtonClick_1(object sender, EventArgs e)
        {
            this.InitailizeControl();
        }
        #endregion


    }
}
