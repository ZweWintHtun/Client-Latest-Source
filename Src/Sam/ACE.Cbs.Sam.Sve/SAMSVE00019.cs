//----------------------------------------------------------------------
// <copyright file="SAMSVE00019.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser></CreatedUser>
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
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Windows.Core.DataModel;
using Ace.Windows.Ix.Core.Ctr;
using Ace.Windows.Ix.Core.DataModel;
namespace Ace.Cbs.Sam.Sve
{
    /// <summary>
    /// KeySetting Service
    /// </summary>
    public class SAMSVE00019 : BaseService, ISAMSVE00019
    {
        #region Properties

        private ITLMDAO00034 dayKeyDAO;
        public ITLMDAO00034 DayKeyDAO
        {
            get { return this.dayKeyDAO; }
            set { this.dayKeyDAO = value; }
        }

        private ITLMDAO00035 monthKeyDAO;
        public ITLMDAO00035 MonthKeyDAO
        {
            get { return this.monthKeyDAO; }
            set { this.monthKeyDAO = value; }
        }

        private ITLMDAO00036 amountKeyDAO;
        public ITLMDAO00036 AmountKeyDAO
        {
            get { return this.amountKeyDAO; }
            set { this.amountKeyDAO = value; }
        }

        private ITLMDAO00037 branchKeyDAO;
        public ITLMDAO00037 BranchKeyDAO
        {
            get { return this.branchKeyDAO; }
            set { this.branchKeyDAO = value; }
        }

        private TLMORM00034 DayKeyInfo;
        private TLMORM00035 MonthKeyInfo;
        private TLMORM00036 AmountKeyInfo;
        private TLMORM00037 BranchKeyInfo;

        #endregion

        #region Helper Method

        private TLMORM00034 GetDayKey(TLMDTO00034 dayKeyDTO, bool isDelete)
        {
            DayKeyInfo = new TLMORM00034();

            DayKeyInfo.Id = dayKeyDTO.Id;
            DayKeyInfo.Code = dayKeyDTO.Code;
            DayKeyInfo.Value = dayKeyDTO.Value;
            DayKeyInfo.StartDate = dayKeyDTO.StartDate;
            DayKeyInfo.UniqueId = dayKeyDTO.UniqueId;
            DayKeyInfo.TS = dayKeyDTO.TS;
            DayKeyInfo.CreatedUserId = dayKeyDTO.CreatedUserId;
            DayKeyInfo.CreatedDate = DateTime.Now;
            DayKeyInfo.UpdatedUserId = dayKeyDTO.UpdatedUserId;
            DayKeyInfo.UpdatedDate = DateTime.Now;
            if (isDelete)
                DayKeyInfo.Active = false;
            else
                DayKeyInfo.Active = true;
            return DayKeyInfo;
        }

        private TLMORM00035 GetMonthKey(TLMDTO00035 monthKeyDTO, bool isDelete)
        {
            MonthKeyInfo = new TLMORM00035();

            MonthKeyInfo.Id = monthKeyDTO.Id;
            MonthKeyInfo.Code = monthKeyDTO.Code;
            MonthKeyInfo.Value = monthKeyDTO.Value;
            MonthKeyInfo.StartDate = monthKeyDTO.StartDate;
            MonthKeyInfo.UniqueId = monthKeyDTO.UniqueId;
            MonthKeyInfo.TS = monthKeyDTO.TS;
            MonthKeyInfo.CreatedUserId = monthKeyDTO.CreatedUserId;
            MonthKeyInfo.CreatedDate = DateTime.Now;
            MonthKeyInfo.UpdatedUserId = monthKeyDTO.UpdatedUserId;
            MonthKeyInfo.UpdatedDate = DateTime.Now;

            if (isDelete)
                MonthKeyInfo.Active = false;
            else
                MonthKeyInfo.Active = true;

            return MonthKeyInfo;
        }

