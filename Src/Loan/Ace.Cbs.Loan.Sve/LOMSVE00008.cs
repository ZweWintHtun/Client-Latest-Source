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
    ///KStock Service
    /// </summary>

    public class LOMSVE00008 : BaseService, ILOMSVE00008
    {
        #region Properties

        private ILOMDAO00010 _kstocknoDAO;
        public ILOMDAO00010 KStockDAO
        {
            get { return this._kstocknoDAO; }
            set { this._kstocknoDAO = value; }
        }

        private LOMORM00010 KStockNoInfo;

        #endregion

        #region Logical Methods

        public virtual IList<LOMDTO00010> GetAll()
        {
            return this.KStockDAO.SelectAll();
        }

        public LOMDTO00010 SelectByCode(string kstockNo)
        {
            return this.KStockDAO.SelectByCode(kstockNo);
        }

        public IList<LOMDTO00010> CheckExist2(string kstockNo, string kstockName)
        {
            return this.KStockDAO.CheckExist2(kstockNo, kstockName);
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual LOMORM00010 Save(LOMDTO00010 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMORM00010 kStock = null;
            
           
                if (!entity.Active)  //Active = 0 , update nature
                {
                    this.Update(entity, dvcvList, "Save");
                    SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.KStockNo);
                    return null;
                }
                else //Active = 1 , insert nature  
                {
                    kStock = this.KStockDAO.Save(this.GetKStockNo(entity, false));

                    this.ServiceResult.MessageCode = "MI90001";// Saving Successful
                    this.SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), entity.CreatedUserId, entity.KStockNo);
                }
            
            //catch (Exception)
            //{
            //    this.ServiceResult.ErrorOccurred = true;
            //    this.ServiceResult.MessageCode = "ME90036";  //Error Occur!!! Please contact your administrator.
            //}
            return kStock;
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual void Update(LOMDTO00010 entity, IList<DataVersionChangedValueDTO> dvcvList, string status)
        {
            try
            {
                //if (this.KStockDAO.CheckExist(entity.KStockNo, entity.Desp, true))
                //{
                //    this.ServiceResult.ErrorOccurred = true;
                //    this.ServiceResult.MessageCode = "MV90001";//data already exists
                //}
               // else

               // { 
                 //   entity.UpdatedDate = DateTime.Now;
                 //   entity.UpdatedUserId = entity.CreatedUserId;
                LOMORM00010 kstockno = this.UpdateServer(entity, dvcvList);
                   // this.KStockDAO.Update(kstockno);
                  //  this.SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.KStockNo);
                    if (!this.ServiceResult.ErrorOccurred)
                    {
                        Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> 
                        { 
                            { "KStockNo", kstockno.KStockNo }, 
                            { "Desp", kstockno.Desp }, 
                            { "Active", kstockno.Active},
                            { "UpdatedDate", kstockno.UpdatedDate }, 
                            { "UpdatedUserId", kstockno.UpdatedUserId},
                            { "TS",kstockno.TS }
                        };
                        Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "KStockNo", kstockno.KStockNo } };
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("LOMORM00010", updateColumnsandValues, whereColumnsandValues));

                        this.ServiceResult.ErrorOccurred = false;
                        if (status == "Update")
                            this.ServiceResult.MessageCode = "MI90002";//Update Success   
                        else
                            this.ServiceResult.MessageCode = "MI90001";//Saving Successful 
                        
                    }
               // }
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual void Delete(IList<LOMDTO00010> itemList)
        {
            try
            {
                foreach (LOMDTO00010 item in itemList)
                {
                    //item.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                    item.UpdatedUserId = item.UpdatedUserId;
                    item.UpdatedDate = DateTime.Now;
                    this.KStockDAO.Delete(GetKStockNo(item, true), false);
                    this.SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), item.CreatedUserId, item.KStockNo);
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("LOMORM00010", "KStockNo", item.KStockNo, item.CreatedUserId, item.TS));

                }
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90003";//Delete Success
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";  //Error Occur!!! Please contact your administrator.
                //throw new Exception(this.ServiceResult.MessageCode);
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual LOMORM00010 UpdateServer(LOMDTO00010 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMORM00010 businessCodeEntity = null;

            if (this.KStockDAO.CheckExist(entity.KStockNo, entity.Desp, true))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists
            }
            else
            {
                businessCodeEntity = this.KStockDAO.Update(this.GetKStockNo(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.KStockNo);
            }
            return businessCodeEntity;
        }


 #endregion


        #region Helper Method

        private LOMORM00010 GetKStockNo(LOMDTO00010 kstockNoDTO, bool isDelete)
        {
            KStockNoInfo = new LOMORM00010();

            KStockNoInfo.KStockNo = kstockNoDTO.KStockNo;
            KStockNoInfo.Desp = kstockNoDTO.Desp;

            KStockNoInfo.TS = kstockNoDTO.TS;
            KStockNoInfo.CreatedUserId = kstockNoDTO.CreatedUserId;
            KStockNoInfo.CreatedDate = DateTime.Now;
            KStockNoInfo.UpdatedUserId = kstockNoDTO.UpdatedUserId;
            KStockNoInfo.UpdatedDate = DateTime.Now;

            if (isDelete)
                KStockNoInfo.Active = false;
            else
                KStockNoInfo.Active = true;

            return KStockNoInfo;
        }


        #endregion

        #region Data Version Update Service
        public void SaveOrUpdateClientDataVersion(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId, string dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
            LOMORM00010 KStockCodeORM = new LOMORM00010();

            //Require Data
            clientDataVersionDTO.ORMObjectName = KStockCodeORM;
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

        public void SaveServerAndServerClient(LOMDTO00010 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMDTO00010 kstockNoEntity = null;


            try
            {
                LOMORM00010 kstockNo = this.Save(entity, dvcvList);
                if (kstockNo != null)
                    kstockNoEntity = KStockDAO.SelectByCode(kstockNo.KStockNo);
                if (kstockNoEntity != null)
                {
                    if (!this.ServiceResult.ErrorOccurred)
                    {
                        Dictionary<string, object> kstockNoKeyPair = new Dictionary<string, object> 
                        { 
                            { "KSTOCK", kstockNoEntity.KStockNo }, 
                            { "DESP", kstockNoEntity.Desp } 
                        };
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("KSTOCK", kstockNoKeyPair, kstockNoEntity.TS, kstockNoEntity.CreatedUserId, kstockNoEntity.CreatedDate));
                        this.ServiceResult.ErrorOccurred = false;
                        this.ServiceResult.MessageCode = "MI90001";// Saving Successful  
                    }
                }
            }

            catch
            {

                this.ServiceResult.ErrorOccurred = true;
                if (!string.IsNullOrEmpty(this.ServiceResult.MessageCode))
                    this.ServiceResult.MessageCode = this.ServiceResult.MessageCode;
                else
                    this.ServiceResult.MessageCode = "ME90036";   //Error Occur!!! Please contact your administrator.
            }
        }


    }
}
