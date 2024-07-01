//----------------------------------------------------------------------
// <copyright file="SAMSVE00051.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser></CreatedUser>
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
using Ace.Cbs.Sam.Ctr.Dao;
using Ace.Cbs.Sam.Ctr.Sve;
using Ace.Cbs.Sam.Dmd;
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
    /// RateInfo Service
    /// </summary>
    public class SAMSVE00051 : BaseService, ISAMSVE00051
    {
        #region Properties

        private IPFMDAO00075 rateInfoDAO;
        public IPFMDAO00075 RateInfoDAO
        {
            get { return this.rateInfoDAO; }
            set { this.rateInfoDAO = value; }
        }

        private PFMORM00074 RateInfoInfo;

        #endregion

        #region Helper Method

        private PFMORM00074 GetRateInfo(PFMDTO00075 rateInfoDTO, bool isDelete)
        {
            RateInfoInfo = new PFMORM00074();
            if (rateInfoDTO.Status == "Update" || rateInfoDTO.Status == "Delete")
            { RateInfoInfo.Id = rateInfoDTO.Id; }
            else
            { RateInfoInfo.Id = rateInfoDAO.SelectMaxId() + 1; }
            //RateInfoInfo.Id = rateInfoDTO.Id;
            RateInfoInfo.CurrencyCode = rateInfoDTO.CurrencyCode;
            RateInfoInfo.RateType = rateInfoDTO.RateType;
            RateInfoInfo.Rate = rateInfoDTO.Rate;
            RateInfoInfo.DenoRate = rateInfoDTO.DenoRate;
            RateInfoInfo.RegisterDate = rateInfoDTO.RegisterDate;
            //RateInfoInfo.LastModify = rateInfoDTO.LastModify;
            RateInfoInfo.ToCurrencyCode = rateInfoDTO.ToCurrencyCode;
            RateInfoInfo.TS = rateInfoDTO.TS;
            RateInfoInfo.CreatedUserId = rateInfoDTO.CreatedUserId;
            RateInfoInfo.CreatedDate = DateTime.Now;
            RateInfoInfo.UpdatedUserId = rateInfoDTO.UpdatedUserId;
            RateInfoInfo.UpdatedDate = DateTime.Now;
            if (isDelete)
            {
                RateInfoInfo.Active = false;
                RateInfoInfo.LastModify = false;
            }
            else
            {
                RateInfoInfo.Active = true;
                RateInfoInfo.LastModify = true;
            }
            return RateInfoInfo;
        }

        #endregion

        #region Main Methods

        public virtual IList<PFMDTO00075> GetAll()
        {
            return this.RateInfoDAO.SelectAll();
        }

        public PFMDTO00075 SelectById(int id)
        {
            return this.RateInfoDAO.SelectById(id);
        }

        public IList<CurrencyDTO> GetCurrency()
        {
            return this.RateInfoDAO.SelectCurrency();
        }
        public void SaveOrUpdateClientDataVersion(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId, int dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
            PFMORM00074 RateInfoORM = new PFMORM00074();

            //Require Data
            clientDataVersionDTO.ORMObjectName = RateInfoORM;
            clientDataVersionDTO.DataIdValue = dataValueId.ToString();
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
        public virtual PFMORM00074 Save(PFMDTO00075 entity)
        {
            PFMORM00074 rateInfo = null;
            if (this.rateInfoDAO.CheckExist(0, entity.CurrencyCode, entity.RateType, entity.ToCurrencyCode))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists                     
            }
            else
            {
                rateInfo = this.rateInfoDAO.Save(this.GetRateInfo(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), rateInfo.CreatedUserId, rateInfo.Id);
            }
            return rateInfo;
        }

        public void SaveServerAndServerClient(PFMDTO00075 entity)
        {
            PFMORM00074 rateInfo = null;         
            try
            {
               rateInfo =  this.Save(entity);
             
                if (!this.ServiceResult.ErrorOccurred)
                {
                    int lastmodify = 0;
                    if (rateInfo.LastModify)
                        lastmodify = 1;
                    Dictionary<string, object> rateInfoKeyPair = new Dictionary<string, object> {
                    { "Id", rateInfo.Id }, 
                    { "Cur", rateInfo.CurrencyCode }, 
                    { "RateType", rateInfo.RateType }, 
                    { "Rate", rateInfo.Rate }, 
                    { "DenoRate", rateInfo.DenoRate }, 
                    { "RDate", rateInfo.RegisterDate }, 
                    { "LastModify", lastmodify },
                    { "ToCur", rateInfo.ToCurrencyCode } 
                    };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("RateInfo", rateInfoKeyPair, rateInfo.TS, rateInfo.CreatedUserId, rateInfo.CreatedDate));
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
        public virtual PFMORM00074 UpdateServer(PFMDTO00075 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
                PFMORM00074 rateInfo = null;
               if (this.rateInfoDAO.CheckExist(entity.Id, entity.CurrencyCode, entity.RateType, entity.ToCurrencyCode))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV90001";//data already exists
                }
                else
                {
                    PFMORM00074 rate = this.GetRateInfo(entity,false);                
                    rateInfo = this.rateInfoDAO.Update(rate);
                    SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Id);                  
                }
               return rateInfo;
        }

        public virtual void Update(PFMDTO00075 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            try
            {
               PFMORM00074 rateinfo = this.UpdateServer(entity,dvcvList);               
                if(!this.ServiceResult.ErrorOccurred)
                {                 
                    Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> { 
                    { "Cur", rateinfo.CurrencyCode },
                    { "RateType", rateinfo.RateType }, 
                    { "Rate", rateinfo.Rate }, 
                    { "DenoRate", rateinfo.DenoRate },
                    { "RDate", rateinfo.RegisterDate }, 
                    { "ToCur", rateinfo.ToCurrencyCode },
                    { "UpdatedUserId", rateinfo.UpdatedUserId },
                    { "UpdatedDate", DateTime.Now },
                    {"TS",rateinfo.TS}
                    };
                    Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "Id", entity.Id }, { "Active", true } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00074", updateColumnsandValues, whereColumnsandValues));
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
        public virtual PFMORM00074 DeleteServer(PFMDTO00075 rateinfoDTO)
        {
            PFMORM00074 rateinfo = this.rateInfoDAO.Delete(GetRateInfo(rateinfoDTO, true), false);
            SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), rateinfoDTO.CreatedUserId, rateinfoDTO.Id);
            return rateinfo; 
        }

        public virtual void Delete(IList<PFMDTO00075> itemList)
        {
            try
            {
                foreach (PFMDTO00075 item in itemList)
                {
                  PFMORM00074 rateinfo =  DeleteServer(item);
                    string id =  rateinfo.Id.ToString();
                  CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("PFMORM00074", "Id",id, rateinfo.CreatedUserId,rateinfo.TS));
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