﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Ptr
{
    class LOMCTL00216 : AbstractPresenter, ILOMCTL00216
    {
        string filterStatus;
        private ILOMVEW00216 view;
        public ILOMVEW00216 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00216 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }

        //public IList<LOMDTO00214> HPAbsentHistoryListing(DateTime startDate, DateTime endDate, string acctno, string sourceBr)
        //{
        //    return CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00214>>(x =>x.HPAbsentHistoryListing(startDate,endDate,acctno,sourceBr));
        //}

        public void Print(string rptName, DateTime startDate, DateTime endDate,string acctno, string sourceBr)
        {
            IList<LOMDTO00214> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00214>>(x => x.HPAbsentHistoryListing(startDate,endDate,acctno,sourceBr));
            if (DTOList==null || DTOList.Count==0 )
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
            }
            else //if (DTOList.Count > 0)
            {
                string header = "Hire Purchase Repayment History Listing";
                string sourcebranch = this.view.SourceBr.ToString();
                CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, header, sourcebranch, startDate.ToString("dd/MM/yyyy"), endDate.ToString("dd/MM/yyyy"), rptName });
            }
        }
    }
}
