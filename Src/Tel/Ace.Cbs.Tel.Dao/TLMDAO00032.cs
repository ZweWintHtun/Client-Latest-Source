//----------------------------------------------------------------------
// <copyright file="TLMDAO00032.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Lenovo</CreatedUser>
// <CreatedDate>08/04/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using NHibernate.Transform;

namespace Ace.Cbs.Tel.Dao
{
	public class TLMDAO00032 : DataRepository<TLMORM00032>, ITLMDAO00032
    {
        public IList<TLMDTO00032> SelectById(int remitBrId)
        {
            IQuery query = this.Session.GetNamedQuery("RmitRateDAO.SelectById");
            query.SetInt32("remitBrId", remitBrId);
            return query.List<TLMDTO00032>();
        }
       
        public bool DeleteById(int remitBrId, int userId)
        {
            IQuery query = this.Session.GetNamedQuery("RmitRateDAO.DeleteById");
            query.SetDateTime("updatedDate", System.DateTime.Now);
            query.SetInt32("updatedUserId", userId);
            query.SetInt32("remitBrId", remitBrId);
            return query.ExecuteUpdate() > 0 ? true:false ;
        }

        public TLMDTO00032 SelectByIdForSaveAppServer(int remitRateId)
        {
            IQuery query = this.Session.GetNamedQuery("RmitRateDAO.SelectByIdForSaveAppServer");
            query.SetInt32("remitRateId", remitRateId);
            return query.UniqueResult<TLMDTO00032>();
        }


        public IList<TLMDTO00032> SelectRmitRatewithRemitBrandBranch()
        {
            IQuery query = this.Session.GetNamedQuery("SP_GetRemittanceWithRate");            //RmitRateDAO.SelectRmitRatewithRemitBrandBranch
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(TLMDTO00032)));
            return query.List<TLMDTO00032>();
        }



	}
}
