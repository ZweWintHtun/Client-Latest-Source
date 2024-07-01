﻿using System;
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
using Ace.Windows.CXServer.Utt;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Windows.CXClient;


namespace Ace.Cbs.Mnm.Sve
{
    public class MNMSVE00010 : BaseService, IMNMSVE00010
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
        public TCMDTO00001 StartDTO { get; set; }//Added by HMW (22-May-2019) : To check reversal info for Seperating EOD
        public IPFMDAO00056 Sys001DAO { get; set; }//Added by HMW (22-May-2019) : To check reversal info for Seperating EOD

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
            
            #region Added By AAM (23-Jan-2018)

            string str = this.TlfDAO.Check_EntryNo_Individual_DepWdwReverse(eno, sourceBr);

            //Added and Modified by HMW (For Seperating EOD Process)
            if ((str == "-1"))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV00213"; //Entry No Not Found
                return null;
            }
            else if ((str == "-2"))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME30003"; //Already Reverse Voucher
                return null;
            }
            else if (str == "-3")
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MI50012"; //Already Cut Off!\nNot Allowed Reversal for "Before Cut Off Transactions"
                return null;
            }
            else if (str == "-4")
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MI50014"; //Already Cut Off!\nNot Allowed Reversal for "Cash Transactions"
                return null;
            }
            else if (str == "-5")
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME30002"; //Not Allow Back Date Transaction
                return null;
            }
            else if (str == "-6")
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME30002"; //Not Allow Back Date Transaction
                return null;
            }
            else if (str == "-7")
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME30002"; //Not Allow Back Date Transaction
                return null;
            }
            else if (str == "-8")
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90201"; //Not Allow Multiple Deposit/Withdraw Transaction
                return null;
            }
            
            #endregion

            else  //Added by HMW (For Seperating EOD Process)
            {
                bool canReversal;
                canReversal = this.CheckInfoBeforeReversal(DateTime.Parse(ListTLFDTO[0].SettlementDate.ToString()), sourceBr);

                if (canReversal == true) // Entry No Exist
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

                        //ListTLFDTO[0].Description = narration;
                        ListTLFDTO[0].SourceCurrency = sourceCurrency;

                        //return ListTLFDTO;
                    }

                    else
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = "MV00213"; //Entry No Not Found
                        return null;
                    }
                }
                return ListTLFDTO;
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

                if(CashDenoDTO != null)
                    CashDenoDTO.WithdrawEntryStatus = "WithdrawReversal";   //added by ASDA

                ListTLFDTO = this.TlfDAO.GetTlfInfoByEntryNo(eno, sourceBr);

                //Added and Modify by HMW (25-Mar-2019) : For Seperating EOD (2 Times EOD ==> At Current Day EOD, At Tomorrow Morning BOD)
                bool canReversal;
                canReversal = this.CheckInfoBeforeReversal(DateTime.Parse(ListTLFDTO[0].SettlementDate.ToString()), sourceBr);                  

                if (ListTLFDTO != null && canReversal == true)
                {                                                          
                    
                    //Getting System Startup Date
                    string systemStartupDate;
                    TCMDTO00001 startDTO = CXServiceWrapper.Instance.Invoke<ITCMSVE00014, TCMDTO00001>(x => x.SelectStartBySourceBr(sourceBr));
                    if (startDTO == null)
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = "ME90047";//System Start Up File has no record.
                        return null;
                    }
                    else
                    {
                        if (startDTO.Status == "C")
                        {
                            //transferCollection[j].SystemStartupDate = startDTO.Date;
                            systemStartupDate = startDTO.Date.ToShortDateString(); // 04/22/2019
                        }
                        else
                        {
                            systemStartupDate = "";
                            this.ServiceResult.ErrorOccurred = true;
                            this.ServiceResult.MessageCode = "MI50010"; //System has already shut down.\nPlease startup first.
                        }
                    }

                    //Getting Last Settlement Date
                    string lastSettlementDate;
                    DateTime settlementDate;
                    string lastSDate = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.LastSettlementDate);
                    PFMDTO00056 sysDTO = CXServiceWrapper.Instance.Invoke<IMNMSVE00004, PFMDTO00056>(x => x.SelectSysDate(lastSDate, sourceBr));
                    lastSettlementDate = sysDTO.SysDate.HasValue ? sysDTO.SysDate.Value.ToString("MM/dd/yyyy") : string.Empty; //"04/08/2019"                 
                    
                    /*
                    int i;
                    //DateTime  = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), BranchCode ,true});

                    if (systemStartupDate != lastSettlementDate)//Before Cut Off TXN
                    {
                        var isOrgnEnoNull = from x in ListTLFDTO
                                            where x.OrgnEno == null
                                                //&& x.DateTime.ToShortDateString() == DateTime.Now.ToShortDateString()
                                            && x.SettlementDate.Value.ToString() == ListTLFDTO[0].SettlementDate.Value.ToShortDateString()//DateTime.Now.ToShortDateString()
                                            select x;
                        i = isOrgnEnoNull.ToList<PFMDTO00054>() == null ? 0 : isOrgnEnoNull.ToList<PFMDTO00054>().Count;
                        settlementDate = DateTime.Parse(ListTLFDTO[0].SettlementDate.ToString()); //DateTime.Now;
                    }
                    else//After Cut Off TXN
                    {
                        var isOrgnEnoNull = from x in ListTLFDTO
                                            where x.OrgnEno == null
                                                //&& x.DateTime.ToShortDateString() == lastSDate
                                            && x.SettlementDate.Value.ToString("MM/dd/yyyy") == lastSettlementDate
                                            select x;
                        i = isOrgnEnoNull.ToList<PFMDTO00054>() == null ? 0 : isOrgnEnoNull.ToList<PFMDTO00054>().Count;
                        settlementDate = DateTime.Parse(ListTLFDTO[0].SettlementDate.ToString());//sysDTO.SysDate.Value;
                    }



                    //var isOrgnEnoNull = from x in ListTLFDTO
                    //                    where x.OrgnEno == null
                    //                    && x.DateTime.ToShortDateString() == DateTime.Now.ToShortDateString()
                    //                    select x;
                    //int i = isOrgnEnoNull.ToList<PFMDTO00054>() == null ? 0 : isOrgnEnoNull.ToList<PFMDTO00054>().Count;

                    if (i == 0)
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = "ME30003"; //Entry No Already Issued
                        //return;
                        throw new Exception(this.ServiceResult.MessageCode);
                    }
                    else
                    {
                    */

                    settlementDate = DateTime.Parse(ListTLFDTO[0].SettlementDate.ToString());

                    //Check IBL Transaction or Normal Transaction
                        IList<TLMDTO00004> ListIBLTLFDTO = SelectIBLTLFByEno(eno, sourceBr);

                        if (ListIBLTLFDTO == null)//NOt IBL Transaction 
                        {
                            //Generate Normal Voucher No
                            GeneratedEno = GetGeneratedEnoLocal("Reversal Code", ListTLFDTO);

                            //Call Reversal Common Module
                            //this.ReverSalDAO.ReversalProcess(eno, GeneratedEno, groupNo, sourceBr, DateTime.Now, sourceBr, currentUserId, CashDenoDTO, string.Empty,true);  //8
                            this.ReverSalDAO.ReversalProcess(eno, GeneratedEno, groupNo, sourceBr, settlementDate, sourceBr, currentUserId, CashDenoDTO, string.Empty, true);  //8
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
                                this.ReverSalDAO.ReversalProcess(eno, GeneratedEno, groupNo, sourceBr, DateTime.Now, sourceBr + ".WithdrawReversalOnline", currentUserId, CashDenoDTO, string.Empty, true);   //1
                                if (this.ServiceResult.ErrorOccurred)
                                    throw new Exception(ServiceResult.MessageCode);

                                //Call Reversal CM(Not Active)
                                this.ReverSalDAO.ReversalProcess(eno, GeneratedEno, groupNo, ListIBLTLFDTO[0].ToBranch, DateTime.Now, sourceBr + ".WithdrawReversalOnline", currentUserId, CashDenoDTO, string.Empty, true);   //2
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
                                    this.ReverSalDAO.ReversalProcess(eno, GeneratedEno, groupNo, Branch.ToArray()[0], DateTime.Now, sourceBr + ".WithdrawReversalOnline", currentUserId, CashDenoDTO, string.Empty, true);  //3
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
                                    this.ReverSalDAO.ReversalProcess(eno, GeneratedEno, groupNo, Branch.ToArray()[0], DateTime.Now, sourceBr + ".WithdrawReversalOnline", currentUserId, CashDenoDTO, string.Empty, true);  //4
                                    if (this.ServiceResult.ErrorOccurred)
                                        throw new Exception(this.ServiceResult.MessageCode);
                                    //return;

                                    if (Branch.ToArray()[0] == sourceBr)
                                        isDebitOrCredit = true;

                                    #endregion

                                    //Debit or Credit is not same as Acitve Branch
                                    if (!isDebitOrCredit)
                                        this.ReverSalDAO.ReversalProcess(eno, GeneratedEno, groupNo, sourceBr, DateTime.Now, sourceBr + ".WithdrawReversalOnline", currentUserId, CashDenoDTO, string.Empty, true);   //5
                                    if (this.ServiceResult.ErrorOccurred)
                                        throw new Exception(this.ServiceResult.MessageCode);
                                    //return;
                                    //Call Reversal CM(Active)
                                }
                                else
                                {
                                    //Transfer Same Branch

                                    //Call Reversal CM(Active)
                                    this.ReverSalDAO.ReversalProcess(eno, GeneratedEno, groupNo, sourceBr, DateTime.Now, sourceBr + ".WithdrawReversalOnline", currentUserId, CashDenoDTO, string.Empty, true);   //6
                                    if (this.ServiceResult.ErrorOccurred)
                                        throw new Exception(this.ServiceResult.MessageCode);
                                    //return;

                                    //Call Reversal CM(Not Active)
                                    this.ReverSalDAO.ReversalProcess(eno, GeneratedEno, groupNo, ListIBLTLFDTO[0].ToBranch, DateTime.Now, sourceBr + ".WithdrawReversalOnline", currentUserId, CashDenoDTO, string.Empty, true);   //7
                                    if (this.ServiceResult.ErrorOccurred)
                                        throw new Exception(this.ServiceResult.MessageCode);
                                    //return;
                                }
                            }

                        }
                        // return ListTLFDTO;
                    //}
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
           
        private decimal GetSumAmount(string groupNo, string sourceBr, string status)   //edited by ASDA
        {
            TLMDTO00015 cashDeno = IBLDAO.SelectCashDenoByGroupNoAndStatus(groupNo, sourceBr, status); 
            return cashDeno==null ? 0 : cashDeno.Amount;
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
            //DateTime sys001 = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), BranchCode ,true});

            #region Added by HMW (29-May-2019) for Seperating EOD

            DateTime lastSDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.LastSettlementDate), BranchCode, true });
            DateTime nextSDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), BranchCode, true });
            string systemStartupDate;
            TCMDTO00001 startDTO = CXServiceWrapper.Instance.Invoke<ITCMSVE00014, TCMDTO00001>(x => x.SelectStartBySourceBr(BranchCode));
            if (startDTO == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90047";//System Start Up File has no record.
                return null;
            }
            else
            {
                if (startDTO.Status == "C")
                {
                    //transferCollection[j].SystemStartupDate = startDTO.Date;
                    systemStartupDate = startDTO.Date.ToShortDateString(); // 04/22/2019
                }
                else
                {
                    systemStartupDate = "";
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MI50010"; //System has already shut down.\nPlease startup first.
                }
            }

            DateTime sys001;
            if (systemStartupDate == lastSDate.ToShortDateString())
            {
                sys001 = lastSDate;//For After Cut Off TXNs (Seperating EOD Process)
            }
            else
            {
                sys001 = nextSDate;//For Before Cut Off TXNs (Seperating EOD Process)
            }
            #endregion

            string day = sys001.Day.ToString().PadLeft(2, '0');
            string month = sys001.Month.ToString().PadLeft(2, '0');
            string year = sys001.Year.ToString().Substring(2);


            string Eno = this.CodeGenerator.GetGenerateCode(MaxItem, string.Empty, UpdateUserID, BranchCode, new object[] { day, month, year });

            return Eno;
        }

        // reversal voucher IBL // Updated by NLH
        private string GetGeneratedEnoIBL(int userID,string sourcebr, IList<PFMDTO00054> ListTLFDTO)
        {
            return this.CodeGenerator.GetGenerateCode("IBLVoucher", string.Empty, userID, sourcebr, new object[] { ListTLFDTO[0].SourceBranchCode });
        }

        private bool CheckAccountType(string EntryNo,string sourceBr, IList<PFMDTO00054> ListTLFDTO, out IList<TLMDTO00004> ListIBLTLFDTO, out string narration)
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

        private bool CheckJournalVoucher(string EntryNo,string sourceBr, out IList<TLMDTO00004> ListIBLTLFDTO, out string narration)
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

        private IList<PFMDTO00054> ConvertIBLTLFToTLF(IList<TLMDTO00004> ListIBLTLFDTO, IList<PFMDTO00054> ListTlfCurrentDTO,out decimal ChargesAmt)
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

        //Added by HMW at 22.05.2019 (Reversal Validation : For Seperating EOD Process)
        public IList<PFMDTO00056> SelectAllAutoPayStatusList(string sourcebr)
        {

            IList<PFMDTO00056> AutoPayStatusList = this.IBLDAO.SelectAllAutoPayStatusList(sourcebr);          
            return AutoPayStatusList;
        }

        public bool CheckInfoBeforeReversal(DateTime txnSettlementDate,string sourceBr)
        {
            DateTime lastSDate, nextSDate, systemDate, autoPayRunDate, settlementDate;
            string strLastSDate;
            bool hasAutoPayRun = false;
            bool isBeforeCutOffTXN = false;
            try
            {
                //Getting Last Settlement Date

                strLastSDate = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.LastSettlementDate);
                PFMDTO00056 sysDTO = CXServiceWrapper.Instance.Invoke<IMNMSVE00004, PFMDTO00056>(x => x.SelectSysDate(strLastSDate, sourceBr));
                lastSDate = DateTime.Parse(sysDTO.SysDate.ToString());
                nextSDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), sourceBr);

                TCMDTO00001 startdto = CXServiceWrapper.Instance.Invoke<ITCMSVE00014, TCMDTO00001>(x => x.SelectStartBySourceBr(sourceBr));
                if (startdto == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME90047";//System Start Up File has no record. 
                    throw new Exception(this.ServiceResult.MessageCode);
                }
                else
                {
                    if (startdto.Status == "C")
                    {
                        systemDate = startdto.Date;
                    }
                    else
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = "MI50010"; //System has already shut down.\nPlease startup first.
                        throw new Exception(this.ServiceResult.MessageCode);
                    }
                }

                IList<PFMDTO00056> AutoPayRunList = CXServiceWrapper.Instance.Invoke<IMNMSVE00010, PFMDTO00056>(x => x.SelectAllAutoPayStatusList(sourceBr));
                if (systemDate.Date == DateTime.Now.Date)
                    settlementDate = nextSDate; //Reversal Before Cut Off 
                else
                    settlementDate = lastSDate;//Reversal After Cut Off 

                for (int i = 0; i < AutoPayRunList.Count; i++)
                {
                    autoPayRunDate = DateTime.Parse(AutoPayRunList[i].SysDate.ToString());
                    if (autoPayRunDate > settlementDate) // Already Auto Pay Run >> Cannot Reversal
                    {
                        hasAutoPayRun = true;
                        break;
                    }
                }

                if (hasAutoPayRun == false)
                {
                    if (txnSettlementDate.Date == nextSDate.Date)
                    {
                        isBeforeCutOffTXN = true; //Before Cut Off TXN
                        return true; // Successful Reversal
                    }                    
                    else if (systemDate.Date == lastSDate.Date && txnSettlementDate.Date == lastSDate.Date && txnSettlementDate >= lastSDate)
                    {
                        isBeforeCutOffTXN = true; //After Cut Off TXN (before System Shut Down)
                        return true; // Successful Reversal
                    }
                    else if (systemDate.Date == lastSDate.Date && txnSettlementDate.Date == lastSDate.Date && txnSettlementDate < lastSDate)
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = "MI50012"; //Already Cut Off!\nNot Allowed Reversal for "Before Cut Off Transactions".
                        throw new Exception(this.ServiceResult.MessageCode);
                    }
                    else if (systemDate.Date > lastSDate.Date && txnSettlementDate.Date == lastSDate.Date)
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = "ME30002"; //Not Allowed Back Date Transaction!
                        throw new Exception(this.ServiceResult.MessageCode);
                    }                    
                }
                else
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MI50011"; //Not Allowed Reversal! \nAuto Pay Process has been Run.
                    throw new Exception(this.ServiceResult.MessageCode);
                }
                return false;
            }            
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = ex.Message;
                throw new Exception(this.ServiceResult.MessageCode);
            }
        }

        #endregion

    }
}
