using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
//using Ace.Cbs.Cx.Ser.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer;
using Ace.Windows.Core.Utt;
using Ace.Windows.Core.DataModel;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Windows.CXServer.Utt;

namespace Ace.Cbs.Mnm.Sve
{
    public class MNMSVE00004 : BaseService, IMNMSVE00004
    {
        #region Properties

        private IPFMDAO00056 sys001DAO;
        public ICXSVE00002 CodeGenerator { get; set; }
        public IPFMDAO00032 FReceiptDAO { get; set; }
        public string code=string.Empty;

        public IPFMDAO00056 Sys001DAO
        {
            get { return this.sys001DAO; }
            set { this.sys001DAO = value; }
        }

        #endregion

        #region Method

        public PFMDTO00056 SelectSysDate(string name, string sourcebr)
        {
            DateTime SysDate = this.Sys001DAO.SelectSysDate(name, sourcebr);

            PFMDTO00056 sys001dto=new PFMDTO00056();

            sys001dto.SysDate = SysDate;

            return sys001dto;
        }

      
        [Transaction(TransactionPropagation.Required)]
        public void FixedDepositAutoRenewalUpdating(DateTime SDate, DateTime EDate, int Start, int UserNo, string SourceBr, int RetValue, string RetMsg)
        {
            try
            {
                string vouno = string.Empty;
                int updatedUserId = UserNo;

                vouno = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, updatedUserId, SourceBr, new object[] { DateTime.Now.Day.ToString().PadLeft(2, '0'), DateTime.Now.Month.ToString().PadLeft(2, '0'), DateTime.Now.Year.ToString().Substring(2) });
                string startDate = SDate.ToString("yyyy/MM/dd");
                string endDate = EDate.ToString("yyyy/MM/dd");

                IFormatProvider theCultureInfo = new System.Globalization.CultureInfo("en-GB", true);
                DateTime Sdate = DateTime.ParseExact(startDate, "yyyy/MM/dd", theCultureInfo);
                DateTime Edate = DateTime.ParseExact(endDate, "yyyy/MM/dd", theCultureInfo);


                string code = this.FReceiptDAO.FixedDepositAutoRenewalUpdating(Sdate, Edate, Start, UserNo, SourceBr, vouno, 0, string.Empty);
                if (code == "MI30034")
                {
                    try
                    {
                        //PFMORM00015 accountType = this.UpdateServer(entity, dvcvList);
                        if (!this.ServiceResult.ErrorOccurred)
                        {
                            Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> {
                            { "SysDate",Edate },
                            { "UpdatedUserId", UserNo },
                            { "UpdatedDate", DateTime.Now } 
                            };
                            Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "Active", true } };
                            CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00056", updateColumnsandValues, whereColumnsandValues));
                            this.ServiceResult.ErrorOccurred = false;
                            this.ServiceResult.MessageCode = "MI90002";//Update Success
                        }

                    }
                    catch (Exception)
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = "ME90036";
                    }
                }
                switch (code.Trim())
                {
                    case "ME30009" :
                         this.ServiceResult.ErrorOccurred = true;
                         this.ServiceResult.MessageCode ="ME30009"; //Error in Coa File
                    break;

                    case "ME30010":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME30010"; //Error in Setup File
                    break;

                    case "MI30032":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MI30032"; //No need to run for back date Fixed Deposit.
                    break;

                    case "MI30033":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MI30033"; //No Fixed Deposit A/C to renew.
                    break;

                    case "MI30034":
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = "MI30034"; //Automated Renewal Successfully.
                    break;                       
                }

                if(this.ServiceResult.ErrorOccurred)
                    throw new Exception(this.ServiceResult.MessageCode);
                
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = ex.Message;
                throw new Exception(this.ServiceResult.MessageCode);
            } 
           
        }
        #endregion
    }
}
    