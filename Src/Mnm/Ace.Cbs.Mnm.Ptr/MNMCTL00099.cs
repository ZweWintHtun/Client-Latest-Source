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
using Ace.Cbs.Mnm.Dmd.DTO;
using System.Windows.Forms;

namespace Ace.Cbs.Mnm.Ptr
{
    class MNMCTL00099 : AbstractPresenter, IMNMCTL00099
    {
        #region Properties

        private IMNMVEW00099 view;
        public IMNMVEW00099 View
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }


        private void WireTo(IMNMVEW00099 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetReportTLFEntity());
            }
        }

        #endregion

        public MNMDTO00032 GetReportTLFEntity()
        {
            MNMDTO00032 reportEntity = new MNMDTO00032();
            reportEntity.ACODE = "PBK001";

           
            return reportEntity;
        }
    }

}
