using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd
{
    [Serializable]
    public class MNMDTO00010 : Supportfields<MNMDTO00010>
    {
        public MNMDTO00010()
        { }

        public MNMDTO00010(decimal hobal, decimal cbal)
        {
            this.HOBAL = hobal;
            this.CBAL = cbal;
        }

        public MNMDTO00010(decimal Amount)
        {
            this.AMOUNT = Amount;
        }

        public MNMDTO00010(string acode, string acname, decimal month)
        {
            this.ACODE = acode;
            this.ACNAME = acname;
            this.COAamount = month;
        }

        public MNMDTO00010(string cur, string sourcebr, DateTime selectedDate)
        {
            this.CUR = cur;
            this.Sourcebranch = sourcebr;
            this.SelectedDate = selectedDate;
        }

        public MNMDTO00010(string acode, string acname, string actype, decimal month)
        {
            this.ACODE = acode;
            this.ACNAME = acname;
            this.ACTYPE = actype;
            this.COAamount = month;

        }


        public MNMDTO00010(string acode, string dcode, string cbmacode, string acname, string actype, decimal amount)
        {
            this.ACODE = acode;
            this.DCODE = dcode;
            this.CBMACODE = cbmacode;
            this.ACNAME = acname;
            this.ACTYPE = actype;
            this.COAamount = amount;
        }

        public MNMDTO00010(string acode, decimal m1, decimal m2, decimal m3, decimal m4, decimal m5, decimal m6, decimal m7, decimal m8, decimal m9, decimal m10, decimal m11, decimal m12)
        {
            this.ACODE = acode;
            this.M1 = m1;

            this.M2 = m2;
            this.M3 = m3;

            this.M4 = m4;
            this.M5 = m5;

            this.M6 = m6;
            this.M7 = m7;

            this.M8 = m8;
            this.M9 = m9;

            this.M10 = m10;
            this.M11 = m11;

            this.M12 = m12;
        }

        //Sub Ledger(Domestic)
        public MNMDTO00010(string acode, decimal m1, decimal m2, decimal m3, decimal m4, decimal m5, decimal m6, decimal m7, decimal m8, decimal m9, decimal m10, decimal m11, decimal m12, decimal m13,
                            decimal msrc1, decimal msrc2, decimal msrc3, decimal msrc4, decimal msrc5, decimal msrc6, decimal msrc7, decimal msrc8, decimal msrc9, decimal msrc10, decimal msrc11, decimal msrc12, decimal msrc13, decimal hobal, decimal cbal)
        {
            this.ACODE = acode;
            this.M1 = m1;
            this.M2 = m2;
            this.M3 = m3;
            this.M4 = m4;
            this.M5 = m5;
            this.M6 = m6;
            this.M7 = m7;
            this.M8 = m8;
            this.M9 = m9;
            this.M10 = m10;
            this.M11 = m11;
            this.M12 = m12;
            this.M13 = m13;
            this.MSRC1 = msrc1;
            this.MSRC2 = msrc2;
            this.MSRC3 = msrc3;
            this.MSRC4 = msrc4;
            this.MSRC5 = msrc5;
            this.MSRC6 = msrc6;
            this.MSRC7 = msrc7;
            this.MSRC8 = msrc8;
            this.MSRC9 = msrc9;
            this.MSRC10 = msrc10;
            this.MSRC11 = msrc11;
            this.MSRC12 = msrc12;
            this.MSRC13 = msrc13;
            this.HOBAL = hobal;
            this.CBAL = cbal;
        }

        //Enquiry On Ledger(GLMVEW00008)
        public MNMDTO00010(string acode, string acname, decimal m1, decimal m2, decimal m3, decimal m4, decimal m5, decimal m6, decimal m7, decimal m8, decimal m9, decimal m10, decimal m11, decimal m12, decimal m13)
        {
            this.ACODE = acode;
            this.ACNAME = acname;
            this.M1 = m1;
            this.M2 = m2;
            this.M3 = m3;
            this.M4 = m4;
            this.M5 = m5;
            this.M6 = m6;
            this.M7 = m7;
            this.M8 = m8;
            this.M9 = m9;
            this.M10 = m10;
            this.M11 = m11;
            this.M12 = m12;
            this.M13 = m13;
        }

        //Opening Balance Entry (GLMVEW00002)
        public MNMDTO00010(string acode, string dcode, string acname, string actype, string cur, decimal obal, decimal hobal)
        {
            this.ACODE = acode;
            this.DCODE = dcode;
            this.ACNAME = acname;
            this.ACTYPE = actype;
            this.CUR = cur;
            this.OBAL = obal;
            this.HOBAL = hobal;
        }

        public MNMDTO00010(string acode, string dcode, string acname, string cur, decimal? bf1, decimal? bf2, decimal? bf3, decimal? bf4, decimal? bf5, decimal? bf6,
                            decimal? bf7, decimal? bf8, decimal? bf9, decimal? bf10, decimal? bf11, decimal? bf12)
        {
            this.ACODE = acode;
            this.DCODE = dcode;
            this.ACNAME = acname;
            this.CUR = cur;
            this.BF1 = bf1;
            this.BF2 = bf2;
            this.BF3 = bf3;
            this.BF4 = bf4;
            this.BF5 = bf5;
            this.BF6 = bf6;
            this.BF7 = bf7;
            this.BF8 = bf8;
            this.BF9 = bf9;
            this.BF10 = bf10;
            this.BF11 = bf11;
            this.BF12 = bf12;
        }

        //Yearly Budget Entry (GLMVEW00003)
        public MNMDTO00010(string acode, string dcode, string cur, decimal bf, string acname)
        {
            this.ACODE = acode;
            this.DCODE = dcode;
            this.CUR = cur;
            this.BF = bf;
            this.ACNAME = acname;
        }

        //Monthly Posting Entry (GLMVEW00023,TCMVIW000009)
        //public MNMDTO00010(string acode, string cur, decimal bf, decimal obal, decimal hobal, decimal cbal, decimal m1, decimal m2, decimal m3, decimal m4, decimal m5, decimal m6, decimal m7, decimal m8, decimal m9, decimal m10, decimal m11, decimal m12, decimal m13,
        //                   decimal msrc1, decimal msrc2, decimal msrc3, decimal msrc4, decimal msrc5, decimal msrc6, decimal msrc7, decimal msrc8, decimal msrc9, decimal msrc10, decimal msrc11, decimal msrc12, decimal msrc13, string budget, string subitem,
        //                 decimal openingBal, decimal closingBal, decimal creditAmt, decimal debitAmt, string dCode, bool active, byte[] ts, int createduserid, DateTime createddate, int updateduserid, DateTime updateddate)
        //{
        //    this.ACODE = acode;
        //    this.CUR = cur;
        //    this.BF = bf;
        //    this.OBAL = obal;
        //    this.HOBAL = hobal;
        //    this.CBAL = cbal;
        //    this.M1 = m1;
        //    this.M2 = m2;
        //    this.M3 = m3;
        //    this.M4 = m4;
        //    this.M5 = m5;
        //    this.M6 = m6;
        //    this.M7 = m7;
        //    this.M8 = m8;
        //    this.M9 = m9;
        //    this.M10 = m10;
        //    this.M11 = m11;
        //    this.M12 = m12;
        //    this.M13 = m13;
        //    this.MSRC1 = msrc1;
        //    this.MSRC2 = msrc2;
        //    this.MSRC3 = msrc3;
        //    this.MSRC4 = msrc4;
        //    this.MSRC5 = msrc5;
        //    this.MSRC6 = msrc6;
        //    this.MSRC7 = msrc7;
        //    this.MSRC8 = msrc8;
        //    this.MSRC9 = msrc9;
        //    this.MSRC10 = msrc10;
        //    this.MSRC11 = msrc11;
        //    this.MSRC12 = msrc12;
        //    this.MSRC13 = msrc13;
        //    this.BUDGET = budget;
        //    this.SubItem = subitem;
        //    this.OpeningBalance = openingBal;
        //    this.ClosingBalance = closingBal;
        //    this.CreditAmount = creditAmt;
        //    this.DebitAmount = debitAmt;
        //    this.DCODE = dCode;
        //    this.Active = active;
        //    this.TS = ts;
        //    this.CreatedUserId = createduserid;
        //    this.CreatedDate = createddate;
        //    this.UpdatedUserId = updateduserid;
        //    this.UpdatedDate = updateddate;
        //}

        public virtual string ACODE { get; set; }
        public virtual string CBMACODE { get; set; }
        public virtual string ACNAME { get; set; }
        public virtual string ACTYPE { get; set; }
        public virtual string DCODE { get; set; }
        public virtual string CUR { get; set; }
        public virtual System.Nullable<decimal> BF { get; set; }
        public virtual System.Nullable<decimal> OBAL { get; set; }
        public virtual System.Nullable<decimal> HOBAL { get; set; }
        public virtual System.Nullable<decimal> CBAL { get; set; }
        public virtual System.Nullable<decimal> M1 { get; set; }
        public virtual System.Nullable<decimal> M2 { get; set; }
        public virtual System.Nullable<decimal> M3 { get; set; }
        public virtual System.Nullable<decimal> M4 { get; set; }
        public virtual System.Nullable<decimal> M5 { get; set; }
        public virtual System.Nullable<decimal> M6 { get; set; }
        public virtual System.Nullable<decimal> M7 { get; set; }
        public virtual System.Nullable<decimal> M8 { get; set; }
        public virtual System.Nullable<decimal> M9 { get; set; }
        public virtual System.Nullable<decimal> M10 { get; set; }
        public virtual System.Nullable<decimal> M11 { get; set; }
        public virtual System.Nullable<decimal> M12 { get; set; }
        public virtual System.Nullable<decimal> M13 { get; set; }
        public virtual System.Nullable<decimal> MSRC1 { get; set; }
        public virtual System.Nullable<decimal> MSRC2 { get; set; }
        public virtual System.Nullable<decimal> MSRC3 { get; set; }
        public virtual System.Nullable<decimal> MSRC4 { get; set; }
        public virtual System.Nullable<decimal> MSRC5 { get; set; }
        public virtual System.Nullable<decimal> MSRC6 { get; set; }
        public virtual System.Nullable<decimal> MSRC7 { get; set; }
        public virtual System.Nullable<decimal> MSRC8 { get; set; }
        public virtual System.Nullable<decimal> MSRC9 { get; set; }
        public virtual System.Nullable<decimal> MSRC10 { get; set; }
        public virtual System.Nullable<decimal> MSRC11 { get; set; }
        public virtual System.Nullable<decimal> MSRC12 { get; set; }
        public virtual System.Nullable<decimal> MSRC13 { get; set; }
        public virtual System.Nullable<decimal> BF1 { get; set; }
        public virtual System.Nullable<decimal> BF2 { get; set; }
        public virtual System.Nullable<decimal> BF3 { get; set; }
        public virtual System.Nullable<decimal> BF4 { get; set; }
        public virtual System.Nullable<decimal> BF5 { get; set; }
        public virtual System.Nullable<decimal> BF6 { get; set; }
        public virtual System.Nullable<decimal> BF7 { get; set; }
        public virtual System.Nullable<decimal> BF8 { get; set; }
        public virtual System.Nullable<decimal> BF9 { get; set; }
        public virtual System.Nullable<decimal> BF10 { get; set; }
        public virtual System.Nullable<decimal> BF11 { get; set; }
        public virtual System.Nullable<decimal> BF12 { get; set; }
        public virtual System.Nullable<decimal> BF13 { get; set; }
        public virtual System.Nullable<decimal> BFSRC1 { get; set; }
        public virtual System.Nullable<decimal> BFSRC2 { get; set; }
        public virtual System.Nullable<decimal> BFSRC3 { get; set; }
        public virtual System.Nullable<decimal> BFSRC4 { get; set; }
        public virtual System.Nullable<decimal> BFSRC5 { get; set; }
        public virtual System.Nullable<decimal> BFSRC6 { get; set; }
        public virtual System.Nullable<decimal> BFSRC7 { get; set; }
        public virtual System.Nullable<decimal> BFSRC8 { get; set; }
        public virtual System.Nullable<decimal> BFSRC9 { get; set; }
        public virtual System.Nullable<decimal> BFSRC10 { get; set; }
        public virtual System.Nullable<decimal> BFSRC11 { get; set; }
        public virtual System.Nullable<decimal> BFSRC12 { get; set; }
        public virtual System.Nullable<decimal> BFSRC13 { get; set; }
        public virtual System.Nullable<decimal> MREV1 { get; set; }
        public virtual System.Nullable<decimal> MREV2 { get; set; }
        public virtual System.Nullable<decimal> MREV3 { get; set; }
        public virtual System.Nullable<decimal> MREV4 { get; set; }
        public virtual System.Nullable<decimal> MREV5 { get; set; }
        public virtual System.Nullable<decimal> MREV6 { get; set; }
        public virtual System.Nullable<decimal> MREV7 { get; set; }
        public virtual System.Nullable<decimal> MREV8 { get; set; }
        public virtual System.Nullable<decimal> MREV9 { get; set; }
        public virtual System.Nullable<decimal> MREV10 { get; set; }
        public virtual System.Nullable<decimal> MREV11 { get; set; }
        public virtual System.Nullable<decimal> MREV12 { get; set; }
        public virtual System.Nullable<decimal> MREV13 { get; set; }
        public virtual System.Nullable<decimal> LYMSRC1 { get; set; }
        public virtual System.Nullable<decimal> LYMSRC2 { get; set; }
        public virtual System.Nullable<decimal> LYMSRC3 { get; set; }
        public virtual System.Nullable<decimal> LYMSRC4 { get; set; }
        public virtual System.Nullable<decimal> LYMSRC5 { get; set; }
        public virtual System.Nullable<decimal> LYMSRC6 { get; set; }
        public virtual System.Nullable<decimal> LYMSRC7 { get; set; }
        public virtual System.Nullable<decimal> LYMSRC8 { get; set; }
        public virtual System.Nullable<decimal> LYMSRC9 { get; set; }
        public virtual System.Nullable<decimal> LYMSRC10 { get; set; }
        public virtual System.Nullable<decimal> LYMSRC11 { get; set; }
        public virtual System.Nullable<decimal> LYMSRC12 { get; set; }
        public virtual System.Nullable<decimal> LYMSRC13 { get; set; }
        public virtual System.Nullable<decimal> SCCRBAL { get; set; }
        public virtual System.Nullable<decimal> ACCRUED { get; set; }
        public virtual string BUDGET { get; set; }
        public virtual string Month { get; set; }
        public virtual string UID { get; set; }
        public virtual string Sourcebranch { get; set; }
        public virtual decimal AMOUNT { get; set; }
        public virtual decimal CCOAAmount { get; set; }
        public virtual decimal COAamount { get; set; }
        public virtual decimal DebitAmount { get; set; }
        public virtual decimal CreditAmount { get; set; }
        public virtual decimal DebitTotal { get; set; }
        public virtual decimal CreditTotal { get; set; }
        public virtual bool IsCheck { get; set; }
        public virtual bool IsHomeCurrency { get; set; }

        public virtual string SubItem { get; set; }
        public virtual decimal OpeningBalance { get; set; }
        public virtual decimal ClosingBalance { get; set; }
        public virtual Nullable<decimal> Balance { get; set; }
        public virtual Nullable<decimal> TotalBal { get; set; }
        public virtual DateTime SelectedDate { get; set; }//Added by HWKO (31-Aug-2017)
    }
}
