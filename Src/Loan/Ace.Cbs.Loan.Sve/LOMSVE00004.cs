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
    /// <summary>
    /// GoodWill Code Service
    /// </summary>
    public class LOMSVE00004 : BaseService, ILOMSVE00004
    {

        #region Properties

        public ILOMDAO00006 GoodWillDAO { get; set; }
        private LOMORM00006 GoodWillCodeInfo;

        #endregion

        #region NewCode
        public virtual IList<LOMDTO00001> SelectAll()
        {
            return this.GoodWillDAO.SelectAll();
        }

        public LOMDTO00001 SelectByGoodCode(string goodWillCode)
        {
            return this.GoodWillDAO.SelectByCode(goodWillCode);
        }

        public IList<LOMDTO00001> CheckExist2(string goodWillCode, string desp)
        {
            return this.GoodWillDAO.CheckExist2(goodWillCode, desp);
        }
        
        public void SaveServerAndServerClient(LOMDTO00001 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {           
            try
            {
                LOMORM00006 goodWill = this.Save(entity,dvcvList);
                if (goodWill != null)
                {
                    if (!this.ServiceResult.ErrorOccurred)
                    {
                        Dictionary<string, object> businessKeyPair = new Dictionary<string, object> {
                        { "GoodWillCode", goodWill.Code },
                        { "GoodWillDescription", goodWill.Description } };
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("GOODWILL", businessKeyPair, goodWill.TS, goodWill.CreatedUserId, goodWill.CreatedDate));
                        this.ServiceResult.ErrorOccurred = false;
                        this.ServiceResult.MessageCode = "MI90001";// Saving Successful  
                    }
                }
            }
            catch
            {               
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";   //Error Occur!!! Please contact your administrator.
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual LOMORM00006 Save(LOMDTO00001 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMORM00006 GoodWillCode = null;
            if (!entity.Active) //Active = 0 , update nature
            {
                this.Update(entity, dvcvList, "Save");
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Code);
                return null;
            }            
            else  //Active = 1 , insert nature  
            {
                GoodWillCode = this.GoodWillDAO.Save(this.GetGoodWillCode(entity, false));                
                this.SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), entity.CreatedUserId, entity.Code);
            }            
            return GoodWillCode;
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual void Update(LOMDTO00001 entity, IList<DataVersionChangedValueDTO> dvcvList, string status)
        {
            try
            {
                LOMORM00006 goodWillCode = this.UpdateServer(entity, dvcvList);
                if(!this.ServiceResult.ErrorOccurred)
                {                   
                    Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> { 
                    { "Code", goodWillCode.Code },
                    { "Description", goodWillCode.Description }, 
                    { "Active", goodWillCode.Active},
                    { "UpdatedDate", goodWillCode.UpdatedDate }, 
                    { "UpdatedUserId", goodWillCode.UpdatedUserId },
                    { "TS",goodWillCode.TS }};
                    Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "Code", goodWillCode.Code } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("LOMORM00006", updateColumnsandValues, whereColumnsandValues));
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
        public virtual LOMORM00006 UpdateServer(LOMDTO00001 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMORM00006 businessCodeEntity = null;

            if (this.GoodWillDAO.CheckExist(entity.Code, entity.Description, true))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists
            }
            else
            {
                businessCodeEntity = this.GoodWillDAO.Update(this.GetGoodWillCode(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Code);
            }
            return businessCodeEntity;
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual void Delete(IList<LOMDTO00001> itemList)
        {
            try
            {
                foreach (LOMDTO00001 item in itemList)
                {
                    LOMORM00006 deletedEntity = this.DeleteServer(item);                     
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("LOMORM00006", "Code", item.Code, item.CreatedUserId, item.TS));                    
                }
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90003";//Delete Success
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";  //Error Occur!!! Please contact your administrator.
                throw new Exception(this.ServiceResult.MessageCode);
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual LOMORM00006 DeleteServer(LOMDTO00001 goodWillCodeDTO)
        {
            LOMORM00006 goodWillCode = this.GetGoodWillCode(goodWillCodeDTO, true);
            LOMORM00006 deletedEntity = this.GoodWillDAO.Delete(goodWillCode, false);
            SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), goodWillCodeDTO.CreatedUserId, goodWillCodeDTO.Code);
            return deletedEntity;
        }

        #endregion

        #region Helper Method
        private LOMORM00006 GetGoodWillCode(LOMDTO00001 goodWillCodeDTO, bool isDelete)
        {
            GoodWillCodeInfo = new LOMORM00006();

            GoodWillCodeInfo.Code = goodWillCodeDTO.Code;
            GoodWillCodeInfo.Description = goodWillCodeDTO.Description;
            GoodWillCodeInfo.TS = goodWillCodeDTO.TS;
            GoodWillCodeInfo.CreatedUserId = goodWillCodeDTO.CreatedUserId;
            GoodWillCodeInfo.CreatedDate = DateTime.Now;
            GoodWillCodeInfo.UpdatedUserId = goodWillCodeDTO.UpdatedUserId;
            GoodWillCodeInfo.UpdatedDate = DateTime.Now;

            if (isDelete)
                GoodWillCodeInfo.Active = false;
            else
                GoodWillCodeInfo.Active = true;

            return GoodWillCodeInfo;
        }
        #endregion

        #region Data Version Update Service
        public void SaveOrUpdateClientDataVersion(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId, string dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
            LOMORM00006 GoodWillCodeORM = new LOMORM00006();

            //Require Data
            clientDataVersionDTO.ORMObjectName = GoodWillCodeORM;
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
