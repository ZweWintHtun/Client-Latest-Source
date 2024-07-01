using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Windows.CXClient;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Mnm.Ptr
{
    public class MNMCTL00066 : AbstractPresenter , IMNMCTL00066
    {
        #region Properties
        IList<PFMDTO00042> PrintDataList { get; set; }
        IList<PFMDTO00032> CheckList { get; set; }

        private IMNMVEW00066 _view;
        public IMNMVEW00066 View
        {
            get{return _view;}
            set{this.WireTo(value);}
        }

        #endregion

        #region Helper Method

        private void WireTo(IMNMVEW00066 view)
        {
            if (this._view == null)
            {
                this._view = view;
                this.Initialize(this._view, this.GetValidateData());
            }
        }
        public PFMDTO00042 GetValidateData()
        {
            PFMDTO00042 ValidateDTO = new PFMDTO00042();
            ValidateDTO.StartDate = this.View.RequiredDate;
            ValidateDTO.CurrencyType = this.View.Currency;
            return ValidateDTO;
        }

        public bool Validate_Form()
        {
            return this.ValidateForm(this.GetValidateData());
        }

        #endregion

        #region Main Method
        public void Print()
        {
            int DaysInYear = 0;
            int i = 0;
            decimal Interest = 0;
            IList<PFMDTO00042> ReturnDataList = new List<PFMDTO00042>();            

            PFMDTO00042 DataDTO = this.GetValidateData();

            if (this.View.FormName == "Renewal Voucher Listing")
            {
                PrintDataList = CXClientWrapper.Instance.Invoke<IMNMSVE00066, IList<PFMDTO00042>>(x => x.GetReportData(DataDTO, CurrentUserEntity.BranchCode, CurrentUserEntity.WorkStationId, CurrentUserEntity.CurrentUserID));
                if (PrintDataList != null && PrintDataList.Count > 0)
                {
                    CXUIScreenTransit.Transit("frmMNMVEW00115", PrintDataList, this.View.FormName, this.View.RequiredDate);
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode("MI00039");  //No Data For Report
                }
            }

            else if (this.View.FormName == "Coming Accrued Listing")
            {
                DaysInYear = DateTime.Now.DayOfYear;                

                //ComingRset
                IList<PFMDTO00032> CheckList = CXClientWrapper.Instance.Invoke<IMNMSVE00066, IList<PFMDTO00032>>(x => x.GetCheckListForComingAccrue(this.View.Currency, CurrentUserEntity.BranchCode));
                if (CheckList != null && CheckList.Count > 0)
                {
                    foreach (PFMDTO00032 CheckDTO in CheckList)
                    { 
                        //MatureRset
                        PFMDTO00042 CheckMatureDate = CXClientWrapper.Instance.Invoke<IMNMSVE00066, PFMDTO00042>(x => x.GetMatureDate(CheckDTO, CurrentUserEntity.CurrentUserID));
                        if (CheckMatureDate != null)
                        {
                            if (DateTime.Now.Date <= CheckMatureDate.MatureDate && this.View.RequiredDate.Date >= CheckMatureDate.MatureDate)
                            {
                                if (CheckDTO.ToAccountNo == null || CheckDTO.ToAccountNo == "" || CheckDTO.ToAccountNo == string.Empty)
                                {
                                    if (CheckDTO.Duration >= 1)
                                    {
                                        //Interest = Format(comingRset.rdoColumns("Amount") * comingRset.rdoColumns("IntRate") / 100 / 12 * comingRset.rdoColumns("Duration"), "###########0.00")
                                        Interest = CheckDTO.Amount * CheckDTO.InterestRate / 100 / 12 * CheckDTO.Duration;
                                    }
                                    else
                                    {
                                        //Interest = Format(comingRset.rdoColumns("Amount") * comingRset.rdoColumns("IntRate") / 100 / DaysInYear * (comingRset.rdoColumns("Duration") * 4 * 7), "###########0.00")
                                        Interest = CheckDTO.Amount * CheckDTO.InterestRate / 100 / DaysInYear * (CheckDTO.Duration * 4 * 7);
                                    }
                                    PFMDTO00042 DTO = new PFMDTO00042();
                                    DTO.AcctNo = CheckDTO.AccountNo;
                                    DTO.Name = CheckDTO.Name;
                                    DTO.ReceiptNo = CheckDTO.ReceiptNo;
                                    DTO.Amount = CheckDTO.Amount;
                                    DTO.Rate = Interest;
                                    DTO.TotalCash = CheckDTO.Amount + Interest;
                                    DTO.MatureDate = CheckMatureDate.MatureDate;
                                    ReturnDataList.Add(DTO);
                                    i++;
                                }
                            }
                        }
                    }
                    if(i != 0)                    
                        CXUIScreenTransit.Transit("frmMNMVEW00140", ReturnDataList, this.View.FormName, this.View.RequiredDate);                   
                    else
                        CXUIMessageUtilities.ShowMessageByCode("MI00039");  //No Data For Print
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode("MI00039");  //No Data For Print
                }
            }

            else 
            {
                bool IntTake = true;
                DaysInYear = DateTime.Now.DayOfYear;

                //ComingRset
                IList<PFMDTO00032> CheckList = CXClientWrapper.Instance.Invoke<IMNMSVE00066, IList<PFMDTO00032>>(x => x.GetCheckListForComingInterest(this.View.Currency, CurrentUserEntity.BranchCode));
                if (CheckList != null && CheckList.Count > 0)
                {
                    foreach (PFMDTO00032 CheckDTO in CheckList)
                    {
                        //MatureRset
                        PFMDTO00042 CheckMatureDate = CXClientWrapper.Instance.Invoke<IMNMSVE00066, PFMDTO00042>(x => x.GetMatureDate(CheckDTO, CurrentUserEntity.CurrentUserID));
                        if (CheckMatureDate != null)
                        {
                            if (DateTime.Now.Date <= CheckMatureDate.MatureDate && this.View.RequiredDate.Date >= CheckMatureDate.MatureDate)
                            {
                                if (CheckDTO.AccuredStatus == "12")
                                {
                                    if (CheckDTO.ToAccountNo != "")
                                        IntTake = true;
                                    else
                                        IntTake = false;
                                }
                                else if(CheckDTO.AccuredStatus == "11"  || CheckDTO.AccuredStatus.Substring(0,1) == "0")
                                {
                                    IntTake = true;
                                }

                                if (IntTake)
                                {
                                    if (CheckDTO.Duration >= 1)
                                    {
                                        Interest = CheckDTO.Amount * CheckDTO.InterestRate / 100 / 12 * CheckDTO.Duration;
                                    }
                                    else
                                    {
                                        Interest = CheckDTO.Amount * CheckDTO.InterestRate / 100 / DaysInYear * (CheckDTO.Duration * 4 * 7);
                                    }
                                    PFMDTO00042 DTO = new PFMDTO00042();
                                    DTO.AcctNo = CheckDTO.AccountNo;
                                    DTO.Name = CheckDTO.Name;
                                    DTO.ReceiptNo = CheckDTO.ReceiptNo;
                                    DTO.Amount = CheckDTO.Amount;
                                    DTO.Rate = Interest;
                                    DTO.ToAccountNo = CheckDTO.ToAccountNo;
                                    DTO.MatureDate = CheckMatureDate.MatureDate;
                                    ReturnDataList.Add(DTO);
                                    i++;
                                }
                            }
                        }
                    }
                    if (i != 0)
                        CXUIScreenTransit.Transit("frmMNMVEW00141", ReturnDataList, this.View.FormName, this.View.RequiredDate);
                    else
                        CXUIMessageUtilities.ShowMessageByCode("MI00039");  //No Data For Report
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode("MI00039");  
                }
            }
        }    
        #endregion
    }
}
