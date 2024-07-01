using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Sve;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00031 : AbstractPresenter, ILOMCTL00031
    {
        #region "Properties"
        //private const string landandbuilding = "Land & Building";
        //private const string guarantee = "Guarantee";
        //private const string pledge = "Pledge";
        //private const string hypothecation = "Hypothecation";
        //private const string goldjewel = "Gold & Jewellery";
       // private const string cng = "CNG";
        #endregion

        #region "WireTo"
        //private ILOMVEW00031 loandataregistrationView;
        //public ILOMVEW00031 RegistrationDataEnquiryView
        //{
        //    get
        //    {
        //        return this.loandataregistrationView;
        //    }
        //    set
        //    {
        //        this.WireTo(value);
        //    }
        //}
        //private void WireTo(ILOMVEW00031 view)
        //{
        //    if (this.loandataregistrationView == null)
        //    {
        //        this.loandataregistrationView = view;
        //        this.Initialize(this.loandataregistrationView, null);
        //    }
        //}  
        private ILOMVEW00031 loandataregistrationView;
        public ILOMVEW00031 RegistrationDataEnquiryView
        {
            get
            {
                return this.loandataregistrationView;
            }
            set
            {
                this.WireTo(value);
            }
        }
        private void WireTo(ILOMVEW00031 view)
        {
            if (this.loandataregistrationView == null)
            {
                this.loandataregistrationView = view;
                this.Initialize(this.loandataregistrationView, null);
            }
        }        
        #endregion 

        #region "Public Methods"

        public void ClearCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }

        public void GetTransaction()
        {
            try
            {
                //switch (this.RegistrationDataEnquiryView.LoanType)
                //{
                //    case "":
                //        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00110);
                //        break;
                //    case "All": this.HelperTransit("All");
                //        break;
                //    case "LB": this.HelperTransit("Land and Building");
                //        break;
                //    case "PL": this.HelperTransit("Pledge");
                //        break;
                //    case "GL": this.HelperTransit("Gold And Jwelly");
                //        break;
                //    case "HP": this.HelperTransit("Hypothecation");
                //        break;
                //    case "PG": this.HelperTransit("Personal Guarantee");
                //        break;                    
                //}
                if (this.RegistrationDataEnquiryView.LoanType == "")
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00110);
                    return;
                }
                else
                {
                    this.HelperTransit(this.RegistrationDataEnquiryView.LoanType);
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception (ex.InnerException +ex.Message);
            }
        }

        #endregion

        #region "Event"
        private void HelperTransit(string typeName)
        {
            CXUIScreenTransit.Transit("frmLOMVEW00034", true, new object[] { typeName });
        }
        public IList<LOMDTO00001> BindLoansBType()
        {
            IList<LOMDTO00001> LoansBTypeDto = CXClientWrapper.Instance.Invoke<ILOMSVE00011, IList<LOMDTO00001>>(x => x.BindLoansBType());
            return LoansBTypeDto;
        }
        #endregion
    }
}
