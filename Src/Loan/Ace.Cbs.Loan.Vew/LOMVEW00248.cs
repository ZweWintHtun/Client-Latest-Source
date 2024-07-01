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

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00248 : BaseForm, ILOMVEW00240
    {
        string noOfName;
        string noOfNRC;
        public LOMVEW00248()
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

        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text.Replace("-", "").Trim(); }
            set { this.mtxtAccountNo.Text = value; }
        }

        public void CheckAccount()
        {
            IList<LOMDTO00244> lst = this.controller.CheckAccountForAccountClosed(AccountNo, CurrentUserEntity.BranchCode);
            if (lst[0].RetCode == "-1")
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00046);
                mtxtAccountNo.Text = "";
                return; 
            }
            else if (lst[0].RetCode == "-2")
            {
                MessageBox.Show("Account No has been closed.");
                mtxtAccountNo.Text = "";
                return; 
            }
            else if (lst[0].RetCode == "-3")
            {
                //Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00054);
                //return; 
                MessageBox.Show("This Account " + AccountNo + " is already loan account.");
                mtxtAccountNo.Text = "";
                return; 
            }
            else if (lst[0].RetCode == "-4")
            {
                //Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90205);
                //return; 

                MessageBox.Show("This Account " + AccountNo + " is already hp account.");
                mtxtAccountNo.Text = "";
                return;
            }
            else if (lst[0].RetCode == "-5")
            {
                //Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90206);
                //return;
                MessageBox.Show("This Dealer Account " + AccountNo + " is already hp account.");
                mtxtAccountNo.Text = "";
                return;
            }
            else if (lst[0].RetCode == "-6")
            {
                //Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90207);
                //return; 
                MessageBox.Show("This Account is already freezed.");
                mtxtAccountNo.Text = "";
                return;
            }
            else if (lst[0].RetCode == "-7")
            {
                //Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00056);
                //return;

                MessageBox.Show("This Account " + AccountNo + " is already Link Account.");
                mtxtAccountNo.Text = "";
                return;
            }
            else if (lst[0].RetCode == "0")
            {

                this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
                IList<LOMDTO00244> lstAccountInfo = this.controller.GetAccountInfoForAccountClosed(AccountNo,CurrentUserEntity.BranchCode);
                dgvAccountInfo.Rows.Clear();
                if (lstAccountInfo[0].RetCode != "0")
                {
                    MessageBox.Show(lstAccountInfo[0].RetMsg);
                    return;
                }
                
                txtBalance.Text = lstAccountInfo[0].Balance.ToString("N2");
                txtCompanyName.Text = lstAccountInfo[0].NAME;
                for (int i = 1; i < lstAccountInfo.Count; i++)
                {
                    if (AccountNo.Substring(5, 1) == "2")
                    {
                        noOfName = noOfName + "," + lstAccountInfo[i].NAME;
                        noOfNRC = noOfNRC + "," + lstAccountInfo[i].NRC;

                    }
                    if (AccountNo.Substring(5, 1) == "3")
                    {
                        noOfName = lstAccountInfo[0].NAME;
                        noOfNRC = "-";
                    }
                    object[] obj = { i, lstAccountInfo[i].NAME, lstAccountInfo[i].NRC };
                    dgvAccountInfo.Rows.Add(obj);

                }
                if (AccountNo.Substring(5, 1) == "2")
                {
                    noOfName = noOfName.Substring(1);
                    noOfNRC = noOfNRC.Substring(1);

                }
            }
        }

        public void InitializeControls()
        {

            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, false, true);
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.mtxtAccountNo.Text = string.Empty;
            txtCloseDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            mtxtAccountNo.Text = string.Empty;
            txtBalance.Text = string.Empty;
            txtCompanyName.Text = string.Empty;
            dgvAccountInfo.Rows.Clear();
        }
        
        private void mtxtAccountNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                if (mtxtAccountNo.Text.Replace("-", "").Trim() != "")
                {
                    CheckAccount();
                }
            }            
        }
        private void mtxtAccountNo_Leave(object sender, EventArgs e)
        {
            if (mtxtAccountNo.Text.Replace("-", "").Trim() != "")
            {
                CheckAccount();
            }
        }

        private void LOMVEW00248_Load(object sender, EventArgs e)
        {
           InitializeControls();
           this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, false, true);
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            IList<LOMDTO00244> lstAccountInfo = this.controller.GetAccountInfoForAccountClosed(AccountNo, CurrentUserEntity.BranchCode);
            decimal balance=lstAccountInfo[0].Balance;

            if (balance > 0)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90207);
                return;
            }
            else if (balance < 0)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90208);
                return;
            }
            else // balance=0
            {
                LOMDTO00244 dto = new LOMDTO00244();
                dto.AcctNo = AccountNo;
                dto.CreatedUserId = CurrentUserEntity.CurrentUserID;
                dto.SourceBr = CurrentUserEntity.BranchCode;
                dto.NoofName = noOfName;
                dto.NoofNRC = noOfNRC;
                
                string str = this.controller.Save_AccountClosed(dto);
                if (str=="0")
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90137);
                    InitializeControls();
                    return;
                }
            }
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            InitializeControls();
        }
    }
}
