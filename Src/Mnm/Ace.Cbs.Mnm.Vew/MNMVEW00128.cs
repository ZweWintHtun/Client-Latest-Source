﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00128 : Form
    {
        public MNMVEW00128()
        {
            InitializeComponent();
        }

        private void MNMVEW00128_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}