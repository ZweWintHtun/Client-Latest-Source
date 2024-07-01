//----------------------------------------------------------------------
// <copyright file="CXCLE00015.cs" company="ACE Data Systems">
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
using Ace.Windows.CXClient;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Cx.Cle
{
    [Serializable]
    public class CXCLE00015
    {
        #region Variables
        private static CXCLE00015 instance = null;
        #endregion

        #region constructor
        public CXCLE00015() { }
        #endregion

        #region Properties
        public static CXCLE00015 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = SpringApplicationContext.Instance.Resolve<CXCLE00015>("CXCLE00015");
                }
                return instance;
            }
        }
        #endregion

        #region Private Method
        private TLMDTO00030 CalculateIBLDrawingRateIncome(string branchCode, string currency, string amount, string soucreBranch)
        {
            return CXCLE00002.Instance.GetObjectByCustomHQL<TLMDTO00030>("TLMDAO00030.SelectRateFixAmtByBranchCodeAndCur", new Dictionary<string, object>() { { "branchCode", branchCode },{ "sourceBranchCode", soucreBranch }, { "cur", currency }, { "amount", amount } });
        }

        private TLMDTO00032 CalculateRMitRateIncome(string branchCode, string currency, string amount, string soucreBranch)
        {
            return CXCLE00002.Instance.GetObjectByCustomHQL<TLMDTO00032>("TLMDAO00032.SelectRateFixAmtByBranchCodeAndCur", new Dictionary<string, object>() { { "branchCode", branchCode },{ "sourceBranchCode", soucreBranch }, { "cur", currency }, { "amount", amount } });
        }

        private decimal CalculateFaxNCommunicationCharges(string branch, string currency, bool isOtherBank, string soucreBranch)
        {
            if (isOtherBank)
            {
                TLMDTO00028 dto = CXCLE00002.Instance.GetScalarObject<TLMDTO00028>("CXCLE00015.Client.IBS.TLXChargesSelectedByBranchCodeandCur"/*"CXCLE00015.RemitBr.SelectTelaxCharges"*/, new object[] { branch, currency, soucreBranch,true });
                return dto.TelaxCharges;
            }
            else
            {
                TLMDTO00029 dto = CXCLE00002.Instance.GetScalarObject<TLMDTO00029>("CXCLE00015.Client.IBL.TLXChargesSelectedByBranchCodeandCur", new object[] { branch, currency , soucreBranch,true });
                return dto.TelaxCharges;
            }
        }
        /// <summary>
        /// Need to consider Name
        /// </summary>
        /// <param name="branchCode"></param>
        /// <returns></returns>
        private bool HasZoneInformation(string branchCode, string soucreBranch)
        {
            TLMDTO00031 dto = CXCLE00002.Instance.GetScalarObject<TLMDTO00031>("CXCLE00015.Client.IBSACSelectedByBRCode", new object[] { branchCode, soucreBranch });
            return dto != null ? (dto.AccountCode == null ? false : true) : false;
        }

        private bool CheckIsOtherBank(string branchCode)
        {
            BranchDTO bdto = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { branchCode });
            return bdto.OtherBank;
        }
        #endregion

        #region Public Method
        /// <summary>
        /// CalculateCharges
        /// </summary>
        /// <param name="branchCode"></param>
        /// <param name="currency"></param>
        /// <param name="amount"></param>
        /// /// <param name="isWithIncome"></param>
        public CXDTO00005 CalculateCharges(string branchCode, string currency, decimal amount, bool isWithIncome,string soucreBranch)
        {
            CXDTO00005 getValues = new CXDTO00005();
            try
            {
                //Need to confirm amount must be greater than 0 or not.
                if (string.IsNullOrEmpty(branchCode) || string.IsNullOrEmpty(currency))
                {
                    throw new Exception(CXMessage.ME90018);
                }
                else if(branchCode.Equals(CurrentUserEntity.BranchCode))
                {
                    return getValues = new CXDTO00005(amount,0,0);
                }
                else
                {
                    if (!this.HasZoneInformation(branchCode, soucreBranch))
                    {
                        throw new Exception(CXMessage.ME00030);
                    }
                    else
                    {
                        decimal remittanceAmount = 0;
                        decimal communicationCharges = 0;
                        decimal rate = 0;
                        decimal income = 0;

                        bool isOtherBank = this.CheckIsOtherBank(branchCode);
                        communicationCharges = this.CalculateFaxNCommunicationCharges(branchCode, currency,isOtherBank,soucreBranch);
                        if (isOtherBank)
                        {
                            TLMDTO00032 getRate = this.CalculateRMitRateIncome(branchCode, currency, amount.ToString(), soucreBranch);
                            if (getRate == null)
                                throw new Exception(CXMessage.ME00021);
                            else
                            {
                                rate = getRate.Rate;
                                income = getRate.FixAmount;
                            }
                        }
                        else
                        {
                            TLMDTO00030 getRate = this.CalculateIBLDrawingRateIncome(branchCode, currency, amount.ToString(), soucreBranch);
                            if (getRate == null)
                                throw new Exception(CXMessage.ME00021);
                            else
                            {
                                rate = getRate.Rate.HasValue ? getRate.Rate.Value : 0;
                                income = getRate.FixAmount.HasValue ? getRate.FixAmount.Value : 0;
                            }
                        }
                        remittanceAmount = (isWithIncome) ? amount : ((rate > 0) ? ((amount - communicationCharges) * 100 / (100 + (rate))) : amount - (communicationCharges + income));
                        getValues = new CXDTO00005();
                        getValues.CommunicationCharges = communicationCharges;
                        getValues.Commission = (rate > 0) ? ((remittanceAmount / 100) * rate) : income;
                        getValues.RemittanceAmount =Math.Round(remittanceAmount,2);
                        return getValues;
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception(CXMessage.ME00021);//Client Data Not Found
            }
        }

        public IList<TLMDTO00032> GetAllRateByBranchCodeAndCur(string branchCode, string currency, string soucreBranch)
        {
            IList<TLMDTO00032> rateList=CXCLE00002.Instance.GetListByCustomHQL<TLMDTO00032>("TLMDAO00032.SelectAllRateByBranchCodeAndCur", new Dictionary<string, object>() { { "branchCode", branchCode }, { "sourceBranchCode", soucreBranch }, { "cur", currency } });
            return rateList;
        } 
    }
        #endregion

}

