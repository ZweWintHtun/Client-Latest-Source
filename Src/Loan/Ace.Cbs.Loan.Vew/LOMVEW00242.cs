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
    public partial class LOMVEW00242 : BaseForm, ILOMVEW00239
    {
        public string acctNo;
        public string custName;
        public string sourceBr;
        public string currency;
        public string reversalStatus;
        public string checkBLValid;
        public string loansType;
        public string loansBType;
        public string formatCode;        

        public LOMVEW00242()
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

        public string BLNo
        {
            get { return this.txtBLNo.Text; }
            set { this.txtBLNo.Text = value; }
        }

        public void ClearControls()
        {
            this.txtBLNo.Text = string.Empty;
            this.mtxtAccountNo.Text = string.Empty;
            this.txtName.Text = string.Empty;
            this.txtLoanBType.Text = string.Empty;
            this.txtLoanType.Text = string.Empty;
            this.txtSourceBr.Text = string.Empty;
            this.txtCurrency.Text = string.Empty;            
        }
        private void LOMVEW00242_Load(object sender, EventArgs e)
        {
            #region Old_Logic
            //tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            #endregion

            #region Seperating_EOD_Logic (Added By YMP at 30-07-2019, Modified by HMW at 26-08-2019)
            DateTime systemDate = this.controller.GetSystemDate(CurrentUserEntity.BranchCode);
            DateTime lastSettlementDate = this.controller.GetLastSettlementDate(CurrentUserEntity.BranchCode);
            this.lblTransactionDate.Text = systemDate.ToString("dd-MM-yyyy");

            if (systemDate.ToString("dd-MM-yyyy") != lastSettlementDate.ToString("dd-MM-yyyy")) //Show Form
            {
                tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
                this.txtBLNo.Focus();
            }
            else //Don't show form after cut off
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI50013);//You have no permission.\n"Back Date EOD Process" needs to be completed!
                this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                //this.InitializeControls();
                this.DisableControls("BLRegisterReverse.AllDisable");
            }
            #endregion
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            // For generating entry no.
            formatCode = "BLRegReversalVoucher";


            string results = this.controller.BL_Registration_Reversal(BLNo, formatCode, CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode);//Modify by HMW at 27-08-2019
            string[] strResult = results.Split('#');
            string retCode = strResult[0];
            string retDesp = strResult[1];

            if (retCode == "0")
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90133);
                ClearControls();
                return;
            }
            else if (retDesp.Substring(0, 2) != "BR")
            {
                MessageBox.Show(retDesp);
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
            this.txtBLNo.Focus();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBLNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtBLNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                string str = this.controller.Get_BLInfo_ByBLNo(BLNo);
                string[] strResult = str.Split('#');
                acctNo = strResult[0];
                custName = strResult[1];
                sourceBr = strResult[2];
                currency = strResult[3];
                reversalStatus = strResult[4];
                checkBLValid = strResult[5];
                loansType = strResult[6];
                loansBType = strResult[7];

                if (checkBLValid == "-1")
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90181);
                    ClearControls();
                    return;
                }
                else
                {
                    if (reversalStatus == "0")
                    {
                        this.mtxtAccountNo.Text = acctNo;
                        this.txtName.Text = custName;
                        this.txtLoanBType.Text = loansBType;
                        this.txtLoanType.Text = loansType;
                        this.txtSourceBr.Text = sourceBr;
                        this.txtCurrency.Text = currency;
                    }
                    else
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90209);
                        ClearControls();
                        return;
                    }
                }
            }

        }

    }
}

