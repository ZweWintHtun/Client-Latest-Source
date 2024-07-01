//----------------------------------------------------------------------
// <copyright file="CXCLE00013.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate>2013-05-21</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version>1.0</Version>
//----------------------------------------------------------------------
using System;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Cx.Cle
{
     /// <summary>
    /// GetRemitACode
    /// Select Remittance Account Code which one is required .
    /// </summary>
    [Serializable]
   public class CXCLE00013 
    {
       #region Constructor
       public CXCLE00013() { }
       #endregion

       #region Instance
       private static CXCLE00013 instance = null;
       public static CXCLE00013 Instance
       {
           get
           {
               if (instance == null)
               {
                   instance = SpringApplicationContext.Instance.Resolve<CXCLE00013>("GetRemitACodeController");
               }
               return instance;
           }
       }
       #endregion

       #region Public Methods
       /// <summary>
       /// Select Account Code from RemitBr when is needed for Drawing or Encash Remittance.
       /// </summary>
       /// <param name="branchCode"></param>
       /// <param name="currency"></param>
       /// <param name="sourceBranchCode"></param>
       /// <param name="dataAction"></param>
       /// <returns></returns>
       public TLMDTO00028 GetRemittanceAccountCode(string branchCode, string currency, string sourceBranchCode,CXDMD00006 dataAction)
       {         
           
           if (string.IsNullOrEmpty(branchCode) || string.IsNullOrEmpty(currency)  || string.IsNullOrEmpty(sourceBranchCode))
           {
               throw new Exception(CXMessage.ME90018);                
           }
           else
           {
               TLMDTO00028 remitBr = new TLMDTO00028();
               if (dataAction == CXDMD00006.Encash)
               {
                   remitBr = this.GetEncashRemittanceAccountCode(branchCode, currency, sourceBranchCode);

               }
               else if (dataAction == CXDMD00006.Drawing)
               {
                   remitBr = this.GetDrawingRemittanceAccountCode(branchCode, currency, sourceBranchCode);

               }
               return remitBr;
           }                  
       }               
       #endregion

       #region Private Methods

       /// <summary>
       /// Get Account Code from RemitBr require for EncashRemittance 
       /// </summary>
       /// <param name="branchCode"></param>
       /// <param name="currency"></param>
       /// <param name="accountType"></param>
       /// <returns></returns>
       private TLMDTO00028 GetEncashRemittanceAccountCode(string branchCode, string currency, string sourceBranchCode)
       {
           try
           {
               TLMDTO00028 remitBr = CXCLE00002.Instance.GetScalarObject<TLMDTO00028>("RemitBr.SelectEncashAccountCode", new object[] { branchCode, currency, sourceBranchCode });
               if (remitBr != null)
               {   
                   if (string.IsNullOrEmpty(remitBr.EncashAccount))
                   {

                       remitBr.EncashAccount = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.EncashOrDrawingAccountCode), currency, sourceBranchCode, true });
                   }
                   return remitBr;
               }
               else
               {
                   throw new Exception(CXMessage.MV00120);
               }
           }
           catch (Exception ex)
           {
               throw;
           }
       }

       /// <summary>
       /// Get Account Code from RemitBr require for Drawing Remittance 
       /// </summary>
       /// <param name="branchCode"></param>
       /// <param name="currency"></param>
       /// <param name="sourceBranchCode"></param>
       /// <returns></returns>
       private TLMDTO00028 GetDrawingRemittanceAccountCode(string branchCode, string currency, string sourceBranchCode)
       {
           try
           {
               TLMDTO00028 remitBr = CXCLE00002.Instance.GetScalarObject<TLMDTO00028>("RemitBr.SelectDrawingAccountCode", new object[] { branchCode, currency, sourceBranchCode });
             
               if (remitBr != null)
               {
                   if (string.IsNullOrEmpty(remitBr.DrawingAccount))
                   {
                       remitBr.DrawingAccount = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.EncashOrDrawingAccountCode), currency, sourceBranchCode, true });
                   }
                   if (string.IsNullOrEmpty(remitBr.TelaxAccount))
                   {
                       remitBr.TelaxAccount = remitBr.DrawingAccount = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TelaxAccountCode), currency, sourceBranchCode, true });
                   }
                   if (string.IsNullOrEmpty(remitBr.IBSComAccount))
                   {
                       remitBr.IBSComAccount = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.IBSCommisionAccount), currency, sourceBranchCode, true });
                   }

                   return remitBr;


               }
               else
               {
                   throw new Exception(CXMessage.MV00120);
               }
           }
           catch (Exception ex)
           {
               throw;
           }
        
       }        
       #endregion  

   }
}
