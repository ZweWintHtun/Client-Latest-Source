//----------------------------------------------------------------------
// <copyright file="TLMVEW00032.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-07-17</CreatedDate>
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


namespace Ace.Cbs.Tel.Vew
{
    /// <summary>
    /// Report->IBL Remittance Listing->IBL Test Key Listing / By Date
    /// </summary>
    public partial class TLMVEW00032 : BaseForm, ITLMVEW00050
    {
        #region "Properties"
        public IList<TLMDTO00037> list { get; set; }
        public DateTime Date
        {
            get { return this.dtpRequiredDate.Value; }
            set { this.dtpRequiredDate.Text = value.ToString(); }
        }
        #endregion

        #region "Constructor"
        public TLMVEW00032()
        {
            InitializeComponent();
        }
        #endregion

        #region "Controller"
        private ITLMCTL00050 iblTestKeyListingController;

        public ITLMCTL00050 IBLTestKeyListingController
        {
            get
            {
                return this.iblTestKeyListingController;
            }
            set
            {
                this.iblTestKeyListingController = value;
                this.iblTestKeyListingController.IBLTestKeyListingView = this;
            }
        }
        #endregion

        #region "Events"
        private void TLMVEW00032_Load(object sender, EventArgs e)
        {
            this.EnableDisableControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            bool date = CXCOM00006.Instance.IsExceedTodayDate(this.Date);
            if (date == true)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00131");
            }
            else
            {
                list = this.IBLTestKeyListingController.GetPrintData(this.Date);
                if (list.Count > 0)
                {
                    CXUIScreenTransit.Transit("frmTLMVEW00050ByDate", true, new object[] { list, Date, "IBL Test Key Listing By Date Report" });
                }
            }
        }

        #endregion

        #region "Method"
        public void EnableDisableControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, true, true);

        }
        public void CloseForm()
        {
            // throw new NotImplementedException();
        }
        #endregion
    }
}
