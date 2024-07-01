using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Windows.Core.Utt;
using System.Windows.Forms;

namespace Ace.Cbs.Mnm.Ptr
{
    public class MNMCTL00025:AbstractPresenter,IMNMCTL00025
    {
        #region View
        private IMNMVEW00025 view;
        public IMNMVEW00025 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private void WireTo(IMNMVEW00025 view)
        {
            if (this.view == null)
            {
                this.view = view;
                TLMDTO00001 entity = this.GetEntity();
                this.Initialize(this.view, entity);
            }
        }
        #endregion

        private TLMDTO00001 GetEntity()
        {
            TLMDTO00001 entity = new TLMDTO00001();
            entity.RegisterNo = View.RegisterNo;
            entity.Ebank = View.DraweeBank;
            entity.ToName = View.PayeeName;
            entity.ToNRC = View.PayeeNRC;
            entity.ToAddress = View.PayeeAddress;
            entity.ToPhoneNo = View.PayeePhoneNo;
            entity.Name = View.RemitterName;
            entity.NRC = View.RemitterNRC;
            entity.PhoneNo = View.RemitterPhoneNo;
            entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
            entity.SourceBranchCode = CurrentUserEntity.BranchCode;
            return entity;
        }


        public void mtxtRegisterNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (!e.HasXmlBaseError)
            {
                TLMDTO00001 reInfo = CXClientWrapper.Instance.Invoke<IMNMSVE00025, TLMDTO00001>(x => x.GetReInfo(View.RegisterNo, CurrentUserEntity.BranchCode));
                if (reInfo == null)
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtRegisterNo"), "MV00168");    //Invalid Register No.
                }
                else
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtRegisterNo"), string.Empty);
                    if (!this.View.SaveStatus)
                        this.ShowData(reInfo);
                    this.view.disablecontrol();
                }
            }
        }

        public void UpdateREInfo(TLMDTO00001 entity)
        {
            if (this.ValidateForm(entity))
            {
                //TLMDTO00001 entity = this.GetEntity();
                entity = this.GetEntity();
                CXClientWrapper.Instance.Invoke<IMNMSVE00025>(x => x.UpdateReInfo(entity));
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    if (CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode) == DialogResult.Yes)
                    {
                        this.UpdateREInfo(entity);
                    }
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode("MI90002");
                    this.View.ClearControls();
                }
            }
        }

        private void ShowData(TLMDTO00001 reInfo)
        {
            View.DraweeBank = reInfo.Ebank;
            View.PayeeName = reInfo.ToName;
            View.PayeeNRC = reInfo.ToNRC;
            View.PayeeAddress = reInfo.ToAddress;
            View.PayeePhoneNo = reInfo.ToPhoneNo;
            View.RemitterName = reInfo.Name;
            View.RemitterNRC = reInfo.NRC;
            View.RemitterPhoneNo = reInfo.PhoneNo;
        }
    }
}
