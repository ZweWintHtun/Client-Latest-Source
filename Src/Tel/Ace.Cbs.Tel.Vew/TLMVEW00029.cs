//----------------------------------------------------------------------
// <copyright file="TLMVEW00029.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-06-10</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;


namespace Ace.Cbs.Tel.Vew
{  
    /// <summary>
    ///Enquiry Type
    ///Remittance Passing > Drawing Remittance 
    /// </summary>
    public partial class frmTLMVEW00029 : BaseDockingForm
    {
        #region "Constructor"

        public frmTLMVEW00029()
        {
            InitializeComponent();
        }
        #endregion

        #region "Events"

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
    
        private void butPassing_Click(object sender, EventArgs e)
        {
            if (rdoByBranchCode.Checked)
            {
                CXUIScreenTransit.Transit("frmDrawingRemittance", "IBL Drawing Remittance Passing (By Branch)");               
            }

            else if (rdoByDateTime.Checked)
            {
                CXUIScreenTransit.Transit("frmDrawingRemittance", "IBL Drawing Remittance Passing (By Date)");
            }
            else

            {
                CXUIScreenTransit.Transit("frmDrawingRemittance", "IBL Drawing Remittance Passing (By Register No)");
               
            }
            
        }

        private void frmTLMVEW00029_Load(object sender, EventArgs e)
        {
            this.Enable_DisableControls();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.rdoByBranchCode.Checked = true;
        }

        #endregion

        #region "Methods"
        private void Enable_DisableControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, false, true);
        }
        #endregion       
       
    }
}
