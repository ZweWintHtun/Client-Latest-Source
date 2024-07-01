using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Windows.CXClient;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Tel.Dmd;
using System;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Mnm.Dmd;
using System.Globalization;
using Ace.Cbs.Tel.Ctr.Dao;


namespace Ace.Cbs.Loan.Ptr
{
    class LOMCTL00011 : AbstractPresenter, ILOMCTL00011
    {
        #region Constructor
        LOMCTL00011()
        {
            this.BranchCode = CurrentUserEntity.BranchCode;
        }
        #endregion

        #region Properties

        ILOMVEW00011 view;
        public ILOMVEW00011 View
        {
            set { this.wierTo(value); }
            get { return this.view; }
        }
        private void wierTo(ILOMVEW00011 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, GetEntity());
            }
        }
        public string LoanNo { get; set; }
        public DateTime sdate { get; set; }
        public DateTime edate { get; set; }
        //public string PrincipleRepaymentOption { get; set; }
        //public string InterestRepaymentOption { get; set; }
        public IList<LOMDTO00012> penalList { get; set; }
        public IList<LOMDTO00021> liList { get; set; }
        public TLMDTO00018 loansdto { get; set; }
        public string BranchCode { get; set; }
        public string Acsign { get; set; }
        public string Guarantee_Address { get; set; }
        public IList<PFMDTO00072> AccountInfoList { get; set; }
        public ICXSVE00002 CodeGenerator { get; set; }

        public ITLMDAO00018 LoansDAO { get; set; }
        #endregion

        #region ValidationMethods
        public TLMDTO00018 GetEntity()
        {
            TLMDTO00018 entity = new TLMDTO00018();
            // entity.Lno = this.view.LoanNo;
            entity.AccountNo = this.view.AccountNo;
            entity.PrincipleRepayOptions = this.view.PrincipleRepaymentOption==null?"":this.view.PrincipleRepaymentOption;
            entity.InterestRepayOptions = this.view.InterestRepaymentOption == null ? "" : this.view.InterestRepaymentOption;
            //entity.IntRate = this.view.RepaymentPeriod;
            //entity.Scharges = Convert.ToDecimal(this.view.RepaymentPeriod);/*/
            //entity.GuaranteeAccountNo = this.view.GuarantorAccountNo;
            return entity;
        }

        private TLMDTO00018 GetEntityForValidate()
        {
            TLMDTO00018 entity = new TLMDTO00018();
            //  entity.Lno = this.view.LoanNo;
            entity.AccountNo = this.view.AccountNo;
            entity.PrincipleRepayOptions = this.view.PrincipleRepaymentOption == null ? "" : this.view.PrincipleRepaymentOption;
            entity.InterestRepayOptions = this.view.InterestRepaymentOption == null ? "" : this.view.InterestRepaymentOption;
            return entity;
        }
        public void ClearAllCustomErrors()
        {
            this.ClearAllCustomErrorMessage();
        }
        public void txtLoanNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            
        }

        public void mtxtAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (!e.HasXmlBaseError && !this.view.isSaveValidate)
            {
                try
                {
                    if (this.view.AccountNo.Substring(0, 3) == CurrentUserEntity.BranchCode.Trim())
                    {
                        Nullable<CXDMD00011> accountType;
                        if (CXCLE00012.Instance.IsValidAccountNo(this.view.AccountNo, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                        {
                            TLMDTO00018 tLMDTO00018 = CXClientWrapper.Instance.Invoke<ILOMSVE00405, TLMDTO00018>(x => x.CountofLoan_byAccountNo(this.View.AccountNo, "BL"));

                            if (tLMDTO00018.Loans_Type.Equals(""))
                            {
                                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00046);
                                this.SetFocus("mtxtAccountNo");
                            }
                           else
                           {
                               if (tLMDTO00018.RCount > 0)
                               {
                                   CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90233);
                                   this.SetFocus("mtxtAccountNo");
                               }
                               else
                               {
                                   AccountInfoList = new List<PFMDTO00072>();
                                   AccountInfoList = CXClientWrapper.Instance.Invoke<ILOMSVE00011, IList<PFMDTO00072>>(x => x.IsValidForLoanAcctno(this.View.AccountNo));

                                   if (AccountInfoList.Count < 1 || CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                                   {
                                       string msgCode = CXClientWrapper.Instance.ServiceResult.MessageCode;

                                       if (msgCode == "MV00056" || msgCode == "MV90069")//new object[]{this.linkAccountView.CurrentAccountNo}
                                       {
                                           CXUIMessageUtilities.ShowMessageByCode(msgCode, new object[] { this.View.AccountNo }); //Invalid Account No.
                                           this.SetFocus("mtxtAccountNo");
                                       }
                                       else
                                       {
                                           CXUIMessageUtilities.ShowMessageByCode(msgCode);
                                           this.SetFocus("mtxtAccountNo");
                                       }
                                   }
                                   else if (AccountInfoList[0].CurrencyCode != this.view.CurrencyCode)
                                   {
                                       this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00086, new object[] { this.view.CurrencyCode }); //Currency of this account should be {0}.
                                       this.SetFocus("mtxtAccountNo");
                                   }
                                   else
                                   {
                                       Acsign = AccountInfoList[0].AccountSignature;
                                       this.view.BindAccountInfo(AccountInfoList);

                                   }
                                }
                           }
                        }
                    }
                    else
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00224, new object[] { this.view.AccountNo, CurrentUserEntity.BranchCode }); //Invalid Account No {0} for Branch {1}.
                        this.SetFocus("mtxtAccountNo");
                    }
                }
                catch (Exception ex)
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), ex.Message);
                }
            }
        }

        //public void mtxtGuaranterAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        //{
        //    // if xml base error does not exist.
        //    if (!e.HasXmlBaseError && !this.view.isSaveValidate)
        //    {
        //        try
        //        {
        //            //the guarantor acctno must be for the current branch
        //            if (this.view.GuarantorAccountNo.Substring(0, 3) == CurrentUserEntity.BranchCode)
        //            {
        //                Nullable<CXDMD00011> accountType;
        //                if (CXCLE00012.Instance.IsValidAccountNo(this.view.GuarantorAccountNo, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
        //                {
        //                    IList<PFMDTO00001> GuaranteeAccountInfoList = new List<PFMDTO00001>();
        //                    GuaranteeAccountInfoList = CXClientWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00001>>(x => x.GetCustomerInfomationByAccountNo(this.View.GuarantorAccountNo, false));

        //                    if (GuaranteeAccountInfoList.Count < 1 || CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
        //                    {
        //                        CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
        //                        this.SetFocus("mtxtGuaranterAccountNo");
        //                    }
        //                    else if (GuaranteeAccountInfoList[0].CurrencyCode != this.view.CurrencyCode)
        //                    {
        //                        this.SetCustomErrorMessage(this.GetControl("mtxtGuaranterAccountNo"), CXMessage.MV00086, new object[] { this.view.CurrencyCode }); //Currency of this account should be {0}.
        //                        this.SetFocus("mtxtGuaranterAccountNo");
        //                    }
        //                    else
        //                    {
        //                        //bind method for the guarantor acct info to UI
        //                        this.BindGuaranteeInfo(GuaranteeAccountInfoList);
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00224, new object[] { this.view.GuarantorAccountNo, CurrentUserEntity.BranchCode }); //Invalid Account No {0} for Branch {1}.
        //                this.SetFocus("mtxtGuaranterAccountNo");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            this.SetCustomErrorMessage(this.GetControl("mtxtGuaranterAccountNo"), ex.Message);
        //        }
        //    }
        //}

        public void cboRepayment_CustomValidating(object sender, ValidationEventArgs e)
        {
            //// if xml base error does not exist.
            //if (!e.HasXmlBaseError)
            //{
            //    try
            //    {
            //        int noOfTerms = this.view.RepaymentDuration / this.view.RepaymentPeriod;

            //        if (noOfTerms == 0)
            //            CXUIMessageUtilities.ShowMessageByCode("MV90087"); //Invalid Repayment Period.
            //        else
            //        {
            //            PFMDTO00009 ratedto = CXCLE00002.Instance.GetScalarObject<PFMDTO00009>("PFMORM00009.Client.SelectByCodeAndLastModify", new object[] { "LOANSRATE", true, true }); //hm
            //            if (ratedto == null)
            //                throw new Exception();
            //            TLMDTO00018 loansdto = new TLMDTO00018();
            //            liList = new List<LOMDTO00021>();
            //            LOMDTO00021 LiDto = new LOMDTO00021();

            //            for (int i = 1; i <= noOfTerms; i++) //12/4
            //            {
            //                string termNo = CXClientWrapper.Instance.Invoke<ICXSVE00002, string>(x => x.GetGenerateCode("TermNo", string.Empty, ratedto.CreatedUserId, this.BranchCode, new object[] { }));
            //                LOMDTO00021 termDto = new LOMDTO00021();
            //                if (string.IsNullOrEmpty(termNo)) throw new Exception();

            //                if (i == 1)
            //                {
            //                    LiDto.StartDate = DateTime.Now;
            //                    // sdate = Convert.ToDateTime(LiDto.StartDate.ToString("dd/MM/yyyy"));

            //                }
            //                else
            //                {
            //                    LiDto.StartDate = LiDto.EndDate.AddDays(1);
            //                }

            //                LiDto.EndDate = LiDto.StartDate.AddMonths(this.view.RepaymentPeriod);
            //                //edate = Convert.ToDateTime(LiDto.EndDate.ToString("dd/MM/yyyy"));
            //                // edate = DateTime.ParseExact(LiDto.EndDate., "dd/MM/yyyy", null);

            //                termDto.StartDate = LiDto.StartDate;
            //                //termDto.StartDate = Convert.ToDateTime(sdate);
            //                //termDto.EndDate = Convert.ToDateTime(LiDto.EndDate.ToString("dd/MM/yyyy"));
            //                termDto.EndDate = LiDto.EndDate;
            //                //termDto.EndDate = Convert.ToDateTime(edate);

            //                //  termDto.StartDate = DateTime.Parse(this.sdate, CultureInfo.CreateSpecificCulture("fr-FR"));

            //                //  termDto.EndDate = Convert.ToDateTime(edate);
            //                termDto.IntRate = ratedto.Rate;
            //                termDto.TNo = termNo;

            //                liList.Add(termDto);


            //            }

            //            var orderByDescendingResult = (from s in liList
            //                                           orderby s.EndDate descending
            //                                           select s.EndDate).FirstOrDefault();
            //            this.view.ExpiredDate = orderByDescendingResult;



            //            ///this.view.BindLoanInterestInfo(liList); //updted2017
            //            //this.view.CleargdvLoanInterest(liList);

            //            //  this.view.gdvLoanInterest.

            //            CXClientWrapper.Instance.Invoke<ICXSVE00002>(x => x.UpdateFormatDefinition("TermNo", CurrentUserEntity.BranchCode));
            //            //   this.view.CleargdvLoanInterest(liList);

            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        this.SetCustomErrorMessage(this.GetControl("txtRepaymentPeriod"), ex.Message);
            //    }
            //}
        }

        public void txtPenalDuration_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (!e.HasXmlBaseError)
            {
                try
                {
                    int duration = this.view.Duration;

                    if (duration == 0)
                        CXUIMessageUtilities.ShowMessageByCode("MV00034"); // Invalid Duration
                    else if (duration < 5)
                        CXUIMessageUtilities.ShowMessageByCode("MV00034"); // Invalid Duration
                    else
                    {
                        penalList = new List<LOMDTO00012>();
                        LOMDTO00012 penalDto = new LOMDTO00012();

                        for (int i = 1; penalDto.EndDay < duration; i++) //12/4
                        {
                            LOMDTO00012 Dto = new LOMDTO00012();

                            if (i == 1) penalDto.StartDay = i;
                            else penalDto.StartDay = penalDto.EndDay + 1;
                            penalDto.EndDay = penalDto.StartDay + 4;
                            if (penalDto.EndDay < duration)
                            {
                                Dto.StartDay = penalDto.StartDay;
                                Dto.EndDay = penalDto.EndDay;
                                penalList.Add(Dto);
                            }
                            else
                            {
                                Dto.StartDay = penalDto.StartDay;
                                Dto.EndDay = duration - Dto.StartDay;  //For the value of greater than endday 
                                penalList.Add(Dto);
                            }
                        }

                        this.view.BindPeanlFee(penalList);
                        this.SetFocus("gdvPenalFee");

                    }
                }
                catch (Exception ex)
                {
                    this.SetCustomErrorMessage(this.GetControl("txtRepaymentPeriod"), ex.Message);
                }
            }

            //else if(e.HasXmlBaseError == true)
            //{
            //    CXUIMessageUtilities.ShowMessageByCode("MV00034");
            //    this.SetFocus("txtPenalDuration");
            //}
        }

        public void cboCurrency_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if (!e.HasXmlBaseError && !this.view.isSaveValidate)

        }
        #endregion

        #region Method
        
        public void BindLoanInfo()
        {
            try
            {
                if (this.view.FormName.Contains("Entry"))
                {
                    //TLMDTO00018 loanInfo = CXClientWrapper.Instance.Invoke<ILOMSVE00011, TLMDTO00018>(x => x.SelectLoanInformationByLoanNoAndSourceBr(this.View.LoanNo, CurrentUserEntity.BranchCode));
                    //if (CXClientWrapper.Instance.Invoke<ILOMSVE00014, TLMDTO00018>(x => x.isValidLoanNo(this.View.LoanNo, CurrentUserEntity.BranchCode)) != null)
                    //{
                    //    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90061);   //Duplicate Loan No. !
                    //    this.SetFocus("txtLoanNo");
                    //}
                }
                else
                {
                    if (String.IsNullOrEmpty(this.view.LoanNo))
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90055);   //Invalid Loan No. !
                        this.SetFocus("txtLoanNo");
                    }
                    TLMDTO00018 loanInfo = CXClientWrapper.Instance.Invoke<ILOMSVE00011, TLMDTO00018>(x => x.SelectLoanInformationByLoanNoAndSourceBr(this.View.LoanNo, CurrentUserEntity.BranchCode));
                    if (loanInfo == null || CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        string code = CXClientWrapper.Instance.ServiceResult.MessageCode;

                        if (code == "MV90069") CXUIMessageUtilities.ShowMessageByCode(code, loanInfo.AccountNo);    //Invalid Loan No.
                        else CXUIMessageUtilities.ShowMessageByCode(code);    //Invalid Loan No.

                        this.SetFocus("txtLoanNo");

                    }
                    else
                    {
                        this.BindCommon(loanInfo);
                        bool isEnable;
                        if (this.view.FormName.Contains("Enquiry"))
                        {
                            isEnable = false;
                            switch (loanInfo.Loans_Type)
                            {

                                case "LB": this.BindLand_Building(loanInfo); this.view.SelectTab("land", isEnable); break;
                                case "PG": this.BindPer_Guarantee(loanInfo); this.view.SelectTab("per", isEnable); break;
                                case "PL": this.BindPledge(loanInfo); this.view.SelectTab("pledge", isEnable); break;
                                case "HP": this.BindHypothecation(loanInfo); this.view.SelectTab("hypo", isEnable); break;
                                case "GJ": this.BindGold_Jewellery(loanInfo); this.view.SelectTab("gold", isEnable); break;
                            }
                            this.EnableDisableForEnquiry();

                        }
                        else
                        {
                            isEnable = true;
                            switch (loanInfo.Loans_Type)
                            {
                                case "LB": this.BindLand_Building(loanInfo); this.view.SelectTab("land", isEnable); break;
                                case "PG": this.BindPer_Guarantee(loanInfo); this.EnableForPGLoans(); this.view.SelectTab("per", isEnable); break;
                                case "PL": this.BindPledge(loanInfo); this.view.SelectTab("pledge", isEnable); this.SetFocus("gdvStock"); break;
                                case "HP": this.BindHypothecation(loanInfo); this.view.SelectTab("hypo", isEnable); break;
                                case "GJ": this.BindGold_Jewellery(loanInfo); this.view.SelectTab("gold", isEnable); break;
                            }
                        }
                        EnableDisableForeditting();
                    }
                }
            }
            catch (Exception ex)
            {
                // this.SetCustomErrorMessage(this.GetControl("txtLoanNo"), CXMessage.MV90055); //Invalid Loan No.
            }
        }

        public void Save(string sourceBranch)
        {
            try
            {
                if (!this.view.FormName.Contains("Entry"))
                {
                    if (!this.ValidateForm())
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MV90055");      //Invalid Loan No.
                        return;
                    }
                }
                TLMDTO00018 loanDto = this.view.GetViewDataForCommon;
                LOMDTO00021 liList = new LOMDTO00021();
                if (loanDto.AType.Contains("LOANS"))
                {
                    liList = this.view.GetInterestList(); //updated2017
                    //if (liList.Acctno == 0)
                    //{
                    //    CXUIMessageUtilities.ShowMessageByCode("MV90068"); //Invalid interest rate for loan registration !
                    //    return;
                    //}
                }

                IList<LOMDTO00012> penalList = new List<LOMDTO00012>();
                penalList = this.view.GetPenalFeeList();

                if (this.view.FormName.Contains("Entry"))
                {
                    loanDto.status = "save";
                }
                else
                {
                    loanDto.status = "update";
                }

                if (this.view.registerType == 1) // Land and Building
                {
                    LOMDTO00015 land_BuildingDto = this.view.GetViewDataForLandAndBuilding;
                    
                    LoanNo = CXClientWrapper.Instance.Invoke<ILOMSVE00011, string>(x => x.Save_LandandBuilding(land_BuildingDto, liList, loanDto, penalList, sourceBranch));
                }
                else if (this.view.registerType == 2) // Personal Guarantee
                {
                    PFMDTO00039 personal_guaranteeDto = this.view.GetViewDataForGuarantee;
                    personal_guaranteeDto.UpdatedDate = DateTime.Now;
                    personal_guaranteeDto.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                    // personal_guaranteeDto.LNo = LoanNo;

                    LoanNo = CXClientWrapper.Instance.Invoke<ILOMSVE00011, string>(x => x.Save_PersonalGuarantee(personal_guaranteeDto, liList, loanDto, penalList, sourceBranch));
                }
                else if (this.view.registerType == 3) // Pledge
                {
                    IList<LOMDTO00016> pledgeDtoList = new List<LOMDTO00016>();
                    pledgeDtoList = this.view.GetViewDataForPledge();

                    LoanNo = CXClientWrapper.Instance.Invoke<ILOMSVE00011, string>(x => x.Save_Pledge(pledgeDtoList, liList, loanDto, penalList, sourceBranch));
                }
                else if (this.view.registerType == 4) // Hypothecation
                {
                    LOMDTO00017 hypothecationDto = this.view.GetViewDataForHypothecation;
                    LoanNo = CXClientWrapper.Instance.Invoke<ILOMSVE00011, string>(x => x.Save_Hypothecation(hypothecationDto, liList, loanDto, penalList, sourceBranch));

                }

                else  // Gold and Jewellery
                {
                    IList<LOMDTO00018> gjTypeDtoList = new List<LOMDTO00018>();
                    IList<LOMDTO00018> gjKindDtoList = new List<LOMDTO00018>();
                    gjTypeDtoList = this.view.GetViewDataForGoldAndJewelleryType();
                    gjKindDtoList = this.view.GetViewDataForGoldAndJewelleryKind();
                    LoanNo = CXClientWrapper.Instance.Invoke<ILOMSVE00011, string>(x => x.Save_GoldAndJewellery(gjTypeDtoList, gjKindDtoList, liList, loanDto, penalList, sourceBranch));
                }

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    CXUIMessageUtilities.ShowMessageByCode("ME90000");      //Saving Error
                    this.view.isSaveValidate = false;
                }
                else
                {
                    if (this.view.FormName.Contains("Entry"))
                    {
                        this.view.LoanNo = LoanNo;
                    }
                    CXUIMessageUtilities.ShowMessageByCode("MI90001");      //Saving Successful.                    
                    this.view.isActive = false;
                    //  this.view.ClearFormControls();
                    this.view.GetFormControlSetting();
                }
            }
            catch (Exception ex)
            {
                CXUIMessageUtilities.ShowMessageByCode("ME90000");      //Saving Error
            }
        }

        public void BindLand_Building(TLMDTO00018 loanDto)
        {
            this.view.YearOfPLBS = loanDto.Land_buildingDto.YearPB;
            this.view.EstablishmentDate = Convert.ToDateTime(loanDto.Land_buildingDto.EDate);
            this.view.YearOfExperience = Convert.ToDecimal(loanDto.Land_buildingDto.ExpYear);
            this.view.Capital = Convert.ToDecimal(loanDto.Land_buildingDto.Capital);
            this.view.IncomeTax = Convert.ToDecimal(loanDto.Land_buildingDto.Tax);
            //this.view.SalesDeed = loanDto.Land_buildingDto.SDEED;
            //this.view.LandOfAffidavit = loanDto.Land_buildingDto.LAFFID;
            this.view.BindCombo(loanDto.Land_buildingDto.SDEED, loanDto.Land_buildingDto.LAFFID, loanDto.Land_buildingDto.HISLB, loanDto.Land_buildingDto.BPERMIT);
            this.view.Land = loanDto.Land_buildingDto.Land;
            this.view.CharacterOfCustomer = loanDto.Land_buildingDto.Char;
            this.view.GoodWill = loanDto.Land_buildingDto.GW;
            this.view.ForceSaleValueOfLand = Convert.ToDecimal(loanDto.Land_buildingDto.FSVLand);
            this.view.ForceSaleValueOfBuilding = Convert.ToDecimal(loanDto.Land_buildingDto.FSVBLD);
            this.view.Address = loanDto.Land_buildingDto.Address;
            //this.view.HistoryOfLand_Building = loanDto.Land_buildingDto.HISLB;
            //this.view.BuildingConstructionPermit = loanDto.Land_buildingDto.BPERMIT;
            this.view.TypeOfInsurance = loanDto.Land_buildingDto.IsType;
            this.view.DateOfInsurance = Convert.ToDateTime(loanDto.Land_buildingDto.IsDate);
            this.view.InsuranceAmount = Convert.ToDecimal(loanDto.Land_buildingDto.IsAMT);
            this.view.LandLeaseSDate = Convert.ToDateTime(loanDto.Land_buildingDto.LandLeaseSDate);
            this.view.LandLeaseEDate = Convert.ToDateTime(loanDto.Land_buildingDto.LandLeaseEDate);
            this.view.RemarkForLand = loanDto.Land_buildingDto.RemarkForLand;
        }

        public void BindPer_Guarantee(TLMDTO00018 loanDto)
        {
            //this.view.GuarantorAccountNo = loanDto.Per_guaranteeDto.AccountNo;
            this.view.GuarantorCompanyName = loanDto.Per_guaranteeDto.GuarantorCompanyName;
            this.view.GuarantorName = loanDto.Per_guaranteeDto.Name;
            this.view.GuarantorNrc = loanDto.Per_guaranteeDto.NRC;
            this.view.GuarantorPhone = loanDto.Per_guaranteeDto.Phone;
        }

        public void BindPledge(TLMDTO00018 loanDto)
        {
            this.view.Pledge(loanDto.PledgeDto);
            this.view.TypeOfInsuranceForPledge = loanDto.PledgeDto[0].IsType;
            this.view.DateOfInsuranceForPledge = Convert.ToDateTime(loanDto.PledgeDto[0].IsDate);
            this.view.InsuranceExpireDateForPledge = Convert.ToDateTime(loanDto.PledgeDto[0].IsExpiredDate);
            this.view.InsuranceAmountForPledge = Convert.ToDecimal(loanDto.PledgeDto[0].IsAMT);
        }

        public void BindHypothecation(TLMDTO00018 loanDto)
        {
            this.view.KindOfStock = loanDto.HypothecationDto.KStock;
            this.view.Value = Convert.ToDecimal(loanDto.HypothecationDto.Value);
            this.view.TypeOfInsuranceForHypo = loanDto.HypothecationDto.IsType;
            this.view.DateOfInsuranceForHypo = Convert.ToDateTime(loanDto.HypothecationDto.IsDate);
            this.view.InsuranceExpireDateForHypo = Convert.ToDateTime(loanDto.HypothecationDto.IsExpiredDate);
            this.view.InsuranceAmountForHypo = Convert.ToDecimal(loanDto.HypothecationDto.IsAMT);
        }

        public void BindGold_Jewellery(TLMDTO00018 loanDto)
        {
            this.view.GoldandJewellery(loanDto);
        }

        public void BindCommon(TLMDTO00018 loanDto)
        {
            this.view.AccountNo = loanDto.AccountNo;
            this.view.CurrencyCode = loanDto.Currency;
            this.view.SanctionAmount = Convert.ToDecimal(loanDto.FirstSAmount);
           
            this.view.AssessorName = loanDto.Assessor;
            this.view.LawerName = loanDto.Lawer;
            this.view.TypeOfBusiness = loanDto.BType;
            this.view.ExpiredDate = Convert.ToDateTime(loanDto.ExpireDate);
            this.view.TypeOfProduct = loanDto.Loans_Type;
            this.view.BindAccountInfo(loanDto.LoanAcctnoInfoList);
            

            if (loanDto.AType.Contains("LOANS"))
            {
                //this.view.RepaymentPeriod = loanDto.LiList[0].RepaymentPeriod;
                int repayOption = Convert.ToInt16(loanDto.LiList[0].Duration); ///1,3,6,12
                IList<LOMDTO00055> TypeOfInstallment = CXCLE00002.Instance.GetListObject<LOMDTO00055>("LOMORM00100.SelectAllInstallmentName", new object[] { repayOption, true });
                //LOMDTO00055 repayment=LoansDAO.GetInstallmentTypeName(repayOption);
                //this.view.Repay = TypeOfInstallment[0].NAME.ToString();
                this.view.RelatedGLACode = loanDto.RelatedGLACode;
                this.view.RepaymentDuration = Convert.ToInt16( loanDto.Min_Period);

                //string _PrincipleRepayOptions = ""; _PrincipleRepayOptions = loanDto.PrincipleRepayOptions;
                //this.view.PrincipleRepaymentOption = _PrincipleRepayOptions.ToString();

                string _InterestRepayOptions = ""; _InterestRepayOptions = loanDto.InterestRepayOptions;
                this.view.InterestRepaymentOption = _InterestRepayOptions.ToString();

                this.view.Rate = loanDto.IntRate.ToString();
                this.view.DocFee = loanDto.DocFee.ToString();
                this.view.GracePeriod= loanDto.GracePeriod;
                //this.view.RepaymentPeriod = loanDto.LiList[0].Repaymentoption;
                this.view.RepaymentDuration = loanDto.LiList[0].RepaymentPeriod;
                //this.view.BindLoanInterestInfo(loanDto.LiList); //updated2017
                

                
            }
            else if (loanDto.AType.Contains("OVERDRAFT"))
            {
                if (loanDto.BalStatus.Contains("Used"))
                {
                    this.view.IsUsedBal = true;
                    this.view.UsedRateForUsedBal = Convert.ToDecimal(loanDto.IntRate);
                    this.view.UnUsedRateForUsedBal = Convert.ToDecimal(loanDto.UnUsedRate);

                }
                else
                {
                    this.view.IsMiddleBal = true;
                    this.view.UsedUnderHalfRate = Convert.ToDecimal(loanDto.IntRate);
                    this.view.UsedOverHalfRate = Convert.ToDecimal(loanDto.UsedOverRate);
                    this.view.MiddleUnUsedRate = Convert.ToDecimal(loanDto.UnUsedRate);
                }
            }

            if (loanDto.isLateFee)
            {
                this.view.IsLateFee = loanDto.isLateFee;
                this.view.Duration = loanDto.PenalFeeList[0].Duration;
                this.view.BindPeanlFee(loanDto.PenalFeeList);
            }
            this.view.TypeOfAdvance = loanDto.AType;
            
            // this.view.IsLateFee = loanDto.isScharge;
            this.view.IsLateFee = loanDto.isLateFee;
            // this.view.IsLateFee = loanDto.isPFcharge;
            this.view.IsScharge = loanDto.isScharge;
        }

        private void BindGuaranteeInfo(IList<PFMDTO00001> GuaranteeAccountInfoList)
        {
            this.view.GuarantorName = GuaranteeAccountInfoList[0].Name;
            this.view.GuarantorNrc = GuaranteeAccountInfoList[0].NRC;
            this.view.GuarantorPhone = GuaranteeAccountInfoList[0].PhoneNo;
            this.Guarantee_Address = GuaranteeAccountInfoList[0].Address;
            if (this.view.FormName.Contains("Edit"))
            {
                this.SetEnableDisable("txtGCompanyName", true);
                this.SetEnableDisable("txtGuarantorName", true);
                this.SetEnableDisable("txtGuarantorNrc", true);
                this.SetEnableDisable("txtGuarantorPhone", true);
            }
            else
            {
                this.SetEnableDisable("txtGCompanyName", false);
                this.SetEnableDisable("txtGuarantorName", false);
                this.SetEnableDisable("txtGuarantorNrc", false);
                this.SetEnableDisable("txtGuarantorPhone", false);
            }
        }

        private void EnableDisableForeditting()
        {
            this.SetEnableDisable("mtxtAccountNo", false);
            this.SetEnableDisable("cboCurrency", false);
            this.SetEnableDisable("cboTypeOfAdvance", false);
            this.SetEnableDisable("txtSanctionAmount", false);
            this.SetEnableDisable("grpPenalFee", false);
            this.SetEnableDisable("grpODInterest", false);
            this.SetEnableDisable("grpLoanInterest", false);
            this.SetEnableDisable("grpSanctionAmount", false);
            this.SetEnableDisable("cboTypeOfProduct", false);
            this.SetEnableDisable("gdvAccountInfo", false);
        }

        private void EnableDisableForEnquiry()
        {
            this.SetEnableDisable("txtAssessorName", false);
            this.SetEnableDisable("txtLawerName", false);
            this.SetEnableDisable("mcboTypeOfBusiness", false);
            this.SetEnableDisable("dtpExpireDate", false);

            this.SetEnableDisable("cboTypeOfProduct", false);
            this.SetEnableDisable("cboRepayment", false);
        }

        private void EnableForPGLoans()
        {
            this.SetEnableDisable("tbpPersonalGuarantee", true);
            this.SetEnableDisable("grpGuarantorInfo", true);
            //this.SetEnableDisable("mtxtGuaranterAccountNo", true);
            this.SetEnableDisable("txtGCompanyName", true);
            this.SetEnableDisable("txtGuarantorName", true);
            this.SetEnableDisable("txtGuarantorNrc", true);
            this.SetEnableDisable("txtGuarantorPhone", true);
        }

        public IList<LOMDTO00001> BindLoansBType()
        {
            IList<LOMDTO00001> LoansBTypeDto = CXClientWrapper.Instance.Invoke<ILOMSVE00011, IList<LOMDTO00001>>(x => x.BindLoansBType());
            return LoansBTypeDto;
        }
        

        //Added by YMP at 30-07-2019 : [Seperating EOD Process] To show system date (not PC date) at report
        public DateTime GetSystemDate(string sourceBr)
        {
            TCMDTO00001 systemStartInfo = CXClientWrapper.Instance.Invoke<ICXSVE00006, TCMDTO00001>(x => x.SelectStartBySourceBr(sourceBr));
            DateTime systemDate = systemStartInfo.Date;
            return systemDate;
        }

        //Added by HMW at 26-08-2019 : [Seperating EOD Process] Check Settlement Date to show form
        public DateTime GetLastSettlementDate(string sourceBr)
        {
            DateTime lastSettlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.LastSettlementDate), sourceBr);
            return lastSettlementDate;
        }
        #endregion

    }
}
