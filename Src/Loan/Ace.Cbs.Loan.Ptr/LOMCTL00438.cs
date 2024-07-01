using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Cbs.Loan.Ctr.Sve;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00438 : AbstractPresenter, ILOMCTL00438
    {
        private ILOMVEW00438 view;
        public ILOMVEW00438 View
        {
            get { return this.view; }
            set { this.WriteTo(value); }
        }
        private void WriteTo(ILOMVEW00438 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }
        IList<LOMDTO00427> WarningListData;
        
        public void Print()
        {
            WarningListData = new List<LOMDTO00427>();
            WarningListData = CXClientWrapper.Instance.Invoke<ILOMSVE00435, IList<LOMDTO00427>>(x => x.GetAllWarningListByACTypeAndDate(this.View.AccountType, this.View.StartDate, this.View.EndDate, this.View.SourceBr));

            if (WarningListData == null || WarningListData.Count == 0)
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
            }
            else //if (DTOList.Count > 0)
            {
                string headerName = "";
               
                
                if (this.View.AccountType == "BL") headerName = "Business Loans";
                else if (this.View.AccountType == "PL") headerName = "Personal Loans";
                else if (this.View.AccountType == "HP") headerName = "Hire Purchase";
                else if (this.View.AccountType == "DL") headerName = "Dealer";
                else headerName = "All";
                
                string sourcebranch = this.view.SourceBr.ToString();
                CXUIScreenTransit.Transit("frmLOMVEW00439.ReportViewer", true, new object[] { WarningListData, headerName, this.View.StartDate.ToString("dd/MM/yyyy"), this.View.EndDate.ToString("dd/MM/yyyy"), this.View.rptName, this.View.SourceBr });
            }
        }


    }
}
