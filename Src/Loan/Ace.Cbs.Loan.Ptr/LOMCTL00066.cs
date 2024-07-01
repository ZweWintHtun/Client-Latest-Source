using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Cbs.Pfm.Dmd;

using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00066 : AbstractPresenter, ILOMCTL00066
    {
        public static string dealerNo;
        public string checkStatus;
        #region Properties
        private ILOMVEW00067 view;
        public ILOMVEW00067 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00067 view)
        {
            if (this.view == null)
            {
                this.view = view;
                //this.Initialize(this.view, GetEntity());
            }
        }

        private IList<PFMDTO00001> customerInformation;
        public IList<PFMDTO00001> CustomerInformation
        {
            get
            {
                if (this.customerInformation == null)
                    this.customerInformation = new List<PFMDTO00001>();
                return customerInformation;
            }
            set
            { this.customerInformation = value; }
        }

        #endregion

        #region Helper Method
        public LOMDTO00080 GetEntity()
        {
            LOMDTO00080 entity = new LOMDTO00080();
            entity.DealerAC = this.view.dealerAC;
            //entity.Dname = this.view.dname;
            return entity;
        }

        private PFMDTO00067 GetViewData()
        {
            PFMDTO00067 dto = new PFMDTO00067();
            dto.AccountNo = this.view.dealerAC;
            return dto;
        }

        #endregion

        public string SaveDealerRegistration(string dealerNo, string dealerAC, string dName, string dPhone, string dAddress, string email, string nrc, string fax, string businessName, string city, string businessEmail, string address, decimal commission, string eventMode, string sourceBr, int createdUserId, DateTime createdDate, int updatedUserId, DateTime updatedDate)
        {
            dealerNo = CXClientWrapper.Instance.Invoke<ILOMSVE00064, string>(x => x.Save(dealerNo, dealerAC, dName, dPhone, dAddress, email, nrc, fax, businessName, city, businessEmail, address, commission, eventMode, sourceBr, createdUserId, createdDate, updatedUserId, updatedDate));
            return dealerNo;
        }

        public IList<LOMDTO00095> GetDealerAccountInfo(string acctNo, string sourceBr)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00064, IList<LOMDTO00095>>(x => x.GetDealerAccountInfo(acctNo, sourceBr));
        }

        public void DeleteDealerRegistration(string dealerNo, int createdUserId, string sourceBr)
        {
            CXClientWrapper.Instance.Invoke<ILOMSVE00064>(x => x.Delete(dealerNo, createdUserId, sourceBr));
        }

        public void Call_Enquiry()
        {
            CXUIScreenTransit.Transit("frmTLMVEW00042", true, new object[] { "frmLOMVEW00067", this.view.dealerAC });
        }

        public string CheckAccountExistsOrValid(string caccount, string sourceBr)
        {
            checkStatus = CXClientWrapper.Instance.Invoke<ILOMSVE00064, string>(x => x.CheckAccountExistsOrValid(caccount, sourceBr));
            return checkStatus;
        }

        public void Call_DealerSearch()
        {
            LOMDTO00080 dealerInfoLst = new LOMDTO00080();
            CXUIScreenTransit.Transit("frmLOMVEW00080", true, new object[] { "frmLOMVEW00067", dealerInfoLst });

            this.view.dealerNo = dealerInfoLst.DealerNo;
            this.view.dealerAC = dealerInfoLst.DealerAC;
            this.view.dname = dealerInfoLst.Dname;
            this.view.nRC = dealerInfoLst.NRC;
            this.view.dphone = dealerInfoLst.Dphone;
            this.view.fax = dealerInfoLst.fax;
            this.view.email = dealerInfoLst.email;
            this.view.daddress = dealerInfoLst.Daddress;
            this.view.business = dealerInfoLst.Business;
            this.view.city = dealerInfoLst.city;
            this.view.businessEmail = dealerInfoLst.BusinessEmail;
            this.view.businessAddress = dealerInfoLst.BusinessAddress;
            this.view.commission = Convert.ToDecimal(dealerInfoLst.commission);
        }

        public void mtxtAcctno_CustomValidating(object sender, ValidationEventArgs e)
        {
            try
            {
                if (e.HasXmlBaseError)
                    return;
                CustomerInformation.Clear();
                Nullable<CXDMD00011> accountType;
                if (CXCLE00012.Instance.IsValidAccountNo(this.view.dealerAC, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                {
                    CustomerInformation = CXClientWrapper.Instance.Invoke<ILOMSVE00064, IList<PFMDTO00001>>(x => x.SelectByAccountNumber(this.view.dealerAC, DateTime.Now));

                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtAcctno"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                        return;
                    }

                }
                else if (accountType == CXDMD00011.DomesticAccountType)
                {
                    ChargeOfAccountDTO COAinfo = CXCLE00002.Instance.GetClientData<ChargeOfAccountDTO>("COA.Client.SelectAccountName", new object[] { this.view.dealerAC,CurrentUserEntity.BranchCode, true });
                    if (COAinfo == null)
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtAcctno"), CXMessage.MV00046);
                        return;
                    }
                }
                else
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtAcctno"), CXMessage.MV00046);
                    return;
                }

                if (CustomerInformation != null || customerInformation.Count > 0)
                {
                    this.view.dname = CustomerInformation[0].Name;
                    this.view.nRC = customerInformation[0].NRC;
                    this.view.dphone = customerInformation[0].PhoneNo;
                    this.view.fax = customerInformation[0].FaxNo;
                    this.view.email = customerInformation[0].Email;
                    this.view.daddress = customerInformation[0].Address;
                }
            }
            catch (Exception ex)
            {
                this.SetCustomErrorMessage(this.GetControl("mtxtAcctno"), ex.Message);
            }
        }

        public PFMDTO00067 GetAccountInformation()
        {
            try
            {
                return CXClientWrapper.Instance.Invoke<ILOMSVE00064, PFMDTO00067>(service => service.GetAccountInformation(this.view.dealerAC));
            }
            catch
            {
                throw new Exception();
            }
        }

        public IList<LOMDTO00080> GetAllDealerInformation(string sourceBr)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00080, IList<LOMDTO00080>>(x => x.GetAllDealerInformation(sourceBr));
        }

    }
}