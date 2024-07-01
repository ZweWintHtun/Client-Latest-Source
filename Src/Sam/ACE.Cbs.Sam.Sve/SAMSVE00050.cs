//----------------------------------------------------------------------
// <copyright file="SAMSVE00050.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>08/08/2013</CreatedDate>
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
    /// Message Service
    /// </summary>
	public class SAMSVE00050:BaseService,ISAMSVE00050
  	{
		#region Properties
		
		private IPFMDAO00048 messageDAO;
        public IPFMDAO00048 MessageDAO
        {
            get { return this.messageDAO; }
            set { this.messageDAO = value; }
        }
		
		private PFMORM00048 MessageInfo;
		
		#endregion

        #region Helper Method

        private PFMORM00048 GetMessage(PFMDTO00048 messageDTO, bool isDelete)
        {
            MessageInfo = new PFMORM00048();

            MessageInfo.Code = messageDTO.Code;
            MessageInfo.Description = messageDTO.Description;
            MessageInfo.TS = messageDTO.TS;
            MessageInfo.CreatedUserId = messageDTO.CreatedUserId;
            MessageInfo.CreatedDate = DateTime.Now;
            MessageInfo.UpdatedUserId = messageDTO.UpdatedUserId;
            MessageInfo.UpdatedDate = DateTime.Now;
            if (isDelete)
                MessageInfo.Active = false;
            else
                MessageInfo.Active = true;

            return MessageInfo;
        }

        #endregion
		
		#region Main Methods

        public virtual IList<PFMDTO00048> GetAll()
        {
            return this.MessageDAO.SelectAll();
        }

        public PFMDTO00048 SelectByCode(string code)
        {
            return this.MessageDAO.SelectByCode(code);
        }

        public IList<PFMDTO00048> CheckExist2(string MessageCode, string desp)
        {
            return this.MessageDAO.CheckExist2(MessageCode, desp);
        }

        public void SaveOrUpdateClientDataVersion(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId, string dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
            PFMORM00048 MessageORM = new PFMORM00048();

            //Require Data
            clientDataVersionDTO.ORMObjectName = MessageORM;
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
        public virtual PFMORM00048 Save(PFMDTO00048 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            PFMORM00048 message = null;
            if (!entity.Active)  //Active = 0 , update nature
            {
                this.Update(entity, dvcvList, "Save");
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Code);
                return null;
            }
            else //Active = 1 , insert nature  
            {
                message = this.messageDAO.Save(this.GetMessage(entity, false));
                this.SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), entity.CreatedUserId, entity.Code);
            }
            return message;
        }

        public void SaveServerAndServerClient(PFMDTO00048 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
              PFMORM00048 message = null;            
                try
                {
                     message  = this.Save(entity, dvcvList);
                     if (message != null)
                     {
                         if (!this.ServiceResult.ErrorOccurred)
                         {
                             Dictionary<string, object> messageKeyPair = new Dictionary<string, object> 
                            {
                                { "Code", message.Code },
                                { "Description", message.Description } 
                            };
                             CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("Message", messageKeyPair, message.TS, message.CreatedUserId, message.CreatedDate));
                             this.ServiceResult.ErrorOccurred = false;
                             this.ServiceResult.MessageCode = "MI90001";// Saving Successful 
                         }
                     }
                }
                catch
                {                   
                    this.ServiceResult.ErrorOccurred = true;               
                    this.ServiceResult.MessageCode = "ME90036";
                }          
            
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual PFMORM00048 UpdateServer(PFMDTO00048 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            PFMORM00048 message = null;
           
            if (this.messageDAO.CheckExist(entity.Code, entity.Description, true))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists
            }
            else
            {                  
              message =  this.MessageDAO.Update(GetMessage(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Code);                         
            }
            return message;
        }

        public virtual void Update(PFMDTO00048 entity, IList<DataVersionChangedValueDTO> dvcvList, string status)
        {
            try
            {
                PFMORM00048 message = UpdateServer(entity, dvcvList);
                if (!this.ServiceResult.ErrorOccurred)
                {
                    Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> { 
                { "Code", message.Code }, 
                { "Description", message.Description }, 
                { "Active", message.Active},
                { "UpdatedUserId", message.UpdatedUserId }, 
                { "UpdatedDate", DateTime.Now },
                {"TS",message.TS}
                };
                    Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "Code", message.Code }};
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00048", updateColumnsandValues, whereColumnsandValues));
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
        public virtual PFMORM00048 DeleteServer(PFMDTO00048 messageDTO)
        {           
              PFMORM00048 message = this.messageDAO.Delete(GetMessage(messageDTO,true), false);
              this.SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), messageDTO.CreatedUserId, messageDTO.Code);
              return message;              
        }

        public virtual void Delete(IList<PFMDTO00048> itemList)
        {
            try
            {
                foreach (PFMDTO00048 item in itemList)
                {
                  PFMORM00048 message = DeleteServer(item);
                  CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("PFMORM00048", "Code", message.Code, message.CreatedUserId,message.TS));
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
