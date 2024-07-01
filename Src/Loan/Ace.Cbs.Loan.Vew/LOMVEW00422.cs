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
    public partial class LOMVEW00422 : BaseDockingForm, ILOMVEW00422
    {
         public IList<LOMDTO00080> lst;
        public IList<LOMDTO00080> lstgv;
        public LOMDTO00080 dealerInfoLst;
        public LOMVEW00422()
        {
            InitializeComponent();
        }

        public LOMVEW00422(string parentFromId)
        {
            InitializeComponent();
            this.ParentFormId = parentFromId;
        }

        public LOMVEW00422(string parentFromId, LOMDTO00080 dealerInfoLst)
        {
            InitializeComponent();
            this.ParentFormId = parentFromId;

            dealerInfoLst.DealerNo = "";
            this.dealerInfoLst = dealerInfoLst;

        }

        public string ParentFormId { get; set; }
        
        private ILOMCTL00422 controller;
        public ILOMCTL00422 Controller
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

        private void tlspCommon_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LOMVEW00422_Load_1(object sender, EventArgs e)
        {
            lst = this.controller.GetAllDealerInformation(CurrentUserEntity.BranchCode);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvDealer.DataSource = null;
            lst = this.controller.GetAllDealerInformation(CurrentUserEntity.BranchCode);
            if (lst.Count == 0)
            {
                this.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                return;
            }

            if (txtNRC.Text.Length > 0)
                foreach (LOMDTO00080 dto in lst)
                {
                    if (dto.NRC == txtNRC.Text)
                    {
                        dgvDealer.DataSource = null;
                        dgvDealer.Rows.Clear();
                        dgvDealer.Refresh();
                        object[] row = { dto.DealerNo,dto.DealerAC, dto.Dname, dto.Business
                                   ,dto.Dphone,dto.Daddress,dto.email,dto.NRC,dto.fax
                                   ,dto.city,dto.BusinessEmail,dto.BusinessAddress,dto.commission };
                        dgvDealer.Rows.Add(row);
                    }
                }
            if (txtName.Text.Length > 0)
                foreach (LOMDTO00080 dto in lst)
                {
                    if (dto.Dname.ToUpper().Contains(txtName.Text.ToUpper()))
                    {
                        dgvDealer.DataSource = null;
                        dgvDealer.Rows.Clear();
                        dgvDealer.Refresh();
                        object[] row = { dto.DealerNo,dto.DealerAC, dto.Dname, dto.Business
                                   ,dto.Dphone,dto.Daddress,dto.email,dto.NRC,dto.fax
                                   ,dto.city,dto.BusinessEmail,dto.BusinessAddress,dto.commission };
                        dgvDealer.Rows.Add(row);
                    }
                }
            else  //all
            {
                lstgv = lst;
                dgvDealer.DataSource = null;
                dgvDealer.Rows.Clear();
                dgvDealer.Refresh();
                for (int i = 0; i < lstgv.Count; i++)
                {
                    object[] row = { lstgv[i].DealerNo, lstgv[i].DealerAC, lstgv[i].Dname, lstgv[i].Business
                                   ,lstgv[i].Dphone,lstgv[i].Daddress,lstgv[i].email,lstgv[i].NRC,lstgv[i].fax
                                   ,lstgv[i].city,lstgv[i].BusinessEmail,lstgv[i].BusinessAddress,lstgv[i].commission };
                    dgvDealer.Rows.Add(row);
                }
            }
        }

        private void dgvDealer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ////LOMDTO00080 dealerInfo = lstgv[e.RowIndex];
            //dealerInfoLst.DealerNo = dealerInfo.DealerNo;
            //dealerInfoLst.DealerAC = dealerInfo.DealerAC;
            //dealerInfoLst.Dname = dealerInfo.Dname;
            //dealerInfoLst.Business = dealerInfo.Business;
            //dealerInfoLst.NRC = dealerInfo.NRC;
            //dealerInfoLst.Dphone = dealerInfo.Dphone;
            //dealerInfoLst.fax = dealerInfo.fax;
            //dealerInfoLst.email = dealerInfo.email;
            //dealerInfoLst.Daddress = dealerInfo.Daddress;
            ////dealerInfoLst.Business = dealerInfo.Business;
            //dealerInfoLst.city = dealerInfo.city;
            //dealerInfoLst.BusinessEmail = dealerInfo.BusinessEmail;
            //dealerInfoLst.BusinessAddress = dealerInfo.BusinessAddress;
            //dealerInfoLst.commission = dealerInfo.commission;
            //LOMDTO00080 dealerInfo = lstgv[e.RowIndex];

            dealerInfoLst.DealerNo = dgvDealer[0, e.RowIndex].Value.ToString();
            dealerInfoLst.DealerAC = dgvDealer[1, e.RowIndex].Value.ToString();
            dealerInfoLst.Dname = dgvDealer[2, e.RowIndex].Value.ToString();
            dealerInfoLst.Business = dgvDealer[3, e.RowIndex].Value.ToString();
            dealerInfoLst.NRC = dgvDealer[4, e.RowIndex].Value.ToString();
            dealerInfoLst.Dphone = dgvDealer[5, e.RowIndex].Value.ToString();
            dealerInfoLst.fax = dgvDealer[6, e.RowIndex].ToString();
            dealerInfoLst.email = dgvDealer[7, e.RowIndex].Value.ToString();
            dealerInfoLst.Daddress = dgvDealer[8, e.RowIndex].Value.ToString();
            //dealerInfoLst.Business = dealerInfo.Business;
            dealerInfoLst.city = dgvDealer[9, e.RowIndex].Value.ToString();
            dealerInfoLst.BusinessEmail = dgvDealer[10, e.RowIndex].Value.ToString();
            dealerInfoLst.BusinessAddress = dgvDealer[11, e.RowIndex].Value.ToString();
            dealerInfoLst.commission = Convert.ToDecimal(dgvDealer[12, e.RowIndex].Value);

            //if (dealerInfo.DealerAC.Length < 15)
            //    dealerInfoLst.DealerNo = dealerInfo.DealerNo;
            //else
            //    dealerInfoLst.DealerNo = dealerInfo.DealerAC;

            //dealerInfoLst.commission = dealerInfo.commission;

            this.Close();
        }

        private void tlspCommon_ExitButtonClick_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
