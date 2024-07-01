using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00046 : BaseForm, IMNMVEW00046
    {
        #region Constructor
        public MNMVEW00046()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties

        public DateTime CurrentDate { get; set; }
        
        public int Year
        {
            get
            {
                int value;
                if (int.TryParse(this.txtYear.Text, out value))
                {
                    return value;
                }
                return 0;
            }
            set
            {
                this.txtYear.Text = value.ToString();
            }
        }

        public int Month
        {
            get
            {
                switch (this.cboMonth.Text.ToString())
                {
                    case "January": return 1; 
                    case "February": return 2;
                    case "March": return 3;
                    case "April": return 4;
                    case "May": return 5;
                    case "June": return 6;
                    case "July": return 7;
                    case "August": return 8;
                    case "September": return 9;
                    case "October": return 10;
                    case "November": return 11;
                    case "December": return 12;
                    default: return 0;
                }
            }

            set
            {
                this.cboMonth.SelectedValue = value.ToString();
                this.cboMonth.SelectedText = value.ToString();
            }
        }

        public string AccountNumber
        {
            get { return this.mtxtAccountNo.Text.Replace("-", "").Trim(); }
            set { this.mtxtAccountNo.Text = value; }
        }

        private string formName = string.Empty;
        public string FormName
        {
            get { return this.formName; }
            set { this.formName = value; }
        }

        public string MonthName { get; set; }
        public bool bindData { get; set; }

        public IList<PFMDTO00001> DTOList { get; set; }
        
        #endregion

        #region Controller
        private IMNMCTL00046 controller;
        public IMNMCTL00046 Controller
        {
            get { return this.controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        #endregion

        #region Method
        public void EnableDisableControls(bool IsEnable)
        {
            this.gvAccount.Visible = IsEnable;
            this.lblRecordCount.Visible = IsEnable;
            this.txtRecordCount.Visible = IsEnable;
            this.lblSelectedAccount.Visible = IsEnable;
            this.txtSelectedAccount.Visible = IsEnable;
            this.lblDate.Visible = IsEnable;
            this.txtCurrentDate.Visible = IsEnable;
        }

        public void BindDataGrid()
        {            
            string month = this.Year.ToString() + "/" + this.Month.ToString();
            if (this.Text.Contains("Saving All"))
            {
                DTOList = CXClientWrapper.Instance.Invoke<IMNMSVE00046, IList<PFMDTO00001>>(x => x.SelectSavingAC_AllByMonth(month, CurrentUserEntity.BranchCode)); //VW_Bankstatement_Saof
            }
            else if (this.Text.Contains("Current All"))
            {
                DTOList = CXClientWrapper.Instance.Invoke<IMNMSVE00046, IList<PFMDTO00001>>(x => x.SelectCurrentAC_AllByMonth(month, CurrentUserEntity.BranchCode));   //VW_Bankstatement_Caof
            }
            
            if (DTOList.Count > 0)
            {                
                this.gvAccount.AutoGenerateColumns = false;
                this.gvAccount.DataSource = null;
                this.gvAccount.DataSource = DTOList;                
                this.txtRecordCount.Text = DTOList.Count.ToString();
            }
        }        

        private int GetSelectedCount()
        {
            int count = 0;
            this.txtSelectedAccount.Text = "";
            for (int i = 0; i < gvAccount.RowCount - 1; i++)
            {
                if (gvAccount.Rows[i].Cells[0].Value != null)
                {
                    bool value = Convert.ToBoolean(gvAccount.Rows[i].Cells[0].Value);
                    if (value)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private void CheckMonth()
        {
            if (this.bindData)
            {
                if (Convert.ToInt32(this.txtYear.Text) > Convert.ToInt32(DateTime.Now.Year.ToString()))
                {
                    CXUIMessageUtilities.ShowMessageByCode("MV30032", new object[] { this.txtYear.Text, DateTime.Now.Year.ToString() });
                    this.gvAccount.DataSource = "";
                    this.gvAccount.Refresh();
                }
                else if (Convert.ToInt32(this.txtYear.Text) == Convert.ToInt32(DateTime.Now.Year.ToString()) && this.Month > Convert.ToInt32(DateTime.Now.Month.ToString()))
                {
                    CXUIMessageUtilities.ShowMessageByCode("MV30022", new object[] { this.cboMonth.Text, this.MonthName });
                    this.gvAccount.DataSource = "";
                    this.gvAccount.Refresh();
                }
                else
                {
                    if (gvAccount.Visible)
                    {
                        this.gvAccount.Focus();
                        this.BindDataGrid();
                    }
                }
            }  
        }

        public bool Check_AccountNo()
        {
            if (string.IsNullOrEmpty(this.AccountNumber))
            {
                CXUIMessageUtilities.ShowMessageByCode("MV00046");  //Invalid Account No
                this.mtxtAccountNo.Focus();
                return false;
            }
            else
            {
                Nullable<CXDMD00011> accountType;
                //string accountNo = this.AccountNumber.Replace("-", "");

                if (CXCLE00012.Instance.IsValidAccountNo(this.AccountNumber, out accountType))
                {
                    string AcSign = CXClientWrapper.Instance.Invoke<IMNMSVE00046, string>(x => x.SelectAccountSign(this.AccountNumber, CurrentUserEntity.BranchCode));
                    if (AcSign != null)
                    {
                        if (this.Text.Contains("Current") && AcSign.Substring(0, 1) != "C")
                        {
                            CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00058);
                            this.mtxtAccountNo.Focus();
                            return false;
                        }
                        else if (this.Text.Contains("Saving") && AcSign.Substring(0, 1) != "S")
                        {
                            CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00051);
                            this.mtxtAccountNo.Focus();
                            return false;
                        }
                    }
                    else
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MV00046");  //Invalid Account No
                        this.mtxtAccountNo.Focus();
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }  
        #endregion

        #region Events

        private void MNMVEW00046_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.Text = this.FormName;
            this.txtYear.Text = DateTime.Now.Year.ToString();
            this.bindData = false;
            this.cboMonth.Text = DateTime.Now.ToString("MMMM");
            this.MonthName = this.cboMonth.Text;
            this.bindData = true;
            this.grpFrame.Text = this.formName;

            if (this.FormName.Contains("Specific"))
            {
                this.EnableDisableControls(false);
                this.mtxtAccountNo.Focus();              
                this.Size = new System.Drawing.Size(533, 179);
                this.grpFrame.Size = new System.Drawing.Size(505, 107);
            }
            else if (this.FormName.Contains("All"))
            {
                this.EnableDisableControls(true);
                this.txtCurrentDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                this.lblAccountNo.Visible = true;
                this.mtxtAccountNo.Visible = true;
                this.mtxtAccountNo.Enabled = false;
                this.txtYear.Focus();
                this.lblAccountNo.Visible = false;
                this.mtxtAccountNo.Visible = false;
                this.lblRequireYear.Location = new System.Drawing.Point(28, 24);
                this.txtYear.Location = new System.Drawing.Point(125, 21);
                this.lblRequireMonth.Location = new System.Drawing.Point(28, 63);
                this.cboMonth.Location = new System.Drawing.Point(125, 60);
            }
        }     

        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CheckMonth();
        }

        private void cboMonth_Leave(object sender, EventArgs e)
        {
            this.CheckMonth();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (this.controller.Print())
            {
                if (Convert.ToInt32(this.txtYear.Text) > Convert.ToInt32(DateTime.Now.Year.ToString()))
                {
                    CXUIMessageUtilities.ShowMessageByCode("MV30032", new object[] { this.txtYear.Text, DateTime.Now.Year.ToString() });
                }
                else if (Convert.ToInt32(this.txtYear.Text) == Convert.ToInt32(DateTime.Now.Year.ToString()) && this.Month > Convert.ToInt32(DateTime.Now.Month.ToString()))
                {
                    CXUIMessageUtilities.ShowMessageByCode("MV30022", new object[] { this.cboMonth.Text, this.MonthName });
                }
                else
                {
                    IList<PFMDTO00001> AccountList = new List<PFMDTO00001>();

                    #region For All
                    if (this.Text.Contains("All"))
                    {
                        #region old code
                        //if (mtxtAccountNo.Text == "")  //if want to sep
                        //{
                        //    AccountList = this.DTOList.Where<PFMDTO00001>(x => x.IsCheck == true).ToList();
                        //}
                        //else
                        //{
                        //    PFMDTO00001 DTO = new PFMDTO00001();
                        //    DTO.AccountNo = this.mtxtAccountNo.Text;
                        //    AccountList.Add(DTO);
                        //}
                        #endregion old code

                        if (mtxtAccountNo.Text != "")
                        {
                            PFMDTO00001 DTO = new PFMDTO00001();
                            DTO.AccountNo = this.mtxtAccountNo.Text;
                            AccountList.Add(DTO);
                        }
                        if (this.gvAccount.RowCount <= 0)
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00171); //Grid Record must has at least one.
                            return;
                        }
                        IList<PFMDTO00001> List = new List<PFMDTO00001>();
                        List = this.DTOList.Where<PFMDTO00001>(x => x.IsCheck == true).ToList();
                        foreach (PFMDTO00001 dto in List)
                        {
                            AccountList.Add(dto);
                        }

                        if (AccountList.Count <= 0)
                        {
                            CXUIMessageUtilities.ShowMessageByCode("MV90012");//Please select at least one record.
                        }
                        else
                        {
                            this.controller.ViewReport(AccountList, this.Text);
                            this.mtxtAccountNo.Text = "";
                        }
                    }

                    #endregion

                    #region For Specific
                    else
                    {
                        if (this.Check_AccountNo())
                        {
                            PFMDTO00001 DTO = new PFMDTO00001();
                            DTO.AccountNo = this.mtxtAccountNo.Text;
                            AccountList.Add(DTO);
                            this.controller.ViewReport(AccountList, this.Text);  // ViewReportbyAccountno                                   
                        }
                    }
                    #endregion
                }
            }
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.txtYear.Text = DateTime.Now.Year.ToString();
            //this.mtxtAccountNo.Enabled = true;
            this.mtxtAccountNo.Text = "";
            this.cboMonth.SelectedIndex = Convert.ToInt32(DateTime.Now.Month.ToString()) - 1;
            this.txtRecordCount.Text = "0";
            this.txtSelectedAccount.Text = "0";
            this.gvAccount.DataSource = null;
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvAccount_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int SelectCount = this.GetSelectedCount();
            this.txtSelectedAccount.Text = SelectCount.ToString();
            //if (txtSelectedAccount.Text == "0")
            //    this.mtxtAccountNo.Enabled = true;
            //else
            //    this.mtxtAccountNo.Enabled = false;           
        }

        private void gvAccount_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (gvAccount.IsCurrentCellDirty)
            {
                gvAccount.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void MNMVEW00046_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }
        #endregion   

    }
}
