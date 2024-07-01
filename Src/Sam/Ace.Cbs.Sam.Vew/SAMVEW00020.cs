//----------------------------------------------------------------------
// <copyright file="SAMVEW00020.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>08/05/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Sam.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Sam.Vew
{
    public partial class SAMVEW00020 : BaseDockingForm, ISAMVEW00020
    {
        #region Constrator

        public SAMVEW00020()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public int Id
        {
            get { throw new NotImplementedException(); }
        }

        public string BranchCode
        {
            get
            {
                if (this.cboBranchCode.SelectedValue == null)
                    return string.Empty;
                else
                    return this.cboBranchCode.SelectedValue.ToString();
            }
            set { this.cboBranchCode.SelectedValue = value; }
        }

        public string SERVERNAME
        {
            get { return this.txtServerName.Text; }
            set { this.txtServerName.Text = value; }
        }

        public string DBNAME
        {
            get { return this.txtDBName.Text; }
            set { this.txtDBName.Text = value ; }
        }

        public string IPADDRESS
        {
            get { return this.txtIPAddress.Text; }
            set { this.txtIPAddress.Text = value; }
        }                

        public bool  NewSystem
        {
            get { return this.rdoNewSystem.Checked; }
            set { this.rdoNewSystem.Checked = value; }
        }

        //public string IBDIPADDRESS
        //{
        //    get { return this.txtIBDIPAddress.Text; }
        //    set { this.txtIBDIPAddress.Text = value; }
        //}  

        public bool OldSystem
        {
            get { return this.rdoOldSystem.Checked; }
            set { this.rdoOldSystem.Checked = value; }
        }

        public bool Vsat
        {
            get { return this.rdoVsat.Checked; }
            set { this.rdoVsat.Checked = value; }
        }

        public bool IPStar
        {
            get { return this.rdoIPStar.Checked; }
            set { this.rdoIPStar.Checked = value; }
        }

        public string Status { get; set; }

        private TLMDTO00027 viewData;
        public TLMDTO00027 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new TLMDTO00027();

                this.viewData.BRANCHNO = this.BranchCode;
                this.viewData.SERVERNAME = this.SERVERNAME;
                this.viewData.IPADDRESS = this.IPADDRESS;
                if (this.rdoNewSystem.Checked) this.viewData.VERSION = "NEW";
                if (this.rdoOldSystem.Checked) this.viewData.VERSION = "OLD";
                if (this.rdoVsat.Checked) this.viewData.ISPNAME ="VSAT";
                if (this.rdoIPStar.Checked) this.viewData.ISPNAME = "IPSTAR";
                this.viewData.DBNAME = this.DBNAME ;
                //this.viewData.IBDIPADDRESS = this.IBDIPADDRESS;
            

                return this.viewData;
            }
            set { this.viewData = value; }
        }

        public IList<TLMDTO00027> SERVERLOGs { get; set; }

        private ISAMCTL00020 controller;
        public ISAMCTL00020 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.SERVERLOGView = this;
            }
        }

        #endregion

        #region Method

        private void dgVSERVERLOG_DataBind()
        {
            gvBranchServer.AutoGenerateColumns = false;
            this.SERVERLOGs = this.controller.GetAll();
            this.gvBranchServer.DataSource = this.SERVERLOGs;
            this.txtRecordCount.Text = gvBranchServer.RowCount.ToString();

        }

        private void cboBranchCode_DataBind()
        {
            IList<BranchDTO> branches = this.controller.GetAllBranchCode();
            cboBranchCode.ValueMember = "BranchAlias";
            cboBranchCode.DisplayMember = "BranchAlias";
            cboBranchCode.DataSource = branches;
            cboBranchCode.SelectedIndex = -1;
        }

        private void ChangeControlStatusByUserType(bool isUpdateOnlyUser)
        {
            this.txtServerName.Enabled = isUpdateOnlyUser;            
            this.txtIPAddress.Enabled = isUpdateOnlyUser;
            this.cboBranchCode.Enabled = isUpdateOnlyUser;
            this.rdoNewSystem.Enabled = isUpdateOnlyUser;
            this.rdoOldSystem.Enabled = isUpdateOnlyUser;
            this.rdoVsat.Enabled = isUpdateOnlyUser;
            this.rdoIPStar.Enabled = isUpdateOnlyUser;
            this.txtDBName.Enabled = isUpdateOnlyUser;
            //this.txtIBDIPAddress.Enabled = isUpdateOnlyUser;

        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.dgVSERVERLOG_DataBind();
            this.InitializeControls();
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        private void InitializeControls()
        {
            this.cboBranchCode.SelectedIndex = -1;
            this.txtServerName.Text = string.Empty;
            this.txtIPAddress.Text = string.Empty;
            this.rdoIPStar.Checked = false;
            this.rdoOldSystem.Checked = false;
            this.txtDBName.Text = string.Empty;
            //this.txtIBDIPAddress.Text = string.Empty;

            this.Status = "Save";
        }

        #endregion

        #region Event

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.Controller.Save(this.ViewData);
          //  this.cboBranchCode.Focus();
            this.dgVSERVERLOG_DataBind();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.Controller.ClearErrors();
            this.gvBranchServer.EndEdit();
            IList<TLMDTO00027> List = this.SERVERLOGs.Where<TLMDTO00027>(x => x.IsCheck == true).ToList();
            foreach (TLMDTO00027 dto in List)
            {
                dto.IsCheck = false;
            }
            this.cboBranchCode.Focus();

        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvBranchServer.EndEdit();
            IList<TLMDTO00027> deleteList = this.SERVERLOGs.Where<TLMDTO00027>(x => x.IsCheck == true).ToList();
            if (deleteList.Count > 0)
            {
                if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes)
                {
                    this.Controller.Delete(deleteList);
                    this.cboBranchCode.Focus();
                }
            }
            else
            {
                this.Failure("MV90012");
            }
        }

        private void SAMVEW00020_Load(object sender, EventArgs e)
        {
            //Enatble Disable Controls
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.dgVSERVERLOG_DataBind();
            this.cboBranchCode_DataBind();
            this.InitializeControls();
        }

        private void dgVSERVERLOG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvBranchServer.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.ChangeControlStatusByUserType(true);

                TLMDTO00027 sERVERLOG = (TLMDTO00027)gvBranchServer.Rows[e.RowIndex].DataBoundItem;// get data from gridview
               
                this.BranchCode = sERVERLOG.BRANCHNO.Trim();
                this.SERVERNAME = sERVERLOG.SERVERNAME;
                this.IPADDRESS = sERVERLOG.IPADDRESS;
                this.DBNAME = sERVERLOG.DBNAME;
                //this.IBDIPADDRESS = sERVERLOG.IBDIPADDRESS;

                if (sERVERLOG.VERSION == "NEW")     //for rdoNewSystem 
                    this.NewSystem = true;
                if (sERVERLOG.VERSION == "OLD")     //for rdoOldSystem 
                    this.OldSystem = true;
                if (sERVERLOG.ISPNAME == "VSAT" || sERVERLOG.ISPNAME == "VAST")     //for rdoVsat
                    this.Vsat = true;
                if (sERVERLOG.ISPNAME == "IPSTAR")   //for rdoIPStar
                    this.IPStar = true;

                this.ViewData = sERVERLOG;
                this.Status = "Update";
            }
        }

        private void dgVSERVERLOGEntry_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Equals("Undefined"))
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
        }

        #endregion


    }
}

