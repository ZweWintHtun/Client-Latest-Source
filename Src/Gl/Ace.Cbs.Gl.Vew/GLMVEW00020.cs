using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Gl.Ctr.Ptr;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Gl.Vew
{
    public partial class GLMVEW00020 : BaseForm, IGLMVEW00020
    {
        IList<ChargeOfAccountDTO> FromCOAList = new List<ChargeOfAccountDTO>();
        IList<ChargeOfAccountDTO> ToCOAList = new List<ChargeOfAccountDTO>();
        //bool isCheck;

        #region Properties
        public string FromAccountNo
        {
            get
            {
                if (this.cbofromAccount.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cbofromAccount.SelectedValue.ToString();
                }
            }

            set
            {
                this.cbofromAccount.SelectedValue = value;
            }
        }

        public string ToAccountNo
        {
            get
            {
                if (this.cbotoAccount.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cbotoAccount.SelectedValue.ToString();
                }
            }

            set
            {
                this.cbotoAccount.SelectedValue = value;
            }
        }

        private string parentFormId = string.Empty;
        public string ParentFormId
        {
            get { return this.parentFormId; }
            set { this.parentFormId = value; }
        }

        #endregion

        #region Controller
        private IGLMCTL00020 controller;
        public IGLMCTL00020 Controller
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
        #endregion

        #region Constructor
        public GLMVEW00020()
        {
            InitializeComponent();
        }

        public GLMVEW00020(string parentFormId)
        {
            InitializeComponent();

            this.ParentFormId = parentFormId;
        }
        #endregion

        #region Method
        public void BindAccountNoFrom()
        {
            this.TestCOA();
            this.cbofromAccount.DisplayMember = "AccountName";
            this.cbofromAccount.ValueMember = "AccountName";
            this.cbofromAccount.ColumnNames = "AccountName, DCODE, COASetUpAccountName";
            this.cbofromAccount.DataSource = FromCOAList;
            this.cbofromAccount.SelectedIndex = -1;
        }

        public void BindAccountNoTo()
        {
            this.TestCOA();
            this.cbotoAccount.DisplayMember = "AccountName";
            this.cbotoAccount.ValueMember = "AccountName";
            this.cbotoAccount.ColumnNames = "AccountName, DCODE, COASetUpAccountName";
            this.cbotoAccount.DataSource = ToCOAList;
            this.cbotoAccount.SelectedIndex = -1;
        }

        public void TestCOA()
        {
            IList<ChargeOfAccountDTO> DTOList = CXCLE00001.Instance.COA_RangeofAccount();

            foreach (ChargeOfAccountDTO dto in DTOList)
            {
                if (dto.AccountName.Length == 6)
                {
                    if (dto.AccountName.Substring(4, 2) != "00")
                    {
                        ChargeOfAccountDTO cboDTO = new ChargeOfAccountDTO();
                        cboDTO.ACode = dto.AccountName;
                        cboDTO.AccountName = dto.COASetUpAccountName;
                        cboDTO.DCODE = dto.DCODE;

                        FromCOAList.Add(dto);
                        ToCOAList.Add(dto);
                    }
                }
            }
        }

        public void InitializeControl()
        {
            //this.isCheck = false;
            this.BindAccountNoFrom();
            this.BindAccountNoTo();            
            this.cbofromAccount.Focus();
            this.txtFromDCode.Text = "";
            this.txtToDCode.Text = "";
            this.controller.ClearErrors();
        }
        #endregion
        
        private void GLMVEW00020_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false,true, false, true, false, true);
            this.Text = this.FormName;
            this.InitializeControl();
        }

        private void GLMVEW00020_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);               
            }
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControl();            
        }

        private void cbofromAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (isCheck == true)
            //{
                int index = this.cbofromAccount.SelectedIndex;
                if (index != -1)
                {
                    for (int i = 0; i <= this.FromCOAList.Count; i++)
                    {
                        if (i == index)
                        {
                            this.txtFromDCode.Text = this.FromCOAList[i].DCODE;
                        }
                        if (i >= index) break;
                    }
                }
            //}
        }

        private void cbotoAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (isCheck == true)
            //{
                int index = this.cbotoAccount.SelectedIndex;
                if (index != -1)
                {
                    for (int i = 0; i <= this.ToCOAList.Count; i++)
                    {
                        if (i == index)
                        {
                            this.txtToDCode.Text = this.ToCOAList[i].DCODE;
                        }
                        if (i >= index) break;
                    }
                }
            //}  
        }

        //private void GLMVEW00020_MouseHover(object sender, EventArgs e) //// condition to be true
        //{
        //    this.isCheck = true;
        //}

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (this.controller.send())
            {
                if (this.cbofromAccount.Text != "" && this.cbotoAccount.Text != "")
                {
                    IList<ChargeOfAccountDTO> DTOList = CXCLE00001.Instance.COA_RangeofAccountbyACode(this.cbofromAccount.Text, this.cbotoAccount.Text);                                                          
                    CXUIScreenTransit.SetData(this.ParentFormId, DTOList);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode("ME90009"); //Account No must not be blank.
                }
            } 
        }        
    }
}
