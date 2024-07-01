using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
namespace Ace.Cbs.Pfm.Sve
{
    public class PFMSVE00018 : BaseService, IPFMSVE00018
    {

        private IPFMDAO00010 custPhotoDAO;
        public IPFMDAO00010 CustPhotoDAO
        {
            get { return this.custPhotoDAO; }
            set { this.custPhotoDAO = value; }

        }

        public PFMDTO00010 CusPhotoSelectById(string Id)
        {
            return this.custPhotoDAO.CustPhotoSelectById(Id);
        }

    }
}