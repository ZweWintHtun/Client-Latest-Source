using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Mnm._Excel;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00102 : BaseForm, ILOMVEW00102
    {
        public LOMVEW00102()
        {
            InitializeComponent();
        }

        #region Properties
        private ILOMCTL00102 controller;
        public ILOMCTL00102 Controller
        {
            get { return controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        public string townshipCode {
            get {
                if (this.cboTownship.SelectedValue == null)
                    return null;
                else
                    return this.cboTownship.SelectedValue.ToString();
            }
            set {
                this.cboTownship.SelectedValue = value;
            }
        }

        public DateTime startDate {
            get
            {
                return this.dtpStartDate.Value;
            }
            set { this.dtpStartDate.Value = value; }
        }

        public DateTime endDate {
            get { return this.dtpEndDate.Value; }
            set { this.dtpEndDate.Value = value; }
        }

        public string ParentFormName { 
            get; 
            set;
        }

        public string LoanType 
        {
            get
            {
                return this.FormName.ToString();
            }
            set
            {
                this.FormName = value;
            }
        }

        #endregion

        #region Events
        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            try
            {
                string formName = this.FormName;
                DataSet ds = this.Controller.PrintExel_New(this.FormName);
                gvCropType.DataSource = ds.Tables[0];
                DataTable dt = ds.Tables[1];


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int k = 5;
                    object[] row = new object[ds.Tables[0].Columns.Count];
                    row = ReturnZero(row);
                    decimal totalAmount = 0;

                    row[0] = i + 1;
                    row[1] = dt.Rows[i]["VillageName"].ToString();
                    row[2] = dt.Rows[i]["SuspendDate"].ToString();
                    row[3] = dt.Rows[i]["SuspendAmu"].ToString();
                    row[4] = dt.Rows[i]["DeliverDate"].ToString();
                    string[] _rowSplit = dt.Rows[i]["BusinessType"].ToString().Split(new string[] { "*", string.Empty, null }, StringSplitOptions.None);
                    for (int l = 0; l < _rowSplit.Length; l++)
                    {
                        if (string.IsNullOrEmpty(_rowSplit[l].Trim())) continue;
                        string[] _BusinessTypeUM = _rowSplit[l].ToString().Split(new string[] { ":", string.Empty, null }, StringSplitOptions.None);
                        IList<LOMDTO00072> lstCropType = CXCLE00002.Instance.GetListObject<LOMDTO00072>("LOMORM00072.SelectAllCropTypeCode", new object[] { true });
                        foreach (LOMDTO00072 lstCropTypeItem in lstCropType)
                        {
                            if (_BusinessTypeUM[0].ToString() == lstCropTypeItem.CropCode)
                            {
                                _BusinessTypeUM[0] = lstCropTypeItem.Desp.ToString();
                            }
                        }
                        if (ds.Tables[0].Columns.Contains(_BusinessTypeUM[0].ToString()))
                        {
                            int colIndex = ds.Tables[0].Columns.IndexOf(ds.Tables[0].Columns[_BusinessTypeUM[0].ToString()]);
                            row[colIndex] = _BusinessTypeUM[1];
                            totalAmount += Convert.ToDecimal(_BusinessTypeUM[1]);
                        }
                    }
                    row[ds.Tables[0].Columns.Count - 5] = totalAmount;
                    row[ds.Tables[0].Columns.Count - 4] = dt.Rows[i]["SanctionAmu"].ToString();
                    row[ds.Tables[0].Columns.Count - 3] = dt.Rows[i]["RefundDate"].ToString();
                    row[ds.Tables[0].Columns.Count - 2] = dt.Rows[i]["RefundVrNo"].ToString();
                    row[ds.Tables[0].Columns.Count - 1] = dt.Rows[i]["RefundAmu"].ToString();
                    ds.Tables[0].Rows.Add(row);
                }

                if (gvCropType.DataSource != null)
                {
                    string reportTitle = (this.FormName == "AGLoan") ? "Agricultural Loan Record Listing" : "LiveStock Loan Record Listing";
                    BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                    CashControlReport_Excel frm = new CashControlReport_Excel(gvCropType);
                    frm.ExportToExcel_LoanRecord(reportTitle, Branch.BranchDescription, Branch.Address, Branch.Phone, Branch.Fax, reportTitle, DateTime.Now, gvCropType);
                }
            }
            catch { }
        }

        private object[] ReturnZero(object[] row)
        {
            for (int i = 0; i < row.Length; i++)
            {
                row[i] = "0.00";
            }
            return row;
        }
        #endregion        

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.ClearControls();
        }

        #region Methods
        private void ClearControls()
        {
            this.cboTownship.SelectedIndex = -1;
            this.dtpStartDate.Value = DateTime.Now;
            this.dtpEndDate.Value = DateTime.Now;
            this.dtpStartDate.Focus();
        }

        private void bindTownshipCode()
        {
            IList<TownshipDTO> TownshipCodeList = CXCLE00002.Instance.GetListObject<TownshipDTO>("TownshipCode.Client.Select", new object[] { true });

            cboTownship.ValueMember = "TownshipCode";
            cboTownship.DisplayMember = "Description";
            cboTownship.DataSource = TownshipCodeList;
            cboTownship.SelectedIndex = -1;
        }
        #endregion

        private void LOMVEW00102_Load(object sender, EventArgs e)
        {
            try
            {
                this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
                this.bindTownshipCode();
            }
            catch { }
        }
    }
}
