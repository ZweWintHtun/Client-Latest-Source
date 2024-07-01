using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Ace.Cbs.Cx.Com;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Tel.Dmd;
using System.Windows.Forms;

namespace Ace.Cbs.Mnm.Ptr
{
    public class MNMCTL00024 : AbstractPresenter, IMNMCTL00024
    {
        public MNMCTL00024()
        {
            this.BranchCode = CXCOM00007.Instance.BranchCode;
        }

        #region "Property"

        public TLMDTO00001 redto = new TLMDTO00001();
        private bool isSaveValidate = false;
        private string BranchCode { get; set; }
        public string status { get; set; }

        private IMNMVEW00024 view;
        public IMNMVEW00024 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        public bool Validate_Form()
        {
            return this.ValidateForm(this.GetReInfoEntity());
        }

        #endregion

        #region WireTo

        private void WireTo(IMNMVEW00024 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetReInfoEntity());
            }
        }

        #endregion WireTo

        #region Method

        public void mtxtRegisterNo_CustomValidating(object sender, ValidationEventArgs e)
         {
            if (e.HasXmlBaseError == false)
            {
                try
                {
                    if (string.IsNullOrEmpty(this.view.RegisterNo))
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00168");  // No data for report
                    }
                    else 
                    {
                       
                        redto = this.GetReInfoByRegisterNo();
                        this.view.DraweeBank = redto.Ebank + "(" + redto.Br_Alias + ")";
                        this.view.Amount = redto.Amount;
                        this.view.PayerAccountNo = redto.ToAccountNo;
                        this.view.PayerName = redto.ToName;
                        this.view.PayerAddress = redto.ToAddress;
                        this.view.PayerNRC = redto.ToNRC;
                        this.view.RemitterName = redto.Name;
                        this.view.RemitterNRC = redto.NRC;
                        this.GetRegisterNo(redto.Ebank);
                        //if (this.status == "OK")
                        //{
                        //    this.view.FocusControl();
                        //    this.status = "NOTOK";
                        //}
                    }
                }

                catch (Exception ex)
                {
                    this.SetCustomErrorMessage(this.GetControl("txtRegisterNo"), ex.Message);
                }
            }
        }

        public void mtxtRegisterNo_NewCustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError == false)
            {
                try
                {
                    if (string.IsNullOrEmpty(this.view.RegisterNo_ToChange))
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00168");  // No data for report
                    }
                    else if (this.view.RegisterNo == (this.view.RegisterNo_New + this.view.RegisterNo_ToChange))
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV90017");  // No data for report
                    }
                }

                catch (Exception ex)
                {
                    this.SetCustomErrorMessage(this.GetControl("txtRegisterNo_ToChange"), ex.Message);
                }
            }
        }
     
        public void Save()
        {
            if (this.Validate_Form())
            {
                TLMDTO00001 entity = new TLMDTO00001();
                entity = this.GetReInfoEntity(); // get viewdata to save
                             
                if (CXUIMessageUtilities.ShowMessageByCode("MC00004") == DialogResult.Yes) // confirm to save
                {
                    entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                    CXClientWrapper.Instance.Invoke<IMNMSVE00024>(x => x.Save_ReEntity(entity));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        string s = CXClientWrapper.Instance.ServiceResult.MessageCode;
                        this.view.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        this.view.InitializeControls();
                    }
                    else
                    {
                        this.view.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        this.SetFocus("txtRegisterNo");
                    }
                }
 
            }
        }

        #endregion

        #region Helper Method

        private TLMDTO00001 GetReInfoEntity()
        {
            TLMDTO00001 reEntity = new TLMDTO00001();
            reEntity.RegisterNo_Old = this.view.RegisterNo;
            reEntity.RegisterNo = this.view.RegisterNo_New + this.view.RegisterNo_ToChange;
            return reEntity;
        }

        public TLMDTO00001 GetReInfoByRegisterNo()
        {
            
            redto = CXClientWrapper.Instance.Invoke<IMNMSVE00024,TLMDTO00001>(x => x.SelectReInfoByRegisterNo(this.view.RegisterNo,this.BranchCode));
        
            if(redto == null)
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00168");  //Invalid Register No
         
            return redto;           
           
        }

        private void GetRegisterNo(string branch)
        {
            string fiscalYear = CXCOM00007.Instance.GetValueByVariable(CXCOM00009.FixcalculationYear);
          
            
            if (this.view.RegisterNo.Contains("IBL"))
            {
                string iblTransfer = CXCOM00007.Instance.GetValueByVariable(CXCOM00009.InterBranchLinkingTransfer);
                this.view.RegisterNo_New = fiscalYear + branch + iblTransfer;
            }
            else
            {
                string telaxTransfer = CXCOM00007.Instance.GetValueByVariable(CXCOM00009.TelaxTransfer);
                this.view.RegisterNo_New = fiscalYear + branch + telaxTransfer;
            }
        }

        #endregion
    }
}
