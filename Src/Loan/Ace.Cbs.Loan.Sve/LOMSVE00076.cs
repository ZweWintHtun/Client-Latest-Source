using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Windows.Ix.Core.DataModel;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Windows.CXServer.Utt;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Windows.Core.DataModel;
using Ace.Windows.Ix.Core.Ctr;

namespace Ace.Cbs.Loan.Sve
{
    /// <summary>
    /// LSBusiness Code Service
    /// </summary>
    public class LOMSVE00076 : BaseService, ILOMSVE00076
    {
        #region Properties
        private ILOMDAO00076 _lsBusinessCodeDAO;
        public ILOMDAO00076 LiveStockTypeDAO
        {
            get { return this._lsBusinessCodeDAO; }
            set { this._lsBusinessCodeDAO = value; }
        }

        private LOMORM00076 LSBusinessCodeInfo;

        private ILOMDAO00077 lsProductTypeItemDAO;
        public ILOMDAO00077 LSProductTypeItemDAO
        {
            get { return this.lsProductTypeItemDAO; }
            set { this.lsProductTypeItemDAO = value; }
        }
        #endregion

        #region MainMethods
        public IList<LOMDTO00076> GetAll()
        {
            return this.LiveStockTypeDAO.SelectAll();
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual void Update(LOMDTO00076 entity, IList<DataVersionChangedValueDTO> dvcvList, string status)
        {
            try
            {
                LOMORM00076 lsBusinessCode = this.UpdateServer(entity, dvcvList);
                if (!this.ServiceResult.ErrorOccurred)
                {
                    Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> { 
                    { "Code", lsBusinessCode.Code },
                    { "Description", lsBusinessCode.Description }, 
                    { "UserNo", lsBusinessCode.UserNo }, 
                    { "Date_Time", lsBusinessCode.Date_Time },
                    { "Active", lsBusinessCode.Active},
                    { "UpdatedDate", lsBusinessCode.UpdatedDate }, 
                    { "UpdatedUserId", lsBusinessCode.UpdatedUserId },
                    { "TS",lsBusinessCode.TS }};
                    Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "Code", lsBusinessCode.Code } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("LOMORM00076", updateColumnsandValues, whereColumnsandValues));
                    this.ServiceResult.ErrorOccurred = false;
                    if (status == "Update")
                        this.ServiceResult.MessageCode = "MI90002";//Update Success
                    else
                        this.ServiceResult.MessageCode = "MI90001";//Saving Successful
                }
            }
            catch
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public LOMORM00076 UpdateServer(LOMDTO00076 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            try
            {
                LOMORM00076 lsBusinessCodeEntity = null;
                if (this.LiveStockTypeDAO.CheckExist(entity.Code, entity.Description, true))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV90001";//data already exists
                }
                else
                {
                    lsBusinessCodeEntity = this.LiveStockTypeDAO.Update(this.GetLsBusinessCode(entity, false));
                    SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Code);
                }
                return lsBusinessCodeEntity;
            }
            catch
            {
                throw;
            }
        }
        [Transaction(TransactionPropagation.Required)]
        public void Delete(IList<LOMDTO00076> itemList)
        {
            try
            {
                foreach (LOMDTO00076 item in itemList)
                {
                    LOMORM00077 lsProductTypeItem = this.LSProductTypeItemDAO.GetAll().Where(x => x.LSBusinessCode.Equals(item.Code)).SingleOrDefault();
                    if (lsProductTypeItem == null)
                    {
                        LOMORM00076 deletedEntity = this.DeleteServer(item);
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("LOMORM00076", "Code", item.Code, item.CreatedUserId, item.TS));
                    }
                    else
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = "ME90050";     //Cannot delete. Used by another record.
                        throw new Exception(this.ServiceResult.MessageCode);
                    }
                }
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90003";//Delete Success
            }
            catch (Exception ex)
            {
                if (ex.Message == "ME90050")
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME90050";     //Cannot delete. Used by another record.
                    throw new Exception(this.ServiceResult.MessageCode);
                }
                else
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME90036";     //Error Occur!!! Please contact your administrator.
                    throw new Exception(this.ServiceResult.MessageCode);
                }
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual LOMORM00076 DeleteServer(LOMDTO00076 lsBusinessCodeDTO)
        {
            try
            {
                LOMORM00076 lsBusinessCode = this.GetLsBusinessCode(lsBusinessCodeDTO, true);
                LOMORM00076 deletedEntity = this.LiveStockTypeDAO.Delete(lsBusinessCode, false);
                SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), lsBusinessCodeDTO.CreatedUserId, lsBusinessCodeDTO.Code);
                return deletedEntity;
            }
            catch
            {
                throw;
            }
        }

        public LOMDTO00076 SelectByLSBusinessCode(string LSBusinessCode)
        {
            try
            {
                return this.LiveStockTypeDAO.SelectByLsBusinessCode(LSBusinessCode);
            }
            catch
            {
                throw;
            }
        }
        public void SaveServerAndServerClient(LOMDTO00076 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            try
            {
                LOMORM00076 lsBusiness = this.Save(entity, dvcvList);
                if (lsBusiness != null)
                {
                    if (!this.ServiceResult.ErrorOccurred)
                    {
                        Dictionary<string, object> businessKeyPair = new Dictionary<string, object> {
                        { "LSBusinessCode", lsBusiness.Code },
                        { "LSBusinessDesp", lsBusiness.Description },
                        { "USERNO", lsBusiness.UserNo},
                        { "DATE_TIME", lsBusiness.Date_Time}};
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("LSBUSINESSTYPE", businessKeyPair, lsBusiness.TS, lsBusiness.CreatedUserId, lsBusiness.CreatedDate));
                        this.ServiceResult.ErrorOccurred = false;
                        this.ServiceResult.MessageCode = "MI90001";// Saving Successful                      
                    }
                }
            }
            catch
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";//Error Occur!!! Please contact your administrator.
            }
        }

        public IList<LOMDTO00076> CheckExist2(string LSBusinessCode, string description)
        {
            return this.LiveStockTypeDAO.CheckExist2(LSBusinessCode, description);
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual LOMORM00076 Save(LOMDTO00076 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMORM00076 lsBusinessCode = null;
            if (!entity.Active) //Active = 0 , update nature
            {
                this.Update(entity, dvcvList, "Save");
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Code);
                return null;
            }
            else  //Active = 1 , insert nature  
            {
                lsBusinessCode = this.LiveStockTypeDAO.Save(this.GetLsBusinessCode(entity, false));
                this.SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), entity.CreatedUserId, entity.Code);
            }
            return lsBusinessCode;
        }
        #endregion

        #region Helper Method
        private LOMORM00076 GetLsBusinessCode(LOMDTO00076 lsBusinessCodeDTO, bool isDelete)
        {
            LSBusinessCodeInfo = new LOMORM00076();

            LSBusinessCodeInfo.Code = lsBusinessCodeDTO.Code;
            LSBusinessCodeInfo.Description = lsBusinessCodeDTO.Description;
            LSBusinessCodeInfo.UserNo = lsBusinessCodeDTO.UserNo;
            LSBusinessCodeInfo.Date_Time = lsBusinessCodeDTO.Date_Time;
            LSBusinessCodeInfo.TS = lsBusinessCodeDTO.TS;
            LSBusinessCodeInfo.CreatedUserId = lsBusinessCodeDTO.CreatedUserId;
            LSBusinessCodeInfo.CreatedDate = DateTime.Now;
            LSBusinessCodeInfo.UpdatedUserId = lsBusinessCodeDTO.UpdatedUserId;
            LSBusinessCodeInfo.UpdatedDate = DateTime.Now;

            if (isDelete)
                LSBusinessCodeInfo.Active = false;
            else
                LSBusinessCodeInfo.Active = true;

            return LSBusinessCodeInfo;
        }
        #endregion

        #region Data Version Update Service
        public void SaveOrUpdateClientDataVersion(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId, string dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
            LOMORM00076 BusinessCodeORM = new LOMORM00076();

            //Require Data
            clientDataVersionDTO.ORMObjectName = BusinessCodeORM;
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
