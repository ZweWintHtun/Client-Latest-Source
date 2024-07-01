//----------------------------------------------------------------------
// <copyright file="TLMVEW00063" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>HM</CreatedUser>
// <CreatedDate>30.12.2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;
using System.Linq;
using Microsoft.Reporting.WinForms;
using System.IO;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00100 : BaseForm, IMNMVEW00100
    {
        #region Constructor

        public MNMVEW00100()
        {
            InitializeComponent();
        }

        #endregion

        #region Controller
        private IMNMCTL00100 controller;
        public IMNMCTL00100 Controller
        {
            get { return this.controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }

        #endregion

        #region Properties

        public string FormName { get; set; }
        public IList<MNMDTO00034> list { get; set; }

        #endregion

        #region Events

        private void MNMVEW00100_Load(object sender, EventArgs e)
        {
            list = this.Controller.GetInterestList();

            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

            rpvSavingBalance.LocalReport.DataSources.Clear();
            ReportParameter[] para = new ReportParameter[9];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[7] = new ReportParameter("BrCode", Branch.BranchCode);
            para[8] = new ReportParameter("Br_Alias", Branch.Bank_Alias);


            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);

                img.Save(tempFilePath);
            }

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[5] = new ReportParameter("Head", FormName + "Listing");
            para[6] = new ReportParameter("Count", list.Count.ToString());

            this.rpvSavingBalance.LocalReport.EnableExternalImages = true;
            rpvSavingBalance.LocalReport.SetParameters(para);
            ReportDataSource dataset = new ReportDataSource("MNMDS00020", list);
            rpvSavingBalance.LocalReport.DataSources.Add(dataset);

            for (int i = 0; i < list.Count; i++)
            {
                if (DateTime.Now.Month >= 1 && DateTime.Now.Month <= 3)
                {
                    list[i].I = list[i].I4;
                    list[i].Total = list[i].Cbal + list[i].I;
                }
                else if (DateTime.Now.Month >= 4 && DateTime.Now.Month <= 6)
                {
                    list[i].I = list[i].I1;
                    list[i].Total = list[i].Cbal + list[i].I;
                }
                else if (DateTime.Now.Month >= 7 && DateTime.Now.Month <= 9)
                {
                    list[i].I = list[i].I2;
                    list[i].Total = list[i].Cbal + list[i].I;
                }
                else if (DateTime.Now.Month >= 10 && DateTime.Now.Month <= 12)
                {
                    list[i].I = list[i].I3;
                    list[i].Total = list[i].Cbal + list[i].I;
                }
            }  
            
            dataset.Value = list;

            this.rpvSavingBalance.RefreshReport();
        }

        #endregion

       
    }
}




