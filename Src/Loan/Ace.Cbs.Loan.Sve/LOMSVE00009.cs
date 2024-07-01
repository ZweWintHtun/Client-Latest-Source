//----------------------------------------------------------------------
// <copyright file="LOMSVE00009.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KSW</CreatedUser>
// <CreatedDate>08/25/2014</CreatedDate>
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
    /// GJTCode Service
    /// </summary>
    public class LOMSVE00009 : BaseService, ILOMSVE00009
    {
        #region Properties

        private ILOMDAO00007 gjtDao;
        public ILOMDAO00007 GJTDAO
        {
            get { return this.gjtDao; }
            set { this.gjtDao = value; }
        }

        private LOMORM00007 GJTCodeInfo;

        #endregion

        #region OldCode

        //[Transaction(TransactionPropagation.Required)]
        //public IList<LOMDTO00007> SelectAll()
        //{
        //    return this.GJTDAO.SelectAll();
        //}

        //[Transaction(TransactionPropagation.Required)]
        //public LOMDTO00007 SelectByGJTCode(string GjtCode)
        //{
        //    return this.GJTDAO.SelectByGjtype(GjtCode);
        //}

        //[Transaction(TransactionPropagation.Required)]
        //public LOMORM00007 Save(LOMDTO00007 entity)
        //{
        //    LOMORM00007 temp = null;
        //    try
        //    {
        //        if (this.GJTDAO.CheckExist(entity.Code, entity.Description, false))
        //        {
        //            this.ServiceResult.ErrorOccurred = true;
        //            this.ServiceResult.MessageCode = "MV90001"; //data already exists                     
        //        }
        //        else
        //        {
        //            temp = this.GJTDAO.Save(this.GetGJTCode(entity, false));
        //            this.ServiceResult.MessageCode = "MI90001"; // Saving Successful
        //            this.SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), temp.CreatedUserId, temp.Code);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        this.ServiceResult.ErrorOccurred = true;
        //        this.ServiceResult.MessageCode = "ME90036";
        //    }
        //    return temp;
        //}        

        //[Transaction(TransactionPropagation.Required)]
        //public void Update(LOMDTO00007 entity, IList<DataVersionChangedValueDTO> dvcvList)
        //{
        //    try
        //    {
        //        if (this.GJTDAO.CheckExist(entity.Code, entity.Description, true))
        //        {
        //            this.ServiceResult.ErrorOccurred = true;
        //            this.ServiceResult.MessageCode = "MV90001"; //Data already exists
        //        }
        //        else
        //        {
        //            entity.UpdatedDate = DateTime.Now;
        //            entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
        //            LOMORM00007 gjtOrm = GetGJTCode(entity, false);

        //            //Update to sql server                    
        //            this.GJTDAO.ManualUpdate(gjtOrm);

        //            //Update to sqlite
        //            this.SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Code);
        //            Dictionary<string, object> updateCol = new Dictionary<string, object>
        //            {
        //                {"Code", entity.Code},
        //                {"Description", entity.Description},
        //                {"UpdatedUserId", entity.UpdatedUserId},
        //                {"UpdatedDate", entity.UpdatedDate}
        //            };
        //            Dictionary<string, object> whereCol = new Dictionary<string, object>
        //            {
        //                {"Code", entity.Code},
        //                {"Active", true}
        //            };

        //            CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("LOMORM00007", updateCol, whereCol));
        //            this.ServiceResult.ErrorOccurred = false;
        //            this.ServiceResult.MessageCode = "MI90002"; //Update successful                    

        //        }
        //    }
        //    catch (Exception)
        //    {
        //        this.ServiceResult.ErrorOccurred = true;
        //        this.ServiceResult.MessageCode = "ME90036";
        //    }
        //}

        //[Transaction(TransactionPropagation.Required)]
        //public virtual void Delete(IList<LOMDTO00007> itemList)
        //{
        //    try
        //    {
        //        foreach (LOMDTO00007 item in itemList)
        //        {
        //            item.UpdatedUserId = CurrentUserEntity.CurrentUserID;
        //            item.UpdatedDate = DateTime.Now;
        //            this.GJTDAO.Delete(GetGJTCode(item, true), false);

        //            this.SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), item.CreatedUserId, item.Code);
        //            CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("LOMORM00007", "Code", item.Code, item.CreatedUserId, item.TS));
        //        }
        //        this.ServiceResult.ErrorOccurred = false;
        //        this.ServiceResult.MessageCode = "MI90003"; //Delete success
        //    }
        //    catch (Exception)
        //    {
        //        this.ServiceResult.ErrorOccurred = true;
        //        this.ServiceResult.MessageCode = "ME90036";
        //    }
        //}

        //public void SaveServerAndServerClient(LOMDTO00007 entity)
        //{
        //    LOMDTO00007 gjtEntity = null;
        //    try
        //    {
        //        LOMORM00007 code = this.Save(entity);
        //        if (code != null)
        //        {
        //            gjtEntity = this.GJTDAO.SelectByGjtype(entity.Code);
        //            if (gjtEntity != null)
        //            {
        //                Dictionary<string, object> keyPair = new Dictionary<string, object>
        //                {
        //                    {"Gjtype", gjtEntity.Code},
        //                    {"Desp", gjtEntity.Description}
        //                };
        //                CXServiceWrapper.Instance.Invoke<ICXSVE00001>(
        //                    x => x.InsertServer(
        //                        "GJTCode",
        //                        keyPair,
        //                        gjtEntity.TS,
        //                        gjtEntity.CreatedUserId,
        //                        gjtEntity.CreatedDate
        //                        ));
        //                this.ServiceResult.ErrorOccurred = false;
        //                this.ServiceResult.MessageCode = "MI90001";// Saving Successful
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        this.ServiceResult.ErrorOccurred = true;
        //        if (!string.IsNullOrEmpty(this.ServiceResult.MessageCode))
        //            this.ServiceResult.MessageCode = this.ServiceResult.MessageCode;
        //        else
        //            this.ServiceResult.MessageCode = "ME90036";   //Error Occur!!! Please contact your administrator.
        //    }
        //}
        #endregion

        #region NewCode
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00007> SelectAll()
        {
            return this.GJTDAO.SelectAll();
        }

        [Transaction(TransactionPropagation.Required)]
        public LOMDTO00007 SelectByGJTCode(string GjtCode)
        {
            return this.GJTDAO.SelectByGjtype(GjtCode);
        }

        public IList<LOMDTO00007> CheckExist2(string GjtCode, string desp)
        {
            return this.GJTDAO.CheckExist2(GjtCode, desp);
        }

        public void SaveServerAndServerClient(LOMDTO00007 entity,IList<DataVersionChangedValueDTO> dvcvList)
        {            
            try
            {
                LOMORM00007 code = this.Save(entity,dvcvList);
                //if (code != null)
                //{                    
                    if (code != null)
                    {
                        Dictionary<string, object> keyPair = new Dictionary<string, object>
                        {
                            {"Gjtype", code.Code},
                            {"Desp", code.Description}
                        };
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001>(
                            x => x.InsertServer(
                                "GJTCode",
                                keyPair,
                                code.TS,
                                code.CreatedUserId,
                                code.CreatedDate
                                ));
                        this.ServiceResult.ErrorOccurred = false;
                        this.ServiceResult.MessageCode = "MI90001";// Saving Successful
                    }
                //}
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";   //Error Occur!!! Please contact your administrator.
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public LOMORM00007 Save(LOMDTO00007 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMORM00007 temp = null;
            if (!entity.Active)  //Active = 0 , update nature
            {
                this.Update(entity, dvcvList, "Save");
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Code);
                return null;                
            }
            else    //Active = 1 , insert nature  
            {
                temp = this.GJTDAO.Save(this.GetGJTCode(entity, false));                
                this.SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), temp.CreatedUserId, temp.Code);
            }           
            return temp;
        }

        [Transaction(TransactionPropagation.Required)]
        public void Update(LOMDTO00007 entity, IList<DataVersionChangedValueDTO> dvcvList, string status)
        {
            try
            {
                LOMORM00007 gjtCode = this.UpdateServer(entity, dvcvList);
                if (!this.ServiceResult.ErrorOccurred)
                {                    
                    Dictionary<string, object> updateCol = new Dictionary<string, object>
                    {
                        {"Code", gjtCode.Code},
                        {"Description", gjtCode.Description},
                        { "Active", gjtCode.Active},
                        {"UpdatedDate", gjtCode.UpdatedDate},
                        {"UpdatedUserId", gjtCode.UpdatedUserId},
                        { "TS",gjtCode.TS }
                    };
                    Dictionary<string, object> whereCol = new Dictionary<string, object>
                    {
                        {"Code", entity.Code},                       
                    };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("LOMORM00007", updateCol, whereCol));
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
        public virtual LOMORM00007 UpdateServer(LOMDTO00007 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMORM00007 GJTCodeEntity = null;

            if (this.GJTDAO.CheckExist(entity.Code, entity.Description, true))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists
            }
            else
            {
                GJTCodeEntity = this.GJTDAO.Update(this.GetGJTCode(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Code);
            }
            return GJTCodeEntity;
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual void Delete(IList<LOMDTO00007> itemList)
        {
            try
            {
                foreach (LOMDTO00007 item in itemList)
                {
                    LOMORM00007 deletedEntity = this.DeleteServer(item);                                           
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("LOMORM00007", "Code", item.Code, item.CreatedUserId, item.TS));
                }
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90003"; //Delete success
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual LOMORM00007 DeleteServer(LOMDTO00007 gJTCodeDTO)
        {
            LOMORM00007 gJTCode = this.GetGJTCode(gJTCodeDTO, true);
            LOMORM00007 deletedEntity = this.GJTDAO.Delete(gJTCode, false);
            SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), gJTCodeDTO.CreatedUserId, gJTCodeDTO.Code);
            return deletedEntity;
        }

        #endregion

        #region Helper Method

        private LOMORM00007 GetGJTCode(LOMDTO00007 gJTCodeDTO, bool isDelete)
        {
            GJTCodeInfo = new LOMORM00007();

            GJTCodeInfo.Code = gJTCodeDTO.Code;
            GJTCodeInfo.Description = gJTCodeDTO.Description;
            GJTCodeInfo.TS = gJTCodeDTO.TS;
            GJTCodeInfo.CreatedUserId = gJTCodeDTO.CreatedUserId;
            GJTCodeInfo.CreatedDate = DateTime.Now;
            GJTCodeInfo.UpdatedUserId = gJTCodeDTO.UpdatedUserId;
            GJTCodeInfo.UpdatedDate = DateTime.Now;

            if (isDelete)
                GJTCodeInfo.Active = false;
            else
                GJTCodeInfo.Active = true;

            return GJTCodeInfo;
        }

        private void SaveOrUpdateClientDataVersion( DataAction dataAction, 
                                                    IList<DataVersionChangedValueDTO> dvcvList, 
                                                    int createdUserId, 
                                                    string dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDto = new ClientDataVersionDTO();
            LOMORM00007 GjtORM = new LOMORM00007();

            //Require Data
            clientDataVersionDto.ORMObjectName = GjtORM;
            clientDataVersionDto.CreatedUserId = createdUserId;
            clientDataVersionDto.DataIdValue = dataValueId;

            //Change Data Content
            IList<ChangeDataContent> cdclist = new List<ChangeDataContent>();
            foreach (DataVersionChangedValueDTO dvcvDto in dvcvList)
            {
                ChangeDataContent cdcdto = new ChangeDataContent();
                cdcdto.Property = dvcvDto.OrmPropertyName;
                cdcdto.OldValue = dvcvDto.OrmPreviousValue;
                cdcdto.NewValue = dvcvDto.OrmNewValue;
                cdclist.Add(cdcdto);
            }

            //Save into sqlite db
            clientDataVersionDto.ChangeDataContentList = cdclist;
            CXServiceWrapper.Instance.Invoke<IDataVersionUpdateService, bool>(x => x.SaveOrUpdateClientDataVersion(clientDataVersionDto, dataAction));
        }
        #endregion
    }
}