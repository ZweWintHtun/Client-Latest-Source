using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Mnm.Dmd;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;

namespace Ace.Cbs.Mnm.Sve
{
    public class MNMSVE00166 : BaseService, IMNMSVE00166
    {
        #region Properties

        public IPFMDAO00054 TlfDAO { get; set; }
        public ITLMDAO00004 IBLTlfDAO { get; set; }
        public ITLMDAO00009 DepoDenoDAO { get; set; }
        public ICXDAO00002 CommonDAO { get; set; }
        public ICXDAO00010 GenerateVoucherDAO { get; set; }
        public ICXSVE00002 CodeGenerator { get; set; }
        public ICXSVE00006 ReverSalDAO { get; set; }
        public ICXDAO00006 IBLDAO { get; set; }

        public IPFMDAO00058 PrnFileDAO { get; set; }   //added by ASDA

        IList<PFMDTO00054> ListTLFDTO;
        string GeneratedEno;
        // IList<MNMDTO00024> ListTLfCashDenoDTO = new List<MNMDTO00024>();
        #endregion

        #region Main Methods

        public IList<PFMDTO00054> Check_EntryNo_Valid(string eno, string sourceBr)
        {
            ListTLFDTO = this.TlfDAO.GetTlfInfoByEntryNo(eno, sourceBr);
            IList<TLMDTO00004> ListIBLTlfDto = null;
            string narration = "";
            string sourceCurrency = string.Empty;
            decimal chargesAmt = 0; // Charges AMount for corresponding Entry Number
            bool status = false;



            if (ListTLFDTO.Count == 0)   // Check Entryno Exist in tlf
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV00213"; //Entry No Not Found
                return null;
            }
            else if (!string.IsNullOrEmpty(ListTLFDTO[0].OrgnEno))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME30003"; //Already Reverse Voucher
                return null;
            }

