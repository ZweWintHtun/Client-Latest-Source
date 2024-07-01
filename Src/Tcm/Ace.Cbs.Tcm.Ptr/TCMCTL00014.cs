//----------------------------------------------------------------------
// <copyright file="TCMCTL00014.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Tcm.Dmd;
using Ace.Windows.CXClient;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;
using System.Windows.Forms;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Client.Utt;

namespace Ace.Cbs.Tcm.Ptr
{
    public class TCMCTL00014 : AbstractPresenter, ITCMCTL00014
    {
        #region Initialize View
        private ITCMVEW00014 view;
        public ITCMVEW00014 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private void WireTo(ITCMVEW00014 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetSystemStartUpEntity());
            }
        }
        #endregion

        #region Variables
        public TCMDTO00001 StartDTO { get; set; }
        public bool isMainMenuEnabled { get; set; }
        //IList<DataVersionChangedValueDTO> dvcvListInfo { get; set; }
        #endregion

        #region Helper Methods
        private TCMDTO00001 GetSystemStartUpEntity()
        {
            TCMDTO00001 startDTO = new TCMDTO00001();
            startDTO.BankHead = this.view.BankHead;
            startDTO.Status = this.view.Status;
            return startDTO;
        }
        #endregion
        #region UI Logic
        public TCMDTO00001 BindInitialData()
        {
            TCMDTO00001 startdto = CXClientWrapper.Instance.Invoke<ITCMSVE00014, TCMDTO00001>(x => x.SelectStartBySourceBr(CurrentUserEntity.BranchCode));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
            {
                this.view.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                this.view.DisableSystemInfo();              
                return null;
            }
            if (startdto != null)
            {
                this.view.BankHead = startdto.BankHead;
                //this.view.SystemDate = startdto.Date.ToShortDateString();

                #region OLD Logic (OK)
                    //this.view.SystemDate = System.DateTime.Now.ToShortDateString();               

                    //#region Start.Date != TodayDate
                    //if (startdto.Date.ToString("dd/MM/yyyy") != DateTime.Now.ToString("dd/MM/yyyy"))
                    //{
                    //    if (startdto.Status == "C")
                    //    {
                    //        this.view.Status = "Need to Shut down for " + startdto.Date.ToString("dd/MMMM/yyyy");
                    //        //this.View.DisableExitButton(true);
                    //    }
                    //    else
                    //    {
                    //        this.view.Status = "Need to Startup.";
                    //        //this.view.NeedToStartUp = "Need to Run Back Date Fixed Deposit Auto Renewal.";
                        
                    //       // this.view.ToShowNeedToStartUpLabel();
                    //    }
                    //}
                    //#endregion
                    //#region Start.Date = TodayDate
                    //else
                    //{
                    //    if (startdto.Status == "C")
                    //    {
                    //        this.view.Status = "Already Startup.";
                    //        //this.View.DisableExitButton(true);
                    //    }
                    //    else
                    //    {
                    //        this.view.Status = "Need to Startup.";
                    //        //this.view.ToShowNeedToStartUpLabel();
                    //        //this.View.DisableExitButton(false);
                    //    }
                    //}
                    //#endregion

                #endregion

                #region New Logic (Seperating EOD Process)
                DateTime lastSettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("LastSettlementDate"), CurrentUserEntity.BranchCode, true });

                if (startdto.Status == "C")
                {
                    this.view.SystemDate = startdto.Date.ToString("dd-MMMM-yyyy");
                }
                else
                {
                    this.view.SystemDate = System.DateTime.Now.ToString("dd-MMMM-yyyy");
                }

                #region Start.Date != TodayDate          
                if ((startdto.Date.ToString("dd/MM/yyyy") == lastSettlementDate.ToString("dd/MM/yyyy")) && (startdto.Date.ToString("dd/MM/yyyy") != DateTime.Now.ToString("dd/MM/yyyy")))
                {
                    if (startdto.Status == "C")
                    {
                        this.view.Status = "Need to complete the previous day ''EOD Process'' firstly\n\n"+ "and ''Shut Down'' for " + startdto.Date.ToString("dd-MMMM-yyyy");
                    }
                    else
                    {
                        this.view.Status = "Need to Startup!";
                    }

                }
                else if ((startdto.Date.ToString("dd/MM/yyyy") != lastSettlementDate.ToString("dd/MM/yyyy")) && (startdto.Date.ToString("dd/MM/yyyy") != DateTime.Now.ToString("dd/MM/yyyy")))
                {
                    if (startdto.Status == "C")
                    {
                        this.view.Status = "Need to Shut Down for " + startdto.Date.ToString("dd-MMMM-yyyy");
                    }
                    else
                    {
                        this.view.Status = "Need to Startup!";
                    }
                }

                #endregion
                #region Start.Date = TodayDate
                else
                {
                    if (startdto.Status == "C")
                    {
                        this.view.Status = "Already Startup the System!";
                    }
                    else
                    {
                        this.view.Status = "Need to Startup!";
                    }
                }
                #endregion

                #endregion
                this.StartDTO = startdto;
            }
            return this.StartDTO;
        }
        public bool StartUp()
        {
            #region StartUp
            this.StartDTO.SourceBr = CurrentUserEntity.BranchCode;
            this.StartDTO.UpdatedUserId = CurrentUserEntity.CurrentUserID;
            if (CXClientWrapper.Instance.Invoke<ITCMSVE00014, bool>(x => x.StartUp(this.StartDTO)))
            {
                // Remove comment if you want to check 
                //#region Fixed Interest Date Validate Message
                //if (this.StartDTO.FixInterestDate != DateTime.Now)
                //{
                //    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00215); //Need to Run Back Date Fixed Deposit Auto Renewal.
                //}
                //#endregion
                this.view.Successful(CXMessage.MI50004);

                #region GetCurRate()

                //Do you want to carry on Currency Rate from {0} ?
                if (Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC30003, new object[] { DateTime.Now }) == System.Windows.Forms.DialogResult.Yes)
                {
                    IList<PFMDTO00075> rateinfos = CXClientWrapper.Instance.Invoke<ITCMSVE00014, IList<PFMDTO00075>>(x => x.SelectAllByLastModify());  //current rateinfo
                    IList<PFMDTO00075> newrateinfos = new List<PFMDTO00075>();
                    int i = 1;
                    IList<DataVersionChangedValueDTO> dvcvListInfo = new List<DataVersionChangedValueDTO>();
                    foreach (PFMDTO00075 oldratedata in rateinfos)
                    {
                        PFMDTO00075 newratedto = new PFMDTO00075();
                        newratedto.Id = oldratedata.Id;
                        newratedto.CurrencyCode = oldratedata.CurrencyCode;
                        newratedto.RateType = oldratedata.RateType;
                        newratedto.Rate = oldratedata.Rate;
                        newratedto.DenoRate = oldratedata.DenoRate;
                        newratedto.RegisterDate = oldratedata.RegisterDate;
                        newratedto.LastModify = false;
                        newratedto.ToCurrencyCode = oldratedata.ToCurrencyCode;
                        newratedto.CreatedUserId = oldratedata.CreatedUserId;
                        newratedto.CreatedDate = oldratedata.CreatedDate;
                        newratedto.UpdatedDate = DateTime.Now;
                        newratedto.UpdatedUserId = CurrentUserEntity.CurrentUserID;

                        IList<DataVersionChangedValueDTO> dvcvList = GetChangedValueOfObject.GetChangedValueList(oldratedata, newratedto);
                        foreach (DataVersionChangedValueDTO dvcvDto in dvcvList)
                        {
                            dvcvListInfo.Add(dvcvDto);

                        }
                        newrateinfos.Add(newratedto);
                        i++;
                    }
                    CXClientWrapper.Instance.Invoke<ITCMSVE00014>(x => x.UpdateRateInfo_ForCurRate(CurrentUserEntity.CurrentUserID, DateTime.Now, dvcvListInfo, i, newrateinfos, rateinfos));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == true)
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }
                #endregion

                //Remove Comment if you want to calculate service charges
                //Do you want to calculate Service Charges FOR {0}?
                //#region CalculateServiceCharges()
                //if (Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC30005, new object[] { DateTime.Now.ToString("dd/MM/yyyy") }) == System.Windows.Forms.DialogResult.Yes)
                //{
                //    CXClientWrapper.Instance.Invoke<ITCMSVE00014>(x => x.CalculateServiceCharge(CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode));
                //    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == true)
                //    {
                //        this.view.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                //    }
                //    else
                //    {
                //        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00142);
                //    }
                //}
                //#endregion
                return true;
            }
            else
            {
                #region Error
                if (CXClientWrapper.Instance.ServiceResult.MessageCode == CXMessage.ME00066)
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME00066, new object[] { this.StartDTO.Date.ToString("dd/MM/yyyy") });
                    return false;
                }
                else
                {
                    this.view.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
                #endregion
                return false;
            }
            #endregion
            //if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
            //{
            //    this.view.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            //}
        }
        #endregion
    }
}
