//----------------------------------------------------------------------
// <copyright file="TLMVEW00006.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Ye Mann Aung</CreatedUser>
// <CreatedDate>26/09/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Tel.Ptr
{
    public class TLMCTL00017 : AbstractPresenter, ITLMCTL00017
    {

        #region Properties
        private ITLMVEW00017 view;
        public ITLMVEW00017 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ITLMVEW00017 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetPassingData());
            }
        }

        public string PassingStatus { get; set; }

        #endregion

        #region HelperMethods

        public IList<TLMDTO00017> GetRDData(string status)
        {
            string sourceBr = CurrentUserEntity.BranchCode;
            this.View.RDDto = CXClientWrapper.Instance.Invoke<ITLMSVE00017, IList<TLMDTO00017>>(service => service.SelectRegisterNoBySendDate(status,sourceBr,DateTime.Now));
            return this.View.RDDto;
        }
        public IList<TLMDTO00001> GetREData(string sourceBranch)
            //public IList<TLMDTO00001> GetREData()
        {
            this.View.REDTO = CXClientWrapper.Instance.Invoke<ITLMSVE00017, IList<TLMDTO00001>>(service => service.SelectRemittanceEncashData(sourceBranch));
            //this.View.REDTO = CXClientWrapper.Instance.Invoke<ITLMSVE00017, IList<TLMDTO00001>>(service => service.SelectRemittanceEncashData());
            return this.View.REDTO;
        }

        public TLMDTO00056 GetPassingData()
        {
            TLMDTO00056 rawdto = new TLMDTO00056();
            rawdto.RegisterNo = this.View.RegisterNo;
            rawdto.SourceBranch = CurrentUserEntity.BranchCode;
            rawdto.Br_Alias = rawdto.SourceBranch + "( " + CurrentUserEntity.BranchDescription + " )";
            return rawdto;
        }

        #endregion

        #region Main Methods

        /// <summary>
        /// Passing Drawing Remittance Data for Multiple
        /// according to GridView Checkboxes checked.
        /// </summary>
        /// <param name="status"></param>
        public void PassingDrawingRemittanceByCheck(string status)
        {
            IList<TLMDTO00017> dto = this.View.RDDto.Where(x => x.IsChecked == true).ToList();

            foreach (TLMDTO00017 item in dto)
            {
                item.CreatedUserId = CurrentUserEntity.CurrentUserID;
            }

            foreach(TLMDTO00017 rddto in this.View.RDDto.Where(x => x.IsChecked.Equals(true)))
            {
                rddto.IsChecked = true;
            }
            CXClientWrapper.Instance.Invoke<ITLMSVE00017>(service => service.PassingRDDataList(dto,CurrentUserEntity.BranchCode));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
            {
                foreach (TLMDTO00017 item in dto)
                {
                    this.View.AddStatusToListbox(item.RegisterNo + " failed.");
                }
                this.View.BindGridData();
            }
            else
            {
                foreach (TLMDTO00017 item in dto)
                {
                    this.View.AddStatusToListbox(item.RegisterNo + " successed.");
                    this.View.RDDto.Remove(item);
                }
                this.View.BindGridData();
            }
        }

        /// <summary>
        /// Passing DrawingRemittence Data by Timer
        /// </summary>
        public bool PassingDrawingRemittanceByTimer()
        {
            IList<TLMDTO00017> dtolist = this.View.RDDto.Where(x => x.IsChecked != true && x.IsFailed == false).ToList();
            
            if (dtolist.Count != 0)
            {
                TLMDTO00017 dto = dtolist.First();
                dto.CreatedUserId = CurrentUserEntity.CurrentUserID;
                try
                {
                    this.PassingStatus = CXClientWrapper.Instance.Invoke<ITLMSVE00017, string>(service => service.PassingRDData(dto));
                }
                catch
                {
                    this.PassingStatus = " failed.";
                }
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    this.View.RDDto[this.View.RDDto.IndexOf(dto)].IsFailed = true;
                    this.View.AddStatusToListbox(dto.RegisterNo + this.PassingStatus);
                    return false;
                }
                else
                {
                    this.View.RDDto.Remove(dto);
                    this.View.AddStatusToListbox(dto.RegisterNo + this.PassingStatus);
                    return true;
                }
            }
            return false;
        }



        /// <summary>
        /// Manager Approved Form for Encash Remittance Data Passing
        /// </summary>
        /// <param name="index"></param>
        public bool ApprovedData(int index)
        {
            //return true;
            TLMDTO00001 redto = this.View.REDTO[index];

            if (redto.TestKey != null)
            {
                if (CXUIScreenTransit.Transit("frmCXCLE00016", true, new object[] { this.View.ParentFormId, (Convert.ToInt32(redto.TestKey.Value)).ToString(), CXDMD00006.Encash, CurrentUserEntity.BranchCode, redto.Date_Time, redto.Amount, this.view.CurrentFormPermissionEntity ,true}) == DialogResult.OK)
                {
                    //redto.UserNo = CurrentUserEntity.CurrentUserName;    //requested by Ma KSWin (BugNo. 502 - 10-Nov-2014)
                    redto.UserNo = CurrentUserEntity.CurrentUserID.ToString();
                    redto.CreatedUserId = CurrentUserEntity.CurrentUserID;
                    redto.POStatus = (String.IsNullOrEmpty(redto.ToAccountNo)) ? true : (redto.ToAccountNo.Length.Equals(15)) ? false : true;
                    string PONo = CXClientWrapper.Instance.Invoke<ITLMSVE00017, string>(x => x.PassingREData(redto));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        this.view.EncashPassingFail(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        return false;
                    }

                    else
                    {
                        this.view.EncashPasingSuccessful(CXClientWrapper.Instance.ServiceResult.MessageCode, PONo, redto.RegisterNo, redto.Amount);
                        return true;
                    }
                }
            }
            else
            { Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00090"); }
            
            return false;
        }
        #endregion
    }
}