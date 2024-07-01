//----------------------------------------------------------------------
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>11/01/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
//using Ace.Cbs.Mnm.Dmd.DTO;

namespace Ace.Cbs.Mnm.Ptr
{

    class MNMCTL00049 : AbstractPresenter, IMNMCTL00049
    {
        #region Properties
        private IMNMVEW00049 view;
        public IMNMVEW00049 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        #endregion
        private void WireTo(IMNMVEW00049 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetVlaidateData());
            }
        }

        #region Helper Methods
        private PFMDTO00054 GetVlaidateData()
        {
            PFMDTO00054 ValidateDto = new PFMDTO00054();
            ValidateDto.AccountNo = view.AccountNumber;
            return ValidateDto;
        }
        #endregion

        #region Events calling Methods
        public void mtxtAccountNo_CustomValidate(object sender, ValidationEventArgs e)
        {
            if (!e.HasXmlBaseError)
            {
                if (string.IsNullOrEmpty(view.AccountNumber))
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), "MV00046");
            }
        }
        #endregion
    }
}
