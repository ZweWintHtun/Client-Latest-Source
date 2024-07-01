using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Pfm.Ptr
{
    public class PFMCTL00007 : AbstractPresenter, IPFMCTL00007
    {
        #region Properties

		private IPFMVEW00007 printUserView;
        public IPFMVEW00007 PrintUserView
        {
            set { this.WireTo(value); }
            get { return this.printUserView; }
        }

        private void WireTo(IPFMVEW00007 view)
        {
            if (this.printUserView == null)
            {
                this.printUserView = view;
                this.Initialize(this.printUserView, this.PrintUserView.PrintUserEntity);
            }
        } 

	    #endregion

        #region Validation Methods
        public override bool ValidateForm(object validationContext)
        {
            return base.ValidateForm(validationContext);
        } 

        public void txtOldPassword_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (e.HasXmlBaseError == false && ( this.printUserView.PrintUserEntity.CheckStatus == "Check" || this.printUserView.PrintUserEntity.CheckStatus == "EditCheck"))
            {
                if (CXClientWrapper.Instance.Invoke<IPFMSVE00007, bool>(x => x.IsValidPassword(this.printUserView.BranchCode, this.printUserView.OldPassword)))
                {
                    // Set Empty to control.
                    this.SetCustomErrorMessage(this.GetControl("txtOldPassword"), string.Empty);
                }
                else
                {
                    // Set Empty to control.
                    this.SetCustomErrorMessage(this.GetControl("txtOldPassword"),CXMessage.MV00043);
                }

                if (this.printUserView.IsCheckOrEdit == true)
                {
                    this.printUserView.PrintUserEntity.CheckStatus = "EditCheck";
                }
                else
                {
                    this.printUserView.PrintUserEntity.CheckStatus = "Check";
                }
            }
        }

        #endregion

        #region Public Methods

        public void CheckUserExist(string branchCode)
        {
            PFMDTO00044 currentUserName = CXClientWrapper.Instance.Invoke<IPFMSVE00007, PFMDTO00044>(x => x.SelectPrintUserByBranchCode(branchCode));

            if (currentUserName != null)
            {
                this.printUserView.VisibleControlsForCurrentUser(currentUserName.UserName.Trim());
            }
            else
            {
                this.printUserView.VisibleControlsForNewUser();
                
                this.printUserView.DisableControlsForNewUser();
            }
        }

        public bool IsValidPassword(string branchCode, string OldPassword)
        {
            return CXClientWrapper.Instance.Invoke<IPFMSVE00007, bool>(x => x.IsValidPassword(branchCode, OldPassword));
        }

        public void SavePrintUserEntity(PFMDTO00044 printUserEntity)
        {
            if (this.ValidateForm(printUserEntity))
            {
                printUserEntity.CreatedUserId = CurrentUserEntity.CurrentUserID;

                CXClientWrapper.Instance.Invoke<IPFMSVE00007>(x => x.Save(printUserEntity));

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                {
                    this.printUserView.RebindAuthorizeUserTextBox(printUserEntity.UserName);

                    this.printUserView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
                else
                {
                    this.printUserView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
            }
        }

        public void UpdatePrintUserEntity(PFMDTO00044 printUserEntity)
        {
           printUserEntity.CheckStatus = "EditCheck";
           if (this.ValidateForm(printUserEntity))
           {
                printUserEntity.UpdatedUserId = CurrentUserEntity.CurrentUserID;

                CXClientWrapper.Instance.Invoke<IPFMSVE00007>(x => x.Update(printUserEntity));

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                {
                    this.printUserView.RebindAuthorizeUserTextBox(printUserEntity.UserName);

                    this.printUserView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
                else
                {
                    this.printUserView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
            }
        } 

        #endregion
    }

}