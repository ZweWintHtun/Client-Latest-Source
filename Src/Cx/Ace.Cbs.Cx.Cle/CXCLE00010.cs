//----------------------------------------------------------------------
// <copyright file="CXCLE00010.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Cho Zin Thant</CreatedUser>
// <CreatedDate>2013-05-22</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version>1.0</Version>
//----------------------------------------------------------------------


using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using System.Linq;

namespace Ace.Cbs.Cx.Cle
{
    [Serializable]
    public class CXCLE00010 
    {
        public CXCLE00010() {}
      

        #region Properties
        private static CXCLE00010 instance;
        public static CXCLE00010 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = SpringApplicationContext.Instance.Resolve<CXCLE00010>("CXCLE00010");
                }
                return instance;
            }
        }
        #endregion

        //need to confirm amount is allowed to be zero?
        public decimal CalculatePOrate(decimal amount, string currency)
        {
            try
            {
                if (string.IsNullOrEmpty(currency))
                {
                    throw new Exception(CXMessage.ME90018);//Invalid Parameter.
                }
                else
                {                    
                    IList<TLMDTO00003> pORate = this.SelectPORate(currency);
                    if (pORate.Count > 0)
                    {
                        decimal charges = 0;
                        foreach (TLMDTO00003 rate in pORate)
                        {
                            if ((amount >= Convert.ToDecimal(rate.StartNo)) && (amount <= Convert.ToDecimal(rate.EndNo)))
                            {
                                charges = (rate.FixAmount.Equals(0)) ? ((amount * Convert.ToDecimal(rate.Rate)) / 100) : rate.FixAmount;   // FixAmount is not null in Table Definition                              
                            }

                            else if (amount >= Convert.ToDecimal(rate.StartNo) && rate.EndNo.Equals(Convert.ToDecimal(0.00)))
                            {
                                charges = Convert.ToDecimal(rate.FixAmount);
                            }
                        }
                        return charges; //Prize_Msg If Charges is equal 0,you will show message to need "po rate not found in table" .
                    }
                    else
                    {//SSW_Msg
                        throw new Exception(CXMessage.ME00036);//po rate not found in table.
                        return 0;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
     
       public IList<TLMDTO00003> SelectPORate(string currency)
       {
           return CXCLE00002.Instance.GetListObject<TLMDTO00003>("CXCLE00010.SelectPORate", new object[] { currency });
       }
     
    }
       
}
