//----------------------------------------------------------------------
// <copyright file="TCMVEW00022.cs" company="Ace Data Systems">
// Copyright (c) Ace Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>AK</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Com.Utt;
using System.Windows.Forms;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00022 : BaseDockingForm, ITCMVEW00022
    {
        #region Constractor

        public TCMVEW00022()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        private ITCMCTL00022 controller;
        public ITCMCTL00022 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }

        private IList<UserDTO> userList;
        public IList<UserDTO> UserList
        {
            get
            {
                if (this.userList == null)
                    this.userList = new List<UserDTO>();

                return this.userList;
            }
            set
            {
                this.userList = value;
            }
        }

        public string LocalBranchCode { get; set; }

        #endregion

        #region Events

        private void TCMVEW00022_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
            //Enatble Disable Controls
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, true , true, false, true);
            this.BindGridView();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.Controller.ClearErrors();
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvDeactivaeUser.EndEdit();
            IList<UserDTO> deleteList = this.UserList.Where<UserDTO>(x => x.IsCheck == true).ToList();
            if (deleteList.Count > 0)
            {
                if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes)
                {
                    this.Controller.Delete(deleteList);
                }
            }
            else
            {
                this.Failure("MV90012");
            }
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Methods

        private void InitializeControls()
        {
            this.LocalBranchCode = CurrentUserEntity.BranchCode;
            this.BindGridView();
        }

        private void BindGridView()
        {
            gvDeactivaeUser.AutoGenerateColumns = false;
            this.UserList = this.controller.SelectByBranchCode();
            this.gvDeactivaeUser.DataSource = this.UserList;
        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.BindGridView();
            this.InitializeControls();
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        #endregion

    }
}
