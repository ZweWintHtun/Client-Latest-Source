using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Tcm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Tcm.Ctr.Sve;
//using Ace.Cbs.Cx.Ser.Sve;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Ctr;
using System.Windows.Forms;

namespace Ace.Cbs.Tcm.Ptr
{
    public class TCMCTL00052 : AbstractPresenter, ITCMCTL00052
    {
        public TCMCTL00052() { }
        private ITCMVEW00030 view;
        public ITCMVEW00030 View
        {
            get { return view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ITCMVEW00030 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetEntity());
            }
        }

        public TCMDTO00052 GetEntity()
        {
            TCMDTO00052 ViewData = new TCMDTO00052();
            ViewData.DATE_TIME = this.view.PostDate;
            ViewData.CUR = this.view.Currency;
            ViewData.CreatedUserId = CurrentUserEntity.CurrentUserID;
            ViewData.CreatedDate = DateTime.Now;

            return ViewData;
        }

        public bool Validate_Form()
        {
            return this.ValidateForm(this.GetEntity());
        }
        

        public void Preview()
        {
            if (this.Validate_Form())
            {
                if (this.view.PostDate > DateTime.Now)
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MV00117");
                    }
                    else
                    {
                        TCMDTO00052 DTOData = this.GetEntity();
                        string rDATE = DateTime.Now.ToShortDateString();
                        string bUDMONTH = "M" + Convert.ToInt32(CXCOM00010.Instance.GetBudgetYear2(CXCOM00009.BudgetYearCode, this.view.PostDate));

                        TCMDTO00052 SPDTO = CXClientWrapper.Instance.Invoke<ITCMSVE00052, TCMDTO00052>(x => x.SelectDailyClosingbySP(rDATE, bUDMONTH, DTOData.CUR,CurrentUserEntity.CurrentUserID));
                        //CXClientWrapper.Instance.Invoke<ITCMSVE00052>(x => x.SelectDailyReportData(SPDTO, DTOData.CUR));
                        //TCMDTO00052 ReportDTO = CXClientWrapper.Instance.Invoke<ITCMSVE00052, TCMDTO00052>(x => x.SelectViewData(DTOData.CUR, DateTime.Now));

                        CXUIScreenTransit.Transit("frmTCMVEW00052.ReportViewer", true, new object[] { SPDTO });

                    }
            }          

        }
    }
}
