//----------------------------------------------------------------------
// <copyright file="TCMCTL00043.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-11-20</CreatedDate>
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
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Tcm.Ctr.Sve;

namespace Ace.Cbs.Tcm.Ptr
{
    /// <summary>
    /// Clearing Posting Controller
    /// </summary>
    public class TCMCTL00043 : AbstractPresenter, ITCMCTL00043
    {
        #region "WireTo"
        private ITCMVEW00043 clearingpostingView;
        public ITCMVEW00043 ClearingPostingView
        {
            get { return this.clearingpostingView; }
            set { this.WireTo(value); }
        }

        private void WireTo(ITCMVEW00043 view)
        {
            if (this.clearingpostingView == null)
            {
                this.clearingpostingView = view;
                this.Initialize(this.clearingpostingView, ClearingPostingView);
            }
        }
        #endregion

        #region"Methods"
        /// <summary>
        /// To Bind Grid View,Get Data Lists from TLF Table
        /// </summary>
        /// <returns>PFMDTO00054 TLF List</returns>
        public IList<PFMDTO00054> GetTLFList()
        {
            IList<PFMDTO00054> TLFDTOList = new List<PFMDTO00054>();           
                TLFDTOList = CXClientWrapper.Instance.Invoke<ITCMSVE00043, PFMDTO00054>(x => x.GetClearingPostingTLFList(CurrentUserEntity.BranchCode));
                if (!TLFDTOList.Count.Equals(0))
                {
                    for (int i = 0; i < TLFDTOList.Count; i++)
                    {
                        if (TLFDTOList[i].CLRPostStatus == "Y")
                        {
                            TLFDTOList[i].IsCheck = true;
                            TLFDTOList[i].SourceBranchCode = CurrentUserEntity.BranchCode;
                        }
                        else
                        {
                            TLFDTOList[i].IsCheck = false;
                            TLFDTOList[i].SourceBranchCode = CurrentUserEntity.BranchCode;
                        }
                    }
                }
                else
                {
                    //Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME00021);
                    return null;
                }
            return TLFDTOList;
        }

        /// <summary>
        /// This Method is Clearing Posting and Printing Transaction.
        /// </summary>
        /// <param name="TLFDTOList">TLFDTOList From Grid View</param>

        public void ClearingPosting(IList<PFMDTO00054> TLFDTOList)
        {
            /*------------Check Account No 15 .--------- */
            for (int i = 0; i < TLFDTOList.Count; i++)
            {
                if (!CXCLE00012.Instance.CheckAccountNoType(TLFDTOList[i].AccountNo, CXDMD00011.AccountNoType2))
                { return; }
            }

            /*------------It returns true or false when clearing posting from service.---------- */
            bool isPosting = CXClientWrapper.Instance.Invoke<ITCMSVE00043, bool>(x => x.ClearingPosting(TLFDTOList, CurrentUserEntity.CurrentUserID,DateTime.Now));

            /*-----------If It is Service Result is true ,Saving Account No and No Return check,Go to Printing Transaction.*/
            if (isPosting == true)
            {
                for (int i = 0; i < TLFDTOList.Count; i++)
                {
                    if (TLFDTOList[i].AccountSign.Substring(0, 1) == "S" && TLFDTOList[i].IsCheck == false)
                    {
                        PFMDTO00043 PrnfileDTO = new PFMDTO00043();
                        PrnfileDTO.AccountNo = TLFDTOList[i].AccountNo;
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00017, new object[] { TLFDTOList[i].AccountNo });
                        if (CXUIScreenTransit.Transit("frmPFMVEW00009", true, new object[] { this.clearingpostingView.GetMenuIDPermission(), PrnfileDTO, TLFDTOList[i].AccountSign, false }) == System.Windows.Forms.DialogResult.OK)
                        {
                        }                       
                    }
                }
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90001);
                this.clearingpostingView.BindGridView();
                
                this.clearingpostingView.HideShowChequeNo();
            }
            /*-----------If It is Service Result is false,Show Saving Error Message .*/
            else
            {
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME90000);
                }
            }

        }
        #endregion
    }
}
