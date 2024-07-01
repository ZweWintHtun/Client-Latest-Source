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
    public class LOMCTL00001 : AbstractPresenter, ILOMCTL00001
    {
        #region Properties

        public LOMCTL00001() { }
        private ILOMVEW00001 view;
        public ILOMVEW00001 BusinessCodeView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(ILOMVEW00001 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.view.ViewData);
            }
        }

        #endregion

        #region Methods

        //public override bool ValidateForm(object validationContext)
        //{
        //    return base.ValidateForm(validationContext);
        //}

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
                if (this.BusinessCodeView.Status.Equals("Save"))
                {                   
                    entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                    entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;

                    IList<LOMDTO00001> BusinessCodeInfo = CXClientWrapper.Instance.Invoke<ILOMSVE00001, IList<LOMDTO00001>>(x => x.CheckExist2(entity.Code, entity.Description));
                    if (BusinessCodeInfo.Count > 0)
                    {
                        LOMDTO00001 businessCodeActive = BusinessCodeInfo.Where<LOMDTO00001>(x => x.Active == false).FirstOrDefault();
                        if (businessCodeActive != null)   //Data exist with active 0 , deleted , so data will be save with update nature
                        {
                            if (businessCodeActive.Code == entity.Code)
                            {
                                entity.TS = businessCodeActive.TS;
                                //cityActive.Active = true;  //to save with active when changingValueOfObject   
                                dvcvList = GetChangedValueOfObject.GetChangedValueList(businessCodeActive, entity);
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
                    CXClientWrapper.Instance.Invoke<ILOMSVE00001>(x => x.SaveServerAndServerClient(entity,dvcvList));
                    this.SaveClient(entity);
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        this.BusinessCodeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        this.view.BusinessCode = string.Empty;
                        this.view.Description = string.Empty;
                        this.SetFocus("txtCode");
                    }
                    else
                    {
                        this.BusinessCodeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }

                else
                {                    
                    entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                    dvcvList = GetChangedValueOfObject.GetChangedValueList(this.BusinessCodeView.PreviousBusinessDto, entity);
                    CXClientWrapper.Instance.Invoke<ILOMSVE00001>(x => x.Update(entity, dvcvList, "Update"));

                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        string s = CXClientWrapper.Instance.ServiceResult.MessageCode;
                        this.BusinessCodeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        this.SetFocus("txtCode");
                    }
                    else
                    {
                      this.BusinessCodeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                      this.SetFocus("txtDescription");
                    }
                }
         
        }
        public void SaveClient(LOMDTO00001 entity)
        {
            try
            {
                Dictionary<string, object> businessKeyPair = new Dictionary<string, object> {
                { "BUSICODE", entity.Code },
                { "BUSIDESP", entity.Description } };
                ClientSQLiteDataHandler.Instance.InsertClient("BUSINESS", businessKeyPair, entity.TS, entity.CreatedUserId, entity.CreatedDate);
                this.BusinessCodeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            catch (Exception)
            {
                this.BusinessCodeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }
        public void Delete(IList<LOMDTO00001> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
            }
            CXClientWrapper.Instance.Invoke<ILOMSVE00001>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.BusinessCodeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            else
            {
                this.BusinessCodeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public IList<LOMDTO00001> GetAll()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00001, IList<LOMDTO00001>>(service => service.GetAll());
        }

        public LOMDTO00001 SelectByBusinessCode(string businessCode)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00001, LOMDTO00001>(service => service.SelectByBusinessCode(businessCode));
        }

        #endregion
    }
}
