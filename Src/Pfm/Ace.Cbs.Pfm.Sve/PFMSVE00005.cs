using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using AutoMapper;

namespace Ace.Cbs.Pfm.Sve
{
    public class PFMSVE00005 : BaseService, IPFMSVE00005
    {

        private IPFMDAO00001 customerIdDAO;
        public IPFMDAO00001 CustomerIdDAO
        {
            get { return this.customerIdDAO; }
            set { this.customerIdDAO = value; }
        }

        public IList<PFMDTO00001> GetList()
        {
            IList<PFMORM00001> list = this.customerIdDAO.GetAll();
            IList<PFMDTO00001> result = Mapper.Map<PFMORM00001[], IList<PFMDTO00001>>(list.ToArray<PFMORM00001>());
            return result;
        }

        public IList<PFMDTO00001> GetAll()
        {
            return this.CustomerIdDAO.SelectAll();
        }

       // public PFMDTO00074 SelectByCustomerSearchInfo(PFMDTO00001 customerIdDTO, int maxSearchRecordCounts)
     public PFMDTO00074 SelectByCustomerSearchInfo(PFMDTO00001 customerIdDTO)
        {
            PFMDTO00074 returnValue = new PFMDTO00074();

            returnValue.TotalRecordCount = this.customerIdDAO.CountByCustomerSearchInfo(customerIdDTO);

          //  returnValue.SearchResultList = this.customerIdDAO.SelectByCustomerSearchInfo(customerIdDTO,maxSearchRecordCounts);
            returnValue.SearchResultList = this.customerIdDAO.SelectByCustomerSearchInfo(customerIdDTO);

            return returnValue;
        }

        
    }
}