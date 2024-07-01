//----------------------------------------------------------------------
// <copyright file="SAMSVE00015.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser></CreatedUser>
// <CreatedDate>08/01/2013</CreatedDate>
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
    /// FixRate Service
    /// </summary>
    public class SAMSVE00015 : BaseService, ISAMSVE00015
    {
        #region Properties

        private IPFMDAO00007 fixRateDAO;
        public IPFMDAO00007 FixRateDAO
        {
            get { return this.fixRateDAO; }
            set { this.fixRateDAO = value; }
        }

        private PFMORM00007 FixRateInfo;

        #endregion

        #region Helper Method

        private PFMORM00007 GetFixRate(PFMDTO00007 fixRateDTO, bool isDelete)
        {
            FixRateInfo = new PFMORM00007();

            FixRateInfo.Id = fixRateDTO.Id;
            FixRateInfo.Description = fixRateDTO.Description;
            FixRateInfo.DATE_TIME = DateTime.Now;
            FixRateInfo.IsLastModify = fixRateDTO.IsLastModify;
            FixRateInfo.UserNumber = fixRateDTO.CreatedUserId.ToString();
            FixRateInfo.Rate = fixRateDTO.Rate;
            FixRateInfo.Duration = fixRateDTO.Duration;
            FixRateInfo.TS = fixRateDTO.TS;
            FixRateInfo.CreatedUserId = fixRateDTO.CreatedUserId;
            FixRateInfo.CreatedDate = DateTime.Now;
            FixRateInfo.UpdatedUserId = fixRateDTO.UpdatedUserId;
            FixRateInfo.UpdatedDate = DateTime.Now;

            if (isDelete)
                FixRateInfo.Active = false;
            else
                FixRateInfo.Active = true;

            return FixRateInfo;
        }

        #endregion

        #region Main Methods

        public virtual IList<PFMDTO00007> GetAll()
        {
            return this.FixRateDAO.SelectAll();
        }

        public PFMDTO00007 SelectById(int id)
        {
            return this.FixRateDAO.SelectById(id);
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual PFMORM00007 Save(PFMDTO00007 entity)
        {
            PFMORM00007 fixRate = null;           
            entity.IsLastModify = true;               
            if (this.fixRateDAO.CheckExist(0, entity.Duration,entity.Description,entity.Rate))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists                     
            }
            else
            {
                 fixRate = this.fixRateDAO.Save(this.GetFixRate(entity, false));                 
                SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), fixRate.CreatedUserId, fixRate.Id.ToString());
            }            
         return fixRate;
        }

        public void SaveServerAndServerClient(PFMDTO00007 entity)
        {          
            try
            {
                PFMORM00007 fixrate = this.Save(entity);
                if (!this.ServiceResult.ErrorOccurred)
                {
                    Dictionary<string, object> accounttypeKeyPair = new Dictionary<string, object> { 
                    { "Id", fixrate.Id },
                    { "Desp", fixrate.Description },
                    { "DATE_TIME", fixrate.DATE_TIME },
                    { "LASTMODIFY",fixrate.IsLastModify  }, 
                    { "USERNO", fixrate.UserNumber },
                    { "Rate", fixrate.Rate },
                    { "Duration", fixrate.Duration } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("FixRate", accounttypeKeyPair, fixrate.TS, fixrate.CreatedUserId, fixrate.CreatedDate));
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
        public virtual PFMORM00007 UpdateServer(PFMDTO00007 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            PFMORM00007 fixRate = null;          
            if (this.FixRateDAO.CheckExist(entity.Id, entity.Duration, entity.Description, entity.Rate))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists
            }
            else
            {                    
                fixRate =  this.fixRateDAO.Update(GetFixRate(entity,false));                 
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Id.ToString());
            }
            return fixRate;           
        }

        public virtual void Update(PFMDTO00007 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            try
            {
                PFMORM00007 fixrate = this.UpdateServer(entity,dvcvList);               
                if(!this.ServiceResult.ErrorOccurred)
                {                   
                    Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> {
                    { "Duration", fixrate.Duration }, 
                    { "Description", fixrate.Description }
                    , { "Rate", fixrate.Rate }, 
                    { "UpdatedUserId", fixrate.UpdatedUserId },
                    { "UpdatedDate", DateTime.Now } ,
                    {"LASTMODIFY",fixrate.IsLastModify},
                    {"TS",fixrate.TS}
                    };
                    Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "Id", fixrate.Id }, { "Active", true } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00007", updateColumnsandValues, whereColumnsandValues));
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
        public virtual PFMORM00007 DeleteServer(PFMDTO00007 fixrateDTO)
        {
            PFMORM00007 fixrateEntity = this.GetFixRate(fixrateDTO,true);
            fixrateEntity.IsLastModify = false;      
            fixrateEntity.UserNumber = fixrateDTO.UserNumber;
            PFMORM00007 deletedEntity =  this.fixRateDAO.Delete(fixrateEntity, false);
            SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), fixrateDTO.CreatedUserId, fixrateDTO.Id.ToString());

            return deletedEntity;
        }

        public virtual void Delete(IList<PFMDTO00007> itemList)
        {
            try
            {
                foreach (PFMDTO00007 item in itemList)
                {
                   PFMORM00007 deletedEntity = this.DeleteServer(item);
                    string id = deletedEntity.Id.ToString();
                   CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("PFMORM00007", "Id",id , deletedEntity.CreatedUserId,deletedEntity.TS));
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
            PFMORM00007 FixedRateORM = new PFMORM00007();

            //Require Data
            clientDataVersionDTO.ORMObjectName = FixedRateORM;
            //clientDataVersionDTO.DataIdValue = GlobalUtilities.ConvertClassPropertyToString(() => FixedRateORM.Id);
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