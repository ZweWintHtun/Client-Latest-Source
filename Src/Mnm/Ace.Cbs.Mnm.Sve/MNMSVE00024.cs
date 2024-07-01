using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Mnm.Sve
{
    public class MNMSVE00024 : BaseService, IMNMSVE00024
    {
        #region DAO_Properties

        public ITLMDAO00001 ReDAO { get; set; }
        public TLMDTO00001 ReDto { get; set; }

        #endregion

        public TLMDTO00001 SelectReInfoByRegisterNo(string registerNo,string branchNo)
        {
            ReDto = this.ReDAO.SelectREInformationByRegisterNo(registerNo, branchNo);
            return ReDto;           
        }

        [Transaction(TransactionPropagation.Required)]
        public void Save_ReEntity(TLMDTO00001 Re_entity)
        {
            try
            {
                if (this.ReDAO.CheckExistRegisterNo(Re_entity.RegisterNo))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV90001";//data already exists                     
                }
                else
                {
                    //this.ReDAO.UpdateReEntity(Re_entity.RegisterNo,Re_entity.RegisterNo_Old, CurrentUserEntity.CurrentUserID, DateTime.Now);
                    this.ReDAO.UpdateReEntity(Re_entity.RegisterNo, Re_entity.RegisterNo_Old, Re_entity.UpdatedUserId, DateTime.Now);
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = "MI90002";// Update Successful
                }
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";
            }
        }      
    }
}
