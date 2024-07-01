//----------------------------------------------------------------------
// <copyright file="TLMSVE00033.cs" company="ACE Data Systems">
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
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Windows.Core.Service;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Ace.Windows.CXServer.Utt;
using Spring.Transaction.Interceptor;
using NHibernate.Criterion;
using System.Linq;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Admin.Contracts.Dao;

namespace Ace.Cbs.Tel.Sve
{
   public class TLMSVE00033:BaseService,ITLMSVE00033
   {
       #region DAO
       ITLMDAO00025 ReconcileDAO { get; set; }
       ITLMDAO00026 ReconcileDWTDAO { get; set; }
       IBranchDAO BranchDAO { get; set; }
       ITLMDAO00017 RDDAO{get;set;}
       ITLMDAO00001 RemittanceEncashDAO { get; set; }
       TLMDTO00025 ReconcileDTO { get; set; }
       ITLMDAO00004 IBITLFDAO { get; set; }
       #endregion

       #region Properties
       public short ADcount = 0;
       public int ACount = 0;
       public int DuCount = 0;
       public string Status = string.Empty;
       public string reconsileRegister = string.Empty;
       
       IList<TLMDTO00017> RDEntityList { get; set; }
       IList<TLMDTO00001> REEntityList { get; set; }
       IList<TLMDTO00004> IBLTLFEntityListHome { get; set; }
       IList<TLMDTO00004> IBLTLFEntityListActive { get; set; }
      
       #endregion

       #region Methods
       public void Initialize()
       {
           this.ACount = 0;
           this.ADcount = 0;
           this.DuCount = 0;
       }

       //get reconsile data
       public IList<TLMDTO00025> GetReconcileDTOList(string sourcebranchcode)
        {
           return ReconcileDAO.SelectReconsileData(sourcebranchcode);

            //IList<TLMDTO00025> reconcileList = new List<TLMDTO00025>();

            //reconcileList = this.ReconcileDAO.SelectReconsileData(sourcebranchcode); 
           
            //return reconcileList;

          
        }

       //get branchcode(002)
       private IList<string> GetBrancodeListForRemittance(IList<BranchDTO> branches)
       {

           IList<BranchDTO> brcodeList = branches;

           var brcode = from value in brcodeList
                        where value.BranchCode != null
                        select value.BranchCode;

           IList<string> brcodestringList = brcode.ToList();

           return brcodestringList;
       }

       //get reconsile data by branchcode
       public IList<TLMDTO00025> SelectReconsileListForRemittance(IList<string> branches, string type, DateTime date_time)
       {
           IList<TLMDTO00025> ReconsileDTOList = new List<TLMDTO00025>();
           ReconsileDTOList = this.ReconcileDAO.GetReconsileListForRemittance(branches, type, date_time);
           return ReconsileDTOList;
       }

       [Transaction(TransactionPropagation.Required)]
       private void UpdateCurselReconcile(string branch, string type, DateTime date, string sourceBranch, int currentUserId)
       {
           ReconcileDAO.UpdateCurselReconcile(branch, type, date, sourceBranch, currentUserId);
       }

       //Delete Reconsile,Save Reconsile
       [Transaction(TransactionPropagation.Required)]
       private void Save_ReconsileForDrawingAndEncash(string branchCode, string rdreType, short aDCount, int aCount, int dupliCount,DateTime date,string sourceBranch,int createdUserId)
       {
           this.ReconcileDAO.DeleteDrawingBankReconcile(rdreType, branchCode, date,sourceBranch);
           TLMORM00025 Reconsile = new TLMORM00025();
           Reconsile.Id = this.ReconcileDAO.SelectID().Value;
           Reconsile.BranchCode = branchCode;
           Reconsile.Date_Time = date;
           Reconsile.Type = rdreType;
           Reconsile.DagRno = aDCount;
           Reconsile.AgRno = aCount;
           Reconsile.DupNo = dupliCount;
           Reconsile.Cursel = 1;
           Reconsile.SourceBranchCode = sourceBranch;
           Reconsile.Active = true;
           Reconsile.CreatedDate = DateTime.Now;
           Reconsile.CreatedUserId =createdUserId;
           //Reconsile.CreatedUserId = CurrentUserEntity.CurrentUserID;
           this.ReconcileDAO.Save(Reconsile);

       }

