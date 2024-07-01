//----------------------------------------------------------------------
// <copyright file="CXSVE00008.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Yu Thandar Aung </CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Ser.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.Core.Utt;
using AutoMapper;
using Spring.Transaction.Interceptor;
using Spring.Transaction;

namespace Ace.Cbs.Cx.Ser.Sve
{
    /// <summary>
    /// Check Remittance RegisterNo
    /// </summary>
    public class CXSVE00008 : BaseService, ICXSVE00008
    {
        private ICXDAO00008 registerDAO { get; set; }
        public ICXDAO00008 RegisterDAO
        {
            set { this.registerDAO = value; }
            get { return this.registerDAO; }
        }

        private static CXSVE00008 instance = null;
        public static CXSVE00008 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = SpringApplicationContext.Instance.Resolve<CXSVE00008>("CXSVE00008");
                }
                return instance;
            }
        }        
        

        public CXDTO00003 CheckRemittanceRegisterNo(string registerNo, CXDMD00006 drawingEncashTransaction)
        {
            try
            {
                CXDTO00003 returnString = new CXDTO00003();
                
                if (!string.IsNullOrEmpty(registerNo))
                {
                    if (drawingEncashTransaction.Equals(CXDMD00006.Drawing))
                    {
                        TLMDTO00017 rdData = this.registerDAO.GetRDByRegisterNo(registerNo);
                        returnString.RemittanceRegisterNoCheck = (rdData != null) ? true : false;
                    }
                    else if (drawingEncashTransaction.Equals(CXDMD00006.Encash))
                    {
                        TLMDTO00001 reData = registerDAO.GetREByRegisterNo(registerNo);

                        if (reData == null)
                        {
                            returnString.RemittanceRegisterNoCheck = false;                           
                        }
                        else
                        {
                            if (reData.IssueDate != null)
                            {
                                this.ServiceResult.ErrorOccurred = true;
                                this.ServiceResult.MessageCode = CXMessage.MV00028;
                                returnString.RemittanceRegisterNoCheck = false;
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(reData.ToAccountNo))
                                {
                                    returnString.ReceiverName = reData.ToName;
                                    returnString.Amount = Convert.ToDecimal(reData.Amount);
                                    returnString.Currency = reData.Currency;
                                }

                                returnString.RemittanceRegisterNoCheck = true;
                            }
                        }
                    }
                    return returnString;
                }
                else
                {
                    throw new Exception(CXMessage.ME90018);//invalid parameter
                }
            }
            catch (Exception exp)
            {
                throw new Exception(CXMessage.MV00031, exp);
            }
            
        }



    }
}
