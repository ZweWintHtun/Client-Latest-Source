//----------------------------------------------------------------------
// <copyright file="PFMVEW00012.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Htet Mon Win</CreatedUser>
// <CreatedDate>30-05-2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using NHibernate;
using Spring.Data.NHibernate.Support;

namespace Ace.Cbs.Cx.Cle
{
    /// <summary>
    /// GetExchangeRate
    /// </summary>
    public class CXCLE00011
    {
        #region variable
        private static CXCLE00011 instance = null;
        #endregion

        #region Property
        public static CXCLE00011 Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = SpringApplicationContext.Instance.Resolve<CXCLE00011>("CXCLE00011");
                }
                return instance;
            }
        }
        #endregion

        #region constructor
        public CXCLE00011() { }
        #endregion

        #region Public Methods       
        public CXDTO00002 GetDenoExchangeRateString(string currencyCode, string branchCode, string rateType)
        {
            try
            {
                if (string.IsNullOrEmpty(currencyCode) || string.IsNullOrEmpty(branchCode) || string.IsNullOrEmpty(rateType))
                {
                    throw new Exception(CXMessage.ME90018);//Invalid Parameter
                }
                else
                {
                    PFMDTO00075 exchangeRateDTO = CXCOM00010.Instance.SelectRateAndDenoRate(currencyCode, rateType);
                    if (exchangeRateDTO != null)
                    {
                        CXDTO00002 denoExchangeRate = new CXDTO00002();
                        denoExchangeRate.ExchangeRateString = Convert.ToString(exchangeRateDTO.Rate);
                        if (rateType.ToUpper() == CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType))//SSW_Msg
                        {
                            denoExchangeRate.DenoRateString = exchangeRateDTO.DenoRate;// Deno Rate is need when RateType is "CS".                    
                        }
                        return denoExchangeRate;
                    }
                    else
                    {
                        throw new Exception(CXMessage.ME00037);//Exchange Rate not found in table.
                    }                   
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}
