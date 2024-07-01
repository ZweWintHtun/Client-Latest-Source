//----------------------------------------------------------------------
// <copyright file="TCMCTL00062" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate>18.6.2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Tcm.Ptr
{
   public class TCMCTL00062:AbstractPresenter,ITCMCTL00062
    {
        #region INITIALIZE VIEW
        private ITCMVEW00062 view;
        public ITCMVEW00062 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ITCMVEW00062 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetCledgerEntity());
            }
        }

        public PFMDTO00028 GetCledgerEntity()
        {
            PFMDTO00028 cledgerentity = new PFMDTO00028();

            return cledgerentity;
        }
        #endregion

        #region UI Logic
        public IList<PFMDTO00028> GetReconsile()
        {
          return  CXClientWrapper.Instance.Invoke<ITCMSVE00015,IList<PFMDTO00028>>(x => x.DailyReconsile(CurrentUserEntity.BranchCode));
        }
        #endregion

    }
}
