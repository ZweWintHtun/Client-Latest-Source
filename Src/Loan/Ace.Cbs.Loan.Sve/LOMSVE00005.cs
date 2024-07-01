using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Dmd;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Windows.Core.DataModel;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.CXServer.Utt;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Windows.Ix.Core.Ctr;

namespace Ace.Cbs.Loan.Sve
{
    class LOMSVE00005 : BaseService, ILOMSVE00005
    {
        #region Properties

        private ILOMDAO00005  _LandDAO;
        public ILOMDAO00005 LandDAO
        {
            get { return this._LandDAO; }
            set { this._LandDAO = value; }
        }

        #endregion

        #region OldCode
        // #region Implementation...

        //[Transaction(TransactionPropagation.Required)]
        //public LOMORM00005 Save(LOMDTO00001 entity)
        //{
        //    LOMORM00005 temp = null;
        //    try
        //    {
        //        if (this.LandDAO.CheckExist(entity.Code, entity.Description, false))
        //        {
        //            this.ServiceResult.ErrorOccurred = true;
        //            this.ServiceResult.MessageCode = "MV90001";//data already exists                     
        //        }
        //        else
        //        {
        //            temp = this.LandDAO.Save(this.GetLand(entity, false));
        //            this.ServiceResult.MessageCode = "MI90001";// Saving Successful
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

        //public void SaveServerAndServerClient(LOMDTO00001 entity)
        //{
        //    LOMDTO00001 landEntity = null;
        //    try
        //    {
        //        LOMORM00005 code = this.Save(entity);
        //        if (code != null)
        //        {
        //            landEntity = this.LandDAO.SelectByCode(code.Code);
        //            if (landEntity != null)
        //            {
        //                Dictionary<string, object> keyPair = new Dictionary<string, object>
        //                {
        //                    {"LandCode", landEntity.Code},
        //                    {"LandDescription", landEntity.Description}
        //                };
        //                CXServiceWrapper.Instance.Invoke<ICXSVE00001>(
        //                    x => x.InsertServer(
        //                        "LAND",
        //                        keyPair,
        //                        landEntity.TS,
        //                        landEntity.CreatedUserId,
        //                        landEntity.CreatedDate
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

        //[Transaction(TransactionPropagation.Required)]
        //public void Delete(IList<LOMDTO00001> itemList)
        //{
        //    try
        //    {
        //        foreach (LOMDTO00001 item in itemList)
        //        {
        //            item.UpdatedUserId = CurrentUserEntity.CurrentUserID;
        //            item.UpdatedDate = DateTime.Now;
        //            this.LandDAO.Delete(GetLand(item, true), false);

        //            this.SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), item.CreatedUserId, item.Code);
        //            CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("LOMORM00005", "Code", item.Code, item.CreatedUserId, item.TS));
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
        //public IList<LOMDTO00001> SelectAll()
        //{
        //    return this.LandDAO.SelectAll();
        //}

        //[Transaction(TransactionPropagation.Required)]
        //public LOMDTO00001 SelectByLandCode(string LandCode)
        //{
        //    return this.LandDAO.SelectByCode(LandCode);
        //}        

        //[Transaction(TransactionPropagation.Required)]
        //public void Update(LOMDTO00001 entity, IList<DataVersionChangedValueDTO> dvcvList)
        //{
        //    try
        //    {
        //        if (this.LandDAO.CheckExist(entity.Code, entity.Description, true))
        //        {
        //            this.ServiceResult.ErrorOccurred = true;
        //            this.ServiceResult.MessageCode = "MV90001"; //Data already exists
        //        }
        //        else
        //        {
        //            entity.UpdatedDate = DateTime.Now;
        //            entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
        //            LOMORM00005 landORm = GetLand(entity, false);

        //            //Update to sql server
        //            this.LandDAO.ManualUpdate(landORm);

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

        //            CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("LOMORM00005", updateCol, whereCol));
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

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00001> SelectAll()
        {
            return this.LandDAO.SelectAll();
        }

        [Transaction(TransactionPropagation.Required)]
        public LOMDTO00001 SelectByLandCode(string LandCode)
        {
            return this.LandDAO.SelectByCode(LandCode);
        }

        public IList<LOMDTO00001> CheckExist2(string LandCode, string desp)
        {
            return this.LandDAO.CheckExist2(LandCode, desp);
        }

