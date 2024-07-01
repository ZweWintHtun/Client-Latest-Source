using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.CXServer.Utt;
using Ace.Cbs.Cx.Com.Ctr;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Windows.Core.DataModel;
using Ace.Windows.Ix.Core.Ctr;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00415 : BaseService, ILOMSVE00415
    {
        #region Properties

        private ILOMDAO00415 personalLoanProductCodeDAO;
        public ILOMDAO00415 PersonalLoanProductCodeDAO
        {
            get { return this.personalLoanProductCodeDAO; }
            set { this.personalLoanProductCodeDAO = value; }
        }

        private LOMORM00415 ProductCodeInfo;

        #endregion

        #region Save
        [Transaction(TransactionPropagation.Required)]
        public void Save(LOMDTO00415 entity)
        {
            try
            {
                if (entity != null)
                    this.PersonalLoanProductCodeDAO.Save(entity);
                
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90001";

            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90000";
                throw;
            }
        }
        #endregion

        #region Update
        [Transaction(TransactionPropagation.Required)]
        public void Update(LOMDTO00415 entity)
        {
            try
            {
                if (entity != null)
                    this.PersonalLoanProductCodeDAO.Update(entity);


                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90001";

            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90000";
                throw;
            }
        }
        #endregion

        #region Delete
        [Transaction(TransactionPropagation.Required)]
        public virtual void Delete(IList<LOMDTO00415> entitylst)
        {
            try
            {
                if (entitylst.Count > 0)
                {
                    for (int i = 0; i < entitylst.Count; i++)
                    {
                        this.PersonalLoanProductCodeDAO.Delete(entitylst[i]);
                    }

                }
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90003";

            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90002";
                throw;
            }
        }
        #endregion

        #region Methods
        public virtual IList<LOMDTO00415> GetAll()
        {
            return this.PersonalLoanProductCodeDAO.SelectAll();
        }

        public IList<LOMDTO00415> SelectAll_ACode()
        {
            return this.PersonalLoanProductCodeDAO.SelectAll_ACode();
        }

        public IList<LOMDTO00415> CheckExist2(string groupCode, string prefix, string desp)
        {
            return this.PersonalLoanProductCodeDAO.CheckExist2(groupCode, prefix, desp);
        }
        #endregion

        #region Helper Method

        private LOMORM00415 GetAdvanceData(LOMDTO00415 productCodeDTO, bool isDelete)
        {
            ProductCodeInfo = new LOMORM00415();

            ProductCodeInfo.ProductCode = productCodeDTO.ProductCode;
            ProductCodeInfo.Description = productCodeDTO.Description;
            ProductCodeInfo.RelatedGLACode = productCodeDTO.RelatedGLACode;
            ProductCodeInfo.TS = productCodeDTO.TS;

            ProductCodeInfo.CreatedUserId = productCodeDTO.CreatedUserId;
            ProductCodeInfo.CreatedDate = DateTime.Now;

            ProductCodeInfo.UpdatedUserId = productCodeDTO.UpdatedUserId;
            ProductCodeInfo.UpdatedDate = DateTime.Now;

            if (isDelete)
                ProductCodeInfo.Active = false;
            else
                ProductCodeInfo.Active = true;

            return ProductCodeInfo;
        }

        #endregion

       

    }
}
