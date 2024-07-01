//----------------------------------------------------------------------
// <copyright file="TCMORM00009.cs" Name="CashClosing" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Ye Mann Aung</CreatedUser>
// <CreatedDate>23/12/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Tcm.Dmd
{
    /// <summary>
    /// LAOF ORM
    /// </summary>

    [Serializable]
    public class TCMORM00010 : EntityBase<TCMORM00001>
    {
        public virtual string AccountNo { get; set; }
        public virtual string Name { get; set; }
        public virtual string AccountSign { get; set; }
        public virtual string Address { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Fax { get; set; }
        public virtual string Email { get; set; }
        public virtual string NRC { get; set; }
        public virtual System.Nullable<DateTime> OpenDate { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string UniqueId { get; set; }
        public virtual string SourceBranch { get; set; }
        public virtual string Currency { get; set; }
        public virtual string JoinType { get; set; }
        public virtual string CustomerId { get; set; }
        public virtual string StateCode { get; set; }
        public virtual string CityCode { get; set; }
        public virtual string TownshipCode { get; set; }
        public virtual string OccupationCode { get; set; }
        public virtual System.Nullable<DateTime> CloseDate { get; set; }
        public virtual System.Nullable<int> NumberPersonSign { get; set; }
        public virtual System.Nullable<int> SerialOfCustomer { get; set; }
    }
}
