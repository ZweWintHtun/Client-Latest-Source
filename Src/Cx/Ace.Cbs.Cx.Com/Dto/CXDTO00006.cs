//----------------------------------------------------------------------
// <copyright file="CXDTO00006.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Su Su Wai</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Com.Dmd;

namespace Ace.Cbs.Cx.Com.Dto
{
    /// <summary>
    /// Data Generate in SQL DTO(Report Parameters)
    /// </summary>
    [Serializable]
    public class CXDTO00006
   {
       #region Constructor
       public CXDTO00006() { }
       #endregion

       #region CXSVE00010 Input Parameter
       /// <summary>
       /// Required Parameter
       /// </summary>
       public string BDateType { get; set; }
       #endregion      

       #region Store Procedure Input Parameter
       private string accountNo = string.Empty;
       /// <summary>
       /// AccountNo(Optional Parameter)
       /// </summary>
       public string AccountNo
       {
           get { return accountNo; }
           set { this.accountNo = value; }
       }
       private string aCode = string.Empty;
       /// <summary>
       /// ACode(Optional Parameter)
       /// </summary>
       public string ACode
       {
           get { return aCode; }
           set { this.aCode = value; }
       }

       private string aCSign = string.Empty;
       /// <summary>
       /// ACSign(Optional Parameter)
       /// </summary>
       public string ACSign
       {
           get { return aCSign; }
           set { this.aCSign = value; }
       }
       private string cashClearTransaction = string.Empty;
       /// <summary>
       /// CashClearTransaction(Optional Parameter)
       /// </summary>
       public string CashClearTransaction
       {
           get { return cashClearTransaction; }
           set { this.cashClearTransaction = value; }
       }
       private Nullable<CXDMD00002> debit_Or_Credit = null;
       /// <summary>
       /// Debit_Or_Credit(Optional Parameter)
       /// </summary>
       public Nullable<CXDMD00002> Debit_Or_Credit 
       {
           get { return this.debit_Or_Credit; }
           set { this.debit_Or_Credit = value; }
       }

       private string orginalENo = string.Empty;
       /// <summary>
       /// OrginalENo(Optional Parameter)
       /// </summary>
       public string OrginalENo
       {
           get { return orginalENo; }
           set { this.orginalENo = value; }
       }

       private string userNo = string.Empty;
       /// <summary>
       /// UserNo(Optional Parameter)
       /// </summary>
       public string UserNo
       {
           get { return userNo; }
           set { this.userNo = value; }
       }

       private string transactionCode = string.Empty;
       /// <summary>
       /// TransactionCode(Optional Parameter)
       /// </summary>
       public string TransactionCode
       {
           get { return transactionCode; }
           set { this.transactionCode = value; }
       }


       private string specialCondition = string.Empty;
       /// <summary>
       /// SpecialCondition(Optional Parameter)
       /// </summary>
       public string SpecialCondition
       {
           get { return specialCondition; }
           set { this.specialCondition = value; }
       }
       /// <summary>
       /// StartDate(Required Parameter)
       /// </summary>
       public DateTime StartDate { get; set; }
       /// <summary>
       /// EndDate(Required Parameter)
       /// </summary>
       public DateTime EndDate { get; set; }
       private CXDMD00009 Check_Or_Return = 0;
       /// <summary>
       /// ForCheck_Or_ForReturn(Required Parameter)
       /// </summary>
       public CXDMD00009 ForCheck_Or_ForReturn
       {
           get { return this.Check_Or_Return; }
           set { this.Check_Or_Return = value; }
       }      
       /// <summary>
       /// CreatedUserId(Required Parameter)
       /// </summary>
       public int CreatedUserId { get; set; }

       /// <summary>
       /// WorkStationId(Required Parameter)
       /// </summary>
       public int WorkStationId { get; set; }

       public string CurrencyCode { get; set; }

       public string SourceBranch { get; set; }

       #endregion
    }
}
