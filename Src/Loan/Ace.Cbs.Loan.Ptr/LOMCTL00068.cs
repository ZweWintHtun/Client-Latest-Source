using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Windows.CXClient;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Core.Utt;
using Ace.Windows.Ix.Client.Utt;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00068 : AbstractPresenter, ILOMCTL00068
    {
        #region Properties

        public LOMCTL00068() { }

        private ILOMVEW00068 view;
        public ILOMVEW00068 HirePurchaseStockGroupEntryView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(ILOMVEW00068 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.view.ViewData);                
            }
        }

        #endregion

        #region Methods
        public void Save(LOMDTO00068 entity)
        {
            if (!this.ValidateForm(entity))
            {
                if (entity.PreFix == string.Empty)
                    this.SetFocus("txtPrefixCode");
                else if (entity.PreFix != string.Empty && entity.GroupCode == string.Empty)
                    this.SetFocus("txtStockGroupCode");
                else if (entity.PreFix != string.Empty && entity.GroupCode != string.Empty)
                    this.SetFocus("txtDescription");
                return;
            }
            IList<DataVersionChangedValueDTO> dvcvList = new List<DataVersionChangedValueDTO>();
            if (this.HirePurchaseStockGroupEntryView.Status.Equals("Save"))
            {
                entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;

                IList<LOMDTO00068> StockGroupInfo = CXClientWrapper.Instance.Invoke<ILOMSVE00068, IList<LOMDTO00068>>(x => x.CheckExist2(entity.GroupCode, entity.PreFix, entity.Description));
                if (StockGroupInfo.Count > 0)
                {
                    LOMDTO00068 stockGroupActive = StockGroupInfo.Where<LOMDTO00068>(x => x.Active == false).FirstOrDefault();
                    if (stockGroupActive != null) //Data exist with active 0 , deleted , so data will be save with update nature
                    {
                        if (stockGroupActive.GroupCode == entity.GroupCode)
                        {
                            entity.TS = stockGroupActive.TS;
                            //cityActive.Active = true;  //to save with active when changingValueOfObject   
                            dvcvList = GetChangedValueOfObject.GetChangedValueList(stockGroupActive, entity);
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
                CXClientWrapper.Instance.Invoke<ILOMSVE00068>(x => x.SaveServerAndServerClient(entity, dvcvList));
                this.SaveClient(entity);
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                {
                    this.HirePurchaseStockGroupEntryView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.view.GroupCode = string.Empty;
                    this.view.Description = string.Empty;
                    this.view.PreFix = string.Empty;
                    this.SetFocus("txtPrefixCode");
                }
                else
                {
                    this.HirePurchaseStockGroupEntryView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
            }

            else
            {
                entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                dvcvList = GetChangedValueOfObject.GetChangedValueList(this.HirePurchaseStockGroupEntryView.PreviousStockGroupDto, entity);
                CXClientWrapper.Instance.Invoke<ILOMSVE00068>(x => x.Update(entity, dvcvList, "Update"));

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                {
                    string s = CXClientWrapper.Instance.ServiceResult.MessageCode;
                    this.HirePurchaseStockGroupEntryView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.SetFocus("txtPrefixCode");
                }
                else
                {
                    this.HirePurchaseStockGroupEntryView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.SetFocus("txtDescription");
                }
            }
        }
        public void SaveClient(LOMDTO00068 entity)
        {
            try
            {
                Dictionary<string, object> stockGroupKeyPair = new Dictionary<string, object> {
	            { "GroupCode", entity.GroupCode },	                    
	            { "Description", entity.Description },	                    
	            { "PreFix", entity.PreFix } };
                ClientSQLiteDataHandler.Instance.InsertClient("StockGroup", stockGroupKeyPair, entity.TS, entity.CreatedUserId, entity.CreatedDate);
                this.HirePurchaseStockGroupEntryView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            catch (Exception)
            {
                this.HirePurchaseStockGroupEntryView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }
 
        public void Delete(IList<LOMDTO00068> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
            }
            CXClientWrapper.Instance.Invoke<ILOMSVE00068>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.HirePurchaseStockGroupEntryView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);

            }
            else
            {
                this.HirePurchaseStockGroupEntryView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public IList<LOMDTO00068> GetAll()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00068, IList<LOMDTO00068>>(service => service.GetAll()); 
        }
        #endregion
    }
}
