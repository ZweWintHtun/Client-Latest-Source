using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Tcm.Ctr.Sve;

using Ace.Windows.CXServer.Utt;



namespace Ace.Cbs.Tcm.Sve
{
    public class TCMSVE00008:BaseService, ITCMSVE00008
    {
        #region Properties
        public IPFMDAO00006 ChequeDAO { get; set; }
        #endregion

        public PFMDTO00006 GetChequeInfoByChequeBookNo(string chequeBookNo,string branchCode)
        {
            PFMDTO00006 chequeInfo = this.ChequeDAO.GetChequeInfoByChequeBookNo(chequeBookNo, branchCode);

            if (chequeInfo == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV00059"; //Duplicate Cheque Book No or Cheque No.\n Please enter New Cheque Book No and Cheque No.
            }
            else if (chequeInfo.CloseDate != null && chequeInfo.CloseDate != System.DateTime.MinValue)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV00228" ; //	This Cheque Book No is already stopped.
            }
            return chequeInfo;
        }

        public string SaveCheque(PFMDTO00006 chequeDTO)
        {
            try
            {
                chequeDTO.UpdatedDate = chequeDTO.CreatedDate;
                chequeDTO.UpdatedUserId = chequeDTO.CreatedUserId;
                this.ChequeDAO.UpdateChequeInfoByChequeBookNo(chequeDTO.ChequeBookNo, chequeDTO.StartNo, chequeDTO.EndNo, chequeDTO.SourceBranchCode, chequeDTO.UpdatedUserId, chequeDTO.UpdatedDate);
                return chequeDTO.ChequeBookNo;
            }
            catch
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90000";
                return null;
            }

        }

    }
}
