//----------------------------------------------------------------------
// <copyright file="SAMVEW00024.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KSW</CreatedUser>
// <CreatedDate>08/02/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Sam.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;

namespace Ace.Cbs.Sam.Vew
{
    public partial class SAMVEW00024 : BaseDockingForm, ISAMVEW00024
    {
        #region Constrator

        public SAMVEW00024()
        {
            InitializeComponent();
        }

        #endregion

        #region Variables

        TLMDTO00012 _previousDenoInfoDto;
        public TLMDTO00012 PreviousDenoInfoDto
        {
            get
            {
                if (_previousDenoInfoDto == null)
                    return new TLMDTO00012();
                return _previousDenoInfoDto;
            }
            set { _previousDenoInfoDto = value; }
        }

        #endregion

        #region Properties

        public int Id
        {
            get { throw new NotImplementedException(); }
        }

        public string DESP
        {
            get { return this.txtDescription.Text; }
            set { this.txtDescription.Text = value; }
        }

        public string D1
        {
            get { return this.txtD1.Text; }
            set { this.txtD1.Text = value; }
        }

        public string D2
        {
            get { return this.txtD2.Text; }
            set { this.txtD2.Text = value; }
        }
       
        public string CUR
        {
            get { return this.cboCurrency.Text; }
            set {  this.cboCurrency.Text = value; }
        }

        public string SYMBOL
        {
            get { return this.txtSymbol.Text; }
            set { this.txtSymbol.Text = value; }
        }

        public string Status { get; set; }

        private TLMDTO00012 viewData;
        public TLMDTO00012 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new TLMDTO00012();

                this.viewData.Description = this.DESP;
                this.viewData.D1 =(this.D1 == null || this.D1 == string.Empty)? 0 :  Convert.ToDecimal(this.D1);
                this.viewData.D2 = (this.D2 == null || this.D2 == string.Empty) ? 0 : Convert.ToDecimal(this.D2);
                this.viewData.Currency = this.CUR;
                this.viewData.Symbol = this.SYMBOL;

                return this.viewData;
            }
            set { this.viewData = value; }
        }

        public IList<TLMDTO00012> Denos { get; set; }

        private ISAMCTL00024 controller;
        public ISAMCTL00024 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.DenoView = this;
            }
        }

        #endregion

        #region Method

        private void dgVDeno_DataBind()
        {
            gvDenomationSetup.AutoGenerateColumns = false;
            this.Denos = this.controller.GetAll();
            this.gvDenomationSetup.DataSource = this.Denos;
            this.txtRecordCount.Text = gvDenomationSetup.RowCount.ToString();

        }

        private void ChangeControlStatusByUserType(bool isUpdateOnlyUser)
        {
            this.txtDescription.Enabled = isUpdateOnlyUser;
            this.txtD1.Enabled = isUpdateOnlyUser;
            this.txtD2.Enabled = isUpdateOnlyUser;
            this.txtSymbol.Enabled = isUpdateOnlyUser;

        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.dgVDeno_DataBind();
            this.InitializeControls();
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        private void InitializeControls()
        {
            this.txtDescription.Text = string.Empty;
            this.txtD1.Text = string.Empty;
            this.txtD2.Text = string.Empty;
            this.cboCurrency.Text = string.Empty;
            this.txtSymbol.Text = string.Empty;
            this.cboCurrency.SelectedIndex = 0;

            this.Status = "Save";
        }


        private void BindComboBoxes()
        {
            //IList<PFMDTO00027> CurrencyList = CXCLE00002.Instance.GetListObject<PFMDTO00027>("CurrencyCode.Client.Select", new object[] { true });

            //cboCurrency.ValueMember = "Symbol";
            //cboCurrency.DisplayMember = "Cur";
            //cboCurrency.DataSource = CurrencyList;

            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = this.controller.GetCur();
            cboCurrency.SelectedIndex = 0;
        }

        #endregion

        #region Event

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.Controller.Save(this.ViewData);
          //  this.cboCurrency.Focus();
            this.dgVDeno_DataBind();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.Controller.ClearErrors();
            this.gvDenomationSetup.EndEdit();
            IList<TLMDTO00012> List = this.Denos.Where<TLMDTO00012>(x => x.IsCheck == true).ToList();
            foreach (TLMDTO00012 dto in List)
            {
                dto.IsCheck = false;
            }
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvDenomationSetup.EndEdit();
            IList<TLMDTO00012> deleteList = this.Denos.Where<TLMDTO00012>(x => x.IsCheck == true).ToList();
            if (deleteList.Count > 0)
            {
                if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes)
                {
                    this.Controller.Delete(deleteList);
                }
            }
            else
            {
                this.Failure("MV90012");
            }
        }

        private void SAMVEW00024_Load(object sender, EventArgs e)
        {
            //Enatble Disable Controls
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.dgVDeno_DataBind();
            this.InitializeControls();
           // this.cboCur_Bind();
            this.BindComboBoxes();
        }

        private void gvDenomationSetup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvDenomationSetup.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.ChangeControlStatusByUserType(true);

                TLMDTO00012 deno = (TLMDTO00012)gvDenomationSetup.Rows[e.RowIndex].DataBoundItem;
                this.PreviousDenoInfoDto = new TLMDTO00012();

                this.PreviousDenoInfoDto.Id = deno.Id;
                this.DESP = this.PreviousDenoInfoDto.Description = deno.Description;
                this.D1 = deno.D1.ToString();
                this.PreviousDenoInfoDto.D1 = deno.D1;
                this.D2 = deno.D2.ToString();
                this.PreviousDenoInfoDto.D2 = deno.D2;
                this.CUR = this.PreviousDenoInfoDto.Currency = deno.Currency;
                this.SYMBOL = this.PreviousDenoInfoDto.Symbol = deno.Symbol;


                this.ViewData = deno;

                this.Status = "Update";
            }
        }

        private void dgVDenoEntry_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Equals("Undefined"))
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
        }

        private void txtSymbol_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            e.Handled = e.KeyChar == ' ';
        }

        

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }
        

        private void txtD1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
                e.Handled = true;

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                e.Handled = true;
            //e.Handled = e.KeyChar == ' ';
        }

        private void txtD2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
                e.Handled = true;

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                e.Handled = true;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      
            //e.Handled = e.KeyChar == ' ';
        }
        #endregion
    }
}

