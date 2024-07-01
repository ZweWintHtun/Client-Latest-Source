using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Dmd.DTO;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Data.SqlClient;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00240 : BaseForm, ILOMVEW00240
    {
        IList<LOMDTO00238> lstCOA;
        List<LOMDTO00238> lstImportData = new List<LOMDTO00238>();
        string eno;
        string acctNo;
        decimal amount;
        string acWithOtherBnk;

        DataTable dtFromFile = new DataTable();

        public LOMVEW00240()
        {
            InitializeComponent();
        }

        private ILOMCTL00238 controller;
        public ILOMCTL00238 Controller
        {
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
            get
            {
                return this.controller;
            }
        }

        public string Narration
        {
            get { return this.txtNarration.Text; }
            set { this.txtNarration.Text = value; }
        }
        
        public void BindCOA_Lists()
        {
            lstCOA = this.controller.Get_COA_Lists(CurrentUserEntity.BranchCode);
            LOMDTO00238 dtoCOA = new LOMDTO00238();
            lstCOA.Insert(0, dtoCOA);
            this.cboACWithOtherBank.DataSource = lstCOA;
            this.cboACWithOtherBank.ValueMember = "ACode";
            this.cboACWithOtherBank.DisplayMember = "ACode";
        }

        public void Successful(string message,string description)
        {
            CXUIMessageUtilities.ShowMessageByCode(message, description);
        }

        public void InitializeControls()
        {
            this.cboACWithOtherBank.SelectedIndex = 0;
            this.txtFileName.Text = "";
            this.txtDesp.Text = "";
            this.dgvImportLst.DataSource = null;
            this.txtNarration.Text = "";
        }

        public bool ValidationControls()
        {
            if (cboACWithOtherBank.SelectedIndex == 0)
            {
                errorProvider1.SetError(cboACWithOtherBank, "ACWithOtherBank");
            }
            if (cboACWithOtherBank.SelectedIndex == 0)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90067);
                errorProvider1.Clear();
                return false;
            }
            else return true;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Select file";
            fdlg.InitialDirectory = @"d:\";
            fdlg.FileName = txtFileName.Text;
            fdlg.Filter = "Text and CSV Files(*.txt, *.csv)|*.txt;*.csv|Text Files(*.txt)|*.txt|CSV Files(*.csv)|*.csv|All Files(*.*)|*.*";
            fdlg.FilterIndex = 1;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = fdlg.FileName;
                //Import();
                dgvImportLst.DataSource = null;
                string retMsg=ImportFile();
                if (retMsg!="OK")
                {
                    MessageBox.Show(retMsg);
                    return;
                }
                //Application.DoEvents();
                dgvImportLst.DataSource = lstImportData;
                dgvImportLst.Columns[0].Visible = false;
                dgvImportLst.Columns[1].Visible = false;

                dgvImportLst.Columns[2].HeaderText = "No";
                dgvImportLst.Columns[3].HeaderText = "AccountNo";
                dgvImportLst.Columns[4].HeaderText = "Amount";

                dgvImportLst.Columns[5].Visible = false;
            }
        }

        private string ImportFile()
        {
            string line = "";
            string[] fields = null;
            bool isFirst = true;

            lstImportData = new List<LOMDTO00238>();
            try
            {
                //dtFromFile.Columns.Add("No");
                //dtFromFile.Columns.Add("Account");
                //dtFromFile.Columns.Add("Amount");

                using (var reader = new StreamReader(txtFileName.Text))
                {
                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        fields = line.Split(',');
                        if (isFirst)
                        {
                            isFirst = false;
                        }
                        else
                        {
                            #region OldCode
                            //object[] row = { fields[0], fields[1], fields[2] };
                            //dtFromFile.Rows.Add(row);

                            //if (fields[1].Length!=15)
                            //{
                            //    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00046);
                            //    return "-2";
                            //}
                            #endregion

                            decimal amt = 0;
                            if (!decimal.TryParse(fields[2],out amt))
                            {
                                MessageBox.Show("Invalid amount value " + fields[2] + " in records no " + (lstImportData.Count+1));
                                break;
                            }
                            

                            LOMDTO00238 dto = new LOMDTO00238();
                            dto.No = Convert.ToInt32(fields[0]);
                            dto.AccountNo = fields[1];
                            dto.Amount = amt;
                            lstImportData.Add(dto);
                        }

                    }
                }
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;    
            }
        }

        private void LOMVEW00240_Load(object sender, EventArgs e)
        {
            //Added by HMW at 08-Oct-2019 : Making read only for no need buttons
            this.tsbCRUD.butNew.Enabled = false;
            this.tsbCRUD.butEdit.Enabled = false;
            this.tsbCRUD.butDelete.Enabled = false;
            this.tsbCRUD.butPrint.Enabled = false;
            BindCOA_Lists();
        }

        private void cboACWithOtherBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDesp.Text = lstCOA[cboACWithOtherBank.SelectedIndex].ACName;   
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (!ValidationControls())
                return;

            acWithOtherBnk = cboACWithOtherBank.SelectedValue.ToString();
            string retMsg= this.controller.Importing_Deposit_Voucher(acWithOtherBnk, lstImportData, eno, CurrentUserEntity.CurrentUserID
                                            ,CurrentUserEntity.BranchCode,Narration);

            string[] strRetMsg = retMsg.Split('*');
            string msgCode = strRetMsg[0];
            string desp = strRetMsg[1];

            if (msgCode == "0")
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90131);
                this.InitializeControls();
                return;
            }
            else
            {
                MessageBox.Show("Invalid Account No At - " + desp);
                return;
            }
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
        }

    }
}
