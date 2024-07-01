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
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00246 : BaseForm, ILOMVEW00239
    {
        #region Variable Declaration
        LOMDTO00241 dtoDealer;
        List<LOMDTO00241> lstHPInfo = new List<LOMDTO00241>();
        public string formatCode;
        public int valueCount;
        public string valueStr;
        int fromDateDataEntryCount = 0;

        #endregion
        #region Constructor
        public LOMVEW00246()
        {
            InitializeComponent();
        }

        private ILOMCTL00237 controller;
        public ILOMCTL00237 Controller
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
        #endregion 

        #region Properties
        public string DealerAC
        {
            get { return this.mtxtAcctno.Text; }
            set { this.mtxtAcctno.Text = value; }
        }
        public DateTime StartDate
        {
            get { return this.dtpStartDate.Value; }
            set { this.dtpStartDate.Text = value.ToString(); }
        }
        public DateTime EndDate
        {
            get { return this.dtpEndDate.Value; }
            set { this.dtpEndDate.Text = value.ToString(); }
        }
        public string SourceBr
        {
            get
            {
                if (this.cboBranch.SelectedValue == null)
                {
                    if (!CurrentUserEntity.IsHOUser)
                    {
                        SourceBr = CurrentUserEntity.BranchCode;
                        return CurrentUserEntity.BranchCode;
                    }
                    else return null;
                }
                else
                {
                    return this.cboBranch.SelectedValue.ToString();
                }

            }
            set { this.cboBranch.SelectedValue = value.ToString(); }
        }
        public string Currency
        {
            get
            {
                if (this.cboCurrency.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboCurrency.SelectedValue.ToString();
                }
            }
            set { this.cboCurrency.SelectedValue = value; }
        }
        #endregion 


        private void BindCurrency()
        {
            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
            cboCurrency.SelectedIndex = 0;
        }
        private void BindSourceBranch()
        {
            IList<BranchDTO> BranchList = CXCLE00002.Instance.GetListObject<BranchDTO>("Branch.Client.SelectNotOtherBank", new object[] { false });

            cboBranch.ValueMember = "BranchCode";
            cboBranch.DisplayMember = "BranchCode";
            cboBranch.DataSource = BranchList;
            cboBranch.SelectedIndex = 0;
        }

        public bool ValidationControls()
        {
            if (cboCurrency.SelectedIndex == -1)
            {
                errorProvider1.SetError(cboCurrency, "Currency");
            }

            if (cboBranch.SelectedIndex == -1)
            {
                errorProvider1.SetError(cboBranch, "Branch");
            }
            if (mtxtAcctno.TextLength == 0)
            {
                errorProvider1.SetError(mtxtAcctno, "DealerAcctNo");
            }

            if (cboCurrency.SelectedIndex == -1 || cboBranch.SelectedIndex == -1)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90067);
                errorProvider1.Clear();
                return false;
            }

            else return true;
        }
        public void InitializeControls()
        {
            tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);

            this.mtxtAcctno.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.mtxtAcctno.Text = string.Empty;

            fromDateDataEntryCount = 1;
            this.dtpStartDate.Value = DateTime.Now;
            this.dtpEndDate.Value = DateTime.Now;
            this.txtDealerName.Text = string.Empty;
            this.txtDealerBName.Text = string.Empty;
            this.lblHPCount.Text = string.Empty;
            this.dgvHPList.Rows.Clear();

            BindCurrency();
            BindSourceBranch();
            this.SourceBr = CurrentUserEntity.BranchCode;
            if (!CurrentUserEntity.IsHOUser)
            {
                this.cboBranch.Enabled = false;
            }
            else
            {
                this.cboBranch.Enabled = true;
            }
        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        private void mtxtAcctno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                BindHPList();
            }
        }

        private void LOMVEW00246_Load(object sender, EventArgs e)
        {
            BindSourceBranch();
            BindCurrency();
            this.InitializeControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.Save();          
            
        }

        private void Save()
        {
            string hpNoStr = "";
            for (int i = 0; i < dgvHPList.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgvHPList.Rows[i].Cells[0].Value))
                {
                    hpNoStr +=",'"+ Convert.ToString(dgvHPList.Rows[i].Cells[2].Value)+"'";
                }
            }

            if (hpNoStr.Length > 0)
                hpNoStr = hpNoStr.Substring(1);

            else if (dgvHPList.Rows.Count==0)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90113); //No Data to show!
                return;
            }
            else 
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90207); //Please select/check at least one rows in data grid!
                return;
            }

            if (!this.ValidationControls())
                return;
            
            // For generating entry no.
            formatCode = "NormalVoucher";
            valueStr = DateTime.Now.ToString("dd,MM,yy");
            valueCount = 3;

            LOMDTO00241 dto=new LOMDTO00241();
            dto.HPNoList=hpNoStr;
            dto.DealerAcctNo=DealerAC;
            dto.CreatedUserId=CurrentUserEntity.CurrentUserID;
            dto.SourceBr=CurrentUserEntity.BranchCode;
            dto.FormatCode=formatCode;
            dto.ValueCount=valueCount;
            dto.ValueStr=valueStr;

            string strVal = this.controller.Dealer_Interest_Prepaid_ForHP(dto);

            string[] strResult = strVal.Split('#');
            string retCode = strResult[0];
            string retDesp = strResult[1];

            if (retCode == "0")
            {
                this.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                this.InitializeControls();
            }
            else if (retDesp.Contains("Invalid"))
            {
                MessageBox.Show(retDesp);
                return;
            }
            else
            {
                this.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                this.InitializeControls();
            }
        }
        
        private void BindHPList()
        {
            LOMDTO00241 hpList = new LOMDTO00241();
            lstHPInfo = new List<LOMDTO00241>();

            hpList.DealerAcctNo = DealerAC;
            hpList.FromDate = StartDate;
            hpList.ToDate = StartDate; // if customer want EndDate,can modify easily;
            hpList.SourceBr = SourceBr;
            hpList.Currency = Currency;

            lstHPInfo.Add(hpList);
            dgvHPList.DataSource = null;

            IList<LOMDTO00241> lstTemp = this.controller.Get_HPList_For_Interest_Prepay_ByDealer(hpList);
            
            if (lstTemp == null || lstTemp.Count == 0)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90113); //No Data to show!
                return;
            }

            else if (lstTemp[0].DealerCheck=="-1")
	        {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90206);//Invalid Dealer Account Number!
                this.InitializeControls();
                return; 
	        } 

            dtoDealer = lstTemp[0];
            txtDealerName.Text = dtoDealer.Name;
            txtDealerBName.Text = dtoDealer.BusinessName;
            lblHPCount.Text = dtoDealer.HpList.Count.ToString();

            dgvHPList.Rows.Clear();
            for (int i = 0; i < dtoDealer.HpList.Count; i++)
            {
                object[] row = {false,Convert.ToInt32(i)+1 ,dtoDealer.HpList[i].HPNo, dtoDealer.HpList[i].AccountNo, dtoDealer.HpList[i].ProductGroup,
                                     dtoDealer.HpList[i].ProductName,dtoDealer.HpList[i].LoanAmount,dtoDealer.HpList[i].Duration,
                                     dtoDealer.HpList[i].TotalPrincipal,dtoDealer.HpList[i].TotalInterest};
                dgvHPList.Rows.Add(row);
            }
        }

        private void dtpStartDate_Leave(object sender, EventArgs e)
        {
            fromDateDataEntryCount += 1;
            if (fromDateDataEntryCount > 1)
            {
                BindHPList();
            }
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
        }

    }
}
