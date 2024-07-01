using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Sam.Ctr.Sve;
using Ace.Cbs.Sam.Ctr.Ptr;
using Ace.Cbs.Sam.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Client.Utt;
using System.Linq;


namespace Ace.Cbs.Sam.Ptr
{
    public class SAMCTL00056 : AbstractPresenter, ISAMCTL00056
    {
        #region Properties

        public SAMCTL00056() { }
        private ISAMVEW00056 view;
        public ISAMVEW00056 NRCCodeView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(ISAMVEW00056 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.view.ViewData);
            }
        }

        #endregion

        #region Methods

        public override bool ValidateForm(object validationContext)
        {
            return base.ValidateForm(validationContext);
        }

        public void Save(SAMDTO00054 entity)
        {
            if (this.ValidateForm(entity))
            {
                if (this.NRCCodeView.Status.Equals("Save"))
                {
                    entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                    //entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                    entity.CreatedDate = DateTime.Now;
                    //entity.UpdatedDate = DateTime.Now;

                    IList<SAMDTO00054> NRCInfo = CXClientWrapper.Instance.Invoke<ISAMSVE00056, IList<SAMDTO00054>>(x => x.CheckExist2(this.view.StateCode, this.view.TownshipCode));
                    if (NRCInfo.Count == 0)
                    {
                        CXClientWrapper.Instance.Invoke<ISAMSVE00056>(x => x.SaveServerAndServerClient(entity));
                        if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                        {
                            this.NRCCodeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                            //this.view.ControlSetting("NRCCode.Enable", true);
                        }
                        else
                        {
                            this.NRCCodeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        }
                    }
                    else
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MV90001");//data already exists      
                        return; 
                    }
                }

                else //Update
                {
                    entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                    entity.UpdatedDate = DateTime.Now;
                    IList<DataVersionChangedValueDTO> dvcvList = GetChangedValueOfObject.GetChangedValueList(this.view.PreviousNRCCodeDto, entity);
                    CXClientWrapper.Instance.Invoke<ISAMSVE00056>(x => x.Update(entity, dvcvList));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        string s = CXClientWrapper.Instance.ServiceResult.MessageCode;
                        this.NRCCodeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                    else
                    {
                        this.NRCCodeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }
            }
            else
            {
                if (entity.StateCode == null)
                    this.SetFocus("cboStateCode");
                else if (entity.TownshipCode.ToString().Equals(string.Empty))
                    this.SetFocus("txtTownshipCode");
                else if (entity.TownshipCode.ToString().Equals(string.Empty))
                    this.SetFocus("txtTownshipDesp");
            }
        }       

        public void Delete(IList<SAMDTO00054> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
                itemList[i].CreatedUserId = CurrentUserEntity.CurrentUserID;
                itemList[i].UpdatedDate = System.DateTime.Now;
            }
            CXClientWrapper.Instance.Invoke<ISAMSVE00056>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.NRCCodeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);

            }
            else
            {
                this.NRCCodeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public IList<SAMDTO00054> GetAll()
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00056, IList<SAMDTO00054>>(service => service.GetAll());
        }

        public IList<SAMDTO00054> SelectByStateCode(string StateCode)
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00056, SAMDTO00054>(service => service.SelectByStateCode(StateCode));
        }

        #endregion

        #region Validation Logic
        public void txtTownshipCode_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError == false)
            {
                if (!string.IsNullOrEmpty(this.view.TownshipCode.ToString()))
                {
                    if (this.view.TownshipCode.Length < 6)
                    {
                        this.SetCustomErrorMessage(this.GetControl("txtTownshipCode"), CXMessage.MI90072);
                        return;
                    }
                }
            }
        }
        #endregion
    }
}
