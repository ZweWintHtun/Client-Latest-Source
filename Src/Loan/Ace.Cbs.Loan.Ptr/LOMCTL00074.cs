using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Client.Utt;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Ctr.Sve;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00074 : AbstractPresenter, ILOMCTL00074
    {
        #region Properties

        public LOMCTL00074() { }
        private ILOMVEW00074 view;
        public ILOMVEW00074 ProductCodeView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(ILOMVEW00074 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.view.ViewData);
            }
        }

        #endregion

        #region Methods

        public void Save(LOMDTO00074 entity)
        {
            if (!this.ValidateForm(entity))
            {
                if (entity.Code == string.Empty)
                    this.SetFocus("txtCode");
                else if (entity.Code != string.Empty)
                    this.SetFocus("txtDescription");
                return;
            }
            IList<DataVersionChangedValueDTO> dvcvList = new List<DataVersionChangedValueDTO>();
            if (this.ProductCodeView.Status.Equals("Save"))
            {
                entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;

                IList<LOMDTO00074> ProductCodeInfo = CXClientWrapper.Instance.Invoke<ILOMSVE00074, IList<LOMDTO00074>>(x => x.CheckExist2(entity.Code, entity.Description));
                if (ProductCodeInfo.Count > 0)
                {
                    LOMDTO00074 productCodeActive = ProductCodeInfo.Where<LOMDTO00074>(x => x.Active == false).FirstOrDefault();
                    if (productCodeActive != null)   //Data exist with active 0 , deleted , so data will be save with update nature
                    {
                        if (productCodeActive.Code == entity.Code)
                        {
                            entity.TS = productCodeActive.TS;
                            //cityActive.Active = true;  //to save with active when changingValueOfObject   
                            dvcvList = GetChangedValueOfObject.GetChangedValueList(productCodeActive, entity);
                            entity.Active = false;  //to check status in service
                        }
                    }
                    else
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MV90001");//data already exists      
                        return;
                    }
                }
                else entity.Active = true;  //active = 1 , new data , so data will be save with insert nature 
                //CXClientWrapper.Instance.Invoke<ILOMSVE00074>(x => x.SaveServerAndServerClient(entity));
                CXClientWrapper.Instance.Invoke<ILOMSVE00074>(x => x.SaveServerAndServerClient(entity, dvcvList));
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                {
                    this.ProductCodeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.view.Code = string.Empty;
                    this.view.Description = string.Empty;
                    this.SetFocus("txtCode");
                }
                else
                {
                    this.ProductCodeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
            }

            else
            {
                entity.SourceBranchCode = CurrentUserEntity.BranchCode;
                entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                dvcvList = GetChangedValueOfObject.GetChangedValueList(this.ProductCodeView.PreviousProductCodeDto, entity);
                CXClientWrapper.Instance.Invoke<ILOMSVE00074>(x => x.Update(entity, dvcvList, "Update"));

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                {
                    string s = CXClientWrapper.Instance.ServiceResult.MessageCode;
                    this.ProductCodeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.SetFocus("txtCode");
                }
                else
                {
                    this.ProductCodeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.SetFocus("txtDescription");
                }
            }
        }

        public void Delete(IList<LOMDTO00074> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
            }
            CXClientWrapper.Instance.Invoke<ILOMSVE00074>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.ProductCodeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);

            }
            else
            {
                this.ProductCodeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public IList<LOMDTO00074> GetAll()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00074, IList<LOMDTO00074>>(service => service.GetAll());
        }

        public LOMDTO00074 SelectByProductCode(string productCode)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00074, LOMDTO00074>(service => service.SelectByProductCode(productCode));
        }

        #endregion
    }
}
