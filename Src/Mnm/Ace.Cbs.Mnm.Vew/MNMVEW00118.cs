using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Microsoft.Reporting.WinForms;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;
using System.IO;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00118 : BaseForm
    {
        IList<PFMDTO00029> LinkACInfoList{get;set;}
        public string Type { get; set; }
        public decimal curbal { get; set; }
        public decimal minbal { get; set; }
     
        public MNMVEW00118()
        {
            InitializeComponent();
        }


        public MNMVEW00118(IList<PFMDTO00029> LinkList,string type)
        {
            this.LinkACInfoList = LinkList;
            this.Type = type;
            InitializeComponent();
        }


        private void MNMVEW00118_Load(object sender, EventArgs e)
        {
            this.Text = "Link Account ( Current <-> Saving ) " + this.Type + " Account Listing";
           
            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            
            rptLinkAC.LocalReport.DataSources.Clear();
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
            para[5] = new ReportParameter("Head", this.Text);
            para[6] = new ReportParameter("TotalRecords",this.LinkACInfoList.Count.ToString() );
          
            this.rptLinkAC.LocalReport.EnableExternalImages = true;
            rptLinkAC.LocalReport.SetParameters(para);

            IList<PFMDTO00029> transactionlist = new List<PFMDTO00029>();
            foreach (PFMDTO00029 linkdto in LinkACInfoList)
            {
                PFMDTO00029 linkAC = new PFMDTO00029();
                curbal = linkdto.MinimumCurrentAccountBalance;
                minbal = linkdto.MinimumLinkAccountBalance;
                linkAC.MinimumSavingAccountBalance = curbal - minbal;
                linkAC.CurrentAccountNo = linkdto.CurrentAccountNo;
                linkAC.SavingAccountNo = linkdto.SavingAccountNo;
                linkAC.MinimumCurrentAccountBalance = curbal;
                linkAC.MinimumLinkAccountBalance = minbal;
                transactionlist.Add(linkAC);
 
            }

            ReportDataSource dataset = new ReportDataSource("LinkACinfoDS", transactionlist);
            rptLinkAC.LocalReport.DataSources.Add(dataset);
            dataset.Value = transactionlist;

            this.rptLinkAC.RefreshReport();
            this.rptLinkAC.RefreshReport();
        }

        
    }
}
