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
    public partial class LOMVEW00011 : BaseDockingForm, ILOMVEW00011
    {
        #region controller

        private ILOMCTL00011 controller;
        public ILOMCTL00011 Controller
        {
            get { return this.controller; }
            set { this.controller = value; this.controller.View = this; }
        }

        #endregion

        public LOMVEW00011()
        {
            InitializeComponent();
        }

        public LOMVEW00011(string name)
        {
            this.Loan_Product = name;
            InitializeComponent();
        }

        #region Control Properties
        Boolean _isLoading;
        public bool isSaveValidate { get; set; }
        public bool flag { get; set; }
        public bool getServiceCharges { get; set; }
        public int registerType { get; set; }
        public bool isCancelExit { get; set; }
        public bool isEdit { get; set; }
        public bool isActive { get; set; }
        private string Loan_Product { get; set; }
        IList<LOMDTO00055> TypeOfInstallmentList;
        //private string Guarantee = "Guarantee";
        //private string Pledge = "Pledge";
        //private string Hypothecation = "Hypothecation";
        //private string GoldAndJewelly = "Gold And Jewellery";
        private IList<LOMDTO00016> pledgeDtoList = new List<LOMDTO00016>();
        private LOMDTO00016 pledgeDto = new LOMDTO00016();

        public IList<LOMDTO00021> loanInfoList { get; set; }
        private decimal penal_amount { get; set; }
        private decimal sAmt { get; set; }
        bool checkSAmt = false;
        //int keyDownSamt = 0;

        int isSaveSuccess = 0;
        int dayForOneMonth = 30; // for bank requrirement one month = 30days

        private bool needToCheck=false; // Added By AAM(31-Jan-2018)

        public bool IsUsedBal
        {
            get { return this.rdoUsedBal.Checked; }
            set { this.rdoUsedBal.Checked = value; }
        }

        public bool IsLateFee
        {
            get { return this.chkPenalFee.Checked; }
            set { this.chkPenalFee.Checked = value; }
        }

        public bool IsScharge
        {
            get { return this.chkServiceCharges.Checked; }
            set { this.chkServiceCharges.Checked = value; }
        }

        public bool IsMiddleBal
        {
            get { return this.rdoMiddleBal.Checked; }
            set { this.rdoMiddleBal.Checked = value; }
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

        //public int RepaymentPeriod
        //{
        //    get
        //    {
        //        if (this.cboRepaymentPeriod.SelectedValue == null)
        //        {
        //            return 0;
        //        }
        //        else
        //        {
        //            return Convert.ToInt32(this.cboRepaymentPeriod.SelectedValue);
        //        }
        //    }
        //    set { this.cboRepaymentPeriod.SelectedValue = value; }
        //}

        private string formname;
        public string FormName
        {
            get { return this.formname; }
            set { this.formname = value; }
        }

        private string loanNo;
        public string LoanNo
        {
            get { return this.txtLoanNo.Text.Trim(); }
            set { this.txtLoanNo.Text = value.Trim(); }
        }

        private string accountNo;
        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text.Trim(); }
            set { this.mtxtAccountNo.Text = value.Trim(); }
        }


        public decimal UsedRateForUsedBal
        {
            set
            {
                this.txtUsedBalRate.Text = Convert.ToString(value);
            }
            get
            {
                decimal result = 0;
                Decimal.TryParse(this.txtUsedBalRate.Text, out result);
                return result;
            }
        }

        public decimal UnUsedRateForUsedBal
        {
            set
            {
                this.txtUnUsedBalRate.Text = Convert.ToString(value);
            }
            get
            {
                decimal result = 0;
                Decimal.TryParse(this.txtUnUsedBalRate.Text, out result);
                return result;
            }
        }
       
        public decimal UsedUnderHalfRate
        {
            set
            {
                this.txtUsedUnderHalfRate.Text = Convert.ToString(value);
            }
            get
            {
                decimal result = 0;
                Decimal.TryParse(this.txtUsedUnderHalfRate.Text, out result);
                return result;
            }
        }

        public decimal UsedOverHalfRate
        {
            set
            {
                this.txtUsedOverHalfRate.Text = Convert.ToString(value);
            }
            get
            {
                decimal result = 0;
                Decimal.TryParse(this.txtUsedOverHalfRate.Text, out result);
                return result;
            }
        }

        public decimal MiddleUnUsedRate
        {
            set
            {
                this.txtMiddleUnUsedRate.Text = Convert.ToString(value);
            }
            get
            {
                decimal result = 0;
                Decimal.TryParse(this.txtMiddleUnUsedRate.Text, out result);
                return result;
            }
        }

        public string YearOfPLBS
        {
            get { return this.mtxtPLandBS.Text; }
            set { this.mtxtPLandBS.Text = value; }
        }

        public string Rate
        {
            get { return this.txtRate.Text; }
            set { this.txtRate.Text = value; }
        }
        
        public string DocFee
        {
            get { return this.txtDocumentFee.Text; }
            set { this.txtDocumentFee.Text = value; }
        }
        public string Address
        {
            get { return this.txtAddress.Text; }
            set { this.txtAddress.Text = value; }
        }

        public decimal Capital
        {
            set
            {
                this.txtCapital.Text = Convert.ToString(value);
            }
            get
            {
                decimal result = 0;
                Decimal.TryParse(this.txtCapital.Text, out result);
                return result;
            }
        }

        public decimal ForceSaleValueOfLand
        {
            set
            {
                this.txtForceSaleValueOfLand.Text = Convert.ToString(value);
            }
            get
            {
                decimal result = 0;
                Decimal.TryParse(this.txtForceSaleValueOfLand.Text, out result);
                return result;
            }
        }

        public decimal ForceSaleValueOfBuilding
        {
            set
            {
                this.txtForceSaleValueOfBuilding.Text = Convert.ToString(value);
            }
            get
            {
                decimal result = 0;
                Decimal.TryParse(this.txtForceSaleValueOfBuilding.Text, out result);
                return result;
            }
        }

        public decimal YearOfExperience
        {
            set
            {
                this.txtYearExperience.Text = Convert.ToString(value);
            }
            get
            {
                decimal result = 0;
                Decimal.TryParse(this.txtYearExperience.Text, out result);
                return result;
            }
        }

        public string SalesDeed
        {
            get
            {
                if (this.cboSalesDeed.SelectedValue == null)
                {
                    return string.Empty;
                }
                else
                {
                    return this.cboSalesDeed.SelectedValue.ToString();
                }
            }
            set
            {
                this.cboSalesDeed.SelectedValue = value;
            }
        }

        public string Land
        {
            get
            {
                if (this.cboLand.SelectedValue == null)
                {
                    return string.Empty;
                }
                else
                {
                    return this.cboLand.SelectedValue.ToString();
                }
            }
            set
            {
                this.cboLand.SelectedValue = value;
            }
        }

        public string HistoryOfLand_Building
        {
            get
            {
                if (this.cboHistoryOfLand.SelectedValue == null)
                {
                    return string.Empty;
                }
                else
                {
                    return this.cboHistoryOfLand.SelectedValue.ToString();
                }
            }
            set
            {
                this.cboHistoryOfLand.SelectedText = value;
            }
        }

        public string TypeOfProduct
        {
            get
            {
                if (this.cboTypeOfProduct.SelectedValue == null)
                {
                    return string.Empty;
                }
                else
                {
                    return this.cboTypeOfProduct.SelectedValue.ToString();
                }
            }
            set
            {
                this.cboTypeOfProduct.SelectedValue = value;
            }
        }

        public string BuildingConstructionPermit
        {
            get
            {
                if (this.cboBuildingConPermit.SelectedValue == null)
                {
                    return string.Empty;
                }
                else
                {
                    return this.cboBuildingConPermit.SelectedValue.ToString();
                }
            }
            set
            {
                this.cboBuildingConPermit.SelectedText = value;
            }
        }

        public string LandOfAffidavit
        {
            get
            {
                if (this.cboLandOfAffidavit.SelectedValue == null)
                {
                    return string.Empty;
                }
                else
                {
                    return this.cboLandOfAffidavit.SelectedValue.ToString();
                }
            }
            set
            {
                this.cboLandOfAffidavit.SelectedText = value;
            }
        }
        public DateTime LandLeaseSDate
        {
            get { return this.dtpLandStartDate.Value; }
            set { this.dtpLandStartDate.Value = value; }
        }
        public DateTime LandLeaseEDate
        {
            get { return this.dtpLEndDate.Value; }
            set { this.dtpLEndDate.Value = value; }
        }
        public string RemarkForLand
        {
            get { return this.txtRemark.Text.ToString(); }
            set { this.txtRemark.Text = value; }
        }
        public string CharacterOfCustomer
        {
            get
            {
                if (this.cboCharacterOfCustomer.SelectedValue == null)
                {
                    return string.Empty;
                }
                else
                {
                    return this.cboCharacterOfCustomer.SelectedValue.ToString();
                }
            }
            set
            {
                this.cboCharacterOfCustomer.SelectedValue = value;
            }
        }

        public string GoodWill
        {
            get
            {
                if (this.cboGoodWill.SelectedValue == null)
                {
                    return string.Empty;
                }
                else
                {
                    return this.cboGoodWill.SelectedValue.ToString();
                }
            }
            set
            {
                this.cboGoodWill.SelectedValue = value;
            }
        }


        public string TypeOfAdvance
        {
            get
            {
                if (this.cboTypeOfAdvance.SelectedValue == null)
                {
                    return string.Empty;
                }
                else
                {
                    return this.cboTypeOfAdvance.SelectedValue.ToString();
                }
            }
            set
            {
                this.cboTypeOfAdvance.SelectedValue = value;
            
            }
        }

        public string TypeOfInsurance
        {
            get
            {
                if (this.cboTypeOfInsuranceForLand_Bld.SelectedValue == null)
                {
                    return string.Empty;
                }
                else
                {
                    return this.cboTypeOfInsuranceForLand_Bld.SelectedValue.ToString();
                }
            }
            set
            {
                this.cboTypeOfInsuranceForLand_Bld.SelectedValue = value;
            }
        }

        public string TypeOfInsuranceForPledge
        {
            get
            {
                if (this.cboTypeOfInsuranceForPledge.SelectedValue == null)
                {
                    return string.Empty;
                }
                else
                {
                    return this.cboTypeOfInsuranceForPledge.SelectedValue.ToString();
                }
            }
            set
            {
                this.cboTypeOfInsuranceForPledge.SelectedValue = value;
            }
        }


        public string TypeOfInsuranceForHypo
        {
            get
            {
                if (this.cboTypeOfInsuranceForHypo.SelectedValue == null)
                {
                    return string.Empty;
                }
                else
                {
                    return this.cboTypeOfInsuranceForHypo.SelectedValue.ToString();
                }
            }
            set
            {
                this.cboTypeOfInsuranceForHypo.SelectedValue = value;
            }
        }


        public decimal InsuranceAmount
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtInsuranceAmount.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtInsuranceAmount.Text = value.ToString(); }
        }

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

        public decimal IncomeTax
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtIncomeTax.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtIncomeTax.Text = value.ToString(); }
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

        public DateTime DateOfInsurance
        {
            get { return this.dtpDateOfInsurance.Value; }
            set { this.dtpDateOfInsurance.Value = value; }
        }

        public DateTime InsuranceExpireDate
        {
            get { return this.dtpInsuranceExpireDate.Value; }
            set { this.dtpInsuranceExpireDate.Value = value; }
        }
        public DateTime ExpireDate
        {
            get { return this.dtpExpireDate.Value; }
            set { this.dtpExpireDate.Value = value; }
        }


        public DateTime DateOfInsuranceForPledge
        {
            get { return this.dtpDateInuranceForPledge.Value; }
            set { this.dtpDateInuranceForPledge.Value = value; }
        }

        public DateTime InsuranceExpireDateForPledge
        {
            get { return this.dtpIsExpiredDateForPledge.Value; }
            set { this.dtpIsExpiredDateForPledge.Value = value; }
        }

        public decimal InsuranceAmountForPledge
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtIsAmountForPledge.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtIsAmountForPledge.Text = value.ToString(); }
        }

        public DateTime DateOfInsuranceForHypo
        {
            get { return this.dtpDateInsuranceForHypo.Value; }
            set { this.dtpDateInsuranceForHypo.Value = value; }
        }

        public DateTime InsuranceExpireDateForHypo
        {
            get { return this.DtpIsExpiredDateForHypo.Value; }
            set { this.DtpIsExpiredDateForHypo.Value = value; }
        }

        public decimal InsuranceAmountForHypo
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtIsAmountForHypo.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtIsAmountForHypo.Text = value.ToString(); }
        }

        public decimal SanctionAmount
        {
            get
            {
                return Convert.ToDecimal(this.txtSanctionAmount.Text);
            }
            set
            { 
                this.txtSanctionAmount.Text = value.ToString();
                if (value > 0)
                {
                    this.txtSanctionAmountEncode.Visible = false;
                    this.txtSanctionAmount.Visible = true;
                }
                else 
                {
                    this.txtSanctionAmountEncode.Visible = true;
                    this.txtSanctionAmount.Visible = false; 
                }

            }
        }

        public string KindOfStock
        {
            get
            {
                if (this.cboKindOfStock.SelectedValue == null)
                {
                    return string.Empty;
                }
                else
                {
                    return this.cboKindOfStock.SelectedValue.ToString();
                }
            }
            set
            {
                this.cboKindOfStock.SelectedValue = value;
            }
        }

        public decimal Value
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtValue.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtValue.Text = value.ToString(); }
        }

        public DateTime ExpiredDate
        {
            get { return this.dtpExpireDate.Value; }
            set { this.dtpExpireDate.Value = value; }
        }

        public DateTime EstablishmentDate
        {
            get { return this.dtpEstablishmentDate.Value; }
            set { this.dtpEstablishmentDate.Value = value; }
        }

        public string GuarantorCompanyName
        {
            get { return this.txtGCompanyName.Text; }
            set { this.txtGCompanyName.Text = value; }
        }

        //public string GuarantorAccountNo
        //{
        //    get { return this.mtxtGuaranterAccountNo.Text; }
        //    set { this.mtxtGuaranterAccountNo.Text = value; }
        //}

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

        //public int RepaymentPeriod
        //{
        //    set
        //    {
        //        this.cboRepayment.SelectedValue = Convert.ToString(value);
        //    }
        //    get
        //    {
        //        if (this.cboRepayment.SelectedValue == null)
        //        {
        //            return 0;

        //        }
        //        else
        //        {
        //            int result = 0;
        //            Int32.TryParse(this.cboRepayment.SelectedValue.ToString(), out result);
        //            return result;
        //        }
        //    }
        //}

        public int Duration
        {
            set
            {
                this.txtPenalDuration.Text = Convert.ToString(value);
            }
            get
            {
                int result = 0;
                Int32.TryParse(this.txtPenalDuration.Text, out result);
                return result;
            }
        }

        //public string RepaymentOption
        //{
        //    get
        //    {
        //        if (this.cboRepayment.SelectedValue == null)
        //        {
        //            return null;
        //        }
        //        else
        //        {
        //            return this.cboRepayment.SelectedValue.ToString();
        //        }
        //    }
        //    set
        //    {
        //        this.cboRepayment.SelectedValue = Convert.ToString(value);
        //    }
        //}

        //public string Repay
        //{
        //    get { return null; }
        //    set
        //    {
        //        this.cboRepayment.Text = value;
        //        //this.cboProductType.SelectedValue = value;
        //    }
        //}


        public string PrincipleRepaymentOption
        {
            set
            {
                this.cboPrincipalOption.SelectedValue = Convert.ToInt32(value);

            }
            get
            {
                if (this.cboPrincipalOption.SelectedValue == null)
                    return "";

                else
                    return this.cboPrincipalOption.SelectedValue.ToString();
              
            }
        }

        public string InterestRepaymentOption
        {
            set
            {
                 this.cboInterestOption.SelectedValue = Convert.ToInt32(value);
            }
            get
            {
                if (this.cboInterestOption.SelectedValue == null)
                    return "";
                else
                    return this.cboInterestOption.SelectedValue.ToString();
               
            }
        }

        public int GracePeriod
        {
            set
            {
                this.txtGracePeriod.Text = Convert.ToString(value);
            }
            get
            {
                int result = 0;
                Int32.TryParse(this.txtGracePeriod.Text, out result);
                return result;
            }
        }

        public string RelatedGLACode
        {
            set
            {
                this.txtGLAcode.Text = Convert.ToString(value);
            }
            get
            {
                return this.txtGLAcode.Text.ToString();
            }
        }

        IList<LOMDTO00001> LandList { get; set; }
        IList<LOMDTO00010> KStockList { get; set; }
        IList<LOMDTO00001> TypeOfBusinessList { get; set; }
        IList<LOMDTO00004> TypeOfInsuranceListForLand_Bld { get; set; }
        IList<LOMDTO00004> TypeOfInsuranceListForHypo { get; set; }
        IList<LOMDTO00004> TypeOfInsuranceListForPledge { get; set; }
        IList<LOMDTO00009> StockList { get; set; }
        IList<LOMDTO00007> GJTCodeList { get; set; }
        IList<LOMDTO00008> GJKCodeList { get; set; }
        #endregion Control Properties

        #region Method

        public void Pledge(IList<LOMDTO00016> pledgeList)
        {
            //dt.Columns.Add("LineNo", typeof(int));
            DataTable dt = new DataTable();
            dt.Columns.Add("StockNo", typeof(string));
            dt.Columns.Add("StockName", typeof(string));
            dt.Columns.Add("StockQTY", typeof(string));
            dt.Columns.Add("Market_VAL", typeof(string));

            if (pledgeList.Count > 0)
            {
                foreach (LOMDTO00016 data in pledgeList)
                {
                    DataRow dr = dt.NewRow();
                    dr["StockNo"] = Convert.ToString(data.StockNo);
                    StockList = CXCLE00002.Instance.GetListObject<LOMDTO00009>("LOMORM00009.SelectAllStock", new object[] { true });
                    dr["StockName"] = (from s in StockList
                                       where s.StockNo.Equals(data.StockNo)
                                       select s.Name).Single();
                    dr["StockQTY"] = Convert.ToString(data.StockQTY);
                    dr["Market_VAL"] = Convert.ToString(data.Market_VAL);
                    dt.Rows.Add(dr);
                }
                this.gdvStock.DataSource = dt;
            }
            gdvStock.DataError += new DataGridViewDataErrorEventHandler(gdvStock_DataError_1);
            gdvStock.DataError -= new DataGridViewDataErrorEventHandler(gdvStock_DataError_1);
            this.isActive = false;
        }

        public void GoldandJewellery(TLMDTO00018 loanDto)
        {
            DataTable dtT = new DataTable();

            dtT.Columns.Add("GJType", typeof(string));
            dtT.Columns.Add("description", typeof(string));
            dtT.Columns.Add("Quantity", typeof(string));
            dtT.Columns.Add("Weight", typeof(string));
            dtT.Columns.Add("Value", typeof(string));

            if (loanDto.GjTypeDtoList.Count > 0)
            {
                foreach (LOMDTO00018 data in loanDto.GjTypeDtoList)
                {
                    DataRow dr = dtT.NewRow();
                    dr["GJType"] = Convert.ToString(data.GJType);
                    dr["description"] = (from s in GJTCodeList
                                         where s.Code.Equals(data.GJType)
                                         select s.Description).Single();
                    dr["Quantity"] = Convert.ToString(data.Quantity);
                    dr["Weight"] = Convert.ToString(data.Weight);
                    dr["Value"] = Convert.ToString(data.Value);
                    dtT.Rows.Add(dr);
                }

                this.gdvTypeOfGold.DataSource = dtT;
            }

            gdvTypeOfGold.DataError += new DataGridViewDataErrorEventHandler(gdvStock_DataError_1);
            gdvTypeOfGold.DataError -= new DataGridViewDataErrorEventHandler(gdvStock_DataError_1);

            DataTable dtK = new DataTable();
            dtK.Columns.Add("GJType", typeof(string));
            dtK.Columns.Add("description", typeof(string));
            dtK.Columns.Add("Quantity", typeof(string));

            if (loanDto.GjKindDtoList.Count > 0)
            {
                foreach (LOMDTO00018 data in loanDto.GjKindDtoList)
                {
                    DataRow dr = dtK.NewRow();
                    dr["GJType"] = Convert.ToString(data.GJType);
                    dr["description"] = (from s in GJKCodeList
                                         where s.Kind.Equals(data.GJType)
                                         select s.Description).Single();
                    dr["Quantity"] = Convert.ToString(data.Quantity);

                    dtK.Rows.Add(dr);
                }

                this.gdvKindOfGold.DataSource = dtK;
            }

            gdvKindOfGold.DataError += new DataGridViewDataErrorEventHandler(gdvStock_DataError_1);
            gdvKindOfGold.DataError -= new DataGridViewDataErrorEventHandler(gdvStock_DataError_1);

            this.isActive = false;
        }

        public void BindTypeOfAdvance()
        {
            IList<LOMDTO00002> TypeOfAdvanceList = CXCLE00002.Instance.GetListObject<LOMDTO00002>("LOMORM00002.SelectAllAdvanceType", new object[] { true });
            this.cboTypeOfAdvance.ValueMember = "Description";
            this.cboTypeOfAdvance.DisplayMember = "Description";
            this.cboTypeOfAdvance.DataSource = TypeOfAdvanceList;
            this.cboTypeOfAdvance.SelectedIndex = -1;
        }

        //public void BindTypeOfBusiness()
        //{
        //    TypeOfBusinessList = CXCLE00002.Instance.GetListObject<LOMDTO00001>("LOMORM00001.SelectAllBusinessType", new object[] { true });
        //    this.mcboTypeOfBusiness.ValueMember = "Code";
        //    this.mcboTypeOfBusiness.DisplayMember = "Code";
        //    this.mcboTypeOfBusiness.ColumnNames = "Code,Description";
        //    this.mcboTypeOfBusiness.DataSource = TypeOfBusinessList;
        //    this.mcboTypeOfBusiness.SelectedIndex = -1;
        //}
        public void BindTypeOfBusiness()
        {
            TypeOfBusinessList = this.Controller.BindLoansBType();
            this.mcboTypeOfBusiness.ValueMember = "Code";
            this.mcboTypeOfBusiness.DisplayMember = "Code";
            this.mcboTypeOfBusiness.ColumnNames = "Code,Description";
            this.mcboTypeOfBusiness.DataSource = TypeOfBusinessList;
            this.mcboTypeOfBusiness.SelectedIndex = -1;
        }

       
        public void BindTypeOfInsuranceForLand_Bld()
        {
            TypeOfInsuranceListForLand_Bld = CXCLE00002.Instance.GetListObject<LOMDTO00004>("LOMORM00004.SelectAllInsuranceType", new object[] { true });
            this.cboTypeOfInsuranceForLand_Bld.ValueMember = "INSUCODE";
            this.cboTypeOfInsuranceForLand_Bld.DisplayMember = "INSUCODE";
            this.cboTypeOfInsuranceForLand_Bld.ColumnNames = "INSUCODE,INSUDESP";
            this.cboTypeOfInsuranceForLand_Bld.DataSource = TypeOfInsuranceListForLand_Bld;
            this.cboTypeOfInsuranceForLand_Bld.SelectedIndex = -1;
        }

        public void BindTypeOfInsuranceForPledge()
        {
            this.TypeOfInsuranceListForPledge = CXCLE00002.Instance.GetListObject<LOMDTO00004>("LOMORM00004.SelectAllInsuranceType", new object[] { true });
            this.cboTypeOfInsuranceForPledge.ValueMember = "INSUCODE";
            this.cboTypeOfInsuranceForPledge.DisplayMember = "INSUCODE";
            this.cboTypeOfInsuranceForPledge.ColumnNames = "INSUCODE,INSUDESP";
            this.cboTypeOfInsuranceForPledge.DataSource = TypeOfInsuranceListForPledge;
            this.cboTypeOfInsuranceForPledge.SelectedIndex = -1;
        }

        public void BindTypeOfInsuranceFsorHypothecation()
        {
            TypeOfInsuranceListForHypo = CXCLE00002.Instance.GetListObject<LOMDTO00004>("LOMORM00004.SelectAllInsuranceType", new object[] { true });
            this.cboTypeOfInsuranceForHypo.ValueMember = "INSUCODE";
            this.cboTypeOfInsuranceForHypo.DisplayMember = "INSUCODE";
            this.cboTypeOfInsuranceForHypo.ColumnNames = "INSUCODE,INSUDESP";
            this.cboTypeOfInsuranceForHypo.DataSource = TypeOfInsuranceListForHypo;
            this.cboTypeOfInsuranceForHypo.SelectedIndex = -1;
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

        public void BindStockInfoForPledge()
        {
            StockList = new List<LOMDTO00009>();
            StockList = CXCLE00002.Instance.GetListObject<LOMDTO00009>("LOMORM00009.SelectAllStock", new object[] { true });
            colStockNo.ValueMember = "StockNo";
            colStockNo.DisplayMember = "StockNo";
            colStockNo.DataSource = StockList;
            //DataGridViewComboBoxColumn cmbcolumn = new DataGridViewComboBoxColumn();
            //gdvStock.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(gdvStock_EditingControlShowing);
            //cmbcolumn.DataSource = StockList;
            //cmbcolumn.DataSource = StockList;
            //((DataGridViewComboBoxColumn)gdvStock.Columns["colStockNo"]).DataSource = null;
            ((DataGridViewComboBoxColumn)gdvStock.Columns["colStockNo"]).DataSource = StockList;
            gdvStock.CurrentCell = gdvStock.Rows[0].Cells[0];
            this.gdvStock.Focus();
        }

        public void BindGJTCode()
        {
            this.gdvTypeOfGold.DataSource = null;
            this.GJTCodeList = new List<LOMDTO00007>();
            GJTCodeList = CXCLE00002.Instance.GetListObject<LOMDTO00007>("LOMORM00007.SelectAllGJTCode", new object[] { true });
            this.colType.ValueMember = "Code";
            colType.DisplayMember = "Code";
            colType.DataSource = GJTCodeList;
            ((DataGridViewComboBoxColumn)gdvTypeOfGold.Columns["colType"]).DataSource = GJTCodeList;
            gdvTypeOfGold.CurrentCell = gdvTypeOfGold.Rows[0].Cells[0];
            this.gdvTypeOfGold.Focus();

        }

        public void BindGJKCode()
        {
            this.gdvKindOfGold.DataSource = null;
            this.GJKCodeList = new List<LOMDTO00008>();
            GJKCodeList = CXCLE00002.Instance.GetListObject<LOMDTO00008>("LOMORM00008.SelectAllGJKCode", new object[] { true });
            this.colKind.ValueMember = "Kind";
            colKind.DisplayMember = "Kind";
            colKind.DataSource = GJKCodeList;
            ((DataGridViewComboBoxColumn)gdvKindOfGold.Columns["colKind"]).DataSource = GJKCodeList;
            gdvKindOfGold.CurrentCell = gdvKindOfGold.Rows[0].Cells[0];
            this.gdvKindOfGold.Focus();

        }

        public void BindPeanlFee(IList<LOMDTO00012> penalList)
        {
            this.gdvPenalFee.AutoGenerateColumns = false;
            this.gdvPenalFee.DataSource = null;
            //this.gdvLoanInterest.CausesValidation = false;
            this.gdvPenalFee.DataSource = penalList;
        }

        public void BindLoanProduct()
        {
            IList<LOMDTO00014> TypeOfProductList = CXCLE00002.Instance.GetListObject<LOMDTO00014>("LOMORM00014.SelectAllLandType", new object[] { true });
            this.cboTypeOfProduct.ValueMember = "LOANS_TYPE";
            this.cboTypeOfProduct.DisplayMember = "LOANSDESP";
            this.cboTypeOfProduct.DataSource = TypeOfProductList;
            this.cboTypeOfProduct.SelectedIndex = -1;
        }

        //public void BindInstallmentPeriod()
        //{
        //    IList<LOMDTO00055> TypeOfInstallmentList = CXCLE00002.Instance.GetListObject<LOMDTO00055>("LOMORM00100.SelectAllInstallmentPeriod", new object[] { true });
        //    this.cboRepayment.ValueMember = "NOOFMONTH";
        //    this.cboRepayment.DisplayMember = "NAME";
        //    this.cboRepayment.DataSource = TypeOfInstallmentList;
        //    this.cboRepayment.SelectedIndex = -1;
        //}

        public void BindLandOfAffidavit()
        {
            this.cboLandOfAffidavit.DataSource = null;
            string[] List = { "REQUIRED", "NOT REQUIRED" };
            this.cboLandOfAffidavit.DataSource = List;
            this.cboLandOfAffidavit.SelectedIndex = -1;
        }

        public void BindHistoryOfLandandBuilding()
        {
            this.cboHistoryOfLand.DataSource = null;
            string[] List = { "INORDER", "NOT INORDER" };
            this.cboHistoryOfLand.DataSource = List;
            this.cboHistoryOfLand.SelectedIndex = -1;
        }

        public void BindSalesDeed()
        {
            this.cboSalesDeed.DataSource = null;
            string[] saleList = { "INORDER", "NOT INORDER" };
            //this.cboSalesDeed.ValueMember ='';
            this.cboSalesDeed.DataSource = saleList;
            this.cboSalesDeed.SelectedIndex = -1;
        }

        public void BindBuildingConstructionPermit()
        {
            this.cboBuildingConPermit.DataSource = null;
            string[] List = { "RECEIVED", "NOT RECEIVED" };
            this.cboBuildingConPermit.DataSource = List;
            this.cboBuildingConPermit.SelectedIndex = -1;
        }

        public void BindGoodWill()
        {
            IList<LOMDTO00001> GoodWillList = CXCLE00002.Instance.GetListObject<LOMDTO00001>("LOMORM00006.SelectAllGoodWill", new object[] { true });
            cboGoodWill.ValueMember = "Code";
            cboGoodWill.DisplayMember = "Code";
            cboGoodWill.ColumnNames = "Code,Description";
            cboGoodWill.DataSource = GoodWillList;
            cboGoodWill.SelectedIndex = -1;
        }

        private void BindCurrency()
        {
            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
            cboCurrency.SelectedIndex = 0;
        }

        public void BindCustomerCharacterCode()
        {
            IList<LOMDTO00001> TypeOfCharacterCodeList = CXCLE00002.Instance.GetListObject<LOMDTO00001>("LOMORM00003.SelectAllCustomerCharacterCode", new object[] { true });
            this.cboCharacterOfCustomer.ValueMember = "Code";
            this.cboCharacterOfCustomer.DisplayMember = "Description";
            this.cboCharacterOfCustomer.DataSource = TypeOfCharacterCodeList;
            this.cboCharacterOfCustomer.SelectedIndex = -1;
        }

        public void BindAllLand()
        {
            LandList = CXCLE00002.Instance.GetListObject<LOMDTO00001>("LOMORM00005.SelectAllLand", new object[] { true });
            this.cboLand.ValueMember = "Code";
            this.cboLand.DisplayMember = "Code";
            this.cboLand.ColumnNames = "Code,Description";
            this.cboLand.DataSource = LandList;
            this.cboLand.SelectedIndex = -1;
        }

        public void BindAllKStock()
        {
            KStockList = CXCLE00002.Instance.GetListObject<LOMDTO00010>("LOMORM00010.SelectAllKStock", new object[] { true });
            this.cboKindOfStock.ValueMember = "KStockNo";
            this.cboKindOfStock.DisplayMember = "KStockNo";
            this.cboKindOfStock.ColumnNames = "KStockNo,Desp";
            this.cboKindOfStock.DataSource = KStockList;
            this.cboKindOfStock.SelectedIndex = -1;
        }

        public void BindPrincipleRepayPeriod()
        {
            TypeOfInstallmentList = CXCLE00002.Instance.GetListObject<LOMDTO00055>("LOMORM00100.SelectAllInstallmentPeriod", new object[] { true });
            this.cboPrincipalOption.ValueMember = "NOOFMONTH";
            this.cboPrincipalOption.DisplayMember = "NAME";
            this.cboPrincipalOption.DataSource = TypeOfInstallmentList;
            this.cboPrincipalOption.SelectedIndex = -1;
        }

        public void BindInterestRepayPeriod()
        {
            TypeOfInstallmentList = CXCLE00002.Instance.GetListObject<LOMDTO00055>("LOMORM00100.SelectAllInstallmentPeriod", new object[] { true }).Where(x=>x.NAME.Equals("Monthly")).ToList();
            this.cboInterestOption.ValueMember = "NOOFMONTH";
            this.cboInterestOption.DisplayMember = "NAME";
            this.cboInterestOption.DataSource = TypeOfInstallmentList;
            this.cboInterestOption.SelectedIndex = -1;
        }
        //Validation For UI Validation
        private bool ControlValidation()
        {
            // bool flag = true ;

            #region Common Loan Registration Controls Validation

            //if (String.IsNullOrEmpty(this.LoanNo))
            //{
            //    this.txtLoanNo.Focus();
            //    return false;

            //}
            //else if (String.IsNullOrEmpty(this.CurrencyCode))
            //{
            // this.cboCurrency.Focus();
            //  return false;

            //}
            if (String.IsNullOrEmpty(this.AccountNo))
            {
                this.mtxtAccountNo.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(this.TypeOfAdvance))
            {
                this.cboTypeOfAdvance.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(this.AssessorName))
            {
                //CXUIMessageUtilities.ShowMessageByCode("MV00046");
                this.txtAssessorName.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(this.LawerName))
            {
                // CXUIMessageUtilities.ShowMessageByCode("MV00046");
                this.txtLawerName.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(this.TypeOfBusiness))
            {
                this.mcboTypeOfBusiness.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(this.cboTypeOfProduct.Text))
            {
                this.cboTypeOfProduct.Focus();
                return false;
            }


            #endregion

            #region Land_Building

            if (this.cboTypeOfProduct.Text != null && this.cboTypeOfProduct.Text.Contains("Land"))
            {
                if (String.IsNullOrEmpty(this.YearOfPLBS))
                {
                    this.mtxtPLandBS.Focus();
                    return false;

                }
                else if (String.IsNullOrEmpty(this.YearOfExperience.ToString()))
                {
                    this.txtYearExperience.Focus();
                    return false;
                }
                else if (String.IsNullOrEmpty(this.Capital.ToString()))
                {
                    this.txtCapital.Focus();
                    return false;
                }
                else if (String.IsNullOrEmpty(this.IncomeTax.ToString()))
                {
                    this.txtIncomeTax.Focus();
                    return false;
                }
                else if (String.IsNullOrEmpty(this.SalesDeed))
                {
                    this.cboSalesDeed.Focus();
                    return false;
                }
                else if (String.IsNullOrEmpty(this.LandOfAffidavit))
                {
                    this.cboLandOfAffidavit.Focus();
                    return false;
                }
                //else if (this.LandLeaseEDate))
                //{
                //    this.cboLandOfAffidavit.Focus();
                //    return false;
                //}
                else if (String.IsNullOrEmpty(this.Land))
                {
                    this.cboLand.Focus();
                    return false;
                }
                else if (String.IsNullOrEmpty(this.CharacterOfCustomer))
                {
                    this.cboCharacterOfCustomer.Focus();
                    return false;
                }
                else if (String.IsNullOrEmpty(this.GoodWill))
                {
                    this.cboGoodWill.Focus();
                    return false;
                }
                else if (String.IsNullOrEmpty(this.ForceSaleValueOfLand.ToString()))
                {
                    this.txtForceSaleValueOfLand.Focus();
                    return false;
                }
                else if (String.IsNullOrEmpty(this.ForceSaleValueOfBuilding.ToString()))
                {
                    this.txtForceSaleValueOfBuilding.Focus();
                    return false;
                }
                else if (String.IsNullOrEmpty(this.Address))
                {
                    this.txtAddress.Focus();
                    return false;
                }
                else if (String.IsNullOrEmpty(this.HistoryOfLand_Building))
                {
                    this.cboHistoryOfLand.Focus();
                    return false;
                }
                else if (String.IsNullOrEmpty(this.BuildingConstructionPermit))
                {
                    this.cboBuildingConPermit.Focus();
                    return false;
                }
            }

            #endregion

            #region Guarantee
            if (this.cboTypeOfProduct != null && this.cboTypeOfProduct.Text.Contains("Guarantee"))
            {
                //if (String.IsNullOrEmpty(this.GuarantorAccountNo))
                //{
                //    // CXUIMessageUtilities.ShowMessageByCode("MV00046");
                //    this.mtxtGuaranterAccountNo.Focus();
                //    return false;
                //}
                if (String.IsNullOrEmpty(this.GuarantorCompanyName))
                {
                    // CXUIMessageUtilities.ShowMessageByCode("MV00046");
                    this.txtGCompanyName.Focus();
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
            }

            #endregion

            #region Pledge

            if (!String.IsNullOrEmpty(this.cboTypeOfProduct.Text) && this.cboTypeOfProduct.Text.Contains("Pledge"))
            {
                //if (this.pledgeDtoList.Count > 0)
                //{
                //    foreach (LOMDTO00016 dto in pledgeDtoList)
                //    {
                //        if (    (dto.StockNo == "") || (dto.StockNo == null) ||
                //         (dto.StockName == "") || (dto.StockName == null) ||
                //         (dto.StockQTY == 0) || (dto.StockQTY == null) ||
                //         (dto.Market_VAL == 0) || (dto.Market_VAL == null))
                //        {
                //            //CXUIMessageUtilities.ShowMessageByCode("MV00046");
                //            this.gdvStock.Focus();
                //            return false;
                //        }
                //    }


                //}
                //else
                //{
                //    this.gdvStock.Focus();
                //    return false;
                //}

                foreach (DataGridViewRow row in this.gdvStock.Rows)
                {
                    if ((Convert.ToString(row.Cells["colStockNo"].Value) == "") ||
                     (row.Cells["colStockNo"].Value == null) ||
                 (Convert.ToString(row.Cells["colStockName"].Value) == "") ||
                     (row.Cells["colStockName"].Value == null) ||
                 (Convert.ToString(row.Cells["colStockQuantity"].Value) == "") ||
                     (row.Cells["colStockQuantity"].Value == null) ||
                 (Convert.ToString(row.Cells["colMarketValue"].Value) == "") ||
                     (row.Cells["colMarketValue"].Value == null))
                    {
                        //CXUIMessageUtilities.ShowMessageByCode("MV00046");
                        this.gdvStock.Focus();
                        return true;
                    }
                }


            }
            #endregion

            #region Hypothecation
            if (this.cboTypeOfProduct != null && this.cboTypeOfProduct.Text.Contains("Hypothecation"))
            {
                if (String.IsNullOrEmpty(this.KindOfStock))
                {
                    //CXUIMessageUtilities.ShowMessageByCode("MV00046");
                    this.cboKindOfStock.Focus();
                    return false;
                }
                else if (String.IsNullOrEmpty(this.Value.ToString()))
                {
                    CXUIMessageUtilities.ShowMessageByCode("MV00046");
                    this.txtValue.Focus();
                    return false;
                }
            }
            #endregion

            #region Gold And Jewellery

            if (!String.IsNullOrEmpty(this.cboTypeOfProduct.Text) && this.cboTypeOfProduct.Text.Contains("Gold"))
            {
                //For Type Of Gold
                //if (this.gdvTypeOfGold.DataSource != null)
                //{
                foreach (DataGridViewRow row in gdvTypeOfGold.Rows)
                {
                    if ((Convert.ToString(row.Cells["colType"].Value) != "") ||
                     (row.Cells["colType"].Value != null) ||
                 (Convert.ToString(row.Cells["colDescription"].Value) != "") ||
                     (row.Cells["colDescription"].Value != null) ||
                 (Convert.ToString(row.Cells["colQuantity"].Value) != "") ||
                     (row.Cells["colQuantity"].Value != null) ||
                 (Convert.ToString(row.Cells["colWeight"].Value) != "") ||
                     (row.Cells["colWeight"].Value != null) ||
                         (Convert.ToString(row.Cells["colValue"].Value) != "") ||
                     (row.Cells["colValue"].Value != null))
                    {
                        //CXUIMessageUtilities.ShowMessageByCode("MV00046");
                        //this.gdvTypeOfGold.Focus();
                        return true;
                    }
                }
                //}
                //else
                //{
                //    this.gdvTypeOfGold.Focus();
                //    return false;
                //}

                //For Kind Of Gold
                if (this.gdvKindOfGold.DataSource != null)
                {
                    foreach (DataGridViewRow row in gdvKindOfGold.Rows)
                    {
                        if ((Convert.ToString(row.Cells["colKind"].Value) != "") ||
                         (row.Cells["colKind"].Value != null) ||
                     (Convert.ToString(row.Cells["colKindDescription"].Value) != "") ||
                         (row.Cells["colKindDescription"].Value != null) ||
                     (Convert.ToString(row.Cells["colKindQuantity"].Value) != "") ||
                         (row.Cells["colKindQuantity"].Value != null))
                        {
                            //CXUIMessageUtilities.ShowMessageByCode("MV00046");
                            this.gdvKindOfGold.Focus();
                            return false;
                        }
                    }
                }
                else
                {
                    this.gdvKindOfGold.Focus();
                    return false;
                }
            }
            #endregion

            #region Interest

            if (!String.IsNullOrEmpty(TypeOfAdvance) && this.TypeOfAdvance.Contains("LOANS"))
            {
                if (String.IsNullOrEmpty(this.RepaymentDuration.ToString()))
                {
                    CXUIMessageUtilities.ShowMessageByCode("MV90087");
                    //this.txtRepaymentDuration.Focus();
                    this.cboRepayment.Focus();
                    return false;
                }
                //if (String.IsNullOrEmpty(this.RepaymentPeriod.ToString()))
                //{
                //    //CXUIMessageUtilities.ShowMessageByCode("MV00046");
                //    this.txtRepaymentPeriod.Focus();
                //    return false;
                //}
                //My update 2017
                //else if (this.gdvLoanInterest.DataSource == null)
                //{
                //    //CXUIMessageUtilities.ShowMessageByCode("MV00046");
                //    this.gdvLoanInterest.Focus();
                //    return false;
                //}
            }
            else if (!String.IsNullOrEmpty(TypeOfAdvance) && this.TypeOfAdvance.Contains("OVERDRAFT"))
            {
                if (this.IsUsedBal)
                {
                    if (this.txtUnUsedBalRate.Text == null)
                    {
                        //CXUIMessageUtilities.ShowMessageByCode("MV00046");
                        this.txtUnUsedBalRate.Focus();
                        return false;
                    }
                    else if (this.txtUsedBalRate.Text == null)
                    {
                        //CXUIMessageUtilities.ShowMessageByCode("MV00046");
                        this.txtUsedBalRate.Focus();
                        return false;
                    }
                }
                else
                {
                    if (this.txtUsedOverHalfRate.Text == null)
                    {
                        //CXUIMessageUtilities.ShowMessageByCode("MV00046");
                        this.txtUsedOverHalfRate.Focus();
                        return false;
                    }
                    else if (this.txtUsedUnderHalfRate.Text == null)
                    {
                        //CXUIMessageUtilities.ShowMessageByCode("MV00046");
                        this.txtUsedUnderHalfRate.Focus();
                        return false;
                    }
                    else if (this.txtMiddleUnUsedRate.Text == null)
                    {
                        //CXUIMessageUtilities.ShowMessageByCode("MV00046");
                        this.txtMiddleUnUsedRate.Focus();
                        return false;
                    }
                }

            }

            #endregion

            #region SanctionAmount

            //else if (String.IsNullOrEmpty(this.SanctionAmount.ToString()) && this.SanctionAmount.ToString() == "0.00" && this.SanctionAmount.ToString() == "0" && this.SanctionAmount.ToString().StartsWith(decimal.Zero.ToString()))
            //{
            //    //CXUIMessageUtilities.ShowMessageByCode("MV00046");
            //    this.txtSanctionAmount.Focus();
            //    return false;s
            //}

            if (!String.IsNullOrEmpty(this.SanctionAmount.ToString()) && this.SanctionAmount == decimal.Zero)
            {
                //CXUIMessageUtilities.ShowMessageByCode("MV00046");
                this.txtSanctionAmount.Focus();
                return false;
            }

            #endregion

            #region For Insurance
            if (this.cboTypeOfProduct != null)
            {
                if (this.cboTypeOfProduct.Text.Contains("Land"))
                {
                    if (String.IsNullOrEmpty(this.TypeOfInsurance))
                    {
                        //CXUIMessageUtilities.ShowMessageByCode("MV00046");
                        this.cboTypeOfInsuranceForLand_Bld.Focus();
                        return false;
                    }

                    else if (String.IsNullOrEmpty(this.InsuranceAmount.ToString()))
                    {
                        //CXUIMessageUtilities.ShowMessageByCode("MV00046");
                        this.txtInsuranceAmount.Focus();
                        return false;
                    }
                }
                else if (this.cboTypeOfProduct.Text.Contains("Pledge"))
                {
                    if (String.IsNullOrEmpty(this.TypeOfInsuranceForPledge))
                    {
                        //CXUIMessageUtilities.ShowMessageByCode("MV00046");
                        this.cboTypeOfInsuranceForPledge.Focus();
                        return false;
                    }

                    else if (String.IsNullOrEmpty(this.InsuranceAmountForPledge.ToString()))
                    {
                        //CXUIMessageUtilities.ShowMessageByCode("MV00046");
                        this.txtIsAmountForPledge.Focus();
                        return false;
                    }
                }
                else if (this.cboTypeOfProduct.Text.Contains("Hypothecation"))
                {
                    if (String.IsNullOrEmpty(this.TypeOfInsuranceForHypo))
                    {
                        this.cboTypeOfInsuranceForHypo.Focus();
                        return false;
                    }

                    else if (String.IsNullOrEmpty(this.InsuranceAmountForHypo.ToString()))
                    {
                        //CXUIMessageUtilities.ShowMessageByCode("MV00046");
                        this.txtIsAmountForHypo.Focus();
                        return false;
                    }
                }
            }

            else return true;

            #endregion

            #region Penal Fee

            if (this.chkPenalFee.Checked)
            {
                if (String.IsNullOrEmpty(this.txtPenalDuration.Text))
                {
                    //  CXUIMessageUtilities.ShowMessageByCode("MV00034");
                    this.txtPenalDuration.Focus();

                    return false;
                }
                //if (this.gdvPenalFee.DataSource != null)
                //{
                foreach (DataGridViewRow row in gdvPenalFee.Rows)
                {
                    if ((Convert.ToString(row.Cells["colStartPeriod"].Value) != "") ||
                     (row.Cells["colStartPeriod"].Value != null) ||
                 (Convert.ToString(row.Cells["colEndPeriod"].Value) != "") ||
                     (row.Cells["colEndPeriod"].Value != null) ||
                 (Convert.ToString(row.Cells["colPenalFee"].Value) != "") ||
                     (row.Cells["colPenalFee"].Value != null) ||
                 (Convert.ToString(row.Cells["colAmount"].Value) != "") ||
                     (row.Cells["colAmount"].Value != null))
                    {
                        //CXUIMessageUtilities.ShowMessageByCode("MV00046");
                        // this.gdvPenalFee.Focus();
                        return true;
                    }
                }
                //}
                //else
                //{
                //    this.gdvPenalFee.Focus();
                //    return false;
                //}

            }

            #endregion

            return true;
        }

        public void ClearFormControls()
        {
            this.txtLoanNo.Text = string.Empty; // Uncommented By AAM(31-Jan-2018)
            this.mtxtAccountNo.Text = string.Empty;
            this.cboCurrency.SelectedIndex = 0;
            this.cboTypeOfAdvance.SelectedIndex = -1;
            this.mcboTypeOfBusiness.SelectedIndex = -1;
            this.txtAssessorName.Text = string.Empty;
            this.txtLawerName.Text = string.Empty;
            this.cboTypeOfProduct.SelectedIndex = -1;
            this.txtAddress.Text = string.Empty;
            this.mtxtPLandBS.Text = string.Empty;
            this.txtYearExperience.Text = string.Empty;
            this.txtCapital.Text = "0.00";
            this.txtIncomeTax.Text = "0.00";
            this.txtForceSaleValueOfBuilding.Text = "0.00";
            this.txtForceSaleValueOfLand.Text = "0.00";
            this.chkEdit.Checked = false;
            this.chkEditDocAmt.Checked = false;
            this.chkGracePeriod.Checked = false;
            this.txtDocumentFee.Text = "0.00";
            this.txtGracePeriod.Text = "0";
            this.txtGLAcode.Text = "";
            this.cboTypeOfInsuranceForLand_Bld.SelectedIndex = -1;
            this.dtpDateOfInsurance.Value = DateTime.Now;
            this.dtpInsuranceExpireDate.Value = DateTime.Now;
            this.dtpLandStartDate.Value = DateTime.Now;
            this.dtpLEndDate.Value = DateTime.Now;
            this.RemarkForLand = string.Empty;

            this.cboTypeOfInsuranceForPledge.SelectedIndex = -1;
            this.dtpDateInuranceForPledge.Value = DateTime.Now;
            this.dtpIsExpiredDateForPledge.Value = DateTime.Now;

            this.cboTypeOfInsuranceForHypo.SelectedIndex = -1;
            this.DtpIsExpiredDateForHypo.Value = DateTime.Now;
            this.dtpDateInsuranceForHypo.Value = DateTime.Now;

            this.txtInsuranceAmount.Text = "0.00";
            this.txtIsAmountForPledge.Text = "0.00";
            this.txtIsAmountForHypo.Text = "0.00";

            this.cboKindOfStock.SelectedIndex = -1;
            this.txtValue.Text = "0.00";

            this.txtGuarantorName.Text = string.Empty;
            this.txtGuarantorNrc.Text = string.Empty;
            this.txtGuarantorPhone.Text = string.Empty;
            //this.mtxtGuaranterAccountNo.Text = string.Empty;
            this.txtGCompanyName.Text = string.Empty;

            this.gdvAccountInfo.DataSource = null;
            this.gdvAccountInfo.Rows.Clear();

            //My update 2017
            //this.gdvLoanInterest.DataSource = null;
            //this.gdvLoanInterest.Rows.Clear();

            this.gdvStock.DataSource = null;
            this.gdvStock.Rows.Clear();

            this.gdvTypeOfGold.DataSource = null;
            this.gdvTypeOfGold.Rows.Clear();

            this.gdvKindOfGold.DataSource = null;
            this.gdvKindOfGold.Rows.Clear();

            this.gdvPenalFee.DataSource = null;
            this.gdvPenalFee.Rows.Clear();

            //this.cboRepaymentPeriod.SelectedIndex = -1 ;
            this.txtRepaymentDuration.Text = string.Empty;
            this.txtRepaymentPeriod.Text = string.Empty;

            this.txtUnUsedBalRate.Text = "0.00";
            this.txtMiddleUnUsedRate.Text = "0.00";
            this.txtUsedBalRate.Text = "0.00";
            this.txtUsedOverHalfRate.Text = "0.00";
            this.txtUsedUnderHalfRate.Text = "0.00";

            this.chkServiceCharges.Checked = false;

            this.txtPenalDuration.Text = string.Empty;
            this.cboRepayment.SelectedIndex = -1;
            this.lblTypeOfInsuranceForHypo.Visible = false;
            this.lblTypeOfInsuranceForLand_Bld.Visible = false;
            this.lblTypeOfInsuranceForPledge.Visible = false;
            this.lblKindOfStock2.Visible = false;
            this.lblTypeOfBusiness2.Visible = false;
            this.lblLand2.Visible = false;
            //this.txtSanctionAmount.Text = "";

            // Added By AAM (31-Jan-2018)
            this.txtSanctionAmount.Text = "0.00";
            this.txtSanctionAmountEncode.Text = "0.00";
            txtSanctionAmountEncode.Visible = true;
            txtSanctionAmount.Visible = false;
            needToCheck = false;
 
            if (this.formname.Contains("Entry"))
            {
                //Start();
            }
            this.cboCurrency.Focus();
        }

        public void GetFormControlSetting()
        {
            if (this.formname.Contains("Enquiry") || this.formname.Contains("Edit"))
            {
                if (this.formname.Contains("Enquiry"))
                {
                    this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, false, true);
                }
                else
                {
                    this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
                }
                this.txtAssessorName.Enabled = false;
                this.txtLawerName.Enabled = false;
                this.mcboTypeOfBusiness.Enabled = false;
                this.dtpExpireDate.Enabled = false;
                this.mtxtAccountNo.Enabled = false;
                this.cboCurrency.Enabled = false;

                this.cboTypeOfAdvance.Enabled = false;
                this.cboTypeOfProduct.Enabled = false;
                this.grpSanctionAmount.Enabled = false;
                this.grpLoanInterest.Enabled = false;
                this.grpODInterest.Enabled = false;
                //this.isSaveValidate = true;
            }
            else
            {
                this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
                this.txtLoanNo.Enabled = false;
                this.cboCurrency.Enabled = true;
                this.cboCurrency.Focus();

                //this.Start();
            }

            this.cboTypeOfProduct.Enabled = true;
            this.BindTypeOfAdvance();
            this.BindTypeOfBusiness();
            this.BindLoanProduct();
            this.BindCurrency();
            //this.BindInstallmentPeriod();
            this.BindPrincipleRepayPeriod();
            this.BindInterestRepayPeriod();
            //  this.dtpExpireDate.Value = DateTime.Now.AddYears(1);
            this.lblSanctionDate2.Text = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            //this.mtxtGuaranterAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);

            #region PenalFee
            this.chkPenalFee.Checked = false;
            this.txtPenalDuration.Enabled = false;
            this.gdvPenalFee.Enabled = false;

            #endregion

            this.lblLand2.Visible = false;
            this.lblTypeOfBusiness2.Visible = false;
            this.lblNameOfFirm2.Visible = false;
            this.lblTypeOfInsuranceForLand_Bld.Visible = false;

            #region Interest and Repayment
            this.grpLoanInterest.Enabled = false;
            this.grpLoanInterest.Visible = true;

            this.grpODInterest.Enabled = true;
            this.grpODInterest.Visible = true;

            this.rdoUsedBal.Checked = true;
            this.txtUsedBalRate.Enabled = true;
            this.txtUnUsedBalRate.Enabled = true;
            this.txtMiddleUnUsedRate.Enabled = false;
            this.txtUsedOverHalfRate.Enabled = false;
            this.txtUsedUnderHalfRate.Enabled = false;

            #endregion

            this.tbLoanProduct.Enabled = false;
            this.tbLoanProduct.SelectedTab = tbpLandAndBuilding;
            ((Control)this.tbpLandAndBuilding).Enabled = false;
            ((Control)this.tbpPersonalGuarantee).Enabled = false;
            ((Control)this.tbpPledge).Enabled = false;
            ((Control)this.tbpHypothecation).Enabled = false;
            ((Control)this.tbpGoldandJewellery).Enabled = false;

            this.lblKindOfStock2.Visible = false;
            this.lblTypeOfInsuranceForLand_Bld.Visible = false;
            this.lblTypeOfInsuranceForPledge.Visible = false;
            this.lblTypeOfInsuranceForHypo.Visible = false;
            this.lblLand2.Visible = false;
        }

        #endregion

        #region Get ViewData To Save

        //private IList<LOMDTO00021> getInterestList;        
        // My update 2017
        //public IList<LOMDTO00021> GetInterestList()
        //{

        //    IList<LOMDTO00021> getInterestList = new List<LOMDTO00021>();
        //    foreach (DataGridViewRow row in gdvLoanInterest.Rows)
        //    {
        //        if ((Convert.ToString(row.Cells["colTerm"].Value) != "") &&
        //              (row.Cells["colTerm"].Value != null) &&
        //          (Convert.ToString(row.Cells["colStartDate"].Value) != "") &&
        //              (row.Cells["colStartDate"].Value != null) &&
        //          (Convert.ToString(row.Cells["colEndDate"].Value) != "") &&
        //              (row.Cells["colEndDate"].Value != null))
        //          //(Convert.ToString(row.Cells["colRate"].Value) != "") &&
        //          //    (row.Cells["colRate"].Value != null))
        //        {
        //            LOMDTO00021 interestDto = new LOMDTO00021();
        //            interestDto.TNo = Convert.ToString(row.Cells["colTerm"].Value);
        //            interestDto.StartDate = Convert.ToDateTime(row.Cells["colStartDate"].Value);
        //            interestDto.EndDate = Convert.ToDateTime(row.Cells["colEndDate"].Value);
        //            interestDto.IntRate = Convert.ToDecimal(this.Rate);
        //            interestDto.ACSign = this.controller.Acsign;
        //            interestDto.Acctno = this.AccountNo;
        //            interestDto.LNo = this.LoanNo;
        //            interestDto.UserNo = CurrentUserEntity.CurrentUserID.ToString();
        //            interestDto.SourceBr = this.controller.BranchCode;
        //            interestDto.RepaymentPeriod = this.RepaymentPeriod;
        //            interestDto.Duration = this.RepaymentDuration;
        //            interestDto.CreatedDate = DateTime.Now;
        //            interestDto.CreatedUserId = CurrentUserEntity.CurrentUserID;
        //            getInterestList.Add(interestDto);
        //        }

        //    }
        //    return getInterestList;
        //}

        //private IList<LOMDTO00012> getPenalFeeList;
        public IList<LOMDTO00012> GetPenalFeeList()
        {
            //get
            //{
            IList<LOMDTO00012> getPenalFeeList = new List<LOMDTO00012>();
            foreach (DataGridViewRow row in this.gdvPenalFee.Rows)
            {
                if ((Convert.ToString(row.Cells["colStartPeriod"].Value) != "") &&
                        (row.Cells["colStartPeriod"].Value != null) &&
                    (Convert.ToString(row.Cells["colEndPeriod"].Value) != "") &&
                        (row.Cells["colEndPeriod"].Value != null) &&
                    (Convert.ToString(row.Cells["colPenalFee"].Value) != "") &&
                        (row.Cells["colPenalFee"].Value != null) &&
                     (Convert.ToString(row.Cells["colAmount"].Value) != "") &&
                        (row.Cells["colAmount"].Value != null))
                {
                    LOMDTO00012 penalDto = new LOMDTO00012();

                    penalDto.StartDay = Convert.ToInt32(row.Cells["colStartPeriod"].Value);
                    penalDto.EndDay = Convert.ToInt32(row.Cells["colEndPeriod"].Value);
                    penalDto.Fee = Convert.ToInt32(row.Cells["colPenalFee"].Value);
                    penalDto.Amount = Convert.ToInt32(row.Cells["colAmount"].Value);
                    penalDto.Lno = this.LoanNo;
                    penalDto.Duration = this.Duration;
                    penalDto.CreatedDate = DateTime.Now;
                    penalDto.CreatedUserId = CurrentUserEntity.CurrentUserID;
                    getPenalFeeList.Add(penalDto);
                }

            }

            return getPenalFeeList;
            //}
            //set { this.getPenalFeeList = value; }
        }

        private TLMDTO00018 getViewDataForCommon;
        public TLMDTO00018 GetViewDataForCommon
        {
            get
            {
                if (this.getViewDataForCommon == null) getViewDataForCommon = new TLMDTO00018();
                getViewDataForCommon.AccountNo = this.AccountNo;
                getViewDataForCommon.Lno = this.LoanNo;
                getViewDataForCommon.AType = this.TypeOfAdvance;
                getViewDataForCommon.Lawer = this.LawerName;
                getViewDataForCommon.Assessor = this.AssessorName;
                getViewDataForCommon.ExpireDate = this.ExpiredDate;
                getViewDataForCommon.SAmount = this.SanctionAmount;
                getViewDataForCommon.SDate = DateTime.Now;
                getViewDataForCommon.BType = this.TypeOfBusiness;
                getViewDataForCommon.IntRate = 0;
                getViewDataForCommon.Time = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
                getViewDataForCommon.FirstSAmount = this.SanctionAmount;
                getViewDataForCommon.SAmount = this.SanctionAmount;
                getViewDataForCommon.DocFee = Convert.ToDecimal(this.DocFee);
                getViewDataForCommon.GracePeriod = Convert.ToInt16(this.GracePeriod);
                getViewDataForCommon.PrincipleRepayOptions = this.PrincipleRepaymentOption;
                getViewDataForCommon.InterestRepayOptions = this.InterestRepaymentOption;
                getViewDataForCommon.RelatedGLACode = this.RelatedGLACode;
                getViewDataForCommon.Min_Period = Convert.ToInt16(this.RepaymentDuration);
                if (this.registerType == 1)
                    getViewDataForCommon.Loans_Type = "LB";
                else if (this.registerType == 2)
                    getViewDataForCommon.Loans_Type = "PG";
                else if (this.registerType == 3)
                    getViewDataForCommon.Loans_Type = "PL";
                else if (this.registerType == 4)
                    getViewDataForCommon.Loans_Type = "HP";
                else
                    getViewDataForCommon.Loans_Type = "GJ";

                //getViewDataForCommon.BalStatus = "UsedBal";
                getViewDataForCommon.LegalCase = false;
                getViewDataForCommon.NPLCase = false;
                getViewDataForCommon.Vouchered = false;
                getViewDataForCommon.ACSign = this.controller.Acsign;
                getViewDataForCommon.SourceBranchCode = this.controller.BranchCode;
                getViewDataForCommon.Currency = this.CurrencyCode;
                getViewDataForCommon.UserNo = CurrentUserEntity.CurrentUserID.ToString();
                getViewDataForCommon.CreatedDate = DateTime.Now;
                getViewDataForCommon.CreatedUserId = CurrentUserEntity.CurrentUserID;

                if (this.chkServiceCharges.Checked)//To get Service Charges or NOt
                {
                    PFMDTO00009 ratedto = new PFMDTO00009();

                    if (this.TypeOfAdvance.Contains("OVERDRAFT"))
                        ratedto = CXCLE00002.Instance.GetScalarObject<PFMDTO00009>("PFMORM00009.Client.SelectByCodeAndLastModify", new object[] { "ODSCHARGERATE", true, true }); //hm
                    else if (this.TypeOfAdvance.Contains("LOANS"))
                        ratedto = CXCLE00002.Instance.GetScalarObject<PFMDTO00009>("PFMORM00009.Client.SelectByCodeAndLastModify", new object[] { "LOANSCHARGERATE", true, true }); //hm

                    getViewDataForCommon.isScharge = true;
                    getViewDataForCommon.serviceChargesRate = ratedto.Rate;

                }

                else
                    getViewDataForCommon.isScharge = false;

                if (this.chkPenalFee.Checked)//To get PenalFee Charges or NOt
                    getViewDataForCommon.isPFcharge = true;
                else
                    getViewDataForCommon.isPFcharge = false;

                if (this.TypeOfAdvance.Contains("OVERDRAFT"))
                {
                    getViewDataForCommon.Charges_Status = "Y";
                    if (this.rdoUsedBal.Checked)
                    {
                        getViewDataForCommon.BalStatus = "UsedBal";
                        getViewDataForCommon.IntRate = this.UsedRateForUsedBal;
                        getViewDataForCommon.UnUsedRate = this.UnUsedRateForUsedBal;
                    }
                    else
                    {
                        getViewDataForCommon.BalStatus = "MiddleBal";
                        getViewDataForCommon.IntRate = this.UsedUnderHalfRate;
                        getViewDataForCommon.UsedOverRate = this.UsedOverHalfRate;
                        getViewDataForCommon.UnUsedRate = this.MiddleUnUsedRate;
                    }
                }
                else
                {
                    getViewDataForCommon.Charges_Status = string.Empty;
                    getViewDataForCommon.BalStatus = "UsedBal";
                }

                return getViewDataForCommon;
            }

            set { this.getViewDataForCommon = value; }
        }

        private LOMDTO00015 getViewDataForLandAndBuilding;
        public LOMDTO00015 GetViewDataForLandAndBuilding
        {
            get
            {
                if (this.getViewDataForLandAndBuilding == null) getViewDataForLandAndBuilding = new LOMDTO00015();

                getViewDataForLandAndBuilding.LNo = this.LoanNo;
                getViewDataForLandAndBuilding.Tax = this.IncomeTax;
                getViewDataForLandAndBuilding.IsAMT = this.InsuranceAmount;
                getViewDataForLandAndBuilding.IsType = this.TypeOfInsurance;
                getViewDataForLandAndBuilding.PADV = "";
                getViewDataForLandAndBuilding.Class = "";
                getViewDataForLandAndBuilding.SType = "";
                getViewDataForLandAndBuilding.Power = "";
                getViewDataForLandAndBuilding.IsExpiredDate = this.ExpiredDate;
                getViewDataForLandAndBuilding.SourceBr = this.controller.BranchCode;
                getViewDataForLandAndBuilding.Cur = this.CurrencyCode;
                getViewDataForLandAndBuilding.Capital = this.Capital;
                getViewDataForLandAndBuilding.ExpYear = this.YearOfExperience;
                getViewDataForLandAndBuilding.EDate = this.EstablishmentDate;
                getViewDataForLandAndBuilding.Char = this.CharacterOfCustomer;
                getViewDataForLandAndBuilding.GW = this.GoodWill;
                getViewDataForLandAndBuilding.YearPB = this.YearOfPLBS;
                getViewDataForLandAndBuilding.Address = this.Address;
                getViewDataForLandAndBuilding.IsDate = this.DateOfInsurance;
                getViewDataForLandAndBuilding.SDEED = this.SalesDeed;
                getViewDataForLandAndBuilding.LAFFID = this.LandOfAffidavit;
                getViewDataForLandAndBuilding.Land = this.Land;
                getViewDataForLandAndBuilding.HISLB = this.HistoryOfLand_Building;
                getViewDataForLandAndBuilding.BPERMIT = this.BuildingConstructionPermit;
                getViewDataForLandAndBuilding.DDate = DateTime.Now;
                getViewDataForLandAndBuilding.FSVBLD = this.ForceSaleValueOfBuilding;
                getViewDataForLandAndBuilding.FSVLand = this.ForceSaleValueOfLand;
                getViewDataForLandAndBuilding.LandLeaseSDate = this.LandLeaseSDate;
                getViewDataForLandAndBuilding.LandLeaseEDate = this.LandLeaseEDate;
                getViewDataForLandAndBuilding.RemarkForLand = this.RemarkForLand;
                getViewDataForLandAndBuilding.CreatedDate = DateTime.Now;
                getViewDataForLandAndBuilding.CreatedUserId = CurrentUserEntity.CurrentUserID;
                // left Eva value 
                return getViewDataForLandAndBuilding;
            }
            set { this.getViewDataForLandAndBuilding = value; }
        }

        private PFMDTO00039 getViewDataForGuarantee;
        public PFMDTO00039 GetViewDataForGuarantee
        {
            get
            {
                if (getViewDataForGuarantee == null) getViewDataForGuarantee = new PFMDTO00039();

                getViewDataForGuarantee.LNo = this.LoanNo;
                getViewDataForGuarantee.Address = this.controller.Guarantee_Address;
                getViewDataForGuarantee.AccountSignature = this.controller.Acsign;
                getViewDataForGuarantee.BranchCode = this.controller.BranchCode;
                getViewDataForGuarantee.CurrencyCode = this.CurrencyCode;
                //getViewDataForGuarantee.AccountNo = this.GuarantorAccountNo;
                getViewDataForGuarantee.GuarantorCompanyName = this.GuarantorCompanyName;
                getViewDataForGuarantee.Name = this.GuarantorName;
                getViewDataForGuarantee.NRC = this.GuarantorNrc;
                getViewDataForGuarantee.Phone = this.GuarantorPhone;
                getViewDataForGuarantee.CreatedDate = DateTime.Now;
                getViewDataForGuarantee.CreatedUserId = CurrentUserEntity.CurrentUserID;

                return getViewDataForGuarantee;
            }
            set { this.getViewDataForGuarantee = value; }

        }

        //private IList<LOMDTO00016> getViewDataForPledge;
        public IList<LOMDTO00016> GetViewDataForPledge()
        {
            //get
            //{
            //    if (getViewDataForPledge.Count ==0 )
            IList<LOMDTO00016> getViewDataForPledge = new List<LOMDTO00016>();
            foreach (DataGridViewRow row in this.gdvStock.Rows)
            {
                if ((Convert.ToString(row.Cells["colStockNo"].Value) != "") &&
                        (row.Cells["colStockNo"].Value != null) &&
                    (Convert.ToString(row.Cells["colStockName"].Value) != "") &&
                        (row.Cells["colStockName"].Value != null) &&
                    (Convert.ToString(row.Cells["colStockQuantity"].Value) != "") &&
                        (row.Cells["colStockQuantity"].Value != null) &&
                    (Convert.ToString(row.Cells["colMarketValue"].Value) != "") &&
                        (row.Cells["colMarketValue"].Value != null))
                {
                    LOMDTO00016 pledgeDto = new LOMDTO00016();

                    pledgeDto.StockNo = Convert.ToString(row.Cells["colStockNo"].Value);
                    pledgeDto.StockQTY = Convert.ToDecimal(row.Cells["colStockQuantity"].Value);
                    pledgeDto.Market_VAL = Convert.ToDecimal(row.Cells["colMarketValue"].Value);

                    pledgeDto.LNo = this.LoanNo;
                    pledgeDto.IsType = this.TypeOfInsuranceForPledge;
                    pledgeDto.IsDate = this.DateOfInsuranceForPledge;
                    pledgeDto.IsExpiredDate = this.InsuranceExpireDateForPledge;
                    pledgeDto.IsAMT = this.InsuranceAmountForPledge;
                    pledgeDto.SourceBr = this.controller.BranchCode;
                    pledgeDto.CreatedDate = DateTime.Now;
                    pledgeDto.CreatedUserId = CurrentUserEntity.CurrentUserID;

                    getViewDataForPledge.Add(pledgeDto);
                }

            }

            return getViewDataForPledge;
            //    }
            //    set { this.getViewDataForPledge = value; }
        }

        //private IList<LOMDTO00018> getViewDataForGoldAndJewelleryType;
        public IList<LOMDTO00018> GetViewDataForGoldAndJewelleryType()
        {
            //get
            //{
            //    //if (getViewDataForGoldAndJewelleryType.Count == 0)
            IList<LOMDTO00018> getViewDataForGoldAndJewelleryType = new List<LOMDTO00018>();
            foreach (DataGridViewRow row in this.gdvTypeOfGold.Rows)
            {
                if ((Convert.ToString(row.Cells["colType"].Value) != "") &&
                        (row.Cells["colType"].Value != null) &&
                    (Convert.ToString(row.Cells["colDescription"].Value) != "") &&
                        (row.Cells["colDescription"].Value != null) &&
                    (Convert.ToString(row.Cells["colQuantity"].Value) != "") &&
                        (row.Cells["colQuantity"].Value != null) &&
                    (Convert.ToString(row.Cells["colWeight"].Value) != "") &&
                        (row.Cells["colWeight"].Value != null) &&
                    (Convert.ToString(row.Cells["colValue"].Value) != "") &&
                        (row.Cells["colValue"].Value != null))
                {
                    LOMDTO00018 gjTypeDto = new LOMDTO00018();

                    gjTypeDto.GJType = Convert.ToString(row.Cells["colType"].Value);
                    gjTypeDto.Quantity = Convert.ToDecimal(row.Cells["colQuantity"].Value);
                    gjTypeDto.Weight = Convert.ToString(row.Cells["colWeight"].Value);
                    gjTypeDto.Value = Convert.ToDecimal(row.Cells["colValue"].Value);

                    gjTypeDto.LNo = this.LoanNo;
                    gjTypeDto.SourceBr = this.controller.BranchCode;
                    gjTypeDto.CreatedDate = DateTime.Now;
                    gjTypeDto.CreatedUserId = CurrentUserEntity.CurrentUserID;

                    getViewDataForGoldAndJewelleryType.Add(gjTypeDto);
                }
            }

            return getViewDataForGoldAndJewelleryType;
            // }
            // set { this.getViewDataForGoldAndJewelleryType = value; }

        }

        // private IList<LOMDTO00018> getViewDataForGoldAndJewelleryKind;
        public IList<LOMDTO00018> GetViewDataForGoldAndJewelleryKind()
        {
            //get
            //{

            //    if(getViewDataForGoldAndJewelleryKind.Count ==0)
            IList<LOMDTO00018> getViewDataForGoldAndJewelleryKind = new List<LOMDTO00018>();
            foreach (DataGridViewRow row in this.gdvKindOfGold.Rows)
            {
                if ((Convert.ToString(row.Cells["colKind"].Value) != "") &&
                        (row.Cells["colKind"].Value != null) &&
                    (Convert.ToString(row.Cells["colKindDescription"].Value) != "") &&
                        (row.Cells["colKindDescription"].Value != null) &&
                    (Convert.ToString(row.Cells["colKindQuantity"].Value) != "") &&
                        (row.Cells["colKindQuantity"].Value != null))
                {
                    LOMDTO00018 gjKindDto = new LOMDTO00018();

                    gjKindDto.GJType = Convert.ToString(row.Cells["colKind"].Value);
                    gjKindDto.Quantity = Convert.ToDecimal(row.Cells["colKindQuantity"].Value);

                    gjKindDto.LNo = this.LoanNo;
                    gjKindDto.SourceBr = this.controller.BranchCode;
                    gjKindDto.CreatedDate = DateTime.Now;
                    gjKindDto.CreatedUserId = CurrentUserEntity.CurrentUserID;

                    getViewDataForGoldAndJewelleryKind.Add(gjKindDto);
                }
            }

            return getViewDataForGoldAndJewelleryKind;
            //}

            //set { this.getViewDataForGoldAndJewelleryKind = value; }
        }

        private LOMDTO00017 getViewDataForHypothecation;
        public LOMDTO00017 GetViewDataForHypothecation
        {
            get
            {
                if (this.getViewDataForHypothecation == null) getViewDataForHypothecation = new LOMDTO00017();
                getViewDataForHypothecation.LNo = this.LoanNo;
                getViewDataForHypothecation.KStock = this.KindOfStock;
                getViewDataForHypothecation.Value = this.Value;
                getViewDataForHypothecation.IsType = this.TypeOfInsuranceForHypo;
                getViewDataForHypothecation.IsDate = this.DateOfInsuranceForHypo;
                getViewDataForHypothecation.IsExpiredDate = this.InsuranceExpireDateForHypo;
                getViewDataForHypothecation.IsAMT = this.InsuranceAmountForHypo;
                getViewDataForHypothecation.SourceBr = this.controller.BranchCode;
                getViewDataForHypothecation.CreatedDate = DateTime.Now;
                getViewDataForHypothecation.CreatedUserId = CurrentUserEntity.CurrentUserID;

                return getViewDataForHypothecation;
            }
            set { this.getViewDataForHypothecation = value; }
        }

        #endregion


        #region Events

        private void cboTypeOfAdvance_SelectedIndexChanged(object sender, EventArgs e)
        {
            PFMDTO00009 ratedto = new PFMDTO00009();
            if (this.TypeOfAdvance.Contains("OVERDRAFT"))
            {
                this.grpODInterest.Visible = true;
                this.grpODInterest.Enabled = true;

                this.grpLoanInterest.Visible = false;
                this.grpLoanInterest.Enabled = false;
                ratedto = CXCLE00002.Instance.GetScalarObject<PFMDTO00009>("PFMORM00009.Client.SelectByCodeAndLastModify", new object[] { "ODSCHARGERATE", true, true });
                txtRate.Text = ratedto.Rate.ToString("N2");

            }
            else if (this.TypeOfAdvance.Contains("LOANS"))
            {
                this.grpODInterest.Visible = false;
                this.grpODInterest.Enabled = false;

                this.grpLoanInterest.Visible = true;
                this.grpLoanInterest.Enabled = true;
                txtRate.Enabled = false;
                //this.BindAllPaymentInterval();
                if (this.formname.Contains("Entry"))
                {
                    ratedto = CXCLE00002.Instance.GetScalarObject<PFMDTO00009>("PFMORM00009.Client.SelectByCodeAndLastModify", new object[] { "LOANSRATE", true, true });
                    txtRate.Text = ratedto.Rate.ToString("N2");
                }
        
                else
                {
                    txtRate.Text = this.Rate.ToString();
                }

                //this.BindInstallmentPeriod();
                this.BindPrincipleRepayPeriod();
                this.BindInterestRepayPeriod();
                cboRepayment.Visible = true;
            }
            if(this.formname.Contains("Entry"))
            {
                ratedto = CXCLE00002.Instance.GetScalarObject<PFMDTO00009>("PFMORM00009.Client.SelectByCodeAndLastModify", new object[] { "DOCFEE", true, true });
                txtDocumentFee.Text = Convert.ToString(ratedto.Rate);
                txtGracePeriod.Text = "0";
            }
            else
            {
                txtDocumentFee.Text = this.DocFee.ToString();
                txtGracePeriod.Text = this.GracePeriod.ToString();
            }
            txtDocumentFee.Enabled = false;
            txtGracePeriod.Enabled = false;
            
        }

        private void LOMVEW00011_Load(object sender, EventArgs e)
        {
            #region Old_Logic
            /*
            if (this.formname.Contains("Entry"))
            {
                this.txtLoanNo.ReadOnly = true;
                this.txtLoanNo.Text = string.Empty;
                this.cboCurrency.Focus();
                //Start();
                this.txtDocumentFee.Text = "";
                this.txtRate.Text = "";
                this.txtGLAcode.Text = "";
            }
            else
            {
                //this.txtLoanNo.ReadOnly = false;
                this.txtLoanNo.Text = string.Empty;
                this.txtLoanNo.Focus();
                this.txtRate.Text = "";
                this.txtDocumentFee.Text = "";
                this.txtRate.Text = "";
                this.txtGLAcode.Text = "";
            }
            //this.txtLoanNo.ReadOnly = true;
            //this.txtLoanNo.Text = string.Empty;
            //this.cboCurrency.Focus();
            this.Text = this.formname;
            this.GetFormControlSetting();
            this.isSaveValidate = false;
            this.flag = false;
            cboRepayment.Visible = true;

            this.txtSanctionAmountEncode.Text = string.Empty; // Added by AAM (31-Jan-2018)
            this.txtSanctionAmount.Text = string.Empty; // Added by AAM (31-Jan-2018)
            */
            #endregion

            #region Seperating_EOD_Logic (Added By YMP at 30-07-2019, Modified by HMW at 26-08-2019)
            DateTime systemDate = this.Controller.GetSystemDate(CurrentUserEntity.BranchCode);
            DateTime lastSettlementDate = this.controller.GetLastSettlementDate(CurrentUserEntity.BranchCode);

            this.lblTransactionDate.Text = systemDate.ToString("dd-MM-yyyy");

            if (systemDate.ToString("dd-MM-yyyy") != lastSettlementDate.ToString("dd-MM-yyyy")) //Show Form
            {
                if (this.formname.Contains("Entry"))
                {
                    this.txtLoanNo.ReadOnly = true;
                    this.txtLoanNo.Text = string.Empty;
                    this.cboCurrency.Focus();
                    this.txtDocumentFee.Text = "";
                    this.txtRate.Text = "";
                    this.txtGLAcode.Text = "";
                }
                else
                {
                    this.txtLoanNo.Text = string.Empty;
                    this.txtLoanNo.Focus();
                    this.txtRate.Text = "";
                    this.txtDocumentFee.Text = "";
                    this.txtRate.Text = "";
                    this.txtGLAcode.Text = "";
                }
                this.Text = this.formname;
                this.GetFormControlSetting();
                this.isSaveValidate = false;
                this.flag = false;
                cboRepayment.Visible = true;

                this.txtSanctionAmountEncode.Text = string.Empty; // Added by AAM (31-Jan-2018)
                this.txtSanctionAmount.Text = string.Empty; // Added by AAM (31-Jan-2018)
            }
            else //Don't show form after cut off
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI50013);//You have no permission.\n"Back Date EOD Process" needs to be completed!
                this.GetFormControlSetting();
                this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                this.DisableControls("BLRegister.AllDisable");
            }
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
                this.cboCurrency.Focus();
                this.Text = this.formname;
                this.GetFormControlSetting();
                this.isSaveValidate = false;
                this.flag = false;
                cboRepayment.Visible = true;
                cboCurrency.Enabled = true;
                mtxtAccountNo.Enabled = true;
                cboTypeOfAdvance.Enabled = true;
                txtAssessorName.Enabled = true;
                txtLawerName.Enabled = true;
                mcboTypeOfBusiness.Enabled = true;
                txtSanctionAmount.Text = "";
                cboCurrency.Focus();
            }
            //this.txtLoanNo.ReadOnly = true;
            //this.txtLoanNo.Text = string.Empty;
            //this.cboCurrency.Focus();
            //this.Text = this.formname;
            //this.GetFormControlSetting();
            //this.isSaveValidate = false;
            //this.flag = false;
            //cboRepayment.Visible = true;
            //cboCurrency.Enabled = true;
            //mtxtAccountNo.Enabled = true;
            //cboTypeOfAdvance.Enabled = true;
            //txtAssessorName.Enabled = true;
            //txtLawerName.Enabled = true;
            //mcboTypeOfBusiness.Enabled = true;            
            else
            {
                this.txtLoanNo.Text = "";
                txtLoanNo.Focus();
                this.Text = this.formname;
            }
            this.GetFormControlSetting();
            this.isSaveValidate = false;
            this.flag = false;
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.isSaveValidate = true;

            if (this.cboTypeOfProduct.Text.Contains("Land"))
            {
                this.registerType = 1;
            }
            else if (this.cboTypeOfProduct.Text.Contains("Guarantee"))
            {
                this.registerType = 2;
            }
            else if (this.cboTypeOfProduct.Text.Contains("Pledge"))
            {
                this.registerType = 3;
            }
            else if (this.cboTypeOfProduct.Text.Contains("Hypothecation"))
            {
                this.registerType = 4;
            }
            else
            {
                this.registerType = 5;
            }

            if (this.ControlValidation())
            {
                this.controller.Save(CurrentUserEntity.BranchCode);
                this.isSaveValidate = false;
                this.flag = true;
                ClearFormControls();
                needToCheck = false;

                //this.txtLoanNo.Text = ""; // Comment By AAM (31-Jan-2018)
                if (!this.formname.Contains("Enquiry")) // For Entry And Edit
                {
                    this.mtxtAccountNo.Enabled = true;
                    cboRepayment.Visible = true;
                    cboCurrency.Enabled = true;
                    mtxtAccountNo.Enabled = true;
                    cboTypeOfAdvance.Enabled = true;
                    txtAssessorName.Enabled = true;
                    txtLawerName.Enabled = true;
                    mcboTypeOfBusiness.Enabled = true;
                    cboTypeOfProduct.Enabled = true;
                    this.txtSanctionAmount.Enabled = true;
                    if (this.formname.Contains("Edit"))
                    {
                        txtLoanNo.Enabled = true;
                        txtLoanNo.Focus();
                    }
                    else
                    {
                        cboCurrency.Focus();
                        isSaveSuccess = 1;    
                    }
                }
                //this.flag = true;
                this.flag = false;
            }
            else
            {
                CXUIMessageUtilities.ShowMessageByCode("MV90067"); //Incomplete data to save !
                this.isSaveValidate = false;
            }
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.isCancelExit = true;
            this.flag = false;
            this.Close();
        }

        private void chkPenalFee_CheckedChanged(object sender, EventArgs e)
        {
            getViewDataForCommon = new TLMDTO00018();
            if (this.chkPenalFee.Checked)
            {
                this.txtPenalDuration.Enabled = true;
                this.gdvPenalFee.Enabled = true;

                this.getViewDataForCommon.isPFcharge = true;
                this.getViewDataForCommon.isPFcharge = chkPenalFee.Checked;
            }
            else
            {
                this.txtPenalDuration.Enabled = false;
                this.gdvPenalFee.Enabled = false;

                this.getViewDataForCommon.isPFcharge = chkPenalFee.Checked;
            }
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
                this.txtGLAcode.Text = (from b in TypeOfBusinessList
                                                where b.Code.Equals(this.mcboTypeOfBusiness.SelectedValue.ToString())
                                                orderby b.Code
                                                select b.RelatedGLACode).Single();
                cboTypeOfProduct.Focus();
            }
        }

        private void dtpExpireDate_Leave(object sender, EventArgs e)
        {
            if (this.dtpExpireDate.Value < DateTime.Now)
                CXUIMessageUtilities.ShowMessageByCode("MV00117"); //MV00117 Invalid Date.
            chkPenalFee.Focus();
        }

        private void cboTypeOfInsurance_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblTypeOfInsuranceForLand_Bld.Visible = false;
            if (this.cboTypeOfInsuranceForLand_Bld.SelectedIndex != -1)
            {
                this.lblTypeOfInsuranceForLand_Bld.Visible = true;
                this.lblTypeOfInsuranceForLand_Bld.Text = (from b in this.TypeOfInsuranceListForLand_Bld
                                                           where b.INSUCODE.Equals(this.cboTypeOfInsuranceForLand_Bld.SelectedValue.ToString())
                                                           orderby b.INSUCODE
                                                           select b.INSUDESP).Single();
            }
        }

        private void colRate_KeyPress(object sender, KeyPressEventArgs e)   //edited by ASDA . to enter decimal point
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
                e.Handled = true;

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void colStockNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ComboBox cbb = (ComboBox)sender;
            ComboBox StockCombobox = (ComboBox)sender;
            if (StockCombobox.SelectedValue != null)
            {
                string code = StockCombobox.SelectedValue.ToString();
                if (StockCombobox.SelectedIndex > -1 && !String.IsNullOrEmpty(code) && !code.Contains("LOMDTO00009"))
                {
                    gdvStock.Rows[gdvStock.CurrentCell.RowIndex].Cells["colStockName"].Value = (from s in StockList
                                                                                                where s.StockNo.Equals(code)
                                                                                                orderby s.StockNo
                                                                                                select s.Name).Single();
                    gdvStock.Rows[gdvStock.CurrentCell.RowIndex].Cells["colStockNo"].Value = StockCombobox.Text;


                }
            }

            this.isActive = true;
        }

        private void colType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGridViewComboBoxEditingControl TypeCombobox = (DataGridViewComboBoxEditingControl)sender;
            string code = TypeCombobox.EditingControlFormattedValue.ToString();
            if (TypeCombobox.SelectedIndex > -1 && !String.IsNullOrEmpty(code) && !code.Contains("LOMDTO00007"))
            {
                this.gdvTypeOfGold.Rows[gdvTypeOfGold.CurrentCell.RowIndex].Cells["colDescription"].Value = (from s in GJTCodeList
                                                                                                             where s.Code.Equals(code)
                                                                                                             orderby s.Code
                                                                                                             select s.Description).Single();
                gdvTypeOfGold.Rows[gdvTypeOfGold.CurrentCell.RowIndex].Cells["colType"].Value = TypeCombobox.Text;


            }

            this.isActive = true;
        }

        private void colkind_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGridViewComboBoxEditingControl kindCombobox = (DataGridViewComboBoxEditingControl)sender;
            string code = kindCombobox.EditingControlFormattedValue.ToString();
            if (kindCombobox.SelectedIndex > -1 && !String.IsNullOrEmpty(code) && !code.Contains("LOMDTO00008"))
            {
                this.gdvKindOfGold.Rows[gdvKindOfGold.CurrentCell.RowIndex].Cells["colKindDescription"].Value = (from s in GJKCodeList
                                                                                                                 where s.Kind.Equals(code)
                                                                                                                 orderby s.Kind
                                                                                                                 select s.Description).Single();
                gdvKindOfGold.Rows[gdvKindOfGold.CurrentCell.RowIndex].Cells["colkind"].Value = kindCombobox.Text;


            }

            this.isActive = true;

        }

        private void colStockQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;

            //// only allow one decimal point
            //if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            //    e.Handled = true;
        }

        private void colQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;

            //// only allow one decimal point
            //if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            //    e.Handled = true;
        }

        private void colKindQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;

            //// only allow one decimal point
            //if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            //    e.Handled = true;
        }

        private void colWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;

            //// only allow one decimal point
            //if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            //    e.Handled = true;
        }

        private void colValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void colMarketValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
                e.Handled = true;

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void colStartPeriod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;

            //// only allow one decimal point
            //if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            //    e.Handled = true;
        }

        private void colEndPeriod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;

            //// only allow one decimal point
            //if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            //    e.Handled = true;
        }

        private void colPenalFee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void colAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void gdvStock_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewCell dataCurrentCell = gdvStock.CurrentCell;
            if (dataCurrentCell.OwningColumn.Name.Equals("colStockNo"))
            {
                ComboBox cbobox = e.Control as ComboBox;
                if (cbobox != null)
                {
                    cbobox.SelectedIndexChanged -= new EventHandler(colStockNo_SelectedIndexChanged);
                    cbobox.SelectedIndexChanged += new EventHandler(colStockNo_SelectedIndexChanged);
                    this.colStockName.ReadOnly = true;
                }
            }

            if (dataCurrentCell.OwningColumn.Name.Equals("colStockQuantity"))
            {
                TextBox txtbox = e.Control as TextBox;
                if (txtbox != null)
                {
                    txtbox.KeyPress -= new KeyPressEventHandler(colStockQuantity_KeyPress);
                    txtbox.KeyPress += new KeyPressEventHandler(colStockQuantity_KeyPress);
                }
            }

            if (dataCurrentCell.OwningColumn.Name.Equals("colMarketValue"))
            {
                TextBox txtbox = e.Control as TextBox;
                if (txtbox != null)
                {
                    txtbox.KeyPress -= new KeyPressEventHandler(colMarketValue_KeyPress);
                    txtbox.KeyPress += new KeyPressEventHandler(colMarketValue_KeyPress);
                }
            }
        }

        private void cboTypeOfInsuranceForPledge_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblTypeOfInsuranceForPledge.Visible = false;
            if (this.cboTypeOfInsuranceForPledge.SelectedIndex != -1)
            {
                this.lblTypeOfInsuranceForPledge.Visible = true;

                this.lblTypeOfInsuranceForPledge.Text = (from b in this.TypeOfInsuranceListForPledge
                                                         where b.INSUCODE.Equals(this.cboTypeOfInsuranceForPledge.SelectedValue.ToString())
                                                         orderby b.INSUCODE
                                                         select b.INSUDESP).Single();
            }
        }

        private void cboTypeOfInsuranceForHypo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblTypeOfInsuranceForHypo.Visible = false;
            if (this.cboTypeOfInsuranceForHypo.SelectedIndex != -1)
            {
                this.lblTypeOfInsuranceForHypo.Visible = true;

                this.lblTypeOfInsuranceForHypo.Text = (from b in this.TypeOfInsuranceListForHypo
                                                       where b.INSUCODE.Equals(this.cboTypeOfInsuranceForHypo.SelectedValue.ToString())
                                                       orderby b.INSUCODE
                                                       select b.INSUDESP).Single();
            }
        }

        private void cboKindOfStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblKindOfStock2.Visible = false;
            if (this.cboKindOfStock.SelectedIndex != -1)
            {
                this.lblKindOfStock2.Visible = true;

                this.lblKindOfStock2.Text = (from k in this.KStockList
                                             where k.KStockNo.Equals(this.cboKindOfStock.SelectedValue.ToString())
                                             orderby k.KStockNo
                                             select k.Desp).Single();
            }
        }

        private void cboLand_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblLand2.Visible = false;
            if (this.cboLand.SelectedIndex != -1)
            {
                this.lblLand2.Visible = true;

                this.lblLand2.Text = (from l in this.LandList
                                      where l.Code.Equals(this.cboLand.SelectedValue.ToString())
                                      orderby l.Code
                                      select l.Description).Single();
            }
        }

        private void gdvPenalFee_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewCell dataCurrentCell = gdvPenalFee.CurrentCell;
            //if (dataCurrentCell.OwningColumn.Name.Equals("colStartPeriod"))
            //{
            //    TextBox txtbox = e.Control as TextBox;
            //    if (txtbox != null)
            //    {
            //        //txtbox.KeyPress -= new KeyPressEventHandler(colAccountNo_KeyPress);
            //        txtbox.KeyPress += new KeyPressEventHandler(colStartPeriod_KeyPress);
            //    }
            //}

            //if (dataCurrentCell.OwningColumn.Name.Equals("colEndPeriod"))
            //{
            //    TextBox txtbox = e.Control as TextBox;
            //    if (txtbox != null)
            //    {
            //        //txtbox.KeyPress -= new KeyPressEventHandler(colAccountNo_KeyPress);
            //        txtbox.KeyPress += new KeyPressEventHandler(colEndPeriod_KeyPress);
            //    }
            //}

            if (dataCurrentCell.OwningColumn.Name.Equals("colPenalFee"))
            {
                TextBox txtbox = e.Control as TextBox;
                if (txtbox != null)
                {
                    //txtbox.KeyPress -= new KeyPressEventHandler(colAccountNo_KeyPress);
                    txtbox.KeyPress += new KeyPressEventHandler(colPenalFee_KeyPress);
                }
            }

            if (dataCurrentCell.OwningColumn.Name.Equals("colAmount"))
            {
                TextBox txtbox = e.Control as TextBox;
                if (txtbox != null)
                {
                    txtbox.KeyPress += new KeyPressEventHandler(colAmount_KeyPress);
                }
            }


        }

        private void gdvPenalFee_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!this.isCancelExit)
            {
                //this.gdvPenalFee.CausesValidation = false;
                DataGridViewRow dataRow = (DataGridViewRow)gdvPenalFee.Rows[e.RowIndex];
                DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

                //if (cell.OwningColumn.Name.Equals("colStartPeriod"))
                //{
                //    if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
                //    {
                //        CXUIMessageUtilities.ShowMessageByCode("MV00046");
                //        gdvPenalFee.CurrentCell = dataRow.Cells["colStartPeriod"];
                //        gdvPenalFee.BeginEdit(true);
                //    }
                //    else
                //    {
                //        dataRow.Cells["colStartPeriod"].Value = cell.EditedFormattedValue.ToString();
                //    }
                //}
                //else if (cell.OwningColumn.Name.Equals("colEndPeriod"))
                //{
                //    if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
                //    {
                //        CXUIMessageUtilities.ShowMessageByCode("MV00046");
                //        gdvPenalFee.CurrentCell = dataRow.Cells["colEndPeriod"];
                //        gdvPenalFee.BeginEdit(true);
                //        //e.Cancel = true;
                //    }
                //    else
                //    {
                //        dataRow.Cells["colEndPeriod"].Value = cell.EditedFormattedValue.ToString();
                //    }
                //}

                if (cell.OwningColumn.Name.Equals("colPenalFee"))
                {
                    if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MV90090");  // Invalid Fees
                        gdvPenalFee.CurrentCell = dataRow.Cells["colPenalFee"];
                        gdvPenalFee.BeginEdit(true);
                        e.Cancel = true;
                    }
                    else
                    {
                        dataRow.Cells["colPenalFee"].Value = cell.EditedFormattedValue.ToString();
                    }
                }
                else if (cell.OwningColumn.Name.Equals("colAmount"))
                {
                    if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MV00037");
                        gdvPenalFee.CurrentCell = dataRow.Cells["colAmount"];
                        gdvPenalFee.BeginEdit(true);
                        e.Cancel = true;
                    }

                    //if (this.SanctionAmount < Convert.ToDecimal(cell.EditedFormattedValue))
                    //    CXUIMessageUtilities.ShowMessageByCode("MV00046");

                    //else if (this.SanctionAmount < penal_amount)
                    //    CXUIMessageUtilities.ShowMessageByCode("MV00046"); 

                    else
                    {
                        penal_amount += Convert.ToDecimal(cell.EditedFormattedValue);
                        dataRow.Cells["colAmount"].Value = cell.EditedFormattedValue.ToString();
                    }
                }
            }

        }

        private void gdvTypeOfGold_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (this.isActive && !this.isCancelExit)
            {
                DataGridViewRow dataRow = (DataGridViewRow)gdvTypeOfGold.Rows[e.RowIndex];
                DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];
                gdvTypeOfGold.AllowUserToAddRows = true;
                if (cell.OwningColumn.Name.Equals("colType"))
                {
                    if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MV20012");
                        gdvTypeOfGold.CurrentCell = dataRow.Cells["colType"];
                        gdvTypeOfGold.BeginEdit(true);
                        e.Cancel = true;
                    }
                    else
                    {
                        dataRow.Cells["colType"].Value = cell.EditedFormattedValue.ToString();
                    }
                }
                else if (cell.OwningColumn.Name.Equals("colDescription"))
                {
                    if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MV80002");
                        gdvTypeOfGold.CurrentCell = dataRow.Cells["colDescription"];
                        gdvTypeOfGold.BeginEdit(true);
                        e.Cancel = true;
                    }
                    else
                    {
                        dataRow.Cells["colDescription"].Value = cell.EditedFormattedValue.ToString();
                    }
                }
                else if (cell.OwningColumn.Name.Equals("colQuantity"))
                {
                    if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MV90054");
                        gdvTypeOfGold.CurrentCell = dataRow.Cells["colQuantity"];
                        gdvTypeOfGold.BeginEdit(true);
                        e.Cancel = true;
                    }
                    else
                    {
                        dataRow.Cells["colQuantity"].Value = cell.EditedFormattedValue.ToString();
                    }
                }
                else if (cell.OwningColumn.Name.Equals("colWeight"))
                {
                    if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MV90089");
                        gdvTypeOfGold.CurrentCell = dataRow.Cells["colWeight"];
                        gdvTypeOfGold.BeginEdit(true);
                        e.Cancel = true;
                    }
                    else
                    {
                        dataRow.Cells["colWeight"].Value = cell.EditedFormattedValue.ToString();
                    }
                }
                else if (cell.OwningColumn.Name.Equals("colValue"))
                {
                    if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MV20024");
                        gdvTypeOfGold.CurrentCell = dataRow.Cells["colValue"];
                        gdvTypeOfGold.BeginEdit(true);
                        e.Cancel = true;
                    }
                    else
                    {
                        dataRow.Cells["colValue"].Value = cell.EditedFormattedValue.ToString();
                    }
                }
            }
        }

        private void gdvKindOfGold_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (this.isActive && !this.isCancelExit)
            {
                DataGridViewRow dataRow = (DataGridViewRow)gdvKindOfGold.Rows[e.RowIndex];
                DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];
                if (cell.OwningColumn.Name.Equals("colKind"))
                {
                    if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MV90088");  // Invalid Kind.
                        gdvKindOfGold.CurrentCell = dataRow.Cells["colKind"];
                        gdvKindOfGold.BeginEdit(true);
                        e.Cancel = true;
                    }
                    else
                    {
                        dataRow.Cells["colKind"].Value = cell.EditedFormattedValue.ToString();
                    }
                }
                else if (cell.OwningColumn.Name.Equals("colDescription"))
                {
                    if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MV80002");
                        gdvKindOfGold.CurrentCell = dataRow.Cells["colDescription"];
                        gdvKindOfGold.BeginEdit(true);
                        e.Cancel = true;
                    }
                    else
                    {
                        dataRow.Cells["colDescription"].Value = cell.EditedFormattedValue.ToString();
                    }
                }
                else if (cell.OwningColumn.Name.Equals("colQuantity"))
                {
                    if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MV90054");
                        gdvKindOfGold.CurrentCell = dataRow.Cells["colQuantity"];
                        gdvKindOfGold.BeginEdit(true);
                        e.Cancel = true;
                    }
                    else
                    {
                        dataRow.Cells["colQuantity"].Value = cell.EditedFormattedValue.ToString();
                    }
                }
            }

        }

        private void gdvStock_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!this.isCancelExit && this.isActive)
            {
                DataGridViewRow dataRow = (DataGridViewRow)gdvStock.Rows[e.RowIndex];
                DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

                if (cell.OwningColumn.Name.Equals("colStockNo"))
                {
                    if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MV90091");
                        gdvStock.CurrentCell = dataRow.Cells["colStockNo"];
                        gdvStock.BeginEdit(true);
                        e.Cancel = true;
                    }
                    else
                    {
                        //dataRow.Cells["colStockName"].Value = (from s in StockList
                        //                                       where s.StockNo.Equals(cell.EditedFormattedValue.ToString())
                        //                                       orderby s.StockNo
                        //                                       select s.Name).Single();
                        //colStockNo_SelectedIndexChanged;
                        dataRow.Cells["colStockNo"].Value = cell.EditedFormattedValue.ToString();
                    }
                }
                else if (cell.OwningColumn.Name.Equals("colStockName"))
                {
                    if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MV00046");
                        gdvStock.CurrentCell = dataRow.Cells["colStockName"];
                        gdvStock.BeginEdit(true);
                        e.Cancel = true;
                    }
                    else
                    {
                        dataRow.Cells["colStockName"].Value = cell.EditedFormattedValue.ToString();
                    }
                }
                else if (cell.OwningColumn.Name.Equals("colStockQuantity"))
                {
                    if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MV00046");
                        gdvStock.CurrentCell = dataRow.Cells["colStockQuantity"];
                        gdvStock.BeginEdit(true);
                        e.Cancel = true;
                    }
                    else
                    {
                        dataRow.Cells["colStockQuantity"].Value = cell.EditedFormattedValue.ToString();
                    }
                }
                else if (cell.OwningColumn.Name.Equals("colMarketValue"))
                {
                    if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MV00046");
                        gdvStock.CurrentCell = dataRow.Cells["colMarketValue"];
                        gdvStock.BeginEdit(true);
                        e.Cancel = true;
                    }
                    else
                    {
                        dataRow.Cells["colMarketValue"].Value = cell.EditedFormattedValue.ToString();
                    }
                }
            }

        }

        private void gdvStock_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //if (this.FormName.Contains("Entry"))
            //{
            this.gdvStock.CausesValidation = false;
            if (!this.isCancelExit)
            {
                DataGridViewRow dataRow = (DataGridViewRow)gdvStock.Rows[e.RowIndex];
                DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

                // pledgeDtoList = new List<LOMDTO00016>();

                if (e.RowIndex > -1 && !dataRow.IsNewRow)
                {
                    // LOMDTO00016 pledgeDto = new LOMDTO00016();
                    if (cell.OwningColumn.Name.Equals("colStockNo"))
                    {
                        dataRow.Cells["colStockNo"].Value = cell.EditedFormattedValue.ToString();

                        //pledgeDto.StockNo = cell.EditedFormattedValue.ToString();
                    }
                    else if (cell.OwningColumn.Name.Equals("colStockName"))
                    {
                        dataRow.Cells["colStockName"].Value = cell.EditedFormattedValue.ToString();
                        // pledgeDto.StockName = cell.EditedFormattedValue.ToString();
                    }
                    else if (cell.OwningColumn.Name.Equals("colStockQuantity"))
                    {
                        dataRow.Cells["colStockQuantity"].Value = cell.EditedFormattedValue.ToString();
                        // pledgeDto.StockQTY = Convert.ToDecimal(cell.EditedFormattedValue);
                    }
                    else if (cell.OwningColumn.Name.Equals("colMarketValue"))
                    {
                        dataRow.Cells["colMarketValue"].Value = cell.EditedFormattedValue.ToString();
                        //pledgeDto.Market_VAL = Convert.ToDecimal(cell.EditedFormattedValue);
                    }

                    // pledgeDtoList.Add(pledgeDto);

                }
            }
            // }
        }

        //private void gdvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex.Equals(-1) || e.ColumnIndex.Equals(-1))
        //    {
        //        return;
        //    }
        //    DataGridViewRow dataRow = (DataGridViewRow)gdvStock.Rows[e.RowIndex];
        //    DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];
        //    if (dataRow.IsNewRow && dataRow.Cells["colStockNo"].Value != null && cell.OwningColumn.Name.Equals("colDelete"))
        //    {
        //        gdvStock.AllowUserToDeleteRows = false;
        //    }
        //    else if (!dataRow.IsNewRow && dataRow.Cells["colStockNo"].Value == null && cell.OwningColumn.Name.Equals("colDelete"))
        //    {
        //        gdvStock.AllowUserToDeleteRows = false;
        //    }
        //    else if (e.RowIndex >= 0 && !dataRow.IsNewRow && dataRow.Cells["colStockNo"].Value != null && cell.OwningColumn.Name.Equals("colDelete"))
        //    {
        //        gdvStock.Rows.RemoveAt(e.RowIndex);

        //        if (gdvStock.CurrentRow.Index < gdvStock.Rows.Count)
        //        {
        //            gdvStock.ClearSelection();
        //            int nRowIndex = gdvStock.Rows.Count - 1;
        //            gdvStock.CurrentCell = gdvStock.Rows[nRowIndex].Cells[4];
        //        }
        //    }
        //    else if (e.RowIndex >= 0 && dataRow.IsNewRow && dataRow.Cells["colStockNo"].Value == null && cell.OwningColumn.Name.Equals("colDelete"))
        //    {
        //        foreach (DataGridViewRow row in gdvStock.Rows)
        //        {
        //            // if (!(row.Cells.OfType<DataGridViewCell>().All(c=>c.Value == null)))
        //            if (e.RowIndex == gdvStock.CurrentCell.RowIndex)
        //             {
        //                 gdvStock.Rows.Remove(row);
        //             }
        //        }

        //        //gdvStock.AllowUserToDeleteRows = false;
        //        //gdvStock.Rows.Remove(gdvStock.CurrentRow);
        //         //DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
        //    }
        //}

        //private void gdvTypeOfGold_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex.Equals(-1) || e.ColumnIndex.Equals(-1))
        //    {
        //        return;
        //    }
        //    DataGridViewRow dataRow = (DataGridViewRow)gdvTypeOfGold.Rows[e.RowIndex];
        //    DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];
        //    if (dataRow.IsNewRow && dataRow.Cells["colType"].Value != null && cell.OwningColumn.Name.Equals("colDeleteForGJT"))
        //    {
        //        gdvTypeOfGold.AllowUserToDeleteRows = false;
        //    }
        //    else if (!dataRow.IsNewRow && dataRow.Cells["colType"].Value == null && cell.OwningColumn.Name.Equals("colDeleteForGJT"))
        //    {
        //        gdvTypeOfGold.AllowUserToDeleteRows = false;
        //    }
        //    else if (e.RowIndex >= 0 && !dataRow.IsNewRow && dataRow.Cells["colType"].Value != null && cell.OwningColumn.Name.Equals("colDeleteForGJT"))
        //    {
        //        gdvTypeOfGold.Rows.RemoveAt(e.RowIndex);

        //        if (gdvTypeOfGold.CurrentRow.Index < gdvTypeOfGold.Rows.Count)
        //        {
        //            gdvTypeOfGold.ClearSelection();
        //            int nRowIndex = gdvTypeOfGold.Rows.Count - 1;
        //            gdvTypeOfGold.CurrentCell = gdvTypeOfGold.Rows[nRowIndex].Cells[5];
        //        }
        //    }
        //    else if (e.RowIndex >= 0 && dataRow.IsNewRow && dataRow.Cells["colType"].Value == null && cell.OwningColumn.Name.Equals("colDeleteForGJT"))
        //    {
        //        foreach (DataGridViewRow row in gdvTypeOfGold.Rows)
        //        {
        //            // if (!(row.Cells.OfType<DataGridViewCell>().All(c=>c.Value == null)))
        //            if (e.RowIndex == gdvTypeOfGold.CurrentCell.RowIndex)
        //            {
        //                gdvTypeOfGold.Rows.Remove(row);
        //            }
        //        }

        //        //gdvStock.AllowUserToDeleteRows = false;
        //        //gdvStock.Rows.Remove(gdvStock.CurrentRow);
        //        //DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
        //    }
        //}

        //private void gdvKindOfGold_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex.Equals(-1) || e.ColumnIndex.Equals(-1))
        //    {
        //        return;
        //    }
        //    DataGridViewRow dataRow = (DataGridViewRow)gdvKindOfGold.Rows[e.RowIndex];
        //    DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];
        //    if (dataRow.IsNewRow && dataRow.Cells["colKind"].Value != null && cell.OwningColumn.Name.Equals("colDeleteForGJK"))
        //    {
        //        gdvKindOfGold.AllowUserToDeleteRows = false;
        //    }
        //    else if (!dataRow.IsNewRow && dataRow.Cells["colKind"].Value == null && cell.OwningColumn.Name.Equals("colDeleteForGJK"))
        //    {
        //        gdvKindOfGold.AllowUserToDeleteRows = false;
        //    }
        //    else if (e.RowIndex >= 0 && !dataRow.IsNewRow && dataRow.Cells["colKind"].Value != null && cell.OwningColumn.Name.Equals("colDeleteForGJK"))
        //    {
        //        gdvKindOfGold.Rows.RemoveAt(e.RowIndex);

        //        if (gdvKindOfGold.CurrentRow.Index < gdvKindOfGold.Rows.Count)
        //        {
        //            gdvKindOfGold.ClearSelection();
        //            int nRowIndex = gdvKindOfGold.Rows.Count - 1;
        //            gdvKindOfGold.CurrentCell = gdvKindOfGold.Rows[nRowIndex].Cells[3];
        //        }
        //    }
        //    else if (e.RowIndex >= 0 && dataRow.IsNewRow && dataRow.Cells["colKind"].Value == null && cell.OwningColumn.Name.Equals("colDeleteForGJK"))
        //    {
        //        foreach (DataGridViewRow row in gdvKindOfGold.Rows)
        //        {
        //            // if (!(row.Cells.OfType<DataGridViewCell>().All(c=>c.Value == null)))
        //            if (e.RowIndex == gdvKindOfGold.CurrentCell.RowIndex)
        //            {
        //                gdvKindOfGold.Rows.Remove(row);
        //            }
        //        }

        //        //gdvStock.AllowUserToDeleteRows = false;
        //        //gdvStock.Rows.Remove(gdvStock.CurrentRow);
        //        //DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
        //    }
        //}

        private void gdvTypeOfGold_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.gdvTypeOfGold.CausesValidation = false;
            if (!this.isCancelExit)
            {
                DataGridViewRow dataRow = (DataGridViewRow)gdvTypeOfGold.Rows[e.RowIndex];
                DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

                // pledgeDtoList = new List<LOMDTO00016>();

                if (e.RowIndex > -1 && !dataRow.IsNewRow)
                {
                    // LOMDTO00016 pledgeDto = new LOMDTO00016();
                    if (cell.OwningColumn.Name.Equals("colType"))
                    {
                        dataRow.Cells["colType"].Value = cell.EditedFormattedValue.ToString();

                        //pledgeDto.StockNo = cell.EditedFormattedValue.ToString();
                    }
                    else if (cell.OwningColumn.Name.Equals("colDescription"))
                    {
                        dataRow.Cells["colDescription"].Value = cell.EditedFormattedValue.ToString();
                        // pledgeDto.StockName = cell.EditedFormattedValue.ToString();
                    }
                    else if (cell.OwningColumn.Name.Equals("colQuantity"))
                    {
                        dataRow.Cells["colQuantity"].Value = cell.EditedFormattedValue.ToString();
                        // pledgeDto.StockQTY = Convert.ToDecimal(cell.EditedFormattedValue);
                    }
                    else if (cell.OwningColumn.Name.Equals("colWeight"))
                    {
                        dataRow.Cells["colWeight"].Value = cell.EditedFormattedValue.ToString();
                        //pledgeDto.Market_VAL = Convert.ToDecimal(cell.EditedFormattedValue);
                    }

                    else if (cell.OwningColumn.Name.Equals("colValue"))
                    {
                        dataRow.Cells["colValue"].Value = cell.EditedFormattedValue.ToString();
                        //pledgeDto.Market_VAL = Convert.ToDecimal(cell.EditedFormattedValue);
                    }

                    // pledgeDtoList.Add(pledgeDto);

                }
            }
        }

        private void gdvKindOfGold_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.gdvKindOfGold.CausesValidation = false;
            if (!this.isCancelExit)
            {
                DataGridViewRow dataRow = (DataGridViewRow)gdvKindOfGold.Rows[e.RowIndex];
                DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

                // pledgeDtoList = new List<LOMDTO00016>();

                if (e.RowIndex > -1 && !dataRow.IsNewRow)
                {
                    // LOMDTO00016 pledgeDto = new LOMDTO00016();
                    if (cell.OwningColumn.Name.Equals("colKind"))
                    {
                        dataRow.Cells["colKind"].Value = cell.EditedFormattedValue.ToString();

                        //pledgeDto.StockNo = cell.EditedFormattedValue.ToString();
                    }
                    else if (cell.OwningColumn.Name.Equals("colKindDescription"))
                    {
                        dataRow.Cells["colKindDescription"].Value = cell.EditedFormattedValue.ToString();
                        // pledgeDto.StockName = cell.EditedFormattedValue.ToString();
                    }
                    else if (cell.OwningColumn.Name.Equals("colKindQuantity"))
                    {
                        dataRow.Cells["colKindQuantity"].Value = cell.EditedFormattedValue.ToString();
                        // pledgeDto.StockQTY = Convert.ToDecimal(cell.EditedFormattedValue);
                    }

                }


            }
        }

        private void gdvTypeOfGold_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewCell dataCurrentCell = gdvTypeOfGold.CurrentCell;
            if (dataCurrentCell.OwningColumn.Name.Equals("colType"))
            {
                ComboBox cbobox = e.Control as ComboBox;
                if (cbobox != null)
                {
                    cbobox.SelectedIndexChanged += new EventHandler(colType_SelectedIndexChanged);
                    this.colDescription.ReadOnly = true;
                }
            }

            if (dataCurrentCell.OwningColumn.Name.Equals("colQuantity"))
            {
                TextBox txtbox = e.Control as TextBox;
                if (txtbox != null)
                {
                    //txtbox.KeyPress -= new KeyPressEventHandler(colAccountNo_KeyPress);
                    txtbox.KeyPress += new KeyPressEventHandler(colQuantity_KeyPress);
                }
            }

            if (dataCurrentCell.OwningColumn.Name.Equals("colWeight"))
            {
                TextBox txtbox = e.Control as TextBox;
                if (txtbox != null)
                {
                    //txtbox.KeyPress -= new KeyPressEventHandler(colAccountNo_KeyPress);
                    txtbox.KeyPress += new KeyPressEventHandler(colWeight_KeyPress);
                }
            }

            if (dataCurrentCell.OwningColumn.Name.Equals("colValue"))
            {
                TextBox txtbox = e.Control as TextBox;
                if (txtbox != null)
                {
                    //txtbox.KeyPress -= new KeyPressEventHandler(colAccountNo_KeyPress);
                    txtbox.KeyPress += new KeyPressEventHandler(colValue_KeyPress);
                }
            }
        }

        private void gdvKindOfGold_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewCell dataCurrentCell = gdvKindOfGold.CurrentCell;
            if (dataCurrentCell.OwningColumn.Name.Equals("colKind"))
            {
                ComboBox cbobox = e.Control as ComboBox;
                if (cbobox != null)
                {
                    cbobox.SelectedIndexChanged += new EventHandler(colkind_SelectedIndexChanged);
                    this.colKindDescription.ReadOnly = true;
                }
            }

            if (dataCurrentCell.OwningColumn.Name.Equals("colKindQuantity"))
            {
                TextBox txtbox = e.Control as TextBox;
                if (txtbox != null)
                {
                    //txtbox.KeyPress -= new KeyPressEventHandler(colAccountNo_KeyPress);
                    txtbox.KeyPress += new KeyPressEventHandler(colKindQuantity_KeyPress);
                }
            }
        }

        private void rdoUsedBal_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoUsedBal.Checked)
            {
                this.txtUsedBalRate.Enabled = true;
                this.txtUnUsedBalRate.Enabled = true;

                this.txtMiddleUnUsedRate.Enabled = false;
                this.txtUsedOverHalfRate.Enabled = false;
                this.txtUsedUnderHalfRate.Enabled = false;
            }
            else
            {
                this.txtMiddleUnUsedRate.Enabled = true;
                this.txtUsedOverHalfRate.Enabled = true;
                this.txtUsedUnderHalfRate.Enabled = true;

                this.txtUsedBalRate.Enabled = false;
                this.txtUnUsedBalRate.Enabled = false;
            }
        }

        private void cboLand_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            this.lblLand2.Visible = false;
            if (this.cboLand.SelectedIndex != -1)
            {
                this.lblLand2.Visible = true;

                this.lblLand2.Text = (from b in LandList
                                      where b.Code.Equals(this.cboLand.SelectedValue.ToString())
                                      orderby b.Code
                                      select b.Description).Single();
            }
        }

        private void txtLoanNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //  e.KeyChar = char.ToUpper(e.KeyChar);       
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

        public void BindCombo(string saleDeed, string landOfAffidavit, string history, string permit)
        {
            this.cboSalesDeed.Text = saleDeed;
            this.cboLandOfAffidavit.Text = landOfAffidavit;
            this.cboHistoryOfLand.Text = history;
            this.cboBuildingConPermit.Text = permit;
        }

        private void txtGuarantorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtGCompanyName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            //Commented by HWKO (30-Aug-2017)
            //if (char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = true; 
            //}
        }

        private void txtGuarantorPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            { e.Handled = true; }
        }

        public void SelectTab(string tabName, bool isEnable)
        {

            ((Control)this.tbpLandAndBuilding).Enabled = false;
            ((Control)this.tbpPersonalGuarantee).Enabled = false;
            ((Control)this.tbpPledge).Enabled = false;
            ((Control)this.tbpHypothecation).Enabled = false;
            ((Control)this.tbpGoldandJewellery).Enabled = false;
            switch (tabName)
            {

                case "land": tbLoanProduct.SelectedTab = tbpLandAndBuilding; ((Control)this.tbpLandAndBuilding).Enabled = isEnable; ; break;
                case "per": tbLoanProduct.SelectedTab = tbpPersonalGuarantee; ((Control)this.tbpPersonalGuarantee).Enabled = isEnable; break;
                case "pledge": tbLoanProduct.SelectedTab = tbpPledge;
                    ((Control)this.tbpPledge).Enabled = isEnable; break;
                case "hypo": tbLoanProduct.SelectedTab = tbpHypothecation; ((Control)this.tbpHypothecation).Enabled = isEnable; break;
                case "gold": tbLoanProduct.SelectedTab = tbpGoldandJewellery; ((Control)this.tbpGoldandJewellery).Enabled = isEnable; break;
            }

            tbLoanProduct.Enabled = isEnable;
        }

        private void cboTypeOfProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tbLoanProduct.Enabled = true;

            if (this.cboTypeOfProduct.Text.Contains("Guarantee"))
            {
                ((Control)this.tbpPersonalGuarantee).Enabled = true;
                // ((Control)this.tbpPersonalGuarantee).Visible = true;
                this.tbLoanProduct.SelectedTab = this.tbpPersonalGuarantee;
                //this.mtxtGuaranterAccountNo.Focus();
                this.txtGCompanyName.Focus();
            }
            else if (this.cboTypeOfProduct.Text.Contains("Pledge"))
            {
                ((Control)this.tbpPledge).Enabled = true;
                this.isSaveValidate = true;
                this.tbLoanProduct.SelectedTab = this.tbpPledge;
                this.isSaveValidate = false;
                this.BindStockInfoForPledge();
                this.BindTypeOfInsuranceForPledge();
            }
            else if (this.cboTypeOfProduct.Text.Contains("Hypothecation"))
            {
                ((Control)this.tbpHypothecation).Enabled = true;
                // ((Control)this.tbpHypothecation).Visible = true;
                this.tbLoanProduct.SelectedTab = this.tbpHypothecation;
                this.BindAllKStock();
                this.BindTypeOfInsuranceFsorHypothecation();
                this.cboKindOfStock.Focus();
            }
            else if (this.cboTypeOfProduct.Text.Contains("Gold"))
            {
                ((Control)this.tbpGoldandJewellery).Enabled = true;
                this.isSaveValidate = true;
                // ((Control)this.tbpGoldandJewellery).Visible = true;
                this.tbLoanProduct.SelectedTab = this.tbpGoldandJewellery;
                this.isSaveValidate = false;
                this.BindGJKCode();
                this.BindGJTCode();
                //this.gdvTypeOfGold.Focus();
            }
            else
            {
                ((Control)this.tbpLandAndBuilding).Enabled = true;
                // ((Control)this.tbpLandAndBuilding).Visible = true;
                this.tbLoanProduct.SelectedTab = this.tbpLandAndBuilding;
                this.mtxtPLandBS.Focus();

                this.BindCustomerCharacterCode();
                this.BindAllLand();
                this.BindGoodWill();
                this.BindSalesDeed();
                this.BindHistoryOfLandandBuilding();
                this.BindLandOfAffidavit();
                this.BindBuildingConstructionPermit();
                this.BindTypeOfInsuranceForLand_Bld();
            }
        }

        private void gdvStock_DataError_1(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void cboKindOfStock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{Tab}");
                this.txtValue.Focus();
            }
        }

        private void LOMVEW00011_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                e.Handled = false;
            }

            else if (e.KeyCode == Keys.Tab)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
                e.Handled = true;
            }

            else if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
                e.Handled = true;
            }
        }

        //private void txtSanctionAmount_Leave(object sender, EventArgs e)
        //{
        //if (this.ActiveControl.Name.Contains("tsbCRUD") && !this.tsbCRUD.butSave.ContainsFocus)
        //{
        //    this.isCancelExit = true;
        //}
        //if ((!flag && !isCancelExit && keyDownSamt == 1))
        //{
        //    if (checkSAmt)
        //    {
        //        if (this.SanctionAmount == decimal.Zero)
        //        {
        //            CXUI MessageUtilities.ShowMessageByCode("MV00037");
        //            this.txtSanctionAmount.Focus();
        //        }
        //        else chkServiceCharges.Focus();
        //    }
        //}
        //}

        private void mtxtAccountNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

        }

        private void txtPenalDuration_Leave(object sender, EventArgs e)
        {
            if (txtPenalDuration.Text == string.Empty || txtPenalDuration.Text == "")
                //  CXUIMessageUtilities.ShowMessageByCode("MV00034");
                this.txtPenalDuration.Focus();
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
                txtRepaymentDuration.Focus();
            }
        }

        private void txtLoanNo_Leave(object sender, EventArgs e)
        {
            //this.controller.CheckLoansNo();
        }

        //private void txtRepaymentDuration_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (txtRepaymentDuration.Text != "")
        //    {
        //        if (this.txtRepaymentDuration.ToString() == "1" || this.txtRepaymentDuration.ToString() == "3" || this.txtRepaymentDuration.ToString() == "12")
        //        {
        //        }
        //        else
        //        {
        //            CXUIMessageUtilities.ShowMessageByCode("MV00046"); // Repayment Duration should be 1month or 3months or 12months!
        //            this.txtRepaymentDuration.Focus();
        //            return ;
        //        }
        //    }
        //    else
        //    {
        //        CXUIMessageUtilities.ShowMessageByCode("MV00046"); // Repayment Duration should not be blank!
        //        this.txtRepaymentDuration.Focus();
        //        return;
        //    }
        //}

        //private void cboRepayment_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (txtRepaymentDuration.Text != "")
        //    {
        //        if (this.txtRepaymentDuration.ToString() == "1")
        //        {
        //            if (this.cboRepayment.SelectedText.ToString() != "Monthly")
        //            {
        //                CXUIMessageUtilities.ShowMessageByCode("MV00046"); // Repayment Option should not be Monthly!
        //                this.cboRepayment.Focus();
        //                return;
        //            }
        //        }
        //    }
        //    else
        //    {

        //    }
        //}       

        //private void chkPenalFee_Leave(object sender, EventArgs e)
        //        {
        //    if (chkPenalFee.Checked == true)
        //        this.getViewDataForCommon.isPFcharge = true;
        //    else
        //        this.getViewDataForCommon.isPFcharge = false;
        //}

        //private void chkPenalFee_Click(object sender, EventArgs e)
        //{
        //    if (chkPenalFee.Checked == true)
        //        this.getViewDataForCommon.isPFcharge = chkPenalFee.Checked;
        //    else
        //        this.getViewDataForCommon.isPFcharge = chkPenalFee.Checked;
        //}

        private void cboTypeOfInsuranceForLand_Bld_KeyDown(object sender, KeyEventArgs e)
        {
            cboTypeOfInsuranceForLand_Bld.Focus();
        }

        private void txtLoanNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!this.FormName.Contains("Entry"))//for  edit and enquiry
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
                            this.controller.BindLoanInfo();
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

        private void txtRepaymentDuration_Leave(object sender, EventArgs e)
                {
            if (txtRepaymentDuration.Text != "")
            {
               DateTime PreDue= DateTime.Now.AddMonths(Convert.ToInt32(txtRepaymentDuration.Text));
               dtpExpireDate.Value =Convert.ToDateTime(( PreDue.Year + "/" + PreDue.Month +"/"+ PreDue.Day).ToString());

                //int DayInDuration = dayForOneMonth * Convert.ToInt32(txtRepaymentDuration.Text);
                //dtpExpireDate.Value = DateTime.Now.AddDays(DayInDuration);
                    SendKeys.Send("{Tab}");
            }
        }

        //private void txtSanctionAmount_KeyDown(object sender, KeyEventArgs e)
        //{
        //if (e.KeyCode.Equals(Keys.Enter))
        //{
        //    if (sAmt > 0)
        //    {
        //        if (sAmt == Convert.ToDecimal(txtSanctionAmount.Text))
        //        {
        //            return;
        //        }
        //        else
        //        {
        //            CXUIMessageUtilities.ShowMessageByCode("MV00037");
        //            this.txtSanctionAmount.Focus();
        //            return;
        //        }
        //    }
        //    if (txtSanctionAmount.Text == "" || txtSanctionAmount.Text == string.Empty)
        //    {
        //        CXUIMessageUtilities.ShowMessageByCode("MV00037");
        //        this.txtSanctionAmount.Focus();
        //    }
        //    sAmt = Convert.ToDecimal(txtSanctionAmount.Text);
        //    txtSanctionAmount.Text = "";
        //    txtSanctionAmount.UseSystemPasswordChar = false;
        //    checkSAmt = true;
        //}
        //}

        //private void txtSanctionAmount_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    #region Old Code
        //    //if (e.KeyChar == '\r')
        //    //{
        //    //    txtSanctionAmount.Focus();
        //    //    if (txtSanctionAmount.PasswordChar == '*')
        //    //    {
        //    //        sAmt = Convert.ToDecimal(txtSanctionAmount.Text);
        //    //        txtSanctionAmount.PasswordChar = '\0';
        //    //        txtSanctionAmount.Text = "";
        //    //        txtSanctionAmount.Focus();
        //    //        //keyDownSamt = 0;
        //    //        if (e.KeyChar == '\t')
        //    //        {
        //    //            txtSanctionAmount.Focus();
        //    //        }
        //    //        if (e.KeyChar == (char)Keys.Tab)
        //    //        {
        //    //            txtSanctionAmount.Focus();
        //    //        }
        //    //    }
        //    //    else
        //    //    {
        //    //        if (sAmt != Convert.ToDecimal(txtSanctionAmount.Text))
        //    //        {
        //    //            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00037);
        //    //            //Start();
        //    //        }
        //    //        //keyDownSamt = 1;
        //    //        else if (sAmt == Convert.ToDecimal(txtSanctionAmount.Text) && (e.KeyChar == (char)Keys.Tab || e.KeyChar == (char)Keys.Enter))
        //    //        {
        //    //            chkServiceCharges.Focus();
        //    //        }
        //    //    }
        //    //}
        //    #endregion

        //    if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
        //    {
        //        e.Handled = true;
        //    }
        //}

        private void chkEditDocAmt_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEditDocAmt.Checked == true)
            {
                txtDocumentFee.Enabled = true;
                txtDocumentFee.Focus();
            }
            else
            {
                txtDocumentFee.Enabled = false;
                chkPenalFee.Focus();
            }
        }
        
        private void chkGracePeriod_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGracePeriod.Checked == true)
            {
                txtGracePeriod.Enabled = true;
                txtGracePeriod.Focus();
            }
            else
            {
                txtGracePeriod.Enabled = false;
                txtRepaymentDuration.Focus();
            }
        }

        private void cboRepayment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{Tab}");
                this.chkEditDocAmt.Focus();
            }
        }

        private void txtSanctionAmount_Leave(object sender, EventArgs e)
        {
            #region Old Code
            //if (!isCancelExit)
            //{
            //    if (isSaveSuccess == 0)
            //    {
            //        if (this.txtSanctionAmount.Text.Replace(",",string.Empty) == "0.00" || String.IsNullOrEmpty(this.txtSanctionAmount.Text))
            //        {
            //            //Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00037);
            //            txtSanctionAmount.Text = "";
            //            //txtSanctionAmount.Focus();
            //        }
            //        else if (sAmt != Convert.ToDecimal(txtSanctionAmount.Text.Replace(",",string.Empty)))
            //        {
            //            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00037);
            //            Start();
            //            txtSanctionAmount.Text = "";
            //            txtSanctionAmount.Focus();
            //        }
            //        else if (sAmt == Convert.ToDecimal(txtSanctionAmount.Text.Replace(",", string.Empty)))
            //        {
            //            //chkServiceCharges.Focus();
            //            txtSanctionAmount.Focus();
            //        }
            //    }
            //    else
            //    {
            //        isSaveSuccess = 0;
            //        txtSanctionAmount.Text = "";
            //        cboCurrency.Focus();
            //    }
            //}
            #endregion

            if (needToCheck==true) return;

            if (txtSanctionAmount.Text != txtSanctionAmountEncode.Text)
            {
                if (MessageBox.Show("Invalid Amount", "Do You Want to re-enter sanction amount?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    txtSanctionAmount.Clear();
                    txtSanctionAmountEncode.Clear();
                    txtSanctionAmountEncode.Visible = true;
                    txtSanctionAmountEncode.Focus();
                }

            }
            else
            {
                txtSanctionAmount.Text = Double.Parse(txtSanctionAmount.Text).ToString("N2");
                chkServiceCharges.Focus();
            }

            //this.cboCurrency.Focus(); // Uncommented By AAM (01-Feb-2018)

        }

        // Added By AAM (31-Jan-2018)
        private void txtSanctionAmountEncode_Leave(object sender, EventArgs e)
        {
            needToCheck = true;
            txtSanctionAmountEncode.Visible = false;
            txtSanctionAmount.Visible = true;
            txtSanctionAmount.Focus();
        }

        private void cboCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSanctionAmount.Text = "";
        }

        //Added by HWKO (30-Aug-2017)
        private void txtGuarantorNrc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        //Added by HWKO (30-Aug-2017)
        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtCapital_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCapital.Text))
                txtCapital.Text = Double.Parse(txtCapital.Text).ToString("N2");
            else
                txtCapital.Text = "0.00";
        }

        private void txtIncomeTax_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtIncomeTax.Text))
                txtIncomeTax.Text = Double.Parse(txtIncomeTax.Text).ToString("N2");
            else
                txtIncomeTax.Text = "0.00";
        }

        private void txtForceSaleValueOfLand_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtForceSaleValueOfLand.Text))
                txtForceSaleValueOfLand.Text = Double.Parse(txtForceSaleValueOfLand.Text).ToString("N2");
            else
                txtForceSaleValueOfLand.Text = "0.00";
        }

        private void txtForceSaleValueOfBuilding_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtForceSaleValueOfBuilding.Text))
                txtForceSaleValueOfBuilding.Text = Double.Parse(txtForceSaleValueOfBuilding.Text).ToString("N2");
            else
                txtForceSaleValueOfBuilding.Text = "0.00";
        }

        private void txtInsuranceAmount_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtInsuranceAmount.Text))
                txtInsuranceAmount.Text = Double.Parse(txtInsuranceAmount.Text).ToString("N2");
            else
                txtInsuranceAmount.Text = "0.00";
        }

        private void txtDocumentFee_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtDocumentFee.Text))
                txtDocumentFee.Text = Double.Parse(txtDocumentFee.Text).ToString("N2");
            else
                txtDocumentFee.Text = "0.00";
        }

        //private void cboInterestOption_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode.Equals(Keys.Enter))
        //    {
        //        SendKeys.Send("{Tab}");
        //        this.chkGracePeriod.Focus();
        //    }
        //}

        private void txtGracePeriod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{Tab}");
                this.txtRepaymentDuration.Focus();
            }
        }
        #endregion

        #region methods
        //private void Start()
        //{
        //    txtSanctionAmount.PasswordChar = '*';
        //    txtSanctionAmount.Text = "";
        //} 
       
        public LOMDTO00021 GetInterestList()
        {
            LOMDTO00021 interestDto = new LOMDTO00021();

            interestDto.Acctno = this.AccountNo;
            interestDto.LNo = this.LoanNo;
            interestDto.IntRate = Convert.ToDecimal(txtRate.Text);
            interestDto.Duration = Convert.ToInt16(txtRepaymentDuration.Text);
            //interestDto.Repaymentoption = Convert.ToInt16(cboRepayment.SelectedValue);
            //interestDto.Repaymentoption = Convert.ToInt16(cboRepayment.SelectedValue);
            //interestDto.Repaymentoption = Convert.ToInt16(cboRepayment.SelectedValue);
            //interestDto.Repaymentoption = Convert.ToInt16(cboRepayment.SelectedValue);
            //interestDto.Repaymentoption = Convert.ToInt16(cboRepayment.SelectedValue);
            interestDto.ACSign = this.controller.Acsign;
            interestDto.UserNo = CurrentUserEntity.CurrentUserID.ToString();
            interestDto.SourceBr = this.controller.BranchCode;
            //interestDto.RepaymentPeriod = this.RepaymentPeriod;/*/
            interestDto.Duration = this.RepaymentDuration;
            interestDto.CreatedDate = DateTime.Now;
            interestDto.CreatedUserId = CurrentUserEntity.CurrentUserID;

            return interestDto;
        }

        #endregion        

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
    }
}
