using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Gl.Ctr.Sve;
using Ace.Windows.Core.Service;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Gl.Ctr.Dao;
using Ace.Cbs.Gl.Dmd;

namespace Ace.Cbs.Gl.Sve
{
    public class GLMSVE00007 : BaseService, IGLMSVE00007
    {
        #region DAOProperties

        IGLMDAO00014 ReportFormatEntryDAO { get; set; }

        IList<GLMDTO00001> FormatFileDataList { get; set; }

        private GLMORM00001 FormatFileORM;
        #endregion

        #region MainMethod

        [Transaction(TransactionPropagation.Required)]
        public IList<GLMDTO00001> GetFormatFileDataList(string formatStatus)
        {
            return FormatFileDataList = ReportFormatEntryDAO.GetFormatFileDataListForReportFormatEntry(formatStatus);
        }

        [Transaction(TransactionPropagation.Required)]
        public void Save(GLMDTO00001 viewData)
        {
            try
            {
                if (this.ReportFormatEntryDAO.CheckExist(0, viewData.FormatType, viewData.FormatStatus))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV30028"; //Format Type should not be duplicate.
                }
                else
                {
                    this.ReportFormatEntryDAO.Save(this.ConvertToORM(viewData));
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = "MI90001"; //Saving Successful
                }
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual void Update(GLMDTO00001 viewData)
        {
            try
            {
                viewData.UpdatedDate = DateTime.Now;
                this.ReportFormatEntryDAO.Update(viewData);
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90002"; //Update Success               
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual void Delete(IList<GLMDTO00001> deleteList)
        {
            try
            {
                foreach (GLMDTO00001 deleteitem in deleteList)
                {                 
                    this.ReportFormatEntryDAO.Delete(deleteitem);
                }
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90003"; //Delete Success
            }

            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";
                throw new Exception(this.ServiceResult.MessageCode);
            }
        }

        public GLMORM00001 ConvertToORM(GLMDTO00001 saveData)        
        {
            FormatFileORM = new GLMORM00001();
            FormatFileORM.Id = saveData.Id;
            FormatFileORM.FormatType = saveData.FormatType;
            FormatFileORM.FormatName = saveData.FormatName;
            FormatFileORM.LineNo = 0;
            FormatFileORM.ACode = saveData.ACode == null ? string.Empty : saveData.ACode;
            FormatFileORM.DCode = saveData.DCode == null ? string.Empty : saveData.DCode;
            FormatFileORM.Description = saveData.Description == null ? string.Empty : saveData.Description;
            FormatFileORM.AccountRange1 = saveData.AccountRange1 == null ? string.Empty : saveData.AccountRange1;
            FormatFileORM.AccountRange2 = saveData.AccountRange2 == null ? string.Empty : saveData.AccountRange2;
            FormatFileORM.LineRange1 = saveData.LineRange1 == null ? string.Empty : saveData.LineRange1;
            FormatFileORM.LineRange2 = saveData.LineRange2 == null ? string.Empty : saveData.LineRange2;
            FormatFileORM.Other = saveData.Other == null ? string.Empty : saveData.Other;
            FormatFileORM.Status = saveData.Status == null ? string.Empty : saveData.Status;
            FormatFileORM.ShowHide = "N"; 
            FormatFileORM.AmountTotal = "Y";
            FormatFileORM.FormatStatus = saveData.FormatStatus;
            FormatFileORM.Normal = saveData.Normal;
            FormatFileORM.UId = saveData.UId;
            FormatFileORM.Active = true;
            FormatFileORM.CreatedDate = saveData.CreatedDate;
            FormatFileORM.CreatedUserId = saveData.CreatedUserId;
            FormatFileORM.UpdatedDate = saveData.UpdatedDate;
            FormatFileORM.UpdatedUserId = saveData.UpdatedUserId;      
            
            return FormatFileORM;
        }     
        #endregion
    }
}
