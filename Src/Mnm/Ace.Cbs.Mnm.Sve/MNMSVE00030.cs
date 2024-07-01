using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Ctr.Sve;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Cx.Com.Ctr;


namespace Ace.Cbs.Mnm.Sve
{
    public class MNMSVE00030:BaseService,IMNMSVE00030
    {
        #region DAO
        public IPFMDAO00032 FReceiptDAO { get; set; }
        public IPFMDAO00001 CustIdDAO { get; set; }
        public IPFMDAO00007 FixRateDAO { get; set; }
        public ICXDAO00009 ViewDAO { get; set; }
        public ICXDAO00006 CodeCheckerDAO { get; set; }
        public IList<PFMDTO00032> BindDatas = new List<PFMDTO00032>();
        public string duration { get; set; }
        public PFMDTO00001 township = new PFMDTO00001();
        public string description { get; set; }
        #endregion

        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00032> GetFReceiptData(PFMDTO00042 DataDTO)
        {
            IList<PFMDTO00032> freceipts = new List<PFMDTO00032>();
            freceipts = this.FReceiptDAO.GetFReceipts(DataDTO.StartDate,DataDTO.SourceBranch);
            if (freceipts.Count > 0)
            {
                foreach (PFMDTO00032 data in freceipts)
                {
                    IList<MNMDTO00039> custInfo = new List<MNMDTO00039>();
                    custInfo = this.ViewDAO.GetFAOFCustomerInfo(data.AccountNo);
                    string custId = custInfo[0].CustID;
                    if (!string.IsNullOrEmpty(custId))
                    {
                        township = this.CustIdDAO.GetTownshipCode(custInfo[0].CustID);
                        description = township.TownshipDesp;
                    }
                    else
                    {
                        description = string.Empty;
                    }
                    PFMDTO00007 DurationData = this.FixRateDAO.SelectFixRateDescription(data.Duration);
                    string duration = DurationData.Description;

                    IList<PFMDTO00021> FAOFInfo = new List<PFMDTO00021>();
                    FAOFInfo = this.CodeCheckerDAO.GetFAOFsByAccountNumber(data.AccountNo);
                    DateTime OpenDate = (DateTime)FAOFInfo[0].OpenDate;
                    data.SourceBranchCode = DataDTO.SourceBranch;

                    PFMDTO00032 record = this.CollectData(data, custInfo, duration, description,OpenDate);
                    BindDatas.Add(record);
                }
            }
            else
            {
                BindDatas = new List<PFMDTO00032>();
            }
            return BindDatas;
        }

        public PFMDTO00032 CollectData(PFMDTO00032 data, IList<MNMDTO00039> custInfo, string duration, string description,DateTime openDate)
        {
            PFMDTO00032 receiptData = new PFMDTO00032();
            receiptData.AccountNo = data.AccountNo;
            receiptData.ReceiptNo = data.ReceiptNo;
            receiptData.Amount = data.Amount;
            receiptData.RDate = data.RDate;
            receiptData.DurationTime = duration;
            receiptData.InterestRate = data.InterestRate;
            receiptData.Name = custInfo[0].Name;
            receiptData.Nrc = custInfo[0].Nrc;
            receiptData.Address = description;
            receiptData.CurrencyCode = data.CurrencyCode;
            receiptData.MatureDate = openDate;
            receiptData.SourceBranchCode = data.SourceBranchCode;
            return receiptData;
        }
    }
}
