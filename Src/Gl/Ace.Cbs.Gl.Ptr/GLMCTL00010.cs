using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Ser;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Gl.Dmd;
using Ace.Cbs.Gl.Ctr.Ptr;
using Ace.Cbs.Gl.Ctr.Sve;

namespace Ace.Cbs.Gl.Ptr
{
    public class GLMCTL00010 : AbstractPresenter, IGLMCTL00010
    {
        private IGLMVEW00010 view;
        public IGLMVEW00010 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(IGLMVEW00010 view)
        {
            if (this.view == null)
            {
                this.view = view;
                //this.Initialize(this.view, this.GetEntity());
            }
        }

        //public GLMDTO00013 GetEntity()
        //{
        //    GLMDTO00013 ViewData = new GLMDTO00013();
        //    ViewData.Year = this.View.Year;
        //    ViewData.Month = this.View.Month;

        //    return ViewData;
        //}

        public void txtMonth_CustomValidate(object sender, ValidationEventArgs e)
        {
            //if (!e.HasXmlBaseError)
            //{
            //    int MonthValue = 0;
            //    if (string.IsNullOrEmpty(this.view.Month))
            //        this.SetCustomErrorMessage(this.GetControl("txtMonth"), "MV00221");// Check Null or Empty
            //    else if (!int.TryParse(this.view.Month, out MonthValue))
            //    {

            //    }
            //    else if (MonthValue > 12 || MonthValue < 1)
            //        this.SetCustomErrorMessage(this.GetControl("txtMonth"), "MV00221");// Check valid Month or not
            //}
        }

        public void txtYear_CustomValidate(object sender, ValidationEventArgs e)
        {
            if (!e.HasXmlBaseError)
            {
                if (string.IsNullOrEmpty(this.view.Year))
                    this.SetCustomErrorMessage(this.GetControl("txtRequiredYear"), "Invalid Required Year.");  // Check Null or Empty
                else if (Convert.ToInt32(this.view.Year) > DateTime.Now.Year)
                {
                    CXUIMessageUtilities.ShowMessageByCode("MV30032", new object[] { this.view.Year, DateTime.Now.Year }); //Required Year {0} could not be greater than {1}.
                    this.SetFocus("txtRequiredYear");
                }
            }
        }

        public void Preview()
        {
            //if (this.ValidateForm())
            //{
                string month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(this.View.actualMonth));
                string todayMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(DateTime.Now.Month));
                if (Convert.ToInt32(this.view.Month) > DateTime.Now.Month && Convert.ToInt32(this.view.Year) == DateTime.Now.Year)
                {
                    CXUIMessageUtilities.ShowMessageByCode("MV30022", new object[] { month, todayMonth });
                }
                else
                {
                    //Modified By AAM (25-Sep-2017-11AM)
                    //string budMonth1 = Convert.ToInt32(this.View.Month) < 4 ? "MSRC" + (Convert.ToInt32(this.View.Month) + 9).ToString() : "MSRC" + (Convert.ToInt32(this.View.Month) - 3).ToString();

                    // Modified by ZMS (2018/09/18) for Budget Month Flexible
                    string budMonth =string.Empty; // calculate budget month in GLMSVE00010

                    IList<GLMDTO00013> DTOList = CXClientWrapper.Instance.Invoke<IGLMSVE00010, IList<GLMDTO00013>>(x => x.SelectIncomeExpenditure(budMonth,this.View.Year,this.View.actualMonth,this.View.branchCode));

                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MI00039"); //No Data for Print.
                    }
                    else
                    {
                        CXUIScreenTransit.Transit("frmGLMVEW00015.ReportViewer", true, new object[] { DTOList, month });
                    }
                }
            //}
        }
    }

}