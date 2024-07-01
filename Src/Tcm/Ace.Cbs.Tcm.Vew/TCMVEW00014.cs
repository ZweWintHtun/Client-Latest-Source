//----------------------------------------------------------------------
// <copyright file="TCMCTL00014.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
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
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00014 : BaseForm,ITCMVEW00014
    {
        #region Constructor
        public TCMVEW00014()
        {
            InitializeComponent();
        }

        public TCMVEW00014(bool isshowMenu)
        {
            InitializeComponent();
            this.IsShow = isshowMenu;

        }
        #endregion

        #region Controller
        private ITCMCTL00014 controller;
        public ITCMCTL00014 Controller
        {
            get
            {
                { return this.controller; }
            }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        #endregion


        int i = 0, j = 0;

        public bool IsShow { get; set; }

        #region Controls Input Output

        public string BankHead
        {
            get { return this.lblBankHead.Text; }
            set { this.lblBankHead.Text = value; }
        }

        public string SystemDate
        {
            get { return this.lblDate.Text; }
            set { this.lblDate.Text = value; }
        }

        public string Status
        {
            get { return this.lblStatus.Text; }
            set { this.lblStatus.Text = value; }
        }

        public void Successful(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);          
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }     

        #endregion

        public bool isMainMenuEnabled = true;

        private void TCMVEW00014_Load(object sender, EventArgs e)
        {
            //tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
            this.controller.BindInitialData();
            if (this.Status == "Need to Startup!")
            {
                label1.Location = label2.Location = label3.Location = new Point(30, 157);
                label1.Font = label2.Font = label3.Font = new System.Drawing.Font("Microsoft Sans Serif",
                        9,
                        System.Drawing.FontStyle.Bold,
                        System.Drawing.GraphicsUnit.Point,
                        ((byte)(0)));
                //
                //giving different color to the middile label(label2)
                //
                this.label2.ForeColor = System.Drawing.Color.Blue;     
                Timer t = new Timer();
                t.Interval = 400;
                t.Tick += new EventHandler(timer1_Tick);
                t.Start();
                this.Size = new System.Drawing.Size(494, 226);
            }
            else if (this.Status.Contains("Need to complete the previous day ''EOD Process'' firstly"))
            {                

                this.gbSystemInformation.Size = new System.Drawing.Size(465, 143);
                this.Size = new System.Drawing.Size(579, 219);
                this.butStartUp.Location= new Point(487, 125);
                
            }

            else //Need to Shut Down for dd/MMMM/yyyy
            {
                this.label1.Visible = this.label2.Visible = this.label3.Visible = false;
                //this.Size = new System.Drawing.Size(514, 206);
            }

            if (this.Status == "Already Startup the System!")
            {
                this.FormClose();
            }
        }      

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.timer1.Stop();
            this.Close();
        }

        private void butStartUp_Click(object sender, EventArgs e)
        {
            if (this.controller.StartUp())
            {
                this.timer1.Stop();
                this.Close();
            }
        }      

        public void FormClose()
        {
            this.Close();
        }

        public void DisableSystemInfo()
        {
            this.gbSystemInformation.Visible = false;
        }     
       
        private void timer1_Tick(object sender, EventArgs e)
        {   
            //string s =  "Need to Run Back Date Fixed Deposit Auto Renewal.";//Updated by HWKO (14-Aug-2017)
            string s = "Need to Startup.";
            string[] l = s.Split(' ');
           
           
            //adding the characters one by one to the label2
            if (i < l.Length-1)
                label2.Text += l[i].ToString() + ' ';

            //starting the third label after 3 charaters of label2 adding
            if (i >=3 && i <= 20)
            {
                if (i <=l.Length+2)
                    label3.Text += l[j].ToString() + ' ';
                j++;
            }
            if (j <=l.Length)
                i++;
            else
            {
                i = j = 0;
                label3.Text = label2.Text = "";
            }


           
        }
    }
}
