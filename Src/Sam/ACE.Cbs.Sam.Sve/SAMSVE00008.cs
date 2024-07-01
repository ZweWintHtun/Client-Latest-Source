//----------------------------------------------------------------------
// <copyright file="SAMSVE00020.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
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
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Dao;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Windows.Core.Service;
using Ace.Windows.Core.DataModel;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Core.Ctr;

namespace Ace.Cbs.Sam.Sve
{
    /// <summary>
    /// DEPOSITCODE Service
    /// </summary>
	public class SAMSVE00008:BaseService,ISAMSVE00008
  	{
		#region Properties

        private ITLMDAO00020 dEPOSITCODEDAO;
        public ITLMDAO00020 DEPOSITCODEDAO
        {
            get { return this.dEPOSITCODEDAO; }
            set { this.dEPOSITCODEDAO = value; }
        }
		
		private TLMORM00020 DEPOSITCODEInfo;
		
		#endregion

        #region Helper Method

        private TLMORM00020 GetDEPOSITCODE(TLMDTO00020 dEPOSITCODEDTO, bool isDelete)
        {
            DEPOSITCODEInfo = new TLMORM00020();

            DEPOSITCODEInfo.DepositCode = dEPOSITCODEDTO.DepositCode;
            DEPOSITCODEInfo.Description = dEPOSITCODEDTO.Description;
            DEPOSITCODEInfo.UniqueId = dEPOSITCODEDTO.UniqueId;
            DEPOSITCODEInfo.SourceBranchCode = dEPOSITCODEDTO.SourceBranchCode;
            DEPOSITCODEInfo.TS = dEPOSITCODEDTO.TS;
            DEPOSITCODEInfo.CreatedUserId = dEPOSITCODEDTO.CreatedUserId;
            DEPOSITCODEInfo.CreatedDate = DateTime.Now;
            DEPOSITCODEInfo.UpdatedUserId = dEPOSITCODEDTO.UpdatedUserId;
            DEPOSITCODEInfo.UpdatedDate = DateTime.Now;
            if (isDelete)
                DEPOSITCODEInfo.Active = false;
            else
                DEPOSITCODEInfo.Active = true;
            return DEPOSITCODEInfo;
        }
        #endregion
		
		#region Main Methods

        public virtual IList<TLMDTO00020> GetAll(string sourceBranch)
        {
            return this.DEPOSITCODEDAO.SelectAll(sourceBranch);
        }

        public TLMDTO00020 SelectById(string dEPCODE)
        {
            return this.DEPOSITCODEDAO.SelectByDEPCODE(dEPCODE);
        }

        public TLMDTO00020 SelectToTS(string dEPCODE, string sourceBranch)
        {
            return this.DEPOSITCODEDAO.SelectToTS(dEPCODE, sourceBranch);
        }

        public TLMDTO00020 SelectToDeleteTS(string dEPCODE, string sourceBranch)
        {
            return this.DEPOSITCODEDAO.SelectToDeleteTS(dEPCODE, sourceBranch);
        }

        public IList<TLMDTO00020> CheckExist2(string branchCode, string sourceBranch)
        {
            return this.DEPOSITCODEDAO.CheckExist2(branchCode, sourceBranch);
        }
		
