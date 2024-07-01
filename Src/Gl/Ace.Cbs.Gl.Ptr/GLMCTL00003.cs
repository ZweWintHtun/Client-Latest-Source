using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Gl.Ctr.Ptr;
using Ace.Cbs.Gl.Ctr.Sve;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Gl.Ptr 
{
    public class GLMCTL00003 : AbstractPresenter , IGLMCTL00003
    {
        #region "Data Properties"
        public IGLMVEW00003 View { get; set; }
        private IList<MNMDTO00010> CCOADataList { get; set; }
        public IList<MNMDTO00010> EditedDataList { get; set; }
        #endregion

        public IList<MNMDTO00010> GetCCOA()
        {
            CCOADataList = CXClientWrapper.Instance.Invoke<IGLMSVE00003, IList<MNMDTO00010>>(x => x.GetCCOADataList());
            return CCOADataList;   
        }

        public void GetEditedCCOAList(MNMDTO00010 editeddto)
        {
            if (EditedDataList == null)
            {
                EditedDataList = new List<MNMDTO00010>();
                this.EditedDataList.Add(editeddto);
                return;
            }

            MNMDTO00010 existeddto = this.EditedDataList.Where(x => x.ACODE.Equals(editeddto.ACODE) && x.DCODE.Equals(editeddto.DCODE)
                                                                                && x.CUR.Equals(editeddto.CUR)).FirstOrDefault();

            if (existeddto != null)
                this.EditedDataList.Remove(existeddto);
            this.EditedDataList.Add(editeddto);
        }

        public void UpdateYearlyBudgetEntry(bool IsDelete, IList<MNMDTO00010> checkedCCOADataList)
        {
            if (IsDelete == false)
            {
                if (EditedDataList == null) return;
                CXClientWrapper.Instance.Invoke<IGLMSVE00003, bool>(x => x.UpdateCCOAListForYearlyBudgetEntry(EditedDataList, false));
            }
            else
            {
                for (int i = 0; i < checkedCCOADataList.Count; i++)
                    checkedCCOADataList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
                CXClientWrapper.Instance.Invoke<IGLMSVE00003, bool>(x => x.UpdateCCOAListForYearlyBudgetEntry(checkedCCOADataList, true)); //Delete Button Click
            }

            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            else
                this.View.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
        }

        public void DeleteYearlyBudgetEntry()
        {
            for (int i = 0; i < CCOADataList.Count; i++)
                CCOADataList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
            CXClientWrapper.Instance.Invoke<IGLMSVE00003, bool>(x => x.UpdateCCOAListForYearlyBudgetEntry(CCOADataList, true)); //Delete All Click
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            else
                this.View.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
        }
    }
}