       //get RD data
       public IList<TLMDTO00017> GetDrawingDataForEachBranch(DateTime datetime, string transfertype, string branchcode, string sourcebrcode)
       {
           this.RDEntityList = this.RDDAO.SelectDrawingDataForIBLReconcile(datetime, transfertype, branchcode, sourcebrcode);
           return RDEntityList;
       }

       //get RE data
       public IList<TLMDTO00001> GetEncashDataForEachBranch(DateTime datetime, string transfertype, string branchcode, string sourcebr)
       {
           this.REEntityList = this.RemittanceEncashDAO.SelectEncashDataForIBLReconcileSide(datetime, transfertype, branchcode, sourcebr);
           return REEntityList;
       }

       [Transaction(TransactionPropagation.Required)]
       public IList<TLMDTO00025> SelectDatasForIBLReconcile(IList<BranchDTO> Branches, DateTime datetime, string transactionType, string transfertype, string sourcebr,int currentUserId)
       {
           //this.UpdateCurselReconcile();//cursel=0
           IList<TLMDTO00025> ReconsileDTOLists = new List<TLMDTO00025>();
           IList<TLMDTO00017> RDList = new List<TLMDTO00017>();
           IList<TLMDTO00001> REList = new List<TLMDTO00001>();
           IList<TLMDTO00004> TransactionList = new List<TLMDTO00004>();
           IList<TLMDTO00017> RDBranchesList = new List<TLMDTO00017>();
           IList<TLMDTO00001> REBranchesList = new List<TLMDTO00001>();
           IList<TLMDTO00004> TransactionBranchesList = new List<TLMDTO00004>();

           IList<string> branchcodestringlist = this.GetBrancodeListForRemittance(Branches);//get branchCode(002)

           if (transactionType == "RD" || transactionType == "RE")
           {
               for (int i = 0; i < Branches.Count; i++)
               {
                   this.UpdateCurselReconcile(Branches[i].BranchCode, transactionType, datetime, sourcebr, currentUserId);

                   if (transactionType == "RD")
                   {
                       this.RDEntityList = this.GetDrawingDataForEachBranch(datetime, transfertype, Branches[i].BranchCode, sourcebr);//get RD data
                       if (RDEntityList.Count > 0)
                       {
                           //To select RE Table
                           this.REEntityList = this.GetEncashDataForEachBranch(datetime, transfertype, sourcebr, Branches[i].BranchCode);//get RE data
                           if (REEntityList.Count > 0)
                           {
                               if (RDEntityList.Count == REEntityList.Count)
                               {
                                   RDList = this.CompareDrawingData(RDEntityList, REEntityList);//get PrintData
                               }
                               else 
                               {
                                   RDList = this.CompareDrawingDataRecord(RDEntityList, REEntityList);//get PrintData
                               }
                               
                               
                               foreach (TLMDTO00017 rddto in RDList)//for Branches
                               {
                                   RDBranchesList.Add(rddto);
                               }
                               this.Save_ReconsileForDrawingAndEncash(Branches[i].BranchCode, transactionType, ADcount, ACount, DuCount,datetime,sourcebr,Branches[i].CreatedUserId);//Save Reconsile Table for each branch
                               this.Initialize();
                           }
                           else
                           {
                               //All Transactions do not inserted into Host Branch
                               this.Save_ReconsileForDrawingAndEncash(Branches[i].BranchCode, transactionType, -1, ACount, DuCount, datetime, sourcebr, Branches[i].CreatedUserId);//Save Reconsile Table for each branch
                               RDList = this.RDEntityList;

                               foreach (TLMDTO00017 rddto in RDList)//for Branches
                               {
                                   rddto.status = "DAgree";
                                   RDBranchesList.Add(rddto);
                               }

                           }
                       }
                       else
                       {
                           /* Save Recon*/
                           /*1.Delete From Reconsile.*/
                           /* 2.Insert into Reconsile.*/
                           this.Save_ReconsileForDrawingAndEncash(Branches[i].BranchCode, transactionType, ADcount, ACount, DuCount,datetime,sourcebr,Branches[i].CreatedUserId);//Save Reconsile Table for each branch

                       }
                   }
                   else
                   {
                       this.REEntityList = this.GetEncashDataForEachBranch(datetime, transfertype, Branches[i].BranchCode, sourcebr);//get RE data
                       if (REEntityList.Count > 0)
                       {
                           this.RDEntityList = this.GetDrawingDataForEachBranch(datetime, transfertype, sourcebr, Branches[i].BranchCode);//get RD data
                           if (RDEntityList.Count > 0)
                           {
                               if (REEntityList.Count == RDEntityList.Count)
                               {
                                   REList = this.CompareEncashData(REEntityList, RDEntityList);//get PrintData
                               }
                               else 
                               {
                                   REList = this.CompareEncashDataRecord(REEntityList, RDEntityList);//get PrintData
                               }
                               
                               foreach (TLMDTO00001 redto in REList)//for Branches
                               {
                                   REBranchesList.Add(redto);
                               }
                               this.Save_ReconsileForDrawingAndEncash(Branches[i].BranchCode, transactionType, ADcount, ACount, DuCount,datetime,sourcebr,Branches[i].CreatedUserId);//Save Reconsile Table for each branch
                               this.Initialize();
                           }
                           else
                           {
                               //All Transactions do not inserted into Host Branch
                               this.Save_ReconsileForDrawingAndEncash(Branches[i].BranchCode, transactionType, -1, ACount, DuCount, datetime, sourcebr, Branches[i].CreatedUserId);//Save Reconsile Table for each branch
                               REList = this.REEntityList;
                               foreach (TLMDTO00001 redto in REList)//for Branches
                               {
                                   redto.status = "DAgree";
                                   REBranchesList.Add(redto);
                               }
                           }
                       }
                       else
                       {
                           this.Save_ReconsileForDrawingAndEncash(Branches[i].BranchCode, transactionType, ADcount, ACount, DuCount,datetime,sourcebr,Branches[i].CreatedUserId);//Save Reconsile Table for each branch
                       }
                   }


               }

               ReconsileDTOLists = this.SelectReconsileListForRemittance(branchcodestringlist, transactionType, datetime);
               if (transactionType == "RD")
               {
                   ReconsileDTOLists[0].RDInfo = RDBranchesList;//printdata
               }
               else
               {
                   ReconsileDTOLists[0].REInfo = REBranchesList;//printdata
               }

           }

           else
           {
               //For Transaction Radio Button 
               for (int i = 0; i < Branches.Count; i++)
               {
                   //this.ReconcileDAO.DeleteDrawingBankReconcile(transactionType, Branches[i].BranchCode, DateTime.Now);
                   this.UpdateCurselReconcile(Branches[i].BranchCode, transactionType, datetime, sourcebr, currentUserId);
                   //this.IBLTLFEntityListHome = this.IBITLFDAO.SelectDataForTransactionReconsile(CurrentUserEntity.BranchCode, Branches[i].BranchCode,false, CurrentUserEntity.BranchCode,datetime);//home transaction
                   this.IBLTLFEntityListHome = this.IBITLFDAO.SelectDataForTransactionReconsile(sourcebr, Branches[i].BranchCode, false, sourcebr, datetime);//home transaction
                   if (this.IBLTLFEntityListHome.Count <= 0)
                   {
                       this.Save_ReconsileForDrawingAndEncash(Branches[i].BranchCode, transactionType, ADcount, ACount, DuCount, datetime, sourcebr, Branches[i].CreatedUserId);//Save Reconsile Table for each branch
                   }
                   else
                   {
                       this.IBLTLFEntityListActive = this.IBITLFDAO.SelectDataForTransactionReconsile(sourcebr, Branches[i].BranchCode, true, Branches[i].BranchCode, datetime);//active transaction
                       //this.IBLTLFEntityListActive = this.IBITLFDAO.SelectDataForTransactionReconsile(CurrentUserEntity.BranchCode, Branches[i].BranchCode, true, Branches[i].BranchCode,datetime);//active transaction
                       if (this.IBLTLFEntityListActive.Count > 0)
                       {
                           if (this.IBLTLFEntityListHome.Count == this.IBLTLFEntityListActive.Count)
                           {
                               TransactionList = this.CompareTransactionData(IBLTLFEntityListHome, IBLTLFEntityListActive);
                           }
                           else
                           {
                               TransactionList = this.CompareTransactionDataRecord(IBLTLFEntityListHome, IBLTLFEntityListActive);
                           }
                           foreach (TLMDTO00004 ibltlfdto in TransactionList)//for Branches
                           {
                               TransactionBranchesList.Add(ibltlfdto);
                           }
                           this.Save_ReconsileForDrawingAndEncash(Branches[i].BranchCode, transactionType, ADcount, ACount, DuCount,datetime,sourcebr,Branches[i].CreatedUserId);//Save Reconsile Table for each branch
                           this.Initialize();
                       }
                       else
                       {
                           this.Save_ReconsileForDrawingAndEncash(Branches[i].BranchCode, transactionType, -1, ACount, DuCount, datetime, sourcebr, Branches[i].CreatedUserId);//Save Reconsile Table for each branch
                           TransactionList = this.IBLTLFEntityListHome;
                           foreach (TLMDTO00004 ibltlfdto in TransactionList)//for Branches
                           {
                               ibltlfdto.Status = "DAgree";
                               TransactionBranchesList.Add(ibltlfdto);
                           }
                       }
                   }


               }
               //ReconsileDTOLists = this.SelectReconsileListForTransactionReconsile(branchcodestringlist);
               ReconsileDTOLists = this.SelectReconsileListForRemittance(branchcodestringlist, transactionType, datetime);
               ReconsileDTOLists[0].IBLTLFInfo = TransactionBranchesList;//printdata
           }

           return ReconsileDTOLists;

       }

