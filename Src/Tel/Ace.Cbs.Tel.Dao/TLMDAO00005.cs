//----------------------------------------------------------------------
// <copyright file="TLMDAO00015.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Su Su Wai</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser>Nyo Me San</UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;

namespace Ace.Cbs.Tel.Dao
{
    /// <summary>
    /// TranType DAO
    /// </summary>
    public class TLMDAO00005 : DataRepository<TLMORM00005>, ITLMDAO00005
    {
        //Select TranType Data
        public TLMDTO00005 SelectTranTypeStatus(string transactionCode)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00005.SelectTranTypeStatus");
            query.SetString("transactionCode", transactionCode);
             TLMDTO00005 tranTypeDTO =  query.UniqueResult<TLMDTO00005>();
             return tranTypeDTO;
        }

        public bool CheckExist(string tranCode, string desp, bool isEdit)
        {
            IQuery query = this.Session.GetNamedQuery("TranTypeDAO.CheckExist");
            query.SetString("tranCode", tranCode);
            //query.SetString("desp", desp);
            IList<TLMDTO00005> TranTypeList = query.List<TLMDTO00005>();
            return TranTypeList == null ? false : this.CheckDTOList(TranTypeList, tranCode, isEdit);
           // return TranTypeList == null ? false : true;
        }

        public IList<TLMDTO00005> CheckExist2(string TranTypeCode, string desp)
        {
            IQuery query = this.Session.GetNamedQuery("TranTypeDAO.CheckExist2");
            query.SetString("TranTypeCode", TranTypeCode);
            query.SetString("description", desp);
            IList<TLMDTO00005> TranTypeList = query.List<TLMDTO00005>();
            return TranTypeList;
        }

        public IList<TLMDTO00005> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("TranTypeDAO.SelectAll");
            return query.List<TLMDTO00005>();
        }

        public TLMDTO00005 SelectByTranCode(string tranCode)
        {
            IQuery query = this.Session.GetNamedQuery("TranTypeDAO.SelectByTranCode");
            query.SetString("tranCode", tranCode);
            return query.UniqueResult<TLMDTO00005>();
        }

        private bool CheckDTOList(IList<TLMDTO00005> tranTypeList, string tranCode, bool isEdit)
        {
            foreach (TLMDTO00005 info in tranTypeList)
            {
                if (info.TransactionCode != tranCode && isEdit)
                    return true;
                else if (!isEdit)
                    return true;
            }
            return false;
        }    
    }
}
