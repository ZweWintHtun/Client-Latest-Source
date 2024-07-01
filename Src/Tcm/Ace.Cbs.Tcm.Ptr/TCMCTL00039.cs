using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Cx.Cle;
//using Ace.Cbs.Cx.Ser;
using Ace.Cbs.Cx.Com.Ctr;


namespace Ace.Cbs.Tcm.Ptr
{
    public class TCMCTL00039:AbstractPresenter,ITCMCTL00039
    {
        #region Properties
        private ITCMVEW00039 view;
        public ITCMVEW00039 View
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        public string StartDate { get; set; }
        public string EndDate { get; set; }
        #endregion

        #region Methods
        private void WireTo(ITCMVEW00039 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetViewData());
            }
        }

        public PFMDTO00042 GetViewData()
        {
            PFMDTO00042 ViewData = new PFMDTO00042();

            ViewData.ChequeType = this.view.ChequeType;
            ViewData.RequiredType = this.view.RequiredType;
            ViewData.StartDate = this.view.StartDate;
            ViewData.EndDate = this.view.EndDate;
            ViewData.AcctNo = this.view.CurrentAccountNo;
            ViewData.CreatedUserId = CurrentUserEntity.CurrentUserID;
            ViewData.SourceBranch = CurrentUserEntity.BranchCode;
            return ViewData;
        }

        public void mtxtAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (e.HasXmlBaseError != false)
            {
                return;
            }
            else
            {
                if (String.IsNullOrEmpty(this.View.CurrentAccountNo))
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), "MV00046");
                    return;
                }

                if (!string.IsNullOrEmpty(this.view.CurrentAccountNo.Trim()))
                {
                    //CXClientWrapper.Instance.Invoke<ITCMSVE00039, bool>(x => x.CheckIsSavingAccountNo(this.view.CurrentAccountNo, CurrentUserEntity.BranchCode));
                    //if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    //{
                    //    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), "MV00211", new object[] { "Current Account" });
                    //    return;
                    //}
                    //else
                    //{
                    //    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), string.Empty);
                    //}

                    //CXClientWrapper.Instance.Invoke<ICXSVE00006, bool>(x => x.IsClosedAccountForCLedger(this.view.CurrentAccountNo));

                    CXClientWrapper.Instance.Invoke<ITCMSVE00039>(x => x.CheckingChequeBookNo(this.view.CurrentAccountNo,CurrentUserEntity.BranchCode));                  
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                        return;
                    }

                    else
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), string.Empty);
                    }
                }
            }
        }

        public void Print()
        {
            PFMDTO00042 DataDTO = this.GetViewData();
            if (DataDTO.RequiredType == "By Date")
            {
                if (!CXCOM00006.Instance.IsExceedTodayDate(this.view.StartDate))
                {
                    if (!CXCOM00006.Instance.IsExceedTodayDate(this.view.EndDate))
                    {
                        if (this.view.StartDate.Date > this.view.EndDate.Date)
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00131");//Start Date must not be greater than End Date.
                        }
                        else
                        { this.GetPrintData(DataDTO); }
                    }
                    else
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00130");//End Date must not be greater than today. 
                    }
                }
                else
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00129");//Start Date must not be greater than today.
                }
            }
            else
            {
                if (this.ValidateForm(DataDTO))
                {
                    this.GetPrintData(DataDTO);
                }
            }
            
            //PFMDTO00042 DataDTO = this.GetViewData();
            //if (this.ValidateForm(DataDTO))
            //{
            //    if (DataDTO.RequiredType == "By Date")
            //    {
            //        if (!CXCOM00006.Instance.IsExceedTodayDate(this.view.StartDate))
            //        {
            //            if (!CXCOM00006.Instance.IsExceedTodayDate(this.view.EndDate))
            //            {
            //                if (this.view.StartDate > this.view.EndDate)
            //                {
            //                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00131");//Start Date must not be greater than End Date.
            //                }
            //                else
            //                {
            //                    this.GetPrintData(DataDTO);
            //                }
            //            }
            //            else
            //            {
            //                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00130");//End Date must not be greater than today.
            //            }
            //        }
            //        else
            //        {
            //            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00129");//Start Date must not be greater than today.
            //        }
            //    }
            //    else
            //    {
            //        if (this.ValidateForm(DataDTO))
            //        {
            //            this.GetPrintData(DataDTO);
            //        }
            //    }
            //}
        }


        public void GetPrintData(PFMDTO00042 DTO)
        {
          

            #region Report Column Name
            string SrNo = "SrNo.";
            string AccountNo = "Account No.";
            string ChequeBookNo = "Cheque Book No.";
            string IssueDate = "Date";
            string ChequeNo = "Cheque No.";
            string Branch = "Branch";
            string StartNo = "Start No.";
            string EndNo = "End No.";
            string Remark = "Remark";
            string head = string.Empty;

            #endregion

            if (DTO.ChequeType == "Issued Cheque")
            {
                head = "Cheque Book Listing";
                IList<PFMDTO00006> IssuedChequeLists = new List<PFMDTO00006>();
                IssuedChequeLists = CXClientWrapper.Instance.Invoke<ITCMSVE00039, IList<PFMDTO00006>>(x => x.GetIssuedChequeData(DTO));
                if (!CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    if (IssuedChequeLists.Count > 0)
                    {
                        StartDate = view.StartDate.ToString("dd/MM/yyyy");
                        EndDate = view.EndDate.ToString("dd/MM/yyyy");
                        if (DTO.RequiredType == "By Date")
                        { CXUIScreenTransit.Transit("frmChequeListingReport", true, new object[] { IssuedChequeLists, StartDate, EndDate, SrNo, AccountNo, ChequeBookNo, IssueDate, StartNo, EndNo, head, Remark }); }
                        else
                        { CXUIScreenTransit.Transit("frmChequeListingReport", true, new object[] { IssuedChequeLists, view.CurrentAccountNo, SrNo, AccountNo, ChequeBookNo, IssueDate, StartNo, EndNo, head }); }

                    }
                    else
                    {
                        //if IssuedChequeLists is null
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Print.
                    }
                }
                
                
            }
            else if (DTO.ChequeType == "Stopped Cheque")
            {
                head = "Stop Cheque Listing";
                IList<PFMDTO00011> StoppedChequeLists = new List<PFMDTO00011>();
                StoppedChequeLists = CXClientWrapper.Instance.Invoke<ITCMSVE00039, IList<PFMDTO00011>>(x => x.GetStoppedChequeData(DTO));
                if (StoppedChequeLists.Count > 0)
                {
                    StartDate = view.StartDate.ToString("dd/MM/yyyy");
                    EndDate = view.EndDate.ToString("dd/MM/yyyy");
                    if (DTO.RequiredType == "By Date")
                    { CXUIScreenTransit.Transit("frmChequeListingReport", true, new object[] { StoppedChequeLists, StartDate, EndDate, SrNo, AccountNo, ChequeBookNo, IssueDate, StartNo, EndNo, Remark, head }); }   //edit by ASDA
                    else
                    { CXUIScreenTransit.Transit("frmChequeListingReport", true, new object[] { StoppedChequeLists, view.CurrentAccountNo, SrNo, AccountNo, ChequeBookNo, IssueDate, StartNo, EndNo, Remark, head}); }  //edit by ASDA

                }
                else
                {
                    //if StoppedChequeLists is null
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Print.
                }
            }
            else
            {
                head = "Print Cheque Listing";
                IList<PFMDTO00014> PrintedChequeLists = new List<PFMDTO00014>();
                PrintedChequeLists = CXClientWrapper.Instance.Invoke<ITCMSVE00039, IList<PFMDTO00014>>(x => x.GetPrintedChequeData(DTO));
                if (PrintedChequeLists.Count > 0)
                {
                    StartDate = view.StartDate.ToString("dd/MM/yyyy");
                    EndDate = view.EndDate.ToString("dd/MM/yyyy");
                    if (DTO.RequiredType == "By Date")
                    { CXUIScreenTransit.Transit("frmChequeListingReport", true, new object[] { PrintedChequeLists, StartDate, EndDate, SrNo, AccountNo, ChequeBookNo, IssueDate, ChequeNo, Branch, head,Remark }); }
                    else
                    { CXUIScreenTransit.Transit("frmChequeListingReport", true, new object[] { PrintedChequeLists, view.CurrentAccountNo, SrNo, AccountNo, ChequeBookNo, IssueDate, ChequeNo, Branch, head }); }

                }
                else
                {
                    //if PrintedChequeLists is null
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Print.
                }
            }
    
        }

        public void ClearErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }
        #endregion
    }
}
