using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Ctr.Dao;
using NHibernate;
using NHibernate.Transform;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00077 : DataRepository<LOMORM00077>, ILOMDAO00077
    {
        public IList<LOMDTO00077> SelectAll()
        {
            IList<LOMDTO00077> result;
            IQuery query = this.Session.GetNamedQuery("SP_GetAllLSProductTypeItem");
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00077)));
            result = query.List<LOMDTO00077>();
            return result;
        }

        public IList<LOMDTO00077> CheckExist2(string productCode, string lsBusinessCode, string umCode)
        {
            IQuery query = this.Session.GetNamedQuery("LSProductTypeItemDAO.CheckExist2");
            query.SetString("productCode", productCode);
            query.SetString("lsBusinessCode", lsBusinessCode);
            query.SetString("umCode", umCode);
            IList<LOMDTO00077> lsProductTypeItemList = query.List<LOMDTO00077>();
            return lsProductTypeItemList;
        }

        public bool CheckExist(string productCode, string lsBusinessCode, string umCode, bool isEdit)
        {
            IQuery query = this.Session.GetNamedQuery("LSProductTypeItemDAO.CheckExist");
            query.SetString("productCode", productCode);
            query.SetString("lsBusinessCode", lsBusinessCode);
            query.SetString("umCode", umCode);
            IList<LOMDTO00077> lsProductTypeItemList = query.List<LOMDTO00077>();

            return lsProductTypeItemList.Count == null ? false : this.CheckDTOList(lsProductTypeItemList, productCode,lsBusinessCode,umCode, isEdit);
        }

        public bool CheckDTOList(IList<LOMDTO00077> lsProductTypeItemList, string productCode, string lsBusinessCode, string umCode, bool isEdit)
        {
            foreach (LOMDTO00077 lsProductTypeItemDto in lsProductTypeItemList)
            {
                if (lsProductTypeItemDto.ProductCode != productCode && 
                    lsProductTypeItemDto.LSBusinessCode != lsBusinessCode && 
                    lsProductTypeItemDto.UMCode != umCode && isEdit)
                    return true;

                else if (!isEdit)
                    return true;
            }
            return false;
        }
    }
}
