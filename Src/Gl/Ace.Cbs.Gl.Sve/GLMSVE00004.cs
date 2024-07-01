using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Gl.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
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
    public class GLMSVE00004:BaseService,IGLMSVE00004
    {
        #region Data Properties

        public IGLMDAO00004 MonthlyBudgetedEntryDAO { get; set; }
        #endregion

        #region Methods
        public IList<MNMDTO00010> GetCCOADataList(bool isHomeCur)
        {
            return this.MonthlyBudgetedEntryDAO.GetCCOAData(isHomeCur);
        }

         [Transaction(TransactionPropagation.Required)]
        public bool UpdateCCOAList(IList<MNMDTO00010> editedlist, bool isHomeCur,bool isDelete)
        {
            try
            {
                if (isHomeCur)
                {
                    foreach (MNMDTO00010 item in editedlist)
                    {
                        this.MonthlyBudgetedEntryDAO.UpdateGetCCOADataForHomeCurrency(item,isDelete);
                    }
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = isDelete ? "MI90003" : "MI90001";//Delete Successful or Saving Successful
                    return true;
                }
                else
                {
                    foreach (MNMDTO00010 item in editedlist)
                    {
                        this.MonthlyBudgetedEntryDAO.UpdateGetCCOAData(item,isDelete);
                    }
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = isDelete ? "MI90003" : "MI90001";//Delete Successful or Saving Successful
                    return true;
                }

            }
            catch
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = isDelete ? "ME90002" : "ME90000";
                throw new Exception(this.ServiceResult.MessageCode);
                //return false;
            }
        }

        [Transaction(TransactionPropagation.Required)]
         public bool DeleteAllCCOAList(IList<MNMDTO00010> deleteList,bool isHomeCur)
         {
             try
             {
                 if (isHomeCur)
                 {
                     foreach (MNMDTO00010 item in deleteList)
                     {
                         this.MonthlyBudgetedEntryDAO.UpdateGetCCOADataForHomeCurrency(item, true);
                     }
                 }
                 else
                 {
                     foreach (MNMDTO00010 item in deleteList)
                     {
                         this.MonthlyBudgetedEntryDAO.UpdateGetCCOAData(item, true);
                     }
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
        #endregion
    }
}
