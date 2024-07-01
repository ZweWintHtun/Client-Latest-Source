using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Mnm.Ctr.Dao;
using Spring.Transaction.Interceptor;
using Spring.Transaction;

namespace Ace.Cbs.Mnm.Sve
{
    public class MNMSVE00021:BaseService,IMNMSVE00021
    {
        #region Properties

        public ITLMDAO00017 RdDAO;
        public ITLMDAO00021 DrawingPrintingDAO;
        public IPFMDAO00054 TLFDAO;
        public IMNMDAO00021 CrossChangeDAO;
        public TLMDTO00017 ReDto { get; set; }

        #endregion

        #region Main Method

        public TLMDTO00017 GetDrawingData(string RegisterNo, string branchNo)
        {
            ReDto = RdDAO.SelectByRegisterNo(RegisterNo, branchNo);
            if (ReDto == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV00218"; //Register Not Found
                return null;
            }
            else
                return ReDto;

        }

        [Transaction(TransactionPropagation.Required)]
        public TLMDTO00017 Save_CrossChange(string registerNo1,string registerNo2,string regCur1, string regCur2, string rAmount1, string rAmount2,DateTime date1, DateTime date2, string workStation, string sourcebr, int currentUserId)  //edit by ASDA
        {
            try
            {
                if (string.IsNullOrEmpty(registerNo1))
                {
                    throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
                }
                if (string.IsNullOrEmpty(registerNo2))
                {
                    throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
                }
                if (string.IsNullOrEmpty(regCur1))
                {
                    throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
                }
                if (string.IsNullOrEmpty(regCur2))
                {
                    throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
                }
                if (string.IsNullOrEmpty(rAmount1))
                {
                    throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
                }
                if (string.IsNullOrEmpty(rAmount2))
                {
                    throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
                }
                if (string.IsNullOrEmpty(workStation))
                {
                    throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
                }
                if (string.IsNullOrEmpty(sourcebr))
                {
                    throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
                }

                if (currentUserId == null)
                {
                    throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
                }

                #region For DrawingPrinting

                //Delete DrawingPrinting By Workstation
                bool flag = DrawingPrintingDAO.DeleteByWorkStation(workStation,sourcebr);

                //Insert into Drawing Printing For Two Register No
                DrawingPrintingDAO.Save(this.GetDrawingPrinting(registerNo1, rAmount1, workStation,sourcebr, currentUserId));
                DrawingPrintingDAO.Save(this.GetDrawingPrinting(registerNo2, rAmount2, workStation, sourcebr,currentUserId));
               
                #endregion

                #region For RD

                string newRegNo2 = registerNo2 + 'C';
                //Update RD 
                 RdDAO.UpdateRDRegisterNoToAddC(registerNo2, newRegNo2, sourcebr,currentUserId);
                 RdDAO.UpdateRDByRegisterNoAndSourceBr(DateTime.Now, currentUserId, DateTime.Now, registerNo1, registerNo2, sourcebr);            
                 RdDAO.UpdateRDByRegisterNoAndSourceBr(DateTime.Now, currentUserId, DateTime.Now,newRegNo2, registerNo1, sourcebr);

                #endregion

                #region For TLF

                 //Update TLf =>  To Concat RegisterNo2 into RegisterNo+"C"
                TLFDAO.UpdateTlfRegisterNoToAddC(registerNo2,newRegNo2, sourcebr,currentUserId);

                //Update Tlf set DRegisterNo=registerNo2 where DRegisterNo=registerNo1
                TLFDAO.UpdateTlfByDRegisterNo(registerNo1, registerNo2, sourcebr,currentUserId);

                //Update Tlf set DRegisterNo=registerNo1 where DRegisterNo=registerNo2+'C'                
                TLFDAO.UpdateTlfByDRegisterNo(newRegNo2, registerNo1, sourcebr,currentUserId);

                 #endregion

               // ReDto = RdDAO.SelectByRegisterNo(registerNo2, sourcebr);                

                //edit by ASDA--------------------------------
                if (date1 < date2)
                {
                    ReDto = RdDAO.SelectByRegisterNo(registerNo1, sourcebr);
                    ReDto.AmountByLetter = rAmount2;
                }
                else
                {
                    ReDto = RdDAO.SelectByRegisterNo(registerNo2, sourcebr);
                    ReDto.AmountByLetter = rAmount1;
                }
                //end edit---------------------------------
                if (ReDto == null)           
                {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV00218"; //Register Not Found
                return null;
           
                }             
                                
            }
            catch(Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = ex.Message;
                throw new Exception(this.ServiceResult.MessageCode);
            }

            return ReDto;                    
          
        }

        #endregion

        #region Helper Method

        private TLMORM00021 GetDrawingPrinting(string RegisterNo, string AmountDesp, string workstation,string sourceBr,int createdUserID)
        {
            TLMORM00021 DrawingPrinting = new TLMORM00021();

            DrawingPrinting.Id = this.DrawingPrintingDAO.SelectMaxId() + 1;
            DrawingPrinting.RegisterNo = RegisterNo;
            DrawingPrinting.RAmount = AmountDesp;
            DrawingPrinting.WorkStation = workstation;
            DrawingPrinting.SourceBranchCode = sourceBr;
            DrawingPrinting.CreatedDate = DateTime.Now;
            DrawingPrinting.CreatedUserId = createdUserID;
           

            return DrawingPrinting;
        }

        #endregion
    }
}
