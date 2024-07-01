using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Ace.Windows.CXClient;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00024 : BaseDockingForm, ILOMVEW00024
    {
        public LOMVEW00024()
        {
            InitializeComponent();
        }

        #region Properties
        public string loan_type { get; set; }
        private bool isSave { get; set; }
        public PFMDTO00072 loanDto { get; set; }
        public IList<PFMDTO00072> List { get; set; }
        public IList<PFMDTO00072> acctInfoList { get; set; }
        private ILOMCTL00024 controller;
        public ILOMCTL00024 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.LoanVoucherView = this;
            }
        }

        private string loanNo;
        public string LoanNo
        {
            get { return this.txtLoanNo.Text; }
            set { this.txtLoanNo.Text = value; }
        }

        public string Currency
        {
            get { return this.txtCurrency.Text; }
            set { this.txtCurrency.Text = value; }            
        }

        public string EntryNo
        {
            get { return this.txtEntryNo.Text; }
            set { this.txtEntryNo.Text = value; }
        }

        public decimal SanctionAmount
        {
            set
            {
                this.txtSanctionAmount.Text = Convert.ToDouble(value).ToString("N2");
            }
            get
            {
                decimal result = 0;
                Decimal.TryParse(this.txtSanctionAmount.Text, out result);
                return result;
            }
        }

        public decimal PartialAmount
        {
            set
            {
                this.txtPartialAmount.Text = Convert.ToString(value);
            }
            get
            {
                decimal result = 0;
                Decimal.TryParse(this.txtPartialAmount.Text, out result);
                return result;
            }
        }
        public bool isSCharge {get;set;}
        #endregion

        private void LOMVEW00024_Load(object sender, EventArgs e)
        {
            #region Old_Logic
            /*
            this.txtLoanNo.Focus();
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true); //save,cancel and exit are true;
            this.lblVoucherDate2.Text = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
            this.txtEntryNo.Enabled = false;
            this.txtPartialAmount.Enabled = false;
            this.txtCurrency.Enabled = false;
            this.txtSanctionAmount.Enabled = false;
            */
            #endregion

            #region Seperating_EOD_Logic (Added By YMP at 30-07-2019, Modified by HMW at 26-08-2019)
            DateTime systemDate = this.Controller.GetSystemDate(CurrentUserEntity.BranchCode);
            DateTime lastSettlementDate = this.controller.GetLastSettlementDate(CurrentUserEntity.BranchCode);

            //this.lblTransactionDate.Text = systemDate.ToString("dd-MM-yyyy");
            this.lblVoucherDate2.Text = systemDate.ToString("dd-MMM-yyyy");

            if (systemDate.ToString("dd-MM-yyyy") != lastSettlementDate.ToString("dd-MM-yyyy")) //Show Form
            {
                this.txtLoanNo.Focus();
                this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true); //save,cancel and exit are true;                
                this.txtEntryNo.Enabled = false;
                this.txtPartialAmount.Enabled = false;
                this.txtCurrency.Enabled = false;
                this.txtSanctionAmount.Enabled = false;
            }
            else //Don't show form after cut off
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI50013);//You have no permission.\n"Back Date EOD Process" needs to be completed!
                this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                this.DisableControls("BLVoucher.AllDisable");
            }
            #endregion
        }

        public void BindAccountInfo(IList<PFMDTO00072> LoanDTO)
        {
            decimal SamtAmount = 0;
            if (LoanDTO.Count == 0)
                return;
            //ChargeOfAccountSetupDTO coaDTo = CXCLE00002.Instance.GetScalarObject<ChargeOfAccountSetupDTO>("COASetup.Client.SelectAccountNameAndAcode", new object[] { "LOANS", LoanDTO[0].CurrencyCode, CurrentUserEntity.BranchCode, true });
            ChargeOfAccountSetupDTO coaDTo = new ChargeOfAccountSetupDTO();
            //string loanType = LoanDTO[0].AccountSignature.ToString() + "LOANS";

            /*
            //Logic Change and comment by HMW at 25-03-2020 (to fix wrong account binding for Project Loan)
            string loanType ="LOANS";
            coaDTo.AccountNo = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { loanType, this.Currency, CurrentUserEntity.BranchCode, true });            
            string Acode = coaDTo.AccountNo;
            */

            string Acode = LoanDTO[0].LoanCOAAccountNo;
            coaDTo.AccountName = CXCLE00002.Instance.GetScalarObject<string>("COA.Client.SelectACName", new object[] { Acode, CurrentUserEntity.BranchCode, true });

            //coaDTo.AccountName = "Loans To Construction";
            this.List = LoanDTO;

            loan_type = LoanDTO[0].AccountSignature;
            acctInfoList = new List<PFMDTO00072>();

            loanDto = LoanDTO[0];

            string acode = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.BLControl), this.Currency, CurrentUserEntity.BranchCode, true });

            PFMDTO00072 arr0 = new PFMDTO00072();
            arr0.BankAccountNo = acode; //curcontrol acctno
            arr0.CreditAccountNo1 = Acode; //coaDTo.AccountNo;
            arr0.BankAccountDescription = coaDTo.AccountName;

            PFMDTO00072 arr1 = new PFMDTO00072();
            arr1.CreditAccountNo1 = loanDto.AccountNo;
            //arr1.BankAccountDescription = loanDto.CustomerName;
            int i = LoanDTO.Count;
            int j = 1;
            arr1.BankAccountDescription = "";
            if (loanDto.AccountNo.Substring(5, 1) != "3") /// not company account
            {
                arr1.BankAccountDescription = "";
                foreach (PFMDTO00072 item in LoanDTO)
                {
                    if (i == j) // Last Data ??
                    {
                        arr1.BankAccountDescription += item.CustomerName;
                    }
                    else // not last data ( to put , ) 
                    {
                        arr1.BankAccountDescription += item.CustomerName + ",";
                    }
                    j = j + 1;
                }
            }
            else
            {
                arr1.BankAccountDescription = LoanDTO[0].companyName;
            }
            PFMDTO00072 arr2 = new PFMDTO00072();
            arr2.BankAccountNo = acode; //bLcontrol acctno//LAK001
            arr2.CreditAccountNo1 = loanDto.AccountNo; // 15digits account

            //arr2.BankAccountDescription = loanDto.CustomerName;//customer name
            arr2.BankAccountDescription = arr1.BankAccountDescription; /// Updated by ZMS (12-July-2018)

            string AccountNo = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { "DOCINCOME", this.Currency, CurrentUserEntity.BranchCode, true });
            string AccountName = CXCLE00002.Instance.GetScalarObject<string>("COA.Client.SelectACName", new object[] { AccountNo, CurrentUserEntity.BranchCode, true }); PFMDTO00072 arr3 = new PFMDTO00072();
            arr3.CreditAccountNo1 = AccountNo;//Documentation Sundary Account
            arr3.BankAccountDescription = AccountName;

            if (this.rdoFull.Checked)
            {
                arr0.CreditAmount1 = loanDto.CreditAmount1;
                arr1.CreditAmount1 = loanDto.CreditAmount1;
                arr2.CreditAmount1 = loanDto.DebitAmount2;
                arr3.CreditAmount1 = loanDto.DebitAmount2;
            }
            else
            {
                arr0.CreditAmount1 = this.PartialAmount;
                arr1.CreditAmount1 = this.PartialAmount;
                arr2.CreditAmount1 = loanDto.DebitAmount2;
                arr3.CreditAmount1 = loanDto.DebitAmount2;
            }
            arr0.CreditDescription2 = "DEBIT";
            arr1.CreditDescription2 = "CREDIT";
            arr2.CreditDescription2 = "DEBIT";
            arr3.CreditDescription2 = "CREDIT";

            acctInfoList.Add(arr0);
            acctInfoList.Add(arr1);
            acctInfoList.Add(arr2);
            acctInfoList.Add(arr3);
            isSCharge = loanDto.isScharge;
            if (loanDto.isScharge == true)           
            {                
                PFMDTO00009 ratedto = new PFMDTO00009();
                // if (loanDto.BType =="001")
                //  {
                //    AccountNo = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { "BL_SME_SCHARGENEW", this.Currency, CurrentUserEntity.BranchCode, true });
                //}
                //if (loanDto.BType == "002")
                //{
                //  AccountNo = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { "BL_PLBUSINESS_SCHARGENEW", this.Currency, CurrentUserEntity.BranchCode, true });

                //}
                AccountNo = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { "SCHARGENEW", this.Currency, CurrentUserEntity.BranchCode, true });

                AccountName = CXCLE00002.Instance.GetScalarObject<string>("COA.Client.SelectACName", new object[] { AccountNo, CurrentUserEntity.BranchCode, true });
                ratedto = CXCLE00002.Instance.GetScalarObject<PFMDTO00009>("PFMORM00009.Client.SelectByCodeAndLastModify", new object[] { "LOANSCHARGERATE", true, true }); //hm

                decimal srate = (Convert.ToDecimal(loanDto.CreditAmount1) * Convert.ToDecimal(ratedto.Rate)) / 100;

                PFMDTO00072 arr4 = new PFMDTO00072();
                arr4.BankAccountNo = acode; //bLcontrol acctno//LAK001
                arr4.CreditAccountNo1 = loanDto.AccountNo; // 15digits account

                //arr4.BankAccountDescription = loanDto.CustomerName;//customer name
                arr4.BankAccountDescription = arr1.BankAccountDescription; /// Updated by ZMS (12-July-2018)
                                                                          
                arr4.CreditAmount1 = srate;

                PFMDTO00072 arr5 = new PFMDTO00072();
                arr5.BankAccountNo = AccountNo; //service charge//IF0010
                arr5.CreditAccountNo1 = AccountNo; // service charge acode
                arr5.BankAccountDescription = AccountName;//Service Charges On Loans & OD 
                arr5.CreditAmount1 = srate;

                arr4.CreditDescription2 = "DEBIT";
                arr5.CreditDescription2 = "CREDIT";

                acctInfoList.Add(arr4);
                acctInfoList.Add(arr5);
            }
            this.gdvAccountInfo.AutoGenerateColumns = false;
            this.gdvAccountInfo.DataSource = null;
            this.gdvAccountInfo.CausesValidation = false;
            this.gdvAccountInfo.DataSource = acctInfoList;
            this.gdvAccountInfo.ReadOnly = true;
        }

        private void rdoPartial_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoFull.Checked)
            {
                this.tsbCRUD.Focus();
                this.txtPartialAmount.Enabled = false;
                if(!isSave)
                this.BindAccountInfo(List);
            }
            else
            {
                this.txtPartialAmount.Focus();
                this.txtPartialAmount.Enabled = true;
            }
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.ClearControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPartialAmount_Leave(object sender, EventArgs e)
        {
            if (this.PartialAmount != 0 && this.PartialAmount > this.SanctionAmount)
            {
                CXUIMessageUtilities.ShowMessageByCode("MV90083");  //Partial amount should not be greater than Sanction amount.
                this.txtPartialAmount.Focus();
                return;
            }
            this.BindAccountInfo(List);
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            string BranchCode = CurrentUserEntity.BranchCode;
            this.controller.Save(this.GetViewData(), acctInfoList, BranchCode);
        }


        private TLMDTO00018 GetViewData()
        {
            TLMDTO00018 entity = new TLMDTO00018();
            entity.Lno = this.LoanNo;
            entity.Currency = this.Currency;
            entity.SAmount = this.SanctionAmount;
            entity.VoucherDate = DateTime.Now;
            entity.Vouchered = true;
           
            if (this.rdoPartial.Checked)
            {
                entity.Partial = true;
                entity.SAmount = this.PartialAmount;  
            }
            else
                entity.Partial = false;
            entity.DocFee = loanDto.DebitAmount2;
            entity.SourceBranchCode = CurrentUserEntity.BranchCode;
            entity.CreatedDate = DateTime.Now;
            entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
            entity.UpdatedDate = DateTime.Now;
            entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
            return entity;
        }

        public void Successful(string message, string voucherNo)
        {
            this.txtEntryNo.Text = voucherNo;
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, new object[] { "Loan Voucher No.", voucherNo });
        }

        public void ClearControls()
        {
            this.controller.ClearErrors();
            this.txtEntryNo.Text = string.Empty;
            this.txtLoanNo.Text = string.Empty;
            this.txtCurrency.Text = string.Empty;
            this.txtSanctionAmount.Text = string.Empty;
            this.txtPartialAmount.Text = string.Empty;
            this.txtPartialAmount.Enabled = false;
            this.isSave = true;
            this.rdoFull.Checked = true;
            this.gdvAccountInfo.DataSource = null;
            this.gdvAccountInfo.Rows.Clear();
            this.txtLoanNo.Focus();
            this.txtLoanNo.Enabled = true;
            this.isSave = false;
        }

        private void txtLoanNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtLoanNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                this.rdoFull.Focus();
            }
        }

        private void txtLoanNo_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