       //get RD print data
       public IList<TLMDTO00017> CompareDrawingData(IList<TLMDTO00017> RDLists, IList<TLMDTO00001> RELists)
       {
           IList<TLMDTO00017> printLists = new List<TLMDTO00017>();
           IList<string> compareRE = new List<string>();

           foreach (TLMDTO00017 data in RDLists)
           {
               Status = string.Empty;
               string drawingNo = data.RegisterNo.Substring(4);

               for (int i = 0; i < RELists.Count; i++)
               {
                   if (string.IsNullOrEmpty(Status))
                   {
                       string encashNo = RELists[i].RegisterNo.Substring(4);
                       if (drawingNo == encashNo && data.Name == RELists[i].Name && data.ToAccountNo == RELists[i].ToAccountNo && data.ToName == RELists[i].ToName && data.ToAddress == RELists[i].ToAddress)
                       {
                           ACount++;
                           Status = "Same";
                           data.status = "Agree";
                           compareRE.Add(encashNo);
                           printLists.Add(data);
                       }
                       else
                       {
                           if (compareRE.Contains(encashNo))
                           { Status = string.Empty; }
                           else
                           {
                               ADcount++;
                               Status = string.Empty;
                               data.status = "DAgree";
                               printLists.Add(data);
                           }
                       }
                   }
               }
           }
           return printLists;
       }

