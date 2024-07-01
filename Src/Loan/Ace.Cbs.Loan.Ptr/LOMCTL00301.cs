using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00301 : AbstractPresenter, ILOMCTL00301
    {
        #region "WireTo"
        private ILOMVEW00301 view;
        public ILOMVEW00301 View
        {
            get
            {
                return this.view;
            }
            set
            {
                this.WireTo(value);
            }
        }
        private void WireTo(ILOMVEW00301 _view)
        {
            if (this.view == null)
            {
                this.view = _view;
                this.Initialize(this.view, this.GetViewData());
            }
        }
        public void ClearCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }
        #endregion

        #region "Private Methods"
        private LOMDTO00085 GetViewData()
        {
            try
            {
                LOMDTO00085 liDTO = new LOMDTO00085();
                liDTO.LNo = this.View.LoansNo;
                liDTO.AcctNo = this.View.AccountNo;
                liDTO.PrincipalAmount = this.View.SanctionAmount;
                liDTO.IntRate = this.View.Rate;
                liDTO.InterestAmount = this.View.InterestAmount;
                liDTO.SourceBr = CurrentUserEntity.BranchCode;
                liDTO.UpdatedDate = DateTime.Now;
                liDTO.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                return liDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException + ex.Message);
            }
        }
        #endregion

        #region "Validation Method"
        public void txtLoanNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            //bool isValidLNo=false;
            LOMDTO00078 LoanDTO = new LOMDTO00078();
            if (e.HasXmlBaseError == true)
            {
                return;
            }
            else
            {
                LoanDTO = CXClientWrapper.Instance.Invoke<ILOMSVE00078, LOMDTO00078>(x => x.isValidLoanNo(this.view.LoansNo, CurrentUserEntity.BranchCode));

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {                   
                    this.SetCustomErrorMessage(this.GetControl("txtLoanNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                    return;
                }
                else
                {
                    this.View.EnableTextBox();
                    this.View.AccountNo = LoanDTO.AcctNo;
                    this.View.SanctionAmount = LoanDTO.SAmt == null ? 0 : LoanDTO.SAmt.Value;
                    this.View.Rate = LoanDTO.IntRate == null ? 0 : LoanDTO.IntRate.Value;
                    this.View.InterestAmount = LoanDTO.FirstSAmt == null ? 0 : LoanDTO.FirstSAmt.Value;
                    this.View.DisableTextBox();
                    this.View.TextFcus();
                }
            }
        }

        public void Focus()
        {
            this.View.TextFcus();
        }

        #endregion

        #region "Public Methods"
        public void Update()
         {
            try
            {
                LOMDTO00085 farmLiDto = this.GetViewData();
                if (this.ValidateForm(farmLiDto))
                {
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        this.view.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                    else if (farmLiDto.AcctNo == null || farmLiDto.AcctNo == string.Empty)
                    {
                        // CXUIMessageUtilities.ShowMessageByCode("MV90101");
                        this.SetFocus("txtLoanNo");
                        // return;
                    }
                    else if (CXUIMessageUtilities.ShowMessageByCode("MC90005") == DialogResult.Yes)
                    {
                        IList<LOMDTO00085> dtoToUpdateList = CXClientWrapper.Instance.Invoke<ILOMSVE00085, IList<LOMDTO00085>>(x => x.SelectFarmLiInfoByLnoAndSourceBr(farmLiDto.LNo,farmLiDto.SourceBr));
                        LOMDTO00085 dtoToUpdate = dtoToUpdateList[0];
                        string monthNo = this.GetMonthNo();
                        switch (monthNo)
                        {
                            case "M1":
                                dtoToUpdate.M1 = farmLiDto.InterestAmount;
                                break;
                            case "M2":
                                dtoToUpdate.M2 = farmLiDto.InterestAmount;
                                break;
                            case "M3":
                                dtoToUpdate.M3 = farmLiDto.InterestAmount;
                                break;
                            case "M4":
                                dtoToUpdate.M4 = farmLiDto.InterestAmount;
                                break;
                            case "M5":
                                dtoToUpdate.M5 = farmLiDto.InterestAmount;
                                break;
                            case "M6":
                                dtoToUpdate.M6 = farmLiDto.InterestAmount;
                                break;
                            case "M7":
                                dtoToUpdate.M7 = farmLiDto.InterestAmount;
                                break;
                            case "M8":
                                dtoToUpdate.M8 = farmLiDto.InterestAmount;
                                break;
                            case "M9":
                                dtoToUpdate.M9 = farmLiDto.InterestAmount;
                                break;
                            case "M10":
                                dtoToUpdate.M10 = farmLiDto.InterestAmount;
                                break;
                            case "M11":
                                dtoToUpdate.M11 = farmLiDto.InterestAmount;
                                break;
                            case "M12":
                                dtoToUpdate.M12 = farmLiDto.InterestAmount;
                                break;
                        }
                        dtoToUpdate.UpdatedDate = DateTime.Now;
                        dtoToUpdate.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                        if (CXClientWrapper.Instance.Invoke<ILOMSVE00301, bool>(x => x.Update(dtoToUpdate)))
                        {
                            this.View.Successful(CXMessage.MI20002);
                        }
                        else
                        {
                            this.View.Failure(CXMessage.ME90043);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException + ex.Message); 
            }
        }
        #endregion

        #region Helper Methods
        private string GetMonthNo()
        {
            string budgetYear = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);
            int initialMonth = Convert.ToInt32(CXCOM00010.Instance.GetBudgetYear2(budgetYear, DateTime.Now));
            string intMonth = "M" + Convert.ToString(initialMonth);
            return intMonth;
        }
        #endregion
    }
}
