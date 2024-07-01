//----------------------------------------------------------------------
// <copyright file="TLMORM00027.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San </CreatedUser>
// <CreatedDate></CreatedDate>
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
    /// ServerLog DTO Entity
    /// </summary>
    [Serializable]
    public class TLMDTO00027 : EntityBase<TLMDTO00027>
    {
        public TLMDTO00027() { }

        public TLMDTO00027(int id, string bRANCHNO, string sERVERNAME, string dBNAME, string iPADDRESS, string uSERNAME, string pASSWORD, string iSPNAME, string uID, string vERSION)
        {
            this.Id = id;
            this.BRANCHNO = bRANCHNO;
            this.SERVERNAME = sERVERNAME;
            this.DBNAME = dBNAME;
            this.IPADDRESS = iPADDRESS;
            this.USERNAME = uSERNAME;
            this.PASSWORD = pASSWORD;
            this.ISPNAME = iSPNAME;
            this.UID = uID;
            //this.IBDIPADDRESS = iBDIPADDRESS;
            this.VERSION = vERSION;
        }

//public TLMDTO00027(int id, string bRANCHNO, string sERVERNAME, string dBNAME, string iPADDRESS, string uSERNAME, string pASSWORD, string iSPNAME, string uID,string iBDIPADDRESS, string vERSION, bool active, byte[] tS, int createdUserId, DateTime createdDate, System.Nullable<int> updatedUserId, System.Nullable<DateTime> updatedDate)
//        {
//            this.Id = id;
//            this.BRANCHNO = bRANCHNO;
//            this.SERVERNAME = sERVERNAME;
//            this.DBNAME = dBNAME;
//            this.IPADDRESS = iPADDRESS;
//            this.USERNAME = uSERNAME;
//            this.PASSWORD = pASSWORD;
//            this.ISPNAME = iSPNAME;
//            this.UID = uID;
//            this.IBDIPADDRESS = iBDIPADDRESS;
//            this.VERSION = vERSION;
//            this.Active = active;
//            this.TS = tS;
//            this.CreatedUserId = createdUserId;
//            this.CreatedDate = createdDate;
//            this.UpdatedUserId = updatedUserId;
//            this.UpdatedDate = updatedDate;
//        }
        public TLMDTO00027(int id, string bRANCHNO, string sERVERNAME, string dBNAME, string iPADDRESS, string uSERNAME, string pASSWORD, string iSPNAME, string uID, string vERSION, bool active, byte[] tS, int createdUserId, DateTime createdDate, System.Nullable<int> updatedUserId, System.Nullable<DateTime> updatedDate)
        {
            this.Id = id;
            this.BRANCHNO = bRANCHNO;
            this.SERVERNAME = sERVERNAME;
            this.DBNAME = dBNAME;
            this.IPADDRESS = iPADDRESS;
            this.USERNAME = uSERNAME;
            this.PASSWORD = pASSWORD;
            this.ISPNAME = iSPNAME;
            this.UID = uID;
            //this.IBDIPADDRESS = iBDIPADDRESS;
            this.VERSION = vERSION;
            this.Active = active;
            this.TS = tS;
            this.CreatedUserId = createdUserId;
            this.CreatedDate = createdDate;
            this.UpdatedUserId = updatedUserId;
            this.UpdatedDate = updatedDate;
        }

        public virtual int Id { get; set; }
        public virtual string BRANCHNO { get; set; }
        public virtual string SERVERNAME { get; set; }
        public virtual string DBNAME { get; set; }
        public virtual string IPADDRESS { get; set; }
        public virtual string USERNAME { get; set; }
        public virtual string PASSWORD { get; set; }
        public virtual string ISPNAME { get; set; }
        public virtual string UID { get; set; }
        public virtual string IBDIPADDRESS { get; set; }
        public virtual string VERSION { get; set; }
        public virtual bool NewSystem { get; set; }
        public virtual bool OldSystem { get; set; }
        public virtual bool Vsat { get; set; }
        public virtual bool IPStar { get; set; }
        public virtual bool IsCheck { get; set; }
    }
}
