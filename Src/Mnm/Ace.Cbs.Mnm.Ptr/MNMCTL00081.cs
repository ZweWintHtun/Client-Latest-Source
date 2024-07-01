//----------------------------------------------------------------------
// <copyright file="MNMCTL00001.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>HM</CreatedUser>
// <CreatedDate>12/27/2013</CreatedDate>
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
using Ace.Cbs.Mnm.Dmd;
using System.Windows.Forms;

namespace Ace.Cbs.Mnm.Ptr
{
    public class MNMCTL00081 : AbstractPresenter, IMNMCTL00081
    {
        #region Properties
        private IMNMVEW00081 view;
        public IMNMVEW00081 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(IMNMVEW00081 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetEntity());
            }
        }
        #endregion

        public MNMDTO00081 GetEntity()
        {
            MNMDTO00081 entity = new MNMDTO00081();

            return entity;
        }

        public IList<MNMDTO00081> SelectFreceipt()
        {
            IList<MNMDTO00081> DTOList = CXClientWrapper.Instance.Invoke<IMNMSVE00081, IList<MNMDTO00081>>(x => x.SelectFreceipt(CurrentUserEntity.BranchCode));

            if (DTOList.Count <= 0)
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039"); //No Data For Report                
            }

            return DTOList;
        }
    }
}
