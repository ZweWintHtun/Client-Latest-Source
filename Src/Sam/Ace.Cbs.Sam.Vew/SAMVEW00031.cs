//----------------------------------------------------------------------
// <copyright file="SAMVEW00031.cs" company="Ace Data Systems">
// Copyright (c) Ace Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo</CreatedUser>
// <CreatedDate>2015-02-04</CreatedDate>
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
using Ace.Cbs.Sam.Ctr.PTR;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Sam.Dmd;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Sam.Vew
{
    /// <summary>
    /// Interest Rate Listing
    /// </summary>
    public partial class SAMVEW00031 : BaseForm ,ISAMVEW00031
    {

        #region "Constructor"
        public SAMVEW00031()
        {
            InitializeComponent();
        }
        #endregion
        
        #region "Variable"
        string screenName = string.Empty;
        #endregion

        #region "Properties"
        public string RateType
        {
            get
            {
                if (this.rdoAll.Checked == true)
                {
                    return "AllRate";
                }
                else
                {
                    return "SelectedRate";
                }
            }
            set
            {
                if (value == "AllRate")
                {
                    this.rdoAll.Checked = true;
                }
                else
                {
                    this.rdoSelectedRate.Checked = true;
                }
            }
        }
        public string Status
        {
            get
            {
                if (this.chkAllStatus.Checked)
                {
                    return "AllStatus";
                }
                else if (this.rdoActive.Checked)
                {
                    return "ActiveStatus";
                }
                else
                {
                    return "NotActiveStatus";
                }
            }
            set
            {
                if (value == "AllStatus")
                {
                    this.chkAllStatus.Checked = true;
                }
                else if (value == "ActiveStatus")
                {
                    this.rdoActive.Checked = true;
                }
                else
                {
                    this.rdoHistory.Checked = true;
                }
            }
        }
        public string SelectedRate
        {
            get
            {
                if (this.cboSelectedRate.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboSelectedRate.SelectedValue.ToString();
                }
            }
            set { this.cboSelectedRate.SelectedValue = value; }
        }
        #endregion

        #region "Controller"
        private ISAMCTL00031 controller;
        public ISAMCTL00031 Controller
        {
            get { return this.controller; }
            set { this.controller = value; this.controller.InterestRateListingView = this; }
        }

        private IList<SAMDTO00056> ratefileList;
        public IList<SAMDTO00056> RateFileList
        {
            get { return this.ratefileList; }
            set { this.ratefileList = value; }
        }
        #endregion

        #region "Public Method"
        public void InitializeControls()
        {
            this.Text = "Interest Rate Listing";
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.BindRateFileList();
            this.cboSelectedRate.Enabled = false;
            this.gbStatus.Enabled = true;
            this.rdoAll.Checked = true;
            this.rdoActive.Checked = true;
        }
        #endregion

        #region "Private Methods"
        private void BindRateFileList()
        {
            const string status = "ACTIVE";
            RateFileList = this.Controller.SelectRateFileList(status);
            this.cboSelectedRate.ValueMember = "CODE";
            this.cboSelectedRate.DisplayMember = "DESP";
            this.cboSelectedRate.DataSource = RateFileList;
        }
        private void EnableDisableStatus(bool isEnable)
        {
            this.rdoActive.Enabled = isEnable;
            this.rdoHistory.Enabled = isEnable;
        }
        private void TransitScreenName(string screenName, IList<SAMDTO00056> rateFileList)
        {
            CXUIScreenTransit.Transit("frmSAMVEW00063", true, new object[] { screenName, rateFileList });
        }
        #endregion

        #region "Event"
        private void SAMVEW00031_Load(object sender, EventArgs e)
        {
            this.InitializeControls();            
        }

        private void rdoSelectedRate_CheckedChanged(object sender, EventArgs e)
        {
            if(this.rdoSelectedRate.Checked)
                {
                    this.cboSelectedRate.Enabled = true;
                }
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {            
            if (this.rdoSelectedRate.Checked && (this.cboSelectedRate.Text == string.Empty))
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00035");//Invalid Interest Rate.
            }
            else
            {
              IList<SAMDTO00056> RateFileList= this.Controller.SelectRateFileList();
              if (this.rdoAll.Checked)
              {
                  if (this.chkAllStatus.Checked)
                  {
                      screenName = "By All Rates and All Status";
                      this.TransitScreenName(screenName, RateFileList);
                  }
                  else if (this.rdoActive.Checked)
                  {
                      screenName = "By All Rates and Active Status";
                      this.TransitScreenName(screenName, RateFileList);
                  }
                  else
                  {
                      screenName = "By All Rates and Not Active Status";
                      this.TransitScreenName(screenName, RateFileList);
                  }
              }
              else
              {
                  if (this.chkAllStatus.Checked)
                  {
                      screenName = "For "+this.cboSelectedRate.Text+" and All Status";
                      this.TransitScreenName(screenName, RateFileList);
                  }
                  else if (this.rdoActive.Checked)
                  {
                      screenName = "For " + this.cboSelectedRate.Text + " and Active Status";
                      this.TransitScreenName(screenName, RateFileList);
                  }
                  else
                  {
                      screenName = "For " + this.cboSelectedRate.Text + " and Not Active Status";
                      this.TransitScreenName(screenName, RateFileList);
                  }
              }               
            }
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void chkAllStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllStatus.Checked)
            {
               this.gbStatus.Enabled = false;
               this.rdoActive.Enabled = false;
               this.rdoHistory.Enabled = false;
            }
        }

        private void rdoAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAll.Checked)
            {
                this.cboSelectedRate.Enabled = false;
            }
        }

        private void chkAllStatus_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkAllStatus.Checked)
            {
                this.EnableDisableStatus(false);
            }
            else
            {
                this.EnableDisableStatus(true);
                this.rdoActive.Checked = true;
            }
        }
        #endregion
       
    }
}
