//----------------------------------------------------------------------
// <copyright file="TLMVIW00009.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-09-11</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Tel.Dmd
{
    /// <summary>
    /// VW_BAL
    /// </summary>
       [Serializable]
   public class TLMVIW00009:EntityBase<TLMVIW00009>
    {
           public TLMVIW00009() { }

          
           public TLMVIW00009(decimal m6,decimal m1,decimal m2,decimal m3,decimal m4,decimal m5)
           {
               this.M1 = m1;
               this.M2 = m2;
               this.M3 = m3;
               this.M4 = m4;
               this.M5 = m5;
               this.M6 = m6;
           }
         

           public virtual string AccountNo { get; set; }
           public virtual string Currency { get; set; }
           public virtual System.Nullable<DateTime> DateTime { get; set; }
           public virtual string UserNo { get; set; }
           public virtual System.Nullable<DateTime> CloseDate { get; set; }
           public virtual string Budget { get; set; }
           public virtual string ACSign { get; set; }
           public virtual System.Nullable<decimal> M1 { get; set; }
           public virtual System.Nullable<decimal> TCount1 { get; set; }
           public virtual System.Nullable<decimal> M2 { get; set; }
           public virtual System.Nullable<decimal> TCount2 { get; set; }
           public virtual System.Nullable<decimal> M3 { get; set; }
           public virtual System.Nullable<decimal> TCount3 { get; set; }
           public virtual System.Nullable<decimal> M4 { get; set; }
           public virtual System.Nullable<decimal> TCount4 { get; set; }
           public virtual System.Nullable<decimal> M5 { get; set; }
           public virtual System.Nullable<decimal> TCount5 { get; set; }
           public virtual System.Nullable<decimal> M6 { get; set; }
           public virtual System.Nullable<decimal> TCount6 { get; set; }
           public virtual System.Nullable<decimal> M7 { get; set; }
           public virtual System.Nullable<decimal> TCount7 { get; set; }
           public virtual System.Nullable<decimal> M8 { get; set; }
           public virtual System.Nullable<decimal> TCount8 { get; set; }
           public virtual System.Nullable<decimal> M9 { get; set; }
           public virtual System.Nullable<decimal> TCount9 { get; set; }
           public virtual System.Nullable<decimal> M10 { get; set; }
           public virtual System.Nullable<decimal> TCount10 { get; set; }
           public virtual System.Nullable<decimal> M11 { get; set; }
           public virtual System.Nullable<decimal> TCount11 { get; set; }
           public virtual System.Nullable<decimal> M12 { get; set; }
           public virtual System.Nullable<decimal> TCount12 { get; set; }
          
           public virtual string SourceBr { get; set; }
    }
}
