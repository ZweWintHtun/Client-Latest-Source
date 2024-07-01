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
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Client.Utt;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Ctr.Sve;


namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00075 : AbstractPresenter, ILOMCTL00075
    {
        #region Properties

        public LOMCTL00075() { }
        private ILOMVEW00075 view;
        public ILOMVEW00075 AGLoanProductTypeItemSetupView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }
        private void WireTo(ILOMVEW00075 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.view.ViewData);
            }
        }
        #endregion

        #region Methods

        public void Save(LOMDTO00075 entity)
        {
            if (!this.ValidateForm(entity))
            {
                if (entity.ProductCode == string.Empty)
                    this.SetFocus("cboProductType");
                else if (entity.ProductCode != string.Empty && entity.SeasonCode == string.Empty)
                    this.SetFocus("cboSeasonType");
                else if (entity.ProductCode != string.Empty && entity.SeasonCode != string.Empty && entity.UMCode == string.Empty)
                    this.SetFocus("cboUM");
                else if (entity.ProductCode != string.Empty && entity.SeasonCode != string.Empty && entity.UMCode != string.Empty && entity.SMonth == string.Empty)
                    this.SetFocus("cboSMonth");
                else if (entity.ProductCode != string.Empty && entity.SeasonCode != string.Empty && entity.UMCode != string.Empty && entity.SMonth != string.Empty && entity.SDay == string.Empty)
                    this.SetFocus("cboSDay");
                else if (entity.ProductCode != string.Empty && entity.SeasonCode != string.Empty && entity.UMCode != string.Empty && entity.SMonth != string.Empty && entity.SDay != string.Empty && entity.EMonth == string.Empty)
                    this.SetFocus("cboEMonth");
                else if (entity.ProductCode != string.Empty && entity.SeasonCode != string.Empty && entity.UMCode != string.Empty && entity.SMonth != string.Empty && entity.SDay != string.Empty && entity.EMonth != string.Empty && entity.EDay == string.Empty)
                    this.SetFocus("cboEDay");
                else if (entity.ProductCode != string.Empty && entity.SeasonCode != string.Empty && entity.UMCode != string.Empty && entity.SMonth != string.Empty && entity.SDay != string.Empty && entity.EMonth != string.Empty && entity.EDay != string.Empty && entity.DeadLineMonth == string.Empty)
                    this.SetFocus("cboDMonth");
                else if (entity.ProductCode != string.Empty && entity.SeasonCode != string.Empty && entity.UMCode != string.Empty && entity.SMonth != string.Empty && entity.SDay != string.Empty && entity.EMonth != string.Empty && entity.EDay != string.Empty && entity.DeadLineMonth != string.Empty && entity.DeadLineMonth == string.Empty)
                    this.SetFocus("cboDDay");
                return;
            }
            IList<DataVersionChangedValueDTO> dvcvList = new List<DataVersionChangedValueDTO>();
            if (this.AGLoanProductTypeItemSetupView.Status.Equals("Save"))
            {
                entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;

                IList<LOMDTO00075> AGLoansInfo = CXClientWrapper.Instance.Invoke<ILOMSVE00075, IList<LOMDTO00075>>(x => x.CheckExist2(entity.SeasonCode));
                if (AGLoansInfo.Count > 0)
                {
                    LOMDTO00075 AGLoanProductTypeItemActive = AGLoansInfo.Where<LOMDTO00075>(x => x.Active == false).FirstOrDefault();
                    if (AGLoanProductTypeItemActive != null)   //Data exist with active 0 , deleted , so data will be save with update nature
                    {
                        if (AGLoanProductTypeItemActive.AGLoanProductTypeItemId == entity.AGLoanProductTypeItemId)
                        {
                            entity.TS = AGLoanProductTypeItemActive.TS;
                            //cityActive.Active = true;  //to save with active when changingValueOfObject   
                            dvcvList = GetChangedValueOfObject.GetChangedValueList(AGLoanProductTypeItemActive, entity);
                            entity.Active = false;  //to check status in service
                        }
                    }
                    else
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MV90001");//data already exists      
                        return;
                    }
                }
                else entity.Active = true;  //active = 1 , new data , so data will be save with insert nature 
                //CXClientWrapper.Instance.Invoke<ILOMSVE00075>(x => x.SaveServerAndServerClient(entity));
                CXClientWrapper.Instance.Invoke<ILOMSVE00075>(x => x.SaveServerAndServerClient(entity, dvcvList));
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                {
                    this.AGLoanProductTypeItemSetupView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.view.ProductCode= string.Empty;
                    this.view.SeasonCode = string.Empty;
                    this.view.UMCode = string.Empty;
                    this.view.SDay = string.Empty;
                    this.view.SMonth = string.Empty;
                    this.view.EDay = string.Empty;
                    this.view.EMonth = string.Empty;
                    this.view.DeadLineDay = string.Empty;
                    this.view.DeadLineMonth = string.Empty;
                    this.SetFocus("cboProductType");
                }
                else
                {
                    this.AGLoanProductTypeItemSetupView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
            }
            else
            {
                entity.SourceBranchCode = CurrentUserEntity.BranchCode;
                entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                dvcvList = GetChangedValueOfObject.GetChangedValueList(this.AGLoanProductTypeItemSetupView.PreviousAGLoanProductTypeItemSetupDto, entity);
                CXClientWrapper.Instance.Invoke<ILOMSVE00075>(x => x.Update(entity, dvcvList, "Update"));

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                {
                    string s = CXClientWrapper.Instance.ServiceResult.MessageCode;
                    this.AGLoanProductTypeItemSetupView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.SetFocus("cboProductType");
                }
                else
                {
                    this.AGLoanProductTypeItemSetupView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    //this.SetFocus("txtDescription");
                    this.SetFocus("cboProductType");
                }
            }
        }

        public void Delete(IList<LOMDTO00075> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
            }
            CXClientWrapper.Instance.Invoke<ILOMSVE00075>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.AGLoanProductTypeItemSetupView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);

            }
            else
            {
                this.AGLoanProductTypeItemSetupView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public IList<LOMDTO00075> GetAll()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00075, IList<LOMDTO00075>>(service => service.GetAll());
        }

        public LOMDTO00075 SelectByAGLoanProductTypeItemSeasonCode(string seasonCode)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00075, LOMDTO00075>(service => service.SelectByAGLoanProductTypeItemSeasonCode(seasonCode));
        }
        #endregion
    }
}
