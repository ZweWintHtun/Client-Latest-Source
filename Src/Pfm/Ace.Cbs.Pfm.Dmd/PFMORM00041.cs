using System;
using Ace.Windows.Core.DataModel;
namespace Ace.Cbs.Pfm.Dmd
{
    [Serializable]
    public class PFMORM00041 : Supportfields<PFMORM00041>
    {
        /// <summary>
        /// Setup Entity
        /// </summary>
        public PFMORM00041() { }
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