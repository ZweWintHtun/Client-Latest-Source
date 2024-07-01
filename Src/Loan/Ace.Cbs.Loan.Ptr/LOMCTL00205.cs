using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Ptr
{
    class LOMCTL00205 : AbstractPresenter, ILOMCTL00205
    {
        string filterStatus;
        private ILOMVEW00205 view;
        public ILOMVEW00205 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00205 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }

        public IList<string> GetAllPersonalLoansCompanyName(string sourceBr)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00080, IList<string>>(x => x.GetAllPersonalLoansCompanyName(sourceBr));
        }

        public void Print(string rptName, DateTime startDate, DateTime endDate,string companyName)
        {
            IList<LOMDTO00205> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00205>>(x => x.GetPLInfoListing(startDate, endDate, companyName, this.view.SourceBr));
            //DTOList=DTOList.Where(x => x.SDate >= startDate && x.SDate <= endDate).ToList();
            filterStatus ="0";
            if (DTOList.Count > 0)
            {
                string currency = this.view.Currency.ToString();
                string header = "Personal Loan Information Listing";
                string sourcebranch = this.view.SourceBr.ToString();
                //CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, currency, header, sourcebranch, startDate.ToString("dd/MM/yyyy"), endDate.ToString("dd/MM/yyyy"), rptName, filterStatus });
                if (companyName == "")
                    CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, currency, header, sourcebranch, startDate.ToString("dd/MM/yyyy"), endDate.ToString("dd/MM/yyyy"), rptName, filterStatus,"ALL" });
                else
                {
                    companyName = DTOList[0].CompanyName;
                    CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, currency, header, sourcebranch, startDate.ToString("dd/MM/yyyy"), endDate.ToString("dd/MM/yyyy"), rptName, filterStatus, companyName });
                }
            }
            else
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
            }
        }

       // public void PrintByCompany(string rptName, string companyName)
        //{
        //    IList<LOMDTO00205> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00205>>(x => x.GetPLInfoListing(this.view.StartDate, this.view.EndDate, this.view.SourceBr)); 
        //    DTOList = DTOList.Where(x => x.CompanyName == companyName).ToList();
        //    filterStatus = "1";
        //    if (DTOList.Count > 0)
        //    {
        //        string currency = this.view.Currency.ToString();
        //        string header = "Personal Loan Information Listing";
        //        string sourcebranch = this.view.SourceBr.ToString();
        //        CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, currency, header, sourcebranch, companyName, rptName, filterStatus });
        //    }
        //    else
        //    {
        //        CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
        //    }
        //}
    }
}
