using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Gl.Ctr.Ptr;
using Ace.Cbs.Gl.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Gl.Ctr.Sve;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Ser;
using Ace.Cbs.Cx.Com.Ctr;

namespace Ace.Cbs.Gl.Ptr
{
    public class GLMCTL00013 : AbstractPresenter, IGLMCTL00013
    {
        public IGLMVEW00013 view { get; set; }

        public IList<GLMDTO00013> SelectDataVW_COA_List()
        {
            IList<GLMDTO00013> DTOList = CXClientWrapper.Instance.Invoke<IGLMSVE00013, IList<GLMDTO00013>>(x => x.SelectDataVW_COA_List(CurrentUserEntity.BranchCode));

            return DTOList;
           
        }
    }
}
