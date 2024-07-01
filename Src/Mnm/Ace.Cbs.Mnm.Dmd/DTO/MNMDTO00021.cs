//----------------------------------------------------------------------
// <copyright file="MNMDTO00021.cs" Name="INTLF" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Banking</CreatedUser>
// <CreatedDate>11/15/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd
{
    [Serializable]
    public class MNMDTO00021 : Supportfields<MNMDTO00021>
    {
        public MNMDTO00021() { }

        public MNMDTO00021(string eNO, string aCCTNO, decimal aMOUNT, string aCODE, decimal hOMEAMOUNT, decimal hOMEAMT, decimal hOMEOAMT, decimal lOCALAMOUNT, decimal lOCALAMT, decimal lOCALOAMT, string sOURCECUR, string cURCODE, string dESP, string nARRATION, System.Nullable<DateTime> dATE_TIME, string sTATUS, string tRANCODE, string aCSIGN, string oRGNENO, string uSERNO, byte[] cHKTIME, string cLRPOSTSTATUS, string cHEQUE, string rECEIPTNO, string uID, string sOURCEBR, System.Nullable<decimal> rATE, System.Nullable<DateTime> sETTLEMENTDATE)
        {
            this.ENO = eNO;
            this.ACCTNO = aCCTNO;
            this.AMOUNT = aMOUNT;
            this.ACODE = aCODE;
            this.HOMEAMOUNT = hOMEAMOUNT;
            this.HOMEAMT = hOMEAMT;
            this.HOMEOAMT = hOMEOAMT;
            this.LOCALAMOUNT = lOCALAMOUNT;
            this.LOCALAMT = lOCALAMT;
            this.LOCALOAMT = lOCALOAMT;
            this.SOURCECUR = sOURCECUR;
            this.CURCODE = cURCODE;
            this.DESP = dESP;
            this.NARRATION = nARRATION;
            this.DATE_TIME = dATE_TIME;
            this.STATUS = sTATUS;
            this.TRANCODE = tRANCODE;
            this.ACSIGN = aCSIGN;
            this.ORGNENO = oRGNENO;
            this.USERNO = uSERNO;
            this.CHKTIME = cHKTIME;
            this.CLRPOSTSTATUS = cLRPOSTSTATUS;
            this.CHEQUE = cHEQUE;
            this.RECEIPTNO = rECEIPTNO;
            this.UID = uID;
            this.SOURCEBR = sOURCEBR;
            this.RATE = rATE;
            this.SETTLEMENTDATE = sETTLEMENTDATE;
        }

        
        public virtual string ENO { get; set; }
        public virtual string ACCTNO { get; set; }
        public virtual decimal AMOUNT { get; set; }
        public virtual string ACODE { get; set; }
        public virtual decimal HOMEAMOUNT { get; set; }
        public virtual decimal HOMEAMT { get; set; }
        public virtual decimal HOMEOAMT { get; set; }
        public virtual decimal LOCALAMOUNT { get; set; }
        public virtual decimal LOCALAMT { get; set; }
        public virtual decimal LOCALOAMT { get; set; }
        public virtual string SOURCECUR { get; set; }
        public virtual string CURCODE { get; set; }
        public virtual string DESP { get; set; }
        public virtual string NARRATION { get; set; }
        public virtual System.Nullable<DateTime> DATE_TIME { get; set; }
        public virtual string STATUS { get; set; }
        public virtual string TRANCODE { get; set; }
        public virtual string ACSIGN { get; set; }
        public virtual string ORGNENO { get; set; }
        public virtual string USERNO { get; set; }
        public virtual byte[] CHKTIME { get; set; }
        public virtual string CLRPOSTSTATUS { get; set; }
        public virtual string CHEQUE { get; set; }
        public virtual string RECEIPTNO { get; set; }
        public virtual string UID { get; set; }
        public virtual string SOURCEBR { get; set; }
        public virtual System.Nullable<decimal> RATE { get; set; }
        public virtual System.Nullable<DateTime> SETTLEMENTDATE { get; set; }
        public virtual bool IsCheck { get; set; }
    }
}