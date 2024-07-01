using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Cx.Com.Utt
{
    /// <summary>
    /// Code Format Checker by Regular Expresson and CheckDigit Generator and Checker Utilities (Account No,etc.)
    /// </summary>
    public class CXCOM00006
    {
        #region Private Variables
        private static CXCOM00006 instance = null;
        private bool isValidate = false;
        #endregion

        #region Properties
        /// <summary>
        /// CXClientData Singleton Object
        /// </summary>
        public static CXCOM00006 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = SpringApplicationContext.Instance.Resolve<CXCOM00006>("CXCOM00006");
                }

                return instance;
            }
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Validate your code by your code format(Regular Expression...)
        /// And validate checkdigit of your code by your checkdigit formula
        /// </summary>
        /// <param name="codeValue">Your code value</param>
        /// <param name="formatCode">Your code format (Regular Expression Code) that is from AppSettings</param>
        /// <param name="checkDigitFormula">Your checkdigit formula that is from AppSettings</param>
        /// <returns>Return true if your code is valid or return false.</returns>
        public bool Validate(string codeValue, string formatCode, string checkDigitFormula)
        {
            try
            {
                string patterns = CXCOM00007.Instance.GetValueByKeyName(formatCode);

                Match match = Regex.Match(codeValue, patterns);

                if (match.Success == false)
                {
                    return false;
                }

                if (string.IsNullOrEmpty(checkDigitFormula) == false)
                {
                    this.isValidate = true;
                    int checkDigitNumber = Convert.ToInt32(codeValue[codeValue.Length - 1].ToString());
                    int checkNumber = this.GenerateCheckDigitNumber(codeValue, checkDigitFormula);

                    return checkDigitNumber == checkNumber;
                }
            }
            catch (Exception exp)
            {
                throw new Exception(CXMessage.ME90012, exp);
            }
            finally
            {
                this.isValidate = false;
            }
            
            return true;
        }

        /// <summary>
        /// Validate your code by your code format(Regular Expression...)
        /// </summary>
        /// <param name="codeValue">Your code value</param>
        /// <param name="formatCode">Your code format (Regular Expression Code) that is from AppSettings</param>
        /// <returns>Return true if your code is valid or return false.</returns>
        public bool Validate(string codeValue, string formatCode)
        {
            try
            {
                string patterns = CXCOM00007.Instance.GetValueByKeyName(formatCode);

                Match match = Regex.Match(codeValue, patterns);

                if (match.Success == false)
                {
                    return false;
                }
            }
            catch (Exception exp)
            {
                throw new Exception(CXMessage.ME90012, exp);
            }

            return true;
        }

        /// <summary>
        /// Generate checkdigit number for your code by checkdigit formula
        /// </summary>
        /// <param name="codeValue">Your code value</param>
        /// <param name="checkDigitFormula">Your checkdigit formula that is from AppSettings</param>
        /// <returns>Return checkdigit number</returns>
        public int GenerateCheckDigitNumber(string codeValue, string checkDigitFormula)
        {
            int digit = 0;
            int totalAccountNo = 0;
            int totalPrimeNo = 0;
            int totalNo = 0;
            List<int> primeNumbers;
            primeNumbers = SpringApplicationContext.Instance.Resolve<List<int>>(CXCOM00007.Instance.GetValueByKeyName(checkDigitFormula));

            try
            {
                if (string.IsNullOrEmpty(codeValue))
                {
                    throw new Exception(CXMessage.ME90009);
                }

                int primeCount = this.isValidate ? primeNumbers.Count + 1 : primeNumbers.Count;
                if (codeValue.Length != primeCount)
                {
                    throw new Exception(CXMessage.ME90010);
                }

                for (int i = 0; i < primeNumbers.Count; i++)
                {
                    totalAccountNo = Convert.ToInt32(codeValue[i]);
                    totalPrimeNo = primeNumbers[i];
                    totalNo += totalAccountNo * totalPrimeNo;
                }

                digit = totalNo % 10;
                return digit;
            }
            catch (Exception exp)
            {
                throw new Exception(CXMessage.ME90011, exp);
            }
        }

        public Boolean isCurrentAccount(string accountNo, string AccountTypePosition)
        {
            int accountTypePosition =Convert.ToInt32( CXCOM00007.Instance.GetValueByKeyName(AccountTypePosition));
            int accountType1 = Convert.ToInt32(accountNo.Substring(accountTypePosition-1, 1));
            int accountType2 = Convert.ToInt32( CXCOM00010.Instance.GetSymbolByAccountType("Current"));
            if (accountType1 == accountType2)
            {
                return true;
            }
            else return false;
        }

        public Boolean isSavingAccount(string accountNo,string AccountTypePosition)
        {
            int accountTypePosition = Convert.ToInt32(CXCOM00007.Instance.GetValueByKeyName(AccountTypePosition));
            int accountType1 = Convert.ToInt32(accountNo.Substring(accountTypePosition-1, 1));
            int accountType2 = Convert.ToInt32(CXCOM00010.Instance.GetSymbolByAccountType("Saving"));
            if (accountType1 == accountType2)
            {
                return true;
            }
            else return false;
            
        }

        /// <summary>
        /// Check Date must not be greather than Today date.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        /// CheckTodayDate
        public bool IsExceedTodayDate(DateTime date)
        {
            return (date.Date > DateTime.Now.Date) ? true : false;
        }

        /// <summary>
        /// Check Date must betweeen in Start Date and End Date .
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public bool IsValidStartDateEndDate(DateTime startDate, DateTime endDate)
        {
            TimeSpan ts = new TimeSpan ();
         
                 ts = endDate.Date.Subtract(startDate.Date);
          
        

                if (this.IsExceedTodayDate(startDate))
            {
                throw new Exception(CXMessage.MV00129);//Start Date must not be greater than today.
            }
            else if (this.IsExceedTodayDate(endDate))
            {
                throw new Exception(CXMessage.MV00130);//End Date must not be greater than today.
            }
                else if (ts.TotalDays < 0)
                {
                    throw new Exception(CXMessage.MV00220);
                    
                }
                else
                {
                    return true;
                }

        }

        /// <summary>
        /// Get require Date Format Needed.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public string GetDateFormat(DateTime date)
        {
            return String.Format("{0:d/M/yyyy}", date);
        }

        #endregion
    }
}