        private TLMORM00036 GetAmountKey(TLMDTO00036 amountKeyDTO, bool isDelete)
        {
            AmountKeyInfo = new TLMORM00036();

            AmountKeyInfo.Id = amountKeyDTO.Id;
            AmountKeyInfo.Code = amountKeyDTO.Code;
            AmountKeyInfo.Value = amountKeyDTO.Value;
            AmountKeyInfo.StartDate = amountKeyDTO.StartDate;
            AmountKeyInfo.UniqueId = amountKeyDTO.UniqueId;
            AmountKeyInfo.TS = amountKeyDTO.TS;
            AmountKeyInfo.CreatedUserId = amountKeyDTO.CreatedUserId;
            AmountKeyInfo.CreatedDate = DateTime.Now;
            AmountKeyInfo.UpdatedUserId = amountKeyDTO.UpdatedUserId;
            AmountKeyInfo.UpdatedDate = DateTime.Now;
            if (isDelete)
                AmountKeyInfo.Active = false;
            else
                AmountKeyInfo.Active = true;

            return AmountKeyInfo;
        }

        private TLMORM00037 GetBranchKey(TLMDTO00037 branchKeyDTO, bool isDelete)
        {
            BranchKeyInfo = new TLMORM00037();

            BranchKeyInfo.Id = branchKeyDTO.Id;
            BranchKeyInfo.Code = branchKeyDTO.Code;
            BranchKeyInfo.Value = branchKeyDTO.Value;
            BranchKeyInfo.StartDate = branchKeyDTO.StartDate;
            BranchKeyInfo.UniqueId = branchKeyDTO.UniqueId;
            BranchKeyInfo.TS = branchKeyDTO.TS;
            BranchKeyInfo.CreatedUserId = branchKeyDTO.CreatedUserId;
            BranchKeyInfo.CreatedDate = DateTime.Now;
            BranchKeyInfo.UpdatedUserId = branchKeyDTO.UpdatedUserId;
            BranchKeyInfo.UpdatedDate = DateTime.Now;
            if (isDelete)
                BranchKeyInfo.Active = false;
            else
                BranchKeyInfo.Active = true;

            return BranchKeyInfo;
        }

        private TLMDTO00034 PutMonthKeyDTO(TLMDTO00035 monthKeyDTO)
        {
            TLMDTO00034 key = new TLMDTO00034();
            key.Id = monthKeyDTO.Id;
            key.Code = monthKeyDTO.Code;
            key.Value = monthKeyDTO.Value;
            key.StartDate = monthKeyDTO.StartDate;
            key.UniqueId = monthKeyDTO.UniqueId;
            key.Active = monthKeyDTO.Active;
            key.TS = monthKeyDTO.TS;
            key.CreatedDate = monthKeyDTO.CreatedDate;
            key.CreatedUserId = monthKeyDTO.CreatedUserId;
            key.UpdatedDate = monthKeyDTO.UpdatedDate;
            key.UpdatedUserId = monthKeyDTO.UpdatedUserId;
            return key;
        }

        private TLMDTO00034 PutAmountKeyDTO(TLMDTO00036 amountKeyDTO)
        {
            TLMDTO00034 key = new TLMDTO00034();
            key.Id = amountKeyDTO.Id;
            key.Code = amountKeyDTO.Code;
            key.Value = amountKeyDTO.Value;
            key.StartDate = amountKeyDTO.StartDate;
            key.UniqueId = amountKeyDTO.UniqueId;
            key.Active = amountKeyDTO.Active;
            key.TS = amountKeyDTO.TS;
            key.CreatedDate = amountKeyDTO.CreatedDate;
            key.CreatedUserId = amountKeyDTO.CreatedUserId;
            key.UpdatedDate = amountKeyDTO.UpdatedDate;
            key.UpdatedUserId = amountKeyDTO.UpdatedUserId;

            return key;
        }

