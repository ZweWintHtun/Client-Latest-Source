//----------------------------------------------------------------------
// <copyright file="ITCMSVE00015.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Tcm.Ctr.Sve
{
    /// <summary>
    /// System Shut Down Service Interface
    /// </summary>
  public  interface ITCMSVE00015 :IBaseService
    {
      bool ShutDown(bool shutdownstatus, string sourceBr, int updatedUserId);
      bool CheckVaultBalance(string sourcebr);
      IList<PFMDTO00028> DailyReconsile(string sourcebr);
      IList<TLMDTO00018> InsuranceExpiredLoansListing(string sourcebr, DateTime sysDate);
      bool CheckBLAutoPayment(string sourcebr);
      bool CheckHPAutoPayment(string sourcebr);
      bool CheckPLAutoPayment(string sourcebr);
      //bool CheckBLLateFeeCalculate(string sourcebr);//Commented by HWKO (17-Nov-2017)
      //bool CheckHPLateFeeCalculate(string sourcebr);//Commented by HWKO (17-Nov-2017)
      //bool CheckPLLateFeeCalculate(string sourcebr);//Commented by HWKO (16-Nov-2017)
      bool CheckPLLateFeeAutoVoucherProcessRun(string sourcebr);//Added by HWKO (16-Nov-2017)
      bool CheckBLLateFeeAutoVoucherProcessRun(string sourcebr);//Added by HWKO (17-Nov-2017)
      bool CheckHPLateFeeAutoVoucherProcessRun(string sourcebr);//Added by HWKO (17-Nov-2017)
      void Delete_ReportTLF_Table(string sourceBr);//Added by HMW (04-09-2019) : To fix "Data Header Receving Error Occur" issue when so many data exists in "ReportTlf" table
    }
}
