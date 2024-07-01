//----------------------------------------------------------------------
// <copyright file="TCMVEW00043.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-11-20</CreatedDate>
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
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;

namespace Ace.Cbs.Tcm.Vew
{
    /// <summary>
    /// Posting->Clearing Posting
    /// </summary>
    public partial class TCMVEW00043 : BaseDockingForm,ITCMVEW00043
    {
        #region "Constructor"
        public TCMVEW00043()
        {
            InitializeComponent();
        }
        #endregion

        #region "Controls Input Output"

        public IList<PFMDTO00054> TLFDTOList { get; set; }
        
        #endregion

        #region "Controller"
        private ITCMCTL00043 clearingpostingController;
        public ITCMCTL00043 ClearingPostingController
        {
            get
            {
                return this.clearingpostingController;
            }
            set
            {
                this.clearingpostingController = value;
                this.clearingpostingController.ClearingPostingView =this;
            }
        }

        #endregion

        #region "Methods"

        private void EnableDisableControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
        }

        /*---In Form_Load Event,to Bind GridView Data Lists from TLF Table---*/
        public void BindGridView()
        {
            this.gvClearingPosting.DataSource = null;
            this.gvClearingPosting.AutoGenerateColumns = false;
            this.TLFDTOList = clearingpostingController.GetTLFList();
            this.gvClearingPosting.DataSource = this.TLFDTOList;
        }

        public void ClearErrors()
        {
            throw new NotImplementedException();
        }

        /*---To show when to bind there is no chequeNo in Grid View---*/
        public void HideShowChequeNo()
        {
            this.lblNoCheque.Show();
            this.butPosting.Enabled = false;
            this.ntxtTotalCheques.Text = "0.00";
            this.ntxtReturnCheques.Text = "0.00";
        }

        /*---When printing Saving Passbook,need Menu Permission Id ---*/
        public int GetMenuIDPermission()
        {
            int menuIdPermission = this.MenuIdForPermission;
            return menuIdPermission;
        }

        #endregion

        #region "Events"

        private void TCMVEW00043_Load(object sender, EventArgs e)
        {
            this.EnableDisableControls();
            this.TLFDTOList = this.clearingpostingController.GetTLFList();
            if (this.TLFDTOList != null)
            {
                this.EnableDisableControls();
                if (this.TLFDTOList.Count.Equals(0))
                {
                    this.lblNoCheque.Show();
                    this.gvClearingPosting.Enabled = false;
                    this.butPosting.Enabled = false;
                }
                else
                {
                    this.lblNoCheque.Hide();
                }
                this.BindGridView();
                this.ntxtTotalCheques.Text = this.TLFDTOList.Count.ToString();
                this.ntxtReturnCheques.Text = "0";
            }
            else
            {
                this.HideShowChequeNo();
                return;
            } 
        }       

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvClearingPosting_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvClearingPosting.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colIsSelected"))
            {
                if (TLFDTOList[e.RowIndex].IsCheck == true)
                {
                    this.ntxtReturnCheques.Text = (this.ntxtReturnCheques.Value - 1).ToString();
                    TLFDTOList[e.RowIndex].IsCheck = false;
                }
                else
                {
                    this.ntxtReturnCheques.Text = (this.ntxtReturnCheques.Value + 1).ToString();
                    TLFDTOList[e.RowIndex].IsCheck = true;
                }
            }
        }
     
        /*---To Clear Posting to Controller ---*/
        private void butPosting_Click(object sender, EventArgs e)
        {
            this.clearingpostingController.ClearingPosting(TLFDTOList);            
        }       

        #endregion    
    }
}
