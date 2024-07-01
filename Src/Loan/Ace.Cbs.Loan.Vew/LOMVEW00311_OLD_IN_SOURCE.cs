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
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00311 : BaseDockingForm, ILOMVEW00311
    {
        #region Controller

        private ILOMCTL00311 controller;
        public ILOMCTL00311 Controller
        {
            get { return this.controller; }
            set { this.controller = value; this.controller.View = this; }
        }

        #endregion

        #region Constructor

        public LOMVEW00311()
        {
            InitializeComponent();
        }

        #endregion

        #region Control Properties
        int NoofMonth;
        //public bool IsLateFee
        //{
        //    get { return this.chkPenalFee.Checked; }
        //    set { this.chkPenalFee.Checked = value; }
        //}
        public string bindProduct;

        public bool IsScharge
        {
            get { return this.chkServiceCharges.Checked; }
            set { this.chkServiceCharges.Checked = value; }
        }

        public string CurrencyCode
        {
            get
            {
                if (this.cboCurrency.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboCurrency.SelectedValue.ToString();
                }
            }
            set { this.cboCurrency.SelectedValue = value; }
        }

        private string formname;
        public string FormName
        {
            get { return this.formname; }
            set { this.formname = value; }
        }


        public string LoanNo
        {
            get { return this.txtLoanNo.Text.Trim(); }
            set { this.txtLoanNo.Text = value.Trim(); }
        }


        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text.Trim(); }
            set { this.mtxtAccountNo.Text = value.Trim(); }
        }

        public string Rate
        {
            get { return this.txtRate.Text; }
            set { this.txtRate.Text = value; }
        }

        //Updated by HWKO (02-Oct-2017)
        public string NYIntRate
        {
            get { return this.txtNYIntRate.Text; }
            set { this.txtNYIntRate.Text = value; }
        }

        public string GracePeriod
        {
            get { return this.txtGracePeriod.Text; }
            set { this.txtGracePeriod.Text = value; }
        }

        //public string TypeOfProduct
        //{
        //    get
        //    {
        //        if (this.cboTypeOfProduct.SelectedValue == null)
        //        {
        //            return string.Empty;
        //        }
        //        else
        //        {
        //            return this.cboTypeOfProduct.SelectedValue.ToString();
        //        }
        //    }
        //    set
        //    {
        //        this.cboTypeOfProduct.SelectedValue = value;
        //    }
        //}

        //public string TypeOfAdvance
        //{
        //    get
        //    {
        //        if (this.cboTypeOfAdvance.SelectedValue == null)
        //        {
        //            return string.Empty;
        //        }
        //        else
        //        {
        //            return this.cboTypeOfAdvance.SelectedValue.ToString();
        //        }
        //    }
        //    set
        //    {
        //        this.cboTypeOfAdvance.SelectedValue = value;
        //    }
        //}

        public string TypeOfBusiness
        {
            get
            {
                if (this.mcboTypeOfBusiness.SelectedValue == null)
                {
                    return string.Empty;
                }
                else
                {
                    return this.mcboTypeOfBusiness.SelectedValue.ToString();
                }
            }
            set
            {
                this.mcboTypeOfBusiness.SelectedValue = value;
            }
        }

        public string AssessorName
        {
            get { return this.txtAssessorName.Text; }
            set { this.txtAssessorName.Text = value; }
        }

        public string LawerName
        {
            get { return this.txtLawerName.Text; }
            set { this.txtLawerName.Text = value; }
        }

        public decimal MonthlyIncome
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtMonthlyIncome.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtMonthlyIncome.Text = value.ToString(); }
        }


        public string MonthlyRepaymentDate
        {
            get { return this.txtMonthlyRepaymentDate.Text; }
            set { this.txtMonthlyRepaymentDate.Text = value; }
        }

        public string ProductType
        {
            get
            {
                if (this.radioListBox1.SelectedItem == null)
                {
                    return string.Empty;
                    
                }
                else 
                {
                    return this.radioListBox1.SelectedItem.ToString();
                }
            }
            set { this.radioListBox1.SelectedValue = value; }
        }

        public string CompanyName
        {
            get { return this.txtCompanyName.Text; }
            set { this.txtCompanyName.Text = value; }
        }

        public decimal DocumentationFee
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtDocumentFees.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtDocumentFees.Text = value.ToString(); }
        }

        public DateTime ExpireDate
        {
            get { return this.dtpExpireDate.Value; }
            set { this.dtpExpireDate.Value = value; }
        }

        public decimal SanctionAmount
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtSanctionAmount.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtSanctionAmount.Text = value.ToString(); }
        }

        public DateTime ExpiredDate
        {
            get { return this.dtpExpireDate.Value; }
            set { this.dtpExpireDate.Value = value; }
        }

        public string GuarantorCompanyName
        {
            get { return this.txtGuarantorCompanyName.Text; }
            set { this.txtGuarantorCompanyName.Text = value; }
        }

        public string GuarantorName
        {
            get { return this.txtGuarantorName.Text; }
            set { this.txtGuarantorName.Text = value; }
        }

        public string GuarantorNrc
        {
            get { return this.txtGuarantorNrc.Text; }
            set { this.txtGuarantorNrc.Text = value; }
        }

        public string GuarantorPhone
        {
            get { return this.txtGuarantorPhone.Text; }
            set { this.txtGuarantorPhone.Text = value; }
        }

        public int RepaymentDuration
        {
            set
            {
                this.txtRepaymentDuration.Text = Convert.ToString(value);
            }
            get
            {
                int result = 0;
                Int32.TryParse(this.txtRepaymentDuration.Text, out result);
                return result;
            }
        }

        public int RepaymentPeriod
        {
            set
            {
                this.cboRepayment.SelectedValue = value;
            }
            get
            {

                return NoofMonth == null?0:NoofMonth;
                //if (this.cboRepayment.SelectedValue == null)
                //{
                //    return 0;

                //}
                //else
                //{
                //    int result = 0;
                //    Int32.TryParse(this.cboRepayment.SelectedValue.ToString(), out result);
                //    return result;
                //}
            }
        }

        //public int Duration
        //{
        //    set
        //    {
        //        this.txtPenalDuration.Text = Convert.ToString(value);
        //    }
        //    get
        //    {
        //        int result = 0;
        //        Int32.TryParse(this.txtPenalDuration.Text, out result);
        //        return result;
        //    }
        //}

        public string RepaymentOption
        {
            get
            {
                return NoofMonth == null ? "0" : NoofMonth.ToString();
                //if (this.cboRepayment.SelectedValue == null)
                //{
                //    return null;
                //}
                //else
                //{
                //    return this.cboRepayment.SelectedValue.ToString();
                //}
            }
            set
            {
                this.cboRepayment.SelectedValue =Convert.ToInt32( value);
            }
        }

        public string Repay
        {
            get { return null; }
            set
            {
                this.cboRepayment.Text = value;
                //this.cboProductType.SelectedValue = value;
            }
        }

        public int RepayOption
        {
            get { return NoofMonth==null?0:NoofMonth; }
            set { this.cboRepayment.SelectedValue = value; }
        }

        IList<LOMDTO00001> TypeOfBusinessList { get; set; }

        IList<LOMDTO00101> SubProductTypeList { get; set; }

        public bool isSaveValidate { get; set; }
        public bool flag { get; set; }
        public bool isCancelExit { get; set; }
        public bool isEdit { get; set; }
        public bool isActive { get; set; }
        public bool found { get; set; }
        string firstAmount;
        private decimal penal_amount { get; set; }
        private decimal sAmt { get; set; }
        int isSaveSuccess = 0;
        #endregion

        #region Methods

        //public void BindTypeOfAdvance()
        //{
        //    IList<LOMDTO00002> TypeOfAdvanceList = CXCLE00002.Instance.GetListObject<LOMDTO00002>("LOMORM00002.SelectAllAdvanceType", new object[] { true });
        //    this.cboTypeOfAdvance.ValueMember = "Description";
        //    this.cboTypeOfAdvance.DisplayMember = "Description";
        //    this.cboTypeOfAdvance.DataSource = TypeOfAdvanceList;
        //    this.cboTypeOfAdvance.SelectedIndex = -1;
        //}

        public void BindTypeOfBusiness()
        {
            TypeOfBusinessList = CXCLE00002.Instance.GetListObject<LOMDTO00001>("LOMORM00001.SelectAllBusinessType", new object[] { true });
            this.mcboTypeOfBusiness.ValueMember = "Code";
            this.mcboTypeOfBusiness.DisplayMember = "Code";
            this.mcboTypeOfBusiness.ColumnNames = "Code,Description";
            this.mcboTypeOfBusiness.DataSource = TypeOfBusinessList;
            this.mcboTypeOfBusiness.SelectedIndex = -1;
        }

        public void BindsubProductType()
        {
            SubProductTypeList = CXCLE00002.Instance.GetListObject<LOMDTO00101>("LOMORM00101.SelectAllSubProductType", new object[] { true });
            List<string> subProductType = SubProductTypeList.Select(x => x.Description).Distinct().ToList();
            string productType = "";
            for (int i = 0; i < subProductType.Count; i++)
            {
                if (i == 0)
                {
                    productType = subProductType[i] ;
                }
                else
                {
                    productType = productType + "," + subProductType[i];
                }
            }
            this.radioListBox1.Items.Clear();
            this.radioListBox1.Items.AddRange(productType.Split(new char[] { ',' }));
            this.radioListBox1.SelectedIndex = -1;
        }
        
        public void BindAccountInfo(IList<PFMDTO00072> accountInfoList)
        {
            this.gdvAccountInfo.AutoGenerateColumns = false;
            this.gdvAccountInfo.DataSource = null;
            this.gdvAccountInfo.CausesValidation = false;
            this.gdvAccountInfo.DataSource = accountInfoList;
            this.lblNameOfFirm2.Visible = true;
            this.lblNameOfFirm2.Text = (accountInfoList[0].BankAccountDescription == "") ? " - " :
                                        accountInfoList[0].BankAccountDescription;//For Name of Firm in Company Account,Association and etc;
        }

        //public void BindPeanlFee(IList<LOMDTO00012> penalList)
        //{
        //    this.gdvPenalFee.AutoGenerateColumns = false;
        //    this.gdvPenalFee.DataSource = null;
        //    //this.gdvLoanInterest.CausesValidation = false;
        //    this.gdvPenalFee.DataSource = penalList;
        //}

        //public void BindLoanProduct()
        //{
        //    IList<LOMDTO00014> TypeOfProductList = CXCLE00002.Instance.GetListObject<LOMDTO00014>("LOMORM00014.SelectAllLandType", new object[] { true });
        //    this.cboTypeOfProduct.ValueMember = "LOANS_TYPE";
        //    this.cboTypeOfProduct.DisplayMember = "LOANSDESP";
        //    this.cboTypeOfProduct.DataSource = TypeOfProductList;
        //    this.cboTypeOfProduct.SelectedIndex = -1;
        //}

        public void BindInstallmentPeriod()
        {
            IList<LOMDTO00055> TypeOfInstallmentList = CXCLE00002.Instance.GetListObject<LOMDTO00055>("LOMORM00100.SelectAllInstallmentPeriod", new object[] { true });
            TypeOfInstallmentList = TypeOfInstallmentList.Where(t => t.NAME.Equals("Monthly")).ToList();
            this.cboRepayment.ValueMember = "NOOFMONTH";
            this.cboRepayment.DisplayMember = "NAME";
            this.cboRepayment.DataSource = TypeOfInstallmentList;
            this.cboRepayment.Refresh();
            this.cboRepayment.SelectedIndex = 0;
            NoofMonth = TypeOfInstallmentList[0].NOOFMONTH;
        }

        private void BindCurrency()
        {
            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
            cboCurrency.SelectedIndex = 0;
        }

        //Validation For UI Validation
        private bool ControlValidation()
        {
            // bool flag = true ;

            #region Common Personal Loan Registration Controls Validation

            if (String.IsNullOrEmpty(this.AccountNo))
            {
                this.mtxtAccountNo.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(this.AssessorName))
            {
                this.txtAssessorName.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(this.LawerName))
            {
                this.txtLawerName.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(this.TypeOfBusiness))
            {
                this.mcboTypeOfBusiness.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(this.MonthlyIncome.ToString()))
            {
                this.txtMonthlyIncome.Focus();
                return false;
            }
            else if (this.radioListBox1.SelectedItem.ToString() == "Myanmar Net Customer")
            {
                if (String.IsNullOrEmpty(this.MonthlyRepaymentDate.ToString()))
                {
                    this.txtMonthlyRepaymentDate.Focus();
                    return false;
                }
            }
            else if (String.IsNullOrEmpty(this.CompanyName.ToString()))
            {
                this.txtCompanyName.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(this.CurrencyCode))
            {
                this.cboCurrency.Focus();
                return false;
            }

            #endregion

            #region Guarantee
            if (String.IsNullOrEmpty(this.GuarantorCompanyName))
            {
                // CXUIMessageUtilities.ShowMessageByCode("MV00046");
                this.txtGuarantorCompanyName.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(this.GuarantorName))
            {
                // CXUIMessageUtilities.ShowMessageByCode("MV00046");
                this.txtGuarantorName.Focus();
                return false;
            }
            //if (String.IsNullOrEmpty(this.GuarantorNrc))
            //{
            //    // CXUIMessageUtilities.ShowMessageByCode("MV00046");
            //    this.cboKindOfStock.Focus();
            //    return false;
            //}
            //else if (String.IsNullOrEmpty(this.GuarantorPhone))
            //{
            //    //  CXUIMessageUtilities.ShowMessageByCode("MV00046");
            //    this.txtGuarantorPhone.Focus();
            //    return false;
            //}

            #endregion

            #region Interest

            if (String.IsNullOrEmpty(this.Rate))
            {
                this.txtRate.Focus();
                return false;
            }
            if (this.txtNYIntRate.Visible == true)
            {
                if (String.IsNullOrEmpty(this.NYIntRate))
                {
                    this.txtNYIntRate.Focus();
                    return false;
                }
            }
            if (String.IsNullOrEmpty(this.GracePeriod))
            {
                this.txtGracePeriod.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(this.RepaymentDuration.ToString()))
            {
                this.cboRepayment.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(this.RepaymentPeriod.ToString()))
            {
                this.txtRepaymentPeriod.Focus();
                return false;
            }
            //My update 2017
            //else if (this.gdvLoanInterest.DataSource == null)
            //{
            //    //CXUIMessageUtilities.ShowMessageByCode("MV00046");
            //    this.gdvLoanInterest.Focus();
            //    return false;
            //}


            #endregion

            #region SanctionAmount


            if (!String.IsNullOrEmpty(this.SanctionAmount.ToString()) && this.SanctionAmount == decimal.Zero)
            {
                //CXUIMessageUtilities.ShowMessageByCode("MV00046");
                this.txtSanctionAmount.Focus();
                return false;
            }

            #endregion

            #region Penal Fee

            //if (this.chkPenalFee.Checked)
            //{
            //    if (String.IsNullOrEmpty(this.txtPenalDuration.Text))
            //    {
            //        this.txtPenalDuration.Focus();

            //        return false;
            //    }
            //    foreach (DataGridViewRow row in gdvPenalFee.Rows)
            //    {
            //        if ((Convert.ToString(row.Cells["colStartPeriod"].Value) != "") ||
            //         (row.Cells["colStartPeriod"].Value != null) ||
            //     (Convert.ToString(row.Cells["colEndPeriod"].Value) != "") ||
            //         (row.Cells["colEndPeriod"].Value != null) ||
            //     (Convert.ToString(row.Cells["colPenalFee"].Value) != "") ||
            //         (row.Cells["colPenalFee"].Value != null) ||
            //     (Convert.ToString(row.Cells["colAmount"].Value) != "") ||
            //         (row.Cells["colAmount"].Value != null))
            //        {
            //            return true;
            //        }
            //    }

            //}

            #endregion

            return true;
        }

        public void ClearFormControls()
        {
            //  this.txtLoanNo.Text = string.Empty;
            this.mtxtAccountNo.Text = string.Empty;
            this.cboCurrency.SelectedIndex = 0;
            //this.cboTypeOfAdvance.SelectedIndex = -1;
            this.mcboTypeOfBusiness.SelectedIndex = -1;
            this.txtAssessorName.Text = string.Empty;
            this.txtLawerName.Text = string.Empty;
            this.txtMonthlyIncome.Text = string.Empty;
            this.txtMonthlyRepaymentDate.Text = string.Empty;
            this.radioListBox1.SelectedItem = "Normal Customer";
            this.txtCompanyName.Text = string.Empty;

            this.txtDocumentFees.Text = string.Empty;

            this.chkEditDocFee.Checked = false;
            this.chkEdit.Checked = false;
            this.chkEditGP.Checked = false;
            this.chkEditNYIR.Checked = false;

            this.txtGuarantorName.Text = string.Empty;
            this.txtGuarantorNrc.Text = string.Empty;
            this.txtGuarantorPhone.Text = string.Empty;
            this.txtGuarantorCompanyName.Text = string.Empty;

            this.gdvAccountInfo.DataSource = null;
            this.gdvAccountInfo.Rows.Clear();

            //My update 2017
            //this.gdvLoanInterest.DataSource = null;
            //this.gdvLoanInterest.Rows.Clear();

            //this.gdvPenalFee.DataSource = null;
            //this.gdvPenalFee.Rows.Clear();

            //this.cboRepayment.SelectedIndex = -1 ;
            this.txtRepaymentDuration.Text = string.Empty;
            this.txtRepaymentPeriod.Text = string.Empty;

            this.txtSanctionAmount.Text = string.Empty;
            this.chkServiceCharges.Checked = false;

            //this.txtPenalDuration.Text = string.Empty;
            this.cboRepayment.SelectedIndex = -1;
            this.lblTypeOfBusiness2.Visible = false;

            //////
            txtLoanNo.Text = string.Empty;
            cboCurrency.Text = string.Empty;
            mcboTypeOfBusiness.Text = string.Empty;
            txtRate.Text = string.Empty;
            txtGracePeriod.Text = string.Empty;

        }

        public void ClearBindingControls()
        {            
            //this.mtxtAccountNo.Text = string.Empty;
            this.cboCurrency.SelectedIndex = 0;            
            this.mcboTypeOfBusiness.SelectedIndex = -1;
            this.txtAssessorName.Text = string.Empty;
            this.txtLawerName.Text = string.Empty;
            this.txtMonthlyIncome.Text = string.Empty;
            this.txtMonthlyRepaymentDate.Text = string.Empty;
            this.radioListBox1.SelectedItem = "Normal Customer";
            this.txtCompanyName.Text = string.Empty;

            this.txtDocumentFees.Text = string.Empty;

            this.chkEditDocFee.Checked = false;
            this.chkEdit.Checked = false;
            this.chkEditGP.Checked = false;
            this.chkEditNYIR.Checked = false;

            this.txtGuarantorName.Text = string.Empty;
            this.txtGuarantorNrc.Text = string.Empty;
            this.txtGuarantorPhone.Text = string.Empty;
            this.txtGuarantorCompanyName.Text = string.Empty;

            this.gdvAccountInfo.DataSource = null;
            this.gdvAccountInfo.Rows.Clear();
           
            this.txtRepaymentDuration.Text = string.Empty;
            this.txtRepaymentPeriod.Text = string.Empty;

            this.txtSanctionAmount.Text = string.Empty;
            this.chkServiceCharges.Checked = false;
            
            this.cboRepayment.SelectedIndex = -1;
            this.lblTypeOfBusiness2.Visible = false;

            //////
            txtLoanNo.Text = string.Empty;
            cboCurrency.Text = string.Empty;
            mcboTypeOfBusiness.Text = string.Empty;
            txtRate.Text = string.Empty;
            txtGracePeriod.Text = string.Empty;
            dtpExpireDate.Text = string.Empty;//Added by HMW (16-01-2023)
        }

        public void FillControls()
        {
            IList<LOMDTO00243> lst = this.controller.Get_PLInfoRegisterEdit_ByAcctNo(AccountNo, CurrentUserEntity.BranchCode);
            if (lst.Count > 0)
            {
                txtLoanNo.Text = lst[0].PLNo;
                txtAssessorName.Text = lst[0].Assessor;
                txtLawerName.Text = lst[0].Lawer;
                mcboTypeOfBusiness.Text = lst[0].BUSIDESP;
                txtMonthlyIncome.Text = lst[0].MonthlyIncome.ToString();
                txtMonthlyRepaymentDate.Text = lst[0].MonthlyRepayDate.ToString();
                radioListBox1.SelectedItem = lst[0].ProductType.ToString();
                txtCompanyName.Text = lst[0].CompanyName;
                txtDocumentFees.Text = lst[0].DocFee.ToString();
                cboCurrency.Text = lst[0].Cur;
                //gdvAccountInfo.Rows[1].Cells["Name"].Value = lst[0].CustName;
                //gdvAccountInfo.Rows[1].Cells["Nrc"].Value = lst[0].CustNRC;
                txtGuarantorCompanyName.Text = lst[0].GuaCompanyName;
                txtGuarantorName.Text = lst[0].GuaName;
                txtGuarantorNrc.Text = lst[0].GuaNRC;
                txtGuarantorPhone.Text = lst[0].GuaPhone;
                txtSanctionAmount.Text = lst[0].SAmt.ToString();
                txtRate.Text = lst[0].IntRate.ToString();
                txtRepaymentDuration.Text = lst[0].RepDuration.ToString();
                cboRepayment.Text = lst[0].InstallName;
                dtpExpireDate.Text = lst[0].ExpireDate.ToString();
                txtGracePeriod.Text = lst[0].GracePeriod.ToString();
                cxC000324.Enabled = true;
                cxC00038.Enabled = true;

                if (txtMonthlyRepaymentDate.Text != "")
                {
                    lblMonthlyRepayDate.Visible = true;
                    txtMonthlyRepaymentDate.Visible = true;
                    txtMonthlyRepaymentDate.Enabled = false;
                    cxC000310.Visible = true;
                }
            }
            else
            {
                ClearBindingControls();                
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90235);                
            }
            this.mtxtAccountNo.Focus();
        }

        public void SetFormsControlsEdit()
        {
            grpLoanInterest.Enabled = false;
            grpSanctionAmount.Enabled = false;

            txtLoanNo.Enabled = false;
            mtxtAccountNo.Enabled = true;
            txtAssessorName.Enabled = false;
            txtLawerName.Enabled = false;
            mcboTypeOfBusiness.Enabled = false;
            txtMonthlyIncome.Enabled = false;
            this.lblMonthlyRepayDate.Enabled = false;
            txtMonthlyRepaymentDate.Enabled = false;
            radioListBox1.Enabled = false;
            txtCompanyName.Enabled = true;
            txtDocumentFees.Enabled = false;
            cboCurrency.Enabled = false;
            gdvAccountInfo.Enabled = false;
            chkEditDocFee.Enabled = false;            

            txtGuarantorCompanyName.Enabled = true;
            txtGuarantorName.Enabled = true;
            txtGuarantorNrc.Enabled = true;
            txtGuarantorPhone.Enabled = true;            
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            mtxtAccountNo.Select();

        }
        public void GetFormControlSetting()
        {
            PFMDTO00009 ratedto = new PFMDTO00009();
            PFMDTO00009 nyratedto = new PFMDTO00009();//added by HWKO (02-Oct-2017)
            PFMDTO00009 docratedto = new PFMDTO00009();
            if (this.formname.Contains("Enquiry") || this.formname.Contains("Edit"))
            {
                if (this.formname.Contains("Enquiry"))
                {
                    this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, false, true);
                    this.txtAssessorName.Enabled = false;
                    this.txtLawerName.Enabled = false;
                    this.mcboTypeOfBusiness.Enabled = false;
                    this.dtpExpireDate.Enabled = false;
                    this.mtxtAccountNo.Enabled = false;
                    this.cboCurrency.Enabled = false;
                    this.txtMonthlyIncome.Enabled = false;
                    this.lblMonthlyRepayDate.Enabled = false;
                    this.txtMonthlyRepaymentDate.Enabled = false;
                    this.radioListBox1.SelectedItem = "Normal Customer";
                    this.radioListBox1.Enabled = false;
                    this.txtCompanyName.Enabled = false;
                    this.txtDocumentFees.Enabled = false;
                    this.chkEditDocFee.Enabled = false;
                    this.chkEditNYIR.Enabled = false;
                    this.chkEditGP.Enabled = false;
                    this.chkEdit.Enabled = false;

                    //this.cboTypeOfAdvance.Enabled = false;
                    this.grpSanctionAmount.Enabled = false;
                    this.grpLoanInterest.Enabled = false;
                    this.grpGuarantorInfo.Enabled = false;
                    //this.isSaveValidate = true;   
                    this.txtLoanNo.Focus();//Added by HMW (10-02-2023)
                }
                else // Edit Form
                {
                    #region OldCode                    
                    //this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
                    //this.grpLoanInterest.Visible = true;
                    //this.grpLoanInterest.Enabled = true;
                    //txtRate.Enabled = false;
                    //this.chkEditDocFee.Enabled = true;
                    //this.chkEditNYIR.Enabled = true;
                    //this.chkEditGP.Enabled = true;
                    //this.chkEdit.Enabled = true;
                    ////this.BindAllPaymentInterval();
                    //ratedto = CXCLE00002.Instance.GetScalarObject<PFMDTO00009>("PFMORM00009.Client.SelectByCodeAndLastModify", new object[] { "PLOANSINTRATE", true, true });
                    //txtRate.Text = ratedto.Rate.ToString("N2");

                    ////Added by HWKO (02-Oct-2017)
                    //txtNYIntRate.Enabled = false;
                    //nyratedto = CXCLE00002.Instance.GetScalarObject<PFMDTO00009>("PFMORM00009.Client.SelectByCodeAndLastModify", new object[] { "PLNYINTRATE", true, true });
                    //txtNYIntRate.Text = nyratedto.Rate.ToString("N2");
                    //this.chkEditNYIR.Checked = false;

                    //this.chkEditGP.Checked = false;
                    //this.txtGracePeriod.Enabled = false;
                    //this.txtGracePeriod.Text = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.GRACEPERIOD);
                    ////End Region

                    //this.BindInstallmentPeriod();
                    //cboRepayment.Visible = true;

                    //txtDocumentFees.Enabled = false;
                    //docratedto = CXCLE00002.Instance.GetScalarObject<PFMDTO00009>("PFMORM00009.Client.SelectByCodeAndLastModify", new object[] { "DOCFEE", true, true });
                    //this.txtDocumentFees.Text = docratedto.Rate.ToString("N2");
                    //this.Start();
                    #endregion
                    SetFormsControlsEdit();
                }
            }
            else // Entry Form
            {
                this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
                this.txtLoanNo.Enabled = false;
                this.cboCurrency.Enabled = true;
                //this.cboCurrency.Focus();

                this.grpLoanInterest.Visible = true;
                this.grpLoanInterest.Enabled = true;
                txtRate.Enabled = false;
                this.chkEditDocFee.Enabled = true;
                this.chkEditNYIR.Enabled = true;
                this.chkEditGP.Enabled = true;
                this.chkEdit.Enabled = true;
                this.lblMonthlyRepayDate.Enabled = true;
                this.txtMonthlyRepaymentDate.Enabled = true;
                //this.BindAllPaymentInterval();
                ratedto = CXCLE00002.Instance.GetScalarObject<PFMDTO00009>("PFMORM00009.Client.SelectByCodeAndLastModify", new object[] { "PLOANSINTRATE", true, true });
                txtRate.Text = ratedto.Rate.ToString("N2");

                //Added by HWKO (02-Oct-2017)
                txtNYIntRate.Enabled = false;
                nyratedto = CXCLE00002.Instance.GetScalarObject<PFMDTO00009>("PFMORM00009.Client.SelectByCodeAndLastModify", new object[] { "PLNYINTRATE", true, true });
                txtNYIntRate.Text = nyratedto.Rate.ToString("N2");
                this.chkEditNYIR.Checked = false;

                this.txtGracePeriod.Enabled = false;
                this.txtGracePeriod.Text = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.GRACEPERIOD);
                this.chkEditGP.Checked = false;
                //End Region

                this.BindInstallmentPeriod();
                cboRepayment.Visible = true;

                txtDocumentFees.Enabled = false;
                docratedto = CXCLE00002.Instance.GetScalarObject<PFMDTO00009>("PFMORM00009.Client.SelectByCodeAndLastModify", new object[] { "DOCFEE", true, true });
                this.txtDocumentFees.Text = docratedto.Rate.ToString("N2");

                this.Start();

                #region PenalFee
                //this.chkPenalFee.Checked = false;
                //this.txtPenalDuration.Enabled = false;
                //this.gdvPenalFee.Enabled = false;

                #endregion

                this.lblTypeOfBusiness2.Visible = false;
                this.lblNameOfFirm2.Visible = false;

                #region Interest and Repayment
                this.grpLoanInterest.Enabled = true;
                this.grpLoanInterest.Visible = true;

                #endregion

                //this.cboCurrency.Focus();
                this.mtxtAccountNo.Focus();
            }

            //this.BindTypeOfAdvance();
            this.BindTypeOfBusiness();
            this.BindsubProductType();
            this.radioListBox1.SelectedItem = "Normal Customer";
            this.lblMonthlyRepayDate.Visible = false;
            this.lblMonthlyRepayDate.Enabled = false;
            this.txtMonthlyRepaymentDate.Visible = false;
            this.txtMonthlyRepaymentDate.Enabled = false;
            this.cxC000310.Visible = false;
            this.cxC000310.Enabled = false;
            this.BindCurrency();
            this.BindInstallmentPeriod();
            //  this.dtpExpireDate.Value = DateTime.Now.AddYears(1);
            this.lblSanctionDate2.Text = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            //this.mtxtGuaranterAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.mtxtAccountNo.Focus();
        }

        public void BindPersonalLoanToView(LOMDTO00311 ploanDto)
        {
            this.AccountNo = ploanDto.ACNo;
            this.CurrencyCode = ploanDto.Cur;
            this.AssessorName = ploanDto.Assessor;
            this.LawerName = ploanDto.Lawer;
            this.TypeOfBusiness = ploanDto.BType;
            this.MonthlyIncome = Convert.ToDecimal(ploanDto.MonthlyIncome);
            this.MonthlyRepaymentDate = ploanDto.MonthlyRepayDate;
            this.radioListBox1.SelectedItem = ploanDto.ProductType;
            this.CompanyName = ploanDto.CompanyName;
            this.DocumentationFee = Convert.ToDecimal(ploanDto.DocFee);
            this.GuarantorCompanyName = ploanDto.PL_GuanDto.COMPANYNAME;
            this.GuarantorName = ploanDto.PL_GuanDto.NAME;
            this.GuarantorNrc = ploanDto.PL_GuanDto.NRC;
            this.GuarantorPhone = ploanDto.PL_GuanDto.PHONE;
            this.SanctionAmount = Convert.ToDecimal(ploanDto.SAmt);
            if (Convert.ToBoolean(ploanDto.isSCharge))
            {
                this.chkServiceCharges.Checked = true;
            }
            this.Rate = Convert.ToDecimal(ploanDto.IntRate).ToString("N2");
            this.NYIntRate = Convert.ToDecimal(ploanDto.NYIntRate).ToString("N2");//Added by HWKO (02-Oct-2017)
            this.GracePeriod = ploanDto.GPeriod.ToString();//Added by HWKO (02-Oct-2017)
            this.RepaymentDuration = Convert.ToInt16(ploanDto.RepDuration);

            IList<LOMDTO00055> TypeOfInstallmentList = CXCLE00002.Instance.GetListObject<LOMDTO00055>("LOMORM00100.SelectAllInstallmentPeriod", new object[] { true });
            LOMDTO00055 SelectedInstallmentType = TypeOfInstallmentList.Where(x => x.Id.Equals(ploanDto.RepOption)).SingleOrDefault();
            this.RepaymentOption = SelectedInstallmentType.NOOFMONTH.ToString();
            this.RepayOption = SelectedInstallmentType.Id;
            
            this.ExpireDate = Convert.ToDateTime(ploanDto.ExpireDate);
            this.controller.CheckPersonalLoanAccountNo(ploanDto.ACNo, this.formname);
        }

        #endregion

        #region Get ViewData To Save

        //public IList<LOMDTO00012> GetPenalFeeList()
        //{
        //    //get
        //    //{
        //    IList<LOMDTO00012> getPenalFeeList = new List<LOMDTO00012>();
        //    foreach (DataGridViewRow row in this.gdvPenalFee.Rows)
        //    {
        //        if ((Convert.ToString(row.Cells["colStartPeriod"].Value) != "") &&
        //                (row.Cells["colStartPeriod"].Value != null) &&
        //            (Convert.ToString(row.Cells["colEndPeriod"].Value) != "") &&
        //                (row.Cells["colEndPeriod"].Value != null) &&
        //            (Convert.ToString(row.Cells["colPenalFee"].Value) != "") &&
        //                (row.Cells["colPenalFee"].Value != null) &&
        //             (Convert.ToString(row.Cells["colAmount"].Value) != "") &&
        //                (row.Cells["colAmount"].Value != null))
        //        {
        //            LOMDTO00012 penalDto = new LOMDTO00012();

        //            penalDto.StartDay = Convert.ToInt32(row.Cells["colStartPeriod"].Value);
        //            penalDto.EndDay = Convert.ToInt32(row.Cells["colEndPeriod"].Value);
        //            penalDto.Fee = Convert.ToInt32(row.Cells["colPenalFee"].Value);
        //            penalDto.Amount = Convert.ToInt32(row.Cells["colAmount"].Value);
        //            //penalDto.Lno = this.LoanNo;
        //            penalDto.Duration = this.Duration;
        //            penalDto.CreatedDate = DateTime.Now;
        //            penalDto.CreatedUserId = CurrentUserEntity.CurrentUserID;
        //            getPenalFeeList.Add(penalDto);
        //        }

        //    }

        //    return getPenalFeeList;
        //    //}
        //    //set { this.getPenalFeeList = value; }
        //}

        private LOMDTO00311 getViewDataForCommon;
        public LOMDTO00311 GetViewDataForCommon
        {
            get
            {
                if (this.getViewDataForCommon == null) getViewDataForCommon = new LOMDTO00311();
                getViewDataForCommon.ACNo = this.AccountNo;
                getViewDataForCommon.PLNo = this.LoanNo;
                getViewDataForCommon.Lawer = this.LawerName;
                getViewDataForCommon.Assessor = this.AssessorName;
                getViewDataForCommon.ExpireDate = this.ExpiredDate;
                getViewDataForCommon.SDate = DateTime.Now;
                getViewDataForCommon.BType = this.TypeOfBusiness;
                getViewDataForCommon.IntRate = Convert.ToDecimal(this.Rate);
                getViewDataForCommon.NYIntRate = Convert.ToDecimal(this.NYIntRate);//Added by HWKO (02-Oct-2017)
                getViewDataForCommon.GPeriod = Convert.ToInt32(this.GracePeriod);//Added by HWKO (02-Oct-2017)
                getViewDataForCommon.FirstSAmt = this.SanctionAmount;
                getViewDataForCommon.SAmt = this.SanctionAmount;
                //getViewDataForCommon.LegalCase = false;
                //getViewDataForCommon.NPLCase = false;
                //getViewDataForCommon.Vouchered = false;
                getViewDataForCommon.ACSign = this.controller.Acsign;
                getViewDataForCommon.SourceBr = this.controller.BranchCode;
                getViewDataForCommon.Cur = this.CurrencyCode;
                getViewDataForCommon.UserNo = CurrentUserEntity.CurrentUserID.ToString();
                getViewDataForCommon.CreatedDate = DateTime.Now;
                getViewDataForCommon.CreatedUserId = CurrentUserEntity.CurrentUserID;

                if (this.chkServiceCharges.Checked)//To get Service Charges or NOt
                {
                    PFMDTO00009 ratedto = new PFMDTO00009();

                    ratedto = CXCLE00002.Instance.GetScalarObject<PFMDTO00009>("PFMORM00009.Client.SelectByCodeAndLastModify", new object[] { "PLSCHGRATE", true, true });

                    getViewDataForCommon.isSCharge = true;
                    getViewDataForCommon.SCharges = this.SanctionAmount * (ratedto.Rate / 100);

                }

                else
                { getViewDataForCommon.isSCharge = false; }

                //if (this.chkPenalFee.Checked)//To get PenalFee Charges or NOt
                //{ 
                getViewDataForCommon.isLateFee = true;
                //}
                //else
                //{ getViewDataForCommon.isLateFee = false; }

                //getViewDataForCommon.Charges_Status = string.Empty;
                //getViewDataForCommon.BalStatus = "UsedBal";
                getViewDataForCommon.RepaymentDuration = this.RepaymentDuration;
                getViewDataForCommon.RepaymentPeriod = this.RepaymentPeriod;
                getViewDataForCommon.RepaymentOption = this.RepaymentOption;
                getViewDataForCommon.MonthlyIncome = this.MonthlyIncome;
                getViewDataForCommon.MonthlyRepayDate = this.MonthlyRepaymentDate;
                getViewDataForCommon.ProductType = this.ProductType;
                getViewDataForCommon.CompanyName = this.CompanyName;
                getViewDataForCommon.DocFee = this.DocumentationFee;

                return getViewDataForCommon;
            }

            set { this.getViewDataForCommon = value; }
        }

        private LOMDTO00313 getViewDataForGuarantee;
        public LOMDTO00313 GetViewDataForGuarantee
        {
            get
            {
                if (getViewDataForGuarantee == null) getViewDataForGuarantee = new LOMDTO00313();

                getViewDataForGuarantee.PLNo = this.LoanNo;
                getViewDataForGuarantee.SourceBr = this.controller.BranchCode.Trim();
                getViewDataForGuarantee.Cur = this.CurrencyCode;
                getViewDataForGuarantee.COMPANYNAME = this.GuarantorCompanyName;
                getViewDataForGuarantee.NAME = this.GuarantorName;
                getViewDataForGuarantee.NRC = this.GuarantorNrc;
                getViewDataForGuarantee.PHONE = this.GuarantorPhone;
                getViewDataForGuarantee.CreatedDate = DateTime.Now;
                getViewDataForGuarantee.CreatedUserId = CurrentUserEntity.CurrentUserID;

                return getViewDataForGuarantee;
            }
            set { this.getViewDataForGuarantee = value; }

        }


        #endregion

        #region Events

        private void LOMVEW00311_Load(object sender, EventArgs e)
        {
            #region Old_Logic
            /*
            if (this.formname.Contains("Entry"))
            {
                this.txtLoanNo.ReadOnly = true;
                this.txtLoanNo.Text = string.Empty;
                this.cboCurrency.Focus();
                Start();
            }
            else
            {
                //this.txtLoanNo.ReadOnly = false;
                this.txtLoanNo.Text = string.Empty;
                this.txtLoanNo.Focus();
            }
            //this.txtLoanNo.ReadOnly = true;
            //this.txtLoanNo.Text = string.Empty;
            //this.cboCurrency.Focus();
            this.Text = this.formname;
            this.GetFormControlSetting();
            this.isSaveValidate = false;
            this.flag = false;
            cboRepayment.Visible = true;
            */
            #endregion

            #region Seperating_EOD_Logic (By HMW at 29-07-2019)
            DateTime systemDate = this.controller.GetSystemDate(CurrentUserEntity.BranchCode.Trim());
            DateTime lastSettlementDate = this.controller.GetLastSettlementDate(CurrentUserEntity.BranchCode.Trim());
            this.lblTransactionDate.Text = systemDate.ToString("dd-MM-yyyy");

            //if (systemDate.ToString("dd-MM-yyyy") != lastSettlementDate.ToString("dd-MM-yyyy")) //Show Form
            //{
                if (this.formname.Contains("Entry"))
                {
                    this.txtLoanNo.ReadOnly = true;
                    this.txtLoanNo.Text = string.Empty;
                    this.cboCurrency.Focus();
                    this.mtxtAccountNo.Select();
                    Start();
                }
                else//Enquiry
                {
                    this.txtLoanNo.Text = string.Empty;
                    this.txtLoanNo.Select();//Updated by HMW (10-02-2023)
                }
                this.Text = this.formname;
                this.GetFormControlSetting();
                this.isSaveValidate = false;
                this.flag = false;
                cboRepayment.Visible = true;
                
            //}
            //else //Don't show form after cut off
            //{
            //    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI50013);//You have no permission.\n"Back Date EOD Process" needs to be completed!
            //    this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
            //    //this.InitializeControls();
            //    this.DisableControls("PLRegister.AllDisable");
            //}
            #endregion
        }


        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.flag = true;
            this.isCancelExit = true;
            this.isEdit = false;

            this.ClearFormControls();
            this.controller.ClearAllCustomErrors();

            if (this.formname.Contains("Entry"))
            {
                this.txtLoanNo.ReadOnly = true;
                this.txtLoanNo.Text = string.Empty;
                this.Text = this.formname;
                this.GetFormControlSetting();
                this.isSaveValidate = false;
                this.flag = false;
                cboRepayment.Visible = true;
                cboCurrency.Enabled = true;
                mtxtAccountNo.Enabled = true;
                txtAssessorName.Enabled = true;
                txtLawerName.Enabled = true;
                mcboTypeOfBusiness.Enabled = true;
                this.cboCurrency.Focus();
            }
            else
            {
                this.txtLoanNo.Text = "";
                txtLoanNo.Focus();
                this.Text = this.formname;
                if (this.FormName.Contains("Enquiry"))
                {
                    this.txtRate.Text = string.Empty;
                    this.txtNYIntRate.Text = string.Empty;
                    this.txtGracePeriod.Text = string.Empty;
                    this.dtpExpireDate.Value = DateTime.Now;
                }
            }

        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (this.formname.Contains("Edit"))
            {
                string str = this.controller.Save_PLInfoRegisterEdit_ByAcctNo(AccountNo, CurrentUserEntity.BranchCode.Trim(), CompanyName, GuarantorCompanyName
                                                , GuarantorName, GuarantorNrc, GuarantorPhone,CurrentUserEntity.CurrentUserID);

                if (str != "0") MessageBox.Show("Invalid Account No!");
                else
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90136);
                    ClearFormControls();
                    mtxtAccountNo.Focus();
                    //txtLoanNo.Text = string.Empty;
                    //cboCurrency.Text = string.Empty;
                    //mcboTypeOfBusiness.Text = string.Empty;
                    //txtRate.Text = string.Empty;
                    //txtGracePeriod.Text = string.Empty;
                }
                return; 
            }
            else
            {
                this.isSaveValidate = true;

                if (!this.controller.CheckPersonalLoanAccountNo(this.AccountNo, this.formname))
                    this.mtxtAccountNo.Text = string.Empty;
                else
                {
                    if (this.ControlValidation())
                    {
                        this.controller.Save(CurrentUserEntity.BranchCode.Trim());
                        this.isSaveValidate = false;
                        this.flag = true;
                        ClearFormControls();
                        mtxtAccountNo.Focus();

                        this.txtLoanNo.Text = "";
                        if (!this.formname.Contains("Enquiry")) // For Entry And Edit
                        {
                            this.mtxtAccountNo.Enabled = true;
                            cboRepayment.Visible = true;
                            cboCurrency.Enabled = true;
                            mtxtAccountNo.Enabled = true;
                            txtAssessorName.Enabled = true;
                            txtLawerName.Enabled = true;
                            mcboTypeOfBusiness.Enabled = true;
                            this.txtSanctionAmount.Enabled = true;
                            if (this.formname.Contains("Edit"))
                            {
                                txtLoanNo.Enabled = true;
                                txtLoanNo.Focus();
                            }
                            else
                            {
                                this.GetFormControlSetting();
                                //cboCurrency.Focus();
                                mtxtAccountNo.Focus();
                                isSaveSuccess = 1;
                            }
                        }
                        this.flag = false;
                    }
                    else
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MV90067"); //Incomplete data to save !
                        this.isSaveValidate = false;
                    }
                }
            }
        }

        private void chkEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEdit.Checked == true)
            {
                txtRate.Enabled = true;
                txtRate.Focus();
            }
            else
            {
                txtRate.Enabled = false;
                PFMDTO00009 ratedto = new PFMDTO00009();
                ratedto = CXCLE00002.Instance.GetScalarObject<PFMDTO00009>("PFMORM00009.Client.SelectByCodeAndLastModify", new object[] { "PLOANSINTRATE", true, true });
                txtRate.Text = ratedto.Rate.ToString("N2");
                txtRepaymentDuration.Focus();
            }
        }

        //Added by HWKO (02-Oct-2017)
        private void chkEditNYIR_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEditNYIR.Checked == true)
            {
                txtNYIntRate.Enabled = true;
                txtNYIntRate.Focus();
            }
            else
            {
                txtNYIntRate.Enabled = false;
                PFMDTO00009 ratedto = new PFMDTO00009();
                ratedto = CXCLE00002.Instance.GetScalarObject<PFMDTO00009>("PFMORM00009.Client.SelectByCodeAndLastModify", new object[] { "PLNYINTRATE", true, true });
                txtNYIntRate.Text = ratedto.Rate.ToString("N2");
                this.tsbCRUD.butSave.Focus();
            }
        }

        private void chkEditGP_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEditGP.Checked == true)
            {
                txtGracePeriod.Enabled = true;
                txtGracePeriod.Focus();
            }
            else
            {
                this.txtGracePeriod.Enabled = false;
                this.txtGracePeriod.Text = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.GRACEPERIOD);
            }
        }
        //End region

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.isCancelExit = true;
            this.flag = false;
            this.Close();
        }

        private void mtxtAccountNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void txtSanctionAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtSanctionAmount.Focus();
                if (txtSanctionAmount.PasswordChar == '*')
                {
                    sAmt = Convert.ToDecimal(txtSanctionAmount.Text);
                    txtSanctionAmount.PasswordChar = '\0';
                    txtSanctionAmount.Text = "";
                    txtSanctionAmount.Focus();
                    //keyDownSamt = 0;
                    if (e.KeyChar == '\t')
                    {
                        txtSanctionAmount.Focus();
                    }
                    if (e.KeyChar == (char)Keys.Tab)
                    {
                        txtSanctionAmount.Focus();
                    }
                    //txtSanctionAmount.Focus();
                }
                else
                {
                    if (sAmt != Convert.ToDecimal(txtSanctionAmount.Text))
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00037);                    
                        Start();
                    }
                    //keyDownSamt = 1;
                    //else if (sAmt == Convert.ToDecimal(txtSanctionAmount.Text) && (e.KeyChar == (char)Keys.Tab || e.KeyChar == (char)Keys.Enter))
                    //{
                    //    chkServiceCharges.Focus();                        
                    //}

                }
            }

        }

        private void txtSanctionAmount_Leave(object sender, EventArgs e)
        {
            if (!isCancelExit)
            {
                if (isSaveSuccess == 0)
                {
                    if (this.txtSanctionAmount.Text == "0.00" || String.IsNullOrEmpty(this.txtSanctionAmount.Text))
                    {
                        //Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00037);
                        txtSanctionAmount.Text = "";
                        txtSanctionAmount.Focus();
                    }
                    else if (sAmt != Convert.ToDecimal(txtSanctionAmount.Text))
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00037);
                        txtSanctionAmount.Text = "";
                        txtSanctionAmount.Focus();
                    }
                    //else if (sAmt == Convert.ToDecimal(txtSanctionAmount.Text))
                    //{
                    //    chkServiceCharges.Focus();                        
                    //}
                }
                else
                {
                    isSaveSuccess = 0;
                    txtSanctionAmount.Text = "";
                    cboCurrency.Focus();
                }
            }
        }

        //private void txtSanctionAmount_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode.Equals(Keys.Tab))
        //    {
        //        txtSanctionAmount.Focus();
        //        if (txtSanctionAmount.PasswordChar == '*')
        //        {
        //            sAmt = Convert.ToDecimal(txtSanctionAmount.Text);
        //            txtSanctionAmount.PasswordChar = '\0';
        //            txtSanctionAmount.Text = "";
        //            txtSanctionAmount.Focus();
        //            //keyDownSamt = 0;
        //            if (e.KeyCode.Equals(Keys.Tab) || e.KeyCode.Equals(Keys.Enter))
        //            {
        //                txtSanctionAmount.Focus();
        //            }
        //        }
        //        else
        //        {
        //            if (sAmt != Convert.ToDecimal(txtSanctionAmount.Text))
        //            {
        //                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00037);
        //            }
        //            //keyDownSamt = 1;
        //            else if (sAmt == Convert.ToDecimal(txtSanctionAmount.Text) && (e.KeyCode.Equals(Keys.Tab) || e.KeyCode.Equals(Keys.Enter)))
        //            {
        //                chkServiceCharges.Focus();
        //            }
        //        }
        //    }
        //}
        
        private void txtRepaymentDuration_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtRepaymentDuration.Text) && isSaveSuccess != 0)
            {
                this.txtRepaymentDuration.Focus();
            }
            else if ((txtRepaymentDuration.Text != "" || txtRepaymentDuration.Text != "0" || txtRepaymentDuration.Text != "0.00") && isSaveSuccess == 0)
            {
               
                int Terms = String.IsNullOrEmpty( this.txtRepaymentDuration.Text)? 0 : Convert.ToInt32(this.txtRepaymentDuration.Text);

                DateTime PreDue = DateTime.Now.AddMonths(Terms);
                string[] arr = DateTime.Now.ToString("dd-MM-yyyy").Split('-');
                int _day =( arr[0].Substring(0, 1) == "0" ? Convert.ToInt32(arr[0].Substring(1, 1)) :Convert.ToInt32( arr[0]));


                if (_day < 26) //1=>25
                    dtpExpireDate.Value = Convert.ToDateTime((PreDue.Year + "/" + PreDue.Month + "/03").ToString());
                else 
                    dtpExpireDate.Value = Convert.ToDateTime((PreDue.Year + "/" + PreDue.AddMonths(1).Month + "/03").ToString());

                dtpExpireDate.Enabled = false;

                ////dtpExpireDate.Text = DateTime.Now.AddDays(Terms*30).ToString();//Updated by HWKO (26-Oct-2017)               
           
            }
        }

        private void txtRepaymentDuration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void chkEditDocFee_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkEditDocFee.Checked == true)
            {
                this.txtDocumentFees.Enabled = true;
                this.txtDocumentFees.Focus();
            }
            else
            {
                this.txtDocumentFees.Enabled = false;
                PFMDTO00009 docratedto = new PFMDTO00009();
                docratedto = CXCLE00002.Instance.GetScalarObject<PFMDTO00009>("PFMORM00009.Client.SelectByCodeAndLastModify", new object[] { "DOCFEE", true, true });
                this.txtDocumentFees.Text = docratedto.Rate.ToString("N2");
                this.txtGuarantorCompanyName.Focus();
            }
        }

        private void txtDocumentFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void txtMonthlyIncome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void txtMonthlyRepaymentDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
        }
        
        private void BindAccountInfoByAccountNo()
        {
            
            if (this.AccountNo != "")
            {
                if (!this.controller.CheckPersonalLoanAccountNo(this.AccountNo, this.formname))//False return
                {                   
                    this.mtxtAccountNo.Focus();
                }
                else//True return
                {
                    if (this.formname.Contains("Edit"))
                        FillControls();                        
                }                
            }
        }

        private void mtxtAccountNo_KeyDown(object sender, KeyEventArgs e)
        {
            //Added By AAM(11_Jun_2018)
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)//Modify by HMW (08-02-2023)
            {
                BindAccountInfoByAccountNo();
            }
        }
        private void txtAssessorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtLawerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtGuarantorCompanyName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            //Commented by HWKO (30-Aug-2017)
            //if (char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = true;
            //}
        }

        private void txtGuarantorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtGuarantorPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            { e.Handled = true; }
        }

        private void mcboTypeOfBusiness_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblTypeOfBusiness2.Visible = false;
            if (this.mcboTypeOfBusiness.SelectedIndex != -1)
            {
                this.lblTypeOfBusiness2.Visible = true;
                this.lblTypeOfBusiness2.Text = (from b in TypeOfBusinessList
                                                where b.Code.Equals(this.mcboTypeOfBusiness.SelectedValue.ToString())
                                                orderby b.Code
                                                select b.Description).Single();
                this.txtMonthlyIncome.Focus();
            }
        }

        private void radioListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.radioListBox1.SelectedItem.ToString()=="Myanmar Net Customer")
            {
                this.lblMonthlyRepayDate.Visible = true;
                this.lblMonthlyRepayDate.Enabled = true;//HMW (08-02-2022)
                this.txtMonthlyRepaymentDate.Visible = true;
                this.txtMonthlyRepaymentDate.Enabled = true;
                this.cxC000310.Visible = true;
                this.cxC000310.Enabled = true;//HMW (08-02-2022)
                this.txtMonthlyRepaymentDate.Focus();
            }
            else
            {
                this.lblMonthlyRepayDate.Visible = false;
                this.lblMonthlyRepayDate.Enabled = false;//HMW (08-02-2022)
                this.txtMonthlyRepaymentDate.Visible = false;
                this.txtMonthlyRepaymentDate.Enabled = false;
                this.cxC000310.Visible = false;
                this.cxC000310.Enabled = false;//HMW (08-02-2022)
            }
        }

        private void Start()
        {
            txtSanctionAmount.Text = "";
            txtSanctionAmount.PasswordChar = '*';            
        }

        private void txtCompanyName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            //Commented by HWKO (30-Aug-2017)
            //if (char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = true;
            //}
        }

        private void txtLoanNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!this.FormName.Contains("Entry"))//Enquiry
                {
                    if (!this.isSaveValidate)
                    {
                        try
                        {
                            if (String.IsNullOrEmpty(this.LoanNo))
                            {
                                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90055);//Invalid Loan No. !
                                this.txtLoanNo.Focus();
                            }
                            this.controller.BindPersonalLoanInfo();
                            this.txtMonthlyRepaymentDate.Enabled = false;
                            this.cxC00038.Enabled = true;
                            this.cxC000324.Enabled = true;
                        }
                        catch (Exception ex)
                        {
                            CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90055);//Invalid Loan No.
                            this.txtLoanNo.Focus();
                        }
                    }
                }
            }
        }

        //Added by HWKO (30-Aug-2017)
        private void txtGuarantorNrc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtMonthlyIncome_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtMonthlyIncome.Text))
                txtMonthlyIncome.Text = Double.Parse(txtMonthlyIncome.Text).ToString("N2");
            else
                txtMonthlyIncome.Text = "0.00";
        }

        private void txtDocumentFees_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtDocumentFees.Text))
                txtDocumentFees.Text = Double.Parse(txtDocumentFees.Text).ToString("N2");
            else
                txtDocumentFees.Text = "5000.00";
        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
                e.Handled = true;


            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void txtRate_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtRate.Text))
                txtRate.Text = Double.Parse(txtRate.Text).ToString("N2");
            else
                txtRate.Text = "0.00";
        }

        private void chkServiceCharges_Leave(object sender, EventArgs e)
        {
            this.chkEdit.Select();
        }

        private void mtxtAccountNo_Leave(object sender, EventArgs e)//Added by HMW : 27-03-2024
        {
            BindAccountInfoByAccountNo();
        }

        //private void mtxtAccountNo_Leave(object sender, EventArgs e)
        //{
        //    //Added By KCM(11_Jun_2018)
        //    if (!String.IsNullOrEmpty(mtxtAccountNo.Text))
        //    {
        //        BindAccountInfoByAccountNo();
        //    }
        //}

        #region PenalFee
        //private void chkPenalFee_CheckedChanged(object sender, EventArgs e)
        //{
        //    getViewDataForCommon = new LOMDTO00311();
        //    if (this.chkPenalFee.Checked)
        //    {
        //        this.txtPenalDuration.Enabled = true;
        //        this.gdvPenalFee.Enabled = true;

        //        this.getViewDataForCommon.isLateFee = true;
        //        this.getViewDataForCommon.isLateFee = chkPenalFee.Checked;
        //    }
        //    else
        //    {
        //        this.txtPenalDuration.Enabled = false;
        //        this.gdvPenalFee.Enabled = false;

        //        this.getViewDataForCommon.isLateFee = chkPenalFee.Checked;
        //    }
        //}

        //private void txtPenalDuration_Leave(object sender, EventArgs e)
        //{
        //    if (txtPenalDuration.Text == string.Empty || txtPenalDuration.Text == "")
        //        //  CXUIMessageUtilities.ShowMessageByCode("MV00034");
        //        this.txtPenalDuration.Focus();
        //}

        //private void gdvPenalFee_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        //{
        //    DataGridViewCell dataCurrentCell = gdvPenalFee.CurrentCell;

        //    if (dataCurrentCell.OwningColumn.Name.Equals("colStartPeriod"))
        //    {
        //        TextBox txtbox = e.Control as TextBox;
        //        if (txtbox != null)
        //        {
        //            //txtbox.KeyPress -= new KeyPressEventHandler(colAccountNo_KeyPress);
        //            txtbox.KeyPress += new KeyPressEventHandler(colStartPeriod_KeyPress);
        //        }
        //    }

        //    if (dataCurrentCell.OwningColumn.Name.Equals("colEndPeriod"))
        //    {
        //        TextBox txtbox = e.Control as TextBox;
        //        if (txtbox != null)
        //        {
        //            //txtbox.KeyPress -= new KeyPressEventHandler(colAccountNo_KeyPress);
        //            txtbox.KeyPress += new KeyPressEventHandler(colEndPeriod_KeyPress);
        //        }
        //    }

        //    if (dataCurrentCell.OwningColumn.Name.Equals("colPenalFee"))
        //    {
        //        TextBox txtbox = e.Control as TextBox;
        //        if (txtbox != null)
        //        {
        //            //txtbox.KeyPress -= new KeyPressEventHandler(colAccountNo_KeyPress);
        //            txtbox.KeyPress += new KeyPressEventHandler(colPenalFee_KeyPress);
        //        }
        //    }

        //    if (dataCurrentCell.OwningColumn.Name.Equals("colAmount"))
        //    {
        //        TextBox txtbox = e.Control as TextBox;
        //        if (txtbox != null)
        //        {
        //            txtbox.KeyPress += new KeyPressEventHandler(colAmount_KeyPress);
        //        }
        //    }
        //}

        //private void gdvPenalFee_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        //{
        //    if (!this.isCancelExit)
        //    {
        //        //this.gdvPenalFee.CausesValidation = false;
        //        DataGridViewRow dataRow = (DataGridViewRow)gdvPenalFee.Rows[e.RowIndex];
        //        DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

        //        if (cell.OwningColumn.Name.Equals("colStartPeriod"))
        //        {
        //            if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
        //            {
        //                CXUIMessageUtilities.ShowMessageByCode("MV00046");
        //                gdvPenalFee.CurrentCell = dataRow.Cells["colStartPeriod"];
        //                gdvPenalFee.BeginEdit(true);
        //            }
        //            else
        //            {
        //                dataRow.Cells["colStartPeriod"].Value = cell.EditedFormattedValue.ToString();
        //            }
        //        }
        //        else if (cell.OwningColumn.Name.Equals("colEndPeriod"))
        //        {
        //            if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
        //            {
        //                CXUIMessageUtilities.ShowMessageByCode("MV00046");
        //                gdvPenalFee.CurrentCell = dataRow.Cells["colEndPeriod"];
        //                gdvPenalFee.BeginEdit(true);
        //                //e.Cancel = true;
        //            }
        //            else
        //            {
        //                dataRow.Cells["colEndPeriod"].Value = cell.EditedFormattedValue.ToString();
        //            }
        //        }

        //        if (cell.OwningColumn.Name.Equals("colPenalFee"))
        //        {
        //            if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
        //            {
        //                CXUIMessageUtilities.ShowMessageByCode("MV90090");  // Invalid Fees
        //                gdvPenalFee.CurrentCell = dataRow.Cells["colPenalFee"];
        //                gdvPenalFee.BeginEdit(true);
        //                e.Cancel = true;
        //            }
        //            else
        //            {
        //                dataRow.Cells["colPenalFee"].Value = cell.EditedFormattedValue.ToString();
        //            }
        //        }
        //        else if (cell.OwningColumn.Name.Equals("colAmount"))
        //        {
        //            if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
        //            {
        //                CXUIMessageUtilities.ShowMessageByCode("MV00037");
        //                gdvPenalFee.CurrentCell = dataRow.Cells["colAmount"];
        //                gdvPenalFee.BeginEdit(true);
        //                e.Cancel = true;
        //            }

        //            //if (this.SanctionAmount < Convert.ToDecimal(cell.EditedFormattedValue))
        //            //    CXUIMessageUtilities.ShowMessageByCode("MV00046");

        //            //else if (this.SanctionAmount < penal_amount)
        //            //    CXUIMessageUtilities.ShowMessageByCode("MV00046"); 

        //            else
        //            {
        //                penal_amount += Convert.ToDecimal(cell.EditedFormattedValue);
        //                dataRow.Cells["colAmount"].Value = cell.EditedFormattedValue.ToString();
        //            }
        //        }
        //    }
        //}



        //private void colStartPeriod_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
        //        e.Handled = true;

        //    //// only allow one decimal point
        //    //if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
        //    //    e.Handled = true;
        //}

        //private void colEndPeriod_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
        //        e.Handled = true;

        //    //// only allow one decimal point
        //    //if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
        //    //    e.Handled = true;
        //}

        //private void colPenalFee_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
        //        e.Handled = true;

        //    // only allow one decimal point
        //    if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
        //        e.Handled = true;
        //}

        //private void colAmount_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
        //        e.Handled = true;

        //    // only allow one decimal point
        //    if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
        //        e.Handled = true;
        //}

        #endregion

        #endregion

    }
}
