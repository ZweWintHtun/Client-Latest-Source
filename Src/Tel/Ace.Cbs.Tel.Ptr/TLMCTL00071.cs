//----------------------------------------------------------------------
// <copyright file="TLMCTL00071.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San </CreatedUser>
// <CreatedDate>2013-06-18</CreatedDate>
// <UpdatedUser>NLKK</UpdatedUser>
// <UpdatedDate>27.12.2013</UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using System.Windows.Forms;
using Ace.Windows.CXClient;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Ser;
using Ace.Windows.Core.Utt;
using System.Collections;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Admin.DataModel;
using System.Data;

namespace Ace.Cbs.Tel.Ptr
{
    struct Counter
    {
        public string CounterNo;
    }

    /// <summary>
    /// Cash Denomination Listing Controller
    /// </summary>
    public class TLMCTL00071 : AbstractPresenter, ITLMCTL00071
    {
        #region INITIALIZE VIEW
        private ITLMVEW00071 view;
        public ITLMVEW00071 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ITLMVEW00071 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetCashDenominationListingEntity());
            }
        }

        public string ReportTitle { get; set; }
        #endregion

        #region Helper Method

        public void ClearAllCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }
        public void CashDenominationListing(string wherestring)
        {
            IList<int> rowCountByCounter = new List<int>();
            IList<TLMDTO00015> resultForMulti = new List<TLMDTO00015>();
            List<string[]> cashlist = new List<string[]>();
            IList<Counter> counterList = new List<Counter>();
            IList<string> counterListString = new List<string>();
            IList<string[]> rowValueListString = new List<string[]>();
            IList<object> result = new List<Object>();
            CXCLE00004 excelfomat = new CXCLE00004();

            #region Raw_Data

            //Get Report Data from SP_CASHCONTROLREPORT
            if (!this.view.isMultiTransaction)
            {
                result = CXClientWrapper.Instance.Invoke<ITLMSVE00071, IList<object>>(x => x.CashControlReport(this.view.CurrencyCode, wherestring));

            }
            //else
            //{
            //    string orderString = " ORDER BY COUNTERNO, UserName, TLF_ENO, CASHDATE";
            //    resultForMulti = CXClientWrapper.Instance.Invoke<ICXSVE00010, IList<TLMDTO00015>>(x => x.CashDenominationListing_ForMultiTransaction(this.view.CurrencyCode, wherestring, orderString));
            //}
           

            #region TestCode
            // resultForMulti = (IList<string>)result;         
	

            //If the object is deserialized as Receipt, you could use Enumerable extensions.
            //resultForMulti = result.Cast<string[]>().ToList();
           
            //resultForMulti = (List<TLMDTO00015>)result;
           
            //if (result is IEnumerable)
            //{
            //    TLMDTO00015 dto = new TLMDTO00015();
            //    var enumerator = ((IEnumerable)result).GetEnumerator();
            //    while (enumerator.MoveNext())
            //    {
            //        resultForMulti.Add((string[])enumerator.Current);
            //        //list.Add(enumerator.Current.GetType());
            //    }
            //}
            #endregion

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
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode,true });
             
            //Get Deno Columns from server db
            // List<string> denolist = CXClientWrapper.Instance.Invoke<ITLMSVE00071, IList<string>>(x => x.SelectDenoDescriptionByCurrency(this.view.CurrencyCode)).ToList();
           
            //Get Deno Columns from Client sqlite db
            IList<TLMDTO00012> deno_List = CXCLE00002.Instance.GetListObject<TLMDTO00012>("CXCLE00004.Client.SelectForDeno", new object[] { this.view.CurrencyCode, true }).ToList();

            List<string> denolist = (from value in deno_List
                         select value.Description).ToList();

            List<string> KytDenoList = new List<string>();

            //Remove Pya Columns in KYT DenoList
            if (this.view.CurrencyCode == "KYT")
            {
                foreach (string deno in denolist)
                {
                    if (deno.Contains("Pya") || deno.Contains("pya"))
                        continue;
                    KytDenoList.Add(deno);
                }
                denolist = KytDenoList;
            }
            #region Counter_List

            foreach (string[] value in cashlist)
            {
                Counter counter = new Counter();
                counter.CounterNo = value[9];
                counterList.Add(counter);
            }

            if (this.view.CounterNo == "All")
            {
                #region Row_Values

                //Get Row Values List
                foreach (string[] rowValue in cashlist)
                {
                    if (rowValue[9] == null || rowValue[9] == "")
                        continue;

                    string[] rv = new string[9 + denolist.Count];

                    rv[0] = rowValue[1];
                    rv[1] = rowValue[2];
                    if(this.View.isNoteChange)
                        rv[2]=rowValue[3];
                    else
                        rv[2] = rowValue[14];
                    rv[3] = rowValue[8];

                    int j = 4; int k = 16;
                    for (int i = 0; i < denolist.Count; i++)
                    {
                        rv[j] = rowValue[k];
                        j++; k++;
                    }

                    rv[j++] = rowValue[6];//.Split(".".ToCharArray())[0];
                    rv[j++] = rowValue[7].Split(".".ToCharArray())[0];
                    rv[j++] = CXCLE00002.Instance.GetDenoAmount(rowValue[15], this.View.CurrencyCode).ToString();
                    rv[j++] = (rowValue[5] == null || rowValue[5] == string.Empty) ? "0" : rowValue[5];
                    rv[j++] = rowValue[6];

                    rowValueListString.Add(rv);
                }
                #endregion


                //Order Counter
                counterList = counterList.OrderBy(x => x.CounterNo).ToList();

                //Count Counter
                var RowCountByCounter = counterList.Where(x => (x.CounterNo != "")).GroupBy(x => x.CounterNo).Select(y => y.Count()).ToList();
                foreach (var rowCount in RowCountByCounter)
                {
                    rowCountByCounter.Add(Convert.ToInt32(rowCount));
                }
                if (rowCountByCounter.Count <= 0)
                {
                    CXUIMessageUtilities.ShowMessageByCode("MI00039");  //No Data For Report
                    return;
                }

                //Group Counter
                var varCounterList = from c in counterList where c.CounterNo != "" group c by new { c.CounterNo } into ct select new { ct.Key.CounterNo };

                //Get CounterList
                foreach (var varCounter in varCounterList.ToList())
                {
                    counterListString.Add(varCounter.CounterNo);
                }
            }
            else
            {
                #region Row_Values

                //Get Row Values List
                foreach (string[] rowValue in cashlist)
                {
                    if (rowValue[9] == null || rowValue[9] == "" || rowValue[9] != this.View.CounterNo)
                        continue;

                    string[] rv = new string[9 + denolist.Count];

                    rv[0] = rowValue[1];
                    rv[1] = rowValue[2];
                    if (this.View.isNoteChange)
                        rv[2] = rowValue[3];
                    else
                        rv[2] = rowValue[14];
                    rv[3] = rowValue[8];

                    int j = 4; int k = 16;
                    for (int i = 0; i < denolist.Count; i++)
                    {
                        rv[j] = rowValue[k];
                        j++; k++;
                    }

                    rv[j++] = rowValue[6].Split(".".ToCharArray())[0];
                    rv[j++] = rowValue[7].Split(".".ToCharArray())[0];
                    rv[j++] = CXCLE00002.Instance.GetDenoAmount(rowValue[15], this.View.CurrencyCode).ToString();
                    rv[j++] = rowValue[5];
                    rv[j++] = rowValue[6];

                    rowValueListString.Add(rv);
                }
                #endregion

                //Get CounterList
                IList<Counter> list = counterList.Where(x => x.CounterNo == this.view.CounterNo).ToList();
                var RowCountByCounter = list.GroupBy(x => x.CounterNo).Select(y => y.Count()).ToList();
                foreach (var rowCount in RowCountByCounter)
                {
                    rowCountByCounter.Add(Convert.ToInt32(rowCount));
                }
                if (rowCountByCounter.Count <= 0)
                {
                    CXUIMessageUtilities.ShowMessageByCode("MI00039");  //No Data For Report
                    return;
                }
                counterListString = new List<string> { this.view.CounterNo };
            }
            #endregion

            string title = this.GetReportTitle();  // to get report title  

            //Excel Report
            excelfomat.CashDenominationReportExportToExcel(Branch.BranchDescription, Branch.Address, Branch.Phone, Branch.Fax, title, DateTime.Now, denolist, counterListString, rowCountByCounter, rowValueListString);
        }

        public DataTable CashDenominationListing_New(string wherestring)
        {
            DataTable dt = new DataTable();
            IList<int> rowCountByCounter = new List<int>();
            IList<TLMDTO00015> resultForMulti = new List<TLMDTO00015>();
            List<string[]> cashlist = new List<string[]>();
            IList<Counter> counterList = new List<Counter>();
            IList<string> counterListString = new List<string>();
            IList<string[]> rowValueListString = new List<string[]>();
            IList<object> result = new List<Object>();
            CXCLE00004 excelfomat = new CXCLE00004();

            #region Raw_Data

            //Get Report Data from SP_CASHCONTROLREPORT
            if (!this.view.isMultiTransaction)
            {
                result = CXClientWrapper.Instance.Invoke<ITLMSVE00071, IList<object>>(x => x.CashControlReport(this.view.CurrencyCode, wherestring));

            }
            //else
            //{
            //    string orderString = " ORDER BY COUNTERNO, UserName, TLF_ENO, CASHDATE";
            //    resultForMulti = CXClientWrapper.Instance.Invoke<ICXSVE00010, IList<TLMDTO00015>>(x => x.CashDenominationListing_ForMultiTransaction(this.view.CurrencyCode, wherestring, orderString));
            //}


            #region TestCode
            // resultForMulti = (IList<string>)result;         


            //If the object is deserialized as Receipt, you could use Enumerable extensions.
            //resultForMulti = result.Cast<string[]>().ToList();

            //resultForMulti = (List<TLMDTO00015>)result;

            //if (result is IEnumerable)
            //{
            //    TLMDTO00015 dto = new TLMDTO00015();
            //    var enumerator = ((IEnumerable)result).GetEnumerator();
            //    while (enumerator.MoveNext())
            //    {
            //        resultForMulti.Add((string[])enumerator.Current);
            //        //list.Add(enumerator.Current.GetType());
            //    }
            //}
            #endregion

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
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode, true });

            //Get Deno Columns from server db
            // List<string> denolist = CXClientWrapper.Instance.Invoke<ITLMSVE00071, IList<string>>(x => x.SelectDenoDescriptionByCurrency(this.view.CurrencyCode)).ToList();

            //Get Deno Columns from Client sqlite db
            IList<TLMDTO00012> deno_List = CXCLE00002.Instance.GetListObject<TLMDTO00012>("CXCLE00004.Client.SelectForDeno", new object[] { this.view.CurrencyCode, true }).ToList();

            List<string> denolist = (from value in deno_List
                                     select value.Description).ToList();

            List<string> KytDenoList = new List<string>();

            //Remove Pya Columns in KYT DenoList
            if (this.view.CurrencyCode == "KYT")
            {
                foreach (string deno in denolist)
                {
                    if (deno.Contains("Pya") || deno.Contains("pya"))
                        continue;
                    KytDenoList.Add(deno);
                }
                denolist = KytDenoList;
            }
            #region Counter_List

            foreach (string[] value in cashlist)
            {
                Counter counter = new Counter();
                counter.CounterNo = value[9];
                counterList.Add(counter);
            }

            if (this.view.CounterNo == "All")
            {
                #region Row_Values

                //Get Row Values List
                foreach (string[] rowValue in cashlist)
                {
                    if (rowValue[9] == null || rowValue[9] == "")
                        continue;

                    string[] rv = new string[9 + denolist.Count];

                    rv[0] = rowValue[1];
                    rv[1] = rowValue[2];
                    if (this.View.isNoteChange)
                        rv[2] = rowValue[3];
                    else
                        rv[2] = rowValue[14];
                    rv[3] = rowValue[8];

                    int j = 4; int k = 16;
                    for (int i = 0; i < denolist.Count; i++)
                    {
                        rv[j] = rowValue[k];
                        j++; k++;
                    }

                    rv[j++] = rowValue[6];//.Split(".".ToCharArray())[0];
                    rv[j++] = rowValue[7].Split(".".ToCharArray())[0];
                    rv[j++] = CXCLE00002.Instance.GetDenoAmount(rowValue[15], this.View.CurrencyCode).ToString();
                    rv[j++] = (rowValue[5] == null || rowValue[5] == string.Empty) ? "0" : rowValue[5];
                    rv[j++] = rowValue[6];

                    rowValueListString.Add(rv);
                }
                #endregion


                //Order Counter
                counterList = counterList.OrderBy(x => x.CounterNo).ToList();

                //Count Counter
                var RowCountByCounter = counterList.Where(x => (x.CounterNo != "")).GroupBy(x => x.CounterNo).Select(y => y.Count()).ToList();
                foreach (var rowCount in RowCountByCounter)
                {
                    rowCountByCounter.Add(Convert.ToInt32(rowCount));
                }
                if (rowCountByCounter.Count <= 0)
                {
                    CXUIMessageUtilities.ShowMessageByCode("MI00039");  //No Data For Report
                    return null;
                }

                //Group Counter
                var varCounterList = from c in counterList where c.CounterNo != "" group c by new { c.CounterNo } into ct select new { ct.Key.CounterNo };

                //Get CounterList
                foreach (var varCounter in varCounterList.ToList())
                {
                    counterListString.Add(varCounter.CounterNo);
                }
            }
            else
            {
                #region Row_Values

                //Get Row Values List
                foreach (string[] rowValue in cashlist)
                {
                    if (rowValue[9] == null || rowValue[9] == "" || rowValue[9] != this.View.CounterNo)
                        continue;

                    string[] rv = new string[9 + denolist.Count];

                    rv[0] = rowValue[1];
                    rv[1] = rowValue[2];
                    if (this.View.isNoteChange)
                        rv[2] = rowValue[3];
                    else
                        rv[2] = rowValue[14];
                    rv[3] = rowValue[8];

                    int j = 4; int k = 16;
                    for (int i = 0; i < denolist.Count; i++)
                    {
                        rv[j] = rowValue[k];
                        j++; k++;
                    }

                    rv[j++] = rowValue[6].Split(".".ToCharArray())[0];
                    rv[j++] = rowValue[7].Split(".".ToCharArray())[0];
                    rv[j++] = CXCLE00002.Instance.GetDenoAmount(rowValue[15], this.View.CurrencyCode).ToString();
                    rv[j++] = rowValue[5];
                    rv[j++] = rowValue[6];

                    rowValueListString.Add(rv);
                }
                #endregion

                //Get CounterList
                IList<Counter> list = counterList.Where(x => x.CounterNo == this.view.CounterNo).ToList();
                var RowCountByCounter = list.GroupBy(x => x.CounterNo).Select(y => y.Count()).ToList();
                foreach (var rowCount in RowCountByCounter)
                {
                    rowCountByCounter.Add(Convert.ToInt32(rowCount));
                }
                if (rowCountByCounter.Count <= 0)
                {
                    CXUIMessageUtilities.ShowMessageByCode("MI00039");  //No Data For Report
                    return null;
                }
                counterListString = new List<string> { this.view.CounterNo };
            }
            #endregion

            string title = this.GetReportTitle();  // to get report title  

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
                dt.Columns.Add("Refund");
                dt.Columns.Add("+ (Or) -");
                dt.Columns.Add("Transaction Amount");

                object[] obj = new object[dt.Columns.Count];
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    obj[i] = dt.Columns[i].ColumnName;
                }

                dt.Rows.Add(obj);

                object[] row = { "Counter No.:" + counterListString[0].ToString() };
                dt.Rows.Add(row);

                for (int i = 0; i < rowValueListString.Count; i++)
                {
                    object[] FooterValue = { 
                                                        countRow,
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
                                                             rowValueListString[i][20],
                                                             rowValueListString[i][21],
                                                             rowValueListString[i][22],
                                                             rowValueListString[i][23],
                                                             rowValueListString[i][24]
                                                         };
                    dt.Rows.Add(FooterValue);
                    countRow++;
                }
            }
            
            

            object[] obj2 = { "Sub Total Counter No.: [" + counterListString[0][0].ToString() + "]" };
            dt.Rows.Add(obj2);


            //object[] obj3 = new object[dt.Columns.Count];
            //for (int i = 5; i < dt.Columns.Count; i++)
            //{
            //    string _sumColumn = "SUM(" + dt.Columns[i].ColumnName + ")";
            //    obj3[i] = Convert.ToInt32(dt.Compute("SUM({" + i + "})", string.Empty));
            //    //obj3[i] = dt.AsEnumerable().Sum(row => row.Field<int>(dt.Columns[i].ColumnName));
            //}

            //dt.Rows.Add(obj3);

            //Excel Report
            //excelfomat.CashDenominationReportExportToExcel(Branch.BranchDescription, Branch.Address, Branch.Phone, Branch.Fax, title, DateTime.Now, denolist, counterListString, rowCountByCounter, rowValueListString);
            return dt;
        }

        public string GetReportTitle()
        {
          if(this.view.isReceipt)
                this.ReportTitle =  "RECEIVING CASHIER'S REGISTER ("+ this.view.CounterNo + ") BY " + this.view.RequireDate.ToString("dd/MM/yyyy") + " " + ((this.view.isReversal) ? "(Before Editing)" : "(Edited)");
          
          else if(this.view.isPayment)
                this.ReportTitle =  "PAYMENT CASHIER'S REGISTER ("+ this.view.CounterNo + ") BY " + this.view.RequireDate.ToString("dd/MM/yyyy") + " " + ((this.view.isReversal) ? "(Before Editing)" : "(Edited)");
          
          else if(this.view.isReceiptWithdraw)               
                    this.ReportTitle = "COUNTER NO. (" + this.view.CounterNo + ") WITHDRAW REGISTER By " + this.view.RequireDate.ToString("dd/MM/yyyy") + " " + ((this.view.isReversal) ? "(Before Editing)" : "(Edited)");
          
          else if (this.view.isNoteChange)
              this.ReportTitle = "NOTE CHANGE REGISTER (" + this.view.CounterNo + ") BY " + this.view.RequireDate.ToString("dd/MM/yyyy") + " " + ((this.view.isReversal) ? "(Before Editing)" : "(Edited)");

          else if (this.view.isReceiptRefund)
              this.ReportTitle = "RECEIPT REFUND REGISTER (" + this.view.CounterNo + ") BY " + this.view.RequireDate.ToString("dd/MM/yyyy") + " " + ((this.view.isReversal) ? "(Before Editing)" : "(Edited)");
              
          else if (this.view.isMultiTransaction)
              this.ReportTitle = "DENOMINATION REPORT FOR MULTIPLE TRANSACTION BY " + this.view.RequireDate.ToString("dd/MM/yyyy") + " " + ((this.view.isReversal) ? "(Before Editing)" : "(Edited)");                    

            return this.ReportTitle;
        }

        public TLMDTO00015 GetCashDenominationListingEntity()
        {
            TLMDTO00015 cashDenoDTO = new TLMDTO00015();
            cashDenoDTO.Currency = this.view.CurrencyCode;
            return cashDenoDTO;
        }

        public IList<CounterInfoDTO> GetCounterInfo()
        {
            // CXClientWrapper.Instance.Invoke<ITLMSVE00071, CounterInfoDTO>(x => x.GetCounterInfo(CurrentUserEntity.BranchCode));

            IList<CounterInfoDTO> CounterList = new List<CounterInfoDTO>();
            IList<CounterInfoDTO> CounterDataList = new List<CounterInfoDTO>();
            CounterList = CXClientWrapper.Instance.Invoke<ITLMSVE00071, CounterInfoDTO>(x => x.GetCounterInfo(CurrentUserEntity.BranchCode));
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
       
        #endregion

        #region UI Logic

        public void Receipt(bool isreversal)
        {
            if (this.ValidateForm(this.GetEntity()))
            {
                string wherestring = string.Empty;

                wherestring = " WHERE CONVERT(CHAR(10),CASHDATE,111) = " + " '" + this.view.RequireDate.ToString("yyyy/MM/dd") + " '" + " and CUR = " + " '" + this.view.CurrencyCode + "' "
                    + "AND REVERSE = 0 AND STATUS = 'R' AND TLF_ENO NOT LIKE 'V%' AND TLF_ENO NOT LIKE 'N%'  And IsNull(FromType,'')=''";

                if (isreversal)
                {
                    wherestring = " WHERE CONVERT(CHAR(10),CASHDATE,111) = " + " '" + this.view.RequireDate.ToString("yyyy/MM/dd") + " '" + " and CUR = " + " '" + this.view.CurrencyCode + "' "
                    + "AND  STATUS = 'R' AND TLF_ENO NOT LIKE 'V%' AND TLF_ENO NOT LIKE 'N%'  And IsNull(FromType,'')=''";
                }

                wherestring += " And BranchCode = " + " '" + CurrentUserEntity.BranchCode + "'";
                this.CashDenominationListing(wherestring);
            }
        }


        public DataTable Receipt_New(bool isreversal)
        {
            if (this.ValidateForm(this.GetEntity()))
            {
                string wherestring = string.Empty;

                wherestring = " WHERE CONVERT(CHAR(10),CASHDATE,111) = " + " '" + this.view.RequireDate.ToString("yyyy/MM/dd") + " '" + " and CUR = " + " '" + this.view.CurrencyCode + "' "
                    + "AND REVERSE = 0 AND STATUS = 'R' AND TLF_ENO NOT LIKE 'V%' AND TLF_ENO NOT LIKE 'N%'  And IsNull(FromType,'')=''";

                if (isreversal)
                {
                    wherestring = " WHERE CONVERT(CHAR(10),CASHDATE,111) = " + " '" + this.view.RequireDate.ToString("yyyy/MM/dd") + " '" + " and CUR = " + " '" + this.view.CurrencyCode + "' "
                    + "AND  STATUS = 'R' AND TLF_ENO NOT LIKE 'V%' AND TLF_ENO NOT LIKE 'N%'  And IsNull(FromType,'')=''";
                }

                wherestring += " And BranchCode = " + " '" + CurrentUserEntity.BranchCode + "'";
                 return this.CashDenominationListing_New(wherestring);
            }
            return null;
        }

        public DataTable ReceiptRefund(bool isreversal)
        {
            if (this.ValidateForm(this.GetEntity()))
            {
                string wherestring = string.Empty;
                wherestring = " WHERE CONVERT(CHAR(10),CASHDATE,111) = " + " '" + this.view.RequireDate.ToString("yyyy/MM/dd") + " '" + " and CUR = " + " '" + this.view.CurrencyCode + "' "
                      + "AND REVERSE = 0 AND STATUS = 'R' AND TLF_ENO NOT LIKE 'V%' AND TLF_ENO NOT LIKE 'N%'  And IsNull(FromType,'')='' AND isnull(Denorefund_detail, ' ') <> ' '";

                if (isreversal)
                {
                    wherestring = " WHERE CONVERT(CHAR(10),CASHDATE,111) = " + " '" + this.view.RequireDate.ToString("yyyy/MM/dd") + " '" + " and CUR = " + " '" + this.view.CurrencyCode + "' "
                        + "AND  STATUS = 'R' AND TLF_ENO NOT LIKE 'V%' AND TLF_ENO NOT LIKE 'N%'  And IsNull(FromType,'')='' AND isnull(Denorefund_detail, ' ') <> ' '";

                }

                wherestring += " And BranchCode = " + " '" + CurrentUserEntity.BranchCode + "'";
                return this.CashDenominationListing_New(wherestring);

            }
            return null;
        }

        public DataTable ReceiptWithdrawByCounter(bool isreversal)
        {
            if (this.ValidateForm(this.GetEntity()))
            {
                string wherestring = string.Empty;
                wherestring = " WHERE CONVERT(CHAR(10),CASHDATE,111) = " + " '" + this.view.RequireDate.ToString("yyyy/MM/dd") + " '" + " and CUR = " + " '" + this.view.CurrencyCode + "' "
                    + " And REVERSE = 0 And isnull(actype,' ') = ' '  And countertype = 'R' And FromType Like 'Cen%' ";

                if (isreversal)
                {
                    wherestring = " WHERE CONVERT(CHAR(10),CASHDATE,111) = " + " '" + this.view.RequireDate.ToString("yyyy/MM/dd") + " '" + " and CUR = " + " '" + this.view.CurrencyCode + "' "
                     + "And isnull(actype,' ') = ' '  And countertype = 'R' And FromType Like 'Cen%' ";
                }

                wherestring += " And BranchCode = " + " '" + CurrentUserEntity.BranchCode + "'";
                return this.CashDenominationListing_New(wherestring);
            }
            return null;
        }

        public DataTable Payment(bool isreversal)
        {
            if (this.ValidateForm(this.GetEntity()))
            {
                string wherestring = string.Empty;
                wherestring = " WHERE CONVERT(CHAR(10),CASHDATE,111) = " + " '" + this.view.RequireDate.ToString("yyyy/MM/dd") + " '" + " and CUR = " + " '" + this.view.CurrencyCode + "' "
                    + " And REVERSE = 0  AND STATUS = 'P' AND TLF_ENO NOT   LIKE 'V%'  AND TLF_ENO NOT LIKE  'N%' And IsNull(FromType,'')=''";

                if (isreversal)
                {
                    wherestring = " WHERE CONVERT(CHAR(10),CASHDATE,111) = " + " '" + this.view.RequireDate.ToString("yyyy/MM/dd") + " '" + " and CUR = " + " '" + this.view.CurrencyCode + "' "
                      + "  AND STATUS = 'P' AND TLF_ENO NOT   LIKE 'V%'  AND TLF_ENO NOT LIKE  'N%' And IsNull(FromType,'')=''";
                }

                wherestring += " And BranchCode = " + " '" + CurrentUserEntity.BranchCode + "'";
                return this.CashDenominationListing_New(wherestring);
            }
            return null;
        }

        public DataTable NotesChange(bool isreversal)
        {
            if (this.ValidateForm(this.GetEntity()))
            {
                string wherestring = string.Empty;
                wherestring = " WHERE CONVERT(CHAR(10),CASHDATE,111) = " + " '" + this.view.RequireDate.ToString("yyyy/MM/dd") + " '" + " and CUR = " + " '" + this.view.CurrencyCode + "' "
                    + "AND REVERSE = 0 AND FROMTYPE LIKE 'NOTE EXCHANGE%' ";

                if (isreversal)
                {
                    wherestring = " WHERE CONVERT(CHAR(10),CASHDATE,111) = " + " '" + this.view.RequireDate.ToString("yyyy/MM/dd") + " '" + " and CUR = " + " '" + this.view.CurrencyCode + "' "
                      + " AND FROMTYPE LIKE 'NOTE EXCHANGE%' ";
                }

                wherestring += " And BranchCode = " + " '" + CurrentUserEntity.BranchCode + "'";
                return this.CashDenominationListing_New(wherestring);
            }
            return null;
        }

        public void MultiTransactions(bool isreversal)
        {
            IList<TLMDTO00009> resultForMulti = new List<TLMDTO00009>();

            if (this.ValidateForm(this.GetEntity()))
            {
                #region ExcelReportCode
                //string wherestring = string.Empty;
                //wherestring = " WHERE CONVERT(CHAR(10),CASHDATE,111) = " + " '" + this.view.RequireDate.ToString("yyyy/MM/dd") + " '" + " and CUR = " + " '" + this.view.CurrencyCode + "' "
                //    + "AND REVERSE = 0 AND TLF_ENO LIKE 'G%' ";
                //if (isreversal)
                //{
                //    wherestring = " WHERE CONVERT(CHAR(10),CASHDATE,111) = " + " '" + this.view.RequireDate.ToString("yyyy/MM/dd") + " '" + " and CUR = " + " '" + this.view.CurrencyCode + "' "
                //       + "AND TLF_ENO LIKE 'G%' ";
                //}

                //wherestring += " And BranchCode = " + " '" + CurrentUserEntity.BranchCode + "'";
                //this.CashDenominationListing(wherestring);

                #endregion

                #region GetReportData

                if (this.view.isMultiTransaction)
                {
                    resultForMulti = CXClientWrapper.Instance.Invoke<ITLMSVE00071, IList<TLMDTO00009>>(x => x.SelectDenoForMultiTransaction(this.view.CurrencyCode, CurrentUserEntity.BranchCode, this.view.RequireDate, false, "all"));
                }
                else
                    resultForMulti = CXClientWrapper.Instance.Invoke< ITLMSVE00071 , IList<TLMDTO00009>>( x => x.SelectDenoForMultiTransaction(this.view.CurrencyCode,CurrentUserEntity.BranchCode,this.view.RequireDate, true , this.view.CounterNo));

                #endregion

                if (resultForMulti.Count == null || resultForMulti.Count == 0)
                {
                    CXUIMessageUtilities.ShowMessageByCode("MI00039"); //No data for Report.
                }
                else
                {   // if u choose multi transactions radio button
                    CXUIScreenTransit.Transit("frmTLMVEW00077", true, new object[] { this.GetReportTitle(), resultForMulti });
                }
            }
        }

        private TLMDTO00015 GetEntity()
        {
           TLMDTO00015 entity = new TLMDTO00015();
            entity.Currency = this.view.CurrencyCode;
            entity.CounterNo = this.view.CounterNo;
           return entity;
        }
        #endregion

    }
}
