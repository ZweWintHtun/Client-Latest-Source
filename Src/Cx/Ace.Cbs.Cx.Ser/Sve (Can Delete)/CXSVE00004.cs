using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.CXServer.Utt;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Dmd;

namespace Ace.Cbs.Cx.Ser.Sve
{
    public class CXSVE00004 : BaseService, ICXSVE00004
    {
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
                    //CXDTO00002 getRate = cashEnable ? this.GetDenoExchangeRateString(denoList.ToList()[0].Currency, branchCode, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType)) : this.GetDenoExchangeRateString(denoList.ToList()[0].Currency, branchCode, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType));
                    //if (getRate != null)
                    {
                        string homeEXRate = "1";//getRate.ExchangeRateString;
                        string denoExRate = string.Empty;//string.IsNullOrEmpty(getRate.DenoRateString) ? string.Empty : getRate.DenoRateString.Trim();
                        foreach (var item in denoList)
                        {
                            strIndvDenoRate = string.Empty; strIndvRefundRate = string.Empty;
                            int times = 1;
                            while (startPosition < (denoExRate.Length))
                            {
                                endPosition = denoExRate.IndexOf("*", startPosition) - 1;
                                if (endPosition <= 0)
                                    endPosition = denoExRate.Length;

                                strTemp = (times == 1) ? (denoExRate.Substring(startPosition, endPosition)) : (denoExRate.Substring(startPosition, endPosition - (startPosition - 1)));

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
                                    strIndvDenoRate += item.Symbol + ":" + homeEXRate + ":" + "*";

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


        private decimal SelectCurrentBalanceByAccountNo(string accountNo)
        {            
            return CXServiceWrapper.Instance.Invoke<ICXSVE00006, PFMDTO00028>(x => x.SelectCurrentBalanceByAccountNo(accountNo)).CurrentBal;
        }

        public PFMDTO00054 AmtOamtParameterCheck(string accountNo, decimal actionAmount, CXDMD00002 debitCreditTransaction)
        {
            //confirm actionAmount must>0 or not.
            try
            {
                if (!string.IsNullOrEmpty(accountNo))
                {
                    decimal currentBalance = this.SelectCurrentBalanceByAccountNo(accountNo);
                    PFMDTO00054 tlfDTO = new PFMDTO00054();
                    switch (debitCreditTransaction)
                    {
                        case CXDMD00002.Credit:
                            {
                                if (currentBalance > 0)
                                {
                                    tlfDTO.LocalAmt = actionAmount;
                                    tlfDTO.LocalOAmt = 0;

                                }

                                else if (Convert.ToDecimal(Math.Abs(currentBalance)) >= actionAmount)
                                {
                                    tlfDTO.LocalOAmt = actionAmount;
                                    tlfDTO.LocalAmt = 0;
                                }
                                else if (Math.Abs(currentBalance) < actionAmount)
                                {
                                    tlfDTO.LocalOAmt = Math.Abs(currentBalance);
                                    tlfDTO.LocalAmt = actionAmount - Math.Abs(currentBalance);
                                }
                            }
                            break;


                        case CXDMD00002.Debit:
                            if (currentBalance <= 0)
                            {
                                tlfDTO.LocalAmt = 0;
                                tlfDTO.LocalOAmt = actionAmount;
                            }
                            else if (currentBalance >= actionAmount)
                            {
                                tlfDTO.LocalOAmt = 0;
                                tlfDTO.LocalAmt = actionAmount;
                            }
                            else if (currentBalance < actionAmount)
                            {
                                tlfDTO.LocalAmt = currentBalance;
                                tlfDTO.LocalOAmt = actionAmount - currentBalance;
                            }
                            break;
                    }
                    return tlfDTO;
                }

                else
                {
                    throw new Exception(CXMessage.MV00046);
                }

            }
            catch (Exception)
            {
                throw new Exception(CXMessage.MV00122);
            }
        }


        public IList<TLMDTO00012> GetDenoCalculateAmount(IList<TLMDTO00012> DenoList, string denoDetail, string denoRefundDetail, string denoStatus)
        {
            string[] strCashDeno = denoDetail.Split('*');
            string[] strRefundDeno = string.IsNullOrEmpty(denoRefundDetail) ? default(string[]) : denoRefundDetail.Split('*');

            foreach (string deno in strCashDeno)
            {
                if (denoStatus == "R")
                    DenoList.Single<TLMDTO00012>(x => x.Symbol == deno.Substring(0, 1)).DenoCount += Convert.ToInt32(deno.Substring(2));
                else
                    DenoList.Single<TLMDTO00012>(x => x.Symbol == deno.Substring(0, 1)).DenoCount -= Convert.ToInt32(deno.Substring(2));
            }

            if (default(string[]) != strRefundDeno)
                foreach (string deno in strRefundDeno)
                {
                    DenoList.Single<TLMDTO00012>(x => x.Symbol == deno.Substring(0, 1)).DenoCount -= Convert.ToInt32(deno.Substring(2));
                }

            return DenoList;
        }

    }
}
