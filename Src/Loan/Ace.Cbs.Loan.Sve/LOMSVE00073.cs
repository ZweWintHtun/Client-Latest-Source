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
    public class LOMSVE00073 : BaseService, ILOMSVE00073
    {
        #region Properties

        private ILOMDAO00073 umDAO;
        public ILOMDAO00073 UMDAO
        {
            get { return this.umDAO; }
            set { this.umDAO = value; }
        }

        private LOMORM00073 UMInfo;

        private ILOMDAO00077 lsProductTypeItemDAO;
        public ILOMDAO00077 LSProductTypeItemDAO
        {
            get { return this.lsProductTypeItemDAO; }
            set { this.lsProductTypeItemDAO = value; }
        }

        private ILOMDAO00075 agLoanProductTypeItemDAO;
        public ILOMDAO00075 AGLoanProductTypeItemDAO
        {
            get { return this.agLoanProductTypeItemDAO; }
            set { this.agLoanProductTypeItemDAO = value; }
        }
        #endregion

        public virtual IList<LOMDTO00073> GetAll()
        {
            return this.UMDAO.SelectAll();
        }

        public IList<LOMDTO00073> CheckExist2(string umCode, string desp)
        {
            return this.UMDAO.CheckExist2(umCode, desp);
        }

        public string SelectUMByUMCode(string umCode)
        {
            return this.UMDAO.SelectByUMCode(umCode).Select(x => x.UMDesp).SingleOrDefault();
        }

        #region Server Client Data Save,Update and Delete
        public void SaveServerAndServerClient(LOMDTO00073 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            try
            {
                LOMORM00073 umEntity = this.Save(entity, dvcvList);
                if (umEntity != null)
                {
                    if (!this.ServiceResult.ErrorOccurred)
                    {
                        Dictionary<string, object> umKeyPair = new Dictionary<string, object> {
	                    { "UMCode", umEntity.UMCode },	                    
	                    { "UMDesp", umEntity.UMDesp },	                    
	                    { "USERNO", umEntity.USERNO },
                        { "DATE_TIME", umEntity.DATE_TIME } };
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("UM", umKeyPair, umEntity.TS, umEntity.CreatedUserId, umEntity.CreatedDate));
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
        public virtual LOMORM00073 Save(LOMDTO00073 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMORM00073 um = null;
            if (!entity.Active)  //Active = 0 , update nature
            {
                this.Update(entity, dvcvList, "Save");
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.UMCode);
                return null;
            }
            else //Active = 1 , insert nature  
            {
                um = this.UMDAO.Save(this.GetUMData(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), entity.CreatedUserId, entity.UMCode);
            }
            return um;
        }

        public virtual void Update(LOMDTO00073 entity, IList<DataVersionChangedValueDTO> dvcvList, string status)
        {
            try
            {
                LOMORM00073 um = this.UpdateServer(entity, dvcvList);
                if (!this.ServiceResult.ErrorOccurred)
                {
                    Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> {
                    { "UMCode", um.UMCode },
                    { "UMDesp", um.UMDesp },   
                    { "USERNO", um.USERNO },
                    { "DATE_TIME", um.DATE_TIME },
					{ "Active", um.Active},
                    { "UpdatedUserId", um.UpdatedUserId },
                    { "UpdatedDate", DateTime.Now },
                    { "TS",um.TS }
                    };
                    Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "UMCode", um.UMCode } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("LOMORM00073", updateColumnsandValues, whereColumnsandValues));
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
        public virtual LOMORM00073 UpdateServer(LOMDTO00073 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMORM00073 umEntity = null;

            if (this.UMDAO.CheckExist(entity.UMCode, entity.UMDesp, true))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists
            }
            else
            {
                umEntity = this.UMDAO.Update(this.GetUMData(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.UMCode);
            }
            return umEntity;
        }

        #region Helper Method

        private LOMORM00073 GetUMData(LOMDTO00073 umDTO, bool isDelete)
        {
            UMInfo = new LOMORM00073();

            UMInfo.UMCode = umDTO.UMCode;
            UMInfo.UMDesp = umDTO.UMDesp;
            UMInfo.USERNO = umDTO.CreatedUserId.ToString();
            UMInfo.DATE_TIME = DateTime.Now;
            UMInfo.TS = umDTO.TS;

            UMInfo.CreatedUserId = umDTO.CreatedUserId;
            UMInfo.CreatedDate = DateTime.Now;

            UMInfo.UpdatedUserId = umDTO.UpdatedUserId;
            UMInfo.UpdatedDate = DateTime.Now;

            if (isDelete)
                UMInfo.Active = false;
            else
                UMInfo.Active = true;

            return UMInfo;
        }

        #endregion

        #region Data Version Update Service
        public void SaveOrUpdateClientDataVersion(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId, string dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
            LOMORM00073 UMORM = new LOMORM00073();

            //Require Data
            clientDataVersionDTO.ORMObjectName = UMORM;
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
        public virtual void Delete(IList<LOMDTO00073> itemList)
        {
            try
            {
                foreach (LOMDTO00073 item in itemList)
                {
                    LOMORM00077 lsProductTypeItem = this.LSProductTypeItemDAO.GetAll().Where(x => x.UMCode.Equals(item.UMCode)).SingleOrDefault();
                    LOMORM00075 agProductTypeItem = this.AGLoanProductTypeItemDAO.GetAll().Where(x => x.UMCode.Equals(item.UMCode)).SingleOrDefault();
                    if (lsProductTypeItem == null && agProductTypeItem == null)
                    {
                        LOMORM00073 deletedEntity = this.DeleteServer(item);
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("LOMORM00073", "UMCode", item.UMCode, item.CreatedUserId, item.TS));
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
        public virtual LOMORM00073 DeleteServer(LOMDTO00073 umDTO)
        {
            LOMORM00073 um = this.GetUMData(umDTO, true);
            LOMORM00073 deletedEntity = this.UMDAO.Delete(um, false);
            SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), umDTO.CreatedUserId, umDTO.UMCode);
            return deletedEntity;
        }

    }
}
