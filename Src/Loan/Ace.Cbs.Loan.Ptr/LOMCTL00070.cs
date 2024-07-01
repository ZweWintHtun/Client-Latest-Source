using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Windows.Ix.Client.Utt;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00070 : AbstractPresenter, ILOMCTL00070
    {
        #region Properties

        public LOMCTL00070() { }

        private ILOMVEW00070 view;
        public ILOMVEW00070 VillageGroupEntryView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(ILOMVEW00070 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.view.ViewData);                
            }
        }

        #endregion

        #region Methods
        public void Save(LOMDTO00070 entity)
        {
            if (!this.ValidateForm(entity))
            {
                if (entity.VillageCode == string.Empty)
                    this.SetFocus("txtCode");
                else if (entity.VillageCode != string.Empty)
                    this.SetFocus("txtDescription");
                return;
            }
            IList<DataVersionChangedValueDTO> dvcvList = new List<DataVersionChangedValueDTO>();
            if (this.VillageGroupEntryView.Status.Equals("Save"))
            {
                entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;

                IList<LOMDTO00070> VillageGroupInfo = CXClientWrapper.Instance.Invoke<ILOMSVE00070, IList<LOMDTO00070>>(x => x.CheckExist2(entity.VillageCode, entity.Desp));
                if (VillageGroupInfo.Count > 0)
                {
                    LOMDTO00070 villageGroupActive = VillageGroupInfo.Where<LOMDTO00070>(x => x.Active == false).FirstOrDefault();
                    if (villageGroupActive != null) //Data exist with active 0 , deleted , so data will be save with update nature
                    {
                        if (villageGroupActive.VillageCode == entity.VillageCode)
                        {
                            entity.TS = villageGroupActive.TS;
                            //cityActive.Active = true;  //to save with active when changingValueOfObject   
                            dvcvList = GetChangedValueOfObject.GetChangedValueList(villageGroupActive, entity);
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
                CXClientWrapper.Instance.Invoke<ILOMSVE00070>(x => x.SaveServerAndServerClient(entity, dvcvList));
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                {
                    this.VillageGroupEntryView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.view.VillageCode = string.Empty;
                    this.view.Description = string.Empty;
                    this.SetFocus("txtCode");
                }
                else
                {
                    this.VillageGroupEntryView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
            }

            else
            {
                entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                dvcvList = GetChangedValueOfObject.GetChangedValueList(this.VillageGroupEntryView.PreviousVillageGroupDto, entity);
                CXClientWrapper.Instance.Invoke<ILOMSVE00070>(x => x.Update(entity, dvcvList, "Update"));

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                {
                    string s = CXClientWrapper.Instance.ServiceResult.MessageCode;
                    this.VillageGroupEntryView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.SetFocus("txtCode");
                }
                else
                {
                    this.VillageGroupEntryView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.SetFocus("txtDescription");
                }
            }
        }

        public void Delete(IList<LOMDTO00070> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
            }
            CXClientWrapper.Instance.Invoke<ILOMSVE00070>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.VillageGroupEntryView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);

            }
            else
            {
                this.VillageGroupEntryView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public IList<LOMDTO00070> GetAll()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00070, IList<LOMDTO00070>>(service => service.GetAll()); 
        }
        #endregion
    }
}
