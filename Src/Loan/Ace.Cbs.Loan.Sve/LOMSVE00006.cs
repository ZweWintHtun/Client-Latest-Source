//----------------------------------------------------------------------
// <copyright file="LOMSVE00006.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KSW</CreatedUser>
// <CreatedDate>08/18/2014</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
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

namespace Ace.Cbs.loan.Sve
{
    /// <summary>
    /// INSURAN Service
    /// </summary>
    public class LOMSVE00006 : BaseService, ILOMSVE00006
    {
        #region Properties

        private ILOMDAO00004 iNSURANDAO;
        public ILOMDAO00004 INSURANDAO
        {
            get { return this.iNSURANDAO; }
            set { this.iNSURANDAO = value; }
        }

        private LOMORM00004 INSURANInfo;

        #endregion

        #region OldCode
        //#region Logical Methods
        //public virtual IList<LOMDTO00004> GetAll()
        //{
        //    return this.INSURANDAO.SelectAll();
        //}

        //public LOMDTO00004 SelectByINSUCODE(string iNSUCODE)
        //{
        //    return this.INSURANDAO.SelectByINSUCODE(iNSUCODE);
        //}

        //[Transaction(TransactionPropagation.Required)]
        //public virtual LOMORM00004 Save(LOMDTO00004 entity)
        //{
        //    LOMORM00004 nationality = null;

        //    try
        //    {
        //        if (this.iNSURANDAO.CheckExist(entity.INSUCODE, entity.INSUDESP, false))
        //        {
        //            this.ServiceResult.ErrorOccurred = true;
        //            this.ServiceResult.MessageCode = "MV90001";//data already exists                     
        //        }
        //        else
        //        {
        //            nationality = this.iNSURANDAO.Save(this.GetINSURAN(entity, false));
        //            this.ServiceResult.ErrorOccurred = false;
        //            this.ServiceResult.MessageCode = "MI90001";// Saving Successful
        //            this.SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), entity.CreatedUserId, entity.INSUCODE);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        this.ServiceResult.ErrorOccurred = true;
        //        this.ServiceResult.MessageCode = "ME90036";
        //    }

        //    return nationality;
        //}

        //[Transaction(TransactionPropagation.Required)]
        //public virtual void Update(LOMDTO00004 entity, IList<DataVersionChangedValueDTO> dvcvList)
        //{
        //    try
        //    {
        //        if (this.iNSURANDAO.CheckExist(entity.INSUCODE, entity.INSUDESP, true))
        //        {
        //            this.ServiceResult.ErrorOccurred = true;
        //            this.ServiceResult.MessageCode = "MV90001";//data already exists
        //        }
        //        else
        //        {
        //            entity.UpdatedDate = DateTime.Now;
        //            entity.UpdatedUserId = entity.CreatedUserId;
        //            LOMORM00004 insuran = GetINSURAN(entity, false);
              
        //            this.iNSURANDAO.Update(insuran);
        //            Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> { { "INSUCODE", insuran.INSUCODE }, { "INSUDESP", insuran.INSUDESP }, { "UpdatedDate", insuran.UpdatedDate }, { "UpdatedUserId", insuran.UpdatedUserId } };
        //            Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "INSUCODE", insuran.INSUCODE }, { "Active", true } };
        //            CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("LOMORM00004", updateColumnsandValues, whereColumnsandValues));

        //            this.ServiceResult.ErrorOccurred = false;
        //            this.ServiceResult.MessageCode = "MI90002";//Update Success
        //            this.SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.INSUCODE);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        this.ServiceResult.ErrorOccurred = true;
        //        this.ServiceResult.MessageCode = "ME90036";
        //    }
        //}

        //[Transaction(TransactionPropagation.Required)]
        //public virtual void Delete(IList<LOMDTO00004> itemList)
        //{
        //    try
        //    {
        //        foreach (LOMDTO00004 item in itemList)
        //        {
        //            item.UpdatedUserId = CurrentUserEntity.CurrentUserID;
        //            item.UpdatedDate = DateTime.Now;
        //            this.iNSURANDAO.Delete(GetINSURAN(item, true), false);

        //            this.SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), item.CreatedUserId, item.INSUCODE);
        //            CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("LOMORM00004", "INSUCODE", item.INSUCODE, item.CreatedUserId, item.TS));               
        //        }
        //        this.ServiceResult.ErrorOccurred = false;
        //        this.ServiceResult.MessageCode = "MI90003";//Delete Success
        //    }
        //    catch (Exception)
        //    {
        //        this.ServiceResult.ErrorOccurred = true;
        //        this.ServiceResult.MessageCode = "ME90036";
        //    }
        //}

        //public void SaveServerAndServerClient(LOMDTO00004 entity)
        //{
        //    LOMDTO00004 insuranceEntity = null;


        //    try
        //    {
        //        LOMORM00004 insurance = this.Save(entity);
        //        if (insurance != null)
        //            insuranceEntity = iNSURANDAO.SelectByINSUCODE(insurance.INSUCODE);
        //        if (insuranceEntity != null)
        //        {

        //            Dictionary<string, object> insuranKeyPair = new Dictionary<string, object> { { "INSUCODE", insuranceEntity.INSUCODE }, { "INSUDESP", insuranceEntity.INSUDESP } };
        //            CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("INSURAN", insuranKeyPair, insuranceEntity.TS, insuranceEntity.CreatedUserId, insuranceEntity.CreatedDate));
        //            this.ServiceResult.ErrorOccurred = false;
        //            this.ServiceResult.MessageCode = "MI90001";// Saving Successful  
        //        }
        //    }

