using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Windows.CXClient;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Core.Utt;
using Ace.Windows.Ix.Client.Utt;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00415: AbstractPresenter, ILOMCTL00415
    {
        #region Properties

        public LOMCTL00415() { }

        private ILOMVEW00415 view;
        public ILOMVEW00415 PersonalLoanProductCodeEntryView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(ILOMVEW00415 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.view.ViewData);                
            }
        }

        #endregion

        #region Methods
        public void Save(LOMDTO00415 entity)
        {
            IList<DataVersionChangedValueDTO> dvcvList = new List<DataVersionChangedValueDTO>();
            if (this.PersonalLoanProductCodeEntryView.Status.Equals("Save"))
            {
                IList<LOMDTO00415> ProductCodeInfo = CXClientWrapper.Instance.Invoke<ILOMSVE00415, IList<LOMDTO00415>>(x => x.CheckExist2(entity.ProductCode, entity.RelatedGLACode, entity.Description));
                if (ProductCodeInfo.Count > 0)
                {
                    CXUIMessageUtilities.ShowMessageByCode("MV90001");//data already exists      
                    return;
                }
                else
                {
                    CXClientWrapper.Instance.Invoke<ILOMSVE00415>(x => x.Save(entity));

                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        this.PersonalLoanProductCodeEntryView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        this.view.ProductCode = string.Empty;
                        this.view.Description = string.Empty;
                        this.view.RelatedGLACode = string.Empty;
                        this.SetFocus("txtProductCode");
                    }
                    else
                    {
                        this.PersonalLoanProductCodeEntryView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }
            }

            else
            {
                dvcvList = GetChangedValueOfObject.GetChangedValueList(this.PersonalLoanProductCodeEntryView.PreviousProductCodeDto, entity);
                CXClientWrapper.Instance.Invoke<ILOMSVE00415>(x => x.Update(entity));

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                {
                    string s = CXClientWrapper.Instance.ServiceResult.MessageCode;
                    this.PersonalLoanProductCodeEntryView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
                else
                    this.PersonalLoanProductCodeEntryView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                this.SetFocus("txtDescription");

            }
        }

        public void Delete(IList<LOMDTO00415> itemList)
        {
          
            CXClientWrapper.Instance.Invoke<ILOMSVE00415>(x => x.Delete(itemList));

            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                this.PersonalLoanProductCodeEntryView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            else
                this.PersonalLoanProductCodeEntryView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
        }

        public IList<LOMDTO00415> GetAll()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00415, IList<LOMDTO00415>>(service => service.GetAll()); 
        }

        public IList<LOMDTO00415> SelectAll_ACode()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00415, IList<LOMDTO00415>>(service => service.SelectAll_ACode()); 
        }
        #endregion
    }
}
