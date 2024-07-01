using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.Admin.DataModel;
using Spring.Stereotype;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Cx.Ser.Sve
{
    /// <summary>
    /// Code Generator (Account, Customer, ....)
    /// </summary> 
    [Service]
    public class CXSVE00002 : BaseService, ICXSVE00002
    {
        #region Private Variables
        private ICXDAO00002 codeGeneratorDAO;
        #endregion

        #region Properties
        public ICXDAO00002 CodeGeneratorDAO
        {
            get { return this.codeGeneratorDAO; }
            set { this.codeGeneratorDAO = value; }
        }
        #endregion

        #region Public Methods
        [Transaction(TransactionPropagation.Required)]
        public string GetGenerateCode(string formatCode, string checkDigitFormula, int updatedUserId,string branchCode, params dynamic[] inputFormatDefinition)
        {
            string code = string.Empty;
            try
            {
                if (formatCode != null || formatCode.Trim() != string.Empty)
                {
                    int maxId = 0;
                    string maxItemId = string.Empty;
                    byte[] tS = null;
                    string maxValue = string.Empty;

                    IList<FormatDefinition> formatDefinitionList = this.codeGeneratorDAO.SelectFormatDefinitonByFormatCode(formatCode,branchCode);
                    if (formatDefinitionList != null)
                    {
                        var isValue = from value in formatDefinitionList
                                      where value.IsValue == true
                                      orderby value.Position ascending
                                      select value;
                        int a = isValue.Count();
                        if (isValue.Count() > 0)
                        {
                            if (inputFormatDefinition.Count().Equals(isValue.Count()))
                            {
                                if (!this.IsValidParameterValue(inputFormatDefinition, isValue.ToList()))
                                {
                                    throw new Exception(CXMessage.ME90018);
                                }
                            }
                            else
                                throw new Exception(CXMessage.ME90019);
                        }


                        int i = 0;
                        foreach (FormatDefinition format in formatDefinitionList)
                        {
                            if (format.Prefix != null)
                            {
                                code += format.Prefix;
                            }
                            if (format.IsValue)
                            {
                                code += inputFormatDefinition[i].ToString();
                                i++;
                            }
                            if (format.IsIncrement)
                            {
                                maxValue = this.GetSerialNo(format);
                                maxId = format.Id;
                                tS = format.TS;
                                code += maxValue;

                            }
                            if (format.Suffix != null)
                            {
                                code += format.Suffix;
                            }
                            if (format.IsCheckDigit)
                            {
                                if(!string.IsNullOrEmpty(checkDigitFormula))
                                    code += CXCOM00006.Instance.GenerateCheckDigitNumber(code, checkDigitFormula); 
                            }
                        }

                        // update formatdefinition table
                        if (this.codeGeneratorDAO.FormatDefinitionUpdate(maxId, maxValue,branchCode, updatedUserId, DateTime.Now, tS) == false)
                        {
                            throw new Exception(CXMessage.ME90022);
                        }

                    }
                    else
                        throw new Exception(CXMessage.ME90020);
                }
                else
                    throw new Exception(CXMessage.ME90021);
            }
            catch (Exception exp)
            {
                throw new Exception(CXMessage.ME90022, exp);
            }
            return code;
        }

        public string GetAccountNoFormatCode(string transactionType, string currencyCode)
        {
            return transactionType + "." + currencyCode;
        }
        #endregion

        #region Private Methods
        private string GetSerialNo(FormatDefinition format)
        {
            try
            {
                string maximumValue = (Convert.ToInt32(format.MaximumValue) + 1).ToString();

                if (format.IsZeroLeading)
                {
                    string serialNo = maximumValue.PadLeft(format.Length, '0');
                    return serialNo;
                }
                else
                {
                    return maximumValue;
                }


            }
            catch (Exception exp)
            {
                throw new Exception(CXMessage.ME90023, exp);
            }

        }

        private bool IsValidParameterValue(dynamic[] inputFormatDefinition, IList<FormatDefinition> formatDefinitionList)
        {
            int i = 0;
            foreach (FormatDefinition formatDefinition in formatDefinitionList)
            {
                if (inputFormatDefinition[i].ToString().Length != formatDefinition.Length)
                {
                    return false;
                }
                i++;
            }
            return true;
        }
        #endregion
    }
}
