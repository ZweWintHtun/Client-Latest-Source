using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.CXServer.Utt;
using Ace.Cbs.Cx.Com.Ctr;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Windows.Core.DataModel;
using Ace.Windows.Ix.Core.Ctr;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00068 : BaseService, ILOMSVE00068
    {
        #region Properties

        private ILOMDAO00068 stockGroupDAO;
        public ILOMDAO00068 StockGroupDAO
        {
            get { return this.stockGroupDAO; }
            set { this.stockGroupDAO = value; }
        }

        private LOMORM00068 StockGroupInfo;

        #endregion

        public virtual IList<LOMDTO00068> GetAll()
        {
            return this.StockGroupDAO.SelectAll();
        }

        public IList<LOMDTO00068> CheckExist2(string groupCode,string prefix, string desp)
        {
            return this.StockGroupDAO.CheckExist2(groupCode,prefix, desp);
        }

        #region Server Client Data Save,Update and Delete
        public void SaveServerAndServerClient(LOMDTO00068 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            try
            {
                LOMORM00068 stockGroupEntity = this.Save(entity, dvcvList);
                if (stockGroupEntity != null)
                {
                    if (!this.ServiceResult.ErrorOccurred)
                    {
                        Dictionary<string, object> stockGroupKeyPair = new Dictionary<string, object> {
	                    { "GroupCode", stockGroupEntity.GroupCode },	                    
	                    { "Description", stockGroupEntity.Description },	                    
	                    { "PreFix", stockGroupEntity.PreFix } };
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("StockGroup", stockGroupKeyPair, stockGroupEntity.TS, stockGroupEntity.CreatedUserId, stockGroupEntity.CreatedDate));
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
        public virtual LOMORM00068 Save(LOMDTO00068 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMORM00068 advance = null;
            if (!entity.Active)  //Active = 0 , update nature
            {
                this.Update(entity, dvcvList, "Save");
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.GroupCode);
                return null;
            }
            else //Active = 1 , insert nature  
            {
                advance = this.StockGroupDAO.Save(this.GetAdvanceData(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), entity.CreatedUserId, entity.GroupCode);
            }
            return advance;
        }

        public virtual void Update(LOMDTO00068 entity, IList<DataVersionChangedValueDTO> dvcvList, string status)
        {
            try
            {
                LOMORM00068 advanceType = this.UpdateServer(entity, dvcvList);
                if (!this.ServiceResult.ErrorOccurred)
                {
                    Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> {
                    { "GroupCode", advanceType.GroupCode },
                    { "Description", advanceType.Description },   
                    { "PreFix", advanceType.PreFix },
					{ "Active", advanceType.Active},
                    { "UpdatedUserId", advanceType.UpdatedUserId },
                    { "UpdatedDate", DateTime.Now },
                    { "TS",advanceType.TS }
                    };
                    Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "GroupCode", advanceType.GroupCode } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("LOMORM00068", updateColumnsandValues, whereColumnsandValues));
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
        public virtual LOMORM00068 UpdateServer(LOMDTO00068 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMORM00068 advanceTypeEntity = null;

            if (this.StockGroupDAO.CheckExist(entity.GroupCode, entity.Description,entity.PreFix, true))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists
            }
            else
            {
                advanceTypeEntity = this.StockGroupDAO.Update(this.GetAdvanceData(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.GroupCode);
            }
            return advanceTypeEntity;
        }

        #region Helper Method

        private LOMORM00068 GetAdvanceData(LOMDTO00068 stockGroupDTO, bool isDelete)
        {
            StockGroupInfo = new LOMORM00068();

            StockGroupInfo.GroupCode = stockGroupDTO.GroupCode;
            StockGroupInfo.Description = stockGroupDTO.Description;
            StockGroupInfo.PreFix = stockGroupDTO.PreFix;
            StockGroupInfo.TS = stockGroupDTO.TS;

            StockGroupInfo.CreatedUserId = stockGroupDTO.CreatedUserId;
            StockGroupInfo.CreatedDate = DateTime.Now;

            StockGroupInfo.UpdatedUserId = stockGroupDTO.UpdatedUserId;
            StockGroupInfo.UpdatedDate = DateTime.Now;

            if (isDelete)
                StockGroupInfo.Active = false;
            else
                StockGroupInfo.Active = true;

            return StockGroupInfo;
        }

        #endregion

        #region Data Version Update Service
        public void SaveOrUpdateClientDataVersion(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId, string dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
            LOMORM00068 StockGroupORM = new LOMORM00068();

            //Require Data
            clientDataVersionDTO.ORMObjectName = StockGroupORM;
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
        public virtual void Delete(IList<LOMDTO00068> itemList)
        {
            try
            {
                foreach (LOMDTO00068 item in itemList)
                {
                    LOMORM00068 deletedEntity = this.DeleteServer(item);
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("LOMORM00068", "GroupCode", item.GroupCode, item.CreatedUserId, item.TS));
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
        public virtual LOMORM00068 DeleteServer(LOMDTO00068 advanceTypeDTO)
        {
            LOMORM00068 advanceType = this.GetAdvanceData(advanceTypeDTO, true);
            LOMORM00068 deletedEntity = this.StockGroupDAO.Delete(advanceType, false);
            SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), advanceTypeDTO.CreatedUserId, advanceTypeDTO.GroupCode);
            return deletedEntity;
        }

    }
}
