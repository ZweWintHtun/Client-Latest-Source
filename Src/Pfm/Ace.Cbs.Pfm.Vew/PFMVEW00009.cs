using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Cx.Cle;

namespace Ace.Cbs.Pfm.Vew
{
    public partial class frmPFMVEW00009 : BaseDockingForm, IPFMVEW00009
    {
        #region Constructor

        public frmPFMVEW00009()
        {
            InitializeComponent();
        }

        public frmPFMVEW00009(bool isOnlyforPrint, int printlineNo ,PFMDTO00043 printFileDto, bool isSavePrnFile)
        {
            InitializeComponent();
            this.IsOnlyforPrint = isOnlyforPrint;
            this.LineNo = printlineNo;
            this.prnFileDTO = printFileDto;
            this.isSaveUI = isSavePrnFile;
            //this.AccountNo = acctno;
        }
        public frmPFMVEW00009(bool isOnlyforPrint, int printlineNo)
        {
            InitializeComponent();
            this.IsOnlyforPrint = isOnlyforPrint;
            this.LineNo = printlineNo;
            //this.AccountNo = acctno;
        }

        public bool IsOnlyforPrint { get; set; }
        public int LineNo { get; set; }
      
        //call from TCMVEW00003(PO Issue By Transfer)
        public frmPFMVEW00009(int menuIdForPermission, PFMDTO00043 printFileDto, string accountSign,bool isSavePrnFile)
        {
            InitializeComponent();
            CurrentUserEntity.CurrentMenuId = menuIdForPermission;
            this.prnFileDTO = printFileDto;
            this.AccountSign = accountSign;
            this.isSaveUI = isSavePrnFile;
        }

        public frmPFMVEW00009(int menuIdForPermission, PFMDTO00043 printFileDto, string accountSign)//call from PFMVEW00008
        {
            InitializeComponent();
            CurrentUserEntity.CurrentMenuId = menuIdForPermission;
            this.prnFileDTO = printFileDto;
            this.AccountSign = accountSign;
            this.isSaveUI = true;
        }
      
        public frmPFMVEW00009(string accountno)
        {
            InitializeComponent();
            //CurrentUserEntity.CurrentMenuId = menuIdForPermission;
            this.AccountNo = accountno;
        }
        #endregion

        #region Controller

        private IPFMCTL00009 printLineEntryController;
        public IPFMCTL00009 PrintLineEntryController
        {
            get { return this.printLineEntryController; }
            set
            {
                this.printLineEntryController = value;
                this.printLineEntryController.PrintLineEntryView = this;
            }
        }

        #endregion

        #region View Data Properties

        public int PrintLineNo
        {
            set
            {
                this.txtLineNo.Text = Convert.ToString(value);
            }
            get
            {
                int result = 0;
                Int32.TryParse(this.txtLineNo.Text, out result);
                return result;
            }
        }

        public string AccountSign
        {
            get;
            set;
        }
        public string AccountNo
        {
            get;
            set;
        }

        public bool IsDoPrinting
        {
            get { return chkDoPrinting.Checked; }
        }
        public bool isSaveUI
        {
            get;
            set;
        }

        
        public List<string[]> printingList { get; set; }
        public IList<PFMDTO00043> PrnFiles { get; set; }

        public IList<PFMDTO00058> FPrnFiles { get; set; }

        #endregion

        #region Entities

        private PFMDTO00043 prnFileDTO;
        public PFMDTO00043 PrnFileDTO
        {
            get
            {
                return prnFileDTO;
            }
            set
            {
                this.prnFileDTO = value;
            }
        }

        private PFMDTO00058 fPrnFileDTO;
        public PFMDTO00058 FPrnFileDTO
        {
            get
            {
                if(this.fPrnFileDTO == null)
                    this.fPrnFileDTO = new PFMDTO00058();
                this.fPrnFileDTO.AccountNo = this.prnFileDTO.AccountNo;
                this.fPrnFileDTO.AccessDate = this.prnFileDTO.DATE_TIME;
                this.fPrnFileDTO.AccessUser = this.prnFileDTO.UserNo;
                this.fPrnFileDTO.Credit = this.prnFileDTO.Credit;
                this.fPrnFileDTO.Debit = this.prnFileDTO.Debit;
                this.fPrnFileDTO.Balance = this.prnFileDTO.Balance;
                this.fPrnFileDTO.Channel = this.prnFileDTO.Channel;
                this.fPrnFileDTO.CurrencyId = this.prnFileDTO.CurrencyCode;
                this.fPrnFileDTO.SourceBr = this.prnFileDTO.SourceBranchCode;
                this.fPrnFileDTO.Reference = this.prnFileDTO.Reference;
                return this.fPrnFileDTO;
            }
            set
            {
                this.FPrnFileDTO = value;
            }
        } 

