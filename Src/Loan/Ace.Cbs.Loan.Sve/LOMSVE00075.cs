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

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00075 : BaseService, ILOMSVE00075
    {
        #region Properties

        private ILOMDAO00075 aGLoanProductTypeItemDAO;
        public ILOMDAO00075 AGLoanProductTypeItemDAO
        {
            get { return this.aGLoanProductTypeItemDAO; }
            set { this.aGLoanProductTypeItemDAO = value; }
        }

        private LOMORM00075 AGLoansInfo;

        #endregion

        public virtual IList<LOMDTO00075> GetAll()
        {
            return this.AGLoanProductTypeItemDAO.GetAllAGLoanProductTypeItem();
        }

        public LOMDTO00075 SelectByAGLoanProductTypeItemSeasonCode(string seasonCode)
        {
            return this.AGLoanProductTypeItemDAO.GetAllAGLoanProductTypeItemBySeasonCode(seasonCode);
        }

        public IList<LOMDTO00075> CheckExist2(string seasonCode)
        {
            return this.AGLoanProductTypeItemDAO.CheckExist2(seasonCode);
        }

        #region Server Client Data Save,Update and Delete
        public void SaveServerAndServerClient(LOMDTO00075 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            try
            {
                LOMORM00075 aGLoansEntity = this.Save(entity, dvcvList);
                if (aGLoansEntity != null)
                {
                    if (!this.ServiceResult.ErrorOccurred)
                    {
                        Dictionary<string, object> AGLoansKeyPair = new Dictionary<string, object> {
                        { "AGLoanProductTypeItemId", aGLoansEntity.AGLoanProductTypeItemId },
                        { "ProductCode", aGLoansEntity.ProductCode },	                    
                        { "SeasonCode", aGLoansEntity.SeasonCode},                 
                        { "UMCode", aGLoansEntity.UMCode },
                        { "SDay", aGLoansEntity.SDay},	                    
                        { "SMonth", aGLoansEntity.SMonth}, 
                        { "EDay", aGLoansEntity.EDay},	                    
                        { "EMonth", aGLoansEntity.EMonth},
                        { "DeadLineDay", aGLoansEntity.DeadLineDay},	                    
                        { "DeadLineMonth", aGLoansEntity.DeadLineMonth},                     
                        { "USERNO", aGLoansEntity.CreatedUserId},	                    
                        { "DATE_TIME", DateTime.Now }};
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("AGLoanProductTypeItem", AGLoansKeyPair, aGLoansEntity.TS, aGLoansEntity.CreatedUserId, aGLoansEntity.CreatedDate));
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
        public virtual LOMORM00075 Save(LOMDTO00075 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMORM00075 AGLoanProductType = null;
            if (!entity.Active)  //Active = 0 , update nature
            {
                this.Update(entity, dvcvList, "Save");
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.AGLoanProductTypeItemId);
                return null;
            }
            else //Active = 1 , insert nature  
            {
                AGLoanProductType = this.AGLoanProductTypeItemDAO.Save(this.GetAGLoansData(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), entity.CreatedUserId, AGLoanProductType.AGLoanProductTypeItemId);
            }
            return AGLoanProductType;
        }

        public virtual void Update(LOMDTO00075 entity, IList<DataVersionChangedValueDTO> dvcvList, string status)
        {
            try
            {
                LOMORM00075 aGLoans = this.UpdateServer(entity, dvcvList);
                if (!this.ServiceResult.ErrorOccurred)
                {
                    Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> {
                        { "ProductCode", aGLoans.ProductCode },	                    
                        { "SeasonCode", aGLoans.SeasonCode },                 
                        { "UMCode", aGLoans.UMCode },
                        { "SDay", aGLoans.SDay},	                    
                        { "SMonth", aGLoans.SMonth}, 
                        { "EDay", aGLoans.EDay},	                    
                        { "EMonth", aGLoans.EMonth},
                        { "DeadLineDay", aGLoans.DeadLineDay},	                    
                        { "DeadLineMonth", aGLoans.DeadLineMonth},                     
                        { "USERNO", aGLoans.CreatedUserId},	                    
                        { "DATE_TIME", DateTime.Now },                   
                        { "Active", aGLoans.Active},
                        { "UpdatedUserId", aGLoans.UpdatedUserId },
                        { "UpdatedDate", DateTime.Now },
                        { "TS",aGLoans.TS }};
                    Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "SeasonCode", aGLoans.SeasonCode } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("LOMORM00075", updateColumnsandValues, whereColumnsandValues));
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
        public virtual LOMORM00075 UpdateServer(LOMDTO00075 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMORM00075 AGLoansEntity = null;

            if (this.AGLoanProductTypeItemDAO.CheckExist(entity.SeasonCode, true))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists
            }
            else
            {
                AGLoansEntity = this.AGLoanProductTypeItemDAO.Update(this.GetAGLoansDataForDeleteUpdate(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.AGLoanProductTypeItemId);
            }
            return AGLoansEntity;
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual void Delete(IList<LOMDTO00075> itemList)
        {
            try
            {
                foreach (LOMDTO00075 item in itemList)
                {
                    LOMORM00075 deletedEntity = this.DeleteServer(item);
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("LOMORM00075", "SeasonCode", item.SeasonCode, item.CreatedUserId, item.TS));
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
        public virtual LOMORM00075 DeleteServer(LOMDTO00075 aGLoansDTO)
        {
            LOMORM00075 aGLoans = this.GetAGLoansDataForDeleteUpdate(aGLoansDTO, true);
            LOMORM00075 deletedEntity = this.AGLoanProductTypeItemDAO.Delete(aGLoans, false);
            SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), aGLoansDTO.CreatedUserId, aGLoansDTO.AGLoanProductTypeItemId);
            return deletedEntity;
        }

        #region Helper Method

        private LOMORM00075 GetAGLoansData(LOMDTO00075 aGLoansDTO, bool isDelete)
        {
            AGLoansInfo = new LOMORM00075();

            AGLoansInfo.AGLoanProductTypeItemId = System.Guid.NewGuid().ToString();
            AGLoansInfo.ProductCode = aGLoansDTO.ProductCode;
            AGLoansInfo.SeasonCode = aGLoansDTO.SeasonCode;
            AGLoansInfo.UMCode = aGLoansDTO.UMCode;
            AGLoansInfo.SDay = aGLoansDTO.SDay;
            AGLoansInfo.SMonth = aGLoansDTO.SMonth;
            AGLoansInfo.EDay = aGLoansDTO.EDay;
            AGLoansInfo.EMonth = aGLoansDTO.EMonth;
            AGLoansInfo.DeadLineDay = aGLoansDTO.DeadLineDay;
            AGLoansInfo.DeadLineMonth = aGLoansDTO.DeadLineMonth;
            AGLoansInfo.USERNO = aGLoansDTO.CreatedUserId.ToString();
            AGLoansInfo.DATE_TIME = DateTime.Now;
            AGLoansInfo.TS = aGLoansDTO.TS;

            AGLoansInfo.CreatedUserId = aGLoansDTO.CreatedUserId;
            AGLoansInfo.CreatedDate = DateTime.Now;

            AGLoansInfo.UpdatedUserId = aGLoansDTO.UpdatedUserId;
            AGLoansInfo.UpdatedDate = DateTime.Now;

            if (isDelete)
                AGLoansInfo.Active = false;
            else
                AGLoansInfo.Active = true;

            return AGLoansInfo;
        }

        private LOMORM00075 GetAGLoansDataForDeleteUpdate(LOMDTO00075 aGLoansDTO, bool isDelete)
        {
            AGLoansInfo = new LOMORM00075();

            AGLoansInfo.AGLoanProductTypeItemId = aGLoansDTO.AGLoanProductTypeItemId;
            AGLoansInfo.ProductCode = aGLoansDTO.ProductCode;
            AGLoansInfo.SeasonCode = aGLoansDTO.SeasonCode;
            AGLoansInfo.UMCode = aGLoansDTO.UMCode;
            AGLoansInfo.SDay = aGLoansDTO.SDay;
            AGLoansInfo.SMonth = aGLoansDTO.SMonth;
            AGLoansInfo.EDay = aGLoansDTO.EDay;
            AGLoansInfo.EMonth = aGLoansDTO.EMonth;
            AGLoansInfo.DeadLineDay = aGLoansDTO.DeadLineDay;
            AGLoansInfo.DeadLineMonth = aGLoansDTO.DeadLineMonth;
            AGLoansInfo.USERNO = aGLoansDTO.CreatedUserId.ToString();
            AGLoansInfo.DATE_TIME = DateTime.Now;
            AGLoansInfo.TS = aGLoansDTO.TS;

            AGLoansInfo.CreatedUserId = aGLoansDTO.CreatedUserId;
            AGLoansInfo.CreatedDate = DateTime.Now;

            AGLoansInfo.UpdatedUserId = aGLoansDTO.UpdatedUserId;
            AGLoansInfo.UpdatedDate = DateTime.Now;

            if (isDelete)
                AGLoansInfo.Active = false;
            else
                AGLoansInfo.Active = true;

            return AGLoansInfo;
        }

        #endregion

        #region Data Version Update Service
        public void SaveOrUpdateClientDataVersion(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId, string dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
            LOMORM00075 AGLoansORM = new LOMORM00075();

            //Require Data
            clientDataVersionDTO.ORMObjectName = AGLoansORM;
            clientDataVersionDTO.DataIdValue = dataValueId.ToString();
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
