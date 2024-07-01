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
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Windows.Ix.Client.Utt;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00076 : AbstractPresenter, ILOMCTL00076
    {
        #region properties
        public LOMCTL00076() { }
        private ILOMVEW00076 view;
        public ILOMVEW00076 LSBusinessCodeView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(ILOMVEW00076 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.view.ViewData);
            }
        }
        #endregion

        #region Methods
        public void Save(LOMDTO00076 entity)
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
            if (this.LSBusinessCodeView.Status.Equals("Save"))
            {
                entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;

                IList<LOMDTO00076> LSBusinessCodeInfo = CXClientWrapper.Instance.Invoke<ILOMSVE00076, IList<LOMDTO00076>>(x => x.CheckExist2(entity.Code, entity.Description));
                if (LSBusinessCodeInfo.Count > 0)
                {
                    LOMDTO00076 lsBusinessCodeActive = LSBusinessCodeInfo.Where<LOMDTO00076>(x => x.Active == false).FirstOrDefault();
                    if (LSBusinessCodeInfo != null)
                    {
                        if (lsBusinessCodeActive.Code == entity.Code)
                        {
                            entity.TS = lsBusinessCodeActive.TS;
                            dvcvList = GetChangedValueOfObject.GetChangedValueList(lsBusinessCodeActive, entity);
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
                CXClientWrapper.Instance.Invoke<ILOMSVE00076>(x => x.SaveServerAndServerClient(entity, dvcvList));
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                {
                    this.LSBusinessCodeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.view.LSBusinessCode = string.Empty;
                    this.view.Description = string.Empty;
                    this.SetFocus("txtCode");
                }
                else
                {
                    this.LSBusinessCodeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
            }

            else
            {
                entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                dvcvList = GetChangedValueOfObject.GetChangedValueList(this.LSBusinessCodeView.PreviousLSBusinessDto, entity);
                CXClientWrapper.Instance.Invoke<ILOMSVE00076>(x => x.Update(entity, dvcvList, "Update"));

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                {
                    string s = CXClientWrapper.Instance.ServiceResult.MessageCode;
                    this.LSBusinessCodeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.SetFocus("txtCode");
                }
                else
                {
                    this.LSBusinessCodeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.SetFocus("txtDescription");
                }
            }
        }

        public void Delete(IList<LOMDTO00076> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
            }
            CXClientWrapper.Instance.Invoke<ILOMSVE00076>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                this.LSBusinessCodeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            else
                this.LSBusinessCodeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
        }

        public IList<LOMDTO00076> GetAll()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00076, IList<LOMDTO00076>>(service => service.GetAll());
        }

        public LOMDTO00076 SelectByLSBusinessCode(string lsBusinessCode)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00076, LOMDTO00076>(service => service.SelectByLSBusinessCode(lsBusinessCode));
        }
        #endregion
    }
}
