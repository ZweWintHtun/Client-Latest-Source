//----------------------------------------------------------------------
// <copyright file="CXCLE00008.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Yu Thandar Aung</CreatedUser>
// <CreatedDate>2013-05-22</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Cx.Cle
{
    /// <summary>
    /// Check Amount
    /// </summary>
   [Serializable]
   public class CXCLE00008
    {
        #region Private Variables
        private static CXCLE00008 instance = null;       
        #endregion

        #region Constructor
        public CXCLE00008()
        { }
        #endregion

        #region Properties
        /// <summary>
        /// CXClientData Singleton Object
        /// </summary>
        public static CXCLE00008 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = SpringApplicationContext.Instance.Resolve<CXCLE00008>("CXCLE00008");
                }

                return instance;
            }
        }

   
        #endregion

        #region Methods
       /// <summary>
        /// ChkAmount
       /// </summary>
       /// <param name="amount"></param>
       /// <returns></returns>
        public bool CheckAmount(decimal amount)
        {
            try
            {
                decimal minimumAmount = Convert.ToDecimal(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.MinimumBalance));
                if (amount > minimumAmount)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception exp)
            {
                throw new Exception(CXMessage.ME90018, exp);
            }
        }
           #endregion      
   }
}
