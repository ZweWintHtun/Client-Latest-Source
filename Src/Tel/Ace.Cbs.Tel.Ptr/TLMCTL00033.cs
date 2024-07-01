//----------------------------------------------------------------------
// <copyright file="TLMCTL00033.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-07-17</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using System.Linq;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tel.Ptr
{
   public class TLMCTL00033:AbstractPresenter,ITLMCTL00033
   {
       #region Properties
       //string SourceBranchCode = CXCOM00007.Instance.BranchCode;
       string SourceBranchCode = CurrentUserEntity.BranchCode;
       IList<TLMDTO00025> ReconcileList { get; set; }
       string type { get; set; }
       #endregion

       #region View
       private ITLMVEW00033 iblReconsileview;
        public ITLMVEW00033 IBLReconsileView
        {
            get { return this.iblReconsileview; }
            set { this.WireTo(value); }
        }
       #endregion

       #region Methods
        private void WireTo(ITLMVEW00033 view)
        {
            if (this.iblReconsileview == null)
            {
                this.iblReconsileview = view;
               this.Initialize(this.iblReconsileview, IBLReconsileView);
            }
        }

        private string GetType()
        {
            if (this.IBLReconsileView.TransactionType == "Drawing")
            {
                return "RD";
            }

            else if (this.iblReconsileview.TransactionType == "Encash")
            {
                return "RE";
            }

            else
            {
                return "DWT";
            }

        }

        public IList<BranchDTO> GetReconsileDTOList()
        {
            IList<BranchDTO> branchdtolist = new List<BranchDTO>();
            BranchDTO oneBranch = new BranchDTO();
            type = this.GetType();
            string BranchCode = string.Empty;
            IList<string> branchArray = new List<string>();
            
            //bind TLMVEW00033 gridView
            ReconcileList = CXClientWrapper.Instance.Invoke<ITLMSVE00033, TLMDTO00025>(x => x.GetReconcileDTOList(SourceBranchCode));

            foreach (TLMDTO00025 data in ReconcileList)
            {
                if (data.Type == type)
                {
                    branchArray.Add(data.Branch.BranchCode);
                    oneBranch = this.ReconsileStatus(data);
                    branchdtolist.Add(oneBranch);
                }
            }

            foreach (TLMDTO00025 dto in ReconcileList)
            {
                if (!branchArray.Contains(dto.Branch.BranchCode) && dto.Branch.BranchCode != BranchCode)
                {
                    BranchCode = dto.Branch.BranchCode;
                    oneBranch = this.ReconsileStatus(dto);
                    branchdtolist.Add(oneBranch);                    
                }
            }

            IList<BranchDTO> PrintDataList = new List<BranchDTO>();
            if (branchdtolist.Count > 0)
            {
                int j = 0;

                PrintDataList.Add(branchdtolist[0]);
                if (branchdtolist.Count > 1)
                {
                    do
                    {
                        string accountNo = branchdtolist[j].BranchCode;
                        j++;
                        if (accountNo != branchdtolist[j].BranchCode)
                            PrintDataList.Add(branchdtolist[j]);


                    } while (j != branchdtolist.Count - 1);
                }
            }


            return PrintDataList;
        }

        public BranchDTO ReconsileStatus(TLMDTO00025 record)
        {
            BranchDTO BranchDTO = new BranchDTO();
            string transactionType = record.Type;
            DateTime Date = Convert.ToDateTime(record.Date_Time).Date;

            if (record.AgRno > 0 && record.DupNo == 0 && record.DagRno == 0 && Date == this.iblReconsileview.Date.Date && transactionType == type && record.SourceBranchCode==SourceBranchCode)
            {
                BranchDTO.Status = "Reconciled";
            }

            else if (record.DupNo > 0 || record.DagRno != 0 && Date == this.iblReconsileview.Date.Date && transactionType == type && record.SourceBranchCode==SourceBranchCode)
            {
                BranchDTO.Status = "Not Agree";
            }

            else
            {
                BranchDTO.Status = "Not Reconciled";
            }

            BranchDTO.BranchCode = record.Branch.BranchCode;
            BranchDTO.BranchDescription = record.Branch.BranchDescription;
            return BranchDTO;
          }

        public void Reconcile(IList<BranchDTO> branches, DateTime date, string transactiontype)
        {
            if (!CXCOM00006.Instance.IsExceedTodayDate(this.IBLReconsileView.Date))
            {
                int currentUserId = CurrentUserEntity.CurrentUserID;
                string transferType = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.InterBranchLinking);
                transactiontype = this.GetType();

                //bind TLMVEW00034 gridView,print data
                ReconcileList = CXClientWrapper.Instance.Invoke<ITLMSVE00033, TLMDTO00025>(x => x.SelectDatasForIBLReconcile(branches, this.iblReconsileview.Date, transactiontype, transferType, SourceBranchCode,currentUserId));

                if (ReconcileList.Count > 0)
                {
                    for (int i = 0; i < ReconcileList.Count; i++)
                    {
                        if (ReconcileList[i].AgRno == 0 && ReconcileList[i].DupNo == 0 && ReconcileList[i].DagRno == 0)
                        {
                            ReconcileList[i].Status = "Not Reconciled";
                            ReconcileList[i].BranchCode = ReconcileList[i].BranchCode;
                        }

                        else if (ReconcileList[i].DupNo == 0 && ReconcileList[i].DagRno == 0)
                        {
                            ReconcileList[i].Status = "Agree";
                            ReconcileList[i].BranchCode = ReconcileList[i].BranchCode;
                        }

                        else if (ReconcileList[i].DupNo > 0 || ReconcileList[i].DagRno > 0)
                        {
                            ReconcileList[i].Status = "Do Not Agree";
                            ReconcileList[i].BranchCode = ReconcileList[i].BranchCode;
                        }
                    }
                    if (transactiontype == "RD")
                    {

                        IList<TLMDTO00017> rd = new List<TLMDTO00017>();
                        rd = ReconcileList[0].RDInfo;
                        CXUIScreenTransit.Transit("frmTLMVEW00034", true, new object[] { ReconcileList, rd, transactiontype, this.IBLReconsileView.Date, "Remittance" ,"Drawing Remittance Reconcilation"});
                       
                    }
                    else if (transactiontype == "RE")
                    {
                        IList<TLMDTO00001> re = new List<TLMDTO00001>();
                        re = ReconcileList[0].REInfo;
                        CXUIScreenTransit.Transit("frmTLMVEW00034", true, new object[] { ReconcileList, re, transactiontype, this.IBLReconsileView.Date, "Remittance", "Encash Remittance Reconcilation" });
                        //this.IBLReconsileView.BindGridView();
                    }
                    else
                    {
                        IList<TLMDTO00004> ibltlf = new List<TLMDTO00004>();
                        ibltlf = ReconcileList[0].IBLTLFInfo;
                        CXUIScreenTransit.Transit("frmTLMVEW00034", true, new object[] { ReconcileList, ibltlf, transactiontype, this.IBLReconsileView.Date, "Transaction", "Online Transaction Reconcilation" });
                        //this.IBLReconsileView.BindGridView();
                    }
                    this.IBLReconsileView.BindGridView();
                }
            }
            else
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00160, this.IBLReconsileView.Date);//Require Date is not greater than today.
                return;
            }
        }
        #endregion
    }
}