        private TLMDTO00034 PutBranchKeyDTO(TLMDTO00037 branchKeyDTO)
        {
            TLMDTO00034 key = new TLMDTO00034();
            key.Id = branchKeyDTO.Id;
            key.Code = branchKeyDTO.Code;
            key.Value = branchKeyDTO.Value;
            key.StartDate = branchKeyDTO.StartDate;
            key.UniqueId = branchKeyDTO.UniqueId;
            key.Active = branchKeyDTO.Active;
            key.TS = branchKeyDTO.TS;
            key.CreatedDate = branchKeyDTO.CreatedDate;
            key.CreatedUserId = branchKeyDTO.CreatedUserId;
            key.UpdatedDate = branchKeyDTO.UpdatedDate;
            key.UpdatedUserId = branchKeyDTO.UpdatedUserId;

            return key;
        }

        private TLMDTO00035 GetMonthKeyDTO(TLMDTO00034 key)
        {
            TLMDTO00035 monthKeyDTO = new TLMDTO00035();
            monthKeyDTO.Id = key.Id;
            monthKeyDTO.Code = key.Code;
            monthKeyDTO.Value = key.Value.Value;
            monthKeyDTO.StartDate = key.StartDate;
            monthKeyDTO.UniqueId = key.UniqueId;
            monthKeyDTO.Active = key.Active;
            monthKeyDTO.TS = key.TS;
            monthKeyDTO.CreatedDate = key.CreatedDate;
            monthKeyDTO.CreatedUserId = key.CreatedUserId;
            monthKeyDTO.UpdatedDate = key.UpdatedDate;
            monthKeyDTO.UpdatedUserId = key.UpdatedUserId;

            return monthKeyDTO;

        }

        private TLMDTO00036 GetAmountKeyDTO(TLMDTO00034 key)
        {
            TLMDTO00036 amountKeyDTO = new TLMDTO00036();
            amountKeyDTO.Id = key.Id;
            amountKeyDTO.Code = key.Code;
            amountKeyDTO.Value = key.Value.Value;
            amountKeyDTO.StartDate = key.StartDate;
            amountKeyDTO.UniqueId = key.UniqueId;
            amountKeyDTO.Active = key.Active;
            amountKeyDTO.TS = key.TS;
            amountKeyDTO.CreatedDate = key.CreatedDate;
            amountKeyDTO.CreatedUserId = key.CreatedUserId;
            amountKeyDTO.UpdatedDate = key.UpdatedDate;
            amountKeyDTO.UpdatedUserId = key.UpdatedUserId;

            return amountKeyDTO;
        }

        private TLMDTO00037 GetBranchKeyDTO(TLMDTO00034 key)
        {
            TLMDTO00037 branchKeyDTO = new TLMDTO00037();
            branchKeyDTO.Id = key.Id;
            branchKeyDTO.Code = key.Code;
            branchKeyDTO.Value = key.Value.Value;
            branchKeyDTO.StartDate = key.StartDate;
            branchKeyDTO.UniqueId = key.UniqueId;
            branchKeyDTO.Active = key.Active;
            branchKeyDTO.TS = key.TS;
            branchKeyDTO.CreatedDate = key.CreatedDate;
            branchKeyDTO.CreatedUserId = key.CreatedUserId;
            branchKeyDTO.UpdatedDate = key.UpdatedDate;
            branchKeyDTO.UpdatedUserId = key.UpdatedUserId;

            return branchKeyDTO;
        }

        #endregion

        #region Main Methods

        public virtual IList<TLMDTO00034> GetAll(string keyType)
        {
            if (keyType == "Day Key")
            {
                return this.DayKeyDAO.SelectAll();
            }

            else if (keyType == "Month Key")
            {
                IList<TLMDTO00035> monthKeys = this.MonthKeyDAO.SelectAll();
                IList<TLMDTO00034> keys = new List<TLMDTO00034>();
                foreach (TLMDTO00035 monthKey in monthKeys)
                {
                    keys.Add(this.PutMonthKeyDTO(monthKey));
                }
                return keys;
            }

            else if (keyType == "Amount Key")
            {
                IList<TLMDTO00036> amountKeys = this.AmountKeyDAO.SelectAll();
                IList<TLMDTO00034> keys = new List<TLMDTO00034>();
                foreach (TLMDTO00036 amountKey in amountKeys)
                {
                    keys.Add(this.PutAmountKeyDTO(amountKey));
                }
                return keys;
            }

            else// Branch Key
            {
                IList<TLMDTO00037> branchKeys = this.BranchKeyDAO.SelectAll();
                IList<TLMDTO00034> keys = new List<TLMDTO00034>();
                foreach (TLMDTO00037 branchKey in branchKeys)
                {
                    keys.Add(this.PutBranchKeyDTO(branchKey));
                }
                return keys;
            }
        }

