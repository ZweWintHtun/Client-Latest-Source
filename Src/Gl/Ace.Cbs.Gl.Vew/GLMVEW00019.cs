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
using Ace.Cbs.Gl.Ctr.Ptr;
using Ace.Cbs.Gl.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Gl.Vew
{
    public partial class GLMVEW00019 : BaseForm, IGLMVEW00019
    {
        #region Properties
        public int LineNo
        {
            get
            {
                int value;
                if (int.TryParse(this.txtLineNo.Text, out value))
                {
                    return value;
                }
                return 0;
            }

            set
            {
                this.txtLineNo.Text = value.ToString();
            }
        }

        public string AccountNo
        {
            get
            {
                return this.txtAccountNo.Text.ToString();
            }

            set
            {
                this.txtAccountNo.Text = value.ToString();
            }
        }

        public string Department
        {
            get
            {
                return this.txtDepartment.Text.ToString();
            }

            set
            {
                this.txtDepartment.Text = value.ToString();
            }
        }

        private string parentFormId = string.Empty;
        public string ParentFormId
        {
            get { return this.parentFormId; }
            set { this.parentFormId = value; }
        }

        public IList<GLMDTO00001> DTOList { get; set; }
        public int Count { get; set; }

        #endregion

        #region Constructor
        public GLMVEW00019()
        {
            InitializeComponent();
        }

        public GLMVEW00019(string parentFormID, int count, IList<GLMDTO00001> dtoList)
        {
            InitializeComponent();

            this.ParentFormId = parentFormID;
            this.Count = count;
            this.DTOList = dtoList;
        }
        #endregion

        #region Controller
        private IGLMCTL00019 controller;
        public IGLMCTL00019 Controller
        {
            get { return controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        #endregion

        public void EnableDiableControl()
        {            
            if (this.rdoLineNo.Checked)
            {
                this.txtLineNo.Enabled = true;
                this.txtAccountNo.Enabled = false;
                this.txtDepartment.Enabled = false;
                this.txtAccountNo.Text = "";
                this.AccountNo = "";
                this.txtDepartment.Text = "";
                this.Department = "";
            }
            else if (this.rdoAccountNo.Checked)
            {
                this.txtLineNo.Text = "0";
                this.LineNo = 0;
                this.Department = "";
                this.txtDepartment.Text = "";
                this.txtAccountNo.Enabled = true;
                this.txtLineNo.Enabled = false;
                this.txtDepartment.Enabled = false;
            }
            else
            {
                this.txtDepartment.Enabled = true;
                this.txtLineNo.Enabled = false;
                this.txtAccountNo.Enabled = false;
                this.txtLineNo.Text = "0";
                this.LineNo = 0;
                this.AccountNo = "";
                this.txtAccountNo.Text = "";
            }
        }

        #region InitializeControl
        public void InitializeControl()
        {
            this.txtAccountNo.Text = "";
            this.txtLineNo.Text = "0";
            this.txtDepartment.Text = "";
            this.rdoLineNo.Checked = true;
            this.txtLineNo.Focus();
            this.controller.ClearErrors();
        }
        #endregion

        #region Method

        public bool Check_LineNo()
        {
            if (this.LineNo <= Count && this.LineNo != 0)
            {
                return true;
            }
            return false;
        }

        public bool Check_AccountNo()
        {
            foreach (GLMDTO00001 dto in DTOList)
            {
                if (dto.ACode == this.AccountNo)
                {
                    return true;
                }                
            }
            return false;
        }

        public bool Check_Department()
        {
            foreach (GLMDTO00001 dto in DTOList)
            {
                if (dto.DCode == this.Department)
                {
                    return true;
                }               
            }
            return false;
        }
        #endregion

        #region Events
        private void GLMVEW00019_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, false, true);
            this.Text = this.FormName;
            this.InitializeControl();

            this.txtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControl();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdoType_CheckedChanged(object sender, EventArgs e)
        {            
            this.EnableDiableControl();
        }
        
        private void txtLineNo_KeyPress(object sender, KeyPressEventArgs e)
        {            
            if (e.KeyChar == '0')
            {
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{TAB}");
        }
        private void txtAccountNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{TAB}");
        }
        private void txtDepartment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{TAB}");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //if (this.controller.Send())
            //{
                if (this.rdoLineNo.Checked)
                {
                    if (!this.Check_LineNo())
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MV30026");
                        this.txtLineNo.Focus();
                        return;
                    }
                }
                else if (this.rdoAccountNo.Checked)
                {
                    if (!this.Check_AccountNo())
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MV00046");
                        this.txtAccountNo.Focus();
                        return;
                    }
                }
                else if (this.rdoDepartment.Checked)
                {
                    if (!this.Check_Department())
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MV90029");
                        this.txtDepartment.Focus();                       
                        return;
                    }
                }               
                GLMDTO00001 Dto = new GLMDTO00001();
                Dto.LineNo = this.LineNo;
                Dto.ACode = this.AccountNo;
                Dto.DCode = this.Department;
                CXUIScreenTransit.SetData(this.ParentFormId, Dto);
                this.DialogResult = DialogResult.OK;
                this.Close();
            //}
        }
        #endregion   
    }
}
