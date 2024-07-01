//----------------------------------------------------------------------
// <copyright file="TCMCTL00037.cs" company="Ace Data Systems">
// Copyright (c) Ace Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>HM</CreatedUser>
// <CreatedDate>11/02/2014</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Sam.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Tcm.Ctr.Sve;

namespace Ace.Cbs.Tcm.Ptr
{
    public class TCMCTL00037 : AbstractPresenter, ITCMCTL00037
    {
        #region Form Initializer

        private ITCMVEW00037 view;
        public ITCMVEW00037 View
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

        private void WireTo(ITCMVEW00037 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }
        
        #endregion

        #region Main Method

        public void GetClearingReceiptReversalListing()
        {
            string userno = CurrentUserEntity.WorkStationId.ToString();
            IList<PFMDTO00042> ReportTLFDTOList = CXClientWrapper.Instance.Invoke<ITCMSVE00037, IList<PFMDTO00042>>(x => x.GetClearingReceiptReverseService(this.view.StartDate, this.view.EndDate, userno,CurrentUserEntity.CurrentUserID,CurrentUserEntity.BranchCode));
            if (ReportTLFDTOList.Count != 0)
            {
                CXUIScreenTransit.Transit("frmTCMVEW00058ReceiptReverse", true, new object[] { ReportTLFDTOList, this.view.StartDate, this.view.EndDate });
            }
            else
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
            }

        }        

        #endregion

        #region Helper Methods

        void IPresenter.ClearErrors()
        {
            throw new NotImplementedException();
        }
        //public void IPresenter.ClearErrors()
        //{
        //    throw new NotImplementedException();
        //}

        public bool CheckDate()
        {

            bool date = CXCOM00006.Instance.IsValidStartDateEndDate(this.view.StartDate, this.view.EndDate);
            if (date == false)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00123");
            }

            return date;

        }    

        #endregion

    }
}
