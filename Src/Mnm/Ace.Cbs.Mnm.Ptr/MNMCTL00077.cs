using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Windows.Core.Utt;


namespace Ace.Cbs.Mnm.Ptr
{
    public class MNMCTL00077 : AbstractPresenter, IMNMCTL00077
    {
        #region Properties

        private IMNMVEW00077 view;
        public IMNMVEW00077 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        IList<TLMDTO00017> DrawingPrintDataLists { get; set; }
        IList<TLMDTO00001> EncashmentPrintDataLists { get; set; }
        #endregion

        #region Helper Method
        private void WireTo(IMNMVEW00077 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetValidateData());
            }
        }        
        public TLMDTO00001 GetValidateData()
        {
            TLMDTO00001 ViewData = new TLMDTO00001();            
            ViewData.RequiredDate  = this.View.RequiredDate;
            ViewData.Ebank = this.View.BranchCode;
            if (this.view.IsTransactionDate == true)
            {
                ViewData.Status = "0";
            }
            else
            {
                ViewData.Status = "1";                
            }
            return ViewData;
        }
        #endregion

        #region Main Method
        public void Print()
        {
            if (this.Validate_Form())
            {
                TLMDTO00001 DataDTO = GetValidateData();
                DataDTO.SourceBranchCode = CurrentUserEntity.BranchCode;

                if (this.view.FormName == "Daily Drawing Remittance Listing")
                {
                    DrawingPrintDataLists = CXClientWrapper.Instance.Invoke<IMNMSVE00077, IList<TLMDTO00017>>(x => x.GetDrawingRemittanceListing(DataDTO));
                    if (DrawingPrintDataLists.Count > 0)
                    {
                        CXUIScreenTransit.Transit("frmMNMVEW00126", true, new object[] { DrawingPrintDataLists, this.view.FormName, this.view.RequiredDate, this.view.IsTransactionDate });
                    }
                    else
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MI00039"); //No Data for Report
                    }
                }
                else if (this.view.FormName == "Daily Encashment Remittance Listing")
                {
                    EncashmentPrintDataLists = CXClientWrapper.Instance.Invoke<IMNMSVE00077, IList<TLMDTO00001>>(x => x.GetEncashRemittanceListing(DataDTO));
                    if (EncashmentPrintDataLists.Count > 0)
                    {
                        CXUIScreenTransit.Transit("frmMNMVEW00137", true, new object[] { EncashmentPrintDataLists, this.view.FormName, this.view.RequiredDate, this.view.IsTransactionDate });
                    }
                    else
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MI00039"); //No Data for Report
                    }
                }                 
            }
            else
            {
                return;
            }
        }        
        public bool Validate_Form()
        {
            return this.ValidateForm(this.GetValidateData());
        }
        #endregion
    }
}
