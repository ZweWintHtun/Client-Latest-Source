//----------------------------------------------------------------------
// <copyright file="TCMCTL00015.cs" company="ACE Data Systems">
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
using Ace.Cbs.Tel.Dmd;
namespace Ace.Cbs.Tcm.Ptr
{
    /// <summary>
    /// Shut Down Controller
    /// </summary>
    public class TCMCTL00015 : AbstractPresenter, ITCMCTL00015
    {
        #region Initialize View
        private ITCMVEW00015 view;
        public ITCMVEW00015 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private void WireTo(ITCMVEW00015 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetSystemShutDownEntity());
            }
        }
        #endregion
        #region Helper Methods
        private TCMDTO00001 GetSystemShutDownEntity()
        {
            TCMDTO00001 startDTO = new TCMDTO00001();
            startDTO.BankHead = this.view.BankHead;
            startDTO.Status = this.view.Status;
            return startDTO;
        }
        #endregion
        #region Variables
        public bool shutdownstatus = false;
        #endregion
        #region UI Logic
        public bool BindInitialData()
        {
            TCMDTO00001 startdto = CXClientWrapper.Instance.Invoke<ITCMSVE00014, TCMDTO00001>(x => x.SelectStartBySourceBr(CurrentUserEntity.BranchCode));
            if (startdto != null)
            {
                this.view.BankHead = startdto.BankHead;
                this.view.SystemDate = startdto.Date.ToLongDateString();
                #region Start.Date != TodayDate
                if (startdto.Date.ToString("dd/MM/yyyy") != DateTime.Now.ToString("dd/MM/yyyy"))
                {
                    if (startdto.Status == "C")
                    {
                        this.view.Status = "Need to Shut down for " + startdto.Date.ToString("dd-MMMM-yyyy") + ".";
                        shutdownstatus = true;
                        return shutdownstatus;
                    }
                    else
                    {
                        this.view.Status = "Already Shutdown.";
                        shutdownstatus = false;
                        return shutdownstatus;
                    }
                }
                #endregion
                #region Start.Date = TodayDate
                else
                {
                    if (startdto.Status == "I")
                    {
                        this.view.Status = "Need to Startup. Already Shutdown.";
                        shutdownstatus = false;
                        return shutdownstatus;
                    }
                    else
                    {
                        this.view.Status = "Need to Shutdown.";
                        shutdownstatus = true;
                        return shutdownstatus;

                    }
                }
                #endregion
            }

            return shutdownstatus;
        }

        public bool CheckAutoPayAndLateFeeCalculateProcess()
        {
            if (CXClientWrapper.Instance.Invoke<ITCMSVE00015, bool>(x => x.CheckBLLateFeeAutoVoucherProcessRun(CurrentUserEntity.BranchCode)))
            {
                shutdownstatus = true;
            }
            else
            {
                shutdownstatus = false;
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI90120");//Please run 'Business Loan' late fee auto pay process first!
            }            
            if (CXClientWrapper.Instance.Invoke<ITCMSVE00015, bool>(x => x.CheckBLAutoPayment(CurrentUserEntity.BranchCode)))
            {
                shutdownstatus = true;
            }
            else
            {
                shutdownstatus = false;
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI90123");//Please Run 'Business Loan' Installment Auto Pay Process First!
            }            
            //Added by HWKo (16-Nov-2017)
            if (CXClientWrapper.Instance.Invoke<ITCMSVE00015, bool>(x => x.CheckPLLateFeeAutoVoucherProcessRun(CurrentUserEntity.BranchCode)))
            {
                shutdownstatus = true;
            }
            else
            {
                shutdownstatus = false;
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI90122");//Please run 'Personal Loan' late fee auto pay process first!
            }
            //End Region
            if (CXClientWrapper.Instance.Invoke<ITCMSVE00015, bool>(x => x.CheckPLAutoPayment(CurrentUserEntity.BranchCode)))
            {
                shutdownstatus = true;
            }
            else
            {
                shutdownstatus = false;
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI90119");//Please Run 'Personal Loan' Installment Auto Pay Process First!
            }
            if (CXClientWrapper.Instance.Invoke<ITCMSVE00015, bool>(x => x.CheckHPLateFeeAutoVoucherProcessRun(CurrentUserEntity.BranchCode)))
            {
                shutdownstatus = true;
            }
            else
            {
                shutdownstatus = false;
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI90121");//Please run 'Hire Purchase' late fee auto pay process first!
            }
            if (CXClientWrapper.Instance.Invoke<ITCMSVE00015, bool>(x => x.CheckHPAutoPayment(CurrentUserEntity.BranchCode)))
            {
                shutdownstatus = true;
            }
            else
            {
                shutdownstatus = false;
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI90118");//Please run 'Hire Purchase' installment auto pay process first!
            }
            //if (CXClientWrapper.Instance.Invoke<ITCMSVE00015, bool>(x => x.CheckBLLateFeeCalculate(CurrentUserEntity.BranchCode)))
            //{
            //    shutdownstatus = true;
            //}
            //else
            //{
            //    shutdownstatus = false;
            //    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI90120");//Please Run Business Loan Late Fee Calculation Process First!
            //}
            //if (CXClientWrapper.Instance.Invoke<ITCMSVE00015, bool>(x => x.CheckHPLateFeeCalculate(CurrentUserEntity.BranchCode)))
            //{
            //    shutdownstatus = true;
            //}
            //else
            //{
            //    shutdownstatus = false;
            //    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI90121");//Please Run Hire Purchase Loan Late Fee Calculation Process First!
            //}            
            //if (CXClientWrapper.Instance.Invoke<ITCMSVE00015, bool>(x => x.CheckPLLateFeeCalculate(CurrentUserEntity.BranchCode)))
            //{
            //    shutdownstatus = true;
            //}
            //else
            //{
            //    shutdownstatus = false;
            //    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI90122");//Please Run Personal Loan Late Fee Calculation Process First!
            //}

            return shutdownstatus;
        }

        public void ShutDown()
        {
            //Comment by HMW at 09-Aug-2019
            //if (shutdownstatus)
            //{
                //IList<TLMDTO00018> loans = CXClientWrapper.Instance.Invoke<ITCMSVE00015, IList<TLMDTO00018>>(x => x.InsuranceExpiredLoansListing(CurrentUserEntity.BranchCode, System.DateTime.Now));
                //if (loans.Count > 0)
                //{
                //    CXUIScreenTransit.Transit("frmTCMVEW00064", new object[] { loans });
                //}
                //else
                //{
                //    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI50008");
                //}

                if (CXClientWrapper.Instance.Invoke<ITCMSVE00015, bool>(x => x.CheckVaultBalance(CurrentUserEntity.BranchCode)))
                {
                    this.view.BindReconsileGrid();
                    this.view.NeedForShutDown();

                }
                else
                {
                    if (Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC30004) == DialogResult.Yes)
                    {
                        this.view.BindReconsileGrid();
                        this.view.NeedForShutDown();
                    }
                }

            //}
        }
        public void CommonShutDown()
        {
            if (Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC00021) == DialogResult.Yes)
            {
                //CXClientWrapper.Instance.Invoke<ITCMSVE00015>(x => x.ShutDown(true, CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID));
                CXClientWrapper.Instance.Invoke<ITCMSVE00015>(x => x.ShutDown(shutdownstatus, CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID));//Modify by HMW at 08-Aug-2019

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
                else
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI50006);
                    this.view.CLoseForm();
                }
            }
        }
        public IList<PFMDTO00028> BindReconsile()
        {
            IList<PFMDTO00028> cledgers = CXClientWrapper.Instance.Invoke<ITCMSVE00015, IList<PFMDTO00028>>(x => x.DailyReconsile(CurrentUserEntity.BranchCode));
            return cledgers;
        }
        #endregion
    }
}