        //    catch
        //    {
        //        //  AccountTypeDAO.Delete(accountypeEntity, true);
        //        this.ServiceResult.ErrorOccurred = true;
        //        if (!string.IsNullOrEmpty(this.ServiceResult.MessageCode))
        //            this.ServiceResult.MessageCode = this.ServiceResult.MessageCode;
        //        else
        //            this.ServiceResult.MessageCode = "ME90036";   //Error Occur!!! Please contact your administrator.
        //    }
        //}

        //#endregion
        #endregion

        #region NewCode
        public virtual IList<LOMDTO00004> GetAll()
        {
            return this.INSURANDAO.SelectAll();
        }

        public LOMDTO00004 SelectByINSUCODE(string iNSUCODE)
        {
            return this.INSURANDAO.SelectByINSUCODE(iNSUCODE);
        }

        public IList<LOMDTO00004> CheckExist2(string iNSUCODE, string desp)
        {
            return this.INSURANDAO.CheckExist2(iNSUCODE, desp);
        }

        public void SaveServerAndServerClient(LOMDTO00004 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {           
            try
            {
                LOMORM00004 insurance = this.Save(entity,dvcvList);
                if (insurance != null)
                {
                    if (insurance != null)
                    {
                        Dictionary<string, object> insuranKeyPair = new Dictionary<string, object> { 
                        { "INSUCODE", insurance.INSUCODE },
                        { "INSUDESP", insurance.INSUDESP } };
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("INSURAN", insuranKeyPair, insurance.TS, insurance.CreatedUserId, insurance.CreatedDate));
                        this.ServiceResult.ErrorOccurred = false;
                        this.ServiceResult.MessageCode = "MI90001";// Saving Successful  
                    }
                }
            }
            catch
            {
                //  AccountTypeDAO.Delete(accountypeEntity, true);
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";   //Error Occur!!! Please contact your administrator.
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual LOMORM00004 Save(LOMDTO00004 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMORM00004 insuranceORM = null;
            if (!entity.Active)  //Active = 0 , update nature
            {
                this.Update(entity, dvcvList, "Save");
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.INSUCODE);
                return null;
            }
            else //Active = 1 , insert nature  
            {
                insuranceORM = this.INSURANDAO.Save(this.GetINSURAN(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), entity.CreatedUserId, entity.INSUCODE);
            }
            return insuranceORM;
        }

        public virtual void Update(LOMDTO00004 entity, IList<DataVersionChangedValueDTO> dvcvList, string status)
        {
            try
            {
                LOMORM00004 insurance = this.UpdateServer(entity, dvcvList);
                if (!this.ServiceResult.ErrorOccurred)
                {
                    Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> {
                    { "INSUCODE", insurance.INSUCODE },
                    { "INSUDESP", insurance.INSUDESP },                     
					{ "Active", insurance.Active},
                    { "UpdatedUserId", insurance.UpdatedUserId },
                    { "UpdatedDate", DateTime.Now },
                    { "TS",insurance.TS }
                    };
                    Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "INSUCODE", insurance.INSUCODE } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("LOMORM00004", updateColumnsandValues, whereColumnsandValues));
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
        public virtual LOMORM00004 UpdateServer(LOMDTO00004 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMORM00004 advanceTypeEntity = null;

            if (this.INSURANDAO.CheckExist(entity.INSUCODE, entity.INSUDESP, true))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists
            }
            else
            {
                advanceTypeEntity = this.INSURANDAO.Update(this.GetINSURAN(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.INSUCODE);
            }
            return advanceTypeEntity;
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual void Delete(IList<LOMDTO00004> itemList)
        {
            try
            {
                foreach (LOMDTO00004 item in itemList)
                {
                    LOMORM00004 deletedEntity = this.DeleteServer(item);                                                             
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("LOMORM00004", "INSUCODE", item.INSUCODE, item.CreatedUserId, item.TS));
                }
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90003";//Delete Success
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";  //Error Occur!!! Please contact your administrator.
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual LOMORM00004 DeleteServer(LOMDTO00004 insuranceDTO)
        {
            LOMORM00004 insurance = this.GetINSURAN(insuranceDTO, true);
            LOMORM00004 deletedEntity = this.iNSURANDAO.Delete(insurance, false);
            SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), insuranceDTO.CreatedUserId, insuranceDTO.INSUCODE);
            return deletedEntity;
        }
        #endregion

        #region Helper Method

        private LOMORM00004 GetINSURAN(LOMDTO00004 iNSURANDTO, bool isDelete)
        {
            INSURANInfo = new LOMORM00004();

            INSURANInfo.INSUCODE = iNSURANDTO.INSUCODE;
            INSURANInfo.INSUDESP = iNSURANDTO.INSUDESP;
            INSURANInfo.TS = iNSURANDTO.TS;
            //INSURANInfo.CreatedUserId = CurrentUserEntity.CurrentUserID;
            INSURANInfo.CreatedUserId = iNSURANDTO.CreatedUserId;
            INSURANInfo.CreatedDate = DateTime.Now;
            //INSURANInfo.UpdatedUserId = CurrentUserEntity.CurrentUserID;
            INSURANInfo.UpdatedUserId = iNSURANDTO.UpdatedUserId;
            INSURANInfo.UpdatedDate = DateTime.Now;

            if (isDelete)
                INSURANInfo.Active = false;
            else
                INSURANInfo.Active = true;

            return INSURANInfo;
        }

        #endregion

        #region Data Version Update Service
        public void SaveOrUpdateClientDataVersion(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId, string dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
            LOMORM00004 InsuranceCodeORM = new LOMORM00004();

            //Require Data
            clientDataVersionDTO.ORMObjectName = InsuranceCodeORM;
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