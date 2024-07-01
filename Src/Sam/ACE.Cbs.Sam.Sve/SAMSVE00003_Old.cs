//----------------------------------------------------------------------
// <copyright file="SAMSVE00003.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser></CreatedUser>
// <CreatedDate>07/24/2013</CreatedDate>
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

namespace Ace.Cbs.Sam.Sve
{
    /// <summary>
    /// OccupationCode Service
    /// </summary>
    public class SAMSVE00003 : BaseService, ISAMSVE00003
    {
        #region Properties

        private IPFMDAO00004 occupationCodeDAO;
        public IPFMDAO00004 OccupationCodeDAO
        {
            get { return this.occupationCodeDAO; }
            set { this.occupationCodeDAO = value; }
        }

        private PFMORM00004 OccupationCodeInfo;

        #endregion

        #region Helper Method
        private PFMORM00004 GetOccupationCode(PFMDTO00004 occupationCodeDTO, bool isDelete)
        {
            OccupationCodeInfo = new PFMORM00004();

            OccupationCodeInfo.Occupation_Code = occupationCodeDTO.Occupation_Code;
            OccupationCodeInfo.Description = occupationCodeDTO.Description;
            OccupationCodeInfo.Date_Time = DateTime.Now;
            OccupationCodeInfo.UserNo = occupationCodeDTO.CreatedUserId.ToString();
            OccupationCodeInfo.TS = occupationCodeDTO.TS;
            OccupationCodeInfo.CreatedUserId = occupationCodeDTO.CreatedUserId;
            OccupationCodeInfo.CreatedDate = DateTime.Now;
            OccupationCodeInfo.UpdatedUserId = occupationCodeDTO.UpdatedUserId;
            OccupationCodeInfo.UpdatedDate = DateTime.Now;
            OccupationCodeInfo.Date_Time = DateTime.Now;
            if (isDelete)
                OccupationCodeInfo.Active = false;
            else
                OccupationCodeInfo.Active = true;

            return OccupationCodeInfo;
        }
        #endregion

        #region Main Methods

        public virtual IList<PFMDTO00004> GetAll()
        {
            return this.OccupationCodeDAO.SelectAll();
        }

        public PFMDTO00004 SelectByOccupationCode(string occupationCode)
        {
            return this.OccupationCodeDAO.SelectByOccupationCode(occupationCode);
        }

        public IList<PFMDTO00004> CheckExist2(string occupationCode, string desp)
        {
            return this.OccupationCodeDAO.CheckExist2(occupationCode, desp);
        }
      
        public void SaveOrUpdateClientDataVersion(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId,string dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
            PFMORM00004 OccupationCodeORM = new PFMORM00004();

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

        [Transaction(TransactionPropagation.Required)]
        public virtual PFMORM00004 Save(PFMDTO00004 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            PFMORM00004 occupation = null;
            if (!entity.Active)  //Active = 0 , update nature
            {
                this.Update(entity, dvcvList, "Save");
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Occupation_Code);
                return null;
            }
            else //Active = 1 , insert nature  
            {
                occupation = this.OccupationCodeDAO.Save(this.GetOccupationCode(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), entity.CreatedUserId, entity.Occupation_Code);
            }
            return occupation;
        }
        
        public void SaveServerAndServerClient(PFMDTO00004 entity,IList<DataVersionChangedValueDTO> dvcvList)
        {          
            PFMORM00004 occupation = null;
            try
            {
                occupation = this.Save(entity,dvcvList);
                if (occupation != null)
                {
                    if (!this.ServiceResult.ErrorOccurred)
                    {
                        Dictionary<string, object> occupationKeyPair = new Dictionary<string, object> 
                    {
                        { "OccupationCode", occupation.Occupation_Code },
                        { "Desp", occupation.Description },
                        { "USERNO", occupation.UserNo }, 
                        { "DATE_TIME",occupation.Date_Time } 
                    };
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("OccupationCode", occupationKeyPair, occupation.TS, occupation.CreatedUserId, occupation.CreatedDate));

                        this.SaveClient(occupation);
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
        public void SaveClient(PFMORM00004 occupation)
        {
            try
            {
                Dictionary<string, object> occupationKeyPair = new Dictionary<string, object> 
                {
                    { "OccupationCode", occupation.Occupation_Code },
                    { "Desp", occupation.Description },
                    { "USERNO", occupation.UserNo }, 
                    { "DATE_TIME",occupation.Date_Time } 
                };
                ClientSQLiteDataHandler.Instance.InsertClient("OccupationCode", occupationKeyPair, occupation.TS, occupation.CreatedUserId, occupation.CreatedDate);
            }
            catch (Exception)
            {
            }
        }  
        [Transaction(TransactionPropagation.Required)]
        public virtual PFMORM00004 UpdateServer(PFMDTO00004 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            PFMORM00004 occupation = null;
            if ((this.OccupationCodeDAO.CheckExist(entity.Occupation_Code, entity.Description, true)))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists
            }
            else
            {               
              occupation =  this.OccupationCodeDAO.Update(GetOccupationCode(entity, false));              
            }       
            return occupation;
        }

        public virtual void Update(PFMDTO00004 entity, IList<DataVersionChangedValueDTO> dvcvList, string status)
        {
            try
            {  
                PFMORM00004 occupation = this.UpdateServer(entity,dvcvList);         
                if(!this.ServiceResult.ErrorOccurred)
                {
                    Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> { 
                    { "Occupation_Code", occupation.Occupation_Code },
                    { "Description", occupation.Description }, 
                    { "Active", occupation.Active},
                    { "UpdatedUserId", occupation.UpdatedUserId },
                    { "UpdatedDate", DateTime.Now },
                    { "TS", occupation.TS }
                    };
                    Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "Occupation_Code", occupation.Occupation_Code } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00004", updateColumnsandValues, whereColumnsandValues));
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
        public virtual PFMORM00004 DeleteServer(PFMDTO00004 occupationDTO)
        {
            PFMORM00004 occupationEntity = this.GetOccupationCode(occupationDTO,true);
            PFMORM00004 deletedEntity = this.OccupationCodeDAO.Delete(occupationEntity, false);
            SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), occupationDTO.CreatedUserId, occupationDTO.Occupation_Code);
            return deletedEntity;          
        }

        public virtual void Delete(IList<PFMDTO00004> itemList)
        {
            try
            {
                foreach (PFMDTO00004 item in itemList)
                {
                   PFMORM00004 deletedEntity =  this.DeleteServer(item);
                  CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("PFMORM00004", "Occupation_Code", deletedEntity.Occupation_Code, deletedEntity.CreatedUserId,deletedEntity.TS));
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

        #endregion
    }
}

