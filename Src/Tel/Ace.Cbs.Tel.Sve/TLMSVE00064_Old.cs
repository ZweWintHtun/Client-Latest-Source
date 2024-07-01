//----------------------------------------------------------------------
// <copyright file="TLMSVE00063" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate>2.9.2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.Core.Utt;



namespace Ace.Cbs.Tel.Sve
{
    public class TLMSVE00064 : BaseService, ITLMSVE00064
    {
        #region DAO
        public ICXDAO00009 ViewDAO { get; set; }
        #endregion

        #region Main Method
        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00042> SelectDepositListingByAccountNo(string accountNo,DateTime startDate,DateTime endDate,string workstation,int createdUserId,string sourceBr)
        {
            //Ace.Windows.Admin.DataModel.UserDTO user = this.ViewDAO.SelectUserNamebyUserId(CurrentUserEntity.CurrentUserID);
            Ace.Windows.Admin.DataModel.UserDTO user = this.ViewDAO.SelectUserNamebyUserId(createdUserId);
            PFMDTO00042 check = new PFMDTO00042();
            CXDTO00006 parameter = new CXDTO00006();
            parameter.AccountNo = accountNo;
            parameter.SpecialCondition = "STATUS='CCD'" + " and sourceBr = '" + sourceBr + "'";
            parameter.StartDate = startDate;
            parameter.EndDate = endDate;
            parameter.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
            //parameter.CreatedUserId = CurrentUserEntity.CurrentUserID;
            parameter.CreatedUserId = createdUserId;
            parameter.BDateType = "T";
            parameter.UserNo = workstation;
            //check = CXServiceWrapper.Instance.Invoke<ICXSVE00010, PFMDTO00042>(x => x.GetReportDataGenerateInSQL(parameter));
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
                 IList<PFMDTO00042> reportlist = this.ViewDAO.SelectDepositListingByAccountNo(sourceBr, accountNo,workstation);
            
            // updated by ZMS (to form user name)
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