        public TLMDTO00034 SelectById(int id)
        {
            return this.DayKeyDAO.SelectById(id);
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual TLMORM00034 SaveDaykey(TLMDTO00034 entity, string keyType)
        {
            TLMORM00034 dayKey = null;
            if (keyType == "Day Key")
            {                
                if (this.dayKeyDAO.CheckExist(0, entity.Value.Value, entity.Code))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV90001";//data already exists                     
                }
                else
                {
                    dayKey = this.dayKeyDAO.Save(this.GetDayKey(entity, false));                      
                    SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), dayKey.CreatedUserId, keyType, dayKey.Id.ToString());
                }                
            }
            return dayKey;
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual TLMORM00035 SaveMonthkey(TLMDTO00034 entity, string keyType)
        {
            TLMORM00035 monthKey = null;          
               
            TLMDTO00035 monthKeyEntity = this.GetMonthKeyDTO(entity);
            if (this.monthKeyDAO.CheckExist(0, monthKeyEntity.Value, monthKeyEntity.Code))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists                     
            }
            else
            {
                monthKey = this.monthKeyDAO.Save(this.GetMonthKey(monthKeyEntity, false));                      
                SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), monthKey.CreatedUserId, keyType, monthKey.Id.ToString());
            }                
            return monthKey;
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual TLMORM00036 SaveAmountkey(TLMDTO00034 entity, string keyType)
        {
            TLMORM00036 amountKey = null;         
                TLMDTO00036 amountKeyEntity = this.GetAmountKeyDTO(entity);
            if (this.amountKeyDAO.CheckExist(0, amountKeyEntity.Value, amountKeyEntity.Code))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists                     
            }
            else
            {
                amountKey = this.amountKeyDAO.Save(this.GetAmountKey(amountKeyEntity, false));                      
                SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), amountKey.CreatedUserId, keyType, amountKey.Id.ToString());
            }                
            return amountKey;
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual TLMORM00037 SaveBranchkey(TLMDTO00034 entity, string keyType)
        {
            TLMORM00037 branchKey = null;           
            TLMDTO00037 branchKeyEntity = this.GetBranchKeyDTO(entity);
            if (this.branchKeyDAO.CheckExist(0, branchKeyEntity.Value, branchKeyEntity.Code))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists                     
            }
            else
            {
                branchKey = this.branchKeyDAO.Save(this.GetBranchKey(branchKeyEntity, false));                     
                SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), branchKey.CreatedUserId, keyType, branchKey.Id.ToString());                      
            }               
            return branchKey;
        }

        public void SaveServerAndServerClient(TLMDTO00034 entity, string keyType)
        {           
            //DayKey
            if (keyType == "Day Key")
            {
                try
                {
                    TLMORM00034 daykey = this.SaveDaykey(entity, keyType);

                    if (daykey != null)
                    {
                        if (daykey.UniqueId == null)
                        {
                            daykey.UniqueId = "";
                        }
                        Dictionary<string, object> accounttypeKeyPair = new Dictionary<string, object> { { "Id", daykey.Id }, { "Code", daykey.Code }, { "Value", daykey.Value }, { "Start_Date", daykey.StartDate }, { "UId", daykey.UniqueId } };
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("DayKey", accounttypeKeyPair, daykey.TS, daykey.CreatedUserId, daykey.CreatedDate));
                        this.ServiceResult.ErrorOccurred = false;
                        this.ServiceResult.MessageCode = "MI90001";// Saving Successful  
                    }
                }
                catch
                {                   
                    this.ServiceResult.ErrorOccurred = true;                    
                }
            }

            //MonthKey
            if (keyType == "Month Key")
            {
                try
                {
                    TLMORM00035 monthkey = this.SaveMonthkey(entity, keyType);

                    if (monthkey != null)
                    {
                        if (monthkey.UniqueId == null)
                        {
                            monthkey.UniqueId = "";
                        }
                        Dictionary<string, object> accounttypeKeyPair = new Dictionary<string, object> { { "Id", monthkey.Id }, { "Code", monthkey.Code }, { "Value", monthkey.Value }, { "Start_Date", monthkey.StartDate } };
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("MonthKey", accounttypeKeyPair, monthkey.TS, monthkey.CreatedUserId, monthkey.CreatedDate));
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

            //AmountKey
            if (keyType == "Amount Key")
            {
                try
                {
                    TLMORM00036 amountkey = this.SaveAmountkey(entity, keyType);

                    if (amountkey != null)
                    {
                        if (amountkey.UniqueId == null)
                        {
                            amountkey.UniqueId = "";
                        }
                        Dictionary<string, object> accounttypeKeyPair = new Dictionary<string, object> { { "Id", amountkey.Id }, { "Code", amountkey.Code }, { "Value", amountkey.Value }, { "Start_Date", amountkey.StartDate }, { "UId", amountkey.UniqueId } };
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("AmountKey", accounttypeKeyPair, amountkey.TS, amountkey.CreatedUserId, amountkey.CreatedDate));
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

            //BranchKey
            if (keyType == "Branch Key")
            {
                try
                {
                    TLMORM00037 branchkey = this.SaveBranchkey(entity, keyType);

                    if (branchkey != null)
                    {
                        if (branchkey.UniqueId == null)
                        {
                            branchkey.UniqueId = "";
                        }
                        Dictionary<string, object> accounttypeKeyPair = new Dictionary<string, object> { { "Id", branchkey.Id }, { "Code", branchkey.Code }, { "Value", branchkey.Value }, { "Start_Date", branchkey.StartDate }, { "UId", branchkey.UniqueId } };
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("BranchKey", accounttypeKeyPair, branchkey.TS, branchkey.CreatedUserId, branchkey.CreatedDate));
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
        }        
       
        [Transaction(TransactionPropagation.Required)]
        public virtual TLMORM00034 UpdateDayKey(TLMDTO00034 entity, IList<DataVersionChangedValueDTO> dvcvList, string keyType)
        {
            TLMORM00034 daykey = null;
            if (this.dayKeyDAO.CheckExist(entity.Id, entity.Value.Value, entity.Code))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists
            }
            else
            {   daykey = this.dayKeyDAO.Update(GetDayKey(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, keyType, entity.Id.ToString());
            }
            return daykey;     
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual TLMORM00035 UpdateMonthKey(TLMDTO00034 entity, IList<DataVersionChangedValueDTO> dvcvList, string keyType)
        {
            TLMORM00035 monthkey = null;
            if (this.monthKeyDAO.CheckExist(entity.Id, entity.Value.Value, entity.Code))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists
            }
            else
            {
                TLMDTO00035 monthkeyDTO = GetMonthKeyDTO(entity);
                monthkey =  this.monthKeyDAO.Update(GetMonthKey(monthkeyDTO, false));
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, keyType, entity.Id.ToString());
            }
            return monthkey;
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual TLMORM00036 UpdateAmountKey(TLMDTO00034 entity, IList<DataVersionChangedValueDTO> dvcvList, string keyType)
        {
            TLMORM00036 amountKey = null;
             TLMDTO00036 amountKeyDTO = this.GetAmountKeyDTO(entity);
             if (this.amountKeyDAO.CheckExist(amountKeyDTO.Id, amountKeyDTO.Value, amountKeyDTO.Code))
             {
                 this.ServiceResult.ErrorOccurred = true;
                 this.ServiceResult.MessageCode = "MV90001";//data already exists
             }
             else
             {
                 amountKey = this.amountKeyDAO.Update(GetAmountKey(amountKeyDTO, false));
                 SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, keyType, entity.Id.ToString());
             }
             return amountKey;               
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual TLMORM00037 UpdateBranchKey(TLMDTO00034 entity, IList<DataVersionChangedValueDTO> dvcvList, string keyType)
        {
            TLMORM00037 branchkey = null;
            TLMDTO00037 branchKeyDTO = this.GetBranchKeyDTO(entity);
            if (this.branchKeyDAO.CheckExist(branchKeyDTO.Id, branchKeyDTO.Value, branchKeyDTO.Code))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists
            }
            else
            {
               branchkey = this.branchKeyDAO.Update(GetBranchKey(branchKeyDTO, false));
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, keyType, entity.Id.ToString());
            }
            return branchkey;      
        }

        public virtual void Update(TLMDTO00034 entity, string keyType, IList<DataVersionChangedValueDTO> dvcvList)
        {
            if (keyType == "Day Key")
            {
                try
                {
                    TLMORM00034 daykey = this.UpdateDayKey(entity,dvcvList,keyType);
                    if (daykey != null)
                    {
                        Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> {
                        { "Code", daykey.Code },
                        { "StartDate", daykey.StartDate },
                        { "Value", daykey.Value },
                        { "UpdatedUserId", daykey.UpdatedUserId },
                        { "UpdatedDate", DateTime.Now },
                        {"TS",daykey.TS}
                        };
                        Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "Id", daykey.Id }, { "Active", true } };
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("TLMORM00034", updateColumnsandValues, whereColumnsandValues));
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

            else if (keyType == "Month Key")
            {
                try
                {
                    TLMORM00035 monthkey = this.UpdateMonthKey(entity, dvcvList,keyType);
                      if(monthkey!=null)
                      {
                        Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> { 
                        { "Code", monthkey.Code },
                        { "StartDate", monthkey.StartDate }, 
                        { "Value", monthkey.Value },
                        { "UpdatedUserId", monthkey.UpdatedUserId },
                        { "UpdatedDate", DateTime.Now } ,
                        {"TS",monthkey.TS}
                        };
                        Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "Id", monthkey.Id }, { "Active", true } };
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("TLMORM00035", updateColumnsandValues, whereColumnsandValues));
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

            else if (keyType == "Amount Key")
            {
                try
                {                 
                        TLMORM00036 amountkey = UpdateAmountKey(entity,dvcvList,keyType);
                      if(amountkey != null)
                      {
                        Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> {
                        { "Code", amountkey.Code },
                        { "StartDate", amountkey.StartDate }, 
                        { "Value", amountkey.Value }, 
                        { "UpdatedUserId", amountkey.UpdatedUserId },
                        { "UpdatedDate", DateTime.Now } ,
                        {"TS",amountkey.TS}
                        };
                        Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "Id", amountkey.Id }, { "Active", true } };
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("TLMORM00036", updateColumnsandValues, whereColumnsandValues));
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

            else if (keyType == "Branch Key")
            {
                try
                {
                    TLMORM00037 branchkey = UpdateBranchKey(entity,dvcvList,keyType);
                    if (branchkey != null)
                    {
                        Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> {
                        { "Code", branchkey.Code }, 
                        { "StartDate", branchkey.StartDate },
                        { "Value", branchkey.Value },
                        { "UpdatedUserId", branchkey.UpdatedUserId },
                        { "UpdatedDate", DateTime.Now } ,
                        {"TS",branchkey.TS}
                        };
                        Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "Id", branchkey.Id }, { "Active", true } };
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("TLMORM00037", updateColumnsandValues, whereColumnsandValues));
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
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual TLMORM00034 DeleteDayKey(TLMDTO00034 item,string keyType)
        {         
           TLMORM00034 daykey = this.dayKeyDAO.Delete(GetDayKey(item,true), false);           
            SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), item.CreatedUserId, keyType, item.Id.ToString());
            return daykey;     
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual TLMORM00035 DeleteMonthKey(TLMDTO00034 item, string keyType)
        {           
            TLMORM00035 monthkey = this.MonthKeyDAO.Delete(GetMonthKey(GetMonthKeyDTO(item), true), false);
            SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), item.CreatedUserId, keyType, item.Id.ToString());
            return monthkey;   
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual TLMORM00036 DeleteAmountKey(TLMDTO00034 item, string keyType)
        {
            TLMORM00036 amountkey = this.AmountKeyDAO.Delete(GetAmountKey(GetAmountKeyDTO(item), true), false);
            SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), item.CreatedUserId, keyType, item.Id.ToString());
            return amountkey;  
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual TLMORM00037 DeleteBranchKey(TLMDTO00034 item, string keyType)
        {
            TLMORM00037 branchkey = this.BranchKeyDAO.Delete(GetBranchKey(GetBranchKeyDTO(item), true), false);
            SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), item.CreatedUserId, keyType, item.Id.ToString());
            return branchkey; 
        }

        public virtual void Delete(IList<TLMDTO00034> itemList, string keyType)
        {
            if (keyType == "Day Key")
            {
                try
                {
                    foreach (TLMDTO00034 item in itemList)
                    {
                        TLMORM00034 daykey = DeleteDayKey(item, keyType);
                        string id = daykey.Id.ToString();
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("TLMORM00034", "Id",id , daykey.CreatedUserId,daykey.TS));
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

            else if (keyType == "Month Key")
            {
                try
                {
                    foreach (TLMDTO00034 item in itemList)
                    {
                        TLMORM00035 monthkey = DeleteMonthKey(item, keyType);
                        string id = monthkey.Id.ToString();
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("TLMORM00035", "Id", id, monthkey.CreatedUserId,monthkey.TS));
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

            else if (keyType == "Amount Key")
            {
                try
                {
                    foreach (TLMDTO00034 item in itemList)
                    {
                        TLMORM00036 amountkey = DeleteAmountKey(item, keyType);
                        string id = amountkey.Id.ToString();
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("TLMORM00036", "Id", id, amountkey.CreatedUserId,amountkey.TS));
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

            else if (keyType == "Branch Key")
            {
                try
                {
                    foreach (TLMDTO00034 item in itemList)
                    {
                        TLMORM00037 branchkey = DeleteBranchKey(item, keyType);
                        string id = branchkey.Id.ToString();
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("TLMORM00037", "Id", id, branchkey.CreatedUserId,branchkey.TS));
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
        }

        public void SaveOrUpdateClientDataVersion(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId, string keyType, string dataIdValue)
        {
            if (keyType == "Day Key")
            {
                ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
                TLMORM00034 DayKeyORM = new TLMORM00034();

                //Require Data
                clientDataVersionDTO.ORMObjectName = DayKeyORM;
                //clientDataVersionDTO.DataIdValue = GlobalUtilities.ConvertClassPropertyToString(() => DayKeyORM.Id);
                clientDataVersionDTO.DataIdValue = dataIdValue;
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

            else if (keyType == "Month Key")
            {
                ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
                TLMORM00035 MonthKeyORM = new TLMORM00035();

                //Require Data
                clientDataVersionDTO.ORMObjectName = MonthKeyORM;
                //clientDataVersionDTO.DataIdValue = GlobalUtilities.ConvertClassPropertyToString(() => MonthKeyORM.Id);
                clientDataVersionDTO.DataIdValue = dataIdValue;
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

            else if (keyType == "Amount Key")
            {
                ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
                TLMORM00036 AmountKeyORM = new TLMORM00036();

                //Require Data
                clientDataVersionDTO.ORMObjectName = AmountKeyORM;
                //clientDataVersionDTO.DataIdValue = GlobalUtilities.ConvertClassPropertyToString(() => AmountKeyORM.Id);
                clientDataVersionDTO.DataIdValue = dataIdValue;
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
            else if (keyType == "Branch Key")
            {
                ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
                TLMORM00037 BranchKeyORM = new TLMORM00037();

                //Require Data
                clientDataVersionDTO.ORMObjectName = BranchKeyORM;
                //clientDataVersionDTO.DataIdValue = GlobalUtilities.ConvertClassPropertyToString(() => BranchKeyORM.Id);
                clientDataVersionDTO.DataIdValue = dataIdValue;
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
        }

        #endregion        

       
    }
}