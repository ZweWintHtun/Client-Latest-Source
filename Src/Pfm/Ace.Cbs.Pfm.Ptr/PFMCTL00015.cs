using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Tcm.Ctr.Sve;

namespace Ace.Cbs.Pfm.Ptr
{
    public class PFMCTL00015 : AbstractPresenter, IPFMCTL00015
    {
        #region"View"
        private IPFMVEW00015 printChequeView;
        public IPFMVEW00015 PrintChequeView
        {
            set { this.WireTo(value); }
            get { return this.printChequeView; }
        }
        #endregion

        #region"Form Initializer"
        private void WireTo(IPFMVEW00015 view)
        {
            if (this.printChequeView == null)
            {
                this.printChequeView = view;
                this.Initialize(this.printChequeView, this.printChequeView.ChequeEntity);             
                this.ErrorProvider.Validating += new EventHandler<ValidationEventArgs>(this.mtxtAccountNo_CustomValidating);
                this.ErrorProvider.Validating += new EventHandler<ValidationEventArgs>(this.txtChequeBookNo_CustomValidating);
                this.ErrorProvider.Validating += new EventHandler<ValidationEventArgs>(this.txtEndNo_CustomValidating);
            }
        }
        #endregion

        #region"Properties"
        private bool isPrintValidate = false;
        IList<PFMDTO00017> CAOFList { get; set; }

        string CurrencyCode;
        #endregion

        #region"Validation"
        
        public override bool ValidateForm(object validationContext)
        {
            return base.ValidateForm(validationContext);
        }
        public string GetCurrentBranch()
        {
            string currentbranchCode = CurrentUserEntity.BranchCode+"( "+CurrentUserEntity.BranchDescription+" )";
            return currentbranchCode;
        }
          
        public void mtxtAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
            {
                return;
            }