        #endregion

        #region Public Methods

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        public void Confirmation(string message, bool isDelete)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            
            if (isDelete)
            {
                this.printLineEntryController.DeletePrintingFile();
            }
            else
            {
                this.printLineEntryController.UpdatePrintingLine();
            }   
        }

        #endregion

        #region Events

        private void tlspCommon_CancelButtonClick(object sender, EventArgs e)
        {
            this.txtLineNo.ResetText();
        }

        private void tlspCommon_ExitButtonClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void PFMVEW00009_Load(object sender, EventArgs e)
        {
            this.tlspCommon.ButtonEnableDisabled(false, false, true, false, true, false, true);
            if (this.IsOnlyforPrint)
            {
                lblPrintInformation.Visible = false;
                lblSaveInformation.Visible = false;
                lblCancelInformation.Visible = false;
                chkDoPrinting.Visible = false;
                this.gvGroupInfo.Visible = false;
                lblLineNo.Visible = true;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                this.MaximizeBox  = false;
                this.MinimizeBox = false;
                this.StartPosition = FormStartPosition.CenterParent;
                this.Size = new System.Drawing.Size(500, 150);
               
                this.lblLineNo.Location = new System.Drawing.Point(75, 50);
                this.txtLineNo.Location = new System.Drawing.Point(131, 50);
                this.Text = "Print";
                txtLineNo.Text = this.LineNo.ToString();
                this.tlspCommon.butSave.Enabled = false;
                this.tlspCommon.butPrint.Enabled = true;
                this.MouseMove -= new System.Windows.Forms.MouseEventHandler(this.frmPFMVEW00009_MouseMove);
                this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmPFMVEW00009_MouseMove);
            }
            else
            {
                gvGroupInfo.Visible = false;
                lblLineNo.Visible = false;
                txtLineNo.Visible = false;
                this.printLineEntryController.SelectPrintLineCount(PrnFileDTO.AccountNo);
            }            

           
        }

        private void tlspCommon_PrintButtonClick(object sender, EventArgs e)
        {
           
            //if(!IsOnlyforPrint)
                if(this.printLineEntryController.Printing(isSaveUI))
                {
                    //bool isFinish=true;
                    //CXUIScreenTransit.SetData(this.ParentForm.Text,isFinish);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
          //  }

                //else
                //{
                //    CXCLE00005.Instance.PrintingList("PassBookCode", "LineByLine", "PassBookPrinting", this.printingList, false, true);
                //    this.DialogResult = DialogResult.OK;
                //    this.Close();
                //}
            
        }

        private void tlspCommon_SaveButtonClick(object sender, EventArgs e)
        {
            if (isSaveUI==true)
            {
                this.printLineEntryController.SavePrintingFile();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void frmPFMVEW00009_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.tlspCommon.PerformExitButtonClick();
            }
            else if (e.KeyCode == Keys.F2)
            {
                if (this.chkDoPrinting.Checked == false)
                {
                    this.tlspCommon.PerformSaveButtonClick();
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00010);
                }
            }
            else if (e.KeyCode == Keys.F7)
            {
                if (this.chkDoPrinting.Checked)
                {
                    this.tlspCommon.PerformPrintButtonClick();
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00010);
                }                  
            }
        }

        private void chkDoPrinting_CheckedChanged(object sender, EventArgs e)
        {
            gvGroupInfo.Visible = chkDoPrinting.Checked;
            lblLineNo.Visible = chkDoPrinting.Checked;
            txtLineNo.Visible = chkDoPrinting.Checked;
            this.tlspCommon.ButtonEnableDisabled(false, false, !chkDoPrinting.Checked, false, chkDoPrinting.Checked, chkDoPrinting.Checked, true);
        }

        #endregion

        private void frmPFMVEW00009_MouseMove(object sender, MouseEventArgs e)
        {
            this.CenterToParent();
        }
    }
}
