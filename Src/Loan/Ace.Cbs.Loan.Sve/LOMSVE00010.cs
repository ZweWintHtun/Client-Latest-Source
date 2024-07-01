using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Ix.Core.Ctr;
using Ace.Windows.Core.DataModel;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Cbs.Cx.Com.Ctr;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00010 : BaseService, ILOMSVE00010
    {
        #region Properties
        private ILOMDAO00008 _gjkdao;
        public ILOMDAO00008 GJKDAO
        {
            get { return this._gjkdao; }
            set { this._gjkdao = value; }
        }

        private LOMORM00008 GjkInfo;
        #endregion

        #region OldCode

        //[Transaction(TransactionPropagation.Required)]
        //public void Delete(IList<LOMDTO00008> itemList)
        //{
        //    try
        //    {
        //        foreach (LOMDTO00008 item in itemList)
        //        {
        //            item.UpdatedUserId = CurrentUserEntity.CurrentUserID;
        //            item.UpdatedDate = DateTime.Now;
        //            this.GJKDAO.Delete(GetGjKind(item, true), false);

        //            this.SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), item.CreatedUserId, item.Kind);
        //            CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("LOMORM00008", "Kind", item.Kind, item.CreatedUserId, item.TS));
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

        //[Transaction(TransactionPropagation.Required)]
        //public LOMORM00008 Save(LOMDTO00008 entity)
        //{
        //    LOMORM00008 temp = null;
        //    try
        //    {
        //        if (this.GJKDAO.CheckExist(entity.Kind, entity.Description, false))
        //        {
        //            this.ServiceResult.ErrorOccurred = true;
        //            this.ServiceResult.MessageCode = "MV90001"; //data already exists                     
        //        }
        //        else
        //        {
        //            temp = this.GJKDAO.Save(this.GetGjKind(entity, false));
        //            this.ServiceResult.MessageCode = "MI90001"; // Saving Successful
        //            this.SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), temp.CreatedUserId, temp.Kind);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        this.ServiceResult.ErrorOccurred = true;
        //        this.ServiceResult.MessageCode = "ME90036";
        //    }
        //    return temp;
        //}

        //public void SaveServerAndServerClient(LOMDTO00008 entity)
        //{
        //    LOMDTO00008 gjtEntity = null;
        //    try
        //    {
        //        LOMORM00008 code = this.Save(entity);
        //        if (code != null)
        //        {
        //            gjtEntity = this.GJKDAO.SelectByGjKind(entity.Kind);
        //            if (gjtEntity != null)
        //            {
        //                Dictionary<string, object> keyPair = new Dictionary<string, object>
        //                {
        //                    {"Gjkind", gjtEntity.Kind},
        //                    {"Desp", gjtEntity.Description}
        //                };
        //                CXServiceWrapper.Instance.Invoke<ICXSVE00001>(
        //                    x => x.InsertServer(
        //                        "GJKCode",
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

        //public IList<LOMDTO00008> SelectAll()
        //{
        //    return this.GJKDAO.SelectAll();
        //}

        //public LOMDTO00008 SelectByGJKind(string kind)
        //{
        //    return this.GJKDAO.SelectByGjKind(kind);
        //}

        //public void Update(LOMDTO00008 entity, IList<DataVersionChangedValueDTO> dvcvList)
        //{
        //    try
        //    {
        //        if (this.GJKDAO.CheckExist(entity.Kind, entity.Description, true))
        //        {
        //            this.ServiceResult.ErrorOccurred = true;
        //            this.ServiceResult.MessageCode = "MV90001"; //Data already exists
        //        }
        //        else
        //        {
        //            entity.UpdatedDate = DateTime.Now;
        //            entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
        //            LOMORM00008 landORm = GetGjKind(entity, false);

        //            //Update to sql server
        //            this.GJKDAO.ManualUpdate(landORm);

        //            //Update to sqlite
        //            this.SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Kind);
        //            Dictionary<string, object> updateCol = new Dictionary<string, object>
        //            {
        //                {"Kind", entity.Kind},
        //                {"Description", entity.Description},
        //                {"UpdatedDate", entity.UpdatedDate},
        //                {"UpdatedUserId", entity.UpdatedUserId}
        //            };
        //            Dictionary<string, object> whereCol = new Dictionary<string, object>
        //            {
        //                {"Kind", entity.Kind},
        //                {"Active", true}
        //            };

        //            CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("LOMORM00008", updateCol, whereCol));
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

        #endregion

        #region NewCode
        
        public IList<LOMDTO00008> SelectAll()
        {
            return this.GJKDAO.SelectAll();
        }

        public LOMDTO00008 SelectByGJKind(string kind)
        {
            return this.GJKDAO.SelectByGjKind(kind);
        }

        public IList<LOMDTO00008> CheckExist2(string kind, string desp)
        {
            return this.GJKDAO.CheckExist2(kind, desp);
        }

        public void SaveServerAndServerClient(LOMDTO00008 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {            
            try
            {
                LOMORM00008 code = this.Save(entity, dvcvList);
                if (code != null)
                {                    
                    if (code != null)
                    {
                        Dictionary<string, object> keyPair = new Dictionary<string, object>
                        {
                            {"Gjkind", code.Kind},
                            {"Desp", code.Description}
                        };
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001>(
                            x => x.InsertServer(
                                "GJKCode",
                                keyPair,
                                code.TS,
                                code.CreatedUserId,
                                code.CreatedDate
                                ));
                        this.ServiceResult.ErrorOccurred = false;
                        this.ServiceResult.MessageCode = "MI90001";// Saving Successful
                    }
                }
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";   //Error Occur!!! Please contact your administrator.
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public LOMORM00008 Save(LOMDTO00008 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMORM00008 temp = null;
            if (!entity.Active)  //Active = 0 , update nature
            {
                this.Update(entity, dvcvList, "Save");
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Kind);
                return null;
            }
            else  //Active = 1 , insert nature  
            {
                temp = this.GJKDAO.Save(this.GetGjKind(entity, false));                
                this.SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), temp.CreatedUserId, temp.Kind);
            }           
            return temp;
        }

        public void Update(LOMDTO00008 entity, IList<DataVersionChangedValueDTO> dvcvList, string status)
        {
            try
            {
                LOMORM00008 gjkCode = this.UpdateServer(entity, dvcvList);
                if (!this.ServiceResult.ErrorOccurred)
                {  
                    Dictionary<string, object> updateCol = new Dictionary<string, object>
                    {
                        {"Kind", gjkCode.Kind},
                        {"Description", gjkCode.Description},
                        {"Active", gjkCode.Active},
                        {"UpdatedDate", gjkCode.UpdatedDate},
                        {"UpdatedUserId", gjkCode.UpdatedUserId},
                        { "TS",gjkCode.TS }
                    };
                    Dictionary<string, object> whereCol = new Dictionary<string, object>
                    {
                        {"Kind", entity.Kind}                        
                    };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("LOMORM00008", updateCol, whereCol));
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
        public virtual LOMORM00008 UpdateServer(LOMDTO00008 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMORM00008 gjkCodeEntity = null;

            if (this.GJKDAO.CheckExist(entity.Kind, entity.Description, true))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists
            }
            else
            {
                gjkCodeEntity = this.GJKDAO.Update(this.GetGjKind(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Kind);
            }
            return gjkCodeEntity;
        }

        [Transaction(TransactionPropagation.Required)]
        public void Delete(IList<LOMDTO00008> itemList)
        {
            try
            {
                foreach (LOMDTO00008 item in itemList)
                {
                    LOMORM00008 deletedEntity = this.DeleteServer(item);                     
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("LOMORM00008", "Kind", item.Kind, item.CreatedUserId, item.TS));
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
        public virtual LOMORM00008 DeleteServer(LOMDTO00008 gjkCodeDTO)
        {
            LOMORM00008 gjkCode = this.GetGjKind(gjkCodeDTO, true);
            LOMORM00008 deletedEntity = this.GJKDAO.Delete(gjkCode, false);
            SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), gjkCodeDTO.CreatedUserId, gjkCodeDTO.Kind);
            return deletedEntity;
        }

        #endregion

        #region Helper Methods

        private LOMORM00008 GetGjKind(LOMDTO00008 GjkDto, bool isDelete)
        {
            GjkInfo = new LOMORM00008();

            GjkInfo.Kind = GjkDto.Kind;
            GjkInfo.Description = GjkDto.Description;
            GjkInfo.TS = GjkDto.TS;
            GjkInfo.CreatedUserId = GjkDto.CreatedUserId;
            GjkInfo.CreatedDate = DateTime.Now;
            GjkInfo.UpdatedUserId = GjkDto.UpdatedUserId;
            GjkInfo.UpdatedDate = DateTime.Now;

            if (isDelete)
                GjkInfo.Active = false;
            else
                GjkInfo.Active = true;

            return GjkInfo;
        }

        private void SaveOrUpdateClientDataVersion(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId, string dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDto = new ClientDataVersionDTO();
            LOMORM00008 GjtORM = new LOMORM00008();

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