            else if (ListTLFDTO[0].SettlementDate.Value.ToShortDateString() != DateTime.Now.ToShortDateString()) //Check Date
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME30002"; //Not Allow Back Date Transaction
                return null;
            }

            else // Entry No Exist
            {
                sourceCurrency = ListTLFDTO[0].SourceCurrency;
                //Check Cash Data Exist
                var CashData = from x in ListTLFDTO
                               where x.TransactionCode == "CSCREDIT"
                               || x.TransactionCode == "CSDEBIT"
                               || x.TransactionCode == "WITHDRAW"
                               || x.TransactionCode == "DEPOSIT"
                               select x;

                int i = CashData.ToList<PFMDTO00054>() == null ? 0 : CashData.ToList<PFMDTO00054>().Count;

                if (i > 0)  //Cash Data Exist
                {
                    chargesAmt = CashData.ToList<PFMDTO00054>()[0].Amount;
                    status = this.CheckAccountType(eno, sourceBr, ListTLFDTO, out ListIBLTlfDto, out narration); //Check COA Account Or Customer Account
                }

                //Check Transfer Data 
                else
                {
                    var TranData = from x in ListTLFDTO
                                   where x.TransactionCode == "TRCREDIT"
                                   || x.TransactionCode == "TRDEBIT"
                                   select x;

                    i = TranData.ToList<PFMDTO00054>() == null ? 0 : TranData.ToList<PFMDTO00054>().Count;


                    if (i > 0)// if Transfer Data Exist
                    {
                        status = this.CheckJournalVoucher(eno, sourceBr, out ListIBLTlfDto, out narration); //Check Journal Voucher Or IBL Transfer
                    }
                }

                if (status != false)
                {


                    // Check IBL transaction or not // Update by NLH
                    if (ListIBLTlfDto != null)
                        if (ListIBLTlfDto.Count > 0)
                            ListTLFDTO = ConvertIBLTLFToTLF(ListIBLTlfDto, ListTLFDTO, out chargesAmt);

                    // Check other transactions left or not
                    if (ListTLFDTO[0].GroupNo != null)
                        ListTLFDTO[0].DenoAmount = this.GetSumAmount(ListTLFDTO[0].GroupNo, sourceBr, "P") - chargesAmt;     //edited by ASDA                    

                    ListTLFDTO[0].Description = narration;
                    ListTLFDTO[0].SourceCurrency = sourceCurrency;

                    ListTLFDTO[0].TotalGroupAmount = this.SelectGroupAmountForMultipleReversal(ListTLFDTO[0].GroupNo,sourceBr);
                    return ListTLFDTO;
                }

                else
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV00213"; //Entry No Not Found
                    return null;
                }
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public string Save_Reversal(string eno, string groupNo, int currentUserId, string sourceBr, TLMDTO00015 CashDenoDTO)
        {

            try
            {
                if (string.IsNullOrEmpty(eno))
                {
                    throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
                }
                if (currentUserId == 0)
                {
                    throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
                }
                if (string.IsNullOrEmpty(sourceBr))
                {
                    throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
                }

                if (CashDenoDTO != null)
                    CashDenoDTO.WithdrawEntryStatus = "WithdrawReversal";   //added by ASDA

                ListTLFDTO = this.TlfDAO.GetTlfInfoByEntryNo(eno, sourceBr);

                if (ListTLFDTO != null)
                {
                    var isOrgnEnoNull = from x in ListTLFDTO
                                        where x.OrgnEno == null
                                        && x.DateTime.ToShortDateString() == DateTime.Now.ToShortDateString()
                                        select x;
                    int i = isOrgnEnoNull.ToList<PFMDTO00054>() == null ? 0 : isOrgnEnoNull.ToList<PFMDTO00054>().Count;

                    if (i == 0)
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = "ME30002"; //Not Allowed Back Date Transaction!
                        //return;
                        throw new Exception(this.ServiceResult.MessageCode);
                    }
                    else
                    {
                        //Check IBL Transaction or Normal Transaction
                        IList<TLMDTO00004> ListIBLTLFDTO = SelectIBLTLFByEno(eno, sourceBr);

                        if (ListIBLTLFDTO == null)//NOt IBL Transaction 
                        {
                            //Generate Normal Voucher No
                            GeneratedEno = GetGeneratedEnoLocal("Reversal Code", ListTLFDTO);

                            //Call Reversal Common Module
                            this.ReverSalDAO.MultipleTransactionReversalProcess(eno, GeneratedEno, groupNo, sourceBr, DateTime.Now, sourceBr, currentUserId, CashDenoDTO, string.Empty, true);  //8
                            if (this.ServiceResult.ErrorOccurred)
                                throw new Exception(this.ServiceResult.MessageCode);
                        }

                        else   // IBL Transaction
                        {
                            //Generate IBL Voucher
                            GeneratedEno = GetGeneratedEnoIBL(currentUserId, sourceBr, ListTLFDTO);

                            var CheckTransfer = from x in ListIBLTLFDTO
                                                where !string.IsNullOrEmpty(x.RelatedBranch)
                                                && !string.IsNullOrEmpty(x.RelatedAccount)
                                                select x;

                            int TranferExist = CheckTransfer.ToList<TLMDTO00004>() == null ? 0 : CheckTransfer.ToList<TLMDTO00004>().Count;

                            //Check Transfer or Not Transfer
                            if (TranferExist == 0)
                            {
                                //Not Transfer 

                                //Call Reversal CM(Active)
                                this.ReverSalDAO.MultipleTransactionReversalProcess(eno, GeneratedEno, groupNo, sourceBr, DateTime.Now, sourceBr + ".WithdrawReversalOnline", currentUserId, CashDenoDTO, string.Empty, true);   //1
                                if (this.ServiceResult.ErrorOccurred)
                                    throw new Exception(ServiceResult.MessageCode);

                                //Call Reversal CM(Not Active)
                                this.ReverSalDAO.MultipleTransactionReversalProcess(eno, GeneratedEno, groupNo, ListIBLTLFDTO[0].ToBranch, DateTime.Now, sourceBr + ".WithdrawReversalOnline", currentUserId, CashDenoDTO, string.Empty, true);   //2
                                if (this.ServiceResult.ErrorOccurred)
                                    throw new Exception(this.ServiceResult.MessageCode);

                            }
                            else
                            {
                                //Transfer Exist
                                //Check Tranfer Same Branch or Different Branch
                                var TransferBr = from x in ListIBLTLFDTO
                                                 where x.ToBranch == x.RelatedBranch
                                                 select x;
                                int TransferBranch = TransferBr.ToList<TLMDTO00004>() == null ? 0 : TransferBr.ToList<TLMDTO00004>().Count;

                                if (TransferBranch == 0)
                                {
                                    //Transfer Different Branch
                                    bool isDebitOrCredit = false;


                                    #region Credit Branch

                                    //Get Credit Branch
                                    var Branch = from x in ListIBLTLFDTO
                                                 where x.TranType.Trim() == "TCV"
                                                 select x.ToBranch;

                                    //Call Reversal CM(Credit Br)
                                    this.ReverSalDAO.MultipleTransactionReversalProcess(eno, GeneratedEno, groupNo, Branch.ToArray()[0], DateTime.Now, sourceBr + ".WithdrawReversalOnline", currentUserId, CashDenoDTO, string.Empty, true);  //3
                                    if (this.ServiceResult.ErrorOccurred)
                                        throw new Exception(this.ServiceResult.MessageCode);
                                    //return;
                                    if (Branch.ToArray()[0] == sourceBr)
                                        isDebitOrCredit = true;
                                    #endregion


                                    #region Debit Branch

                                    //Get Credit Branch
                                    Branch = from x in ListIBLTLFDTO
                                             where x.TranType.Trim() == "TDV"
                                             select x.ToBranch;

                                    //Call Reversal CM(Debit Br)
                                    this.ReverSalDAO.MultipleTransactionReversalProcess(eno, GeneratedEno, groupNo, Branch.ToArray()[0], DateTime.Now, sourceBr + ".WithdrawReversalOnline", currentUserId, CashDenoDTO, string.Empty, true);  //4
                                    if (this.ServiceResult.ErrorOccurred)
                                        throw new Exception(this.ServiceResult.MessageCode);
                                    //return;

                                    if (Branch.ToArray()[0] == sourceBr)
                                        isDebitOrCredit = true;

                                    #endregion

                                    //Debit or Credit is not same as Acitve Branch
                                    if (!isDebitOrCredit)
                                        this.ReverSalDAO.MultipleTransactionReversalProcess(eno, GeneratedEno, groupNo, sourceBr, DateTime.Now, sourceBr + ".WithdrawReversalOnline", currentUserId, CashDenoDTO, string.Empty, true);   //5
                                    if (this.ServiceResult.ErrorOccurred)
                                        throw new Exception(this.ServiceResult.MessageCode);
                                    //return;
                                    //Call Reversal CM(Active)
                                }
                                else
                                {
                                    //Transfer Same Branch

                                    //Call Reversal CM(Active)
                                    this.ReverSalDAO.MultipleTransactionReversalProcess(eno, GeneratedEno, groupNo, sourceBr, DateTime.Now, sourceBr + ".WithdrawReversalOnline", currentUserId, CashDenoDTO, string.Empty, true);   //6
                                    if (this.ServiceResult.ErrorOccurred)
                                        throw new Exception(this.ServiceResult.MessageCode);
                                    //return;

                                    //Call Reversal CM(Not Active)
                                    this.ReverSalDAO.MultipleTransactionReversalProcess(eno, GeneratedEno, groupNo, ListIBLTLFDTO[0].ToBranch, DateTime.Now, sourceBr + ".WithdrawReversalOnline", currentUserId, CashDenoDTO, string.Empty, true);   //7
                                    if (this.ServiceResult.ErrorOccurred)
                                        throw new Exception(this.ServiceResult.MessageCode);
                                    //return;
                                }
                            }

                        }
                        // return ListTLFDTO;
                    }


                }
                return GeneratedEno;


            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = ex.Message;
                throw new Exception(this.ServiceResult.MessageCode);
            }

        }

        private decimal GetSumAmount(string groupNo, string sourceBr, string status) 
        {
            TLMDTO00015 cashDeno = IBLDAO.SelectCashDenoByGroupNoAndStatus(groupNo, sourceBr, status);
            return cashDeno == null ? 0 : cashDeno.Amount;
        }
        public decimal SelectGroupAmountForMultipleReversal(string groupNo, string sourceBr)
        {
            PFMDTO00054 groupAmount = TlfDAO.SelectGroupAmountForMultipleReversal(groupNo, sourceBr);
            return groupAmount == null ? 0 : Convert.ToDecimal(groupAmount.TotalGroupAmount);
        }
        #endregion

        #region Helper Methods

        private IList<TLMDTO00004> SelectIBLTLFByEno(string entryNo, string sourceBr)
        {
            IList<TLMDTO00004> IBLTlfInfo = IBLDAO.SelectIBLTLFs(entryNo, sourceBr);

            if (IBLTlfInfo.Count == 0)
                return null;

            else
                return IBLTlfInfo;


        }

        private TLMDTO00009 SelectGroupNoByEno(string entryno, string sourceBr)
        {
            TLMDTO00009 DepoDenoInfo = DepoDenoDAO.SelectGroupNoByEno(entryno, sourceBr);

            return DepoDenoInfo;

        }

        private IList<FormatDefinition> CheckEnoForJournalVoucher(string brancode)
        {
            IList<FormatDefinition> formatDefInfo = CommonDAO.SelectFormatDefinitonByFormatCode("voucherNo", brancode);
            return formatDefInfo;
        }

        // Adding R to reversal voucher // Updated by NLH
        private string GetGeneratedEnoLocal(string MaxItem, IList<PFMDTO00054> ListTLFDTO)
        {
            int UpdateUserID = 0;
            string BranchCode = null;

            if (ListTLFDTO.Count != 0)
            {
                UpdateUserID = (Int32)ListTLFDTO[0].UpdatedUserId;
                BranchCode = ListTLFDTO[0].SourceBranchCode.ToString();
            }
            DateTime sys001 = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), BranchCode, true });

            string day = sys001.Day.ToString().PadLeft(2, '0');
            string month = sys001.Month.ToString().PadLeft(2, '0');
            string year = sys001.Year.ToString().Substring(2);


            string Eno = this.CodeGenerator.GetGenerateCode(MaxItem, string.Empty, UpdateUserID, BranchCode, new object[] { day, month, year });

            return Eno;
        }

        // reversal voucher IBL // Updated by NLH
        private string GetGeneratedEnoIBL(int userID, string sourcebr, IList<PFMDTO00054> ListTLFDTO)
        {
            return this.CodeGenerator.GetGenerateCode("IBLVoucher", string.Empty, userID, sourcebr, new object[] { ListTLFDTO[0].SourceBranchCode });
        }

        private bool CheckAccountType(string EntryNo, string sourceBr, IList<PFMDTO00054> ListTLFDTO, out IList<TLMDTO00004> ListIBLTLFDTO, out string narration)
        {
            bool isValid = false;
            ListIBLTLFDTO = null;
            bool isCOAAC = true;
            narration = ""; // Narration for showing data
            foreach (PFMDTO00054 tlfInfo in ListTLFDTO)
            {
                if (!tlfInfo.Narration.Contains("Income"))
                    narration = tlfInfo.Narration;
                if (tlfInfo.AccountNo.Trim().Length != 6)
                {
                    isCOAAC = false;
                    narration = tlfInfo.Narration;
                    break;
                }
            }

            if (isCOAAC == true) //COA Account
            {
                //Check Exist in IBLTLF
                ListIBLTLFDTO = SelectIBLTLFByEno(EntryNo, sourceBr);

                if (ListIBLTLFDTO != null)
                {
                    TLMDTO00009 DepoDenoDTO = SelectGroupNoByEno(EntryNo, sourceBr);

                    if (DepoDenoDTO != null)
                    {
                        ListTLFDTO[0].GroupNo = DepoDenoDTO.GroupNo;
                    }

                    if (ListIBLTLFDTO[0].TranType == "CCD")
                        narration = "IBL Deposit";
                    else
                        narration = "IBL Withdraw";

                    isValid = true;
                }
            }

            else  //Customer Account
            {
                isValid = true;
                TLMDTO00009 DepoDenoDTO = SelectGroupNoByEno(EntryNo, sourceBr);

                if (DepoDenoDTO != null)
                {
                    ListTLFDTO[0].GroupNo = DepoDenoDTO.GroupNo;
                }
            }

            return isValid;
        }

        private bool CheckJournalVoucher(string EntryNo, string sourceBr, out IList<TLMDTO00004> ListIBLTLFDTO, out string narration)
        {

            bool isValid = false;
            ListIBLTLFDTO = null;
            narration = "Transfer";

            //Select from FormatDefinition 
            IList<FormatDefinition> ListFormatDefinitionDTO = CheckEnoForJournalVoucher(sourceBr);

            if (ListFormatDefinitionDTO != null)
            {
                #region Format checking the PreFix and surFix
                //int PrevLen = 0;
                //int EndLen = 0;
                //string Prev;
                //var FormatDefData = from x in ListFormatDefinitionDTO
                //                    where x.PortionCode != "SerialCode"
                //                    select x;

                //FormatDefinition[] FormatNotSerialArr = FormatDefData.ToArray();

                //PrevLen += (String.IsNullOrEmpty(FormatNotSerialArr[0].Prefix) ? 0 : (FormatNotSerialArr[0].Prefix.Length));
                //EndLen += (String.IsNullOrEmpty(FormatNotSerialArr[0].Suffix) ? 0 : (FormatNotSerialArr[0].Suffix.Length));
                //                FormatDefData = from x in ListFormatDefinitionDTO
                //                where x.PortionCode != "SerialCode"
                //                select x;
                //FormatDefinition[] FormatArr = FormatDefData.ToArray();
                ////Check for journal Voucher
                //        double j = 0;

                //        // to check total length
                //        if (EntryNo.Length == (PrevLen + EndLen + FormatArr[0].Length))

                //        Prev = EntryNo.Substring(PrevLen, (FormatArr[0].Length) - EndLen); //Substring from entry No


                #endregion
                #region Format checking for serialCOde
                double j = 0;

                if (double.TryParse(EntryNo, out j)) //If Journal Voucher 
                {
                    isValid = true;
                }

                else // IBL Transfers and Other Transfers
                {
                    narration = "IBL Transfer";
                    //Check Exist in IBLTLF 
                    ListIBLTLFDTO = SelectIBLTLFByEno(EntryNo, sourceBr);

                    if (ListIBLTLFDTO != null)
                    {
                        TLMDTO00009 DepoDenoDTO = SelectGroupNoByEno(EntryNo, sourceBr);

                        if (DepoDenoDTO != null)
                        {
                            ListTLFDTO[0].GroupNo = DepoDenoDTO.GroupNo;
                        }
                    }

                    // Exists in IBLTLF
                    if (ListIBLTLFDTO.Count != 0)
                        isValid = true;
                }

                #endregion

            }

            return isValid;

        }

        private IList<PFMDTO00054> ConvertIBLTLFToTLF(IList<TLMDTO00004> ListIBLTLFDTO, IList<PFMDTO00054> ListTlfCurrentDTO, out decimal ChargesAmt)
        {
            ChargesAmt = 0;
            IList<PFMDTO00054> ListTlfDTO = new List<PFMDTO00054>();
            foreach (TLMDTO00004 IblTlfDTO in ListIBLTLFDTO)
            {
                PFMDTO00054 tlfDTO;

                //0 NoIncome ,1 Cash ,2 Transfer 
                if (IblTlfDTO.IncomeType == 1)
                {
                    #region calculating charges income by cash
                    var chargesTempList = from x in ListTlfCurrentDTO
                                          where (x.Narration.Contains("COMMUNICATION CHARGES") ||
                                          x.Narration.Contains("INCOME VOUCHER")) && x.AccountNo.Length == 6
                                          select x;

                    IList<PFMDTO00054> chargesList = chargesTempList.ToList<PFMDTO00054>();
                    foreach (PFMDTO00054 chargesTlfDto in chargesList)
                    {
                        ChargesAmt += chargesTlfDto.Amount;
                        ListTlfDTO.Add(chargesTlfDto);
                    }
                    #endregion
                }
                else if (IblTlfDTO.IncomeType == 2)
                {
                    #region Calculating charges income by transfer
                    if (IblTlfDTO.Income != null && IblTlfDTO.Income > 0)
                    {
                        tlfDTO = new PFMDTO00054();
                        tlfDTO.AccountNo = IblTlfDTO.AccountNo;
                        tlfDTO.Amount = IblTlfDTO.Income.Value;
                        tlfDTO.TransactionCode = "TRDEBIT";
                        tlfDTO.Narration = "Income";
                        ListTlfDTO.Add(tlfDTO);
                    }

                    if (IblTlfDTO.Communicationcharge != null && IblTlfDTO.Communicationcharge > 0)
                    {
                        tlfDTO = new PFMDTO00054();
                        tlfDTO.AccountNo = IblTlfDTO.AccountNo;
                        tlfDTO.Amount = IblTlfDTO.Communicationcharge.Value;
                        tlfDTO.TransactionCode = "TRDEBIT";
                        tlfDTO.Narration = "Fax";
                        ListTlfDTO.Add(tlfDTO);
                    }
                    #endregion
                }

                tlfDTO = new PFMDTO00054();
                tlfDTO.AccountNo = IblTlfDTO.AccountNo;
                tlfDTO.Amount = IblTlfDTO.Amount;
                if (IblTlfDTO.IncomeType == 1)   //income by Cash (IBL)
                    ChargesAmt = IblTlfDTO.Amount;
                else
                    ChargesAmt += IblTlfDTO.Amount;
                //CCD       CDW       TDV       TCV
                switch (IblTlfDTO.TranType)
                {
                    case "CCD":
                        tlfDTO.Narration = "Cash Credit Voucher";
                        tlfDTO.TransactionCode = "CSCREDIT";
                        break;
                    case "CDW":
                        tlfDTO.Narration = "Cash Debit Voucher";
                        tlfDTO.TransactionCode = "CSDEBIT";
                        break;
                    case "TDV":
                        tlfDTO.Narration = "Transfer Debit Voucher";
                        tlfDTO.TransactionCode = "TRDEBIT";
                        break;
                    case "TCV":
                        tlfDTO.Narration = "Transfer Credit Voucher";
                        tlfDTO.TransactionCode = "TRCREDIT";
                        break;
                }
                ListTlfDTO.Add(tlfDTO);
            }
            // Assigning group NO and Remaining amount for IBL Transaction // Update by NLH
            ListTlfDTO[0].GroupNo = ListTlfCurrentDTO[0].GroupNo;
            ListTlfDTO[0].DenoAmount = ListTlfCurrentDTO[0].DenoAmount;
            return ListTlfDTO;
        }

        public IList<PFMDTO00043> SelectPrnFileByAccountNo(string accountNo)  //added by ASDA
        {
            IList<PFMDTO00043> PrnFileList = CXServiceWrapper.Instance.Invoke<ICXSVE00003, IList<PFMDTO00043>>(x => x.PRNFile_SelecByAccountNo(accountNo));
            return PrnFileList;
        }

        #endregion

    }
}

