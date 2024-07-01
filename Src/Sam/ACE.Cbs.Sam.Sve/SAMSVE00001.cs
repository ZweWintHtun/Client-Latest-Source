//----------------------------------------------------------------------
// <copyright file="SAMSVE00001.cs" company="ACE Data Systems">
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
using Ace.Windows.Core.DataModel;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Ix.Core.Ctr;
using Ace.Windows.Ix.Core.DataModel;

namespace Ace.Cbs.Sam.Sve
{
    /// <summary>
    /// AccountType Service
    /// </summary>
	public class SAMSVE00001:BaseService,ISAMSVE00001
  	{
		#region Properties
		
		private IPFMDAO00015 accountTypeDAO;
        public IPFMDAO00015 AccountTypeDAO
        {
            get { return this.accountTypeDAO; }
            set { this.accountTypeDAO = value; }
        }
		
		private PFMORM00015 AccountTypeInfo;
		
		#endregion

        #region Helper Method
        private PFMORM00015 GetAccountType(PFMDTO00015 accountTypeDTO, bool isEdit, bool isDelete)
        {
            AccountTypeInfo = new PFMORM00015();
            AccountTypeInfo.Id = accountTypeDTO.Id;
            AccountTypeInfo.Code = accountTypeDTO.Code;
            AccountTypeInfo.Description = accountTypeDTO.Description;
            AccountTypeInfo.Symbol = accountTypeDTO.Symbol;
            AccountTypeInfo.CreatedUserId = accountTypeDTO.CreatedUserId;
            AccountTypeInfo.TS = accountTypeDTO.TS;
            AccountTypeInfo.CreatedDate = DateTime.Now;
            if (isEdit || isDelete)
            {
                AccountTypeInfo.UpdatedUserId = accountTypeDTO.CreatedUserId;
                AccountTypeInfo.UpdatedDate = DateTime.Now;
            }
            if (isDelete)
                AccountTypeInfo.Active = false;
            else
                AccountTypeInfo.Active = true;

            return AccountTypeInfo;
        }

        #endregion
		
		#region Main Methods
		
		public virtual IList<PFMDTO00015> GetAll()
        {
            return this.AccountTypeDAO.SelectAll();
        }

        public PFMDTO00015 SelectById(int id)
        {
            return this.AccountTypeDAO.SelectById(id);
        }
		
		[Transaction(TransactionPropagation.Required)]
        public virtual PFMORM00015 Save(PFMDTO00015 entity )
        {
            PFMORM00015 accounttype = null;
             if (this.AccountTypeDAO.CheckExist(0,entity.Code,entity.Description,entity.Symbol))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV90001";//data already exists      
                 }
                else
                {
                 accounttype = this.accountTypeDAO.Save(this.GetAccountType(entity, false, false));              
                 SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), accounttype.CreatedUserId, accounttype.Id.ToString());
                }                
          
            return accounttype;
        }

        public void SaveServerAndServerClient(PFMDTO00015 entity)
        {          
            try
            {
                PFMORM00015 accountype = this.Save(entity);
                if (!this.ServiceResult.ErrorOccurred)
                {
                    Dictionary<string, object> accounttypeKeyPair = new Dictionary<string, object> {
                    { "Id", accountype.Id },
                    { "Code", accountype.Code },
                    { "Description", accountype.Description }, 
                    { "Symbol", accountype.Symbol } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("AccountType", accounttypeKeyPair, accountype.TS, accountype.CreatedUserId, accountype.CreatedDate));
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = "MI90001";// Saving Successful  
                }
            }
            catch
            {
                this.ServiceResult.ErrorOccurred = true;               
                this.ServiceResult.MessageCode = "ME90036";
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual PFMORM00015 UpdateServer(PFMDTO00015 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            PFMORM00015 accounttype = null;            
            if (this.AccountTypeDAO.CheckExist(entity.Id, entity.Code, entity.Description, entity.Symbol))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists
            }
            else
            {
                accounttype = this.AccountTypeDAO.Update(this.GetAccountType(entity, true, false));
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Id.ToString());
            }

            return accounttype;
        }

        public virtual void Update(PFMDTO00015 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            try
            {
               PFMORM00015 accountType = this.UpdateServer(entity,dvcvList);                  
                if(!this.ServiceResult.ErrorOccurred)
                {    Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> {
                    { "Code", accountType.Code }, 
                    { "Description", accountType.Description },
                    { "Symbol", accountType.Symbol },
                    { "UpdatedUserId", accountType.UpdatedUserId },
                    { "UpdatedDate", DateTime.Now } ,
                     { "TS", accountType.TS }
                    };
                    Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "Id", accountType.Id }, { "Active", true } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00015", updateColumnsandValues, whereColumnsandValues));
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
        public virtual PFMORM00015 DeleteServer(PFMDTO00015 accounttypeDTO)
        {
            PFMORM00015 accountType = this.GetAccountType(accounttypeDTO,false,true);
           PFMORM00015 deletedEntity =  this.AccountTypeDAO.Delete(accountType, false); //nms                  
           SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), accounttypeDTO.CreatedUserId, accounttypeDTO.Id.ToString());
           return deletedEntity; 
        }

        public virtual void Delete(IList<PFMDTO00015> itemList)
        {
            try
            {
                foreach (PFMDTO00015 item in itemList)
                {
                    PFMORM00015 deletedEntity = this.DeleteServer(item);
                    string id = deletedEntity.Id.ToString();
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("PFMORM00015", "Id", id, item.CreatedUserId,deletedEntity.TS));                  
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
	
        public void SaveOrUpdateClientDataVersion(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList,int createdUserId,string dataIdValue)
        {
            ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
            PFMORM00015 AccountTypeORM = new PFMORM00015();

            //Require Data
            clientDataVersionDTO.ORMObjectName = AccountTypeORM;
            clientDataVersionDTO.DataIdValue = dataIdValue;
            //clientDataVersionDTO.DataIdValue = GlobalUtilities.ConvertClassPropertyToString(() => AccountTypeORM.Id);
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