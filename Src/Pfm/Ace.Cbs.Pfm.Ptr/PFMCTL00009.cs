using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.CXClient;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Pfm.Ptr
{
    public class PFMCTL00009 : AbstractPresenter, IPFMCTL00009
    {
        #region Private Variable

        private int printLineCountPerPage =Convert.ToInt32(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.MaxPassBookPrintLineNo));

        private bool isFixedAccount;

        private List<string[]> printedList = new List<string[]>();

        #endregion

        #region Initializer
        private IPFMVEW00009 printLineEntryView;
        public IPFMVEW00009 PrintLineEntryView
        {
            get
            {
                return this.printLineEntryView;
            }
            set
            {
                this.WireTo(value);
            }
        }

        private void WireTo(IPFMVEW00009 view)
        {
            if (this.printLineEntryView == null)
            {
                this.printLineEntryView = view;
                this.Initialize(this.printLineEntryView, this.GetPrintFileEntity());
            }
        }  
        #endregion

        #region Private Method

        private PFMDTO00043 GetPrintFileEntity()
        {
            PFMDTO00043 printFileEntity = new PFMDTO00043();

            printFileEntity.PrintLineNo = this.printLineEntryView.PrintLineNo;

            return printFileEntity;
        }

        private int GetUpdatePrintLineNo(int totalPrintedCount)
        {
            if (totalPrintedCount >= printLineCountPerPage)
            {
                return (totalPrintedCount % printLineCountPerPage);
            }

            return totalPrintedCount;
        }

        #endregion

        #region Validation Logics

        public override bool ValidateForm(object validationContext)
        {
            return base.ValidateForm(validationContext);
        }

        public void txtLineNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError == false && this.printLineEntryView.IsDoPrinting)
            {
                if (this.printLineEntryView.PrintLineNo <= 0 || this.printLineEntryView.PrintLineNo > printLineCountPerPage)
                {
                    // Set Error Message to Control.
                    this.SetCustomErrorMessage(this.GetControl("txtLineNo"), CXMessage.MV00045); 
                }
                else
                {
                    // Set Error Message to Control.
                    this.SetCustomErrorMessage(this.GetControl("txtLineNo"), string.Empty);
                }
            }
        }

        #endregion

        #region Public Methods

        public void SavePrintingFile()
        {
            if (isFixedAccount)
            {
                CXClientWrapper.Instance.Invoke<IPFMSVE00009>(x => x.SaveFPrnFile(this.printLineEntryView.FPrnFileDTO));
            }
            else
            {
                CXClientWrapper.Instance.Invoke<IPFMSVE00009>(x => x.SavePrnFile(this.printLineEntryView.PrnFileDTO));
            }

            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.printLineEntryView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            else
            {
                this.printLineEntryView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public void UpdatePrintLineNo(string accountNo, int lineCount)
        {
            CXClientWrapper.Instance.Invoke<IPFMSVE00009>(x => x.UpdatePrintLineNumber(accountNo, lineCount, isFixedAccount,CurrentUserEntity.CurrentUserID));
        }

        public void SelectPrintLineCount(string accountNo)
        {
            isFixedAccount = this.printLineEntryView.AccountSign.StartsWith("F");

            this.printLineEntryView.PrintLineNo = CXClientWrapper.Instance.Invoke<IPFMSVE00009, int>(x => x.SelectPrintLineNumberByAccountNo(accountNo,isFixedAccount)) + 1;
        }

        private void PassBookPrinting(bool isSaveUI)
        {
            List<string[]> printingList = new List<string[]>();
            
            this.printLineEntryView.PrnFiles = new List<PFMDTO00043>();
            this.printLineEntryView.FPrnFiles = new List<PFMDTO00058>();
            
            int startPrintLineNo = this.printLineEntryView.PrintLineNo;

            if (isFixedAccount)
            {
                CXClientWrapper.Instance.Invoke<IPFMSVE00009>(x => x.SaveFPrnFile(this.printLineEntryView.FPrnFileDTO));
                this.printLineEntryView.FPrnFiles = CXClientWrapper.Instance.Invoke<IPFMSVE00009, IList<PFMDTO00058>>(x => x.GetFPrnFileByAccountNo(this.printLineEntryView.PrnFileDTO.AccountNo));
                //this.printLineEntryView.FPrnFiles.Add(this.printLineEntryView.FPrnFileDTO);
                var query = this.printLineEntryView.FPrnFiles.OrderBy(x => x.CreatedDate);
                
                for (int i = 0; i < query.Count<PFMDTO00058>(); i++)
                {
                    PFMDTO00058 fprnFile = query.ElementAt(i);

                    string[] prnFileStrArr = { fprnFile.CreatedDate.ToString("dd/MM/yyyy").Replace('/', '-'), fprnFile.Reference, fprnFile.Debit.ToString(), fprnFile.Credit.ToString(), fprnFile.Balance.ToString(), fprnFile.Id.ToString() };

                    printingList.Add(prnFileStrArr);
                }
            }
            else
            {
                if (isSaveUI == true)
                {
                    CXClientWrapper.Instance.Invoke<IPFMSVE00009>(x => x.SavePrnFile(this.printLineEntryView.PrnFileDTO));
                }
                //if (!this.printLineEntryView.IsOnlyforPrint)
                //{
                    this.printLineEntryView.PrnFiles = CXClientWrapper.Instance.Invoke<IPFMSVE00009, IList<PFMDTO00043>>(x => x.GetPrnFileByAccountNo(this.printLineEntryView.PrnFileDTO.AccountNo));
                    //this.printLineEntryView.PrnFiles.Add(this.printLineEntryView.PrnFileDTO);
                    //this.printLineEntryView.PrnFiles 
                    var query = this.printLineEntryView.PrnFiles.OrderBy(x => x.CreatedDate);

                    for (int i = 0; i < query.Count<PFMDTO00043>(); i++)
                    {
                        PFMDTO00043 prnFile = query.ElementAt(i);
                        string dateTime = CXCOM00006.Instance.GetDateFormat(prnFile.DATE_TIME.Value).ToString();
                        //string[] prnFileStrArr = { printLineEntryView.PrnFileDTO.DATE_TIME.Value.ToString("dd/MM/yyyy").Replace('/','-'), prnFile.Reference, prnFile.Debit.ToString(), prnFile.Credit.ToString(), prnFile.Balance.ToString(), prnFile.Id.ToString() };
                        string[] prnFileStrArr = { dateTime, prnFile.Reference, prnFile.Debit.ToString(), prnFile.Credit.ToString(), prnFile.Balance.ToString(), prnFile.Id.ToString() };

                        printingList.Add(prnFileStrArr);
                    }
               // }
            }

            try
            {
                CXCLE00005.Instance.StartLineNo = startPrintLineNo;
                CXCLE00005.Instance.PrintingList("PassBookCode", "LineByLine", "PassBookPrinting", printingList,false,true);
                //else CXCLE00005.Instance.PrintingList("PassBookCode", "LineByLine", "PassBookPrinting", this.printLineEntryView.printingList, false, true);
            }
            catch
            {

            }
            finally
            {
                foreach (string[] s in CXCLE00005.Instance.PrintedList)
                {
                    printedList.Add(s);
                }
            }
        }

        public void DeletePrintingFile()
        {
            if (this.printedList.Count == 0)
            {
                return;
            }

            if (isFixedAccount)
            {
                CXClientWrapper.Instance.Invoke<IPFMSVE00009>(x => x.DeleteFPrnFile(this.printLineEntryView.FPrnFiles,printedList));
            }
            else
            {
                //if(!this.printLineEntryView.IsOnlyforPrint)
                CXClientWrapper.Instance.Invoke<IPFMSVE00009>(x => x.DeletePrnFile(this.printLineEntryView.PrnFiles,printedList));
               // else CXClientWrapper.Instance.Invoke<IPFMSVE00009>(x => x.DeletePrnFile(this.printLineEntryView.PrnFiles, printedList));
            }

            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
            {
                this.printLineEntryView.Confirmation(CXClientWrapper.Instance.ServiceResult.MessageCode, true);
            }
        }

        public void UpdatePrintingLine()
        {
            if (this.printedList.Count == 0)
            {
                return;
            }

            int updatedPrintLineNo = GetUpdatePrintLineNo(this.printLineEntryView.PrintLineNo + (this.printedList.Count - 1));

            if (updatedPrintLineNo > printLineCountPerPage)
            {
                updatedPrintLineNo = updatedPrintLineNo % printLineCountPerPage;
            }

            if (isFixedAccount)
            {
                CXClientWrapper.Instance.Invoke<IPFMSVE00009>(x => x.UpdatePrintLineNumber(this.printLineEntryView.FPrnFileDTO.AccountNo,updatedPrintLineNo, true,CurrentUserEntity.CurrentUserID));
            }
            else
            {
                //if(!this.printLineEntryView.IsOnlyforPrint)
                    CXClientWrapper.Instance.Invoke<IPFMSVE00009>(x => x.UpdatePrintLineNumber(this.printLineEntryView.PrnFileDTO.AccountNo,updatedPrintLineNo, false,CurrentUserEntity.CurrentUserID));
                //else CXClientWrapper.Instance.Invoke<IPFMSVE00009>(x => x.UpdatePrintLineNumber(this.printLineEntryView.AccountNo, updatedPrintLineNo, false, CurrentUserEntity.CurrentUserID));
            }

            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
            {
                this.printLineEntryView.Confirmation(CXClientWrapper.Instance.ServiceResult.MessageCode,false);
            }           
        }

        public bool Printing(bool isSaveUI)
        {
            if (this.ValidateForm(this.GetPrintFileEntity()))
            {
                this.PassBookPrinting(isSaveUI);

                CXCLE00005.Instance.ClearPrintedList();

                this.UpdatePrintingLine();

                this.DeletePrintingFile();

                int totalPrintingCount = 0;

                int totalPrintedCount = 0;

                if (isFixedAccount == false && this.printedList.Count > 0 )
                {
                    totalPrintingCount = this.printLineEntryView.PrnFiles.Count;

                    totalPrintedCount = this.printedList.Count;
                }
                else if (isFixedAccount == true && this.printedList.Count > 0)
                {
                    totalPrintingCount = this.printLineEntryView.FPrnFiles.Count;

                    totalPrintedCount = this.printedList.Count;
                }

                if (totalPrintingCount == 0)
                {
                    return true;
                }

                string[] args = new string[4];

                if (totalPrintingCount == 1)
                {
                    args[0] = "Record is 1";
                }
                else
                {
                    args[0] = "Records are " + totalPrintingCount;
                }

                if (isFixedAccount)
                {
                    args[1] = this.printLineEntryView.FPrnFileDTO.AccountNo + ".\n";
                }
                else
                {
                    args[1] = this.printLineEntryView.PrnFileDTO.AccountNo + ".\n";
                }

                if (totalPrintedCount == 0)
                {
                    args[2] = "All Printing Records Failure.\n";
                }
                else if (totalPrintingCount == totalPrintedCount)
                {
                    args[2] = "All Records are already Printed Successfully.\n";
                }
                else
                {
                    args[2] = totalPrintedCount + " Records" + " are already Printed.\n";
                    args[3] = "But, " + (totalPrintingCount - totalPrintedCount) + " Records are Remaining.";
                }

                this.PrintingSuccessful(CXMessage.MI00007, args);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PrintingSuccessful(string message, string[] arguments)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message,arguments[0],arguments[1],arguments[2],arguments[3]);
        }

        #endregion
    }
}