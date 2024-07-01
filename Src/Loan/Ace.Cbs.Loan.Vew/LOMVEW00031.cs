//----------------------------------------------------------------------
// <copyright file="LOMVEW00031.cs" company="Ace Data Systems">
// Copyright (c) Ace Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo</CreatedUser>
// <CreatedDate>2015-02-04</CreatedDate>
// <UpdatedUser>ZMS</UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Cx.Cle;

namespace Ace.Cbs.Loan.Vew
{
    //Enquiry -> Registration Data Enquiry
    public partial class LOMVEW00031 : BaseForm,ILOMVEW00031
    {
        #region "Constructor"
        public LOMVEW00031()
        {
            InitializeComponent();
        }
        #endregion

        #region Controls Input Output      

        //public int Index
        //{
        //    get { return this.cboTypeOfAdvance.SelectedIndex; }
        //    set { this.cboTypeOfAdvance.SelectedIndex = value; }
        //}
        public string LoanType
        {
            get
            {
                if (this.cboTypeOfAdvance.Text == null)
                {
                    return null;
                }
                else
                {
                    return this.cboTypeOfAdvance.Text.ToString();
                }
            }
            set { this.cboTypeOfAdvance.Text = value; }
        }
        IList<LOMDTO00001> TypeOfBusinessList { get; set; }
        #endregion

        #region Controller
        private ILOMCTL00031 controller;
        public ILOMCTL00031 Controller
        {
            get { return this.controller; }
            set
            {
                this.controller = value;
                this.controller.RegistrationDataEnquiryView = this;
            }
        }
        #endregion        

        #region "Events"
        private void butOk_Click(object sender, EventArgs e)
        {
            this.Controller.GetTransaction();
        }

        private void LOMVEW00031_Load(object sender, EventArgs e)
        {
            this.Text = "Business Loans Information Listing";
            //BindLoanProduct();
            BindBLoanType();
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, true, true);
        }

        public void BindLoanProduct()
        {
            IList<LOMDTO00014> TypeOfProductList = CXCLE00002.Instance.GetListObject<LOMDTO00014>("LOMORM00014.SelectAllLandType", new object[] { true });
            LOMDTO00014 item = new LOMDTO00014();
            item.LOANSDESP = "All";
            item.LOANS_TYPE = "All";
            TypeOfProductList.Insert(0, item);
            this.cboTypeOfAdvance.ValueMember = "LOANS_TYPE";
            this.cboTypeOfAdvance.DisplayMember = "LOANSDESP";
            this.cboTypeOfAdvance.DataSource = TypeOfProductList;
            this.cboTypeOfAdvance.SelectedIndex = -1;
        }
        public void BindBLoanType()
        {
            TypeOfBusinessList = this.Controller.BindLoansBType();
            LOMDTO00001 item = new LOMDTO00001();
            item.Code = "All";
            item.Description = "All";
            TypeOfBusinessList.Insert(0,item);
            this.cboTypeOfAdvance.ValueMember = "Code";
            this.cboTypeOfAdvance.DisplayMember = "Description";
            this.cboTypeOfAdvance.DataSource = TypeOfBusinessList;
            this.cboTypeOfAdvance.SelectedIndex = -1;
        }
        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.cboTypeOfAdvance.SelectedIndex = -1;
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
