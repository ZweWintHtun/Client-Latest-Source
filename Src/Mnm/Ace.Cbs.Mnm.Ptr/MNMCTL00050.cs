//----------------------------------------------------------------------
// <copyright file="MNMCTL00001.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>HM</CreatedUser>
// <CreatedDate>12/27/2013</CreatedDate>
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
using Ace.Cbs.Pfm.Dmd;
using System.Windows.Forms;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Mnm.Ptr
{
    class MNMCTL00050 : AbstractPresenter, IMNMCTL00050
    {
      
        #region properties

        IMNMVEW00050 view;
        public IMNMVEW00050 View
        {
            set { this.wierTo(value); }
            get { return this.view; }
        }

        #endregion

        #region Validation Method
        private void wierTo(IMNMVEW00050 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetInterestSchedule());
            }
        }

        public PFMDTO00040 GetInterestSchedule()
        {
            PFMDTO00040 entity = new PFMDTO00040(); 
            entity.Budget = this.view.RequiredYear;
            entity.CurrencyCode = this.view.Currency;
        

            return entity;
        }

        public void ClearCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }

        public void mtxtRequiredYear_CustomValidate(object sender, ValidationEventArgs e)
        {
            string budget = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);

            string[] strArr = budget.Split('/');
            int[] intArr = new int[2];
            intArr[0] = int.Parse(strArr[0]);
            intArr[1] = int.Parse(strArr[1]);

            string prev_budget = (intArr[0] - 1).ToString() + "/" + (intArr[1] - 1).ToString();

            if (budget != this.View.RequiredYear && prev_budget != this.View.RequiredYear)
            {
                this.SetCustomErrorMessage(this.GetControl("mtxtRequiredYear"), "MV00144");
            }
            else
            {
                this.SetCustomErrorMessage(this.GetControl("mtxtRequiredYear"), string.Empty);
            }
        }

        public bool Validate()
        {
            return this.ValidateForm(this.GetInterestSchedule());
        }

        #endregion

        #region Methods
        public void ShowReport(string formName)
        {
            string sourceBr = CurrentUserEntity.BranchCode;

            IList<MNMDTO00007> SiList = CXClientWrapper.Instance.Invoke<IMNMSVE00050, IList<MNMDTO00007>>(x => x.GetSiList(sourceBr, this.View.Currency, this.view.RequiredYear));
            if (SiList.Count <= 0)
                CXUIMessageUtilities.ShowMessageByCode("MI00039"); //No Data For Report
            else
                CXUIScreenTransit.Transit("frmMNMVEW00099", true, new object[] { formName, this.View.Currency, SiList });
        }

        #endregion

    }
}
