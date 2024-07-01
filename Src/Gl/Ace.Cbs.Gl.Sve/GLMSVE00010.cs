using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Core.Service;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Gl.Dmd;
using Ace.Cbs.Gl.Ctr.Sve;

namespace Ace.Cbs.Gl.Sve
{
    public class GLMSVE00010 : BaseService, IGLMSVE00010
    {
        public ICXDAO00010 GetIncomeExpenditureDAO { get; set; }

        private ICXDAO00014 bLFDAO;
        public ICXDAO00014 BLFDAO
        {
            get { return this.bLFDAO; }
            set { this.bLFDAO = value; }
        }

        public GLMSVE00010() { }

        public IList<GLMDTO00013> SelectIncomeExpenditure(string budMonth, string year, int month, string branchCode)
        {
            // Modified by ZMS (2018/09/18) for Budget Month Flexible
            string Return = string.Empty;
            DateTime tempDate = Convert.ToDateTime(Convert.ToString(year) + "/" + Convert.ToString(month) + "/" + Convert.ToString(DateTime.Now.Day));
            budMonth = BLFDAO.GetBudget_Month_Year_Quarter(3, tempDate,branchCode, Return);  // For 2018/09/17 => 6
            budMonth = "MSRC" + budMonth;

            IList<GLMDTO00013> DTO = this.GetIncomeExpenditureDAO.SelectIncomeExpenditure(budMonth,year,month);
            if (DTO.Count <= 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                return null;
            }
            else
            {
                this.ServiceResult.ErrorOccurred = false;
            }
            return DTO;
        }
    }
}
