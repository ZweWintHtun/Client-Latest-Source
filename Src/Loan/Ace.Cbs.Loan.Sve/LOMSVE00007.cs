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
    ///Stock Service
    /// </summary>
    public class LOMSVE00007 : BaseService, ILOMSVE00007
    {
        #region Properties

        private ILOMDAO00009 _stocknoDAO;
        public ILOMDAO00009 StockDAO
        {
            get { return this._stocknoDAO; }
            set { this._stocknoDAO = value; }
        }

        private LOMORM00009 StockNoInfo;

        #endregion

        #region Logical Methods

        public virtual IList<LOMDTO00009> GetAll()
        {
            return this.StockDAO.SelectAll();
        }

        public LOMDTO00009 SelectByCode(string stockNo)
        {
            return this.StockDAO.SelectByCode(stockNo);
        }

        public IList<LOMDTO00009> CheckExist2(string stockNo, string stockName)
        {
            return this.StockDAO.CheckExist2(stockNo, stockName);
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual LOMORM00009 Save(LOMDTO00009 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMORM00009 nationality = null;
            try
            {
                if (!entity.Active)  //Active = 0 , update nature
                {
                    this.Update(entity, dvcvList, "Save");
                    SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.StockNo);
                    return null;
                }
                else //Active = 1 , insert nature  
                {
                    nationality = this.StockDAO.Save(this.GetStockNo(entity, false));

                    this.ServiceResult.MessageCode = "MI90001";// Saving Successful
                    this.SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), entity.CreatedUserId, entity.StockNo);
                }
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";  //Error Occur!!! Please contact your administrator.
            }
            return nationality;
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual void Update(LOMDTO00009 entity, IList<DataVersionChangedValueDTO> dvcvList, string status)
        {
            try
            {
                //if (this.StockDAO.CheckExist(entity.StockNo, entity.Name, true))
                //{
                //    this.ServiceResult.ErrorOccurred = true;
                //    this.ServiceResult.MessageCode = "MV90001";//data already exists
                //}
                LOMORM00009 stockno = this.UpdateServer(entity, dvcvList); 
                if(!this.ServiceResult.ErrorOccurred)
                {
                   // entity.UpdatedDate = DateTime.Now;
                  //  entity.UpdatedUserId = entity.CreatedUserId;
                 //   LOMORM00009 stockno = GetStockNo(entity, false);
                   // this.StockDAO.Update(stockno);
                  //  this.SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.StockNo);
                  //  if (!this.ServiceResult.ErrorOccurred)
                   // {
                        Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> 
                        { 
                            { "StockNo", stockno.StockNo }, 
                            { "Name", stockno.Name }, 
                            { "Active", stockno.Active},
                            { "UpdatedDate", stockno.UpdatedDate }, 
                            { "UpdatedUserId", stockno.UpdatedUserId } ,
                             { "TS",stockno.TS }};
                        
                        Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "StockNo", stockno.StockNo } };
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("LOMORM00009", updateColumnsandValues, whereColumnsandValues));

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
        public virtual LOMORM00009 UpdateServer(LOMDTO00009 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMORM00009 stockCodeEntity = null;

            if (this.StockDAO.CheckExist(entity.StockNo, entity.Name, true))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists
            }
            else
            {
                stockCodeEntity = this.StockDAO.Update(this.GetStockNo(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.StockNo);
            }
            return stockCodeEntity;
        }
        [Transaction(TransactionPropagation.Required)]
        public virtual void Delete(IList<LOMDTO00009> itemList)
        {
            try
            {
                foreach (LOMDTO00009 item in itemList)
                {
                
                    item.UpdatedUserId = item.UpdatedUserId;
                    item.UpdatedDate = DateTime.Now;
                    this.StockDAO.Delete(GetStockNo(item, true), false);
                    this.SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), item.CreatedUserId, item.StockNo);
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("LOMORM00009", "StockNo", item.StockNo, item.CreatedUserId, item.TS));

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



        #endregion

       #region Helper Method

        private LOMORM00009 GetStockNo(LOMDTO00009 stockNoDTO, bool isDelete)
        {
            StockNoInfo  = new LOMORM00009();

            StockNoInfo.StockNo = stockNoDTO.StockNo;
            StockNoInfo.Name = stockNoDTO.Name;

            StockNoInfo.TS = stockNoDTO.TS;
            StockNoInfo.CreatedUserId = stockNoDTO.CreatedUserId;
            StockNoInfo.CreatedDate = DateTime.Now;
            StockNoInfo.UpdatedUserId = stockNoDTO.UpdatedUserId;
            StockNoInfo.UpdatedDate = DateTime.Now;

            if (isDelete)
                StockNoInfo.Active = false;
            else
                StockNoInfo.Active = true;

            return StockNoInfo;
        }


        #endregion

       #region Data Version Update Service
        public void SaveOrUpdateClientDataVersion(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId, string dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
            LOMORM00009 StockCodeORM = new LOMORM00009();

            //Require Data
            clientDataVersionDTO.ORMObjectName = StockCodeORM;
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

        public void SaveServerAndServerClient(LOMDTO00009 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMDTO00009 stockNoEntity = null;


            try
            {
                LOMORM00009 stockNo = this.Save(entity, dvcvList);
                if (stockNo != null)
                    stockNoEntity = StockDAO.SelectByCode(stockNo.StockNo);
                if (stockNoEntity != null)
                {
                    if (!this.ServiceResult.ErrorOccurred)
                    {
                        Dictionary<string, object> stockNoKeyPair = new Dictionary<string, object> 
                        { 
                            { "STOCKNO", stockNoEntity.StockNo }, 
                            { "STOCKNAME", stockNoEntity.Name } 
                        };
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("STOCK", stockNoKeyPair, stockNoEntity.TS, stockNoEntity.CreatedUserId, stockNoEntity.CreatedDate));
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
