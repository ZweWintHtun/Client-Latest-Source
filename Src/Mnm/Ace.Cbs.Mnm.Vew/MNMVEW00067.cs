﻿//----------------------------------------------------------------------
// <copyright file="MNMVEW00067.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>10/23/2013</CreatedDate>
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
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;


namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00067 : BaseForm
    {
        public MNMVEW00067()
        {
            InitializeComponent();
        }

        private void MNMVEW00067_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
