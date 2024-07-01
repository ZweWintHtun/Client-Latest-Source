using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Sam.Ctr.PTR;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Sam.Vew
{
    public partial class SAMVEW00054 : BaseForm, ISAMVEW00054
    {
        public SAMVEW00054()
        {
            InitializeComponent();
        }

        public string StateCode
        {
            get
            {
                if (this.cboStateCode.Text == null)
                {
                    return null;
                }
                else
                {
                    return this.cboStateCode.Text.ToString();
                }
            }
            set
            {
                this.cboStateCode.Text = value;
                this.cboStateCode.SelectedValue = value;
            }
        }

        private ISAMCTL00054 controller;
        public ISAMCTL00054 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.View = this;
            }
        }

        private void SAMVEW00054_Load(object sender, EventArgs e)
        {
            tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            tsbCRUD.butPrint.TabIndex = 0;
            rdoAllBranch.Focus();
            BindcboStateCode();
        }        

        private void rdoByState_CheckedChanged(object sender, EventArgs e)
        {
            cboStateCode.Enabled = true;
        }

        private void rdoAllBranch_CheckedChanged(object sender, EventArgs e)
        {
            cboStateCode.Enabled = false;
            this.controller.ClearErrors();
        }

        private void BindcboStateCode()
        {
            IList<StateDTO> stateDTO = new List<StateDTO>();
            stateDTO = CXCLE00002.Instance.GetClientDataList<StateDTO>("StateCode.Client.Select", true);
            stateDTO.OrderBy(a => a.StateCode);          
           cboStateCode.ValueMember = "StateCode";
           cboStateCode.DisplayMember = "StateCode";
           cboStateCode.DataSource = stateDTO;
           cboStateCode.SelectedIndex = -1;
        }

        private void cxcliC0011_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cxcliC0011_CancelButtonClick(object sender, EventArgs e)
        {
            rdoAllBranch.Checked = true;
            cboStateCode.SelectedIndex = -1;
            chkRemitRate.Checked = false;
            cboStateCode.Enabled = false;
            rdoAllBranch.Focus();
            this.controller.ClearErrors();
        }

        private void cboStateCode_Validated(object sender, EventArgs e)
        {
            //Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV90029");
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (rdoAllBranch.Checked && chkRemitRate.Checked)
            {
                IList<TLMDTO00032> rmitrateList = this.controller.SelectRmitRate();
                if (rmitrateList.Count > 0)
                {
                    CXUIScreenTransit.Transit("frmSAMVEW00062", true, new object[] { rmitrateList });
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode("ME90033");   //No Data For Report.
                }

            }
            else if (rdoAllBranch.Checked)
            {
                IList<BranchDTO> branchList = this.controller.SelectBranch();
                if(branchList.Count>0)
                CXUIScreenTransit.Transit("frmSAMVEW00061", true, new object[] { branchList });
                else
                    CXUIMessageUtilities.ShowMessageByCode("ME90033");  //No Data For Report.
            }

            else if (rdoByState.Checked && chkRemitRate.Checked)
            {
                if (string.IsNullOrEmpty(cboStateCode.Text.ToString()))
                {
                    MessageBox.Show("Please Choose Required State/Division");
                    return;
                }

                IList<TLMDTO00032> rmitrateList = this.controller.SelectRmitRate();
                if (rmitrateList.Count > 0)
                {
                    var rmitrates = (from value in rmitrateList
                                     where value.StateCode.Equals(cboStateCode.SelectedValue.ToString())
                                     select value).ToList();
                    if(rmitrates.Count>0)
                    CXUIScreenTransit.Transit("frmSAMVEW00062", true, new object[] { rmitrates });
                    else
                        CXUIMessageUtilities.ShowMessageByCode("ME90033");   //No Data For Report.
                }
                else
                    CXUIMessageUtilities.ShowMessageByCode("ME90033");    //No Data For Report.
            }
            else if (rdoByState.Checked)
            {
                if (string.IsNullOrEmpty(cboStateCode.Text.ToString()))
                {
                    MessageBox.Show("Please Choose Required State/Division");
                    return;
                }

                IList<BranchDTO> branchList = this.controller.SelectBranch();
                if (branchList.Count > 0)
                {                    
                    var branches = (from value in branchList
                                    where value.StateCode.Equals(cboStateCode.SelectedValue.ToString())
                                    select value).ToList();

                    if (branches.Count > 0)
                        CXUIScreenTransit.Transit("frmSAMVEW00061", true, new object[] { branches });
                    else
                        CXUIMessageUtilities.ShowMessageByCode("ME90033");    //No Data For Report.
                }
                else
                    CXUIMessageUtilities.ShowMessageByCode("ME90033");    //No Data For Report.
              
            }


           
        }
    }
}
