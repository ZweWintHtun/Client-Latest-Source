using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Client.Utt;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00010 : AbstractPresenter, ILOMCTL00010
    {
        #region Constructor
        public LOMCTL00010() { }
        #endregion

        #region Properties

        private ILOMVEW00010 view;
        public ILOMVEW00010 GJKCodeView
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00010 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, GetGJKDto());
            }
        }

        private LOMDTO00008 GetGJKDto()
        {
            LOMDTO00008 gjkDto = new LOMDTO00008();
            gjkDto.Kind = this.view.Kind;
            gjkDto.Description = this.view.Description;
            return gjkDto;
        }

        #endregion

        #region Methods

        //public override bool ValidateForm(object validationContext)
        //{
        //    return base.ValidateForm(validationContext);
        //}

        public IList<LOMDTO00008> SelectAll()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00010, LOMDTO00008>(x => x.SelectAll());
        }

        public void Save(LOMDTO00008 entity)
        {
           
            if (!this.ValidateForm(entity))
            {
                if (entity.Kind == string.Empty)
                    this.SetFocus("txtKind");
                else if (entity.Kind != string.Empty)
                    this.SetFocus("txtDescription");
                return;
            }
                IList<DataVersionChangedValueDTO> dvcvList = new List<DataVersionChangedValueDTO>();
                if (this.GJKCodeView.Status.Equals("Save"))
                {
                    entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                    entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;

                    IList<LOMDTO00008> GJKCodeInfo = CXClientWrapper.Instance.Invoke<ILOMSVE00010, IList<LOMDTO00008>>(x => x.CheckExist2(entity.Kind, entity.Description));
                    if (GJKCodeInfo.Count > 0)
                    {
                        LOMDTO00008 gJKCodeActive = GJKCodeInfo.Where<LOMDTO00008>(x => x.Active == false).FirstOrDefault();
                        if (gJKCodeActive != null)   //Data exist with active 0 , deleted , so data will be save with update nature
                        {
                            if (gJKCodeActive.Kind == entity.Kind)
                            {
                                entity.TS = gJKCodeActive.TS;
                                //cityActive.Active = true;  //to save with active when changingValueOfObject   
                                dvcvList = GetChangedValueOfObject.GetChangedValueList(gJKCodeActive, entity);
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
                    //CXClientWrapper.Instance.Invoke<ILOMSVE00010>(x => x.SaveServerAndServerClient(entity));
                    CXClientWrapper.Instance.Invoke<ILOMSVE00010>(x => x.SaveServerAndServerClient(entity,dvcvList));
                    this.SaveClient(entity);
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        //this.GJKCodeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        this.GJKCodeView.ControlSetting("GJK.Enable", true);
                    }
                    else
                    {
                        this.GJKCodeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }

                else
                {
                    entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                    dvcvList = GetChangedValueOfObject.GetChangedValueList(this.GJKCodeView.PreviousGJKDto, entity);
                    CXClientWrapper.Instance.Invoke<ILOMSVE00010>(x => x.Update(entity, dvcvList,"Update"));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        this.GJKCodeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        this.GJKCodeView.ControlSetting("GJK.Enable", true);
                    }
                    else
                    {
                        this.GJKCodeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }
          //  }
        }

        public void SaveClient(LOMDTO00008 entity)
        {
            try
            {
                Dictionary<string, object> keyPair = new Dictionary<string, object>
                {
                    {"Gjkind", entity.Kind},
                    {"Desp", entity.Description}
                };
                ClientSQLiteDataHandler.Instance.InsertClient("GJKCode", keyPair, entity.TS, entity.CreatedUserId, entity.CreatedDate);
                this.GJKCodeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            catch (Exception)
            {
                this.GJKCodeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }
        public void Delete(IList<LOMDTO00008> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
            }
            CXClientWrapper.Instance.Invoke<ILOMSVE00010>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.GJKCodeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                this.GJKCodeView.ControlSetting("GJK.Enable", true);
            }
            else
            {
                this.GJKCodeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public LOMDTO00008 SelectByGjkCode(string gjkind)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00010, LOMDTO00008>(x => x.SelectByGJKind(gjkind));
        }

        #endregion

    }
}
