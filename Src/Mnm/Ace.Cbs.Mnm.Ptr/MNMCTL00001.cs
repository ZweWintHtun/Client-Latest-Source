//----------------------------------------------------------------------
// <copyright file="MNMCTL00001.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>12/02/2013</CreatedDate>
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
using Ace.Cbs.Cx.Com.Utt;
using System.Windows.Forms;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Cx.Com.Ctr;

namespace Ace.Cbs.Mnm.Ptr
{
    class MNMCTL00001:AbstractPresenter,IMNMCTL00001
    {
        IList<MNMDTO00001> postingStatusList;

        #region properties
        IMNMVEW00001 view;
        public IMNMVEW00001 View
        {
            set { this.wierTo(value); }
            get { return this.view; }
        }
        private void wierTo(IMNMVEW00001 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }
        #endregion

        public void CheckClosing()
        {
            CXClientWrapper.Instance.Invoke<IMNMSVE00001>(x => x.CheckClosing(CurrentUserEntity.BranchCode));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                this.View.butProcess_Enable = false;
            }
            else
            {
                this.View.butProcess_Enable = true;
            }
        }

        public void Posting()
        {
            this.View.ProgressBar2Style = ProgressBarStyle.Marquee;
            postingStatusList = CXClientWrapper.Instance.Invoke<IMNMSVE00001, IList<MNMDTO00001>>(x => x.Posting(CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID));
            this.View.ProgressBar2Visible = false;
            if (postingStatusList == null || postingStatusList.Count <= 0)
            {
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
                else
                {
                    this.View.TimerProgress2.Start();
                    //Added By AAM(25-08-2017)
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90014); //Before Day Close Finished.
                    this.View.butProcess_Enable = false;
                }
            }
            else
            {
                this.View.TimerProgress.Start();

            }

        }

        public void Show_Loans_Posting_Message()
        {
            IList<MNMDTO00001> LoansPostingList = postingStatusList.Where<MNMDTO00001>(x => x.PostingName == "LOANSPOST").ToList();
            if (LoansPostingList.Count > 0 && LoansPostingList[0].Status == "1")
                CXUIMessageUtilities.ShowMessageByCode("MI30037", new object[] { "Loans " });  //{Loans} Posting Finished
            else if (LoansPostingList.Count > 0 && LoansPostingList[0].Status == "0")
            {
                string[] msgArr = LoansPostingList[0].MessageCode.Split(",".ToCharArray());
                if (msgArr.Length > 0)
                    CXUIMessageUtilities.ShowMessageByCode(msgArr[0], new object[] { msgArr[1] }); //Message From Service
                else
                    CXUIMessageUtilities.ShowMessageByCode(LoansPostingList[0].MessageCode); //Message From Service
            }
            else if (LoansPostingList.Count > 0 && LoansPostingList[0].Status == "2")
                CXUIMessageUtilities.ShowMessageByCode("MI30025", new object[] { "Loans " });   //Error Occur in {Loans} Posting.

            this.View.TimerProgress.Start();
        }

        public void Show_OverDraft_Posting_Message()
        {
            IList<MNMDTO00001> ODpostingList = postingStatusList.Where<MNMDTO00001>(x => x.PostingName == "ODPOST").ToList();
            if (ODpostingList.Count > 0 && ODpostingList[0].Status == "1")
                CXUIMessageUtilities.ShowMessageByCode("MI30037", new object[] { "Overdraft " });  //{Overdraft} Posting Finished
            else if (ODpostingList.Count > 0 && ODpostingList[0].Status == "0")
            {
                string[] msgArr = ODpostingList[0].MessageCode.Split(",".ToCharArray());
                if (msgArr.Length > 0)
                    CXUIMessageUtilities.ShowMessageByCode(msgArr[0], new object[] { msgArr[1] }); //Message From Service
                else
                    CXUIMessageUtilities.ShowMessageByCode(ODpostingList[0].MessageCode); //Message From Service
            }
            else if (ODpostingList.Count > 0 && ODpostingList[0].Status == "2")
                CXUIMessageUtilities.ShowMessageByCode("MI30025", new object[] { "Overdraft " });   //Error Occur in {Overdraft} Posting.

            this.View.TimerProgress.Start();
        }

        public void Show_CommitFee_Posting_Message()
        {
            IList<MNMDTO00001> CommitPostingList = postingStatusList.Where<MNMDTO00001>(x => x.PostingName == "COMFEEPOST").ToList();
            if (CommitPostingList.Count > 0 && CommitPostingList[0].Status == "1")
                CXUIMessageUtilities.ShowMessageByCode("MI30037", new object[] { "CommitFees " });  //{CommitFees} Posting Finished
            else if (CommitPostingList.Count > 0 && CommitPostingList[0].Status == "0")
            {
                string[] msgArr = CommitPostingList[0].MessageCode.Split(",".ToCharArray());
                if (msgArr.Length > 0)
                    CXUIMessageUtilities.ShowMessageByCode(msgArr[0], new object[] { msgArr[1] }); //Message From Service
                else
                    CXUIMessageUtilities.ShowMessageByCode(CommitPostingList[0].MessageCode); //Message From Service
            }
            else if (CommitPostingList.Count > 0 && CommitPostingList[0].Status == "2")
                CXUIMessageUtilities.ShowMessageByCode("MI30025", new object[] { "CommitFees " });   //Error Occur in {CommitFees} Posting.

            this.View.TimerProgress.Start();
        }

        public void Show_Saving_Posting_Message()
        {
            IList<MNMDTO00001> SavingPostingList = postingStatusList.Where<MNMDTO00001>(x => x.PostingName == "SAVINGPOST").ToList();
            if (SavingPostingList.Count > 0 && SavingPostingList[0].Status == "1")
                CXUIMessageUtilities.ShowMessageByCode("MI30037", new object[] { "Saving " });  //{Saving} Posting Finished
            else if (SavingPostingList.Count > 0 && SavingPostingList[0].Status == "0")
            {
                string[] msgArr = SavingPostingList[0].MessageCode.Split(",".ToCharArray());
                if (msgArr.Length > 0)
                    CXUIMessageUtilities.ShowMessageByCode(msgArr[0], new object[] { msgArr[1] }); //Message From Service
                else
                    CXUIMessageUtilities.ShowMessageByCode(SavingPostingList[0].MessageCode); //Message From Service
            }
            else if (SavingPostingList.Count > 0 && SavingPostingList[0].Status == "2")
                CXUIMessageUtilities.ShowMessageByCode("MI30025", new object[] { "Saving " });   //Error Occur in {Saving} Posting.

            this.View.TimerProgress.Start();
        }

        public void Show_Fixed_Posting_Message()
        {
            IList<MNMDTO00001> FixedPostingList = postingStatusList.Where<MNMDTO00001>(x => x.PostingName == "FIXEDPOST").ToList();
            if (FixedPostingList.Count > 0 && FixedPostingList[0].Status == "1")
                CXUIMessageUtilities.ShowMessageByCode("MI30037", new object[] { "Fixed " });  //{Fixed} Posting Finished
            else if (FixedPostingList.Count > 0 && FixedPostingList[0].Status == "0")
            {
                string[] msgArr = FixedPostingList[0].MessageCode.Split(",".ToCharArray());
                if (msgArr.Length > 0)
                    CXUIMessageUtilities.ShowMessageByCode(msgArr[0], new object[] { msgArr[1] }); //Message From Service
                else
                    CXUIMessageUtilities.ShowMessageByCode(FixedPostingList[0].MessageCode); //Message From Service
            }
            else if (FixedPostingList.Count > 0 && FixedPostingList[0].Status == "2")
                CXUIMessageUtilities.ShowMessageByCode("MI30025", new object[] { "Fixed " });   //Error Occur in {Fixed} Posting.
            CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90014); //Before Day Close Finished.
            this.View.butProcess_Enable = false;
        }

        public void Successful_Message()
        {
            CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90012); //Monthly Closing Successfully Finished.
            this.View.butProcess_Enable = false;
        }

        //Added by HMW at 16-10-2019 : [Seperating EOD Process] To get system date (not PC date)
        public DateTime GetSystemDate(string sourceBr)
        {
            TCMDTO00001 systemStartInfo = CXClientWrapper.Instance.Invoke<ICXSVE00006, TCMDTO00001>(x => x.SelectStartBySourceBr(sourceBr));
            DateTime systemDate = systemStartInfo.Date;
            return systemDate;
        }
    }
}
