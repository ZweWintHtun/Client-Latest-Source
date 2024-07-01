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
    public partial class LOMVEW00241 : BaseForm, ILOMVEW00239
    {
        public string acctNo;
        public string custName;
        public string reversalEno;
        public string sourceBr;
        public string currency;
        public string reversalStatus;
        public string checkPLValid;
        public string companyName;
        public string formatCode;
        public int valueCount;
        public string valueStr;

        public LOMVEW00241()
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

        public string PLNo
        {
            get { return this.txtPLNo.Text; }
            set { this.txtPLNo.Text = value; }
        }

        #region Events
        private void LOMVEW00241_Load(object sender, EventArgs e)
        {
            #region Old_Logic
            //this.txtPLNo.Focus();
            //tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            #endregion

            #region Seperating_EOD_Logic (By HMW at 29-07-2019)
            DateTime systemDate = this.controller.GetSystemDate(CurrentUserEntity.BranchCode);
            DateTime lastSettlementDate = this.controller.GetLastSettlementDate(CurrentUserEntity.BranchCode);
            this.lblTransactionDate.Text = systemDate.ToString("dd-MM-yyyy");

            if (systemDate.ToString("dd-MM-yyyy") != lastSettlementDate.ToString("dd-MM-yyyy")) //Show Form
            {
                this.txtPLNo.Focus();
                tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            }
            else //Don't show form after cut off
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI50013);//You have no permission.\n"Back Date EOD Process" needs to be completed!
                this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                
                this.DisableControls("PLRegisterReverse.AllDisable");
            }
            #endregion
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            // For generating entry no.
            formatCode = "PLRegReversalID";
            valueStr = DateTime.Now.ToString("dd,MM,yy");
            valueCount = 3;

            string results = this.controller.PL_Registration_Reversal(PLNo,CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode
                                                                      ,formatCode,valueCount,valueStr);
            string[] strResult = results.Split('#');
            string retCode = strResult[0];
            string retDesp = strResult[1];

            if (retCode == "-1")
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME30002);//Not Allowed Back Date Transaction!
                ClearControls();
                return;
            }
            if (retCode == "0")
            {
                //Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90225);//Personal Loan Registration Reversal Process is successfully finshed!
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90139, "Voucher No", retDesp);
                ClearControls();
                return;
            }
            else if (retDesp.Substring(0,2)!="PR")
            {
                MessageBox.Show(retDesp);
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

        private void txtPLNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtPLNo_Enter(object sender, EventArgs e)
        {
            GetPersonalLoans();
        }

        private void txtPLNo_Leave(object sender, EventArgs e)
        {
            GetPersonalLoans();
        }
        #endregion

        #region Helper method
        public void GetPersonalLoans()
        {
            if (txtPLNo.Text != string.Empty || txtPLNo.Text != "")
            {
                string str = this.controller.Get_PLInfo_ByPLNo(PLNo);
                string[] strResult = str.Split('#');
                acctNo = strResult[0];
                custName = strResult[1];
                companyName = strResult[2];
                sourceBr = strResult[3];
                currency = strResult[4];
                reversalStatus = strResult[5];
                checkPLValid = strResult[6];

                if (checkPLValid == "-1")
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90187);
                    ClearControls();
                    return;
                }
                else
                {
                    if (reversalStatus == "0")
                    {
                        this.mtxtAccountNo.Text = acctNo;
                        this.txtName.Text = custName;
                        this.txtCompanyName.Text = companyName;
                        this.txtSourceBr.Text = sourceBr;
                        this.txtCurrency.Text = currency;
                    }
                    else
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90226);//This Personal Loan Registration is already reversed!
                        ClearControls();
                        return;
                    }
                }
            }
        }
        public void ClearControls()
        {
            this.txtPLNo.Text = string.Empty;
            this.mtxtAccountNo.Text = string.Empty;
            this.txtName.Text = string.Empty;
            this.txtCompanyName.Text = string.Empty;
            this.txtSourceBr.Text = string.Empty;
            this.txtCurrency.Text = string.Empty;
            this.txtPLNo.Focus();
        }
        #endregion
    }
}
