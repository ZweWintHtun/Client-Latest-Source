//----------------------------------------------------------------------
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>HM</CreatedUser>
// <CreatedDate>11/01/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Mnm.Ptr
{

    class MNMCTL00043 : AbstractPresenter, IMNMCTL00043
    {
        public string month { get; set; }
        public string str_month { get; set; }
      
        private IMNMVEW00043 view;
        public IMNMVEW00043 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(IMNMVEW00043 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetVlaidateData());
            }
        }

        public bool Validate_Form()
        {
            return this.ValidateForm(this.GetVlaidateData());
        }

        public void ClearCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }

        public IList<BranchDTO> GetAllBranchList()
        {
            return CXCLE00002.Instance.GetListObject<BranchDTO>("Branch.Client.Select").ToList();
        }

        private MNMDTO00010 GetVlaidateData()
        {
            MNMDTO00010 ValidateDto = new MNMDTO00010();
            ValidateDto.CUR = this.view.currencyNo;
            ValidateDto.BUDGET = this.view.Year;
            ValidateDto.Month = this.view.Month;
            return ValidateDto;
        }

        public void txtYear_CustomValidate(object sender, ValidationEventArgs e)
        {
            if (!e.HasXmlBaseError)
            {
                int YearValue = 0;
                string budget = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);
                // Check Null or Empty
                if (string.IsNullOrEmpty(this.view.Year))
                    this.SetCustomErrorMessage(this.GetControl("txtYear"), "MV30002");
                else if (!int.TryParse(this.view.Year, out YearValue))
                    this.SetCustomErrorMessage(this.GetControl("txtYear"), "MV30002"); // Check text box value is int
                else if ((YearValue != Convert.ToInt32(budget.Substring(0,4))) && (YearValue != Convert.ToInt32(budget.Substring(5,4))))
                    this.SetCustomErrorMessage(this.GetControl("txtYear"), "MV30002"); // Check valid Year or not

            }
        }

        public void txtMonth_CustomValidate(object sender, ValidationEventArgs e)
        {
            if (!e.HasXmlBaseError)
            {
                string date_str;
                int MonthValue = 0;

                if (string.IsNullOrEmpty(this.view.Month))
                    this.SetCustomErrorMessage(this.GetControl("txtMonth"), "MV00221");// Check Null or Empty
                else if (!int.TryParse(this.view.Month, out MonthValue))
                {

                }
                 

                else if (MonthValue > 12 || MonthValue < 1)
                    this.SetCustomErrorMessage(this.GetControl("txtMonth"), "MV00221");// Check valid Month or not
                else
                {
                    // Date time correct
                    this.month = this.str_month = this.view.Month;
                    date_str = "20," + month + ",2013";
                    System.Globalization.CultureInfo theCultureInfo = new System.Globalization.CultureInfo("en-GB", true);
                    this.view.Month = DateTime.ParseExact(date_str, "dd,M,yyyy", theCultureInfo).ToString("MMMMM");
                   
                }
            }
        }

        public IList<MNMDTO00010> SelectTrialBalanceDetail(string Branchno, string Currency, int Month,bool ishome)
        {
            IList<MNMDTO00010> trialDetailList = CXClientWrapper.Instance.Invoke<IMNMSVE00091, IList<MNMDTO00010>>(x => x.SelectTrialBalanceDetail(Branchno, CurrentUserEntity.BranchCode, Currency, Month, ishome));
            IList<MNMDTO00010> transactionlist = new List<MNMDTO00010>();
            if (trialDetailList.Count > 0 || trialDetailList != null)
            {
                foreach (MNMDTO00010 data in trialDetailList)
                {
                    MNMDTO00010 list = new MNMDTO00010();
                    if (Convert.ToDouble(data.COAamount) != 0.0)
                    {
                        list.ACODE = data.ACODE;
                        list.ACNAME = data.ACNAME;
                        list.COAamount = data.COAamount;
                        list.ACTYPE = data.ACTYPE;
                        transactionlist.Add(list);
                    }
                }
                return transactionlist;
            }
           
            return transactionlist;
        }
     
    }
}
