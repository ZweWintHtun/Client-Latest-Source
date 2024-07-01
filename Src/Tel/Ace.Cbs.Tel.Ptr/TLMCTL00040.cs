//----------------------------------------------------------------------
// <copyright file="TLMCTL00040.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate> 2013-09-24</CreatedDate>
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
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Tel.Ptr
{
    public class TLMCTL00040 : AbstractPresenter, ITLMCTL00040
    {
        #region "For Initializer"
        private ITLMVEW00040 drawingRemittanceEncashNRCandNameview;
        public ITLMVEW00040 DrawingRemittanceEncashNRCandNameView
        {
            get { return this.drawingRemittanceEncashNRCandNameview; }
            set { this.WireTo(value); }
        }
        private void WireTo(ITLMVEW00040 view)
        {
            if (this.drawingRemittanceEncashNRCandNameview == null)
            {
                this.drawingRemittanceEncashNRCandNameview = view;
                this.Initialize(this.drawingRemittanceEncashNRCandNameview, this.Print());
            }
        }
        #endregion

        #region "Methods"
        private TLMDTO00017 Print()
        {
            TLMDTO00017 DrawingEncashRemittanceEntity = new TLMDTO00017();
            if (DrawingEncashRemittanceEntity != null)
            {
                DrawingEncashRemittanceEntity.StartDate = this.drawingRemittanceEncashNRCandNameview.StartDate;
                DrawingEncashRemittanceEntity.EndDate = this.drawingRemittanceEncashNRCandNameview.EndDate;
                DrawingEncashRemittanceEntity.Name = this.drawingRemittanceEncashNRCandNameview.NameAndNRC;
                DrawingEncashRemittanceEntity.NRC = this.drawingRemittanceEncashNRCandNameview.NameAndNRC;
               
            }

            return DrawingEncashRemittanceEntity;
        }

        public IList<TLMDTO00017> MainPrint(string typename)
        {
            IList<TLMDTO00017> DrawingEncashRemittanceAmountDTOList = new List<TLMDTO00017>();
            DrawingEncashRemittanceAmountDTOList = CXClientWrapper.Instance.Invoke<ITLMSVE00040, TLMDTO00017>(x => x.GetNRCDrawingEncashRemittanceLists(typename, this.drawingRemittanceEncashNRCandNameview.StartDate, this.drawingRemittanceEncashNRCandNameview.EndDate,this.drawingRemittanceEncashNRCandNameview.NameAndNRC));


            return DrawingEncashRemittanceAmountDTOList;
        }
        #endregion
    }
}
