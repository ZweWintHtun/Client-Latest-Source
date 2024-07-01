using System;
using Ace.Windows.Core.DataModel;
namespace Ace.Cbs.Pfm.Dmd
{
    [Serializable]
    public class PFMDTO00041 : Supportfields<PFMDTO00041>
    {
        /// <summary>
        /// Setup Entity
        /// </summary>
        public PFMDTO00041() { }

        public PFMDTO00041(decimal currentMinimumBalance,decimal savingMinimumBalance) 
        {
            this.CurrentMinimumBalance = currentMinimumBalance;
            this.SavingMinimumBalance = savingMinimumBalance;
        }

        //Id,Fixed3,Fixed6,Fixed9,Fixed12,Fixed24,Fixed36,Saving,Tax,OD,Loans,LetterofGuarantee,CurrentIndividual,CurrentJoint,
        //CurrentCompany,CurrentPartner,CurrentAssociation,CurSole,SavingIndividual,SavingJoint,SavingMinor,SavingOrganization,
        //FixedCompany,FixedIndividual,FixedJoint,FixedMinor,DenoStatus,CCloseCha,SCloseCha,CurMonth,SavMonth,CurrentMinimumBalance,
        //SavingMinimumBalance,CalMinBal,SDInDi,SDJoint,SDOrgain,SDMinBal,CurrencyCode,SourceBranchCode,CashAC,Active,CreatedDate,
        //CreatedUserId,UpdatedDate,UpdatedUserId,TS
        public PFMDTO00041(int Id, decimal Fixed3, decimal Fixed6, decimal Fixed9, decimal Fixed12, decimal Fixed24, decimal Fixed36,
            decimal Saving, decimal Tax, decimal OD, decimal Loans, string LetterofGuarantee, string CurrentIndividual, string CurrentJoint,
            string CurrentCompany, string CurrentPartner, string CurrentAssociation, string CurSole, string SavingIndividual, string SavingJoint,
            string SavingMinor, string SavingOrganization, string FixedCompany, string FixedIndividual, string FixedJoint,string FixedMinor,
            string DenoStatus, decimal CCloseCha, decimal SCloseCha, decimal CurMonth, decimal SavMonth, decimal CurrentMinimumBalance,
            decimal SavingMinimumBalance, decimal CalMinBal, string SDInDi, string SDJoint, string SDOrgain, decimal SDMinBal, string CurrencyCode,
            string SourceBranchCode, string CashAC, bool active, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId, byte[] tS)
        {
            this.Id = Id;
            this.Fixed3 = Fixed3;
            this.Fixed6 = this.Fixed6;
            this.Fixed12 = Fixed12;
            this.Fixed24 = Fixed24;
            this.Fixed36 = Fixed36;
            this.Saving = Saving;
            this.Tax = Tax;
            this.OD = OD;
            this.Loans = this.Loans;
            this.LetterofGuarantee = LetterofGuarantee;
            this.CurrentIndividual = CurrentIndividual;
            this.CurrentJoint = CurrentJoint;
            this.CurrentCompany = CurrentCompany;
            this.CurrentPartner = CurrentPartner;
            this.CurrentAssociation = CurrentAssociation;
            this.CurSole = CurSole;
            this.SavingIndividual = SavingIndividual;
            this.SavingJoint = SavingJoint;
            this.SavingMinor = SavingMinor;
            this.SavingOrganization = SavingOrganization;
            this.FixedCompany = FixedCompany;
            this.FixedIndividual = FixedIndividual;
            this.FixedJoint = FixedJoint;
            this.FixedMinor = FixedMinor;
            this.DenoStatus = DenoStatus;
            this.CCloseCha = CCloseCha;
            this.SCloseCha = SCloseCha;
            this.CurMonth = CurMonth; 
            this.SavMonth = SavMonth;
            this.CurrentMinimumBalance = CurrentMinimumBalance;
            this.SavingMinimumBalance = SavingMinimumBalance;
            this.CalMinBal = CalMinBal; 
            this.SDInDi = SDInDi;
            this.SDJoint = SDJoint;
            this.SDOrgain = SDOrgain; 
            this.SDMinBal = SDMinBal;
            this.CurrencyCode = CurrencyCode;
            this.SourceBranchCode = SourceBranchCode; 
            this.CashAC = CashAC;
            this.Active = active;
            this.CreatedUserId = createdUserId;
            this.CreatedDate = createdDate;
            this.TS = tS;
            this.UpdatedUserId = updatedUserId;
            this.UpdatedDate = updatedDate;
        }

        public virtual int Id { get; set; }
        public virtual decimal Fixed3 { get; set; }
        public virtual decimal Fixed6 { get; set; }
        public virtual decimal Fixed9 { get; set; }
        public virtual decimal Fixed12 { get; set; }
        public virtual decimal Fixed24 { get; set; }
        public virtual decimal Fixed36 { get; set; }
        public virtual decimal Saving { get; set; }
        public virtual decimal Tax { get; set; }
        public virtual decimal OD { get; set; }
        public virtual decimal Loans { get; set; }
        public virtual string LetterofGuarantee { get; set; }
        public virtual string CurrentIndividual { get; set; }
        public virtual string CurrentJoint { get; set; }
        public virtual string CurrentCompany { get; set; }
        public virtual string CurrentPartner { get; set; }
        public virtual string CurrentAssociation { get; set; }
        public virtual string CurSole { get; set; }
        public virtual string SavingIndividual { get; set; }
        public virtual string SavingJoint { get; set; }
        public virtual string SavingMinor { get; set; }
        public virtual string SavingOrganization { get; set; }
        public virtual string FixedCompany { get; set; }
        public virtual string FixedIndividual { get; set; }
        public virtual string FixedJoint { get; set; }
        public virtual string FixedMinor { get; set; }
        public virtual string DenoStatus { get; set; }
        public virtual decimal CCloseCha { get; set; }
        public virtual decimal SCloseCha { get; set; }
        public virtual decimal CurMonth { get; set; }
        public virtual decimal SavMonth { get; set; }
        public virtual decimal CurrentMinimumBalance { get; set; }
        public virtual decimal SavingMinimumBalance { get; set; }
        public virtual decimal CalMinBal { get; set; }
        public virtual string SDInDi { get; set; }
        public virtual string SDJoint { get; set; }
        public virtual string SDOrgain { get; set; }
        public virtual decimal SDMinBal { get; set; }
        public virtual string CashAC { get; set; }
        public virtual string CurrencyCode { get; set; }
        public virtual string SourceBranchCode { get; set; }
    }
}