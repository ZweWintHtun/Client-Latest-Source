//----------------------------------------------------------------------
// <copyright file="CXCLE00012.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
using NHibernate;
using Spring.Data.NHibernate.Support;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Cx.Cle
{
    /// <summary>
    /// Parameters's Checking
    /// </summary>

    public class CXCLE00012
    {
        #region Private  Variables
        
        string Ctype2, Ctype1;
        public string ReportAmountInword;
        private bool isValidateForm = false;

        #endregion

        #region " Constructor "

        public CXCLE00012()
        {

        }
        #endregion

        #region " Private Variables "

        private static CXCLE00012 instance = null;
     

        #endregion

        #region " Properties "
        public static CXCLE00012 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = SpringApplicationContext.Instance.Resolve<CXCLE00012>("CXCLE00012");
                }

                return instance;
            }
        }
        #endregion

        #region Private Methods

        //To add Comma
        private string ChkComma()
        {
            string comma = ",";
            return comma;
        }

        //To Conver Number to Letter
        private string NumberToWords(Int64 number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";
            if ((number / 100000000) > 0)
            {
                words += NumberToWords(number / 100000000) + " Trillion ";
            //    words += this.ChkComma();
                number %= 100000000;
            }
            if ((number / 10000000) > 0)
            {
                words += NumberToWords(number / 10000000) + " Billion ";
           //     words += this.ChkComma();
                number %= 10000000;
            }

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " Million ";
             //   words += this.ChkComma();
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " Thousand ";
         //     words += this.ChkComma();
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " Hundred ";
         //      words += this.ChkComma();
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

        private IList<string> SelectNewSetupByVariable(string[] variables)
        {
            IList<string> values = new List<string>();           
            foreach (string variable in variables)
            {
               PFMDTO00057 newSetupDTO = CXCLE00002.Instance.GetClientData<PFMDTO00057>("NewSetup.Client.SelectValueByVariable", new object[] { variable });
               if (newSetupDTO != null)
               {
                   values.Add(newSetupDTO.Value);
               }
                
            }
            return values;
        }

        private IList<PFMDTO00057> SelectNewSetupListByVariable(string[] variables)
        {
            IList<PFMDTO00057> values = new List<PFMDTO00057>();
            foreach (string variable in variables)
            {
                PFMDTO00057 newSetupDTO = CXCLE00002.Instance.GetClientData<PFMDTO00057>("NewSetup.Client.SelectValueByVariable", new object[] { variable });
                if (newSetupDTO != null)
                {
                    values.Add(newSetupDTO);
                }

            }
            return values;
        }
        
        private decimal SelectCurrentBalanceByAccountNo(string accountNo)
        { 
            return CXClientWrapper.Instance.Invoke<ICXSVE00006, PFMDTO00028>(x => x.SelectCurrentBalanceByAccountNo(accountNo)).CurrentBal;
        }
        private string[] SplitString(string str)
        {
            return str.Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries);
            

        }
        #endregion

        #region Public Method

        public bool IsValidAccountNo(string accountNo, out Nullable<CXDMD00011> accountType)
        {
            if (string.IsNullOrEmpty(accountNo))
            {
                throw new Exception(CXMessage.MV00046);//Invalid AccountNo
            }
            else
            {
                int accountNoLength = accountNo.Length;
                string[] accountVariable = this.SplitString(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountParameterCheck));
                if (accountVariable.Length > 0)
                {
                    IList<string> values = this.SelectNewSetupByVariable(accountVariable);
                    if (values.Count > 0)
                    {
                        int i = 0;
                        foreach (string value in values)
                        {
                            if (Convert.ToInt32(value) == accountNoLength)
                                i++;
                        }
                        if (i > 0)
                        {
                            if (CXCLE00012.Instance.CheckAccountNoType(accountNo, CXDMD00011.AccountNoType2))
                            {
                                if (!CXCOM00006.Instance.Validate(accountNo, CXCOM00009.AccountNoCodeFormat, CXCOM00009.AccountNoCheckDigitFormula))
                                {
                                    throw new Exception(CXMessage.MV00114);//Invalid Check Digit No.                                    
                                }
                                accountType = CXDMD00011.AccountNoType2;
                                return true;
                            }
                            else if (CXCLE00012.Instance.CheckAccountNoType(accountNo, CXDMD00011.AccountNoType1))
                            {
                                if (!CXCOM00006.Instance.Validate(accountNo, CXCOM00009.AccountNoCodeFormat, CXCOM00009.AccountNoCheckDigitFormula))
                                {
                                    throw new Exception(CXMessage.MV00114);//Invalid Check Digit No.                                
                                }
                                accountType = CXDMD00011.AccountNoType1;
                                return true;
                            }
                            else if (CXCLE00012.Instance.CheckAccountNoType(accountNo, CXDMD00011.DomesticAccountType))
                            {
                                IList<ChargeOfAccountDTO> coaList = CXCLE00002.Instance.GetListObject<ChargeOfAccountDTO>("COA.Client.SelectAccountNameList", new object[] { accountNo, CXCOM00007.Instance.BranchCode, true });
                                if (coaList.Count < 1)
                                {
                                    //Account No. Not Found.
                                    throw new Exception(CXMessage.MV00175);
                                }
                                else if (accountNo.Substring(3, 3) == "000")
                                {
                                    //Group COA Code is not allowed.
                                    throw new Exception(CXMessage.MV00132);
                                }
                                accountType = CXDMD00011.DomesticAccountType;
                                return true;

                            }
                            else
                            {
                                throw new Exception(CXMessage.MV00199);//Incompleted Account No.                           
                            }
                        }
                        else
                        {
                            throw new Exception(CXMessage.MV00199);//Incompleted Account No.                           
                        }
                    }
                    else
                    {
                        throw new Exception(CXMessage.ME00021);//Client Data not Found.
                    }

                }
                else
                {
                    throw new Exception(CXMessage.ME00021);//Client Data not Found.
                }
            }
        }

        public string AllAccountParameterCheck(string accountNo)
        {
            if (!string.IsNullOrEmpty(accountNo))
            {
                int accountNoLength = accountNo.Length;
                string[] accountVariable = this.SplitString(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountParameterCheck));
                if (accountVariable.Length > 0)
                {
                    IList<PFMDTO00057> values = this.SelectNewSetupListByVariable(accountVariable);
                    if (values.Count > 0)
                    {
                        foreach (PFMDTO00057 value in values)
                        {
                            if (Convert.ToInt32(value.Value) == accountNoLength)
                                return value.Variable;
                        }
                        return string.Empty;
                    }
                    else
                    {
                        throw new Exception(CXMessage.ME00039);//AccountCode Length Format not found.
                    }

                }
                else
                {
                    throw new Exception(CXMessage.ME00038);//AccountCode Format not found.
                }

            }

            else
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter
            }
        }
        public bool CheckAccountNoType(string accountNo, CXDMD00011 accountNoType)
        {
            if (!string.IsNullOrEmpty(accountNo))
            {
                int accountNoLength = accountNo.Length;
                PFMDTO00057 newSetupDTO = new PFMDTO00057();
               
                switch (accountNoType)
                { 
                    case CXDMD00011.AccountNoType1:
                        newSetupDTO = CXCLE00002.Instance.GetClientData<PFMDTO00057>("NewSetup.Client.SelectValueByVariable", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoType1Length) });
                        break;
                    case CXDMD00011.AccountNoType2:
                        newSetupDTO = CXCLE00002.Instance.GetClientData<PFMDTO00057>("NewSetup.Client.SelectValueByVariable", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoType2Length) });
                        break;
                    case CXDMD00011.DomesticAccountType:
                        newSetupDTO = CXCLE00002.Instance.GetClientData<PFMDTO00057>("NewSetup.Client.SelectValueByVariable", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.DomesticAccountTypeLength) });
                        break;
                }
                return accountNoLength.Equals(Convert.ToInt32(newSetupDTO.Value)) ? true : false;
            }
            else
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter
            }
        }       
        public bool LedgerTypeParameterCheck(CXDMD00007 ledgerTypeConst, IList<CXDTO00004> amounts)
        {
            bool isValid = false;
            if (ledgerTypeConst.Equals(CXDMD00007.baCash))
            {
                isValid = true;
            }

            else if (ledgerTypeConst.Equals(CXDMD00007.baJournal))
            {
                if (amounts.Count > 0)
                {
                    decimal debitAmount = 0;
                    decimal creditAmount = 0;

                    for (int i = 0; i < amounts.Count; i++)
                    {

                        if (amounts[i].DebitCreditTransaction.Equals(CXDMD00002.Debit))
                        {
                            debitAmount = debitAmount + amounts[i].Amount;

                        }

                        if (amounts[i].DebitCreditTransaction.Equals(CXDMD00002.Credit))
                        {
                            creditAmount = creditAmount + amounts[i].Amount;
                        }
                    }
                    isValid = (debitAmount == creditAmount) ? true : false;
                }
                else
                {
                    throw new Exception(CXMessage.ME90018);//Invalid Parameter.
                }
            }
            return isValid;
        }

        /// <summary>
        /// TransactionCode Parameter Checking
        /// </summary>
        /// <param name="transactionCode"></param>
        /// <param name="currencyStatus"></param>
        /// <param name="currencyReference"></param>
        /// <returns></returns>
        //confirm select from database where parameter value can be null or not.
        public bool TransactionCodeParameterCheck(string transactionCode)
        {
            if (!string.IsNullOrEmpty(transactionCode))
            {
                TLMDTO00005 transactionTypeDTO = CXCLE00002.Instance.GetScalarObject<TLMDTO00005>("CXCLE00012.TranType.Client.SelectByTranCode", new object[] { transactionCode });
                return transactionTypeDTO == null ? false : true;
            }
            else
            {
                throw new Exception(CXMessage.ME90018);
            }

        }

        /// <summary>
        /// AmtOamt Parameter Check
        /// </summary>
        /// <param name="accountNo"></param>
        /// <param name="actionAmount"></param>
        /// <param name="debitCreditTransaction"></param>
        /// <returns></returns>
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


        //To Convert Number From Amount Textbox to Words
        /// <summary>
        /// Calculate Amount to Words.(44580.70 ,KYT) => Forty-Four Thousand ,Five Hundred ,and Eighty KYATs and Seven PYAs Only)
        /// </summary>
        /// <param name="Amount"></param>
        /// <param name="curType"></param>
        /// <returns>string</returns>
        public string CalculateAmountToWords(double Amount, string curType)
        {
            string point = string.Empty;
            string firstamount = string.Empty;
            string str = Amount.ToString();
            string[] answers = str.Split(new string[] { ".", " " }, StringSplitOptions.RemoveEmptyEntries);

            if (answers.Length > 1)
            {
                firstamount = this.NumberToWords(Convert.ToInt64(answers[0]));
                if ((Convert.ToInt32(answers[1])) > 0)
                {
                    point = this.NumberToWords(Convert.ToInt64(answers[1]));
                }
            }
            else
            {
                firstamount = this.NumberToWords(Convert.ToInt64(answers[0]));
            }
            CurrencyDTO currecy = CXCLE00002.Instance.GetScalarObject<CurrencyDTO>("Cur.DescriptioninWords.Select", new object[] { curType, true });
            if (currecy != null)
            {
                Ctype1 = currecy.Cur;
                Ctype2 = currecy.Symbol;
            }

            this.ReportAmountInword = firstamount + " " + Ctype1 + "S";
            if (string.IsNullOrEmpty(point))
            {
                this.ReportAmountInword += " Only";
            }
            else
            {
                this.ReportAmountInword += " " + point + " " + Ctype2 + "S " + "Only";
            }
            return ReportAmountInword;
        }     

        #endregion

      
       
    }
}

