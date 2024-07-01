using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.CBM.Ctr.Sve;
using Ace.Cbs.CBM.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.CBM.Sve
{
    public class CBMSVE00001 : BaseService, ICBMSVE00001
    {
        ICBMDAO00001 CashInHandDAO { get; set; }

        public IList<PFMDTO00042> GetAll_CBMDataByDateAndName(DateTime date,string fname,string Currency)
        {
            IList<PFMDTO00042> list = new List<PFMDTO00042>();
            try
            {
                switch (fname)
                {
                    case "CashInHand": 
                        list = this.CashInHandDAO.GetAll_CashInHandPosition(date,Currency); break;
                    //case "Position": 
                    //    list = this.CashInHandDAO.GetAll_DailyPosition_CBM(date); break;
                    case "DailyPosition": 
                        list = this.CashInHandDAO.GetAll_DailyPosition_CBM(date,Currency); break;
                    case "FinancialStatement": 
                        list = GetFinancialStatementData(date, Currency); break;
                    case "DailyImprovement":
                        int budgetMonth = Convert.ToInt32(CXCOM00010.Instance.GetBudgetYear2(CXCOM00009.BudgetYearCode, date));
                        list = this.CashInHandDAO.GetAll_DailyImprovement_CBM(date,budgetMonth,Currency); break;
                    case "DailyProgress":
                        int month = Convert.ToInt32(CXCOM00010.Instance.GetBudgetYear2(CXCOM00009.BudgetYearCode, date));
                        list = this.CashInHandDAO.GetAll_DailyProgress_CBM(date, month,Currency); break;
                    case "LiquidityRatio":
                        int Bmonth = Convert.ToInt32(CXCOM00010.Instance.GetBudgetYear2(CXCOM00009.BudgetYearCode, date));
                        list = this.CashInHandDAO.GetAll_DailyProgress_CBM(date, Bmonth, Currency); break;
                }
                if (list == null || list.Count == 0) throw new Exception();                
                return list;
            }
            catch (Exception e)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90033";
                return list;
            }
        }

        public PFMDTO00042 GetAllData_CBM(DateTime date,string fname,string Currency)
        {
            PFMDTO00042 Dtodata = new PFMDTO00042();
            try
            {
                if (fname.Contains("Flow"))
                    Dtodata = this.CashInHandDAO.GetAll_CashFlowData_CBM(date, Currency);
                else Dtodata = this.CashInHandDAO.Get_Liquidity_Ratio_CBM(date, Currency);
                if (Dtodata == null)
                    this.ServiceResult.MessageCode = "ME90033"; //No Data for Report.
                return Dtodata;
            }
            catch (Exception e)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90033";
                return Dtodata;
            }
        }

        public IList<PFMDTO00042> GetFinancialStatementData(DateTime date,string Currency)
        {
            IList<PFMDTO00042> list = new List<PFMDTO00042>();
            list = this.CashInHandDAO.GetAll_FinancialStatement_CBM(date, Currency);
            if (list == null || list.Count == 0)
                this.ServiceResult.MessageCode = "ME90033"; //No Data for Report.
            else
                return list;
            return list;
        }

    }
}
