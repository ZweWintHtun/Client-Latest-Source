using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Pfm.Dao;
using Ace.Cbs.Cx.Ser.Sve;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Windows.Core.Utt;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;

namespace Ace.Cbs.Tel.Sve
{
  public  class TLMSVE00063 : BaseService, ITLMSVE00063
    {  

      #region DAO
      public ICXDAO00009 ViewDAO { get; set; }
      #endregion

      #region Main Method

      [Transaction(TransactionPropagation.Required)]
      public IList<PFMDTO00042> SelectDepositListingByAll(DateTime startDate, DateTime endDate, int CurrentUserId, string workstation, string sourceBr)
      {
          Ace.Windows.Admin.DataModel.UserDTO user = this.ViewDAO.SelectUserNamebyUserId(CurrentUserId);
          PFMDTO00042 check = new PFMDTO00042();
          CXDTO00006 parameter = new CXDTO00006();
          parameter.SpecialCondition = "STATUS='CCD'" + " and sourceBr = '" + sourceBr + "'";
          parameter.StartDate = startDate;
          parameter.EndDate = endDate;
          parameter.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
          parameter.CreatedUserId = CurrentUserId;
          //parameter.UserNo = Convert.ToString(createdUserId);
          parameter.UserNo = workstation;
          parameter.BDateType = "T";
         check = CXServiceWrapper.Instance.Invoke<ICXSVE00010, PFMDTO00042>(x => x.GetReportDataGenerateInSQL(parameter));
          if (check == null)
          {
              this.ServiceResult.ErrorOccurred = true;
              this.ServiceResult.MessageCode = "MI00039"; //No Data For Report
              IList<PFMDTO00042> reportlist = new List<PFMDTO00042>();

              
              return reportlist;
          }
          else
          {
              //IList<PFMDTO00042> reportlist = this.ViewDAO.SelectDepositListingByAll(sourceBr,workstation); // Comment By AAM (18-Jan-2018)
              
              // Added By AAM (18-Jan-2018)
              IList<PFMDTO00042> reportlist = this.ViewDAO.SelectDepositListingByAll_New(sourceBr, workstation); 

              //reportlist = reportlist.Where(x => x.SourceBranch == sourceBr).ToList();
              
              /*updated by ZMS(14/12/2017)to show user name in reports */
              //if (user != null)
              //{
              //    foreach (PFMDTO00042 item in reportlist)
              //    {
              //        item.UserNo = user.UserName;
 
              //    }
              //}
              return reportlist;
        }
      }

      [Transaction(TransactionPropagation.Required)]
      public IList<PFMDTO00042> SelectDepositListingByCounter(DateTime startDate, DateTime endDate, int createdUserId, string workStation, string counterNo, string sourceBr)
      {
          Ace.Windows.Admin.DataModel.UserDTO user = this.ViewDAO.SelectUserNamebyUserId(createdUserId);

          try
          {
              //int userno = this.ViewDAO.SelectUserInfobyUseNameForUserNoReport(counterNo,sourceBr).Id;

              // updated by ZMS (to filter with user name in DepositListingByUserName)
              string userno = this.ViewDAO.SelectUserInfobyUseNameForUserNoReport(counterNo, sourceBr).UserName;
              counterNo = userno.ToString();
          }
          catch 
          {
              this.ServiceResult.ErrorOccurred = true;
              this.ServiceResult.MessageCode = "MI00039";
              IList<PFMDTO00042> deposit = new List<PFMDTO00042>();
              return deposit;
          }

          PFMDTO00042 check = new PFMDTO00042();
          CXDTO00006 parameter = new CXDTO00006();
          parameter.UserNo = counterNo;
          parameter.SpecialCondition = "Status='CCD'" + " and sourceBr = '" + sourceBr + "'";
          parameter.StartDate = startDate;
          parameter.EndDate = endDate;
          parameter.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
          parameter.CreatedUserId = createdUserId;
          parameter.BDateType = "T";
          //parameter.UserNo = Convert.ToString(createdUserId);
          parameter.UserNo = workStation;
         check = CXServiceWrapper.Instance.Invoke<ICXSVE00010, PFMDTO00042>(x => x.GetReportDataGenerateInSQL(parameter));
         if (check == null)
         {
             this.ServiceResult.ErrorOccurred = true;
             this.ServiceResult.MessageCode = "MI00039"; //No Data For Report
             IList<PFMDTO00042> reportlist = new List<PFMDTO00042>();
             return reportlist;
         }
         else
         {
             //IList<PFMDTO00042> reportlist = this.ViewDAO.SelectDepositListingByCounterNo(sourceBr, counterNo,workStation);

             #region Added By AAM (18-Jan-2018)
             IList<PFMDTO00042> reportlist = this.ViewDAO.SelectDepositListingByAll_New(sourceBr, workStation);
             reportlist = reportlist.Where(a => a.UserNo==counterNo).ToList();
             #endregion

             //reportlist = reportlist.Where(x => x.SourceBranch == sourceBr).ToList();
             /*updated by ZMS(14/12/2017)to show user name in reports */
             //if (user != null)
             //{
             //    foreach (PFMDTO00042 item in reportlist)
             //    {
             //        item.UserNo = user.UserName;

             //    }
             //}
             return reportlist;
         }
      }

