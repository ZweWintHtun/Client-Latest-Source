//----------------------------------------------------------------------
// <copyright file="SAMSVE00056.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser></CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser>Ma Tin Shwe</UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Core.Ctr;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Sam.Sve
{
    /// <summary>
    /// NRC Code Service
    /// </summary>
    public class SAMSVE00056 : BaseService, ISAMSVE00056
    {
        #region Properties

        private ISAMDAO00054 nRCCodeDAO;
        public ISAMDAO00054 NRCCodeDAO
        {
            get { return this.nRCCodeDAO; }
            set { this.nRCCodeDAO = value; }
        }

        private SAMORM00054 NRCCodeInfo;

        #endregion

        #region Helper Method

        private SAMORM00054 GetNationalityCode(SAMDTO00054 NRCCodeDTO, bool isDelete)
        {
            NRCCodeInfo = new SAMORM00054();

            NRCCodeInfo.Id = NRCCodeDTO.Id;
            NRCCodeInfo.TownshipCode = NRCCodeDTO.TownshipCode;
            NRCCodeInfo.TownshipDesp = NRCCodeDTO.TownshipDesp;
            NRCCodeInfo.StateCode = NRCCodeDTO.StateCode;
            NRCCodeInfo.TS = NRCCodeDTO.TS;
            NRCCodeInfo.CreatedUserId = NRCCodeDTO.CreatedUserId;
            NRCCodeInfo.CreatedDate = NRCCodeDTO.CreatedDate;
            NRCCodeInfo.UpdatedUserId = NRCCodeDTO.UpdatedUserId;
            NRCCodeInfo.UpdatedDate = NRCCodeDTO.UpdatedDate;

            if (isDelete)
                NRCCodeInfo.Active = false;
            else
                NRCCodeInfo.Active = true;
            return NRCCodeInfo;
        }


        #endregion

        #region Main Methods

        public virtual IList<SAMDTO00054> GetAll()
        {
            return this.NRCCodeDAO.SelectAll();
        }

        public IList<SAMDTO00054> SelectByStateCode(string StateCode)
        {
            return this.NRCCodeDAO.SelectByStateCode(StateCode);
        }

        public IList<SAMDTO00054> CheckExist2(string StateCode, string TownshipCode)
        {
            return this.NRCCodeDAO.CheckExist2(StateCode, TownshipCode);
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual SAMORM00054 Save(SAMDTO00054 entity)
        {
            SAMORM00054 NRCORM = null;
            try
            {
                if (this.NRCCodeDAO.CheckExist(0, entity.StateCode, entity.TownshipCode, entity.TownshipDesp, false))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV90001";//data already exists
                }
                else //Active = 1 , insert nature
                {
                    NRCORM = this.NRCCodeDAO.Save(this.GetNationalityCode(entity, false));
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = "MI90001";// Saving Successful
                    this.SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), entity.CreatedUserId, entity.TownshipCode);
                }
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";
            }
            return NRCORM;
        }

        public void SaveServerAndServerClient(SAMDTO00054 entity)
        {
            try
            {
                SAMORM00054 NRCORM = this.Save(entity);
                if (NRCORM != null)
                {
                    if (!this.ServiceResult.ErrorOccurred)
                    {
                        Dictionary<string, object> NRCCodeKeyPair = new Dictionary<string, object> 
                        { 
                            { "Id", NRCORM.Id },
                            { "TownshipCode", NRCORM.TownshipCode },                             
                            { "TownshipDesp", NRCORM.TownshipDesp }, 
                            { "StateCode", NRCORM.StateCode }
                        };
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("NRCCodeSetUp", NRCCodeKeyPair, NRCORM.TS, NRCORM.CreatedUserId, NRCORM.CreatedDate));
                        SaveClient(NRCORM);
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
        public void SaveClient(SAMORM00054 entity)
        {
            try
            {
                Dictionary<string, object> NRCCodeKeyPair = new Dictionary<string, object> 
                { 
                    { "Id", entity.Id},
                    { "TownshipCode", entity.TownshipCode },                             
                    { "TownshipDesp", entity.TownshipDesp }, 
                    { "StateCode", entity.StateCode }
                };
                ClientSQLiteDataHandler.Instance.InsertClient("NRCCodeSetUp", NRCCodeKeyPair, entity.TS, entity.CreatedUserId, entity.CreatedDate);
            }
            catch (Exception)
            {
            }
        }
        [Transaction(TransactionPropagation.Required)]
        public virtual SAMORM00054 UpdateServer(SAMDTO00054 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            SAMORM00054 NRCORM = null;
            if (this.NRCCodeDAO.CheckExist(entity.Id, entity.StateCode, entity.TownshipCode, entity.TownshipDesp, true))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists
            }
            else
            {
                NRCORM = this.NRCCodeDAO.Update(GetNationalityCode(entity, false));
                this.SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.TownshipCode);
            }
            return NRCORM;
        }

        public virtual void Update(SAMDTO00054 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            try
            {
                SAMORM00054 NRCORM = UpdateServer(entity, dvcvList);
                if (!this.ServiceResult.ErrorOccurred)
                {
                    Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> { 
                    { "TownshipCode", NRCORM.TownshipCode },                    
                    { "TownshipDesp", NRCORM.TownshipDesp },
                    { "StateCode", NRCORM.StateCode },
                    { "Active", NRCORM.Active},
                    { "UpdatedUserId", NRCORM.UpdatedUserId }, 
                    { "UpdatedDate", NRCORM.UpdatedDate },
                    {"TS",NRCORM.TS}
                    };
                    Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "Id", NRCORM.Id }, { "Active", true } }; 
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("SAMORM00054", updateColumnsandValues, whereColumnsandValues));
                    this.ServiceResult.ErrorOccurred = false;
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
        public virtual SAMORM00054 DeleteServer(SAMDTO00054 NRCCodeDTO)
        {
            SAMORM00054 NRCORM = this.NRCCodeDAO.Delete(GetNationalityCode(NRCCodeDTO, true), false);
            this.SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), NRCCodeDTO.CreatedUserId, NRCCodeDTO.TownshipCode);
            return NRCORM;
        }

        public virtual void Delete(IList<SAMDTO00054> itemList)
        {
            try
            {
                foreach (SAMDTO00054 item in itemList)
                {
                    SAMORM00054 NRCORM = DeleteServer(item);
                    string DeleteId = NRCORM.Id.ToString();
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("SAMORM00054", "Id", DeleteId, NRCORM.CreatedUserId, NRCORM.TS));
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
            SAMORM00053 OccupationCodeORM = new SAMORM00053();

            //Require Data
            clientDataVersionDTO.ORMObjectName = OccupationCodeORM;
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
