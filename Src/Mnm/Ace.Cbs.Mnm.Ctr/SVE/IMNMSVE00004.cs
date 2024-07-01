using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using System.Drawing;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Service;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00004 : IBaseService
    {
        IPFMDAO00056 Sys001DAO { get; set; }

        PFMDTO00056 SelectSysDate(string name, string sourcebr);

        void FixedDepositAutoRenewalUpdating(DateTime SDate, DateTime EDate, int Start, int UserNo, string SourceBr,int RetValue, string RetMsg);
    }
}
