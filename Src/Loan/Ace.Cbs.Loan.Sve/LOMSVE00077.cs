using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Core.DataModel;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Windows.CXServer.Utt;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Windows.Ix.Core.Ctr;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00077 : BaseService,ILOMSVE00077
    {
        #region Properties

        private ILOMDAO00077 lsProductTypeItemDAO;
        public ILOMDAO00077 LSProductTypeItemDAO
        {
            get { return this.lsProductTypeItemDAO; }
            set { this.lsProductTypeItemDAO = value; }
        }

        private ILOMDAO00078 farmLoanDAO;
        public ILOMDAO00078 FarmLoanDAO
        {
            get { return this.farmLoanDAO; }
            set { this.farmLoanDAO = value; }
        }

        private LOMORM00077 LSProductTypeItemInfo;

        #endregion

        public IList<LOMDTO00077> GetAll()
        {
            return this.LSProductTypeItemDAO.SelectAll();
        }

        public IList<LOMDTO00077> CheckExist2(string productCode, string lsBusinessCode, string umCode)
        {
            return this.LSProductTypeItemDAO.CheckExist2(productCode, lsBusinessCode, umCode);
        }

        #region Server Client Data Save,Update and Delete
        public void SaveServerAndServerClient(LOMDTO00077 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            try
            {
                LOMORM00077 lsProductTypeItemEntity = this.Save(entity, dvcvList);
                if (lsProductTypeItemEntity != null)
                {
                    if (!this.ServiceResult.ErrorOccurred)
                    {
                        Dictionary<string, object> lsProductTypeItemKeyPair = new Dictionary<string, object> {
                        { "LSProductTypeItemId", lsProductTypeItemEntity.LSProductTypeItemId},       
	                    { "ProductCode", lsProductTypeItemEntity.ProductCode },	                    
	                    { "LSBusinessCode", lsProductTypeItemEntity.LSBusinessCode },		                    
	                    { "UMCode", lsProductTypeItemEntity.UMCode },	  	                    
	                    { "DurationMonths", lsProductTypeItemEntity.DurationMonths },	                      
	                    { "USERNO", lsProductTypeItemEntity.USERNO },
                        { "DATE_TIME", lsProductTypeItemEntity.DATE_TIME } };
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("LSProductTypeItem", lsProductTypeItemKeyPair, lsProductTypeItemEntity.TS, lsProductTypeItemEntity.CreatedUserId, lsProductTypeItemEntity.CreatedDate));
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
        public virtual LOMORM00077 Save(LOMDTO00077 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMORM00077 lsProductTypeItem = null;
            if (!entity.Active)  //Active = 0 , update nature
            {
                this.Update(entity, dvcvList, "Save");
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId,entity.LSProductTypeItemId);
                return null;
            }
            else //Active = 1 , insert nature  
            {
                lsProductTypeItem = this.LSProductTypeItemDAO.Save(this.GetLSProductTypeItemData(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), entity.CreatedUserId, lsProductTypeItem.LSProductTypeItemId);
            }
            return lsProductTypeItem;
        }

        public virtual void Update(LOMDTO00077 entity, IList<DataVersionChangedValueDTO> dvcvList, string status)
        {
            try
            {
                LOMORM00077 lsProductTypeItem = this.UpdateServer(entity, dvcvList);
                if (!this.ServiceResult.ErrorOccurred)
                {
                    Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> {
                    { "ProductCode", lsProductTypeItem.ProductCode },
                    { "LSBusinessCode", lsProductTypeItem.LSBusinessCode },  
                    { "UMCode", lsProductTypeItem.UMCode },   
                    { "DurationMonths", lsProductTypeItem.DurationMonths },    
                    { "USERNO", lsProductTypeItem.USERNO },
                    { "DATE_TIME", lsProductTypeItem.DATE_TIME },
					{ "Active", lsProductTypeItem.Active},
                    { "UpdatedUserId", lsProductTypeItem.UpdatedUserId },
                    { "UpdatedDate", DateTime.Now },
                    { "TS",lsProductTypeItem.TS }
                    };
                    Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "LSProductTypeItemId", lsProductTypeItem.LSProductTypeItemId } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("LOMORM00077", updateColumnsandValues, whereColumnsandValues));
                    this.ServiceResult.ErrorOccurred = false;
                    if (status == "Update")
                        this.ServiceResult.MessageCode = "MI90002";//Update Success
                    else
                        this.ServiceResult.MessageCode = "MI90001";//Saving Successful   
                }
            }
            catch (Exception ex)
            {                
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual LOMORM00077 UpdateServer(LOMDTO00077 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMORM00077 lsProductTypeItemEntity = null;

            if (this.LSProductTypeItemDAO.CheckExist(entity.ProductCode,entity.LSBusinessCode,entity.UMCode, true))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists
            }
            else
            {
                lsProductTypeItemEntity = this.LSProductTypeItemDAO.Update(this.GetLSProductTypeItemData(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, lsProductTypeItemEntity.LSProductTypeItemId);
            }
            return lsProductTypeItemEntity;
        }

        #region Helper Method

        private LOMORM00077 GetLSProductTypeItemData(LOMDTO00077 lsProductTypeItemDTO, bool isDelete)
        {
            LSProductTypeItemInfo = new LOMORM00077();
            if (!String.IsNullOrEmpty(lsProductTypeItemDTO.LSProductTypeItemId))
            {
                LSProductTypeItemInfo.LSProductTypeItemId = lsProductTypeItemDTO.LSProductTypeItemId;
            }
            else
            {
                LSProductTypeItemInfo.LSProductTypeItemId = System.Guid.NewGuid().ToString();
            }
            LSProductTypeItemInfo.ProductCode = lsProductTypeItemDTO.ProductCode;
            LSProductTypeItemInfo.LSBusinessCode = lsProductTypeItemDTO.LSBusinessCode;
            LSProductTypeItemInfo.UMCode = lsProductTypeItemDTO.UMCode;
            LSProductTypeItemInfo.DurationMonths = lsProductTypeItemDTO.DurationMonths;
            LSProductTypeItemInfo.USERNO = lsProductTypeItemDTO.CreatedUserId.ToString();
            LSProductTypeItemInfo.DATE_TIME = DateTime.Now;
            LSProductTypeItemInfo.TS = lsProductTypeItemDTO.TS;

            LSProductTypeItemInfo.CreatedUserId = lsProductTypeItemDTO.CreatedUserId;
            LSProductTypeItemInfo.CreatedDate = DateTime.Now;

            LSProductTypeItemInfo.UpdatedUserId = lsProductTypeItemDTO.UpdatedUserId;
            LSProductTypeItemInfo.UpdatedDate = DateTime.Now;

            if (isDelete)
                LSProductTypeItemInfo.Active = false;
            else
                LSProductTypeItemInfo.Active = true;

            return LSProductTypeItemInfo;
        }

        #endregion

        #region Data Version Update Service
        public void SaveOrUpdateClientDataVersion(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId, string dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
            LOMORM00077 LSProductTypeItemORM = new LOMORM00077();

            //Require Data
            clientDataVersionDTO.ORMObjectName = LSProductTypeItemORM;
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
        public virtual void Delete(IList<LOMDTO00077> itemList)
        {
            try
            {
                foreach (LOMDTO00077 item in itemList)
                {
                    IList<LOMDTO00078> farmLoanList = this.FarmLoanDAO.CheckDataForDeleteLSProductType(item.UMCode,item.LSBusinessCode);
                    if (farmLoanList.Count == 0)
                    {
                        LOMORM00077 deletedEntity = this.DeleteServer(item);
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("LOMORM00077", "LSProductTypeItemId", item.LSProductTypeItemId, item.CreatedUserId, item.TS));
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
        public virtual LOMORM00077 DeleteServer(LOMDTO00077 lsProductTypeItemDTO)
        {
            LOMORM00077 lsProductTypeItem = this.GetLSProductTypeItemData(lsProductTypeItemDTO, true);
            LOMORM00077 deletedEntity = this.LSProductTypeItemDAO.Delete(lsProductTypeItem, false);
            SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), lsProductTypeItemDTO.CreatedUserId, lsProductTypeItemDTO.LSProductTypeItemId);
            return deletedEntity;
        }
    }
}
