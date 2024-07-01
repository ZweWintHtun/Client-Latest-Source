using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Tcm.Ctr.Sve;
using System.Windows.Forms;

namespace Ace.Cbs.Tcm.Ptr
{
    public class TCMCTL00045 : AbstractPresenter, ITCMCTL00045
    {

        #region Properties

        private ITCMVEW00045 view;
        public ITCMVEW00045 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        IList<PFMDTO00001> customerInfo { get; set; }

        #endregion

        #region Methods
        private void WireTo(ITCMVEW00045 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view,this.GetCustomerInfo());
            }
        }

        public PFMDTO00001 GetCustomerInfo()
        {
            PFMDTO00001 dto = new PFMDTO00001();
            dto.CustomerId = this.view.CustomerID;
            dto.Name = this.view.CustomerName;
            dto.NRC = this.view.NRC;
            dto.OpenAC = String.IsNullOrEmpty(this.view.NumOfAccountOpened)?0:Convert.ToDecimal(this.view.NumOfAccountOpened);
            dto.CloseAC = String.IsNullOrEmpty(this.view.NumOfAccountClosed) ? 0 : Convert.ToDecimal(this.view.NumOfAccountClosed);

            return dto;
        }

        public void ClearControls()
        {
            this.view.CustomerID = string.Empty;
            this.view.CustomerName = string.Empty;
            this.view.NRC = string .Empty;
            this.view.NumOfAccountOpened = string.Empty;
            this.view.NumOfAccountClosed = string.Empty;
            this.ClearAllCustomErrorMessage();
            this.view.BindSAOFCAOFFAOFGridview(null);
            this.view.BindAccountCountGridview(null);
            this.view.BindLoanGuaranteeGridView(null);
        }

        private void FillCustomerInfo(PFMDTO00001 customer)
        {
            this.view.CustomerName = customer.Name;
            this.view.NRC = customer.NRC;
            this.view.NumOfAccountOpened = customer.OpenAC.ToString();
            this.view.NumOfAccountClosed = customer.CloseAC.ToString();
        }

        private void BindUIData(PFMDTO00001 customer, IList<TCMDTO00045> caofsafofaoflist, IList<TCMDTO00045> accountcountlist, IList<TLMDTO00018> lglist)
        {
            this.FillCustomerInfo(customer);
            this.view.BindSAOFCAOFFAOFGridview(caofsafofaoflist);
            this.view.BindAccountCountGridview(accountcountlist);
            this.view.BindLoanGuaranteeGridView(lglist);
        }

        public void SearchCustomerId()
        {
            object[] objects = new object[] { false, false };
            if (CXUIScreenTransit.Transit("frmPFMVEW00005", objects) == DialogResult.OK)
            {
                PFMDTO00001 resultDTO = CXUIScreenTransit.GetData<PFMDTO00001>("PFMVEW00005");
                if (resultDTO != null)
                {
                    this.View.CustomerID = resultDTO.CustomerId;
                    this.GetAllCustomerInformation();
                }
            }
        }

        private void GetAllCustomerInformation()
        {
            CXDTO00011 dto = CXClientWrapper.Instance.Invoke<ITCMSVE00045, CXDTO00011>(x => x.SelectCustomerAccountInformation(this.view.CustomerID));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
            {
                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            else
            {
                if (dto.CustomerDto.IsVIP)
                    this.view.IsVIP = true;
                this.BindUIData(dto.CustomerDto, dto.SaofCaofFaofInformation, dto.AccountCount, dto.LoanGuarantee);
            }
        }
        #endregion

        #region Validation Logic

        public void txtCustomerID_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError == false)
            {
                this.GetAllCustomerInformation();
            }
        }
        #endregion
    }
}
