//----------------------------------------------------------------------
// <copyright file="PFMVEW00005.cs" company="Ace Data Systems">
// Copyright (c) Ace Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;

namespace Ace.Cbs.Pfm.Vew
{
    /// <summary>
    /// CustomerId Search Form
    /// </summary>
    public partial class frmPFMVEW00005 : BaseForm, IPFMVEW00005
    {
        private bool isValidateLessThan18 = false;
        private bool isValidateGreaterThan18 = false;
        PFMDTO00001 customerid;


        #region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>

        public frmPFMVEW00005()
        {
            InitializeComponent();
        }

        public frmPFMVEW00005(bool isValidateLessThan18, bool isValidateGreaterThan18)
        {
            InitializeComponent();
            this.isValidateLessThan18 = isValidateLessThan18;
            this.isValidateGreaterThan18 = isValidateGreaterThan18;
        }

        public frmPFMVEW00005(int menuIdForPermission, string screenName)
        {
            InitializeComponent();
            this.parameter = screenName;
            CurrentUserEntity.CurrentMenuId = menuIdForPermission;
        }

        public frmPFMVEW00005(string screenName, PFMDTO00001 customerDTO, bool setFocus)
        {

        }

        #endregion

        #region View Data Properties

        public string parameter;

        /// <summary>
        /// Parent Menu
        /// </summary>
        private string parentMenuFormId = string.Empty;
        public string ParentMenuFormId
        {
            get { return this.parentMenuFormId; }
            set { this.parentMenuFormId = value; }
        }

        #endregion

        #region Entity
        /// <summary>
        /// View Data 
        /// </summary>
        private PFMDTO00001 viewData;
        public PFMDTO00001 ViewData
        {
            get
            {
                this.viewData = new PFMDTO00001();
                viewData.Name = txtName.Text;
                viewData.NRC = txtNRC.Text;
                viewData.FatherName = txtFatherName.Text;
                viewData.isCheckName = chkExactly1.Checked;
                viewData.isCheckNRC = chkExactly2.Checked;
                viewData.isCheckFatherName = chkExactly3.Checked;
                return viewData;
            }
            set
            {
                this.viewData = value;
            }
        }
        #endregion

        #region Presenter
        /// <summary>
        /// customerIdSearchController
        /// </summary>
        private IPFMCTL00005 customerIdSearchController;
        public IPFMCTL00005 CustomerIdSearchController
        {
            set
            {
                this.customerIdSearchController = value;
                this.customerIdSearchController.CustomerIdSearchView = this;
            }
            get
            {
                return this.customerIdSearchController;
            }
        }
        #endregion

        #region Public Method

        //Bind CustomerId Gridview
        public void gvCustomerId_Databind(IList<PFMDTO00001> CustomerIds)
        {
            gvCustomer.AutoGenerateColumns = false;
            gvCustomer.DataSource = null;
            if (CustomerIds.Count > 0)
            {
                this.gvCustomer.DataSource = CustomerIds;
                this.gvCustomer.Focus();
            }
        }

       // public void ShowMessage(string message, int totalRecordCounts, int maxSearchCounts)
        public void ShowMessage(string message, int totalRecordCounts)
        {
            if (totalRecordCounts == 0)
            {
                gvCustomer.DataSource = null;
                CXUIMessageUtilities.ShowMessageByCode(message);
            }
            else
            {
              //  CXUIMessageUtilities.ShowMessageByCode(message, new object[] { totalRecordCounts, maxSearchCounts });
                CXUIMessageUtilities.ShowMessageByCode(message, new object[] { totalRecordCounts});

            }
        }

        #endregion

        #region Private Method

        //Enable/Disable COntrols
        private void EnableDisableControls()
        {
            tlspCommon.ButtonEnableDisabled(true, false, false, false, true, false, true);

        }

        #endregion

        #region Event
        // Bind CustomerId Data After Search Click
        private void butSearch_Click(object sender, EventArgs e)
        {
            this.customerIdSearchController.SearchCustomerId(ViewData);
        }

        // When CustomerId Search Form Load
        private void PFMVEW00005_Load(object sender, EventArgs e)
        {
            this.EnableDisableControls();
            this.txtName.Focus();

        }

        //Screen Transit to CustomerId Entry When New Buton Click
        private void tlspCommon_NewButtonClick(object sender, EventArgs e)
        {
            //   this.Hide();  If comment is removed , parent form and child form will appear separately ... 
            //  u can change according to your business logic

            if (CXUIScreenTransit.Transit("frmPFMVEW00004", true, new object[] { false, this.Name, this.isValidateLessThan18, this.isValidateGreaterThan18 }) == DialogResult.OK)
            {
                CXUIScreenTransit.SetData("PFMVEW00005", CXUIScreenTransit.GetData<PFMDTO00001>("frmPFMVEW00005Transit"));
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        //Initialize Controls when Cancel button click
        private void tlspCommon_CancelButtonClick(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            txtNRC.Text = string.Empty;
            txtFatherName.Text = string.Empty;
            chkExactly1.Checked = false;
            chkExactly2.Checked = false;
            chkExactly3.Checked = false;
            this.gvCustomer.DataSource = null;
        }

        //When Exit Button Clicked
        private void tlspCommon_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        //Transit CustomerId Entity to other form


        #endregion

        #region Common Module Possible

        /// <summary>
        ///Enter/Tab for Controls
        /// </summary>
        #region Enter/Tab

        /// <summary>
        ///Enter/Tab for Name Textbox
        /// </summary>
        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtNRC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtFatherName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void chkExactly1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void chkExactly2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void chkExactly3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{Tab}");
            }
        }
        #endregion


        /// <summary>
        /// Capital letter for Textboxes
        /// </summary>
        #region Capital letter

        /// <summary>
        /// Capital letter for Name Textbox 
        /// </summary>
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Capital letter for NRC Textbox 
        /// </summary>
        private void txtNRC_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        /// <summary>
        /// Capital letter for Father Name Textbox 
        /// </summary>
        private void txtFatherName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        #endregion

        private void gvCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            while (e.KeyCode == Keys.Enter)
            {
                DataGridViewCell curCell = this.gvCustomer.CurrentCell;
                customerid = this.gvCustomer.Rows[curCell.RowIndex].DataBoundItem as PFMDTO00001;

                if (this.isValidateGreaterThan18 && customerid.DateOfBirth > DateTime.Now.AddYears(-18))
                {
                    // Date of Birth should be greater than 18.
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00079);
                    return;
                }

                if (this.isValidateLessThan18 && customerid.DateOfBirth < DateTime.Now.AddYears(-18))
                {
                    // Date of Birth should not be greater than 18.
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00024);
                    return;
                }

                CXUIScreenTransit.SetData("PFMVEW00005", customerid);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
                break;
            }

        }

        private void gvCustomer_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            customerid = this.gvCustomer.Rows[e.RowIndex].DataBoundItem as PFMDTO00001;

            if (this.isValidateGreaterThan18 && customerid.DateOfBirth > DateTime.Now.AddYears(-18))
            {
                // Date of Birth should be greater than 18.
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00079);
                return;
            }

            if (this.isValidateLessThan18 && customerid.DateOfBirth < DateTime.Now.AddYears(-18))
            {
                // Date of Birth should not be greater than 18.
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00024);
                return;
            }

            CXUIScreenTransit.SetData("PFMVEW00005", customerid);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }     

    }
        #endregion
       
}


