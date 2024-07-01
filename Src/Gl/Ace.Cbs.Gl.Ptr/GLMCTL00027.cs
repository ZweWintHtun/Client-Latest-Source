using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Gl.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Gl.Ctr.Sve;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using System.Globalization;
using Ace.Cbs.Gl.Dmd;
using System.Data;

namespace Ace.Cbs.Gl.Ptr
{
    public class GLMCTL00027 : AbstractPresenter, IGLMCTL00027
    {
        #region Properties

        private IGLMVEW00027 _view;
        public IGLMVEW00027 View
        {
            get { return _view; }
            set { this.WireTo(value); }
        }      

        DataSet PrintDataList { get; set; }
        #endregion

        #region Helper Methods

        private void WireTo(IGLMVEW00027 view)
        {
            if (this._view == null)
            {
                this._view = view;
                this.Initialize(this._view, this.GetViewData());
            }
        }
        private PFMDTO00042 GetViewData()
        {
            PFMDTO00042 ViewData = new PFMDTO00042();
            ViewData.StartDate = this._view.RequiredDate;
            return ViewData;
        }
        //public void txtMonth_CustomValidate(object sender, ValidationEventArgs e)
        //{
        //    if (!e.HasXmlBaseError)
        //    {
        //        int MonthValue = 0;
        //        if (string.IsNullOrEmpty(this.view.Month))
        //            this.SetCustomErrorMessage(this.GetControl("txtMonth"), "MV00221");// Check Null or Empty
        //        else if (!int.TryParse(this.view.Month, out MonthValue))
        //        {

        //        }
        //        else if (MonthValue > 12 || MonthValue < 1)
        //            this.SetCustomErrorMessage(this.GetControl("txtMonth"), "MV00221");// Check valid Month or not
        //    }
        //}
        #endregion     

