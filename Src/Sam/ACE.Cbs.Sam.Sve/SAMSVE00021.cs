//----------------------------------------------------------------------
// <copyright file="SAMSVE00021.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser></CreatedUser>
// <CreatedDate></CreatedDate>
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
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Core.Ctr;
using Ace.Windows.Core.DataModel;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Ix.Server.Sve;

namespace Ace.Cbs.Sam.Sve
{
    /// <summary>
    /// Initial Setup Service
    /// </summary>
    public class SAMSVE00021 : BaseService, ISAMSVE00021
    {
        #region Properties

        private IPFMDAO00003 initialDAO;
        public IPFMDAO00003 InitialDAO
        {
            get { return this.initialDAO; }
            set { this.initialDAO = value; }
        }

        private PFMORM00003 InitialInfo;

        #endregion

        #region Helper Method

        private PFMORM00003 GetInitial(PFMDTO00003 initialDTO, bool isDelete)
        {
            InitialInfo = new PFMORM00003();

            InitialInfo.Initial = initialDTO.Initial;
            InitialInfo.Description = initialDTO.Description;
            InitialInfo.TS = initialDTO.TS;
            InitialInfo.CreatedUserId = initialDTO.CreatedUserId;
            InitialInfo.CreatedDate = DateTime.Now;
            InitialInfo.UpdatedUserId = initialDTO.UpdatedUserId;
            InitialInfo.UpdatedDate = DateTime.Now;
            if (isDelete)
                InitialInfo.Active = false;
            else
                InitialInfo.Active = true;
            return InitialInfo;
        }

        #endregion

        #region Main Methods

        public virtual IList<PFMDTO00003> GetAll()
        {
            return this.InitialDAO.SelectAll();            
        }

        public PFMDTO00003 SelectByInitial(string initial)
        {
            return this.InitialDAO.SelectByInitial(initial);
        }

 public IList<PFMDTO00003> CheckExist2(string initial, string desp)
        {
            return this.InitialDAO.CheckExist2(initial, desp);
        }
        [Transaction(TransactionPropagation.Required)]
        public virtual PFMORM00003 Save(PFMDTO00003 entity , IList<DataVersionChangedValueDTO> dvcvList)
        {
            PFMORM00003 initial = null;           
            //if (this.initialDAO.CheckExist(entity.Initial, entity.Description,false))
            //{
            //    this.ServiceResult.ErrorOccurred = true;
            //    this.ServiceResult.MessageCode = "MV90001";//data already exists                     
            //}
            //else
            //{
            //    initial = this.initialDAO.Save(this.GetInitial(entity, false));                 
            //    this.SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), entity.CreatedUserId, entity.Initial);
            //}  
            if (!entity.Active)  //Active = 0 , update nature
            {
                this.Update(entity, dvcvList, "Save");
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Initial);
                return null;
            }
            else //Active = 1 , insert nature  
            {
                initial = this.initialDAO.Save(this.GetInitial(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), entity.CreatedUserId, entity.Initial);
            }        
            return initial;
        }

       public void SaveServerAndServerClient(PFMDTO00003 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {           
            try
            {
                PFMORM00003 initail = this.Save(entity,dvcvList);
				if (initail != null)
                {
	                if (!this.ServiceResult.ErrorOccurred)
	                {
	                    Dictionary<string, object> initalKeyPair = new Dictionary<string, object> {
	                    { "Initial", initail.Initial }, 
	                    { "Description", initail.Description }                    
	                    };
	                    CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("Initial", initalKeyPair, initail.TS, initail.CreatedUserId, initail.CreatedDate));
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
        public virtual PFMORM00003 UpdateServer(PFMDTO00003 entity,IList<DataVersionChangedValueDTO> dvcvList)
        {
            PFMORM00003 initial = null;
                if ((this.initialDAO.CheckExist(entity.Initial, entity.Description,true)))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV90001";//data already exists
                }
                else
                {                  
                    initial =  this.initialDAO.Update(GetInitial(entity, false));                   
                    this.SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Initial);
                }
                return initial;            
              }

		public virtual void Update(PFMDTO00003 entity, IList<DataVersionChangedValueDTO> dvcvList,string status)
        {
            try
            {
               PFMORM00003 initial =  this.UpdateServer(entity, dvcvList);
               if (!this.ServiceResult.ErrorOccurred)
               {
                   Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> { 
                   { "Initial", initial.Initial }, 
                   { "Description", initial.Description }, 
				   { "Active", initial.Active},
                   { "UpdatedUserId", initial.UpdatedUserId },
                   { "UpdatedDate", DateTime.Now } ,
                   {"TS",initial.TS}
                   };
				   //Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "Initial", initial.Initial }, { "Active", true } };
                   Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "Initial", initial.Initial } };
                   CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00003", updateColumnsandValues, whereColumnsandValues));
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
        public virtual PFMORM00003 DeleteServer(PFMDTO00003 initialDTO)
        {
            PFMORM00003 initial = this.initialDAO.Delete(this.GetInitial(initialDTO, true), false);
            this.SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), initialDTO.CreatedUserId, initialDTO.Initial);
            return initial;           
        }

        public virtual void Delete(IList<PFMDTO00003> itemList)
        {
            try
            {
                foreach (PFMDTO00003 item in itemList)
                {
                     PFMORM00003 deletedEntity = this.DeleteServer(item);
                     CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("PFMORM00003", "Initial", deletedEntity.Initial, deletedEntity.CreatedUserId, deletedEntity.TS));
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
            PFMORM00003 InitialORM = new PFMORM00003();

            //Require Data
            clientDataVersionDTO.ORMObjectName = InitialORM;
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