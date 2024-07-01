using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using System.Linq;

namespace Ace.Cbs.Tel.Ptr
{
    public class TLMCTL00055 : AbstractPresenter, ITLMCTL00055
    {

        #region Properties
        private ITLMVEW00055 view;
        public ITLMVEW00055 View
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }


        string workStation { get; set; }
        private void WireTo(ITLMVEW00055 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetDayBookEntity());
            }
        }

        public TLMDTO00058 GetDayBookEntity()
        {
            TLMDTO00058 daybookEntity = new TLMDTO00058();
            return daybookEntity;

        }
        #endregion

        //Added by HWKO (23-Nov-2017)
        public string GetAcnoNameByACNo(string acno,string sourceBr)
        {
            return CXCLE00001.Instance.GetCOAAccountNameByCoaSetupAccountNo(acno, sourceBr);
        }

        //public IList<TLMDTO00058> GetACNoDespForList(IList<TLMDTO00058> inputList)
        //{
        //    IList<TLMDTO00058> outputList = new List<TLMDTO00058>();

        //    foreach(TLMDTO00058 dto in inputList)
        //    {
        //        dto.ACNoDesp = this.GetAcnoNameByACNo(dto.Account_No, dto.SourceBr);
        //        outputList.Add(dto);
        //    }

        //    return outputList;
        //}
        //Updated by ZMS (19-06-18) // To show SUBTotal
        public IList<TLMDTO00058> GetACNoDespForList(IList<TLMDTO00058> inputList)
        {
            IList<TLMDTO00058> despoutputList = new List<TLMDTO00058>();
            IList<TLMDTO00058> outputList = new List<TLMDTO00058>();
            IList<TLMDTO00058> headCodeList = new List<TLMDTO00058>();
            string account, headAccount, acode1, acode2, acode3;
            decimal DEBIT_CASH, DEBIT_TRANSFER, DEBIT_CLEARING, DEBIT_TOTAL, CREDIT_CASH, CREDIT_TRANSFER, CREDIT_CLEARING,CREDIT_TOTAL;

            // For Description
            //foreach (TLMDTO00058 dto in inputList)
            //{
            //    dto.ACNoDesp = this.GetAcnoNameByACNo(dto.Account_No, dto.SourceBr);
            //    despoutputList.Add(dto);
            //}

            #region old
            //DEBIT_CASH = 0;
            //DEBIT_TRANSFER = 0;
            //DEBIT_CLEARING = 0;
            //DEBIT_TOTAL = 0;
            //CREDIT_CASH = 0;
            //CREDIT_TRANSFER = 0;
            //CREDIT_CLEARING = 0;
            //CREDIT_TOTAL = 0;
            //acode1 = "";
            //acode2 = "";


            //for (int i = 0; i < inputList.Count; i++)
            //{
            //    //for (int j = 0; j < inputList.Count; j++)
            //    //{
            //    acode1 = inputList[i].Account_No.Substring(0, 3) + "000";
            //    if (i != inputList.Count - 1)
            //    {
            //        acode2 = inputList[i + 1].Account_No.Substring(0, 3) + "000";
            //    }
            //    TLMDTO00058 temp = new TLMDTO00058();

            //    inputList[i].ACNoDesp = this.GetAcnoNameByACNo(inputList[i].Account_No, inputList[i].SourceBr);
            //    outputList.Add(inputList[i]);

            //    DEBIT_CASH = DEBIT_CASH + Convert.ToDecimal(inputList[i].Debit_Cash);
            //    DEBIT_TRANSFER = DEBIT_TRANSFER + Convert.ToDecimal(inputList[i].Debit_Transfer);
            //    DEBIT_CLEARING = DEBIT_CLEARING + Convert.ToDecimal(inputList[i].Debit_Clearing);
            //    DEBIT_TOTAL = DEBIT_TOTAL + Convert.ToDecimal(inputList[i].Debit_Total);
            //    CREDIT_CASH = CREDIT_CASH + Convert.ToDecimal(inputList[i].Credit_Cash);
            //    CREDIT_TRANSFER = CREDIT_TRANSFER + Convert.ToDecimal(inputList[i].Credit_Transfer);
            //    CREDIT_CLEARING = CREDIT_CLEARING + Convert.ToDecimal(inputList[i].Credit_Clearing);
            //    CREDIT_TOTAL = CREDIT_TOTAL + Convert.ToDecimal(inputList[i].Credit_Total);
                
            //    if (i + 1 == inputList.Count)  /// for data lastest line subtotal
            //    {
            //        //inputList[i].ACNoDesp = this.GetAcnoNameByACNo(inputList[i].Account_No, inputList[i].SourceBr);
            //        //outputList.Add(inputList[i]);

            //        //DEBIT_CASH = DEBIT_CASH + Convert.ToDecimal(inputList[i].Debit_Cash);
            //        //DEBIT_TRANSFER = DEBIT_TRANSFER + Convert.ToDecimal(inputList[i].Debit_Transfer);
            //        //DEBIT_CLEARING = DEBIT_CLEARING + Convert.ToDecimal(inputList[i].Debit_Clearing);
            //        //DEBIT_TOTAL = DEBIT_TOTAL + Convert.ToDecimal(inputList[i].Debit_Total);
            //        //CREDIT_CASH = CREDIT_CASH + Convert.ToDecimal(inputList[i].Credit_Cash);
            //        //CREDIT_TRANSFER = CREDIT_TRANSFER + Convert.ToDecimal(inputList[i].Credit_Transfer);
            //        //CREDIT_CLEARING = CREDIT_CLEARING + Convert.ToDecimal(inputList[i].Credit_Clearing);
            //        //CREDIT_TOTAL = CREDIT_TOTAL + Convert.ToDecimal(inputList[i].Credit_Total);

            //        temp.ACNoDesp = this.GetAcnoNameByACNo(acode1, inputList[i].SourceBr)+"(SUB TOTAL)";
            //        temp.Account_No = acode1;
            //        temp.Debit_Cash = DEBIT_CASH;
            //        temp.Debit_Transfer = DEBIT_TRANSFER;
            //        temp.Debit_Clearing = DEBIT_CLEARING;
            //        temp.Debit_Total = DEBIT_TOTAL;
            //        temp.Credit_Cash = CREDIT_CASH;
            //        temp.Credit_Transfer = CREDIT_TRANSFER;
            //        temp.Credit_Clearing = CREDIT_CLEARING;
            //        temp.Credit_Total = CREDIT_TOTAL;
            //        outputList.Add(temp);

            //        DEBIT_CASH = 0;
            //        DEBIT_TRANSFER = 0;
            //        DEBIT_CLEARING = 0;
            //        DEBIT_TOTAL = 0;
            //        CREDIT_CASH = 0;
            //        CREDIT_TRANSFER = 0;
            //        CREDIT_CLEARING = 0;
            //        CREDIT_TOTAL = 0;
            //    }
            //    else if (acode1 != acode2)
            //    {
            //        temp.ACNoDesp = this.GetAcnoNameByACNo(acode1, inputList[i].SourceBr) + "(SUB TOTAL)";
            //        temp.Account_No = acode1;
            //        temp.Debit_Cash = DEBIT_CASH;
            //        temp.Debit_Transfer = DEBIT_TRANSFER;
            //        temp.Debit_Clearing = DEBIT_CLEARING;
            //        temp.Debit_Total = DEBIT_TOTAL;
            //        temp.Credit_Cash = CREDIT_CASH;
            //        temp.Credit_Transfer = CREDIT_TRANSFER;
            //        temp.Credit_Clearing = CREDIT_CLEARING;
            //        temp.Credit_Total = CREDIT_TOTAL;
            //        outputList.Add(temp);

            //        DEBIT_CASH = 0;
            //        DEBIT_TRANSFER = 0;
            //        DEBIT_CLEARING = 0;
            //        DEBIT_TOTAL = 0;
            //        CREDIT_CASH = 0;
            //        CREDIT_TRANSFER = 0;
            //        CREDIT_CLEARING = 0;
            //        CREDIT_TOTAL = 0;
            //    }
            //}
            #endregion

            ///For Description
            ///
            acode1 = "";
            acode2 = "";
            int sortcount = 1;
            for (int i = 0; i < inputList.Count; i++)
            {
                acode1 = inputList[i].Account_No.Substring(0, 3) + "000";
                if (i != inputList.Count - 1)
                {
                    acode2 = inputList[i + 1].Account_No.Substring(0, 3) + "000";
                }

                inputList[i].ACNoDesp = this.GetAcnoNameByACNo(inputList[i].Account_No, inputList[i].SourceBr);
                inputList[i].HeadACNo = acode1;
                inputList[i].HeadACNoDesp = this.GetAcnoNameByACNo(acode1, inputList[i].SourceBr);
                //inputList[i].recordcount = 
                outputList.Add(inputList[i]);
                //if (i + 1 == inputList.Count)
                //{
                //    sortcount = sortcount + 1;
                //}
                if (acode1 != acode2)
                {
                    sortcount = sortcount + 1;
                }
                inputList[i].recordcount = sortcount;
            }

            return outputList;
        }

        public IList<TLMDTO00058> SelectDomesticDayBook()
        {
            workStation = Convert.ToString(CurrentUserEntity.WorkStationId);
            //IList<TLMDTO00058> dayBooks = CXClientWrapper.Instance.Invoke<ITLMSVE00055, IList<TLMDTO00058>>(x => x.SelectDomesticDayBook(this.view.RequireDate, CurrentUserEntity.CurrentUserID,this.view.CurrencyCode, CurrentUserEntity.BranchCode, workStation,this.view.IsSettlementDate));
            IList<TLMDTO00058> dayBooks = CXClientWrapper.Instance.Invoke<ITLMSVE00055, IList<TLMDTO00058>>(x => x.SelectDomesticDayBook(this.view.RequireDate, CurrentUserEntity.CurrentUserID, this.view.CurrencyCode, this.view.BranchCode, workStation, this.view.IsSettlementDate, this.view.SortByTime));
            
            dayBooks = this.GetACNoDespForList(dayBooks);

            return dayBooks;
        }

        public IList<TLMDTO00058> SelectDomesticReversalDayBook()
        {
            workStation = Convert.ToString(CurrentUserEntity.WorkStationId);
            //IList<TLMDTO00058> dayBooks = CXClientWrapper.Instance.Invoke<ITLMSVE00055, IList<TLMDTO00058>>(x => x.SelectDomesticReversalDayBook(this.view.RequireDate, CurrentUserEntity.CurrentUserID, this.view.CurrencyCode, CurrentUserEntity.BranchCode, workStation, this.view.IsSettlementDate));
            IList<TLMDTO00058> dayBooks = CXClientWrapper.Instance.Invoke<ITLMSVE00055, IList<TLMDTO00058>>(x => x.SelectDomesticReversalDayBook(this.view.RequireDate, CurrentUserEntity.CurrentUserID, this.view.CurrencyCode, this.view.BranchCode, workStation, this.view.IsSettlementDate, this.view.SortByTime));

            dayBooks = this.GetACNoDespForList(dayBooks);

            return dayBooks;
        }

        public IList<TLMDTO00058> SelectDomesticHomeDayBook()
        {
            workStation = Convert.ToString(CurrentUserEntity.WorkStationId);
            //IList<TLMDTO00058> dayBooks = CXClientWrapper.Instance.Invoke<ITLMSVE00055, IList<TLMDTO00058>>(x => x.SelectDomesticHomeDayBook(this.view.RequireDate, CurrentUserEntity.CurrentUserID, this.view.CurrencyCode, CurrentUserEntity.BranchCode, workStation, this.view.IsSettlementDate));
            IList<TLMDTO00058> dayBooks = CXClientWrapper.Instance.Invoke<ITLMSVE00055, IList<TLMDTO00058>>(x => x.SelectDomesticHomeDayBook(this.view.RequireDate, CurrentUserEntity.CurrentUserID, this.view.CurrencyCode, this.view.BranchCode, workStation, this.view.IsSettlementDate, this.view.SortByTime));

            dayBooks = this.GetACNoDespForList(dayBooks);

            return dayBooks;
        }

        public IList<TLMDTO00058> SelectDomesticHomeReversalDayBook()
        {
            workStation = Convert.ToString(CurrentUserEntity.WorkStationId);
            //IList<TLMDTO00058> dayBooks = CXClientWrapper.Instance.Invoke<ITLMSVE00055, IList<TLMDTO00058>>(x => x.SelectDomesticHomeReversalDayBook(this.view.RequireDate, CurrentUserEntity.CurrentUserID, this.view.CurrencyCode, CurrentUserEntity.BranchCode, workStation, this.view.IsSettlementDate));
            IList<TLMDTO00058> dayBooks = CXClientWrapper.Instance.Invoke<ITLMSVE00055, IList<TLMDTO00058>>(x => x.SelectDomesticHomeReversalDayBook(this.view.RequireDate, CurrentUserEntity.CurrentUserID, this.view.CurrencyCode, this.view.BranchCode, workStation, this.view.IsSettlementDate, this.view.SortByTime));

            dayBooks = this.GetACNoDespForList(dayBooks);

            return dayBooks;
        }



    }
}
