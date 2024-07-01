using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Tcm.Ctr.Sve;

namespace Ace.Cbs.Tcm.Ptr
{
    public class TCMCTL00026 : AbstractPresenter, ITCMCTL00026
    {
        #region Properties
        private ITCMVEW00026 view;
        public ITCMVEW00026 View
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }
        #endregion

        #region Methods

        private void WireTo(ITCMVEW00026 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetViewData());
            }
        }

        public void ClearCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }

        public PFMDTO00042 GetViewData()
        {
            PFMDTO00042 ViewData = new PFMDTO00042();
            ViewData.BranchName = this.view.Branch;
            ViewData.IsAllBranches = this.view.IsAllBranch;
            ViewData.StartDate = this.view.Date;
            ViewData.CurrencyType = this.view.CurrencyType;
            ViewData.CurCode = this.view.Currency;
            ViewData.IsWithReversal = this.view.IsWithReversal;
            ViewData.IsHomeCurrency = this.view.IsByHomeCurrency;
            ViewData.CreatedUserId = CurrentUserEntity.CurrentUserID;
            //*
            string Branch = CurrentUserEntity.IsHOUser ? this.view.IsAllBranch ? string.Empty : this.view.BranchCode : CurrentUserEntity.BranchCode;
            ViewData.SourceBranch = Branch;
            //
            //ViewData.SourceBranch = this.view.BranchCode;
            ViewData.BankName = ViewData.SourceBranch + "( " + CurrentUserEntity.BranchDescription + " )";
            ViewData.WorkStationId = CurrentUserEntity.WorkStationId;
            ViewData.Status = this.view.DateType;
            return ViewData;
        }

        public void Print()
        {
            if (this.ValidateForm(GetViewData()))
            {
                if (!CXCOM00006.Instance.IsExceedTodayDate(this.view.Date))
                {
                    IList<PFMDTO00042> PrintDataLists = new List<PFMDTO00042>();
                    PFMDTO00042 DataDTO = this.GetViewData();

                    //datas for print
                    PrintDataLists = CXClientWrapper.Instance.Invoke<ITCMSVE00026, IList<PFMDTO00042>>(x => x.GetReportData(DataDTO));

                    string title1 = "Clean Cash Report Without Reversal By Date";
                    string title2 = "Clean Cash Report With Reversal By Date";

                    if (PrintDataLists.Count > 0)
                    {
                        #region Report Parameters
                        string Date = view.Date.ToString("dd/MM/yyyy");
                        //string branch=(this.view.AllBranches==true)?"All Branches":"Branch:" + " " + this.view.Branch;
                        string branch = this.view.Branch;

                        string currency = string.Empty;
                        if (this.view.CurrencyType == "Home Currency")
                        { currency = "All Currencies By Home Amount"; }
                        else
                        {
                            if (this.view.IsByHomeCurrency == true)
                            {
                                currency = " " + this.view.Currency + " " + "By Home Amount";
                            }
                            else
                            {
                                currency = " " + this.view.Currency;
                            }
                        }
                        #endregion

                        if (this.view.IsAllBranch)
                        {
                            if (this.view.CurrencyType == "Home Currency")
                            {
                                if (this.view.IsWithReversal)
                                {
                                    //All Branches,Home Currency,With Reversal
                                    //header = "Clean Cash Scroll Report With Reversal All Transactions by Home Currency at Date";
                                    CXUIScreenTransit.Transit("frmTCMCleanCashReport", true, new object[] { PrintDataLists, title2, Date, branch, currency });
                                }
                                else
                                {
                                    //All Branches,Home Currency,Without Reversal
                                    //header = "Clean Cash Scroll Report Without Reversal All Transactions by Home Currency at Date";
                                    CXUIScreenTransit.Transit("frmTCMCleanCashReport", true, new object[] { PrintDataLists, title1, Date, branch, currency });
                                }
                            }
                            else
                            {
                                if (this.view.IsWithReversal)
                                {
                                    if (this.view.IsByHomeCurrency)
                                    {
                                        //All Branches,Source Currency,With Reversal,By Home Currency
                                        //header = "Clean Cash Scroll Report With Reversal All Transactions by Home Currency at Date";
                                        CXUIScreenTransit.Transit("frmTCMCleanCashReport", true, new object[] { PrintDataLists, title2, Date, branch, currency });
                                    }
                                    else
                                    {
                                        //All Branches,Source Currency,With Reversal,Not By Home Currency
                                        //header = "Clean Cash Scroll Report With Reversal All Transactions at Date";
                                        CXUIScreenTransit.Transit("frmTCMCleanCashReport", true, new object[] { PrintDataLists, title2, Date, branch, currency });
                                    }
                                }
                                else
                                {
                                    if (this.view.IsByHomeCurrency)
                                    {
                                        //All Branches,Source Currency,Without Reversal,By Home Currency
                                        //header = "Clean Cash Scroll Report Without Reversal All Transactions by Home Currency at Date";
                                        CXUIScreenTransit.Transit("frmTCMCleanCashReport", true, new object[] { PrintDataLists, title1, Date, branch, currency });
                                    }
                                    else
                                    {
                                        //All Branches,Source Currency,Without Reversal,Not By Home Currency
                                        //header = "Clean Cash Scroll Report Without Reversal All Transactions at Date";
                                        CXUIScreenTransit.Transit("frmTCMCleanCashReport", true, new object[] { PrintDataLists, title1, Date, branch, currency });
                                    }
                                }
                            }
                        }
                        else if (!this.view.IsAllBranch)
                        {
                            if (this.view.CurrencyType == "Home Currency")
                            {
                                if (this.view.IsWithReversal)
                                {
                                    //One Branch,Home Currency,With Reversal
                                    //header = "Clean Cash Scroll Report With Reversal All Transactions by Home Currency at Date";
                                    CXUIScreenTransit.Transit("frmTCMCleanCashReport", true, new object[] { PrintDataLists, title2, Date, branch, currency });
                                }
                                else
                                {
                                    //One Branch,Home Currency,Without Reversal
                                    //header = "Clean Cash Scroll Report Without Reversal All Transactions by Home Currency at Date";
                                    CXUIScreenTransit.Transit("frmTCMCleanCashReport", true, new object[] { PrintDataLists, title1, Date, branch, currency });
                                }
                            }
                            else
                            {
                                if (this.view.IsWithReversal)
                                {
                                    if (this.view.IsByHomeCurrency)
                                    {
                                        //One Branch,Source Currency,With Reversal,By Home Currency
                                        //header = "Clean Cash Scroll Report With Reversal Transactions by Home Currency at Date";
                                        CXUIScreenTransit.Transit("frmTCMCleanCashReport", true, new object[] { PrintDataLists, title2, Date, branch, currency });
                                    }
                                    else
                                    {
                                        //One Branch,Source Currency,With Reversal,Not By Home Currency
                                        //header = "Clean Cash Scroll Report With Reversal Transactions at Date";
                                        CXUIScreenTransit.Transit("frmTCMCleanCashReport", true, new object[] { PrintDataLists, title2, Date, branch, currency });
                                    }
                                }
                                else
                                {
                                    if (this.view.IsByHomeCurrency)
                                    {
                                        //One Branch,Source Currency,Without Reversal,By Home Currency
                                        //header = "Clean Cash Scroll Report Without Reversal Transactions by Home Currency at Date";
                                        CXUIScreenTransit.Transit("frmTCMCleanCashReport", true, new object[] { PrintDataLists, title1, Date, branch, currency });
                                    }
                                    else
                                    {
                                        //One Branch,Source Currency,Without Reversal,Not By Home Currency
                                        //header = "Clean Cash Scroll Report Without Reversal Transactions at Date";
                                        CXUIScreenTransit.Transit("frmTCMCleanCashReport", true, new object[] { PrintDataLists, title1, Date, branch, currency });
                                    }
                                }

                            }

                        }
                        // modified by ZMS 
                        //else
                        //{
                        //    //if PrintDataLists is null
                        //    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Print.
                        //}
                    }
                    //else
                    //{
                    //    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00160, this.view.Date);//Datetime cannot be greater than today date.
                    //    return;
                    //}
                    else  // modified by ZMS 
                    {
                        //if PrintDataLists is null
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");// No data for Report.
                    }
                }
                else
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00160, this.view.Date);//Datetime cannot be greater than today date.
                    return;
                }
            }
        }
        
        #endregion

    }
}