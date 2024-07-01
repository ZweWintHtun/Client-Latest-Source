using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00431 : AbstractPresenter, ILOMCTL00431
    {
        private ILOMVEW00431 view;
        public ILOMVEW00431 View
        {
            get { return this.view; }
            set { this.WriteTo(value); }
        }
        private void WriteTo(ILOMVEW00431 view)
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
            BlackListData = CXClientWrapper.Instance.Invoke<ILOMSVE00427, IList<LOMDTO00427>>(x => x.GetAllBlackListByACTypeAndDate(this.View.TypeofCust, this.View.AccountType, this.View.StartDate, this.View.EndDate, this.View.SourceBr));
            
            if (BlackListData == null || BlackListData.Count == 0)
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
            }
            else //if (DTOList.Count > 0)
            {
                //if (this.View.TypeofCust == true)
                //{
                //    BlackListResultData = new List<LOMDTO00427>();
                //    foreach (LOMDTO00427 item in BlackListData)
                //    {
                //        LOMDTO00427 bLdata = new LOMDTO00427();
                        
                //        if(item.Name == "" || item.Name==string.Empty)                        
                //            bLdata.Name = "-";
                //        else
                //            bLdata.Name = item.Name;

                //        bLdata.NRC = item.NRC;

                //        if (item.FatherName == "" || item.FatherName == string.Empty)
                //            bLdata.FatherName = "-";
                //        else
                //            bLdata.FatherName = item.FatherName;

                //        if (Convert.ToString(bLdata.DOB) == null )
                //            bLdata.DOB = Convert.ToDateTime(DBNull.Value);
                //        else
                //            bLdata.DOB = item.DOB;

                //        if (item.Address == "" || item.Address == string.Empty)
                //            bLdata.Address = "-";
                //        else
                //            bLdata.Address = item.Address;

                //        if (item.CompanyName == "" || item.CompanyName == string.Empty)
                //            bLdata.CompanyName = "-";
                //        else
                //            bLdata.CompanyName = item.CompanyName;

                //        bLdata.CreatedDate = item.CreatedDate;
                //        bLdata.UserName = item.UserName;
                //        bLdata.ApprovedUserName = item.ApprovedUserName;

                //        BlackListResultData.Add(bLdata);
                //    }
                //}
                string headerName = "";
                //string header="";

                if (this.View.TypeofCust == false) // for Internal Customer
                {
                    if (this.View.AccountType == "BL") headerName = "Business Loans";
                    else if (this.View.AccountType == "PL") headerName = "Personal Loans";
                    else if (this.View.AccountType == "HP") headerName = "Hire Purchase";
                    else if (this.View.AccountType == "DL") headerName = "Dealer";
                    else headerName = "All";
                }
                else headerName = "External Customer";
                string sourcebranch = this.view.SourceBr.ToString();
                CXUIScreenTransit.Transit("frmLOMVEW00432.ReportViewer", true, new object[] { BlackListData, headerName, this.View.StartDate.ToString("dd/MM/yyyy"), this.View.EndDate.ToString("dd/MM/yyyy"), this.View.rptName, this.View.SourceBr });
            }
        }
        #region Helper Method
        //private string GenerateMultipleLines(string str)
        //{
        //    string[] field = str.Split(',');
        //    string result = "";
        //    if (field.Length == 0)
        //        return result;
        //    result = field[0];
        //    for (int i = 1; i < field.Length; i++)
        //    {
        //        result += Environment.NewLine + field[i].Trim();
        //    }
        //    return result;
        //}
        //private string GenerateMultipleLinesForAddress(string str)
        //{
        //    string[] field = str.Split(';');
        //    string result = "";
        //    if (field.Length == 0)
        //        return result;
        //    result = field[0];
        //    for (int i = 1; i < field.Length; i++)
        //    {
        //        result += Environment.NewLine + field[i].Trim();
        //    }
        //    return result;
        //}
        #endregion
    }
}
