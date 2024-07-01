//----------------------------------------------------------------------
// <copyright file="PFMDAO00075.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>08/08/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using Ace.Windows.Admin.DataModel;
using NHibernate;
using System;

namespace Ace.Cbs.Pfm.Dao
{
    public class PFMDAO00075 : DataRepository<PFMORM00074>, IPFMDAO00075
    {
        public bool CheckExist(int id, string cur, string rateType, string toCur)
        {
            IQuery query = this.Session.GetNamedQuery("RateInfoDAO.CheckExist");
            query.SetString("cur", cur);
            query.SetString("rateType", rateType);
            query.SetString("toCur", toCur);
            PFMDTO00075 RateInfoList = query.UniqueResult<PFMDTO00075>();
            return RateInfoList == null ? false : (RateInfoList.Id == id ? false : true);
            //return RateInfoList.Count == 0 ? false : this.CheckList(RateInfoList, id, cur, rateType, toCur);
        }

        //public bool CheckList(IList<PFMDTO00075> RateInfoList, int id, string cur, string rateType, string tocur)
        //{
        //    foreach (PFMDTO00075 RateInfo in RateInfoList)
        //    {
        //        if (RateInfo.Id == id)
        //        {

        //            for (int i = 0; i < RateInfoList.Count; i++)
        //            {
        //                if ((RateInfo.Id != RateInfoList[i].Id) && (RateInfoList[i].CurrencyCode == cur && RateInfoList[i].RateType == rateType && RateInfoList[i].ToCurrencyCode == tocur))
        //                {
        //                    return true;
        //                }
        //            }
        //            return false;
        //        }

        //    }
        //    return true;
        //}

        public IList<PFMDTO00075> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("RateInfoDAO.SelectAll");
            return query.List<PFMDTO00075>();
        }

        public PFMDTO00075 SelectById(int id)
        {
            IQuery query = this.Session.GetNamedQuery("RateInfoDAO.SelectById");
            query.SetInt32("id", id);
            return query.UniqueResult<PFMDTO00075>();
        }

        public IList<CurrencyDTO> SelectCurrency()
        {
            IQuery query = this.Session.GetNamedQuery("PORate.SelectCurrency");
            IList<CurrencyDTO> list = query.List<CurrencyDTO>();
            return list;
        }

        public IList<PFMDTO00075> SelectAllByLastModify()
        {
            IQuery query = this.Session.GetNamedQuery("RateInfoDAO.SelectByLastModify");
            return query.List<PFMDTO00075>();
        }

        public bool UpdateByLastModify(int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("RateInfoDAO.UpdateByLastModify");          
            query.SetInt32("updateduserid", updatedUserId);
            query.SetDateTime("updateddate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        public IList<decimal> SelectRate(string cur, string rateType)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00075.SelectTodayRate");
            query.SetString("currencyCode", cur);
            query.SetString("rateType", rateType);
            query.SetDateTime("currentDate", DateTime.Now);
            return query.List<decimal>();
        }

        public int SelectMaxId()
        {
            IQuery query = this.Session.GetNamedQuery("RateInfoDAO.SelectMaxId");
            PFMDTO00075 dto = query.UniqueResult<PFMDTO00075>();
            return dto.Id;
        }

    }
}