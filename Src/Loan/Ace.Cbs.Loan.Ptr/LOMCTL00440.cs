using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00440 : AbstractPresenter, ILOMCTL00440
    {
        private ILOMVEW00440 view;
        public ILOMVEW00440 View
        {
            get { return this.view; }
            set { this.WriteTo(value); }
        }
        private void WriteTo(ILOMVEW00440 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }
        IList<LOMDTO00427> BlackListData;
        IList<LOMDTO00427> BlackListResultData;

        public void Print()
        {
            BlackListData = new List<LOMDTO00427>();
            BlackListData = CXClientWrapper.Instance.Invoke<ILOMSVE00435, IList<LOMDTO00427>>(x => x.GetAllWarningListHistoryByACTypeAndDate(this.View.AccountType, this.View.StartDate, this.View.EndDate, this.View.SourceBr));
            if (BlackListData == null || BlackListData.Count == 0)
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
            }
            else //if (DTOList.Count > 0)
            {
                
                BlackListResultData = new List<LOMDTO00427>();
                foreach (LOMDTO00427 item in BlackListData)
                {
                    LOMDTO00427 bLdata = new LOMDTO00427();

                    if (item.Name == "" || item.Name == string.Empty)
                        bLdata.Name = "-";
                    else
                        bLdata.Name = item.Name;

                    bLdata.NRC = item.NRC;

                    if (item.FatherName == "" || item.FatherName == string.Empty)
                        bLdata.FatherName = "-";
                    else
                        bLdata.FatherName = item.FatherName;

                    if (Convert.ToString(bLdata.DOB) == "1/1/1900 12:00:00 AM")
                        bLdata.DOB = Convert.ToDateTime(DBNull.Value);
                    else
                        bLdata.DOB = item.DOB;

                    if (item.Address == "" || item.Address == string.Empty)
                        bLdata.Address = "-";
                    else
                        bLdata.Address = item.Address;

                    if (item.CompanyName == "" || item.CompanyName == string.Empty)
                        bLdata.CompanyName = "-";
                    else
                        bLdata.CompanyName = item.CompanyName;

                    bLdata.CreatedDate = item.CreatedDate;
                    bLdata.UserName = item.UserName;
                    bLdata.ApprovedUserName = item.ApprovedUserName;

                    BlackListResultData.Add(bLdata);
                }
                
                string headerName = "";
                //string header="";

                if (this.View.AccountType == "BL") headerName = "Business Loans";
                else if (this.View.AccountType == "PL") headerName = "Personal Loans";
                else if (this.View.AccountType == "HP") headerName = "Hire Purchase";
                else if (this.View.AccountType == "DL") headerName = "Dealer";
                else headerName = "All";
                
                string sourcebranch = this.view.SourceBr.ToString();
                CXUIScreenTransit.Transit("frmLOMVEW00439.ReportViewer", true, new object[] { BlackListData, headerName, this.View.StartDate.ToString("dd/MM/yyyy"), this.View.EndDate.ToString("dd/MM/yyyy"), this.View.rptName, this.View.SourceBr });
            }
        }
    }
}
