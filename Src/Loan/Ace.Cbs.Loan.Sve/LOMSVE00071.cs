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
    public class LOMSVE00071 : BaseService, ILOMSVE00071
    {
        #region Properties
        private ILOMDAO00071 seasoncodeDAO;
        public ILOMDAO00071 SeasonCodeDAO
        {
            get { return this.seasoncodeDAO; }
            set { this.seasoncodeDAO = value; }
        }

        private LOMORM00071 SeasonInfo;

        private ILOMDAO00075 agLoanProductTypeItemDAO;
        public ILOMDAO00075 AGLoanProductTypeItemDAO
        {
            get { return this.agLoanProductTypeItemDAO; }
            set { this.agLoanProductTypeItemDAO = value; }
        }

        private ILOMDAO00078 farmLoanDAO;
        public ILOMDAO00078 FarmLoanDAO
        {
            get { return this.farmLoanDAO; }
            set { this.farmLoanDAO = value; }
        }

        #endregion

        public virtual IList<LOMDTO00071> GetAll()
        {
            return this.SeasonCodeDAO.SelectAll();
        }

        public LOMDTO00071 SelectBySeasonCode(string seasonCode)
        {
            return this.SeasonCodeDAO.SelectBySeasonCode(seasonCode);
        }

        public IList<LOMDTO00071> CheckExist2(string seasonCode, string desp)
        {
            return this.SeasonCodeDAO.CheckExist2(seasonCode, desp);
        }

        #region Server Client Data Save,Update and Delete
        public void SaveServerAndServerClient(LOMDTO00071 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            try
            {
                LOMORM00071 seasonCodeEntity = this.Save(entity, dvcvList);
                if (seasonCodeEntity != null)
                {
                    if (!this.ServiceResult.ErrorOccurred)
                    {
                        Dictionary<string, object> seasonCodeKeyPair = new Dictionary<string, object> {
	                    { "SeasonCode", seasonCodeEntity.Code },	                    
	                    { "SeasonDesp", seasonCodeEntity.Description },
                        { "USERNO", seasonCodeEntity.CreatedUserId},	                    
	                    { "DATE_TIME", seasonCodeEntity.CreatedDate }};
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("SeasonCode", seasonCodeKeyPair, seasonCodeEntity.TS, seasonCodeEntity.CreatedUserId, seasonCodeEntity.CreatedDate));
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
        public virtual LOMORM00071 Save(LOMDTO00071 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMORM00071 seasonCode = null;
            if (!entity.Active)  //Active = 0 , update nature
            {
                this.Update(entity, dvcvList, "Save");
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Code);
                return null;
            }
            else //Active = 1 , insert nature  
            {
                seasonCode = this.SeasonCodeDAO.Save(this.GetseasonCodeData(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), entity.CreatedUserId, entity.Code);
            }
            return seasonCode;
        }

        public virtual void Update(LOMDTO00071 entity, IList<DataVersionChangedValueDTO> dvcvList, string status)
        {
            try
            {
                LOMORM00071 seasonCodeType = this.UpdateServer(entity, dvcvList);
                if (!this.ServiceResult.ErrorOccurred)
                {
                    Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> {
                    { "SeasonCode", seasonCodeType.Code },
                    { "SeasonDesp", seasonCodeType.Description },                                          
					{ "USERNO", seasonCodeType.USERNO},
                    { "DATE_TIME", seasonCodeType.DATE_TIME },
					{ "Active", seasonCodeType.Active},
                    { "UpdatedUserId", seasonCodeType.UpdatedUserId },
                    { "UpdatedDate", DateTime.Now },
                    { "TS",seasonCodeType.TS }
                    };
                    Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "SeasonCode", seasonCodeType.Code } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("LOMORM00071", updateColumnsandValues, whereColumnsandValues));
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
        public virtual LOMORM00071 UpdateServer(LOMDTO00071 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMORM00071 seasonCodeEntity = null;

            if (this.SeasonCodeDAO.CheckExist(entity.Code, entity.Description, true))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists
            }
            else
            {
                seasonCodeEntity = this.SeasonCodeDAO.Update(this.GetseasonCodeData(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Code);
            }
            return seasonCodeEntity;
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual void Delete(IList<LOMDTO00071> itemList)
        {
            try
            {
                foreach (LOMDTO00071 item in itemList)
                {
                    LOMORM00075 agProductTypeItem = this.AGLoanProductTypeItemDAO.GetAll().Where(x => x.SeasonCode.Equals(item.Code)).SingleOrDefault();
                    LOMORM00078 farmLoan = this.FarmLoanDAO.GetAll().Where(x => x.SeasonType.Equals(item.Code)).SingleOrDefault();
                    if (agProductTypeItem == null && farmLoan == null)
                    {
                        LOMORM00071 deletedEntity = this.DeleteServer(item);
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("LOMORM00071", "Code", item.Code, item.CreatedUserId, item.TS));
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
        public virtual LOMORM00071 DeleteServer(LOMDTO00071 seasonCodeDTO)
        {
            LOMORM00071 seasonCode = this.GetseasonCodeData(seasonCodeDTO, true);
            LOMORM00071 deletedEntity = this.SeasonCodeDAO.Delete(seasonCode, false);
            SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), seasonCodeDTO.CreatedUserId, seasonCodeDTO.Code);
            return deletedEntity;
        }

        #region Helper Method

        private LOMORM00071 GetseasonCodeData(LOMDTO00071 seasonCodeDTO, bool isDelete)
        {
            SeasonInfo = new LOMORM00071();

            SeasonInfo.Code = seasonCodeDTO.Code;
            SeasonInfo.Description = seasonCodeDTO.Description;
            SeasonInfo.TS = seasonCodeDTO.TS;
            SeasonInfo.USERNO = seasonCodeDTO.CreatedUserId.ToString();
            SeasonInfo.DATE_TIME = DateTime.Now;

            SeasonInfo.CreatedUserId = seasonCodeDTO.CreatedUserId;
            SeasonInfo.CreatedDate = DateTime.Now;

            SeasonInfo.UpdatedUserId = seasonCodeDTO.UpdatedUserId;
            SeasonInfo.UpdatedDate = DateTime.Now;

            if (isDelete)
                SeasonInfo.Active = false;
            else
                SeasonInfo.Active = true;

            return SeasonInfo;
        }

        #endregion

        #region Data Version Update Service
        public void SaveOrUpdateClientDataVersion(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId, string dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
            LOMORM00071 seasonCodeORM = new LOMORM00071();

            //Require Data
            clientDataVersionDTO.ORMObjectName = seasonCodeORM;
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
