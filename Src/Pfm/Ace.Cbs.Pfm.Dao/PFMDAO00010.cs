using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;

namespace Ace.Cbs.Pfm.Dao
{
    public class PFMDAO00010 : DataRepository<PFMORM00010>, IPFMDAO00010
    {
        public PFMDTO00010 CustPhotoSelectById(string CustId)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00010.SelectCustPhotoByCustomerId");
            query.SetString("custId", CustId);
            return query.UniqueResult<PFMDTO00010>();
        }

        public bool UpdateCustPhoto(PFMDTO00010 custphotoEntity)
        {
           IQuery query = this.Session.GetNamedQuery("PFMDAO00010.UpdateCustomerPhoto");
           query.SetString("customerid", custphotoEntity.CustomerId);
           query.SetString("custphotoname", custphotoEntity.CustPhotoName);
           query.SetBinary("custphotos",(System.Byte[]) custphotoEntity.CustPhotos);
           query.SetString("sourcebranch", custphotoEntity.SourceBranch);         
           query.SetDateTime("updateddate", (System.DateTime)custphotoEntity.UpdatedDate);
           query.SetInt32("updateduserId", (System.Int32)custphotoEntity.UpdatedUserId);
           return query.ExecuteUpdate() > 0;	
        }

        public bool DeleteCustPhoto(PFMDTO00010 custphotoEntity)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00010.DeleteCustomerPhoto");
            query.SetString("customerid", custphotoEntity.CustomerId);
            query.SetDateTime("updatedDate", (System.DateTime)custphotoEntity.UpdatedDate);
            query.SetInt32("updatedUserId", (System.Int32)custphotoEntity.UpdatedUserId);
            return query.ExecuteUpdate() > 0;
        }
    }
}