      [Transaction(TransactionPropagation.Required)]
      public IList<PFMDTO00042> SelectDepositListingByGrade(DateTime startDate, DateTime endDate, int createdUserId, string workStation, decimal minimumAmount,decimal maximumAmount,string accountSign,string sourceBr)
      {
          Ace.Windows.Admin.DataModel.UserDTO user = this.ViewDAO.SelectUserNamebyUserId(createdUserId);
          PFMDTO00042 check = new PFMDTO00042();
          CXDTO00006 parameter = new CXDTO00006();
          //parameter.ACSign = accountSign;
          //parameter.SpecialCondition = "Status='CCD' and Amount between " + minimumAmount.ToString() + " and " + maximumAmount.ToString() + " and sourceBr = '" + sourceBr + "'";
          //parameter.SpecialCondition = "Status='CCD' and ACSign like '"+ accountSign +"%' And Amount between " + minimumAmount.ToString() + " and " + maximumAmount.ToString() + " and sourceBr = '" + sourceBr + "'";
          parameter.SpecialCondition = "Status='CCD' and ACSign like '" + accountSign + "%'";
          parameter.SourceBranch = sourceBr;
          parameter.StartDate = startDate;
          parameter.EndDate = endDate;
          parameter.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
          parameter.CreatedUserId = createdUserId;
          parameter.BDateType = "T";
          parameter.UserNo = workStation;
            check = CXServiceWrapper.Instance.Invoke<ICXSVE00010, PFMDTO00042>(x => x.GetReportDataGenerateInSQL(parameter));
          if (check == null)
          {
              this.ServiceResult.ErrorOccurred = true;
              this.ServiceResult.MessageCode = "MI00039"; //No Data For Report
              IList<PFMDTO00042> reportlist = new List<PFMDTO00042>();
              return reportlist;
          }
          else
          {
          IList<PFMDTO00042> reportlist = this.ViewDAO.SelectDepositListingByGrade(startDate, endDate, minimumAmount, maximumAmount, accountSign, sourceBr,workStation);
          //reportlist = reportlist.Where(x => x.SourceBranch == sourceBr).ToList();
          
          /*updated by ZMS(14/12/2017)to show user name in reports */
          //if (user != null)
          //{
          //    foreach (PFMDTO00042 item in reportlist)
          //    {
          //        item.UserNo = user.UserName;

          //    }
          //}
              return reportlist;
          }
      }

      [Transaction(TransactionPropagation.Required)]
      public IList<PFMDTO00042> SelectWithdrawListingByGrade(DateTime startDate, DateTime endDate, int createdUserId, int workStation, decimal minimumAmount, decimal maximumAmount, string accountSign, string sourceBr)
      {
          Ace.Windows.Admin.DataModel.UserDTO user = this.ViewDAO.SelectUserNamebyUserId(createdUserId);
          PFMDTO00042 check = new PFMDTO00042();
          CXDTO00006 parameter = new CXDTO00006();
          parameter.ACSign = accountSign;
          parameter.SpecialCondition = "Status='CDW' and Amount between " + minimumAmount.ToString() + " and " + maximumAmount.ToString() + " and SourceBr = '" + sourceBr + "'";
          parameter.StartDate = startDate;
          parameter.EndDate = endDate;
          parameter.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
          parameter.CreatedUserId = createdUserId;
          parameter.BDateType = "T";
          //parameter.UserNo = Convert.ToString(createdUserId);
          parameter.UserNo = workStation.ToString();
          check = CXServiceWrapper.Instance.Invoke<ICXSVE00010, PFMDTO00042>(x => x.GetReportDataGenerateInSQL(parameter));
          if (check == null)
          {
              this.ServiceResult.ErrorOccurred = true;
              this.ServiceResult.MessageCode = "MI00039"; //No Data For Report
              IList<PFMDTO00042> reportlist = new List<PFMDTO00042>();
              return reportlist;
          }
          else
          {
              //IList<PFMDTO00042> reportlist = this.ViewDAO.SelectWithdrawListingByGrade(startDate, endDate, minimumAmount, maximumAmount, accountSign, sourceBr, workStation);
              IList<PFMDTO00042> reportlist = this.ViewDAO.SelectWithdrawalListingAllReport_New(sourceBr, workStation); // Added by JZT (06-Feb-2018)
              /*updated by ZMS(14/12/2017)to show user name in reports */
              //if (user != null)
              //{
              //    foreach (PFMDTO00042 item in reportlist)
              //    {
              //        item.UserNo = user.UserName;

              //    }
              //}
              return reportlist;
          }
      }
      #endregion
    }
}