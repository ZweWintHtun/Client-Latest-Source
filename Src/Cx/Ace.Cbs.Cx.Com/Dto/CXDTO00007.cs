using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Cx.Com.Dto
{
     [Serializable]
   public class CXDTO00007
    {
       #region Constructor
       public CXDTO00007() { }

      

       #endregion

       #region Store Procedure Input Parameter
       public string VoucherNo { get; set; }

       private string accountNo = string.Empty;
       /// <summary>
       /// AccountNo(Optional Parameter)
       /// </summary>
       public string AccountNo
       {
           get { return accountNo; }
           set { this.accountNo = value; }
       }

       public decimal Amount { get; set; }

       private string checkNo = string.Empty;
       /// <summary>
       /// AccountNo(Optional Parameter)
       /// </summary>
       public string CheckNo
       {
           get { return checkNo; }
           set { this.checkNo = value; }
       }

       private decimal commission = 0;
       public decimal Commission
       {
           get { return commission; }
           set { this.commission = value; }
       }

       public string DBank { get; set; }

       public string RegisterNo { get; set; }

       public int RemitStatus { get; set; }

       private string userNo = string.Empty;
       /// <summary>
       /// UserNo(Optional Parameter)
       /// </summary>
       public string UserNo
       {
           get { return userNo; }
           set { this.userNo = value; }
       }

       public bool ChkClose { get; set; }

       public int TrueLink { get; set; }

       public string Currency { get; set; }

       public decimal ExchangeRateString { get; set; }

       public string BranchCode { get; set; }

       public string SettlementDate { get; set; }

       public string Channel { get; set; }

       public int CreatedUserId { get; set; }

       public string RETVALUE { get; set; }

       public string NO { get; set; }

     
       
       #endregion

    }
}
