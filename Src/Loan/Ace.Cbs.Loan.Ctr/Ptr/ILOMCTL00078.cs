using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Loan.Dmd;
using System.Drawing;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00078 : IPresenter
    {
        ILOMVEW00078 View { get; set; }
        string BranchCode { get; set; }
        string Acsign { get; set; }
        void ClearAllCustomErrors();
        void Save(string BranchCode);
        void BindFarmLoanInfo();
        string SelectUMDespByUMCode(string umCode);
    }

    public interface ILOMVEW00078
    {
        ILOMCTL00078 Controller { get; set; }

        bool isOtherNRC { get; set; }
        string FormName { get; set; }
        bool isSaveValidate { get; set; }
        bool isActive { get; set; }
        int LargestSize { get; set; }

        string LoanNo { get; set; }
        string CurrencyCode { get; set; }
        string AccountNo { get; set; }
        string TypeOfLoan { get; set; }
        string NameInPI { get; set; }
        string FatherNameInPI { get; set; }
        string VillageGroupCode { get; set; }
        string TownshipCode { get; set; }
        string StateCodeForNRC { get; set; }
        string TownshipCodeForNRC { get; set; }
        string NationalityCodeForNRC { get; set; }
        string NRCNo { get; set; }
        string NRC { get; set; }
        string Address { get; set; }

        string FarmName { get; set; }
        string LandNo { get; set; }
        string TypeOfLand { get; set; }
        string SeasonType { get; set; }
        string CropType { get; set; }
        string LoanProductType { get; set; }
        string GroupNo { get; set; }
        decimal Interest { get; set; }
        decimal Penalties { get; set; }
        string StartPeriod { get; set; }
        string EndPeriod { get; set; }
        DateTime WithdrawDate { get; set; }
        DateTime DeadlineDate { get; set; }
        decimal LoanAmtPerAcre { get; set; }
        decimal TotalAcre { get; set; }
        decimal SanctionLimit { get; set; }

        string LSBusinessType { get; set; }
        string LSTypeOfLand { get; set; }
        string LSUMCode { get; set; }
        string LSLicenseNo { get; set; }
        string LSLoanProductType { get; set; }
        string LSOther { get; set; }
        decimal LSInterest { get; set; }
        decimal LSPenalties { get; set; }
        string LSStartPeriod { get; set; }
        string LSEndPeriod { get; set; }
        DateTime LSWithdrawDate { get; set; }
        DateTime LSDeadlineDate { get; set; }
        decimal LSLoanAmtPerAcre { get; set; }
        decimal LSTotalAcre { get; set; }
        decimal LSSanctionLimit { get; set; }

        string YearOfPLBS { get; set; }
        DateTime EstablishmentDate { get; set; }
        decimal YearOfExperience { set; get; }
        decimal Capital { set; get; }
        decimal IncomeTax { get; set; }
        string SalesDeed { get; set; }
        string LandOfAffidavit { get; set; }
        string Land { get; set; }
        string CharacterOfCustomer { get; set; }
        string GoodWill { get; set; }
        decimal ForceSaleValueOfLand { set; get; }
        decimal ForceSaleValueOfBuilding { set; get; }
        string AddressInLB { get; set; }
        string HistoryOfLand_Building { get; set; }
        string BuildingConstructionPermit { get; set; }
        string TypeOfInsurance { get; set; }
        DateTime DateOfInsurance { get; set; }
        DateTime InsuranceExpireDate { get; set; }
        decimal InsuranceAmount { get; set; }

        string GuarantorAccountNo1 { get; set; }
        string GuarantorName1 { get; set; }
        string GuarantorNrc1 { get; set; }
        string GuarantorPhone1 { get; set; }
        string GuarantorAccountNo2 { get; set; }
        string GuarantorName2 { get; set; }
        string GuarantorNrc2 { get; set; }
        string GuarantorPhone2 { get; set; }

        Image FirmCertificate { get; set; }
        Image CusSignature { get; set; }

        LOMDTO00078 GetViewDataForCommon { get; set; }
        LOMDTO00015 GetViewDataForLandAndBuilding { get; set; }
        LOMDTO00079 GetViewDataForGuarantee { get; set; }
        LOMDTO00085 GetViewDataForInterest();
        LOMDTO00300 GetViewDataForPenalFee();

        void ClearFormControls();
        void ClearFormControlsForAgriLoan();
        void ClearFormControlsForLSLoan();
        void GetFormControlSetting();
        void BindCombo(string saleDeed, string landOfAffidavit, string history, string permit);
        void SelectTab(string tabName, bool isEnable);
        void SetVisibleDisableLoanTypePanel(bool isVisible);
        void SetEnableDisableLoanTypePanel(bool isEnable);
        byte[] CreateThumbnail(byte[] PassedImage, int LargestSide);
        void BindCommonFarmLoanToView(LOMDTO00078 loanDto);
    }
}

