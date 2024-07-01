//----------------------------------------------------------------------
// <copyright file="TLMVEW00001" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate>18.6.2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Windows.Core.Utt;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tel.Ptr
{
    public class TLMCTL00072 : AbstractPresenter, ITLMCTL00072
    {
        #region Initialize View
        private ITLMVEW00072 view;
        public ITLMVEW00072 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ITLMVEW00072 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetPrintRemainTransactionEntity());
            }
        }

        public PFMDTO00043 GetPrintRemainTransactionEntity()
        {
            PFMDTO00043 prnFileEntiy = new PFMDTO00043();
            prnFileEntiy.AccountNo = this.view.AccountNo;
            return prnFileEntiy;

        }
    public IList<PFMDTO00043> printTransactionList { get; set; }
    public bool isCledgerStatus { get; set; }

        #endregion

    #region Variables
    bool IsCledgerStatus { get; set; }
    #endregion

    #region Validation Logic
    public void mtxtAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
            {
                return;
            }
            Nullable<CXDMD00011> accountType;
            try 
            {
                if (CXCLE00012.Instance.IsValidAccountNo(this.view.AccountNo, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2)==true)

                {
                   
                   IList<PFMDTO00043> printtransaction  = CXClientWrapper.Instance.Invoke<ITLMSVE00072, IList<PFMDTO00043>>(x => x.GetPrintTransactionByAccountNo(this.view.AccountNo));

                   if (printtransaction[0].IsCledgerAccountStatus)
                   {
                       this.isCledgerStatus = true;
                   }
                   else
                   {
                       this.isCledgerStatus = false;
 
                   }

                  var print = printtransaction.OrderByDescending(a => a.DATE_TIME);
                  this.printTransactionList = print.ToList();

                    if (printTransactionList == null || printTransactionList.Count <= 0)
                    {
                        if (!string.IsNullOrEmpty(CXClientWrapper.Instance.ServiceResult.MessageCode))
                        {
                            this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                        }
                        else
                        {
                            this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"),CXMessage.MI00047); 
                        }
                    }
                        
                    else
                    {
                        this.view.BindTransactionGridView(printTransactionList);
                    }
                }
            }

            catch (Exception ex)
            {
                if (!string.IsNullOrEmpty(CXClientWrapper.Instance.ServiceResult.MessageCode))
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode,new object[] {this.view.AccountNo});
                }
                else
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MI00047);
                }


              //  this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), ex.Message);

            }
        }
        #endregion

     #region UI Logic



    public void PrintRemainTransaction()
        {
            try
            {
            //    List<string[]> printingList = new List<string[]>();
            //    foreach (PFMDTO00043 item in this.printTransactionList)
            //    {
            //        string date = CXCOM00006.Instance.GetDateFormat(item.DATE_TIME.Value).ToString();
            //        string[] prnFileStrArr = {date, item.Reference, item.Credit.ToString(), item.Debit.ToString(), item.Balance.ToString(),this.view.AccountNo};

            //        printingList.Add(prnFileStrArr);

            //    }
               int printedLine = 0;

               printedLine = CXClientWrapper.Instance.Invoke<ITLMSVE00072, int>(x => x.GetPrintLineNumberByAccountNo(this.view.AccountNo));

                PFMDTO00043 PrnFileDTO = new PFMDTO00043();
                PrnFileDTO.AccountNo = this.view.AccountNo;
                PrnFileDTO.UserNo = CurrentUserEntity.CurrentUserID.ToString();
                PrnFileDTO.DATE_TIME = DateTime.Now;
                CXUIScreenTransit.Transit("frmPFMVEW00009", true, new object[] { true, printedLine +1 , PrnFileDTO ,false});
              this.view.ClearControls();
               // CXCLE00005.Instance.PrintingList("PassBookCode", "LineByLine", "PassBookPrinting", printingList, false, true);
            
               // return true;
            }
            catch (Exception ex)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00010);
                return;
 
            }           

        }

        //public void PrintRemainTransaction()
        //{
        //    if (this.PrintTransaction())
        //    {
        //        int lineNo = this.printTransactionList.Count;
        //        CXClientWrapper.Instance.Invoke<ITLMSVE00072, bool>(x => x.UpdateAndDeleteByAccountNo(this.view.AccountNo, this.printTransactionList, this.isCledgerStatus, lineNo, CurrentUserEntity.CurrentUserID));
        //        this.view.ClearControls();
        //    }
        //    else
        //    {
        //        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME00012); 
        //    }
        //}

        public void clear()
        {
            this.ClearErrors();
            this.ClearAllCustomErrorMessage();
            this.view.AccountNo = string.Empty;
        }
        #endregion


    }
}
