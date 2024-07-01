//----------------------------------------------------------------------
// <copyright file="CXCLE00009.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Ye Mann Aung</CreatedUser>
// <CreatedDate>2013-05-22</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version>1.0</Version>
//----------------------------------------------------------------------


using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Windows.CXClient;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Utt;
using System.Linq;

namespace Ace.Cbs.Cx.Cle
{
    public class CXCLE00009
    {
        #region variables
        private static CXCLE00009 instance = null;
        #endregion

        #region Property
        public static CXCLE00009 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = SpringApplicationContext.Instance.Resolve<CXCLE00009>("CXCLE00009");
                }
                return instance;
            }
        }
        #endregion

        #region constructor
        public CXCLE00009() { }
        #endregion

        #region Public Method
        public CXDTO00001 GetDenoString(IList<TLMDTO00012> getDenoInfo, bool cashEnable, string branchCode)
        {
            if (!string.IsNullOrEmpty(branchCode) && (getDenoInfo.Count > 0))
            {
                var denoList = from value in getDenoInfo
                               where value.DenoCount > 0 || value.RefundCount > 0
                               select value;

                if (denoList != null)
                {
                    string strDeno = string.Empty;
                    string strDenoRate = string.Empty;
                    string strRefund = string.Empty;
                    string strRefundRate = string.Empty;
                    string strTemp = string.Empty;
                    string strIndvDenoRate = string.Empty;                   
                    string strIndvRefundRate = string.Empty;
                    int startPosition = 1;
                    int endPosition;
                                 
                    CXDTO00001 getStrings;
                    CXDTO00002 getRate = cashEnable ? CXCLE00011.Instance.GetDenoExchangeRateString(denoList.ToList()[0].Currency, branchCode, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType)) : CXCLE00011.Instance.GetDenoExchangeRateString(denoList.ToList()[0].Currency, branchCode, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType));
                    if (getRate != null)
                    {
                       
                        string homeEXRate = getRate.ExchangeRateString;
                        string denoExRate = string.IsNullOrEmpty(getRate.DenoRateString) ? string.Empty : getRate.DenoRateString.Trim();
                        foreach (var item in denoList)
                        {
                            strIndvDenoRate = string.Empty; strIndvRefundRate = string.Empty;
                            int times = 1;
                           
                            while (startPosition < (denoExRate.Length))
                            {
                               endPosition = denoExRate.IndexOf("*", startPosition) - 1;
                               // endPosition = denoExRate.IndexOf("*", startPosition);
                                if (endPosition <= 0)
                                    endPosition = denoExRate.Length;

                                strTemp = (times == 1) ? (denoExRate.Substring(startPosition - 1, endPosition)) : (denoExRate.Substring(startPosition, endPosition - (startPosition - 1)));

                                if (item.DenoCount > 0)
                                    if (item.Symbol == strTemp.PadLeft(1))
                                        strIndvDenoRate += item.Symbol + ":" + (strTemp.Substring(3, strTemp.Trim().Length - 2)) + "*";

                                if (item.RefundCount > 0)
                                    if (item.Symbol == strTemp.PadLeft(1))
                                        strIndvRefundRate += item.Symbol + ":" + (strTemp.Substring(3, strTemp.Trim().Length - 2)) + "*";

                                startPosition = endPosition + 2;
                                times++;
                               

                            }

                            if (item.DenoCount > 0)// why in Deno case not use D1 D2
                            {
                                strDeno += item.Symbol + ":" + item.DenoCount.ToString() + "*";//-----
                                //-----
                                if (string.IsNullOrEmpty(strIndvDenoRate))
                                    strIndvDenoRate += item.Symbol + ":" + homeEXRate + "*";

                                strDenoRate += strIndvDenoRate;
                            }
                            if (item.RefundCount > 0)
                            {
                                if (Convert.ToInt32(item.D1) > 0)
                                    strRefund += (item.Symbol + ":" + item.RefundCount + "*");                               
                                if (Convert.ToInt32(item.D2) > 0)
                                    strRefund += (item.Symbol + ":" + +item.RefundCount + "*");
                                //----
                               
                                if (string.IsNullOrEmpty(strIndvRefundRate))
                                    strIndvRefundRate += item.Symbol + ":" + homeEXRate + ":" + "*";

                                strRefundRate += strIndvRefundRate;
                            }
                        }
                        getStrings = new CXDTO00001();
                        getStrings.DenoString = strDeno.Substring(0, strDeno.Length - 1);
                        getStrings.DenoRateString = strDenoRate.Substring(0, strDenoRate.Length - 1);
                        if (!string.IsNullOrEmpty(strRefund))
                        {
                            getStrings.RefundString = strRefund.Substring(0, strRefund.Length - 1);
                            getStrings.RefundRateString = strRefundRate.Substring(0, strRefundRate.Length - 1);
                        }
                        return getStrings;
                    }
                    else
                    {
                        throw new Exception(CXMessage.MI00013); //<<=== Edited MI00116 to  MI00013 ( No Rate for this Currency).
                    }
                   
                }
                else
                {
                    throw new Exception(CXMessage.MI00013); //<<=== Edited MI00116 to  MI00013 ( No Rate for this Currency).
                }
            }
            else
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter.
            }

        }
    }
        #endregion
}
