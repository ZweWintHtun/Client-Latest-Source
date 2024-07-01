using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Cx.Cle;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00039 : BaseForm
    {
        #region "Properties"
        private const string landandbuilding = "Land and Building";
        private const string guarantee = "Personal Guarantee";
        private const string pledge = "Pledge";
        private const string hypothecation = "Hypothecation";
        private const string goldjewel = "Gold and Jewellery";
        private const string all = "All";

        public string SelectedCode
        {
            get { return this.lbRegistration.SelectedValue.ToString(); }
            set { this.lbRegistration.SelectedValue = value; }
        }

        #endregion

        #region Contructor
        public LOMVEW00039()
        {
            InitializeComponent();
        }
        #endregion

        public void BindLoanProduct()
        {
            IList<LOMDTO00014> TypeOfProductList = CXCLE00002.Instance.GetListObject<LOMDTO00014>("LOMORM00014.SelectAllLandType", new object[] { true });
            LOMDTO00014 item = new LOMDTO00014();
            item.LOANSDESP = "All";
            item.LOANS_TYPE = "All";
            TypeOfProductList.Insert(0, item);

            TypeOfProductList = TypeOfProductList.OrderBy(x => x.LOANSDESP).ToList();

            this.lbRegistration.DisplayMember = "LOANSDESP";
            this.lbRegistration.ValueMember = "LOANS_TYPE";
            this.lbRegistration.DataSource = TypeOfProductList;

            //this.lbRegistration.datab
        }

        #region Events
        private void LOMVEW00039_Load(object sender, EventArgs e)
        {
            this.BindLoanProduct();
            this.Text = "Loans and Overdraft Rregistration Listing";
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, false, true);
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            try
            {
                switch (this.SelectedCode)
                {
                    case "":
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00110);
                        break;
                    case "LB":
                        this.Close();
                        this.HelperTransit(landandbuilding);
                        break;
                    case "PG":
                        this.Close();
                        this.HelperTransit(guarantee);
                        break;
                    case "PL":
                        this.Close();
                        this.HelperTransit(pledge);
                        break;
                    case "HP":
                        this.Close();
                        this.HelperTransit(hypothecation);
                        break;
                    case "GJ":
                        this.Close();
                        this.HelperTransit(goldjewel);
                        break;
                    case "All":
                        this.Close();
                        this.HelperTransit(all);
                        break;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.InnerException + ex.Message);
            }
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.BindLoanProduct();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HelperTransit(string typeName)
        {
            CXUIScreenTransit.Transit("frmLOMVEW00040", true, new object[] { typeName });
        }
        #endregion

    }
}
