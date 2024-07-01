using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00044 : AbstractPresenter, ILOMCTL00044
    {
        #region Properties
        private ILOMVEW00044 view;
        public ILOMVEW00044 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00044 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetEntity());
            }
        }

        public bool Validate_Form()
        {
            return this.ValidateForm(this.GetEntity());
        }
        #endregion

        #region Helper Method
        public LOMDTO00044 GetEntity()
        {
            LOMDTO00044 entity = new LOMDTO00044();
            entity.InterestCalculationDate = this.view.InterestCalculationDate;

            return entity;
        }
        #endregion

        #region Methods
        public void CalculateOD()
        {
            if (this.Validate_Form())
            {
                LOMDTO00044 DTO = this.GetEntity();
                CXClientWrapper.Instance.Invoke<ILOMSVE00044>(x => x.CalculateODInterest(DTO));
            }
        }
        #endregion
    }
}
