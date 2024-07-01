using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using NHibernate;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using System.Collections.Generic;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Dao;

namespace Ace.Cbs.Loan.Dao
{

    /// <summary>
    /// Land_Building DAO
    /// </summary>
    public class LOMDAO00015 : DataRepository<LOMORM00015>, ILOMDAO00015
    {
        public LOMDTO00015 SelectLand_BuildingInfoByLoanNoAndSourceBr(string lno, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("SelectLand_BuildingInfo");
            query.SetString("lno", lno);
            query.SetString("sourcebr", sourcebr);
            LOMDTO00015 land_bldDto = query.UniqueResult<LOMDTO00015>();
            return land_bldDto;
        }

        public bool UpdateLand_BuildingInfoByLoanNoAndSourceBr(LOMDTO00015 land_buildingDto)
         {
            IQuery query = this.Session.GetNamedQuery("LOMDAO00015.UpdateLand_BuildingInfoByLoanNoAndSourceBr");
            query.SetString("plBsYear", land_buildingDto.YearPB);
            query.SetDateTime("esDate", Convert.ToDateTime(land_buildingDto.EDate));
            query.SetDecimal("eYear", Convert.ToDecimal(land_buildingDto.ExpYear));
            query.SetDecimal("capital", Convert.ToDecimal(land_buildingDto.Capital));
            query.SetDecimal("incometax", Convert.ToDecimal(land_buildingDto.Tax));
            query.SetString("sdeed", land_buildingDto.SDEED);
            query.SetString("landOfAffidavit", land_buildingDto.LAFFID);
            query.SetString("land", land_buildingDto.Land);
            query.SetString("charaOfCustomer", land_buildingDto.Char);
            query.SetString("gw", land_buildingDto.GW);
            query.SetDecimal("fsvLand", Convert.ToDecimal(land_buildingDto.FSVLand));
            query.SetDecimal("fsvBuilding", Convert.ToDecimal(land_buildingDto.FSVBLD));
            query.SetString("address", land_buildingDto.Address);
            query.SetString("historyOfLB", land_buildingDto.HISLB);
            query.SetString("bConPermit", land_buildingDto.BPERMIT);
            query.SetString("isType", land_buildingDto.IsType);
            query.SetDateTime("isDate", Convert.ToDateTime(land_buildingDto.IsDate));
            query.SetDateTime("isEdate", Convert.ToDateTime(land_buildingDto.IsExpiredDate));
            query.SetDecimal("isAmt", Convert.ToDecimal(land_buildingDto.IsAMT));

            query.SetString("lno", land_buildingDto.LNo);
            query.SetString("sourcebr", land_buildingDto.SourceBr);
            query.SetDateTime("updatedDate", (DateTime)land_buildingDto.UpdatedDate);
            query.SetInt32("updatedUserId", (int)land_buildingDto.UpdatedUserId);
            return query.ExecuteUpdate() > 0;
        }
    }
}
