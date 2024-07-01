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
    public class LONCTL00002 : AbstractPresenter, ILOMCTL00002
    {
         #region Properties

        public LONCTL00002() { }
        private ILONVEW00002 view;
        public ILONVEW00002 TypeOfAdvanceView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(ILONVEW00002 view)
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

        public void Save(LONDTO00002 entity)
        {
            if (this.ValidateForm(entity))
            {
                if (this.TypeOfAdvanceView.Status.Equals("Save"))
                {                    
                    entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                    CXClientWrapper.Instance.Invoke<ILOMSVE00002>(x => x.SaveServerAndServerClient(entity));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        this.TypeOfAdvanceView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                    else
                    {
                        this.TypeOfAdvanceView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }

                else
                {                    
                    entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                    IList<DataVersionChangedValueDTO> dvcvList = GetChangedValueOfObject.GetChangedValueList(this.TypeOfAdvanceView.PreviousAdvanceDto, entity);
                    CXClientWrapper.Instance.Invoke<ILOMSVE00002>(x => x.Update(entity, dvcvList));

                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        string s = CXClientWrapper.Instance.ServiceResult.MessageCode;
                        this.TypeOfAdvanceView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                    else
                    {
                        this.TypeOfAdvanceView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }
            }
        }

        public void Delete(IList<LONDTO00002> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
            }
            CXClientWrapper.Instance.Invoke<ILOMSVE00002>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.TypeOfAdvanceView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            else
            {
                this.TypeOfAdvanceView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public IList<LONDTO00002> GetAll()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00002, IList<LONDTO00002>>(service => service.GetAll());
        }

        public LONDTO00002 SelectByAdvanceId(int id)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00002, LONDTO00002>(service => service.SelectByAdvanceId(id));
        }
       


        #endregion
    }
}
