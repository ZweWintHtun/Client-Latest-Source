using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Admin.Contracts.Dao;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Tcm.Sve
{
    public class TCMSVE00022 : BaseService, ITCMSVE00022
    {
        #region Properties

        private IUserDAO userDAO;
        public IUserDAO UserDAO
        {
            get { return this.userDAO; }
            set { this.userDAO = value; }
        }

        #endregion

        #region Logical Methods

        public IList<UserDTO> SelectByBranchCode(string branchCode)
        {
            return this.UserDAO.SelectByBranchCode(branchCode);
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual void DeactivateUser(IList<UserDTO> userList)
        {
            try
            {
                foreach (UserDTO user in userList)
                {
                    user.UpdatedDate = DateTime.Now;
                    this.UserDAO.UpdateByUserId(false, user.Id, user.CreatedUserId, user.UpdatedDate.Value);
                }
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90003";//Delete Success
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";
                throw new Exception(this.ServiceResult.MessageCode);
            }
        }

        #endregion

    }
}