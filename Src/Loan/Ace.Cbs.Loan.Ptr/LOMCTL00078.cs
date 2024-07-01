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
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00078 : AbstractPresenter, ILOMCTL00078
    {
        #region Constructor
        public LOMCTL00078()
        {
            this.BranchCode = CurrentUserEntity.BranchCode;
            //this.Acsign = "LI";
        }
        #endregion

        #region Properties
        ILOMVEW00078 view;
        public ILOMVEW00078 View
        {
            set { this.wierTo(value); }
            get { return this.view; }
        }
        private void wierTo(ILOMVEW00078 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, GetEntity());
            }
        }

        public string LoanNo { get; set; }
        public string BranchCode { get; set; }
        public string Acsign { get; set; }

        public IList<PFMDTO00072> AccountInfoList { get; set; }

        #endregion

        #region Validation Methods

        public LOMDTO00078 GetEntity()
        {
            LOMDTO00078 entity = new LOMDTO00078();
            //entity.Lno = this.view.LoanNo;
            entity.AcctNo = this.view.AccountNo;
            entity.AType = "LOANS";
            entity.Name = this.view.NameInPI;
            entity.FatherName = this.view.FatherNameInPI;
            entity.Cur = this.view.CurrencyCode;
            entity.SourceBr = this.BranchCode;
            entity.LoanType = this.view.TypeOfLoan;
            entity.Village = this.view.VillageGroupCode;
            entity.Township = this.view.TownshipCode;
            if (this.view.isOtherNRC)
            {
                entity.NRC = this.view.NRC;
            }
            else
            {
                entity.NRC = this.view.StateCodeForNRC + this.view.TownshipCodeForNRC +
                    this.view.NationalityCodeForNRC + this.view.NRCNo;
            }
            entity.Address = this.view.Address;
            return entity;
        }

        public void ClearAllCustomErrors()
        {
            this.ClearAllCustomErrorMessage();
        }

        public void mtxtAcctNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (!e.HasXmlBaseError && !this.view.isSaveValidate)
            {
                try
                {
                    if (this.view.AccountNo.Substring(0, 3) == CurrentUserEntity.BranchCode)
                    {
                        Nullable<CXDMD00011> accountType;
                        if (CXCLE00012.Instance.IsValidAccountNo(this.view.AccountNo, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                        {
                            AccountInfoList = new List<PFMDTO00072>();
                            AccountInfoList = CXClientWrapper.Instance.Invoke<ILOMSVE00078, IList<PFMDTO00072>>(x => x.IsValidForLoanAcctno(this.View.AccountNo));

                            if (AccountInfoList.Count < 1 || CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                            {
                                string msgCode = CXClientWrapper.Instance.ServiceResult.MessageCode;

                                if (msgCode == "MV00056" || msgCode == "MV90069")//new object[]{this.linkAccountView.SavingAccountNo}
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
                                //this.view.BindAccountInfo(AccountInfoList);
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

        public void mtxtGuaranterAccountNo1_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (!e.HasXmlBaseError && !this.view.isSaveValidate)
            {
                try
                {
                    //the guarantor acctno must be for the current branch
                    if (this.view.GuarantorAccountNo1.Substring(0, 3) == CurrentUserEntity.BranchCode)
                    {
                        Nullable<CXDMD00011> accountType;
                        if (CXCLE00012.Instance.IsValidAccountNo(this.view.GuarantorAccountNo1, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                        {
                            IList<PFMDTO00001> GuaranteeAccountInfoList = new List<PFMDTO00001>();
                            GuaranteeAccountInfoList = CXClientWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00001>>(x => x.GetCustomerInfomationByAccountNo(this.View.GuarantorAccountNo1, false));

                            if (GuaranteeAccountInfoList.Count < 1 || CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                            {
                                CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                                this.SetFocus("mtxtGuaranterAccountNo");
                            }
                            else if (GuaranteeAccountInfoList[0].CurrencyCode != this.view.CurrencyCode)
                            {
                                this.SetCustomErrorMessage(this.GetControl("mtxtGuaranterAccountNo"), CXMessage.MV00086, new object[] { this.view.CurrencyCode }); //Currency of this account should be {0}.
                                this.SetFocus("mtxtGuaranterAccountNo");
                            }
                            else
                            {
                                //bind method for the guarantor acct info to UI
                                this.BindGuarantee1Info(GuaranteeAccountInfoList);
                            }
                        }
                    }
                    else
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00224, new object[] { this.view.GuarantorAccountNo1, CurrentUserEntity.BranchCode }); //Invalid Account No {0} for Branch {1}.
                        this.SetFocus("mtxtGuaranterAccountNo");
                    }
                }
                catch (Exception ex)
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtGuaranterAccountNo"), ex.Message);
                }
            }
        }

        public void mtxtGuaranterAccountNo2_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (!e.HasXmlBaseError && !this.view.isSaveValidate)
            {
                try
                {
                    //the guarantor acctno must be for the current branch
                    if (this.view.GuarantorAccountNo2.Substring(0, 3) == CurrentUserEntity.BranchCode)
                    {
                        Nullable<CXDMD00011> accountType;
                        if (CXCLE00012.Instance.IsValidAccountNo(this.view.GuarantorAccountNo2, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                        {
                            IList<PFMDTO00001> GuaranteeAccountInfoList = new List<PFMDTO00001>();
                            GuaranteeAccountInfoList = CXClientWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00001>>(x => x.GetCustomerInfomationByAccountNo(this.View.GuarantorAccountNo2, false));

                            if (GuaranteeAccountInfoList.Count < 1 || CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                            {
                                CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                                this.SetFocus("mtxtGuaranterAccountNo2");
                            }
                            else if (GuaranteeAccountInfoList[0].CurrencyCode != this.view.CurrencyCode)
                            {
                                this.SetCustomErrorMessage(this.GetControl("mtxtGuaranterAccountNo2"), CXMessage.MV00086, new object[] { this.view.CurrencyCode }); //Currency of this account should be {0}.
                                this.SetFocus("mtxtGuaranterAccountNo2");
                            }
                            else
                            {
                                //bind method for the guarantor acct info to UI
                                this.BindGuarantee2Info(GuaranteeAccountInfoList);
                            }
                        }
                    }
                    else
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00224, new object[] { this.view.GuarantorAccountNo1, CurrentUserEntity.BranchCode }); //Invalid Account No {0} for Branch {1}.
                        this.SetFocus("mtxtGuaranterAccountNo");
                    }
                }
                catch (Exception ex)
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtGuaranterAccountNo"), ex.Message);
                }
            }
        }

        public void txtGroupNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.  
            if (!e.HasXmlBaseError && !this.view.isSaveValidate)
            {
                try
                {
                    if (this.view.TypeOfLoan == "111")
                    {
                        //the guarantor acctno must be for the current branch
                        if (this.view.GroupNo.Substring(1, 3) == CurrentUserEntity.BranchCode)
                        {
                            IList<PFMDTO00078> SolidarityList = CXClientWrapper.Instance.Invoke<IPFMSVE00078, PFMDTO00078>(service => service.SelectByGroupNo(this.view.GroupNo));
                            bool isGroupValid = false;
                            if (SolidarityList.Count > 0)
                            {
                                for (int i = 0; i < SolidarityList.Count; i++)
                                {
                                    if (SolidarityList[i].GroupNo == this.view.GroupNo)
                                    {
                                        isGroupValid = true;
                                    }
                                }
                            }
                            if (isGroupValid == false)
                            {
                                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90119); //Invalid Group No.
                                this.SetFocus("txtGroupNo");
                            }
                        }
                        else
                        {
                            CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90120, new object[] { this.view.GroupNo, CurrentUserEntity.BranchCode }); //Invalid Group No {0} for Branch {1}.
                            this.SetFocus("txtGroupNo");
                        }
                    }                    
                }
                catch (Exception ex)
                {
                    this.SetCustomErrorMessage(this.GetControl("txtGroupNo"), ex.Message);
                }
            }
        }

        private void BindGuarantee1Info(IList<PFMDTO00001> GuaranteeAccountInfoList)
        {
            this.view.GuarantorName1 = GuaranteeAccountInfoList[0].Name;
            this.view.GuarantorNrc1 = GuaranteeAccountInfoList[0].NRC;
            this.view.GuarantorPhone1 = GuaranteeAccountInfoList[0].PhoneNo;
            if (this.view.FormName.Contains("Edit"))
            {
                this.SetEnableDisable("txtGuarantorName", true);
                this.SetEnableDisable("txtGuarantorNrc", true);
                this.SetEnableDisable("txtGuarantorPhone", true);
            }
            else
            {
                this.SetEnableDisable("txtGuarantorName", false);
                this.SetEnableDisable("txtGuarantorNrc", false);
                this.SetEnableDisable("txtGuarantorPhone", false);
            }
        }

        private void BindGuarantee2Info(IList<PFMDTO00001> GuaranteeAccountInfoList)
        {
            this.view.GuarantorName2 = GuaranteeAccountInfoList[0].Name;
            this.view.GuarantorNrc2 = GuaranteeAccountInfoList[0].NRC;
            this.view.GuarantorPhone2 = GuaranteeAccountInfoList[0].PhoneNo;
            if (this.view.FormName.Contains("Edit"))
            {
                this.SetEnableDisable("txtGuarantorName2", true);
                this.SetEnableDisable("txtGuarantorNrc2", true);
                this.SetEnableDisable("txtGuarantorPhone2", true);
            }
            else
            {
                this.SetEnableDisable("txtGuarantorName2", false);
                this.SetEnableDisable("txtGuarantorNrc2", false);
                this.SetEnableDisable("txtGuarantorPhone2", false);
            }
        }

        #endregion

        #region Method
        public void Save(string BranchCode)
        {
            try
            {
                if (!this.ValidateForm(this.view.GetViewDataForCommon))
                {
                    CXUIMessageUtilities.ShowMessageByCode("MV90055");      //Invalid Loan No.                    
                    return;
                }
                LOMDTO00078 farmLoanDto = this.view.GetViewDataForCommon;

                LOMDTO00085 farmLIDto = this.view.GetViewDataForInterest();
                if (farmLIDto == null)
                {
                    CXUIMessageUtilities.ShowMessageByCode("MV90068"); //Invalid interest rate for loan registration !
                    return;
                }

                LOMDTO00300 farmLoanPenalFeeDto = this.view.GetViewDataForPenalFee();
                if (farmLoanPenalFeeDto == null)
                {
                    CXUIMessageUtilities.ShowMessageByCode("MV90140"); //Invalid penal fee for farm loan!
                    return;
                }


                if (this.view.FormName.Contains("Entry"))
                {
                    farmLoanDto.status = "save";
                }
                else
                {
                    farmLoanDto.status = "update";
                }

                if (this.view.TypeOfLoan == "111")
                {
                    LOMDTO00015 land_BuildingDto = this.view.GetViewDataForLandAndBuilding;

                    LoanNo = CXClientWrapper.Instance.Invoke<ILOMSVE00078, string>(x => x.Save_LandAndBuilding(land_BuildingDto, farmLIDto, farmLoanPenalFeeDto, farmLoanDto, BranchCode));
                }
                else if (this.view.TypeOfLoan == "112")
                {
                    LOMDTO00015 land_BuildingDto = this.view.GetViewDataForLandAndBuilding;
                    LOMDTO00079 personal_guaranteeDto = this.view.GetViewDataForGuarantee;
                    personal_guaranteeDto.UpdatedDate = DateTime.Now;
                    personal_guaranteeDto.UpdatedUserId = CurrentUserEntity.CurrentUserID;

                    LoanNo = CXClientWrapper.Instance.Invoke<ILOMSVE00078, string>(x => x.Save_PersonalGuarantee(land_BuildingDto, personal_guaranteeDto, farmLIDto, farmLoanPenalFeeDto, farmLoanDto, BranchCode));

                }

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    CXUIMessageUtilities.ShowMessageByCode("ME90000");      //Saving Error
                    this.view.isSaveValidate = false;
                }
                else
                {
                    this.view.LoanNo = LoanNo;
                    this.view.isActive = false;
                    this.view.isSaveValidate = false;
                    if (this.view.FormName.Contains("Entry"))
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MI90001");      //Saving Successful.
                    }
                    else
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MI90002");      //Updating Successful.
                    }
                    
                    this.view.GetFormControlSetting();
                    this.view.ClearFormControls();
                    this.view.ClearFormControlsForAgriLoan();
                    this.view.ClearFormControlsForLSLoan();
                }
            }
            catch (Exception ex)
            {
                CXUIMessageUtilities.ShowMessageByCode("ME90000");      //Saving Error
            }
        }

        public void BindFarmLoanInfo()
        {
            LOMDTO00078 loanInfo = CXClientWrapper.Instance.Invoke<ILOMSVE00078, LOMDTO00078>(x => x.SelectFarmLoanInfoByLnoAndSourceBr(this.View.LoanNo, CurrentUserEntity.BranchCode));
            if (loanInfo == null || CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
            {
                string code = CXClientWrapper.Instance.ServiceResult.MessageCode;

                if (code == "MV90069") CXUIMessageUtilities.ShowMessageByCode(code, loanInfo.AcctNo);    //Invalid Loan No.
                else CXUIMessageUtilities.ShowMessageByCode(code);    //Invalid Loan No.

                this.SetFocus("txtLoanNo");
            }
            else
            {
                this.view.BindCommonFarmLoanToView(loanInfo);
                bool isEnable;
                if (this.view.FormName.Contains("Enquiry"))
                {
                    isEnable = false;
                    this.view.SetEnableDisableLoanTypePanel(isEnable);
                    switch (loanInfo.LoanType)
                    {
                        case "111":
                            this.BindLand_Building(loanInfo); this.view.SelectTab("land", isEnable);
                            break;
                        case "112":
                            this.BindLand_Building(loanInfo); this.view.SelectTab("land", isEnable);
                            this.BindPer_Guarantee(loanInfo); this.view.SelectTab("per", isEnable);
                            break;
                    }
                }
                else
                {
                    isEnable = true;
                    this.view.SetEnableDisableLoanTypePanel(isEnable);
                    switch (loanInfo.LoanType)
                    {
                        case "111":
                            this.BindLand_Building(loanInfo); this.view.SelectTab("land", isEnable);
                            break;
                        case "112":
                            this.BindLand_Building(loanInfo); this.view.SelectTab("land", isEnable);
                            this.BindPer_Guarantee(loanInfo); this.view.SelectTab("per", isEnable);
                            break;
                    }
                    this.SetEnableDisable("txtLoanNo", false);
                    this.SetEnableDisable("mtxtAccountNo", false);
                    this.SetEnableDisable("cboCurrency", false);
                    this.SetEnableDisable("cboTypeOfLoan", false);
                }
            }
        }        

        public void BindLand_Building(LOMDTO00078 loanDto)
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
            this.view.AddressInLB  = loanDto.Land_buildingDto.Address;
            //this.view.HistoryOfLand_Building = loanDto.Land_buildingDto.HISLB;
            //this.view.BuildingConstructionPermit = loanDto.Land_buildingDto.BPERMIT;
            this.view.TypeOfInsurance = loanDto.Land_buildingDto.IsType;
            this.view.DateOfInsurance = Convert.ToDateTime(loanDto.Land_buildingDto.IsDate);
            this.view.InsuranceAmount = Convert.ToDecimal(loanDto.Land_buildingDto.IsAMT);

        }

        public void BindPer_Guarantee(LOMDTO00078 loanDto)
        {
            this.view.GuarantorAccountNo1 = loanDto.Per_guaranteeDto.AcctNo1;
            this.view.GuarantorName1 = loanDto.Per_guaranteeDto.Name1;
            this.view.GuarantorNrc1 = loanDto.Per_guaranteeDto.NRC1;
            this.view.GuarantorPhone1 = loanDto.Per_guaranteeDto.Phone1;

            this.view.GuarantorAccountNo2 = loanDto.Per_guaranteeDto.AcctNo2;
            this.view.GuarantorName2 = loanDto.Per_guaranteeDto.Name2;
            this.view.GuarantorNrc2 = loanDto.Per_guaranteeDto.NRC2;
            this.view.GuarantorPhone2 = loanDto.Per_guaranteeDto.Phone2;
        }

        public string SelectUMDespByUMCode(string umCode)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00073, string>(x => x.SelectUMByUMCode(umCode));
        }
        #endregion
    }
}
