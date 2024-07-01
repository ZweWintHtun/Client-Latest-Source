using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Sam.Ctr.Sve;
using Ace.Cbs.Sam.Ctr.Ptr;
using Ace.Cbs.Sam.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Client.Utt;
using System.Linq;


namespace Ace.Cbs.Sam.Ptr
{
    public class SAMCTL00053 : AbstractPresenter, ISAMCTL00053
    {
         #region Properties

        public SAMCTL00053() { }
        private ISAMVEW00053 view;
        public ISAMVEW00053 NationalityCodeView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(ISAMVEW00053 view)
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

        public void Save(SAMDTO00053 entity)
        {
               
             if (!this.ValidateForm(entity))
            {
                if (entity.Nationality_Code == string.Empty)
                    this.SetFocus("txtCode");
                else if (entity.Nationality_Code!= string.Empty)
                    this.SetFocus("txtDescription");
                return;
            }
                IList<DataVersionChangedValueDTO> dvcvList = new List<DataVersionChangedValueDTO>();
                if (this.NationalityCodeView.Status.Equals("Save"))
                {
                    entity.UserNo = CurrentUserEntity.CurrentUserID.ToString ();
                    entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                    entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                    IList<SAMDTO00053> NationalityInfo = CXClientWrapper.Instance.Invoke<ISAMSVE00053, IList<SAMDTO00053>>(x => x.CheckExist2(entity.Nationality_Code, entity.Description));
                    if (NationalityInfo.Count > 0)
                    {
                        SAMDTO00053 NationalityActive = NationalityInfo.Where<SAMDTO00053>(x => x.Active == false).FirstOrDefault();
                        if (NationalityActive != null)   //Data exist with active 0 , deleted , so data will be save with update nature
                        {
                            if (NationalityActive.Nationality_Code == entity.Nationality_Code)
                            {
                                entity.TS = NationalityActive.TS;
                                //cityActive.Active = true;  //to save with active when changingValueOfObject   
                                dvcvList = GetChangedValueOfObject.GetChangedValueList(NationalityActive, entity);
                                entity.Active = false;  //to check status in service
                            }
                        }
                        else
                        {
                            CXUIMessageUtilities.ShowMessageByCode("MV90001");//data already exists      
                            return;
                        }
                    }
                    else entity.Active = true;    //active = 1 , new data , so data will be save with insert nature 

                    //CXClientWrapper.Instance.Invoke<ICityService>(x => x.SaveServerAndServerClient(entity));
                    CXClientWrapper.Instance.Invoke<ISAMSVE00053>(x => x.SaveServerAndServerClient(entity, dvcvList));
                    this.SaveClient(entity);
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        this.NationalityCodeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                    else
                    {
                        this.NationalityCodeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }

                else //Update
                {                    
                    entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                    dvcvList = GetChangedValueOfObject.GetChangedValueList(this.NationalityCodeView.PreviousNationalityDto, entity);
                    CXClientWrapper.Instance.Invoke<ISAMSVE00053>(x => x.Update(entity, dvcvList, "Update"));
                  
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        string s = CXClientWrapper.Instance.ServiceResult.MessageCode;
                        this.NationalityCodeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                    else
                    {
                        this.NationalityCodeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }
            //}
        }
        public void SaveClient(SAMDTO00053 entity)
        {
            try
            {
                Dictionary<string, object> nationalityKeyPair = new Dictionary<string, object> 
                { 
                    { "NationalityCode", entity.Nationality_Code }, 
                    { "Desp", entity.Description }, 
                    { "UserNo", entity.UserNo }, 
                    { "Date_Time", DateTime.Now } 
                };
                ClientSQLiteDataHandler.Instance.InsertClient("NationalityCode", nationalityKeyPair, entity.TS, entity.CreatedUserId, entity.CreatedDate);
                this.NationalityCodeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            catch (Exception)
            {
                this.NationalityCodeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public void Delete(IList<SAMDTO00053> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
                itemList[i].CreatedUserId = CurrentUserEntity.CurrentUserID;
            }
            CXClientWrapper.Instance.Invoke<ISAMSVE00053>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.NationalityCodeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            else
            {
                this.NationalityCodeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public IList<SAMDTO00053> GetAll()
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00053, IList<SAMDTO00053>>(service => service.GetAll());
            //return CXCLE00002.Instance.GetListObject<SAMDTO00053>("SAMORM00053.Client.SelectAll",new object[]{true});
        }

        public SAMDTO00053 SelectByNationalityCode(string NationalityCode)
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00053, SAMDTO00053>(service => service.SelectByNationalityCode(NationalityCode));
            //return CXCLE00002.Instance.GetScalarObject<SAMDTO00053>("SAMORM00053.Client.SelectByNationalityCode", new object[] { NationalityCode ,true});
        }

        #endregion
    }
}
