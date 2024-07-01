//----------------------------------------------------------------------
// <copyright file="SAMSVE00002.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser></CreatedUser>
// <CreatedDate>07/09/2013</CreatedDate>
// <UpdatedUser>Nyo Me San</UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Sam.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Core.Ctr;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Sam.Sve
{
    /// <summary>
    /// SubAccountType Service
    /// </summary>
    public class SAMSVE00002 : BaseService, ISAMSVE00002
    {
        #region Properties

        private IPFMDAO00022 subAccountTypeDAO;
        public IPFMDAO00022 SubAccountTypeDAO
        {
            get { return this.subAccountTypeDAO; }
            set { this.subAccountTypeDAO = value; }
        }

        private PFMORM00022 SubAccountTypeInfo;

        #endregion

        #region Helper Method
        private PFMORM00022 GetSubAccountType(PFMDTO00022 subAccountTypeDTO, bool isDelete)
        {
            SubAccountTypeInfo = new PFMORM00022();
            SubAccountTypeInfo.Id = subAccountTypeDTO.Id;
            SubAccountTypeInfo.Code = subAccountTypeDTO.Code;
            SubAccountTypeInfo.Description = subAccountTypeDTO.Description;
            SubAccountTypeInfo.Symbol = subAccountTypeDTO.Symbol;
            SubAccountTypeInfo.AccountSignature = subAccountTypeDTO.AccountSignature;
            SubAccountTypeInfo.AccountTypeId = subAccountTypeDTO.AccountTypeId;
            SubAccountTypeInfo.TS = subAccountTypeDTO.TS;
            SubAccountTypeInfo.CreatedUserId = subAccountTypeDTO.CreatedUserId;
            SubAccountTypeInfo.CreatedDate = DateTime.Now;
            SubAccountTypeInfo.UpdatedUserId = subAccountTypeDTO.UpdatedUserId;
            SubAccountTypeInfo.UpdatedDate = DateTime.Now;
            if (isDelete)
                SubAccountTypeInfo.Active = false;
            else
                SubAccountTypeInfo.Active = true;
            return SubAccountTypeInfo;
        }
        #endregion

        #region Main Methods
        public virtual IList<PFMDTO00022> GetAll()
        {
            return this.SubAccountTypeDAO.SelectAll();
        }

        public PFMDTO00022 SelectById(int id)
        {
            return this.SubAccountTypeDAO.SelectById(id);
        }  

        public void SaveOrUpdateClientDataVersion(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId,string dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
            PFMORM00022 SubAccountTypeORM = new PFMORM00022();

            //Require Data
            clientDataVersionDTO.ORMObjectName = SubAccountTypeORM;
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

        [Transaction(TransactionPropagation.Required)]
        public virtual PFMORM00022 Save(PFMDTO00022 entity)
        {
            PFMORM00022 subAccountType = null;
            if (this.SubAccountTypeDAO.CheckExist(0, entity.Code, entity.Description))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists                     
            }
            else
            {
                subAccountType = this.SubAccountTypeDAO.Save(this.GetSubAccountType(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), entity.CreatedUserId, subAccountType.Id.ToString());
            }
            return subAccountType;
        }
        public void SaveServerAndServerClient(PFMDTO00022 entity)
        {
            PFMORM00022 subAccountType = null;                 
            try
            {
                subAccountType = this.Save(entity);
                if (!this.ServiceResult.ErrorOccurred)
                {
                    Dictionary<string, object> subAcTypeKeyPair = new Dictionary<string, object> { 
                    { "Id", subAccountType.Id },
                    { "Code", subAccountType.Code },
                    { "AccountTypeId", subAccountType.AccountTypeId },
                    { "Description", subAccountType.Description },
                    { "AccountSign", subAccountType.AccountSignature },
                    { "Symbol", subAccountType.Symbol } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("SubAccountType", subAcTypeKeyPair, subAccountType.TS, subAccountType.CreatedUserId, subAccountType.CreatedDate));
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = "MI90001";// Saving Successful 
                }
            }
            catch
            {                  
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";//Saving Failure.                 
            }          
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual PFMORM00022 UpdateServer(PFMDTO00022 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            PFMORM00022 subAccountTypeEntity = null;     
                if (this.SubAccountTypeDAO.CheckExist(entity.Id, entity.Code, entity.Description))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV90001";//data already exists
                }
                else
                {   
                  subAccountTypeEntity =  this.SubAccountTypeDAO.Update(GetSubAccountType(entity, false));
                    SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Id.ToString());               
                
                }
                return subAccountTypeEntity;          
        }

        public virtual void Update(PFMDTO00022 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            try
            {
               PFMORM00022 subaccounttypeEntity = this.UpdateServer(entity,dvcvList);
                if(!this.ServiceResult.ErrorOccurred)
                {   
                    Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> { 
                    { "Code", subaccounttypeEntity.Code }, 
                    { "AccountTypeId", subaccounttypeEntity.AccountTypeId },
                    { "Description", subaccounttypeEntity.Description },
                    { "AccountSignature", subaccounttypeEntity.AccountSignature },
                    { "Symbol", subaccounttypeEntity.Symbol },
                    { "UpdatedUserId", subaccounttypeEntity.UpdatedUserId }, 
                    { "UpdatedDate", DateTime.Now } ,
                    { "TS", subaccounttypeEntity.TS }
                    };
                    Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "Id", subaccounttypeEntity.Id }, { "Active", true } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00022", updateColumnsandValues, whereColumnsandValues));
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = "MI90002";//Update Success  
                }
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual PFMORM00022 DeleteServer(PFMDTO00022 subaccountTypeDTO)
        {
            PFMORM00022 subaccountType = this.GetSubAccountType(subaccountTypeDTO,true);
            PFMORM00022 deletedEntity = this.SubAccountTypeDAO.Delete(subaccountType, false);
            string deleteId = deletedEntity.Id.ToString();
            this.SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), subaccountTypeDTO.CreatedUserId, subaccountTypeDTO.Id.ToString());
            return deletedEntity;
        }

        public virtual void Delete(IList<PFMDTO00022> itemList)
        {
            try
            {
                foreach (PFMDTO00022 item in itemList)
                {
                    PFMORM00022 deletedEntity = this.DeleteServer(item);
                    string deleteId = deletedEntity.Id.ToString();
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("PFMORM00022", "Id", deleteId, deletedEntity.UpdatedUserId.Value,deletedEntity.TS));
                }
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90003";//Delete Success
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";
                throw new Exception(this.ServiceResult.MessageCode);
            }
        }

        #endregion

    }
}