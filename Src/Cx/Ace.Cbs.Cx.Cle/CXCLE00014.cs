//----------------------------------------------------------------------
// <copyright file="CXCLE00014.cs" company="ACE Data Systems">
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
   [Serializable]
   public class CXCLE00014
   {
       #region Constructor
       public CXCLE00014()
       {}
       #endregion

        #region Private Variables
        private static CXCLE00014 instance = null;  
        #endregion

        #region Properties
        /// <summary>
        /// CXClientData Singleton Object
        /// </summary>
        public static CXCLE00014 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = SpringApplicationContext.Instance.Resolve<CXCLE00014>("CXCLE00014");
                }

                return instance;
            }
        }
        #endregion

        #region Public Method
     
        #endregion
   }
}
