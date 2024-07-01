using System;
using Ace.Windows.Core.DataModel;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    //LinkAccountDTO (LinkAC)
    [Serializable]
    public class PFMDTO00029 : EntityBase<PFMDTO00029>
    {
        public PFMDTO00029() { }
        public PFMDTO00029(int id)
        {
            this.Id = id;
        }

        public PFMDTO00029(decimal currentAccountBalance, decimal savingAccountBalance)
        {
            this.MinimumCurrentAccountBalance = currentAccountBalance;
            this.MinimumSavingAccountBalance = savingAccountBalance;
        }

        public PFMDTO00029(string currentacctno,string savingacctno,decimal currentBalance, decimal minimumBalance)
        {
            this.CurrentAccountNo = currentacctno;
            this.SavingAccountNo = savingacctno;
            this.MinimumCurrentAccountBalance = currentBalance;
            this.MinimumLinkAccountBalance = minimumBalance;
         }

        public PFMDTO00029(string currentacctno, string savingacctno,string callacctno, string firstPriority,string secondPriority,string thirdPriority)
        {
            this.CurrentAccountNo = currentacctno;
            this.SavingAccountNo = savingacctno;
            this.CALACCTNO = callacctno;
            this.FirstPriority = firstPriority;
            this.SecondPriority = secondPriority;
            this.ThirdPriority = thirdPriority;          
        }

        public PFMDTO00029(string savingAccountNo)
        {
            this.CurrentAccountNo = savingAccountNo;
        }
        public PFMDTO00029(string currentAccountNo, int id)
        {
            this.SavingAccountNo = currentAccountNo;
        }

        //Auto Link Schedule Report
        public PFMDTO00029(string eno, string accountSign, string status,DateTime datetime,string debit_AccountNo, decimal debit_CurrentBalance, decimal debit_SavingBalance, decimal debit_Call, decimal debit_Domestic,
                            string credit_AccountNo, decimal credit_CurrentBalance, decimal credit_SavingBalance, decimal credit_Call, decimal credit_Domestic)
        {
            this.ENO = eno;
            this.ACSIGN = accountSign;
            this.STATUS = status;
            this.DRACCTNO = debit_AccountNo;
            this.DR_CURRENT = debit_CurrentBalance;
            this.DR_SAVING = debit_SavingBalance;
            this.DR_CALL = debit_Call;
            this.DR_DOMESTIC = debit_Domestic;
            this.CRACCTNO = credit_AccountNo;
            this.CR_CURRENT = credit_CurrentBalance;
            this.CR_SAVING = credit_SavingBalance;
            this.CR_CALL = credit_Call;
            this.CR_DOMESTIC = credit_Domestic;
        }

        public virtual string CurrentAccountNo { get; set; }
        public virtual string SavingAccountNo { get; set; }
        public virtual string CALACCTNO { get; set; }
        public virtual decimal MinimumCurrentAccountBalance { get; set; }
        public virtual decimal MinimumSavingAccountBalance { get; set; }
       
        public virtual string FirstPriority { get; set; }
        public virtual string SecondPriority { get; set; }
        public virtual string ThirdPriority { get; set; }
        public virtual string CurrencyCode { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual System.Nullable<DateTime> AccessDate { get; set; }
        public virtual System.Nullable<DateTime> CALDATE { get; set; }
        public virtual decimal ExcessAmount { get; set; }
        public virtual decimal MinimumLinkAccountBalance { get; set; }
        public virtual decimal CurrentLinkAccountBalance { get; set; }
        //Source Branch Relation
        public virtual BranchDTO Branch { get; set; }
        //Currency Relation

        #region Auto Link Schedule        
        public virtual string ENO { get; set; }
        public virtual string ACSIGN { get; set; }       
        public virtual string STATUS { get; set; }
        public virtual DateTime DATE_TIME { get; set; }
        public virtual bool IsTransactionDate { get; set; }
        public virtual bool IsSettlementDate { get; set; }
        public virtual bool IsWithReversal { get; set; }

        public virtual string DRACCTNO { get; set; }
        public virtual decimal DR_CURRENT { get; set; }
        public virtual decimal DR_SAVING { get; set; }
        public virtual decimal DR_CALL { get; set; }
        public virtual decimal DR_DOMESTIC { get; set; }

        public virtual string CRACCTNO { get; set; }
        public virtual decimal CR_CURRENT { get; set; }
        public virtual decimal CR_SAVING { get; set; }
        public virtual decimal CR_CALL { get; set; }
        public virtual decimal CR_DOMESTIC { get; set; }
        #endregion
    }
}