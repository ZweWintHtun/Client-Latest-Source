//----------------------------------------------------------------------
// <copyright file="CXDMD00010.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Su Su Wai</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;

namespace Ace.Cbs.Cx.Com.Dmd
{
    /// <summary>
    /// Current Form Entity
    /// </summary>
    [Serializable()]
    public class CXDMD00010
    {
        private int userId;
        /// <summary>
        /// UserId for ManagerApprove Form
        /// </summary>
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private string validPassword = string.Empty;
        /// <summary>
        /// RememberedPassword for ManagerApprove Form
        /// </summary>
        public string ValidPassword 
        {
            get { return validPassword; }
            set { validPassword = value; }
        }
        private string userName = string.Empty;
        /// <summary>
        /// UserName for ManagerApprove Form
        /// </summary>
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private int createdUserId;
        /// <summary>
        /// UserName for ManagerApprove Form
        /// </summary>
        public int CreatedUserId
        {
            get { return createdUserId; }
            set { createdUserId = value; }
        }
        private bool isRememberPassword = false;
        /// <summary>
        /// IsRememberPassword for ManagerApprove Form
        /// </summary>
        public bool IsRememberPassword
        {
            get { return isRememberPassword; }
            set { isRememberPassword = value; }
        }

        private bool isValidFormPermission = false;
        /// <summary>
        /// isValidFormPermission for ManagerApprove Form
        /// </summary>
        public bool IsValidFormPermission
        {
            get { return isValidFormPermission; }
            set { isValidFormPermission = value; }
        }
    }
}