       //get RE print data
       public IList<TLMDTO00001> CompareEncashData(IList<TLMDTO00001> RELists, IList<TLMDTO00017> RDLists)
       {
           IList<TLMDTO00001> printLists = new List<TLMDTO00001>();
           IList<string> compareRD = new List<string>();

           foreach (TLMDTO00001 data in RELists)
           {
               Status = string.Empty;
               string encashNo = data.RegisterNo.Substring(4);

               for (int i = 0; i < RDLists.Count; i++)
               {
                   if (string.IsNullOrEmpty(Status))
                   {
                       string drawingNo = RDLists[i].RegisterNo.Substring(4);

                       if (encashNo == drawingNo && data.Name == RDLists[i].Name && data.ToAccountNo == RDLists[i].ToAccountNo && data.ToName == RDLists[i].ToName && data.ToAddress == RDLists[i].ToAddress)
                       {
                           ACount++;
                           Status = "Same";
                           data.status = "Agree";
                           compareRD.Add(drawingNo);
                           printLists.Add(data);
                       }
                       else
                       {
                           if (compareRD.Contains(drawingNo))
                           { Status = string.Empty; }
                           else
                           {
                               ADcount++;
                               Status = string.Empty;
                               data.status = "DAgree";
                               printLists.Add(data);
                           }
                       }

                   }
               }
           }
           return printLists;
       }

       //get Transaction print data
       public IList<TLMDTO00004> CompareTransactionData(IList<TLMDTO00004> IBLTLFEntityListHome, IList<TLMDTO00004> IBLTLFEntityListActive)
       {
           IList<TLMDTO00004> printLists = new List<TLMDTO00004>();
           IList<string> compareTrans = new List<string>();

           foreach (TLMDTO00004 data in IBLTLFEntityListHome)
           {
               Status = string.Empty;
               for (int i = 0; i < IBLTLFEntityListActive.Count; i++)
               {
                   if (string.IsNullOrEmpty(Status))
                   {
                       if (data.Eno == IBLTLFEntityListActive[i].Eno && data.Amount == IBLTLFEntityListActive[i].Amount && data.AccountNo == IBLTLFEntityListActive[i].AccountNo)
                       {
                           ACount++;
                           Status = "Same";
                           data.Status = "Agree";
                           compareTrans.Add(data.Eno);
                           printLists.Add(data);
                       }
                       else
                       {
                           if (compareTrans.Contains(IBLTLFEntityListActive[i].Eno))
                           { Status = string.Empty; }
                           else
                           {
                               ADcount++;
                               Status = string.Empty;
                               data.Status = "DAgree";
                               printLists.Add(data);
                           }
                       }
                   }
               }
           }
           return printLists;
       }

