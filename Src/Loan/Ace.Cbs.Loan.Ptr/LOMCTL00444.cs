using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Loan.Ctr;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00444 : AbstractPresenter, ILOMCTL00444
    {
        IList<LOMDTO00444> LimitExtendList;
        private ILOMVEW00444 view;
        public ILOMVEW00444 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private void WireTo(ILOMVEW00444 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }

        public IList<LOMDTO00444> GetLimitExtendList(DateTime date, string sortby)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00444, IList<LOMDTO00444>>(x => x.GetLimitExtendList(date, sortby));
        }

        public void Print(DateTime date, string sortby)
        {
            LimitExtendList = new List<LOMDTO00444>();
            LimitExtendList = CXClientWrapper.Instance.Invoke<ILOMSVE00444, IList<LOMDTO00444>>(x => x.GetLimitExtendList(date,sortby));

            if (LimitExtendList == null || LimitExtendList.Count == 0)
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
            }
            else //if (DTOList.Count > 0)
            {
                //string sourcebranch = this.view.SourceBr.ToString();
                //CXUIScreenTransit.Transit("frmLOMVEW00445.ReportViewer", true, new object[] { LimitExtendList, this.View.Date.ToString("dd/MM/yyyy"), this.View.rptName, this.View.SourceBr });
                CXUIScreenTransit.Transit("frmLOMVEW00445.ReportViewer", true, new object[] { LimitExtendList, this.View.Date.ToString("dd/MM/yyyy"), this.View.rptName, this.View.SourceBr });
            }
        }
    }
}
