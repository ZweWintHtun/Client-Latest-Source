using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Sam.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.DataModel;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Ptr;
using System.Globalization;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Ctr;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00078 : BaseDockingForm, ILOMVEW00078
    {
        #region Controller

        private ILOMCTL00078 controller;
        public ILOMCTL00078 Controller
        {
            get { return this.controller; }
            set { this.controller = value; this.controller.View = this; }
        }

        #endregion

        #region Constructor
        public LOMVEW00078()
        {
            InitializeComponent();
        }

        public LOMVEW00078(string name)
        {
            this.Loan_Product = name;
            InitializeComponent();
        }
        #endregion

        #region Control Properties

        private int largestSize;
        public int LargestSize 
        { 
            get { return 400; } 
            set { this.largestSize = 400; } 
        }
        public bool isSaveValidate { get; set; }
        public bool flag { get; set; }
        public bool isCancelExit { get; set; }
        public bool isEdit { get; set; }
        public bool isActive { get; set; }
        public bool isOtherNRC { get; set; }
        private string Loan_Product { get; set; }


        public IList<StateDTO> StateCodeList { get; set; }
        public IList<SAMDTO00054> NRCCodeList { get; set; }//For FormLoad
        public IList<SAMDTO00054> NRCCodes { get; set; }//ForNRCCombo
        IList<LOMDTO00001> LandList { get; set; }
        IList<LOMDTO00004> TypeOfInsuranceListForLand_Bld { get; set; }
        IList<LOMDTO00077> ListForLSProductTypeItem { get; set; }
        IList<LOMDTO00073> ListForUM { get; set; }
        IList<LOMDTO00071> ListForSeasonType { get; set; }
        IList<LOMDTO00072> ListForCropType { get; set; }
        IList<LOMDTO00075> ListForAGProductTypeItem { get; set; }

        #region Properties for Personal Information

        public string LoanNo
        {
            get { return this.txtLoanNo.Text.Trim(); }
            set { this.txtLoanNo.Text = value.Trim(); }
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

        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text.Trim(); }
            set { this.mtxtAccountNo.Text = value.Trim(); }
        }

        public string TypeOfLoan
        {
            get
            {
                if (this.cboTypeOfLoan.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboTypeOfLoan.SelectedValue.ToString();
                }
            }
            set { this.cboTypeOfLoan.SelectedValue = value; }
        }

        public string NameInPI
        {
            get { return this.txtName.Text; }
            set { this.txtName.Text = value; }
        }

        public string FatherNameInPI
        {
            get { return this.txtFatherName.Text; }
            set { this.txtFatherName.Text = value; }
        }

        public string VillageGroupCode
        {
            get
            {
                if (this.cboVillageGroup.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboVillageGroup.SelectedValue.ToString();
                }
            }
            set { this.cboVillageGroup.SelectedValue = value; }
        }

        public string TownshipCode
        {
            get
            {
                if (this.cboTownship.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboTownship.SelectedValue.ToString();
                }
            }
            set { this.cboTownship.SelectedValue = value; }
        }

        public string StateCodeForNRC
        {
            get
            {
                if (this.cboStateCode.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return cboStateCode.SelectedValue.ToString();
                }
            }
            set
            {
                cboStateCode.SelectedValue = value;
            }
        }

        public string TownshipCodeForNRC
        {
            get
            {
                if (this.cboTownshipCode.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return cboTownshipCode.SelectedValue.ToString();
                }
            }
            set
            {
                cboTownshipCode.SelectedValue = value;
            }
        }

        public string NationalityCodeForNRC
        {
            get
            {
                if (this.cboNationalityCode.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return cboNationalityCode.SelectedValue.ToString();
                }
            }
            set
            {
                cboNationalityCode.SelectedValue = value;
            }
        }

        public string NRCNo
        {
            get { return txtNRCNo.Text; }
            set { this.txtNRCNo.Text = value; }
        }

        public string NRC
        {
            get { return this.txtNRC.Text; }
            set { this.txtNRC.Text = value; }
        }

        public string Address
        {
            get { return this.txtAddress.Text; }
            set { this.txtAddress.Text = value; }
        }

        #endregion

        #region Properties for AgriLoan

        public string FarmName
        {
            get { return this.txtFarmName.Text; }
            set { this.txtFarmName.Text = value; }
        }

        public string LandNo
        {
            get { return this.txtLandNo.Text; }
            set { this.txtLandNo.Text = value; }
        }

        public string TypeOfLand
        {
            get
            {
                if (this.cboTypeOfLand.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboTypeOfLand.SelectedValue.ToString();
                }
            }
            set { this.cboTypeOfLand.SelectedValue = value; }
        }

        public string SeasonType
        {
            get
            {
                if (this.cboSeasonType.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboSeasonType.SelectedValue.ToString();
                }
            }
            set { this.cboSeasonType.SelectedValue = value; }
        }

        public string CropType
        {
            get
            {
                if (this.cboCropType.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboCropType.SelectedValue.ToString();
                }
            }
            set { this.cboCropType.SelectedValue = value; }
        }

        public string LoanProductType
        {
            get { return this.txtLoanProductType.Text; }
            set { this.txtLoanProductType.Text = value; }
        }

        public string GroupNo
        {
            get { return this.txtGroupNo.Text; }
            set { this.txtGroupNo.Text = value; }
        }

        public decimal Interest
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtInterest.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtInterest.Text = value.ToString(); }
        }

        public decimal Penalties
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtPenalties.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtPenalties.Text = value.ToString(); }
        }

        public string StartPeriod
        {
            get { return this.txtFromDuration.Text; }
            set { this.txtFromDuration.Text = value; }
        }

        public string EndPeriod
        {
            get { return this.txtToDuration.Text; }
            set { this.txtToDuration.Text = value; }
        }

        public DateTime WithdrawDate
        {
            get { return this.dtpWithdrawDate.Value; }
            set { this.dtpWithdrawDate.Value = value; }
        }

        public DateTime DeadlineDate
        {
            get { return this.dtpDeadlineDate.Value; }
            set { this.dtpDeadlineDate.Value = value; }
        }

        public decimal LoanAmtPerAcre
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtLoanAmount.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtLoanAmount.Text = value.ToString(); }
        }

        public decimal TotalAcre
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtTotalAcrePerUnit.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtTotalAcrePerUnit.Text = value.ToString(); }
        }

        public decimal SanctionLimit
        {
            get
            {
                return (this.LoanAmtPerAcre * this.TotalAcre);
            }
            set { this.txtSanctionLimit.Text = value.ToString(); }
        }

        #endregion

        #region Properties for Livestock Loan

        public string LSBusinessType
        {
            get
            {
                if (this.cboLSBusinessType.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboLSBusinessType.SelectedValue.ToString();
                }
            }
            set { this.cboLSBusinessType.SelectedValue = value; }
        }

        public string LSTypeOfLand
        {
            get { return this.txtLSTypeOfLand.Text; }
            set { this.txtLSTypeOfLand.Text = value; }
        }

        public string LSUMCode
        {
            get { return this.lblLSUMCode.Text; }
            set { this.lblLSUMCode.Text = value; }
        }

        public string LSLicenseNo
        {
            get { return this.txtLSLicenseNo.Text; }
            set { this.txtLSLicenseNo.Text = value; }
        }

        public string LSLoanProductType
        {
            get { return this.txtLSLoanProductType.Text; }
            set { this.txtLSLoanProductType.Text = value; }
        }

        public string LSOther
        {
            get { return this.txtLSOther.Text; }
            set { this.txtLSOther.Text = value; }
        }

        public decimal LSInterest
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtLSInterest.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtLSInterest.Text = value.ToString(); }
        }

        public decimal LSPenalties
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtLSPenalties.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtLSPenalties.Text = value.ToString(); }
        }

        public string LSStartPeriod
        {
            get { return this.txtLSFromDuration.Text; }
            set { this.txtLSFromDuration.Text = value; }
        }

        public string LSEndPeriod
        {
            get { return this.txtLSToDuration.Text; }
            set { this.txtLSToDuration.Text = value; }
        }

        public DateTime LSWithdrawDate
        {
            get { return this.dtpLSWithdrawDate.Value; }
            set { this.dtpLSWithdrawDate.Value = value; }
        }

        public DateTime LSDeadlineDate
        {
            get { return this.dtpLSDeadlineDate.Value; }
            set { this.dtpLSDeadlineDate.Value = value; }
        }

        public decimal LSLoanAmtPerAcre
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtLSLoanAmount.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtLSLoanAmount.Text = value.ToString(); }
        }

        public decimal LSTotalAcre
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtLSTotalAcre.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtLSTotalAcre.Text = value.ToString(); }
        }

        public decimal LSSanctionLimit
        {
            get
            {
                return (this.LSLoanAmtPerAcre * this.LSTotalAcre);
            }
            set { this.txtLSSanctionLimit.Text = value.ToString(); }
        }

        #endregion

        #region Properties for Land & Building

        public string YearOfPLBS
        {
            get { return this.mtxtPLandBS.Text; }
            set { this.mtxtPLandBS.Text = value; }
        }

        public DateTime EstablishmentDate
        {
            get { return this.dtpEstablishmentDate.Value; }
            set { this.dtpEstablishmentDate.Value = value; }
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

        public string AddressInLB
        {
            get { return this.txtAddressInLB.Text; }
            set { this.txtAddressInLB.Text = value; }
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

        #endregion

        #region Properties for Persoanl Guarantee

        public string GuarantorAccountNo1
        {
            get { return this.mtxtGuaranterAccountNo.Text; }
            set { this.mtxtGuaranterAccountNo.Text = value; }
        }

        public string GuarantorName1
        {
            get { return this.txtGuarantorName.Text; }
            set { this.txtGuarantorName.Text = value; }
        }

        public string GuarantorNrc1
        {
            get { return this.txtGuarantorNrc.Text; }
            set { this.txtGuarantorNrc.Text = value; }
        }

        public string GuarantorPhone1
        {
            get { return this.txtGuarantorPhone.Text; }
            set { this.txtGuarantorPhone.Text = value; }
        }

        public string GuarantorAccountNo2
        {
            get { return this.mtxtGuaranterAccountNo2.Text; }
            set { this.mtxtGuaranterAccountNo2.Text = value; }
        }

        public string GuarantorName2
        {
            get { return this.txtGuarantorName2.Text; }
            set { this.txtGuarantorName2.Text = value; }
        }

        public string GuarantorNrc2
        {
            get { return this.txtGuarantorNrc2.Text; }
            set { this.txtGuarantorNrc2.Text = value; }
        }

        public string GuarantorPhone2
        {
            get { return this.txtGuarantorPhone2.Text; }
            set { this.txtGuarantorPhone2.Text = value; }
        }
        #endregion

        #region Properties for Firm Certificate & Customer Signature
        public Image FirmCertificate
        {
            get { return this.picFirmCertificate.Image; }
            set { this.picFirmCertificate.Image = value; }
        }

        public Image CusSignature
        {
            get { return this.picCusSignature.Image; }
            set { this.picCusSignature.Image = value; }
        }

        #endregion

        #endregion

        #region View Data Properties
        private FormState formState;
        public FormState FormState
        {
            get { return this.formState; }
            set { this.formState = value; }
        }

        public string FormName
        {
            get { return this.Text; }
            set { this.Text = value; }
        }

        #endregion

        #region Helper Methods

        #region BindComboBox for Personal Information
        public void BindCurrency()
        {
            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
            cboCurrency.SelectedIndex = 0;
        }

        public void BindTypeOfLoan()
        {
            IList<LOMDTO00074> ProductTypeList = CXCLE00002.Instance.GetListObject<LOMDTO00074>("LOMORM00074.SelectAllProductCode", new object[] { true });
            this.cboTypeOfLoan.ValueMember = "Code";
            this.cboTypeOfLoan.DisplayMember = "Description";
            this.cboTypeOfLoan.ColumnNames = "Code,Description";
            this.cboTypeOfLoan.DataSource = ProductTypeList;
            this.cboTypeOfLoan.SelectedIndex = -1;
        }

        /// <summary>
        /// Bind State CodeCombobox For NRC
        /// </summary>
        private void BindStateCombobox()
        {
            StateCodeList = CXCLE00002.Instance.GetListObject<StateDTO>("StateCode.Client.Select", new object[] { true });
            for (int i = 0; i < StateCodeList.Count; i++)
            {
                StateCodeList[i].StateCode = StateCodeList[i].StateCode + "/";
            }
            cboStateCode.ValueMember = "StateCode";
            cboStateCode.DisplayMember = "StateCode";
            cboStateCode.DataSource = StateCodeList;
            cboStateCode.SelectedIndex = -1;
        }

        /// <summary>
        /// Bind Township CodeCombobox For NRC
        /// </summary>
        private void BindTownshipCombobox()
        {
            //NRCCodes = CXCLE00002.Instance.GetListObject<SAMDTO00054>("NRCCode.Client.Select", new object[] { true });//Bind NRC Code
            cboTownshipCode.ValueMember = "TownshipCode";
            cboTownshipCode.DisplayMember = "TownshipCode";
            cboTownshipCode.DataSource = NRCCodes;
            cboTownshipCode.SelectedIndex = -1;
        }

        /// <summary>
        /// Bind Nationality CodeCombobox For NRC
        /// </summary>
        private void BindNationalityCombobox()
        {
            IList<SAMDTO00053> NationalityList = new List<SAMDTO00053>();
            NationalityList.Add(new SAMDTO00053("(N)", null));
            NationalityList.Add(new SAMDTO00053("(E)", null));
            NationalityList.Add(new SAMDTO00053("(T)", null));
            NationalityList.Add(new SAMDTO00053("(P)", null));
            cboNationalityCode.ValueMember = "Nationality_Code";
            cboNationalityCode.DisplayMember = "Nationality_Code";
            cboNationalityCode.DataSource = NationalityList;
            cboNationalityCode.SelectedIndex = -1;
        }

        public void BindVillageGroupCombobox()
        {
            IList<LOMDTO00070> VillageGroupList = CXCLE00002.Instance.GetListObject<LOMDTO00070>("LOMORM00070.SelectAllVillageGroupCode", new object[] { true });
            this.cboVillageGroup.ValueMember = "VillageCode";
            this.cboVillageGroup.DisplayMember = "Desp";
            this.cboVillageGroup.DataSource = VillageGroupList;
            this.cboVillageGroup.SelectedIndex = -1;
        }

        /// <summary>
        /// Bind Township Code Combobox
        /// </summary>
        private void BindTownshipCodeCombobox()
        {
            IList<TownshipDTO> TownshipCodeList = CXCLE00002.Instance.GetListObject<TownshipDTO>("TownshipCode.Client.Select", new object[] { true });

            cboTownship.ValueMember = "TownshipCode";
            cboTownship.DisplayMember = "Description";
            cboTownship.DataSource = TownshipCodeList;
            cboTownship.SelectedIndex = -1;

        }
        #endregion

        #region BindComboBox for Land & Building
        public void BindSalesDeed()
        {
            this.cboSalesDeed.DataSource = null;
            string[] saleList = { "INORDER", "NOT INORDER" };
            //this.cboSalesDeed.ValueMember ='';
            this.cboSalesDeed.DataSource = saleList;
            this.cboSalesDeed.SelectedIndex = -1;
        }

        public void BindLandOfAffidavit()
        {
            this.cboLandOfAffidavit.DataSource = null;
            string[] List = { "REQUIRED", "NOT REQUIRED" };
            this.cboLandOfAffidavit.DataSource = List;
            this.cboLandOfAffidavit.SelectedIndex = -1;
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

        public void BindCustomerCharacterCode()
        {
            IList<LOMDTO00001> TypeOfCharacterCodeList = CXCLE00002.Instance.GetListObject<LOMDTO00001>("LOMORM00003.SelectAllCustomerCharacterCode", new object[] { true });
            this.cboCharacterOfCustomer.ValueMember = "Code";
            this.cboCharacterOfCustomer.DisplayMember = "Description";
            this.cboCharacterOfCustomer.DataSource = TypeOfCharacterCodeList;
            this.cboCharacterOfCustomer.SelectedIndex = -1;
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

        public void BindHistoryOfLandandBuilding()
        {
            this.cboHistoryOfLand.DataSource = null;
            string[] List = { "INORDER", "NOT INORDER" };
            this.cboHistoryOfLand.DataSource = List;
            this.cboHistoryOfLand.SelectedIndex = -1;
        }

        public void BindBuildingConstructionPermit()
        {
            this.cboBuildingConPermit.DataSource = null;
            string[] List = { "RECEIVED", "NOT RECEIVED" };
            this.cboBuildingConPermit.DataSource = List;
            this.cboBuildingConPermit.SelectedIndex = -1;
        }

        public void BindTypeOfInsuranceForLand_Bld()
        {
            TypeOfInsuranceListForLand_Bld = CXCLE00002.Instance.GetListObject<LOMDTO00004>("LOMORM00004.SelectAllInsuranceType", new object[] { true });
            this.cboTypeOfInsuranceForLand_Bld.ValueMember = "INSUCODE";
            this.cboTypeOfInsuranceForLand_Bld.DisplayMember = "INSUCODE";
            this.cboTypeOfInsuranceForLand_Bld.DataSource = TypeOfInsuranceListForLand_Bld;
            this.cboTypeOfInsuranceForLand_Bld.SelectedIndex = -1;
        }

        public void BindCombo(string saleDeed, string landOfAffidavit, string history, string permit)
        {
            this.cboSalesDeed.Text = saleDeed;
            this.cboLandOfAffidavit.Text = landOfAffidavit;
            this.cboHistoryOfLand.Text = history;
            this.cboBuildingConPermit.Text = permit;
        }

        #endregion
                
        #region BindComboBox for LoanTypeandInterestInformation for agrilLoan
        public void BindTypeOfLand()
        {
            IList<LOMDTO00073> UMList = CXCLE00002.Instance.GetListObject<LOMDTO00073>("LOMORM00073.SelectAllUMCode", new object[] { true });
            this.cboTypeOfLand.ValueMember = "UMCode";
            this.cboTypeOfLand.DisplayMember = "UMDesp";
            this.cboTypeOfLand.DataSource = UMList;
            this.cboTypeOfLand.SelectedIndex = -1;
        }

        public void BindSeasonType()
        {
            ListForSeasonType = CXCLE00002.Instance.GetListObject<LOMDTO00071>("LOMORM00071.SelectAllSeasonCode", new object[] { true });
            this.cboSeasonType.ValueMember = "Code";
            this.cboSeasonType.DisplayMember = "Description";
            this.cboSeasonType.DataSource = ListForSeasonType;
            this.cboSeasonType.SelectedIndex = -1;
        }

        public void BindCropType()
        {
            ListForCropType = CXCLE00002.Instance.GetListObject<LOMDTO00072>("LOMORM00072.SelectAllCropTypeCode", new object[] { true });
            this.cboCropType.ValueMember = "CropCode";
            this.cboCropType.DisplayMember = "Desp";
            this.cboCropType.DataSource = ListForCropType;
            this.cboCropType.SelectedIndex = -1;
        }
        #endregion

        #region BindComboBox for LoanTypeandInterestInformation for Livestock Loan

        public void BindLSBusinessType()
        {
            IList<LOMDTO00076> LSBusinessTypeList = CXCLE00002.Instance.GetListObject<LOMDTO00076>("LOMORM00076.SelectAllLSBusinessCode", new object[] { true });
            this.cboLSBusinessType.ValueMember = "Code";
            this.cboLSBusinessType.DisplayMember = "Description";
            this.cboLSBusinessType.DataSource = LSBusinessTypeList;
            this.cboLSBusinessType.SelectedIndex = -1;
        }

        //public void BindLSTypeOfLand()
        //{
        //    IList<LOMDTO00073> UMList = CXCLE00002.Instance.GetListObject<LOMDTO00073>("LOMORM00073.SelectAllUMCode", new object[] { true });
        //    this.cboLSTypeOfLand.ValueMember = "UMCode";
        //    this.cboLSTypeOfLand.DisplayMember = "UMDesp";
        //    this.cboLSTypeOfLand.DataSource = UMList;
        //    this.cboLSTypeOfLand.SelectedIndex = -1;
        //}

        #endregion

        public void ClearFormControls()
        {
            this.txtLoanNo.Text = string.Empty;
            this.mtxtAccountNo.Text = string.Empty;
            this.cboCurrency.SelectedIndex = 0;
            this.cboTypeOfLoan.SelectedIndex = -1;
            this.txtName.Text = string.Empty;
            this.txtFatherName.Text = string.Empty;
            this.cboStateCode.SelectedIndex = -1;
            this.cboTownshipCode.SelectedIndex = -1;
            this.cboNationalityCode.SelectedIndex = -1;
            this.txtNRCNo.Text = string.Empty;
            this.txtNRC.Text = string.Empty;
            this.cboVillageGroup.SelectedIndex = -1;
            this.cboTownship.SelectedIndex = -1;
            this.txtAddress.Text = string.Empty;
            this.FirmCertificate = null;
            this.CusSignature = null;

            this.txtFarmName.Text = string.Empty;
            this.txtLandNo.Text = string.Empty;
            this.cboTypeOfLand.SelectedIndex = -1;
            this.cboSeasonType.SelectedIndex = -1;
            this.cboCropType.SelectedIndex = -1;
            this.txtLoanProductType.Text = string.Empty;
            this.txtGroupNo.Text = string.Empty;
            this.txtInterest.Text = string.Empty;
            this.txtPenalties.Text = string.Empty;
            this.txtFromDuration.Text = string.Empty;
            this.txtToDuration.Text = string.Empty;
            this.dtpWithdrawDate.Value = DateTime.Now;
            this.dtpDeadlineDate.Value = DateTime.Now;
            this.txtLoanAmount.Text = string.Empty;
            this.txtTotalAcrePerUnit.Text = string.Empty;
            this.txtSanctionLimit.Text = string.Empty;

            this.cboLSBusinessType.SelectedIndex = -1;
            this.txtLSTypeOfLand.Text = string.Empty;
            this.txtLSLicenseNo.Text = string.Empty;
            this.txtLSLoanProductType.Text = string.Empty;
            this.txtLSOther.Text = string.Empty;
            this.txtLSInterest.Text = string.Empty;
            this.txtLSPenalties.Text = string.Empty;
            this.txtLSFromDuration.Text = string.Empty;
            this.txtLSToDuration.Text = string.Empty;
            this.dtpLSWithdrawDate.Value = DateTime.Now;
            this.dtpLSDeadlineDate.Value = DateTime.Now;
            this.txtLSLoanAmount.Text = string.Empty;
            this.txtLSTotalAcre.Text = string.Empty;
            this.txtLSSanctionLimit.Text = string.Empty;

            this.mtxtPLandBS.Text = string.Empty;
            this.dtpEstablishmentDate.Value = DateTime.Now;
            this.txtYearExperience.Text = string.Empty;
            this.txtCapital.Text = "0.00";
            this.txtIncomeTax.Text = "0.00";
            this.cboSalesDeed.SelectedIndex = -1;
            this.cboLandOfAffidavit.SelectedIndex = -1;
            this.cboLand.SelectedIndex = -1;
            this.lblLand2.Text = string.Empty;
            this.cboCharacterOfCustomer.SelectedIndex = -1;
            this.cboGoodWill.SelectedIndex = -1;
            this.txtForceSaleValueOfBuilding.Text = "0.00";
            this.txtForceSaleValueOfLand.Text = "0.00";
            this.txtAddressInLB.Text = string.Empty;
            this.cboHistoryOfLand.SelectedIndex = -1;
            this.cboBuildingConPermit.SelectedIndex = -1;
            this.cboTypeOfInsuranceForLand_Bld.SelectedIndex = -1;
            this.lblTypeOfInsuranceForLand_Bld.Text = string.Empty;
            this.dtpDateOfInsurance.Value = DateTime.Now;
            this.dtpInsuranceExpireDate.Value = DateTime.Now;
            this.txtInsuranceAmount.Text = "0.00";

            this.txtGuarantorName.Text = string.Empty;
            this.txtGuarantorNrc.Text = string.Empty;
            this.txtGuarantorPhone.Text = string.Empty;
            this.mtxtGuaranterAccountNo.Text = string.Empty;
            this.txtGuarantorName2.Text = string.Empty;
            this.txtGuarantorNrc2.Text = string.Empty;
            this.txtGuarantorPhone2.Text = string.Empty;
            this.mtxtGuaranterAccountNo2.Text = string.Empty;
        }

        public void ClearFormControlsForAgriLoan()
        {
            this.txtFarmName.Text = string.Empty;
            this.txtLandNo.Text = string.Empty;
            this.cboTypeOfLand.SelectedIndex = -1;
            this.cboSeasonType.SelectedIndex = -1;
            this.cboCropType.SelectedIndex = -1;
            this.txtLoanProductType.Text = string.Empty;
            this.txtGroupNo.Text = string.Empty;
            this.txtInterest.Text = "0.00";
            this.txtPenalties.Text = "0.00";
            this.txtFromDuration.Text = string.Empty;
            this.txtToDuration.Text = string.Empty;
            this.dtpWithdrawDate.Value = DateTime.Now;
            this.dtpDeadlineDate.Value = DateTime.Now;
            this.txtLoanAmount.Text = "0.00";
            this.txtTotalAcrePerUnit.Text = "0.00";
            this.txtSanctionLimit.Text = "0.00";
        }

        public void ClearFormControlsForLSLoan()
        {
            this.cboLSBusinessType.SelectedIndex = -1;
            this.txtLSTypeOfLand.Text = string.Empty;
            this.txtLSLicenseNo.Text = string.Empty;
            this.txtLSLoanProductType.Text = string.Empty;
            this.txtLSOther.Text = string.Empty;
            this.txtLSInterest.Text = "0.00";
            this.txtLSPenalties.Text = "0.00";
            this.txtLSFromDuration.Text = string.Empty;
            this.txtLSToDuration.Text = string.Empty;
            this.dtpLSWithdrawDate.Value = DateTime.Now;
            this.dtpLSDeadlineDate.Value = DateTime.Now;
            this.txtLSLoanAmount.Text = "0.00";
            this.txtLSTotalAcre.Text = "0.00";
            this.txtLSSanctionLimit.Text = "0.00";
        }

        public void GetFormControlSetting()
        {
            this.isActive = false;
            this.grpPersonalInformation.Enabled = true;
            if (this.FormName.Contains("Enquiry"))
            {
                this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, false, true);
                this.txtLoanNo.MaxLength = 16;
                this.txtLoanNo.Enabled = true;
                this.cboCurrency.Enabled = false;
                this.mtxtAccountNo.Enabled = false;
                this.cboTypeOfLoan.Enabled = false;
                this.txtName.Enabled = false;
                this.txtFatherName.Enabled = false;
                this.cboVillageGroup.Enabled = false;
                this.cboTownship.Enabled = false;
                this.rdoNRC.Enabled = false;
                this.rdoOther.Enabled = false;
                this.cboStateCode.Enabled = false;
                this.cboTownshipCode.Enabled = false;
                this.cboNationalityCode.Enabled = false;
                this.txtNRC.Enabled = false;
                this.txtNRCNo.Enabled = false;
                this.txtAddress.Enabled = false;

                this.grpAgriLoanTypeIntInfo.Enabled = false;
                this.grpLSLoanTypeIntInfo.Enabled = false;

                this.tbLoanProduct.Enabled = true;
                this.tbLoanProduct.SelectedTab = tbpLandAndBuilding;
                ((Control)this.tbpLandAndBuilding).Enabled = false;
                ((Control)this.tbpPersonalGuarantee).Enabled = false;

                this.grpFirmCertificate.Enabled = false;
                this.grpCusSignature.Enabled = false;
            }
            else if (this.FormName.Contains("Entry"))
            {
                this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);

                this.txtLoanNo.Enabled = false;

                this.cboTypeOfLoan.Enabled = true;
                this.cboCurrency.Enabled = true;
                this.mtxtAccountNo.Enabled = true;
                this.cboCurrency.SelectedIndex = 0;
                this.cboCurrency.Focus();

                this.tbLoanProduct.Enabled = false;
                this.tbLoanProduct.SelectedTab = tbpLandAndBuilding;
                ((Control)this.tbpLandAndBuilding).Enabled = false;
                ((Control)this.tbpPersonalGuarantee).Enabled = false;

                this.grpFirmCertificate.Enabled = true;
                this.grpCusSignature.Enabled = true;
            }
            else if (this.FormName.Contains("Editting"))
            {
                this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);

                this.txtLoanNo.Enabled = true;
                this.txtLoanNo.Focus();

                this.cboCurrency.Enabled = false;
                this.cboTypeOfLoan.Enabled = false;
                this.mtxtAccountNo.Enabled = false;
                this.rdoNRC.Checked = false;
                this.rdoOther.Checked = true;

                this.tbLoanProduct.Enabled = false;
                this.tbLoanProduct.SelectedTab = tbpLandAndBuilding;
                ((Control)this.tbpLandAndBuilding).Enabled = false;
                ((Control)this.tbpPersonalGuarantee).Enabled = false;

                this.grpFirmCertificate.Enabled = true;
                this.grpCusSignature.Enabled = true;
            }
            
            this.BindCurrency();
            this.BindTypeOfLoan();
            this.BindStateCombobox();
            this.BindTownshipCombobox();
            this.BindNationalityCombobox();
            this.BindVillageGroupCombobox();
            this.BindTownshipCodeCombobox();
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.mtxtGuaranterAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.mtxtGuaranterAccountNo2.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);

            this.lblLand2.Visible = false;
            this.lblTypeOfInsuranceForLand_Bld.Visible = false;

            NRCCodeList = CXCLE00002.Instance.GetListObject<SAMDTO00054>("NRCCode.Client.Select", new object[] { true });//Bind NRC Code
        }

        private bool ControlValidation()
        {
            #region Personal Information
            if (String.IsNullOrEmpty(this.AccountNo))
            {
                this.mtxtAccountNo.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(this.TypeOfLoan))
            {
                this.cboTypeOfLoan.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(this.NameInPI))
            {
                this.txtName.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(this.FatherNameInPI))
            {
                this.txtFatherName.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(this.VillageGroupCode))
            {
                this.cboVillageGroup.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(this.TownshipCode))
            {
                this.cboTownship.Focus();
                return false;
            }
            else if (rdoNRC.Checked)
            {
                if (String.IsNullOrEmpty(this.StateCodeForNRC))
                {
                    this.cboStateCode.Focus();
                    return false;
                }
                else if (String.IsNullOrEmpty(this.TownshipCodeForNRC))
                {
                    this.cboTownshipCode.Focus();
                    return false;
                }
                else if (String.IsNullOrEmpty(this.NationalityCodeForNRC))
                {
                    this.cboNationalityCode.Focus();
                    return false;
                }
                else if (String.IsNullOrEmpty(this.NRCNo))
                {
                    this.txtNRCNo.Focus();
                    return false;
                }
            }
            else if (rdoOther.Checked)
            {
                if (String.IsNullOrEmpty(this.NRC))
                {
                    this.txtNRC.Focus();
                    return false;
                }
            }
            else if (String.IsNullOrEmpty(this.Address))
            {
                this.txtAddress.Focus();
                return false;
            }
            #endregion

            #region Loan Type and Interest Information
            if (this.cboTypeOfLoan.Text != null && this.cboTypeOfLoan.Text.Contains("AGRICULTURAL"))
            {
                if (String.IsNullOrEmpty(this.FarmName))
                {
                    this.txtFarmName.Focus();
                    return false;
                }
                else if (String.IsNullOrEmpty(this.LandNo))
                {
                    this.txtLandNo.Focus();
                    return false;
                }
                else if (String.IsNullOrEmpty(this.TypeOfLand))
                {
                    this.cboTypeOfLand.Focus();
                    return false;
                }
                else if (String.IsNullOrEmpty(this.SeasonType))
                {
                    this.cboSeasonType.Focus();
                    return false;
                }
                else if (String.IsNullOrEmpty(this.CropType))
                {
                    this.cboCropType.Focus();
                    return false;
                }
                else if (String.IsNullOrEmpty(this.LoanProductType))
                {
                    this.txtLoanProductType.Focus();
                    return false;
                }
                else if (String.IsNullOrEmpty(this.GroupNo))
                {
                    this.txtGroupNo.Focus();
                    return false;
                }
                else if (this.Interest == null)
                {
                    this.txtInterest.Focus();
                    return false;
                }
                else if (this.Penalties == null)
                {
                    this.txtPenalties.Focus();
                    return false;
                }
                else if (this.LoanAmtPerAcre == null)
                {
                    this.txtLoanAmount.Focus();
                    return false;
                }
                else if (this.TotalAcre == null)
                {
                    this.txtTotalAcrePerUnit.Focus();
                    return false;
                }
            }
            else if (this.cboTypeOfLoan.Text != null && this.cboTypeOfLoan.Text.Contains("LIVESTOCK"))
            {
                if (String.IsNullOrEmpty(this.LSBusinessType))
                {
                    this.cboLSBusinessType.Focus();
                    return false;
                }
                else if (String.IsNullOrEmpty(this.LSTypeOfLand))
                {
                    this.txtLSTypeOfLand.Focus();
                    return false;
                }
                else if (String.IsNullOrEmpty(this.LSLicenseNo))
                {
                    this.txtLSLicenseNo.Focus();
                    return false;
                }
                else if (String.IsNullOrEmpty(this.LSLoanProductType))
                {
                    this.txtLSLoanProductType.Focus();
                    return false;
                }
                else if (this.LSInterest == null)
                {
                    this.txtLSInterest.Focus();
                    return false;
                }
                else if (this.LSPenalties == null)
                {
                    this.txtLSPenalties.Focus();
                    return false;
                }
                else if (this.LSLoanAmtPerAcre == null)
                {
                    this.txtLSLoanAmount.Focus();
                    return false;
                }
                else if (this.LSTotalAcre == null)
                {
                    this.txtLSTotalAcre.Focus();
                    return false;
                }
            }
            #endregion

            #region Land_Building

            if (this.cboTypeOfLoan.Text != null)
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
            if (this.cboTypeOfLoan != null && this.cboTypeOfLoan.Text.Contains("LIVESTOCK"))
            {
                //if (String.IsNullOrEmpty(this.GuarantorAccountNo1))
                //{
                //    this.mtxtGuaranterAccountNo.Focus();
                //    return false;
                //}else
                if (String.IsNullOrEmpty(this.GuarantorName1))
                {
                    this.txtGuarantorName.Focus();
                    return false;
                }
                if (String.IsNullOrEmpty(this.GuarantorNrc1))
                {
                    this.txtGuarantorNrc.Focus();
                    return false;
                }
                else if (String.IsNullOrEmpty(this.GuarantorPhone1))
                {
                    this.txtGuarantorPhone.Focus();
                    return false;
                }
                //else if (String.IsNullOrEmpty(this.GuarantorAccountNo2))
                //{
                //    this.mtxtGuaranterAccountNo2.Focus();
                //    return false;
                //}
                else if (String.IsNullOrEmpty(this.GuarantorName2))
                {
                    this.txtGuarantorName2.Focus();
                    return false;
                }
                if (String.IsNullOrEmpty(this.GuarantorNrc2))
                {
                    this.txtGuarantorNrc2.Focus();
                    return false;
                }
                else if (String.IsNullOrEmpty(this.GuarantorPhone2))
                {
                    this.txtGuarantorPhone2.Focus();
                    return false;
                }
            }

            #endregion

            return true;
        }

        public void BindComboOfLB()
        {
            this.BindSalesDeed();
            this.BindLandOfAffidavit();
            this.BindAllLand();
            this.BindCustomerCharacterCode();
            this.BindGoodWill();
            this.BindHistoryOfLandandBuilding();
            this.BindBuildingConstructionPermit();
            this.BindTypeOfInsuranceForLand_Bld();
        }

        public void BindComboForAgriLoan()
        {
            this.BindTypeOfLand();
            this.BindSeasonType();
            this.BindCropType();
        }

        public void BindComboForLSLoan()
        {
            this.BindLSBusinessType();
            //this.BindLSTypeOfLand();
        }

        //public void BindAccountInfo(IList<PFMDTO00072> accountInfoList)
        //{
        //    this.gdvAccountInfo.AutoGenerateColumns = false;
        //    this.gdvAccountInfo.DataSource = null;
        //    this.gdvAccountInfo.CausesValidation = false;
        //    this.gdvAccountInfo.DataSource = accountInfoList;
        //    this.lblNameOfFirm2.Visible = true;
        //    this.lblNameOfFirm2.Text = (accountInfoList[0].BankAccountDescription == "") ? " - " :
        //                                accountInfoList[0].BankAccountDescription;//For Name of Firm in Company Account,Association and etc;
        //}

        private void BindGuarantee1Info(IList<PFMDTO00001> GuaranteeAccountInfoList)
        {
            this.GuarantorName1 = GuaranteeAccountInfoList[0].Name;
            this.GuarantorNrc1 = GuaranteeAccountInfoList[0].NRC;
            this.GuarantorPhone1 = GuaranteeAccountInfoList[0].PhoneNo;
            if (this.FormName.Contains("Edit"))
            {
                this.txtGuarantorName.Enabled = true;
                this.txtGuarantorNrc.Enabled = true;
                this.txtGuarantorPhone.Enabled = true;
            }
            else
            {
                this.txtGuarantorName.Enabled = false;
                this.txtGuarantorNrc.Enabled = false;
                this.txtGuarantorPhone.Enabled = false;
            }
        }

        private void BindGuarantee2Info(IList<PFMDTO00001> GuaranteeAccountInfoList)
        {
            this.GuarantorName2 = GuaranteeAccountInfoList[0].Name;
            this.GuarantorNrc2 = GuaranteeAccountInfoList[0].NRC;
            this.GuarantorPhone2 = GuaranteeAccountInfoList[0].PhoneNo;
            if (this.FormName.Contains("Edit"))
            {
                this.txtGuarantorName2.Enabled = true;
                this.txtGuarantorNrc2.Enabled = true;
                this.txtGuarantorPhone2.Enabled = true;
            }
            else
            {
                this.txtGuarantorName2.Enabled = false;
                this.txtGuarantorNrc2.Enabled = false;
                this.txtGuarantorPhone2.Enabled = false;
            }
        }

        // Create a thumbnail in byte array format from the image encoded in the passed byte array.  
        // (RESIZE an image in a byte[] variable.)          
        public byte[] CreateThumbnail(byte[] PassedImage, int LargestSide)
        {
            byte[] ReturnedThumbnail;

            using (System.IO.MemoryStream StartMemoryStream = new System.IO.MemoryStream(),
                                NewMemoryStream = new System.IO.MemoryStream())
            {
                // write the string to the stream  
                StartMemoryStream.Write(PassedImage, 0, PassedImage.Length);

                // create the start Bitmap from the MemoryStream that contains the image  
                Bitmap startBitmap = new Bitmap(StartMemoryStream);

                // set thumbnail height and width proportional to the original image.  
                int newHeight;
                int newWidth;
                double HW_ratio;
                if (startBitmap.Height > startBitmap.Width)
                {
                    newHeight = LargestSide;
                    HW_ratio = (double)((double)LargestSide / (double)startBitmap.Height);
                    newWidth = (int)(HW_ratio * (double)startBitmap.Width);
                }
                else
                {
                    newWidth = LargestSide;
                    HW_ratio = (double)((double)LargestSide / (double)startBitmap.Width);
                    newHeight = (int)(HW_ratio * (double)startBitmap.Height);
                }

                // create a new Bitmap with dimensions for the thumbnail.  
                Bitmap newBitmap = new Bitmap(newWidth, newHeight);

                // Copy the image from the START Bitmap into the NEW Bitmap.  
                // This will create a thumnail size of the same image.  
                newBitmap = ResizeImage(startBitmap, newWidth, newHeight);

                // Save this image to the specified stream in the specified format.  
                newBitmap.Save(NewMemoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);

                // Fill the byte[] for the thumbnail from the new MemoryStream.  
                ReturnedThumbnail = NewMemoryStream.ToArray();
            }

            // return the resized image as a string of bytes.  
            return ReturnedThumbnail;
        }

        // Resize a Bitmap  
        private static Bitmap ResizeImage(Bitmap image, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics gfx = Graphics.FromImage(resizedImage))
            {
                gfx.DrawImage(image, new Rectangle(0, 0, width, height),
                    new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
            }
            return resizedImage;
        }

        public void BindCommonFarmLoanToView(LOMDTO00078 loanDto)
        {
            this.AccountNo = loanDto.AcctNo;
            this.CurrencyCode = loanDto.Cur;
            this.TypeOfLoan = loanDto.LoanType;
            this.NameInPI = loanDto.Name;
            this.FatherNameInPI = loanDto.FatherName;
            this.VillageGroupCode = loanDto.Village;
            this.TownshipCode = loanDto.Township;
            this.NRC = loanDto.NRC;
            this.Address = loanDto.Address;
            if (loanDto.FarmSignature != null)
            {
                this.FirmCertificate = CXClientGlobal.GetImage(loanDto.FarmSignature);
            }
            if (loanDto.Signature != null)
            {
                this.CusSignature = CXClientGlobal.GetImage(loanDto.Signature);
            }
            if (loanDto.LoanType.Equals("111"))
            {
                this.FarmName = loanDto.FarmName;
                this.LandNo = loanDto.LandNo;
                this.TypeOfLand = loanDto.LandType;
                this.SeasonType = loanDto.SeasonType;
                this.CropType = loanDto.BusinessType;
                this.LoanProductType = loanDto.LoanProductType;
                this.GroupNo = loanDto.GroupNo;
                this.Interest = (decimal)loanDto.IntRate;
                this.Penalties = (decimal)loanDto.Penalties;
                this.StartPeriod = loanDto.StartPeriod;
                this.EndPeriod = loanDto.EndPeriod;
                this.WithdrawDate = (DateTime)loanDto.WithdrawDate;
                this.DeadlineDate = (DateTime)loanDto.ExpireDate;
                this.LoanAmtPerAcre = (decimal)loanDto.LoanAmtPerAcre;
                this.TotalAcre = (decimal)loanDto.TotalAcre;
                this.SanctionLimit = (decimal)loanDto.SAmt;

                this.SetVisibleDisableLoanTypePanel(true);
            }
            else if (loanDto.LoanType.Equals("112"))
            {
                this.LSBusinessType = loanDto.BusinessType;
                this.LSTypeOfLand = this.Controller.SelectUMDespByUMCode(loanDto.LandType);
                this.LSUMCode = loanDto.LandType;
                this.LSLicenseNo = loanDto.LandNo;
                this.LSLoanProductType = loanDto.LoanProductType;
                this.LSOther = loanDto.Remark;
                this.LSInterest = (decimal)loanDto.IntRate;
                this.LSPenalties = (decimal)loanDto.Penalties;
                this.LSStartPeriod = loanDto.StartPeriod;
                this.LSEndPeriod = loanDto.EndPeriod;
                this.LSWithdrawDate = (DateTime)loanDto.WithdrawDate;
                this.LSDeadlineDate = (DateTime)loanDto.ExpireDate;
                this.LSLoanAmtPerAcre = (decimal)loanDto.LoanAmtPerAcre;
                this.LSTotalAcre = (decimal)loanDto.TotalAcre;
                this.LSSanctionLimit = (decimal)loanDto.SAmt;

                this.SetVisibleDisableLoanTypePanel(false);
            }
        }

        public void SelectTab(string tabName, bool isEnable)
        {
            this.tbLoanProduct.Enabled = true;
            //((Control)this.tbpLandAndBuilding).Enabled = false;
            //((Control)this.tbpPersonalGuarantee).Enabled = false;
            switch (tabName)
            {
                case "land": tbLoanProduct.SelectedTab = tbpLandAndBuilding; ((Control)this.tbpLandAndBuilding).Enabled = isEnable; ; break;
                case "per": tbLoanProduct.SelectedTab = tbpPersonalGuarantee; ((Control)this.tbpPersonalGuarantee).Enabled = isEnable; break;
            }
        }

        public void SetVisibleDisableLoanTypePanel(bool isVisible)
        {
            this.grpAgriLoanTypeIntInfo.Visible = isVisible;
            this.grpLSLoanTypeIntInfo.Visible = !isVisible;
        }

        public void SetEnableDisableLoanTypePanel(bool isEnable)
        {
            this.grpAgriLoanTypeIntInfo.Enabled = isEnable;
            this.grpLSLoanTypeIntInfo.Enabled = isEnable;
        }

        #endregion

        #region Get ViewData To Save

        private LOMDTO00078 getViewDataForCommon;
        public LOMDTO00078 GetViewDataForCommon
        {
            get
            {
                if (this.getViewDataForCommon == null) getViewDataForCommon = new LOMDTO00078();
                //Personal Information
                if (!String.IsNullOrEmpty(this.txtLoanNo.Text))
                {
                    getViewDataForCommon.Lno = this.LoanNo;
                }
                getViewDataForCommon.AcctNo = this.AccountNo;
                getViewDataForCommon.AType = "LOANS";
                getViewDataForCommon.Name = this.NameInPI;
                getViewDataForCommon.FatherName = this.FatherNameInPI;
                getViewDataForCommon.Cur = this.CurrencyCode;
                getViewDataForCommon.SourceBr = this.controller.BranchCode;
                getViewDataForCommon.LoanType = this.TypeOfLoan;
                getViewDataForCommon.Village = this.VillageGroupCode;
                getViewDataForCommon.Township = this.TownshipCode;
                if (this.isOtherNRC)
                {
                    getViewDataForCommon.NRC = this.NRC;
                }
                else
                {
                    getViewDataForCommon.NRC = this.StateCodeForNRC + this.TownshipCodeForNRC +
                        this.NationalityCodeForNRC + this.NRCNo;
                }
                getViewDataForCommon.Address = this.Address;

                //Loan Type and Interest Information for agri loan 
                if (this.TypeOfLoan.Contains("111"))
                {
                    getViewDataForCommon.FarmName = this.FarmName;
                    getViewDataForCommon.LandNo = this.LandNo;
                    getViewDataForCommon.LandType = this.TypeOfLand;
                    getViewDataForCommon.SeasonType = this.SeasonType;
                    getViewDataForCommon.BusinessType = this.CropType;
                    getViewDataForCommon.LoanProductType = this.LoanProductType;
                    getViewDataForCommon.GroupNo = this.GroupNo;
                    getViewDataForCommon.IntRate = this.Interest;
                    getViewDataForCommon.Penalties = this.Penalties;
                    getViewDataForCommon.StartPeriod = this.StartPeriod;
                    getViewDataForCommon.EndPeriod = this.EndPeriod;
                    getViewDataForCommon.WithdrawDate = this.WithdrawDate;
                    getViewDataForCommon.ExpireDate = this.DeadlineDate;
                    getViewDataForCommon.LoanAmtPerAcre = this.LoanAmtPerAcre;
                    getViewDataForCommon.TotalAcre = this.TotalAcre;
                    getViewDataForCommon.SAmt = this.SanctionLimit;
                }
                //Loan Type and Interest Information for Livestock loan
                else if (this.TypeOfLoan.Contains("112"))
                {
                    getViewDataForCommon.BusinessType = this.LSBusinessType;
                    getViewDataForCommon.LandType = this.LSUMCode;
                    getViewDataForCommon.LandNo = this.LSLicenseNo;
                    getViewDataForCommon.LoanProductType = this.LSLoanProductType;
                    getViewDataForCommon.Remark = this.LSOther;
                    getViewDataForCommon.IntRate = this.LSInterest;
                    getViewDataForCommon.Penalties = this.LSPenalties;
                    getViewDataForCommon.StartPeriod = this.LSStartPeriod;
                    getViewDataForCommon.EndPeriod = this.LSEndPeriod;
                    getViewDataForCommon.WithdrawDate = this.LSWithdrawDate;
                    getViewDataForCommon.ExpireDate = this.LSDeadlineDate;
                    getViewDataForCommon.LoanAmtPerAcre = this.LSLoanAmtPerAcre;
                    getViewDataForCommon.TotalAcre = this.LSTotalAcre;
                    getViewDataForCommon.SAmt = this.LSSanctionLimit;
                    getViewDataForCommon.GroupNo = "-";
                }

                getViewDataForCommon.ACSign = this.controller.Acsign;
                getViewDataForCommon.CreatedUserId = CurrentUserEntity.CurrentUserID;
                getViewDataForCommon.CreatedDate = DateTime.Now;
                getViewDataForCommon.UniqueId = CurrentUserEntity.CurrentUserID.ToString();
                if (this.FirmCertificate != null)
                {
                    getViewDataForCommon.FarmSignature = this.CreateThumbnail(CXClientGlobal.ImageToByteArray(this.FirmCertificate), this.LargestSize);
                }
                else
                {
                    getViewDataForCommon.FarmSignature = null;
                }
                if (this.CusSignature != null)
                {
                    getViewDataForCommon.Signature = this.CreateThumbnail(CXClientGlobal.ImageToByteArray(this.CusSignature), this.LargestSize);
                }
                else
                {
                    getViewDataForCommon.Signature = null;
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
                getViewDataForLandAndBuilding.IsExpiredDate = this.InsuranceExpireDate;
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
                getViewDataForLandAndBuilding.CreatedDate = DateTime.Now;
                getViewDataForLandAndBuilding.CreatedUserId = CurrentUserEntity.CurrentUserID;
                // left Eva value 
                return getViewDataForLandAndBuilding;
            }
            set { this.getViewDataForLandAndBuilding = value; }
        }

        private LOMDTO00079 getViewDataForGuarantee;
        public LOMDTO00079 GetViewDataForGuarantee
        {
            get
            {
                if (getViewDataForGuarantee == null) getViewDataForGuarantee = new LOMDTO00079();

                getViewDataForGuarantee.Lno = this.LoanNo;
                getViewDataForGuarantee.AcctNo1 = this.GuarantorAccountNo1;
                getViewDataForGuarantee.Name1 = this.GuarantorName1;
                getViewDataForGuarantee.NRC1 = this.GuarantorNrc1;
                getViewDataForGuarantee.Phone1 = this.GuarantorPhone1;
                getViewDataForGuarantee.AcctNo2 = this.GuarantorAccountNo2;
                getViewDataForGuarantee.Name2 = this.GuarantorName2;
                getViewDataForGuarantee.NRC2 = this.GuarantorNrc2;
                getViewDataForGuarantee.Phone2 = this.GuarantorPhone2;
                getViewDataForGuarantee.USERNO = CurrentUserEntity.CurrentUserID.ToString();
                getViewDataForGuarantee.SourceBr = this.controller.BranchCode;
                getViewDataForGuarantee.Cur = this.CurrencyCode;

                getViewDataForGuarantee.CreatedDate = DateTime.Now;
                getViewDataForGuarantee.CreatedUserId = CurrentUserEntity.CurrentUserID;

                return getViewDataForGuarantee;
            }
            set { this.getViewDataForGuarantee = value; }

        }

        public LOMDTO00085 getViewDataForInterest;
        public LOMDTO00085 GetViewDataForInterest()
        {
            getViewDataForInterest = new LOMDTO00085();
            getViewDataForInterest.LNo = this.LoanNo;
            getViewDataForInterest.AcctNo = this.AccountNo;
            getViewDataForInterest.ACSign = this.controller.Acsign;

            if (this.TypeOfLoan == "111")
            {
                getViewDataForInterest.PrincipalAmount = this.SanctionLimit;
                getViewDataForInterest.LoanProductCode = this.LoanProductType;
            }
            else if (this.TypeOfLoan == "112")
            {
                getViewDataForInterest.PrincipalAmount = this.LSSanctionLimit;
                getViewDataForInterest.LoanProductCode = this.LSLoanProductType;
            }

            getViewDataForInterest.SourceBr = this.controller.BranchCode;
            getViewDataForInterest.Cur = this.CurrencyCode;

            getViewDataForInterest.CreatedDate = DateTime.Now;
            getViewDataForInterest.CreatedUserId = CurrentUserEntity.CurrentUserID;

            return getViewDataForInterest;
        }

        public LOMDTO00300 getViewDataForPenalFee;
        public LOMDTO00300 GetViewDataForPenalFee()
        {
            getViewDataForPenalFee = new LOMDTO00300();
            getViewDataForPenalFee.Lno = this.LoanNo;
            getViewDataForPenalFee.LoanType = this.TypeOfLoan;

            if (this.TypeOfLoan == "111")
            {
                getViewDataForPenalFee.LoanProductType = this.LoanProductType;
                getViewDataForPenalFee.SAmt = this.SanctionLimit;
                getViewDataForPenalFee.FirstAmt = this.SanctionLimit;
                getViewDataForPenalFee.ExpireDate = this.DeadlineDate;
            }
            else if (this.TypeOfLoan == "112")
            {
                getViewDataForPenalFee.LoanProductType = this.LSLoanProductType;
                getViewDataForPenalFee.SAmt = this.LSSanctionLimit;
                getViewDataForPenalFee.FirstAmt = this.LSSanctionLimit;
                getViewDataForPenalFee.ExpireDate = this.LSDeadlineDate;
            }

            getViewDataForPenalFee.SourceBr = this.controller.BranchCode;

            getViewDataForPenalFee.CreatedDate = DateTime.Now;
            getViewDataForPenalFee.CreatedUserId = CurrentUserEntity.CurrentUserID;

            return getViewDataForPenalFee;
        }


        #endregion

        #region Events

        private void LOMVEW00078_Load(object sender, EventArgs e)
        {
            this.txtLoanNo.MaxLength = 16;
            this.Text = this.FormName;
            this.GetFormControlSetting();
            this.grpAgriLoanTypeIntInfo.Visible = true;
            this.txtNRC.Enabled = false;
            this.isSaveValidate = false;
            this.flag = false;
            if (this.FormName.Contains("Entry"))
            {
                this.txtLoanNo.Enabled = false;
                this.cboCurrency.Focus();
            }
            else
            {
                this.txtLoanNo.Enabled = true;
                this.txtLoanNo.Focus();
            }
            this.isActive = true;
        }

        private void textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
            catch { }
        }

        private void mtxtAccountNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void cboTypeOfLoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.isActive)
            {
                if (!String.IsNullOrEmpty(this.TypeOfLoan))
                {
                    PFMDTO00009 interestRateDto = new PFMDTO00009();
                    interestRateDto = CXCLE00002.Instance.GetScalarObject<PFMDTO00009>("PFMORM00009.Client.SelectByCodeAndLastModify", new object[] { "FLOANRATE", true, true });
                    PFMDTO00009 penalRateDto = new PFMDTO00009();
                    penalRateDto = CXCLE00002.Instance.GetScalarObject<PFMDTO00009>("PFMORM00009.Client.SelectByCodeAndLastModify", new object[] { "FLOANPENALRATE", true, true });

                    if (this.TypeOfLoan.Contains("111"))
                    {
                        this.ClearFormControlsForAgriLoan();

                        this.grpAgriLoanTypeIntInfo.Visible = true;
                        this.grpAgriLoanTypeIntInfo.Enabled = true;
                        this.tbLoanProduct.Enabled = true;
                        this.tbLoanProduct.SelectedTab = tbpLandAndBuilding;
                        ((Control)this.tbpLandAndBuilding).Enabled = true;
                        this.BindComboOfLB();
                        this.BindComboForAgriLoan();

                        ((Control)this.tbpPersonalGuarantee).Enabled = false;
                        this.grpLSLoanTypeIntInfo.Visible = false;
                        this.grpLSLoanTypeIntInfo.Enabled = false;

                        this.Interest = interestRateDto.Rate;
                        this.Penalties = penalRateDto.Rate;

                        this.txtName.Focus();
                    }
                    else if (this.TypeOfLoan.Contains("112"))
                    {
                        this.ClearFormControlsForLSLoan();

                        this.grpAgriLoanTypeIntInfo.Visible = false;
                        this.grpAgriLoanTypeIntInfo.Enabled = false;

                        this.grpLSLoanTypeIntInfo.Visible = true;
                        this.grpLSLoanTypeIntInfo.Enabled = true;
                        this.tbLoanProduct.Enabled = true;
                        this.tbLoanProduct.SelectedTab = tbpLandAndBuilding;
                        ((Control)this.tbpLandAndBuilding).Enabled = true;
                        ((Control)this.tbpPersonalGuarantee).Enabled = true;
                        this.BindComboOfLB();
                        this.BindComboForLSLoan();

                        this.LSInterest = interestRateDto.Rate;
                        this.LSPenalties = penalRateDto.Rate;

                        this.txtName.Focus();
                    }
                }
                else
                {
                    this.grpAgriLoanTypeIntInfo.Visible = true;
                    this.grpAgriLoanTypeIntInfo.Enabled = false;

                    this.grpLSLoanTypeIntInfo.Visible = false;
                    this.grpLSLoanTypeIntInfo.Enabled = false;

                    this.tbLoanProduct.Enabled = false;
                    this.tbLoanProduct.SelectedTab = tbpLandAndBuilding;
                    ((Control)this.tbpLandAndBuilding).Enabled = false;
                    ((Control)this.tbpPersonalGuarantee).Enabled = false;
                }
            }
        }

        private void rdoNRC_CheckedChanged(object sender, EventArgs e)
        {
            if (this.FormState == FormState.New)
            {
                if (this.txtNRC.Text != null || this.txtNRC.Text.ToString() != string.Empty)
                {
                    this.txtNRC.Text = "";
                }
                this.txtNRC.Enabled = false;

                this.cboStateCode.Enabled = true;
                this.cboTownshipCode.Enabled = true;
                this.cboNationalityCode.Enabled = true;
                this.txtNRCNo.Enabled = true;
                this.isOtherNRC = false;
            }
        }

        private void rdoOther_CheckedChanged(object sender, EventArgs e)
        {
            if (this.FormState == FormState.New)
            {
                if (this.cboStateCode.SelectedIndex > -1 || this.cboStateCode.SelectedValue != null)
                {
                    this.cboStateCode.SelectedIndex = -1;
                }
                if (this.cboTownshipCode.SelectedIndex > -1 || this.cboTownshipCode.SelectedValue != null)
                {
                    this.cboTownshipCode.SelectedIndex = -1;
                }
                if (this.cboNationalityCode.SelectedIndex > -1 || this.cboNationalityCode.SelectedValue != null)
                {
                    this.cboNationalityCode.SelectedIndex = -1;
                }
                if (this.txtNRCNo.Text != null || this.txtNRCNo.Text.ToString() != string.Empty)
                {
                    this.txtNRCNo.Text = "";
                }
                this.txtNRC.Enabled = true;
                this.isOtherNRC = true;

                this.cboStateCode.Enabled = false;
                this.cboTownshipCode.Enabled = false;
                this.cboNationalityCode.Enabled = false;
                this.txtNRCNo.Enabled = false;
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

        private void cboTypeOfInsuranceForLand_Bld_SelectedIndexChanged(object sender, EventArgs e)
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

        private void cboLSBusinessType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.LSBusinessType))
            {
                if (this.cboLSBusinessType.SelectedIndex != -1)
                {
                    this.ListForLSProductTypeItem = CXCLE00002.Instance.GetListObject<LOMDTO00077>("LOMORM00077.SelectAllLSProductType", new object[] { true });
                    this.ListForUM = CXCLE00002.Instance.GetListObject<LOMDTO00073>("LOMORM00073.SelectAllUMCode", new object[] { true });

                    //Bind Land Type via selected business type
                    string value = this.cboLSBusinessType.SelectedValue.ToString();
                    string umcode = (from b in this.ListForLSProductTypeItem
                                     where b.LSBusinessCode.Equals(this.cboLSBusinessType.SelectedValue.ToString())
                                     orderby b.LSBusinessCode
                                     select b.UMCode).Single();
                    this.txtLSTypeOfLand.Text = (from a in this.ListForUM
                                                 where a.UMCode.Equals(umcode.ToString())
                                                 orderby a.UMCode
                                                 select a.UMDesp).Single();
                    this.lblLSUMCode.Text = (from a in this.ListForUM
                                             where a.UMCode.Equals(umcode.ToString())
                                             orderby a.UMCode
                                             select a.UMCode).Single();
                    //Bind Loan Product Type via selected business type
                    string businessCode = (from b in this.ListForLSProductTypeItem
                                           where b.LSBusinessCode.Equals(this.cboLSBusinessType.SelectedValue.ToString())
                                           orderby b.LSBusinessCode
                                           select b.LSBusinessCode).Single();
                    string currentYear = (DateTime.Now.Year.ToString()).Substring(2, 2);
                    this.txtLSLoanProductType.Text = "L" + businessCode.ToUpper() + currentYear;

                    //Bind Duration and Deadline Date via selected business type
                    int months = (from b in this.ListForLSProductTypeItem
                                  where b.LSBusinessCode.Equals(this.cboLSBusinessType.SelectedValue.ToString())
                                  orderby b.LSBusinessCode
                                  select b.DurationMonths).Single();
                    this.txtLSFromDuration.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    this.txtLSToDuration.Text = DateTime.Now.AddMonths(months).ToString("dd/MM/yyyy");
                    this.dtpLSDeadlineDate.Value = DateTime.Now.AddMonths(months);
                }
            }
            else
            {
                this.txtLSTypeOfLand.Text = string.Empty;
                this.txtLSLoanProductType.Text = string.Empty;
                this.txtLSFromDuration.Text = string.Empty;
                this.txtLSToDuration.Text = string.Empty;
                this.dtpLSDeadlineDate.Value = DateTime.Now;
            }
        }

        private void txtLSLoanAmount_Leave(object sender, EventArgs e)
        {
            decimal loanAmt = 0;
            decimal totalAcre = 0;
            Decimal.TryParse(this.txtLSLoanAmount.Text, out loanAmt);
            Decimal.TryParse(this.txtLSTotalAcre.Text, out totalAcre);
            decimal sanctionLimit = loanAmt * totalAcre;
            this.txtLSSanctionLimit.Text = sanctionLimit.ToString();
        }

        private void txtLSTotalAcre_Leave(object sender, EventArgs e)
        {
            decimal loanAmt = 0;
            decimal totalAcre = 0;
            Decimal.TryParse(this.txtLSLoanAmount.Text, out loanAmt);
            Decimal.TryParse(this.txtLSTotalAcre.Text, out totalAcre);
            decimal sanctionLimit = loanAmt * totalAcre;
            this.txtLSSanctionLimit.Text = sanctionLimit.ToString();
        }

        private void cboSeasonType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.SeasonType))
            {
                //Bind From Duration and To Duration and Deadline Date via selected season type
                string dateFormat = "{0}/{1}/{2}";
                string curYear = DateTime.Now.Year.ToString();
                string nextYear = DateTime.Now.AddYears(1).Year.ToString();
                string deadLineDate = string.Empty;
                string preYear = (DateTime.Now.Year - 1).ToString();

                ListForAGProductTypeItem = CXCLE00002.Instance.GetListObject<LOMDTO00075>("LOMORM00075.SelectAllAGProductTypeItem", new object[] { true });
                LOMDTO00075 agPTI = (from b in this.ListForAGProductTypeItem
                                     where b.SeasonCode.Equals(this.cboSeasonType.SelectedValue.ToString())
                                     orderby b.SeasonCode
                                     select b).Single();


                if (agPTI.SMonth.Length == 1)
                {
                    agPTI.SMonth = "0" + agPTI.SMonth;
                }
                if (agPTI.EMonth.Length == 1)
                {
                    agPTI.EMonth = "0" + agPTI.EMonth;
                }
                if (agPTI.DeadLineMonth.Length == 1)
                {
                    agPTI.DeadLineMonth = "0" + agPTI.DeadLineMonth;
                }
                if (agPTI.SDay.Length == 1)
                {
                    agPTI.SDay = "0" + agPTI.SDay;
                }
                if (agPTI.EDay.Length == 1)
                {
                    agPTI.EDay = "0" + agPTI.EDay;
                }
                if (agPTI.DeadLineDay.Length == 1)
                {
                    agPTI.DeadLineDay = "0" + agPTI.DeadLineDay;
                }


                if (Int32.Parse(agPTI.SMonth) > Int32.Parse(agPTI.EMonth))
                {
                    if (DateTime.Now.Month <= 12 && DateTime.Now.Month > 9)
                    {
                        this.txtFromDuration.Text = String.Format(dateFormat, agPTI.SDay, agPTI.SMonth, curYear);
                        this.txtToDuration.Text = String.Format(dateFormat, agPTI.EDay, agPTI.EMonth, nextYear);
                    }
                    else
                    {

                        this.txtFromDuration.Text = String.Format(dateFormat, agPTI.SDay, agPTI.SMonth, preYear);
                        this.txtToDuration.Text = String.Format(dateFormat, agPTI.EDay, agPTI.EMonth, curYear);
                    }
                }
                else if (Int32.Parse(agPTI.SMonth) < Int32.Parse(agPTI.EMonth))
                {
                    this.txtFromDuration.Text = String.Format(dateFormat, agPTI.SDay, agPTI.SMonth, curYear);
                    this.txtToDuration.Text = String.Format(dateFormat, agPTI.EDay, agPTI.EMonth, curYear);
                }
                if (agPTI.SeasonCode == "W" && DateTime.Now.Month < 5)
                {
                    deadLineDate = String.Format(dateFormat, agPTI.DeadLineDay, agPTI.DeadLineMonth, curYear);
                }
                else
                {
                    deadLineDate = String.Format(dateFormat, agPTI.DeadLineDay, agPTI.DeadLineMonth, nextYear);
                }

                this.dtpDeadlineDate.Value = DateTime.ParseExact(deadLineDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                //Bind Loan Product Type via selected season type and crop type
                string seasonCode = (from b in this.ListForSeasonType
                                     where b.Code.Equals(this.cboSeasonType.SelectedValue.ToString())
                                     orderby b.Code
                                     select b.Code).Single();
                string cropCode = string.Empty;
                if (!String.IsNullOrEmpty(this.CropType))
                {
                    if (this.cboSeasonType.SelectedIndex != -1)
                    {
                        cropCode = (from b in this.ListForCropType
                                    where b.CropCode.Equals(this.cboCropType.SelectedValue.ToString())
                                    orderby b.CropCode
                                    select b.CropCode).Single();
                    }
                }
                string currentYear = (DateTime.Now.Year.ToString()).Substring(2, 2);
                this.txtLoanProductType.Text = "L" + seasonCode.ToUpper() + cropCode.ToUpper() + currentYear;
            }
            else
            {
                this.txtLoanProductType.Text = string.Empty;
                this.txtFromDuration.Text = string.Empty;
                this.txtToDuration.Text = string.Empty;
                this.dtpDeadlineDate.Value = DateTime.Now;
            }
        }

        private void cboCropType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.CropType))
            {
                if (this.cboSeasonType.SelectedIndex != -1)
                {
                    //Bind Loan Product Type via selected season type and crop type
                    string seasonCode = (from b in this.ListForSeasonType
                                         where b.Code.Equals(this.cboSeasonType.SelectedValue.ToString())
                                         orderby b.Code
                                         select b.Code).Single();
                    string cropCode = (from b in this.ListForCropType
                                       where b.CropCode.Equals(this.cboCropType.SelectedValue.ToString())
                                       orderby b.CropCode
                                       select b.CropCode).Single();
                    string currentYear = (DateTime.Now.Year.ToString()).Substring(2, 2);
                    this.txtLoanProductType.Text = "L" + seasonCode.ToUpper() + cropCode.ToUpper() + currentYear;
                }
                else
                {
                    this.cboSeasonType.Focus();
                    this.txtLoanProductType.Text = string.Empty;
                }
            }
        }

        private void txtLoanAmount_Leave(object sender, EventArgs e)
        {
            decimal loanAmt = 0;
            decimal totalAcre = 0;
            Decimal.TryParse(this.txtLoanAmount.Text, out loanAmt);
            Decimal.TryParse(this.txtTotalAcrePerUnit.Text, out totalAcre);
            decimal sanctionLimit = loanAmt * totalAcre;
            this.txtSanctionLimit.Text = sanctionLimit.ToString();
        }

        private void txtTotalAcrePerUnit_Leave(object sender, EventArgs e)
        {
            decimal loanAmt = 0;
            decimal totalAcre = 0;
            Decimal.TryParse(this.txtLoanAmount.Text, out loanAmt);
            Decimal.TryParse(this.txtTotalAcrePerUnit.Text, out totalAcre);
            decimal sanctionLimit = loanAmt * totalAcre;
            this.txtSanctionLimit.Text = sanctionLimit.ToString();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (this.FormName.Contains("Entry"))
            {
                this.isSaveValidate = true;
            }

            if (this.ControlValidation())
            {
                this.controller.Save(CurrentUserEntity.BranchCode);
                this.isSaveValidate = false;
                this.flag = true;
                this.isActive = true;
                //this.grpPersonalInformation.Enabled = false;
                //this.grpAgriLoanTypeIntInfo.Enabled = false;
                //this.grpLSLoanTypeIntInfo.Enabled = false;
                //this.grpCollateralInformation.Enabled = false;
                //this.grpFirmCertificate.Enabled = false;
                //this.grpCusSignature.Enabled = false;
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

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.flag = true;
            this.isCancelExit = true;
            this.isEdit = false;

            this.ClearFormControls();
            this.controller.ClearAllCustomErrors();
            if (this.FormName.Contains("Entry"))
            {
                this.txtLoanNo.ReadOnly = true;
                this.txtLoanNo.Text = string.Empty;
                this.mtxtAccountNo.Focus();
                this.grpPersonalInformation.Enabled = true;
                this.grpFirmCertificate.Enabled = true;
                this.grpCusSignature.Enabled = true;
            }            
            this.GetFormControlSetting();
            this.isSaveValidate = false;
            this.flag = false;            
        }

        private void mtxtGuaranterAccountNo_Leave(object sender, EventArgs e)
        {
            // if xml base error does not exist.
            if (!this.isSaveValidate && !String.IsNullOrEmpty(this.GuarantorAccountNo1))
            {
                try
                {
                    //the guarantor acctno must be for the current branch
                    if (this.GuarantorAccountNo1.Substring(0, 3) == CurrentUserEntity.BranchCode)
                    {
                        Nullable<CXDMD00011> accountType;
                        if (CXCLE00012.Instance.IsValidAccountNo(this.GuarantorAccountNo1, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                        {
                            IList<PFMDTO00001> GuaranteeAccountInfoList = new List<PFMDTO00001>();
                            GuaranteeAccountInfoList = CXClientWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00001>>(x => x.GetCustomerInfomationByAccountNo(this.GuarantorAccountNo1, false));

                            if (GuaranteeAccountInfoList.Count < 1 || CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                            {
                                CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                                this.mtxtGuaranterAccountNo.Focus();
                            }
                            else if (GuaranteeAccountInfoList[0].CurrencyCode != this.CurrencyCode)
                            {
                                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00086, new object[] { this.CurrencyCode }); //Currency of this account should be {0}.
                                this.mtxtGuaranterAccountNo.Focus();
                            }
                            else
                            {
                                //bind method for the guarantor acct info to UI
                                this.BindGuarantee1Info(GuaranteeAccountInfoList);
                            }
                        }
                    }
                    else
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00224, new object[] { this.GuarantorAccountNo1, CurrentUserEntity.BranchCode }); //Invalid Account No {0} for Branch {1}.
                        this.mtxtGuaranterAccountNo.Focus();
                    }
                }
                catch (Exception ex)
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME90043);
                }
            }
        }

        private void mtxtGuaranterAccountNo2_Leave(object sender, EventArgs e)
        {
            // if xml base error does not exist.
            if (!this.isSaveValidate && !String.IsNullOrEmpty(this.GuarantorAccountNo2))
            {
                try
                {
                    //the guarantor acctno must be for the current branch
                    if (this.GuarantorAccountNo2.Substring(0, 3) == CurrentUserEntity.BranchCode)
                    {
                        Nullable<CXDMD00011> accountType;
                        if (CXCLE00012.Instance.IsValidAccountNo(this.GuarantorAccountNo2, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                        {
                            IList<PFMDTO00001> GuaranteeAccountInfoList = new List<PFMDTO00001>();
                            GuaranteeAccountInfoList = CXClientWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00001>>(x => x.GetCustomerInfomationByAccountNo(this.GuarantorAccountNo2, false));

                            if (GuaranteeAccountInfoList.Count < 1 || CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                            {
                                CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                                this.mtxtGuaranterAccountNo2.Focus();
                            }
                            else if (GuaranteeAccountInfoList[0].CurrencyCode != this.CurrencyCode)
                            {
                                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00086, new object[] { this.CurrencyCode }); //Currency of this account should be {0}.
                                this.mtxtGuaranterAccountNo2.Focus();
                            }
                            else
                            {
                                //bind method for the guarantor acct info to UI
                                this.BindGuarantee2Info(GuaranteeAccountInfoList);
                            }
                        }
                    }
                    else
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00224, new object[] { this.GuarantorAccountNo2, CurrentUserEntity.BranchCode }); //Invalid Account No {0} for Branch {1}.
                        this.mtxtGuaranterAccountNo2.Focus();
                    }
                }
                catch (Exception ex)
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME90043);
                }
            }
        }

        private void btnEnquiryGroup_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.GroupNo))
            {
                CXUIScreenTransit.Transit("frmLOMVEW00087", new object[] { this.GroupNo });
            }
        }
        
        private void txtLoanNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!this.FormName.Contains("Entry"))//Condition true when edit and enquiry
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
                            this.controller.BindFarmLoanInfo();
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
        
        private void btnCustSign_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();

                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        this.picCusSignature.Image = new Bitmap(open.FileName);
                    }
                    catch
                    {
                        //  Invalid file format.Please re-choose again.
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00018);
                        return;
                    }
                }
            }
            catch (Exception)
            {
                this.Failure("Failed loading image");
            }
        }

        private void butFirmCertificate_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();

                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        this.picFirmCertificate.Image = new Bitmap(open.FileName);
                    }
                    catch
                    {
                        //  Invalid file format.Please re-choose again.
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00018);
                        return;
                    }
                }
            }
            catch (Exception)
            {
                this.Failure("Failed loading image");
            }
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        #endregion

        private void cboStateCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboStateCode.SelectedIndex != -1)
            {
                if (this.cboStateCode.SelectedValue != null && this.NRCCodeList != null)
                {
                    string StateCode = string.Empty;
                    StateCode = this.cboStateCode.SelectedValue.ToString().Substring(0, this.cboStateCode.SelectedValue.ToString().Length - 1);
                    NRCCodes = (from x in this.NRCCodeList where x.StateCode == StateCode select x).ToList();
                    this.BindTownshipCombobox();
                }
            }
        }
    }
}
