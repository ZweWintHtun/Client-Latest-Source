//----------------------------------------------------------------------
// <copyright file="LOMCTL00032" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>ASDA</CreatedUser>
// <CreatedDate>19.01.2015</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00032 :  AbstractPresenter, ILOMCTL00032
    {
        #region "Wire To"

        string accountNo = string.Empty;
        private ILOMVEW00032 view;
        public ILOMVEW00032 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00032 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetEntity());
            }
        }

        private LOMDTO00013 GetEntity()
        {
            LOMDTO00013 LegalEntity = new LOMDTO00013();
            LegalEntity.AcctNo = this.view.LegalAccountNo;
            return LegalEntity;
        }


        
        #endregion
        public void Print()
        {
            IList<LOMDTO00013> ReportList = CXClientWrapper.Instance.Invoke<ILOMSVE00032, IList<LOMDTO00013>>(x => x.GetLegalListByAccountNo(accountNo, CurrentUserEntity.BranchCode));
            if (ReportList != null)
            {
                if (ReportList.Count > 0)
                    CXUIScreenTransit.Transit("frmLOMVEW00033", true, new object[] { ReportList });
                else
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");  //No Data For Report.
            }
            else
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");  //No Data For Report.
        }
        
        #region validation
        public void mtxtAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (e.HasXmlBaseError == false)
            {
                try
                {
                    Nullable<CXDMD00011> accountType;
                    accountNo = this.view.LegalAccountNo.Replace("-", "");
                    if (CXCLE00012.Instance.IsValidAccountNo(accountNo, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                    {
                        PFMDTO00028 CledgerAccountInfo = CXClientWrapper.Instance.Invoke<ILOMSVE00032, PFMDTO00028>(x => x.CheckAccountNo(accountNo, CurrentUserEntity.BranchCode));
                        if (CledgerAccountInfo != null)
                        {
                            if (CledgerAccountInfo.AccountSign.Substring(0, 1) != "C")
                            {
                                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), "MV00058"); //Invalid Current Account No.
                            }
                            else
                                this.view.SetFocus();
                        }
                        else
                            this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), "MV00046"); //Invalid Account No.                        
                    }
                }
                catch (Exception ex)
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), "MV00046"); //Invalid Account No.
                }
            }
            else
            { return; }
        }
        #endregion
    }
}
