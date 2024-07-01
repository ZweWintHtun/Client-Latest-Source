using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Windows.Core.Presenter;
using Ace.Windows.CXClient;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Mnm.Ptr
{
    public class MNMCTL00076 : AbstractPresenter, IMNMCTL00076
    {
        #region Properties
        private IMNMVEW00076 view;
        public IMNMVEW00076 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(IMNMVEW00076 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetEntity());
            }
        }
        #endregion

        public MNMDTO00076 GetEntity()
        {
            MNMDTO00076 entity = new MNMDTO00076();

            return entity;
        }


        public IList<MNMDTO00076> SelectPONO(string SourceBr)
        {
            IList<MNMDTO00076> DTOList = CXClientWrapper.Instance.Invoke<IMNMSVE00076, IList<MNMDTO00076>>(x => x.SelectPoNo(SourceBr));

            if (DTOList.Count <= 0)
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039"); //No Data For Report
            }

            return DTOList;
        }

    }
}