            if (CXCOM00006.Instance.Validate(this.printChequeView.AccountNo, CXCOM00009.AccountNoCodeFormat, CXCOM00009.AccountNoCheckDigitFormula))
            {
                if (CXClientWrapper.Instance.Invoke<ICXSVE00006, bool>(x => x.IsClosedAccountForCLedger(this.printChequeView.AccountNo)))
                {
                    // Account No has been closed.
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                    return;
                }
                else
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), string.Empty);
                }

                this.CAOFList = CXClientWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00017>>(x => x.GetCAOFsByAccountNumber(this.printChequeView.AccountNo));

                if (CAOFList.Count < 1)
                {
                    // Invalid Current Account No.
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00058);
                }
                else
                {
                    SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), string.Empty);
                }
            }
            else
            {
                // Invalid Current Account No.
                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00058);
            }
        }

        public void txtChequeBookNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
            {
                return;
            }

            if (!string.IsNullOrEmpty(this.printChequeView.ChequeBookNo))
            {
                this.printChequeView.ChequeBookNo = CXCLE00007.GetFormatString(Convert.ToInt32(this.printChequeView.ChequeBookNo), CXCOM00009.ChequeBookNoDisplayFormat);
            }

            PFMDTO00006 chequedto = CXClientWrapper.Instance.Invoke<IPFMSVE00015, PFMDTO00006>(x => x.SelectStartNoAndEndNoByChequeBookNo(this.PrintChequeView.AccountNo, this.PrintChequeView.ChequeBookNo));
            
            if (chequedto != null)
            {
                if (this.PrintChequeView.ChequeBookNo == chequedto.ChequeBookNo && this.isPrintValidate == false)
                {
                    this.PrintChequeView.StartSerialNo = chequedto.StartNo;
                    this.PrintChequeView.EndSerialNo = chequedto.EndNo;
                    this.CurrencyCode = chequedto.CurrencyCode;  //Added by ASDA
                    this.SetCustomErrorMessage(this.GetControl("txtChequeBookNo"), string.Empty);
                }
            }
            else
            {
                // Invalid Cheque Book No.
                this.SetCustomErrorMessage(this.GetControl("txtChequeBookNo"), CXMessage.MV00067);
            }     
        }

        public void txtEndNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
            {
                return;
            }

            if (!string.IsNullOrEmpty(this.printChequeView.EndSerialNo))
            {
                this.printChequeView.EndSerialNo = CXCLE00007.GetFormatString(Convert.ToInt32(this.printChequeView.EndSerialNo), CXCOM00009.ChequeNoDisplayFormat);
            }

            if (CXCLE00007.IsValidChequeEndNo(this.printChequeView.StartSerialNo, this.printChequeView.EndSerialNo) == false)
            {
                //  Invalid End Cheque No.
                this.SetCustomErrorMessage(this.GetControl("txtEndChequeNo"), CXMessage.MV00072);
            }
            else
            {
                this.SetCustomErrorMessage(this.GetControl("txtEndChequeNo"), string.Empty);
            } 
        }

        #endregion

        #region"Private Methods"
       
        //Get ChequeNo List if Start Cheque No and End Cheque No is valid
        private IList<string[]> GetPrintingChequeList(PFMDTO00006 entity)
        {
            IList<string[]> printingList = new List<string[]>();
            string branch =  entity.AccountNo.Substring(0,3);

            // Whether Start No and End No is valid in Cheque or not
            //if (CXClientWrapper.Instance.Invoke<ICXSVE00006, bool>(x => x.IsValidChequeBookIssueNoForStopCheque(entity.AccountNo, entity.ChequeBookNo, entity.StartNo, entity.EndNo, CXCOM00007.Instance.BranchCode)) == false)
            if (CXClientWrapper.Instance.Invoke<ICXSVE00006, bool>(x => x.IsValidChequeBookIssueNoForStopCheque(entity.AccountNo, entity.ChequeBookNo, entity.StartNo, entity.EndNo,branch,this.CurrencyCode)) == false)
            {
                switch (CXClientWrapper.Instance.ServiceResult.MessageCode)
                {
                    case "MV00061": MessageBox.Show("Used Cheque Contains!"); break;    //This Cheque No is already used.
                    case "MV00060": MessageBox.Show("Stopped Cheque Contains!"); break;  //This Cheque No is already stopped.
                    default: this.printChequeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode); break;
                }
                return null;
            }
            //else if (CXClientWrapper.Instance.Invoke<ICXSVE00006, bool>(x => x.IsAlreadyPrintedChequeNo(entity.StartNo, entity.EndNo, CXCOM00007.Instance.BranchCode)))
            else if (CXClientWrapper.Instance.Invoke<ICXSVE00006, bool>(x => x.IsAlreadyPrintedChequeNo(entity.AccountNo,entity.StartNo, entity.EndNo, branch,entity.ChequeBookNo)))
            {
                this.printChequeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                return null;
            }

            // Are you sure to print?
            if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC00002) == DialogResult.Yes)
            {
                string branchcode = string.Empty;
                string sourcebr = string.Empty;
                if (entity.SourceBranchCode.Length > 3)
                {
                    branchcode = entity.SourceBranchCode.Substring(0, 3) + "-" + entity.SourceBranchCode.Substring(3, 3); //001-002
                    sourcebr = entity.SourceBranchCode.Substring(3, 3);
                }
                else
                {
                    branchcode = entity.SourceBranchCode.Substring(0, 3) + "-" + entity.SourceBranchCode.Substring(0, 3); //001-001
                    sourcebr = entity.SourceBranchCode.Substring(0, 3);                    
                }

                IList<PFMDTO00011> ChequeList = new List<PFMDTO00011>();
                IList<PFMDTO00011> SchequeInfo = CXClientWrapper.Instance.Invoke<ITCMSVE00012, IList<PFMDTO00011>>(x => x.GetSChequeInfoByChequeBookNo(entity.AccountNo, entity.ChequeBookNo,sourcebr));
                if (SchequeInfo.Count > 0)
                {
                    foreach(PFMDTO00011 schequedto in SchequeInfo)
                    {
                        if (schequedto.StartNo == schequedto.EndNo)
                            ChequeList.Add(schequedto);
                        else
                        {
                            int chequeCount = (Convert.ToInt32(schequedto.EndNo)) - (Convert.ToInt32(schequedto.StartNo)) + 1;
                            int no = Convert.ToInt32(schequedto.StartNo);
                            for (int k = 0; k < chequeCount; k++)
                            {
                                PFMDTO00011 scheque = new PFMDTO00011();
                                scheque.StartNo = CXCLE00007.GetFormatString(no, CXCOM00009.ChequeNoDisplayFormat);
                                ChequeList.Add(scheque);
                                no++;
                            }
                        }
                    }
                }
                IList<PFMDTO00020> UchequeInfo = CXClientWrapper.Instance.Invoke<IPFMSVE00015, IList<PFMDTO00020>>(x => x.SelectUchequeByAccountNoChequeNo(entity.AccountNo, entity.ChequeBookNo, sourcebr));
                if (UchequeInfo.Count > 0)
                {
                    foreach (PFMDTO00020 uchequedto in UchequeInfo)
                    {
                        PFMDTO00011 ucheque = new PFMDTO00011();
                        ucheque.StartNo = uchequedto.ChequeNo;
                        ChequeList.Add(ucheque);
                    }
                }            

                ChequeList = ChequeList.OrderBy(o => o.StartNo).ToList();                   

                int count = (Convert.ToInt32(entity.EndNo)) - (Convert.ToInt32(entity.StartNo)) + 1;
                int chequeNo = Convert.ToInt32(entity.StartNo);

                #region Old Code
                //string branchcode = string.Empty ;
                //if(entity.SourceBranchCode.Length > 3)
                //    branchcode = entity.SourceBranchCode.Substring(0,3) +"-"+entity.SourceBranchCode.Substring(3,3); //001-002
                //else
                //    branchcode = entity.SourceBranchCode.Substring(0,3) +"-"+entity.SourceBranchCode.Substring(0,3); //001-001

                //for (int i = 0; i < count; i++)
                //{                    
                //    if (ChequeList[i].StartNo != CXCLE00007.GetFormatString(chequeNo, CXCOM00009.ChequeNoDisplayFormat))
                //    {
                //        string[] str = { entity.AccountNo, entity.ChequeBookNo, branchcode, CXCLE00007.GetFormatString(chequeNo, CXCOM00009.ChequeNoDisplayFormat) };
                //        printingList.Add(str);
                //        chequeNo++;
                //    }
                //}
                #endregion

                int i = 0;
                int j = 0;
                string startNo = string.Empty;    
                do
                {             
                    if (ChequeList.Count > 0)                      
                    {
                            if (j != ChequeList.Count)
                            {
                                if (ChequeList[j].StartNo != CXCLE00007.GetFormatString(chequeNo, CXCOM00009.ChequeNoDisplayFormat))
                                {
                                    string[] str = { entity.AccountNo, entity.ChequeBookNo, branchcode, CXCLE00007.GetFormatString(chequeNo, CXCOM00009.ChequeNoDisplayFormat) };
                                    printingList.Add(str);
                                    chequeNo++;
                                }
                                else
                                {
                                    j++;
                                    chequeNo++;
                                }
                            }
                            else
                            {                                    
                                string[] str = { entity.AccountNo, entity.ChequeBookNo, branchcode, CXCLE00007.GetFormatString(chequeNo, CXCOM00009.ChequeNoDisplayFormat) };
                                printingList.Add(str);
                                chequeNo++;
                            }
                        
                    }
                    else
                    {
                        string[] str = { entity.AccountNo, entity.ChequeBookNo, branchcode, CXCLE00007.GetFormatString(chequeNo, CXCOM00009.ChequeNoDisplayFormat) };
                        printingList.Add(str);
                        chequeNo++;
                    }
                    i++;
                } while (i != count); 
            }
            return printingList;
        }       
                     
        #endregion

        #region"Public Methods"
        //Print ChequeNo
        public void Print()
        {
            this.isPrintValidate = true;

            // get ChequeNo List 
            if (this.ValidateForm(printChequeView.ChequeEntity))
            {  
                IList<string[]> printList = this.GetPrintingChequeList(printChequeView.ChequeEntity);

                if (printList != null && printList.Count() > 0)
                {
                    CXCLE00005.Instance.PrintingList("PrintChequeCode", "Heading", "PrintChequePrinting", printList, false, true);

                    IList<PFMDTO00014> printedList = new List<PFMDTO00014>();

                    for (int i = 0; i < printList.Count; i++)
                    {
                        PFMDTO00014 printcheque = new PFMDTO00014();

                        string[] printline = printList[i];
                        printcheque.AccountNo = printline[0];
                        printcheque.ChequeBookNo = printline[1];
                        printcheque.SourceBranchCode = CurrentUserEntity.BranchCode;  // updated by haymar
                        printcheque.ChequeNo = printline[3];
                        printcheque.UserNo = CurrentUserEntity.CurrentUserID.ToString();
                        printcheque.DATE_TIME = DateTime.Now;
                        printcheque.CreatedUserId = CurrentUserEntity.CurrentUserID;
                        if(this.printChequeView.SourceBranchCode.Length > 3)
                            printcheque.BranchCode = this.printChequeView.SourceBranchCode.Substring(0, 3) + "-" + this.printChequeView.SourceBranchCode.Substring(3,3); //001-002
                        else
                            printcheque.BranchCode = this.printChequeView.SourceBranchCode.Substring(0, 3) + "-" + this.printChequeView.SourceBranchCode.Substring(0,3); //001-002
                        printedList.Add(printcheque);
                    }

                    CXClientWrapper.Instance.Invoke<IPFMSVE00015>(x => x.Save(printedList));

                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        this.printChequeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                    else
                    {
                       this.printChequeView.Successful(CXMessage.MI00012); // Printing successful.
                    }
                }              
            }

            this.isPrintValidate = false;
        }

        public void PrintWithRDLC()
        {
            this.isPrintValidate = true;

            // get ChequeNo List 
            if (this.ValidateForm(printChequeView.ChequeEntity))
            {
                IList<string[]> printList = this.GetPrintingChequeList(printChequeView.ChequeEntity);
                if (printList != null && printList.Count() > 0)
                {
                    CXUIScreenTransit.Transit("frmPFMVEW00079.ReportViewer", true, new object[] { printList, this.printChequeView.SourceBranchCode });
                }
            }
        }
        #endregion
    }
}
