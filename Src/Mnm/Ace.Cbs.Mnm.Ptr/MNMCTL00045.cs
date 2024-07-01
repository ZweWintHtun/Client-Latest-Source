//----------------------------------------------------------------------
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>11/01/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Mnm.Dmd.DTO;

namespace Ace.Cbs.Mnm.Ptr
{

    class MNMCTL00045 : AbstractPresenter, IMNMCTL00045
    {
        IList<PFMDTO00042> PrintData;
        private IMNMVEW00045 view;
        public IMNMVEW00045 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(IMNMVEW00045 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetVlaidateData());
            }
        }

        public void ClearCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }

        public void print()
        {
            string sourceBr = CurrentUserEntity.BranchCode;

            if (this.ValidateForm())
            {
                string workstation = CurrentUserEntity.WorkStationId.ToString();
                CurrencyDTO curdto = CXCOM00011.Instance.GetScalarObject<CurrencyDTO>("Cur.HomeCur.Select", new object[] { true });
                string cur = View.IsHomeCurrency ? curdto.Cur : View.Currency;
                PrintData = CXClientWrapper.Instance.Invoke<IMNMSVE00045, IList<PFMDTO00042>>(x => x.print(View.IsHomeCurrency, View.RequiredDate, CurrentUserEntity.CurrentUserID, View.DateType, sourceBr, cur, workstation, CurrentUserEntity.BranchCode, View.WithReversal));
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
                else
                {
                    if (!string.IsNullOrEmpty(CXClientWrapper.Instance.ServiceResult.MessageCode))
                    {
                        string[] msgArr = CXClientWrapper.Instance.ServiceResult.MessageCode.Split(',');
                        CXUIMessageUtilities.ShowMessageByCode(msgArr[0], new object[] { msgArr[1] });
                    }
                    CXUIScreenTransit.Transit("frmMNMVEW00093TrialSheetReport", true, new object[] { sourceBr, View.IsHomeCurrency ? curdto.Cur : View.Currency, View.WithReversal, "Trial Sheet", PrintData, View.IsCBMACode });
                }
            }
        }

        

        public void cboCurrency_CustomValidate(object sender, ValidationEventArgs e)
        {
            if (!View.IsHomeCurrency)
            {
                if (string.IsNullOrEmpty(View.Currency))
                    this.SetCustomErrorMessage(this.GetControl("cboCurrency"), "MV00020");     //Invalid Currency
                else
                    this.SetCustomErrorMessage(this.GetControl("cboCurrency"), string.Empty);
            }
        }

        private MNMDTO00032 GetVlaidateData()
        {
            MNMDTO00032 ValidateDto = new MNMDTO00032();
            ValidateDto.SOURCECUR = this.view.Currency;
            return ValidateDto;
        }
    }
}
