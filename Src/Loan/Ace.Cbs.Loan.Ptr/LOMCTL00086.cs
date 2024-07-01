using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Windows.Ix.Client.Utt;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00086 : AbstractPresenter, ILOMCTL00086
    {
        #region Properties

        private ILOMVEW00086 view;
        public ILOMVEW00086 LoanRecordView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(ILOMVEW00086 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.view.ViewData);
            }
        }
        #endregion

        #region Validation
        public void cboTownship_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (this.view.TownshipCode == null)
            {
                this.SetCustomErrorMessage(this.GetControl("cboTownship"), CXMessage.MV20005);
            }
        }

        public void cboVillageGroup_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (this.view.VillageCode == null)
            {
                this.SetCustomErrorMessage(this.GetControl("cboVillageGroup"), CXMessage.MV90134);
            }
        }

        public void cboBusinessType_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (this.view.BusinessCode == null)
            {
                if (this.view.LoanType == "LIVESTOCK LOAN")
                    this.SetCustomErrorMessage(this.GetControl("cboBusinessType"), CXMessage.MV00021);
                else
                    this.SetCustomErrorMessage(this.GetControl("cboBusinessType"), CXMessage.MV90112);                
            }
        }

        public void txtTotalGroup_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (this.view.TotalGroup== "0.00")
            {
                this.SetCustomErrorMessage(this.GetControl("txtTotalGroup"), CXMessage.MV90122);            
            }
        }

        public void txtPopulation_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (this.view.Population== "0.00")
            {
                this.SetCustomErrorMessage(this.GetControl("txtPopulation"), CXMessage.MV90123);            
            }
        }

        public void txtAcre_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (this.view.Acre== "0.00")
            {
                this.SetCustomErrorMessage(this.GetControl("txtAcre"), CXMessage.MV90124);            
            }
        }
        #endregion

        #region Methods   
        public void Save(LOMDTO00086 entity)
        {
            try
            {
                if (this.LoanRecordView.Status.Equals("Save"))
                {
                    entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                    entity.SourceBr = CurrentUserEntity.BranchCode;
                    entity.UserNo = CurrentUserEntity.CurrentUserID.ToString();

                    this.LoanRecordView.Eno = CXClientWrapper.Instance.Invoke<ILOMSVE00086, string>(x => x.SaveServerAndServerClient(entity));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                       this.LoanRecordView.Successful("MI00051", this.LoanRecordView.Eno);
                    }
                    else
                    {
                        this.LoanRecordView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }

                else
                {
                    entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                    IList<DataVersionChangedValueDTO> dvcvList = GetChangedValueOfObject.GetChangedValueList(this.LoanRecordView.PreviousLoanRecord, entity);
                    CXClientWrapper.Instance.Invoke<ILOMSVE00086>(x => x.UpdateLoanRecord(entity, dvcvList, "Update"));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        this.LoanRecordView.Successful("MI90002", "");
                    }

                }
            }
            catch { }
        }


        public IList<LOMDTO00099> GetLoanRecordByLoanNo(string eno)
        {
            try
            {
                return CXClientWrapper.Instance.Invoke<ILOMSVE00086, IList<LOMDTO00099>>(service => service.GetLoanRecordByLoanNo(eno));
            }
            catch { return null; }
        }

        public void Delete(string eno)
        {
            try
            {
                CXClientWrapper.Instance.Invoke<ILOMSVE00086>(x => x.Delete(eno));
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    this.LoanRecordView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode, "");
                else
                    this.LoanRecordView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            catch {  }
        }

        public int CheckLoanAccNo(string acctNo)
        {
            try
            {
                return CXClientWrapper.Instance.Invoke<ILOMSVE00086, int>(service => service.CheckLoanAccNo(acctNo));
            }
            catch { return 0; }
        }

        #region LoanRecord_BusinessType
        public void SaveBusinessType(IList<LOMDTO00099> lstBusinessType)
        {
            try
            {
                if (this.LoanRecordView.Status.Equals("Save"))
                { 
                    lstBusinessType.ToList().ForEach(x => { x.CreatedDate = DateTime.Now; x.CreatedUserId = CurrentUserEntity.CurrentMenuId; });

                }
            }
            catch { }
        }
        #endregion
        #endregion
    }
}
