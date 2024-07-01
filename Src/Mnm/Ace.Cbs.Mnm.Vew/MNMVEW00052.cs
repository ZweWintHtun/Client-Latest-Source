using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Pfm.Dmd;
namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00052 : BaseForm, IMNMVEW00052
    {
        #region Constructor

        public MNMVEW00052()
        {
            InitializeComponent();
        }

        #endregion 

        #region Properties

        private string formName = string.Empty;
        int i = 0;

        #region controller
        private IMNMCTL00052 currentCompanyController;
        public IMNMCTL00052 Controller
        {
            get
            {
                return this.currentCompanyController;
            }
            set
            {
                this.currentCompanyController = value;
                this.currentCompanyController.View = this;
            }
        }
        #endregion

        public string FormName
        {
            get { return this.formName; }
            set { this.formName = value; }
        }

        public string AccountNumber
        {
            get { return this.mtxtAccountNo.Text.Replace("-", "").Trim(); }
            set { this.mtxtAccountNo.Text = value; }
        }

        public string AccountType
        {
            get;
            set;
        }

        public DateTime StartPeriod
        {
            get { return this.dtpStartDate.Value; }
            set { this.dtpStartDate.Text = value.ToString(); }
        }

        public DateTime EndPeriod
        {
            get { return this.dtpEndDate.Value; }
            set { this.dtpEndDate.Text = value.ToString(); }
        }

        public DateTime FormatEndPeriod {get;set;}        

        IList<PFMDTO00001> CustomerDataSource { get; set; }

        #endregion

        #region Events

        private void MNMVEW00052_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.Text = this.FormName;
            this.dtpStartDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            this.dtpEndDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            if (this.FormName.Contains("Specific"))
            {
                this.gvSubledgerCustomer.Visible = false;
                this.grpFrame.Visible = true;
                this.grpFrame.Text = this.formName;
                this.lblSelectedAC.Visible = false;
                this.lblSelectedACDesc.Visible = false;
                this.lblTotalAC.Visible = false;
                this.lblTotalACDesc.Visible = false;
                this.Size = new System.Drawing.Size(516, 187);

            }
            else if (this.FormName.Contains("All"))
            {
                this.gvSubledgerCustomer.Visible = true;
                this.mtxtAccountNo.Enabled = false;
                this.tsbCRUD.butPrint.Text = "Preview";
                this.lblAccountNo.Visible = false;
                this.mtxtAccountNo.Visible = false;
                this.gvSubledgerCustomer.Visible = true;
                this.grpFrame.Visible = false;
                this.lblStartPeriod.Location = new System.Drawing.Point(12, 46);
                this.dtpStartDate.Location = new System.Drawing.Point(104, 42);
                this.lblEndPeriod.Location = new System.Drawing.Point(12, 73);
                this.dtpEndDate.Location = new System.Drawing.Point(104, 69);
                this.lblAccountNo.Location = new System.Drawing.Point(12, 100);
                this.mtxtAccountNo.Location = new System.Drawing.Point(104, 96);
            }
        }

        #region rsb Events

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.mtxtAccountNo.Text = string.Empty;
            this.dtpStartDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            this.dtpEndDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            this.gridview_clear();
            this.lblSelectedAC.Text = "               0";
            this.lblTotalAC.Text = "               0";
            this.tsbCRUD.butPrint.Text = "Preview";
            this.dtpStartDate.Focus();
            this.Controller.ClearCustomErrorMessage();
        }

        void gridview_clear()
        {
            this.gvSubledgerCustomer.ClearSelection();
            this.gvSubledgerCustomer.DataSource = null;
            this.gvSubledgerCustomer.Rows.Clear();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {            
            try
            {                
                if (this.Controller.Validate_Form())
                {
                    if (this.CheckDate())
                    {
                        //if (this.tsbCRUD.butPrint.Text == "Preview" )
                        //{
                            IList<PFMDTO00001> AccountInfo = this.Controller.GetAccountInfo();
                            if (this.tsbCRUD.butPrint.Text == "Preview") 
                                this.BindGridView(AccountInfo);
                        //}
                        //else
                        //{
                            if (this.gvSubledgerCustomer.Visible)
                            {
                                if (this.tsbCRUD.butPrint.Text == "Print")
                                {
                                    IList<PFMDTO00001> custlist = this.CustomerDataSource.Where<PFMDTO00001>(x => x.IsCheck == true).ToList();

                                    if (custlist.Count.Equals(0))
                                    {
                                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90012);/* Please Select at least one record. */
                                    }
                                    else
                                    {
                                        foreach (PFMDTO00001 custdto in custlist)
                                        {
                                            this.AccountNumber = custdto.AccountNo;

                                            this.Controller.PrintAll(this.AccountNumber, custdto.AccountSign, custdto.Name, custdto.NRC, custdto.Address);
                                        }
                                    }
                                }
                            }
       
                            else
                            {
                                this.Controller.PrintAll(this.AccountNumber, AccountInfo[0].AccountSign, AccountInfo[0].Name, AccountInfo[0].NRC, AccountInfo[0].Address);
                            }
                        this.tsbCRUD.butPrint.Text = "Print";
                       // }
                    }
                }
            }

            catch (Exception ex)
            {
                throw new Exception(CXMessage.ME90043, ex);   //Unexpected Error Occurs
            }
        }
        

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvSubledgerCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                DataGridViewRow dataRow = (DataGridViewRow)gvSubledgerCustomer.Rows[e.RowIndex];
                DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

                if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colSelect"))
                {
                   dataRow.Selected = true;
                   
                    if (CustomerDataSource[e.RowIndex].IsCheck == false)
                    {
                        i += gvSubledgerCustomer.SelectedRows.Count;
                        CustomerDataSource[e.RowIndex].IsCheck = true;
                    }
                    else
                    {
                        i = Convert.ToInt32(lblSelectedAC.Text) - 1;
                        CustomerDataSource[e.RowIndex].IsCheck = false;
                    }
                  
                    this.lblSelectedAC.Text = i.ToString();
                }
            }
        }     
        
        public bool CheckDate()
        {
            // Check dtpStartDate Date Time
            if (this.dtpStartDate.Value.Date > DateTime.Now.Date)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00160, this.dtpStartDate.Value.ToString("dd/MM/yyyy"));//Datetime cannot be greater than today date.
                this.dtpStartDate.Focus();
                return false;
            }
            // Check dtpEndDate Date Time
            else if (this.dtpEndDate.Value.Date > DateTime.Now.Date)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00160, this.dtpEndDate.Value.ToString("dd/MM/yyyy"));//Datetime cannot be greater than today date.
                this.dtpEndDate.Focus();
                return false;
            }
            else if (dtpStartDate.Value.Date > this.dtpEndDate.Value.Date)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00131);//Start Date must not be greater than End Date.
                this.dtpEndDate.Focus();
                return false;
            }             
            else if (this.dtpEndDate.Value.Month > DateTime.Now.Month && this.dtpEndDate.Value.Year == DateTime.Now.Year || dtpEndDate.Value.Year > DateTime.Now.Year)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV30005"); //Require end month can't be greater than current month.
                this.dtpEndDate.Focus();
                return false;   
            }
           
            return true;
        }
     
        public void BindGridView(IList<PFMDTO00001> AccountInfo )
        {
            this.gvSubledgerCustomer.DataSource = null;
            this.gvSubledgerCustomer.AutoGenerateColumns = false;            
            this.CustomerDataSource = AccountInfo;
            this.gvSubledgerCustomer.DataSource = CustomerDataSource;
            this.lblTotalAC.Text = gvSubledgerCustomer.RowCount.ToString();                  
                       
        }

        public DateTime GetEndDate()
        {
            DateTime ME_Date;
            if (dtpEndDate.Value.ToShortDateString() == DateTime.Now.ToShortDateString())
            {
                return ME_Date = Convert.ToDateTime(dtpEndDate.Value.ToString("yyyy/MM/dd"));
            }
            else
            {
                int M_Day = DateTime.DaysInMonth(dtpEndDate.Value.Year, dtpEndDate.Value.Month);

                return ME_Date = Convert.ToDateTime(dtpEndDate.Value.Year.ToString() + "/" + dtpEndDate.Value.Month.ToString() + "/" + M_Day.ToString());
            }            
        }

        public DateTime GetStartDate()
        {
            int M_Day = DateTime.DaysInMonth(dtpStartDate.Value.Year, dtpStartDate.Value.Month);

            DateTime MS_Date = Convert.ToDateTime(dtpStartDate.Value.Year.ToString() + "/" + dtpStartDate.Value.Month.ToString() + "/" + "01");

            return MS_Date;
        }        

        #endregion

        private void MNMVEW00052_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

        #endregion
    }
}
