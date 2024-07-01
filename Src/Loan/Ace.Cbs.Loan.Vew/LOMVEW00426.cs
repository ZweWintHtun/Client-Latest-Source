using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.CXClient.Controls;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00426 : BaseDockingForm, ILOMVEW00426
    {
        private ILOMCTL00426 controller;
        public ILOMCTL00426 Controller
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
        public int indexOfCombo {get;set;}
        public LOMVEW00426()
        {
            InitializeComponent();
            indexOfCombo = 0;
        }
        private void butOk_Click(object sender, EventArgs e)
        {
            if (cboACType.SelectedIndex == 0) // BL
            {
                indexOfCombo = 0;
            }
            else if (cboACType.SelectedIndex == 1)//Dealer
            {
                indexOfCombo = 1;
            }
            else if (cboACType.SelectedIndex == 2)//HP
            {
                indexOfCombo = 2;
            }
            else if (cboACType.SelectedIndex == 3)//PL
            {
                indexOfCombo = 3;
            }
            Controller.CallingForm();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LOMVEW00426_Load(object sender, EventArgs e)
        {
            tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, false, true);
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.cboACType.SelectedIndex = 0;
        }
    }
}
