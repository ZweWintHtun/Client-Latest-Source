//----------------------------------------------------------------------
// <copyright file="IMNMCTL00001.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>12/02/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00011 : IPresenter
    {

        string Acsign { get; set; }
        ILOMVEW00011 View { get; set; }
        string BranchCode { get; set; }
        string Guarantee_Address { get; set; }
        IList<PFMDTO00072> AccountInfoList { get; set; }
        void ClearAllCustomErrors();
        void Save(string BranchCode);
       // void CheckLoansNo();
        //void txtLoanNo_CustomValidating();

        void BindLoanInfo();
        IList<LOMDTO00001> BindLoansBType();
        DateTime GetSystemDate(string sourceBr);
        DateTime GetLastSettlementDate(string sourceBr);
    }

    public interface ILOMVEW00011
    {
        void SelectTab(string tabName,bool isEnable);
        string TypeOfProduct { get; set; }
        string FormName { get; set; }
        string CurrencyCode { get; set; }
        int Duration { get; set; }
        bool IsLateFee { get; set; }
        bool IsScharge { get; set; }
        DateTime ExpireDate { get; set; }
        string LoanNo { get; set; }
        string AccountNo { get; set; }
        string TypeOfAdvance { get; set; }
        string TypeOfInsurance { get;set ; }
        string TypeOfInsuranceForPledge { get; set; }
        string TypeOfInsuranceForHypo { get; set; }
        DateTime DateOfInsuranceForPledge { get; set; }
        DateTime InsuranceExpireDateForPledge { get; set; }
        decimal InsuranceAmountForPledge { get; set; }

        DateTime DateOfInsuranceForHypo { set; get; }
        DateTime InsuranceExpireDateForHypo { get; set; }
        decimal InsuranceAmountForHypo { get; set; }
       


        string GoodWill { get; set; }
        string CharacterOfCustomer { get; set; }
        string TypeOfBusiness { get;set ; }
        string YearOfPLBS { get; set; }
        string Address { get; set; }
        string SalesDeed { get; set; }
        string Land { get; set; }
        string HistoryOfLand_Building { get; set; }
        string LandOfAffidavit { get; set; }
        decimal ForceSaleValueOfLand { get; set; }
        decimal ForceSaleValueOfBuilding { get; set; }
        string BuildingConstructionPermit { get; set; }

        bool IsUsedBal { get; set; }
        bool IsMiddleBal { get; set; }
        decimal Capital { get; set; }
        decimal IncomeTax { get; set; }
        decimal YearOfExperience { get; set; }
        string AssessorName{ get;set ; }
        string LawerName{ get;set ; }
        DateTime DateOfInsurance{ get;set ; }
        decimal InsuranceAmount{ get;set ; }
        decimal SanctionAmount{ get;set ; }
        string KindOfStock{ get;set ; }
        decimal Value{ get;set ; }
        DateTime ExpiredDate{ get;set ; }
        DateTime EstablishmentDate { get; set; }
        DateTime LandLeaseSDate { get; set; }
        DateTime LandLeaseEDate { get; set; }
        string RemarkForLand { get; set; }

        //string GuarantorAccountNo{ get;set ; }
        string GuarantorCompanyName { get; set; }
        string GuarantorName{ get;set ; }
        string GuarantorNrc{ get;set ; }
        string GuarantorPhone { get; set; }
        int RepaymentDuration { get; set; }
        //int RepaymentPeriod { get; set; }
        //string RepaymentOption { get; set; }
        //string Repay { get; set; }
        string Rate { get; set; }
        string DocFee { get; set; }
        string PrincipleRepaymentOption { get; set; }
        string InterestRepaymentOption { get; set; }
        int GracePeriod { get; set; }
        string RelatedGLACode { get; set; }

        decimal UsedRateForUsedBal { get;set; }
        decimal UnUsedRateForUsedBal { get; set; }
        decimal UsedUnderHalfRate { get; set; }
        decimal UsedOverHalfRate { get; set; }
        decimal MiddleUnUsedRate { get; set; }

        bool isSaveValidate { get; set; }
        int registerType { get; set; }
        bool getServiceCharges { get; set; }
        bool isActive { get; set; }
        ILOMCTL00011 Controller { get; set; }
        ///void CleargdvLoanInterest(IList<LOMDTO00021> loanInfoList); //update2017
        void ClearFormControls();
        void GetFormControlSetting();
        void Pledge(IList<LOMDTO00016> pledgeList);
        void GoldandJewellery(TLMDTO00018 loanDto);

      //ssssssssss  void BindLoanInterestInfo(IList<LOMDTO00021> loanInfoList); //update2017
        void BindPeanlFee(IList<LOMDTO00012> penalList);
        void BindAccountInfo(IList<PFMDTO00072> accountInfoList);

        LOMDTO00015 GetViewDataForLandAndBuilding { get; set; }
        IList<LOMDTO00016> GetViewDataForPledge();
        LOMDTO00017 GetViewDataForHypothecation { get; set; }
        PFMDTO00039 GetViewDataForGuarantee { get; set; }
        TLMDTO00018 GetViewDataForCommon { get; set; }

        //IList<LOMDTO00021> GetInterestList(); //update2017
        IList<LOMDTO00012> GetPenalFeeList();
        IList<LOMDTO00018> GetViewDataForGoldAndJewelleryKind();
        IList<LOMDTO00018> GetViewDataForGoldAndJewelleryType();

        void BindCombo(string saleDeed, string landOfAffidavit,string history ,string pERMIT);

        LOMDTO00021 GetInterestList();

        
    }
}
