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
    public class LOMCTL00008 : AbstractPresenter, ILOMCTL00008
    {
         
        #region Properties

        public LOMCTL00008() { }

        private ILOMVEW00008 view;
        public ILOMVEW00008 KStockNoView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(ILOMVEW00008 view)
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

        public void Save(LOMDTO00010 entity)
        {

            if (!this.ValidateForm(entity))
            {
                if (entity.KStockNo == string.Empty)
                    this.SetFocus("txtStock");
                else if (entity.KStockNo != string.Empty)
                    this.SetFocus("txtDescription");

                return;
            }

            IList<DataVersionChangedValueDTO> dvcvList = new List<DataVersionChangedValueDTO>();
          
                if (this.KStockNoView.Status.Equals("Save"))
                {
                    entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                    entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                    IList<LOMDTO00010> KStockInfo = CXClientWrapper.Instance.Invoke<ILOMSVE00008, IList<LOMDTO00010>>(x => x.CheckExist2(entity.KStockNo, entity.Desp));
                    if (KStockInfo.Count > 0)
                    {
                        LOMDTO00010 KStockActive = KStockInfo.Where<LOMDTO00010>(x => x.Active == false).FirstOrDefault();
                        if (KStockActive != null)   //Data exist with active 0 , deleted , so data will be save with update nature
                        {
                            if (KStockActive.KStockNo == entity.KStockNo)
                            {
                                entity.TS = KStockActive.TS;
                                //cityActive.Active = true;  //to save with active when changingValueOfObject   
                                dvcvList = GetChangedValueOfObject.GetChangedValueList(KStockActive, entity);
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
                    CXClientWrapper.Instance.Invoke<ILOMSVE00008>(x => x.SaveServerAndServerClient(entity, dvcvList));
                    this.SaveClient(entity);
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        this.KStockNoView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        this.view.KStockNo = string.Empty;
                        this.view.Desp = string.Empty;
                        this.SetFocus("txtStock");
                    }
                    else
                    {
                        this.KStockNoView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }

                else  //Update
                {
                    entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                    dvcvList = GetChangedValueOfObject.GetChangedValueList(this.KStockNoView.PreviousKStockNoDto, entity);
                    CXClientWrapper.Instance.Invoke<ILOMSVE00008>(x => x.Update(entity, dvcvList, "Update"));

                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        string s = CXClientWrapper.Instance.ServiceResult.MessageCode;
                        this.KStockNoView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        this.SetFocus("txtStock");
                    }
                    else
                    {
                        this.KStockNoView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        this.SetFocus("txtDescription");
                    }
                }
           // }
        }
        public void SaveClient(LOMDTO00010 entity)
        {
            try
            {
                Dictionary<string, object> kstockNoKeyPair = new Dictionary<string, object> 
                { 
                    { "KSTOCK", entity.KStockNo }, 
                    { "DESP", entity.Desp } 
                };
                ClientSQLiteDataHandler.Instance.InsertClient("KSTOCK", kstockNoKeyPair, entity.TS, entity.CreatedUserId, entity.CreatedDate);
                this.KStockNoView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            catch (Exception)
            {
                this.KStockNoView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public void Delete(IList<LOMDTO00010> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
            }
            CXClientWrapper.Instance.Invoke<ILOMSVE00008>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.KStockNoView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            else
            {
                this.KStockNoView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public IList<LOMDTO00010> GetAll()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00008, IList<LOMDTO00010>>(service => service.GetAll());
        }

        public LOMDTO00010 SelectByCode(string kstockNo)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00008, LOMDTO00010>(service => service.SelectByCode(kstockNo));
        }

        #endregion



    }
}
