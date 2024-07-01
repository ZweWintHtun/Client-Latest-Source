using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00074 : DataRepository<LOMORM00074>, ILOMDAO00074
    {
        public bool CheckExist(string productCode, string description, bool isEdit)
        {
            IQuery query = this.Session.GetNamedQuery("ProductCodeDAO.CheckExist");
            query.SetString("code", productCode);
            query.SetString("description", description);
            IList<LOMDTO00074> productList = query.List<LOMDTO00074>();

            return productList.Count == null ? false : this.CheckDTOList(productList, productCode, isEdit);
        }

        public IList<LOMDTO00074> CheckExist2(string productCode, string description)
        {
            IQuery query = this.Session.GetNamedQuery("ProductCodeDAO.CheckExist2");
            query.SetString("code", productCode);
            query.SetString("description", description);
            IList<LOMDTO00074> productList = query.List<LOMDTO00074>();
            return productList;
        }

        public IList<LOMDTO00074> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("ProductCodeDAO.SelectAll");
            return query.List<LOMDTO00074>();
        }

        public LOMDTO00074 SelectByProductCode(string productCode)
        {
            IQuery query = this.Session.GetNamedQuery("ProductCodeDAO.SelectByProductCode");
            query.SetString("code", productCode);
            return query.UniqueResult<LOMDTO00074>();
        }

        public bool CheckDTOList(IList<LOMDTO00074> productList, string productCode, bool isEdit)
        {
            foreach (LOMDTO00074 productDto in productList)
            {
                if (productDto.Code != productCode && isEdit)
                    return true;

                else if (!isEdit)
                    return true;
            }
            return false;
        }
    }
}
