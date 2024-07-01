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

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00080 : BaseDockingForm, ILOMVEW00080
    {
        public IList<LOMDTO00080> lst;
        public IList<LOMDTO00080> lstgv;
        public LOMDTO00080 dealerInfoLst;
        public LOMVEW00080()
        {
            InitializeComponent();
        }

        public LOMVEW00080(string parentFromId)
        {
            InitializeComponent();
            this.ParentFormId = parentFromId;
        }

        public LOMVEW00080(string parentFromId, LOMDTO00080 dealerInfoLst)
        {
            InitializeComponent();
            this.ParentFormId = parentFromId;

            dealerInfoLst.DealerNo = "";
            this.dealerInfoLst = dealerInfoLst;

        }

        public string ParentFormId { get; set; }

        private ILOMCTL00080 controller;
        public ILOMCTL00080 Controller
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


        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        private void LOMVEW00080_Load(object sender, EventArgs e)
        {
            lst = this.controller.GetAllDealerInformation(CurrentUserEntity.BranchCode);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.FillToGrid();
        }

        public void FillToGrid()
        {
            dgvDealer.DataSource = null;
            //if (lst.Count == 0)
            //{
            //    this.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            //    return;
            //}

            lst = this.controller.GetAllDealerInformation(CurrentUserEntity.BranchCode);

            //lstgv = lst;
            string name = txtName.Text;
            string nrc = txtNRC.Text;
            
            if (txtNRC.Text.Length > 0)
            {
                lst = lst.Where(x => x.NRC == nrc).ToList();
            }
            if (txtName.Text.Length > 0)
            {
                lst = lst.Where(x => x.Dname.StartsWith(name)).ToList();
            }

            //dgvDealer.DataSource = lstgv; // Commented By AAM (12_Apr_2018)

            // Added By AAM (12_Apr_2018)
            dgvDealer.Rows.Clear();
            for (int i = 0; i < lst.Count; i++)
            {
                object[] row = { false, lst[i].DealerNo, lst[i].DealerAC, lst[i].Dname, lst[i].Business
                                   ,lst[i].Dphone,lst[i].Daddress,lst[i].email,lst[i].NRC,lst[i].fax
                                   ,lst[i].city,lst[i].BusinessEmail,lst[i].BusinessAddress,lst[i].commission };
                dgvDealer.Rows.Add(row);
            }
        }

        private void dgvDealer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            LOMDTO00080 dealerInfo = lstgv[e.RowIndex];
            dealerInfoLst.DealerNo = dealerInfo.DealerNo;
            dealerInfoLst.DealerAC = dealerInfo.DealerAC;
            dealerInfoLst.Dname = dealerInfo.Dname;
            dealerInfoLst.Business = dealerInfo.Business;
            dealerInfoLst.NRC = dealerInfo.NRC;
            dealerInfoLst.Dphone = dealerInfo.Dphone;
            dealerInfoLst.fax = dealerInfo.fax;
            dealerInfoLst.email = dealerInfo.email;
            dealerInfoLst.Daddress = dealerInfo.Daddress;
            //dealerInfoLst.Business = dealerInfo.Business;
            dealerInfoLst.city = dealerInfo.city;
            dealerInfoLst.BusinessEmail = dealerInfo.BusinessEmail;
            dealerInfoLst.BusinessAddress = dealerInfo.BusinessAddress;
            dealerInfoLst.commission = dealerInfo.commission;

            //if (dealerInfo.DealerAC.Length < 15)
            //    dealerInfoLst.DealerNo = dealerInfo.DealerNo;
            //else
            //    dealerInfoLst.DealerNo = dealerInfo.DealerAC;

            //dealerInfoLst.commission = dealerInfo.commission;

            this.Close();
        }
        private void tlspCommon_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Successful(string message, string dealerNo)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        private void Save()
        {
            string dealerNoStr = "";
            for (int i = 0; i < dgvDealer.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgvDealer.Rows[i].Cells[0].Value))
                {
                    dealerNoStr += "," + Convert.ToString(dgvDealer.Rows[i].Cells[1].Value) + "";
                }
                
            }

            if (dealerNoStr.Length == 0)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90207); //Please select/check at least one rows in data grid!
                return;
            }
            
            dealerNoStr = dealerNoStr.Substring(1);

            if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC90001) == DialogResult.Yes)
            {
                this.controller.DeleteDealerRegistration(dealerNoStr,CurrentUserEntity.CurrentUserID,CurrentUserEntity.BranchCode);
                this.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode, dealerNoStr);
                
                lst= this.controller.GetAllDealerInformation(CurrentUserEntity.BranchCode);

                dgvDealer.Rows.Clear();
                for (int i = 0; i < lst.Count; i++)
                {
                    object[] row = { false, lst[i].DealerNo, lst[i].DealerAC, lst[i].Dname, lst[i].Business
                                   ,lst[i].Dphone,lst[i].Daddress,lst[i].email,lst[i].NRC,lst[i].fax
                                   ,lst[i].city,lst[i].BusinessEmail,lst[i].BusinessAddress,lst[i].commission };
                    dgvDealer.Rows.Add(row);
                }
            }
            else
            {
                return;
            }

            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
