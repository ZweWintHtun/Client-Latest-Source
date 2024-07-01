using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
//using Ace.Cbs.Cx.Ser.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Mnm.Sve
{
    public class MNMSVE00012 : BaseService, IMNMSVE00012
    {

        #region Properties
        public ICXSVE00002 CodeGenerator { get; set; }
        public IPFMDAO00054 TlfDAO { get; set; }
        public ICXDAO00006 codeCheckerDAO { get; set; }
        public ICXSVE00006 reversalSVE { get; set; }

        public string EntryNo { get; set; }

        private ITLMDAO00016 paymentOrderDAO;

        public ITLMDAO00016 PaymentOrderDAO
        {
            get { return this.paymentOrderDAO; }
            set { this.paymentOrderDAO = value; }
        }

        private TLMORM00016 PaymentOrderInfo;
                
        #endregion

        #region Methods

        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00054> SelectTlfInfoByEntryNoandDateTime(string eno,string trancode1,string trancode2,string sourcebr)
        {
            IList<PFMDTO00054> tlflist = this.TlfDAO.SelectTlfInfoByEnoandDate(eno,trancode1,trancode2,sourcebr);
            if (tlflist.Count <= 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME30012";    //Data Not Found
                return tlflist;
            }
            string pono = tlflist[0].PaymentOrderNo;
            if (!this.paymentOrderDAO.CheckExist(pono))               //check pono in po(If not exist,return true)
            {
                return tlflist;
            }
            else
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV00103";     //Invalid PO
            }
            return tlflist;
        }

        public TLMDTO00016 SelectPOInfoByPONO(string PoNo,string sourcebr)
        {
            TLMDTO00016 podto = this.codeCheckerDAO.SelectPOByPoNo(PoNo,sourcebr);
            return podto;
        }

        [Transaction(TransactionPropagation.Required)]
        public string Save(PFMDTO00054 Entity)
        {
            string vouno = string.Empty;

            //int updatedUserId = CurrentUserEntity.CurrentUserID;
            int updatedUserId = Entity.CreatedUserId;

            //vouno = this.CodeGenerator.GetGenerateCode("PORRENO", string.Empty, updatedUserId, CurrentUserEntity.BranchCode, new object[] { DateTime.Now.Day.ToString().PadLeft(2, '0'), DateTime.Now.Month.ToString().PadLeft(2, '0'), DateTime.Now.Year.ToString().Substring(2) });
            vouno = this.CodeGenerator.GetGenerateCode("PORRENO", string.Empty, updatedUserId, Entity.SourceBranchCode, new object[] { DateTime.Now.Day.ToString().PadLeft(2, '0'), DateTime.Now.Month.ToString().PadLeft(2, '0'), DateTime.Now.Year.ToString().Substring(2) });

            //call Reversal Common Module
            //this.reversalSVE.ReversalProcess(Entity.Eno, vouno, null, CurrentUserEntity.BranchCode, System.DateTime.Now, CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID, new TLMDTO00015(), "PORCL",true);
            this.reversalSVE.ReversalProcess(Entity.Eno, vouno, null, Entity.SourceBranchCode, Entity.DateTime, Entity.SourceBranchCode, updatedUserId, new TLMDTO00015(), "PORCL", true);
            if (reversalSVE.ServiceResult.ErrorOccurred)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME30002"; //Not Allow Back Date Transaction
              //  return;
            }
            TLMDTO00016 entity = new TLMDTO00016();
            try
            {
                this.paymentOrderDAO.UpdateIDateAndStatus(Entity.PaymentOrderNo, Entity.UpdatedUserId.Value);
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90002";//Update Success
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";
                throw new Exception(this.ServiceResult.MessageCode);
            }
            return vouno;
        }


        [Transaction(TransactionPropagation.Required)]
        public virtual void Update(TLMDTO00016 entity)
        {
            try
            {
                entity.UpdatedDate = DateTime.Now;
                entity.IDate = null;
                entity.Status = null;
                this.paymentOrderDAO.Update(this.GetPO(entity, true));
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90002";//Update Success
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";
            }
        }

        private TLMORM00016 GetPO(TLMDTO00016 paymentOrderDTO, bool isEdit)
        {
            PaymentOrderInfo = new TLMORM00016();

            PaymentOrderInfo.PONo = paymentOrderDTO.PONo;
            PaymentOrderInfo.IDate = paymentOrderDTO.IDate;
            PaymentOrderInfo.Status = paymentOrderDTO.Status;

            return PaymentOrderInfo;
        }

        // Convert DTO to ORM method
        private PFMORM00054 GetPORREntity(PFMDTO00054 Entity)
        {
            PFMORM00054 porrOrmEntity = new PFMORM00054();
            porrOrmEntity.Eno = Entity.Eno;

            return porrOrmEntity;
        }

       
        #endregion
    }
}