       public IList<TLMDTO00017> CompareDrawingDataRecord(IList<TLMDTO00017> RDLists, IList<TLMDTO00001> RELists)
       {
           IList<TLMDTO00017> printLists = new List<TLMDTO00017>();
           IList<string> duplicateRegisterNo=new List<string>();
           IList<string> compareData = new List<string>();
           string register = string.Empty;
           int dataCount=0;

           if(RDLists.Count>RELists.Count)
           {
               duplicateRegisterNo=this.DuplicateRDData(RDLists);
              
               foreach (TLMDTO00017 rd in RDLists)
               {
                   dataCount++;
                   string drawingNo=rd.RegisterNo.Substring(4);
                   string Status = string.Empty;
                   foreach(TLMDTO00001 re in RELists)
                   {
                       string encashNo = re.RegisterNo.Substring(4);

                       if (duplicateRegisterNo.Contains(drawingNo))
                       {
                           if (register != drawingNo)
                           {
                               register = drawingNo;
                               DuCount++;
                               rd.status = "Duplicate";
                               printLists.Add(rd);
                           }
                       }
                       else
                       {
                           if (string.IsNullOrEmpty(Status))
                           {
                               if (drawingNo == encashNo && rd.Name == re.Name && rd.ToAccountNo == re.ToAccountNo && rd.ToName == re.ToName && rd.ToAddress == re.ToAddress)
                               {
                                   ACount++;
                                   Status = "Same";
                                   rd.status = "Agree";
                                   compareData.Add(drawingNo);
                                   printLists.Add(rd);
                               }
                               else
                               {
                                   if (!compareData.Contains(drawingNo) && dataCount <= RELists.Count)
                                   { Status = string.Empty; }
                                   else
                                   {
                                       ADcount++;
                                       Status = string.Empty;
                                       rd.status = "DAgree";
                                       printLists.Add(rd);
                                   }
                               }
                           }
                       }
                   }
               }
           }
           else
           {
              duplicateRegisterNo=this.DuplicateREData(RELists);

              foreach (TLMDTO00017 rd in RDLists)
              {
                  dataCount++;
                  string drawingNo = rd.RegisterNo.Substring(4);
                  string Status = string.Empty;
                  foreach (TLMDTO00001 re in RELists)
                  {
                      string encashNo = re.RegisterNo.Substring(4);

                      if (duplicateRegisterNo.Contains(encashNo))
                      {
                          if (register != encashNo)
                          {
                              register = encashNo;
                              DuCount++;
                              rd.status = "Duplicate";
                              printLists.Add(rd);
                          }
                      }
                      else
                      {
                          if (string.IsNullOrEmpty(Status))
                          {
                              if (drawingNo == encashNo && rd.Name == re.Name && rd.ToAccountNo == re.ToAccountNo && rd.ToName == re.ToName && rd.ToAddress == re.ToAddress)
                              {
                                  ACount++;
                                  Status = "Same";
                                  rd.status = "Agree";
                                  compareData.Add(encashNo);
                                  printLists.Add(rd);
                              }
                              else
                              {
                                  if (compareData.Contains(encashNo) && RELists.Count<=dataCount)
                                  {
                                      Status = string.Empty;
                                  }
                                  else
                                  {
                                      ADcount++;
                                      Status = string.Empty;
                                      rd.status = "DAgree";
                                      printLists.Add(rd);
                                  }
                              }
                          }
                      }
                  }
              }
           }
           return printLists;
       }

