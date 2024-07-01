//----------------------------------------------------------------------
// <copyright file="SAMSVE00023.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>08/05/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
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

namespace Ace.Cbs.Sam.Sve
{
    /// <summary>
    /// RateFile Service
    /// </summary>
    public class SAMSVE00023 : BaseService, ISAMSVE00023
    {
        #region Properties

        private IPFMDAO00009 rateFileDAO;
        public IPFMDAO00009 RateFileDAO
        {
            get { return this.rateFileDAO; }
            set { this.rateFileDAO = value; }
        }

        private PFMORM00009 RateFileInfo;

        #endregion

        #region Helper Method

        private PFMORM00009 GetRateFile(PFMDTO00009 rateFileDTO, bool isDelete)
        {
            RateFileInfo = new PFMORM00009();

            RateFileInfo.Code = rateFileDTO.Code;
            RateFileInfo.Description = rateFileDTO.Description;
            RateFileInfo.DATE_TIME = rateFileDTO.DATE_TIME;
            RateFileInfo.LASTMODIFY = rateFileDTO.LASTMODIFY;
            RateFileInfo.USERNO = rateFileDTO.USERNO;
            RateFileInfo.Rate = rateFileDTO.Rate;
            RateFileInfo.Duration = rateFileDTO.Duration;
            RateFileInfo.TS = rateFileDTO.TS;
            RateFileInfo.CreatedUserId = rateFileDTO.CreatedUserId;
            RateFileInfo.CreatedDate = DateTime.Now;
            RateFileInfo.UpdatedUserId = rateFileDTO.UpdatedUserId;
            RateFileInfo.UpdatedDate = DateTime.Now;
            if (isDelete)
                RateFileInfo.Active = false;
            else
                RateFileInfo.Active = true;
            return RateFileInfo;
        }

        #endregion

        #region Logical Methods

        public virtual IList<PFMDTO00009> GetAll()
        {
            return this.RateFileDAO.SelectAll();
        }

        public PFMDTO00009 SelectByCode(string code)
        {
            return this.RateFileDAO.SelectByCode(code);
        }

        public PFMDTO00009 SelectByRateCode(string code)
        {
            return this.RateFileDAO.SelectByRateCode(code);
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual PFMORM00009 Save(PFMDTO00009 entity, IList<DataVersionChangedValueDTO> dvcvList)  //2
        {
            PFMORM00009 rateFile = null;
            if (this.rateFileDAO.CheckExist(entity.Code, entity.Description, entity.DATE_TIME, entity.LASTMODIFY, entity.Rate, false))
            {
                PFMDTO00009 updateEntity = this.SelectByRateCode(entity.Code);
                updateEntity.LASTMODIFY = false;
                updateEntity.UpdatedDate = System.DateTime.Now;
                updateEntity.UpdatedUserId = CurrentUserEntity.CurrentUserID;

                PFMORM00009 ratefileEntity = GetRateFile(updateEntity, false);
                //ratefileEntity = GetRateFile(updateEntity, false);
                //rateFile = GetRateFile(updateEntity, false);
                this.RateFileDAO.UpdateRate(updateEntity);
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, updateEntity.CreatedUserId, updateEntity.Code);
                Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> { { "Code", ratefileEntity.Code }, { "Description", ratefileEntity.Description }, { "DATE_TIME", ratefileEntity.DATE_TIME }, { "LASTMODIFY", ratefileEntity.LASTMODIFY }, { "Rate", ratefileEntity.Rate }, { "Duration", ratefileEntity.Duration }, { "UpdatedUserId", ratefileEntity.UpdatedUserId }, { "UpdatedDate", DateTime.Now } };
                Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "Code", ratefileEntity.Code }, { "Active", true }, { "TS", ratefileEntity.TS } };
                CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00009", updateColumnsandValues, whereColumnsandValues));
                //this.ServiceResult.ErrorOccurred = false;
                //this.ServiceResult.MessageCode = "MI90002";//Update Success


                //this.ServiceResult.ErrorOccurred = true;
                //this.ServiceResult.MessageCode = "MV90001";//data already exists                     
            }

