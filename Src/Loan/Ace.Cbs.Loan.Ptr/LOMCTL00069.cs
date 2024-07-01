using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Windows.Ix.Client.Utt;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00069 : AbstractPresenter, ILOMCTL00069
    {
        #region Properties
        public LOMCTL00069() { }

        private ILOMVEW00069 view;
        public ILOMVEW00069 HirePurchaseStockSubItemCodeRegisterationView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(ILOMVEW00069 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.view.ViewData);
            }
        }
        #endregion

        #region Methods
        public void Save(LOMDTO00069 entity)
        {
            if (!this.ValidateForm(entity))
            {
                if (entity.SubCode == string.Empty)
                    this.SetFocus("txtSubCode");
                else if (entity.SubCode != string.Empty && entity.GroupCode == string.Empty)
                    this.SetFocus("cboGroupCode");
                else if (entity.SubCode != string.Empty && entity.GroupCode != string.Empty)
                    this.SetFocus("txtDescription");
                return;
            }
            IList<DataVersionChangedValueDTO> dvcvList = new List<DataVersionChangedValueDTO>();
            if (this.HirePurchaseStockSubItemCodeRegisterationView.Status.Equals("Save"))
            {
                entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;

                IList<LOMDTO00069> StockItemInfo = CXClientWrapper.Instance.Invoke<ILOMSVE00069, IList<LOMDTO00069>>(x => x.CheckExist2(entity.GroupCode, entity.SubCode, entity.Description));
                if (StockItemInfo.Count > 0)
                {
                    LOMDTO00069 stockItemActive = StockItemInfo.Where<LOMDTO00069>(x => x.Active == false).FirstOrDefault();
                    if (stockItemActive != null) //Data exist with active 0 , deleted , so data will be save with update nature
                    {
                        if (stockItemActive.SubCode == entity.SubCode)
                        {
                            entity.TS = stockItemActive.TS;
                            //cityActive.Active = true;  //to save with active when changingValueOfObject   
                            dvcvList = GetChangedValueOfObject.GetChangedValueList(stockItemActive, entity);
                            entity.Active = false;  //to check status in service
                        }
                    }
                    else
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MV90001");//data already exists      
                        return;
                    }
                }
                else entity.Active = true;//active = 1 , new data , so data will be save with insert nature 
                //CXClientWrapper.Instance.Invoke<ILOMSVE00002>(x => x.SaveServerAndServerClient(entity));
                CXClientWrapper.Instance.Invoke<ILOMSVE00069>(x => x.SaveServerAndServerClient(entity, dvcvList));
                this.SaveClient(entity);
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                {
                    this.HirePurchaseStockSubItemCodeRegisterationView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.view.GroupCode = string.Empty;
                    this.view.Description = string.Empty;
                    this.view.SubCode = string.Empty;
                    this.SetFocus("cboGroupCode");
                }
                else
                {
                    this.HirePurchaseStockSubItemCodeRegisterationView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
            }
            else
            {
                entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                dvcvList = GetChangedValueOfObject.GetChangedValueList(this.HirePurchaseStockSubItemCodeRegisterationView.PreviousStockItemDto, entity);
                CXClientWrapper.Instance.Invoke<ILOMSVE00069>(x => x.Update(entity, dvcvList, "Update"));

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                {
                    string s = CXClientWrapper.Instance.ServiceResult.MessageCode;
                    this.HirePurchaseStockSubItemCodeRegisterationView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.SetFocus("cboGroupCode");
                }
                else
                {
                    this.HirePurchaseStockSubItemCodeRegisterationView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.SetFocus("txtDescription");
                }
            }
        }
        public void SaveClient(LOMDTO00069 entity)
        {
            try
            {
                Dictionary<string, object> stockGroupKeyPair = new Dictionary<string, object> {
	            { "GroupCode", entity.GroupCode },	                    
	            { "Description", entity.Description },	                    
	            { "SubCode", entity.SubCode } };
                ClientSQLiteDataHandler.Instance.InsertClient("StockItem", stockGroupKeyPair, entity.TS, entity.CreatedUserId, entity.CreatedDate);
                this.HirePurchaseStockSubItemCodeRegisterationView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            catch (Exception)
            {
                this.HirePurchaseStockSubItemCodeRegisterationView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }
        public void Delete(IList<LOMDTO00069> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
            }
            CXClientWrapper.Instance.Invoke<ILOMSVE00069>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.HirePurchaseStockSubItemCodeRegisterationView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);

            }
            else
            {
                this.HirePurchaseStockSubItemCodeRegisterationView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public IList<LOMDTO00069> GetAll()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00069, IList<LOMDTO00069>>(service => service.GetAll());
        }
        #endregion
    }
}
