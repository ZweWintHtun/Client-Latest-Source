using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Gl.Ctr.Sve;
using Ace.Cbs.Gl.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Gl.Ptr
{
    public class GLMCTL00004 : AbstractPresenter,IGLMCTL00004
    {
        #region "Data Properties"
        private IGLMVEW00004 view;
        public IGLMVEW00004 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private void WireTo(IGLMVEW00004 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetMonthlyBudgetedData());
            }
        }
        public IList<MNMDTO00010> EditedCCOAList { get; set; }
        #endregion

        #region "Methods"

        private MNMDTO00010 GetMonthlyBudgetedData()
        {
            MNMDTO00010 dto = new MNMDTO00010();
            dto.IsHomeCurrency = this.view.IsHomeCurrency;
            return dto;
        }
        public IList<MNMDTO00010> GetCCOA()
        {
            return CXClientWrapper.Instance.Invoke<IGLMSVE00004, IList<MNMDTO00010>>(x => x.GetCCOADataList(this.view.IsHomeCurrency));
        }

        /// <summary>
        /// To get edited dto
        /// </summary>
        /// <param name="editeddto"></param>
        public void GetEditedCCOAList(MNMDTO00010 editeddto)
        {
            if (this.EditedCCOAList == null)
            {
                this.EditedCCOAList = new List<MNMDTO00010>();
                this.EditedCCOAList.Add(editeddto);
                return;
            }
            MNMDTO00010 existeddto = this.EditedCCOAList.Where(x => x.ACODE.Equals(editeddto.ACODE) && x.DCODE.Equals(editeddto.DCODE)
                                                                                && x.CUR.Equals(editeddto.CUR)).FirstOrDefault();

            if (existeddto != null)
                this.EditedCCOAList.Remove(existeddto);
            this.EditedCCOAList.Add(editeddto);
        }

        public void UpdateMonthlyBudgetedEntry(bool isDelete,IList<MNMDTO00010> checkedCCOAList)
        {
            if (isDelete)
            {
                for (int i = 0; i < checkedCCOAList.Count; i++)
                    checkedCCOAList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
                CXClientWrapper.Instance.Invoke<IGLMSVE00004, bool>(x => x.UpdateCCOAList(checkedCCOAList, this.view.IsHomeCurrency, true));
            }
            else
            {
                if (this.EditedCCOAList == null) return;
                CXClientWrapper.Instance.Invoke<IGLMSVE00004, bool>(x => x.UpdateCCOAList(this.EditedCCOAList, this.view.IsHomeCurrency, false));
            }

            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            else
            {
                this.View.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                this.EditedCCOAList = null;
            }
        }

        public void DeleteAllMonthlyBudgetedEntry()
        {
            for (int i = 0; i < this.view.CCOADto.Count; i++)
                this.view.CCOADto[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
            CXClientWrapper.Instance.Invoke<IGLMSVE00004, bool>(x => x.DeleteAllCCOAList(this.view.CCOADto, this.view.IsHomeCurrency));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            else
            {
                this.View.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }
        #endregion
    }
}
