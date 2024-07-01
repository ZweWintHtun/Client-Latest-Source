using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.CXClient;
using Ace.Windows.Ix.Client.Utt;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Loan.Ctr.Sve;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00077 : AbstractPresenter, ILOMCTL00077
    {
        #region Properties
        public LOMCTL00077() { }

        private ILOMVEW00077 view;
        public ILOMVEW00077 LSProductTypeItemSetupView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(ILOMVEW00077 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.view.ViewData);
            }
        }
        #endregion

        #region Methods
        public void Save(LOMDTO00077 entity)
        {
            if (!this.ValidateForm(entity))
            {
                if (entity.ProductCode == string.Empty)
                    this.SetFocus("cboProductType");
                else if (entity.ProductCode != string.Empty && entity.LSBusinessCode == string.Empty)
                    this.SetFocus("cboLSBusinessType");
                else if (entity.ProductCode != string.Empty && entity.LSBusinessCode != string.Empty && entity.UMCode == string.Empty)
                    this.SetFocus("cboUMCode");
                else if (entity.ProductCode != string.Empty && entity.LSBusinessCode != string.Empty && entity.UMCode != string.Empty && entity.DurationMonths == null)
                    this.SetFocus("txtDurationMonths");
                return;
            }
            IList<DataVersionChangedValueDTO> dvcvList = new List<DataVersionChangedValueDTO>();
            if (this.LSProductTypeItemSetupView.Status.Equals("Save"))
            {
                entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;

                IList<LOMDTO00077> LSProductTypeItemInfo = CXClientWrapper.Instance.Invoke<ILOMSVE00077, IList<LOMDTO00077>>(x => x.CheckExist2(entity.ProductCode,entity.LSBusinessCode,entity.UMCode));
                if (LSProductTypeItemInfo.Count > 0)
                {
                    for (int i = 0; i < LSProductTypeItemInfo.Count; i++)
                    {
                        LOMDTO00077 lsProductTypeItem = LSProductTypeItemInfo[i];
                        if (lsProductTypeItem.Active == true)
                        {
                            CXUIMessageUtilities.ShowMessageByCode("MV90001");//data already exists      
                            return;
                        }
                    }
                    LOMDTO00077 lsProductTypeItemActive = LSProductTypeItemInfo.Where<LOMDTO00077>(x => x.Active == false).FirstOrDefault();
                    if (lsProductTypeItemActive.Active == false) //Data exist with active 0 , deleted , so data will be save with update nature
                    {
                        if (lsProductTypeItemActive.LSProductTypeItemId == entity.LSProductTypeItemId)
                        {
                            entity.TS = lsProductTypeItemActive.TS;
                            //cityActive.Active = true;  //to save with active when changingValueOfObject   
                            dvcvList = GetChangedValueOfObject.GetChangedValueList(lsProductTypeItemActive, entity);
                            entity.Active = false;  //to check status in service
                        }
                    }
                    else
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MV90001");//data already exists      
                        return;
                    }
                }
                else
                {
                    entity.Active = true;//active = 1 , new data , so data will be save with insert nature 
                }
                //CXClientWrapper.Instance.Invoke<ILOMSVE00002>(x => x.SaveServerAndServerClient(entity));
                CXClientWrapper.Instance.Invoke<ILOMSVE00077>(x => x.SaveServerAndServerClient(entity, dvcvList));
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                {
                    this.LSProductTypeItemSetupView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.view.ProductCode = string.Empty;
                    this.view.LSBusinessCode = string.Empty;
                    this.view.UMCode = string.Empty;
                    this.SetFocus("cboProductType");
                }
                else
                {
                    this.LSProductTypeItemSetupView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
            }
            else
            {
                entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                dvcvList = GetChangedValueOfObject.GetChangedValueList(this.LSProductTypeItemSetupView.PreviousLSProductTypeItemDto, entity);
                CXClientWrapper.Instance.Invoke<ILOMSVE00077>(x => x.Update(entity, dvcvList, "Update"));

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                {
                    string s = CXClientWrapper.Instance.ServiceResult.MessageCode;
                    this.LSProductTypeItemSetupView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.SetFocus("cboProductType");
                }
                else
                {
                    this.LSProductTypeItemSetupView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.SetFocus("cboProductType");
                }
            }
        }

        public void Delete(IList<LOMDTO00077> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
            }
            CXClientWrapper.Instance.Invoke<ILOMSVE00077>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.LSProductTypeItemSetupView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);

            }
            else
            {
                this.LSProductTypeItemSetupView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public IList<LOMDTO00077> GetAll()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00077, IList<LOMDTO00077>>(service => service.GetAll());
        }
        #endregion
    }
}
