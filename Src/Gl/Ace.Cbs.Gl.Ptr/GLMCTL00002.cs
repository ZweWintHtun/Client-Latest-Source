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
    public class GLMCTL00002 : AbstractPresenter, IGLMCTL00002
    {

        #region "Data Properties"
        public IGLMVEW00002 View { get; set; }
        private IList<MNMDTO00010> CCOADataList { get; set; }
        #endregion

        #region "Methods"

        public IList<MNMDTO00010> GetCCOA()
        {
            CCOADataList = CXClientWrapper.Instance.Invoke<IGLMSVE00002, IList<MNMDTO00010>>(x => x.GetCCOADataList());
            if (CCOADataList.Count > 0)
            {
                decimal balance = 0;
                for (int i = 0; i < CCOADataList.Count; i++)
                {
                    CCOADataList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
                    if (CCOADataList[i].ACTYPE == "A")
                    {
                       // this.View.OutOfBalance = this.View.OutOfBalance + Convert.ToDecimal(CCOADataList[i].HOBAL);
                        balance += Convert.ToDecimal(CCOADataList[i].HOBAL) == null ? 0 : Convert.ToDecimal(CCOADataList[i].HOBAL);
                    }
                    else
                    {
                        balance -= Convert.ToDecimal(CCOADataList[i].HOBAL) == null ? 0 : Convert.ToDecimal(CCOADataList[i].HOBAL);
                    }
                }
                this.View.OutOfBalance = balance;
            }
            return CCOADataList;
        }

        //public IList<MNMDTO00010> GetCCOA()
        //{
        //    CCOADataList = CXClientWrapper.Instance.Invoke<IGLMSVE00002, IList<MNMDTO00010>>(x => x.GetCCOADataList());
        //    if (CCOADataList.Count > 0)
        //    {
        //        for (int i = 0; i < CCOADataList.Count; i++)
        //        {
        //            if (CCOADataList[i].ACTYPE == "A")
        //            {
        //                this.View.OutOfBalance = this.View.OutOfBalance + Convert.ToDecimal(CCOADataList[i].HOBAL);
        //            }
        //            else
        //            {
        //                this.View.OutOfBalance = this.View.OutOfBalance - Convert.ToDecimal(CCOADataList[i].HOBAL);
        //            }
        //        }               
        //    }
        //    return CCOADataList;
        //}

        //public void GetEditedCCOAList(MNMDTO00010 editeddto)
        //{
        //    if (this.CCOADataList == null)
        //    {
        //        this.CCOADataList = new List<MNMDTO00010>();
        //        this.CCOADataList.Add(editeddto);
        //        return;
        //    }

        //    MNMDTO00010 existeddto = this.CCOADataList.Where(x => x.ACODE.Equals(editeddto.ACODE) && x.DCODE.Equals(editeddto.DCODE)   //Check for removing the firstcell saved value 
        //                                                                        && x.CUR.Equals(editeddto.CUR)).FirstOrDefault();

        //    if (existeddto != null)
        //        this.CCOADataList.Remove(existeddto); // if firstCell value saved Dto is existed , remove the row and
        //    this.CCOADataList.Add(editeddto);  //added with secondCell Changed Value.
        //}

        public void GetEditedCCOAList(MNMDTO00010 editeddto)
        {
            this.CCOADataList.Add(editeddto);
        }

        public void UpdateOpeningBalanceEntry(bool IsDelete)
        {           
            if (IsDelete == false)
            {               
                CXClientWrapper.Instance.Invoke<IGLMSVE00002, bool>(x => x.UpdateCCOAListForOpeningBalanceEntry(CCOADataList, false));
            }
            else
            {
                IList<MNMDTO00010> CheckedCCOADataList = this.View.DataSource.Where<MNMDTO00010>(x => x.IsCheck == true).ToList();

                if (CheckedCCOADataList.Count.Equals(0))
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90012);/*Please Select at least one record.*/
                    return;
                }
                else
                {
                    CXClientWrapper.Instance.Invoke<IGLMSVE00002, bool>(x => x.UpdateCCOAListForOpeningBalanceEntry(CheckedCCOADataList, true)); //Delete Button Click
                }
            }

            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            else
                this.View.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
        }

        public void DeleteOpeningBalanceEntry()
        {
            this.View.OutOfBalance = 0;
            CXClientWrapper.Instance.Invoke<IGLMSVE00002, bool>(x => x.UpdateCCOAListForOpeningBalanceEntry(CCOADataList, true)); //Delete All Click
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            else
                this.View.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
        }
        #endregion

    }
}
