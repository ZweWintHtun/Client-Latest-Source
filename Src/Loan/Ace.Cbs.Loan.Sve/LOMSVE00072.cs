using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Dmd;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Windows.Core.DataModel;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.CXServer.Utt;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Windows.Ix.Core.Ctr;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00072 : BaseService, ILOMSVE00072
    {
        #region Properties

        private ILOMDAO00072 cropTypeDAO;
        public ILOMDAO00072 CropTypeDAO
        {
            get { return this.cropTypeDAO; }
            set { this.cropTypeDAO = value; }
        }

        private LOMORM00072 CropTypeInfo;

        private ILOMDAO00078 farmLoanDAO;
        public ILOMDAO00078 FarmLoanDAO
        {
            get { return this.farmLoanDAO; }
            set { this.farmLoanDAO = value; }
        }
        #endregion

        public virtual IList<LOMDTO00072> GetAll()
        {
            return this.CropTypeDAO.SelectAll();
        }

        public IList<LOMDTO00072> CheckExist2(string cropCode, string desp)
        {
            return this.CropTypeDAO.CheckExist2(cropCode, desp);
        }

        #region Server Client Data Save,Update and Delete
        public void SaveServerAndServerClient(LOMDTO00072 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            try
            {
                LOMORM00072 cropTypeEntity = this.Save(entity, dvcvList);
                if (cropTypeEntity != null)
                {
                    if (!this.ServiceResult.ErrorOccurred)
                    {
                        Dictionary<string, object> cropTypeKeyPair = new Dictionary<string, object> {
	                    { "CropCode", cropTypeEntity.CropCode },	                    
	                    { "Desp", cropTypeEntity.Desp },	                    
	                    { "USERNO", cropTypeEntity.USERNO },
                        { "DATE_TIME", cropTypeEntity.DATE_TIME } };
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("CropType", cropTypeKeyPair, cropTypeEntity.TS, cropTypeEntity.CreatedUserId, cropTypeEntity.CreatedDate));
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
        public virtual LOMORM00072 Save(LOMDTO00072 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMORM00072 cropType = null;
            if (!entity.Active)  //Active = 0 , update nature
            {
                this.Update(entity, dvcvList, "Save");
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.CropCode);
                return null;
            }
            else //Active = 1 , insert nature  
            {
                cropType = this.CropTypeDAO.Save(this.GetCropTypeData(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), entity.CreatedUserId, entity.CropCode);
            }
            return cropType;
        }

        public virtual void Update(LOMDTO00072 entity, IList<DataVersionChangedValueDTO> dvcvList, string status)
        {
            try
            {
                LOMORM00072 cropType = this.UpdateServer(entity, dvcvList);
                if (!this.ServiceResult.ErrorOccurred)
                {
                    Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> {
                    { "CropCode", cropType.CropCode },
                    { "Desp", cropType.Desp },   
                    { "USERNO", cropType.USERNO },
                    { "DATE_TIME", cropType.DATE_TIME },
					{ "Active", cropType.Active},
                    { "UpdatedUserId", cropType.UpdatedUserId },
                    { "UpdatedDate", DateTime.Now },
                    { "TS",cropType.TS }
                    };
                    Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "CropCode", cropType.CropCode } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("LOMORM00072", updateColumnsandValues, whereColumnsandValues));
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
        public virtual LOMORM00072 UpdateServer(LOMDTO00072 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMORM00072 cropTypeEntity = null;

            if (this.CropTypeDAO.CheckExist(entity.CropCode, entity.Desp, true))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists
            }
            else
            {
                cropTypeEntity = this.CropTypeDAO.Update(this.GetCropTypeData(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.CropCode);
            }
            return cropTypeEntity;
        }

        #region Helper Method

        private LOMORM00072 GetCropTypeData(LOMDTO00072 cropTypeDTO, bool isDelete)
        {
            CropTypeInfo = new LOMORM00072();

            CropTypeInfo.CropCode = cropTypeDTO.CropCode;
            CropTypeInfo.Desp = cropTypeDTO.Desp;
            CropTypeInfo.USERNO = cropTypeDTO.CreatedUserId.ToString();
            CropTypeInfo.DATE_TIME = DateTime.Now;
            CropTypeInfo.TS = cropTypeDTO.TS;

            CropTypeInfo.CreatedUserId = cropTypeDTO.CreatedUserId;
            CropTypeInfo.CreatedDate = DateTime.Now;

            CropTypeInfo.UpdatedUserId = cropTypeDTO.UpdatedUserId;
            CropTypeInfo.UpdatedDate = DateTime.Now;

            if (isDelete)
                CropTypeInfo.Active = false;
            else
                CropTypeInfo.Active = true;

            return CropTypeInfo;
        }

        #endregion

        #region Data Version Update Service
        public void SaveOrUpdateClientDataVersion(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId, string dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
            LOMORM00072 CropTypeORM = new LOMORM00072();

            //Require Data
            clientDataVersionDTO.ORMObjectName = CropTypeORM;
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
        public virtual void Delete(IList<LOMDTO00072> itemList)
        {
            try
            {
                foreach (LOMDTO00072 item in itemList)
                {
                    LOMORM00078 farmLoan = this.FarmLoanDAO.GetAll().Where(x => x.BusinessType.Equals(item.CropCode)).SingleOrDefault();
                    if (farmLoan == null)
                    {
                        LOMORM00072 deletedEntity = this.DeleteServer(item);
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("LOMORM00072", "CropCode", item.CropCode, item.CreatedUserId, item.TS));
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
        public virtual LOMORM00072 DeleteServer(LOMDTO00072 cropTypeDTO)
        {
            LOMORM00072 cropType = this.GetCropTypeData(cropTypeDTO, true);
            LOMORM00072 deletedEntity = this.CropTypeDAO.Delete(cropType, false);
            SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), cropTypeDTO.CreatedUserId, cropTypeDTO.CropCode);
            return deletedEntity;
        }

    }
}
