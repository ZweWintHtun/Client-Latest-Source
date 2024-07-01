//----------------------------------------------------------------------
// <copyright file="TLMCTL00039.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate> 2013-09-21</CreatedDate>
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
  public class TLMCTL00039:AbstractPresenter,ITLMCTL00039
    {
        #region "For Initializer"
        private ITLMVEW00039 drawingRemittanceEncashAmountview;
        public ITLMVEW00039 DrawingRemittanceEncashAmountView
        {
            get { return this.drawingRemittanceEncashAmountview; }
            set { this.WireTo(value); }
        }
        private void WireTo(ITLMVEW00039 view)
        {
            if (this.drawingRemittanceEncashAmountview == null)
            {
                this.drawingRemittanceEncashAmountview = view;
                this.Initialize(this.drawingRemittanceEncashAmountview, this.Print());
            }
        }
        #endregion    

        #region "Methods"
        private TLMDTO00017 Print()
        {
            TLMDTO00017 DrawingEncashRemittanceEntity = new TLMDTO00017();
            if (DrawingEncashRemittanceEntity != null)
            {
                DrawingEncashRemittanceEntity.StartDate = this.drawingRemittanceEncashAmountview.StartDate;
                DrawingEncashRemittanceEntity.EndDate = this.drawingRemittanceEncashAmountview.EndDate;
                DrawingEncashRemittanceEntity.StartAmount = this.drawingRemittanceEncashAmountview.StartAmount;
                DrawingEncashRemittanceEntity.EndAmount = this.drawingRemittanceEncashAmountview.EndAmount;
            }

            return DrawingEncashRemittanceEntity;
        }

        public IList<TLMDTO00017> MainPrint(string typename)
        {
            string sourceBr = CurrentUserEntity.BranchCode;
            IList<TLMDTO00017> DrawingEncashRemittanceAmountDTOList = new List<TLMDTO00017>();
            DrawingEncashRemittanceAmountDTOList = CXClientWrapper.Instance.Invoke<ITLMSVE00039, TLMDTO00017>(x => x.GetAmountDrawingEncashRemittanceBranchLists(typename, this.drawingRemittanceEncashAmountview.StartDate, this.drawingRemittanceEncashAmountview.EndDate, this.drawingRemittanceEncashAmountview.StartAmount,this.drawingRemittanceEncashAmountview.EndAmount,sourceBr));


            return DrawingEncashRemittanceAmountDTOList;
        }
        #endregion
    }
}
