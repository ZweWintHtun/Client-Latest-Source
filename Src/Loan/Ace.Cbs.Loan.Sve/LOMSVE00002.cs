using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Core.Ctr;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00002 : BaseService, ILOMSVE00002
    {
        #region Properties

        private ILOMDAO00002 advanceDAO;
        public ILOMDAO00002 AdvanceDAO
        {
            get { return this.advanceDAO; }
            set { this.advanceDAO = value; }
        }

        private LOMORM00002 AdvanceInfo;

        #endregion

        #region OldCode       

        //public virtual IList<LOMDTO00002> GetAll()
        //{
        //    return this.AdvanceDAO.SelectAll();
        //}

        //public LOMDTO00002 SelectByAdvanceCode(string advanceCode)
        //{
        //    return this.AdvanceDAO.SelectByAdvanceCode(advanceCode);
        //}
        
        //[Transaction(TransactionPropagation.Required)]
        //public virtual LOMORM00002 Save(LOMDTO00002 entity)
        //{
        //    LOMORM00002 advance = null;
        //    try
        //    {
        //        if (this.AdvanceDAO.CheckExist(entity.Code, entity.Description, false))
        //        {
        //            this.ServiceResult.ErrorOccurred = true;
        //            this.ServiceResult.MessageCode = "MV90001";//data already exists                     
        //        }
        //        else
        //        {
        //            advance = this.AdvanceDAO.Save(this.GetAdvanceData(entity, false));
        //            this.ServiceResult.MessageCode = "MI90001";// Saving Successful
        //            this.SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), advance.CreatedUserId, advance.Code);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        this.ServiceResult.ErrorOccurred = true;
        //        this.ServiceResult.MessageCode = "ME90036";
        //    }
        //    return advance;
        //}

        //[Transaction(TransactionPropagation.Required)]        
        //public virtual void Update(LOMDTO00002 entity, IList<DataVersionChangedValueDTO> dvcvList)
        //{
        //    try
        //    {
        //        if (this.AdvanceDAO.CheckExist(entity.Code, entity.Description, true))
        //        {
        //            this.ServiceResult.ErrorOccurred = true;
        //            this.ServiceResult.MessageCode = "MV90001";//data already exists
        //        }
        //        else
        //        {
        //            entity.UpdatedDate = DateTime.Now;
        //            entity.UpdatedUserId = entity.CreatedUserId;
        //            LOMORM00002 advance = GetAdvanceData(entity, false);
        //            this.AdvanceDAO.Update(advance);
        //      //      this.SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Code);
        //            Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> { { "Code", advance.Code }, { "Description", advance.Description }, { "UpdatedDate", advance.UpdatedDate }, { "UpdatedUserId" ,advance.UpdatedUserId} };
        //            Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "Code", advance.Code}, { "Active", true } };
        //            CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("LOMORM00002", updateColumnsandValues, whereColumnsandValues));
                    
                    
        //            this.ServiceResult.ErrorOccurred = false;
        //            this.ServiceResult.MessageCode = "MI90002";//Update Success
        //            this.SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Code);
                    
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        this.ServiceResult.ErrorOccurred = true;
        //        this.ServiceResult.MessageCode = "ME90036";  // Error Occur!!! Please contact your administrator.
        //    }
        //}

        //[Transaction(TransactionPropagation.Required)]
        //public virtual void Delete(IList<LOMDTO00002> itemList)
        //{
        //    try
        //    {
        //        foreach (LOMDTO00002 item in itemList)
        //        {
        //            item.UpdatedUserId = item.UpdatedUserId;
        //            item.UpdatedDate = DateTime.Now;                    
        //            this.AdvanceDAO.Delete(GetAdvanceData(item, true), false);

        //            this.SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), item.CreatedUserId, item.Code);
        //            CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("LOMORM00002", "Code", item.Code, item.CreatedUserId, item.TS));
        //        }
        //        this.ServiceResult.ErrorOccurred = false;
        //        this.ServiceResult.MessageCode = "MI90003";//Delete Success
        //    }
        //    catch (Exception)
        //    {
        //        this.ServiceResult.ErrorOccurred = true;
        //        this.ServiceResult.MessageCode = "ME90036";     //Error Occur!!! Please contact your administrator.
        //        //throw new Exception(this.ServiceResult.MessageCode);
        //    }
        //}
        

        //#region Server Client Data Save,Update and Delete
        //public void SaveServerAndServerClient(LOMDTO00002 entity)
        //{
        //    LOMDTO00002 advanceEntity = null;
        //    try
        //    {
        //        LOMORM00002 advance = this.Save(entity);
        //        if (advance != null)
        //            advanceEntity = AdvanceDAO.SelectByAdvanceCode(advance.Code);
        //        if (advanceEntity != null)
        //        {

        //            Dictionary<string, object> advancetypeKeyPair = new Dictionary<string, object> { { "AdvanceCode", advanceEntity.Code }, { "AdvanceDesp", advanceEntity.Description }};
        //            CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("Advance", advancetypeKeyPair, advanceEntity.TS, advanceEntity.CreatedUserId, advanceEntity.CreatedDate));
        //            this.ServiceResult.ErrorOccurred = false;
        //            this.ServiceResult.MessageCode = "MI90001";// Saving Successful  
        //        }

        //    }
        //    catch
        //    {
        //        // AppSettingsDAO.Delete(appsettingEntity, true);
        //        this.ServiceResult.ErrorOccurred = true;
        //        if (!string.IsNullOrEmpty(this.ServiceResult.MessageCode))
        //            this.ServiceResult.MessageCode = this.ServiceResult.MessageCode;
        //        else
        //            this.ServiceResult.MessageCode = "ME90036";
        //    }
        //}
        //#endregion
        #endregion

        #region NewCode
        
        public virtual IList<LOMDTO00002> GetAll()
        {
            return this.AdvanceDAO.SelectAll();
        }

        public LOMDTO00002 SelectByAdvanceCode(string advanceCode)
        {
            return this.AdvanceDAO.SelectByAdvanceCode(advanceCode);
        }

        public IList<LOMDTO00002> CheckExist2(string advanceCode, string desp)
        {
            return this.AdvanceDAO.CheckExist2(advanceCode, desp);
        }

        #region Server Client Data Save,Update and Delete
        public void SaveServerAndServerClient(LOMDTO00002 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {            
            try
            {                
                LOMORM00002 advanceEntity = this.Save(entity, dvcvList);
                if (advanceEntity != null)
                {
                    if (!this.ServiceResult.ErrorOccurred)
                    {
                        Dictionary<string, object> advancetypeKeyPair = new Dictionary<string, object> {
	                    { "AdvanceCode", advanceEntity.Code },	                    
	                    { "AdvanceDesp", advanceEntity.Description } };
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("Advance", advancetypeKeyPair, advanceEntity.TS, advanceEntity.CreatedUserId, advanceEntity.CreatedDate));
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
        #endregion

        [Transaction(TransactionPropagation.Required)]
        public virtual LOMORM00002 Save(LOMDTO00002 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMORM00002 advance = null;
            if (!entity.Active)  //Active = 0 , update nature
            {
                this.Update(entity, dvcvList, "Save");
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Code);
                return null;
            }
            else //Active = 1 , insert nature  
            {
                advance = this.AdvanceDAO.Save(this.GetAdvanceData(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), entity.CreatedUserId, entity.Code);
            }
            return advance;
        }

        public virtual void Update(LOMDTO00002 entity, IList<DataVersionChangedValueDTO> dvcvList, string status)
        {
            try
            {
                LOMORM00002 advanceType = this.UpdateServer(entity, dvcvList);
                if (!this.ServiceResult.ErrorOccurred)
                {
                    Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> {
                    { "AdvanceCode", advanceType.Code },
                    { "AdvanceDesp", advanceType.Description },                     
					{ "Active", advanceType.Active},
                    { "UpdatedUserId", advanceType.UpdatedUserId },
                    { "UpdatedDate", DateTime.Now },
                    { "TS",advanceType.TS }
                    };                    
                    Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "AdvanceCode", advanceType.Code } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("LOMORM00002", updateColumnsandValues, whereColumnsandValues));
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
        public virtual LOMORM00002 UpdateServer(LOMDTO00002 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMORM00002 advanceTypeEntity = null;

            if (this.AdvanceDAO.CheckExist(entity.Code, entity.Description, true))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists
            }
            else
            {
                advanceTypeEntity = this.AdvanceDAO.Update(this.GetAdvanceData(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Code);
            }
            return advanceTypeEntity;
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual void Delete(IList<LOMDTO00002> itemList)
        {
            try
            {
                foreach (LOMDTO00002 item in itemList)
                {
                    LOMORM00002 deletedEntity = this.DeleteServer(item); 
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("LOMORM00002", "Code", item.Code, item.CreatedUserId, item.TS));
                }
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90003";//Delete Success
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";     //Error Occur!!! Please contact your administrator.
                throw new Exception(this.ServiceResult.MessageCode);
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual LOMORM00002 DeleteServer(LOMDTO00002 advanceTypeDTO)
        {
            LOMORM00002 advanceType = this.GetAdvanceData(advanceTypeDTO, true);
            LOMORM00002 deletedEntity = this.AdvanceDAO.Delete(advanceType, false);
            SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), advanceTypeDTO.CreatedUserId, advanceTypeDTO.Code);
            return deletedEntity;
        }

         #endregion

        #region Helper Method

        private LOMORM00002 GetAdvanceData(LOMDTO00002 advanceDTO, bool isDelete)
        {
            AdvanceInfo = new LOMORM00002();

            AdvanceInfo.Code = advanceDTO.Code;
            AdvanceInfo.Description = advanceDTO.Description;
            AdvanceInfo.TS = advanceDTO.TS;

            AdvanceInfo.CreatedUserId = advanceDTO.CreatedUserId;
            AdvanceInfo.CreatedDate = DateTime.Now;

            AdvanceInfo.UpdatedUserId = advanceDTO.UpdatedUserId;
            AdvanceInfo.UpdatedDate = DateTime.Now;

            if (isDelete)
                AdvanceInfo.Active = false;
            else
                AdvanceInfo.Active = true;

            return AdvanceInfo;
        }

        #endregion

        #region Data Version Update Service
        public void SaveOrUpdateClientDataVersion(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId, string dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
            LOMORM00002 AdvanceORM = new LOMORM00002();

            //Require Data
            clientDataVersionDTO.ORMObjectName = AdvanceORM;
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
