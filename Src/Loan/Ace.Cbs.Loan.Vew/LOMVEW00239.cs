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
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00239 : BaseForm, ILOMVEW00239
    {
        public string acctNo;
        public string custName;
        public string dealerName;
        public string reversalEno;
        public string sourceBr;
        public string currency;
        public string reversalStatus;
        public string checkHPValid;

        public LOMVEW00239()
        {
            InitializeComponent();
        }

        private ILOMCTL00237 controller;
        public ILOMCTL00237 Controller
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

        public string HPNo
        {
            get { return this.txtHPNo.Text; }
            set { this.txtHPNo.Text = value; }
        }

        public void ClearControls()
        {
            this.txtHPNo.Text = string.Empty;
            this.mtxtAccountNo.Text = string.Empty;
            this.txtName.Text = string.Empty;
            this.txtDealerName.Text = string.Empty;
            this.txtSourceBr.Text = string.Empty;
            this.txtCurrency.Text = string.Empty;
        }
        private void LOMVEW00239_Load(object sender, EventArgs e)
        {
            #region Old_Logic
            //tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            #endregion

            DateTime systemDate = this.Controller.GetSystemDate(CurrentUserEntity.BranchCode);
            DateTime lastSettlementDate = this.controller.GetLastSettlementDate(CurrentUserEntity.BranchCode);
            this.lblTransactionDate.Text = systemDate.ToString("dd-MM-yyyy");

            if (systemDate.ToString("dd-MM-yyyy") != lastSettlementDate.ToString("dd-MM-yyyy")) //Show Form
            {
                tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            }
            else //Don't show form after cut off
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI50013);//You have no permission.\n"Back Date EOD Process" needs to be completed!
                this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                //this.InitializeControls();
                this.DisableControls("HPRegisterReverse.AllDisable");
            }
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            string results = this.controller.HP_Registration_Reversal(HPNo, reversalEno, CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode);
            if (results == "0")
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90130);
                ClearControls();
                return; 
            }
            else
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME30002);
                return; 
            }
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            ClearControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtHPNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtHPNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                string str = this.controller.Get_HPInfo_ByHPNo(HPNo);
                string[] strResult = str.Split('#');
                acctNo = strResult[0];
                custName = strResult[1];
                dealerName = strResult[2];
                sourceBr = strResult[3];
                currency = strResult[4];
                reversalStatus = strResult[5];
                checkHPValid = strResult[6];

                if (checkHPValid == "-1")
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90156);
                    ClearControls();
                    return;
                }
                else
                {
                    if (reversalStatus == "0")
                    {
                        this.mtxtAccountNo.Text = acctNo;
                        this.txtName.Text = custName;
                        this.txtDealerName.Text = dealerName;
                        this.txtSourceBr.Text = sourceBr;
                        this.txtCurrency.Text = currency;
                    }
                    else
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90203);
                        ClearControls();
                        return;
                    }
                }
            }

        }
    }
}
