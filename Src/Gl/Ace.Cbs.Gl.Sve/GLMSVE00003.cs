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
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Gl.Sve
{
    public class GLMSVE00003 : BaseService , IGLMSVE00003
    {
        #region Properties
        public IGLMDAO00008 YearlyBudgetEntryDAO { get; set; }
        
        #endregion

        public IList<MNMDTO00010> GetCCOADataList()
        {
            return this.YearlyBudgetEntryDAO.GetCCOADataListForYearlyBudgetEntry();
        }

        public bool UpdateCCOAListForYearlyBudgetEntry(IList<MNMDTO00010> editedccoalist, bool IsDelete)
        {
            try
            {
                if (IsDelete == false)
                {
                    foreach (MNMDTO00010 editedccoadto in editedccoalist)
                    {
                        this.YearlyBudgetEntryDAO.UpdateCCOAForYearlyBudgetEntry(editedccoadto, false);
                    }
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = "MI90001"; //Saving Successful
                    return true;
                }
                else
                {
                    foreach (MNMDTO00010 editedccoadto in editedccoalist)
                    {
                        this.YearlyBudgetEntryDAO.UpdateCCOAForYearlyBudgetEntry(editedccoadto, true);
                    }
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = "MI90003"; //Delete Successful
                    return true;
                }
            }
            catch
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = IsDelete ? "ME90002" : "ME90000";
                throw new Exception(this.ServiceResult.MessageCode);
                //return false;
            } 
        }

        [Transaction(TransactionPropagation.Required)]
        public bool DeleteAllCCOAListForOpeningBalanceEntry(IList<MNMDTO00010> ccoaDataList)
        {
            try
            {
                foreach (MNMDTO00010 ccoadto in ccoaDataList)
                {
                    this.YearlyBudgetEntryDAO.UpdateCCOAForYearlyBudgetEntry(ccoadto, true);
                }

                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90003"; //Delete Successful
                return true;
            }
            catch
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90002"; //Deleting Error
                throw new Exception(this.ServiceResult.MessageCode);
                //return false;
            }
        }
    }
}
