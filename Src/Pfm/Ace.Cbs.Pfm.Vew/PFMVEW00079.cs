using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Cle;
using Microsoft.Reporting.WinForms;
using Ace.Windows.Core.Utt;
using System.IO;
using Ace.Cbs.Cx.Com.Utt;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using Ace.Cbs.Pfm.Ctr.Sve;

namespace Ace.Cbs.Pfm.Vew
{
    public partial class PFMVEW00079 : BaseDockingForm
    {
        #region Properties
        public IList<string[]> PrintLists { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string SourceBr { get; set; }

        private int m_currentPageIndex;
        private IList<Stream> m_streams;

        #endregion

        #region Constructor
        public PFMVEW00079()
        {
            InitializeComponent();
        }

        public PFMVEW00079(IList<string[]> printLists,string sourceBr)
        {
            this.PrintLists = printLists;
            this.SourceBr = sourceBr;
            InitializeComponent();
        }
        #endregion

        #region"Public Methods"

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);            
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        #endregion

        #region Events

        private void PFMVEW00079_Load(object sender, EventArgs e)
        {
            IList<PFMDTO00014> lists = new List<PFMDTO00014>();

            if (PrintLists != null && this.PrintLists.Count > 0)
            {
                for (int i = 0; i < PrintLists.Count; i++)
                {
                    PFMDTO00014 printcheque = new PFMDTO00014();

                    string[] printline = PrintLists[i];
                    printcheque.AccountNo = printline[0];
                    printcheque.ChequeBookNo = printline[1];
                    printcheque.SourceBranchCode = CurrentUserEntity.BranchCode;  // updated by haymar
                    printcheque.ChequeNo = printline[3];
                    printcheque.UserNo = CurrentUserEntity.CurrentUserID.ToString();
                    printcheque.DATE_TIME = DateTime.Now;
                    printcheque.CreatedUserId = CurrentUserEntity.CurrentUserID;
                    if (this.SourceBr.Length > 3)
                        printcheque.BranchCode = this.SourceBr.Substring(0, 3) + "-" + this.SourceBr.Substring(3, 3); //001-002
                    else
                        printcheque.BranchCode = this.SourceBr.Substring(0, 3) + "-" + this.SourceBr.Substring(0, 3); //001-002
                    lists.Add(printcheque);
                }

                //Preview with report viewer and print
                this.rpvChequePrinting.LocalReport.DataSources.Clear();
                ReportDataSource dataset = new ReportDataSource("DSPFMRDLC00014", lists);
                this.rpvChequePrinting.LocalReport.DataSources.Add(dataset);
                dataset.Value = lists;
                rpvChequePrinting.LocalReport.Refresh();
                this.rpvChequePrinting.RefreshReport();

                CXClientWrapper.Instance.Invoke<IPFMSVE00015>(x => x.Save(lists));

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    this.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
                else
                {
                    this.Successful(CXMessage.MI00012); // Printing successful.
                }
            }
            
        }

        #endregion
    }
}
