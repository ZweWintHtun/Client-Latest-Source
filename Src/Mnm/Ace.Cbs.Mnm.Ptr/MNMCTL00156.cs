//----------------------------------------------------------------------
// <copyright file="MNMCTL00156.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2015-02-12</CreatedDate>
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
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Mnm.Ptr
{
    /// <summary>
    /// DrawingRemittanceMonthlyClosing Controller
    /// </summary>
    public class MNMCTL00156 : AbstractPresenter, IMNMCTL00156
    {
        #region "For Initializer"
        private IMNMVEW00156 drawingremittancemonthlyclosingView;
        public IMNMVEW00156 DrawingRemittanceMonthlyClosingView
        {
            get { return this.drawingremittancemonthlyclosingView; }
            set { this.WireTo(value); }
        }
        private void WireTo(IMNMVEW00156 view)
        {
            if (this.drawingremittancemonthlyclosingView == null)
            {
                this.drawingremittancemonthlyclosingView = view;
                this.Initialize(this.drawingremittancemonthlyclosingView, this.Print());
            }
        }
        #endregion

        #region Methods
        private TLMDTO00017 Print()
        {
            try
            {
                TLMDTO00017 rdDTO = new TLMDTO00017();
                rdDTO.RequiredYear = this.DrawingRemittanceMonthlyClosingView.RequiredYear;
                rdDTO.RequiredMonth = this.DrawingRemittanceMonthlyClosingView.RequiredMonth;
                return rdDTO;
            }
            catch (Exception ex)
            {
                
                throw new Exception (ex.InnerException+ex.Message);
            }
        }
        public IList<TLMDTO00017> MainDrawingPrint(string typename)
        {
            try
            {
                string budgetyear = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);
                IList<TLMDTO00017> DrawingRemittanceDTOList = CXClientWrapper.Instance.Invoke<IMNMSVE00156, IList<TLMDTO00017>>(x => x.GetDrawingRemittanceLists(typename, CurrentUserEntity.BranchCode, budgetyear));
                return DrawingRemittanceDTOList;
            }
            catch (Exception ex)
            {                
                throw new Exception (ex.InnerException+ex.Message);
            }
        }
        public IList<TLMDTO00001> MAinEncashPrint(string typename)
        {
            try
            {
                string budgetyear = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);
                IList<TLMDTO00001> EncashRemittanceDTOList = CXClientWrapper.Instance.Invoke<IMNMSVE00156, IList<TLMDTO00001>>(x => x.GetEncashRemittanceLists(typename, CurrentUserEntity.BranchCode, budgetyear));
                return EncashRemittanceDTOList;
            }
            catch (Exception ex)
            {                
                throw new Exception (ex.InnerException+ex.Message);
            }
        }
        #endregion
    }
}
