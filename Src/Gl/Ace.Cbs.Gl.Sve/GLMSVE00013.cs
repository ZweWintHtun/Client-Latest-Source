using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Gl.Dmd;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Gl.Ctr.Dao;
using Ace.Cbs.Gl.Ctr.Sve;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Gl.Sve
{
    public class GLMSVE00013 : BaseService, IGLMSVE00013
    {
        public IGLMDAO00013 CoADAO { get; set; }

        #region Method
        [Transaction(TransactionPropagation.Required)]
        public IList<GLMDTO00013> SelectDataVW_COA_List(string sourcebr)
        {
            IList<GLMDTO00013> DTOList = this.CoADAO.SelectDataOrderByACode(sourcebr);
            return DTOList;
        }

        public MNMDTO00010 VW_CCOA_SumM11ByACode(string aCode)
        {
            return new MNMDTO00010();
        }
        #endregion
    }
}
