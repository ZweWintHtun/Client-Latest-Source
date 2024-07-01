using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00301 : BaseService, ILOMSVE00301
    {
        #region "Properties"
        private ILOMDAO00085 farmliDAO;
        public ILOMDAO00085 FarmLiDAO
        {
            get { return this.farmliDAO; }
            set { this.farmliDAO = value; }
        }
        #endregion

        [Transaction(TransactionPropagation.Required)]
        public bool Update(LOMDTO00085 farmLiDto)
        {
            try
            {
                bool isUpdate = false;
                try 
                {
                    if (this.FarmLiDAO.UpdateFarmLoanInterest(
                        (decimal)farmLiDto.TotalInt,
                        (decimal)farmLiDto.LastInt,
                        (decimal)farmLiDto.M1,
                        (decimal)farmLiDto.M2,
                        (decimal)farmLiDto.M3,
                        (decimal)farmLiDto.M4,
                        (decimal)farmLiDto.M5,
                        (decimal)farmLiDto.M6,
                        (decimal)farmLiDto.M7,
                        (decimal)farmLiDto.M8,
                        (decimal)farmLiDto.M9,
                        (decimal)farmLiDto.M10,
                        (decimal)farmLiDto.M11,
                        (decimal)farmLiDto.M12,
                        (DateTime)farmLiDto.UpdatedDate,
                        (int)farmLiDto.UpdatedUserId,
                        farmLiDto.LNo,
                        farmLiDto.AcctNo,
                        farmLiDto.SourceBr))
                    {
                        isUpdate = true;
                    }
                }
                catch
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME90000";
                    isUpdate = false;
                }
                return isUpdate;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.InnerException + ex.Message);
            }
        }
    }
}
