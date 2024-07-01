//----------------------------------------------------------------------
// <copyright file="SAMSVE00026.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Lenovo</CreatedUser>
// <CreatedDate>08/04/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Sam.Ctr.Sve;
using Ace.Cbs.Sam.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Core.Ctr;
using Ace.Windows.Core.DataModel;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Core.Ctr;

namespace Ace.Cbs.Sam.Sve
{
    /// <summary>
    /// RemitBr Service
    /// </summary>
    public class SAMSVE00026 : BaseService, ISAMSVE00026
    {
        #region Properties

        private ITLMDAO00028 remitBrDAO;
        public ITLMDAO00028 RemitBrDAO
        {
            get { return this.remitBrDAO; }
            set { this.remitBrDAO = value; }
        }

        private ISAMDAO00004 branchDAOForAll;
        public ISAMDAO00004 BranchDAOForAll
        {
            get { return this.branchDAOForAll; }
            set { this.branchDAOForAll = value; }
        }

        private ITLMDAO00032 rmitRateDAO;
        public ITLMDAO00032 RmitRateDAO
        {
            get { return this.rmitRateDAO; }
            set { this.rmitRateDAO = value; }
        }

        public TLMORM00028 RemitBrInfo;
        public TLMORM00032 RmitRateInfo;

        #endregion

        #region Logical Methods

        public TLMDTO00028 SelectById(string currency, string branchCode, string sourceBranch)
        {
            return this.RemitBrDAO.SelectByCode(currency, branchCode, sourceBranch);
        }

        public IList<TLMDTO00032> SelectItemlistById(int id)
        {
            return this.RmitRateDAO.SelectById(id);
        }

        public IList<BranchDTO> SelectAllBranch()
        {
            return this.BranchDAOForAll.SelectAllBranch();
        }

        //[Transaction(TransactionPropagation.Required)]
        //public virtual void Save(TLMDTO00028 entity, IList<TLMDTO00032> itemList, IList<DataVersionChangedValueDTO> dvcvList)
        //{
        //    try
        //    {
        //        int oldId = 0;
        //        bool isDelete = false;
        //        if (this.remitBrDAO.CheckExist(0, entity.BranchCode, entity.SourceBranchCode, entity.Currency))
        //        {
        //            oldId = entity.Id;
        //            isDelete = true;
        //        }

        //        this.RemitBrInfo = this.remitBrDAO.Save(this.GetRemitBr(entity, false));
        //        this.SaveOrUpdateClientDataVersionForRemitBR(DataAction.Insert, dvcvList, RemitBrInfo.CreatedUserId, RemitBrInfo.Id.ToString());
        //        if (RemitBrInfo != null)
        //        {
        //            foreach (TLMDTO00032 item in itemList)
        //            {
        //                TLMORM00032 rmitRate = this.rmitRateDAO.Save(this.GetRmitRate(item, RemitBrInfo.Id));

        //                this.SaveOrUpdateClientDataVersionForRmitRate(DataAction.Insert, dvcvList, rmitRate.CreatedUserId, rmitRate.Id.ToString());

        //            }
        //        }
        //        else
        //            throw new Exception("ME90036");

        //        if (isDelete)
        //        {
        //            TLMDTO00028 deleteEntity = new TLMDTO00028();
        //            deleteEntity.Id = oldId;
        //            deleteEntity.CreatedUserId = entity.CreatedUserId;
        //            this.Delete(deleteEntity);
        //        }

        //        this.ServiceResult.ErrorOccurred = false;
        //        this.ServiceResult.MessageCode = entity.Id == 0 ? "MI90001" : "MI90002";// Saving or Update Successful               
        //    }
        //    catch (Exception)
        //    {
        //        this.ServiceResult.ErrorOccurred = true;
        //        this.ServiceResult.MessageCode = "ME90036";
        //        throw new Exception(this.ServiceResult.MessageCode);
        //    }
        //}

        #endregion

        #region Helper Methods

