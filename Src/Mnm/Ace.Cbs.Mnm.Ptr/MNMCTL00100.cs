//----------------------------------------------------------------------
// <copyright file="MNMCTL00001.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>HM</CreatedUser>
// <CreatedDate>12/30/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Windows.Core.Presenter;
using Ace.Windows.CXClient;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Mnm.Dmd.DTO;
using Ace.Cbs.Mnm.Dmd;
using System.Windows.Forms;

namespace Ace.Cbs.Mnm.Ptr
{
    class MNMCTL00100 : AbstractPresenter, IMNMCTL00100
    {
        #region Properties

        private IMNMVEW00100 view;
        public IMNMVEW00100 View
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }


        private void WireTo(IMNMVEW00100 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetSavingEntity());
            }
        }

        #endregion

        public MNMDTO00032 GetSavingEntity()
        {
            MNMDTO00032 entity = new MNMDTO00032();
            entity.ACODE = "PBK001";

            return entity;
        }

        public IList<MNMDTO00034> GetInterestList()
        {
            return CXClientWrapper.Instance.Invoke<IMNMSVE00051, IList<MNMDTO00034>>(x => x.GetInterestList(CurrentUserEntity.BranchCode));
        }
    }

}
