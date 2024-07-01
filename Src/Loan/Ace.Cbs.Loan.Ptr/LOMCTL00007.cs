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
    public class LOMCTL00007 : AbstractPresenter, ILOMCTL00007
    {  
        
        #region Properties

        public LOMCTL00007() { }

        private ILOMVEW00007 view;
        public ILOMVEW00007 StockNoView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(ILOMVEW00007 view)
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

        public void Save(LOMDTO00009 entity)
        {

            if (!this.ValidateForm(entity))
            {
                if (entity.StockNo == string.Empty)
                    this.SetFocus("txtStock");
                else if (entity.StockNo != string.Empty )
                    this.SetFocus("txtName");

                return;
            }
            IList<DataVersionChangedValueDTO> dvcvList = new List<DataVersionChangedValueDTO>();
               
                if (this.StockNoView.Status.Equals("Save"))
                {
                    entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                    entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                    IList<LOMDTO00009> StockInfo = CXClientWrapper.Instance.Invoke<ILOMSVE00007, IList<LOMDTO00009>>(x => x.CheckExist2(entity.StockNo, entity.Name));
                    if (StockInfo.Count > 0)
                    {
                        LOMDTO00009 StockActive = StockInfo.Where<LOMDTO00009>(x => x.Active == false).FirstOrDefault();
                        if (StockActive != null)   //Data exist with active 0 , deleted , so data will be save with update nature
                        {
                            if (StockActive.StockNo == entity.StockNo)
                            {
                                entity.TS = StockActive.TS;
                                //cityActive.Active = true;  //to save with active when changingValueOfObject   
                                dvcvList = GetChangedValueOfObject.GetChangedValueList(StockActive, entity);
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
                    CXClientWrapper.Instance.Invoke<ILOMSVE00007>(x => x.SaveServerAndServerClient(entity, dvcvList));
                    this.SaveClient(entity);
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        this.StockNoView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        this.view.StockNo= string.Empty;
                        this.view.Name = string.Empty;
                        this.SetFocus("txtStock");
                    
                    }
                    else
                    {
                        this.StockNoView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }

                else  //Update
                {
                    entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                    dvcvList = GetChangedValueOfObject.GetChangedValueList(this.StockNoView.PreviousStockNoDto, entity);
                    CXClientWrapper.Instance.Invoke<ILOMSVE00007>(x => x.Update(entity, dvcvList, "Update"));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        string s = CXClientWrapper.Instance.ServiceResult.MessageCode;
                        this.StockNoView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        this.SetFocus("txtStock");
                    }
                    else
                    {
                        this.StockNoView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        this.SetFocus("txtName");
                    }
                }
          //  }
        }
        public void SaveClient(LOMDTO00009 entity)
        {
            try
            {
                Dictionary<string, object> stockNoKeyPair = new Dictionary<string, object> 
                { 
                    { "STOCKNO", entity.StockNo }, 
                    { "STOCKNAME", entity.Name } 
                };
                ClientSQLiteDataHandler.Instance.InsertClient("STOCK", stockNoKeyPair, entity.TS, entity.CreatedUserId, entity.CreatedDate);
                this.StockNoView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            catch (Exception)
            {
                this.StockNoView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public void Delete(IList<LOMDTO00009> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
            }
            CXClientWrapper.Instance.Invoke<ILOMSVE00007>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.StockNoView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            else
            {
                this.StockNoView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public IList<LOMDTO00009> GetAll()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00007, IList<LOMDTO00009>>(service => service.GetAll());
        }

        public LOMDTO00009 SelectByCode(string stockNo)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00007, LOMDTO00009>(service => service.SelectByCode(stockNo));
        }

        #endregion


    }
}
