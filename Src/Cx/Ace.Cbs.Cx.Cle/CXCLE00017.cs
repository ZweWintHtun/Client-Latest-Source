//----------------------------------------------------------------------
// <copyright file="CXCLE00012.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Cho Zin Thant </CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser>
//</UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;


namespace Ace.Cbs.Cx.Cle
{
    public class CXCLE00017
    {
        public CXCLE00017() { }

        #region Private Variables



        #endregion

        #region Properties
        private static CXCLE00017 instance;
        public static CXCLE00017 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = SpringApplicationContext.Instance.Resolve<CXCLE00017>("CXCLE00017");
                }
                return instance;
            }
        }
        #endregion

        public decimal GetTestKey(string branchKey, string dayKey, string monthKey, decimal amountKey, string sourceBranchCode)
        {
            try
            {
                //need to confirm amountKey has zero amount value in setup.
                if (string.IsNullOrEmpty(branchKey) || string.IsNullOrEmpty(dayKey) || string.IsNullOrEmpty(monthKey) || string.IsNullOrEmpty(sourceBranchCode))
                {
                    throw new Exception(CXMessage.ME90018);
                }
                else
                {
                    decimal Key1 = this.SelectBranchKey(branchKey, sourceBranchCode);
                    decimal Key2 = this.SelectDayKey(dayKey, sourceBranchCode);

                    //old code
                    //decimal Key3 = this.SelectMonthKey((monthKey.Substring(0, 1) == "0") ? monthKey.Substring(1, 1) : monthKey, sourceBranchCode);

                    decimal Key3 = this.SelectMonthKey(monthKey, sourceBranchCode); //edited by ZMA

                    double Key4 = Convert.ToDouble(this.CalculateAmountKey(amountKey, sourceBranchCode));
                    decimal Key = Convert.ToDecimal(Key4);
                    return (Key1 + Key2 + Key3 + Key);
                }
            }
            catch (Exception exp)
            {
                throw new Exception(CXMessage.ME00040, exp);//TestKey Calculation Error.
            }
        }


        private decimal SelectDayKey(string DayKey, string SourceBranchCode)
        {
            return CXCLE00001.Instance.SelectDayKey(DayKey);
        }

        private decimal SelectMonthKey(string MonthKey, string SourceBranchCode)
        {
            return CXCLE00001.Instance.SelectMonthKey(MonthKey);
        }

        private decimal SelectAmountKey(decimal AmountKey, string SourceBranchCode)
        {
            return CXCLE00001.Instance.SelectAmountKey(AmountKey);
        }

        private decimal SelectBranchKey(string BranchKey, string SourceBranchCode)
        {

            return CXCLE00001.Instance.SelectBranchKey(BranchKey);
        }


        #region calculateAmountKey
        private decimal CalculateAmountKey(decimal amount, string sourceBranchCode)
        {
            if (amount < 1 || string.IsNullOrEmpty(sourceBranchCode))
            {
                throw new Exception(CXMessage.MV00037);
            }
            else
            {
                int digits = 0;
                double returnAmount = 0;
                double remainAmount;
                if (amount <= 100)
                {
                    returnAmount = Convert.ToDouble(this.SelectAmountKey(amount, sourceBranchCode));
                }
                else if (amount > 100)
                {
                    int amint = Convert.ToInt32(amount);
                    string amstring = Convert.ToString(amint);
                    int length = amstring.Length;
                    digits = length - 1;
                    Double amt = Convert.ToDouble(amount) / Math.Pow(10, digits);
                    string a = Convert.ToString(amt).Substring(0, 1);
                    int amtt = Convert.ToInt32(a);
                    returnAmount = Convert.ToDouble(amtt) * Math.Pow(10, digits);
                    //returnAmount = Convert.ToInt32((Convert.ToDouble(amount))/ Math.Pow(10, digits)) * Math.Pow(10, digits);
                    //ReturnValue = Int(SValue / (10 ^ Digit)) * (10 ^ Digit)
                    remainAmount = Convert.ToDouble(amount) - returnAmount;
                    decimal ramt = Convert.ToDecimal(returnAmount);
                    returnAmount = Convert.ToDouble(this.SelectAmountKey(ramt, sourceBranchCode));
                    if (remainAmount != 0)
                    {
                        returnAmount += Convert.ToDouble(this.CalculateAmountKey(Convert.ToDecimal(remainAmount), sourceBranchCode));
                    }
                }

                return Convert.ToDecimal(returnAmount);
            }
        }

        #endregion
    }
}


