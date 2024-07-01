using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.Core.Service;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Spring.Data.NHibernate;
using Spring.Data.NHibernate.Support;
using Ace.Windows.Admin.DataModel;
////////
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00034 : BaseService, ILOMSVE00034
    {
        #region Properties
        public ILOMDAO00034 LoanRegistrationListingDAO { get; set; }
        public ILOMDAO00096 BLInfoListingDAO { get; set; }
        #endregion

        #region GetReportData Method
        //[Transaction(TransactionPropagation.Required)]
        //public IList<LOMDTO00034> GetReportData(LOMDTO00034 dto, bool IsByloan)
        //{

        //    IList<LOMDTO00034> DataList = new List<LOMDTO00034>();
        //    if(IsByloan == true)
        //    {
        //        DataList = ViewDAO.SelectLoanListing(dto.LOANS_TYPE, dto.StartDate, dto.EndDate, dto.SourceBr, dto.Currency);
        //    }
        //    else
        //    {
        //        DataList = ViewDAO.SelectLoanListingAll(dto.StartDate, dto.EndDate, dto.SourceBr, dto.Currency);
        //    }

        //    return DataList;
        //}
        #endregion

         [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00034>  SelectLoanListing(string loans, DateTime startDate, DateTime endDate, string sourceBranchCode, string cur)
        {
            IList<LOMDTO00034> LoanList = new List<LOMDTO00034>();
            LoanList = LoanRegistrationListingDAO.SelectLoanListing(loans, startDate, endDate, sourceBranchCode, cur);
            return LoanList;
        }
         [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00034> SelectLoanListingAll(DateTime startDate, DateTime endDate, string sourceBranchCode, string cur)
        {
            IList<LOMDTO00034> LoanList = new List<LOMDTO00034>();
            LoanList = LoanRegistrationListingDAO.SelectLoanListingAll(startDate, endDate, sourceBranchCode, cur);
            return LoanList;
        }
        
        [Transaction(TransactionPropagation.Required)]
         public IList<LOMDTO00204> GetBLInfoListingByDateRange(DateTime startDate, DateTime endDate, string sourceBranchCode, string businessType)
        {
            IList<LOMDTO00204> BLInfoList = new List<LOMDTO00204>();
            BLInfoList = BLInfoListingDAO.GetBLInfoListingByDateRange(startDate, endDate, sourceBranchCode, businessType);
            return BLInfoList;
        }
    }
}
