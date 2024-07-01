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
    public class LOMSVE00070 : BaseService, ILOMSVE00070
    {
        #region Properties

        private ILOMDAO00070 villageGroupDAO;
        public ILOMDAO00070 VillageGroupDAO
        {
            get { return this.villageGroupDAO; }
            set { this.villageGroupDAO = value; }
        }

        private LOMORM00070 VillageGroupInfo;


        private ILOMDAO00078 farmLoanDAO;
        public ILOMDAO00078 FarmLoanDAO
        {
            get { return this.farmLoanDAO; }
            set { this.farmLoanDAO = value; }
        }


        #endregion

        public virtual IList<LOMDTO00070> GetAll()
        {
            return this.VillageGroupDAO.SelectAll();
        }

        public IList<LOMDTO00070> CheckExist2(string villageCode, string desp)
        {
            return this.VillageGroupDAO.CheckExist2(villageCode, desp);
        }

        #region Server Client Data Save,Update and Delete
        public void SaveServerAndServerClient(LOMDTO00070 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            try
            {
                LOMORM00070 villageGroupEntity = this.Save(entity, dvcvList);
                if (villageGroupEntity != null)
                {
                    if (!this.ServiceResult.ErrorOccurred)
                    {
                        Dictionary<string, object> villageGroupKeyPair = new Dictionary<string, object> {
	                    { "VillageCode", villageGroupEntity.VillageCode },	                    
	                    { "Desp", villageGroupEntity.Desp },	                    
	                    { "USERNO", villageGroupEntity.USERNO },
                        { "DATE_TIME", villageGroupEntity.DATE_TIME } };
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("VillageGroupCode", villageGroupKeyPair, villageGroupEntity.TS, villageGroupEntity.CreatedUserId, villageGroupEntity.CreatedDate));
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
        public virtual LOMORM00070 Save(LOMDTO00070 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMORM00070 villageGroup = null;
            if (!entity.Active)  //Active = 0 , update nature
            {
                this.Update(entity, dvcvList, "Save");
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.VillageCode);
                return null;
            }
            else //Active = 1 , insert nature  
            {
                villageGroup = this.VillageGroupDAO.Save(this.GetVillageGroupData(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), entity.CreatedUserId, entity.VillageCode);
            }
            return villageGroup;
        }

        public virtual void Update(LOMDTO00070 entity, IList<DataVersionChangedValueDTO> dvcvList, string status)
        {
            try
            {
                LOMORM00070 villageGroup = this.UpdateServer(entity, dvcvList);
                if (!this.ServiceResult.ErrorOccurred)
                {
                    Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> {
                    { "VillageCode", villageGroup.VillageCode },
                    { "Desp", villageGroup.Desp },   
                    { "USERNO", villageGroup.USERNO },
                    { "DATE_TIME", villageGroup.DATE_TIME },
					{ "Active", villageGroup.Active},
                    { "UpdatedUserId", villageGroup.UpdatedUserId },
                    { "UpdatedDate", DateTime.Now },
                    { "TS",villageGroup.TS }
                    };
                    Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "VillageCode", villageGroup.VillageCode } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("LOMORM00070", updateColumnsandValues, whereColumnsandValues));
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
        public virtual LOMORM00070 UpdateServer(LOMDTO00070 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMORM00070 villageGroupEntity = null;

            if (this.VillageGroupDAO.CheckExist(entity.VillageCode, entity.Desp, true))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists
            }
            else
            {
                villageGroupEntity = this.VillageGroupDAO.Update(this.GetVillageGroupData(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.VillageCode);
            }
            return villageGroupEntity;
        }

        #region Helper Method

        private LOMORM00070 GetVillageGroupData(LOMDTO00070 villageGroupDTO, bool isDelete)
        {
            VillageGroupInfo = new LOMORM00070();

            VillageGroupInfo.VillageCode = villageGroupDTO.VillageCode;
            VillageGroupInfo.Desp = villageGroupDTO.Desp;
            VillageGroupInfo.USERNO = villageGroupDTO.CreatedUserId.ToString();
            VillageGroupInfo.DATE_TIME = DateTime.Now;
            VillageGroupInfo.TS = villageGroupDTO.TS;

            VillageGroupInfo.CreatedUserId = villageGroupDTO.CreatedUserId;
            VillageGroupInfo.CreatedDate = DateTime.Now;

            VillageGroupInfo.UpdatedUserId = villageGroupDTO.UpdatedUserId;
            VillageGroupInfo.UpdatedDate = DateTime.Now;

            if (isDelete)
                VillageGroupInfo.Active = false;
            else
                VillageGroupInfo.Active = true;

            return VillageGroupInfo;
        }

        #endregion

        #region Data Version Update Service
        public void SaveOrUpdateClientDataVersion(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId, string dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
            LOMORM00070 VillageGroupORM = new LOMORM00070();

            //Require Data
            clientDataVersionDTO.ORMObjectName = VillageGroupORM;
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
        public virtual void Delete(IList<LOMDTO00070> itemList)
        {
            try
            {
                foreach (LOMDTO00070 item in itemList)
                {
                    LOMORM00078 farmloan = this.FarmLoanDAO.GetAll().Where(x => x.Village.Equals(item.VillageCode)).SingleOrDefault();
                    if (farmloan == null)
                    {
                        LOMORM00070 deletedEntity = this.DeleteServer(item);
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("LOMORM00070", "VillageCode", item.VillageCode, item.CreatedUserId, item.TS));
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
        public virtual LOMORM00070 DeleteServer(LOMDTO00070 villageGroupDTO)
        {
            LOMORM00070 villageGroup = this.GetVillageGroupData(villageGroupDTO, true);
            LOMORM00070 deletedEntity = this.VillageGroupDAO.Delete(villageGroup, false);
            SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), villageGroupDTO.CreatedUserId, villageGroupDTO.VillageCode);
            return deletedEntity;
        }

    }
}
