﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Ctr.Dao;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00047 : BaseService, ILOMSVE00047
    {
        #region Properties
        public ILOMDAO00047 LoansRepaymentScheduleByDateDAO { get; set; }
        #endregion

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00047> SelectLoansRepaymentScheduleByDate(LOMDTO00047 dto)
        {
            IList<LOMDTO00047> DataList = new List<LOMDTO00047>();
            DataList = LoansRepaymentScheduleByDateDAO.SelectLoansRepaymentScheduleByDate(dto.StartDate, dto.EndDate, dto.Lno, dto.Cur, dto.SourceBr);
            return DataList;
        }

    }
}