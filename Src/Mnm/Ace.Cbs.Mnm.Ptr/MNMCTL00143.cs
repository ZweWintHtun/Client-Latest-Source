using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.CXClient;
using System.Windows.Forms;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Mnm.Ptr
{
   public class MNMCTL00143 : AbstractPresenter, IMNMCTL00143
    {

        #region Properties

        IMNMVEW00143 view;
        public IMNMVEW00143 View
        {
            set { this.wierTo(value); }
            get { return this.view; }
        }

        private void wierTo(IMNMVEW00143 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }

        public IList<MNMDTO00043> showReport(string formname)
        {

            string sourceBr = CurrentUserEntity.BranchCode;
            CXClientWrapper.Instance.ServiceResult.MessageCode = "";
            CXClientWrapper.Instance.ServiceResult.ErrorOccurred = false;

            if (formname == "Fixed Year End Interest")
            {
                IList<MNMDTO00043> FiList = CXClientWrapper.Instance.Invoke<IMNMSVE00143, IList<MNMDTO00043>>(x => x.SelectFixedYearEnd(sourceBr));

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred==true)
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    
                }
                

                    return FiList;
               
                

            }
                //prev listing 
            else
            {
                IList<MNMDTO00043> FiList = CXClientWrapper.Instance.Invoke<IMNMSVE00143, IList<MNMDTO00043>>(x => x.SelectFixedYearEndPrev(sourceBr));


                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred==true)
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);

                }
                else
                {

                    return FiList;
                }
                

            }
            return null;
           

        }

        #endregion
    }
}
