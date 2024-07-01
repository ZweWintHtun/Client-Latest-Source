using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Gl.Ctr.Ptr;
using Ace.Cbs.Gl.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Gl.Vew
{
    public partial class GLMVEW00010 : BaseForm, IGLMVEW00010
    {
        #region Constructor
        public GLMVEW00010()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        public string Year
        {
            get { return this.txtRequiredYear.Text; }
            set { this.txtRequiredYear.Text = value.ToString(); }
        }

        public string Month
        {
            get 
            {
                switch (this.cboMonth.SelectedItem.ToString())
                {
                    case "January": return "1";
                    case "February": return "2";
                    case "March": return "3";
                    case "April": return "4";
                    case "May": return "5";
                    case "June": return "6";
                    case "July": return "7";
                    case "August": return "8";
                    case "September": return "9";
                    case "October": return "10";
                    case "November": return "11";
                    case "December": return "12";
                    default: return "1";
                } 
            }
            set { this.cboMonth.SelectedItem = value.ToString(); }
        }
        public int actualMonth { get; set; }
        public string branchCode { get; set; }
        #endregion

        #region Controller
        private IGLMCTL00010 controller;
        public IGLMCTL00010 Controller
        {
            get { return controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        #endregion

        #region Method
        private string GetMonthName(string i)
        {
            string month=string.Empty;
            switch (i)
            {
                //case "01": month = "January";break;
                //case "02": month = "February"; break;
                //case "03": month = "March"; break;
                //case "04": month = "April"; break;
                //case "05": month = "May"; break;
                //case "06": month = "June"; break;
                //case "07": month = "July"; break;
                //case "08": month = "August"; break;
                //case "09": month = "September"; break;
                //case "10": month = "October"; break;
                //case "11": month = "November"; break;
                //case "12": month = "December"; break;      
                case "1": month = "January"; break;
                case "2": month = "February"; break;
                case "3": month = "March"; break;
                case "4": month = "April"; break;
                case "5": month = "May"; break;
                case "6": month = "June"; break;
                case "7": month = "July"; break;
                case "8": month = "August"; break;
                case "9": month = "September"; break;
                case "10": month = "October"; break;
                case "11": month = "November"; break;
                case "12": month = "December"; break; 
            }

            return month;
                
        }

        private void InitializeControl()
        {
            txtRequiredYear.Text = DateTime.Now.Year.ToString();
            //txtRequiredMonth.Text = DateTime.Now.ToString("MM");     
            
            this.controller.ClearErrors();
        }
        #endregion

        #region Events
        private void GLMVEW00010_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.InitializeControl();
            this.cboMonth.SelectedItem = GetMonthName(DateTime.Now.Month.ToString());
            //this.txtRequiredMonth.MaxLength = 2;
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControl();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            branchCode = CurrentUserEntity.BranchCode;
            actualMonth = Convert.ToInt32(GetNametoDigitInteger(cboMonth.SelectedItem.ToString()));
            this.controller.Preview();
        }
        #endregion
        private string GetNametoDigitInteger(string i)
        {
            string month = string.Empty;
            switch (i)
            {
                case "January": month = "1"; break;
                case "February": month = "2"; break;
                case "March": month = "3"; break;
                case "April": month = "4"; break;
                case "May": month = "5"; break;
                case "June": month = "6"; break;
                case "July": month = "7"; break;
                case "August": month = "8"; break;
                case "September": month = "9"; break;
                case "October": month = "10"; break;
                case "November": month = "11"; break;
                case "December": month = "12"; break;
            }

            return month;

        }
        private void txtRequiredMonth_Leave(object sender, EventArgs e)
        {
            ChangeEvent();            
        }
        private void txtRequiredMonth_Enter(object sender, EventArgs e)
        {
            ChangeEvent();
        }
        private void ChangeEvent()
        {
            if (txtRequiredMonth.TextLength < 2)
            {
                txtRequiredMonth.Text = "0" + txtRequiredMonth.Text;
            }
            if (txtRequiredMonth.TextLength <= 2)
            {
                txtRequiredMonth.Text = this.GetMonthName(txtRequiredMonth.Text);
            }
        }
        //private void txtRequiredMonth2_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!(char.IsControl(Convert.ToChar(this.Month.Substring(1, 1)))) || 
        //        Convert.ToChar(this.Month.Substring(1, 1)) == '1' || 
        //        Convert.ToChar(this.Month.Substring(1, 1)) == '2')
        //    {
        //         e.Handled = true;
        //    }
        //}

        private void txtRequiredMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            ////if (!(char.IsControl(e.KeyChar) || e.KeyChar == '1'
            ////    || e.KeyChar == '2'
            ////    || e.KeyChar == '3'
            ////    || e.KeyChar == '4'
            ////    || e.KeyChar == '5'
            ////    || e.KeyChar == '6'
            ////    || e.KeyChar == '7'
            ////    || e.KeyChar == '9'))
            ////{
            ////    e.Handled = true;
            ////}

            //if ((Keys)e.KeyChar != Keys.Enter)
            //{
            //    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            //    { e.Handled = true; }
            //}
            //if ((Keys)e.KeyChar != Keys.Back)
            //{
            //    if ((Keys)e.KeyChar != Keys.Delete)
            //    {
            //        if (txtRequiredMonth.TextLength > 2)
            //        {
            //            txtRequiredMonth.Text = "";
            //        }

            //        if (txtRequiredMonth.TextLength <= 2)
            //        {
            //            if (txtRequiredMonth.Text != null && txtRequiredMonth.Text != "")
            //            {
            //                if ((Keys)e.KeyChar != Keys.Enter)
            //                {
            //                    if (txtRequiredMonth.Text.Substring(0, 1) == "0")
            //                    {
            //                        this.txtRequiredMonth.Text = string.Empty;
            //                        //txtRequiredMonth.Text = e.KeyChar.ToString();
            //                    }
            //                    else
            //                    {
            //                        txtRequiredMonth.Text = txtRequiredMonth.Text + e.KeyChar;
            //                    }
            //                }
            //            }
            //            if ((Keys)e.KeyChar == Keys.Enter)
            //            {
            //                if (txtRequiredMonth.TextLength < 2)
            //                {
            //                    txtRequiredMonth.Text = "0" + txtRequiredMonth.Text;
            //                }                            
            //                txtRequiredMonth.Text = this.GetMonthName(txtRequiredMonth.Text);
            //                this.tsbCRUD.Focus();
            //            }
            //        }
            //    }                
            //}
        }

        private void GLMVEW00010_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }           
        }

        private void txtRequiredMonth_KeyDown(object sender, KeyEventArgs e)
        {
             //e.KeyCode || e.which;
           
        }

        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            string month = string.Empty;
            switch (cboMonth.SelectedItem.ToString())
            {
                case "January": month = "1"; break;
                case "February": month = "2"; break;
                case "March": month = "3"; break;
                case "April": month = "4"; break;
                case "May": month = "5"; break;
                case "June": month = "6"; break;
                case "July": month = "7"; break;
                case "August": month = "8"; break;
                case "September": month = "9"; break;
                case "October": month = "10"; break;
                case "November": month = "11"; break;
                case "December": month = "12"; break;
            }
        }
    }
}