		[Transaction(TransactionPropagation.Required)]
        public virtual TLMORM00020 Save(TLMDTO00020 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
             TLMORM00020 depositcode = null;
             if (!entity.Active)  //Active = 0 , update nature
             {
                 this.UpdateSameCode(entity, dvcvList, "Save");
                 SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.DepositCode);
                 return null;
             }
             else //Active = 1 , insert nature  
             {
                 depositcode = this.DEPOSITCODEDAO.Save(this.GetDEPOSITCODE(entity, false));
                 SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), entity.CreatedUserId, entity.DepositCode);
             }
             return depositcode;
        }

        public void SaveServerAndServerClient(TLMDTO00020 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {        
            try
            {
                TLMDTO00020 ts = new TLMDTO00020();
                TLMORM00020 depositcode = this.Save(entity, dvcvList);
                if (depositcode != null)
                {
                    ts = this.SelectToTS(depositcode.DepositCode, depositcode.SourceBranchCode);
                    if (!this.ServiceResult.ErrorOccurred)
                    {
                        //if (depositcode.UniqueId == null)
                        //{ depositcode.UniqueId = depositcode.UpdatedUserId.ToString(); }
                        Dictionary<string, object> accounttypeKeyPair = new Dictionary<string, object> 
                        { { "DepCode", depositcode.DepositCode }, 
                        { "Desp", depositcode.Description }, 
                        //{ "UniqueId", depositcode.UniqueId }, 
                        { "SourceBr", depositcode.SourceBranchCode } };
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("DepositCode", accounttypeKeyPair, ts.TS, depositcode.CreatedUserId, depositcode.CreatedDate));
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
        public virtual TLMORM00020 UpdateServer(TLMDTO00020 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            TLMORM00020 depoditcode = null;
           
            if (this.DEPOSITCODEDAO.CheckExist(entity.DepositCode,entity.Description,entity.SourceBranchCode,true))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists
            }
            else
            { 				
                depoditcode = this.DEPOSITCODEDAO.Update(GetDEPOSITCODE(entity,false));                 
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.DepositCode);
            }
            return depoditcode;
        }

        public virtual void Update(TLMDTO00020 entity, IList<DataVersionChangedValueDTO> dvcvList, string status)
        {
            try
            {
                TLMORM00020 depositCode = this.UpdateServer(entity,dvcvList);
                //TLMDTO00020 ts = new TLMDTO00020();
                //ts = this.SelectToTS(depositCode.DepositCode, depositCode.SourceBranchCode);
                if (!this.ServiceResult.ErrorOccurred)
                {
                    //if (depositCode.UniqueId == null)
                    //{depositCode.UniqueId = depositCode.UpdatedUserId.ToString();}
                    Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> { 
                { "DepositCode", depositCode.DepositCode },
                { "Description", depositCode.Description },
                //{ "UniqueId", depositCode.UniqueId }, 
                //{ "SourceBranchCode", depositCode.SourceBranchCode },
                { "UpdatedUserId", depositCode.UpdatedUserId },
                { "UpdatedDate", DateTime.Now },
                {"TS",depositCode.TS},
                { "Active", depositCode.Active}
                };
                    //Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "DepositCode", depositCode.DepositCode }, { "SourceBranchCode", depositCode.SourceBranchCode } };
                    Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "DepositCode", depositCode.DepositCode }, { "TS", entity.TS } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("TLMORM00020", updateColumnsandValues, whereColumnsandValues));
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

        public virtual void UpdateSameCode(TLMDTO00020 entity, IList<DataVersionChangedValueDTO> dvcvList, string status)
        {
            try
            {
                TLMDTO00020 ts = new TLMDTO00020();
                TLMORM00020 depositCode = this.UpdateServer(entity, dvcvList);
                ts = this.SelectToTS(depositCode.DepositCode, depositCode.SourceBranchCode);
                if (!this.ServiceResult.ErrorOccurred)
                {
                    //if (depositCode.UniqueId == null)
                    //{depositCode.UniqueId = depositCode.UpdatedUserId.ToString();}
                    Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> { 
                { "DepositCode", depositCode.DepositCode },
                { "Description", depositCode.Description },
                //{ "UniqueId", depositCode.UniqueId }, 
                { "SourceBranchCode", depositCode.SourceBranchCode },
                { "UpdatedUserId", depositCode.UpdatedUserId },
                 { "UpdatedDate", DateTime.Now },
                {"TS",ts.TS},
                { "Active", depositCode.Active}
                };
                    Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "DepositCode", depositCode.DepositCode }, { "SourceBranchCode", depositCode.SourceBranchCode } };
                    //Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "DepositCode", depositCode.DepositCode }, { "TS", entity.TS } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("TLMORM00020", updateColumnsandValues, whereColumnsandValues));
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
        public virtual TLMORM00020 DeleteServer(TLMDTO00020 depositCodeDTO)
        {
            TLMORM00020 depositcodeEntity = this.GetDEPOSITCODE(depositCodeDTO,true);
            TLMORM00020 deletedEntity = this.DEPOSITCODEDAO.Delete(depositcodeEntity,false);
            this.DEPOSITCODEDAO.Delete(deletedEntity, false);
            SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), depositCodeDTO.CreatedUserId, depositCodeDTO.DepositCode);
            return deletedEntity;
        }

        #region old delete
        //public virtual void Delete(IList<TLMDTO00020> itemList)
        //{
        //    try
        //    {
        //        foreach (TLMDTO00020 item in itemList)
        //        {
        //          TLMORM00020 deletedEntity = this.DeleteServer(item);
        //          CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("TLMORM00020", "DepositCode", deletedEntity.DepositCode, deletedEntity.CreatedUserId,deletedEntity.TS));
        //        }
        //        this.ServiceResult.ErrorOccurred = false;
        //        this.ServiceResult.MessageCode = "MI90003";//Delete Success
        //    }
        //    catch (Exception)
        //    {
        //        this.ServiceResult.ErrorOccurred = true;
        //        this.ServiceResult.MessageCode = "ME90036";
        //        throw new Exception(this.ServiceResult.MessageCode);
        //    }
        //}
        #endregion


        public virtual void Delete(IList<TLMDTO00020> itemList)
        {
            try
            {
                foreach (TLMDTO00020 item in itemList)
                {
                    //PFMORM00009 ratefile = this.DeleteServer(item);
                    //TLMDTO00020 ts = new TLMDTO00020();
                    item.UpdatedDate = System.DateTime.Now;
                    this.DEPOSITCODEDAO.DeleteCode(item);
                    //ts = this.SelectToDeleteTS(item.DepositCode, item.SourceBranchCode);
                    this.SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), item.CreatedUserId, item.DepositCode);
                    //item.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                    item.Active = false;
                    
                    Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> {
                    { "Active", item.Active },
                    { "UpdatedUserId", item.UpdatedUserId },
                    { "UpdatedDate", DateTime.Now },
                    {"TS",item.TS}
                    };
                    Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "DepositCode", item.DepositCode }, { "SourceBranchCode", item.SourceBranchCode } };
                    //Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "DepositCode", item.DepositCode }, { "TS", item.TS } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("TLMORM00020", updateColumnsandValues, whereColumnsandValues));
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

        public void SaveOrUpdateClientDataVersion(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId, string dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
            TLMORM00020 DepositCodeORM = new TLMORM00020();

            //Require Data
            clientDataVersionDTO.ORMObjectName = DepositCodeORM;
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
