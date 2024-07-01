//----------------------------------------------------------------------
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>11/15/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using System.Windows.Forms;

namespace Ace.Cbs.Mnm.Ptr
{

    public class MNMCTL00003 : AbstractPresenter, IMNMCTL00003
    {
        #region Properties

        IMNMVEW00003 view;
        public IMNMVEW00003 View
        {
            get { return this.view; }
            set { this.WierTo(value); }
        }

        private void WierTo(IMNMVEW00003 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.view.Year);
            }
        }


        #endregion

        #region Main Methods

        public void CalculateInterest(int month, int year)
        {
            if (this.ValidateForm())
            {
                if (this.CheckBudgetYear())
                {
                    try
                    {
                        string workstation = CurrentUserEntity.WorkStationId.ToString();
                        CXClientWrapper.Instance.Invoke<IMNMSVE00003>(x => x.Save(month, year, CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode, workstation));
                        this.View.IsSuccessful = true; //Saving Interest Calculation Successfully Finished
                        this.View.ButCalculate.Enabled = false;
                        this.View.TimerProgress.Start();
                    }
                    catch
                    {
                        this.View.IsSuccessful = false;     //Saving Interest Calculation Failed
                        this.View.TimerProgress.Start();
                    }
                }
            }
        }

        #endregion

        #region Validation Methods

        public void txtRequiredYear_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
            {
                return;
            }

            if (this.View.Year.ToString().Length > 4 || this.View.Year.ToString().Length < 4 || this.View.Year > 2100 || this.View.Year < 1001 || this.View.Year == 0)
            {
                this.SetCustomErrorMessage(this.GetControl("txtRequiredYear"), "MV30002");  // Invalid Required Year
            }
            else
            {
                this.SetCustomErrorMessage(this.GetControl("txtRequiredYear"), string.Empty);
            }
        }

        private bool CheckBudgetYear()
        {
            string CurBudYear = CXCOM00010.Instance.GetBudgetYear1("");
            string BudYear = string.Empty;

            string value = CXCOM00007.Instance.GetValueByVariable(CXCOM00009.BudgetYearCode);
            int month = Convert.ToInt32(value.ToString());
            if (this.View.MonthValue < month)
            {
                BudYear = (this.View.Year - 1).ToString() + "/" + this.View.Year.ToString();    //Get inputed Budget Year
            }
            else
            {
                BudYear = this.View.Year.ToString() + "/" + (this.View.Year + 1).ToString();    //Get inputed Budget Year
            }

            if (Convert.ToInt32(BudYear.Substring(0, 4)) < Convert.ToInt32(CurBudYear.Substring(0, 4)))
            {
                CXUIMessageUtilities.ShowMessageByCode("MI30008");  //Not allow to calculate previous budget
                return false;
            }
            else if (Convert.ToInt32(BudYear.Substring(0, 4)) > Convert.ToInt32(CurBudYear.Substring(0, 4)) || this.IsOverToday())
            {
                CXUIMessageUtilities.ShowMessageByCode("MI30009");  //Saving interest calculation allows only current budget
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool IsOverToday()
        {
            if (this.View.Year > DateTime.Today.Year)
            {
                return true;
            }
            else
            {
                if (this.View.MonthValue > DateTime.Today.Month)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region helper_method

        public void Show_Message(string msgCode)
        {
            CXUIMessageUtilities.ShowMessageByCode(msgCode);
        }

        #endregion
    }
}
