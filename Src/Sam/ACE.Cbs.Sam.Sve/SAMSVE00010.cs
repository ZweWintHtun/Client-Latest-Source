//----------------------------------------------------------------------
// <copyright file="SAMSVE00010.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser></CreatedUser>
// <CreatedDate>/2013</CreatedDate>
// <UpdatedUser>Nyo Me San</UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Sam.Ctr.Dao;
using Ace.Cbs.Sam.Ctr.Sve;
using Ace.Cbs.Sam.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Windows.Ix.Core.Ctr;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Sam.Sve
{
    /// <summary>
    /// AppSettings Service
    /// </summary>
    public class SAMSVE00010 : BaseService, ISAMSVE00010
    {
        #region Properties

        private IPFMDAO00053 appSettingsDAO;
        public IPFMDAO00053 AppSettingsDAO
        {
            get { return this.appSettingsDAO; }
            set { this.appSettingsDAO = value; }
        }

        private PFMORM00053 AppSettingsInfo;

        #endregion

        #region Helper Method

        private PFMORM00053 GetAppSettings(PFMDTO00053 appSettingsDTO, bool isDelete)
        {
            AppSettingsInfo = new PFMORM00053();
            AppSettingsInfo.Id = appSettingsDTO.Id;
            AppSettingsInfo.KeyName = appSettingsDTO.KeyName;
            AppSettingsInfo.KeyValue = appSettingsDTO.KeyValue;
            AppSettingsInfo.Description = appSettingsDTO.Description;
            AppSettingsInfo.Location = appSettingsDTO.Location;
            AppSettingsInfo.Type = appSettingsDTO.Type;
            AppSettingsInfo.BinaryValue = appSettingsDTO.BinaryValue;
            AppSettingsInfo.CreatedUserId = appSettingsDTO.CreatedUserId;
            AppSettingsInfo.UpdatedUserId = appSettingsDTO.UpdatedUserId;
            AppSettingsInfo.TS = appSettingsDTO.TS;
            AppSettingsInfo.CreatedUserId = appSettingsDTO.CreatedUserId;
            AppSettingsInfo.CreatedDate = DateTime.Now;
            AppSettingsInfo.UpdatedUserId = appSettingsDTO.UpdatedUserId;
            AppSettingsInfo.UpdatedDate = DateTime.Now;
            if (isDelete)
                AppSettingsInfo.Active = false;
            else
                AppSettingsInfo.Active = true;
            return AppSettingsInfo;
        }

        #endregion

        #region Main Methods

        public virtual IList<PFMDTO00053> GetAll()
        {
            return this.AppSettingsDAO.SelectAll();
        }

        public PFMDTO00053 SelectById(int id)
        {
            return this.AppSettingsDAO.SelectById(id);
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual PFMORM00053 Save(PFMDTO00053 entity)
        {
            PFMORM00053 appSettings  = null;
            if (this.appSettingsDAO.CheckExist(0, entity.KeyName, entity.KeyValue, entity.Location, entity.Type))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists                     
            }
            else
            {
                appSettings = this.appSettingsDAO.Save(this.GetAppSettings(entity, false));              
                SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), appSettings.CreatedUserId, appSettings.Id.ToString());
            }
            return appSettings;
        }

        public void SaveServerAndServerClient(PFMDTO00053 entity)
        {           
            try
            {
                PFMORM00053 appsetting = this.Save(entity);
                if (!this.ServiceResult.ErrorOccurred)
                {
                    if (appsetting.BinaryValue == null)
                        appsetting.BinaryValue = new Byte[0];
                    Dictionary<string, object> accounttypeKeyPair = new Dictionary<string, object> { { "Id", appsetting.Id }, { "KeyName", appsetting.KeyName }, { "KeyValue", appsetting.KeyValue }, { "Description", appsetting.Description }, { "Location", appsetting.Location }, { "Type", appsetting.Type }, { "BinaryValue", appsetting.BinaryValue } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("AppSettings", accounttypeKeyPair, appsetting.TS, appsetting.CreatedUserId, appsetting.CreatedDate));
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
        public virtual PFMORM00053 UpdateServer(PFMDTO00053 entity,IList<DataVersionChangedValueDTO> dvcvList)
        {
            PFMORM00053 appsetting = null;

                if (this.appSettingsDAO.CheckExist(entity.Id, entity.KeyName, entity.KeyValue, entity.Location, entity.Type))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV90001";//data already exists
                }
                else
                {
                    appsetting = this.AppSettingsDAO.Update(GetAppSettings(entity,false));                  
                    SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Id.ToString());                   
                }
                return appsetting;
        }
     
        public virtual void Update(PFMDTO00053 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            try
            {
                PFMORM00053 appsetting = this.UpdateServer(entity,dvcvList);
                if (appsetting.BinaryValue == null)
                    appsetting.BinaryValue = new Byte[0];
               if(!this.ServiceResult.ErrorOccurred)
               {
                   Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> { 
                    { "KeyName", appsetting.KeyName }, 
                    { "KeyValue", appsetting.KeyValue },
                    { "Description", appsetting.Description },
                    { "Location", appsetting.Location }, 
                    { "Type", appsetting.Type }, 
                    { "BinaryValue", appsetting.BinaryValue },
                    { "UpdatedUserId", appsetting.UpdatedUserId },
                    { "UpdatedDate", DateTime.Now },
                    {"TS",appsetting.TS}                    
                    };
                   Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "Id", appsetting.Id }, { "Active", true } };
                   CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00053", updateColumnsandValues, whereColumnsandValues));
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
        public virtual PFMORM00053 DeleteServer(PFMDTO00053 appsettingDTO)
        {
             PFMORM00053 deletedEntity = this.AppSettingsDAO.Delete(this.GetAppSettings(appsettingDTO, true),false);
            SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), appsettingDTO.CreatedUserId, appsettingDTO.Id.ToString());
            return deletedEntity;
        }

        public virtual void Delete(IList<PFMDTO00053> itemList)
        {
            try
            {
                foreach (PFMDTO00053 item in itemList)
                {
                   PFMORM00053 deletedEntity =  this.DeleteServer(item);
                   string id = deletedEntity.Id.ToString();
                   CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("PFMORM00053", "Id", id, item.CreatedUserId, deletedEntity.TS));
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

        public void SaveOrUpdateClientDataVersion(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId, string dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
            PFMORM00053 AppSettingORM = new PFMORM00053();

            //Require Data
            clientDataVersionDTO.ORMObjectName = AppSettingORM;
            //clientDataVersionDTO.DataIdValue = GlobalUtilities.ConvertClassPropertyToString(() => AppSettingORM.Id);
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