        public void SaveServerAndServerClient(LOMDTO00001 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {            
            try
            {
                LOMORM00005 code = this.Save(entity,dvcvList);
                if (code != null)
                {   //landEntity = this.LandDAO.SelectByCode(code.Code);
                    if (!this.ServiceResult.ErrorOccurred)
                    {
                        Dictionary<string, object> keyPair = new Dictionary<string, object>
                        {
                            {"LandCode", code.Code},
                            {"LandDescription", code.Description}
                        };
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001>(
                            x => x.InsertServer(
                                "LAND",
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
        public LOMORM00005 Save(LOMDTO00001 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMORM00005 temp = null;
            try
            {
                if (!entity.Active)  //Active = 0 , update nature
                {
                    this.Update(entity, dvcvList, "Save");
                    SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Code);
                    return null;                    
                }
                else  //Active = 1 , insert nature  
                {
                    temp = this.LandDAO.Save(this.GetLand(entity, false));                    
                    this.SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), temp.CreatedUserId, temp.Code);
                }
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";
            }
            return temp;
        }

        [Transaction(TransactionPropagation.Required)]
        public void Update(LOMDTO00001 entity, IList<DataVersionChangedValueDTO> dvcvList, string status)
        {
            try
            {
                LOMORM00005 LandCode = this.UpdateServer(entity, dvcvList);
                if (!this.ServiceResult.ErrorOccurred)
                {
                    //Update to sqlite                    
                    Dictionary<string, object> updateCol = new Dictionary<string, object>
                    {
                        {"Code", LandCode.Code},
                        {"Description", LandCode.Description},
                        {"Active", LandCode.Active},
                        {"UpdatedDate", LandCode.UpdatedDate},
                        {"UpdatedUserId", LandCode.UpdatedUserId},                        
                        {"TS",LandCode.TS }
                    };
                    Dictionary<string, object> whereCol = new Dictionary<string, object>
                    {
                        {"Code", LandCode.Code}                       
                    };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("LOMORM00005", updateCol, whereCol));
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
        public virtual LOMORM00005 UpdateServer(LOMDTO00001 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMORM00005 LandEntity = null;

            if (this.LandDAO.CheckExist(entity.Code, entity.Description, true))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists
            }
            else
            {
                LandEntity = this.LandDAO.Update(this.GetLand(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Code);
            }
            return LandEntity;
        }

        [Transaction(TransactionPropagation.Required)]
        public void Delete(IList<LOMDTO00001> itemList)
        {
            try
            {
                foreach (LOMDTO00001 item in itemList)
                {
                    LOMORM00005 deletedEntity = this.DeleteServer(item);                      
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("LOMORM00005", "Code", item.Code, item.CreatedUserId, item.TS));
                }
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90003"; //Delete success
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";
                throw new Exception(this.ServiceResult.MessageCode);
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual LOMORM00005 DeleteServer(LOMDTO00001 LandCodeDTO)
        {
            LOMORM00005 businessCode = this.GetLand(LandCodeDTO, true);
            LOMORM00005 deletedEntity = this.LandDAO.Delete(businessCode, false);
            SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), LandCodeDTO.CreatedUserId, LandCodeDTO.Code);
            return deletedEntity;
        }

        #endregion

        #region Helper Methods
        //This methods will convert DTO to ORM...
        public LOMORM00005 GetLand(LOMDTO00001 LandDto, bool isDelete)
        {
            LOMORM00005 LandORM = new LOMORM00005();
            LandORM.Code = LandDto.Code;
            LandORM.Description = LandDto.Description;

            //---Default fields---//
            LandORM.TS = LandDto.TS;
            LandORM.CreatedDate = DateTime.Now;
            LandORM.CreatedUserId = LandDto.CreatedUserId;
            LandORM.UpdatedDate = DateTime.Now;
            LandORM.UpdatedUserId = LandDto.UpdatedUserId;

            if (isDelete)
                LandORM.Active = false;
            else
                LandORM.Active = true;

            return LandORM;
        }

        private void SaveOrUpdateClientDataVersion(DataAction dataAction, 
                                                    IList<DataVersionChangedValueDTO> dvcvList, 
                                                    int createdUserId, 
                                                    string dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDto = new ClientDataVersionDTO();
            LOMORM00005 landORM = new LOMORM00005();

            //Require Data
            clientDataVersionDto.ORMObjectName = landORM;
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
