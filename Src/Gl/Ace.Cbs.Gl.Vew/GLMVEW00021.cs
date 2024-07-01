using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Gl.Ctr.Ptr;
using Ace.Windows.CXClient;
using Ace.Cbs.Gl.Dmd;

namespace Ace.Cbs.Gl.Vew
{
    public partial class GLMVEW00021 : BaseForm, IGLMVEW00021
    {
        #region Properties
        public int FromLineNo
        {
            get
            {
                int value;
                if (int.TryParse(this.txtFromLineNo.Text, out value))
                {
                    return value;
                }
                return 0;
            }

            set
            {
                this.txtFromLineNo.Text = value.ToString();
            }
        }

        public int ToLineNo
        {
            get
            {
                int value;
                if (int.TryParse(this.txtToLineNo.Text, out value))
                {
                    return value;
                }
                return 0;
            }
            set
            {
                this.txtToLineNo.Text = value.ToString();
            }
        }

        private string parentFormId = string.Empty;
        public string ParentFormId
        {
            get { return this.parentFormId; }
            set { this.parentFormId = value; }
        }

        public int Count { get; set; }
        #endregion

        #region Constructor
        public GLMVEW00021()
        {
            InitializeComponent();
        }

        public GLMVEW00021(string parentFormID, int count)
        {
            InitializeComponent();

            this.ParentFormId = parentFormID;
            this.Count = count;
        }
        #endregion

        #region Controller
        private IGLMCTL00021 controller;
        public IGLMCTL00021 Controller
        {
            get { return this.controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        #endregion

        #region InitializeControl
        public void InitializeControl()
        {
            this.txtFromLineNo.Text = "0";
            this.txtToLineNo.Text = "0";
            this.controller.ClearErrors();
        }
        #endregion

        #region CheckMethod
        public bool Check_FromLineNo()
        {
            if (this.FromLineNo <= Count || this.FromLineNo != 0)
            {
                return true;
            }
            return false;
        }

        public bool Check_ToLineNo()
        {
            if (this.ToLineNo <= Count || this.ToLineNo != 0)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region Events
        private void GLMVEW00021_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false,true, false, true, false, true);
            this.Text = this.FormName;
            this.InitializeControl();
        }

        private void GLMVEW00021_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);                 
            } 
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControl();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }       

        private void txtLineNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (this.controller.Send())
            {
                if (this.Check_FromLineNo() && this.Check_ToLineNo())
                {
                    if (this.FromLineNo > this.ToLineNo)
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MV30026");//Invalid Line No.
                    }
                    else
                    {
                        GLMDTO00001 dto = new GLMDTO00001();
                        dto.Id = Convert.ToInt32(this.FromLineNo);
                        dto.LineNo = Convert.ToInt32(this.ToLineNo);
                        CXUIScreenTransit.SetData(this.ParentFormId, dto);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode("MV30026");//Invalid Line No.
                }
            }
        }
        #endregion

    }
}
