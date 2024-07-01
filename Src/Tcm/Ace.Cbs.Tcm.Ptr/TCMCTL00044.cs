//----------------------------------------------------------------------
// <copyright file="TCMCTL00044.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-12-09</CreatedDate>
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
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Tcm.Ptr
{
    /// <summary>
    /// PO Printing Controller
    /// </summary>
    public class TCMCTL00044 : AbstractPresenter, ITCMCTL00044
    {
        #region "WireTo"
        private ITCMVEW00044 poprintingview;
        public ITCMVEW00044 POPrintingView
        {
            get { return this.poprintingview; }
            set { this.WireTo(value); }
        }

        private void WireTo(ITCMVEW00044 view)
        {
            if (this.poprintingview == null)
            {
                this.poprintingview = view;
                this.Initialize(this.poprintingview, POPrintingView);
            }
        }
        #endregion

        #region "Methods"
        /*To bind Gird View By User required Date.*/
        public IList<TLMDTO00001> SelectREDTOList(DateTime requireDate)
        {
           const int accountlength = 15;
           string branchCode = CXCOM00007.Instance.BranchCode;
            IList<TLMDTO00001> REDOList = CXClientWrapper.Instance.Invoke<ITCMSVE00044, IList<TLMDTO00001>>(service => service.SelectREDTOListForPOPrinting(requireDate, branchCode));
            for (int i = 0; i < REDOList.Count; i++)
            {
                REDOList[i].PONo = (REDOList[i].ToAccountNo == null) ? REDOList[i].PONo = string.Empty : REDOList[i].ToAccountNo;
                if (REDOList[i].PONo !=null)
                {
                    if (REDOList[i].ToAccountNo.Length != accountlength)
                    {
                        /*Get Budget Year "13-14" Format.*/
                        // decimal ggg = Convert.ToDecimal(4.5);
                        string budgetYear = "/" + CXCOM00010.Instance.GetBudgetYear3(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.BudgetYearCode), DateTime.Now);
                        REDOList[i].PONo = REDOList[i].ToAccountNo + budgetYear;
                    }                  

                }
                REDOList[i].ToName = REDOList[i].ToName + " ," + REDOList[i].ToAddress;
                REDOList[i].Status = (REDOList[i].PrintStatus == null || REDOList[i].PrintStatus == 0) ? "Not Printed" : REDOList[i].PrintStatus.Value.ToString() + " times printed.";
            }
            
            return REDOList;
        }
    

        /*Check Date*/
        public bool CheckDate()
        {
            bool IsgreaterTodayDate = CXCOM00006.Instance.IsExceedTodayDate(this.poprintingview.RequiredDate);
            if (IsgreaterTodayDate == true)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00129");
            }
            return IsgreaterTodayDate;
        }

        public IList<TLMDTO00001> SelectPOPrintingList(IList<TLMDTO00001> poprintinglist)
        {
            //IList<TLMDTO00001> bbb=
            
            return null;
        }

        public void dtpDate_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (this.CheckDate() == false)
            {
                this.POPrintingView.BindGridView();
            }
        }
        #endregion
    }
}
