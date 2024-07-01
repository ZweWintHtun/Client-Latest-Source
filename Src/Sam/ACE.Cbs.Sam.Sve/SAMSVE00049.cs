//----------------------------------------------------------------------
// <copyright file="SAMSVE00049.cs" company="ACE Data Systems">
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
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Sam.Sve
{
    /// <summary>
    /// Sys001 Service
    /// </summary>
	public class SAMSVE00049:BaseService,ISAMSVE00049
  	{
		#region Properties
		
		private IPFMDAO00056 sys001DAO;
        public IPFMDAO00056 Sys001DAO
        {
            get { return this.sys001DAO; }
            set { this.sys001DAO = value; }
        }
		
		private PFMORM00056 Sys001Info;
        //IList<PFMDTO00056> sys001List = new List<PFMDTO00056>();
        IList<PFMDTO00056> sys001List { get; set; }
        string existStatus = string.Empty;
        
		#endregion

        #region Helper Method

        private PFMORM00056 GetSys001(PFMDTO00056 sys001DTO, bool isEdit ,bool isDelete)
        {
            Sys001Info = new PFMORM00056();

            Sys001Info.Id = sys001DTO.Id;
            Sys001Info.Name = sys001DTO.Name;
            Sys001Info.SysMonYear = sys001DTO.SysMonYear;
            Sys001Info.Status = sys001DTO.Status;
            if(isEdit)
                Sys001Info.SysDate = sys001DTO.SysDate;
            else
                Sys001Info.SysDate = DateTime.Now;
            Sys001Info.SysQty = sys001DTO.SysQty;
            Sys001Info.BranchCode = sys001DTO.BranchCode;
            Sys001Info.TS = sys001DTO.TS;            
            Sys001Info.CreatedUserId = sys001DTO.CreatedUserId;
            Sys001Info.CreatedDate = DateTime.Now;           
            if (isEdit || isDelete)
            {
                Sys001Info.UpdatedUserId = sys001DTO.UpdatedUserId;
                Sys001Info.UpdatedDate = DateTime.Now;
            }

            if (isDelete)
                Sys001Info.Active = false;
            else
                Sys001Info.Active = true;

            return Sys001Info;
        }

        #endregion
		
		#region Main Methods

        public virtual IList<PFMDTO00056> GetAll()
        {
            return this.Sys001DAO.SelectAll();
        }

        public PFMDTO00056 SelectById(int id)
        {
            return this.Sys001DAO.SelectById(id);
        }

        //[Transaction(TransactionPropagation.Required)]
        //public virtual PFMORM00056 Save(PFMDTO00056 entity)
        //{
        //    PFMORM00056 sys001 = null;
        //    if (entity.checkStatus == "First")
        //    {
        //        if (this.sys001DAO.CheckExist(0, entity.Name, entity.Status))
        //        {
        //            this.ServiceResult.ErrorOccurred = true;
        //            this.ServiceResult.MessageCode = "MV90001";//data already exists                     
        //        }
        //        else
        //        {
        //            sys001 = this.sys001DAO.Save(this.GetSys001(entity, false, false));
        //            this.SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), sys001.CreatedUserId, sys001.Id);
        //        }
        //    }
        //    else
        //    {
        //        sys001 = this.sys001DAO.Save(this.GetSys001(entity, false, false));
        //        this.SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), sys001.CreatedUserId, sys001.Id);
        //    }
        //    return sys001;
        //}

        [Transaction(TransactionPropagation.Required)]
        public virtual PFMORM00056 Save(PFMDTO00056 entity)
        {
            PFMORM00056 sys001 = null;            
            string br = string.Empty;
            if (entity.checkStatus == "First")
            {
                sys001List = this.sys001DAO.CheckExist2(0, entity.Name);
                if(sys001List.Count > 0)
                {
                    if (sys001List.Count == entity.Count)
                    {
                        if (existStatus == "yes")
                        {
                            existStatus = string.Empty;
                            this.ServiceResult.ErrorOccurred = true;
                            this.ServiceResult.MessageCode = "MV90001";//data already exists                     
                        }
                        else
                        {
                            this.ServiceResult.ErrorOccurred = false;
                            this.ServiceResult.MessageCode = "MI90001";// Saving Successful 
                        } 
                    }
                    else
                    {
                        foreach(PFMDTO00056 sys001DTO in sys001List)
                        {
                            existStatus = "yes";
                            if (entity.BranchCode != sys001DTO.BranchCode)
                            {                               
                                if (br != entity.BranchCode)
                                {
                                    sys001 = this.sys001DAO.Save(this.GetSys001(entity, false, false));
                                    this.SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), sys001.CreatedUserId, sys001.Id);
                                    br = entity.BranchCode;
                                }
                            }
                            else return null;
                        }                        
                    }
                }
                else
                {
                    sys001 = this.sys001DAO.Save(this.GetSys001(entity, false, false));
                    this.SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), sys001.CreatedUserId, sys001.Id);
                }
            }
            else
            {
                //if (sys001List != null)
                //{
                //    if (sys001List.Count > 0)
                //    {
                //        foreach (PFMDTO00056 sys001DTO in sys001List)
                //        {
                //            if (entity.BranchCode != sys001DTO.BranchCode)
                //            {
                //                if (br != entity.BranchCode)
                //                {
                //                    sys001 = this.sys001DAO.Save(this.GetSys001(entity, false, false));
                //                    this.SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), sys001.CreatedUserId, sys001.Id);
                //                    br = entity.BranchCode;
                //                }
                //            }
                //            else return null;
                //        }
                //    }
                //}
                //else
                //{
                    sys001 = this.sys001DAO.Save(this.GetSys001(entity, false, false));
                    this.SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), sys001.CreatedUserId, sys001.Id);
                //}
            }
            return sys001;
        }
      
        public void SaveServerAndServerClient(PFMDTO00056 entity)
        {
            PFMORM00056 sys001 = null;
            try
            {
                sys001 = this.Save(entity);
                if (sys001 == null)
                    return;
                
                if (!this.ServiceResult.ErrorOccurred)
                {
                    Dictionary<string, object> sys001KeyPair = new Dictionary<string, object> {
                        { "Id", sys001.Id }, 
                        { "Name", sys001.Name },
                        { "SysMonYear", sys001.SysMonYear },
                        { "Status", sys001.Status }, 
                        { "SysDate", sys001.SysDate },
                        { "SysQty", sys001.SysQty }, 
                        { "SourceBr", sys001.BranchCode } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("Sys001", sys001KeyPair, sys001.TS, sys001.CreatedUserId, sys001.CreatedDate));
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
        public virtual PFMORM00056 UpdateServer(PFMDTO00056 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            PFMORM00056 sys001 = null;

            if (entity.checkStatus == "First")
            {
                if (this.sys001DAO.CheckExist(entity.Id, entity.Name))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV90001";//data already exists
                }
                else
                {
                    sys001 = this.sys001DAO.Update(GetSys001(entity, true, false));
                    SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Id);
                }
            }
            else
            {
                sys001 = this.sys001DAO.Update(GetSys001(entity, true, false));
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Id);
            }
            return sys001;
        }

        public virtual void Update(PFMDTO00056 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            try
            {
                PFMORM00056 sys001 = this.UpdateServer(entity, dvcvList);
                if (!this.ServiceResult.ErrorOccurred)
                {
                    Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> { 
                    { "Name", sys001.Name }, 
                    { "UpdatedUserId", sys001.UpdatedUserId },
                    { "UpdatedDate", DateTime.Now },
                    {"TS",sys001.TS}
                    };
                    Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "Id", sys001.Id }, { "Active", true } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00056", updateColumnsandValues, whereColumnsandValues));
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
        public virtual PFMORM00056 DeleteServer(PFMDTO00056 sys001DTO)
        {
            PFMORM00056 sys001 = this.sys001DAO.Delete(GetSys001(sys001DTO,false, true), false);
            this.SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), sys001DTO.CreatedUserId, sys001DTO.Id);
            return sys001;
        }

        public virtual void Delete(IList<PFMDTO00056> itemList)
        {
            try
            {
                foreach (PFMDTO00056 item in itemList)
                {
                    PFMORM00056 sys001 = DeleteServer(item);
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("PFMORM00056", "Name", sys001.Name, sys001.CreatedUserId, sys001.TS));
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

        public void SaveOrUpdateClientDataVersion(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId, int dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
            PFMORM00056 Sys001ORM = new PFMORM00056();

            //Require Data
            clientDataVersionDTO.ORMObjectName = Sys001ORM;
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
		
		#endregion	
         
    }	
}