       public IList<TLMDTO00001> CompareEncashDataRecord(IList<TLMDTO00001> RELists, IList<TLMDTO00017> RDLists)
       {
           IList<TLMDTO00001> printLists = new List<TLMDTO00001>();
           IList<string> duplicateRegisterNo = new List<string>();
           IList<string> compareData = new List<string>();
           string register = string.Empty;
           int dataCount = 0;

           if (RELists.Count > RDLists.Count)
           {
              
               duplicateRegisterNo = this.DuplicateREData(RELists);

               foreach (TLMDTO00001 re in RELists)
               {
                   dataCount++;
                   string encashNo = re.RegisterNo.Substring(4);
                   string Status = string.Empty;
                   foreach (TLMDTO00017 rd in RDLists)
                   {
                       string drawingNo = rd.RegisterNo.Substring(4);

                       if (duplicateRegisterNo.Contains(encashNo))
                       {
                           if (register != encashNo)
                           {
                               register = encashNo;
                               DuCount++;
                               re.status = "Duplicate";
                               printLists.Add(re);
                           }
                       }
                       else
                       {
                           if (string.IsNullOrEmpty(Status))
                           {
                               if (drawingNo == encashNo && rd.Name == re.Name && rd.ToAccountNo == re.ToAccountNo && rd.ToName == re.ToName && rd.ToAddress == re.ToAddress)
                               {
                                   ACount++;
                                   Status = "Same";
                                   re.status = "Agree";
                                   compareData.Add(encashNo);
                                   printLists.Add(re);
                               }
                               else
                               {
                                   if (!compareData.Contains(encashNo) && dataCount<=RDLists.Count)
                                   { Status = string.Empty; }
                                   else
                                   {
                                       ADcount++;
                                       Status = string.Empty;
                                       re.status = "DAgree";
                                       printLists.Add(re);
                                   }
                               }
                           }
                       }
                   }
               }
           }
           else
           {
               duplicateRegisterNo = this.DuplicateRDData(RDLists);

               foreach (TLMDTO00001 re in RELists)
               {
                   dataCount++;
                   string encashNo = re.RegisterNo.Substring(4);
                   string Status = string.Empty;
                   foreach (TLMDTO00017 rd in RDLists)
                   {
                       string drawingNo = rd.RegisterNo.Substring(4);

                       if (duplicateRegisterNo.Contains(drawingNo))
                       {
                           if (register != drawingNo)
                           {
                               register = drawingNo;
                               DuCount++;
                               re.status = "Duplicate";
                               printLists.Add(re);
                           }
                       }
                       else
                       {
                           if (string.IsNullOrEmpty(Status))
                           {
                               if (drawingNo == encashNo && rd.Name == re.Name && rd.ToAccountNo == re.ToAccountNo && rd.ToName == re.ToName && rd.ToAddress == re.ToAddress)
                               {
                                   ACount++;
                                   Status = "Same";
                                   re.status = "Agree";
                                   compareData.Add(drawingNo);
                                   printLists.Add(re);
                               }
                               else
                               {
                                   if (compareData.Contains(drawingNo) && RDLists.Count<=dataCount)
                                   {
                                       Status = string.Empty;
                                   }
                                   else
                                   {
                                       ADcount++;
                                       Status = string.Empty;
                                       re.status = "DAgree";
                                       printLists.Add(re);
                                   }
                               }
                           }
                       }
                   }
               }
           }
           return printLists;
       }

       public IList<TLMDTO00004> CompareTransactionDataRecord(IList<TLMDTO00004> IBLTLFEntityListHome, IList<TLMDTO00004> IBLTLFEntityListActive)//recheck
       {
           IList<TLMDTO00004> printLists = new List<TLMDTO00004>();
           IList<string> duplicateENo = new List<string>();
           IList<string> compareData = new List<string>();
           string eNo = string.Empty;
           int dataCount = 0;

           if (IBLTLFEntityListHome.Count > IBLTLFEntityListActive.Count)
           {
               duplicateENo = this.DuplicateTransactionData(IBLTLFEntityListHome);
           }
           else
           {
               duplicateENo = this.DuplicateTransactionData(IBLTLFEntityListActive);
           }

           foreach (TLMDTO00004 home in IBLTLFEntityListHome)
           {
               dataCount++;
               string Status = string.Empty;
               foreach (TLMDTO00004 active in IBLTLFEntityListActive)
               {
                   if (duplicateENo.Contains(home.Eno))
                   {
                       if (eNo != home.Eno)
                       {
                           eNo = home.Eno;
                           DuCount++;
                           home.Status = "Duplicate";
                           printLists.Add(home);
                       }
                   }
                   else
                   {
                       if (string.IsNullOrEmpty(Status))
                       {
                           if (home.Eno == active.Eno && home.Amount == active.Amount && home.AccountNo == active.AccountNo)
                           {
                               ACount++;
                               Status = "Same";
                               home.Status = "Agree";
                               compareData.Add(home.Eno);
                               printLists.Add(home);
                           }
                           else
                           {
                               if ((compareData.Contains(active.Eno) && dataCount <= IBLTLFEntityListActive.Count) || (compareData.Contains(active.Eno) && IBLTLFEntityListActive.Count <= dataCount))
                               { Status = string.Empty; }
                               else
                               {
                                   ADcount++;
                                   Status = string.Empty;
                                   home.Status = "DAgree";
                                   printLists.Add(home);
                               }
                           }
                       }
                   }
               }
           }
           return printLists;
       }

