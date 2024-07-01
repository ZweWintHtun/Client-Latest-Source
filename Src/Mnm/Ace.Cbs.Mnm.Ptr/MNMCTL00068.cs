using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Windows.Core.Presenter;
using Ace.Windows.CXClient;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Mnm.Ptr
{
    public class MNMCTL00068: AbstractPresenter, IMNMCTL00068
    {
        #region Properties
        private IMNMVEW00068 view;
        public IMNMVEW00068 View
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(IMNMVEW00068 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetEntity());
            }
        }

        #endregion

        #region Helper Method
        public MNMDTO00037 GetEntity()
        {
            MNMDTO00037 entity = new MNMDTO00037();
            entity.StartDate = this.view.StartDate;
            entity.EndDate = this.view.EndDate;
            entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
            entity.SourceBr = CurrentUserEntity.BranchCode;

            return entity;
        }

        public void Print()
        {
            if (!CXCOM00006.Instance.IsExceedTodayDate(this.view.StartDate))
            {
                if (!CXCOM00006.Instance.IsExceedTodayDate(this.view.EndDate))
                {
                    if (this.view.StartDate > this.view.EndDate)
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MV00131");//Start Date must not be greater than End Date.
                    }
                    else
                    {
                        MNMDTO00037 DTO = this.GetEntity();
                        bool IsCurrent = false;//To send Report Form Name
                        if (this.view.ParentFormName == "CurrentAccountClosing")
                        {
                            IsCurrent = true;
                        }

                        IList<MNMDTO00037> cacDtoList = CXClientWrapper.Instance.Invoke<IMNMSVE00068, IList<MNMDTO00037>>(x => x.GetReportData(DTO, IsCurrent));
                        if (cacDtoList.Count > 0)
                        {                            
                            string startDate = this.view.StartDate.ToShortDateString();
                            string endDate = this.view.EndDate.ToShortDateString();
                            string header = string.Empty;

                            if (IsCurrent==true)
                            {
                                header = "Closed Account Listing (Current)";
                                CXUIScreenTransit.Transit("frmMNMVEW000117.ReportViewer", true, new object[] { cacDtoList, startDate, endDate, header });
                            }
                            else
                            {
                                header = "Closed Account Listing (Saving)";
                                CXUIScreenTransit.Transit("frmMNMVEW000117.ReportViewer", true, new object[] { cacDtoList, startDate, endDate, header });
                            }
                        }
                        else
                        {
                            CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
                        }
                    }
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode("MV00130");//End Date must not be greater than today.
                }
            }
            else
            {
                CXUIMessageUtilities.ShowMessageByCode("MV00129");//Start Date must not be greater than today.
            }
        }
        #endregion
    }
}
