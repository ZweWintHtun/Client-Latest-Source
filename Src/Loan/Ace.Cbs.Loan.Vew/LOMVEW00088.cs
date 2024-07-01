using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Ace.Windows.CXClient;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00088 : BaseDockingForm, ILOMVEW00088
    {
        #region Variables Declaration
        public IList<LOMDTO00092> lst;
        // For HP Limit Voucher Printing 
        public List<LOMDTO00234> lstHPLimitVou1;
        public List<LOMDTO00234> lstHPLimitVou2;
        public List<LOMDTO00234> lstHPLimitVou3;
        public List<LOMDTO00234> lstHPLimitVou4;

        public List<LOMDTO00234> lst_Debit_HPLimitVou;
        public List<LOMDTO00234> lst_Credit_HPLimitVou;

        public List<LOMDTO00234> lst_HP_LimitVouPrint;
        public List<LOMDTO00234> lsts_hpLoans_Limit_Vou_Print;

        public string eno;
        public string debitAcctNo;
        public string creditAcctNo;
        public string brCode;
        public string acType;
        public string serialNo;
        public string debitAcctDespDomestic;
        public string creditAcctDespDomestic;
        public int index;
        public string desp;
        public string dealerNo;
        string description = "";
        #endregion

        #region Constructor
        public LOMVEW00088()
        {
            InitializeComponent();
        }
        public LOMVEW00088(string parentFromId, IList<LOMDTO00092> lst,string dealerAC)
        {
            InitializeComponent();
            this.ParentFormId = parentFromId;
            this.lst = lst;
            this.dealerNo = dealerAC;
            this.eno = lst[0].eno;
        }
        
        private ILOMCTL00088 controller;
        public ILOMCTL00088 Controller
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
        public string ParentFormId { get; set; }
        #endregion 

        #region Event
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC00016) == DialogResult.Yes)
            {
                string rptName = "TransferVouPrintLists";
                lst_HP_LimitVouPrint=this.controller.Get_HPLimitVou_Lists(eno).ToList();
                this.HP_Reg_Vou_Printing(rptName, lst_HP_LimitVouPrint);
            }

            this.Close();
        }
        #endregion

        #region Method
        private void HP_Reg_Vou_Printing(string rptName, IList<LOMDTO00234> lst_HP_LimitVouPrint)
        {
            lstHPLimitVou1 = lst_HP_LimitVouPrint.Where(a => a.Narration.Contains("HP Reg Voucher")).ToList();
            lstHPLimitVou2 = lst_HP_LimitVouPrint.Where(a => a.Narration.Contains("Documentation Charges")).ToList();
            lstHPLimitVou3 = lst_HP_LimitVouPrint.Where(a => a.Narration.Contains("CustToDealer OR CustToSundry")).ToList();
            lstHPLimitVou4 = lst_HP_LimitVouPrint.Where(a => a.Narration.Contains("Commission Charges")).ToList();

            lsts_hpLoans_Limit_Vou_Print = new List<LOMDTO00234>();

            string dealerBusinessName = "";
            string dealerInfo = this.controller.GetDealerBusinessName_For_HPLimitVoucher_Printing(dealerNo);
            string[] strval = dealerInfo.Split('#');
            string dealerAC = strval[0];
            string dealerBizName = strval[1];

            if (dealerAC.Length ==0 || dealerAC=="") dealerBusinessName ="No Dealer A/C";
            else dealerBusinessName = dealerBizName;

            #region HP Reg Voucher
            for (int i = 0; i < lstHPLimitVou1.Count - 1; i++)
            {
                lst_Debit_HPLimitVou = lstHPLimitVou1.Where(a => a.Status == "TDV").ToList();
                lst_Credit_HPLimitVou = lstHPLimitVou1.Where(a => a.Status == "TCV").ToList();

                LOMDTO00234 transferVouPrint = new LOMDTO00234(); // For RDLC Display

                if (lst_Debit_HPLimitVou[i].AcctNo.Length == 6)
                {
                    debitAcctNo = lstHPLimitVou1[i].AcctNo;
                    index = debitAcctNo.IndexOf("0");
                    acType = debitAcctNo.Substring(0, index);
                    serialNo = debitAcctNo.Substring(index, debitAcctNo.Length - index);
                    desp = lst_Debit_HPLimitVou[i].HeadACName + "-" + lst_Debit_HPLimitVou[i].Desp + "(" + acType + "-" + serialNo + ")";
                }

                else if (lst_Debit_HPLimitVou[i].AcctNo.Length == 15 && lst_Debit_HPLimitVou[i].AcctNo.Substring(4, 1) == "2")
                {
                    debitAcctNo = lst_Debit_HPLimitVou[i].AcctNo;
                    brCode = debitAcctNo.Substring(0, 3);
                    acType = debitAcctNo.Substring(3, 3);
                    serialNo = debitAcctNo.Substring(6, 9);
                    debitAcctNo = brCode + " - " + acType + "-" + serialNo;
                    desp = "Customer A/C - ( " + debitAcctNo + " ) " + " " + lst_Debit_HPLimitVou[i].Desp;
                }

                else
                {
                    debitAcctNo = lst_Debit_HPLimitVou[i].AcctNo;
                    brCode = debitAcctNo.Substring(0, 3);
                    acType = debitAcctNo.Substring(3, 3);
                    serialNo = debitAcctNo.Substring(6, 9);
                    debitAcctNo = brCode + " - " + acType + "-" + serialNo;
                    desp = "Dealer A/C - ( " + debitAcctNo + " ) " + " " + dealerBusinessName;//lstDebit[i].Desp;
                }

                transferVouPrint.Eno = lst_Debit_HPLimitVou[i].Eno;
                transferVouPrint.DebitAcctDesp = desp;
                transferVouPrint.DebitAcctAmount = lst_Debit_HPLimitVou[i].Amount;
                transferVouPrint.DebitAcctNo = lst_Debit_HPLimitVou[i].AcctNo;
                transferVouPrint.DrNarration = lst_Debit_HPLimitVou[i].Desp;

                description=lst_Debit_HPLimitVou[i].Desp;

                //////////////For Credit Transactions////////////////

                if (lst_Credit_HPLimitVou[i].AcctNo.Length == 6)
                {
                    creditAcctNo = lst_Credit_HPLimitVou[i].AcctNo;
                    index = creditAcctNo.IndexOf("0");
                    acType = creditAcctNo.Substring(0, index);
                    serialNo = creditAcctNo.Substring(index, creditAcctNo.Length - index);
                    desp = lst_Credit_HPLimitVou[i].HeadACName + "-" + lst_Credit_HPLimitVou[i].Desp + "(" + acType + "-" + serialNo + ")";
                }

                else if (lst_Credit_HPLimitVou[i].AcctNo.Length == 15 && lst_Credit_HPLimitVou[i].AcctNo.Substring(4, 1) == "2")
                {
                    creditAcctNo = lst_Credit_HPLimitVou[i].AcctNo;
                    brCode = creditAcctNo.Substring(0, 3);
                    acType = creditAcctNo.Substring(3, 3);
                    serialNo = creditAcctNo.Substring(6, 9);
                    creditAcctNo = brCode + " - " + acType + "-" + serialNo;
                    desp = "Customer A/C - ( " + creditAcctNo + " ) " + " " + lst_Credit_HPLimitVou[i].Desp;
                }

                else
                {
                    debitAcctNo = lst_Credit_HPLimitVou[i].AcctNo;
                    brCode = debitAcctNo.Substring(0, 3);
                    acType = debitAcctNo.Substring(3, 3);
                    serialNo = debitAcctNo.Substring(6, 9);
                    debitAcctNo = brCode + " - " + acType + "-" + serialNo;
                    desp = "Dealer A/C - ( " + debitAcctNo + " ) " + " " + dealerBusinessName;//lstDebit[i].Desp;
                }

                transferVouPrint.Eno = lst_Credit_HPLimitVou[i].Eno;
                transferVouPrint.CreditAcctDesp = desp;
                transferVouPrint.CreditAcctAmount = lst_Credit_HPLimitVou[i].Amount;
                transferVouPrint.CreditAcctNo = lst_Credit_HPLimitVou[i].AcctNo;
                transferVouPrint.CrNarration = description;

                transferVouPrint.AmountInWords = this.AmountToWords(lst_Credit_HPLimitVou[i].Amount.ToString());
                lsts_hpLoans_Limit_Vou_Print.Add(transferVouPrint);

            } // End of For Looping
            #endregion

            #region Documentation Charges
            for (int i = 0; i < lstHPLimitVou2.Count - 1; i++)
            {
                lst_Debit_HPLimitVou = lstHPLimitVou2.Where(a => a.Status == "TDV").ToList();
                lst_Credit_HPLimitVou = lstHPLimitVou2.Where(a => a.Status == "TCV").ToList();

                LOMDTO00234 transferVouPrint = new LOMDTO00234(); // For RDLC Display

                if (lst_Debit_HPLimitVou[i].AcctNo.Length == 6)
                {
                    debitAcctNo = lstHPLimitVou2[i].AcctNo;
                    index = debitAcctNo.IndexOf("0");
                    acType = debitAcctNo.Substring(0, index);
                    serialNo = debitAcctNo.Substring(index, debitAcctNo.Length - index);
                    desp = lst_Debit_HPLimitVou[i].HeadACName + "-" + lst_Debit_HPLimitVou[i].Desp + "(" + acType + "-" + serialNo + ")";
                }

                else if (lst_Debit_HPLimitVou[i].AcctNo.Length == 15 && lst_Debit_HPLimitVou[i].AcctNo.Substring(4, 1) == "2")
                {
                    debitAcctNo = lst_Debit_HPLimitVou[i].AcctNo;
                    brCode = debitAcctNo.Substring(0, 3);
                    acType = debitAcctNo.Substring(3, 3);
                    serialNo = debitAcctNo.Substring(6, 9);
                    debitAcctNo = brCode + " - " + acType + "-" + serialNo;
                    desp = "Customer A/C - ( " + debitAcctNo + " ) " + " " + lst_Debit_HPLimitVou[i].Desp;
                }

                else
                {
                    debitAcctNo = lst_Debit_HPLimitVou[i].AcctNo;
                    brCode = debitAcctNo.Substring(0, 3);
                    acType = debitAcctNo.Substring(3, 3);
                    serialNo = debitAcctNo.Substring(6, 9);
                    debitAcctNo = brCode + " - " + acType + "-" + serialNo;
                    desp = "Dealer A/C - ( " + debitAcctNo + " ) " + " " + dealerBusinessName;//lstDebit[i].Desp;
                }

                transferVouPrint.Eno = lst_Debit_HPLimitVou[i].Eno;
                transferVouPrint.DebitAcctDesp = desp;
                transferVouPrint.DebitAcctAmount = lst_Debit_HPLimitVou[i].Amount;
                transferVouPrint.DebitAcctNo = lst_Debit_HPLimitVou[i].AcctNo;
                transferVouPrint.DrNarration = lst_Credit_HPLimitVou[i].Desp;

                //////////////For Credit Transactions////////////////

                if (lst_Credit_HPLimitVou[i].AcctNo.Length == 6)
                {
                    creditAcctNo = lst_Credit_HPLimitVou[i].AcctNo;
                    index = creditAcctNo.IndexOf("0");
                    acType = creditAcctNo.Substring(0, index);
                    serialNo = creditAcctNo.Substring(index, creditAcctNo.Length - index);
                    desp = lst_Credit_HPLimitVou[i].HeadACName + "-" + lst_Credit_HPLimitVou[i].Desp + "(" + acType + "-" + serialNo + ")";
                }

                else if (lst_Credit_HPLimitVou[i].AcctNo.Length == 15 && lst_Credit_HPLimitVou[i].AcctNo.Substring(4, 1) == "2")
                {
                    creditAcctNo = lst_Credit_HPLimitVou[i].AcctNo;
                    brCode = creditAcctNo.Substring(0, 3);
                    acType = creditAcctNo.Substring(3, 3);
                    serialNo = creditAcctNo.Substring(6, 9);
                    creditAcctNo = brCode + " - " + acType + "-" + serialNo;
                    desp = "Customer A/C - ( " + creditAcctNo + " ) " + " " + lst_Credit_HPLimitVou[i].Desp;
                }

                else
                {
                    debitAcctNo = lst_Credit_HPLimitVou[i].AcctNo;
                    brCode = debitAcctNo.Substring(0, 3);
                    acType = debitAcctNo.Substring(3, 3);
                    serialNo = debitAcctNo.Substring(6, 9);
                    debitAcctNo = brCode + " - " + acType + "-" + serialNo;
                    desp = "Dealer A/C - ( " + debitAcctNo + " ) " + " " + dealerBusinessName;//lstDebit[i].Desp;
                }

                transferVouPrint.Eno = lst_Credit_HPLimitVou[i].Eno;
                transferVouPrint.CreditAcctDesp = desp;
                transferVouPrint.CreditAcctAmount = lst_Credit_HPLimitVou[i].Amount;
                transferVouPrint.CreditAcctNo = lst_Credit_HPLimitVou[i].AcctNo;
                transferVouPrint.CrNarration = lst_Credit_HPLimitVou[i].Desp;

                transferVouPrint.AmountInWords = this.AmountToWords(lst_Credit_HPLimitVou[i].Amount.ToString());
                lsts_hpLoans_Limit_Vou_Print.Add(transferVouPrint);

            } // End of For Looping
            #endregion

            #region CustToDealer OR CustToSundry
            for (int i = 0; i < lstHPLimitVou3.Count - 1; i++)
            {
                lst_Debit_HPLimitVou = lstHPLimitVou3.Where(a => a.Status == "TDV").ToList();
                lst_Credit_HPLimitVou = lstHPLimitVou3.Where(a => a.Status == "TCV").ToList();

                LOMDTO00234 transferVouPrint = new LOMDTO00234(); // For RDLC Display

                if (lst_Debit_HPLimitVou[i].AcctNo.Length == 6)
                {
                    debitAcctNo = lstHPLimitVou3[i].AcctNo;
                    index = debitAcctNo.IndexOf("0");
                    acType = debitAcctNo.Substring(0, index);
                    serialNo = debitAcctNo.Substring(index, debitAcctNo.Length - index);
                    desp = lst_Debit_HPLimitVou[i].HeadACName + "-" + lst_Debit_HPLimitVou[i].Desp +
                            "(" + acType + "-" + serialNo + ")" + " " + dealerBusinessName;
                }

                else if (lst_Debit_HPLimitVou[i].AcctNo.Length == 15 && lst_Debit_HPLimitVou[i].AcctNo.Substring(4, 1) == "2")
                {
                    debitAcctNo = lst_Debit_HPLimitVou[i].AcctNo;
                    brCode = debitAcctNo.Substring(0, 3);
                    acType = debitAcctNo.Substring(3, 3);
                    serialNo = debitAcctNo.Substring(6, 9);
                    debitAcctNo = brCode + " - " + acType + "-" + serialNo;
                    desp = "Customer A/C - ( " + debitAcctNo + " ) " + " " + lst_Debit_HPLimitVou[i].Desp;
                }

                else
                {
                    debitAcctNo = lst_Debit_HPLimitVou[i].AcctNo;
                    brCode = debitAcctNo.Substring(0, 3);
                    acType = debitAcctNo.Substring(3, 3);
                    serialNo = debitAcctNo.Substring(6, 9);
                    debitAcctNo = brCode + " - " + acType + "-" + serialNo;
                    desp = "Dealer A/C - ( " + debitAcctNo + " ) " + " " + dealerBusinessName;//lstDebit[i].Desp;
                }

                transferVouPrint.Eno = lst_Debit_HPLimitVou[i].Eno;
                transferVouPrint.DebitAcctDesp = desp;
                transferVouPrint.DebitAcctAmount = lst_Debit_HPLimitVou[i].Amount;
                transferVouPrint.DebitAcctNo = lst_Debit_HPLimitVou[i].AcctNo;
                transferVouPrint.DrNarration = description; //lst_Debit_HPLimitVou[i].Desp;
                //}

                //////////////For Credit Transactions////////////////

                if (lst_Credit_HPLimitVou[i].AcctNo.Length == 6)
                {
                    creditAcctNo = lst_Credit_HPLimitVou[i].AcctNo;
                    index = creditAcctNo.IndexOf("0");
                    acType = creditAcctNo.Substring(0, index);
                    serialNo = creditAcctNo.Substring(index, creditAcctNo.Length - index);
                    desp = lst_Credit_HPLimitVou[i].HeadACName + "-" + lst_Credit_HPLimitVou[i].Desp 
                        + "(" + acType + "-" + serialNo + ")"+" "+dealerBusinessName;
                }

                else if (lst_Credit_HPLimitVou[i].AcctNo.Length == 15 && lst_Credit_HPLimitVou[i].AcctNo.Substring(4, 1) == "2")
                {
                    creditAcctNo = lst_Credit_HPLimitVou[i].AcctNo;
                    brCode = creditAcctNo.Substring(0, 3);
                    acType = creditAcctNo.Substring(3, 3);
                    serialNo = creditAcctNo.Substring(6, 9);
                    creditAcctNo = brCode + " - " + acType + "-" + serialNo;
                    desp = "Customer A/C - ( " + creditAcctNo + " ) " + " " + lst_Credit_HPLimitVou[i].Desp;
                }

                else
                {
                    debitAcctNo = lst_Credit_HPLimitVou[i].AcctNo;
                    brCode = debitAcctNo.Substring(0, 3);
                    acType = debitAcctNo.Substring(3, 3);
                    serialNo = debitAcctNo.Substring(6, 9);
                    debitAcctNo = brCode + " - " + acType + "-" + serialNo;
                    desp = "Dealer A/C - ( " + debitAcctNo + " ) " + " " + dealerBusinessName;//lstDebit[i].Desp;
                }

                transferVouPrint.Eno = lst_Credit_HPLimitVou[i].Eno;
                transferVouPrint.CreditAcctDesp = desp;
                transferVouPrint.CreditAcctAmount = lst_Credit_HPLimitVou[i].Amount;
                transferVouPrint.CreditAcctNo = lst_Credit_HPLimitVou[i].AcctNo;
                transferVouPrint.CrNarration = description;//lst_Debit_HPLimitVou[i].Desp;
                //}

                transferVouPrint.AmountInWords = this.AmountToWords(lst_Credit_HPLimitVou[i].Amount.ToString());
                lsts_hpLoans_Limit_Vou_Print.Add(transferVouPrint);

            } // End of For Looping
            #endregion

            #region Commission Charges
            for (int i = 0; i < lstHPLimitVou4.Count - 1; i++)
            {
                lst_Debit_HPLimitVou = lstHPLimitVou4.Where(a => a.Status == "TDV").ToList();
                lst_Credit_HPLimitVou = lstHPLimitVou4.Where(a => a.Status == "TCV").ToList();

                LOMDTO00234 transferVouPrint = new LOMDTO00234(); // For RDLC Display

                if (lst_Debit_HPLimitVou[i].AcctNo.Length == 6)
                {
                    debitAcctNo = lstHPLimitVou4[i].AcctNo;
                    index = debitAcctNo.IndexOf("0");
                    acType = debitAcctNo.Substring(0, index);
                    serialNo = debitAcctNo.Substring(index, debitAcctNo.Length - index);
                    desp = lst_Debit_HPLimitVou[i].HeadACName + "-" + lst_Debit_HPLimitVou[i].Desp + "(" + acType + "-" + serialNo + ")";
                }

                else if (lst_Debit_HPLimitVou[i].AcctNo.Length == 15 && lst_Debit_HPLimitVou[i].AcctNo.Substring(4, 1) == "2")
                {
                    debitAcctNo = lst_Debit_HPLimitVou[i].AcctNo;
                    brCode = debitAcctNo.Substring(0, 3);
                    acType = debitAcctNo.Substring(3, 3);
                    serialNo = debitAcctNo.Substring(6, 9);
                    debitAcctNo = brCode + " - " + acType + "-" + serialNo;
                    desp = "Customer A/C - ( " + debitAcctNo + " ) " + " " + lst_Debit_HPLimitVou[i].Desp;
                }

                else
                {
                    debitAcctNo = lst_Debit_HPLimitVou[i].AcctNo;
                    brCode = debitAcctNo.Substring(0, 3);
                    acType = debitAcctNo.Substring(3, 3);
                    serialNo = debitAcctNo.Substring(6, 9);
                    debitAcctNo = brCode + " - " + acType + "-" + serialNo;
                    desp = "Dealer A/C - ( " + debitAcctNo + " ) " + " " + dealerBusinessName;//lstDebit[i].Desp;
                }

                transferVouPrint.Eno = lst_Debit_HPLimitVou[i].Eno;
                transferVouPrint.DebitAcctDesp = desp;
                transferVouPrint.DebitAcctAmount = lst_Debit_HPLimitVou[i].Amount;
                transferVouPrint.DebitAcctNo = lst_Debit_HPLimitVou[i].AcctNo;
                transferVouPrint.DrNarration = "HP Dealer Commission (____) % ";//lst_Credit_HPLimitVou[i].Desp;

                //////////////For Credit Transactions////////////////

                if (lst_Credit_HPLimitVou[i].AcctNo.Length == 6)
                {
                    creditAcctNo = lst_Credit_HPLimitVou[i].AcctNo;
                    index = creditAcctNo.IndexOf("0");
                    acType = creditAcctNo.Substring(0, index);
                    serialNo = creditAcctNo.Substring(index, creditAcctNo.Length - index);
                    desp = lst_Credit_HPLimitVou[i].HeadACName + "-" + lst_Credit_HPLimitVou[i].Desp + "(" + acType + "-" + serialNo + ")";
                }

                else if (lst_Credit_HPLimitVou[i].AcctNo.Length == 15 && lst_Credit_HPLimitVou[i].AcctNo.Substring(4, 1) == "2")
                {
                    creditAcctNo = lst_Credit_HPLimitVou[i].AcctNo;
                    brCode = creditAcctNo.Substring(0, 3);
                    acType = creditAcctNo.Substring(3, 3);
                    serialNo = creditAcctNo.Substring(6, 9);
                    creditAcctNo = brCode + " - " + acType + "-" + serialNo;
                    desp = "Customer A/C - ( " + creditAcctNo + " ) " + " " + lst_Credit_HPLimitVou[i].Desp;
                }

                else
                {
                    debitAcctNo = lst_Credit_HPLimitVou[i].AcctNo;
                    brCode = debitAcctNo.Substring(0, 3);
                    acType = debitAcctNo.Substring(3, 3);
                    serialNo = debitAcctNo.Substring(6, 9);
                    debitAcctNo = brCode + " - " + acType + "-" + serialNo;
                    desp = "Dealer A/C - ( " + debitAcctNo + " ) " + " " + dealerBusinessName;//lstDebit[i].Desp;
                }

                transferVouPrint.Eno = lst_Credit_HPLimitVou[i].Eno;
                transferVouPrint.CreditAcctDesp = desp;
                transferVouPrint.CreditAcctAmount = lst_Credit_HPLimitVou[i].Amount;
                transferVouPrint.CreditAcctNo = lst_Credit_HPLimitVou[i].AcctNo;
                transferVouPrint.CrNarration = "HP Dealer Commission (____) % ";//lst_Credit_HPLimitVou[i].Desp;

                transferVouPrint.AmountInWords = this.AmountToWords(lst_Credit_HPLimitVou[i].Amount.ToString());
                lsts_hpLoans_Limit_Vou_Print.Add(transferVouPrint);

            } // End of For Looping
            #endregion

            this.controller.Call_Transfer_Voucher_Printing(rptName, lsts_hpLoans_Limit_Vou_Print);
        }
        #endregion

        #region Form_Load
        private void LOMVEW00088_Load(object sender, EventArgs e)
        {
            dgvHPVoucher.DataSource = null;
            dgvHPVoucher.DataSource = lst;
            if(dgvHPVoucher.Columns.Count>1)
            {

                dgvHPVoucher.Columns[0].Visible = true;
                dgvHPVoucher.Columns[1].Visible = true;
                dgvHPVoucher.Columns[2].Visible = true;
                dgvHPVoucher.Columns[3].Visible = false;
                dgvHPVoucher.Columns[4].Visible = false;
                dgvHPVoucher.Columns[5].Visible = false;
                dgvHPVoucher.Columns[6].Visible = false;
                dgvHPVoucher.Columns[7].Visible = false;
                dgvHPVoucher.Columns[8].Visible = false;
                dgvHPVoucher.Columns[9].Visible = false;
                dgvHPVoucher.Columns[10].Visible = false;

                //dgvHPVoucher.Columns[0].Visible = false;
                //dgvHPVoucher.Columns[1].Visible = true;
                //dgvHPVoucher.Columns[2].Visible = true;
                //dgvHPVoucher.Columns[3].Visible = true;
                //dgvHPVoucher.Columns[4].Visible = false;
                //dgvHPVoucher.Columns[5].Visible = false;
                //dgvHPVoucher.Columns[6].Visible = false;
                //dgvHPVoucher.Columns[7].Visible = false;
                //dgvHPVoucher.Columns[8].Visible = false;
                //dgvHPVoucher.Columns[9].Visible = false;
                //dgvHPVoucher.Columns[10].Visible = false;
                //dgvHPVoucher.Columns[11].Visible = false;
                //dgvHPVoucher.Columns[12].Visible = false;
                //dgvHPVoucher.Columns[13].Visible = false;
                //dgvHPVoucher.Columns[14].Visible = false;
            }
        }
        #endregion

        #region AmountInWords
        public string ReportAmountInword;

        //To Convert Number From Amount Textbox to Words
        private string AmountToWords(string inputStr)
        {
            string point = string.Empty;
            string firstamount = string.Empty;
            string[] answers = inputStr.Split(new string[] { ".", " " }, StringSplitOptions.RemoveEmptyEntries);

            if (answers.Length > 1)
            {
                firstamount = this.NumberToWords(Convert.ToInt64(answers[0]));
                if ((Convert.ToInt32(answers[1])) > 0)
                {
                    point = this.NumberToWords(Convert.ToInt64(answers[1]));
                }
            }
            else
            {
                firstamount = this.NumberToWords(Convert.ToInt64(answers[0]));
            }


            this.ReportAmountInword = "Kyats " + firstamount + " ";
            if (string.IsNullOrEmpty(point))
            {
                this.ReportAmountInword += " Only.";
            }
            else
            {
                this.ReportAmountInword += " " + point + " " + "Pyar Only.";
            }

            return ReportAmountInword;
        }

        //To Conver Number to Letter
        private string NumberToWords(Int64 number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";
            if ((number / 100000000) > 0)
            {
                if ((number / 10000000) > 0)
                {
                    if ((number / 1000000) > 0)
                    {
                        words +=" "+ NumberToWords(number / 1000000) + " Million";
                        number %= 1000000;
                    }
                    else
                    {
                        words += " " + NumberToWords(number / 10000000) + " Billion";
                        number %= 10000000;
                    }
                }
                else
                {
                    words += " " + NumberToWords(number / 100000000) + " Trillion";
                    number %= 100000000;
                }
            }
            if ((number / 10000000) > 0)
            {
                if ((number / 1000000) > 0)
                {
                    words += " " + NumberToWords(number / 1000000) + " Million";
                    number %= 1000000;
                }
                else
                {
                    words += " " + NumberToWords(number / 10000000) + " Billion";
                    number %= 10000000;
                }
            }

            if ((number / 1000000) > 0)
            {
                words += " " + NumberToWords(number / 1000000) + " Million";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += " " + NumberToWords(number / 1000) + " Thousand";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += " " + NumberToWords(number / 100) + " Hundred";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += " " + " and ";

                var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                if (number < 20)
                    words += " " + unitsMap[number];
                else
                {
                    words += " " + tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += " " + "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

        private string CashInZawGyiFont(decimal amount)
        {
            //int stringCount = (amount.ToString().Length);
            string keyword = string.Empty;
            //for (int i = 0; i < stringCount; i++)
            //{
            //    keyword += (amount.ToString()).;
            //}
            //return keyword;

            char[] keys = (amount.ToString()).ToCharArray();
            foreach (char item in keys)
            {
                keyword += GetZawGyiFont(item);
            }
            return keyword;
        }

        private string GetZawGyiFont(char key)
        {
            switch (key)
            {
                case '1':
                    return "၁";
                case '2':
                    return "၂";
                case '3':
                    return "၃";
                case '4':
                    return "၄";
                case '5':
                    return "၅";
                case '6':
                    return "၆";
                case '7':
                    return "၇";
                case '8':
                    return "၈";
                case '9':
                    return "၉";
                default:
                    return "၀";
            }
        }
        #endregion
    }
}
