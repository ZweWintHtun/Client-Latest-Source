using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Mnm.Ctr.Ptr;
using System.Windows.Forms;

namespace Ace.Cbs.Mnm.Ptr
{
    public class MNMCTL00022:AbstractPresenter,IMNMCTL00022
    {
        #region View
        private IMNMVEW00022 view;
        public IMNMVEW00022 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private void WireTo(IMNMVEW00022 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetEntity());
            }
        }
        #endregion


        public string Cur;

        public void UpdateRDInfo(TLMDTO00017 entity)
        {

            if (this.ValidateForm(entity))
            {
                //TLMDTO00017 entity = this.GetEntity();
                entity = this.GetEntity();
                entity = CXClientWrapper.Instance.Invoke<IMNMSVE00022, TLMDTO00017>(x => x.UpdateRDInfo(entity, CurrentUserEntity.WorkStationId));
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    if ((CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode) == DialogResult.Yes))
                        this.UpdateRDInfo(entity);
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode("MI90002");  //Update Successful
                    if (CXUIMessageUtilities.ShowMessageByCode("MC00002") == DialogResult.Yes)
                    {
                        entity.status = "RDPersonalInfo";
                        CXUIScreenTransit.Transit("frmMNMVEW00130DrawintPrintingReport", true, new object[] { entity });
                    }
                    this.View.ClearControl();
                    this.View.SaveStatus = false;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(this.view.RegisterNo.ToString()))
                {
                    this.SetFocus("mtxtRegisterNo");
                }
                else if (string.IsNullOrEmpty(this.view.PayerName.ToString()))
                {
                    this.SetFocus("txtPayerName");
                }
                else if (string.IsNullOrEmpty(this.view.PayerNRC.ToString()))
                {
                    this.SetFocus("txtPayerNRC");
                }
                else if (string.IsNullOrEmpty(this.view.PayerAddress.ToString()))
                {
                    this.SetFocus("txtPayerAddress");
                }
                else if (string.IsNullOrEmpty(this.view.PayeeName.ToString()))
                {
                    this.SetFocus("txtPayeeName");
                }
                else if (string.IsNullOrEmpty(this.view.PayeeNRC.ToString()))
                {
                    this.SetFocus("txtPayeeNRC");
                }
                else if (string.IsNullOrEmpty(this.view.PayeeAddress.ToString()))
                {
                    this.SetFocus("txtPayeeAddress");
                }
            }
        }

        public void mtxtRegisterNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (!e.HasXmlBaseError)
            {
                TLMDTO00017 rdInfo = CXClientWrapper.Instance.Invoke<IMNMSVE00022, TLMDTO00017>(x => x.GetRDInfo(View.RegisterNo, CurrentUserEntity.BranchCode));
                if (rdInfo == null)
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtRegisterNo"), "MV00168");    //Invalid Register No.
                }
                else
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtRegisterNo"), string.Empty);
                    if(!this.View.SaveStatus)
                        this.ShowData(rdInfo);

                    this.view.DisableControl();
                }
            }
        }

        public void ShowData(TLMDTO00017 entity)
        {
            this.View.RegisterNo = entity.RegisterNo;
            this.View.DBank = entity.Dbank;
            this.View.PayerAccountNo = entity.AccountNo;
            this.View.PayerName = entity.Name;
            this.View.PayerNRC = entity.NRC;
            this.View.PayerAddress = entity.Address;
            this.View.PayerPhoneNo = entity.PhoneNo;
            this.View.Narration = entity.Narration;
            this.View.PayeeAccountNo = entity.ToAccountNo;
            this.View.PayeeName = entity.ToName;
            this.View.PayeeNRC = entity.ToNRC;
            this.View.PayeeAddress = entity.ToAddress;
            this.View.PayeePhoneNo = entity.ToPhoneNo;
            this.Cur = entity.Currency;
        }

        private TLMDTO00017 GetEntity()
        {
            TLMDTO00017 entity = new TLMDTO00017();
            entity.RegisterNo = this.View.RegisterNo;
            entity.Dbank = this.View.DBank;
            entity.AccountNo = this.View.PayerAccountNo;
            entity.Name = this.View.PayerName;
            entity.NRC = this.View.PayerNRC;
            entity.Address = this.View.PayerAddress;
            entity.PhoneNo = this.View.PayerPhoneNo;
            entity.Narration = this.View.Narration;
            entity.ToAccountNo = this.View.PayeeAccountNo;
            entity.ToName = this.View.PayeeName;
            entity.ToNRC = this.View.PayeeNRC;
            entity.ToAddress = this.View.PayeeAddress;
            entity.ToPhoneNo = this.View.PayeePhoneNo;
            entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
            entity.SourceBranchCode = CurrentUserEntity.BranchCode;
            entity.Currency = this.Cur;
            return entity;
        }
    }
}
