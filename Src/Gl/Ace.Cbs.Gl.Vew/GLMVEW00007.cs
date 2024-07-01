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

namespace Ace.Cbs.Gl.Vew
{
    public partial class GLMVEW00007 : BaseForm , IGLMVEW00007
    {
        #region Constructor

        public GLMVEW00007()
        {
            InitializeComponent();
        }
        string formName;
        string formatStatus;
        public GLMVEW00007(string formName, string formStatus)
        {
            InitializeComponent();
            this.formName = formName + " Format Type Selection";
            this.formatStatus = formStatus;
        }

        #endregion

        #region Properties
       
        public string FormatType
        {
            get
            {
                return mtxtFormatType.Text.ToString(); 
            }
            set 
            {
                this.mtxtFormatType.Text = value;
            }
        }

        public string FormatName
        {
            get 
            {
                return txtName.Text.ToString(); 
            }
            set 
            {
                this.txtName.Text = value; 
            }
        }

        public string Status { get; set; }
       
        private IList<GLMDTO00001> _formatFileDataSource;
        public IList<GLMDTO00001> FormatFileDataSource 
        {
            get
            {
                if (_formatFileDataSource == null)
                    _formatFileDataSource = new List<GLMDTO00001>();
                return _formatFileDataSource;
            }
            set { _formatFileDataSource = value; }
        }

        private GLMDTO00001 viewData;
        public GLMDTO00001 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new GLMDTO00001();
                this.viewData.FormatType = this.FormatType;
                this.viewData.FormatName = this.FormatName;
                this.viewData.FormatStatus = this.formatStatus;

                return this.viewData;
            }
            set
            {
                this.viewData = value;
            }
        }

        #endregion      

        #region Controller
        private IGLMCTL00007 _controller;
        public IGLMCTL00007 Controller
        {
            get
            {
                return this._controller;
            }
            set
            {
                this._controller = value;
                _controller.View = this;
            }
        }

        #endregion    

        #region Methods
        public void ClearControls()
        {
           // this.mtxtFormatType.Text = string.Empty;
           // this.txtName.Text = string.Empty;
           
            this.mtxtFormatType.Clear();
            this.txtName.Clear();
           // this.HideControls("FormatEnty.HiddenFormatEnty");
            this.tsbCRUD.ButtonEnableDisabled(true, false, false, true, true, false, true);
            this.butFormatEntry.Enabled = true;
            this.Status = "Save";
        }
        public void BindGridView()
        {
            this.gvFormatStyle.AutoGenerateColumns = false;
            this.FormatFileDataSource = this.Controller.GetFormatFileDataSource(formatStatus);
            this.gvFormatStyle.DataSource = null;
            this.gvFormatStyle.DataSource = this.FormatFileDataSource;
            if (FormatFileDataSource == null || FormatFileDataSource.Count <= 0)
            {
                tsbCRUD.butDelete.Enabled = false; 
            }            
        }
       
        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }
        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        #endregion

        #region Events

        private void GLVEW00007_Load(object sender, EventArgs e)

        {            
            this.Text = this.formName;
            this.ClearControls();
            this.BindGridView();          
        }

        //private void GLVEW00007_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        this.SelectNextControl(this.ActiveControl, true, true, true, true);
        //    }
        //}

        private void tsbCRUD_NewButtonClick(object sender, EventArgs e)
       {
            this.ShowControls("FormatEnty.VisibleFormatEnty");
            this.mtxtFormatType.Focus();
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.butFormatEntry.Enabled = false;
        }
        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
           
            this.ShowControls("FormatEnty.VisibleFormatEnty");
           //  this.mtxtFormatType.Clear();

          //  this.txtName.Clear();
            this.mtxtFormatType.Focus();
            foreach (DataGridViewRow row in gvFormatStyle.Rows)
            {
                row.Cells["colchk"].Value = false;
            }
          //  this.ShowControls("FormatEnty.VisibleFormatEnty");
            this.Controller.ClearErrors();
            this.ClearControls();
            this.grpInputFormat.Visible = false;
           
        }
        
        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.Controller.Save(this.ViewData);
            if (CXClientWrapper.Instance.ServiceResult.MessageCode.Equals("MI90001"))
            {
                this.ClearControls();
                this.grpInputFormat.Visible = false;
                this.BindGridView();
            }
            else if (CXClientWrapper.Instance.ServiceResult.MessageCode.Equals("MV30028"))
            {
                this.mtxtFormatType.Focus();
            }
            else 
            {
                this.ClearControls();
                this.grpInputFormat.Visible = false;
            }

            this.mtxtFormatType.Focus();

           
        }

        private void gvFormatStyle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvFormatStyle.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {               
                this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
                GLMDTO00001 selectedformatData = (GLMDTO00001)gvFormatStyle.Rows[e.RowIndex].DataBoundItem;               
                this.FormatType = selectedformatData.FormatType;
                this.FormatName = selectedformatData.FormatName;

                this.ShowControls("FormatEnty.VisibleFormatEnty");
              //  this.mtxtFormatType.ReadOnly = true;
                this.ViewData = selectedformatData;
                this.Status = "Update";
            }
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvFormatStyle.EndEdit();
            IList<GLMDTO00001> deleteList = this.FormatFileDataSource.Where<GLMDTO00001>(x => x.IsCheck == true).ToList();
            if (deleteList.Count > 0)
            {
                if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes)
                {                    
                    this.Controller.Delete(deleteList);
                    this.BindGridView();
                }
            }
            else
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90012);/* Please Select at least one record. */                
            }
        }
       
        #endregion

        private void butFormatEntry_Click(object sender, EventArgs e)
        {
            //IList<GLMDTO00001> CheckList = this.FormatFileDataSource.Where<GLMDTO00001>(x => x.IsCheck == true).ToList();
            //if (CheckList.Count > 0 )
            //{
            //    if(CheckList.Count >= 2)
            //        CXUIMessageUtilities.ShowMessageByCode("Pls, select only one record");
            //    else
            //        CXUIScreenTransit.Transit("frmGLMVEW00018", true, new object[] { CheckList[0].FormatType, CheckList[0].FormatName, CheckList[0].FormatStatus, formName });  
            //}

            if (gvFormatStyle.RowCount > 0)
            {
                CXUIScreenTransit.Transit("frmGLMVEW00018", true, new object[] { gvFormatStyle.CurrentRow.Cells["colFormatCode"].Value.ToString(), gvFormatStyle.CurrentRow.Cells["colName"].Value.ToString(), formatStatus, formName });
            }
        }

    }
}
