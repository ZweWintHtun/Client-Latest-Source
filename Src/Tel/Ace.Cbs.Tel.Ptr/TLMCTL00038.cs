//----------------------------------------------------------------------
// <copyright file="TLMCTL00038.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate> 2013-09-17 </CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Sve;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Tel.Ptr
{
    public class TLMCTL00038 : AbstractPresenter, ITLMCTL00038
    {
        #region "For Initializer"
        private ITLMVEW00038 drawingRemittanceEncashAllByBranchview;
        public ITLMVEW00038 DrawingRemittanceEncashAllByBranchView
        {
            get { return this.drawingRemittanceEncashAllByBranchview; }
            set { this.WireTo(value); }
        }
        private void WireTo(ITLMVEW00038 view)
        {
            if (this.drawingRemittanceEncashAllByBranchview == null)
            {
                this.drawingRemittanceEncashAllByBranchview = view;
                this.Initialize(this.drawingRemittanceEncashAllByBranchview, this.Print());
            }
        }
        #endregion       

        #region "Methods"
        private TLMDTO00017 Print()
        {
            TLMDTO00017 DrawingEncashRemittanceEntity = new TLMDTO00017();
            if (DrawingEncashRemittanceEntity != null)
            {
                DrawingEncashRemittanceEntity.StartDate = this.DrawingRemittanceEncashAllByBranchView.StartDate;
                DrawingEncashRemittanceEntity.EndDate = this.DrawingRemittanceEncashAllByBranchView.EndDate;
                DrawingEncashRemittanceEntity.TransactionStatus = this.DrawingRemittanceEncashAllByBranchView.TransactionStatus;
                DrawingEncashRemittanceEntity.BranchNo = this.DrawingRemittanceEncashAllByBranchView.BranchNo;
            }

            return DrawingEncashRemittanceEntity;
        }

        public IList<TLMDTO00017> MainPrint(string typename)
        {
            string sourceBr = CurrentUserEntity.BranchCode;
            IList<TLMDTO00017> DrawingEncashRemittanceDTOList = new List<TLMDTO00017>();
            DrawingEncashRemittanceDTOList = CXClientWrapper.Instance.Invoke<ITLMSVE00038, TLMDTO00017>(x => x.GetDrawingEncashRemittanceDataAllandByBranchLists(typename, this.drawingRemittanceEncashAllByBranchview.StartDate, this.drawingRemittanceEncashAllByBranchview.EndDate, this.drawingRemittanceEncashAllByBranchview.BranchNo,sourceBr));
            return DrawingEncashRemittanceDTOList;
        }
        #endregion
    }
}
