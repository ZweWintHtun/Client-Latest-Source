using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Pfm.Dmd.DTO
{
    [Serializable]
    public class PFMDTO00079 : Supportfields<PFMDTO00079>
    {

        public PFMDTO00079() { }
        public PFMDTO00079(string bInfo,DateTime bSDate,DateTime bEDate,string qtr1,string qtr2
                            ,string qtr3, string qtr4, string m1, string m2, string m3
                            , string m4, string m5, string m6, string m7, string m8
                            , string m9, string m10, string m11, string m12)
        {
            BUDGET_INFO = bInfo;
            BSTART_DATE = bSDate;
            BEND_DATE = bEDate;
            QTR1 = qtr1;
            QTR2 = qtr2;
            QTR3 = qtr3;
            QTR4 = qtr4;
            M1 = m1;
            M2 = m2;
            M3 = m3;
            M4 = m4;
            M5 = m5;
            M6 = m6;
            M7 = m7;
            M8 = m8;
            M9 = m9;
            M10 = m10;
            M11 = m11;
            M12 = m12;
        }
        public PFMDTO00079(string bInfo, DateTime bSDate, DateTime bEDate, string qtr1, string qtr2
                           , string qtr3, string qtr4, string m1, string m2, string m3
                           , string m4, string m5, string m6, string m7, string m8
                           , string m9, string m10, string m11, string m12, string MByDate)
        {
            BUDGET_INFO = bInfo;
            BSTART_DATE = bSDate;
            BEND_DATE = bEDate;
            QTR1 = qtr1;
            QTR2 = qtr2;
            QTR3 = qtr3;
            QTR4 = qtr4;
            M1 = m1;
            M2 = m2;
            M3 = m3;
            M4 = m4;
            M5 = m5;
            M6 = m6;
            M7 = m7;
            M8 = m8;
            M9 = m9;
            M10 = m10;
            M11 = m11;
            M12 = m12;
            MByDate = MByDate;
        }
        public virtual string BUDGET_INFO { get; set; }
        public virtual DateTime BSTART_DATE { get; set; }
        public virtual DateTime BEND_DATE { get; set; }
        public virtual string QTR1 { get; set; }
        public virtual string QTR2 { get; set; }
        public virtual string QTR3 { get; set; }
        public virtual string QTR4 { get; set; }
        public virtual string M1 { get; set; }
        public virtual string M2 { get; set; }
        public virtual string M3 { get; set; }
        public virtual string M4 { get; set; }
        public virtual string M5 { get; set; }
        public virtual string M6 { get; set; }
        public virtual string M7 { get; set; }
        public virtual string M8 { get; set; }
        public virtual string M9 { get; set; }
        public virtual string M10 { get; set; }
        public virtual string M11 { get; set; }
        public virtual string M12 { get; set; }
        public virtual string MByDate { get; set; }
    }
}
