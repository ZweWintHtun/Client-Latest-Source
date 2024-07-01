//----------------------------------------------------------------------
// <copyright file="SAMSVE00052.cs" company="ACE Data Systems">
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
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Sam.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Core.Ctr;
using Ace.Windows.Core.DataModel;


namespace Ace.Cbs.Sam.Sve
{
    /// <summary>
    /// TranType Service
    /// </summary>
	public class SAMSVE00052:BaseService,ISAMSVE00052
  	{
		#region Properties
		
		private ITLMDAO00005 tranTypeDAO;
        public ITLMDAO00005 TranTypeDAO
        {
            get { return this.tranTypeDAO; }
            set { this.tranTypeDAO = value; }
        }
		
		private TLMORM00005 TranTypeInfo;
		
		#endregion      

        #region Helper Method

        private TLMORM00005 GetTranType(TLMDTO00005 tranTypeDTO, bool isDelete)
        {
            TranTypeInfo = new TLMORM00005();
            TranTypeInfo.TransactionCode = tranTypeDTO.TransactionCode;
            TranTypeInfo.Description = tranTypeDTO.Description;
            TranTypeInfo.Narration = tranTypeDTO.Narration;
            TranTypeInfo.Status = tranTypeDTO.Status;
            TranTypeInfo.PBReference = tranTypeDTO.PBReference;
            TranTypeInfo.RVReference = tranTypeDTO.RVReference;
            TranTypeInfo.UniqueId = tranTypeDTO.UniqueId;
            TranTypeInfo.TS = tranTypeDTO.TS;
            TranTypeInfo.CreatedUserId = tranTypeDTO.CreatedUserId;
            TranTypeInfo.CreatedDate = DateTime.Now;
            TranTypeInfo.UpdatedUserId = tranTypeDTO.UpdatedUserId;
            TranTypeInfo.UpdatedDate = DateTime.Now;
            if (isDelete)
                TranTypeInfo.Active = false;
            else
                TranTypeInfo.Active = true;
            return TranTypeInfo;
        }

        #endregion
		
		#region Main Methods
		
		public virtual IList<TLMDTO00005> GetAll()
        {
            return this.TranTypeDAO.SelectAll();
        }

        public TLMDTO00005 SelectByTranCode(string tranCode)
        {
            return this.TranTypeDAO.SelectByTranCode(tranCode);
        }

        public IList<TLMDTO00005> CheckExist2(string TranTypeCode, string desp)
        {
            return this.TranTypeDAO.CheckExist2(TranTypeCode, desp);
        }
		
		[Transaction(TransactionPropagation.Required)]
        public virtual TLMORM00005 Save(TLMDTO00005 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            TLMORM00005 trantype = null;
            if (!entity.Active)  //Active = 0 , update nature
            {
                this.Update(entity, dvcvList, "Save");
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.TransactionCode);
                return null;
            }
            else //Active = 1 , insert nature
            {
                trantype = this.tranTypeDAO.Save(this.GetTranType(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), entity.CreatedUserId, entity.TransactionCode);                   
            }               
            
            return trantype;
        }

        public void SaveServerAndServerClient(TLMDTO00005 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            TLMORM00005 trantype = null;
            try
            {
                trantype = this.Save(entity, dvcvList);
                if (trantype != null)
                {
                    if (!this.ServiceResult.ErrorOccurred)
                    {
                        Dictionary<string, object> initalKeyPair = new Dictionary<string, object> 
                        { 
                            { "TranCode", trantype.TransactionCode }, 
                            { "Desp", trantype.Description }, 
                            { "Narration", trantype.Narration }, 
                            { "Status", trantype.Status }, 
                            { "PBReference", trantype.PBReference }, 
                            { "RVReference", trantype.RVReference } 
                        };
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("TranType", initalKeyPair, trantype.TS, trantype.CreatedUserId, trantype.CreatedDate));
                        this.ServiceResult.ErrorOccurred = false;
                        this.ServiceResult.MessageCode = "MI90001";// Saving Successful  
                    }
                }

            }
            catch (Exception )
            {                
                this.ServiceResult.ErrorOccurred = true;               
                this.ServiceResult.MessageCode = "ME90036";
            }

        }
		
		[Transaction(TransactionPropagation.Required)]
        public virtual TLMORM00005 UpdateServer(TLMDTO00005 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            TLMORM00005 trantype = null; 
            if (this.tranTypeDAO.CheckExist(entity.TransactionCode,entity.Description,true))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV90001";//data already exists
                }
                else
                {  
					
                  trantype =  this.tranTypeDAO.Update(GetTranType(entity,false));
                    SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.TransactionCode);                                   
                }
            return trantype;
        }

        public virtual void Update(TLMDTO00005 entity, IList<DataVersionChangedValueDTO> dvcvList, string status)
        {
            try
            {
                TLMORM00005 trantype = UpdateServer(entity,dvcvList);
                if (!this.ServiceResult.ErrorOccurred)
                {
                    Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> {
                { "TransactionCode", trantype.TransactionCode },
                { "Description", trantype.Description },
                { "Active", trantype.Active},
                { "Narration", trantype.Narration },
                { "Status", trantype.Status }, 
                { "PBReference", trantype.PBReference },
                { "RVReference", trantype.RVReference },
                { "UpdatedUserId", trantype.UpdatedUserId }, { "UpdatedDate", DateTime.Now } ,
                {"TS",trantype.TS}   
                };
                Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "TransactionCode", trantype.TransactionCode }};
                CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("TLMORM00005", updateColumnsandValues, whereColumnsandValues));
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
        public virtual TLMORM00005 DeleteServer(TLMDTO00005 trantypeDTO)
        {
            TLMORM00005 trantype =  this.tranTypeDAO.Delete(GetTranType(trantypeDTO,true), false);
            SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), trantypeDTO.CreatedUserId, trantypeDTO.TransactionCode);
            return trantype;        
        }

        public virtual void Delete(IList<TLMDTO00005> itemList)
        {
            try
            {
                foreach (TLMDTO00005 item in itemList)
                {
                    TLMORM00005 trantype =  DeleteServer(item);
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("TLMORM00005", "TransactionCode", trantype.TransactionCode, trantype.CreatedUserId,trantype.TS));
                }
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90003";//Delete Success
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";
            }
        }

        public void SaveOrUpdateClientDataVersion(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId, string dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
            TLMORM00005 TranTypeORM = new TLMORM00005();

            //Require Data
            clientDataVersionDTO.ORMObjectName = TranTypeORM;
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

