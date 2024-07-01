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
    public class GLMSVE00018 : BaseService, IGLMSVE00018
    {
        private GLMORM00001 FormatFileORM;
        IGLMDAO00014 ReportFormatEntryDAO { get; set; }
        IList<GLMDTO00001> FormatFileDataList { get; set; }

        [Transaction(TransactionPropagation.Required)]
        public IList<GLMDTO00001> GetAllFormatFile(string formatType, string formatStatus)
        {
            return FormatFileDataList = ReportFormatEntryDAO.GetFormatFileDataListForFormulaEntry(formatType,formatStatus);
        }

        public void Save(IList<GLMDTO00001> formatFileDataList)
        {
            this.DeleteOldList(formatFileDataList[0].FormatType,formatFileDataList[0].FormatStatus);
            if (formatFileDataList.Count > 0)
            {                 
                foreach (GLMDTO00001 formatFileData in formatFileDataList)
                {   
                    //ReportFormatEntryDAO.DeleteAll(formatFileData);
                    ReportFormatEntryDAO.Save(ConvertToORM(formatFileData));                    
                }
                if (this.ServiceResult.ErrorOccurred == false)
                {
                    this.ServiceResult.MessageCode = "MI90001"; //Saving Successful
                }
                else
                {
                    //return;
                    throw new Exception("ME90000"); //Saving Error.
                }
            }            
        }

        public void Delete(IList<GLMDTO00001> formatFileDeleteList)
        {
            if (formatFileDeleteList.Count > 0)
            {
                foreach (GLMDTO00001 formatFileData in formatFileDeleteList)
                {
                   ReportFormatEntryDAO.Delete(formatFileData);
                    //ReportFormatEntryDAO.Delete(ConvertToORM(formatFileData),true);
                }
            }
        }

        public void DeleteOldList(string formatType, string formatStatus)
        {
            IList<GLMDTO00001> DeleteOldList = GetAllFormatFile(formatType, formatStatus);
            if(DeleteOldList != null || DeleteOldList.Count > 0)
            {
                foreach (GLMDTO00001 formatFileData in FormatFileDataList)
                {
                    ReportFormatEntryDAO.DeleteAll(formatFileData);
                }
            }
        }

        public GLMORM00001 ConvertToORM(GLMDTO00001 formatFileData)
        {        
            if(this.FormatFileORM == null)
                FormatFileORM = new GLMORM00001();
                FormatFileORM.Id = FormatFileORM.Id;       
                FormatFileORM.LineNo = formatFileData.LineNo;
                FormatFileORM.FormatType = formatFileData.FormatType;
                FormatFileORM.FormatName = formatFileData.FormatName;
                FormatFileORM.FormatStatus = formatFileData.FormatStatus;
                FormatFileORM.ACode = formatFileData.ACode;
                FormatFileORM.DCode = formatFileData.DCode == null ? string.Empty : formatFileData.DCode;
                FormatFileORM.Description = formatFileData.Description;
                FormatFileORM.AccountRange1 = formatFileData.AccountRange1 == null ? string.Empty : formatFileData.AccountRange1;
                FormatFileORM.AccountRange2 = formatFileData.AccountRange2 == null ? string.Empty : formatFileData.AccountRange2;
                FormatFileORM.LineRange1 = formatFileData.LineRange1 == null ? "0" : formatFileData.LineRange1;
                FormatFileORM.LineRange2 = formatFileData.LineRange2 == null ? "0" : formatFileData.LineRange2;
                FormatFileORM.ShowHide = formatFileData.ShowHide == null ? "N" : formatFileData.ShowHide;
                FormatFileORM.AmountTotal = formatFileData.AmountTotal;
                if(formatFileData.Other == null || formatFileData.Other == "")
                {
                    FormatFileORM.Other = string.Empty ;  
                    FormatFileORM.Status = formatFileData.Status;
                }
                else
                {
                   FormatFileORM.Other = formatFileData.Other; 
                    FormatFileORM.Status = "O";
                }
                FormatFileORM.Normal = formatFileData.Normal;
                FormatFileORM.CreatedDate = formatFileData.CreatedDate;
                FormatFileORM.CreatedUserId = formatFileData.CreatedUserId;
           
            return FormatFileORM;
        }
    }
}
