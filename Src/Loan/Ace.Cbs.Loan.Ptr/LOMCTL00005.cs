using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Windows.CXClient;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Client.Utt;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00005 : AbstractPresenter, ILOMCTL00005
    {
        #region Properties
        private ILOMVEW00005 _view;
        public ILOMVEW00005 LandView
        {
            get { return this._view; }
            set { this.WireTo(value); }
        }

        #endregion

        #region Helper Methods
        private void WireTo(ILOMVEW00005 view)
        {
            if (this._view == null)
            {
                this._view = view;
                this.Initialize(this._view, this._view.ViewData);
            }
            
        }

        //private LOMDTO00001 GetLandDto()
        //{
        //    LOMDTO00001 landDto = new LOMDTO00001();
        //    landDto.Code = this.LandView.lCode;
        //    landDto.Description = this.LandView.lDesp;
        //    return landDto;
        //}

        //public override bool ValidateForm(object validationContext)
        //{
        //    return base.ValidateForm(validationContext);
        //}

        #endregion

        #region Implementation

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
                if (this._view.Status.Equals("Save"))
                {
                    entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                    entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;

                    IList<LOMDTO00001> LandInfo = CXClientWrapper.Instance.Invoke<ILOMSVE00005, IList<LOMDTO00001>>(x => x.CheckExist2(entity.Code, entity.Description));
                    if (LandInfo.Count > 0)
                    {
                        LOMDTO00001 landActive = LandInfo.Where<LOMDTO00001>(x => x.Active == false).FirstOrDefault();
                        if (landActive != null)   //Data exist with active 0 , deleted , so data will be save with update nature
                        {
                            if (landActive.Code == entity.Code)
                            {
                                entity.TS = landActive.TS;
                                //cityActive.Active = true;  //to save with active when changingValueOfObject   
                                dvcvList = GetChangedValueOfObject.GetChangedValueList(landActive, entity);
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
                    //CXClientWrapper.Instance.Invoke<ILOMSVE00005>(x => x.SaveServerAndServerClient(entity));
                    CXClientWrapper.Instance.Invoke<ILOMSVE00005>(x => x.SaveServerAndServerClient(entity,dvcvList));
                    this.SaveClient(entity);
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        //this._view.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        this._view.ControlSetting("Land.Enable", true);
                         this.SetFocus("txtCode");
                    }
                    else
                    {
                        this.LandView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }
                else
                {
                    //try
                    //{
                        entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                        dvcvList = GetChangedValueOfObject.GetChangedValueList(this.LandView.PreviousLandDto, entity);
                        CXClientWrapper.Instance.Invoke<ILOMSVE00005>(x => x.Update(entity, dvcvList,"Update"));
                        if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                        {
                            this.LandView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                            this.LandView.ControlSetting("Land.Enable", true);
                             this.SetFocus("txtCode");
                        }
                        else
                        {
                            this.LandView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                            this.SetFocus("txtDescription");
                        }
                    //}
                    //catch (Exception)
                    //{
                    //    throw new Exception("Error");
                    //}
                }
            
        }
        public void SaveClient(LOMDTO00001 entity)
        {
            try
            {               
                Dictionary<string, object> keyPair = new Dictionary<string, object>
                {
                    {"LandCode", entity.Code},
                    {"LandDescription", entity.Description}
                };
                ClientSQLiteDataHandler.Instance.InsertClient("LAND", keyPair, entity.TS, entity.CreatedUserId, entity.CreatedDate);
                this.LandView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            catch (Exception)
            {
                this.LandView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }
        public void Delete(IList<LOMDTO00001> itemList)
        {
            foreach (LOMDTO00001 item in itemList)
            {
                item.UpdatedUserId = CurrentUserEntity.CurrentUserID;
            }

            CXClientWrapper.Instance.Invoke<ILOMSVE00005>(x => x.Delete(itemList));

            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this._view.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                this._view.ControlSetting("Land.Enable", true);
            }
            else
            {
                this._view.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public IList<LOMDTO00001> SelectAll()
        {
            IList<LOMDTO00001> list = CXClientWrapper.Instance.Invoke<ILOMSVE00005, LOMDTO00001>(x => x.SelectAll());
            return list;
        }

        public LOMDTO00001 SelectByLandCode(string code)
        {
            LOMDTO00001 data = CXClientWrapper.Instance.Invoke<ILOMSVE00005, LOMDTO00001>(x => x.SelectByLandCode(code));
            return data;
        }

        #endregion
    }
}
