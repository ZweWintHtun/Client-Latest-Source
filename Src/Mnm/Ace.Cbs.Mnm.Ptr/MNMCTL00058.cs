//----------------------------------------------------------------------
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>HM</CreatedUser>
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
//using Ace.Cbs.Mnm.Dmd.DTO;

namespace Ace.Cbs.Mnm.Ptr
{

    class MNMCTL00058 : AbstractPresenter, IMNMCTL00058
    {
          #region "Constructor"

        public MNMCTL00058()
        {
            this.BranchCode = CXCOM00007.Instance.BranchCode;
        }

        #endregion 

        #region Properties

        private string BranchCode { get; set; }
        IList<PFMDTO00021> fixACList { get; set; }
        private IMNMVEW00058 view;
        public IMNMVEW00058 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        #endregion

        #region Helper Methods

        private void WireTo(IMNMVEW00058 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetVlaidateData());
            }
        }

        private PFMDTO00021 GetVlaidateData()
        {
            PFMDTO00021 ValidateDto = new PFMDTO00021();
            ValidateDto.CurrencyCode = this.view.currencyNo;
            return ValidateDto;
        }

        public void ClearCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }

        public bool Validate_Form()
        {
            return this.ValidateForm(this.GetVlaidateData());
        }

        public void Print(DateTime sdate,DateTime edate,string cur, string status)
        {
            fixACList = CXClientWrapper.Instance.Invoke<IMNMSVE00058, IList<PFMDTO00021>>(x => x.SelectFixedDepoistAll(sdate, edate, cur, this.view.FormName, this.BranchCode, status));
            
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            else
            {
                //edited by ADSA
                if (fixACList.Count > 0)   
                {
                    int j = 0;
                    IList<PFMDTO00021> PrintDataList = new List<PFMDTO00021>();
                    PrintDataList.Add(fixACList[0]);
                    if (fixACList.Count > 1)  
                    {
                        do
                        {
                            string accountNo = fixACList[j].FledgerAccountNo;
                            j++;
                            if (accountNo != fixACList[j].FledgerAccountNo)
                                PrintDataList.Add(fixACList[j]);


                        } while (j != fixACList.Count - 1);
                    }
                    CXUIScreenTransit.Transit("frmMNMVEW00107FixedDepoAll_ReceiptReport", true, new object[] { PrintDataList, this.view.FormName,sdate,edate});
                }
            }

        }

        #endregion
    }
}