            //else
            //{
            entity.LASTMODIFY = true;
            rateFile = this.rateFileDAO.Save(this.GetRateFile(entity, false));
            this.SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), rateFile.CreatedUserId, rateFile.Code);
            //}
            return rateFile;
        }

        public void SaveServerAndServerClient(PFMDTO00009 entity, IList<DataVersionChangedValueDTO> dvcvList)  //1
        {
            PFMORM00009 rateFile = null;
            PFMDTO00009 rateFileEntity = null;
            try
            {
                rateFile = this.Save(entity, dvcvList);  //2                 

                rateFileEntity = this.RateFileDAO.SelectByRateCode(rateFile.Code);
                if (rateFileEntity != null)
                {
                    int lastModify = 0;
                    if (rateFileEntity.LASTMODIFY)
                    { lastModify = 1; }
                    //Dictionary<string, object> occupationKeyPair = new Dictionary<string, object> { { "OccupationCode", occupationEntity.Occupation_Code }, { "Desp", occupationEntity.Description }, { "USERNO", occupationEntity.UserNo }, { "DATE_TIME", occupationEntity.Date_Time }, { "EDITDATE_TIME", occupationEntity.EditDate_Time }, { "EDITUSER", occupationEntity.EditUser }, { "EDITTYPE", occupationEntity.EditType }, { "DEFAULTS", occupationEntity.Defaults }, { "Active", occupationEntity.Active }, { "TS", occupationEntity.TS }, { "CreatedDate", occupationEntity.CreatedDate }, { "CreatedUserId", occupationEntity.CreatedUserId }, { "UpdatedDate", occupationEntity.UpdatedDate }, { "UpdatedUserId", occupationEntity.UpdatedUserId } };
                    Dictionary<string, object> occupationKeyPair = new Dictionary<string, object> { { "Code", rateFileEntity.Code }, { "Desp", rateFileEntity.Description }, { "DATE_TIME", rateFileEntity.DATE_TIME }, { "LASTMODIFY", lastModify }, { "USERNO", rateFileEntity.USERNO }, { "Rate", rateFileEntity.Rate }, { "Duration", rateFileEntity.Duration } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("RateFile", occupationKeyPair, rateFileEntity.TS, rateFile.CreatedUserId, rateFile.CreatedDate));
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = "MI90001";// Saving Successful 
                }
            }
            catch
            {
                // this.RateFileDAO.Delete(rateFileEntity, true);
                this.ServiceResult.ErrorOccurred = true;
                if (!string.IsNullOrEmpty(this.ServiceResult.MessageCode))
                    this.ServiceResult.MessageCode = this.ServiceResult.MessageCode;
                else
                    this.ServiceResult.MessageCode = "ME90036";//Saving Failure.
            }

        }

        [Transaction(TransactionPropagation.Required)]
        public virtual PFMORM00009 UpdateServer(PFMDTO00009 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            PFMORM00009 ratefile = null;
            if (this.rateFileDAO.CheckExist(entity.Code, entity.Description, entity.DATE_TIME, entity.LASTMODIFY, entity.Rate, true))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists
            }
            else
            {         
                ratefile = this.RateFileDAO.Update(GetRateFile(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Code);                      
            }
            return ratefile;
        }

        public virtual void Update(PFMDTO00009 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            try
            {
                PFMORM00009 ratefile = this.UpdateServer(entity,dvcvList);
                if (!this.ServiceResult.ErrorOccurred)
                {
                    Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> {
                    { "Code", ratefile.Code }, 
                    { "Description", ratefile.Description }, 
                    { "DATE_TIME", ratefile.DATE_TIME }, 
                    { "LASTMODIFY", ratefile.LASTMODIFY },
                    { "Rate", ratefile.Rate }, 
                    { "Duration", ratefile.Duration }, 
                    { "UpdatedUserId", ratefile.UpdatedUserId },
                    { "UpdatedDate", DateTime.Now },
                    {"TS",ratefile.TS}
                    };
                    Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "Code", ratefile.Code }, { "Active", true }, { "TS", entity.TS } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00009", updateColumnsandValues, whereColumnsandValues));
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = "MI90002";//Update Success       
                }
         
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";

            }
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual PFMORM00009 DeleteServer(PFMDTO00009 rateFileDTO)
        {
            PFMORM00009 ratefile = this.rateFileDAO.Delete(this.GetRateFile(rateFileDTO, true), false);
            this.SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), rateFileDTO.CreatedUserId, rateFileDTO.Code);
            return ratefile;            
        }

        //[Transaction(TransactionPropagation.Required)]
        public virtual void Delete(IList<PFMDTO00009> itemList)
        {
            try
            {
                foreach (PFMDTO00009 item in itemList)
                {
                 //PFMORM00009 ratefile = this.DeleteServer(item);
                 item.UpdatedDate = System.DateTime.Now;
                 this.rateFileDAO.DeleteRate(item);
                 this.SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), item.CreatedUserId, item.Code);
                 //item.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                 item.Active = false;
                 Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> {
                    { "Code", item.Code }, 
                    { "Description", item.Description }, 
                    { "DATE_TIME", item.DATE_TIME }, 
                    { "LASTMODIFY", item.LASTMODIFY },
                    { "Rate", item.Rate }, 
                    { "Duration", item.Duration },
                    { "Active", item.Active },
                    { "UpdatedUserId", item.UpdatedUserId },
                    { "UpdatedDate", DateTime.Now },
                    {"TS",item.TS}
                    };
                 Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "Code", item.Code }, { "TS", item.TS } };
                 CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00009", updateColumnsandValues, whereColumnsandValues));
                 //CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("PFMORM00009", "Code", ratefile.Code, ratefile.CreatedUserId, ratefile.TS));
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


        #region Data Version Update Service
        public void SaveOrUpdateClientDataVersion(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId, string dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
            PFMORM00009 RateFileORM = new PFMORM00009();

            //Require Data
            clientDataVersionDTO.ORMObjectName = RateFileORM;
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