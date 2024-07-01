using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Core.Ctr;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Sve
{
    /// <summary>
    /// Business Code Service
    /// </summary>
    public class LOMSVE00001 : BaseService, ILOMSVE00001
    {
        #region Properties

        private ILOMDAO00001 _businessCodeDAO;
        public ILOMDAO00001 BusinessDAO
        {
            get { return this._businessCodeDAO; }
            set { this._businessCodeDAO = value; }
        }

        private LOMORM00001 BusinessCodeInfo;

        #endregion

        #region OldCode

        //public virtual IList<LOMDTO00001> GetAll()
        //{
        //    return this.BusinessDAO.SelectAll();
        //}

        //public LOMDTO00001 SelectByBusinessCode(string businessCode)
        //{
        //    return this.BusinessDAO.SelectByBusinessCode(businessCode);
        //}

        //[Transaction(TransactionPropagation.Required)]
        //public virtual LOMORM00001 Save(LOMDTO00001 entity)
        //{
        //    LOMORM00001 nationality = null;
        //    try
        //    {
        //        if (this.BusinessDAO.CheckExist(entity.Code, entity.Description, false))
        //        {
        //            this.ServiceResult.ErrorOccurred = true;
        //            this.ServiceResult.MessageCode = "MV90001";//data already exists                     
        //        }
        //        else
        //        {
        //            nationality = this.BusinessDAO.Save(this.GetBusinessCode(entity, false));
                    
        //            this.ServiceResult.MessageCode = "MI90001";// Saving Successful
        //            this.SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), entity.CreatedUserId, entity.Code);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        this.ServiceResult.ErrorOccurred = true;
        //        this.ServiceResult.MessageCode = "ME90036";  //Error Occur!!! Please contact your administrator.
        //    }
        //    return nationality;
        //}

        //[Transaction(TransactionPropagation.Required)]
        //public virtual void Update(LOMDTO00001 entity, IList<DataVersionChangedValueDTO> dvcvList)
        //{
        //    try
        //    {
        //        if (this.BusinessDAO.CheckExist(entity.Code, entity.Description, true))
        //        {
        //            this.ServiceResult.ErrorOccurred = true;
        //            this.ServiceResult.MessageCode = "MV90001";//data already exists
        //        }
        //        else
        //        {
        //            entity.UpdatedDate = DateTime.Now;
        //            entity.UpdatedUserId = entity.CreatedUserId;
        //            LOMORM00001 business = GetBusinessCode(entity, false);
        //            this.BusinessDAO.Update(business);
        //            Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> { { "Code", business.Code }, { "Description", business.Description }, { "UpdatedDate", business.UpdatedDate }, { "UpdatedUserId", business.UpdatedUserId } };
        //            Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "Code", business.Code }, { "Active", true } };
        //            CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("LOMORM00001", updateColumnsandValues, whereColumnsandValues));

        //            this.ServiceResult.ErrorOccurred = false;
        //            this.ServiceResult.MessageCode = "MI90002";//Update Success
        //            this.SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Code);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        this.ServiceResult.ErrorOccurred = true;
        //        this.ServiceResult.MessageCode = "ME90036";
        //    }
        //}

        //[Transaction(TransactionPropagation.Required)]
        //public virtual void Delete(IList<LOMDTO00001> itemList)
        //{
        //    try
        //    {
        //        foreach (LOMDTO00001 item in itemList)
        //        {                  
        //            item.UpdatedUserId = item.UpdatedUserId;
        //            item.UpdatedDate = DateTime.Now;
        //            this.BusinessDAO.Delete(GetBusinessCode(item, true), false);                                                                                 
        //            this.SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), item.CreatedUserId, item.Code);
        //            CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("LOMORM00001", "Code", item.Code, item.CreatedUserId, item.TS));               
        //            //CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("LOMORM00001", "TS", item.TS, item.CreatedUserId, item.TS));               
        //        }
        //        this.ServiceResult.ErrorOccurred = false;
        //        this.ServiceResult.MessageCode = "MI90003";//Delete Success
        //    }
        //    catch (Exception)
        //    {
        //        this.ServiceResult.ErrorOccurred = true;
        //        this.ServiceResult.MessageCode = "ME90036";  //Error Occur!!! Please contact your administrator.
        //        //throw new Exception(this.ServiceResult.MessageCode);
        //    }
        //}

        //public void SaveServerAndServerClient(LOMDTO00001 entity)
        //{
        //    LOMDTO00001 businessEntity = null;


        //    try
        //    {
        //        LOMORM00001 business = this.Save(entity);
        //        if (business != null)
        //            businessEntity = BusinessDAO.SelectByBusinessCode(business.Code);
        //        if (businessEntity != null)
        //        {

        //            Dictionary<string, object> businessKeyPair = new Dictionary<string, object> { { "BUSICODE", businessEntity.Code }, { "BUSIDESP", businessEntity.Description } };
        //            CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("BUSINESS", businessKeyPair, businessEntity.TS, businessEntity.CreatedUserId, businessEntity.CreatedDate));
        //            this.ServiceResult.ErrorOccurred = false;
        //            this.ServiceResult.MessageCode = "MI90001";// Saving Successful  
        //        }
        //    }

        //    catch
        //    {
        //        //  AccountTypeDAO.Delete(accountypeEntity, true);
        //        this.ServiceResult.ErrorOccurred = true;
        //        if (!string.IsNullOrEmpty(this.ServiceResult.MessageCode))
        //            this.ServiceResult.MessageCode = this.ServiceResult.MessageCode;
        //        else
        //            this.ServiceResult.MessageCode = "ME90036";   //Error Occur!!! Please contact your administrator.
        //    }
        //}

        #endregion

        #region NewCode
        public virtual IList<LOMDTO00001> GetAll()
        {
            return this.BusinessDAO.SelectAll();
        }

        public LOMDTO00001 SelectByBusinessCode(string businessCode)
        {
            return this.BusinessDAO.SelectByBusinessCode(businessCode);
        }

        public IList<LOMDTO00001> CheckExist2(string businessCode, string desp)
        {
            return this.BusinessDAO.CheckExist2(businessCode, desp);
        }

        public void SaveServerAndServerClient(LOMDTO00001 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {           
            try
            {
                LOMORM00001 business = this.Save(entity,dvcvList);
                if (business != null)
                {
                    if (!this.ServiceResult.ErrorOccurred)
                    {
                        Dictionary<string, object> businessKeyPair = new Dictionary<string, object> {
                        { "BUSICODE", business.Code },
                        { "BUSIDESP", business.Description } };
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("BUSINESS", businessKeyPair, business.TS, business.CreatedUserId, business.CreatedDate));
                        this.ServiceResult.ErrorOccurred = false;
                        this.ServiceResult.MessageCode = "MI90001";// Saving Successful  
                    }
                }
            }
            catch
            {               
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";   //Error Occur!!! Please contact your administrator.
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual LOMORM00001 Save(LOMDTO00001 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMORM00001 BusinessCode = null;
            if (!entity.Active) //Active = 0 , update nature
            {
                this.Update(entity, dvcvList, "Save");
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Code);
                return null;
            }            
            else  //Active = 1 , insert nature  
            {
                BusinessCode = this.BusinessDAO.Save(this.GetBusinessCode(entity, false));                
                this.SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), entity.CreatedUserId, entity.Code);
            }            
            return BusinessCode;
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual void Update(LOMDTO00001 entity, IList<DataVersionChangedValueDTO> dvcvList, string status)
        {
            try
            {
                LOMORM00001 businessCode = this.UpdateServer(entity, dvcvList);
                if(!this.ServiceResult.ErrorOccurred)
                {                   
                    Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> { 
                    { "Code", businessCode.Code },
                    { "Description", businessCode.Description }, 
                    { "Active", businessCode.Active},
                    { "UpdatedDate", businessCode.UpdatedDate }, 
                    { "UpdatedUserId", businessCode.UpdatedUserId },
                    { "TS",businessCode.TS }};
                    Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "Code", businessCode.Code } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("LOMORM00001", updateColumnsandValues, whereColumnsandValues));
                    this.ServiceResult.ErrorOccurred = false;
                    if (status == "Update")
                        this.ServiceResult.MessageCode = "MI90002";//Update Success
                    else
                        this.ServiceResult.MessageCode = "MI90001";//Saving Successful   
                }
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual LOMORM00001 UpdateServer(LOMDTO00001 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMORM00001 businessCodeEntity = null;

            if (this.BusinessDAO.CheckExist(entity.Code, entity.Description, true))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists
            }
            else
            {
                businessCodeEntity = this.BusinessDAO.Update(this.GetBusinessCode(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Code);
            }
            return businessCodeEntity;
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual void Delete(IList<LOMDTO00001> itemList)
        {
            try
            {
                foreach (LOMDTO00001 item in itemList)
                {
                    LOMORM00001 deletedEntity = this.DeleteServer(item);                     
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("LOMORM00001", "Code", item.Code, item.CreatedUserId, item.TS));                    
                }
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90003";//Delete Success
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";  //Error Occur!!! Please contact your administrator.
                throw new Exception(this.ServiceResult.MessageCode);
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual LOMORM00001 DeleteServer(LOMDTO00001 businessCodeDTO)
        {
            LOMORM00001 businessCode = this.GetBusinessCode(businessCodeDTO, true);
            LOMORM00001 deletedEntity = this.BusinessDAO.Delete(businessCode, false);
            SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), businessCodeDTO.CreatedUserId, businessCodeDTO.Code);
            return deletedEntity;
        }

        #endregion

        #region Helper Method

        private LOMORM00001 GetBusinessCode(LOMDTO00001 businessCodeDTO, bool isDelete)
        {
            BusinessCodeInfo = new LOMORM00001();

            BusinessCodeInfo.Code = businessCodeDTO.Code;
            BusinessCodeInfo.Description = businessCodeDTO.Description;           
            BusinessCodeInfo.TS = businessCodeDTO.TS;
            BusinessCodeInfo.CreatedUserId = businessCodeDTO.CreatedUserId;
            BusinessCodeInfo.CreatedDate = DateTime.Now;
            BusinessCodeInfo.UpdatedUserId = businessCodeDTO.UpdatedUserId;
            BusinessCodeInfo.UpdatedDate = DateTime.Now;

            if (isDelete)
                BusinessCodeInfo.Active = false;
            else
                BusinessCodeInfo.Active = true;

            return BusinessCodeInfo;
        }


        #endregion

        #region Data Version Update Service
        public void SaveOrUpdateClientDataVersion(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId, string dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
            LOMORM00001 BusinessCodeORM = new LOMORM00001();

            //Require Data
            clientDataVersionDTO.ORMObjectName = BusinessCodeORM;
            clientDataVersionDTO.DataIdValue = dataValueId;
            clientDataVersionDTO.CreatedUserId = createdUserId;

            //ChangedDataContents
            IList<ChangeDataContent> cdclist = new List<ChangeDataContent>();
            foreach (DataVersionChangedValueDTO dvcvdto in dvcvList)
            {
                ChangeDataContent cdcdto = new ChangeDataContent();
                cdcdto.Property = dvcvdto.OrmPropertyName;
                cdcdto.OldValue = dvcvdto.OrmPreviousValue;
                cdcdto.NewValue = dvcvdto.OrmNewValue;
                cdclist.Add(cdcdto);
            }
            clientDataVersionDTO.ChangeDataContentList = cdclist;
            CXServiceWrapper.Instance.Invoke<IDataVersionUpdateService, bool>(x => x.SaveOrUpdateClientDataVersion(clientDataVersionDTO, dataAction));
        }
        #endregion

    }
}
        
