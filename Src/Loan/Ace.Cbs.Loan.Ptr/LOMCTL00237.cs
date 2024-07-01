using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
using System.Windows.Forms;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Cx.Com.Ctr;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00237 : AbstractPresenter, ILOMCTL00237
    {
        string header = "";
        string showDate = "";
        private ILOMVEW00239 view;
        public ILOMVEW00239 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00239 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }

        private CXDMD00010 permissionEntity;
        public CXDMD00010 PermissionEntity
        {
            get
            {
                if (permissionEntity == null)
                    permissionEntity = new CXDMD00010();
                return permissionEntity;
            }
            set
            {
                permissionEntity = value;
            }
        }

        //Added by YMP at 30-07-2019 : [Seperating EOD Process] To show system date (not PC date) at report
        public DateTime GetSystemDate(string sourceBr)
        {
            TCMDTO00001 systemStartInfo = CXClientWrapper.Instance.Invoke<ICXSVE00006, TCMDTO00001>(x => x.SelectStartBySourceBr(sourceBr));
            DateTime systemDate = systemStartInfo.Date;
            return systemDate;
        }

        //Added by HMW at 26-08-2019 : [Seperating EOD Process] Check Settlement Date to show form
        public DateTime GetLastSettlementDate(string sourceBr)
        {
            DateTime lastSettlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.LastSettlementDate), sourceBr);
            return lastSettlementDate;
        }

        public string Get_HPInfo_ByHPNo(string hpNo)
        {
           string str=CXClientWrapper.Instance.Invoke<ILOMSVE00096, string>(x => x.Get_HPInfo_ByHPNo(hpNo));
           return str;
        }

        public string HP_Registration_Reversal(string hpNo, string reversalEno, int createdUserId, string sourceBr)
        {
            if (CXUIScreenTransit.Transit("frmCXCLE00016", true, new object[] { "frmLOMVEW00325", CXDMD00006.Other, PermissionEntity, false }) == DialogResult.OK)
            {
                string str = CXClientWrapper.Instance.Invoke<ILOMSVE00096, string>(x => x.HP_Registration_Reversal(hpNo, reversalEno, createdUserId, sourceBr));
                return str;
            }
            else return null;
        }

        public string Get_PLInfo_ByPLNo(string plNo)
        {
            string str = CXClientWrapper.Instance.Invoke<ILOMSVE00096, string>(x => x.Get_PLInfo_ByPLNo(plNo));
            return str;
        }

        public string PL_Registration_Reversal(string plNo, int createdUserId, string sourceBr,string formatCode
                                                , int valueCount, string valueStr)
        {
            if (CXUIScreenTransit.Transit("frmCXCLE00016", true, new object[] { "frmLOMVEW00325", CXDMD00006.Other, PermissionEntity, false }) == DialogResult.OK)
            {
                string str = CXClientWrapper.Instance.Invoke<ILOMSVE00096, string>(x => x.PL_Registration_Reversal(plNo, createdUserId, sourceBr,formatCode,valueCount,valueStr));
                return str;
            }
            else return null;
        }

        

        #region For Year End Zerorization Voucher for "Income A/C"
        //Added by HMW (23-Sept-2018)
        public string Check_AlreadyZerorizationForIncomeAC(string ProfitAndLossAC)
        {
            string Msg = CXClientWrapper.Instance.Invoke<ILOMSVE00096, string>(x => x.Check_AlreadyZerorizationForIncomeAC(ProfitAndLossAC));
            return Msg;
        }       
        //Added by AAM (28-Mar-2018)
        public string Get_Info_For_PNL_Zerorization_Income_ByPLAC(string plAC, string sourceBr)
        {
            string str = CXClientWrapper.Instance.Invoke<ILOMSVE00096, string>(x => x.Get_Info_For_PNL_Zerorization_Income_ByPLAC(plAC, sourceBr));
            return str;
        }
        public IList<LOMDTO00239> Get_PNL_Zerorization_Income_Info(string sourceBr)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00239>>(x => x.Get_PNL_Zerorization_Income_Info(sourceBr));
        }
        public string PNL_Zerorization_Income_Voucher(string pnlAC, int createdUserId, string sourceBr)
        {
            string str = CXClientWrapper.Instance.Invoke<ILOMSVE00096, string>(x => x.PNL_Zerorization_Income_Voucher(pnlAC,createdUserId,sourceBr));
            return str;
        }
        #endregion

        #region For Year End Zerorization Voucher for "Expense A/C"
        //added by HMW (23-Sept-2018)
        public string Check_AlreadyZerorizationForExpenseAC(string ProfitAndLossAC)
        {
            string Msg = CXClientWrapper.Instance.Invoke<ILOMSVE00096, string>(x => x.Check_AlreadyZerorizationForExpenseAC(ProfitAndLossAC));
            return Msg;
        }
        //added by AAM (28-Mar-2018)
        public IList<LOMDTO00239> Get_Expn_Zerorization_Expense_Info(string sourceBr)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00239>>(x => x.Get_Expn_Zerorization_Expense_Info(sourceBr));
        }
        public string Get_Info_For_Expn_Zerorization_Expense_ByExpnAC(string expnAC, string sourceBr)
        {
            string str = CXClientWrapper.Instance.Invoke<ILOMSVE00096, string>(x => x.Get_Info_For_Expn_Zerorization_Expense_ByExpnAC(expnAC, sourceBr));
            return str;
        }
        public string Expn_Zerorization_Expense_Voucher(string expnAC, int createdUserId, string sourceBr)
        {
            string str = CXClientWrapper.Instance.Invoke<ILOMSVE00096, string>(x => x.Expn_Zerorization_Expense_Voucher(expnAC,createdUserId,sourceBr));
            return str;
        }
        #endregion

        public string Get_BLInfo_ByBLNo(string blNo)
        {
            string str = CXClientWrapper.Instance.Invoke<ILOMSVE00096, string>(x => x.Get_BLInfo_ByBLNo(blNo));
            return str;
        }

        public string BL_Registration_Reversal(string blNo, string formatCode, int createdUserId, string sourceBr)//Modify by HMW at 27-08-2019
        {
            if (CXUIScreenTransit.Transit("frmCXCLE00016", true, new object[] { "frmLOMVEW00325", CXDMD00006.Other, PermissionEntity, false }) == DialogResult.OK)
            {
                string str = CXClientWrapper.Instance.Invoke<ILOMSVE00096, string>(x => x.BL_Registration_Reversal(blNo,formatCode,createdUserId,sourceBr));
                return str;
            }
            else return null;
        }

        public IList<LOMDTO00241> Get_HPList_For_Interest_Prepay_ByDealer(LOMDTO00241 hpListBydealer)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00241>>(x => x.Get_HPList_For_Interest_Prepay_ByDealer(hpListBydealer));
        }

        public string Dealer_Interest_Prepaid_ForHP(LOMDTO00241 hpListBydealer)
        {
            string str = CXClientWrapper.Instance.Invoke<ILOMSVE00096, string>(x => x.Dealer_Interest_Prepaid_ForHP(hpListBydealer));
            return str;
        }

        public void Print(LOMDTO00242 hpIntPrepaidList)
        {
            IList<LOMDTO00242> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00242>>(x => x.HPInterestPrepaidByDealer_Listing(hpIntPrepaidList));
            if (DTOList.Count > 0)
            {
                string currency = hpIntPrepaidList.Currency.ToString();

                if (hpIntPrepaidList.searchByOpt == "All") header = "Hire Purchase Interest Prepaid All Listing";
                else header = "Hire Purchase Interest Prepaid Installment Listing";

                if (hpIntPrepaidList.StartDate.ToString("yyyyMMdd") == hpIntPrepaidList.EndDate.ToString("yyyyMMdd"))
                    showDate = "At " + hpIntPrepaidList.StartDate.ToString("dd/MM/yyyy");
                else
                    showDate = "From " + hpIntPrepaidList.StartDate.ToString("dd/MM/yyyy") + " To " + hpIntPrepaidList.EndDate.ToString("dd/MM/yyyy");

                if (hpIntPrepaidList.StockGroupCode == "")
                    CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, hpIntPrepaidList.Currency, header, 
                        hpIntPrepaidList.SourceBr, showDate, hpIntPrepaidList.rptName, "ALL" 
                        ,hpIntPrepaidList.storedName});
                else
                {
                    hpIntPrepaidList.StockGroupDesp = DTOList[0].StockGroupDesp;
                    CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, hpIntPrepaidList.Currency, header,
                        hpIntPrepaidList.SourceBr, showDate, hpIntPrepaidList.rptName, hpIntPrepaidList.StockGroupDesp
                        ,hpIntPrepaidList.storedName });
                }

            }

            else
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
            }
        }

    }
}
