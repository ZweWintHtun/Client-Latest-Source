using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.Core.Utt;
using AutoMapper;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Pfm.Sve
{
    //CustomerId Service
    public class PFMSVE00004 : BaseService, IPFMSVE00004
    {
        public ICXSVE00002 CodeGenerator { get; set; }

        private IPFMDAO00001 customerIdDAO;
        public IPFMDAO00001 CustomerIdDAO
        {
            get { return this.customerIdDAO; }
            set { this.customerIdDAO = value; }
        }

        private IPFMDAO00010 custphotoDAO;
        public IPFMDAO00010 CustPhotoDAO
        {
            get { return this.custphotoDAO; }
            set { this.custphotoDAO = value; }
        }

        private PFMDTO00001 cust;
        public PFMDTO00001 Cust
        {
            get { return this.cust; }
            set { this.cust = value; }
        }

        [Transaction(TransactionPropagation.Required)]
        public string Save(PFMDTO00001 entity)
        {
            string custId = string.Empty;

            PFMORM00001 result = Mapper.Map<PFMDTO00001, PFMORM00001>(entity);

            try
            {
                if (this.customerIdDAO.CheckExist(result.NRC))
                {
                    //this.ServiceResult.ErrorOccurred = true;
                    //this.ServiceResult.MessageCode = CXMessage.MV00015; // Duplicate NRC No.
                    //return null;

                    throw new Exception(CXMessage.MV00015);
                }
                else
                {
                    string customerId = this.CodeGenerator.GetGenerateCode(CXCOM00009.CustomerNoCodeFormula, CXCOM00009.CustomerNoCheckDigitFormula, result.CreatedUserId, result.SourceBranch, new object[] { result.SourceBranch });

                    result.CustomerId = customerId;
                    result.DATE_TIME = DateTime.Now;
                    result.CreatedDate = DateTime.Now;
                    PFMORM00001 custIdAfterSave = this.customerIdDAO.Save(result);

                    if (custIdAfterSave.CustomerId != null && custIdAfterSave.CustPhoto.CustPhotos != null)
                    {
                        PFMORM00010 custphoto = new PFMORM00010();
                        custphoto.CustomerId = custIdAfterSave.CustomerId;
                        custphoto.CustPhotoName = result.CustPhoto.CustPhotoName;
                        custphoto.SourceBranch = custIdAfterSave.SourceBranch;
                        custphoto.CustPhotos = result.CustPhoto.CustPhotos;
                        custphoto.CreatedUserId = result.CreatedUserId;
                        this.CustPhotoDAO.Save(custphoto);

                    }

                    custId = custIdAfterSave.CustomerId;
                }

                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MI00001;
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = ex.Message;
                throw new Exception(this.ServiceResult.MessageCode);
            }

            return custId;
        }

        public IList<PFMDTO00001> SelectAll()
        {
            return this.customerIdDAO.SelectAll();
        }

        public PFMDTO00001 SelectByCustomerId(string customerid)
        {
            return this.customerIdDAO.SelectByCustomerId(customerid);
        }

        public PFMDTO00001 GetCustomerById(string customerid)
        {
            PFMORM00001 a = this.CustomerIdDAO.Get(customerid);

            return Mapper.Map<PFMORM00001, PFMDTO00001>(a);
        }

        [Transaction(TransactionPropagation.Required)]
        public void Update(PFMDTO00001 custEntity,PFMDTO00010 custphotoEntity)
        {
            custEntity.UpdatedDate = DateTime.Now;            
            custEntity.UpdatedUserId = custEntity.CreatedUserId;
            custEntity.DATE_TIME = DateTime.Now;

            try
            {
                if (customerIdDAO.UpdateName(custEntity) == false)
                {
                    throw new Exception(CXMessage.MI00009);
                }

                if (custEntity.CustomerId != null && custEntity.CustPhoto.CustPhotos != null)
                {
                    custphotoEntity.UpdatedDate = DateTime.Now;                    
                    custphotoEntity.UpdatedUserId = custEntity.CreatedUserId;
                    custphotoEntity.CustPhotos = custEntity.CustPhoto.CustPhotos;
                    //custphotoEntity.SourceBranch = custEntity.SourceBranch;
                    PFMORM00010 result = Mapper.Map<PFMDTO00010, PFMORM00010>(custphotoEntity);

                    if (custphotoDAO.CustPhotoSelectById(custEntity.CustomerId) != null)
                    {
                        if (custphotoDAO.UpdateCustPhoto(custphotoEntity) == false)
                        {
                            //throw new Exception(CXMessage.MI00009);
                            throw new Exception(CXMessage.ME90043);
                            
                        }
                    }
                    else
                    {
                        result.CreatedUserId = custEntity.CreatedUserId;
                        result.CreatedDate = custEntity.CreatedDate;
                        custphotoDAO.Save(result);
                    }
                }
                else
                {
                    if (custphotoDAO.CustPhotoSelectById(custEntity.CustomerId) != null)
                    {
                        custphotoEntity.UpdatedDate = DateTime.Now;
                        custphotoEntity.UpdatedUserId = custEntity.CreatedUserId;
                        if (custphotoDAO.DeleteCustPhoto(custphotoEntity) == false)
                        {
                            //throw new Exception(CXMessage.MI00009);
                            throw new Exception(CXMessage.ME90043);
                        }
                    }
                }

                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MI90002;
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME90043;
                //this.ServiceResult.MessageCode = CXMessage.MI00009;
                throw new Exception(this.ServiceResult.MessageCode);
            }
        }

        public PFMDTO00001 SelectTopCustomerId()
        {
            return this.customerIdDAO.SelectTopCustomerId();
        }

        public PFMDTO00001 SelectLastCustomerId()
        {
            return this.customerIdDAO.SelectLastCustomerId();
        }

        public IList<PFMDTO00001> GetRange(string customerid, string click, int rows)
        {
            throw new NotImplementedException();
        }
        public PFMDTO00080 CheckNRCForExternalBlackListCustomer(string nRC, string BranchCode)
        {
            return CustomerIdDAO.CheckNRCForExternalBlackListCustomer(nRC, BranchCode);
        }
     
    }
}