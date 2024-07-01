using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Gl.Ctr.Ptr;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Dmd;

namespace Ace.Cbs.Gl.Vew
{
    public partial class GLMVEW00001 : BaseDockingForm,IGLMVEW00001
    {
        private IList<CXDMD00013> currencylist = new List<CXDMD00013>();
        public IList<CXDMD00013> CurrencyList
        { get { return this.currencylist; } set { this.currencylist = value; } }

        private IList<CXDMD00013> deletelist = new List<CXDMD00013>();
        public IList<CXDMD00013> DeleteList
        { get { return this.deletelist; } set { this.deletelist = value; } }

        private IList<CXDMD00013> initialList = new List<CXDMD00013>();
        public GLMVEW00001()
        {
            InitializeComponent();
        }

        #region Controller

        private IGLMCTL00001 controller;
        public IGLMCTL00001 Controller
        {
            get { return this.controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }

        #endregion

        public void GridDataBind(IList<CXDMD00013> currencyList)
        {
            this.gvCurrencyRate.DataSource = null;
            this.gvCurrencyRate.DataSource = currencyList;
        }

        public void GridViewColumnReadOnly(bool status)
        {
            this.gvCurrencyRate.Columns["colIsSelected"].ReadOnly = status;
            this.gvCurrencyRate.Columns["colJanuary"].ReadOnly = status;
            this.gvCurrencyRate.Columns["colFebruary"].ReadOnly = status;
            this.gvCurrencyRate.Columns["colMarch"].ReadOnly = status;
            this.gvCurrencyRate.Columns["colApril"].ReadOnly = status;
            this.gvCurrencyRate.Columns["colMay"].ReadOnly = status;
            this.gvCurrencyRate.Columns["colJune"].ReadOnly = status;
            this.gvCurrencyRate.Columns["colJuly"].ReadOnly = status;
            this.gvCurrencyRate.Columns["colAugust"].ReadOnly = status;
            this.gvCurrencyRate.Columns["colSeptember"].ReadOnly = status;
            this.gvCurrencyRate.Columns["colOctober"].ReadOnly = status;
            this.gvCurrencyRate.Columns["colNovember"].ReadOnly = status;
            this.gvCurrencyRate.Columns["colDecember"].ReadOnly = status;
        }

        public void tsbCRUD_InitialState()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, true, false, true, false, false, true);
            this.tsbCRUD.butDelete.Text = "DeleteAll";
        }

        private void GLMVEW00001_Load(object sender, EventArgs e)
        {
            this.tsbCRUD_InitialState();
            this.gvCurrencyRate.AutoGenerateColumns = false;
            this.CurrencyList = this.Controller.GetAllCurrency();
            this.GridDataBind(this.CurrencyList);
            foreach (CXDMD00013 cur in CurrencyList)
            {
                string curr = cur.Cur;
                string desp = cur.Description;
                string symbol = cur.Symbol;
                decimal m1 = cur.Month1Ammount;
                decimal m2 = cur.Month2Ammount;
                decimal m3 = cur.Month3Ammount;
                decimal m4 = cur.Month4Ammount;
                decimal m5 = cur.Month5Ammount;
                decimal m6 = cur.Month6Ammount;
                decimal m7 = cur.Month7Ammount;
                decimal m8 = cur.Month8Ammount;
                decimal m9 = cur.Month9Ammount;
                decimal m10 = cur.Month10Ammount;
                decimal m11 = cur.Month11Ammount;
                decimal m12 = cur.Month12Ammount;

                CXDMD00013 currency = new CXDMD00013();
                currency.Cur = curr;
                currency.Description = desp;
                currency.Symbol = symbol;
                currency.Month1Ammount = m1;
                currency.Month2Ammount = m2;
                currency.Month3Ammount = m3;
                currency.Month4Ammount = m4;
                currency.Month5Ammount = m5;
                currency.Month6Ammount = m6;
                currency.Month7Ammount = m7;
                currency.Month8Ammount = m8;
                currency.Month9Ammount = m9;
                currency.Month10Ammount = m10;
                currency.Month11Ammount = m11;
                currency.Month12Ammount = m12;
                initialList.Add(currency);
            }
        }

        private void tsbCRUD_EditButtonClick(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.tsbCRUD.butDelete.Text = "Delete";
            this.GridViewColumnReadOnly(false);
            this.gvCurrencyRate.Focus();
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            if (tsbCRUD.butDelete.Text == "DeleteAll")
            {
                if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes) //Are you sure you want to delete? 
                {
                    this.Controller.DeleteAllCurrencyRate();
                }
            }
            else
            {  
                this.gvCurrencyRate.EndEdit();
                int row = gvCurrencyRate.Rows.Count;
                for (int i = 0; i < row; i++)
                {
                    if (Convert.ToBoolean(gvCurrencyRate.Rows[i].Cells["colIsSelected"].Value))
                    {
                        CXDMD00013 currency = (CXDMD00013)gvCurrencyRate.Rows[i].DataBoundItem;
                        DeleteList.Add(currency);
                    }
                }
                if (DeleteList.Count > 0)
                {
                    if (CXUIMessageUtilities.ShowMessageByCode("MC00003") == DialogResult.Yes) //Are you sure,you want to delete selected record?
                    {
                        this.Controller.DeleteCurrencyRateByCur(DeleteList);
                    }
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode("MV90012");  //Please Select at least one record.
                }
            }
        }

        private void gvCurrencyRate_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CXDMD00013 currency = (CXDMD00013)gvCurrencyRate.Rows[e.RowIndex].DataBoundItem;
        }

        private void gvCurrencyRate_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Equals("Undefined"))
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.gvCurrencyRate.DataSource = null;
            this.gvCurrencyRate.DataSource = this.initialList;
            this.tsbCRUD_InitialState();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (CXUIMessageUtilities.ShowMessageByCode("MC00004") == DialogResult.Yes)
            {
                IList<CXDMD00013> saveList = new List<CXDMD00013>();
                this.gvCurrencyRate.EndEdit();
                int row = gvCurrencyRate.Rows.Count;
                for (int i = 0; i < row; i++)
                {
                    CXDMD00013 currency = (CXDMD00013)gvCurrencyRate.Rows[i].DataBoundItem;
                    saveList.Add(currency);
                }
                this.Controller.UpdateCurrencyRateByCur(saveList);
            }
            this.tsbCRUD_InitialState();
        }
    
    }
}
