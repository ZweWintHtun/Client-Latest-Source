using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tcm.Ptr
{
    public class TCMCTL00066 : AbstractPresenter, ITCMCTL00066
    {
        private ITCMVEW00066 view;
        public ITCMVEW00066 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ITCMVEW00066 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetEntity());
            }
        }

        public TCMDTO00013 GetEntity()
        {
            TCMDTO00013 entity = new TCMDTO00013();
            entity.currency = this.view.currency;

            return entity;
        }

        #region Main Method
        public void Preview()
        {
            PFMDTO00042 ledger_rawdata = new PFMDTO00042();
            IList<TCMDTO00013> TCMDataDTOList = new List<TCMDTO00013>();

            ledger_rawdata.Description = this.view.transactionType;   // all or current or saving or fixed accountno
            ledger_rawdata.Status = this.view.typeofSort;             // sorting type to sort report data
            ledger_rawdata.StartDate = this.view.StartDate; 
            ledger_rawdata.EndDate = this.view.EndDate;
            ledger_rawdata.WorkStationId = CurrentUserEntity.WorkStationId ;
            ledger_rawdata.SourceBranch = CurrentUserEntity.BranchCode;
            ledger_rawdata.CreatedUserId = CurrentUserEntity.CurrentUserID;

            // Home Currency ......................
            #region Home Currency
            if (this.view.currencyType == "Home Currency")
            {
                CurrencyDTO curdto = CXCOM00011.Instance.GetScalarObject<CurrencyDTO>("Cur.HomeCur.Select", new object[] { true });

                ledger_rawdata.SourceCur = curdto.Cur;
               
                             
                #region oldcode
                //if (this.view.transactionType == "All")
                //{
                //    PFMDataDTOList = CXClientWrapper.Instance.Invoke<ITCMSVE00066, IList<PFMDTO00042>>(x => x.SelectAcctNoAbyWorkstation(CurrentUserEntity.WorkStationId, curdto.Cur));
                //}
                //else if (this.view.transactionType == "Current")
                //{
                //    PFMDataDTOList = CXClientWrapper.Instance.Invoke<ITCMSVE00066, IList<PFMDTO00042>>(x => x.SelectAcctNoCbyWorkstation(CurrentUserEntity.WorkStationId, curdto.Cur));
                //}
                //else if (this.view.transactionType == "Saving")<ITCMSVE00066, IList<PFMDTO00042>>(x => x.SelectAcctNoSbyWorkstation(CurrentUserEntity.WorkStationId, curdto.Cur));
                //}
                //{
                //    PFMDataDTOList = CXClientWrapper.Instance.Invoke
                //else if (this.view.transactionType == "Fix")
                //{
                //    PFMDataDTOList = CXClientWrapper.Instance.Invoke<ITCMSVE00066, IList<PFMDTO00042>>(x => x.SelectAcctNoFbyWorkstation(CurrentUserEntity.WorkStationId, curdto.Cur));                                                                                                            
                //}
                #endregion 

                if (!this.view.transactionType.Contains("OverDrawn"))
                {
                    TCMDataDTOList = CXClientWrapper.Instance.Invoke<ITCMSVE00066, IList<TCMDTO00013>>(x => x.SelectLedgerBalanceByTransaction(ledger_rawdata));
                }
                else
                {
                    TCMDataDTOList = CXClientWrapper.Instance.Invoke<ITCMSVE00066, IList<TCMDTO00013>>(x => x.SelectAcctNoByOverDrawn(ledger_rawdata));
                }
                    #region oldcode 
                    //if (PFMDataDTOList.Count <= 0 && this.view.transactionType != "OverDrawn")
                    //{
                    //    CXUIMessageUtilities.ShowMessageByCode("MI00039"); //No data for Report.
                    //}

                    //if (PFMDataDTOList.Count > 0)
                    //{
                    //    if (this.view.transactionType == "All")
                    //    {
                    //        TCMDataDTOList = CXClientWrapper.Instance.Invoke<ITCMSVE00066, IList<TCMDTO00013>>(x => x.SelectAcctNoByAll(CurrentUserEntity.WorkStationId, curdto.Cur, this.view.typeofSort));
                    //    }
                    //    else if (this.view.transactionType == "Current")
                    //    {
                    //        TCMDataDTOList = CXClientWrapper.Instance.Invoke<ITCMSVE00066, IList<TCMDTO00013>>(x => x.SelectAcctNoByCurrent(CurrentUserEntity.WorkStationId, curdto.Cur, this.view.typeofSort));
                    //    }
                    //    else if (this.view.transactionType == "Saving")
                    //    {
                    //        TCMDataDTOList = CXClientWrapper.Instance.Invoke<ITCMSVE00066, IList<TCMDTO00013>>(x => x.SelectAcctNoBySaving(CurrentUserEntity.WorkStationId, curdto.Cur, this.view.typeofSort));
                    //    }
                    //    else if (this.view.transactionType == "Fix")
                    //    {
                    //        TCMDataDTOList = CXClientWrapper.Instance.Invoke<ITCMSVE00066, IList<TCMDTO00013>>(x => x.SelectAcctNoByFixed(CurrentUserEntity.WorkStationId, curdto.Cur, this.view.typeofSort));
                    //    }
                    //    //else
                    //    //{
                    //    //    TCMDataDTOList = CXClientWrapper.Instance.Invoke<ITCMSVE00066, IList<TCMDTO00013>>(x => x.SelectAcctNoByOverDrawn(CurrentUserEntity.WorkStationId, curdto.Cur, this.view.typeofSort));
                    //    //}
                    //    CXUIScreenTransit.Transit("frmTCMVEW00067.ReportViewer", true, new object[] { TCMDataDTOList, this.view.transactionType, curdto.Cur });
                    //}
                    #endregion

                if (TCMDataDTOList != null && TCMDataDTOList.Count > 0)
                {                   
                     CXUIScreenTransit.Transit("frmTCMVEW00067.ReportViewer", true, new object[] { TCMDataDTOList, this.view.transactionType, curdto.Cur });
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode("MI00039"); //No data for Report.
                }
                
            }
            #endregion

            // Source Currency..............
            #region Source Currency
            else
            {
                #region oldcode 
                //if (this.view.transactionType == "All")
                //{
                //    PFMDataDTOList = CXClientWrapper.Instance.Invoke<ITCMSVE00066, IList<PFMDTO00042>>(x => x.SelectAcctNoAbyWorkstation(CurrentUserEntity.WorkStationId, this.view.currency));
                //}
                //else if (this.view.transactionType == "Current")
                //{
                //    PFMDataDTOList = CXClientWrapper.Instance.Invoke<ITCMSVE00066, IList<PFMDTO00042>>(x => x.SelectAcctNoCbyWorkstation(CurrentUserEntity.WorkStationId, this.view.currency));
                //}
                //else if (this.view.transactionType == "Saving")
                //{
                //    PFMDataDTOList = CXClientWrapper.Instance.Invoke<ITCMSVE00066, IList<PFMDTO00042>>(x => x.SelectAcctNoSbyWorkstation(CurrentUserEntity.WorkStationId, this.view.currency));
                //}
                //else if (this.view.transactionType == "Fix")
                //{
                //    PFMDataDTOList = CXClientWrapper.Instance.Invoke<ITCMSVE00066, IList<PFMDTO00042>>(x => x.SelectAcctNoFbyWorkstation(CurrentUserEntity.WorkStationId, this.view.currency));
                //}
                #endregion

                ledger_rawdata.SourceCur = this.view.currency;
               
                if (!this.view.transactionType.Contains("OverDrawn"))
                {
                    TCMDataDTOList = CXClientWrapper.Instance.Invoke<ITCMSVE00066, IList<TCMDTO00013>>(x => x.SelectLedgerBalanceByTransaction(ledger_rawdata));
                }
                else
                {
                    TCMDataDTOList = CXClientWrapper.Instance.Invoke<ITCMSVE00066, IList<TCMDTO00013>>(x => x.SelectAcctNoByOverDrawn(ledger_rawdata));
                }
                    #region oldcode

                    //if (PFMDataDTOList.Count > 0)
                //{
                //    if (this.view.transactionType == "All")
                //    {
                //        TCMDataDTOList = CXClientWrapper.Instance.Invoke<ITCMSVE00066, IList<TCMDTO00013>>(x => x.SelectAcctNoByAll(CurrentUserEntity.WorkStationId, this.view.currency, this.view.typeofSort));
                //    }
                //    else if (this.view.transactionType == "Current")
                //    {
                //        TCMDataDTOList = CXClientWrapper.Instance.Invoke<ITCMSVE00066, IList<TCMDTO00013>>(x => x.SelectAcctNoByCurrent(CurrentUserEntity.WorkStationId, this.view.currency, this.view.typeofSort));
                //    }
                //    else if (this.view.transactionType == "Saving")
                //    {
                //        TCMDataDTOList = CXClientWrapper.Instance.Invoke<ITCMSVE00066, IList<TCMDTO00013>>(x => x.SelectAcctNoBySaving(CurrentUserEntity.WorkStationId, this.view.currency, this.view.typeofSort));
                //    }
                //    else if (this.view.transactionType == "Fix")
                //    {
                //        TCMDataDTOList = CXClientWrapper.Instance.Invoke<ITCMSVE00066, IList<TCMDTO00013>>(x => x.SelectAcctNoByFixed(CurrentUserEntity.WorkStationId, this.view.currency, this.view.typeofSort));
                //    }                    
                //    CXUIScreenTransit.Transit("frmTCMVEW00067.ReportViewer", true, new object[] { TCMDataDTOList, this.view.transactionType, this.view.currency });
                    //}
                    #endregion 

                if (TCMDataDTOList != null && TCMDataDTOList.Count > 0)
                {                  
                        CXUIScreenTransit.Transit("frmTCMVEW00067.ReportViewer", true, new object[] { TCMDataDTOList, this.view.transactionType, this.view.currency });                   
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode("MI00039"); //No data for Report.
                }
            
            }
            #endregion
        }
        #endregion

        #region Helper Property and Method
   
        public bool CheckDate()
        {
            bool date = CXCOM00006.Instance.IsValidStartDateEndDate(this.View.StartDate, this.View.EndDate);
            if (date == false)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00123");
            }
            return date;
        }
        #endregion
    }
}
