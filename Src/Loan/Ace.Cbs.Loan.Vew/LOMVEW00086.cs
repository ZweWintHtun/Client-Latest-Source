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
using Ace.Cbs.Sam.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00086 : BaseDockingForm, ILOMVEW00086
    {
        public LOMVEW00086()
        {
            InitializeComponent();
        }

        #region Declare Variables
        static decimal totalAcre = 0;
        bool flag = false;
        static int editAcre = 0;
        private IList<LOMDTO00099> lstBusinessType = new List<LOMDTO00099>();
        private IList<LOMDTO00099> lstDeleteBusinessType = new List<LOMDTO00099>();
        IList<LOMDTO00099> lstLoanRecordBusinessType;
        #endregion

        #region ControlProperties
        private string _loanType;
        public string LoanType
        {
            get { return this._loanType = "111"; }
            set { this._loanType = value; }
        }

        public string Eno
        {
            get { return this.txtLoanVrNo.Text; }
            set { this.txtLoanVrNo.Text = value; }
        }

        public string TownshipCode
        {
            get
            {
                if (this.cboTownship.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return cboTownship.SelectedValue.ToString();
                }
            }
            set
            {
                cboTownship.SelectedValue = value;
            }
        }

        public string VillageCode
        {
            get
            {
                if (this.cboVillageGroup.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return cboVillageGroup.SelectedValue.ToString();
                }
            }
            set
            {
                cboVillageGroup.SelectedValue = value;
            }
        }

        public string FinancialYear
        {
            get { return this.txtFinancialYear.Text; }
            set { this.txtFinancialYear.Text = value; }
        }

        public string BusinessCode
        {
            get
            {
                if (this.cboBusinessType.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return cboBusinessType.SelectedValue.ToString();
                }
            }
            set
            {
                cboBusinessType.SelectedValue = value;
            }
        }

        public DateTime SuspendDate
        {
            get { return this.dtpSuspendDate.Value; }
            set { this.dtpSuspendDate.Value = value; }
        }

        public decimal SuspendAmu
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtSuspendAmount.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtSuspendAmount.Text = value.ToString(); }
        }

        public DateTime DeliverDate
        {
            get { return this.dtpDeliverDate.Value; }
            set { this.dtpDeliverDate.Value = value; }
        }

        public string TotalGroup
        {
            get { return this.txtTotalGroup.Text; }
            set { this.txtTotalGroup.Text = value; }
        }

        public string Population
        {
            get { return this.txtPopulation.Text; }
            set { this.txtPopulation.Text = value; }
        }

        public string Acre
        {
            get { return this.txtAcre.Text; }
            set { this.txtAcre.Text = value; }
        }

        public decimal SanctionAmu
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtSanctionAmount.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtSanctionAmount.Text = value.ToString(); }
        }

        public DateTime RefundDate
        {
            get { return this.dtpRefundDate.Value; }
            set { this.dtpRefundDate.Value = value; }
        }

        public decimal RefundAmu
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtRefundAmount.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtRefundAmount.Text = value.ToString(); }
        }

        public string RefundVrNo
        {
            get { return this.txtRefundVrNo.Text; }
            set { this.txtRefundVrNo.Text = value; }
        }
        #endregion

        #region ControllerProperties
        private string _status;
        public string Status
        {
            get { return this._status; }
            set { this._status = value; }
        }

        private LOMDTO00086 _previousLoanRecord;
        public LOMDTO00086 PreviousLoanRecord
        {
            get
            {
                if (_previousLoanRecord == null)
                    return new LOMDTO00086();
                else
                    return _previousLoanRecord;
            }

            set { this._previousLoanRecord = value; }
        }
        public IList<LOMDTO00086> LoanRecords { get; set; }

        private ILOMCTL00086 controller;
        public ILOMCTL00086 LoanRecordController
        {

            get { return this.controller; }
            set { this.controller = value; this.controller.LoanRecordView = this; }
        }

        public ILOMCTL00086 LiveStockLoanController { get; set; }

        public string businessTypeUm { get; set; }
        private LOMDTO00086 _viewData;
        public LOMDTO00086 ViewData
        {
            get
            {
                if (this._viewData == null) this._viewData = new LOMDTO00086();

                this._viewData.LoanType = this.LoanType;
                this._viewData.Eno = this.Eno;
                this._viewData.TownshipCode = this.TownshipCode;
                this._viewData.VillageCode = this.VillageCode;
                this._viewData.FinancialYear = this.FinancialYear;
                this._viewData.BusinessCode = this.BusinessCode;
                this._viewData.SuspendDate = this.SuspendDate;
                this._viewData.SuspendAmu = this.SuspendAmu;
                this._viewData.DeliverDate = this.DeliverDate;
                this._viewData.TotalGroup = this.TotalGroup;
                this._viewData.Population = this.Population;
                this._viewData.Acre = this.Acre;
                this._viewData.SanctionAmu = this.SanctionAmu;
                this._viewData.RefundDate = this.RefundDate;
                this._viewData.RefundAmu = this.RefundAmu;
                this._viewData.RefundVrNo = this.RefundVrNo;
                this._viewData.BusinessTypeUM = this.businessTypeUm;

                return this._viewData;
            }
            set
            {
                this._viewData = value;
            }
        }

        private FormState formState;
        public FormState FormState
        {
            get { return this.formState; }
            set { this.formState = value; }
        }
        #endregion

        #region BindDropDownValue

        public void BindSeasonType()
        {
            IList<LOMDTO00071> ListForSeasonType = CXCLE00002.Instance.GetListObject<LOMDTO00071>("LOMORM00071.SelectAllSeasonCode", new object[] { true });
            this.cboBusinessType.ValueMember = "Code";
            this.cboBusinessType.DisplayMember = "Description";
            this.cboBusinessType.DataSource = ListForSeasonType;
            this.cboBusinessType.SelectedIndex = -1;
        }

        private void BindTownshipCodeCombobox()
        {
            IList<TownshipDTO> TownshipCodeList = CXCLE00002.Instance.GetListObject<TownshipDTO>("TownshipCode.Client.Select", new object[] { true });

            cboTownship.ValueMember = "TownshipCode";
            cboTownship.DisplayMember = "Description";
            cboTownship.DataSource = TownshipCodeList;
            cboTownship.SelectedIndex = -1;

        }

        public void BindVillageGroupCombobox()
        {
            IList<LOMDTO00070> VillageGroupList = CXCLE00002.Instance.GetListObject<LOMDTO00070>("LOMORM00070.SelectAllVillageGroupCode", new object[] { true });
            this.cboVillageGroup.ValueMember = "VillageCode";
            this.cboVillageGroup.DisplayMember = "Desp";
            this.cboVillageGroup.DataSource = VillageGroupList;
            this.cboVillageGroup.SelectedIndex = -1;
        }

        public void BindCropType()
        {
            try
            {
                IList<LOMDTO00072> CropTypeList = CXCLE00002.Instance.GetListObject<LOMDTO00072>("LOMORM00072.SelectAllCropTypeCode", new object[] { true });
                colBusinessType.ValueMember = "CropCode";
                colBusinessType.DisplayMember = "Desp";
                colBusinessType.DataSource = CropTypeList;
            }
            catch { }
        }

        public void BindLoanRecordBusinessType(IList<LOMDTO00099> List)
        {
            try
            {
                this.grdBusinessType.AutoGenerateColumns = false;
                this.grdBusinessType.DataSource = List;
            }
            catch { }
        }
        #endregion

        #region Events
        private void LOMORM00086_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.FormState == FormState.New)
                {
                    this.Text = "Loan Record Entry";
                    tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
                    EnableDisableCtrl(true);
                }
                else if (this.FormState == FormState.Edit)
                {
                    this.Text = "Loan Record Edit";
                    tsbCRUD.ButtonEnableDisabled(false, true, false, true, true, false, true);
                    EnableDisableCtrl(false);
                }

                this.grdBusinessType.Enabled = false;
                this.BindSeasonType();
                this.BindTownshipCodeCombobox();
                this.BindVillageGroupCombobox();
                this.txtLoanVrNo.Enabled = false;
                this.cboTownship.Focus();
                ClearControls();
            }
            catch { }
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            try
            {
                this.ClearControls();
            }
            catch { }
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch { }
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            try
            {
                this.GetDataFromGrd("Save");
            }
            catch { }
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (this.Eno != "" || this.Eno != string.Empty)
                {
                    if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes)//Are you sure you want to delete?
                    {
                        this.LoanRecordController.Delete(this.ViewData.Eno);

                        this.txtLoanVrNo.Focus();
                        this.ClearControls();
                        this.txtLoanVrNo.Text = string.Empty;
                        this.EnableDisableCtrl(false);
                        lstBusinessType.Clear();
                    }
                }
            }
            catch { }
        }

        private void txtSuspendAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }

                // only allow one decimal point
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
            }
            catch { }
        }

        private void txtTotalGroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                    e.Handled = true;


            }
            catch { }
        }

        private void txtPopulation_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                    e.Handled = true;


            }
            catch { }
        }

        private void txtAcre_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                    e.Handled = true;


            }
            catch { }
        }

        private void txtSanctionAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }

                // only allow one decimal point
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }


            }
            catch { }
        }

        private void txtRefundAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }

                // only allow one decimal point
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }

            }
            catch { }
        }

        private void txtRefundVrNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
            catch { }
        }

        private void txtLoanVrNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (this.Eno != "" || this.Eno != string.Empty)
                {
                    IList<LOMDTO00099> lstLoanBusinessType = this.LoanRecordController.GetLoanRecordByLoanNo(this.Eno);
                    if (lstLoanBusinessType.Count <= 0)
                    {
                        this.Failure("MV90055");
                        return;
                    }
                    else
                    {
                        LOMDTO00099 loanRecord = lstLoanBusinessType.FirstOrDefault();
                        this.PreviousLoanRecord.Id = loanRecord.Id;
                        this.Eno = this.PreviousLoanRecord.Eno = loanRecord.Eno;
                        this.TownshipCode = this.PreviousLoanRecord.TownshipCode = loanRecord.TownshipCode;
                        this.VillageCode = this.PreviousLoanRecord.VillageCode = loanRecord.VillageCode;
                        this.FinancialYear = this.PreviousLoanRecord.FinancialYear = loanRecord.FinancialYear;
                        this.BusinessCode = this.PreviousLoanRecord.BusinessCode = loanRecord.BusinessCode;
                        this.SuspendDate = this.PreviousLoanRecord.SuspendDate = loanRecord.SuspendDate;
                        this.SuspendAmu = this.PreviousLoanRecord.SuspendAmu = loanRecord.SuspendAmu;
                        this.DeliverDate = this.PreviousLoanRecord.DeliverDate = loanRecord.DeliverDate;
                        this.TotalGroup = this.PreviousLoanRecord.TotalGroup = loanRecord.TotalGroup;
                        this.Population = this.PreviousLoanRecord.Population = loanRecord.Population;
                        this.Acre = this.PreviousLoanRecord.Acre = loanRecord.Acre;
                        this.SanctionAmu = this.PreviousLoanRecord.SanctionAmu = loanRecord.SanctionAmu;
                        this.RefundDate = this.PreviousLoanRecord.RefundDate = loanRecord.RefundDate;
                        this.RefundAmu = this.PreviousLoanRecord.RefundAmu = loanRecord.RefundAmu;
                        this.RefundVrNo = this.PreviousLoanRecord.RefundVrNo = loanRecord.RefundVrNo;
                        this.PreviousLoanRecord.Active = loanRecord.Active;
                        this.BindGridViewData();
                        EnableDisableCtrl(true);
                        grdBusinessType.Enabled = false;
                    }
                }
            }
            catch { }
        }

        private void tsbCRUD_EditButtonClick(object sender, EventArgs e)
        {
            try
            {
                this.GetDataFromGrd("Update");
            }
            catch { }
        }

        private void butContinue_Click(object sender, EventArgs e)
        {
            try
            {
                this.grdBusinessType.Enabled = true;
                this.BindCropType();
            }
            catch { }
        }

        private void grdBusinessType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex.Equals(-1) || e.ColumnIndex.Equals(-1))
                    return;

                DataGridViewRow dataRow = (DataGridViewRow)grdBusinessType.Rows[e.RowIndex];
                DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

                if (cell.OwningColumn.Name.Equals("colDelete"))
                {
                    if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes)
                    {
                        if (this.Eno == string.Empty)
                            grdBusinessType.Rows.RemoveAt(e.RowIndex);
                        else
                        {
                            string delBusinessType = dataRow.Cells["colBusinessType"].Value.ToString();
                            BindGridViewData(delBusinessType);
                        }
                    }
                }
                if (cell.OwningColumn.Name.Equals("colTotal"))
                {
                    int gridCount = grdBusinessType.Rows.Count - 1;
                    int current = e.RowIndex;
                    if (gridCount == current && this.FormState == FormState.Edit)
                    {
                        List<LOMDTO00099> businessTypeLst = (List<LOMDTO00099>)grdBusinessType.DataSource;
                        businessTypeLst.Add(new LOMDTO00099());
                        grdBusinessType.DataSource = businessTypeLst.ToList();
                    }
                }
            }
            catch { }
        }

        private void grdBusinessType_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                grdBusinessType.CausesValidation = false;
                DataGridViewRow dataRow = (DataGridViewRow)grdBusinessType.Rows[e.RowIndex];
                DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];
                if (e.RowIndex > -1 && !dataRow.IsNewRow)
                {
                    if (cell.OwningColumn.Name.Equals("colTotal"))
                    {
                        grdBusinessType.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType = Type.GetType("System.Decimal");
                        if (!cell.EditedFormattedValue.ToString().StartsWith(decimal.Zero.ToString()) && !String.IsNullOrEmpty(cell.EditedFormattedValue.ToString()) && dataRow.Cells["colBusinessType"].Value != null)
                        {
                            dataRow.Cells["colTotal"].Value = cell.EditedFormattedValue.ToString().Trim();
                        }
                    }
                }
            }
            catch { }
        }

        private void grdBusinessType_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewCell dataCurrentCell = grdBusinessType.CurrentCell;
            e.Control.KeyPress -= new KeyPressEventHandler(colTotal_KeyPress);
            if (dataCurrentCell.OwningColumn.Name.Equals("colTotal"))
            {
                TextBox txtbox = e.Control as TextBox;
                if (txtbox != null)
                {
                    txtbox.KeyPress += new KeyPressEventHandler(colTotal_KeyPress);
                }
            }
        }

        private void colTotal_KeyPress(object sender, KeyPressEventArgs e)   //edited by ASDA . to enter decimal point
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
                e.Handled = true;

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                e.Handled = true;
        }       
        #endregion

        #region Methods
        private void BindGridViewData(string delBT = "")
        {
            IList<LOMDTO00099> bindLstBusinessType = new List<LOMDTO00099>();
            if (delBT != "")
            {
                bindLstBusinessType = (List<LOMDTO00099>)grdBusinessType.DataSource;
                grdBusinessType.AutoGenerateColumns = false;
                grdBusinessType.DataSource = bindLstBusinessType.Where(x => x.BusinessType != delBT).ToList();
                grdBusinessType.Refresh();
            }
            else
            {
                this.BindCropType();
                lstLoanRecordBusinessType = this.LoanRecordController.GetLoanRecordByLoanNo(this.Eno).Where(x => x.Active == true).ToList();

                string businessType = lstLoanRecordBusinessType.Select(x => x.BusinessType).SingleOrDefault();
                string[] businessTypeArr = businessType.Split('*');
                for (int i = 0; i < businessTypeArr.Length; i++)
                {
                    LOMDTO00099 ObjBT = new LOMDTO00099();
                    string[] detailArr = businessTypeArr[i].Split(':');
                    ObjBT.BusinessType = detailArr[0];
                    ObjBT.UM = Convert.ToDecimal(detailArr[1]);
                    bindLstBusinessType.Add(ObjBT);
                }

                if (bindLstBusinessType.Count() > 0)
                {
                    bindLstBusinessType.Add(new LOMDTO00099());
                    grdBusinessType.AutoGenerateColumns = false;
                    grdBusinessType.DataSource = bindLstBusinessType.ToList();
                    grdBusinessType.Refresh();
                }
            }
        }

        private void GetDataFromGrd(string status)
        {
            try
            {
                foreach (DataGridViewRow dr in grdBusinessType.Rows)
                {
                    int row = dr.Index;
                    if (dr.Cells["colTotal"].Value != null || dr.Cells["colBusinessType"].Value != null)
                        totalAcre += Convert.ToDecimal(dr.Cells["colTotal"].EditedFormattedValue);
                }

                if (grdBusinessType.Rows.Count > 0 && Convert.ToDecimal(txtAcre.Text.ToString()) == totalAcre)//Check total acre and txtAcre value match or not
                {
                    //Remove Comment if you want to check Refund Vr No exist in TLF or not
                    //if (this.LoanRecordController.CheckLoanAccNo(this.RefundVrNo) > 0)//Check Refund Vr No exist in TLF or not
                    //{
                        string businessType = string.Empty;
                        foreach (DataGridViewRow dr in grdBusinessType.Rows)//dr.Cells["colTotal"].Value.ToString() != "0" || 
                        {
                            if ((dr.Cells["colBusinessType"].Value != null || dr.Cells["colTotal"].Value != null))
                            {
                                if (dr.Cells["colTotal"].Value.ToString() != "0")
                                {
                                    if (businessType.Contains(dr.Cells["colBusinessType"].Value.ToString()) == true)
                                    {
                                        this.Failure("MV90001");
                                        totalAcre = 0;
                                        flag = false;
                                        break;
                                    }
                                    else
                                    {
                                        businessType += dr.Cells["colBusinessType"].Value + ":" + Convert.ToDecimal(dr.Cells["colTotal"].EditedFormattedValue.ToString()) + "*";
                                        flag = true;
                                    }
                                }
                            }
                        }
                        this.businessTypeUm = businessType.TrimEnd('*');
                        if (flag != false)
                        {
                            this.Status = status;
                            this.LoanRecordController.Save(this.ViewData);
                            if (status == "Update")
                            {
                                this.txtLoanVrNo.Text = string.Empty;
                                this.EnableDisableCtrl(false);
                            }
                            else
                            {
                                this.txtLoanVrNo.Text = this.ViewData.Eno;
                            }
                            this.ClearControls();
                            totalAcre = 0;
                            lstBusinessType.Clear();
                            grdBusinessType.DataSource = null;
                        }
                    //}//Remove Comment if you want to check Refund Vr No exist in TLF or not
                    //else
                    //{
                    //    this.Failure("MV90129");
                    //    this.txtLoanVrNo.Focus();
                    //    totalAcre = 0;
                    //}
                }
                else
                {
                    this.Failure("MV90137");
                    this.butContinue.Focus();
                    totalAcre = 0;
                }
            }
            catch { }
        }

        private void ClearControls()
        {
            try
            {
                if (this.FormState == FormState.New)
                {
                    this.txtLoanVrNo.Enabled = false;
                    txtLoanVrNo.TabStop = false;
                }
                else if (this.FormState == FormState.Edit)
                {
                    this.txtLoanVrNo.Enabled = true;
                    txtLoanVrNo.TabStop = true;
                }
                txtLoanVrNo.Text = string.Empty;
                this.cboTownship.SelectedIndex = -1;
                this.cboVillageGroup.SelectedIndex = -1;
                this.txtFinancialYear.Text = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);
                this.cboBusinessType.SelectedIndex = -1;
                this.dtpSuspendDate.Value = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                this.txtSuspendAmount.Text = "0.00";
                this.dtpDeliverDate.Value = DateTime.Now;
                this.txtTotalGroup.Text = "0.00";
                this.txtPopulation.Text = "0.00";
                this.txtAcre.Text = "0.00";
                this.txtSanctionAmount.Text = "0.00";
                this.dtpRefundDate.Value = DateTime.Now;
                this.txtRefundAmount.Text = "0.00";
                this.txtRefundVrNo.Text = string.Empty;
                grdBusinessType.Rows.Clear();
            }
            catch { }
        }

        private void EnableDisableCtrl(bool flag)
        {
            this.cboTownship.Enabled = flag;
            this.cboVillageGroup.Enabled = flag;
            this.cboBusinessType.Enabled = flag;
            this.dtpSuspendDate.Enabled = flag;
            this.txtSuspendAmount.Enabled = flag;
            this.dtpDeliverDate.Enabled = flag;
            this.txtTotalGroup.Enabled = flag;
            this.txtPopulation.Enabled = flag;
            this.txtAcre.Enabled = flag;
            this.txtSanctionAmount.Enabled = flag;
            this.dtpRefundDate.Enabled = flag;
            this.txtRefundAmount.Enabled = flag;
            this.txtRefundVrNo.Enabled = flag;
        }

        public void Successful(string message, string eno)
        {
            if (eno != "")
            {
                this.txtLoanVrNo.Text = eno;
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, new object[] { "Loan Vouncher No.", eno });
            }
            else
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        public void Failure(string message)
        {
            try
            {
                CXUIMessageUtilities.ShowMessageByCode(message);
            }
            catch { }
        }
        #endregion
    }
}
