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
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
//using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Dmd;

namespace Ace.Cbs.Gl.Vew
{
    public partial class GLMVEW00018 : BaseForm , IGLMVEW00018
    {
        #region Constructor
        public GLMVEW00018()
        {
            InitializeComponent();
        }

        string formatType;
        string formatName;
        string formatStatus;
        string formName;
        public GLMVEW00018(string formType, string formatName , string formStatus, string formName )
        {
            this.formatType = formType;
            this.formatName = formatName;
            this.formatStatus = formStatus;
            this.formName = formName;
            InitializeComponent();
        }
        #endregion

        #region Properties

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

        IList<ChargeOfAccountDTO> ACodeList { get; set; }
        IList<ChargeOfAccountDTO> DCodeList { get; set; }
        IList<ChargeOfAccountDTO> COAList { get; set; }
        IList<GLMDTO00001> GridViewDataList { get; set; }
        IList<GLMDTO00001> DeleteList { get; set; }
      
        private string parentFormId = string.Empty;
        public string ParentFormId
        {
            get { return this.parentFormId; }
            set { this.parentFormId = value; }
        }

        private int _rowCount;
        public int RowCount
        {
            get
            {
                _rowCount = this.gvFormatStyle.RowCount;
                return _rowCount;
            }

            set 
            {
                this._rowCount = value;
            }
        }

        public DataTable dt = new DataTable();

        #region Controller
        private IGLMCTL00018 _controller;
        public IGLMCTL00018 Controller
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

        #endregion

        #region Method

        public void GetFormatFileDataSource()
        {                    
            this.FormatFileDataSource = this.Controller.GetFormatFileDataSource(this.formatType, this.formatStatus);
        }   

        private void BindAccountCode()
        {
            ACodeList = CXCLE00001.Instance.GetACodeForFormatFileEntry();  
            cboAccountCode.ValueMember = "ACode";
            cboAccountCode.DisplayMember = "ACode";
            cboAccountCode.DataSource = ACodeList;
            ((DataGridViewComboBoxColumn)gvFormatStyle.Columns["cboAccountCode"]).DataSource = ACodeList;
        }

        private string GetAccountNameByACode(string aCode)
        {            
            ACodeList = CXCLE00002.Instance.GetListObject<ChargeOfAccountDTO>("COA.Client.SelectAccountName", new object[] { aCode, CurrentUserEntity.BranchCode, true });
            return ACodeList[0].AccountName.ToString();
        }

