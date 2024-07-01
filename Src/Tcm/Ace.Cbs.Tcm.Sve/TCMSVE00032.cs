using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tcm.Ctr.Sve;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Com.Utt;


namespace Ace.Cbs.Tcm.Sve
{
    public class TCMSVE00032 : BaseService, ITCMSVE00032
    {

        #region DAO
        public ICXDAO00009 ViewDAO { get; set; }
        public IPFMDAO00020 UCheckDAO { get; set; }
        #endregion

        #region Methods
        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00020> GetReportData(PFMDTO00042 DataDTO)
        {
            Ace.Windows.Admin.DataModel.UserDTO user = this.ViewDAO.SelectUserNamebyUserId(DataDTO.CreatedUserId);
            IList<PFMDTO00020> uCheckList = new List<PFMDTO00020>();
            uCheckList = UCheckDAO.GetUCheckData(DataDTO.StartDate, DataDTO.EndDate,DataDTO.SourceBranch);
            if (user != null)
            {
                for (int i = 0; i < uCheckList.Count; i++)
                {
                    uCheckList[i].USERNO = user.UserName;
                }
            }
            return uCheckList;
        }
        #endregion
    }
}
