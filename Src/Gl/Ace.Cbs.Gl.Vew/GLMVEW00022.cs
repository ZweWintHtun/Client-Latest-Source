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
using Ace.Cbs.Gl.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Gl.Vew
{
    public partial class GLMVEW00022 : BaseDockingForm 
    {
        #region Constructor
        public GLMVEW00022()
        {
            InitializeComponent();
        }

        public GLMVEW00022(string parentFormID,int rowCount,string aCode, string description, string other)
        {
            InitializeComponent();
            this.ParentFormId = parentFormId;
            this.RowCount = rowCount;
            this.AccountNo = aCode;
            this.EnglishDescription = description;
            this.Other = other;
        }

        #endregion

        #region Properties

        private string parentFormId = string.Empty;
        public string ParentFormId
        {
            get { return this.parentFormId; }
            set { this.parentFormId = value; }
        }
        public int RowCount { get; set; }
        public string AccountNo { get; set; }
        public string EnglishDescription { get; set; }
        public string Other { get; set; }

        public string Formula
        {
            get
            {
                return this.txtFormula.Text.ToString();
            }                
            set 
            {
                this.txtFormula.Text = value;
            }
        }
        bool flag = true;

        #endregion

        #region Method
        public bool CheckFormula()
        {
            string formula = txtFormula.Text;
            int Length = formula.Length - 1;

            if (formula != "")
            {
                if (formula.Substring(formula.Length - 1, 1) == "+" || formula.Substring(formula.Length - 1, 1) == "-" ||
                    formula.Substring(formula.Length - 1, 1) == "*" || formula.Substring(formula.Length - 1, 1) == "/" ||
                    formula.Substring(formula.Length - 1, 1) == "{")
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV30027, string.Empty); // Invalid Formula
                    return false;
                }

                else if (formula.Substring(0, 1) == "+" || formula.Substring(0, 1) == "-" || formula.Substring(0, 1) == "*" ||
                         formula.Substring(0, 1) == "/" || formula.Substring(0, 1) == "," || formula.Substring(0, 1) == "}")
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV30027, string.Empty); // Invalid Formula
                    return false;
                }

                else if (formula.Substring(0, 1) == "{" && formula.Substring(formula.Length - 1, 1) == "}")
                {
                    if (Convert.ToInt32(formula.Substring(1, formula.Length - 2)) > this.RowCount)
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV30027, "Line no." + formula.Substring(1, formula.Length - 2) + " not found"); // Invalid Formula
                        return false;
                    }
                    else
                    {
                        for (int i = 1; i == formula.Length - 1; i++)
                        {
                            if (formula.Substring(i, 1) == "{" || formula.Substring(i, 1) == "}")   //Check for {{123} / {12}}/ {1{} /{1{2{}
                            {
                                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV30027, string.Empty); // Invalid Formula.
                                return false;
                            }
                        }
                    }
                }

                else if (formula.Substring(0, 1) == "{" || formula.Substring(formula.Length - 1, 1) == "}")  //check for {+1} /{1+} / {1+2}
                {
                    if (formula.Contains("+") || formula.Contains("-") || formula.Contains("*") || formula.Contains("/"))
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV30027, string.Empty); // Invalid Formula
                    }
                    else
                    {
                        for (int i = 1; i < formula.Length - 1; i++)
                        {
                            if (formula.Substring(i, 1) == "{" || formula.Substring(i, 1) == "}")   //Check for {{123} / {12}}/ {1{} /{1{2{}
                            {
                                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV30027, string.Empty); // Invalid Formula
                                return false;
                            }
                        }
                    }
                }
            }
            CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME30016); //No Error Found
            flag = false;
            return true;
        }
        #endregion

        #region Events
        private void GLMVEW00022_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, false, false, true); //New , Edit , Save , Delete , Cancel , Print , Exit
            this.txtAccountNo.Text = this.AccountNo;
            this.txtEnglishDescription.Text = this.EnglishDescription;
            this.txtFormula.Text = this.Other;
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (flag == true)
            {
                if (this.CheckFormula())
                {
                    flag = true;
                    CXUIScreenTransit.SetData(this.ParentFormId, this.txtFormula.Text);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                CXUIScreenTransit.SetData(this.ParentFormId, this.txtFormula.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private void butCheckFormula_Click(object sender, EventArgs e)
        {
            this.CheckFormula();           
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            this.txtFormula.Text += "+";
        }

        private void butSubstract_Click(object sender, EventArgs e)
        {
            this.txtFormula.Text += "-";
        }

        private void butMultiply_Click(object sender, EventArgs e)
        {
            this.txtFormula.Text += "*";
        }

        private void butDivide_Click(object sender, EventArgs e)
        {
            this.txtFormula.Text += "/";
        }

        private void butComma_Click(object sender, EventArgs e)
        {
            this.txtFormula.Text += ",";
        }

        private void butDot_Click(object sender, EventArgs e)
        {
            this.txtFormula.Text += ".";
        }

        private void butLeft_Click(object sender, EventArgs e)
        {
            this.txtFormula.Text += "{";
        }

        private void butRight_Click(object sender, EventArgs e)
        {
            this.txtFormula.Text += "}";
        }

        private void but0_Click(object sender, EventArgs e)
        {
            this.txtFormula.Text += "0";
        }

        private void but1_Click(object sender, EventArgs e)
        {
            this.txtFormula.Text += "1";
        }

        private void but2_Click(object sender, EventArgs e)
        {
            this.txtFormula.Text += "2";
        }

        private void but3_Click(object sender, EventArgs e)
        {
            this.txtFormula.Text += "3";
        }

        private void but4_Click(object sender, EventArgs e)
        {
            this.txtFormula.Text += "4";
        }

        private void but5_Click(object sender, EventArgs e)
        {
            this.txtFormula.Text += "5";
        }

        private void but6_Click(object sender, EventArgs e)
        {
            this.txtFormula.Text += "6";
        }

        private void but7_Click(object sender, EventArgs e)
        {
            this.txtFormula.Text += "7";
        }

        private void but8_Click(object sender, EventArgs e)
        {
            this.txtFormula.Text += "8";
        }

        private void but9_Click(object sender, EventArgs e)
        {
            this.txtFormula.Text += "9";
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }       

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.txtFormula.Clear();
        }
       
        private void txtFormula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
        }
        #endregion
    }
}