       public IList<string> DuplicateRDData(IList<TLMDTO00017> RDLists)
       {
           string registerNo = string.Empty;
           int count = 0;
           int recordCount=0;
           IList<string> duplicatedata = new List<String>();
           foreach (TLMDTO00017 rd in RDLists)
           {   
               recordCount++;
               if (registerNo == rd.RegisterNo)
               { 
                   count++;
                   if (RDLists.Count == recordCount)
                   {
                       string rddata = registerNo.Substring(4);
                       duplicatedata.Add(rddata);
                   }
               }
               else
               {
                   registerNo = rd.RegisterNo;
                   if (count > 0)
                   {
                       string rddata = registerNo.Substring(4);
                       duplicatedata.Add(rddata);

                   }
               }
           }
           return duplicatedata;
        }

       public IList<string> DuplicateREData(IList<TLMDTO00001> RELists)
       {
           string registerNo = string.Empty;
           int count = 0;
           int recordCount = 0;
           IList<string> duplicatedata = new List<String>();
           foreach (TLMDTO00001 re in RELists)
           {
               recordCount++;
               if (registerNo == re.RegisterNo)
               { 
                   count++;
                   if (RELists.Count == recordCount)
                   {
                       string redata = registerNo.Substring(4);
                       duplicatedata.Add(redata);
                   }
               }
               else
               {
                   registerNo = re.RegisterNo;
                   if (count > 0)
                   {
                       string redata = registerNo.Substring(4);
                       duplicatedata.Add(redata);

                   }
               }
           }
           return duplicatedata;
       }

       public IList<string> DuplicateTransactionData(IList<TLMDTO00004> TransactionLists)
       {
           string eNo = string.Empty;
           string tranType=string.Empty;
           int count = 0;
           int recordCount = 0;
           IList<string> duplicatedata = new List<String>();
           foreach (TLMDTO00004 dto in TransactionLists)
           {
               recordCount++;
               if (eNo == dto.Eno && tranType==dto.TranType)
               {
                   count++;
                   if (TransactionLists.Count == recordCount)
                   {
                       duplicatedata.Add(dto.Eno);
                   }
               }
               else
               {
                   eNo = dto.Eno;
                   tranType=dto.TranType;
                   if (count > 0)
                   {
                       duplicatedata.Add(dto.Eno);

                   }
               }
           }
           return duplicatedata;
       }

       #endregion   

       #region No Need
       //public IList<BranchDTO> SelectAllOthersBranchByReconsileBranchcodelist(string sourcebranchcode,IList<string> reconsilebranhcodelist)
        //{
        //    return BranchDAO.SelectAllOthersBranchByReconsileBranchcodelist(sourcebranchcode, reconsilebranhcodelist);
        //}

       //[Transaction(TransactionPropagation.Required)]
       //private void Save_TransactionReconsile(string branchCode,short dArgno,int agRNo,int dupliNo)
       //{
       //    this.ReconcileDWTDAO.DeleteTransactionReconcile(branchCode, DateTime.Now);
       //    TLMORM00026 ReconsileDWT = new TLMORM00026();
       //    ReconsileDWT.Id = this.ReconcileDWTDAO.SelectID().Value;
       //    ReconsileDWT.BranchCode = branchCode;
       //    ReconsileDWT.Date_Time = DateTime.Now;
       //    ReconsileDWT.Type = "DWT";
       //    ReconsileDWT.DagRno = dArgno;
       //    ReconsileDWT.AgRno = agRNo;
       //    ReconsileDWT.DupNo = dupliNo;
       //    ReconsileDWT.Cursel = 1;        
       //    ReconsileDWT.Active = true;
       //    ReconsileDWT.CreatedDate = DateTime.Now;
       //    ReconsileDWT.CreatedUserId = CurrentUserEntity.CurrentUserID;
       //    this.ReconcileDWTDAO.Save(ReconsileDWT);
       //}

     

      

