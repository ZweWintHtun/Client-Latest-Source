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
    public class LOMCTL00071 : AbstractPresenter, ILOMCTL00071
    {
           #region Properties

        public LOMCTL00071() { }
        private ILOMVEW00071 view;
        public ILOMVEW00071 SeasonCodeView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(ILOMVEW00071 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.view.ViewData);                
            }
        }

        #endregion

        #region Methods

        //public override bool ValidateForm(object validationContext)
        //{
        //    return base.ValidateForm(validationContext);
            
        //}

        public void Save(LOMDTO00071 entity)
        {
            if (!this.ValidateForm(entity))
            {
                if (entity.Code == string.Empty )
                    this.SetFocus("txtCode");
                else if (entity.Code != string.Empty)
                    this.SetFocus("txtDescription");               
                return;
            }
            IList<DataVersionChangedValueDTO> dvcvList = new List<DataVersionChangedValueDTO>();
           if (this.SeasonCodeView.Status.Equals("Save"))
            {
                entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;

                IList<LOMDTO00071> SeasonCodeInfo = CXClientWrapper.Instance.Invoke<ILOMSVE00071, IList<LOMDTO00071>>(x => x.CheckExist2(entity.Code, entity.Description));
                if (SeasonCodeInfo.Count > 0)
                {
                    LOMDTO00071 typeOfAdvanceActive = SeasonCodeInfo.Where<LOMDTO00071>(x => x.Active == false).FirstOrDefault();
                    if (typeOfAdvanceActive != null)   //Data exist with active 0 , deleted , so data will be save with update nature
                    {
                        if (typeOfAdvanceActive.Code == entity.Code)
                        {
                            entity.TS = typeOfAdvanceActive.TS;
                            //cityActive.Active = true;  //to save with active when changingValueOfObject   
                            dvcvList = GetChangedValueOfObject.GetChangedValueList(typeOfAdvanceActive, entity);
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
               //CXClientWrapper.Instance.Invoke<ILOMSVE00071>(x => x.SaveServerAndServerClient(entity));
                CXClientWrapper.Instance.Invoke<ILOMSVE00071>(x => x.SaveServerAndServerClient(entity, dvcvList));
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                {
                    this.SeasonCodeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.view.Code = string.Empty;
                    this.view.Description = string.Empty;
                    this.SetFocus("txtCode");                    
                }
                else
                {
                    this.SeasonCodeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);                    
                }               
            }

            else
            {
                entity.SourceBranchCode = CurrentUserEntity.BranchCode;
                entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                dvcvList = GetChangedValueOfObject.GetChangedValueList(this.SeasonCodeView.PreviousSeasonCodeDto, entity);
                CXClientWrapper.Instance.Invoke<ILOMSVE00071>(x => x.Update(entity, dvcvList, "Update"));

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                {
                    string s = CXClientWrapper.Instance.ServiceResult.MessageCode;
                    this.SeasonCodeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.SetFocus("txtCode");
                }
                else
                {
                    this.SeasonCodeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.SetFocus("txtDescription");
                }
            }          
        }

        public void Delete(IList<LOMDTO00071> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;                
            }
            CXClientWrapper.Instance.Invoke<ILOMSVE00071>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.SeasonCodeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
               
            }
            else
            {
                this.SeasonCodeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public IList<LOMDTO00071> GetAll()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00071, IList<LOMDTO00071>>(service => service.GetAll());
        }

        public LOMDTO00071 SelectBySeasonCode(string seasonCode)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00071, LOMDTO00071>(service => service.SelectBySeasonCode(seasonCode));
        }

        //public void txtDescription_CustomValidating(object sender, ValidationEventArgs e)
        //{
        //   if(string.IsNullOrEmpty(this.view.Description))
        //   {
        //       CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90005); //Description is required.
        //       this.SetFocus("txtDescription");
        //       return;
        //   }
        //}

        #endregion
    }
}
