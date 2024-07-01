using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Dao;
using NHibernate;
using NHibernate.Transform;
using System;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00415 : DataRepository<LOMORM00415>, ILOMDAO00415
    {
        public IList<LOMDTO00415> SelectAll()
        {
            IList<LOMDTO00415> productCodeList =new List<LOMDTO00415>();

            IQuery query = this.Session.GetNamedQuery("PersonalLoanProductCodeDAO.SelectAll");
            productCodeList = query.List<LOMDTO00415>();

            return productCodeList;
        }

        public IList<LOMDTO00415> SelectAll_ACode()
        {
            var query = this.Session.GetNamedQuery("PersonalLoanProductCodeDAO.SelectAll_ACode")
            .SetResultTransformer(Transformers.AliasToBean<LOMDTO00415>()).List<LOMDTO00415>();
            IList<LOMDTO00415> multilist = query.ToList<LOMDTO00415>();
            return multilist;
        }

        public IList<LOMDTO00415> CheckExist2(string productCode,string gLCode, string description)
        {
            IQuery query = this.Session.GetNamedQuery("PersonalLoanProductCodeDAO.CheckExist2");
            query.SetString("productCode", productCode);
            query.SetString("gLCode", gLCode);
            query.SetString("description", description);
            IList<LOMDTO00415> stockgroupList = query.List<LOMDTO00415>();
            return stockgroupList;
        }

        public bool CheckExist(string productCode, string desp, string gLCode, bool isEdit)
        {
            IQuery query = this.Session.GetNamedQuery("PersonalLoanProductCodeDAO.CheckExist");
            query.SetString("productCode", productCode);
            query.SetString("description", desp);
            query.SetString("gLCode", gLCode);
            IList<LOMDTO00415> productCodeList = query.List<LOMDTO00415>();

            return productCodeList.Count == null ? false : this.CheckDTOList(productCodeList, productCode, isEdit);
        }

        public bool CheckDTOList(IList<LOMDTO00415> productCodeList, string productCode, bool isEdit)
        {
            foreach (LOMDTO00415 productCodeDto in productCodeList)
            {
                if (productCodeDto.ProductCode != productCode && isEdit)
                    return true;

                else if (!isEdit)
                    return true;
            }
            return false;
        }
        
        public void Save(LOMDTO00415 productdto)
        {
            IQuery query = this.Session.GetNamedQuery("PersonalLoanProductCodeDAO.Save");
            
            query.SetString("ProductCode", productdto.ProductCode);
            query.SetString("Description", productdto.Description);
            query.SetString("RelatedGLACode", productdto.RelatedGLACode);
            query.SetBoolean("Active", productdto.Active);

            query.SetDateTime("CreatedDate", DateTime.Now);
            query.SetInt32("CreatedUserId", Convert.ToInt32(CurrentUserEntity.CurrentUserID));
            query.ExecuteUpdate();   

        }

        public void Update(LOMDTO00415 productdto)
        {
            IQuery query = this.Session.GetNamedQuery("PersonalLoanProductCodeDAO.Update");

            //query.SetString("ProductCode", productdto.ProductCode);
            query.SetString("Description", productdto.Description);
            query.SetString("RelatedGLACode", productdto.RelatedGLACode);
            query.SetInt32("Id", productdto.Id);
            query.SetBoolean("Active", productdto.Active);
            query.SetBoolean("Active", productdto.Active);

            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", Convert.ToInt32(CurrentUserEntity.CurrentUserID));

            query.ExecuteUpdate();
        }

        public void Delete(LOMDTO00415 productdto)
        {
            IQuery query = this.Session.GetNamedQuery("PersonalLoanProductCodeDAO.Delete");
            query.SetInt32("Id", productdto.Id);
            query.ExecuteUpdate();
        }

        

    }
}

