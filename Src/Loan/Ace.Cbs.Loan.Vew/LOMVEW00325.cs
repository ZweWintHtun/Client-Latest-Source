using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Loan.Vew
{
    //Added by HWKO (28-Jul-2017)
    public partial class LOMVEW00325 : BaseDockingForm, ILOMVEW00325
    {
        #region Constructor
        public LOMVEW00325()
        {
            InitializeComponent();
        }
        #endregion

        #region Controller
        private ILOMCTL00325 controller;
        public ILOMCTL00325 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        #endregion

        #region Control Properties
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
            get
            {
                decimal result = 0;
                Decimal.TryParse(this.txtSanctionAmount.Text, out result);
                return result;
            }
            set
            {
                this.txtSanctionAmount.Text = value.ToString("N2");
            }
        }
        #endregion

        #region Methods
        public void ClearControls()
        {
            this.controller.ClearErrors();
            this.txtEntryNo.Text = string.Empty;
            this.txtLoanNo.Text = string.Empty;
            //this.txtCurrency.Text = string.Empty;
            this.txtSanctionAmount.Text = string.Empty;
            this.gdvAccountInfo.DataSource = null;
            this.gdvAccountInfo.Rows.Clear();
            this.txtLoanNo.Focus();
            this.txtLoanNo.Enabled = true;
        }

        public void Successful(string message, string voucherNo)
        {
            this.txtEntryNo.Text = voucherNo;
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, new object[] { "Loan Voucher No.", voucherNo });
        }

        public void BindPLVoucherInfo(IList<PFMDTO00072> dtoList)
        {
            if (dtoList.Count == 0)
            {
                return;
            }
            else
            {
                #region old
                //    //this.LoanNo = dtoList[0].LoanNo;
            //    this.Currency = dtoList[0].CurrencyCode;
            //    this.SanctionAmount = dtoList[0].SAmt;

            //    this.gdvAccountInfo.AutoGenerateColumns = false;
            //    this.gdvAccountInfo.DataSource = null;
            //    this.gdvAccountInfo.CausesValidation = false;
            //    this.gdvAccountInfo.DataSource = dtoList;
                //    this.gdvAccountInfo.ReadOnly = true;
                #endregion

                IList<PFMDTO00072> returnDtoList = new List<PFMDTO00072>();
                 ChargeOfAccountSetupDTO coaDTo = new ChargeOfAccountSetupDTO();

                this.LoanNo =dtoList[0].LoanNo;
                this.Currency = dtoList[0].CurrencyCode;
                this.SanctionAmount = dtoList[0].SAmt;

                #region SanctionAmount
                PFMDTO00072 dtoForSAmtDr = new PFMDTO00072();
                string loanType ="PLLOANS";
                coaDTo.AccountNo = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { loanType, this.Currency, CurrentUserEntity.BranchCode, true });
                string Acode = coaDTo.AccountNo;
                coaDTo.AccountName = CXCLE00002.Instance.GetScalarObject<string>("COA.Client.SelectACName", new object[] { Acode, CurrentUserEntity.BranchCode, true });
                
                dtoForSAmtDr.CreditAccountNo1 = coaDTo.AccountNo;
                dtoForSAmtDr.BankAccountDescription = coaDTo.AccountName;
                dtoForSAmtDr.CreditAmount1 =dtoList[0].SAmt;
                dtoForSAmtDr.CreditDescription2 = "DEBIT";
                returnDtoList.Add(dtoForSAmtDr);

                PFMDTO00072 dtoForSAmtCr = new PFMDTO00072();
                loanType ="PLCONTROL";
                coaDTo.AccountNo = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { loanType, this.Currency, CurrentUserEntity.BranchCode, true });
                Acode = coaDTo.AccountNo;
                coaDTo.AccountName = CXCLE00002.Instance.GetScalarObject<string>("COA.Client.SelectACName", new object[] { Acode, CurrentUserEntity.BranchCode, true });

                dtoForSAmtCr.CreditAccountNo1 = dtoList[0].AccountNo; //coaDTo.AccountNo;
                //dtoForSAmtCr.BankAccountDescription =coaDTo.AccountName; // Commented By AAM (27-Feb-2018)

                string custName = this.controller.Get_CustomerName_PLVoucher(LoanNo); // Added By AAM (27-Feb-2018)
                dtoForSAmtCr.BankAccountDescription = custName; // Added By AAM (27-Feb-2018)

                dtoForSAmtCr.CreditAmount1 = dtoList[0].SAmt;
                dtoForSAmtCr.CreditDescription2 = "CREDIT";
                returnDtoList.Add(dtoForSAmtCr);
                #endregion

                #region Documentation Fee
                if (dtoList[0].docFee > 0)
                {
                    PFMDTO00072 dtoForDocFeeDr = new PFMDTO00072();

                    loanType ="PLCONTROL";
                    coaDTo.AccountNo = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { loanType, this.Currency, CurrentUserEntity.BranchCode, true });
                    Acode = coaDTo.AccountNo;
                    coaDTo.AccountName = CXCLE00002.Instance.GetScalarObject<string>("COA.Client.SelectACName", new object[] { Acode, CurrentUserEntity.BranchCode, true });

                    dtoForDocFeeDr.CreditAccountNo1 = dtoList[0].AccountNo;//coaDTo.AccountNo;
                    //dtoForDocFeeDr.BankAccountDescription =coaDTo.AccountName; // Commented By AAM(27-Feb-2018)
                    dtoForDocFeeDr.BankAccountDescription = custName; // Added By AAM (27-Feb-2018)
                    dtoForDocFeeDr.CreditAmount1 =dtoList[0].docFee;
                    dtoForDocFeeDr.CreditDescription2 = "DEBIT";
                    returnDtoList.Add(dtoForDocFeeDr);

                    PFMDTO00072 dtoForDocFeeCr = new PFMDTO00072();

                    loanType ="DOCINCOME";
                    coaDTo.AccountNo = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { loanType, this.Currency, CurrentUserEntity.BranchCode, true });
                    Acode = coaDTo.AccountNo;
                    coaDTo.AccountName = CXCLE00002.Instance.GetScalarObject<string>("COA.Client.SelectACName", new object[] { Acode, CurrentUserEntity.BranchCode, true });

                    dtoForDocFeeCr.CreditAccountNo1 =  coaDTo.AccountNo;
                    dtoForDocFeeCr.BankAccountDescription = coaDTo.AccountName;
                    dtoForDocFeeCr.CreditAmount1 =dtoList[0].docFee;
                    dtoForDocFeeCr.CreditDescription2 = "CREDIT";
                    returnDtoList.Add(dtoForDocFeeCr);
                }
                #endregion

                #region Service Charges
                if (dtoList[0].sCharge > 0)
                {
                    PFMDTO00072 dtoForSChargeDr = new PFMDTO00072();

                    loanType ="PLCONTROL";
                    coaDTo.AccountNo = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { loanType, this.Currency, CurrentUserEntity.BranchCode, true });
                    Acode = coaDTo.AccountNo;
                    coaDTo.AccountName = CXCLE00002.Instance.GetScalarObject<string>("COA.Client.SelectACName", new object[] { Acode, CurrentUserEntity.BranchCode, true });

                    dtoForSChargeDr.CreditAccountNo1 = dtoList[0].AccountNo;//coaDTo.AccountNo;
                    //dtoForSChargeDr.BankAccountDescription = coaDTo.AccountName; // Commented By AAM(27-Feb-2018)
                    dtoForSChargeDr.BankAccountDescription = custName; // Added By AAM (27-Feb-2018)
                    dtoForSChargeDr.CreditAmount1 = dtoList[0].sCharge;
                    dtoForSChargeDr.CreditDescription2 = "DEBIT";
                    returnDtoList.Add(dtoForSChargeDr);

                    PFMDTO00072 dtoForSChargeCr = new PFMDTO00072();

                    loanType ="PLSCHARGE";
                    coaDTo.AccountNo = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { loanType, this.Currency, CurrentUserEntity.BranchCode, true });
                    Acode = coaDTo.AccountNo;
                    coaDTo.AccountName = CXCLE00002.Instance.GetScalarObject<string>("COA.Client.SelectACName", new object[] { Acode, CurrentUserEntity.BranchCode, true });

                    dtoForSChargeCr.CreditAccountNo1 = coaDTo.AccountNo;
                    dtoForSChargeCr.BankAccountDescription = coaDTo.AccountName ;
                    dtoForSChargeCr.CreditAmount1 =  dtoList[0].sCharge;
                    dtoForSChargeCr.CreditDescription2 = "CREDIT";
                    returnDtoList.Add(dtoForSChargeCr);
                }
                #endregion
                this.gdvAccountInfo.AutoGenerateColumns = false;
                this.gdvAccountInfo.DataSource = null;
                this.gdvAccountInfo.CausesValidation = false;
                this.gdvAccountInfo.DataSource = returnDtoList;
                this.gdvAccountInfo.ReadOnly = true;
            }
        }
        #endregion

        private void LOMVEW00325_Load(object sender, EventArgs e)
        {
            #region Old_Logic
            /*
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.lblVoucherDate2.Text = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
            this.txtEntryNo.Enabled = false;
            this.txtCurrency.Enabled = false;
            this.txtSanctionAmount.Enabled = false;
            txtLoanNo.Focus();
            */
            #endregion

            #region Seperating_EOD_Logic (By HMW at 29-07-2019)
            DateTime systemDate = this.controller.GetSystemDate(CurrentUserEntity.BranchCode);
            DateTime lastSettlementDate = this.controller.GetLastSettlementDate(CurrentUserEntity.BranchCode);
            this.lblVoucherDate2.Text = systemDate.ToString("dd-MM-yyyy");

            if (systemDate.ToString("dd-MM-yyyy") != lastSettlementDate.ToString("dd-MM-yyyy")) //Show Form
            {
                this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
                this.lblVoucherDate2.Text = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
                this.txtEntryNo.Enabled = false;
                this.txtCurrency.Enabled = false;
                this.txtSanctionAmount.Enabled = false;
                txtLoanNo.Focus();
            }
            else //Don't show form after cut off
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI50013);//You have no permission.\n"Back Date EOD Process" needs to be completed!
                this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                this.DisableControls("PLVoucher.AllDisable");
            }
            #endregion
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.ClearControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (txtLoanNo.Text!="" && gdvAccountInfo.RowCount>1)//Added by HMW at 24-09-2019
            {
                this.controller.Save(this.LoanNo, CurrentUserEntity.BranchCode);
                txtLoanNo.Focus();
            }
            else
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90067);//Incomplete data to save !
            }
        }

        private void txtLoanNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        //Comment and Added by HMW at 17-Sept-2019
        private void txtLoanNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.Controller.BindPersonalLoanVoucherInfor(this.LoanNo);
                //SendKeys.Send("{Tab}");
                tsbCRUD.butSave.Focus();
            }
        }

        //private void txtLoanNo_Leave(object sender, EventArgs e)
        //{
        //    this.Controller.BindPersonalLoanVoucherInfor(this.LoanNo);
        //    tsbCRUD.butSave.Focus();
        //}
    }
}
