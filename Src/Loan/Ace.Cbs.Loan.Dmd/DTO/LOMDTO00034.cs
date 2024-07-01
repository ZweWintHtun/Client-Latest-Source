using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMDTO00034 : Supportfields<LOMDTO00034>
    {
        public LOMDTO00034() { }
        public LOMDTO00034(DateTime startDate, DateTime endDate, string sourceBranch, string currency)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.SourceBr = sourceBranch;
            this.CUR = currency;
        }
        public LOMDTO00034(int id,string Lno, string acctno, decimal samt, string cur, DateTime Sdate, decimal FSAmt, DateTime EDate, string name, string sourcebr, decimal cbal,string aType)
        {
            this.Id = id;
            this.LNO = Lno;
            this.ACCTNO = acctno;
            this.SAMT = samt;
            this.CUR = cur;
            this.SDATE = Sdate;
            this.FIRSTSAMT = FSAmt;
            this.EXPIREDATE = EDate;
            this.NAME = name;
            this.SourceBr = sourcebr;
            this.CBAL = cbal;
            this.ATYPE = aType;
        }
         public LOMDTO00034(int id,string lno,string acctNo, string name, DateTime expireDate, decimal sAmt, decimal cBal)
        {
            this.Id = id;
            this.LNO = lno;
            this.ACCTNO = acctNo;
            this.NAME = name;
            this.EXPIREDATE = expireDate;
            this.SAMT = sAmt;
            this.CBAL = cBal;
        }

        //public LOMDTO00034(string Lno, string acctno, decimal samt, string cur, DateTime Sdate, decimal FSAmt, DateTime EDate)
        //{
            
        //    this.LNO = Lno;
        //    this.ACCTNO = acctno;
        //    this.SAMT = samt;
        //    this.CUR = cur;
        //    this.SDATE = Sdate;
        //    this.FIRSTSAMT = FSAmt;
        //    this.EXPIREDATE = EDate;
           
        //}

        //public LOMDTO00034(int id, string lno, string acctNo, string name, DateTime expireDate, decimal sAmt, decimal cBal)
        //{
        //    this.Id = id;
        //    this.LNO = lno;
        //    this.ACCTNO = acctNo;
        //    this.NAME = name;
        //    this.EXPIREDATE = expireDate;
        //    this.SAMT = sAmt;
        //    this.CBAL = cBal;
        //}
        //public LOMDTO00034(string loanType, DateTime startDate, DateTime endDate, string sourceBranch, string currency);

        public virtual Int32 Id { get; set; }
        public virtual string LNO { get; set; }
        public virtual string ACCTNO { get; set; }
        public virtual decimal SAMT { get; set; }
        public virtual string CUR { get; set; }
        public virtual DateTime SDATE { get; set; }
        public virtual decimal FIRSTSAMT { get; set; }
        public virtual DateTime EXPIREDATE { get; set; }
        public virtual bool LEGALCASE { get; set; }
        public virtual bool NPLCASE { get; set; }
        public virtual string NAME { get; set; }
        public virtual decimal CBAL { get; set; }
        public virtual string ATYPE { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string LOANS_TYPE { get; set; }
        public virtual decimal FORCE_SALE_VALUE { get; set; }       

        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual string TransactionStatus { get; set; }
    }
}

