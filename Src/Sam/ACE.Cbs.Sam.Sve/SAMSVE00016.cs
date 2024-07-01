//----------------------------------------------------------------------
// <copyright file="SAMSVE00016.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>08/07/2013</CreatedDate>
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
    /// NewSetup Service
    /// </summary>
	public class SAMSVE00016:BaseService,ISAMSVE00016
  	{
		#region Properties
		
		private IPFMDAO00057 newSetupDAO;
        public IPFMDAO00057 NewSetupDAO
        {
            get { return this.newSetupDAO; }
            set { this.newSetupDAO = value; }
        }
		
		private PFMORM00057 NewSetupInfo;
		
		#endregion

        #region Helper Method

        private PFMORM00057 GetNewSetup(PFMDTO00057 newSetupDTO, bool isDelete)
        {
            NewSetupInfo = new PFMORM00057();

            NewSetupInfo.Variable = newSetupDTO.Variable;
            NewSetupInfo.Value = newSetupDTO.Value;
            NewSetupInfo.TS = newSetupDTO.TS;           
            NewSetupInfo.CreatedUserId = newSetupDTO.CreatedUserId;
            NewSetupInfo.CreatedDate = DateTime.Now;          
            NewSetupInfo.UpdatedUserId = newSetupDTO.UpdatedUserId;
            NewSetupInfo.UpdatedDate = DateTime.Now;
            if (isDelete)
                NewSetupInfo.Active = false;
            else
                NewSetupInfo.Active = true;
            return NewSetupInfo;
        }

        #endregion
		
		#region Main Methods

        public virtual IList<PFMDTO00057> GetAll()
        {
            return this.NewSetupDAO.SelectAll();
        }

        public PFMDTO00057 SelectByVariable(string variable)
        {
            return this.NewSetupDAO.SelectByVariable(variable);
        }

        public IList<PFMDTO00057> CheckExist2(string variable, string value)
        {
            return this.NewSetupDAO.CheckExist2(variable, value);
        }
		
		[Transaction(TransactionPropagation.Required)]
        public virtual PFMORM00057 Save(PFMDTO00057 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            PFMORM00057 newsetup = null;
            if (!entity.Active)  //Active = 0 , update nature
            {
                this.Update(entity, dvcvList, "Save");
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Variable);
                return null;
            }
            else //Active = 1 , insert nature
            {
                newsetup = this.newSetupDAO.Save(this.GetNewSetup(entity,false));  
                this.SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), entity.CreatedUserId, entity.Variable);
            }              
           
            return newsetup;
        }

        public void SaveServerAndServerClient(PFMDTO00057 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            PFMORM00057 newsetup = null;
            try
            {
                newsetup = this.Save(entity, dvcvList);
                if (newsetup != null)
                {
                    if (!this.ServiceResult.ErrorOccurred)
                    {
                        Dictionary<string, object> newsetUpKeyPair = new Dictionary<string, object> 
                        { 
                            { "Variable", newsetup.Variable }, 
                            { "Value", newsetup.Value } 
                        };
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("NewSetup", newsetUpKeyPair, newsetup.TS, newsetup.CreatedUserId, newsetup.CreatedDate));
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
        public virtual PFMORM00057 UpdateServer(PFMDTO00057 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            PFMORM00057 newsetup = null;
                if (this.newSetupDAO.CheckExist(entity.Variable,entity.Value,true))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV90001";//data already exists
                }
                else
                {   					
                   newsetup = this.newSetupDAO.Update(GetNewSetup(entity,false));                  
                   this.SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Variable);
                }    
         
            return newsetup;
        }

        public virtual void Update(PFMDTO00057 entity, IList<DataVersionChangedValueDTO> dvcvList, string status)
        {
            try
            { 
               PFMORM00057 newsetup =  this.UpdateServer(entity,dvcvList);               
                if(!this.ServiceResult.ErrorOccurred)
                {  				   
                    Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> {
                    { "Variable", newsetup.Variable }, 
                    { "Value", newsetup.Value },
                    { "Active", newsetup.Active},
                    { "UpdatedUserId", newsetup.UpdatedUserId },
                    { "UpdatedDate", DateTime.Now },
                    {"TS",newsetup.TS}
                    };
                    Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "Variable", newsetup.Variable }};
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00057", updateColumnsandValues, whereColumnsandValues));
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
       public virtual PFMORM00057 DeleteServer(PFMDTO00057 newsetupDTO)
        {
           PFMORM00057 newsetup = this.NewSetupDAO.Delete(this.GetNewSetup(newsetupDTO,true),false);
           this.SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), newsetupDTO.CreatedUserId, newsetupDTO.Variable);
           return newsetup;
        }
        public virtual void Delete(IList<PFMDTO00057> itemList)
        {
            try
            {
                foreach (PFMDTO00057 item in itemList)
                {
                  PFMORM00057 newsetup =  this.DeleteServer(item);
                  CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("PFMORM00057", "Variable", newsetup.Variable, newsetup.CreatedUserId, newsetup.TS));
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
            PFMORM00057 NewSetupORM = new PFMORM00057();

            //Require Data
            clientDataVersionDTO.ORMObjectName = NewSetupORM;
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
