//----------------------------------------------------------------------
// <copyright file="TCMVEW00062" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate>18.6.2013</CreatedDate>
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
using Microsoft.Reporting.WinForms;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Cle;
using System.IO;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00062 : BaseForm, ITCMVEW00062
    {
        public TCMVEW00062()
        {
            InitializeComponent();
        }

        public TCMVEW00062(string name)
        {
            InitializeComponent();
            this.Name = name;

        }

        public string Name { get; set; }

        #region Controller
        private ITCMCTL00062 controller;
        public ITCMCTL00062 Controller
        {
            get { return this.controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }

        #endregion

        private void TCMVEW00062_Load(object sender, EventArgs e)
        {
            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            IList<PFMDTO00028> list = this.controller.GetReconsile();
            rpvReconsile.LocalReport.DataSources.Clear();
            ReportParameter[] para = new ReportParameter[8];
            para[0] = new ReportParameter("BankName", Branch.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[6] = new ReportParameter("BrCode", Branch.BranchCode);
            para[7] = new ReportParameter("Br_Alias", Branch.Bank_Alias);

            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);

                img.Save(tempFilePath);
            }

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[5] = new ReportParameter("TotalRecords", list.Count.ToString());
            this.rpvReconsile.LocalReport.EnableExternalImages = true;
            rpvReconsile.LocalReport.SetParameters(para);
            ReportDataSource dataset = new ReportDataSource("Reconsile_DataSet", list);
            rpvReconsile.LocalReport.DataSources.Add(dataset);

            dataset.Value = list;            
            this.rpvReconsile.RefreshReport();
        }
    }
}