        private TLMORM00028 GetRemitBr(TLMDTO00028 remitBrDTO, bool isDelete)
        {
            RemitBrInfo = new TLMORM00028();

            //RemitBrInfo.Id = 1;
            RemitBrInfo.Id = remitBrDTO.Id;
            RemitBrInfo.BranchCode = remitBrDTO.BranchCode;
            RemitBrInfo.TelaxCharges = remitBrDTO.TelaxCharges;
            RemitBrInfo.TTSerial = remitBrDTO.TTSerial;
            RemitBrInfo.DraftSerial = remitBrDTO.DraftSerial;
            RemitBrInfo.StateCode = remitBrDTO.StateCode;
            RemitBrInfo.DrawingAccount = remitBrDTO.DrawingAccount;
            RemitBrInfo.EncashAccount = remitBrDTO.EncashAccount;
            RemitBrInfo.IBSComAccount = remitBrDTO.IBSComAccount;
            RemitBrInfo.TelaxAccount = remitBrDTO.TelaxAccount;
            RemitBrInfo.IblSerial = remitBrDTO.IblSerial;
            RemitBrInfo.IRPOAccount = remitBrDTO.IRPOAccount;
            RemitBrInfo.UniqueIdentifier = remitBrDTO.UniqueIdentifier;
            RemitBrInfo.SourceBranchCode = remitBrDTO.SourceBranchCode;
            RemitBrInfo.Currency = remitBrDTO.Currency;
            RemitBrInfo.CreatedUserId = remitBrDTO.CreatedUserId;
            RemitBrInfo.CreatedDate = DateTime.Now;
            if (isDelete)
                RemitBrInfo.Active = false;
            else
                RemitBrInfo.Active = true;

            return RemitBrInfo;
        }

        private TLMORM00032 GetRmitRate(TLMDTO00032 rmitRateDTO, int id)
        {
            RmitRateInfo = new TLMORM00032();

            RmitRateInfo.Id = rmitRateDTO.Id;
            RmitRateInfo.RemitBrId = id;
            RmitRateInfo.BranchCode = rmitRateDTO.BranchCode;
            RmitRateInfo.StartNo = rmitRateDTO.StartNo;
            RmitRateInfo.EndNo = Convert.ToDecimal(rmitRateDTO.EndNo);
            RmitRateInfo.Rate = rmitRateDTO.Rate;
            RmitRateInfo.FixAmount = rmitRateDTO.FixAmount;
            RmitRateInfo.Discount = rmitRateDTO.Discount;
            RmitRateInfo.TrDiscount = rmitRateDTO.TrDiscount;
            RmitRateInfo.CsDiscount = rmitRateDTO.CsDiscount;
            RmitRateInfo.CsMinRate = rmitRateDTO.CsMinRate;
            RmitRateInfo.MinRate = rmitRateDTO.MinRate;
            //RmitRateInfo.UniqueId = rmitRateDTO.UniqueId;
            RmitRateInfo.SourceBranchCode = rmitRateDTO.SourceBranchCode;
            RmitRateInfo.Currency = rmitRateDTO.Currency;
            //RmitRateInfo.CreatedUserId = CurrentUserEntity.CurrentUserID;
            RmitRateInfo.CreatedUserId = rmitRateDTO.CreatedUserId;
            RmitRateInfo.CreatedDate = DateTime.Now;
            RmitRateInfo.Active = true;

            return RmitRateInfo;
        }

        #endregion

