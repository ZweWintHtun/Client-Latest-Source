using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using Ace.Cbs.Cx.Com;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Admin.DataModel;
using System.Windows.Forms;

namespace Ace.Cbs.Mnm.Ptr
{
    public class MNMCTL00029:AbstractPresenter,IMNMCTL00029
    {
        private IMNMVEW00029 view;
        public IMNMVEW00029 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private void WireTo(IMNMVEW00029 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetAccountNo());
            }
        }

        private IList<PFMDTO00001> saving_CustomerList { get; set; }
        private IList<PFMDTO00021> Fixed_CustomerList { get; set; }
        private string acsign { get; set; }
        #region HelperMethod
        private TLMDTO00001 GetAccountNo()
        {
            TLMDTO00001 dto = new TLMDTO00001();
            dto.AccountNo = this.view.AccountNo;
            return dto;
        }

        private void GetCustomerInfo(string acctno)
        {
            saving_CustomerList = CXClientWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00001>>(x => x.GetCustomerInfomationByCaofOrSaof(acctno, "S"));
            if (saving_CustomerList.Count == 0 || saving_CustomerList == null)
            {
                Fixed_CustomerList = CXClientWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00021>>(x => x.FAOFSelectByAccountNumberForRePrintingPassBook(acctno));
                if(Fixed_CustomerList.Count == 0)
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00051);
                else
                {
                    this.view.CustomerName = Fixed_CustomerList[0].Name;
                    this.view.CustomerNRC = Fixed_CustomerList[0].NRC;
                    this.view.Fathername = Fixed_CustomerList[0].GuardianName;
                    this.view.Address = Fixed_CustomerList[0].Address;
                    this.acsign = Fixed_CustomerList[0].AccountSignature;
                }

            }
            else
            {
                this.view.CustomerName = saving_CustomerList[0].Name;
                this.view.CustomerNRC = saving_CustomerList[0].NRC;
                this.view.Fathername = saving_CustomerList[0].FatherName;
                this.view.Address = saving_CustomerList[0].Address;
                this.acsign = saving_CustomerList[0].AccountSign;
            }
        }

        public void ClearControls()
        {
            this.ClearAllCustomErrorMessage();
            this.view.AccountNo = string.Empty;
            this.view.CustomerName = string.Empty;
            this.view.Address = string.Empty;
            this.view.Fathername = string.Empty;
            this.view.CustomerNRC = string.Empty;
        }
        #endregion

        #region UI Validating Logic
        public void mtxtAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError == false)
            {
                this.GetCustomerInfo(this.view.AccountNo);
            }
        }
        #endregion

        #region Print Methods

        private IList<string[]> GetPrintingData(string accountCode)
        {
            IList<string[]> printingData = new List<string[]>();
            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            if (this.acsign.Contains("S"))
            {                
                printingData.Add(new string[] { this.GetPersonSignatureString(this.saving_CustomerList[0].AccountSign) });
                
                if (!(this.acsign.Contains("SM") || this.acsign.Contains("SI"))) 
                    printingData.Add(new string[] { this.saving_CustomerList[0].NoOfPersonSign.ToString() + " " + ((this.saving_CustomerList[0].NoOfPersonSign > 1) ? "persons" : "person") + " will sign" });
                else
                    printingData.Add(new string[] { "-" });
               
                printingData.Add(new string[] { accountCode + "(" + this.saving_CustomerList[0].CurrencyCode + ")" + "(" + Branch.Bank_Alias + "-" + Branch.BranchDescription + ")"});
               
                if(this.acsign.Contains("SO"))
                    printingData.Add(new string[] { (saving_CustomerList[0].Business) == null ? "-":saving_CustomerList[0].Business });
                else printingData.Add(new string[] { string.Empty });

                foreach (PFMDTO00001 customer in this.saving_CustomerList)
                {
                    printingData.Add(new string[] { customer.Name, customer.NRC });
                }
            }
            else
            {              
                printingData.Add(new string[] { this.GetPersonSignatureString(this.Fixed_CustomerList[0].AccountSignature) });
                
                if (!(this.acsign.Contains("FM") || this.acsign.Contains("FI")))
                    printingData.Add(new string[] { this.Fixed_CustomerList[0].NoOfPersonSign.ToString() + " " + ((this.Fixed_CustomerList[0].NoOfPersonSign > 1) ? "persons" : "person") + " will sign" });
                else
                    printingData.Add(new string[] { "-" });

                printingData.Add(new string[] { accountCode + "(" + this.Fixed_CustomerList[0].CurrencyCode + ")" + "(" + Branch.Bank_Alias + "-" + Branch.BranchDescription + ")" });
                
                if (this.acsign.Contains("FC"))
                    printingData.Add(new string[] { (Fixed_CustomerList[0].Business) == null ? "-" : Fixed_CustomerList[0].Business });
                else printingData.Add(new string[] { string.Empty });


                foreach (PFMDTO00021 customer in this.Fixed_CustomerList)
                {
                    printingData.Add(new string[] { customer.Name, customer.NRC });
                }
            }

            return printingData;
        }

        private string GetPersonSignatureString(string acsign)
        {
            switch (acsign)
            {
                case "SI":
                    return "Individual";
                case "SJ":
                    return "Joint";
                case "SM":
                    return "Minor";
                case "SO":
                    return "Organization";
                case "FI":
                    return "Individual";
                case "FJ":
                    return "Joint";
                case "FM":
                    return "Minor";
                case "FC":
                    return "Organization";
                default:
                    return string.Empty;
            }
        }

        public void PrintPassbook()
        {
            IList<string[]> printingData = this.GetPrintingData(this.view.AccountNo);
            try
            {
                // Printing Logic
                CXCLE00005.Instance.PrintingList(CXCOM00009.AccountOpeningDirectPrinting, CXCOM00009.PrintingHeadingCode, printingData[0][0], printingData, false, false);
            }
            catch (Exception)
            {
                //this.view.Failure(CXMessage.ME00061);
            }
            finally
            {
                // Clear all controls
                this.ClearControls();
            }
        }
        #endregion
    }
}
