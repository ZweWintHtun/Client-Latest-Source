using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.CXClient;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00146 : BaseDockingForm 
    {
        public MNMVEW00146()
        {
            InitializeComponent();
        }

        public MNMVEW00146(string groupNo, string entryNo)
        {
            InitializeComponent();
            this.lblNumber1.Text = groupNo;
            this.lblNumber2.Text = entryNo;
        }


        private void butYes_Click(object sender, EventArgs e)
        {
            CXUIScreenTransit.SetData("MNMVEW00146", "1");
            this.Close();
        }

        private void butNo_Click(object sender, EventArgs e)
        {
            CXUIScreenTransit.SetData("MNMVEW00146", "0");
            this.Close();
        }
    }
}
