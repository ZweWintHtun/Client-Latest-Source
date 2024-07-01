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
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00081 : BaseDockingForm, ILOMVEW00081
    {
        #region variables declaration
        int NoofMonth;
        public string msgCode="";
        public string hpno = "";
        int noOfTerms=0;
        public static string eno = "";
        public string dealerStatus;
        public string checkStatus;
        public decimal balance;
        public bool status=true;
        string firstAmount;
        int gapPeriod;
        string relatedGLACode;

        decimal rentalChgRate;
        decimal serviceChgRate;
        decimal nextyearRentalChgRate;
        decimal nextyearRentalChgRate1;
        decimal docFees;

        int rentalChgDataEntryCount = 0;
        int downPayDataEntryCount = 0;
        int paymentDurationDataEntry = 0;

        IList<LOMDTO00082> lststockGroup;
        public LOMDTO00080 dealerInfoLst;
        public IList<LOMDTO00080> lstByDealerNo;
        public List<LOMDTO00084> lst;

        IList<LOMDTO00083> lstinstallmentTypes;
        public IList<LOMDTO00237> lstForHPEnquiry;

        //IList<decimal> lstHPRegRates;
        public LOMDTO00084 dto;
        public LOMDTO00092 d;
        #endregion

        #region Constructor
        public LOMVEW00081()
        {
            InitializeComponent();
        }

        public LOMVEW00081(string parentFromId, LOMDTO00080 dealerInfoLst)
        {
            InitializeComponent();
            this.ParentFormId = parentFromId;
            dealerInfoLst.DealerNo = "";
            this.dealerInfoLst = dealerInfoLst;
        }

        private ILOMCTL00081 controller;
        public ILOMCTL00081 Controller
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

        private ILOMCTL00088 controller1;
        public ILOMCTL00088 Controller1
        {
            set
            {
                this.controller1 = value;
            }
            get
            {
                return this.controller1;
            }
        }
        #endregion

        #region Properties
        public PFMDTO00067 AccountInformation { get; set; }
        public string ParentFormId { get; set; }
        IList<ChargeOfAccountDTO> RelatedGLACodeLists { get; set; }

        public string DealerAC
        {
            get { return this.txtDealerAcctno.Text.Replace("-", "").Trim(); }
            set { this.txtDealerAcctno.Text = value; }
        }
        public string DealerNo
        {
            get { return this.txtDealerAcctno.Text; }
            set { this.txtDealerAcctno.Text = value; }
        }
        public string HPNo
        {
            get { return this.txtHPno.Text; }
            set { this.txtHPno.Text = value; }
        }
        public string Caccount
        {
            get { return this.mtxtAccountNo.Text.Replace("-", "").Trim(); }
            set { this.mtxtAccountNo.Text = value; }
        }
        public string StockGroup 
        { 
            get { return this.cboProductGroup.SelectedValue.ToString();}
            set { this.cboProductGroup.Text = value; }
        }
        public string StockItems
        {
            get { return this.cboProductName.SelectedValue.ToString(); }
            set { this.cboProductName.Text = value; }
        }
        public decimal LoanAmount
        {
            get
            {
                if (string.IsNullOrEmpty(txtDisburseAmt.Text.ToString()))
                {
                    txtDisburseAmt.Text = "0";

                }
                return Convert.ToDecimal(txtDisburseAmt.Text);
            }
            set { this.txtDisburseAmt.Text = Convert.ToString(value); }
        }

        public decimal DocFees
        {
            get
            {
                if (string.IsNullOrEmpty(txtDocFees.Text.ToString()))
                {
                    txtDocFees.Text = "0";

                }
                return Convert.ToDecimal(txtDocFees.Text);
            }
            set { this.txtDocFees.Text = Convert.ToString(value); }
        }

        public int Term
        {
            get { return txtPaymentDuration.Text==""? 0 : Convert.ToInt32(txtPaymentDuration.Text); }
            set { this.txtPaymentDuration.Text = Convert.ToString(value); }
        }
        public decimal DownPayment
        {
            get
            {
                if (string.IsNullOrEmpty(txtDownPayment.Text.ToString()))
                {
                    txtDownPayment.Text = "0";

                }
                return Convert.ToDecimal(txtDownPayment.Text);
            }
            set { this.txtDownPayment.Text = Convert.ToString(value); }
        }
        public decimal RentalCharges
        {
            //get { return Convert.ToDecimal(txtRentalChgs.Text); }
            //set { this.txtRentalChgs.Text = Convert.ToString(value); }
            get
            {
                if (string.IsNullOrEmpty(txtRentalChgs.Text.ToString()))
                {
                    txtRentalChgs.Text = "0";

                }
                return Convert.ToDecimal(txtRentalChgs.Text);
            }
            set { this.txtRentalChgs.Text = (value).ToString("N2"); }

        }
        //public decimal ServiceCharges
        //{
        //    get
        //    {
        //        if (string.IsNullOrEmpty(txtServiceChgs.Text.ToString()))
        //        {
        //            txtServiceChgs.Text = "0";

        //        }
        //        return Convert.ToDecimal(txtServiceChgs.Text);
        //    }
        //    set { this.txtServiceChgs.Text = Convert.ToString(value); }

        //}
        public decimal NextRentalPercent
        {
            get
            {
                if (string.IsNullOrEmpty(txtNextYrRC.Text.ToString()))
                {
                    txtNextYrRC.Text = "0";

                }
                return Convert.ToDecimal(txtNextYrRC.Text);
            }
            set { this.txtNextYrRC.Text = Convert.ToString(value); }

        }
        public decimal Commission
        {
            get
            {
                if (string.IsNullOrEmpty(txtCommission.Text.ToString()))
                {
                    txtCommission.Text = "0";

                }
                return Convert.ToDecimal(txtCommission.Text);
            }
            set { this.txtCommission.Text = Convert.ToString(value); }
        }
        public string Slocation
        {
            get { return this.txtRemarks.Text; }
            set { this.txtRemarks.Text = value; }
        }
        public string guanacctno
        {
            get { return this.mtxtGraunteeAcctno.Text.Replace("-", "").Trim(); }
            set { this.mtxtGraunteeAcctno.Text = value; }
        }
        public decimal ProductValue
        {
            get
            {
                if (string.IsNullOrEmpty(txtProductValue.Text.ToString()))
                {
                    txtProductValue.Text = "0";

                }
                return Convert.ToDecimal(txtProductValue.Text);
            }
            set { this.txtProductValue.Text = Convert.ToString(value); }
        }
        public DateTime RepaySDate
        {
            get { return this.dtpRepayStart.Value; }
            set { this.dtpRepayStart.Text = Convert.ToString(value); }
        }
        public DateTime RepayExpDate
        {
            get { return this.dtpRepayExpired.Value; }
            set { this.dtpRepayExpired.Text = Convert.ToString(value); }
        }
        public int RepayOption
        {
            //get { return Convert.ToInt32(cboPaymentOpt.SelectedIndex); }
            //set { this.cboPaymentOpt.Text = Convert.ToString(value); }

            set{ this.cboPaymentOpt.SelectedValue = Convert.ToInt32(value); }
            get { return NoofMonth == null ? 0 : NoofMonth; }
        }

        public decimal PRIDownPay
        {
            get { return Convert.ToDecimal(txtPRIdownpayment.Text); }
            set { this.txtPRIdownpayment.Text = Convert.ToString(value); }
        }
        public decimal PRIRentalChgs
        {
            get { return Convert.ToDecimal(txtPRIrentalChgs.Text); }
            set { this.txtPRIrentalChgs.Text = Convert.ToString(value); }
        }
        //public decimal PRIServiceChgs
        //{
        //    get { return Convert.ToDecimal(txtPRIsvrchgs.Text); }
        //    set { this.txtPRIsvrchgs.Text = Convert.ToString(value); }
        //}
        public decimal PRIInstallment
        {
            get { return Convert.ToDecimal(txtPRIInstallAmt.Text); }
            set { this.txtPRIInstallAmt.Text = Convert.ToString(value); }
        }
        public decimal PRICommChgs
        {
            get { return Convert.ToDecimal(txtPRIcommi.Text); }
            set { this.txtPRIcommi.Text = Convert.ToString(value); }
        }
        public int GapPeriod
        {
            get
            {
                if (string.IsNullOrEmpty(txtGapDayForHP.Text.ToString()))
                {
                    txtGapDayForHP.Text = "0";

                }
                return Convert.ToInt32(txtGapDayForHP.Text);
            }
            set { this.txtGapDayForHP.Text = Convert.ToString(value); }
        }

        //public string RelatedGLACode
        //{
        //    get { return this.txtRelatedGL.Text; }
        //    set { this.txtRelatedGL.Text = lststockGroup[cboProductGroup.SelectedIndex].RelatedGLACode;}
        //}

        private string formname;
        public string FormName
        {
            get { return this.formname; }
            set { this.formname = value; }
        }  //Added By AAM (07-Feb-2018)

        public string SourceBr { get; set; }

        #endregion 

        #region Binding Method
        public void BindStockItem()
        {
            IList<LOMDTO00081> lststockItem = this.controller.GetAllStockItem();
            LOMDTO00081 dtostockItem = new LOMDTO00081();
            dtostockItem.Description = " -- SELECT --";
            lststockItem.Insert(0, dtostockItem);
            this.cboProductName.DataSource = lststockItem;
            this.cboProductName.ValueMember = "SubCode";
            this.cboProductName.DisplayMember = "Description";
        }

        public void BindStockGroup()
        {
            lststockGroup = this.controller.GetAllStockGroup();
            LOMDTO00082 dtostockGroup = new LOMDTO00082();
            dtostockGroup.Description = " -- SELECT --";
            lststockGroup.Insert(0, dtostockGroup);
            this.cboProductGroup.DataSource = lststockGroup;
            this.cboProductGroup.ValueMember = "GroupCode";
            this.cboProductGroup.DisplayMember = "Description";
        }

        public void BindInstallmentTypes()
        {
            lstinstallmentTypes = this.controller.GetAllInstallmentTypes();
            LOMDTO00083 dtoInstallmentTypes = new LOMDTO00083();
            dtoInstallmentTypes.Id = 0;
            dtoInstallmentTypes.Name = " -- SELECT --";
            lstinstallmentTypes.Insert(0, dtoInstallmentTypes);

            lstinstallmentTypes = lstinstallmentTypes.Where(t => t.Name.Equals("Monthly")).ToList();
            this.cboPaymentOpt.DataSource = lstinstallmentTypes;
            //this.cboPaymentOpt.ValueMember = "Id";
            this.cboPaymentOpt.ValueMember = "NOOFMONTH";
            this.cboPaymentOpt.DisplayMember = "Name";
            this.cboPaymentOpt.Refresh();
            this.cboPaymentOpt.SelectedIndex = 0;
            NoofMonth = lstinstallmentTypes[0].NoofMonth;
        }

        public void BindRateForHPReg()
        {
            //lstHPRegRates = this.controller.GetRateForHPReg();
            //txtRentalChgs.Text = lstHPRegRates[0].ToString();
            //txtServiceChgs.Text = lstHPRegRates[1].ToString();
            //txtNextYrRC.Text = lstHPRegRates[2].ToString();

            rentalChgRate = CXCLE00002.Instance.GetScalarObject<decimal>("RateFile.AccountClose.Select", new object[] { "HPRCHGRATE", true });
            //serviceChgRate = CXCLE00002.Instance.GetScalarObject<decimal>("RateFile.AccountClose.Select", new object[] { "HPSCHGRATE", true });
            //nextyearRentalChgRate = CXCLE00002.Instance.GetScalarObject<decimal>("RateFile.AccountClose.Select", new object[] { "HPNYRCHGRATE", true });
            nextyearRentalChgRate1 = CXCLE00002.Instance.GetScalarObject<decimal>("RateFile.AccountClose.Select", new object[] { "HPNYRCHGRATE1", true });
            docFees = CXCLE00002.Instance.GetScalarObject<decimal>("RateFile.AccountClose.Select", new object[] { "DOCFEE", true });
            gapPeriod = Convert.ToInt32(CXCLE00002.Instance.GetScalarObject<decimal>("RateFile.AccountClose.Select", new object[] { "GAPPERIOD", true }));

            txtRentalChgs.Text = rentalChgRate.ToString("N2");
            //txtServiceChgs.Text = serviceChgRate.ToString();
            txtNextYrRC.Text = nextyearRentalChgRate.ToString();
            txtDocFees.Text = docFees.ToString();
            txtDocFees.Text = Double.Parse(txtDocFees.Text).ToString("N2");
            txtGapDayForHP.Text = gapPeriod.ToString();

        }
        #endregion

        #region Initialize and Validation
        public bool ValidationControls()
        {
            if (string.IsNullOrEmpty(this.Caccount))
            {
                errorProvider1.SetError(mtxtAccountNo, "AccountNo");
            }
            if (string.IsNullOrEmpty(this.DealerAC))
            {
                errorProvider1.SetError(txtDealerAcctno, "DealerACNo");
            }
            if (txtDownPayment.TextLength == 0)
            {
                errorProvider1.SetError(txtDownPayment, "DownPayment");
            }
            if (txtRentalChgs.TextLength == 0)
            {
                errorProvider1.SetError(txtRentalChgs, "RentalChgs");
            }
            //if (txtServiceChgs.TextLength == 0)
            //{
            //    errorProvider1.SetError(txtServiceChgs, "ServiceChgs");
            //}
            if (txtNextYrRC.TextLength == 0)
            {
                errorProvider1.SetError(txtNextYrRC, "NextYrRC");
            }
            if (txtDisburseAmt.TextLength == 0)
            {
                errorProvider1.SetError(txtDisburseAmt, "DisburseAmt");
            }
            if (cboPaymentOpt.Text == "")
            {
                errorProvider1.SetError(cboPaymentOpt, "PaymentOption");
            }
            if (cboProductGroup.SelectedIndex == 0)
            {
                errorProvider1.SetError(cboProductGroup, "ProductGroup");
            }
            if (cboProductName.SelectedIndex == 0)
            {
                errorProvider1.SetError(cboProductName, "ProductName");
            }
            if (txtProductValue.TextLength == 0)
            {
                errorProvider1.SetError(txtProductValue, "ProductValue");
            }
            if (txtPaymentDuration.TextLength == 0)
            {
                errorProvider1.SetError(txtPaymentDuration, "PaymentDuration");
            }
            if (string.IsNullOrEmpty(this.Caccount) || string.IsNullOrEmpty(this.DealerAC) || txtDownPayment.TextLength == 0 ||
                txtRentalChgs.TextLength == 0 || txtNextYrRC.TextLength == 0 || //txtServiceChgs.TextLength==0||
                txtDisburseAmt.TextLength == 0 || cboPaymentOpt.Text == "" || cboProductGroup.SelectedIndex == 0 ||
                cboProductName.SelectedIndex == 0 || txtPaymentDuration.TextLength == 0)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90067);
                errorProvider1.Clear();
                return false;
            }
            else return true;
        }

        private void InitializeControls()
        {
            this.txtHPno.Text = string.Empty;
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.mtxtAccountNo.Text = string.Empty;
            //this.txtDealerAcctno.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.txtDealerAcctno.Text = string.Empty;
            this.mtxtGraunteeAcctno.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.mtxtGraunteeAcctno.Text = string.Empty;
            this.txtDownPayment.Text = string.Empty;

            this.txtRentalChgs.Text = string.Empty;
            this.txtRentalChgs.Enabled = false;

            //this.txtServiceChgs.Text = string.Empty;
            //this.txtServiceChgs.Enabled = false;

            this.txtNextYrRC.Text = string.Empty;
            this.txtNextYrRC.Enabled = false;

            this.txtDocFees.Text = string.Empty;
            this.txtDocFees.Enabled = false;

            this.chkRentalChgEdit.Checked = false;
            //this.chkServiceChgEdit.Checked = false;
            this.chkNYrRentalChgEdit.Checked = false;
            this.chkDocFees.Checked = false;

            this.txtDisburseAmountEncode.Text = string.Empty;
            //this.txtDisburseAmountEncode.Enabled = true; // Added By AAM (19-Feb-2018)
            //this.txtDisburseAmt.Enabled = false; // Added By AAM (19-Feb-2018)

            this.txtDisburseAmt.Text = string.Empty;
            this.txtDocFees.Text = string.Empty;
            this.txtProductValue.Text = string.Empty;
            this.txtPaymentDuration.Text = string.Empty;
            this.txtPRIdownpayment.Text = string.Empty;
            this.txtPRIcommi.Text = string.Empty;
            this.txtPRIInstallAmt.Text = string.Empty;
            this.txtPRIrentalChgs.Text = string.Empty;
            //this.txtPRIsvrchgs.Text = string.Empty;
            this.txtProductValue.Text = string.Empty;
            this.dtpRepayStart.Text = string.Empty;
            this.dtpRepayExpired.Text = string.Empty;
            this.txtCommission.Text = string.Empty;
            this.txtRemarks.Text = string.Empty;

            this.cboPaymentOpt.Text = string.Empty;
            this.cboProductGroup.Text = string.Empty;
            this.cboProductName.Text = string.Empty;

            this.txtRelatedGL.Text = string.Empty;

            this.txtGapDayForHP.Text = string.Empty;
            this.txtGapDayForHP.Enabled = false;

            this.chkGapDayForHP.Checked = false;
        }
        #endregion

        #region Successful and Failure
        public void Successful(string message, string hpno)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.InitializeControls();
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        #endregion

        #region Supporting Method
        public void ShowTotalInterestAmount()
        {
            txtDisburseAmt.Text = Double.Parse(txtDisburseAmt.Text).ToString("N2");
            txtProductValue.Text = (LoanAmount - (this.LoanAmount * this.DownPayment / 100)).ToString("N2");
           
            LOMDTO00084 dto1 = new LOMDTO00084();
            dto1.DownPayment = DownPayment;
            dto1.LoanAmount = LoanAmount;
            dto1.Term = Term;
            dto1.RepayOption = RepayOption;
            dto1.RentalCharges = RentalCharges;
            dto1.SourceBr = SourceBr;
            dto1.Commission = Commission;

            IList<LOMDTO00240> lst = this.controller.Get_TotalInterestAndFirstInstallment(dto1);
            if (lst.Count > 0)
            {
                txtPRIrentalChgs.Text = lst[0].TotalInterest.ToString("N2");

                txtPRIdownpayment.Text = lst[0].DownPaymentAmount.ToString("N2");
                txtPRIrentalChgs.Text = lst[0].RentalChargesAmount.ToString("N2");
                txtPRIInstallAmt.Text = lst[0].InstallmentAmount.ToString("N2");
                txtPRIcommi.Text = lst[0].CommissionAmount.ToString("N2");
            }     
            
        }

        public void ShowPaymentInfo(int repayOpt)
        {
            decimal downpayAmt = (this.LoanAmount * this.DownPayment) / 100;
            decimal commAmt = (this.LoanAmount * this.Commission) / 100;
            decimal netDisAmt = this.LoanAmount - downpayAmt;
            //decimal rentChgAmt = (netDisAmt * this.RentalCharges) / 100;
            //decimal serviceChgAmt = (netDisAmt * this.ServiceCharges) / 100;

            txtPRIdownpayment.Text = downpayAmt.ToString();
            //txtPRIsvrchgs.Text = serviceChgAmt.ToString();
            //txtPRIrentalChgs.Text = rentChgAmt.ToString();
            txtPRIcommi.Text = commAmt.ToString();

            if (repayOpt == 1) noOfTerms = Term / 1;            //Monthly 
            else if (repayOpt == 2) noOfTerms = Term / 6;       //Half_Yearly
            else if (repayOpt == 3) noOfTerms = Term / 12;      //Yearly
            else if (repayOpt == 4) noOfTerms = Term / 3;       //Quartely

            if (netDisAmt > 0 && noOfTerms > 0)
                txtPRIInstallAmt.Text = this.controller.GetInstallmentAmt(netDisAmt, noOfTerms);
            else
                txtPRIInstallAmt.Text = "0,00";

            txtPRIdownpayment.Text = Double.Parse(txtPRIdownpayment.Text).ToString("N2");
            //txtPRIsvrchgs.Text = Double.Parse(txtPRIsvrchgs.Text).ToString("N2");
            //txtPRIrentalChgs.Text = Double.Parse(txtPRIrentalChgs.Text).ToString("N2");
            txtPRIcommi.Text = Double.Parse(txtPRIcommi.Text).ToString("N2");
            txtPRIInstallAmt.Text = Double.Parse(txtPRIInstallAmt.Text).ToString("N2");
            //Start();
        }
        
        private void Reset()
        {
            this.txtHPno.Text = string.Empty;
            this.mtxtAccountNo.Text = string.Empty;
            this.txtDealerAcctno.Text = string.Empty;
            this.mtxtGraunteeAcctno.Text = string.Empty;
            this.txtDownPayment.Text = string.Empty;

            this.txtRentalChgs.Text = string.Empty;
            this.txtRentalChgs.Enabled = false;

            //this.txtServiceChgs.Text = string.Empty;
            //this.txtServiceChgs.Enabled = false;

            this.txtNextYrRC.Text = string.Empty;
            this.txtNextYrRC.Enabled = false;

            this.txtDocFees.Text = string.Empty;
            this.txtDocFees.Enabled = false;

            this.chkRentalChgEdit.Checked = false;
            //this.chkServiceChgEdit.Checked = false;
            this.chkNYrRentalChgEdit.Checked = false;
            this.chkDocFees.Checked = false;

            this.txtDisburseAmountEncode.Text = string.Empty;
            this.txtDisburseAmountEncode.Enabled = true;

            this.txtDisburseAmt.Text = string.Empty;
            this.txtDocFees.Text = string.Empty;
            this.txtProductValue.Text = string.Empty;
            this.txtPaymentDuration.Text = string.Empty;
            this.txtPRIdownpayment.Text = string.Empty;
            this.txtPRIcommi.Text = string.Empty;
            this.txtPRIInstallAmt.Text = string.Empty;
            this.txtPRIrentalChgs.Text = string.Empty;
            //this.txtPRIsvrchgs.Text = string.Empty;
            this.txtProductValue.Text = string.Empty;
            this.dtpRepayStart.Text = string.Empty;
            this.dtpRepayExpired.Text = string.Empty;
            this.txtCommission.Text = string.Empty;
            this.txtRemarks.Text = string.Empty;

            this.cboPaymentOpt.SelectedIndex = 0;
            this.cboProductGroup.SelectedIndex = 0;
            this.cboProductName.SelectedIndex = 0;

            this.txtRelatedGL.Text = string.Empty;

            this.txtGapDayForHP.Text = string.Empty;
            this.txtGapDayForHP.Enabled = false;

            this.chkGapDayForHP.Checked = false;
        }

        private string CheckBalance(decimal balance)
        {
            string balStatus = "";

            decimal downpayAmt = (this.LoanAmount * this.DownPayment) / 100;
            decimal docFees = this.DocFees;
            #region Comment belows instructions according to PRISTINE Version.
            //decimal netDisAmt = this.LoanAmount - downpayAmt;
            //decimal rentChgAmt = (netDisAmt * this.RentalCharges) / 100;
            //decimal serviceChgAmt = (netDisAmt * this.ServiceCharges) / 100;
            //decimal initialPayAmt = downpayAmt + rentChgAmt; +serviceChgAmt;
            #endregion
            decimal initialPayAmt = downpayAmt + docFees;
           
            if (balance < 0) balStatus = "-0";                  // Customer Ledger (-) Case
            else if (balance >=0 && balance < initialPayAmt) balStatus = "-1"; // Insufficient Balance in Customer Ledger.
            else balStatus = "0";                               // Sufficient Balance in Customer Ledger.

            return balStatus;
        }

        private void SetControlsSetting_For_Enquiry()
        {
            this.txtHPno.ReadOnly = true;
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.mtxtAccountNo.Text = string.Empty;
            this.mtxtAccountNo.Enabled = true;
            this.txtDealerAcctno.Enabled = false;
            this.txtDownPayment.Enabled = false;
            this.txtRentalChgs.Enabled = false;
            this.txtPaymentDuration.Enabled = false;
            this.cboPaymentOpt.Enabled = false;
            this.txtCommission.Enabled = false;
            this.txtNextYrRC.Enabled = false;
            this.txtDisburseAmt.Enabled = false;
            this.txtDisburseAmountEncode.Visible = false;
            this.txtDocFees.Enabled = false;
            this.txtGapDayForHP.Enabled = false;
            this.dtpRepayStart.Enabled = false;
            this.dtpRepayExpired.Enabled = false;
            this.mtxtGraunteeAcctno.Enabled = false;
            this.cboProductGroup.Enabled = false;
            this.cboProductName.Enabled = false;
            this.txtProductValue.Enabled = false;
            this.txtRelatedGL.Enabled = false;
            this.txtPRIdownpayment.Enabled = false;
            this.txtPRIrentalChgs.Enabled = false;
            this.txtPRIcommi.Enabled = false;
            this.txtPRIInstallAmt.Enabled = false;
            this.txtRemarks.Enabled = false;

        }
        #endregion

        #region Form_Load Method
        private void LOMVEW00081_Load(object sender, EventArgs e)
        {
            SourceBr = CurrentUserEntity.BranchCode;
            #region Old_Logic
            #region Old Code
            //this.InitializeControls();
            //this.status = false;
            //this.BindInstallmentTypes();
            //this.BindStockGroup();
            //this.BindStockItem();
            //this.BindRateForHPReg();
            #endregion

            /*
            if (this.formname.Contains("Entry"))
            {
                this.InitializeControls();
                this.status = false;
                this.BindInstallmentTypes();
                this.BindStockGroup();
                this.BindStockItem();
                this.BindRateForHPReg();
            }
            else if (this.formname.Contains("Enquiry"))
            {
                this.SetControlsSetting_For_Enquiry();
            }
            */

            #endregion

            #region Seperating_EOD_Logic (By HMW at 29-07-2019)
            DateTime systemDate = this.controller.GetSystemDate(CurrentUserEntity.BranchCode);
            DateTime lastSettlementDate = this.controller.GetLastSettlementDate(CurrentUserEntity.BranchCode);
            this.lblTransactionDate.Text = systemDate.ToString("dd-MM-yyyy");

            //if (systemDate.ToString("dd-MM-yyyy") != lastSettlementDate.ToString("dd-MM-yyyy")) //Show Form
            //{
                if (this.formname.Contains("Entry"))
                {
                    this.InitializeControls();
                    this.status = false;
                    this.BindInstallmentTypes();
                    this.BindStockGroup();
                    this.BindStockItem();
                    this.BindRateForHPReg();
                }
                else if (this.formname.Contains("Enquiry"))
                {
                    this.SetControlsSetting_For_Enquiry();
                }
            //}
            //else //Don't show form after cut off
            //{
            //    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI50013);//You have no permission.\n"Back Date EOD Process" needs to be completed!
            //    this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
            //    this.InitializeControls();
            //    this.DisableControls("HPRegister.AllDisable");
            //}
            #endregion
        }

        #endregion

        #region Event Method
        private void txtDownPayment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b'&&e.KeyChar!='.')
            {
                e.Handled = true;
            }
        }

        private void txtRentalChgs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
                e.Handled = true;

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                e.Handled = true;
           
        }

        private void txtServiceChgs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtNextYrRC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        //private void Start()
        //{
        //    txtDisburseAmt.PasswordChar = '*';
        //    txtDisburseAmt.Text = "";
        //}

        //private void txtDisburseAmt_KeyPress(object sender, KeyPressEventArgs e)
        //{

        //}

        //private void txtProductValue_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
        //    {
        //        e.Handled = true;
        //    }

        //    //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
        //    //{
        //    //    e.Handled = true;
        //    //}

        //    //// only allow one decimal point 
        //    //if (e.KeyChar == '.'
        //    //    && (sender as TextBox).Text.IndexOf('.') > -1)
        //    //{
        //    //    e.Handled = true;
        //    //}

        //}

        private void txtPaymentDuration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void mtxtGraunteeAcctno_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void btnDealerEnquiry_Click(object sender, EventArgs e)
        {
            this.controller.Call_DealerSearch();
        }

        private void btnAccountEnquiry_Click(object sender, EventArgs e)
        {
            if (Caccount.Trim() != string.Empty)
            {
                this.AccountInformation = new PFMDTO00067();
                this.AccountInformation = this.Controller.GetAccountInformation();
                if (this.AccountInformation == null)
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00046);
                    mtxtAccountNo.Focus();
                }
                else
                   // this.InitializeControls();
                    this.controller.Call_AccountEnquiry();
            }
            else
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME90009);
                mtxtAccountNo.Focus();
            }

            //this.controller.Call_AccountEnquiry();
        }

        private void btnGraunteeEnquiry_Click(object sender, EventArgs e)
        {
            this.controller.Call_GuanteeAccountEnquiry();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (this.formname.Contains("Entry"))
            {
                TLMDTO00018 tLMDTO00018 = this.controller.CountofLoan_byAccountNo(Caccount, "HP");

                if (tLMDTO00018.Loans_Type.Equals(""))
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00046);
                    this.mtxtAccountNo.Text = string.Empty;
                    this.mtxtAccountNo.Focus();
                    return;
                }
                else
                {
                    if (tLMDTO00018.RCount > 0)
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90233);
                        this.mtxtAccountNo.Text = string.Empty;
                        this.mtxtAccountNo.Focus();
                        return;
                    }
                }
            }
                   
            checkStatus=this.controller.CheckAccountExistsOrValid(Caccount,CurrentUserEntity.BranchCode);
            if (checkStatus == "0")
            {
                if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC00004) == DialogResult.Yes)
                {
                    if (!this.ValidationControls())
                        return;
                    if (DealerAC.Substring(0, 2) == "DR")
                        dealerStatus = "1"; // to generate PO Number coz of Dealer haven't account number.
                    else
                        dealerStatus = "0"; // Dealer have account. No need PO.

                    balance = Convert.ToDecimal(this.controller.CheckBalance(Caccount, CurrentUserEntity.BranchCode));
                    string status = this.CheckBalance(balance);
                    if (status == "0")
                    {
                        LOMDTO00084 dto = this.controller.AddHirePurchaseRegistration(hpno, Caccount, DealerAC, dealerStatus, guanacctno, DownPayment, RentalCharges,// ServiceCharges,
                                                        NextRentalPercent, LoanAmount, DocFees, GapPeriod, Commission, StockGroup, StockItems, relatedGLACode, ProductValue, Term, RepayOption,
                                                        RepaySDate, RepayExpDate, CurrentUserEntity.BranchCode, Slocation, CurrentUserEntity.CurrentUserID, eno, CurrentUserEntity.CurrentUserName);

 
                        msgCode = CXClientWrapper.Instance.ServiceResult.MessageCode;
                        if (dto.RetMsg=="-1")
                        {
                            this.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode, Caccount);
                            return; 
                        }
                        if (dto != null && dto.HPNo != "-1")
                        {
                            this.HPNo = dto.HPNo;
                            this.PRIDownPay = dto.DownPayAmt;
                            this.PRIRentalChgs = dto.RentalCharges;
                            //this.PRIServiceChgs = dto.ServiceCharges;
                            this.PRICommChgs = dto.Commission;
                            this.PRIInstallment = dto.Installment;
                            this.RepayExpDate = dto.ExpiredDate;
                             
                            LOMDTO00092 d = new LOMDTO00092();
                            d.eno = dto.Eno;
                            IList<LOMDTO00092> lsts = this.controller.GetHPVoucherDetails(d);
                            this.controller.Call_HPVoucherDetails(lsts,DealerAC);
                            this.Successful(msgCode, HPNo);
                            
                            //Added By AAM(30-08-2017)
                            //this.InitializeControls();
                            this.Reset(); //Modified (16-11-2017)
                            this.BindRateForHPReg();
                        }
                    }

                    else if (status == "-1")
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90159);
                        return; 
                    }
                    else if (status == "-0")
                    {
                        //Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90160);
                        MessageBox.Show("Overdraft in Customer Ledger!");
                        return; 
                    }
                }
            }
            else
            {
                this.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode, Caccount);
                return;
            }

        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mtxtAccountNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                #region Old Code
                //checkStatus = this.controller.CheckAccountExistsOrValid(Caccount, CurrentUserEntity.BranchCode);
                //if (checkStatus == "0") return;
                //string acctno = Caccount;
                //this.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode, Caccount);
                //this.mtxtAccountNo.Text = acctno;
                //txtDealerAcctno.Focus();
                #endregion 
                if (this.formname.Contains("Entry"))
                {
                    TLMDTO00018 tLMDTO00018 = this.controller.CountofLoan_byAccountNo(Caccount, "HP");

                    if (tLMDTO00018.Loans_Type.Equals(""))
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00046);
                        this.mtxtAccountNo.Text = string.Empty;
                        this.mtxtAccountNo.Focus();
                    }
                    else
                    {
                        if (tLMDTO00018.RCount > 0)
                        {
                            CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90233);
                            this.mtxtAccountNo.Text = string.Empty;
                            this.mtxtAccountNo.Focus();
                        }
                        else
                        {
                            checkStatus = this.controller.CheckAccountExistsOrValid(Caccount, CurrentUserEntity.BranchCode);
                            if (checkStatus == "0") return;
                            string acctno = Caccount;
                            this.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode, Caccount);
                            this.mtxtAccountNo.Text = acctno;
                            txtDealerAcctno.Focus();
                        }
                    }
                }
                else if (this.formname.Contains("Enquiry"))
                {
                    lstForHPEnquiry=this.controller.Get_HP_Information_For_Enquiry(Caccount, CurrentUserEntity.BranchCode);

                    if (lstForHPEnquiry.Count > 0)
                    {
                        this.mtxtAccountNo.Text = lstForHPEnquiry[0].Caccount;
                        this.txtDealerAcctno.Text = lstForHPEnquiry[0].DealerAC;
                        this.txtDownPayment.Text = lstForHPEnquiry[0].DownPayPercent.ToString();
                        this.txtRentalChgs.Text = lstForHPEnquiry[0].RCharges_Percent.ToString("N2");
                        this.txtPaymentDuration.Text = lstForHPEnquiry[0].Duration.ToString();
                        this.cboPaymentOpt.Text = lstForHPEnquiry[0].PaymentOption;
                        this.txtCommission.Text = lstForHPEnquiry[0].DealerCommi.ToString("N2");
                        this.txtNextYrRC.Text = lstForHPEnquiry[0].NextRentalPercent.ToString();
                        this.txtDisburseAmt.Text = lstForHPEnquiry[0].LoanAmount.ToString("N2");
                        this.txtDocFees.Text = lstForHPEnquiry[0].DocFees.ToString("N2");
                        this.txtGapDayForHP.Text = lstForHPEnquiry[0].GapPeriod.ToString();
                        this.dtpRepayStart.Text = lstForHPEnquiry[0].RepayStartDate.ToString();
                        this.dtpRepayExpired.Text = lstForHPEnquiry[0].ExpiredDate.ToString();
                        this.mtxtGraunteeAcctno.Text = lstForHPEnquiry[0].guanacctno;
                        this.cboProductGroup.Text = lstForHPEnquiry[0].ProductGroup;
                        this.cboProductName.Text = lstForHPEnquiry[0].ProductName;
                        this.txtProductValue.Text = lstForHPEnquiry[0].ProductValue.ToString("N2");
                        this.txtRelatedGL.Text = lstForHPEnquiry[0].RelatedGLACode;

                        this.txtPRIdownpayment.Text = lstForHPEnquiry[0].DownPayment.ToString("N2");
                        this.txtPRIrentalChgs.Text = lstForHPEnquiry[0].RentalCharges.ToString("N2");
                        this.txtPRIInstallAmt.Text = lstForHPEnquiry[0].InstallmentAmount.ToString("N2");
                        this.txtPRIcommi.Text = lstForHPEnquiry[0].Commission.ToString("N2");

                        this.txtRemarks.Text = lstForHPEnquiry[0].Remarks.ToString();
                    }
                    else
                        this.Reset();
                }

            }
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            if (mtxtAccountNo.Text.Length>0 && txtDealerAcctno.Text.Length>0)
            {
                if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC90010) == DialogResult.No)
                    return;
                else
                {
                    this.Reset();
                    this.BindRateForHPReg();
                }
            }

        }

        private void cboPaymentOpt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (status == false)
            {
                int indx = cboPaymentOpt.SelectedIndex;
                if (indx == 0)
                    return;

                if (indx==1)
                {
                    //dtpRepayStart.Text=DateTime.Now.AddMonths(1).AddDays(-1).ToString(); 
                    dtpRepayStart.Text = DateTime.Now.AddDays(30).ToString(); //Modified By AAM(26-10-2017)
                }
                else if (indx == 2)
                {
                    //dtpRepayStart.Text = DateTime.Now.AddMonths(6).AddDays(-1).ToString();
                    dtpRepayStart.Text = DateTime.Now.AddDays(180).ToString();//Modified By AAM(26-10-2017)
                }
                else if (indx == 3)
                {
                    //dtpRepayStart.Text = DateTime.Now.AddMonths(12).AddDays(-1).ToString();
                    dtpRepayStart.Text = DateTime.Now.AddDays(360).ToString();//Modified By AAM(26-10-2017)
                }
                else
                {
                    //dtpRepayStart.Text = DateTime.Now.AddMonths(3).AddDays(-1).ToString();
                    dtpRepayStart.Text = DateTime.Now.AddDays(90).ToString();//Modified By AAM(26-10-2017)
                }

                ShowPaymentInfo(indx);
                ShowTotalInterestAmount();
                ///////////////////////////////           
                nextyearRentalChgRate1 = CXCLE00002.Instance.GetScalarObject<decimal>("RateFile.AccountClose.Select", new object[] { "HPNYRCHGRATE1", true });
                gapPeriod = Convert.ToInt32(CXCLE00002.Instance.GetScalarObject<decimal>("RateFile.AccountClose.Select", new object[] { "GAPPERIOD", true }));

                if (indx!=0)
                {
                    //int paymentOpt = 12 / lstinstallmentTypes[cboPaymentOpt.SelectedIndex].NoofMonth;
                    //int noOfTerms = Convert.ToInt32(txtPaymentDuration.Text) / lstinstallmentTypes[cboPaymentOpt.SelectedIndex].NoofMonth;
                    int paymentOpt = 12 /NoofMonth;
                    int noOfTerms = Convert.ToInt32(txtPaymentDuration.Text) / NoofMonth;
                    txtNextYrRC.Text = "0.00";
                    //if (noOfTerms <= paymentOpt)
                    //{
                    //    txtNextYrRC.Text = "0.00";
                    //}
                    //else if (noOfTerms % paymentOpt == 0 || (noOfTerms % paymentOpt) * 2 > paymentOpt)
                    //    txtNextYrRC.Text = rentalChgRate.ToString();

                    //else txtNextYrRC.Text = nextyearRentalChgRate1.ToString();
                }

                
                ///////////////////////////////

                //txtDisburseAmountEncode.Visible = true; // Comment By AAM (06-Feb-2018)
            }
        }

        private void txtPaymentDuration_Leave(object sender, EventArgs e)
        {
            if (txtPaymentDuration.Text != "0" || txtPaymentDuration.Text != string.Empty)
            {
                int durationInMonth = txtPaymentDuration.Text=="" ? 0 :Convert.ToInt32(txtPaymentDuration.Text);
                DateTime PreDue = DateTime.Now.AddMonths(durationInMonth);

                string[] arr = DateTime.Now.ToString("dd-MM-yyyy").Split('-');
                int _day = (arr[0].Substring(0, 1) == "0" ? Convert.ToInt32(arr[0].Substring(1, 1)) : Convert.ToInt32(arr[0]));

                if (_day < 21) //1=>25
                    dtpRepayExpired.Value = Convert.ToDateTime((PreDue.Year + "/" + PreDue.Month + "/05").ToString());
                else
                    dtpRepayExpired.Value = Convert.ToDateTime((PreDue.Year + "/" + PreDue.AddMonths(1).Month + "/05").ToString());


                paymentDurationDataEntry += 1;
                if (paymentDurationDataEntry > 1)
                {
                    int indx = cboPaymentOpt.SelectedIndex;
                    this.ShowPaymentInfo(indx);
                    this.ShowTotalInterestAmount();
                }
            }
        }

        private void txtDisburseAmt_Leave(object sender, EventArgs e)
        {
            if (txtDisburseAmt.Text == "")
            {
                txtDisburseAmountEncode.Visible = true;
                txtDisburseAmt.Visible = false;
                txtDisburseAmountEncode.Focus();
            }
            else
            {
                if (txtDisburseAmt.Text != txtDisburseAmountEncode.Text)
                {
                    #region
                    //Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00037);
                    //MessageBox.Show("Invalid amount");
                    //CXUIMessageUtilities.ShowMessageByCode("MC00002") == DialogResult.No
                    //if (CXUIMessageUtilities.ShowMessageByCode("MV00037") == DialogResult.Yes)
                    //{
                    //    txtDisburseAmt.Focus();
                    //}
                    #endregion

                    if (MessageBox.Show("Invalid Amount", "Do You Want to re-enter disburse amount?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        txtDisburseAmt.Clear();
                        txtDisburseAmountEncode.Clear();
                        txtDisburseAmountEncode.PasswordChar = '*';

                        txtDisburseAmountEncode.Visible = true;
                        txtDisburseAmt.Visible = false;

                        txtDisburseAmountEncode.Focus();
                    }

                }
                else
                {
                    if (txtPaymentDuration.Text != "0" || txtPaymentDuration.Text != "")
                    {
                        txtDisburseAmountEncode.Visible = false;
                        txtDisburseAmt.Visible = true;

                        ShowPaymentInfo(RepayOption);

                        //txtDisburseAmt.Text = Double.Parse(txtDisburseAmt.Text).ToString("N2");
                        //txtProductValue.Text = (LoanAmount - (this.LoanAmount * this.DownPayment / 100)).ToString("N2");

                        ShowTotalInterestAmount();
                    }
                    else
                    {
                        txtDisburseAmountEncode.Visible = true;
                        txtDisburseAmt.Visible = false;
                        txtDisburseAmountEncode.Focus();
                    }
                }
            }
        }

        private void txtDisburseAmountEncode_Leave(object sender, EventArgs e)
        {
            txtDisburseAmountEncode.Visible = false;
            txtDisburseAmt.Visible = true;
            txtDisburseAmt.Focus();
        }

        private void chkRentalChgEdit_Click(object sender, EventArgs e)
        {
            this.txtRentalChgs.Enabled = true;          
        }

        private void chkNYrRentalChgEdit_Click(object sender, EventArgs e)
        {
            this.txtNextYrRC.Enabled = true;
        }

        private void chkDocFees_Click(object sender, EventArgs e)
        {
            this.txtDocFees.Enabled = true;
        }

        private void txtDealerAcctno_Leave(object sender, EventArgs e)
        {
            if (txtDealerAcctno.Text != "" && txtDealerAcctno.Text != string.Empty)
            {
                string commission = this.controller.GetDealerCommission_ByDealerNo(DealerAC, CurrentUserEntity.BranchCode);
                txtCommission.Text = commission;
                this.controller.Call_DealerSearch();
            }
        }

        private void txtDealerAcctno_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void cboProductGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboProductGroup.SelectedIndex<1)
            {
                txtRelatedGL.Text="";
                
            }
            else
            {
                txtRelatedGL.Text=lststockGroup[cboProductGroup.SelectedIndex].RelatedGLACode+" | "+lststockGroup[cboProductGroup.SelectedIndex].ACName;
                relatedGLACode = lststockGroup[cboProductGroup.SelectedIndex].RelatedGLACode;
            }
        }

        private void txtDocFees_Leave(object sender, EventArgs e)
        {
            if (txtDocFees.TextLength==0)
                txtDocFees.Text = "0";
            else txtDocFees.Text = Double.Parse(txtDocFees.Text).ToString("N2");
        }

        //private void txtProductValue_Leave(object sender, EventArgs e)
        //{
            //decimal DisburseAmt = 0; decimal ProductValue = 0;
            //DisburseAmt= Convert.ToDecimal(txtDisburseAmt.Text);
            //ProductValue = Convert.ToDecimal(txtProductValue.Text);

            //if (DisburseAmt != ProductValue)
            //{
            //    MessageBox.Show("Product Value must be equal Product Original Value!");
            //    txtProductValue.Focus();
            //}
            //else
            //    txtProductValue.Text = Double.Parse(txtProductValue.Text).ToString("N2");
       // }

        private void chkGapDayForHP_Click(object sender, EventArgs e)
        {
            this.txtGapDayForHP.Enabled = true;
        }

        private void txtGapDayForHP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }


        private void txtRentalChgs_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtRentalChgs.Text))
                txtRentalChgs.Text = Double.Parse(txtRentalChgs.Text).ToString("N2");
            else
                txtRentalChgs.Text = "0.00";

            rentalChgDataEntryCount += 1;
            if (rentalChgDataEntryCount>1)
            {
                int indx = cboPaymentOpt.SelectedIndex;
                this.ShowPaymentInfo(indx);
                ShowTotalInterestAmount();
            }

        }

        // Added By AAM (06-Feb-2018)
        private void txtDownPayment_Leave(object sender, EventArgs e)
        {
            downPayDataEntryCount += 1;
            if (downPayDataEntryCount > 1 && txtPaymentDuration.Text != "0" && txtPaymentDuration.Text != string.Empty)
            {
                int indx = cboPaymentOpt.SelectedIndex;
                this.ShowPaymentInfo(indx);
                ShowTotalInterestAmount();
            }
        }
        #endregion

        private void cboPaymentOpt_Leave(object sender, EventArgs e)
        {
            if (status == false)
            {
                int indx = cboPaymentOpt.SelectedIndex;
                if (indx == 0)
                    return;

                if (indx == 1)
                {
                    //dtpRepayStart.Text=DateTime.Now.AddMonths(1).AddDays(-1).ToString(); 
                    dtpRepayStart.Text = DateTime.Now.AddDays(30).ToString(); //Modified By AAM(26-10-2017)
                }
                else if (indx == 2)
                {
                    //dtpRepayStart.Text = DateTime.Now.AddMonths(6).AddDays(-1).ToString();
                    dtpRepayStart.Text = DateTime.Now.AddDays(180).ToString();//Modified By AAM(26-10-2017)
                }
                else if (indx == 3)
                {
                    //dtpRepayStart.Text = DateTime.Now.AddMonths(12).AddDays(-1).ToString();
                    dtpRepayStart.Text = DateTime.Now.AddDays(360).ToString();//Modified By AAM(26-10-2017)
                }
                else
                {
                    //dtpRepayStart.Text = DateTime.Now.AddMonths(3).AddDays(-1).ToString();
                    dtpRepayStart.Text = DateTime.Now.AddDays(90).ToString();//Modified By AAM(26-10-2017)
                }

                ShowPaymentInfo(indx);
                ShowTotalInterestAmount();
                ///////////////////////////////           
                nextyearRentalChgRate1 = CXCLE00002.Instance.GetScalarObject<decimal>("RateFile.AccountClose.Select", new object[] { "HPNYRCHGRATE1", true });
                gapPeriod = Convert.ToInt32(CXCLE00002.Instance.GetScalarObject<decimal>("RateFile.AccountClose.Select", new object[] { "GAPPERIOD", true }));

                if (indx != 0)
                {
                    int paymentOpt = 12 / NoofMonth;
                    int noOfTerms = Convert.ToInt32(txtPaymentDuration.Text) / NoofMonth;
                    txtNextYrRC.Text = "0.00";
                    //if (noOfTerms <= paymentOpt)
                    //{
                    //    txtNextYrRC.Text = "0.00";
                    //}
                    //else if (noOfTerms % paymentOpt == 0 || (noOfTerms % paymentOpt) * 2 > paymentOpt)
                    //    txtNextYrRC.Text = rentalChgRate.ToString();

                    //else txtNextYrRC.Text = nextyearRentalChgRate1.ToString();
                }


                ///////////////////////////////

                //txtDisburseAmountEncode.Visible = true; // Comment By AAM (06-Feb-2018)
            }
        }

        private void txtDisburseAmt_KeyDown(object sender, KeyEventArgs e)
        {
            if( (e.KeyCode == Keys.Delete) || (e.KeyCode == Keys.Back))
            {
                txtDisburseAmt.Text = "";
                txtDisburseAmountEncode.Text = "";
                txtDisburseAmt.Visible = false;
                txtDisburseAmountEncode.Visible = true;
                txtDisburseAmountEncode.Focus();
            }
        }
    }
}   
