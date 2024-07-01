//----------------------------------------------------------------------
// <copyright file="SAMSVE00007.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>07/26/2013</CreatedDate>
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
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Core.Ctr;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Sam.Sve
{
    /// <summary>
    /// HOLIDAY Service
    /// </summary>
    public class SAMSVE00007 : BaseService, ISAMSVE00007
    {
        #region Properties

        private ISAMDAO00003 hOLIDAYDAO;
        public ISAMDAO00003 HOLIDAYDAO
        {
            get { return this.hOLIDAYDAO; }
            set { this.hOLIDAYDAO = value; }
        }

        private SAMORM00003 HOLIDAYInfo;

        #endregion

        #region Helper Method
        private SAMORM00003 GetHOLIDAY(SAMDTO00003 hOLIDAYDTO, bool isDelete)
        {
            HOLIDAYInfo = new SAMORM00003();

            HOLIDAYInfo.Id = hOLIDAYDTO.Id;
            HOLIDAYInfo.DATE = hOLIDAYDTO.DATE.Date;
            HOLIDAYInfo.DESCRIPTION = hOLIDAYDTO.DESCRIPTION;
            HOLIDAYInfo.USERNO = hOLIDAYDTO.CreatedUserId.ToString();
            HOLIDAYInfo.UID = hOLIDAYDTO.UID;
            HOLIDAYInfo.TS = hOLIDAYDTO.TS;
            HOLIDAYInfo.CreatedUserId = hOLIDAYDTO.CreatedUserId;
            HOLIDAYInfo.CreatedDate = DateTime.Now;
            HOLIDAYInfo.UpdatedUserId = hOLIDAYDTO.UpdatedUserId;
            HOLIDAYInfo.UpdatedDate = DateTime.Now;
            if (isDelete)
                HOLIDAYInfo.Active = false;
            else
                HOLIDAYInfo.Active = true;
            return HOLIDAYInfo;
        }

        #endregion

        #region Main Methods

        public virtual IList<SAMDTO00003> GetAll()
        {
            return this.HOLIDAYDAO.SelectAll();
        }

        public SAMDTO00003 SelectById(int id)
        {
            return this.HOLIDAYDAO.SelectById(id);
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual SAMORM00003 Save(SAMDTO00003 entity)
        {
            SAMORM00003 holiday = null;
             
            
             if ((this.HOLIDAYDAO.CheckExist(0, entity.DATE, entity.DESCRIPTION)) &&
                 (entity.DATE <= DateTime.Now || entity.DATE > DateTime.Now))
            {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV90001";//data already exists                     
             }
            else if (entity.DATE <= DateTime.Now)
            {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV90234";// holiday should greater than sysdate
            }

            else
            {
                    holiday = this.hOLIDAYDAO.Save(this.GetHOLIDAY(entity, false));
                    this.SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), holiday.CreatedUserId, holiday.Id.ToString());
            }

            
            return holiday;
        }

        public void SaveServerAndServerClient(SAMDTO00003 entity)
        {
            try
            {
                SAMORM00003 holiday = this.Save(entity);
                if (!this.ServiceResult.ErrorOccurred)
                {
                    Dictionary<string, object> accounttypeKeyPair = new Dictionary<string, object> { 
                    { "Id", holiday.Id }, 
                    { "Date", holiday.DATE },
                    { "Description", holiday.DESCRIPTION }, 
                    { "USERNO", holiday.USERNO } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("Holiday", accounttypeKeyPair, holiday.TS, holiday.CreatedUserId, holiday.CreatedDate));
                    SaveClient(entity, holiday);
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
        public void SaveClient(SAMDTO00003 entity, SAMORM00003 holiday)
        {

            int myId = 0;
            try
            {
                Dictionary<string, object> accounttypeKeyPair = new Dictionary<string, object> { 
                { "Id", myId }, 
                { "Date", entity.DATE },
                { "Description", entity.DESCRIPTION }, 
                { "USERNO", entity.USERNO } };
                ClientSQLiteDataHandler.Instance.InsertClient("Holiday", accounttypeKeyPair, holiday.TS, entity.CreatedUserId, entity.CreatedDate);
            }
            catch (Exception)
            {
            }
        }
        [Transaction(TransactionPropagation.Required)]
        public virtual SAMORM00003 UpdateServer(SAMDTO00003 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            SAMORM00003 holiday = null;
            if (this.HOLIDAYDAO.CheckExist(entity.Id, entity.DATE, entity.DESCRIPTION))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists
            }
            else
            {
                holiday = this.HOLIDAYDAO.Update(this.GetHOLIDAY(entity, false));
                this.SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Id.ToString());
            }
            return holiday;
        }

        public virtual void Update(SAMDTO00003 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            try
            {
                SAMORM00003 holiday = this.UpdateServer(entity, dvcvList);
                if (!this.ServiceResult.ErrorOccurred)
                {
                    Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> { { "DATE", holiday.DATE }, 
                { "DESCRIPTION", holiday.DESCRIPTION },
                { "UpdatedUserId", holiday.UpdatedUserId }, 
                { "UpdatedDate", DateTime.Now },
                {"TS",holiday.TS}
                };
                    Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "Id", holiday.Id }, { "Active", true } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("SAMORM00003", updateColumnsandValues, whereColumnsandValues));
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
        public virtual SAMORM00003 DeleteServer(SAMDTO00003 holidayDTO)
        {
            SAMORM00003 holiday = this.GetHOLIDAY(holidayDTO, true);
            SAMORM00003 deletedEntity = this.HOLIDAYDAO.Delete(holiday, false);
            this.SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), holidayDTO.CreatedUserId, holidayDTO.Id.ToString());
            return deletedEntity;
        }
        public virtual void Delete(IList<SAMDTO00003> itemList)
        {
            try
            {
                foreach (SAMDTO00003 item in itemList)
                {
                    SAMORM00003 holiday = this.DeleteServer(item);
                    string deleteId = holiday.Id.ToString();
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("SAMORM00003", "Id", deleteId, holiday.CreatedUserId, holiday.TS));
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
            SAMORM00003 HolidayORM = new SAMORM00003();

            //Require Data
            clientDataVersionDTO.ORMObjectName = HolidayORM;
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