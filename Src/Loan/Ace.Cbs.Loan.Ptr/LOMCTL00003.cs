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
    public class LOMCTL00003 : AbstractPresenter, ILOMCTL00003
    {
        #region Properties

        public LOMCTL00003() { }

        private ILOMVEW00003 view;
        public ILOMVEW00003 CharacterCodeView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(ILOMVEW00003 view)
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

        public void Save(LOMDTO00001 entity)
        {
             if (!this.ValidateForm(entity))
                {
                    if (entity.Code == string.Empty)
                        this.SetFocus("txtCode");
                    else if (entity.Code != string.Empty)
                        this.SetFocus("txtDescription");
                    return;
                }
             IList<DataVersionChangedValueDTO> dvcvList = new List<DataVersionChangedValueDTO>();
             if (this.CharacterCodeView.Status.Equals("Save"))
             {
                 entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                 entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                 IList<LOMDTO00001> CharacterCodeInfo = CXClientWrapper.Instance.Invoke<ILOMSVE00003, IList<LOMDTO00001>>(x => x.CheckExist2(entity.Code, entity.Description));
                 if (CharacterCodeInfo.Count > 0)
                 {
                     LOMDTO00001 characterCodeActive = CharacterCodeInfo.Where<LOMDTO00001>(x => x.Active == false).FirstOrDefault();
                     if (characterCodeActive != null)   //Data exist with active 0 , deleted , so data will be save with update nature
                     {
                         if (characterCodeActive.Code == entity.Code)
                         {
                             entity.TS = characterCodeActive.TS;                             
                             dvcvList = GetChangedValueOfObject.GetChangedValueList(characterCodeActive, entity);
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

                 //CXClientWrapper.Instance.Invoke<ILOMSVE00003>(x => x.SaveServerAndServerClient(entity));
                 CXClientWrapper.Instance.Invoke<ILOMSVE00003>(x => x.SaveServerAndServerClient(entity,dvcvList));
                 this.SaveClient(entity);
                 if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                 {
                     this.CharacterCodeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                     this.view.CharacterCode = string.Empty;
                     this.view.Description = string.Empty;
                     this.SetFocus("txtCode");
                 }
                 else
                 {
                     this.CharacterCodeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                 }
             }
             else
             {
                 entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                 dvcvList = GetChangedValueOfObject.GetChangedValueList(this.CharacterCodeView.PreviousCharacterCodeDto, entity);
                 CXClientWrapper.Instance.Invoke<ILOMSVE00003>(x => x.Update(entity, dvcvList,"Update"));
                 if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                 {
                     string s = CXClientWrapper.Instance.ServiceResult.MessageCode;
                     this.CharacterCodeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                     this.SetFocus("txtCode");
                 }
                 else
                 {
                     this.CharacterCodeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                     this.SetFocus("txtDescription");
                 }
             }
        }
        public void SaveClient(LOMDTO00001 entity)
        {
            try
            {
                Dictionary<string, object> charactercodeKeyPair = new Dictionary<string, object> {
                { "CharacterCode", entity.Code },
                { "CharacterDescription", entity.Description } };
                ClientSQLiteDataHandler.Instance.InsertClient("CustomerCharacterCode", charactercodeKeyPair, entity.TS, entity.CreatedUserId, entity.CreatedDate);
                this.CharacterCodeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            catch (Exception)
            {
                this.CharacterCodeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }
        public void Delete(IList<LOMDTO00001> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
            }
            CXClientWrapper.Instance.Invoke<ILOMSVE00003>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.CharacterCodeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            else
            {
                this.CharacterCodeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public IList<LOMDTO00001> GetAll()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00003, IList<LOMDTO00001>>(service => service.GetAll());
        }

        public LOMDTO00001 SelectByCode(string characterCode)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00003, LOMDTO00001>(service => service.SelectByCode(characterCode));
        }

        #endregion
    }
}