        public DataSet Print()
        {
            string workStation=CurrentUserEntity.WorkStationId.ToString();
            string month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(this._view.RequiredDate.Month));
            string todayMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(DateTime.Now.Month));
            if (Convert.ToInt32(this._view.RequiredDate.Month) > DateTime.Now.Month && Convert.ToInt32(this._view.RequiredDate.Year) == DateTime.Now.Year)
            {
                CXUIMessageUtilities.ShowMessageByCode("MV30022", new object[] { month, todayMonth }); ///Month {0} cannot be greater than Today {1}.
            }
            else
            {               
                //if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                //{
                //    CXUIMessageUtilities.ShowMessageByCode("MI30003"); //No Data for Report
                //}
                //else
                //{
                    //string sourceBranchCode;
                    //if (View.isAllBranch == "1")
                    //{
                    //    sourceBranchCode = "All";
                    //}
                    //else
                    //{
                    //    sourceBranchCode = View.SourceBranch.ToString();
                    //}
                string Branch = CurrentUserEntity.IsHOUser ? this.View.IsAllBranch ? string.Empty : this.View.BranchCode : CurrentUserEntity.BranchCode;

                //PrintDataList = CXClientWrapper.Instance.Invoke<IGLMSVE00027,  DataSet>(x => x.SelectMonthlyCOAForIncomeExpenditureAndGeneralReturnsReport(this.View.RequiredDate, Branch, this.View.isIncome, workStation));
                //PrintDataList = CXClientWrapper.Instance.Invoke<IGLMSVE00027, IList<GLMDTO00023>>(x => x.SelectMonthlyCOAForIncomeExpenditureAndGeneralReturnsReport1(this.View.RequiredDate, Branch, this.View.isIncome, workStation));
                //PrintDataList = CXClientWrapper.Instance.Invoke<IGLMSVE00027, IList<GLMDTO00023>>(x => x.SelectMonthlyCOAForIncomeExpenditureAndGeneralReturnsReport2(this.View.RequiredDate, Branch, this.View.isIncome, workStation));
                //if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                //{
                //    CXUIMessageUtilities.ShowMessageByCode("MI30003"); //No Data for Report
                //}
                }               
            //}
            return PrintDataList;
        }

        public IList<GLMDTO00023> Print1()
        {
            IList<GLMDTO00023> PrintDataList1 = new List<GLMDTO00023>();
            string workStation = CurrentUserEntity.WorkStationId.ToString();
            string month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(this._view.RequiredDate.Month));
            string todayMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(DateTime.Now.Month));
            if (Convert.ToInt32(this._view.RequiredDate.Month) > DateTime.Now.Month && Convert.ToInt32(this._view.RequiredDate.Year) == DateTime.Now.Year)
            {
                CXUIMessageUtilities.ShowMessageByCode("MV30022", new object[] { month, todayMonth }); ///Month {0} cannot be greater than Today {1}.
            }
            else
            {
                //if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                //{
                //    CXUIMessageUtilities.ShowMessageByCode("MI30003"); //No Data for Report
                //}
                //else
                //{
                //string sourceBranchCode;
                //if (View.isAllBranch == "1")
                //{
                //    sourceBranchCode = "All";
                //}
                //else
                //{
                //    sourceBranchCode = View.SourceBranch.ToString();
                //}
                string Branch = CurrentUserEntity.IsHOUser ? this.View.IsAllBranch ? string.Empty : this.View.BranchCode : CurrentUserEntity.BranchCode;
               
                //PrintDataList = CXClientWrapper.Instance.Invoke<IGLMSVE00027,  DataSet>(x => x.SelectMonthlyCOAForIncomeExpenditureAndGeneralReturnsReport(this.View.RequiredDate, Branch, this.View.isIncome, workStation));
                PrintDataList1 = CXClientWrapper.Instance.Invoke<IGLMSVE00027, IList<GLMDTO00023>>(x => x.SelectMonthlyCOAForIncomeExpenditureAndGeneralReturnsReport1(this.View.RequiredDate, Branch, this.View.isIncome, workStation));
                //PrintDataList1 = CXClientWrapper.Instance.Invoke<IGLMSVE00027, IList<GLMDTO00023>>(x => x.SelectMonthlyCOAForIncomeExpenditureAndGeneralReturnsReport2(this.View.RequiredDate, Branch, this.View.isIncome, workStation));
                //if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                //{
                //    CXUIMessageUtilities.ShowMessageByCode("MI30003"); //No Data for Report
                //}
            }
            //}
            return PrintDataList1;
        }

        public IList<GLMDTO00023> Print2()
        {
            IList<GLMDTO00023> PrintDataList2 = new List<GLMDTO00023>();
            string workStation = CurrentUserEntity.WorkStationId.ToString();
            string month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(this._view.RequiredDate.Month));
            string todayMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(DateTime.Now.Month));
            if (Convert.ToInt32(this._view.RequiredDate.Month) > DateTime.Now.Month && Convert.ToInt32(this._view.RequiredDate.Year) == DateTime.Now.Year)
            {
                CXUIMessageUtilities.ShowMessageByCode("MV30022", new object[] { month, todayMonth }); ///Month {0} cannot be greater than Today {1}.
            }
            else
            {
                //if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                //{
                //    CXUIMessageUtilities.ShowMessageByCode("MI30003"); //No Data for Report
                //}
                //else
                //{
                //string sourceBranchCode;
                //if (View.isAllBranch == "1")
                //{
                //    sourceBranchCode = "All";
                //}
                //else
                //{
                //    sourceBranchCode = View.SourceBranch.ToString();
                //}
                string Branch = CurrentUserEntity.IsHOUser ? this.View.IsAllBranch ? string.Empty : this.View.BranchCode : CurrentUserEntity.BranchCode;

                //PrintDataList = CXClientWrapper.Instance.Invoke<IGLMSVE00027,  DataSet>(x => x.SelectMonthlyCOAForIncomeExpenditureAndGeneralReturnsReport(this.View.RequiredDate, Branch, this.View.isIncome, workStation));
                //PrintDataList = CXClientWrapper.Instance.Invoke<IGLMSVE00027, IList<GLMDTO00023>>(x => x.SelectMonthlyCOAForIncomeExpenditureAndGeneralReturnsReport1(this.View.RequiredDate, Branch, this.View.isIncome, workStation));
                PrintDataList2 = CXClientWrapper.Instance.Invoke<IGLMSVE00027, IList<GLMDTO00023>>(x => x.SelectMonthlyCOAForIncomeExpenditureAndGeneralReturnsReport2(this.View.RequiredDate, Branch, this.View.isIncome, workStation));
                //if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                //{
                //    CXUIMessageUtilities.ShowMessageByCode("MI30003"); //No Data for Report
                //}
            }
            //}
            return PrintDataList2;
        }
    }
}
