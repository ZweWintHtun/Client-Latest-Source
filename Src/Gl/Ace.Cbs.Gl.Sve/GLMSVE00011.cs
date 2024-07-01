using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Gl.Ctr.Sve;
using Ace.Windows.Core.Service;
using Ace.Cbs.Gl.Dmd;
using Ace.Cbs.Gl.Ctr.Dao;

namespace Ace.Cbs.Gl.Sve
{
    class GLMSVE00011 : BaseService, IGLMSVE00011
    {
        public IGLMDAO00014 FormatFileDAO { get; set; }

        public IList<GLMDTO00001> SelectAllFormatFile(string formatStatus)
        {
            IList<GLMDTO00001> formatFileList = this.FormatFileDAO.SelectAllByFormatStatus(formatStatus);
            if (formatFileList.Count > 0)
            {
                IList<GLMDTO00001> tempList = new List<GLMDTO00001>();
                string tempFormatType = string.Empty;

                #region Distinct
                formatFileList = formatFileList.OrderBy(x => x.FormatType).ToList();
                
                for (int i = 0; i < formatFileList.Count; i++)
                {
                    if (i == 0)
                    {
                        tempList.Add(formatFileList[i]);
                    }
                    else
                    {
                        if (formatFileList[i - 1].FormatType == formatFileList[i].FormatType)
                            continue;
                        else
                            tempList.Add(formatFileList[i]);
                    }
                        
                }
                formatFileList = tempList;
                #endregion
            }
            return formatFileList;
        }

        public IList<GLMDTO00001> GetPreViewData(int month, string formatType, string formatStatus, string cur)
        {
            IList<GLMDTO00001> formatFileInfos = new List<GLMDTO00001>();
            formatFileInfos = this.FormatFileDAO.SelectFormatFileByFormatTypeAndFormatStatus(formatType, formatStatus);
            IList<GLMDTO00001> formatFileList = (from value in formatFileInfos

                              where !string.IsNullOrEmpty(value.ACode)
                              select value).ToList();


            //IList<GLMDTO00001> formatFileList = (from value in formatFileInfos

            //                                     where !string.IsNullOrEmpty(value.ACode)
            //                                     select value).ToList();
                       
            IList<string> acodeList = new List<string>();
            IList<string> dcodeList = new List<string>();
            if (formatFileList.Count > 0)
            {
                foreach (GLMDTO00001 formatFile in formatFileList)
                {
                    acodeList.Add(formatFile.ACode);
                    dcodeList.Add(formatFile.DCode);
                }

                if (string.IsNullOrEmpty(cur))
                {
                    string requiredMonth = month < 4 ? "MSRC" + (month + 9).ToString() : "MSRC" + (month - 3).ToString();
                    string bfRequiredMonth = month < 4 ? "BFSRC" + (month + 9).ToString() : "BFSRC" + (month - 3).ToString();
                    IList<GLMDTO00001> sumList = this.FormatFileDAO.SelectCCOASumAmountByAcodeAndDcode(acodeList, dcodeList, requiredMonth, bfRequiredMonth);
                    for (int i = 0; i < sumList.Count; i++)
                    {
                        for (int j = 0; j < formatFileList.Count; j++)
                        {
                            if (sumList[i].ACode == formatFileList[j].ACode && sumList[i].DCode == formatFileList[j].DCode)
                            {
                                formatFileList[j].CBal = sumList[i].CBal;
                                formatFileList[j].BFAmount = sumList[i].BFAmount;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    string requiredMonth = month < 4 ? "M" + (month + 9).ToString() : "M" + (month - 3).ToString();
                    string bfRequiredMonth = month < 4 ? "BF" + (month + 9).ToString() : "BF" + (month - 3).ToString();
                    IList<GLMDTO00001> amountList = this.FormatFileDAO.SelectCCOAAmountByCurAndAcodeAndDcode(acodeList, dcodeList, requiredMonth, bfRequiredMonth, cur);
                    for (int i = 0; i < amountList.Count; i++)
                    {
                        for (int j = 0; j < formatFileList.Count; j++)
                        {
                            if (amountList[i].ACode == formatFileList[j].ACode && amountList[i].DCode == formatFileList[j].DCode)
                            {
                                formatFileList[j].CBal = amountList[i].CBal;
                                formatFileList[j].BFAmount = amountList[i].BFAmount;
                                break;
                            }
                        }
                    }
                }

                IList<GLMDTO00001> tempFormatFileList = new List<GLMDTO00001>();

                tempFormatFileList = this.FormatFileDAO.SelectFormatFileByFormatTypeAndFormatStatusAndStatus(formatType, formatStatus, "LR");
                foreach (GLMDTO00001 formatFile in tempFormatFileList)
                {
                    var Cbal = from x in formatFileList where x.LineNo >= Convert.ToInt32(formatFile.LineRange1) && x.LineNo <= Convert.ToInt32(formatFile.LineRange2) select x.CBal;
                    decimal sumCBAL = Cbal.Sum();
                    IList<GLMDTO00001> tempList = formatFileList.Where(x => x.LineNo == formatFile.LineNo).ToList();
                    foreach (GLMDTO00001 item in tempList)
                    {
                        item.CBal = sumCBAL;
                    }
                }

                tempFormatFileList = this.FormatFileDAO.SelectFormatFileByFormatTypeAndFormatStatusAndStatus(formatType, formatStatus, "O");
                foreach (GLMDTO00001 formatFile in tempFormatFileList)
                {
                    decimal sumCBAL = 0;
                    if (formatFile.Other.Contains('+'))
                    {
                        string[] amountArr = formatFile.Other.Split('+');
                        sumCBAL = Convert.ToDecimal(amountArr[0]) + Convert.ToDecimal(amountArr[1]);
                    }
                    else if (formatFile.Other.Contains('-'))
                    {
                        string[] amountArr = formatFile.Other.Split('-');
                        sumCBAL = Convert.ToDecimal(amountArr[0]) - Convert.ToDecimal(amountArr[1]);
                    }
                    else if (formatFile.Other.Contains('*'))
                    {
                        string[] amountArr = formatFile.Other.Split('*');
                        sumCBAL = Convert.ToDecimal(amountArr[0]) * Convert.ToDecimal(amountArr[1]);
                    }
                    else if (formatFile.Other.Contains('/'))
                    {
                        string[] amountArr = formatFile.Other.Split('/');
                        sumCBAL = Convert.ToDecimal(amountArr[0]) / Convert.ToDecimal(amountArr[1]);
                    }

                    if (sumCBAL != 0)
                    {
                        IList<GLMDTO00001> tempList = formatFileList.Where(x => x.LineNo == formatFile.LineNo).ToList();
                        foreach (GLMDTO00001 item in tempList)
                        {
                            item.CBal = sumCBAL;
                        }
                    }
                }

                return formatFileList;
            }

            return formatFileList;
        }
    }
}
