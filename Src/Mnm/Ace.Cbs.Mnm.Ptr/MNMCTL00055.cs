//----------------------------------------------------------------------
// <copyright file="Cash Control By Counter" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Khin Swe Win</CreatedUser>
// <CreatedDate>30/07/2014</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Mnm.Dmd;
using System.Linq;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Windows.Admin.DataModel;
using System.Data;

namespace Ace.Cbs.Mnm.Ptr
{
    public class MNMCTL00055 : AbstractPresenter, IMNMCTL00055
    {
        #region Data View 
        public string _counterType { get; set; }
        private string ReportTitle { get; set; }
        private bool IsPaymentCounter { get; set; }

        #endregion

        private IMNMVEW00055 view;
        public IMNMVEW00055 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private void WireTo(IMNMVEW00055 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetViewData());
                
            }
        }

        private MNMDTO00001 GetViewData()
        {
            MNMDTO00001 dto = new MNMDTO00001();
            dto.Currency = this.view.Currency;
            dto.DataComboBoxString = this.view.CounterNo;
            //dto.Date_time = this.view.EndDateTime;
            return dto;
        }


        #region Method
        //To get All Counters by Source Branch Code in database.
        public IList<CounterInfoDTO> GetAllCounterListBySourceBranchCode()
        {
            IList<CounterInfoDTO> CounterList = new List<CounterInfoDTO>();
            IList<CounterInfoDTO> CounterDataList = new List<CounterInfoDTO>();
            CounterList = CXClientWrapper.Instance.Invoke<ITLMSVE00004, CounterInfoDTO>(x => x.GetAllCounterInfoListBySourceBranchCode(CurrentUserEntity.BranchCode));
            if (CounterList.Count > 0)
            {
                int j = 0;

                CounterDataList.Add(CounterList[0]);
                if (CounterList.Count > 1)
                {
                    do
                    {
                        string accountNo = CounterList[j].CounterNo;
                        j++;
                        if (accountNo != CounterList[j].CounterNo)
                            CounterDataList.Add(CounterList[j]);


                    } while (j != CounterList.Count - 1);
                }
            }

            return CounterDataList;
        }

        public void ClearUIControl()
        {
            this.view.Currency = string.Empty;
            this.view.CounterNo = string.Empty;
            this.ClearAllCustomErrorMessage();
        }

        public void ClearCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }

        private string GetParameterValue()
        {
            string sourceBr=CurrentUserEntity.BranchCode;

            string whereString = " WHERE CONVERT(CHAR(10),CASHDATE,111) = " + " '" + this.view.EndDateTime.ToString("yyyy/MM/dd") + "'" + " and CUR = " + " '" + this.view.Currency + "'" + " and BRANCHCODE= " + " '" + sourceBr + "'";
            if (this.view.IsReversal)
            {
                whereString = whereString + " AND REVERSE =0 ";
            }
            this.ReportTitle = "COUNTER NO. (" + this.view.CounterNo + ") REGISTER By " + this.view.EndDateTime.ToString("dd/MM/yyyy") + " " + ((this.view.IsReversal) ? "(Before Editing)" : "(Edited)");
            whereString = whereString + " AND COUNTERNO =" + "'" + this.view.CounterNo + "'" + " AND Active=1 ";

            return whereString;

        }

        public string[] IntializeValue(string[] list, string firstindexword)
        {
            list[0] = firstindexword;
            for (int i = 1; i < list.Length; i++)
            {
                list[i] = "0";
            }
            return list;
        }

        public List<string[]> GetVaultTransaction(List<string[]> cashlist, int denoCount)
        {
            List<string[]> VaultTransactionList = new List<string[]>();
            foreach (string[] rowvalue in cashlist)
            {
                if (rowvalue[1].Substring(0, 1).Equals("V"))
                {
                    string[] vaultrow = new string[7 + denoCount];
                    vaultrow[0] = rowvalue[1];
                    vaultrow[1] = rowvalue[3];
                    vaultrow[2] = rowvalue[8];
                    // vaultrow[2] = rowvalue[8] + "-" + rowvalue[9] ;
                    int y = 3;
                    for (int i = 16; i < rowvalue.Length; i++)
                    {
                        vaultrow[y] = rowvalue[i];
                        y++;
                    }
                    //
                    vaultrow[y] = rowvalue[6].Remove(rowvalue[6].Length - 3, 3);
                    vaultrow[y + 1] = rowvalue[7];
                    decimal vaultvalue = Convert.ToDecimal(vaultrow[y]) + (Convert.ToDecimal(vaultrow[y + 1]) / 100);
                    //_counterType = rowvalue[4];

                    _counterType = cashlist[0][10];
                    //if (rowvalue[10].Equals("R")) 
                    if (rowvalue[4].Equals("R"))     
                    {
                        vaultrow[y + 2] = vaultvalue.ToString();
                        vaultrow[y + 3] = "0";
                    }
                    else
                    {
                        vaultrow[y + 2] = "0";
                        vaultrow[y + 3] = vaultvalue.ToString();
                    }
                    VaultTransactionList.Add(vaultrow);
                }
            }
            return VaultTransactionList;
        }

        #endregion 

        #region Custom Validation
        public void cboCurrency_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (String.IsNullOrEmpty(this.view.CounterNo))
            {
               
                    this.SetCustomErrorMessage(this.GetControl("cboCounterNo"), "MV00115");
                    return;
              
            }
            else
            {
                this.SetCustomErrorMessage(this.GetControl("cboCounterNo"), string.Empty);
                return;
            }

        }
        #endregion

        public void PrintExel()
        {
            if (this.ValidateForm(this.GetViewData()))
            {
                string whereString = this.GetParameterValue();
                List<string[]> cashlist = new List<string[]>();
                List<string[]> cashrefundlist = new List<string[]>();
                List<string[]> rowValueListString = new List<string[]>();
                List<string[]> VaultTransactionList = new List<string[]>();
                CXCLE00004 excelfomat = new CXCLE00004();

                decimal RpAmount = 0;
                decimal RpCoin = 0;
                decimal RefundAmount = 0;
                decimal RefundCoin = 0;

                if (view.CounterNo.Substring(0, 1) == "P")
                {
                    IsPaymentCounter = true;
                }
                else
                {
                    IsPaymentCounter = false;
                }

                #region Raw_Data

                //Get Report Data from SP_CASHCONTROLREPORT
                IList<object> result = CXClientWrapper.Instance.Invoke<ITLMSVE00071, IList<object>>(x => x.CashControlReport(this.view.Currency, whereString));
                IList<object> refundResult = CXClientWrapper.Instance.Invoke<ITLMSVE00071, IList<object>>(x => x.CashControlRefundList(this.view.Currency, whereString));
                string Date = CXClientWrapper.Instance.Invoke<ITLMSVE00071, string>(x => x.GetMaxDate(this.view.EndDateTime.ToString("yyyy/MM/dd")));
                if (result == null || result.Count <= 0)
                {
                    CXUIMessageUtilities.ShowMessageByCode("MI00039");  //No Data For Report
                    return;
                }

                for (int i = 0; i < result.Count; i++)
                {
                    object[] a = (object[])result[i];
                    string[] b = Array.ConvertAll(a, p => (p ?? String.Empty).ToString());
                    cashlist.Add(b);
                }
                #endregion

                //Get Branch Information
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

                //Get Deno Columns
                List<string> denolist = CXClientWrapper.Instance.Invoke<ITLMSVE00071, IList<string>>(x => x.SelectDenoDescriptionByCurrency(this.view.Currency)).ToList();
                IList<TLMDTO00012> DenoValue = CXCLE00002.Instance.GetListObject<TLMDTO00012>("Deno.SelectByCurrencyCode", new object[] { this.view.Currency, true });
                VaultTransactionList = this.GetVaultTransaction(cashlist, denolist.Count);

                string[] CashControlReceiveTotal = new string[5 + denolist.Count];
                string[] CashControlRefundTotal = new string[5 + denolist.Count];
                string[] CashControlNoteChangeDeposit = new string[5 + denolist.Count];
                string[] CashControlNoteChangeWithdrawal = new string[5 + denolist.Count];
                string[] CashControlGrandTotal = new string[5 + denolist.Count];
                string[] CashControlCounterBalance = new string[5 + denolist.Count];

                CashControlReceiveTotal = this.IntializeValue(CashControlReceiveTotal, "Receive Total");
                CashControlRefundTotal = this.IntializeValue(CashControlRefundTotal, "Refund Total");
                CashControlNoteChangeDeposit = this.IntializeValue(CashControlNoteChangeDeposit, "Note Change Deposit");
                CashControlNoteChangeWithdrawal = this.IntializeValue(CashControlNoteChangeWithdrawal, "Note Change Withdrawal");
                CashControlGrandTotal = this.IntializeValue(CashControlGrandTotal, "Grand Total");
                CashControlCounterBalance = this.IntializeValue(CashControlCounterBalance, "Counter Balance");


                #region For Refund Amount

                if (refundResult != null && refundResult.Count > 0)
                {
                    for (int i = 0; i < refundResult.Count; i++)
                    {
                        object[] a = (object[])refundResult[i];
                        string[] b = Array.ConvertAll(a, p => (p ?? String.Empty).ToString());
                        cashrefundlist.Add(b);
                    }

                    foreach (string[] refund in cashrefundlist)
                    {
                        int y = 0;
                        for (int i = 16; i < refund.Length; i++)
                        {
                            RefundAmount += Convert.ToDecimal(refund[i]) * Convert.ToDecimal(DenoValue[y].D1);
                            RefundCoin += Convert.ToDecimal(refund[i]) * Convert.ToDecimal(DenoValue[y].D2);
                            y++;
                        }
                    }
                }

                #endregion

                #region For Cash Deno

                foreach (string[] rowValue in cashlist)
                {
                    int x = 0; int y = 16;
                    for (int i = 16; i < rowValue.Length; i++)
                    {
                        ++x; ++y;
                        if (rowValue[1].Substring(0, 1) != "V" && rowValue[1].Substring(0, 1) != "N")
                        {
                            if (rowValue[10].Substring(0, 1).Equals(rowValue[4]))
                                CashControlReceiveTotal[x] = (Convert.ToInt32((String.IsNullOrEmpty(CashControlReceiveTotal[x])) ? "0" : CashControlReceiveTotal[x]) + Convert.ToInt32(rowValue[i])).ToString();
                            else
                                CashControlReceiveTotal[x] = (Convert.ToInt32((String.IsNullOrEmpty(CashControlReceiveTotal[x])) ? "0" : CashControlReceiveTotal[x]) - Convert.ToInt32(rowValue[i])).ToString();
                        }

                        if (rowValue[1].Substring(0, 1) == "N" && rowValue[4].Substring(0, 1) == "R")
                        {
                            CashControlNoteChangeDeposit[x] = (Convert.ToInt32((String.IsNullOrEmpty(CashControlNoteChangeDeposit[x])) ? "0" : CashControlNoteChangeDeposit[x]) + Convert.ToInt32(rowValue[i])).ToString();
                        }

                        if (rowValue[1].Substring(0, 1) == "N" && rowValue[4].Substring(0, 1) == "P")
                        {
                            CashControlNoteChangeWithdrawal[x] = (Convert.ToInt32((String.IsNullOrEmpty(CashControlNoteChangeWithdrawal[x])) ? "0" : CashControlNoteChangeWithdrawal[x]) + Convert.ToInt32(rowValue[i])).ToString();
                        }
                        if (rowValue[4].Substring(0, 1) == "R")
                        {
                            CashControlCounterBalance[x] = (Convert.ToInt32((String.IsNullOrEmpty(CashControlCounterBalance[x])) ? "0" : CashControlCounterBalance[x]) + Convert.ToInt32(rowValue[i])).ToString();
                        }
                        else
                        {
                            CashControlCounterBalance[x] = (Convert.ToInt32((String.IsNullOrEmpty(CashControlCounterBalance[x])) ? "0" : CashControlCounterBalance[x]) - Convert.ToInt32(rowValue[i])).ToString();
                        }
                    }

                #endregion

                #region Amount n Coin
                    RpAmount = (String.IsNullOrEmpty(rowValue[6]) ? 0 : Convert.ToDecimal(rowValue[6].Remove(rowValue[6].Length - 3, 3)));
                    RpCoin = (String.IsNullOrEmpty(rowValue[7]) ? 0 : Convert.ToDecimal(rowValue[7]));

                    CashControlGrandTotal[x + 1] = ((String.IsNullOrEmpty(CashControlGrandTotal[x + 1]) ? 0 : Convert.ToDecimal(CashControlGrandTotal[x + 1])) + RpAmount).ToString();
                    CashControlGrandTotal[x + 2] = ((String.IsNullOrEmpty(CashControlGrandTotal[x + 2]) ? 0 : Convert.ToDecimal(CashControlGrandTotal[x + 2])) + RpCoin).ToString();



                    if (!rowValue[1].Substring(0, 1).Equals("V"))
                    {
                        //if(rowValue[10].Substring(0,1).Equals(rowValue[4]))
                        CashControlReceiveTotal[x + 1] = ((String.IsNullOrEmpty(CashControlReceiveTotal[x + 1]) ? 0 : Convert.ToDecimal(CashControlReceiveTotal[x + 1])) + RpAmount).ToString();
                        //else
                        //CashControlReceiveTotal[x + 1] = ((String.IsNullOrEmpty(CashControlReceiveTotal[x + 1]) ? 0 : Convert.ToDecimal(CashControlReceiveTotal[x + 1])) - RpAmount).ToString();
                    }

                    if (!rowValue[1].Substring(0, 1).Equals("V") && !rowValue[1].Substring(0, 1).Equals("N"))
                    {
                        CashControlReceiveTotal[x + 2] = ((String.IsNullOrEmpty(CashControlReceiveTotal[x + 2]) ? 0 : Convert.ToDecimal(CashControlReceiveTotal[x + 2])) + RpCoin).ToString();
                    }

                    if (rowValue[1].Substring(0, 1).Equals("N") && rowValue[4].Substring(0, 1) == "R")
                    {
                        CashControlNoteChangeDeposit[x + 1] = ((String.IsNullOrEmpty(CashControlNoteChangeDeposit[x + 1]) ? 0 : Convert.ToDecimal(CashControlNoteChangeDeposit[x + 1])) + RpAmount).ToString();
                        CashControlNoteChangeDeposit[x + 2] = ((String.IsNullOrEmpty(CashControlNoteChangeDeposit[x + 2]) ? 0 : Convert.ToDecimal(CashControlNoteChangeDeposit[x + 2])) + RpCoin).ToString();
                    }

                    if (rowValue[1].Substring(0, 1).Equals("N") && rowValue[4].Substring(0, 1) == "P")
                    {
                        CashControlNoteChangeWithdrawal[x + 1] = ((String.IsNullOrEmpty(CashControlNoteChangeWithdrawal[x + 1]) ? 0 : Convert.ToDecimal(CashControlNoteChangeWithdrawal[x + 1])) + RpAmount).ToString();
                        CashControlNoteChangeWithdrawal[x + 2] = ((String.IsNullOrEmpty(CashControlNoteChangeWithdrawal[x + 2]) ? 0 : Convert.ToDecimal(CashControlNoteChangeWithdrawal[x + 2])) + RpCoin).ToString();
                    }

                    if (rowValue[4].Substring(0, 1) == "R")
                    {
                        CashControlCounterBalance[x + 1] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlCounterBalance[x + 1])) ? "0" : CashControlCounterBalance[x + 1]) + RpAmount).ToString();
                        CashControlCounterBalance[x + 2] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlCounterBalance[x + 2])) ? "0" : CashControlCounterBalance[x + 2]) + RpCoin).ToString();
                    }
                    else
                    {
                        CashControlCounterBalance[x + 1] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlCounterBalance[x + 1])) ? "0" : CashControlCounterBalance[x + 1]) - RpAmount).ToString();
                        CashControlCounterBalance[x + 2] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlCounterBalance[x + 2])) ? "0" : CashControlCounterBalance[x + 2]) - RpCoin).ToString();
                    }
                    #endregion

                RpAmount = RpAmount + (RpCoin / 100);

                #region Calculation for Deposit Amount And Withdrawal Amount

                    if (!this.IsPaymentCounter)
                    {
                        if (rowValue[1].Substring(0, 1).Equals("V") && rowValue[4].Substring(0, 1) == "P")
                        {
                            if (rowValue[1].Substring(0, 1).Equals("N") && rowValue[4].Substring(0, 1) == "P")
                            {
                                CashControlGrandTotal[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 3])) ? "0.00" : CashControlGrandTotal[x + 3]) + RpAmount).ToString();
                                CashControlGrandTotal[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 4])) ? "0.00" : CashControlGrandTotal[x + 4]) + 0).ToString();
                            }
                            else
                            {
                                CashControlGrandTotal[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 3])) ? "0.00" : CashControlGrandTotal[x + 3]) + 0).ToString();
                                CashControlGrandTotal[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 4])) ? "0.00" : CashControlGrandTotal[x + 4]) + RpAmount).ToString();
                            }
                        }
                        else
                        {
                            if (rowValue[1].Substring(0, 1).Equals("N") && rowValue[4].Substring(0, 1) == "R")
                            {
                                CashControlGrandTotal[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 3])) ? "0.00" : CashControlGrandTotal[x + 3]) + 0).ToString();
                                CashControlGrandTotal[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 4])) ? "0.00" : CashControlGrandTotal[x + 4]) + RpAmount).ToString();
                            }
                            else
                            {
                                CashControlGrandTotal[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 3])) ? "0.00" : CashControlGrandTotal[x + 3]) + RpAmount).ToString();
                                CashControlGrandTotal[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 4])) ? "0.00" : CashControlGrandTotal[x + 4]) + 0).ToString();
                            }
                        }
                        if (!rowValue[1].Substring(0, 1).Equals("V") && !rowValue[1].Substring(0, 1).Equals("N"))
                        {
                            CashControlReceiveTotal[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlReceiveTotal[x + 3])) ? "0.00" : CashControlReceiveTotal[x + 3]) + RpAmount).ToString();
                            CashControlReceiveTotal[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlReceiveTotal[x + 4])) ? "0.00" : CashControlReceiveTotal[x + 4]) + 0).ToString();
                        }

                        if (rowValue[1].Substring(0, 1).Equals("N") && rowValue[4].Substring(0, 1) == "R")
                        {
                            CashControlNoteChangeDeposit[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlNoteChangeDeposit[x + 3])) ? "0.00" : CashControlNoteChangeDeposit[x + 3]) + RpAmount).ToString();
                            CashControlNoteChangeDeposit[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlNoteChangeDeposit[x + 4])) ? "0.00" : CashControlNoteChangeDeposit[x + 4]) + 0).ToString();
                        }

                        if (rowValue[1].Substring(0, 1).Equals("N") && rowValue[4].Substring(0, 1) == "P")
                        {
                            CashControlNoteChangeWithdrawal[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlNoteChangeWithdrawal[x + 3])) ? "0.00" : CashControlNoteChangeWithdrawal[x + 3]) + 0).ToString();
                            CashControlNoteChangeWithdrawal[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlNoteChangeWithdrawal[x + 4])) ? "0.00" : CashControlNoteChangeWithdrawal[x + 4]) + RpAmount).ToString();
                        }

                        if (rowValue[4].Substring(0, 1) == "R")
                        {
                            CashControlCounterBalance[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlCounterBalance[x + 3])) ? "0.00" : CashControlCounterBalance[x + 3]) + RpAmount).ToString();
                            CashControlCounterBalance[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlCounterBalance[x + 4])) ? "0.00" : CashControlCounterBalance[x + 4]) + 0).ToString();
                        }
                        else
                        {
                            CashControlCounterBalance[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlCounterBalance[x + 3])) ? "0.00" : CashControlCounterBalance[x + 3]) - RpAmount).ToString();
                            CashControlCounterBalance[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlCounterBalance[x + 4])) ? "0.00" : CashControlCounterBalance[x + 4]) - 0).ToString();
                        }
                    }
                    else
                    {
                        if (rowValue[1].Substring(0, 1).Equals("V") && rowValue[4].Substring(0, 1) == "P")
                        {
                            if (rowValue[1].Substring(0, 1).Equals("N") && rowValue[4].Substring(0, 1) == "P")
                            {
                                CashControlGrandTotal[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 3])) ? "0.00" : CashControlGrandTotal[x + 3]) + RpAmount).ToString();
                                CashControlGrandTotal[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 4])) ? "0.00" : CashControlGrandTotal[x + 4]) + 0).ToString();
                            }

                        }
                        else
                        {
                            if (rowValue[1].Substring(0, 1).Equals("N") && rowValue[4].Substring(0, 1) == "R")
                            {
                                CashControlGrandTotal[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 3])) ? "0.00" : CashControlGrandTotal[x + 3]) + 0).ToString();
                                CashControlGrandTotal[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 4])) ? "0.00" : CashControlGrandTotal[x + 4]) + RpAmount).ToString();
                            }

                        }

                        if (rowValue[4].Substring(0, 1) == "R")
                        {
                            CashControlGrandTotal[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 3])) ? "0.00" : CashControlGrandTotal[x + 3]) + RpAmount).ToString();
                            CashControlGrandTotal[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 4])) ? "0.00" : CashControlGrandTotal[x + 4]) + 0).ToString();
                        }
                        else
                        {
                            CashControlGrandTotal[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 3])) ? "0.00" : CashControlGrandTotal[x + 3]) + 0).ToString();
                            CashControlGrandTotal[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 4])) ? "0.00" : CashControlGrandTotal[x + 4]) + RpAmount).ToString();

                        }

                        if (!rowValue[1].Substring(0, 1).Equals("V") && !rowValue[1].Substring(0, 1).Equals("N"))
                        {
                            CashControlReceiveTotal[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlReceiveTotal[x + 3])) ? "0.00" : CashControlReceiveTotal[x + 3]) + 0).ToString();
                            CashControlReceiveTotal[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlReceiveTotal[x + 4])) ? "0.00" : CashControlReceiveTotal[x + 4]) + RpAmount).ToString();
                        }

                        if (rowValue[1].Substring(0, 1).Equals("N") && rowValue[4].Substring(0, 1) == "R")
                        {
                            CashControlNoteChangeDeposit[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlNoteChangeDeposit[x + 3])) ? "0.00" : CashControlNoteChangeDeposit[x + 3]) + 0).ToString();
                            CashControlNoteChangeDeposit[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlNoteChangeDeposit[x + 4])) ? "0.00" : CashControlNoteChangeDeposit[x + 4]) + RpAmount).ToString();
                        }

                        if (rowValue[1].Substring(0, 1).Equals("N") && rowValue[4].Substring(0, 1) == "P")
                        {
                            CashControlNoteChangeWithdrawal[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlNoteChangeWithdrawal[x + 3])) ? "0.00" : CashControlNoteChangeWithdrawal[x + 3]) + RpAmount).ToString();
                            CashControlNoteChangeWithdrawal[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlNoteChangeWithdrawal[x + 4])) ? "0.00" : CashControlNoteChangeWithdrawal[x + 4]) + 0).ToString();
                        }

                        if (rowValue[4].Substring(0, 1) == "R")
                        {
                            CashControlCounterBalance[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlCounterBalance[x + 3])) ? "0.00" : CashControlCounterBalance[x + 3]) + RpAmount).ToString();
                            CashControlCounterBalance[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlCounterBalance[x + 4])) ? "0.00" : CashControlCounterBalance[x + 4]) + 0).ToString();
                        }
                        else
                        {
                            CashControlCounterBalance[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlCounterBalance[x + 3])) ? "0.00" : CashControlCounterBalance[x + 3]) - RpAmount).ToString();
                            CashControlCounterBalance[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlCounterBalance[x + 4])) ? "0.00" : CashControlCounterBalance[x + 4]) - 0).ToString();
                        }
                    }
                    #endregion

                }

                #region Refund Amount

                foreach (string[] rowValue in cashrefundlist)
                {
                    int x = 0; int y = 16;
                    for (int i = 16; i < rowValue.Length; i++)
                    {
                        ++x; ++y;
                        if (!rowValue[1].Substring(0, 1).Equals("V"))
                        {
                            if (rowValue[10].Substring(0, 1).Equals(rowValue[4]))
                                CashControlRefundTotal[x] = (Convert.ToInt32((String.IsNullOrEmpty(CashControlRefundTotal[x])) ? "0" : CashControlRefundTotal[x]) + Convert.ToInt32(rowValue[i])).ToString();
                            else
                                CashControlRefundTotal[x] = (Convert.ToInt32((String.IsNullOrEmpty(CashControlRefundTotal[x])) ? "0" : CashControlRefundTotal[x]) - Convert.ToInt32(rowValue[i])).ToString();
                        }
                        CashControlGrandTotal[x] = (Convert.ToInt32((String.IsNullOrEmpty(CashControlGrandTotal[x])) ? "0" : CashControlGrandTotal[x]) - Convert.ToInt32(rowValue[i])).ToString();
                        CashControlCounterBalance[x] = (Convert.ToInt32((String.IsNullOrEmpty(CashControlCounterBalance[x])) ? "0" : CashControlCounterBalance[x]) - Convert.ToInt32(rowValue[i])).ToString();
                    }
                    if (!rowValue[1].Substring(0, 1).Equals("V"))
                    {
                        CashControlRefundTotal[x + 1] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlRefundTotal[x + 1])) ? "0" : CashControlRefundTotal[x + 1]) + RefundAmount).ToString();
                        CashControlGrandTotal[x + 1] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 1])) ? "0" : CashControlGrandTotal[x + 1]) + RefundAmount).ToString();
                        CashControlRefundTotal[x + 2] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlRefundTotal[x + 2])) ? "0" : CashControlRefundTotal[x + 2]) + RefundCoin).ToString();
                        CashControlGrandTotal[x + 2] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 2])) ? "0" : CashControlGrandTotal[x + 2]) + RefundCoin).ToString();
                    }
                    RefundAmount = RefundAmount + (RefundCoin / 100);

                    if (rowValue[4].Equals("R"))
                    {
                        if (!this.IsPaymentCounter)
                        {
                            CashControlRefundTotal[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlRefundTotal[x + 3])) ? "0.00" : CashControlRefundTotal[x + 3]) + 0).ToString();
                            CashControlRefundTotal[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlRefundTotal[x + 4])) ? "0.00" : CashControlRefundTotal[x + 4]) + RefundAmount).ToString();
                        }
                    }
                    else
                    {
                        if (this.IsPaymentCounter)
                        {
                            CashControlRefundTotal[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlRefundTotal[x + 3])) ? "0.00" : CashControlRefundTotal[x + 3]) + 0).ToString();
                            CashControlRefundTotal[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlRefundTotal[x + 4])) ? "0.00" : CashControlRefundTotal[x + 4]) + RefundAmount).ToString();
                        }
                    }
                    CashControlGrandTotal[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 3])) ? "0.00" : CashControlGrandTotal[x + 3]) + 0).ToString();
                    CashControlGrandTotal[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 4])) ? "0.00" : CashControlGrandTotal[x + 4]) + 0).ToString();
                }

                #endregion


                if (this.IsPaymentCounter)
                {
                    CashControlReceiveTotal[0] = "Payment Total";
                    rowValueListString.Add(CashControlReceiveTotal);
                }
                else
                {
                    rowValueListString.Add(CashControlReceiveTotal);
                    rowValueListString.Add(CashControlRefundTotal);
                }

                rowValueListString.Add(CashControlNoteChangeDeposit);
                rowValueListString.Add(CashControlNoteChangeWithdrawal);
                rowValueListString.Add(CashControlGrandTotal);
                rowValueListString.Add(CashControlCounterBalance);

                excelfomat.CashControlReportExportToExcel(Branch.BranchDescription, Branch.Address, Branch.Phone, Branch.Fax, this.ReportTitle, DateTime.Now, denolist, VaultTransactionList, rowValueListString);
            }
        }

        public DataTable PrintExel_New()
        {
            DataTable dt = new DataTable();
            try
            {

                if (this.ValidateForm(this.GetViewData()))
                {
                    string whereString = this.GetParameterValue();
                    List<string[]> cashlist = new List<string[]>();
                    List<string[]> cashrefundlist = new List<string[]>();
                    List<string[]> rowValueListString = new List<string[]>();
                    List<string[]> VaultTransactionList = new List<string[]>();
                    CXCLE00004 excelfomat = new CXCLE00004();

                    decimal RpAmount = 0;
                    decimal RpCoin = 0;
                    decimal RefundAmount = 0;
                    decimal RefundCoin = 0;

                    if (view.CounterNo.Substring(0, 1) == "P")
                    {
                        IsPaymentCounter = true;
                    }
                    else
                    {
                        IsPaymentCounter = false;
                    }

                    #region Raw_Data

                    //Get Report Data from SP_CASHCONTROLREPORT
                    IList<object> result = CXClientWrapper.Instance.Invoke<ITLMSVE00071, IList<object>>(x => x.CashControlReport(this.view.Currency, whereString));
                    IList<object> refundResult = CXClientWrapper.Instance.Invoke<ITLMSVE00071, IList<object>>(x => x.CashControlRefundList(this.view.Currency, whereString));
                    string Date = CXClientWrapper.Instance.Invoke<ITLMSVE00071, string>(x => x.GetMaxDate(this.view.EndDateTime.ToString("yyyy/MM/dd")));
                    if (result == null || result.Count <= 0)
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MI00039");  //No Data For Report
                        return null;
                    }

                    for (int i = 0; i < result.Count; i++)
                    {
                        object[] a = (object[])result[i];
                        string[] b = Array.ConvertAll(a, p => (p ?? String.Empty).ToString());
                        cashlist.Add(b);
                    }
                    #endregion

                    //Get Branch Information
                    BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

                    //Get Deno Columns
                    List<string> denolist = CXClientWrapper.Instance.Invoke<ITLMSVE00071, IList<string>>(x => x.SelectDenoDescriptionByCurrency(this.view.Currency)).ToList();
                    IList<TLMDTO00012> DenoValue = CXCLE00002.Instance.GetListObject<TLMDTO00012>("Deno.SelectByCurrencyCode", new object[] { this.view.Currency, true });
                    VaultTransactionList = this.GetVaultTransaction(cashlist, denolist.Count);

                    string[] CashControlReceiveTotal = new string[5 + denolist.Count];
                    string[] CashControlRefundTotal = new string[5 + denolist.Count];
                    string[] CashControlNoteChangeDeposit = new string[5 + denolist.Count];
                    string[] CashControlNoteChangeWithdrawal = new string[5 + denolist.Count];
                    string[] CashControlGrandTotal = new string[5 + denolist.Count];
                    string[] CashControlCounterBalance = new string[5 + denolist.Count];

                    CashControlReceiveTotal = this.IntializeValue(CashControlReceiveTotal, "Receive Total");
                    CashControlRefundTotal = this.IntializeValue(CashControlRefundTotal, "Refund Total");
                    CashControlNoteChangeDeposit = this.IntializeValue(CashControlNoteChangeDeposit, "Note Change Deposit");
                    CashControlNoteChangeWithdrawal = this.IntializeValue(CashControlNoteChangeWithdrawal, "Note Change Withdrawal");
                    CashControlGrandTotal = this.IntializeValue(CashControlGrandTotal, "Grand Total");
                    CashControlCounterBalance = this.IntializeValue(CashControlCounterBalance, "Counter Balance");


                    #region For Refund Amount

                    if (refundResult != null && refundResult.Count > 0)
                    {
                        for (int i = 0; i < refundResult.Count; i++)
                        {
                            object[] a = (object[])refundResult[i];
                            string[] b = Array.ConvertAll(a, p => (p ?? String.Empty).ToString());
                            cashrefundlist.Add(b);
                        }

                        foreach (string[] refund in cashrefundlist)
                        {
                            int y = 0;
                            for (int i = 16; i < refund.Length; i++)
                            {
                                RefundAmount += Convert.ToDecimal(refund[i]) * Convert.ToDecimal(DenoValue[y].D1);
                                RefundCoin += Convert.ToDecimal(refund[i]) * Convert.ToDecimal(DenoValue[y].D2);
                                y++;
                            }
                        }
                    }

                    #endregion

                    #region For Cash Deno

                    foreach (string[] rowValue in cashlist)
                    {
                        int x = 0; int y = 16;
                        for (int i = 16; i < rowValue.Length; i++)
                        {
                            ++x; ++y;
                            if (rowValue[1].Substring(0, 1) != "V" && rowValue[1].Substring(0, 1) != "N")
                            {
                                if (rowValue[10].Substring(0, 1).Equals(rowValue[4]))
                                    CashControlReceiveTotal[x] = (Convert.ToInt32((String.IsNullOrEmpty(CashControlReceiveTotal[x])) ? "0" : CashControlReceiveTotal[x]) + Convert.ToInt32(rowValue[i])).ToString();
                                else
                                    CashControlReceiveTotal[x] = (Convert.ToInt32((String.IsNullOrEmpty(CashControlReceiveTotal[x])) ? "0" : CashControlReceiveTotal[x]) - Convert.ToInt32(rowValue[i])).ToString();
                            }

                            if (rowValue[1].Substring(0, 1) == "N" && rowValue[4].Substring(0, 1) == "R")
                            {
                                CashControlNoteChangeDeposit[x] = (Convert.ToInt32((String.IsNullOrEmpty(CashControlNoteChangeDeposit[x])) ? "0" : CashControlNoteChangeDeposit[x]) + Convert.ToInt32(rowValue[i])).ToString();
                            }

                            if (rowValue[1].Substring(0, 1) == "N" && rowValue[4].Substring(0, 1) == "P")
                            {
                                CashControlNoteChangeWithdrawal[x] = (Convert.ToInt32((String.IsNullOrEmpty(CashControlNoteChangeWithdrawal[x])) ? "0" : CashControlNoteChangeWithdrawal[x]) + Convert.ToInt32(rowValue[i])).ToString();
                            }
                            if (rowValue[4].Substring(0, 1) == "R")
                            {
                                CashControlCounterBalance[x] = (Convert.ToInt32((String.IsNullOrEmpty(CashControlCounterBalance[x])) ? "0" : CashControlCounterBalance[x]) + Convert.ToInt32(rowValue[i])).ToString();
                            }
                            else
                            {
                                CashControlCounterBalance[x] = (Convert.ToInt32((String.IsNullOrEmpty(CashControlCounterBalance[x])) ? "0" : CashControlCounterBalance[x]) - Convert.ToInt32(rowValue[i])).ToString();
                            }
                        }

                    #endregion

                        #region Amount n Coin
                        RpAmount = (String.IsNullOrEmpty(rowValue[6]) ? 0 : Convert.ToDecimal(rowValue[6].Remove(rowValue[6].Length - 3, 3)));
                        RpCoin = (String.IsNullOrEmpty(rowValue[7]) ? 0 : Convert.ToDecimal(rowValue[7]));

                        CashControlGrandTotal[x + 1] = ((String.IsNullOrEmpty(CashControlGrandTotal[x + 1]) ? 0 : Convert.ToDecimal(CashControlGrandTotal[x + 1])) + RpAmount).ToString();
                        CashControlGrandTotal[x + 2] = ((String.IsNullOrEmpty(CashControlGrandTotal[x + 2]) ? 0 : Convert.ToDecimal(CashControlGrandTotal[x + 2])) + RpCoin).ToString();



                        if (!rowValue[1].Substring(0, 1).Equals("V"))
                        {
                            //if(rowValue[10].Substring(0,1).Equals(rowValue[4]))
                            CashControlReceiveTotal[x + 1] = ((String.IsNullOrEmpty(CashControlReceiveTotal[x + 1]) ? 0 : Convert.ToDecimal(CashControlReceiveTotal[x + 1])) + RpAmount).ToString();
                            //else
                            //CashControlReceiveTotal[x + 1] = ((String.IsNullOrEmpty(CashControlReceiveTotal[x + 1]) ? 0 : Convert.ToDecimal(CashControlReceiveTotal[x + 1])) - RpAmount).ToString();
                        }

                        if (!rowValue[1].Substring(0, 1).Equals("V") && !rowValue[1].Substring(0, 1).Equals("N"))
                        {
                            CashControlReceiveTotal[x + 2] = ((String.IsNullOrEmpty(CashControlReceiveTotal[x + 2]) ? 0 : Convert.ToDecimal(CashControlReceiveTotal[x + 2])) + RpCoin).ToString();
                        }

                        if (rowValue[1].Substring(0, 1).Equals("N") && rowValue[4].Substring(0, 1) == "R")
                        {
                            CashControlNoteChangeDeposit[x + 1] = ((String.IsNullOrEmpty(CashControlNoteChangeDeposit[x + 1]) ? 0 : Convert.ToDecimal(CashControlNoteChangeDeposit[x + 1])) + RpAmount).ToString();
                            CashControlNoteChangeDeposit[x + 2] = ((String.IsNullOrEmpty(CashControlNoteChangeDeposit[x + 2]) ? 0 : Convert.ToDecimal(CashControlNoteChangeDeposit[x + 2])) + RpCoin).ToString();
                        }

                        if (rowValue[1].Substring(0, 1).Equals("N") && rowValue[4].Substring(0, 1) == "P")
                        {
                            CashControlNoteChangeWithdrawal[x + 1] = ((String.IsNullOrEmpty(CashControlNoteChangeWithdrawal[x + 1]) ? 0 : Convert.ToDecimal(CashControlNoteChangeWithdrawal[x + 1])) + RpAmount).ToString();
                            CashControlNoteChangeWithdrawal[x + 2] = ((String.IsNullOrEmpty(CashControlNoteChangeWithdrawal[x + 2]) ? 0 : Convert.ToDecimal(CashControlNoteChangeWithdrawal[x + 2])) + RpCoin).ToString();
                        }

                        if (rowValue[4].Substring(0, 1) == "R")
                        {
                            CashControlCounterBalance[x + 1] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlCounterBalance[x + 1])) ? "0" : CashControlCounterBalance[x + 1]) + RpAmount).ToString();
                            CashControlCounterBalance[x + 2] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlCounterBalance[x + 2])) ? "0" : CashControlCounterBalance[x + 2]) + RpCoin).ToString();
                        }
                        else
                        {
                            CashControlCounterBalance[x + 1] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlCounterBalance[x + 1])) ? "0" : CashControlCounterBalance[x + 1]) - RpAmount).ToString();
                            CashControlCounterBalance[x + 2] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlCounterBalance[x + 2])) ? "0" : CashControlCounterBalance[x + 2]) - RpCoin).ToString();
                        }
                        #endregion

                        RpAmount = RpAmount + (RpCoin / 100);

                        #region Calculation for Deposit Amount And Withdrawal Amount

                        if (!this.IsPaymentCounter)
                        {
                            if (rowValue[1].Substring(0, 1).Equals("V") && rowValue[4].Substring(0, 1) == "P")
                            {
                                if (rowValue[1].Substring(0, 1).Equals("N") && rowValue[4].Substring(0, 1) == "P")
                                {
                                    CashControlGrandTotal[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 3])) ? "0.00" : CashControlGrandTotal[x + 3]) + RpAmount).ToString();
                                    CashControlGrandTotal[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 4])) ? "0.00" : CashControlGrandTotal[x + 4]) + 0).ToString();
                                }
                                else
                                {
                                    CashControlGrandTotal[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 3])) ? "0.00" : CashControlGrandTotal[x + 3]) + 0).ToString();
                                    CashControlGrandTotal[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 4])) ? "0.00" : CashControlGrandTotal[x + 4]) + RpAmount).ToString();
                                }
                            }
                            else
                            {
                                if (rowValue[1].Substring(0, 1).Equals("N") && rowValue[4].Substring(0, 1) == "R")
                                {
                                    CashControlGrandTotal[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 3])) ? "0.00" : CashControlGrandTotal[x + 3]) + 0).ToString();
                                    CashControlGrandTotal[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 4])) ? "0.00" : CashControlGrandTotal[x + 4]) + RpAmount).ToString();
                                }
                                else
                                {
                                    CashControlGrandTotal[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 3])) ? "0.00" : CashControlGrandTotal[x + 3]) + RpAmount).ToString();
                                    CashControlGrandTotal[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 4])) ? "0.00" : CashControlGrandTotal[x + 4]) + 0).ToString();
                                }
                            }
                            if (!rowValue[1].Substring(0, 1).Equals("V") && !rowValue[1].Substring(0, 1).Equals("N"))
                            {
                                CashControlReceiveTotal[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlReceiveTotal[x + 3])) ? "0.00" : CashControlReceiveTotal[x + 3]) + RpAmount).ToString();
                                CashControlReceiveTotal[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlReceiveTotal[x + 4])) ? "0.00" : CashControlReceiveTotal[x + 4]) + 0).ToString();
                            }

                            if (rowValue[1].Substring(0, 1).Equals("N") && rowValue[4].Substring(0, 1) == "R")
                            {
                                CashControlNoteChangeDeposit[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlNoteChangeDeposit[x + 3])) ? "0.00" : CashControlNoteChangeDeposit[x + 3]) + RpAmount).ToString();
                                CashControlNoteChangeDeposit[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlNoteChangeDeposit[x + 4])) ? "0.00" : CashControlNoteChangeDeposit[x + 4]) + 0).ToString();
                            }

                            if (rowValue[1].Substring(0, 1).Equals("N") && rowValue[4].Substring(0, 1) == "P")
                            {
                                CashControlNoteChangeWithdrawal[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlNoteChangeWithdrawal[x + 3])) ? "0.00" : CashControlNoteChangeWithdrawal[x + 3]) + 0).ToString();
                                CashControlNoteChangeWithdrawal[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlNoteChangeWithdrawal[x + 4])) ? "0.00" : CashControlNoteChangeWithdrawal[x + 4]) + RpAmount).ToString();
                            }

                            if (rowValue[4].Substring(0, 1) == "R")
                            {
                                CashControlCounterBalance[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlCounterBalance[x + 3])) ? "0.00" : CashControlCounterBalance[x + 3]) + RpAmount).ToString();
                                CashControlCounterBalance[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlCounterBalance[x + 4])) ? "0.00" : CashControlCounterBalance[x + 4]) + 0).ToString();
                            }
                            else
                            {
                                CashControlCounterBalance[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlCounterBalance[x + 3])) ? "0.00" : CashControlCounterBalance[x + 3]) - RpAmount).ToString();
                                CashControlCounterBalance[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlCounterBalance[x + 4])) ? "0.00" : CashControlCounterBalance[x + 4]) - 0).ToString();
                            }
                        }
                        else
                        {
                            if (rowValue[1].Substring(0, 1).Equals("V") && rowValue[4].Substring(0, 1) == "P")
                            {
                                if (rowValue[1].Substring(0, 1).Equals("N") && rowValue[4].Substring(0, 1) == "P")
                                {
                                    CashControlGrandTotal[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 3])) ? "0.00" : CashControlGrandTotal[x + 3]) + RpAmount).ToString();
                                    CashControlGrandTotal[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 4])) ? "0.00" : CashControlGrandTotal[x + 4]) + 0).ToString();
                                }

                            }
                            else
                            {
                                if (rowValue[1].Substring(0, 1).Equals("N") && rowValue[4].Substring(0, 1) == "R")
                                {
                                    CashControlGrandTotal[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 3])) ? "0.00" : CashControlGrandTotal[x + 3]) + 0).ToString();
                                    CashControlGrandTotal[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 4])) ? "0.00" : CashControlGrandTotal[x + 4]) + RpAmount).ToString();
                                }

                            }

                            if (rowValue[4].Substring(0, 1) == "R")
                            {
                                CashControlGrandTotal[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 3])) ? "0.00" : CashControlGrandTotal[x + 3]) + RpAmount).ToString();
                                CashControlGrandTotal[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 4])) ? "0.00" : CashControlGrandTotal[x + 4]) + 0).ToString();
                            }
                            else
                            {
                                CashControlGrandTotal[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 3])) ? "0.00" : CashControlGrandTotal[x + 3]) + 0).ToString();
                                CashControlGrandTotal[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 4])) ? "0.00" : CashControlGrandTotal[x + 4]) + RpAmount).ToString();

                            }

                            if (!rowValue[1].Substring(0, 1).Equals("V") && !rowValue[1].Substring(0, 1).Equals("N"))
                            {
                                CashControlReceiveTotal[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlReceiveTotal[x + 3])) ? "0.00" : CashControlReceiveTotal[x + 3]) + 0).ToString();
                                CashControlReceiveTotal[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlReceiveTotal[x + 4])) ? "0.00" : CashControlReceiveTotal[x + 4]) + RpAmount).ToString();
                            }

                            if (rowValue[1].Substring(0, 1).Equals("N") && rowValue[4].Substring(0, 1) == "R")
                            {
                                CashControlNoteChangeDeposit[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlNoteChangeDeposit[x + 3])) ? "0.00" : CashControlNoteChangeDeposit[x + 3]) + 0).ToString();
                                CashControlNoteChangeDeposit[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlNoteChangeDeposit[x + 4])) ? "0.00" : CashControlNoteChangeDeposit[x + 4]) + RpAmount).ToString();
                            }

                            if (rowValue[1].Substring(0, 1).Equals("N") && rowValue[4].Substring(0, 1) == "P")
                            {
                                CashControlNoteChangeWithdrawal[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlNoteChangeWithdrawal[x + 3])) ? "0.00" : CashControlNoteChangeWithdrawal[x + 3]) + RpAmount).ToString();
                                CashControlNoteChangeWithdrawal[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlNoteChangeWithdrawal[x + 4])) ? "0.00" : CashControlNoteChangeWithdrawal[x + 4]) + 0).ToString();
                            }

                            if (rowValue[4].Substring(0, 1) == "R")
                            {
                                CashControlCounterBalance[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlCounterBalance[x + 3])) ? "0.00" : CashControlCounterBalance[x + 3]) + RpAmount).ToString();
                                CashControlCounterBalance[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlCounterBalance[x + 4])) ? "0.00" : CashControlCounterBalance[x + 4]) + 0).ToString();
                            }
                            else
                            {
                                CashControlCounterBalance[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlCounterBalance[x + 3])) ? "0.00" : CashControlCounterBalance[x + 3]) - RpAmount).ToString();
                                CashControlCounterBalance[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlCounterBalance[x + 4])) ? "0.00" : CashControlCounterBalance[x + 4]) - 0).ToString();
                            }
                        }
                        #endregion

                    }

                    #region Refund Amount

                    foreach (string[] rowValue in cashrefundlist)
                    {
                        int x = 0; int y = 16;
                        for (int i = 16; i < rowValue.Length; i++)
                        {
                            ++x; ++y;
                            if (!rowValue[1].Substring(0, 1).Equals("V"))
                            {
                                if (rowValue[10].Substring(0, 1).Equals(rowValue[4]))
                                    CashControlRefundTotal[x] = (Convert.ToInt32((String.IsNullOrEmpty(CashControlRefundTotal[x])) ? "0" : CashControlRefundTotal[x]) + Convert.ToInt32(rowValue[i])).ToString();
                                else
                                    CashControlRefundTotal[x] = (Convert.ToInt32((String.IsNullOrEmpty(CashControlRefundTotal[x])) ? "0" : CashControlRefundTotal[x]) - Convert.ToInt32(rowValue[i])).ToString();
                            }
                            CashControlGrandTotal[x] = (Convert.ToInt32((String.IsNullOrEmpty(CashControlGrandTotal[x])) ? "0" : CashControlGrandTotal[x]) - Convert.ToInt32(rowValue[i])).ToString();
                            CashControlCounterBalance[x] = (Convert.ToInt32((String.IsNullOrEmpty(CashControlCounterBalance[x])) ? "0" : CashControlCounterBalance[x]) - Convert.ToInt32(rowValue[i])).ToString();
                        }
                        if (!rowValue[1].Substring(0, 1).Equals("V"))
                        {
                            CashControlRefundTotal[x + 1] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlRefundTotal[x + 1])) ? "0" : CashControlRefundTotal[x + 1]) + RefundAmount).ToString();
                            CashControlGrandTotal[x + 1] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 1])) ? "0" : CashControlGrandTotal[x + 1]) + RefundAmount).ToString();
                            CashControlRefundTotal[x + 2] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlRefundTotal[x + 2])) ? "0" : CashControlRefundTotal[x + 2]) + RefundCoin).ToString();
                            CashControlGrandTotal[x + 2] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 2])) ? "0" : CashControlGrandTotal[x + 2]) + RefundCoin).ToString();
                        }
                        RefundAmount = RefundAmount + (RefundCoin / 100);

                        if (rowValue[4].Equals("R"))
                        {
                            if (!this.IsPaymentCounter)
                            {
                                CashControlRefundTotal[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlRefundTotal[x + 3])) ? "0.00" : CashControlRefundTotal[x + 3]) + 0).ToString();
                                CashControlRefundTotal[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlRefundTotal[x + 4])) ? "0.00" : CashControlRefundTotal[x + 4]) + RefundAmount).ToString();
                            }
                        }
                        else
                        {
                            if (this.IsPaymentCounter)
                            {
                                CashControlRefundTotal[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlRefundTotal[x + 3])) ? "0.00" : CashControlRefundTotal[x + 3]) + 0).ToString();
                                CashControlRefundTotal[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlRefundTotal[x + 4])) ? "0.00" : CashControlRefundTotal[x + 4]) + RefundAmount).ToString();
                            }
                        }
                        CashControlGrandTotal[x + 3] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 3])) ? "0.00" : CashControlGrandTotal[x + 3]) + 0).ToString();
                        CashControlGrandTotal[x + 4] = (Convert.ToDecimal((String.IsNullOrEmpty(CashControlGrandTotal[x + 4])) ? "0.00" : CashControlGrandTotal[x + 4]) + 0).ToString();
                    }

                    #endregion


                    if (this.IsPaymentCounter)
                    {
                        CashControlReceiveTotal[0] = "Payment Total";
                        rowValueListString.Add(CashControlReceiveTotal);
                    }
                    else
                    {
                        rowValueListString.Add(CashControlReceiveTotal);
                        rowValueListString.Add(CashControlRefundTotal);
                    }

                    rowValueListString.Add(CashControlNoteChangeDeposit);
                    rowValueListString.Add(CashControlNoteChangeWithdrawal);
                    rowValueListString.Add(CashControlGrandTotal);
                    rowValueListString.Add(CashControlCounterBalance);


                    int countRow = 1;

                    if (denolist.Count > 0)
                    {
                        dt.Columns.Add("Sr No.");
                        dt.Columns.Add("Entry No.");
                        dt.Columns.Add("Description");
                        dt.Columns.Add("Cashier");
                        for (int i = 0; i < denolist.Count; i++)
                        {
                            dt.Columns.Add(denolist[i].ToString());
                        }
                        dt.Columns.Add("Total Amount of Notes");
                        dt.Columns.Add("Coins");
                        dt.Columns.Add("Deposit Amount");
                        dt.Columns.Add("Withdraw Amount");

                        object[] obj = new object[dt.Columns.Count];
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            obj[i] = dt.Columns[i].ColumnName;
                        }

                        dt.Rows.Add(obj);
                        for (int i = 0; i < VaultTransactionList.Count; i++)
                        {
                            object[] vault = { 
                                                            countRow,
                                                            VaultTransactionList[i][0],
                                                            VaultTransactionList[i][1],
                                                            VaultTransactionList[i][2],
                                                            VaultTransactionList[i][3],
                                                            VaultTransactionList[i][4],
                                                             VaultTransactionList[i][5],
                                                             VaultTransactionList[i][6],
                                                             VaultTransactionList[i][7],
                                                             VaultTransactionList[i][8],
                                                             VaultTransactionList[i][9],
                                                             VaultTransactionList[i][10],
                                                             VaultTransactionList[i][11],
                                                             VaultTransactionList[i][12],
                                                             VaultTransactionList[i][13],
                                                             VaultTransactionList[i][14],
                                                             VaultTransactionList[i][15],
                                                             VaultTransactionList[i][16],
                                                             VaultTransactionList[i][17],
                                                             VaultTransactionList[i][18],
                                                             VaultTransactionList[i][19],
                                                             VaultTransactionList[i][20],
                                                             VaultTransactionList[i][21],
                                                             VaultTransactionList[i][22]
                                                         };

                            dt.Rows.Add(vault);
                            countRow++;
                        }
                        for (int i = 0; i < rowValueListString.Count; i++)
                        {
                            object[] FooterValue = { 

                                                       "","","","",
                                                             rowValueListString[i][1],
                                                             rowValueListString[i][2],
                                                             rowValueListString[i][3],
                                                             rowValueListString[i][4],
                                                             rowValueListString[i][5],
                                                             rowValueListString[i][6],
                                                             rowValueListString[i][7],
                                                             rowValueListString[i][8],
                                                             rowValueListString[i][9],
                                                             rowValueListString[i][10],
                                                             rowValueListString[i][11],
                                                             rowValueListString[i][12],
                                                             rowValueListString[i][13],
                                                             rowValueListString[i][14],
                                                             rowValueListString[i][15],
                                                             rowValueListString[i][16],
                                                             rowValueListString[i][17],
                                                             rowValueListString[i][18],
                                                             rowValueListString[i][19],
                                                             rowValueListString[i][20]
                                                         };
                            dt.Rows.Add(FooterValue);
                        }
                    }
                    dt.Rows[dt.Rows.Count - 1][0] = "Counter Balance";
                    dt.Rows[dt.Rows.Count - 2][0] = "Grand Total";
                    dt.Rows[dt.Rows.Count - 3][0] = "Note Change Withdrawal";
                    dt.Rows[dt.Rows.Count - 4][0] = "Note Change Deposit";

                    if (_counterType.ToLower() == "r")
                    {
                        dt.Rows[dt.Rows.Count - 5][0] = "Refund Total";
                        dt.Rows[dt.Rows.Count - 6][0] = "Receive Total";
                    }
                    else
                    {
                        //dt.Rows.RemoveAt(dt.Rows.Count - 5);
                        dt.Rows[dt.Rows.Count - 5][0] = "Payment Total";
                    }

                    //excelfomat.CashControlReportExportToExcel(Branch.BranchDescription, Branch.Address, Branch.Phone, Branch.Fax, this.ReportTitle, DateTime.Now, denolist, VaultTransactionList, rowValueListString);
                }
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string SendReportTitle()
        {
            if (this.ReportTitle != string.Empty)
            {
                return this.ReportTitle;
            }
            return null;
        }
       
    }
}
