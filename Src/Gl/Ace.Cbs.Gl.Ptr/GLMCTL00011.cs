using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Gl.Ctr.Ptr;
using Ace.Cbs.Gl.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Gl.Ctr.Sve;

namespace Ace.Cbs.Gl.Ptr
{
    public class GLMCTL00011 : AbstractPresenter, IGLMCTL00011
    {
        #region View
        IGLMVEW00011 view;
        public IGLMVEW00011 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private void WireTo(IGLMVEW00011 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetEntity());
            }
        }
        #endregion

        public IList<GLMDTO00001> SelectFormatFile(string formatStatus)
        {
            return CXClientWrapper.Instance.Invoke<IGLMSVE00011, IList<GLMDTO00001>>(x => x.SelectAllFormatFile(formatStatus));
        }

        public void PreView(string formatType, string formatStatus)
        {
            IList<GLMDTO00001> formatFileList = CXClientWrapper.Instance.Invoke<IGLMSVE00011, IList<GLMDTO00001>>(x => x.GetPreViewData(View.Month, formatType, formatStatus, View.Currency));
            if (formatFileList.Count > 0)
            {
                if (string.IsNullOrEmpty(View.Currency))
                {
                    IList<GLMDTO00001> tempFormatFileList = formatFileList.Where(x => x.CBal != 0).ToList();
                    if (tempFormatFileList.Count <= 0)
                        CXUIMessageUtilities.ShowMessageByCode("MI00039");  //No data for Report.
                    else
                    {
                        CXUIScreenTransit.Transit("frmGLMVEW00016", formatFileList, View.Header, View.ReportFormat,View.FormName);
                        //CXUIScreenTransit.Transit("frmGLMVEW00016");
                    }
                }
                else
                {
                    switch (View.ReportFormat)
                    {
                        case "AF":
                            var cbalList = formatFileList.Where(x => x.CBal != 0 && x.ShowHide == "N").Select(x => x.CBal);
                            decimal sumCBal = cbalList.Sum();
                            if (sumCBal == 0)
                                CXUIMessageUtilities.ShowMessageByCode("MI00039");  //No data for Report.
                            else
                                CXUIScreenTransit.Transit("frmGLMVEW00016", formatFileList, View.Header, View.ReportFormat, View.FormName);
                            break;

                        case "BAF":
                            var cbalList_2 = formatFileList.Where(x => x.CBal != 0 && x.ShowHide == "N").Select(x => x.CBal);
                            decimal sumCBal_2 = cbalList_2.Sum();
                            var bfamountList = formatFileList.Where(x => x.BFAmount != 0 && x.ShowHide == "N").Select(x => x.BFAmount);
                            decimal sumBFAmount = bfamountList.Sum();
                            if (sumCBal_2 == 0 && sumBFAmount == 0)
                                CXUIMessageUtilities.ShowMessageByCode("MI00039");  //No data for Report.
                            else
                                CXUIScreenTransit.Transit("frmGLMVEW00016", formatFileList, View.Header, View.ReportFormat, View.FormName);
                            break;
                    }
                }
            }
            else
                CXUIMessageUtilities.ShowMessageByCode("MI00039");  //No data for Report.
        }

        //public void txtRequiredMonth_Validing(object sender,ValidationEventArgs e)
        //{
        //    if (string.IsNullOrEmpty(this.View.MonthText))
        //    {
        //        this.SetCustomErrorMessage(this.GetControl("txtRequiredMonth"), "MV30004");
        //    }
        //    else if (Convert.ToInt32(this.View.MonthText) > DateTime.Now.Month)
        //    {
        //      this.SetCustomErrorMessage(this.GetControl("txtRequiredMonth"), "MV30022", new object[] { this.View.MonthText, DateTime.Now.Month });  //Month {0} cannot be greater than Today {1}.
        //    }
        //    else
        //    {
        //        this.SetCustomErrorMessage(this.GetControl("txtRequiredMonth"), string.Empty);
        //    }
        //}

        public void cboCurrency_CustomValiding(object sender, ValidationEventArgs e)
        {
            if (!this.View.isHomeCurrency)
            {
                if (string.IsNullOrEmpty(this.View.Currency))
                    this.SetCustomErrorMessage(this.GetControl("cboCurrency"), "MV00020");
                else
                    this.SetCustomErrorMessage(this.GetControl("cboCurrency"), string.Empty);
            }
        }

        public GLMDTO00013 GetEntity()
        {
            GLMDTO00013 entity = new GLMDTO00013();
            entity.Month = this.View.Month.ToString();
            return entity;
        }
    }
}
