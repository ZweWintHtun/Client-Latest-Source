//----------------------------------------------------------------------
// <copyright file="TLMVEW00022.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-06-18</CreatedDate>
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
    /// Enquiry Type
    /// Listing -> Deno Outstanding Report
    /// </summary>
    public partial class frmTLMVEW00022 : BaseForm
    {
        #region "Constructor"
        public frmTLMVEW00022()
        {
            InitializeComponent();
        }
        #endregion       

        #region "Private variables"
       
           private string PoNormalRpt = "Listing For Payment Order Outstanding Normal Report";
           private string DeNoRpt = "Deno Outstanding Report";
           private string DeNoMultiTranOutRpt = "Deno Muliple Transaction Outstanding Report";
        
        #endregion

        #region " Events"
        private void TLMVEW00022_Load(object sender, EventArgs e)
        {
            this.EnableDisableControls();
        }
        
        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (rdoPOOutstandingNormalReport.Checked)
            {
                CXUIScreenTransit.Transit("frmTLMVEW00045", PoNormalRpt);           
            }

            else if (rdoDenoOutStandingReport.Checked)
            {
                CXUIScreenTransit.Transit("frmTLMVEW00043",DeNoRpt);        
            }

            else 
            {
                CXUIScreenTransit.Transit("frmTLMVEW00044", DeNoMultiTranOutRpt);
          
            }          
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.rdoDenoOutStandingReport.Checked = true;
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Methods"
        private void EnableDisableControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true); ;
        }
        #endregion
    }
}
