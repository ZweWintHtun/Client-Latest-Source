using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Dmd;
using Spring.Transaction.Interceptor;
using Ace.Windows.Core.DataModel;
using Ace.Windows.Ix.Core.DataModel;
using Spring.Transaction;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Ix.Core.Ctr;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Ctr;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00086 : BaseService, ILOMSVE00086
    {
        #region Properties
        public ICXSVE00002 CodeGenerator { get; set; }
        public ILOMDAO00074 ProductCodeDAO { get; set; }
        public ILOMDAO00099 LoanType_BusinessTypeDAO { get; set; }

        private ILOMDAO00086 loanRecordDAO;
        public ILOMDAO00086 LoanRecordDAO
        {
            get { return this.loanRecordDAO; }
            set { this.loanRecordDAO = value; }
        }

        private LOMORM00086 loanRecordInfo;
        private LOMORM00099 businessTypeInfo;

        #endregion

        #region Helper Method
        private LOMORM00086 GetLoanRecord(LOMDTO00086 loanRecordDTO, bool isDelete)
        {
            loanRecordInfo = new LOMORM00086();

            loanRecordInfo.Id = loanRecordDTO.Id;
            loanRecordInfo.Eno = loanRecordDTO.Eno;
            loanRecordInfo.LoanType = loanRecordDTO.LoanType;
            loanRecordInfo.TownshipCode = loanRecordDTO.TownshipCode;
            loanRecordInfo.VillageCode = loanRecordDTO.VillageCode;
            loanRecordInfo.FinancialYear = loanRecordDTO.FinancialYear;
            loanRecordInfo.BusinessCode = loanRecordDTO.BusinessCode;
            loanRecordInfo.SuspendDate = loanRecordDTO.SuspendDate;
            loanRecordInfo.SuspendAmu = loanRecordDTO.SuspendAmu;
            loanRecordInfo.DeliverDate = loanRecordDTO.DeliverDate;
            loanRecordInfo.TotalGroup = loanRecordDTO.TotalGroup;
            loanRecordInfo.Population = loanRecordDTO.Population;
            loanRecordInfo.Acre = loanRecordDTO.Acre;
            loanRecordInfo.SanctionAmu = loanRecordDTO.SanctionAmu;
            loanRecordInfo.RefundDate = loanRecordDTO.RefundDate;
            loanRecordInfo.RefundAmu = loanRecordDTO.RefundAmu;
            loanRecordInfo.RefundVrNo = loanRecordDTO.RefundVrNo;
            loanRecordInfo.Date_Time = DateTime.Now;
            loanRecordInfo.UserNo = loanRecordDTO.UserNo;
            loanRecordInfo.SourceBr = loanRecordDTO.SourceBr;
            loanRecordInfo.TS = loanRecordDTO.TS;
            loanRecordInfo.CreatedUserId = loanRecordDTO.CreatedUserId;
            loanRecordInfo.CreatedDate = DateTime.Now;
            loanRecordInfo.UpdatedUserId = loanRecordDTO.UpdatedUserId;
            loanRecordInfo.UpdatedDate = DateTime.Now;
            loanRecordInfo.BusinessTypeUM = loanRecordDTO.BusinessTypeUM;
            if (isDelete)
                loanRecordInfo.Active = false;
            else
                loanRecordInfo.Active = true;
            return loanRecordInfo;
        }

        #endregion

        #region MainMethods
        [Transaction(TransactionPropagation.Required)]
        public virtual LOMORM00086 Save(LOMDTO00086 entity)
        {
            LOMORM00086 loanRecord = null;
            loanRecord = this.LoanRecordDAO.Save(this.GetLoanRecord(entity, false));
            this.SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), loanRecord.CreatedUserId, loanRecord.Id.ToString());

            return loanRecord;
        }

        public string SaveServerAndServerClient(LOMDTO00086 entity)
        {
            try
            {

                string voucherNumber = this.CodeGenerator.GenerateLoanRecordVouncher("NormalVoucher", entity.CreatedUserId, entity.SourceBr, new object[] { DateTime.Now.ToString("dd"), DateTime.Now.ToString("MM"), DateTime.Now.ToString("yy") });
                entity.Eno = voucherNumber;                
                LOMORM00086 loanRecord = this.Save(entity);
                if (!this.ServiceResult.ErrorOccurred)
                {
                    return voucherNumber;
                }
                else
                    return "";
            }
            catch
            {
                this.ServiceResult.ErrorOccurred = true;
                return "ME90036";
            }
        }

        public IList<LOMDTO00099> GetLoanRecordByLoanNo(string eno)
        {
            try
            {
                return this.LoanType_BusinessTypeDAO.SelectByLoanNo(eno);
            }
            catch
            {
                return null;
            }
        }

        public int CheckLoanAccNo(string acctNo)
        {
            try { return this.LoanRecordDAO.CheckLoanAccNo(acctNo); }
            catch { return 0; }
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual void UpdateLoanRecord(LOMDTO00086 entity, IList<DataVersionChangedValueDTO> dvcvList, string status)
        {
            try
            {
                if (this.UpdateServer(entity, dvcvList) != null)
                {
                    LOMORM00086 loanRecord = this.UpdateServer(entity, dvcvList);
                }
            }
            catch
            {
                this.ServiceResult.ErrorOccurred = true;
            }
        }

        /* Update To SQLServer by using DAO Query */
        [Transaction(TransactionPropagation.Required)]
        public LOMORM00086 UpdateServer(LOMDTO00086 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            try
            {
                LOMORM00086 loanRecordEntity = null;
                if (this.LoanRecordDAO.UpdateLoanRecord(entity) == true)
                {
                    loanRecordEntity = this.GetLoanRecord(entity, false);
                    return loanRecordEntity;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                throw;
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual void Delete(string eno)
        {
            try
            {
                bool result = this.LoanRecordDAO.DeleteLoanRecord(eno);
                if (result)
                {
                    this.ServiceResult.MessageCode = "MI90003";
                }
                else
                {
                    this.ServiceResult.MessageCode = "ME90036";
                }
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";
                throw new Exception(this.ServiceResult.MessageCode);
            }
        }

        public void SaveOrUpdateClientDataVersion(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId, string dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
            LOMORM00086 HolidayORM = new LOMORM00086();

            //Require Data
            clientDataVersionDTO.ORMObjectName = HolidayORM;
            clientDataVersionDTO.DataIdValue = dataValueId;
            clientDataVersionDTO.CreatedUserId = createdUserId;

            //ChangedDataContents
            IList<ChangeDataContent> cdclist = new List<ChangeDataContent>();
            foreach (DataVersionChangedValueDTO dvcvdto in dvcvList)
            {
                ChangeDataContent cdcdto = new ChangeDataContent();
                cdcdto.Property = dvcvdto.OrmPropertyName;
                cdcdto.OldValue = dvcvdto.OrmPreviousValue;
                cdcdto.NewValue = dvcvdto.OrmNewValue;
                cdclist.Add(cdcdto);
            }
            clientDataVersionDTO.ChangeDataContentList = cdclist;
            CXServiceWrapper.Instance.Invoke<IDataVersionUpdateService, bool>(x => x.SaveOrUpdateClientDataVersion(clientDataVersionDTO, dataAction));
        }
        #endregion       

        #region SaveLoanType_BusinessType
        public LOMORM00099 GetLoanType_BusinessType(LOMDTO00099 businessType, bool isDelete)
        {
            try
            {
                businessTypeInfo = new LOMORM00099();
                businessTypeInfo.Id = businessType.Id;
                businessTypeInfo.RENO = businessType.Eno;
                businessTypeInfo.UM = businessType.UM;
                businessTypeInfo.BusinessType = businessType.BusinessType;
                businessTypeInfo.TS = businessType.TS;
                businessTypeInfo.CreatedDate = DateTime.Now;
                businessTypeInfo.CreatedUserId = CurrentUserEntity.CurrentUserID;
                businessTypeInfo.UpdatedDate = DateTime.Now;
                businessTypeInfo.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                businessTypeInfo.Active = (isDelete) ? true : false;
                return businessTypeInfo;
            }
            catch { return null; }
        }

        public bool SaveServerForLoanType_BusinessType(IList<LOMDTO00099> lstBusinessType)
        {
            try
            {
                int count = this.SaveBusinessType(lstBusinessType);
                return (!this.ServiceResult.ErrorOccurred && count > 0 && count == lstBusinessType.Count) ? true:false;
            }
            catch
            {
                return false;
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public int SaveBusinessType(IList<LOMDTO00099> lstBusinessType)
        {
            try
            {
                int count = 0;
                foreach (LOMDTO00099 businessType in lstBusinessType)
                {
                    LOMORM00099 loanBusinessTypeRecord = null;
                    loanBusinessTypeRecord = this.LoanType_BusinessTypeDAO.Save(this.GetLoanType_BusinessType(businessType, true));
                    this.SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), loanBusinessTypeRecord.CreatedUserId, loanBusinessTypeRecord.Id.ToString());
                    count++;
                }
                return count;
            }
            catch { return 0; }
        }
        #endregion

        #region Delete LoanRecord_BusinessType
        //public void deleteBusinessType(IList<LOMDTO00099> lstDeleteBT)
        //{
        //    this.LoanType_BusinessTypeDAO.DeleteLoanRecord_BusinessType(lstDeleteBT);
        //}
        #endregion
    }
}