        #region Data Version Update Service
        public void SaveOrUpdateClientDataVersionForRemitBR(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId, string dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
            TLMORM00028 RemitBrORM = new TLMORM00028();

            //Require Data
            clientDataVersionDTO.ORMObjectName = RemitBrORM;
            //clientDataVersionDTO.DataIdValue = GlobalUtilities.ConvertClassPropertyToString(() => RemitBrORM.Id);
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

        public void SaveOrUpdateClientDataVersionForRmitRate(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId, string dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
            TLMORM00032 RemitRateORM = new TLMORM00032();

            //Require Data
            clientDataVersionDTO.ORMObjectName = RemitRateORM;
            clientDataVersionDTO.DataIdValue = dataValueId;
            //clientDataVersionDTO.DataIdValue = GlobalUtilities.ConvertClassPropertyToString(() => RemitRateORM.Id);
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

        #region Server Client Data Save,Update and Delete

        [Transaction(TransactionPropagation.Required)]
        public virtual TLMORM00028 SaveRemitBranch(TLMDTO00028 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            int oldId = 0;
            bool isDelete = false;
            if (this.remitBrDAO.CheckExist(0, entity.BranchCode, entity.SourceBranchCode, entity.Currency))
            {
                oldId = entity.Id;
                isDelete = true;
            }
            TLMORM00028 remitBrInfo = null;
            TLMDTO00028 remitBrInfoEntity = null;
            remitBrInfo = this.remitBrDAO.Save(this.GetRemitBr(entity,false));
            remitBrInfoEntity = this.RemitBrDAO.SelectById(remitBrInfo.Id, remitBrInfo.SourceBranchCode);
            this.SaveOrUpdateClientDataVersionForRemitBR(DataAction.Insert, dvcvList, entity.CreatedUserId, remitBrInfo.Id.ToString());
            Dictionary<string, object> remitbrKeyPair = new Dictionary<string, object> { { "Id", remitBrInfoEntity.Id }, { "BranchCode", remitBrInfoEntity.BranchCode }, { "TlxCharges", remitBrInfoEntity.TelaxCharges }, { "TTSerial", remitBrInfoEntity.TTSerial }, { "DrftSerial", remitBrInfoEntity.DraftSerial }, { "StateCode", remitBrInfoEntity.StateCode }, { "DrawAc", remitBrInfoEntity.DrawingAccount }, { "EncashAc", remitBrInfoEntity.EncashAccount }, { "IBSComAc", remitBrInfoEntity.IBSComAccount }, { "TelexAc", remitBrInfoEntity.TelaxAccount }, { "IBLSerial", remitBrInfoEntity.IblSerial }, { "IRPOAC", remitBrInfoEntity.IRPOAccount }, { "UId", remitBrInfoEntity.UniqueIdentifier }, { "SourceBr", remitBrInfoEntity.SourceBranchCode }, { "Cur", remitBrInfoEntity.Currency } };
            CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("RemitBr", remitbrKeyPair, remitBrInfoEntity.TS, remitBrInfoEntity.CreatedUserId, remitBrInfoEntity.CreatedDate));
            return remitBrInfo;
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual void SaveServerAndServerClient(TLMDTO00028 entity, IList<TLMDTO00032> itemList, IList<DataVersionChangedValueDTO> dvcvList)
        {
            try
            {
                int oldId = 0;
                bool isDelete = false;
                if (this.remitBrDAO.CheckExist(0, entity.BranchCode, entity.SourceBranchCode, entity.Currency))
                {
                    oldId = entity.Id;
                    isDelete = true;
                }
                TLMORM00028 remitBr = this.SaveRemitBranch(entity, dvcvList);
                if (remitBr != null)
                {
                    foreach (TLMDTO00032 item in itemList)
                    {
                        TLMORM00032 rmitRate = this.rmitRateDAO.Save(this.GetRmitRate(item, remitBr.Id));
                        //IList<TLMDTO00032> remitRateEntityList = null;
                        this.SaveOrUpdateClientDataVersionForRmitRate(DataAction.Insert, dvcvList, rmitRate.CreatedUserId, rmitRate.Id.ToString());
                        TLMDTO00032 data = this.RmitRateDAO.SelectByIdForSaveAppServer(rmitRate.Id);
                        Dictionary<string, object> remitRateKeyPair = new Dictionary<string, object> { { "Id", data.Id }, { "RemitBrId", data.RemitBrId }, { "BranchCode", data.BranchCode }, { "StartNo", data.StartNo }, { "EndNo", data.EndNo }, { "Rate", data.Rate }, { "FixAmt", data.FixAmount }, { "Discount", data.Discount }, { "TrDiscount", data.TrDiscount }, { "CsDiscount", data.CsDiscount }, { "CsMinRate", data.CsMinRate }, { "MinRate", data.MinRate }, { "UId", data.UniqueId }, { "SourceBr", data.SourceBranchCode }, { "Cur", data.Currency } };
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("RmitRate", remitRateKeyPair, data.TS, data.CreatedUserId, data.CreatedDate));
                        this.ServiceResult.ErrorOccurred = false;
                        this.ServiceResult.MessageCode = "MI90001";// Saving Successful 
                        //for (int i = 0; i < remitRateEntityList.Count; i++)
                        //{
                        //    Dictionary<string, object> remitRateKeyPair = new Dictionary<string, object> { { "Id", remitRateEntityList[i].Id }, { "RemitBrId", remitRateEntityList[i].RemitBrId }, { "BranchCode", remitRateEntityList[i].BranchCode }, { "StartNo", remitRateEntityList[i].StartNo }, { "EndNo", remitRateEntityList[i].EndNo }, { "Rate", remitRateEntityList[i].Rate }, { "FixAmt", remitRateEntityList[i].FixAmount },{ "Discount", remitRateEntityList[i].Discount }, { "TrDiscount", remitRateEntityList[i].TrDiscount },{ "CsDiscount", remitRateEntityList[i].CsDiscount }, { "CsMinRate", remitRateEntityList[i].CsMinRate },{ "MinRate", remitRateEntityList[i].MinRate }, { "UId", remitRateEntityList[i].UniqueId },{ "SourceBr", remitRateEntityList[i].SourceBranchCode }, { "Cur", remitRateEntityList[i].Currency }};
                        //    CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("RmitRate", remitRateKeyPair, remitRateEntityList[i].TS, remitRateEntityList[i].CreatedUserId, remitRateEntityList[i].CreatedDate));
                        //    this.ServiceResult.ErrorOccurred = false;
                        //    this.ServiceResult.MessageCode = "MI90001";// Saving Successful 
                        //}
                    }
                }
                else
                    throw new Exception("ME90036");

                if (isDelete)
                {

                    TLMDTO00028 deleteEntity = new TLMDTO00028();
                    deleteEntity.Status = "Update";
                    deleteEntity.Id = oldId;
                    deleteEntity.CreatedUserId = entity.CreatedUserId;
                    this.Delete(deleteEntity);
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = "MI90002";
                }
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual void Delete(TLMDTO00028 item)
        {
            try
            {
                if (this.remitBrDAO.DeleteById(item.Id, item.CreatedUserId))
                {
                    this.SaveOrUpdateClientDataVersionForRemitBR(DataAction.Delete, new List<DataVersionChangedValueDTO>(), item.CreatedUserId, item.Id.ToString());
                    string deleteId = item.Id.ToString();
                    TLMORM00028 remitbr = this.RemitBrDAO.Get(item.Id);
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("TLMORM00028", "Id", deleteId, remitbr.CreatedUserId, remitbr.TS));
                    IList<TLMDTO00032> rmitRateList = this.rmitRateDAO.SelectById(item.Id);
                    if (this.rmitRateDAO.DeleteById(item.Id, item.CreatedUserId))
                    {

                        foreach (TLMDTO00032 data in rmitRateList)
                        {
                            this.SaveOrUpdateClientDataVersionForRmitRate(DataAction.Delete, new List<DataVersionChangedValueDTO>(), item.CreatedUserId, data.Id.ToString());
                            string delId = data.Id.ToString();
                            TLMORM00032 rmitrate = RmitRateDAO.Get(data.Id);
                            CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("TLMORM00032", "Id", delId, item.CreatedUserId, rmitrate.TS));
                            //throw new Exception("ME90036");
                        }
                    }
                    if (string.IsNullOrEmpty(item.Status))
                    {
                        this.ServiceResult.ErrorOccurred = false;
                        this.ServiceResult.MessageCode = "MI90003";//Delete Success
                    }
                }
                else
                    throw new Exception("ME90036");
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