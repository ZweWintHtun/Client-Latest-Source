// <copyright file="SAMSVE00004.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser></CreatedUser>
// <CreatedDate>07/25/2013</CreatedDate>
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
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Core.Ctr;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Sam.Sve
{
    /// <summary>
    /// BCode Service
    /// </summary>
    public class SAMSVE00004 : BaseService, ISAMSVE00004
    {
        #region Properties

        private ITLMDAO00040 bCodeDAO;
        public ITLMDAO00040 BCodeDAO
        {
            get { return this.bCodeDAO; }
            set { this.bCodeDAO = value; }
        }

        private TLMORM00040 BCodeInfo;

        #endregion

        #region Helper Method
        private TLMORM00040 GetBCode(TLMDTO00040 bCodeDTO, bool isDelete)
        {
            BCodeInfo = new TLMORM00040();
            BCodeInfo.BCode = bCodeDTO.BCode;
            BCodeInfo.BDesp = bCodeDTO.BDesp;
            BCodeInfo.BAccountNo = bCodeDTO.BAccountNo;
            BCodeInfo.UniqueId = bCodeDTO.UniqueId;
            BCodeInfo.TS = bCodeDTO.TS;
            BCodeInfo.CreatedUserId = bCodeDTO.CreatedUserId;
            BCodeInfo.CreatedDate = DateTime.Now;
            BCodeInfo.UpdatedUserId = bCodeDTO.UpdatedUserId;
            BCodeInfo.UpdatedDate = DateTime.Now;
            if (isDelete)
                BCodeInfo.Active = false;
            else
                BCodeInfo.Active = true;

            return BCodeInfo;
        }
        #endregion

        #region Main Methods
        public virtual IList<TLMDTO00040> GetAll()
        {
            return this.BCodeDAO.SelectAll();
        }

        public TLMDTO00040 SelectByBCode(string bCode)
        {
            return this.BCodeDAO.SelectByBCode(bCode);
        }

  public IList<TLMDTO00040> CheckExist2(string bCode, string desp)
        {
            return this.BCodeDAO.CheckExist2(bCode, desp);
        }
        [Transaction(TransactionPropagation.Required)]
        public virtual TLMORM00040 Save(TLMDTO00040 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            TLMORM00040 bcode = null;           
            //if (this.bCodeDAO.CheckExist(entity.BCode, entity.BDesp,false))
            //{
            //    this.ServiceResult.ErrorOccurred = true;
            //    this.ServiceResult.MessageCode = "MV90001";//data already exists                     
            //}
            //else
            //{
            //    bcode = this.bCodeDAO.Save(this.GetBCode(entity, false));                    
            //    SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), entity.CreatedUserId, entity.BCode);
            //}
            if (!entity.Active)  //Active = 0 , update nature
            {
                this.Update(entity, dvcvList, "Save");
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.BCode);
                return null;
            }
            else //Active = 1 , insert nature  
            {
                bcode = this.BCodeDAO.Save(this.GetBCode(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), entity.CreatedUserId, entity.BCode);
            }          
            return bcode;
        }

        public void SaveServerAndServerClient(TLMDTO00040 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {            
            try
            {
                TLMORM00040 bcode = this.Save(entity, dvcvList);
				if (bcode != null)
                {
	                if (!this.ServiceResult.ErrorOccurred)
	                {
	                    Dictionary<string, object> accounttypeKeyPair = new Dictionary<string, object> {
	                    { "BCode", bcode.BCode },
	                    { "BDesp", bcode.BDesp },
	                    { "BAcctNo", bcode.BAccountNo } };
	                    CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("BCode", accounttypeKeyPair, bcode.TS, bcode.CreatedUserId, bcode.CreatedDate));
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
        public virtual TLMORM00040 UpdateServer(TLMDTO00040 entity,IList<DataVersionChangedValueDTO> dvcvList)
        {
            TLMORM00040 bcodeEntity = null;
           
                if (this.bCodeDAO.CheckExist(entity.BCode, entity.BDesp,true))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV90001";//data already exists
                }
                else
                {
                    bcodeEntity = this.BCodeDAO.Update(this.GetBCode(entity, false));                  
                    SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.BCode);
                }
                return bcodeEntity;
        }

		public virtual void Update(TLMDTO00040 entity, IList<DataVersionChangedValueDTO> dvcvList,string status)
        {
            try
            {
                TLMORM00040 bcode = this.UpdateServer(entity,dvcvList);
                if (!this.ServiceResult.ErrorOccurred)
                {
                    Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> {
                    { "BCode", bcode.BCode },
                    { "BDesp", bcode.BDesp }, 
                    { "BAccountNo", bcode.BAccountNo },
					{ "Active", bcode.Active},
                    { "UpdatedUserId", bcode.UpdatedUserId },
                    { "UpdatedDate", DateTime.Now },
                      { "TS",bcode.TS }
                    };
					// Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "BCode", bcode.BCode }, { "Active", true } };
                    Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "BCode", bcode.BCode } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("TLMORM00040", updateColumnsandValues, whereColumnsandValues));
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
        public virtual TLMORM00040 DeleteServer(TLMDTO00040 bcodeDTO)
        {
            TLMORM00040 bcode = this.GetBCode(bcodeDTO,true);
            TLMORM00040 deletedEntity =  this.BCodeDAO.Delete(bcode, false);
            SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), bcodeDTO.CreatedUserId, bcodeDTO.BCode);
            return deletedEntity;
        }

        public virtual void Delete(IList<TLMDTO00040> itemList)
        {
            try
            {
                foreach (TLMDTO00040 item in itemList)
                {
                   TLMORM00040 deletedEntity = this.DeleteServer(item);
                   CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("TLMORM00040", "BCode", deletedEntity.BCode, deletedEntity.CreatedUserId, deletedEntity.TS));
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

        public void SaveOrUpdateClientDataVersion(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId,string dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
            TLMORM00040 BCodeORM = new TLMORM00040();

            //Require Data
            clientDataVersionDTO.ORMObjectName = BCodeORM;
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