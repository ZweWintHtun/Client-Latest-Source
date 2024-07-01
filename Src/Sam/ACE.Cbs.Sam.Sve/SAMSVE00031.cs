//----------------------------------------------------------------------
// <copyright file="SAMSVE00031.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo</CreatedUser>
// <CreatedDate>2015-02-20</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Sam.Ctr.SVE;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Sam.Dmd;

namespace Ace.Cbs.Sam.Sve
{
    public class SAMSVE00031 : BaseService, ISAMSVE00031
    {
        #region Properties
        private ICXDAO00009 viewDAO;
        public ICXDAO00009 ViewsDAO
        {
            get { return this.viewDAO; }
            set { this.viewDAO = value; }
        }
        #endregion

        #region Methods
        public IList<SAMDTO00056> SelectRateFileListByRateActive(string activeRate)
        {
            try
            {
                IList<SAMDTO00056> RateFileList = this.ViewsDAO.SelectRateFileListByStatusActive(activeRate);
                return RateFileList;
            }
            catch (Exception ex)
            {                
                throw new Exception (ex.InnerException +ex.Message);
            }
        }
        public IList<SAMDTO00056> SelectRateFileList(string rateType,string status,string selectedRate)
        {
            try
            {
                IList<SAMDTO00056> RateFileList = this.ViewsDAO.SelectRateFileList();
                if (rateType == "AllRate")
                {
                    if (status == "AllStatus")
                    {
                        return RateFileList;
                    }
                    else if (status == "ActiveStatus")
                    {
                        var ratefilelist = (from value in RateFileList
                                            where value.STATUS == "ACTIVE"
                                            select value).ToList();
                        RateFileList = ratefilelist;
                    }
                    else
                    {
                        var ratefilelist = (from value in RateFileList
                                            where value.STATUS == "NOT ACTIVE"
                                            select value).ToList();
                        RateFileList = ratefilelist;
                    }
                }
                else
                {
                    if (status == "AllStatus")
                    {
                        var ratefilelist = (from value in RateFileList
                                            where value.CODE == selectedRate
                                            select value).ToList();
                        RateFileList = ratefilelist;
                    }
                    else if (status == "ActiveStatus")
                    {
                        var ratefilelist = (from value in RateFileList
                                            where value.CODE == selectedRate & value.STATUS == "ACTIVE"
                                            select value).ToList();
                        RateFileList = ratefilelist;
                    }
                    else
                    {
                        var ratefilelist = (from value in RateFileList
                                            where value.CODE == selectedRate & value.STATUS == "Not ACTIVE"
                                            select value).ToList();
                        RateFileList = ratefilelist;
                    }
                }
                return RateFileList;
            }
            catch (Exception ex)
            {
                
                throw new Exception (ex.InnerException+ex.Message);
            }
        }
        #endregion
    }
}
