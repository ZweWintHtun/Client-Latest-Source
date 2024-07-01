using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Sam.Ctr.SVE;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Admin.Contracts.Dao;
using Ace.Cbs.Tel.Ctr.Dao;

namespace Ace.Cbs.Sam.Sve
{
    public class SAMSVE00054 : BaseService, ISAMSVE00054
    {
        private IBranchDAO branchDAO;
        public IBranchDAO BranchDAO
        {
            get { return this.branchDAO; }
            set { this.branchDAO = value; }
        }


        private ITLMDAO00032 rmitRateDAO;
        public ITLMDAO00032 RmitRateDAO
        {
            get { return this.rmitRateDAO; }
            set { this.rmitRateDAO = value; }
        }

        public IList<BranchDTO> SelectBranch()
        {
           return this.BranchDAO.SelectAll();
        }

        public IList<TLMDTO00032> SelectRmitRate()
        {
            return RmitRateDAO.SelectRmitRatewithRemitBrandBranch();
        }
    }
}
