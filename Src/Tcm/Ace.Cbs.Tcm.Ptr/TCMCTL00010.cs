using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Tcm.Ctr.Sve;

namespace Ace.Cbs.Tcm.Ptr
{
    public class TCMCTL00010 : AbstractPresenter , ITCMCTL00010
    {
        public TCMCTL00010() { }       

        public ITCMVEW00010 View { get; set; }
        public IList<TLMDTO00015> CashDenoList { get; set; }

        public void Delete()
        {
            try
            {
                //string statusString = string.Empty;
                //statusString = " and Status='" + this.View.Status + "'";
                //string whereString = string.Empty;
                //whereString = " Where Sourcebr='" +CurrentUserEntity.BranchCode+ "' And (CONVERT(char(10), Cash_Date, 111) between '" + this.View.StartDate + "' and '" + this.View.EndDate + "' and actype  not in ('V00000','VN0000') " + status + " )";
                //whereString = whereString + " or (CONVERT(char(10), Cash_Date, 111) between  '" + this.View.StartDate + "' and '" + this.View.EndDate + "' and actype is null " + status + ") And (isnull(FromType,'')='' or FromType<>'Closing Balance')";
                // CXClientWrapper.Instance.Invoke<ITCMSVE00010>(x => x.DeleteDataFromCashDeno(CurrentUserEntity.BranchCode, this.View.StartDate, this.View.EndDate, this.View.Status));
                //string tlf_eno = CXClientWrapper.Instance.Invoke<ITCMSVE00010, string>(x => x.GetTlf_Eno(CurrentUserEntity.BranchCode, this.View.StartDate, this.View.EndDate, statusString));

                CXClientWrapper.Instance.Invoke<ITCMSVE00010>(x => x.DeleteDataFromDepoDeno(CurrentUserEntity.BranchCode, this.View.StartDate, this.View.EndDate));
                CXClientWrapper.Instance.Invoke<ITCMSVE00010>(x => x.DeleteDataFromCashDeno(CurrentUserEntity.BranchCode, this.View.StartDate, this.View.EndDate, this.View.Status));                
                CXClientWrapper.Instance.Invoke<ITCMSVE00010>(x => x.UpdateFormatDefinationMaxValue(CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID, DateTime.Now));
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                {
                    CXUIMessageUtilities.ShowMessageByCode("MI90003");  //Delete Successful(All records are deleted successfully )
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }   

        public bool CheckDate()
        {
            if (CXCOM00006.Instance.IsExceedTodayDate(this.View.StartDate))
            {
                CXUIMessageUtilities.ShowMessageByCode("MV00129");//Start Date must not be greater than today.
                return false;
            }
            else if (this.View.StartDate.ToShortDateString() == DateTime.Now.ToShortDateString())
            {
                //CXUIMessageUtilities.ShowMessageByCode("MV30033",this.View.StartDate.ToString("dd/MMM/yyyy")); // Start Date shouldn't be today date to delete transaction
                CXUIMessageUtilities.ShowMessageByCode("MV30033","Start Date "); // Start Date shouldn't be today date to delete transaction
                return false;
            }
            else if (CXCOM00006.Instance.IsExceedTodayDate(this.View.EndDate))
            {
                CXUIMessageUtilities.ShowMessageByCode("MV00130");//End Date must not be greater than today.
                return false;
            }
            else if (this.View.EndDate.ToShortDateString() == DateTime.Now.ToShortDateString())
            {
                CXUIMessageUtilities.ShowMessageByCode("MV30033","End Date "); // End Date shouldn't be today date to delete transaction
                return false;
            }
            else if (this.View.StartDate > this.View.EndDate)            
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00131");//Start Date must not be greater than End Date.
                return false;
            }
            return true ;
        }

        public bool Check_Data()
        {
            if(!CheckDate())
            {
                return false;
            }
            //statusString = " and Status='" + this.View.Status + "'";
            //string queryString = string.Empty ;
            //queryString = " Where Sourcebr='" + CurrentUserEntity.BranchCode + "' And CONVERT(char(10), Cash_Date, 111) between '" + this.View.StartDate + "' and '" + this.View.EndDate + "' and actype  not in ('V00000','VN0000') " + status + " ";
            //queryString = queryString + " or CONVERT(char(10), Cash_Date, 111) between  '" + this.View.StartDate + "' and '" +this.View.EndDate +"' and actype is null " +status+ "";                              
            
            CashDenoList = CXClientWrapper.Instance.Invoke<ITCMSVE00010,IList<TLMDTO00015>>(x => x.GetCashDenoList(CurrentUserEntity.BranchCode,this.View.StartDate, this.View.EndDate, this.View.Status));
            if(CashDenoList.Count <= 0)
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00016"); // No record to Delete.
                return false;
            }
            return true ;                        
        }

        //public string GetStatus()
        //{            
        //    if (this.View.Status == "R" || this.View.Status == "P")
        //        return status = " and Status='" + this.View.Status + "'";

        //    else
        //        return status = "";
        //}
    }
}
