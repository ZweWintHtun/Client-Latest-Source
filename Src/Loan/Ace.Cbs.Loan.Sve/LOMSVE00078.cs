using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Loan.Ctr.Dao;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00078 : BaseService, ILOMSVE00078
    {
        #region Constructor

        public LOMSVE00078()
        {
            budget = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode); 
        }

        #endregion

        #region Properties

        public ICXSVE00002 CodeGenerator { get; set; }

        private ILOMDAO00078 farmLoanDAO;
        public ILOMDAO00078 FarmLoanDAO
        {
            get { return this.farmLoanDAO; }
            set { this.farmLoanDAO = value; }
        }

        private ILOMDAO00015 land_bldDAO;
        public ILOMDAO00015 Land_BldDAO
        {
            get { return this.land_bldDAO; }
            set { this.land_bldDAO = value; }
        }

        private ILOMDAO00079 pGDAO;
        public ILOMDAO00079 PGDAO
        {
            get { return this.pGDAO; }
            set { this.pGDAO = value; }
        }

        private ILOMDAO00085 farmliDAO;
        public ILOMDAO00085 FarmLiDAO
        {
            get { return this.farmliDAO; }
            set { this.farmliDAO = value; }
        }

        private IPFMDAO00028 cledgerDAO;
        public IPFMDAO00028 CledgerDAO
        {
            get { return this.cledgerDAO; }
            set { this.cledgerDAO = value; }
        }

        private ICXDAO00006 accountDAO;
        public ICXDAO00006 AccountDAO
        {
            get { return this.accountDAO; }
            set { this.accountDAO = value; }
        }

        private ILOMDAO00300 farmLoanPenalFeeDAO;
        public ILOMDAO00300 FarmLoanPenalFeeDAO
        {
            get { return this.farmLoanPenalFeeDAO; }
            set { this.farmLoanPenalFeeDAO = value; }
        }

        public string budget { get; set; }
        public string lno { get; set; }
        public string acctno { get; set; }
        public string actype { get; set; }
        public string acsign { get; set; }
        public string sourceBr { get; set; }
        string loanNo;

        #endregion

        #region Saving Methods

        [Transaction(TransactionPropagation.Required)]
        public string Save_LandAndBuilding(LOMDTO00015 land_BuildingDto,LOMDTO00085 farmliDto,LOMDTO00300 farmLoanPenalFeeDto, LOMDTO00078 farmLoanDto,string BranchCode)
        {            
            try
            {
                sourceBr = farmLoanDto.SourceBr;
                acsign = farmLoanDto.ACSign;
                lno = farmLoanDto.Lno;

                DateTime today = DateTime.Today;

                #region ***Save***
                if (farmLoanDto.status.Contains("save"))
                {
                    loanNo = this.CodeGenerator.GetGenerateCode("FARMLOANNO", string.Empty, farmLoanDto.CreatedUserId, BranchCode, new object[] { BranchCode, farmLoanDto.LoanType });
                    farmLoanDto.Lno = loanNo.ToString();
                    farmLoanDto.Budget = this.budget;
                    land_BuildingDto.LNo = loanNo.ToString();

                    this.farmLoanDAO.Save(this.GetFarmLoanORM(farmLoanDto));

                    this.land_bldDAO.Save(this.GetLand_BuildingORM(land_BuildingDto));

                    if (farmLoanDto.AType.Contains("LOANS"))
                    {
                        farmliDto.LNo = loanNo.ToString();
                        farmliDto.Budget = this.budget;
                        this.farmliDAO.Save(this.GetFarmLiORM(farmliDto));

                        farmLoanPenalFeeDto.Lno = loanNo.ToString();
                        this.farmLoanPenalFeeDAO.Save(this.GetFarmLoanPenalFeeORM(farmLoanPenalFeeDto));

                        if (!this.CledgerDAO.UpdateLoansCountForLoan(farmLoanDto.SourceBr, farmLoanDto.AcctNo, farmLoanDto.CreatedUserId, farmLoanDto.CreatedDate))
                            this.ServiceResult.ErrorOccurred = true;
                    }
                }
                #endregion

                #region ***Update***
                else
                {
                    
                    farmLoanDto.UpdatedDate = DateTime.Now;
                    farmLoanDto.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                    if (this.FarmLoanDAO.UpdateFarmLoanByLnoAndSourceBr(farmLoanDto))
                    {
                        land_BuildingDto.UpdatedDate = DateTime.Now;
                        land_BuildingDto.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                        if (this.land_bldDAO.UpdateLand_BuildingInfoByLoanNoAndSourceBr(land_BuildingDto))
                        {
                            loanNo = farmLoanDto.Lno;
                        }
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90000";  //Saving Error.
            }
            return loanNo;
        }

        [Transaction(TransactionPropagation.Required)]
        public string Save_PersonalGuarantee(LOMDTO00015 land_BuildingDto, LOMDTO00079 personal_GuaranteeDto, LOMDTO00085 farmliDto, LOMDTO00300 farmLoanPenalFeeDto, LOMDTO00078 farmLoanDto, string BranchCode)
        {
            try
            {
                sourceBr = farmLoanDto.SourceBr;
                acsign = farmLoanDto.ACSign;
                lno = farmLoanDto.Lno;

                DateTime today = DateTime.Today;

                #region ***Save***
                if (farmLoanDto.status.Contains("save"))
                {
                    loanNo = this.CodeGenerator.GetGenerateCode("FARMLOANNO", string.Empty, farmLoanDto.CreatedUserId, BranchCode, new object[] {BranchCode, farmLoanDto.LoanType });
                    farmLoanDto.Lno = loanNo.ToString();
                    land_BuildingDto.LNo = loanNo.ToString();
                    personal_GuaranteeDto.Lno = loanNo.ToString();

                    this.farmLoanDAO.Save(this.GetFarmLoanORM(farmLoanDto));
                    this.land_bldDAO.Save(this.GetLand_BuildingORM(land_BuildingDto));
                    this.pGDAO.Save(this.GetPersonal_GuaranteeORM(personal_GuaranteeDto));

                    if (farmLoanDto.AType.Contains("LOANS"))
                    {
                        farmliDto.LNo = loanNo.ToString();
                        farmliDto.Budget = this.budget;
                        this.farmliDAO.Save(this.GetFarmLiORM(farmliDto));

                        farmLoanPenalFeeDto.Lno = loanNo.ToString();
                        this.farmLoanPenalFeeDAO.Save(this.GetFarmLoanPenalFeeORM(farmLoanPenalFeeDto));

                        if (!this.CledgerDAO.UpdateLoansCountForLoan(farmLoanDto.SourceBr, farmLoanDto.AcctNo, farmLoanDto.CreatedUserId, farmLoanDto.CreatedDate))
                            this.ServiceResult.ErrorOccurred = true;
                    }

                }
                #endregion

                #region ***Update***
                else
                {
                    farmLoanDto.UpdatedDate = DateTime.Now;
                    farmLoanDto.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                    if (this.FarmLoanDAO.UpdateFarmLoanByLnoAndSourceBr(farmLoanDto))
                    {
                        land_BuildingDto.UpdatedDate = DateTime.Now;
                        land_BuildingDto.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                        if (this.land_bldDAO.UpdateLand_BuildingInfoByLoanNoAndSourceBr(land_BuildingDto))
                        {
                            personal_GuaranteeDto.UpdatedDate = DateTime.Now;
                            personal_GuaranteeDto.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                            if (this.pGDAO.UpdatePGOfFarmLoanByLnoAndSourceBr(personal_GuaranteeDto))
                            {
                                loanNo = farmLoanDto.Lno;
                            }
                        }
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90000";  //Saving Error.
            }
            return loanNo;
        }

        #endregion

        #region Select Methods
        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00072> IsValidForLoanAcctno(string acctno)
        {
            IList<PFMDTO00072> AccountInfoList = new List<PFMDTO00072>();
            try
            {
                // Select Saving Account Info ,farm loan acctno must be saving acctno...
                AccountInfoList = this.AccountDAO.GetSavingAccountInfoByAccountNumber(acctno);

                if (AccountInfoList.Count > 0)
                {
                    //Close Account Checking
                    if (AccountInfoList[0].CloseDate.ToShortDateString() != "01/01/0001" && String.IsNullOrEmpty(AccountInfoList[0].CloseDate.ToShortDateString()))
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = "MV00044";//Account No has been closed.
                    }

                    //Link Account Checking
                    int count = this.AccountDAO.GetLinkAccountCountBySavingAccountNo(acctno);
                    if (count > 0)
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = "MV00056"; //This Account {0} is already Link Account.
                    }

                    //Legal Case Checking
                    int legalcaseCount = this.AccountDAO.GetLegalCaseFromLoansByAccountNo(acctno);
                    if (legalcaseCount > 0)
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = "MV90069"; // This AccountNo. ( {0} ) is in Legal Case ! 
                    }
                }
                else
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV00046"; //	Invalid Account No.
                }

                return AccountInfoList;
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV00058";// Invalid Current Account No.
            }

            return AccountInfoList;
        }

        public IList<LOMDTO00078> SelectByGroupNo(string groupNo)
        {
            return this.FarmLoanDAO.SelectByGroupNo(groupNo);
        }

        [Transaction(TransactionPropagation.Required)]
        public LOMDTO00078 SelectFarmLoanInfoByLnoAndSourceBr(string lno, string sourcebr)
        {
            LOMDTO00078 loanDto = new LOMDTO00078();
            try 
            {
                loanDto = this.FarmLoanDAO.GetFarmLoansByLnoAndSourceBr(lno, sourcebr);
                IList<LOMDTO00085> farmLiDto = this.FarmLiDAO.SelectFarmLiInfoByLnoAndSourceBr(lno, sourcebr);
                if (loanDto == null || farmLiDto.Count == 0)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV90055"; //Invalid Loan No.
                }
                else if (farmLiDto[0].CloseDate != null && !farmLiDto[0].CloseDate.ToString().Contains("01/01/0001"))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV90057"; //Loans No. Already Closed!
                }
                else if (String.IsNullOrEmpty(loanDto.LoanType))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME90048"; //Invalid Loan Type for this LoanNo.
                }
                else
                {
                    try
                    { 
                        // Select Saving Account Info , farm loan acctno must be saving acctno...
                        loanDto.LoanAcctnoInfoList = this.IsValidForLoanAcctno(loanDto.AcctNo);
                        if (this.ServiceResult.ErrorOccurred)
                        {
                            return loanDto;
                        }
                        switch (loanDto.LoanType)
                        {
                            case "111": //Agri Loan
                                loanDto.Land_buildingDto = this.Land_BldDAO.SelectLand_BuildingInfoByLoanNoAndSourceBr(lno, sourcebr);
                                if (loanDto.Land_buildingDto == null) throw new Exception();

                                break;

                            case "112": //Livestock Loan
                                loanDto.Land_buildingDto = this.Land_BldDAO.SelectLand_BuildingInfoByLoanNoAndSourceBr(lno, sourcebr);
                                if (loanDto.Land_buildingDto == null) throw new Exception();

                                loanDto.Per_guaranteeDto = this.PGDAO.SelectPersonalGuaranteeInfoByLoanNoandSourcebr(lno, sourcebr);
                                if (loanDto.Per_guaranteeDto == null) throw new Exception();

                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = "MV90055"; //Invalid Loan No.
                    }

                    #region Interest

                    if (String.IsNullOrEmpty(loanDto.AType)) throw new Exception();

                    if (loanDto.AType.Contains("LOANS"))
                    {
                        //IList<LOMDTO00021> lilist = new List<LOMDTO00021>();
                        loanDto.FarmLiList = this.FarmLiDAO.SelectFarmLiInfoByLnoAndSourceBr(lno, sourcebr);
                        if (loanDto.FarmLiList.Count == 0) throw new Exception();
                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90055"; //Invalid Loan No.
            }

            return loanDto;
        }

        public LOMDTO00078 isValidLoanNo(string loanNo, string sourceBr)
        {
            LOMDTO00078 farmLoanDTO = new LOMDTO00078();
            try
            {
                bool isValidLno;
                LOMDTO00085 FarmLiDto = new LOMDTO00085();

                IList<LOMDTO00085> FarmLiList = FarmLiDAO.SelectFarmLiInfoByLnoAndSourceBr(loanNo, sourceBr);
                if (FarmLiList.Count > 0)
                {
                    FarmLiDto = FarmLiList.First();
                }
                else
                {
                    FarmLiDto = null;
                }

                isValidLno = FarmLiDto != null ? true : false;
                if (isValidLno)
                {
                    farmLoanDTO = FarmLoanDAO.GetFarmLoansByLnoAndSourceBr(loanNo, sourceBr);
                    if (farmLoanDTO != null)
                    {
                        if (farmLoanDTO.AType != "LOANS")
                        {
                            this.ServiceResult.ErrorOccurred = true;
                            ServiceResult.MessageCode = "MV90085";//Loan Account Type Only.                          
                        }
                        else if (farmLoanDTO.CloseDate != null)
                        {
                            this.ServiceResult.ErrorOccurred = true;
                            ServiceResult.MessageCode = "MV90086";//Loan Account has been Closed. 
                        }
                        else
                        {
                            string monthNo = this.GetMonthNo();
                            switch (monthNo)
                            {
                                case "M1":
                                    farmLoanDTO.FirstSAmt = FarmLiDto.M1;
                                    FarmLiDto.InterestAmount = FarmLiDto.M1;
                                    break;
                                case "M2":
                                    farmLoanDTO.FirstSAmt = FarmLiDto.M2;
                                    FarmLiDto.InterestAmount = FarmLiDto.M2;
                                    break;
                                case "M3":
                                    farmLoanDTO.FirstSAmt = FarmLiDto.M3;
                                    FarmLiDto.InterestAmount = FarmLiDto.M3;
                                    break;
                                case "M4":
                                    farmLoanDTO.FirstSAmt = FarmLiDto.M4;
                                    FarmLiDto.InterestAmount = FarmLiDto.M4;
                                    break;
                                case "M5":
                                    farmLoanDTO.FirstSAmt = FarmLiDto.M5;
                                    FarmLiDto.InterestAmount = FarmLiDto.M5;
                                    break;
                                case "M6":
                                    farmLoanDTO.FirstSAmt = FarmLiDto.M6;
                                    FarmLiDto.InterestAmount = FarmLiDto.M6;
                                    break;
                                case "M7":
                                    farmLoanDTO.FirstSAmt = FarmLiDto.M7;
                                    FarmLiDto.InterestAmount = FarmLiDto.M7;
                                    break;
                                case "M8":
                                    farmLoanDTO.FirstSAmt = FarmLiDto.M8;
                                    FarmLiDto.InterestAmount = FarmLiDto.M8;
                                    break;
                                case "M9":
                                    farmLoanDTO.FirstSAmt = FarmLiDto.M9;
                                    FarmLiDto.InterestAmount = FarmLiDto.M9;
                                    break;
                                case "M10":
                                    farmLoanDTO.FirstSAmt = FarmLiDto.M10;
                                    FarmLiDto.InterestAmount = FarmLiDto.M10;
                                    break;
                                case "M11":
                                    farmLoanDTO.FirstSAmt = FarmLiDto.M11;
                                    FarmLiDto.InterestAmount = FarmLiDto.M11;
                                    break;
                                case "M12":
                                    farmLoanDTO.FirstSAmt = FarmLiDto.M12;
                                    FarmLiDto.InterestAmount = FarmLiDto.M12;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        ServiceResult.MessageCode = "MV90055";//Loan No is Valid                     
                    }
                }
                else
                {
                    this.ServiceResult.ErrorOccurred = true;

                    ServiceResult.MessageCode = "MI90067";//Loans No. not found in Interest File.                   
                    // ServiceResult.MessageCode = "MV90100";  //Invalid Account No {0} for Branch {1}.                      
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException + ex.Message);
            }
            return farmLoanDTO;
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

        #region Convert DTO To ORM

        private LOMORM00078 GetFarmLoanORM(LOMDTO00078 dto)
        {
            LOMORM00078 farmLoanOrm = new LOMORM00078();
            farmLoanOrm.AcctNo = acctno = dto.AcctNo;
            farmLoanOrm.Lno = lno = dto.Lno;
            farmLoanOrm.AType = actype = dto.AType;
            farmLoanOrm.LoanType = dto.LoanType;
            farmLoanOrm.LoanProductType = dto.LoanProductType;
            farmLoanOrm.SDate = DateTime.Now;
            farmLoanOrm.SAmt = dto.SAmt;
            farmLoanOrm.Budget = budget;
            farmLoanOrm.FirstSAmt = dto.SAmt;
            farmLoanOrm.ExpireDate = dto.ExpireDate;
            farmLoanOrm.IntRate = dto.IntRate;
            farmLoanOrm.Penalties = dto.Penalties;
            farmLoanOrm.Name = dto.Name;
            farmLoanOrm.FatherName = dto.FatherName;
            farmLoanOrm.NRC = dto.NRC;
            farmLoanOrm.Village = dto.Village;
            farmLoanOrm.Township = dto.Township;
            farmLoanOrm.Address = dto.Address;
            farmLoanOrm.FarmName = dto.FarmName;
            farmLoanOrm.LandNo = dto.LandNo;
            farmLoanOrm.LandType = dto.LandType;
            farmLoanOrm.SeasonType = dto.SeasonType;
            farmLoanOrm.BusinessType = dto.BusinessType;
            farmLoanOrm.GroupNo = dto.GroupNo;
            farmLoanOrm.StartPeriod = dto.StartPeriod;
            farmLoanOrm.EndPeriod = dto.EndPeriod;
            farmLoanOrm.WithdrawDate = dto.WithdrawDate;
            farmLoanOrm.LoanAmtPerAcre = dto.LoanAmtPerAcre;
            farmLoanOrm.TotalAcre = dto.TotalAcre;
            farmLoanOrm.FarmSignature = dto.FarmSignature;
            farmLoanOrm.Signature = dto.Signature;
            farmLoanOrm.Remark = dto.Remark;
            farmLoanOrm.ACSign = acsign = dto.ACSign;
            farmLoanOrm.UniqueId = dto.UniqueId;
            farmLoanOrm.SourceBr = dto.SourceBr;
            farmLoanOrm.Cur = dto.Cur;

            return farmLoanOrm;
        }

        private LOMORM00015 GetLand_BuildingORM(LOMDTO00015 land_buildingDto)
        {
            LOMORM00015 land_BuildingORM = new LOMORM00015();
            land_BuildingORM.LNo = land_buildingDto.LNo;
            land_BuildingORM.Tax = land_buildingDto.Tax;
            land_BuildingORM.IsAMT = land_buildingDto.IsAMT;
            land_BuildingORM.PADV = land_buildingDto.PADV;
            land_BuildingORM.Class = land_buildingDto.Class;
            land_BuildingORM.SType = land_buildingDto.SType;
            land_BuildingORM.Power = land_buildingDto.Power;
            land_BuildingORM.IsExpiredDate = land_buildingDto.IsExpiredDate;
            land_BuildingORM.SourceBr = land_buildingDto.SourceBr;
            land_BuildingORM.Cur = land_buildingDto.Cur;
            land_BuildingORM.Capital = land_buildingDto.Capital;
            land_BuildingORM.ExpYear = land_buildingDto.ExpYear;
            land_BuildingORM.EDate = land_buildingDto.EDate;
            land_BuildingORM.Char = land_buildingDto.Char;
            land_BuildingORM.GW = land_buildingDto.GW;
            land_BuildingORM.YearPB = land_buildingDto.YearPB;
            land_BuildingORM.Address = land_buildingDto.Address;
            land_BuildingORM.IsType = land_buildingDto.IsType;
            land_BuildingORM.IsDate = land_buildingDto.IsDate;
            land_BuildingORM.SDEED = land_buildingDto.SDEED;
            land_BuildingORM.LAFFID = land_buildingDto.LAFFID;
            land_BuildingORM.Land = land_buildingDto.Land;
            land_BuildingORM.HISLB = land_buildingDto.HISLB;
            land_BuildingORM.BPERMIT = land_buildingDto.BPERMIT;
            land_BuildingORM.DDate = land_buildingDto.DDate;
            land_BuildingORM.FSVBLD = land_buildingDto.FSVBLD;
            land_BuildingORM.FSVLand = land_buildingDto.FSVLand;
            land_BuildingORM.CreatedDate = land_buildingDto.CreatedDate;
            land_BuildingORM.CreatedUserId = land_buildingDto.CreatedUserId;

            return land_BuildingORM;
        }

        private LOMORM00079 GetPersonal_GuaranteeORM(LOMDTO00079 personal_GuaranteeDto)
        {
            LOMORM00079 personal_GuaranteeOrm = new LOMORM00079();

            personal_GuaranteeOrm.Lno = loanNo;
            personal_GuaranteeOrm.AcctNo1 = personal_GuaranteeDto.AcctNo1;
            personal_GuaranteeOrm.Name1 = personal_GuaranteeDto.Name1;
            personal_GuaranteeOrm.NRC1 = personal_GuaranteeDto.NRC1;
            personal_GuaranteeOrm.Phone1 = personal_GuaranteeDto.Phone1;
            personal_GuaranteeOrm.AcctNo2 = personal_GuaranteeDto.AcctNo2;
            personal_GuaranteeOrm.Name2 = personal_GuaranteeDto.Name2;
            personal_GuaranteeOrm.NRC2 = personal_GuaranteeDto.NRC2;
            personal_GuaranteeOrm.Phone2 = personal_GuaranteeDto.Phone2;
            personal_GuaranteeOrm.USERNO = personal_GuaranteeDto.USERNO;
            personal_GuaranteeOrm.SourceBr = personal_GuaranteeDto.SourceBr;
            personal_GuaranteeOrm.Cur = personal_GuaranteeDto.Cur;
            
            personal_GuaranteeOrm.CreatedDate = personal_GuaranteeDto.CreatedDate;
            personal_GuaranteeOrm.CreatedUserId = personal_GuaranteeDto.CreatedUserId;

            return personal_GuaranteeOrm;
        }

        private LOMORM00085 GetFarmLiORM(LOMDTO00085 farmLiDto)
        {
            LOMORM00085 farmliOrm = new LOMORM00085();

            // liOrm.Id = this.liDAO.SelectMaxId() + 1;
            farmliOrm.LNo = loanNo;
            farmliOrm.AcctNo = farmLiDto.AcctNo;
            farmliOrm.ACSign = acsign;
            farmliOrm.LoanProductCode = farmLiDto.LoanProductCode;
            farmliOrm.PrincipalAmount = farmLiDto.PrincipalAmount;
            farmliOrm.TotalInt = 0;
            farmliOrm.LastInt = 0;
            farmliOrm.AccuredInt = 0;
            farmliOrm.M1 = 0;
            farmliOrm.M2 = 0;
            farmliOrm.M3 = 0;
            farmliOrm.M4 = 0;
            farmliOrm.M5 = 0;
            farmliOrm.M6 = 0;
            farmliOrm.M7 = 0;
            farmliOrm.M8 = 0;
            farmliOrm.M9 = 0;
            farmliOrm.M10 = 0;
            farmliOrm.M11 = 0;
            farmliOrm.M12 = 0;
            farmliOrm.Budget = budget;
            farmliOrm.DATE_TIME = DateTime.Now;
            farmliOrm.SourceBr = sourceBr;
            farmliOrm.Cur = farmLiDto.Cur;
            farmliOrm.CreatedDate = farmLiDto.CreatedDate;
            farmliOrm.CreatedUserId = farmLiDto.CreatedUserId;

            return farmliOrm;
        }

        private LOMORM00300 GetFarmLoanPenalFeeORM(LOMDTO00300 farmLoanPenalFeeDto)
        {
            LOMORM00300 farmLoanPenalFeeOrm = new LOMORM00300();

            //farmLoanPenalFeeOrm.ID = this.farmLoanPenalFeeDAO.SelectMaxId() + 1;
            farmLoanPenalFeeOrm.Lno = loanNo;
            farmLoanPenalFeeOrm.LoanType = farmLoanPenalFeeDto.LoanType;
            farmLoanPenalFeeOrm.LoanProductType = farmLoanPenalFeeDto.LoanProductType;
            farmLoanPenalFeeOrm.DCount = 0;
            farmLoanPenalFeeOrm.Date_Time = DateTime.Now;
            farmLoanPenalFeeOrm.SAmt = farmLoanPenalFeeDto.SAmt;
            farmLoanPenalFeeOrm.FirstAmt = farmLoanPenalFeeDto.FirstAmt;
            farmLoanPenalFeeOrm.PenalFee = 0;
            farmLoanPenalFeeOrm.LastPenalFee = 0;
            farmLoanPenalFeeOrm.LastPenalDate = null;
            farmLoanPenalFeeOrm.IsCalculate = false;
            farmLoanPenalFeeOrm.ExpireDate = farmLoanPenalFeeDto.ExpireDate;
            farmLoanPenalFeeOrm.Status = null;
            farmLoanPenalFeeOrm.SourceBr = sourceBr;
            farmLoanPenalFeeOrm.CreatedDate = farmLoanPenalFeeDto.CreatedDate;
            farmLoanPenalFeeOrm.CreatedUserId = farmLoanPenalFeeDto.CreatedUserId;

            return farmLoanPenalFeeOrm;
        }

        #endregion
    }
}
