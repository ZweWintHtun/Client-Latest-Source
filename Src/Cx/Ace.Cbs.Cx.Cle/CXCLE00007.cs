using System;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Cx.Cle
{
    /// <summary>
    /// Client Global Utilities
    /// </summary>
    public class CXCLE00007
    {
        /// <summary>
        /// Get Cheque End No By Start No
        /// </summary>
        /// <param name="startNo">Your Cheque Book Start No</param>
        /// <returns>If start no is wrong, return "-1", or return End No</returns>
        public static string GetChequeEndNo(string startNo)
        {
            int startNumber = 0;

            try
            {
                startNumber = Convert.ToInt32(startNo);
                int chequeSerializeNumber = Convert.ToInt32(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ChequeNoSerialNumber));

                int modulus = startNumber % chequeSerializeNumber;

                if (modulus == 1)
                {
                    startNumber += (chequeSerializeNumber - 1);
                    if (startNumber > Convert.ToInt32(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ChequeNoMaximumValue)))
                    {
                        return "-2";
                    }
                }
                else
                {
                    return "-1";
                }
            }
            catch 
            {
                return "-1";
            }

            return GetFormatString(startNumber, CXCOM00009.ChequeNoDisplayFormat);
        }

        /// <summary>
        ///  Check given start no and end no are valid or not.
        /// </summary>
        /// <param name="startNo">Your cheque start no</param>
        /// <param name="endNo">Your cheque start no</param>
        /// <returns>Return ture if cheque start no and end no are valid, or return false.</returns>
        public static bool IsValidChequeEndNo(string startNo, string endNo)
        {
            int range = Convert.ToInt32(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ChequeNoSerialNumber));
            int actualStartNo = (Convert.ToInt32(startNo) / range) * range;
            int actualEndNo = actualStartNo + range;

            return Convert.ToInt32(endNo) >= (actualStartNo+1) && Convert.ToInt32(endNo) <= actualEndNo;
        }

        /// <summary>
        /// Get Formatted string value
        /// </summary>
        /// <param name="value">Your integer value</param>
        /// <param name="codeFormat">Your code format that is from AppSettings</param>
        /// <returns>Return formatted string value</returns>
        public static string GetFormatString(int value, string codeFormat)
        {
            return string.Format(CXCOM00007.Instance.GetValueByKeyName(codeFormat), value);
        }

        /// <summary>
        /// Get Formatted string value
        /// </summary>
        /// <param name="value">Your integer value</param>
        /// <param name="codeFormat">Your code format that is from AppSettings</param>
        /// <returns>Return formatted string value</returns>
        public static string GetFormatStringBy999(string value, string codeFormat)
        {
            string returnValue = string.Empty;
            int valueCount = 0;

            for (int i = 0; i < codeFormat.Length; i++)
            {
                if (codeFormat[i] != '9' && codeFormat[i] != '&')
                {
                    returnValue += codeFormat[i];
                }
                else
                {
                    returnValue += value[valueCount++];
                }
            }

            return returnValue;
        }

        public static bool CheckAmountFormat(int maximunLength, int decimalPlaces,decimal currentValue)
        {
            string strRoundedValue = currentValue.ToString();

            if (!strRoundedValue.Contains("."))
            {
                if (strRoundedValue.Length > maximunLength)
                {
                    return false;
                }
            }
            else
            {
                strRoundedValue = strRoundedValue.Substring(0, strRoundedValue.LastIndexOf("."));

                if (strRoundedValue.Length > maximunLength)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
