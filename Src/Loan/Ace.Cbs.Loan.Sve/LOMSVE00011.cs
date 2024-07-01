//----------------------------------------------------------------------
// <copyright file="LOMSVE00011.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Haymar</CreatedUser>
// <CreatedDate>13/01/2015</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Core.Ctr;
using Ace.Windows.Core.DataModel;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Tcm.Ctr.Dao;

using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Loan.Sve
{
    /// <summary>
    /// Loan Registeration Service
    /// </summary>
    public class LOMSVE00011 : BaseService, ILOMSVE00011
    {

        #region Constructor
        LOMSVE00011()
        {
            budget = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);
        }
        #endregion

        #region Properties

        public ICXSVE00002 CodeGenerator { get; set; }
        private ILOMDAO00015 land_bldDAO;
        public ILOMDAO00015 Land_BldDAO
        {
            get { return this.land_bldDAO; }
            set { this.land_bldDAO = value; }
        }

        private ILOMDAO00012 penalFeeDAO;
        public ILOMDAO00012 PenalFeeDAO
        {
            get { return this.penalFeeDAO; }
            set { this.penalFeeDAO = value; }
        }

        private ILOMDAO00016 pledgeDAO;
        public ILOMDAO00016 PledgeDAO
        {
            get { return this.pledgeDAO; }
            set { this.pledgeDAO = value; }
        }

        private ILOMDAO00019 gjKindDAO;
        public ILOMDAO00019 GJKindDAO
        {
            get { return this.gjKindDAO; }
            set { this.gjKindDAO = value; }
        }

        private ILOMDAO00018 gJTindDAO;
        public ILOMDAO00018 GJTypeDAO
        {
            get { return this.gJTindDAO; }
            set { this.gJTindDAO = value; }
        }

        private ILOMDAO00017 hypothecationDAO;
        public ILOMDAO00017 HypothecationDAO
        {
            get { return this.hypothecationDAO; }
            set { this.hypothecationDAO = value; }
        }

        private ITLMDAO00018 loanDAO;
        public ITLMDAO00018 LoanDAO
        {
            get { return this.loanDAO; }
            set { this.loanDAO = value; }
        }

        private IPFMDAO00028 cledgerDAO;
        public IPFMDAO00028 CledgerDAO
        {
            get { return this.cledgerDAO; }
            set { this.cledgerDAO = value; }
        }

        private IPFMDAO00039 pGDAO;
        public IPFMDAO00039 PGDAO
        {
            get { return this.pGDAO; }
            set { this.pGDAO = value; }
        }

        private IMNMDAO00027 schargeDAO;
        public IMNMDAO00027 SChargeDAO
        {
            get { return this.schargeDAO; }
            set { this.schargeDAO = value; }
        }

        private IMNMDAO00008 oiDAO;
        public IMNMDAO00008 OiDAO
        {
            get { return this.oiDAO; }
            set { this.oiDAO = value; }
        }

        private IMNMDAO00011 commitFeeDAO;
        public IMNMDAO00011 CommitFeeDAO
        {
            get { return this.commitFeeDAO; }
            set { this.commitFeeDAO = value; }
        }

        private ITCMDAO00002 serviceChargeDAO;
        public ITCMDAO00002 ServiceChargeDAO
        {
            get { return this.serviceChargeDAO; }
            set { this.serviceChargeDAO = value; }
        }

        private IMNMDAO00017 liDAO;
        public IMNMDAO00017 LiDAO
        {
            get { return this.liDAO; }
            set { this.liDAO = value; }
        }

        private ICXDAO00006 accountDAO;
        public ICXDAO00006 AccountDAO
        {
            get { return this.accountDAO; }
            set { this.accountDAO = value; }
        }

        private ILOMDAO00401 outstandLoanBalanceDAO;
        public ILOMDAO00401 OutstandLoanBalanceDAO
        {
            get { return this.outstandLoanBalanceDAO; }
            set { this.outstandLoanBalanceDAO = value; }
        }

        private ILOMDAO00404 loanBTypeDAO;
        public ILOMDAO00404 LoanBTypeDAO
        {
            get { return this.loanBTypeDAO; }
            set { this.loanBTypeDAO = value; }
        }
        public string lno { get; set; }
        public string acctno { get; set; }
        public string acsign { get; set; }
        public string actype { get; set; }
        public string budget { get; set; }
        public string currency { get; set; }
        public string sourceBr { get; set; }
        public string budget2 { get; set; }
        public int[] idArr { get; set; }
        private int NoOfGJKind { get; set; }
        private int NoOfGJType { get; set; }
        #endregion

        #region variables

        string Month;
        public int NoOfDays;
        string loanNo;
        public decimal Interest;

        #endregion

        #region Logical Methods

        #region Saving Methods
        //public string returnMonthNumber(string MonthName)
        //{
        //    if (MonthName == "01")
        //        return Month = 
        //    return Month;
        //}

        //[Transaction(TransactionPropagation.Required)]
        public string Save_LandandBuilding(LOMDTO00015 land_BuildingDto, LOMDTO00021 liList, TLMDTO00018 loanDto, IList<LOMDTO00012> penalFeeList, string sourceBranch)
        {
            try
            {
                sourceBr = loanDto.SourceBranchCode;
                acsign = loanDto.ACSign;
                lno = loanDto.Lno;
                string AcnoName = "";
                #region to get difference loans account
                //if (loanDto.AType == "LOANS")
                //{
                //    AcnoName = loanDto.Loans_Type + "LOANS";
                //}
                //else if (loanDto.AType == "OVERDRAFT")
                //{
                //    AcnoName = loanDto.Loans_Type + loanDto.AType;
                //}
                #endregion
                if (loanDto.AType == "LOANS")
                {
                    AcnoName =  "LOANS";
                }
                else if (loanDto.AType == "OVERDRAFT")
                {
                    AcnoName = loanDto.AType;
                }
                DateTime today = DateTime.Today;

                #region ***Save***
                if (loanDto.status.Contains("save"))
                {
                    Interest = Convert.ToDecimal(liList.IntRate);
                    if (loanDto.AType == "LOANS")
                    {
                        loanNo = this.CodeGenerator.GetGenerateCode("BusinessLoanNo", string.Empty, loanDto.CreatedUserId, sourceBranch, new object[] { sourceBranch });
                    }
                    else if (loanDto.AType == "OVERDRAFT")
                    {
                        loanNo = this.CodeGenerator.GetGenerateCode("OverDraftRegistration", string.Empty, loanDto.CreatedUserId, sourceBranch, new object[] { sourceBranch });
                    }
                    //loanNo = this.CodeGenerator.GetGenerateCode("BusinessLoanNo", string.Empty, loanDto.CreatedUserId, CurrentUserEntity.BranchCode, new object[] { loanDto.SourceBranchCode });

                    //string CoaSetupLoanACode = CXCOM00010.Instance.GetCoaSetupAccountNo(AcnoName, sourceBranch); //// For Acode From Coasetup eg.ABK002
                    //loanDto.RelatedGLACode = CoaSetupLoanACode;

                    loanDto.Lno = loanNo.ToString();
                    land_BuildingDto.LNo = loanNo.ToString();
                    this.loanDAO.Save(this.GetLoanORM(loanDto));

                    this.land_bldDAO.Save(this.GetLand_BuildingORM(land_BuildingDto));

                    LOMDTO00401 outLoansBalDTO= new LOMDTO00401();
                    outLoansBalDTO.LNo= lno;
                    outLoansBalDTO.AccountNo = loanDto.AccountNo;
                    outLoansBalDTO.CurrentSanAmt = loanDto.SAmount;
                    outLoansBalDTO.CreatedDate = loanDto.CreatedDate;
                    outLoansBalDTO.CreatedUserId = loanDto.CreatedUserId;
                    this.outstandLoanBalanceDAO.Save(this.GetOutstandingLoansBalanceORM(outLoansBalDTO));

                    if (loanDto.AType.Contains("LOANS"))
                    {
                        this.liDAO.Save(this.GetLiORM(liList));
                        //}
                        if (!this.CledgerDAO.UpdateLoansCountForLoan(sourceBranch, loanDto.AccountNo, loanDto.CreatedUserId, loanDto.CreatedDate))
                            this.ServiceResult.ErrorOccurred = true;

                        //if (!this.CledgerDAO.UpdateLoansCountAndAmountForLoan(sourceBranch, loanDto.AccountNo, loanDto.CreatedUserId, loanDto.CreatedDate,Convert.ToDecimal(loanDto.FirstSAmount)))
                        //    this.ServiceResult.ErrorOccurred = true;
                    }
                    else
                    {
                        this.oiDAO.Save(this.GetOiORM(loanDto));
                        if (!this.CledgerDAO.UpdateLoansCountForOD(sourceBranch, loanDto.AccountNo, loanDto.CreatedUserId, loanDto.CreatedDate, Convert.ToDecimal(loanDto.IntRate), Convert.ToDecimal(loanDto.FirstSAmount)))
                            this.ServiceResult.ErrorOccurred = true;
                    }


                    #region ServiceCharges For LOAN and OD

                    if (loanDto.isScharge && loanDto.AType.Contains("LOANS"))

                        this.schargeDAO.Save(this.GetSChargeORM(liList));

                    else if (loanDto.isScharge && loanDto.AType.Contains("OVERDRAFT"))  //if user check serviceCharges checkbox in UI              
                    {
                        this.GetServiceChargesForOD(loanDto);
                    }

                    #endregion

                    if (loanDto.isPFcharge && penalFeeList.Count > 0)
                    {
                        foreach (LOMDTO00012 penalFeeDto in penalFeeList)
                        {
                            penalFeeDto.Lno = loanNo;
                            this.PenalFeeDAO.Save(this.GetPenalFeeORM(penalFeeDto));
                        }
                    }
                }

                #endregion

                #region  ***Update***
                else
                {
                    this.loanDAO.UpdateLoanInfoByLoanNoAndSourceBr(loanDto);
                    this.land_bldDAO.UpdateLand_BuildingInfoByLoanNoAndSourceBr(land_BuildingDto);

                    //if (loanDto.AType.Contains("LOANS"))
                    //{
                    //    foreach (LOMDTO00021 liDto in liList)
                    //    {
                    //        this.liDAO.Update_LI_InfoByLoanNoAndSourceBr(liDto);
                    //    }

                    //    if (!this.CledgerDAO.UpdateLoansCountForLoan(sourceBranch, loanDto.AccountNo, loanDto.CreatedUserId, loanDto.CreatedDate))
                    //        this.ServiceResult.ErrorOccurred = true;
                    //}
                    //else
                    //{
                    //    this.oiDAO.Update_OI_InfoByLoanNoAndSourceBr(loanDto);
                    //    if (!this.CledgerDAO.UpdateLoansCountForOD(sourceBranch, loanDto.AccountNo, loanDto.CreatedUserId, loanDto.CreatedDate, Convert.ToDecimal(loanDto.IntRate), Convert.ToDecimal(loanDto.FirstSAmount)))
                    //        this.ServiceResult.ErrorOccurred = true;
                    //}


                    #region ServiceCharges For LOAN and OD

                    if (loanDto.isScharge && loanDto.AType.Contains("LOANS"))
                    {
                        //this.schargeDAO.Save(this.GetSChargeORM(liList));
                    }

                    else if (loanDto.isScharge && loanDto.AType.Contains("OVERDRAFT"))  //if user check serviceCharges checkbox in UI              
                    {
                        this.GetServiceChargesForOD(loanDto);
                    }

                    #endregion

                    if (loanDto.isPFcharge && penalFeeList.Count > 0)
                    {
                        foreach (LOMDTO00012 penalFeeDto in penalFeeList)
                        {
                            this.PenalFeeDAO.Save(this.GetPenalFeeORM(penalFeeDto));
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
        public string Save_PersonalGuarantee(PFMDTO00039 personal_GuaranteeDto, LOMDTO00021 liList, TLMDTO00018 loanDto, IList<LOMDTO00012> penalFeeList, string sourceBranch)
        {
            try
            {
                sourceBr = loanDto.SourceBranchCode.Trim();
                acsign = loanDto.ACSign;
                lno = loanDto.Lno;
                string AcnoName = "";
                #region to get difference loans account
                //if (loanDto.AType == "LOANS")
                //{
                //    AcnoName = loanDto.Loans_Type + "LOANS";
                //}
                //else if (loanDto.AType == "OVERDRAFT")
                //{
                //    AcnoName = loanDto.Loans_Type + loanDto.AType;
                //}
                #endregion
                if (loanDto.AType == "LOANS")
                {
                    AcnoName = "LOANS";
                }
                else if (loanDto.AType == "OVERDRAFT")
                {
                    AcnoName = loanDto.AType;
                }

                #region ***Save***
                if (loanDto.status.Contains("save"))
                {
                    Interest = Convert.ToDecimal(liList.IntRate);
                    sourceBranch = loanDto.SourceBranchCode.Trim();
                    if (loanDto.AType == "LOANS")
                    {
                        loanNo = this.CodeGenerator.GetGenerateCode("BusinessLoanNo", "BusinessLoanNo", 1, sourceBranch, new object[] { sourceBranch });
                    }
                    else if (loanDto.AType == "OVERDRAFT")
                    {
                        loanNo = this.CodeGenerator.GetGenerateCode("OverDraftRegistration", string.Empty, loanDto.CreatedUserId, sourceBranch, new object[] { sourceBranch });
                    }
                    //string CoaSetupLoanACode = CXCOM00010.Instance.GetCoaSetupAccountNo(AcnoName, sourceBranch); //// For Acode From Coasetup eg.ABK002
                    //loanDto.RelatedGLACode = CoaSetupLoanACode;

                    loanDto.Lno = loanNo.ToString();
                    personal_GuaranteeDto.LNo = loanNo.ToString();

                    this.loanDAO.Save(this.GetLoanORM(loanDto));
                    this.pGDAO.Save(this.GetPersonal_GuaranteeORM(personal_GuaranteeDto));

                    LOMDTO00401 outLoansBalDTO = new LOMDTO00401();
                    outLoansBalDTO.LNo = lno;
                    outLoansBalDTO.AccountNo = loanDto.AccountNo;
                    outLoansBalDTO.CurrentSanAmt = loanDto.SAmount;
                    outLoansBalDTO.CreatedDate = loanDto.CreatedDate;
                    outLoansBalDTO.CreatedUserId = loanDto.CreatedUserId;
                    LOMORM00401 entity = this.GetOutstandingLoansBalanceORM(outLoansBalDTO);
                    this.outstandLoanBalanceDAO.Save(entity);

                    if (loanDto.AType.Contains("LOANS"))
                    {
                        liList.LNo = loanNo.ToString();
                        this.liDAO.Save(this.GetLiORM(liList));
                        //}
                        if (!this.CledgerDAO.UpdateLoansCountForLoan(sourceBranch, loanDto.AccountNo, loanDto.CreatedUserId, loanDto.CreatedDate))
                            this.ServiceResult.ErrorOccurred = true;

                    }
                    else
                    {
                        this.oiDAO.Save(this.GetOiORM(loanDto));
                        if (!this.CledgerDAO.UpdateLoansCountForOD(sourceBranch, loanDto.AccountNo, loanDto.CreatedUserId, loanDto.CreatedDate, Convert.ToDecimal(loanDto.IntRate), Convert.ToDecimal(loanDto.FirstSAmount)))
                            this.ServiceResult.ErrorOccurred = true;
                    }

                    #region ServiceCharges For LOAN and OD

                    if (loanDto.isScharge && loanDto.AType.Contains("LOANS"))
                        this.schargeDAO.Save(this.GetSChargeORM(liList));

                    else if (loanDto.isScharge && loanDto.AType.Contains("OVERDRAFT"))  //if user check serviceCharges checkbox in UI              
                    {
                        this.GetServiceChargesForOD(loanDto);
                    }

                    #endregion

                    if (loanDto.isPFcharge && penalFeeList.Count > 0)
                    {
                        foreach (LOMDTO00012 penalFeeDto in penalFeeList)
                        {
                            penalFeeDto.Lno = lno.ToString();
                            this.PenalFeeDAO.Save(this.GetPenalFeeORM(penalFeeDto));
                        }
                    }
                }
                #endregion

                #region  ***Update***
                else
                {
                    this.loanDAO.UpdateLoanInfoByLoanNoAndSourceBr(loanDto);
                    this.pGDAO.UpdatePer_GuaranteeInfoByLoanNoAndSourceBr(personal_GuaranteeDto);

                   
                    #region ServiceCharges For LOAN and OD

                    if (loanDto.isScharge && loanDto.AType.Contains("LOANS"))
                    {
                        //this.schargeDAO.Save(this.GetSChargeORM(liList));
                    }

                    else if (loanDto.isScharge && loanDto.AType.Contains("OVERDRAFT"))  //if user check serviceCharges checkbox in UI              
                    {
                        this.GetServiceChargesForOD(loanDto);
                    }

                    #endregion

                    if (loanDto.isPFcharge && penalFeeList.Count > 0)
                    {
                        foreach (LOMDTO00012 penalFeeDto in penalFeeList)
                        {
                            this.PenalFeeDAO.Save(this.GetPenalFeeORM(penalFeeDto));
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
        public string Save_Pledge(IList<LOMDTO00016> pledgeDtoList, LOMDTO00021 liList, TLMDTO00018 loanDto, IList<LOMDTO00012> penalFeeList, string sourceBranch)
        {
            try
            {
                sourceBr = loanDto.SourceBranchCode;
                acsign = loanDto.ACSign;
                lno = loanDto.Lno;
                string AcnoName = "";
                double cBal = 0;
                #region to get difference loans account
                //if (loanDto.AType == "LOANS")
                //{
                //    AcnoName = loanDto.Loans_Type + "LOANS";
                //}
                //else if (loanDto.AType == "OVERDRAFT")
                //{
                //    AcnoName = loanDto.Loans_Type + loanDto.AType;
                //}
                #endregion
                if (loanDto.AType == "LOANS")
                {
                    AcnoName = "LOANS";
                }
                else if (loanDto.AType == "OVERDRAFT")
                {
                    AcnoName = loanDto.AType;
                }
                #region ***Save***

                if (loanDto.status.Contains("save"))
                {
                    Interest = Convert.ToDecimal(liList.IntRate);
                    //cBal = cledgerDAO.;
                    if (loanDto.AType == "LOANS")
                    {
                        loanNo = this.CodeGenerator.GetGenerateCode("BusinessLoanNo", string.Empty, loanDto.CreatedUserId, sourceBranch, new object[] { sourceBranch });
                    }
                    else if (loanDto.AType == "OVERDRAFT")
                    {
                        loanNo = this.CodeGenerator.GetGenerateCode("OverDraftRegistration", string.Empty, loanDto.CreatedUserId, sourceBranch, new object[] { sourceBranch });
                    }
                    //string CoaSetupLoanACode = CXCOM00010.Instance.GetCoaSetupAccountNo(AcnoName, sourceBranch); //// For Acode From Coasetup eg.ABK002
                    //loanDto.RelatedGLACode = CoaSetupLoanACode;

                    loanDto.Lno = loanNo;
                    this.loanDAO.Save(this.GetLoanORM(loanDto));
                    loanDto.Lno = loanNo.ToString();

                    foreach (LOMDTO00016 pledgeDto in pledgeDtoList)
                    {
                        pledgeDto.LNo = loanDto.Lno;
                        pledgeDto.UpdatedDate = loanDto.UpdatedDate;
                        pledgeDto.UpdatedUserId = loanDto.UpdatedUserId;
                        this.PledgeDAO.Save(this.GetPledgeORM(pledgeDto));
                    }

                    LOMDTO00401 outLoansBalDTO = new LOMDTO00401();
                    outLoansBalDTO.LNo = lno;
                    outLoansBalDTO.AccountNo = loanDto.AccountNo;
                    outLoansBalDTO.CurrentSanAmt = loanDto.SAmount;
                    outLoansBalDTO.CreatedDate = loanDto.CreatedDate;
                    outLoansBalDTO.CreatedUserId = loanDto.CreatedUserId;
                    this.outstandLoanBalanceDAO.Save(this.GetOutstandingLoansBalanceORM(outLoansBalDTO));

                    if (loanDto.AType.Contains("LOANS"))
                    {
                        liList.LNo = loanNo.ToString();
                        this.liDAO.Save(this.GetLiORM(liList));
                        if (!this.CledgerDAO.UpdateLoansCountForLoan(sourceBranch, loanDto.AccountNo, loanDto.CreatedUserId, loanDto.CreatedDate))
                            this.ServiceResult.ErrorOccurred = true;
                    }
                    else
                    {
                        this.oiDAO.Save(this.GetOiORM(loanDto));
                        if (!this.CledgerDAO.UpdateLoansCountForOD(sourceBranch, loanDto.AccountNo, loanDto.CreatedUserId, loanDto.CreatedDate, Convert.ToDecimal(loanDto.IntRate), Convert.ToDecimal(loanDto.FirstSAmount)))
                            this.ServiceResult.ErrorOccurred = true;
                    }

                    #region ServiceCharges For LOAN and OD

                    if (loanDto.isScharge && loanDto.AType.Contains("LOANS"))
                        this.schargeDAO.Save(this.GetSChargeORM(liList));

                    else if (loanDto.isScharge && loanDto.AType.Contains("OVERDRAFT"))  //if user check serviceCharges checkbox in UI              
                    {
                        this.GetServiceChargesForOD(loanDto);
                    }

                    #endregion

                    if (loanDto.isPFcharge && penalFeeList.Count > 0)
                    {
                        foreach (LOMDTO00012 penalFeeDto in penalFeeList)
                        {
                            this.PenalFeeDAO.Save(this.GetPenalFeeORM(penalFeeDto));
                        }
                    }
                }
                #endregion

                #region  ***Update***
                else
                {
                    this.loanDAO.UpdateLoanInfoByLoanNoAndSourceBr(loanDto);

                    //select old data(id) to Update 
                    IList<LOMDTO00016> pledgeList = new List<LOMDTO00016>();
                    pledgeList = this.pledgeDAO.SelectPledgeInfoByLoanNoandSourcebr(lno, sourceBr);

                    //Insert new stock Info
                    foreach (LOMDTO00016 pledgeDto in pledgeDtoList)
                    {

                        this.PledgeDAO.Save(this.GetPledgeORM(pledgeDto));
                    }

                    //Delete old stock info..................
                    foreach (LOMDTO00016 pledgeDto in pledgeList)
                        this.PledgeDAO.UpdatePledgeInfoByLoanNoAndSourceBr(pledgeDto.Id, loanDto.Lno, sourceBranch);


                    #region ServiceCharges For LOAN and OD

                    //if (loanDto.isScharge && loanDto.AType.Contains("LOANS"))
                    //    this.schargeDAO.Save(this.GetSChargeORM(liList));

                    //else if (loanDto.isScharge && loanDto.AType.Contains("OVERDRAFT"))  //if user check serviceCharges checkbox in UI              
                    //{
                    //    this.GetServiceChargesForOD(loanDto);
                    //}

                    #endregion

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
        public string Save_Hypothecation(LOMDTO00017 hypothecationDto, LOMDTO00021 liList, TLMDTO00018 loanDto, IList<LOMDTO00012> penalFeeList, string sourceBranch)
        {
            try
            {
                sourceBr = loanDto.SourceBranchCode;
                acsign = loanDto.ACSign;
                lno = loanDto.Lno;
                string AcnoName = "";
                #region to get difference loans account
                //if (loanDto.AType == "LOANS")
                //{
                //    AcnoName = loanDto.Loans_Type + "LOANS";
                //}
                //else if (loanDto.AType == "OVERDRAFT")
                //{
                //    AcnoName = loanDto.Loans_Type + loanDto.AType;
                //}
                #endregion
                if (loanDto.AType == "LOANS")
                {
                    AcnoName = "LOANS";
                }
                else if (loanDto.AType == "OVERDRAFT")
                {
                    AcnoName = loanDto.AType;
                }

                #region ***Save***
                if (loanDto.status.Contains("save"))
                {
                    Interest = Convert.ToDecimal(liList.IntRate);
                    if (loanDto.AType == "LOANS")
                    {
                        loanNo = this.CodeGenerator.GetGenerateCode("BusinessLoanNo", string.Empty, loanDto.CreatedUserId, sourceBranch, new object[] { sourceBranch });
                    }
                    else if (loanDto.AType == "OVERDRAFT")
                    {
                        loanNo = this.CodeGenerator.GetGenerateCode("OverDraftRegistration", string.Empty, loanDto.CreatedUserId, sourceBranch, new object[] { sourceBranch });
                    }
                    //string CoaSetupLoanACode = CXCOM00010.Instance.GetCoaSetupAccountNo(AcnoName, sourceBranch); //// For Acode From Coasetup eg.ABK002
                    //loanDto.RelatedGLACode = CoaSetupLoanACode;

                    loanDto.Lno = loanNo.ToString();
                    hypothecationDto.LNo = loanDto.Lno;
                    this.loanDAO.Save(this.GetLoanORM(loanDto));
                    this.HypothecationDAO.Save(this.GetHypothecationORM(hypothecationDto));

                    LOMDTO00401 outLoansBalDTO = new LOMDTO00401();
                    outLoansBalDTO.LNo = lno;
                    outLoansBalDTO.AccountNo = loanDto.AccountNo;
                    outLoansBalDTO.CurrentSanAmt = loanDto.SAmount;
                    outLoansBalDTO.CreatedDate = loanDto.CreatedDate;
                    outLoansBalDTO.CreatedUserId = loanDto.CreatedUserId;
                    this.outstandLoanBalanceDAO.Save(this.GetOutstandingLoansBalanceORM(outLoansBalDTO));


                    if (loanDto.AType.Contains("LOANS"))
                    {                        liList.LNo = loanNo.ToString();
                        this.liDAO.Save(this.GetLiORM(liList));
                        if (!this.CledgerDAO.UpdateLoansCountForLoan(sourceBranch, loanDto.AccountNo, loanDto.CreatedUserId, loanDto.CreatedDate))
                            this.ServiceResult.ErrorOccurred = true;
                        //if (!this.CledgerDAO.UpdateLoansCountAndAmountForLoan(sourceBranch, loanDto.AccountNo, loanDto.CreatedUserId, loanDto.CreatedDate, Convert.ToDecimal(loanDto.FirstSAmount)))
                        //    this.ServiceResult.ErrorOccurred = true;
                    }
                    else
                    {
                        this.oiDAO.Save(this.GetOiORM(loanDto));
                        if (!this.CledgerDAO.UpdateLoansCountForOD(sourceBranch, loanDto.AccountNo, loanDto.CreatedUserId, loanDto.CreatedDate, Convert.ToDecimal(loanDto.IntRate), Convert.ToDecimal(loanDto.FirstSAmount)))
                            this.ServiceResult.ErrorOccurred = true;
                    }

                    #region ServiceCharges For LOAN and OD

                    if (loanDto.isScharge && loanDto.AType.Contains("LOANS"))
                        this.schargeDAO.Save(this.GetSChargeORM(liList));

                    else if (loanDto.isScharge && loanDto.AType.Contains("OVERDRAFT"))  //if user check serviceCharges checkbox in UI              
                    {
                        this.GetServiceChargesForOD(loanDto);
                    }

                    #endregion

                    if (loanDto.isPFcharge && penalFeeList.Count > 0)
                    {
                        foreach (LOMDTO00012 penalFeeDto in penalFeeList)
                        {
                            this.PenalFeeDAO.Save(this.GetPenalFeeORM(penalFeeDto));
                        }
                    }
                }
                #endregion

                #region  ***Update***
                else
                {
                    this.loanDAO.UpdateLoanInfoByLoanNoAndSourceBr(loanDto);

                    hypothecationDto.UpdatedDate = loanDto.UpdatedDate;
                    hypothecationDto.UpdatedUserId = loanDto.UpdatedUserId;
                    this.hypothecationDAO.UpdateHypothecationInfoByLoanNoAndSourceBr(hypothecationDto);

                    #region ServiceCharges For LOAN and OD

                    if (loanDto.isScharge && loanDto.AType.Contains("LOANS"))
                    {
                        //this.schargeDAO.Save(this.GetSChargeORM(liList));
                    }

                    else if (loanDto.isScharge && loanDto.AType.Contains("OVERDRAFT"))  //if user check serviceCharges checkbox in UI              
                    {
                        this.GetServiceChargesForOD(loanDto);
                    }

                    #endregion

                    if (loanDto.isPFcharge && penalFeeList.Count > 0)
                    {
                        foreach (LOMDTO00012 penalFeeDto in penalFeeList)
                        {
                            this.PenalFeeDAO.Save(this.GetPenalFeeORM(penalFeeDto));
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
        public string Save_GoldAndJewellery(IList<LOMDTO00018> gjTypeDtoList, IList<LOMDTO00018> gjKindDtoList, LOMDTO00021 liList, TLMDTO00018 loanDto, IList<LOMDTO00012> penalFeeList, string sourceBranch)
        {
            try
            {
                sourceBr = loanDto.SourceBranchCode;
                acsign = loanDto.ACSign;
                lno = loanDto.Lno;
                string AcnoName = "";
                #region to get difference loans account
                //if (loanDto.AType == "LOANS")
                //{
                //    AcnoName = loanDto.Loans_Type + "LOANS";
                //}
                //else if (loanDto.AType == "OVERDRAFT")
                //{
                //    AcnoName = loanDto.Loans_Type + loanDto.AType;
                //}
                #endregion
                if (loanDto.AType == "LOANS")
                {
                    AcnoName = "LOANS";
                }
                else if (loanDto.AType == "OVERDRAFT")
                {
                    AcnoName = loanDto.AType;
                }

                #region ***Save***
                if (loanDto.status.Contains("save"))
                {
                    Interest = Convert.ToDecimal(liList.IntRate);
                    if (loanDto.AType == "LOANS")
                    {
                        loanNo = this.CodeGenerator.GetGenerateCode("BusinessLoanNo", string.Empty, loanDto.CreatedUserId, sourceBranch, new object[] { sourceBranch });
                    }
                    else if (loanDto.AType == "OVERDRAFT")
                    {
                        loanNo = this.CodeGenerator.GetGenerateCode("OverDraftRegistration", string.Empty, loanDto.CreatedUserId, sourceBranch, new object[] { sourceBranch });
                    }
                    //string CoaSetupLoanACode = CXCOM00010.Instance.GetCoaSetupAccountNo(AcnoName, sourceBranch); //// For Acode From Coasetup eg.ABK002
                    //loanDto.RelatedGLACode = CoaSetupLoanACode;

                    loanDto.Lno = loanNo.ToString();
                    this.loanDAO.Save(this.GetLoanORM(loanDto));

                    foreach (LOMDTO00018 gjTypeDto in gjTypeDtoList)
                    {
                        gjTypeDto.LNo = loanDto.Lno;
                        gjTypeDto.UpdatedDate = loanDto.UpdatedDate;
                        gjTypeDto.UpdatedUserId = loanDto.UpdatedUserId;
                        this.GJTypeDAO.Save(this.GetGJTypeORM(gjTypeDto));
                    }

                    foreach (LOMDTO00018 gjKindDto in gjKindDtoList)
                    {
                        gjKindDto.UpdatedDate = loanDto.UpdatedDate;
                        gjKindDto.UpdatedUserId = loanDto.UpdatedUserId;
                        this.GJKindDAO.Save(this.GetGJKindORM(gjKindDto));
                    }

                    LOMDTO00401 outLoansBalDTO = new LOMDTO00401();
                    outLoansBalDTO.LNo = lno;
                    outLoansBalDTO.AccountNo = loanDto.AccountNo;
                    outLoansBalDTO.CurrentSanAmt = loanDto.SAmount;
                    outLoansBalDTO.CreatedDate = loanDto.CreatedDate;
                    outLoansBalDTO.CreatedUserId = loanDto.CreatedUserId;
                    this.outstandLoanBalanceDAO.Save(this.GetOutstandingLoansBalanceORM(outLoansBalDTO));

                    if (loanDto.AType.Contains("LOANS"))
                    {
                        liList.LNo = loanNo.ToString();
                        this.liDAO.Save(this.GetLiORM(liList));
                        //}
                        if (!this.CledgerDAO.UpdateLoansCountForLoan(sourceBranch, loanDto.AccountNo, loanDto.CreatedUserId, loanDto.CreatedDate))
                            this.ServiceResult.ErrorOccurred = true;
                        //if (!this.CledgerDAO.UpdateLoansCountAndAmountForLoan(sourceBranch, loanDto.AccountNo, loanDto.CreatedUserId, loanDto.CreatedDate, Convert.ToDecimal(loanDto.FirstSAmount)))
                        //    this.ServiceResult.ErrorOccurred = true;
                    }
                    else
                    {
                        this.oiDAO.Save(this.GetOiORM(loanDto));
                        if (!this.CledgerDAO.UpdateLoansCountForOD(sourceBranch, loanDto.AccountNo, loanDto.CreatedUserId, loanDto.CreatedDate, Convert.ToDecimal(loanDto.IntRate), Convert.ToDecimal(loanDto.FirstSAmount)))
                            this.ServiceResult.ErrorOccurred = true;
                    }

                    #region ServiceCharges For LOAN and OD

                    if (loanDto.isScharge && loanDto.AType.Contains("LOANS"))
                        this.schargeDAO.Save(this.GetSChargeORM(liList));

                    else if (loanDto.isScharge && loanDto.AType.Contains("OVERDRAFT"))  //if user check serviceCharges checkbox in UI              
                    {
                        this.GetServiceChargesForOD(loanDto);
                    }

                    #endregion

                    if (loanDto.isPFcharge && penalFeeList.Count > 0)
                    {
                        foreach (LOMDTO00012 penalFeeDto in penalFeeList)
                        {
                            this.PenalFeeDAO.Save(this.GetPenalFeeORM(penalFeeDto));
                        }
                    }
                }
                #endregion

                #region  ***Update***
                else
                {
                    this.loanDAO.UpdateLoanInfoByLoanNoAndSourceBr(loanDto);

                    //Selecting id For Update active = 0 to old data of GJKind and GJType
                    IList<LOMDTO00018> GjTypeDtoList = new List<LOMDTO00018>();
                    GjTypeDtoList = this.GJTypeDAO.SelectGoldAndJewelleryTypeInfoByLoanNoandSourcebr(lno, sourceBr);
                    IList<LOMDTO00018> GjKindDtoList = new List<LOMDTO00018>();
                    GjKindDtoList = this.GJKindDAO.SelectGoldAndJewelleryKindInfoByLoanNoandSourcebr(lno, sourceBr);

                    //Save new data to GJKind and GJType
                    foreach (LOMDTO00018 gjTypeDto in gjTypeDtoList)
                    {
                        this.GJTypeDAO.Save(this.GetGJTypeORM(gjTypeDto));
                    }

                    foreach (LOMDTO00018 gjKindDto in gjKindDtoList)
                    {
                        this.GJKindDAO.Save(this.GetGJKindORM(gjKindDto));
                    }

                    //Update Active=0  to old data in GJType and GJKind 
                    for (int i = 0; i < GjTypeDtoList.Count; i++)
                        this.GJTypeDAO.UpdateGJTInfoByLoanNoAndSourceBr(GjTypeDtoList[i].Id, lno, sourceBr);

                    for (int i = NoOfGJType; i < GjKindDtoList.Count; i++)
                        this.GJKindDAO.UpdateGJKInfoByLoanNoAndSourceBr(GjKindDtoList[i].Id, lno, sourceBr);
                                     

                    #region ServiceCharges For LOAN and OD

                    if (loanDto.isScharge && loanDto.AType.Contains("LOANS"))
                    {
                        //this.schargeDAO.Save(this.GetSChargeORM(liList));
                    }

                    else if (loanDto.isScharge && loanDto.AType.Contains("OVERDRAFT"))  //if user check serviceCharges checkbox in UI              
                    {
                        this.GetServiceChargesForOD(loanDto);
                    }

                    #endregion

                    if (loanDto.isPFcharge && penalFeeList.Count > 0)
                    {
                        foreach (LOMDTO00012 penalFeeDto in penalFeeList)
                        {
                            this.PenalFeeDAO.Save(this.GetPenalFeeORM(penalFeeDto));
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
                // Select Current Account Info , loan acctno must be current acctno...
                AccountInfoList = this.AccountDAO.GetCurrentAccountInfoByAccountNumber(acctno);
                if (AccountInfoList.Count > 0)
                {                  
                    //Close Account Checking
                    if (AccountInfoList[0].CloseDate.ToShortDateString() != "01/01/0001" && String.IsNullOrEmpty(AccountInfoList[0].CloseDate.ToShortDateString()))
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = "MV00044";//Account No has been closed.
                    }

                    ////Link Account Checking
                    //int count = this.AccountDAO.GetLinkAccountCountByCurrentAccountNo(acctno);
                    //if (count > 0)
                    //{
                    //    this.ServiceResult.ErrorOccurred = true;
                    //    this.ServiceResult.MessageCode = "MV00056"; //This Account {0} is already Link Account.
                    //}                                   
                    
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
        [Transaction(TransactionPropagation.Required)]
        public TLMDTO00018 SelectLoanInformationByLoanNoAndSourceBr(string lno, string sourcebr)
        {
            TLMDTO00018 loanDto = new TLMDTO00018();
            try
            {
                loanDto = this.LoanDAO.GetLoansAccountInformation(lno, sourcebr);

                if (loanDto == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV90055"; //Invalid Loan No.
                }
                else if (loanDto.CloseDate != null && !loanDto.CloseDate.ToString().Contains("01/01/0001"))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV90057"; //Loans No. Already Closed!
                }
                else if (String.IsNullOrEmpty(loanDto.Loans_Type))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME90048"; //Invalid Loan Type for this LoanNo.
                }
                else
                {
                    try
                    {

                        // Select Current Account Info , loan acctno must be current acctno...
                        loanDto.LoanAcctnoInfoList = this.IsValidForLoanAcctno(loanDto.AccountNo);
                        if (this.ServiceResult.ErrorOccurred)
                        {
                            return loanDto;
                        }
                        switch (loanDto.Loans_Type)
                        {
                            case "LB":
                                loanDto.Land_buildingDto = this.Land_BldDAO.SelectLand_BuildingInfoByLoanNoAndSourceBr(lno, sourcebr);
                                if (loanDto.Land_buildingDto == null) throw new Exception();

                                break;

                            case "PG":
                                loanDto.Per_guaranteeDto = this.PGDAO.SelectPersonalGuaranteeInfoByLoanNoandSourcebr(lno, sourcebr);
                                if (loanDto.Per_guaranteeDto == null) throw new Exception();

                                break;

                            case "PL":
                                loanDto.PledgeDto = this.pledgeDAO.SelectPledgeInfoByLoanNoandSourcebr(lno, sourcebr);
                                if (loanDto.PledgeDto.Count == 0) throw new Exception();
                                break;

                            case "HP":
                                loanDto.HypothecationDto = this.HypothecationDAO.SelectHypothecationInfoByLoanNoandSourcebr(lno, sourcebr);
                                if (loanDto.HypothecationDto == null) throw new Exception();
                                break;

                            case "GJ":
                                loanDto.GjTypeDtoList = this.GJTypeDAO.SelectGoldAndJewelleryTypeInfoByLoanNoandSourcebr(lno, sourcebr);
                                loanDto.GjKindDtoList = this.GJKindDAO.SelectGoldAndJewelleryKindInfoByLoanNoandSourcebr(lno, sourcebr);
                                if (loanDto.GjTypeDtoList.Count == 0) throw new Exception();
                                else if (loanDto.GjKindDtoList.Count == 0) throw new Exception();

                                #region Testing
                                //else
                                //{
                                //    this.NoOfGJKind = loanDto.GjKindDtoList.Count;
                                //    this.NoOfGJType = loanDto.GjTypeDtoList.Count;
                                //    idArr = new int[NoOfGJKind + NoOfGJType];
                                //    int i ;
                                //    //int id;
                                //    //for (i = 0 ; i < NoOfGJType; i++)
                                //    //{
                                //    //    id = loanDto.GjTypeDtoList[i].Id;
                                //    //}

                                //    //for ( i = NoOfGJType ; i < NoOfGJKind + NoOfGJType; i++)
                                //    //{
                                //    //    idArr[NoOfGJType] = loanDto.GjKindDtoList[i].Id;
                                //    //}

                                //    //do 
                                //    //{
                                //    //    foreach (LOMDTO00018 gjtDto in loanDto.GjTypeDtoList)
                                //    //        idArr[i++] = loanDto.GjTypeDtoList[i].Id;
                                //    //    foreach (LOMDTO00018 gjkDto in loanDto.GjKindDtoList)
                                //    //        idArr[i++] = loanDto.GjKindDtoList[i].Id;
                                //    //}while(NoOfGJType + NoOfGJKind)
                                //    IList<LOMDTO00018> gjList = new List<LOMDTO00018>();

                                //    foreach (LOMDTO00018 gjtDto in loanDto.GjTypeDtoList)
                                //        gjList.Add(gjtDto);
                                //    foreach (LOMDTO00018 gjkDto in loanDto.GjKindDtoList)
                                //        gjList.Add(gjkDto);

                                //    for (i = 0; i < gjList.Count; i++)
                                //    {
                                //        idArr[i] = gjList[i].Id;
                                //    }
                                //}

                                #endregion

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
                        loanDto.LiList = this.liDAO.SelectLiInfoForLoanInterest(lno, sourcebr);
                        if (loanDto.LiList.Count == 0) throw new Exception();
                    }
                    else if (loanDto.AType.Contains("OVERDRAFT"))
                    {
                        //to select loans table
                    }

                    #endregion

                    #region PenalFeed/LateFee

                    if (loanDto.isLateFee)
                    {
                        loanDto.PenalFeeList = this.PenalFeeDAO.SelectPenalFeeInfoByLoanNoandSourcebr(lno, sourcebr);
                        if (loanDto.PenalFeeList.Count == 0) throw new Exception();
                    }

                    #endregion

                }

                return loanDto;

            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90055"; //Invalid Loan No.
            }

            return loanDto;

        }
        //For voucher Added By ZMS (12-July-2018)
        [Transaction(TransactionPropagation.Required)]
        public string GetCompanyName(string acctno)
        {
            string companyName = loanBTypeDAO.SelectCompanyName(acctno);
            return companyName;
        }
        #endregion

        #endregion

        #region Helper Method

        [Transaction(TransactionPropagation.Required)]
        private void GetServiceChargesForOD(TLMDTO00018 loanDto)
        {
            //If u want serviceCharges, save commitFee,ServiceCharges and tlf(Sp_SERVICECHARGES_VOU)
            this.CommitFeeDAO.Save(this.GetCommitFeeORM(loanDto));
            this.ServiceChargeDAO.Save(this.GetServiceChargesORM(loanDto));

            string voucherNo = this.CodeGenerator.GetGenerateCode("ServiceVoucher", string.Empty, loanDto.CreatedUserId, sourceBr);

            DateTime settlementdate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("NextSettlementDate"), sourceBr, true });
            string channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);

            //Sp_SERVICECHARGES_VOU For Tlf Exchange Rate
            decimal rate = CXCOM00010.Instance.GetExchangeRate(loanDto.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType));
            PFMDTO00075 rateDto = CXCOM00011.Instance.GetScalarObject<PFMDTO00075>("RateInfo.Rate.Select", new object[] { loanDto.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType), true, loanDto.Currency, true });
            decimal servicesRate = loanDto.SAmount.Value * Convert.ToDecimal(loanDto.serviceChargesRate) / 100;
            int exRate = Convert.ToInt32(rateDto.Rate);
            string CoaSetupLsIncome = CXCOM00010.Instance.GetCoaSetupAccountNo("SCHARGENEW", sourceBr);
            // int i;
            //for (i = 1; i <= 2; i++)
            if (!CXServiceWrapper.Instance.Invoke<ICXSVE00010, bool>(x => x.Sp_SERVICECHARGES_VOU(voucherNo, loanDto.AccountNo, loanDto.Lno,
                "1 Year Service Charges", servicesRate, decimal.Zero, loanDto.UserNo, "D", false, loanDto.Currency,
                exRate, sourceBr, settlementdate, channel, true, string.Empty)))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME00018;   //Transaction is not Success!
                throw new Exception(this.ServiceResult.MessageCode);
            }

            else if (!CXServiceWrapper.Instance.Invoke<ICXSVE00010, bool>(x => x.Sp_SERVICECHARGES_VOU(voucherNo, CoaSetupLsIncome, loanDto.Lno,
                  "1 Year Service Charges", servicesRate, decimal.Zero, loanDto.UserNo, "C", false, loanDto.Currency,
                  exRate, sourceBr, settlementdate, channel, true, string.Empty)))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME00018;   //Transaction is not Success!
                throw new Exception(this.ServiceResult.MessageCode);
            }
        }

        public IList<LOMDTO00001> BindLoansBType()
        {
            IList<LOMDTO00001> LoansBType;
            LoansBType = this.loanBTypeDAO.SelectAll();
            return LoansBType;
        }
        #endregion

        #region Convert DTO To ORM

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

            land_BuildingORM.LandLeaseSDate = land_buildingDto.LandLeaseSDate;
            land_BuildingORM.LandLeaseEDate = land_buildingDto.LandLeaseEDate;
            land_BuildingORM.RemarkForLand = land_buildingDto.RemarkForLand;
            return land_BuildingORM;
        }

        private LOMORM00016 GetPledgeORM(LOMDTO00016 pledgeDto)
        {
            LOMORM00016 pledgeORM = new LOMORM00016();
            //pledgeORM.Id = PledgeDAO.SelectMaxId() + 1;
            pledgeORM.LNo = pledgeDto.LNo;
            pledgeORM.StockNo = pledgeDto.StockNo;
            pledgeORM.StockQTY = pledgeDto.StockQTY;
            pledgeORM.Market_VAL = pledgeDto.Market_VAL;
            //pledgeORM.CloseDate = pledgeDto.CloseDate;
            pledgeORM.IsType = pledgeDto.IsType;
            pledgeORM.IsDate = pledgeDto.IsDate;
            pledgeORM.IsExpiredDate = pledgeDto.IsExpiredDate;
            pledgeORM.IsAMT = pledgeDto.IsAMT;
            pledgeORM.SourceBr = pledgeDto.SourceBr;
            pledgeORM.CreatedDate = pledgeDto.CreatedDate;
            pledgeORM.CreatedUserId = pledgeDto.CreatedUserId;
            pledgeORM.UpdatedDate = pledgeDto.UpdatedDate;
            pledgeORM.UpdatedUserId = pledgeDto.UpdatedUserId;

            return pledgeORM;
        }

        private LOMORM00017 GetHypothecationORM(LOMDTO00017 hypothecationDto)
        {
            LOMORM00017 hypothecaionORM = new LOMORM00017();

            hypothecaionORM.LNo = hypothecationDto.LNo;
            hypothecaionORM.KStock = hypothecationDto.KStock;
            hypothecaionORM.Value = hypothecationDto.Value;
            hypothecaionORM.IsType = hypothecationDto.IsType;
            hypothecaionORM.IsDate = hypothecationDto.IsDate;
            hypothecaionORM.IsExpiredDate = hypothecationDto.IsExpiredDate;
            hypothecaionORM.IsAMT = hypothecationDto.IsAMT;
            hypothecaionORM.SourceBr = hypothecationDto.SourceBr;
            hypothecaionORM.CreatedDate = hypothecationDto.CreatedDate;
            hypothecaionORM.CreatedUserId = hypothecationDto.CreatedUserId;
            return hypothecaionORM;
        }

        private LOMORM00018 GetGJTypeORM(LOMDTO00018 gjTypeDto)
        {
            LOMORM00018 gjTypeORM = new LOMORM00018();

            gjTypeORM.LNo = gjTypeDto.LNo;
            gjTypeORM.GJType = gjTypeDto.GJType;
            gjTypeORM.Quantity = gjTypeDto.Quantity;
            gjTypeORM.Value = gjTypeDto.Value;
            gjTypeORM.Weight = gjTypeDto.Weight;
            gjTypeORM.SourceBr = gjTypeDto.SourceBr;
            gjTypeORM.CreatedDate = gjTypeDto.CreatedDate;
            gjTypeORM.CreatedUserId = gjTypeDto.CreatedUserId;
            gjTypeORM.UpdatedDate = gjTypeDto.UpdatedDate;
            gjTypeORM.UpdatedUserId = gjTypeDto.UpdatedUserId;
            return gjTypeORM;
        }

        private LOMORM00019 GetGJKindORM(LOMDTO00018 gjKindDto)
        {
            LOMORM00019 gjKindORM = new LOMORM00019();

            //gjKindORM.LNo = gjKindDto.LNo;
            gjKindORM.LNo = gjKindDto.LNo;
            gjKindORM.GJKind = gjKindDto.GJType;
            gjKindORM.Quantity = gjKindDto.Quantity;
            gjKindORM.SourceBr = gjKindDto.SourceBr;
            gjKindORM.CreatedDate = gjKindDto.CreatedDate;
            gjKindORM.CreatedUserId = gjKindDto.CreatedUserId;
            gjKindORM.UpdatedDate = gjKindDto.UpdatedDate;
            gjKindORM.UpdatedUserId = gjKindDto.UpdatedUserId;
            return gjKindORM;
        }

        private PFMORM00039 GetPersonal_GuaranteeORM(PFMDTO00039 personal_GuaranteeDto)
        {
            PFMORM00039 personal_GuaranteeOrm = new PFMORM00039();

            personal_GuaranteeOrm.LineNo = loanNo;
            personal_GuaranteeOrm.Address = personal_GuaranteeDto.Address;
            personal_GuaranteeOrm.AccountSignature = acsign;
            personal_GuaranteeOrm.BranchCode = personal_GuaranteeDto.BranchCode;
            personal_GuaranteeOrm.CurrencyCode = personal_GuaranteeDto.CurrencyCode;
            personal_GuaranteeOrm.AccountNo = personal_GuaranteeDto.AccountNo;
            personal_GuaranteeOrm.Name = personal_GuaranteeDto.Name;
            personal_GuaranteeOrm.NRC = personal_GuaranteeDto.NRC;
            personal_GuaranteeOrm.Phone = personal_GuaranteeDto.Phone;
            personal_GuaranteeOrm.GuarantorCompanyName = personal_GuaranteeDto.GuarantorCompanyName;
            personal_GuaranteeOrm.CreatedDate = personal_GuaranteeDto.CreatedDate;
            personal_GuaranteeOrm.CreatedUserId = personal_GuaranteeDto.CreatedUserId;

            return personal_GuaranteeOrm;
        }
        private LOMORM00401 GetOutstandingLoansBalanceORM(LOMDTO00401 oLoansBalDto)
        {
            LOMORM00401 outstandingLoansBalanceOrm = new LOMORM00401();

            outstandingLoansBalanceOrm.LNo = loanNo;
            outstandingLoansBalanceOrm.AccountNo = oLoansBalDto.AccountNo;
            outstandingLoansBalanceOrm.CurrentSanAmt = oLoansBalDto.CurrentSanAmt;
            //outstandingLoansBalanceOrm.CurrentSanDate = DateTime.Now;
            outstandingLoansBalanceOrm.TotalInt = 0;
            outstandingLoansBalanceOrm.LastInt =0;
            //outstandingLoansBalanceOrm.LastIntDate = DateTime.Now;
            //outstandingLoansBalanceOrm.IntPaidDate = DateTime.Now;
            outstandingLoansBalanceOrm.TotalLateFee = 0;
            outstandingLoansBalanceOrm.LastLateFee = 0;
            //outstandingLoansBalanceOrm.LastLatefeeDate = DateTime.Now;
            //outstandingLoansBalanceOrm.LatefeePaidDate = DateTime.Now;
            outstandingLoansBalanceOrm.TODAmt =0;
            //outstandingLoansBalanceOrm.TOD_Date = DateTime.Now;
            //outstandingLoansBalanceOrm.TODPaidDate = DateTime.Now;
            //outstandingLoansBalanceOrm.CloseDate = DateTime.Now;
            //outstandingLoansBalanceOrm.FirstDueDate = DateTime.Now;
            //outstandingLoansBalanceOrm.UniqueId = oLoansBalDto.CreatedDate;
            outstandingLoansBalanceOrm.SourceBranchCode = sourceBr;
            outstandingLoansBalanceOrm.Currency =currency;
            outstandingLoansBalanceOrm.CreatedDate = oLoansBalDto.CreatedDate;
            outstandingLoansBalanceOrm.CreatedUserId = oLoansBalDto.CreatedUserId;

            return outstandingLoansBalanceOrm;
        }
        
        private TLMORM00018 GetLoanORM(TLMDTO00018 loanDto)
        {
            TLMORM00018 loanOrm = new TLMORM00018();
            loanOrm.AccountNo = acctno = loanDto.AccountNo;
            loanOrm.Lno = lno = loanDto.Lno;
            loanOrm.AType = actype = loanDto.AType;
            loanOrm.Time = loanDto.Time;
            loanOrm.Lawer = loanDto.Lawer;
            loanOrm.Assessor = loanDto.Assessor;
            loanOrm.ExpireDate = loanDto.ExpireDate;
            loanOrm.SDate = loanDto.SDate;
            loanOrm.BType = loanDto.BType;
            loanOrm.FirstSAmount = loanDto.SAmount;
            loanOrm.DocmentationFee = loanDto.DocFee;
            if (!loanDto.AType.Contains("LOANS")) loanOrm.SAmount = loanDto.SAmount;
            else loanOrm.SAmount = 0;
            loanOrm.IntRate = loanDto.IntRate;
            loanOrm.Loans_Type = loanDto.Loans_Type;
            loanOrm.LegalCase = loanDto.LegalCase;
            loanOrm.NPLCase = loanDto.NPLCase;
            loanOrm.Vouchered = loanDto.Vouchered;
            loanOrm.ACSign = acsign = loanDto.ACSign;
            loanOrm.SourceBranchCode = sourceBr = loanDto.SourceBranchCode;
            loanOrm.Currency = currency = loanDto.Currency;
            loanOrm.UserNo = loanDto.UserNo;
            loanOrm.CreatedDate = loanDto.CreatedDate;
            loanOrm.CreatedUserId = loanDto.CreatedUserId;
            loanOrm.Charges_Status = loanDto.Charges_Status;
            loanOrm.isSCharge = loanDto.isScharge;
            loanOrm.isLateFee = loanDto.isPFcharge;
            loanOrm.BalStatus = loanDto.BalStatus;
            loanOrm.RelatedGLACode = loanDto.RelatedGLACode;
            loanOrm.PrincipleRepayOptions = loanDto.PrincipleRepayOptions;
            loanOrm.InterestRepayOptions = loanDto.InterestRepayOptions;
            loanOrm.GracePeriod = loanDto.GracePeriod;
            loanOrm.Min_Period = loanDto.Min_Period;
            if (loanDto.BalStatus.Contains("UsedBal"))
            {
                //loanOrm.IntRate = loanDto.IntRate;
                loanOrm.IntRate = Interest;
                loanOrm.UnUsedRate = loanDto.UnUsedRate;

            }
            else
            {
                //loanOrm.IntRate = loanDto.IntRate;
                loanOrm.IntRate = Interest;
                loanOrm.UsedOverRate = loanDto.UsedOverRate;
                loanOrm.UnUsedRate = loanDto.UnUsedRate;
            }
            loanOrm.ReversalStatus = 0;
            return loanOrm;
        }

        private MNMORM00017 GetLiORM(LOMDTO00021 liDto)
        {
            MNMORM00017 liOrm = new MNMORM00017();

            liOrm.Id = this.liDAO.SelectMaxId() + 1;
            liOrm.LNo = loanNo;
            //liOrm.TNo = liDto.TNo;
            liOrm.Acctno = liDto.Acctno;
            liOrm.IntRate = liDto.IntRate;
            Interest = Convert.ToDecimal(liDto.IntRate);
            //liOrm.StartDate = liDto.StartDate;
            //liOrm.EndDate = liDto.EndDate;
            liOrm.Duration = liDto.Duration;
            liOrm.Repaymentoption = liDto.Repaymentoption;
            if ((liDto.EndDate.Year > DateTime.Now.Year) || (liDto.EndDate.Year == DateTime.Now.Year && liDto.EndDate.Month > 4 && liDto.EndDate.Day > 1))
                liOrm.Budget = budget2 = CXCOM00010.Instance.GetBudgetYearForLoan(CXCOM00009.BudgetYearCode, liDto.EndDate);
            else
                liOrm.Budget = budget;
            liOrm.M1 = 0;
            liOrm.M2 = 0;
            liOrm.M3 = 0;
            liOrm.M4 = 0;
            liOrm.M5 = 0;
            liOrm.M6 = 0;
            liOrm.M7 = 0;
            liOrm.M8 = 0;
            liOrm.M9 = 0;
            liOrm.M10 = 0;
            liOrm.M11 = 0;
            liOrm.M12 = 0;
            liOrm.Q1 = 0;
            liOrm.Q2 = 0;
            liOrm.Q3 = 0;
            liOrm.Q4 = 0;
            liOrm.QBal1 = 0;
            liOrm.QBal2 = 0;
            liOrm.QBal3 = 0;
            liOrm.QBal4 = 0;
            liOrm.UserNo = liDto.UserNo;
            liOrm.ACSign = acsign;
            liOrm.ACSign = liDto.ACSign;
            liOrm.SourceBr = sourceBr;
            liOrm.Cur = currency;
            liOrm.CreatedDate = liDto.CreatedDate;
            liOrm.CreatedUserId = liDto.CreatedUserId;

            return liOrm;
        }

        private MNMORM00008 GetOiORM(TLMDTO00018 loanDto)
        {
            MNMORM00008 oiOrm = new MNMORM00008();

            oiOrm.LNo = loanDto.Lno;
            oiOrm.Acctno= loanDto.AccountNo;
            oiOrm.LastDate = loanDto.CreatedDate;
            oiOrm.ACSign = acsign;
            oiOrm.UserNo = loanDto.UserNo;
            oiOrm.SourceBr = sourceBr;
            oiOrm.Cur = loanDto.Currency;
            oiOrm.Budget = budget;
            oiOrm.CreatedDate = loanDto.CreatedDate;
            oiOrm.CreatedUserId = loanDto.CreatedUserId;

            return oiOrm;
        }

        private MNMORM00027 GetSChargeORM(LOMDTO00021 liList)
        {
            MNMORM00027 schargeOrm = new MNMORM00027();

            schargeOrm.Id = this.schargeDAO.SelectMaxId() + 1;
            // schargeOrm.LNo = liList[0].LNo;
            schargeOrm.LNo = loanNo;
            schargeOrm.Acctno = liList.Acctno;
            schargeOrm.ACSign = liList.ACSign;
            schargeOrm.AType = actype;
            schargeOrm.UserNo = liList.UserNo;
            schargeOrm.Budget = budget;
            schargeOrm.M1 = 0;
            schargeOrm.M2 = 0;
            schargeOrm.M3 = 0;
            schargeOrm.M4 = 0;
            schargeOrm.M5 = 0;
            schargeOrm.M6 = 0;
            schargeOrm.M7 = 0;
            schargeOrm.M8 = 0;
            schargeOrm.M9 = 0;
            schargeOrm.M10 = 0;
            schargeOrm.M11 = 0;
            schargeOrm.M12 = 0;
            schargeOrm.LastDate = liList.CreatedDate;
            schargeOrm.LastInt = 0;
            schargeOrm.ACSign = liList.ACSign;
            schargeOrm.SourceBr = liList.SourceBr;
            schargeOrm.Cur = currency;
            schargeOrm.CreatedDate = liList.CreatedDate;
            schargeOrm.CreatedUserId = liList.CreatedUserId;

            return schargeOrm;
        }

        private LOMORM00012 GetPenalFeeORM(LOMDTO00012 penalFeeDto)
        {
            LOMORM00012 penalFeeOrm = new LOMORM00012();

            //penalFeeOrm.Lno = penalFeeDto.Lno;
            penalFeeOrm.Lno = loanNo;
            penalFeeOrm.StartDay = penalFeeDto.StartDay;
            penalFeeOrm.EndDay = penalFeeDto.EndDay;
            penalFeeOrm.Fee = penalFeeDto.Fee;
            penalFeeOrm.Amount = penalFeeDto.Amount;
            penalFeeOrm.Duration = penalFeeDto.Duration;
            //penalFeeOrm.Status = string.Empty;
            penalFeeOrm.SourceBr = sourceBr;
            penalFeeOrm.CreatedDate = penalFeeDto.CreatedDate;
            penalFeeOrm.CreatedUserId = penalFeeDto.CreatedUserId;

            return penalFeeOrm;
        }

        private MNMORM00011 GetCommitFeeORM(TLMDTO00018 loanDto)
        {
            MNMORM00011 commitFeeOrm = new MNMORM00011();

            commitFeeOrm.Acctno = loanDto.AccountNo;
            commitFeeOrm.LNo = loanDto.Lno;
            commitFeeOrm.LastDate = loanDto.CreatedDate;
            commitFeeOrm.LastInt = loanDto.IntRate;
            commitFeeOrm.ACSign = acsign;
            commitFeeOrm.UserNo = loanDto.UserNo;
            commitFeeOrm.Budget = budget;
            commitFeeOrm.M1 = 0;
            commitFeeOrm.M2 = 0;
            commitFeeOrm.M3 = 0;
            commitFeeOrm.M4 = 0;
            commitFeeOrm.M5 = 0;
            commitFeeOrm.M6 = 0;
            commitFeeOrm.M7 = 0;
            commitFeeOrm.M8 = 0;
            commitFeeOrm.M9 = 0;
            commitFeeOrm.M10 = 0;
            commitFeeOrm.M11 = 0;
            commitFeeOrm.M12 = 0;
            commitFeeOrm.SourceBr = sourceBr;
            commitFeeOrm.Cur = currency;
            commitFeeOrm.CreatedDate = loanDto.CreatedDate;
            commitFeeOrm.CreatedUserId = loanDto.CreatedUserId;

            return commitFeeOrm;
        }

        private TCMORM00002 GetServiceChargesORM(TLMDTO00018 loanDto)
        {
            TCMORM00002 serviceChargeOrm = new TCMORM00002();
            serviceChargeOrm.Id = this.ServiceChargeDAO.SelectMaxId() + 1;
            serviceChargeOrm.LNo = loanDto.Lno;
            serviceChargeOrm.AcctNo = loanDto.AccountNo;
            serviceChargeOrm.Desp = "NEW/RENEWAL";
            serviceChargeOrm.GetColo = string.Empty;
            serviceChargeOrm.VouDate = loanDto.CreatedDate;
            serviceChargeOrm.Amount = Convert.ToDecimal(loanDto.SAmount) * Convert.ToDecimal(loanDto.serviceChargesRate) / 100;
            serviceChargeOrm.SourceBr = sourceBr;
            serviceChargeOrm.Cur = currency;
            serviceChargeOrm.CreatedDate = loanDto.CreatedDate;
            serviceChargeOrm.CreatedUserId = loanDto.CreatedUserId;

            return serviceChargeOrm;
        }

        #endregion

    }
}