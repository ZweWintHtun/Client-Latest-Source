using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Windows.Ix.Client.Utt;

namespace Ace.Cbs.Loan.Ptr
{
     public class LOMCTL00072 : AbstractPresenter, ILOMCTL00072
    {
        #region Properties

        public LOMCTL00072() { }

        private ILOMVEW00072 view;
        public ILOMVEW00072 CropTypeEntryView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(ILOMVEW00072 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.view.ViewData);                
            }
        }

        #endregion

        #region Methods
        public void Save(LOMDTO00072 entity)
        {
            if (!this.ValidateForm(entity))
            {
                if (entity.CropCode == string.Empty)
                    this.SetFocus("txtCode");
                else if (entity.CropCode != string.Empty)
                    this.SetFocus("txtDescription");
                return;
            }
            IList<DataVersionChangedValueDTO> dvcvList = new List<DataVersionChangedValueDTO>();
            if (this.CropTypeEntryView.Status.Equals("Save"))
            {
                entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;

                IList<LOMDTO00072> CropTypeInfo = CXClientWrapper.Instance.Invoke<ILOMSVE00072, IList<LOMDTO00072>>(x => x.CheckExist2(entity.CropCode, entity.Desp));
                if (CropTypeInfo.Count > 0)
                {
                    LOMDTO00072 cropTypeActive = CropTypeInfo.Where<LOMDTO00072>(x => x.Active == false).FirstOrDefault();
                    if (cropTypeActive != null) //Data exist with active 0 , deleted , so data will be save with update nature
                    {
                        if (cropTypeActive.CropCode == entity.CropCode)
                        {
                            entity.TS = cropTypeActive.TS;
                            //cityActive.Active = true;  //to save with active when changingValueOfObject   
                            dvcvList = GetChangedValueOfObject.GetChangedValueList(cropTypeActive, entity);
                            entity.Active = false;  //to check status in service
                        }
                    }
                    else
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MV90001");//data already exists      
                        return;
                    }
                }
                else entity.Active = true;//active = 1 , new data , so data will be save with insert nature 
                //CXClientWrapper.Instance.Invoke<ILOMSVE00002>(x => x.SaveServerAndServerClient(entity));
                CXClientWrapper.Instance.Invoke<ILOMSVE00072>(x => x.SaveServerAndServerClient(entity, dvcvList));
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                {
                    this.CropTypeEntryView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.view.CropCode = string.Empty;
                    this.view.Description = string.Empty;
                    this.SetFocus("txtCode");
                }
                else
                {
                    this.CropTypeEntryView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
            }

            else
            {
                entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                dvcvList = GetChangedValueOfObject.GetChangedValueList(this.CropTypeEntryView.PreviousCropTypeDto, entity);
                CXClientWrapper.Instance.Invoke<ILOMSVE00072>(x => x.Update(entity, dvcvList, "Update"));

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                {
                    string s = CXClientWrapper.Instance.ServiceResult.MessageCode;
                    this.CropTypeEntryView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.SetFocus("txtCode");
                }
                else
                {
                    this.CropTypeEntryView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.SetFocus("txtDescription");
                }
            }
        }

        public void Delete(IList<LOMDTO00072> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
            }
            CXClientWrapper.Instance.Invoke<ILOMSVE00072>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.CropTypeEntryView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);

            }
            else
            {
                this.CropTypeEntryView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public IList<LOMDTO00072> GetAll()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00072, IList<LOMDTO00072>>(service => service.GetAll()); 
        }
        #endregion
    }
}
