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
    public class LOMSVE00074 : BaseService, ILOMSVE00074
    {
        #region Properties

        private ILOMDAO00074 productDAO;
        public ILOMDAO00074 ProductCodeDAO
        {
            get { return this.productDAO; }
            set { this.productDAO = value; }
        }

        private LOMORM00074 ProductInfo;

        #endregion       

        #region NewCode
        
        public virtual IList<LOMDTO00074> GetAll()
        {
            return this.ProductCodeDAO.SelectAll();
        }

        public LOMDTO00074 SelectByProductCode(string productCode)
        {
            return this.ProductCodeDAO.SelectByProductCode(productCode);
        }

        public IList<LOMDTO00074> CheckExist2(string productCode, string desp)
        {
            return this.ProductCodeDAO.CheckExist2(productCode, desp);
        }

        #region Server Client Data Save,Update and Delete
        public void SaveServerAndServerClient(LOMDTO00074 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {            
            try
            {                
                LOMORM00074 productEntity = this.Save(entity, dvcvList);
                if (productEntity != null)
                {
                    if (!this.ServiceResult.ErrorOccurred)
                    {
                        Dictionary<string, object> ProductCodeKeyPair = new Dictionary<string, object> {
	                    { "ProductCode", productEntity.Code },	                    
	                    { "ProductDesp", productEntity.Description },
                        { "USERNO", productEntity.USERNO},	                    
	                    { "DATE_TIME", productEntity.DATE_TIME }};
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("ProductCode", ProductCodeKeyPair, productEntity.TS, productEntity.CreatedUserId, productEntity.CreatedDate));
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
        public virtual LOMORM00074 Save(LOMDTO00074 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMORM00074 product = null;
            if (!entity.Active)  //Active = 0 , update nature
            {
                this.Update(entity, dvcvList, "Save");
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Code);
                return null;
            }
            else //Active = 1 , insert nature  
            {
                product = this.ProductCodeDAO.Save(this.GetProductCodeData(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), entity.CreatedUserId, entity.Code);
            }
            return product;
        }

        public virtual void Update(LOMDTO00074 entity, IList<DataVersionChangedValueDTO> dvcvList, string status)
        {
            try
            {
                LOMORM00074 productType = this.UpdateServer(entity, dvcvList);
                if (!this.ServiceResult.ErrorOccurred)
                {
                    Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> {
                    { "ProductCode", productType.Code },	                    
	                { "ProductDesp", productType.Description },
                    { "USERNO", productType.USERNO},	                    
	                { "DATE_TIME", productType.DATE_TIME },                 
					{ "Active", productType.Active},
                    { "UpdatedUserId", productType.UpdatedUserId },
                    { "UpdatedDate", DateTime.Now },
                    { "TS",productType.TS }
                    };
                    Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "ProductCode", productType.Code } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("LOMORM00074", updateColumnsandValues, whereColumnsandValues));
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
        public virtual LOMORM00074 UpdateServer(LOMDTO00074 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMORM00074 ProductCodeEntity = null;

            if (this.ProductCodeDAO.CheckExist(entity.Code, entity.Description, true))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists
            }
            else
            {
                ProductCodeEntity = this.ProductCodeDAO.Update(this.GetProductCodeData(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Code);
            }
            return ProductCodeEntity;
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual void Delete(IList<LOMDTO00074> itemList)
        {
            try
            {
                foreach (LOMDTO00074 item in itemList)
                {
                    LOMORM00074 deletedEntity = this.DeleteServer(item); 
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("LOMORM00074", "Code", item.Code, item.CreatedUserId, item.TS));
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
        public virtual LOMORM00074 DeleteServer(LOMDTO00074 ProductCodeDTO)
        {
            LOMORM00074 ProductCode = this.GetProductCodeData(ProductCodeDTO, true);
            LOMORM00074 deletedEntity = this.ProductCodeDAO.Delete(ProductCode, false);
            SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), ProductCodeDTO.CreatedUserId, ProductCodeDTO.Code);
            return deletedEntity;
        }

         #endregion

        #region Helper Method

        private LOMORM00074 GetProductCodeData(LOMDTO00074 productCodeDTO, bool isDelete)
        {
            ProductInfo = new LOMORM00074();

            ProductInfo.Code = productCodeDTO.Code;
            ProductInfo.Description = productCodeDTO.Description;
            ProductInfo.TS = productCodeDTO.TS;

            ProductInfo.USERNO = productCodeDTO.CreatedUserId.ToString();
            ProductInfo.DATE_TIME = DateTime.Now;

            ProductInfo.CreatedUserId = productCodeDTO.CreatedUserId;
            ProductInfo.CreatedDate = DateTime.Now;

            ProductInfo.UpdatedUserId = productCodeDTO.UpdatedUserId;
            ProductInfo.UpdatedDate = DateTime.Now;

            if (isDelete)
                ProductInfo.Active = false;
            else
                ProductInfo.Active = true;

            return ProductInfo;
        }

        #endregion

        #region Data Version Update Service
        public void SaveOrUpdateClientDataVersion(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId, string dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
            LOMORM00074 ProductORM = new LOMORM00074();

            //Require Data
            clientDataVersionDTO.ORMObjectName = ProductORM;
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
