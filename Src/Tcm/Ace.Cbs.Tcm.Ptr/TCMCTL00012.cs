using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Tcm.Ptr
{
    public class TCMCTL00012 : AbstractPresenter, ITCMCTL00012
    {
        #region Properties
        private ITCMVEW00012 view;
        public ITCMVEW00012 View
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        IList<PFMDTO00011> sCheques { get; set; }
        public string FormStatus { get; set; }
        public string AccountNo { get; set; }       

        #endregion

        #region Methods
        private void WireTo(ITCMVEW00012 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetChequeData());
            }
        }

        public void ClearControls()
        {
            this.view.AccountNo = string.Empty;
            this.view.CheckBookNo = string.Empty;
            this.view.StartSerialNo = string.Empty;
            this.view.EndSerialNo = string.Empty;
            this.view.Name = string.Empty;
            this.view.NRC = string.Empty;
        }

        public PFMDTO00011 GetChequeData()
        {
            PFMDTO00011 sChequeDTO = new PFMDTO00011();
            sChequeDTO.AccountNo = this.view.AccountNo;
            sChequeDTO.ChequeBookNo = this.view.CheckBookNo;
            sChequeDTO.StartNo = this.view.StartSerialNo;
            sChequeDTO.EndNo = this.view.EndSerialNo;
            return sChequeDTO;
        }

        public string CheckCheque()
        {
          
            string status = string.Empty;
            this.FormStatus = "Save";

            PFMDTO00011 sChequeData = GetChequeData();            
            if (this.ValidateForm(sChequeData))
            {
                if (!string.IsNullOrEmpty(sCheques[0].ChequeBookNo))
                {
                    var schequeInfo = (from value in sCheques
                                       where value.AccountNo == this.view.AccountNo
                                       && value.ChequeBookNo == this.view.CheckBookNo
                                       && value.StartNo == this.view.StartSerialNo
                                       && value.EndNo == this.view.EndSerialNo
                                       select value);

                    //var schequeInfo = (from value in sCheques
                    //                   where value.AccountNo == this.view.AccountNo
                    //                   && value.ChequeBookNo == this.view.CheckBookNo
                    //                   && (Convert.ToInt32(value.StartNo) <= Convert.ToInt32(this.view.StartSerialNo)
                    //                   && Convert.ToInt32(value.EndNo) >= Convert.ToInt32(this.view.EndSerialNo))
                    //                   select value);
                    IList<PFMDTO00011> list = schequeInfo.ToList<PFMDTO00011>();
                    if (list.Count > 0)
                    {
                        status = "OK";
                    }
                    else
                    {
                       status="NOT OK";
                    }
                }
            }
               
            
            return status;
        }

        public void Save()
        {            
            PFMDTO00011 sChequeData = GetChequeData();
            sChequeData.CreatedUserId = CurrentUserEntity.CurrentUserID;
            CXClientWrapper.Instance.Invoke<ITCMSVE00012>(x => x.UpdateSCheckData(sChequeData));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == true)
            {
              this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            else
            {
              this.View.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
              this.ClearControls();
            }
            
        }
        #endregion

        #region Validation Logic
        public void mtxtAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (e.HasXmlBaseError == false)
            {
                try
                {
                    Nullable<CXDMD00011> accountType;
                    IList<PFMDTO00011> customer = new List<PFMDTO00011>();
                    if (CXCLE00012.Instance.IsValidAccountNo(this.view.AccountNo, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                    {
                        customer = CXClientWrapper.Instance.Invoke<ITCMSVE00012, IList<PFMDTO00011>>(x => x.GetCustomersByAccountNumber(this.view.AccountNo));
                        
                        if(!string.IsNullOrEmpty(customer[0].SourceBranchCode))
                        {
                            if(customer[0].SourceBranchCode.ToString()!=CurrentUserEntity.BranchCode)
                            {
                            this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), "MV00091",new object[]{CurrentUserEntity.BranchCode});
                            return;
                            }
                        }
                        if (!string.IsNullOrEmpty(customer[0].CloseAccount))
                        {
                            this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), "MV00044");
                        }
                        else if (string.IsNullOrEmpty(customer[0].Name))
                        {
                            this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), "MV00211", new object[] { "Current Account" });
                        }
                        else if (this.FormStatus == "Save" && this.view.AccountNo != AccountNo)
                        {
                            this.view.Name = customer[0].Name;
                            this.view.NRC = customer[0].NRC;
                            this.sCheques = customer;
                            this.AccountNo = this.view.AccountNo;
                        }
                        else if (this.FormStatus != "Save" && this.view.AccountNo != AccountNo)
                        {
                            this.view.Name = customer[0].Name;
                           this.view.NRC = customer[0].NRC;
                            this.sCheques = customer;
                            this.view.CheckBookNo = string.Empty;
                            this.view.StartSerialNo = string.Empty;
                            this.view.EndSerialNo = string.Empty;
                            this.AccountNo = this.view.AccountNo;
                        }
                        else
                        {
                            this.view.Name = customer[0].Name;
                            this.view.NRC = customer[0].NRC;
                            this.sCheques = customer;
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), ex.Message);
                }
            }
            else
                return;
        }

        public void txtCheckBookNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (e.HasXmlBaseError != false)
            {
                return;
            }                
            else
            {
                if (String.IsNullOrEmpty(this.View.CheckBookNo))
                {
                    this.SetCustomErrorMessage(this.GetControl("txtChequeBookNo"), "MV00067");
                    return;
                }

                if (!string.IsNullOrEmpty(this.view.CheckBookNo.Trim()))
                {
                    this.view.CheckBookNo = CXCLE00007.GetFormatString(Convert.ToInt32(this.view.CheckBookNo), CXCOM00009.ChequeBookNoDisplayFormat);

                    IList<PFMDTO00011> SchequeInfo = CXClientWrapper.Instance.Invoke<ITCMSVE00012, IList<PFMDTO00011>>(x => x.GetSChequeInfoByChequeBookNo(this.view.AccountNo, this.View.CheckBookNo, CurrentUserEntity.BranchCode));
                    if (this.FormStatus == "Save")
                    {
                        if (this.view.StartSerialNo == this.view.EndSerialNo)
                        {
                            var ActiveInfo = (from value in SchequeInfo
                                              where value.AccountNo == this.view.AccountNo
                                              && value.ChequeBookNo == this.view.CheckBookNo
                                              && value.StartNo == this.view.StartSerialNo
                                              && value.EndNo == this.view.EndSerialNo
                                              && value.Active == true
                                              select value).ToList();

                            if (ActiveInfo.Count == 0)
                            {
                                MessageBox.Show("ChequeNo Already released.!");
                                return;
                            }
                        }
                    }
                    else
                    {
                        if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                        {
                            if (CXClientWrapper.Instance.ServiceResult.MessageCode == "")
                                this.SetCustomErrorMessage(this.GetControl("txtCheckBookNo"), CXMessage.MV90047); //Already released Cheque Book No.!
                            else
                                this.SetCustomErrorMessage(this.GetControl("txtCheckBookNo"), CXClientWrapper.Instance.ServiceResult.MessageCode); //"MV00226" Invalid already stopped Cheque Book No.Firstly, need to stop!!
                            return;
                        }
                    }
                    this.FormStatus = string.Empty;
                }                    
            }
        }

        public void txtStartSerialNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (e.HasXmlBaseError != false)
                return;
            else
            {
                if (!string.IsNullOrEmpty(this.view.StartSerialNo.Trim()))
                    this.view.StartSerialNo = CXCLE00007.GetFormatString(Convert.ToInt32(this.view.StartSerialNo), CXCOM00009.ChequeNoDisplayFormat);
            }
        }

        public void txtEndSerialNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (e.HasXmlBaseError != false)
                return;
            else
            {
                if (!string.IsNullOrEmpty(this.view.EndSerialNo.Trim()))
                    this.view.EndSerialNo = CXCLE00007.GetFormatString(Convert.ToInt32(this.view.EndSerialNo), CXCOM00009.ChequeNoDisplayFormat);
            }
        }


        #endregion
       
    }
}
