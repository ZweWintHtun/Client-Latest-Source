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
    public class LOMCTL00326 : AbstractPresenter, ILOMCTL00326
    {
        public LOMDTO00326 dto;
        private ILOMVEW00326 view;
        public ILOMVEW00326 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00326 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }

        public string CheckPLAccountandStartTerm(string plNo, string sourceBr)
        {
            string str = CXClientWrapper.Instance.Invoke<ILOMSVE00311, string>(x => x.CheckPLAccountandStartTerm(plNo, sourceBr));
            return str;
        }

        public string Get_PL_PrepaymentInfo_NewLogic(string plNo, int startTerm, int endTerm, string sourceBr)
        {
            string str = CXClientWrapper.Instance.Invoke<ILOMSVE00311, string>(x => x.Get_PL_PrepaymentInfo_NewLogic(plNo, startTerm, endTerm, sourceBr));
            return str;
        }

        public string PL_Manual_Pre_Payment_Process_NewLogic(string plNo, int startTerm, int endTerm, decimal totalPaidInstallmentAmt, decimal totalPaidPrincipleAmt, decimal totalPaidRentalChgAmt,
                                            decimal rentalDiscountRate, string eno, string sourceBr, int createdUserId, string userName)
        {
            string str = CXClientWrapper.Instance.Invoke<ILOMSVE00311, string>(x => x.PL_Manual_Pre_Payment_Process_NewLogic(plNo, startTerm, endTerm, totalPaidInstallmentAmt, totalPaidPrincipleAmt, totalPaidRentalChgAmt,
                                                                                                                    rentalDiscountRate, eno, sourceBr, createdUserId, userName));
            return str;
        }

    }
}
