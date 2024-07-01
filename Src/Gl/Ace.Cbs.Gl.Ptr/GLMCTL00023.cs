using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
//using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Gl.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Gl.Ctr.Sve;
using Ace.Cbs.Gl.Ctr.Ptr;
using Ace.Windows.Admin.DataModel;
//using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Gl.Ptr
{
    public class GLMCTL00023 : AbstractPresenter, IGLMCTL00023
    {
        #region Properties

        public GLMCTL00023() { }

        private IGLMVEW00023 view;
        public IGLMVEW00023 ViewData
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(IGLMVEW00023 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view,null);
            }
        }
        #endregion

        #region Method
        public void MonthlyPosting()
        {
            string workStation=CurrentUserEntity.WorkStationId.ToString();
            int userNo=CurrentUserEntity.CurrentUserID;
            view.ProgressBar =50;
            string Branch = CurrentUserEntity.IsHOUser ? this.view.IsAllBranch ? string.Empty : this.view.BranchCode: CurrentUserEntity.BranchCode;
            CXClientWrapper.Instance.Invoke<IGLMSVE00023>(x => x.Posting(view.StartDate, view.EndDate, workStation, userNo, Branch));
            view.ProgressBar = 80;
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {

                view.ProgressBar = 100;
                this.ViewData.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                this.Clear();
            }
            else
            {
                if (!CXClientWrapper.Instance.ServiceResult.MessageCode.Contains(","))
                    CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                else
                {
                    string[] name = CXClientWrapper.Instance.ServiceResult.MessageCode.Split(",".ToCharArray());
                    
                    CXUIMessageUtilities.ShowMessageByCode(name[0], new object[] { name[1] });
                }
                this.Clear();
            }
        }

        public void Clear()
        {
            this.view.ProgressBar = 0;
            this.view.Progressstatus = false;

        }
       
        #endregion

        #region Monthly Report Setup
        public void Save(object sender, EventArgs args)
        {
            GLMDTO00023 gLMVEW00023 = this.view.ViewData;

            CXClientWrapper.Instance.Invoke<IGLMSVE00023>(x => x.Save(gLMVEW00023));

            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                this.view.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            
            else
                this.view.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
           
        }

        public void Update(object sender, EventArgs args, List<GLMDTO00023> TitleOrderList, List<GLMDTO00023> SubTitleOrderList)
        {
            GLMDTO00023 gLMVEW00023 = this.view.ViewData;

            CXClientWrapper.Instance.Invoke<IGLMSVE00023>(x => x.Update(gLMVEW00023, TitleOrderList, SubTitleOrderList));

            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                this.view.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);

            else
                this.view.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);

        }

        public void Delete(object sender, EventArgs args)
        {
            GLMDTO00023 gLMVEW00023 = this.view.ViewData;

            CXClientWrapper.Instance.Invoke<IGLMSVE00023>(x => x.Delete(gLMVEW00023));

            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                this.view.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);

            else
                this.view.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);

        }        

        public GLMDTO00023 SelectAllByAccountCode(string ACode)
        {
            return CXClientWrapper.Instance.Invoke<IGLMSVE00023, GLMDTO00023>(x => x.SelectAllByAccountCode(ACode));

        }

        public GLMDTO00023 SelectAllMonthlyCOAByAccountCode(string ACode)//Added by HMW (13-12-2022)
        {
            return CXClientWrapper.Instance.Invoke<IGLMSVE00023, GLMDTO00023>(x => x.SelectAllMonthlyCOAByAccountCode(ACode));

        }

        public IList<GLMDTO00023> SelectAllAccountType()
        {
            return CXClientWrapper.Instance.Invoke<IGLMSVE00023, IList<GLMDTO00023>>(x => x.SelectAllAccountType());
        }

        public IList<GLMDTO00023> SelectAllBranchCode()
        {
            return CXClientWrapper.Instance.Invoke<IGLMSVE00023, IList<GLMDTO00023>>(x => x.SelectAllBranchCode());
        }

        public IList<GLMDTO00023> SelectAllTITLE()
        {
            return CXClientWrapper.Instance.Invoke<IGLMSVE00023, IList<GLMDTO00023>>(x => x.SelectAllTITLE());
        }

        public IList<GLMDTO00023> SelectAllTITLE_By_Type(string Type)
        {
            return CXClientWrapper.Instance.Invoke<IGLMSVE00023, IList<GLMDTO00023>>(x => x.SelectAllTITLE_By_Type(Type));
        }

        public IList<GLMDTO00023> SelectAllSUBTITLE_by_TITLE(string TITLE)
        {
            return CXClientWrapper.Instance.Invoke<IGLMSVE00023, IList<GLMDTO00023>>(x => x.SelectAllSUBTITLE_by_TITLE(TITLE));
        }

        public IList<GLMDTO00023> SelectAllOtherBankGroupTitle(string ACode)
        {
            return CXClientWrapper.Instance.Invoke<IGLMSVE00023, IList<GLMDTO00023>>(x => x.SelectAllOtherBankGroupTitle(ACode));
        }
        #endregion
    }
}
