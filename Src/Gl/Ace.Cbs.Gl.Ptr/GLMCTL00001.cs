using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Gl.Ctr.Ptr;
using Ace.Windows.CXClient;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Gl.Ctr.Sve;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Dmd;

namespace Ace.Cbs.Gl.Ptr
{
    public class GLMCTL00001 : AbstractPresenter,IGLMCTL00001
    {
        #region View

        private IGLMVEW00001 view;
        public IGLMVEW00001 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private void WireTo(IGLMVEW00001 view)
        {
            if (this.view == null)
                this.view = view;
        }

        #endregion

        public IList<CXDMD00013> GetAllCurrency()
        {
            return CXClientWrapper.Instance.Invoke<IGLMSVE00001, IList<CXDMD00013>>(x => x.SelectAllCurrency());
        }

        public void UpdateCurrencyRateByCur(IList<CXDMD00013> currencyList)
        {
            IList<CXDMD00013> curList = CXClientWrapper.Instance.Invoke<IGLMSVE00001, IList<CXDMD00013>>(x => x.UpdateCurrencyRate(currencyList, CurrentUserEntity.CurrentUserID));
            if (!CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
            {
                CXUIMessageUtilities.ShowMessageByCode("MI90001"); //Saving Successful
                this.View.GridDataBind(curList);
                this.View.tsbCRUD_InitialState();
                this.View.GridViewColumnReadOnly(true);
                this.View.CurrencyList.Clear();
            }
        }

        public void DeleteCurrencyRateByCur(IList<CXDMD00013> currencyList)
        {
            IList<CXDMD00013> curList = CXClientWrapper.Instance.Invoke<IGLMSVE00001, IList<CXDMD00013>>(x => x.DeleteCurrencyRateByCur(currencyList, CurrentUserEntity.CurrentUserID));
            if (!CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
            {
                CXUIMessageUtilities.ShowMessageByCode("MI90003"); //Delete Successful
                this.View.GridDataBind(curList);
                this.View.tsbCRUD_InitialState();
                this.View.GridViewColumnReadOnly(true);
                this.View.CurrencyList.Clear();
                this.View.DeleteList.Clear();
            }
        }

        public void DeleteAllCurrencyRate()
        {
            IList<CXDMD00013> curList = CXClientWrapper.Instance.Invoke<IGLMSVE00001, IList<CXDMD00013>>(x => x.DeleteAllCurrencyRate(CurrentUserEntity.CurrentUserID));
            if (!CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
            {
                CXUIMessageUtilities.ShowMessageByCode("MI90003"); //Delete Successful
                this.View.GridDataBind(curList);
                this.View.tsbCRUD_InitialState();
                this.View.GridViewColumnReadOnly(true);
                this.View.CurrencyList.Clear();
                this.View.DeleteList.Clear();
            }
        }
    }
}
