//----------------------------------------------------------------------
// <copyright file="SAMSVE00022.cs" company="ACE Data Systems">
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
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Core.Ctr;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Sam.Sve
{
    /// <summary>
    /// PORate Service
    /// </summary>
    public class SAMSVE00022 : BaseService, ISAMSVE00022
    {
        #region Properties

        private ITLMDAO00003 pORateDAO;
        public ITLMDAO00003 PORateDAO
        {
            get { return this.pORateDAO; }
            set { this.pORateDAO = value; }
        }

        private TLMORM00003 PORateInfo;

        #endregion

        #region Helper Method

        private TLMORM00003 GetPORate(TLMDTO00003 pORateDTO, bool isDelete)
        {
            PORateInfo = new TLMORM00003();

            //if (pORateDTO.Status == "Update" || pORateDTO.Status == "Delete")
            //{ PORateInfo.Id = pORateDTO.Id; }
            PORateInfo.Id = pORateDTO.Id;
            PORateInfo.Range = pORateDTO.Range;
            PORateInfo.Rate = pORateDTO.Rate;
            PORateInfo.FixAmount = pORateDTO.FixAmount;
            PORateInfo.StartNo = pORateDTO.StartNo;
            PORateInfo.EndNo = pORateDTO.EndNo;
            PORateInfo.UniqueId = pORateDTO.UniqueId;
            PORateInfo.Currency = pORateDTO.Currency;
            PORateInfo.TS = pORateDTO.TS;
            PORateInfo.CreatedUserId = pORateDTO.CreatedUserId;
            PORateInfo.CreatedDate = DateTime.Now;
            PORateInfo.UpdatedUserId = pORateDTO.CreatedUserId;
            PORateInfo.UpdatedDate = DateTime.Now;
            if (isDelete)
                PORateInfo.Active = false;
            else
                PORateInfo.Active = true;
            return PORateInfo;
        }

        #endregion

        #region Main Methods

        public virtual IList<TLMDTO00003> GetAll()
        {
            return this.PORateDAO.SelectAll();
        }

        public TLMDTO00003 SelectById(int id)
        {
            return this.PORateDAO.SelectById(id);
        }

        public IList<CurrencyDTO> GetCurrency()
        {
            return this.PORateDAO.SelectCurrency();        
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual TLMORM00003 Save(TLMDTO00003 entity)
        {
            TLMORM00003 poRate = null;
            entity.Range = 0;

            if (this.pORateDAO.CheckExist(0, entity.Rate, entity.FixAmount, entity.StartNo, entity.EndNo, entity.Currency))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists                     
            }
            else
            {
                poRate = this.pORateDAO.Save(this.GetPORate(entity, false));
                this.SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), poRate.CreatedUserId, poRate.Id.ToString());
            }
            return poRate;
        }
        public void SaveServerAndServerClient(TLMDTO00003 entity)
        {
            TLMORM00003 poRate = null;           
            try
            {
                poRate = this.Save(entity);
                if (!this.ServiceResult.ErrorOccurred)
                {
                    Dictionary<string, object> poKeyPair = new Dictionary<string, object> { 
                    { "Id", poRate.Id },
                    { "Range", poRate.Range },
                    { "Rate", poRate.Rate },
                    { "FixAmt", poRate.FixAmount },
                    { "StartNo", poRate.StartNo },
                    { "EndNo", poRate.EndNo },
                    { "UId", poRate.UniqueId },
                    { "Cur", poRate.Currency } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("PORate", poKeyPair, poRate.TS, poRate.CreatedUserId, poRate.CreatedDate));
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
        public virtual TLMORM00003 UpdateServer(TLMDTO00003 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
                TLMORM00003 porate = null;
                if (this.pORateDAO.CheckExist(entity.Id, entity.Rate, entity.FixAmount, entity.StartNo, entity.EndNo, entity.Currency))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV90001";//data already exists
                }
                else
                {         
                   
                 porate =   this.pORateDAO.Update(this.GetPORate(entity,false));
                 SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, porate.CreatedUserId, porate.Id.ToString());                 
                }
                return porate;
           
        }

        public virtual void Update(TLMDTO00003 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            try
            {
                 TLMORM00003 porate = this.UpdateServer(entity,dvcvList);
                 if (!this.ServiceResult.ErrorOccurred)
                 {
                     Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> { 
                    { "Rate", porate.Rate }, 
                    { "FixAmount", porate.FixAmount },
                    { "StartNo", porate.StartNo }, 
                    { "EndNo", porate.EndNo }, 
                    { "Currency", porate.Currency }, 
                    { "UpdatedUserId", porate.UpdatedUserId },
                    { "UpdatedDate", DateTime.Now } ,
                    {"TS",porate.TS}
                    
                    };
                     Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "Id", porate.Id.ToString() }, { "Active", true } };
                     CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("TLMORM00003", updateColumnsandValues, whereColumnsandValues));
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
        public virtual TLMORM00003 DeleteServer(TLMDTO00003 porateDTO)
        {
            TLMORM00003 porate = this.PORateDAO.Delete(this.GetPORate(porateDTO,true),false);
            SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), porateDTO.UpdatedUserId.Value, porateDTO.Id.ToString());
            return porate;
        }

        public virtual void Delete(IList<TLMDTO00003> itemList)
        {
            try
            {
                foreach (TLMDTO00003 item in itemList)
                {
                    TLMORM00003 deletedEntity = this.DeleteServer(item);
                    string id = deletedEntity.Id.ToString();
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("TLMORM00003", "Id", id, deletedEntity.CreatedUserId, deletedEntity.TS));
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
            TLMORM00003 PORateORM = new TLMORM00003();

            //Require Data
            clientDataVersionDTO.ORMObjectName = PORateORM;
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