       //public IList<TLMDTO00017> GetDrawingDataForEachBranchSide(DateTime datetime, string transfertype, string branchcode,string sourcebr)
       //{
       //    this.RDEntityList = this.RDDAO.SelectDrawingDataForIBLReconcile(datetime, transfertype,branchcode,sourcebr);
       //    return RDEntityList;
       //}

      

       //public IList<TLMDTO00001> GetEncashDataForEachBranchSide(DateTime datetime, string transfertype, string branchcode, string sourcebranchcode)
       //{
       //    this.REEntityList = this.RemittanceEncashDAO.SelectEncashDataForIBLReconcileSide(datetime, transfertype, branchcode, sourcebranchcode);
       //    return REEntityList;
       //}

       //public void DeleteDrawingDataForEachBranch(string type,string branchcode,DateTime datetime)
       //{
       //    this.ReconcileDAO.DeleteDrawingBankReconcile(type, branchcode, datetime);
       //}

       //public void InsertDrawingEncashDataForEachBranch()
       //{
       //    TLMORM00025 ReconsileORM = this.SaveReconcileDTO(this.ReconcileDTO);
       //    this.ReconcileDAO.Save(ReconsileORM);

       //}

       //public TLMDTO00025 GetReconcileDTOByBranchCodeandType(string branchcode,string type,short adcount,int acount,int ducount,DateTime datetime)
       //{
       //    TLMDTO00025 Reconsile = new TLMDTO00025();
       //     Reconsile.BranchCode = branchcode;
       //     Reconsile.Type = type;
       //     Reconsile.DagRno = adcount;
       //     Reconsile.AgRno = acount;
       //     Reconsile.DupNo = ducount;
       //     Reconsile.Active = true;
       //     Reconsile.CreatedDate = DateTime.Now;
       //     Reconsile.CreatedUserId = CurrentUserEntity.CurrentUserID;
       //     Reconsile.Date_Time = datetime;
       //     ReconcileDTO = Reconsile;
       //   return ReconcileDTO;
       //}

       //public TLMORM00025 SaveReconcileDTO(TLMDTO00025 ReconsileDTO)
       //{
       //    TLMORM00025 ReconsileORM = new TLMORM00025();          
       //    ReconsileORM.BranchCode = this.ReconcileDTO.BranchCode;
       //    ReconsileORM.Type = this.ReconcileDTO.Type;
       //    ReconsileORM.Date_Time = this.ReconcileDTO.Date_Time;
       //    ReconsileORM.DagRno = this.ReconcileDTO.DagRno;
       //    ReconsileORM.AgRno = this.ReconcileDTO.AgRno;
       //    ReconsileORM.DupNo = this.ReconcileDTO.DupNo;
       //    ReconsileORM.Cursel = 1;         
       //    ReconsileORM.CreatedDate = DateTime.Now;
       //    ReconsileORM.CreatedUserId = CurrentUserEntity.CurrentUserID;           
       //    return ReconsileORM;
       //}

       /*Select Datas From Reconsile For Drawing and Encash,To bind Datas IBL Remittance  */
      

       /*Select Datas From ReconsileDWT For Transaction,To bind Datas IBL Remittance */
       //private IList<TLMDTO00025> SelectReconsileListForTransactionReconsile(IList<string> branches)
       // {
       //     IList<TLMDTO00025> ReconsileList = new List<TLMDTO00025>();
       //     IList<TLMDTO00026> ReconsileDWTList = new List<TLMDTO00026>();
       //     ReconsileDWTList = this.ReconcileDWTDAO.SelectReconsileDWTData(branches);

       //     for (int i = 0; i < ReconsileDWTList.Count; i++)
       //     {
       //         TLMDTO00025 ReconsileDTO = new TLMDTO00025();
       //         ReconsileDTO.BranchCode = ReconsileDWTList[i].BranchCode;
       //         ReconsileDTO.DagRno = ReconsileDWTList[i].DagRno;
       //         ReconsileDTO.AgRno = ReconsileDWTList[i].AgRno;
       //         ReconsileDTO.DupNo = ReconsileDWTList[i].DupNo;
       //         ReconsileList.Add(ReconsileDTO);
       //     }
       //     return ReconsileList;

       // }
       #endregion



   }
}

