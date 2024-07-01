using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Utt;
using Ace.Windows.Ix.Client.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Cbs.Loan.Ctr.Sve;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00073 : AbstractPresenter, ILOMCTL00073
    {
        #region Properties

        public LOMCTL00073() { }

        private ILOMVEW00073 view;
        public ILOMVEW00073 UMEntryView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(ILOMVEW00073 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.view.ViewData);
            }
        }

        #endregion

        #region Methods
        public void Save(LOMDTO00073 entity)
        {
            if (!this.ValidateForm(entity))
            {
                if (entity.UMCode == string.Empty)
                    this.SetFocus("txtCode");
                else if (entity.UMCode != string.Empty)
                    this.SetFocus("txtDescription");
                return;
            }
            IList<DataVersionChangedValueDTO> dvcvList = new List<DataVersionChangedValueDTO>();
            if (this.UMEntryView.Status.Equals("Save"))
            {
                entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;

                IList<LOMDTO00073> UMInfo = CXClientWrapper.Instance.Invoke<ILOMSVE00073, IList<LOMDTO00073>>(x => x.CheckExist2(entity.UMCode, entity.UMDesp));
                if (UMInfo.Count > 0)
                {
                    LOMDTO00073 umActive = UMInfo.Where<LOMDTO00073>(x => x.Active == false).FirstOrDefault();
                    if (umActive != null) //Data exist with active 0 , deleted , so data will be save with update nature
                    {
                        if (umActive.UMCode == entity.UMCode)
                        {
                            entity.TS = umActive.TS;
                            //cityActive.Active = true;  //to save with active when changingValueOfObject   
                            dvcvList = GetChangedValueOfObject.GetChangedValueList(umActive, entity);
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
                CXClientWrapper.Instance.Invoke<ILOMSVE00073>(x => x.SaveServerAndServerClient(entity, dvcvList));
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                {
                    this.UMEntryView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.view.UMCode = string.Empty;
                    this.view.Description = string.Empty;
                    this.SetFocus("txtCode");
                }
                else
                {
                    this.UMEntryView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
            }

            else
            {
                entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                dvcvList = GetChangedValueOfObject.GetChangedValueList(this.UMEntryView.PreviousUMDto, entity);
                CXClientWrapper.Instance.Invoke<ILOMSVE00073>(x => x.Update(entity, dvcvList, "Update"));

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                {
                    string s = CXClientWrapper.Instance.ServiceResult.MessageCode;
                    this.UMEntryView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.SetFocus("txtCode");
                }
                else
                {
                    this.UMEntryView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.SetFocus("txtDescription");
                }
            }
        }

        public void Delete(IList<LOMDTO00073> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
            }
            CXClientWrapper.Instance.Invoke<ILOMSVE00073>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.UMEntryView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);

            }
            else
            {
                this.UMEntryView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public IList<LOMDTO00073> GetAll()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00073, IList<LOMDTO00073>>(service => service.GetAll());
        }
        #endregion
    }
}
