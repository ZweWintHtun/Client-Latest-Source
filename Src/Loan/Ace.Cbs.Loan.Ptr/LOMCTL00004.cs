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
    public class LOMCTL00004 : AbstractPresenter, ILOMCTL00004
    {
        #region Properties

        public LOMCTL00004() { }
        private ILOMVEW00004 view;
        public ILOMVEW00004 GoodWillView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(ILOMVEW00004 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.view.ViewData);
            }
        }

        #endregion

        public void Save(LOMDTO00001 entity)
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
            if (this.GoodWillView.Status.Equals("Save"))
            {
                entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;

                IList<LOMDTO00001> GoodWillCodeInfo = CXClientWrapper.Instance.Invoke<ILOMSVE00004, IList<LOMDTO00001>>(x => x.CheckExist2(entity.Code, entity.Description));
                if (GoodWillCodeInfo.Count > 0)
                {
                    LOMDTO00001 goodWillCodeActive = GoodWillCodeInfo.Where<LOMDTO00001>(x => x.Active == false).FirstOrDefault();
                    if (goodWillCodeActive != null)   //Data exist with active 0 , deleted , so data will be save with update nature
                    {
                        if (goodWillCodeActive.Code == entity.Code)
                        {
                            entity.TS = goodWillCodeActive.TS;
                            //cityActive.Active = true;  //to save with active when changingValueOfObject   
                            dvcvList = GetChangedValueOfObject.GetChangedValueList(goodWillCodeActive, entity);
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
                //CXClientWrapper.Instance.Invoke<ILOMSVE00001>(x => x.SaveServerAndServerClient(entity));
                CXClientWrapper.Instance.Invoke<ILOMSVE00004>(x => x.SaveServerAndServerClient(entity, dvcvList));
                this.SaveClient(entity);
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                {
                    this.GoodWillView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.view.GoodWillCode = string.Empty;
                    this.view.Description = string.Empty;
                    this.SetFocus("txtCode");
                }
                else
                {
                    this.GoodWillView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
            }

            else
            {
                entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                dvcvList = GetChangedValueOfObject.GetChangedValueList(this.GoodWillView.PreviousGoodWillDto, entity);
                CXClientWrapper.Instance.Invoke<ILOMSVE00004>(x => x.Update(entity, dvcvList, "Update"));

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                {
                    string s = CXClientWrapper.Instance.ServiceResult.MessageCode;
                    this.GoodWillView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.SetFocus("txtCode");
                }
                else
                {
                    this.GoodWillView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.SetFocus("txtDescription");
                }
            }
        }
        public void SaveClient(LOMDTO00001 entity)
        {
            try
            {
                Dictionary<string, object> businessKeyPair = new Dictionary<string, object> {
                { "GoodWillCode", entity.Code },
                { "GoodWillDescription", entity.Description } };
                ClientSQLiteDataHandler.Instance.InsertClient("GOODWILL", businessKeyPair, entity.TS, entity.CreatedUserId, entity.CreatedDate);
                this.GoodWillView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            catch (Exception)
            {
                this.GoodWillView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }
        public void Delete(IList<LOMDTO00001> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
            }
            CXClientWrapper.Instance.Invoke<ILOMSVE00004>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.GoodWillView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            else
            {
                this.GoodWillView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public IList<LOMDTO00001> SelectAll()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00004, IList<LOMDTO00001>>(service => service.SelectAll());
        }

        public LOMDTO00001 SelectByGoodWillCode(string goodWillCode)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00004, LOMDTO00001>(service => service.SelectByGoodCode(goodWillCode));
        }
    }
}
