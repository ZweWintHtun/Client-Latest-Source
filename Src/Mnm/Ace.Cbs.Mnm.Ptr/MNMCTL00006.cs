using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Pfm.Dmd.DTO;// Added by AAM (20_Sep_2018)
using Ace.Cbs.Pfm.Ctr;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Windows.Ix.Core.DataModel;//Added by HMW (29-Sep-2019)
using Ace.Windows.Ix.Client.Utt;//Added by HMW (29-Sep-2019)


namespace Ace.Cbs.Mnm.Ptr
{
    public class MNMCTL00006 : AbstractPresenter, IMNMCTL00006
    {
        #region Properties
        public MNMCTL00006() { }
        private IMNMVEW00006 view;
        public IMNMVEW00006 YearpostViewData
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(IMNMVEW00006 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetSyspostEntity());
            }
        }


        #endregion

        #region method
        public IList<PFMDTO00079> Get_BLFInfo_ByActiveBudget(string sourceBr)
        {
            sourceBr = CurrentUserEntity.BranchCode;
            return CXClientWrapper.Instance.Invoke<IMNMSVE00006, IList<PFMDTO00079>>(x => x.Get_BLFInfo_ByActiveBudget(sourceBr));
        }

        public void Posting()
        {
          
                view.Progressstatus = true;
                view.ProgressBar = 30;
                view.LabelStatus = "Posting balance to year file...";

                // Commented by AAM (20_Sep_2018)
                //IList<CurrencyChargeOfAccountDTO> accountlist = SelectAllyearly(); 
                view.ProgressBar = 50;

                string sourceBr = CurrentUserEntity.BranchCode;
                int currentUserId = CurrentUserEntity.CurrentUserID;
                // Commented by AAM (20_Sep_2018) 
                //CXClientWrapper.Instance.Invoke<IMNMSVE00006>(x => x.YearlyPosting(accountlist, view.Date_time.Value,sourceBr,currentUserId));
                
                //Added by HMW (30-Sept-2019)                
                TCMDTO00001 startDTO = CXClientWrapper.Instance.Invoke<ITCMSVE00014, TCMDTO00001>(x => x.SelectStartBySourceBr(sourceBr));
                PFMDTO00056 PreviousSys001Dto = new PFMDTO00056();
                PreviousSys001Dto = CXCOM00011.Instance.GetScalarObject<PFMDTO00056>("Sys001.SelectYearlyPostData", new object[] { "YRPOSTDATE", sourceBr, true });               

                PFMDTO00056 NewSys001Dto = new PFMDTO00056();
                NewSys001Dto.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                NewSys001Dto.SysMonYear = startDTO.Date.ToString("MM/yyyy") ;
                NewSys001Dto.Status = "Y";
                //NewSys001Dto.SysDate = DateTime.Parse(startDTO.Date.ToString("dd/MM/yyyy"));
                NewSys001Dto.SysDate = startDTO.Date;
                IList<DataVersionChangedValueDTO> dvcvList = GetChangedValueOfObject.GetChangedValueList(PreviousSys001Dto, NewSys001Dto);


                // Added by AAM (20_Sep_2018)                
                CXClientWrapper.Instance.Invoke<IMNMSVE00006>(x => x.YearlyPosting(view.Date_time.Value, sourceBr, currentUserId, dvcvList));

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                {
                    view.ProgressBar = 100;
                    this.YearpostViewData.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.Clear();
                }
                else
                {
                    this.YearpostViewData.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.Clear();

                }
           
        }
        public IList<CurrencyChargeOfAccountDTO> SelectAllyearly()
        {
            return CXClientWrapper.Instance.Invoke<IMNMSVE00006, IList<CurrencyChargeOfAccountDTO>>(service => service.SelectAllyearly(CurrentUserEntity.BranchCode));

        }

        private MNMDTO00001 GetSyspostEntity()
        {
            //Added by HMW at (30-Sept-2019)
            TCMDTO00001 startDTO = CXClientWrapper.Instance.Invoke<ITCMSVE00014, TCMDTO00001>(x => x.SelectStartBySourceBr(CurrentUserEntity.BranchCode));

            MNMDTO00001 syspostentity = new MNMDTO00001();
            //syspostentity.Date_time = view.Date_time;
            syspostentity.Date_time = startDTO.Date;

            return syspostentity;
        }

        public void Clear()
        {
            this.view.LabelStatus = string.Empty;
            this.view.ProgressBar = 0;
            this.view.Progressstatus = false;

        }
        #endregion

    }
}
