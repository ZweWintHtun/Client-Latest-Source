using System;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Tcm.Ctr.Sve;

namespace Ace.Cbs.Tcm.Ptr
{
    public class TCMCTL00022 : AbstractPresenter, ITCMCTL00022
    {
        #region Form Initializer

        private ITCMVEW00022 view;
        public ITCMVEW00022 View
        {
            get
            {
                return this.view;
            }
            set
            {

                this.WireTo(value);
            }
        }

        private void WireTo(ITCMVEW00022 view)
        {
            if (this.view == null)
            {
                this.view = view;

                this.Initialize(this.view, this.view.UserList);
            }
        }

        #endregion

        #region Main Methods

        public void Delete(IList<UserDTO> deleteList)
        {
            for (int i = 0; i < deleteList.Count; i++)
            {
                deleteList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
            }

            CXClientWrapper.Instance.Invoke<ITCMSVE00022>(x => x.DeactivateUser(deleteList));

            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.View.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            else
            {
                this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public IList<UserDTO> SelectByBranchCode()
        {
            return CXClientWrapper.Instance.Invoke<ITCMSVE00022, IList<UserDTO>>(service => service.SelectByBranchCode(this.View.LocalBranchCode));
        }

        #endregion

    }
}