        private void BindDepartmentCode()
        {
            IList<BranchDTO> BranchCodeList = CXCLE00002.Instance.GetListObject<BranchDTO>("Branch.Client.Select");

            cboDepartment.ValueMember = "BranchCode";   //BranchCode
            cboDepartment.DisplayMember = "BranchCode";
            cboDepartment.DataSource = BranchCodeList;
            ((DataGridViewComboBoxColumn)gvFormatStyle.Columns["cboDepartment"]).DataSource = BranchCodeList;
        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        public void BindSavedData()
        {           
            dt.Columns.Add("LineNo", typeof(int));
            //dt.Columns["LineNo"].AutoIncrement = true;
            //dt.Columns["LineNo"].AutoIncrementSeed = 1;
            //dt.Columns["LineNo"].AutoIncrementStep = 1;           
            dt.Columns.Add("ACode", typeof(string));
            dt.Columns.Add("BranchCode", typeof(string));
            dt.Columns.Add("Description", typeof(string));           
            dt.Columns.Add("ShowHide", typeof(string));
            dt.Columns.Add("AmountTotal", typeof(string));
            dt.Columns.Add("Other", typeof(string));
            dt.Columns.Add("Status", typeof(string));  
            dt.Columns.Add("Normal", typeof(string));  
            
            this.GetFormatFileDataSource();
            if (FormatFileDataSource.Count > 0)
            {
                foreach (GLMDTO00001 data in FormatFileDataSource)
                {
                    DataRow dr = dt.NewRow();                    
                    dr["LineNo"] = Convert.ToString(data.LineNo);
                    dr["ACode"] = Convert.ToString(data.ACode);
                    dr["BranchCode"] = Convert.ToString(data.DCode);
                    dr["Description"] = Convert.ToString(data.Description);
                    dr["ShowHide"] = Convert.ToString(data.ShowHide);
                    dr["AmountTotal"] = Convert.ToString(data.AmountTotal);
                    dr["Other"] = Convert.ToString(data.Other);
                    dr["Status"] = Convert.ToString(data.Status);
                    dr["Normal"] = Convert.ToString(data.Normal);
                    dt.Rows.Add(dr);
                }
                gvFormatStyle.DataSource = dt;
            }            
            gvFormatStyle.DataError += new DataGridViewDataErrorEventHandler(gvFormatStyle_DataError);
            gvFormatStyle.DataError -= new DataGridViewDataErrorEventHandler(gvFormatStyle_DataError);
        }

        private IList<GLMDTO00001> GetSavingFormatData()
        {
            IList<GLMDTO00001> FormatFileList = new List<GLMDTO00001>();
            foreach (DataGridViewRow row in gvFormatStyle.Rows)
            {
                if ((Convert.ToString(row.Cells["colLineNo"].Value) != "") &&
                        (row.Cells["colLineNo"].Value != null) ||
                    (Convert.ToString(row.Cells["cboAccountCode"].Value) != "") &&
                        (row.Cells["cboAccountCode"].Value != null) ||
                    (Convert.ToString(row.Cells["cboDepartment"].Value) != "") &&
                        (row.Cells["cboDepartment"].Value != null) ||
                    (Convert.ToString(row.Cells["colDescription"].Value) != "") &&
                        (row.Cells["colDescription"].Value != null) ||
                    (Convert.ToString(row.Cells["colHide"].Value) != "") &&
                        (row.Cells["colHide"].Value != null) &&
                    (Convert.ToString(row.Cells["colAmountTotal"].Value) != "") &&
                        (row.Cells["colAmountTotal"].Value != null) )                    
                {
                    GLMDTO00001 FormatFileDTO = new GLMDTO00001();                    
                    FormatFileDTO.LineNo = Convert.ToInt16(row.Cells["colLineNo"].Value);
                    //drawing.BranchAlias = (from value in BranchList
                    //                       where value.BranchCode.Equals(drawing.Dbank)
                    //                       select value.BranchAlias).Single();
                                        
                    FormatFileDTO.ACode = Convert.ToString(row.Cells["cboAccountCode"].Value).Trim();
                    FormatFileDTO.DCode = Convert.ToString(row.Cells["cboDepartment"].Value);
                    FormatFileDTO.Description = Convert.ToString(row.Cells["colDescription"].Value);
                    FormatFileDTO.ShowHide = Convert.ToString(row.Cells["colHide"].Value);
                    FormatFileDTO.AmountTotal = Convert.ToString(row.Cells["colAmountTotal"].Value) == "Amount" ? "Y" : "N";
                    FormatFileDTO.Other = Convert.ToString(row.Cells["colFormula"].Value);
                    FormatFileDTO.Status = Convert.ToString(row.Cells["colStatus"].Value);
                    FormatFileDTO.Normal = Convert.ToString(row.Cells["colNormal"].Value);
                    FormatFileDTO.FormatType = this.formatType;
                    FormatFileDTO.FormatName = this.formatName;
                    FormatFileDTO.FormatStatus = this.formatStatus;                    

                    FormatFileList.Add(FormatFileDTO);
                }
            }
            return FormatFileList;
        }

        #endregion     

        #region Events
        private void GLMVEW00018_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, false, false, true);                        
            this.BindAccountCode();
            this.BindDepartmentCode();
            this.BindSavedData();            
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            if (DeleteList != null)
            {
                if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC30008) == DialogResult.Yes) //Are you sure to save changes?
                {
                    this.Controller.Delete(DeleteList);                    
                    this.GridViewDataList = this.GetSavingFormatData();
                    if(GridViewDataList.Count > 0)
                    this.Controller.Save(GridViewDataList);                  
                }
            }
           
            this.Close();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (DeleteList != null)
            {
                this.Controller.Delete(DeleteList);
                gvFormatStyle.Refresh();
                DeleteList.Clear();
            }
            this.GridViewDataList = this.GetSavingFormatData();
            if (this.GridViewDataList.Count < 1)
            {
                //At least one record must be exist to save.
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00107);
                return;
            }
            else
            {                
                this.Controller.Save(GridViewDataList);
                
            }            
        }

        private void gvFormatStyle_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dataRow = (DataGridViewRow)gvFormatStyle.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];
            if (e.RowIndex > -1 && (!dataRow.IsNewRow))
            {
                if (cell.OwningColumn.Name.Equals("cboAccountCode"))
                {
                    if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
                    {
                        this.Failure("MV00046"); //If AccountCode is not selected , need to show message;
                        gvFormatStyle.CurrentCell = dataRow.Cells["cboAccountCode"];
                        gvFormatStyle.BeginEdit(true);
                    }
                    else
                    {
                        dataRow.Cells["cboAccountCode"].Value = cell.EditedFormattedValue.ToString();                        
                        dataRow.Cells["colDescription"].Value = this.GetAccountNameByACode(dataRow.Cells["cboAccountCode"].Value.ToString());
                    }
                }
            }
        }
     
        private void btnInsertRange_Click(object sender, EventArgs e)  //NNL
        {
            if (CXUIScreenTransit.Transit("frmGLMVEW00020", true, new object[] { this.Name}) == DialogResult.OK)
            {
                COAList = CXUIScreenTransit.GetData<List<ChargeOfAccountDTO>>(this.Name);
                if (COAList.Count != 0)
                {
                    this.GetFormatFileDataSource();
                    int count = dt.Rows.Count;
                    
                    foreach (ChargeOfAccountDTO COADTO in COAList)
                    {                        
                        count++;
                        DataRow dr = dt.NewRow();                        
                        dr["LineNo"] = Convert.ToString(count);
                        dr["ACode"] = Convert.ToString(COADTO.ACode);
                        dr["BranchCode"] = Convert.ToString(COADTO.DCODE);
                        dr["Description"] = Convert.ToString(COADTO.AccountName);                        
                        dr["ShowHide"] = Convert.ToString("N");
                        dr["AmountTotal"] = Convert.ToString("Amount");
                        dr["Other"] = Convert.ToString("");
                        dr["Status"] = Convert.ToString("N");
                        dr["Normal"] = Convert.ToString(COADTO.ACode);
                        dt.Rows.Add(dr);
                    }
                    this.gvFormatStyle.DataSource = dt;
                }
            }
        }  

        private void btnDeleteRange_Click(object sender, EventArgs e)  //NNL
        {
            int rowcount = dt.Rows.Count;
            int lineNo = 0;
            if (CXUIScreenTransit.Transit("frmGLMVEW00021", true, new object[] { this.Name, rowcount}) == DialogResult.OK)
            {
                GLMDTO00001 Dto = CXUIScreenTransit.GetData<GLMDTO00001>(this.Name);

                if (Dto != null)
                {
                    int fromline = Dto.Id;
                    int toline = Dto.LineNo;

                    for (int i = toline; i >= fromline; i--)
                    {                        
                        dt.Rows[i-1].Delete();
                        if (i < FormatFileDataSource.Count)
                        {
                            FormatFileDataSource[i - 1].IsCheck = true;
                            DeleteList = this.FormatFileDataSource.Where<GLMDTO00001>(x => x.IsCheck == true).ToList();
                        }
                    }
                    foreach (DataRow row in dt.Rows)
                    {
                        lineNo++;
                        row["LineNo"] = lineNo.ToString();
                    }                    
                    gvFormatStyle.DataSource = dt;
                }
            }
        }    

        private void btnFind_Click(object sender, EventArgs e)  //NNL
        {
            int rowcount = dt.Rows.Count;

            IList<GLMDTO00001> DTOList = new List<GLMDTO00001>();
            foreach (DataRow row in dt.Rows)
            {
                DTOList.Add(new GLMDTO00001 { ACode = row["ACode"].ToString(), DCode = row["BranchCode"].ToString(), Description = row["Description"].ToString(), ShowHide = row["ShowHide"].ToString(), AmountTotal = row["AmountTotal"].ToString(), Other = row["Other"].ToString() });
            }
            
            if (CXUIScreenTransit.Transit("frmGLMVEW00019", new object[] { this.Name, rowcount, DTOList }) == DialogResult.OK)
            {
                gvFormatStyle.MultiSelect = false;
                GLMDTO00001 Dto = CXUIScreenTransit.GetData<GLMDTO00001>(this.Name);

                if (Dto != null)
                {
                    if (Dto.LineNo != 0)
                    {
                        int i = Dto.LineNo;
                       // gvFormatStyle.Rows[i-1].Selected = true;                        
                        gvFormatStyle.Rows[i - 1].Cells["colLineNo"].Selected = true;                        
                    }
                    else if (Dto.ACode != string.Empty)
                    {
                        int rowIndex = -1;
                        string accountCode = Dto.ACode;
                        foreach (DataGridViewRow row in gvFormatStyle.Rows)
                        {
                            if (row.Cells[1].Value.ToString().Equals(accountCode))
                            {
                                rowIndex = row.Index;
                                break;
                            }
                        }
                        //gvFormatStyle.Rows[rowIndex].Selected = true;                        
                        gvFormatStyle.Rows[rowIndex].Cells["colLineNo"].Selected = true;    
                    }
                    else if (Dto.DCode != string.Empty)
                    {
                        int rowIndex = -1;
                        string dCode = Dto.DCode;
                        foreach (DataGridViewRow row in gvFormatStyle.Rows)
                        {
                            if (row.Cells[2].Value.ToString().Equals(dCode))
                            {
                                rowIndex = row.Index;
                                break;
                            }
                        }
                        gvFormatStyle.Rows[rowIndex].Cells["colLineNo"].Selected = true; 
                    }
                }
            }
        }  
      
        private void gvFormatStyle_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void gvFormatStyle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1) || e.ColumnIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvFormatStyle.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colFormula"))
            {
                if(CXUIScreenTransit.Transit("frmGLMVEW00022", true, new object[] {this.Name,gvFormatStyle.Rows.Count-1, gvFormatStyle.CurrentRow.Cells["cboAccountCode"].EditedFormattedValue.ToString(), gvFormatStyle.CurrentRow.Cells["colDescription"].EditedFormattedValue.ToString(), gvFormatStyle.CurrentRow.Cells["colFormula"].EditedFormattedValue.ToString() })== DialogResult.OK)
                {
                    string formula = CXUIScreenTransit.GetData<string>(this.ParentFormId);
                    gvFormatStyle.Rows[e.RowIndex].Cells["colFormula"].Value = formula;
                }
            }
            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("cboAccountCode") || cell.OwningColumn != null && cell.OwningColumn.Name.Equals("cboBranchCode") ||
                cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colDescription") || cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colShowHide") ||
                cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colAmountTotal"))
            {
                gvFormatStyle.EndEdit();
            }
        }

        private void butInsertLine_Click(object sender, EventArgs e)
        {
            gvFormatStyle.AllowUserToAddRows = true;
            int rowcount = dt.Rows.Count;
            gvFormatStyle.DataSource = dt;
            if (rowcount > 0)
            {
                int index = gvFormatStyle.CurrentRow.Index;
                int count = 0;
                dt.Rows.InsertAt(dt.NewRow(), index);
                gvFormatStyle.Rows[index].Cells["cboAccountCode"].Selected = true;
                gvFormatStyle.Rows[index + 1].Selected = false;
                foreach (DataRow row in dt.Rows)
                {
                    count++;
                    row["LineNo"] = count.ToString();
                }
            }
            else
            {
                gvFormatStyle.Rows[0].Cells["colLineNo"].Selected = true;
            }
            //gvFormatStyle.DataSource = dt;
        }

        private void butDeleteLine_Click(object sender, EventArgs e)
        {
            int rowcount = dt.Rows.Count;
            if (rowcount > 0)
            {
                int index = gvFormatStyle.CurrentRow.Index;

                if (gvFormatStyle.CurrentRow.Selected || gvFormatStyle.CurrentCell.Selected)
                {
                    gvFormatStyle.AllowUserToDeleteRows = true;

                    dt.Rows[index].Delete();

                    this.gvFormatStyle.EndEdit();

                    if (index < FormatFileDataSource.Count)  //check for unsaved row delete
                    {
                        FormatFileDataSource[index].IsCheck = true;
                        DeleteList = this.FormatFileDataSource.Where<GLMDTO00001>(x => x.IsCheck == true).ToList();
                    }
                    int j = gvFormatStyle.Rows.Count - 1;
                    for (int i = 0; i < j; i++)
                    {
                        gvFormatStyle.Rows[i].Cells["colLineNo"].Value = i + 1;
                    }
                }
                else
                {
                    gvFormatStyle.MultiSelect = false;
                    gvFormatStyle.Rows[index + 1].Selected = false;
                    //gvFormatStyle.Rows[index].Selected = true;                
                    gvFormatStyle.Rows[index].Cells["colLineNo"].Selected = true;

                }
            }
        }
                
        #endregion 

        #region Old Code
        //private void BindAccountCode()
        //{
        //    IList<ChargeOfAccountDTO> ResultList = new List<ChargeOfAccountDTO>();
        //    ACodeList = CXCLE00002.Instance.GetListObject<ChargeOfAccountDTO>("COADAO.SelectByBranchDetail", new object[] { CurrentUserEntity.BranchCode, true });                    
        //    foreach (ChargeOfAccountDTO ACodeData in ACodeList)
        //    {
        //        if (ACodeData.ACode.Substring(3, 3) != "000")
        //        {                    
        //            ResultList.Add(ACodeData);
        //            this.BindDepartmentCodeByACode(ACodeData.ACode);
        //        }
        //    }
        //    cboAccountCode.ValueMember = "ACode";
        //    cboAccountCode.DisplayMember = "ACode";
        //    cboAccountCode.DataSource = ResultList;            
        //    ((DataGridViewComboBoxColumn)gvFormatStyle.Columns["cboAccountCode"]).DataSource = ResultList;
        //}

        //private void BindDepartmentCode()
        //{
        //    IList<CXDMD00013> DCodeList = CXCLE00001.Instance.GetDCODEForFormatFileEntry();
        //    cboDepartment.ValueMember = "DCODE";
        //    cboDepartment.DisplayMember = "DCODE";
        //    cboDepartment.DataSource = DCodeList;
        //    ((DataGridViewComboBoxColumn)gvFormatStyle.Columns["cboDepartment"]).DataSource = DCodeList;            
        //}

        //private void BindDepartmentCodeByACode(string aCode)
        //{
        //    DCodeList = CXCLE00002.Instance.GetListObject<ChargeOfAccountDTO>("COA.Client.SelectDCodeByACode", new object[] { aCode, true });
        //    cboDepartment.DataSource = DCodeList;
        //    cboDepartment.ValueMember = "DCODE";   //BranchCode
        //    cboDepartment.DisplayMember = "DCODE";
        //    cboDepartment.DisplayStyleForCurrentCellOnly = true;
        //    ((DataGridViewComboBoxColumn)gvFormatStyle.Columns["cboDepartment"]).DataSource = DCodeList; 
        //}

        //private void GLMVEW00018_Load(object sender, EventArgs e)
        //{
        //    this.BindAccountCodeAndBranchCode();
        //    this.BindDepartmentCode();

        //    //IList<GLMDTO00001> ShowData = this.BindGridView();
        //    if (ShowData.Count > 0)
        //    {
        //        for (int i = 0; i < ShowData.Count; i++)
        //        {
        //            gvFormatStyle.Rows[i].Cells["colLineNo"].Value = ShowData[i].LineNo.ToString();
        //            gvFormatStyle.Rows[i].Cells["cboAccountCode"].Value = ShowData[i].ACode.ToString();
        //            gvFormatStyle.Rows[i].Cells["cboDepartment"].Value = ShowData[i].DCode.ToString();
        //            gvFormatStyle.Rows[i].Cells["colDescription"].Value = ShowData[i].Description.ToString();
        //            gvFormatStyle.Rows[i].Cells["colHide"].Value = ShowData[i].ShowHide.ToString();
        //            gvFormatStyle.Rows[i].Cells["colAmountTotal"].Value = ShowData[i].AmountTotal.ToString();
        //            gvFormatStyle.Rows[i].Cells["colFormula"].Value = ShowData[i].Other.ToString();
        //        }
        //    }
        //    gvFormatStyle.DataError += new DataGridViewDataErrorEventHandler(gvFormatStyle_DataError);
        //    gvFormatStyle.DataError -= new DataGridViewDataErrorEventHandler(gvFormatStyle_DataError);

        //    gvFormatStyle.AllowUserToAddRows = true;
        //    DataGridViewRow row = new DataGridViewRow();
        //    //gvFormatStyle.Rows.Add(row);
        //}

        //private void GLMVEW00018_Load(object sender, EventArgs e)
        //{
        //    this.GetFormatFileDataSource();            
        //    if (FormatFileDataSource.Count > 0)
        //    {
        //        for (int i = 0; i < FormatFileDataSource.Count; i++)
        //        {
        //            gvFormatStyle.Rows[i].Cells["colLineNo"].Value = FormatFileDataSource[i].LineNo.ToString();
        //            gvFormatStyle.Rows[i].Cells["cboAccountCode"].Value = FormatFileDataSource[i].ACode.ToString();
        //            gvFormatStyle.Rows[i].Cells["cboDepartment"].Value = FormatFileDataSource[i].DCode.ToString();
        //            gvFormatStyle.Rows[i].Cells["colDescription"].Value = FormatFileDataSource[i].Description.ToString();
        //            gvFormatStyle.Rows[i].Cells["colHide"].Value = FormatFileDataSource[i].ShowHide.ToString();
        //            gvFormatStyle.Rows[i].Cells["colAmountTotal"].Value = FormatFileDataSource[i].AmountTotal.ToString();
        //            gvFormatStyle.Rows[i].Cells["colFormula"].Value = FormatFileDataSource[i].Other.ToString();
        //            gvFormatStyle.Rows[i].Cells["colStatus"].Value = FormatFileDataSource[i].Status.ToString();                    
        //        }
        //    }
        //    gvFormatStyle.DataError += new DataGridViewDataErrorEventHandler(gvFormatStyle_DataError);
        //    gvFormatStyle.DataError -= new DataGridViewDataErrorEventHandler(gvFormatStyle_DataError);
        //    gvFormatStyle.Refresh(); 

        //    //gvFormatStyle.AllowUserToAddRows = true;
        //    //DataGridViewRow row = new DataGridViewRow();
        //    //gvFormatStyle.Rows.Add(row);
        //}
        #endregion

        #region unused Code
        //private void gvFormatStyle_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        //{
        //    DataGridViewCell dataCurrentCell = gvFormatStyle.CurrentCell;
        //    if (dataCurrentCell.OwningColumn.Name.Equals("cboAccountCode"))
        //    {
        //        ComboBox combo = e.Control as ComboBox;
        //        if (combo != null)
        //        {
        //            ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
        //            ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
        //            ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;

        //            combo.SelectedIndexChanged -= (combo_SelectedIndexChanged);
        //            combo.SelectedIndexChanged += (combo_SelectedIndexChanged);
        //        }
        //    }
        //    else if (dataCurrentCell.OwningColumn.Name.Equals("cboDepartment"))
        //    {
        //        ComboBox combo = e.Control as ComboBox;
        //        this.BindDepartmentCodeByACode(gvFormatStyle.CurrentRow.Cells["cboAccountCode"].EditedFormattedValue.ToString());
        //    }
        //}

        //private void combo_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (gvFormatStyle.CurrentCell.ColumnIndex == 1)
        //    {
        //        var rowindex = gvFormatStyle.CurrentCell.RowIndex;

        //        if (gvFormatStyle[1, rowindex].EditedFormattedValue != null)
        //        {
        //            this.BindDepartmentCodeByACode(gvFormatStyle[1, rowindex].EditedFormattedValue.ToString());
        //            gvFormatStyle.Rows[rowindex].Cells["colDescription"].Value = this.GetAccountNameByACode(gvFormatStyle[1, rowindex].EditedFormattedValue.ToString());
        //        }
        //    }
        //}    

        //private void gvFormatStyle_CellValidated(object sender, DataGridViewCellEventArgs e)
        //{
        //    DataGridViewRow dataRow = (DataGridViewRow)gvFormatStyle.Rows[e.RowIndex];
        //        DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];
        //        if (e.RowIndex > -1 && (!dataRow.IsNewRow))
        //        {
        //            if (cell.OwningColumn.Name.Equals("cboAccountCode"))
        //            {
        //                if (cell.EditedFormattedValue.ToString() != null || cell.EditedFormattedValue.ToString() != string.Empty)
        //                {
        //                    this.BindDepartmentCodeByACode(dataRow.Cells["cboAccountCode"].Value.ToString());
        //                    dataRow.Cells["cboAccountCode"].Value = cell.EditedFormattedValue.ToString();
                            
        //                }                       
        //            }
        //        }
        //}

        //private void gvFormatStyle_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    for (int i = 0; i < gvFormatStyle.Rows.Count; i++)
        //    {
        //        gvFormatStyle.Rows[i].Cells["cboDepartment"].Value = DCodeList[i].DCODE;
        //    }   
        //}

        //private void gvFormatStyle_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        //{
        //    DataGridViewRow dataRow = (DataGridViewRow)gvFormatStyle.Rows[e.RowIndex];
        //    DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];
        //    if (e.RowIndex > -1 && (!dataRow.IsNewRow))
        //    {
        //        if (cell.OwningColumn.Name.Equals("cboAccountCode"))
        //        {
        //            if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
        //            {
        //                this.Failure("MV00046");
        //                gvFormatStyle.CurrentCell = dataRow.Cells["cboAccountCode"];
        //                this.BindDepartmentCodeByACode(dataRow.Cells["cboAccountCode"].Value.ToString());
        //                gvFormatStyle.BeginEdit(true);
        //                e.Cancel = true;
        //            }
        //            else
        //            {
        //                dataRow.Cells["cboAccountCode"].Value = cell.EditedFormattedValue.ToString();
        //            }
        //        }
        //        else if (cell.OwningColumn.Name.Equals("cboDepartment"))
        //        {
        //            gvFormatStyle.CurrentCell = dataRow.Cells["cboDepartment"];
        //            gvFormatStyle.BeginEdit(true);
        //            dataRow.Cells["cboDepartment"].Value = cell.EditedFormattedValue.ToString();

        //        }

        //        else if (cell.OwningColumn.Name.Equals("colDescription"))
        //        {
        //            gvFormatStyle.CurrentCell = dataRow.Cells["colDescription"];
        //            gvFormatStyle.BeginEdit(true);
        //            dataRow.Cells["colDescription"].Value = cell.EditedFormattedValue.ToString();
        //        }

        //        else if (cell.OwningColumn.Name.Equals("colHide"))
        //        {
        //            if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
        //            {
        //                this.Failure("ME90018"); //Invalid Parameter Value
        //                gvFormatStyle.CurrentCell = dataRow.Cells["colHide"];
        //                gvFormatStyle.BeginEdit(true);
        //                e.Cancel = true;
        //            }
        //            else
        //            {
        //                dataRow.Cells["colHide"].Value = cell.EditedFormattedValue.ToString();
        //            }
        //        }
        //        else if (cell.OwningColumn.Name.Equals("colAmountTotal"))
        //        {
        //            if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
        //            {
        //                this.Failure("ME90018"); //Invalid Parameter Value
        //                gvFormatStyle.CurrentCell = dataRow.Cells["colAmountTotal"];
        //                gvFormatStyle.BeginEdit(true);
        //                e.Cancel = true;
        //            }
        //            else
        //            {
        //                dataRow.Cells["colAmountTotal"].Value = cell.EditedFormattedValue.ToString();
        //            }
        //        }
        //        else if (cell.OwningColumn.Name.Equals("colFormula"))
        //        {
        //            gvFormatStyle.CurrentCell = dataRow.Cells["colFormula"];
        //            gvFormatStyle.BeginEdit(true);
        //            dataRow.Cells["colFormula"].Value = cell.EditedFormattedValue.ToString();
        //        }
        //    }
        //}
        #endregion

    }
}
