using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.CXServer.Utt;
using Ace.Cbs.Cx.Com.Ctr;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Windows.Core.DataModel;
using Ace.Windows.Ix.Core.Ctr;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00069 : BaseService, ILOMSVE00069
    {
        #region Properties

        private ILOMDAO00069 stockItemDAO;
        public ILOMDAO00069 StockItemDAO
        {
            get { return this.stockItemDAO; }
            set { this.stockItemDAO = value; }
        }

        private LOMORM00069 StockItemInfo;

        #endregion

        public virtual IList<LOMDTO00069> GetAll()
        {
            return this.StockItemDAO.SelectAll();
        }

        public IList<LOMDTO00069> CheckExist2(string groupCode, string subCode, string desp)
        {
            return this.StockItemDAO.CheckExist2(groupCode, subCode, desp);
        }

        #region Server Client Data Save,Update and Delete
        public void SaveServerAndServerClient(LOMDTO00069 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            try
            {
                LOMORM00069 stockItemEntity = this.Save(entity, dvcvList);
                if (stockItemEntity != null)
                {
                    if (!this.ServiceResult.ErrorOccurred)
                    {
                        Dictionary<string, object> stockGroupKeyPair = new Dictionary<string, object> {
	                    { "GroupCode", stockItemEntity.GroupCode },	                    
	                    { "Description", stockItemEntity.Description },	                    
	                    { "SubCode", stockItemEntity.SubCode } };
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("StockItem", stockGroupKeyPair, stockItemEntity.TS, stockItemEntity.CreatedUserId, stockItemEntity.CreatedDate));
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
        public virtual LOMORM00069 Save(LOMDTO00069 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMORM00069 advance = null;
            if (!entity.Active)  //Active = 0 , update nature
            {
                this.Update(entity, dvcvList, "Save");
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.GroupCode);
                return null;
            }
            else //Active = 1 , insert nature  
            {
                advance = this.StockItemDAO.Save(this.GetAdvanceData(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), entity.CreatedUserId, entity.SubCode);
            }
            return advance;
        }

        public virtual void Update(LOMDTO00069 entity, IList<DataVersionChangedValueDTO> dvcvList, string status)
        {
            try
            {
                LOMORM00069 stockItem = this.UpdateServer(entity, dvcvList);
                if (!this.ServiceResult.ErrorOccurred)
                {
                    Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> {
                    { "GroupCode", stockItem.GroupCode },
                    { "Description", stockItem.Description },   
                    { "SubCode", stockItem.SubCode },
					{ "Active", stockItem.Active},
                    { "UpdatedUserId", stockItem.UpdatedUserId },
                    { "UpdatedDate", DateTime.Now },
                    { "TS",stockItem.TS }
                    };
                    Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "SubCode", stockItem.SubCode } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("LOMORM00069", updateColumnsandValues, whereColumnsandValues));
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
        public virtual LOMORM00069 UpdateServer(LOMDTO00069 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMORM00069 advanceTypeEntity = null;

            if (this.StockItemDAO.CheckExist(entity.GroupCode, entity.Description, entity.SubCode, true))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists
            }
            else
            {
                advanceTypeEntity = this.StockItemDAO.Update(this.GetAdvanceData(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.SubCode);
            }
            return advanceTypeEntity;
        }

        #region Helper Method

        private LOMORM00069 GetAdvanceData(LOMDTO00069 stockItemDTO, bool isDelete)
        {
            StockItemInfo = new LOMORM00069();

            StockItemInfo.GroupCode = stockItemDTO.GroupCode;
            StockItemInfo.Description = stockItemDTO.Description;
            StockItemInfo.SubCode = stockItemDTO.SubCode;
            StockItemInfo.TS = stockItemDTO.TS;

            StockItemInfo.CreatedUserId = stockItemDTO.CreatedUserId;
            StockItemInfo.CreatedDate = DateTime.Now;

            StockItemInfo.UpdatedUserId = stockItemDTO.UpdatedUserId;
            StockItemInfo.UpdatedDate = DateTime.Now;

            if (isDelete)
                StockItemInfo.Active = false;
            else
                StockItemInfo.Active = true;

            return StockItemInfo;
        }

        #endregion

        #region Data Version Update Service
        public void SaveOrUpdateClientDataVersion(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId, string dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
            LOMORM00069 StockItemORM = new LOMORM00069();

            //Require Data
            clientDataVersionDTO.ORMObjectName = StockItemORM;
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

        [Transaction(TransactionPropagation.Required)]
        public virtual void Delete(IList<LOMDTO00069> itemList)
        {
            try
            {
                foreach (LOMDTO00069 item in itemList)
                {
                    LOMORM00069 deletedEntity = this.DeleteServer(item);
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("LOMORM00069", "SubCode", item.SubCode, item.CreatedUserId, item.TS));
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
        public virtual LOMORM00069 DeleteServer(LOMDTO00069 stockItemDTO)
        {
            LOMORM00069 stockItem = this.GetAdvanceData(stockItemDTO, true);
            LOMORM00069 deletedEntity = this.StockItemDAO.Delete(stockItem, false);
            SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), stockItemDTO.CreatedUserId, stockItemDTO.SubCode);
            return deletedEntity;
        }
    }
}
