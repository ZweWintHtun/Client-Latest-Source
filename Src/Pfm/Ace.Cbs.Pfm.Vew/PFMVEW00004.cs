//----------------------------------------------------------------------
// <copyright file="PFMVEW00004.cs" company="Ace Data Systems">
// Copyright (c) Ace Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Sam.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.DataModel;
using Ace.Windows.Admin.DataModel;
using System.Linq;

namespace Ace.Cbs.Pfm.Vew
{
    /// <summary>
    /// CustomerId Entry/Edit
    /// </summary>    
    public partial class frmPFMVEW00004 : BaseDockingForm, IPFMVEW00004
    {
        #region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
        public frmPFMVEW00004()
        {
            InitializeComponent();
        }

        public frmPFMVEW00004(bool isMainMenu, string parentFormId)
        {
            InitializeComponent();
            this.IsMainMenu = isMainMenu;
            this.ParentFormId = parentFormId;
        }

        public frmPFMVEW00004(bool isMainMenu, string parentFormId, bool isValidateLessThan18, bool isValidateGreaterThan18)
        {
            InitializeComponent();
            this.IsMainMenu = isMainMenu;
            this.ParentFormId = parentFormId;
            this.IsValidateGreaterThan18 = isValidateGreaterThan18;
            this.IsValidateLessThan18 = isValidateLessThan18;            
            CurrentUserEntity.IsIgnoreDataValidating = false;
           
        }
        #endregion

        #region Transit

        public PFMDTO00001 TransitEntity { get; set; }
        #endregion

        #region View Data Properties
        private DateTime maxDate;
        private FormState formState;
        public FormState FormState
        {
            get { return this.formState; }
            set { this.formState = value; }
        }

        private bool isMainMenu = true;
        public bool IsMainMenu
        {
            get { return this.isMainMenu; }
            set { this.isMainMenu = value; }
        }

        private string parentFormId = string.Empty;
        public string ParentFormId
        {
            get { return this.parentFormId; }
            set { this.parentFormId = value; }
        }

        public bool IsValidateLessThan18 { get; set; }
        public bool IsValidateGreaterThan18 { get; set; }

        /// <summary>
        /// CustomerId 
        /// </summary>     
        public string CustomerId
        {
            get { return this.mtxtCustomerId.Text; }
            set { this.mtxtCustomerId.Text = value; }
        }

        /// <summary>
        /// NRC 
        /// </summary>     
        public string NRC
        {
            get { return txtNRC.Text; }
            set { this.txtNRC.Text = value; }
        }

        /// <summary>
        /// GuardianName 
        /// </summary>     
        public string GuardianName
        {
            get { return txtGuardianshipName.Text; }
            set { this.txtGuardianshipName.Text = value; }
        }

        /// <summary>
        /// GuardianNRCNo 
        /// </summary>     
        public string GuardianNRCNo
        {
            get { return txtFatherGuardianNRC.Text; }
            set { this.txtFatherGuardianNRC.Text = value; }
        }

        /// <summary>
        /// FatherName 
        /// </summary>     
        public string FatherName
        {
            get { return txtFatherName.Text; }
            set { this.txtFatherName.Text = value; }
        }

        /// <summary>
        /// Address 
        /// </summary>     
        public string Address
        {
            get { return txtAddress.Text; }
            set { this.txtAddress.Text = value; }
        }

        /// <summary>
        /// PhoneNo 
        /// </summary>     
        public string PhoneNo
        {
            get { return txtPhone.Text; }
            set { this.txtPhone.Text = value; }
        }

        /// <summary>
        /// FaxNo 
        /// </summary>     
        public string FaxNo
        {
            get { return txtFax.Text; }
            set { this.txtFax.Text = value; }
        }

        /// <summary>
        /// Email 
        /// </summary>     
        public string Email
        {
            get { return txtEmail.Text; }
            set { this.txtEmail.Text = value; }
        }

        /// <summary>
        /// Photo
        /// </summary>
        public Image Photo
        {
            get { return this.picPhoto.Image; }
            set { this.picPhoto.Image = value; }
        }

        /// <summary>
        /// Signature 
        /// </summary>     
        public Image Signature
        {
            get { return this.picSignature.Image; }
            set { this.picSignature.Image = value; }
        }

        /// <summary>
        /// IsVIP 
        /// </summary>     
        public bool IsVIP
        {
            get { return chkVIPCustomer.Checked; }
            set { chkVIPCustomer.Checked = value; }
        }

        /// <summary>
        /// Gender 
        /// </summary>     
        public string Gender
        {
            get
            {
                if (this.cboGender.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return cboGender.SelectedValue.ToString();
                }
            }
            set
            {
                this.cboGender.SelectedValue = value;
            }
        }

        /// <summary>
        /// Remark 
        /// </summary>     
        public string Remark
        {

            get { return txtRemark.Text; }
            set { this.txtRemark.Text = value; }
        }

        /// <summary>
        /// NameOnly 
        /// </summary>     
        public string NameOnly
        {
            get { return txtName.Text; }
            set
            {
                this.txtName.Text = value;

            }
        }

        /// <summary>
        /// PassportNo 
        /// </summary>     
        public string PassportNo
        {
            get { return txtPassportNo.Text; }
            set { this.txtPassportNo.Text = value; }
        }

        /// <summary>
        /// DateOfBirth 
        /// </summary>     
        public DateTime DateOfBirth
        {
            get { return this.dtpDOB.Value; }
            set { this.dtpDOB.Value = value; }
        }

        /// <summary>
        /// NickName 
        /// </summary>     
        public string NickName
        {
            get { return txtNickName.Text; }
            set { this.txtNickName.Text = value; }
        }

        /// <summary>
        /// CityCode 
        /// </summary>     
        public string CityCode
        {
            get
            {
                if (this.cboCity.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return cboCity.SelectedValue.ToString();
                }
            }
            set
            {
                cboCity.SelectedValue = value;
            }

        }

        public string CityDesp { get; set; }

        /// <summary>
        /// StateCode 
        /// </summary>     
        public string StateCode
        {
            get
            {
                if (this.cboState.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return cboState.SelectedValue.ToString();
                }
            }

            set
            {
                cboState.SelectedValue = value;
            }

        }

        /// <summary>
        /// TownshipCode 
        /// </summary>     
        public string TownshipCode
        {
            get
            {
                if (cboTownship.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return cboTownship.SelectedValue.ToString();
                }
            }
            set
            {
                cboTownship.SelectedValue = value;
            }

        }

        /// <summary>
        /// Initial 
        /// </summary>     
        public string Initial
        {
            get
            {
                if (cboInitial.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return cboInitial.SelectedValue.ToString();
                }
            }
            set
            {
                cboInitial.SelectedValue = value;
            }
        }

        /// <summary>
        /// OccupationCode 
        /// </summary>     
        public string OccupationCode
        {
            get
            {
                if (cboOccupation.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return cboOccupation.SelectedValue.ToString();
                }
            }

            set
            {
                cboOccupation.SelectedValue = value;
            }
        }

        /// <summary>
        /// Nationality 
        /// </summary>             
        public string Nationality
        {
            get
            {
                if (cboNationality.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return cboNationality.SelectedValue.ToString();
                }
            }

            set
            {
                cboNationality.SelectedValue = value;
            }
        }

        //public string Nationality
        //{
        //    get { return this.cboNationality.Text; }
        //    set { this.cboNationality.Text = value; }
        //}
        /// <summary>
        /// For NRC Formmat(Represnt by Ma Tin Shwe
        /// </summary>
        public string StateCodeForNRC
        {
            get
            {
                if (this.cboStateCode.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return cboStateCode.SelectedValue.ToString();
                }
            }
            set
            {
                cboStateCode.SelectedValue = value;
            }
        }

        public string TownshipCodeForNRC
        {
            get
            {
                if (this.cboTownshipCode.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return cboTownshipCode.SelectedValue.ToString();
                }
            }
            set
            {
                cboTownshipCode.SelectedValue = value;
            }
        }

        public string NationalityCodeForNRC
        {
            get
            {
                if (this.cboNationalityCode.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return cboNationalityCode.SelectedValue.ToString();
                }
            }
            set
            {
                cboNationalityCode.SelectedValue = value;
            }
        }

        public string NRCNo
        {
            get { return txtNRCNo.Text; }
            set { this.txtNRCNo.Text = value; }
        }

        /// <summary>
        /// For FatherNRC
        /// </summary>

        public string FatherStateCodeForNRC
        {
            get
            {
                if (this.cboFatherStateCode.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return cboFatherStateCode.SelectedValue.ToString();
                }
            }
            set
            {
                cboFatherStateCode.SelectedValue = value;
            }
        }

        public string FatherTownshipCodeForNRC
        {
            get
            {
                if (this.cboFatherTownshipCode.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return cboFatherTownshipCode.SelectedValue.ToString();
                }
            }
            set
            {
                cboFatherTownshipCode.SelectedValue = value;
            }
        }

        public string FatherNationalityCodeForNRC
        {
            get
            {
                if (this.cboFatherNationalityCode.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return cboFatherNationalityCode.SelectedValue.ToString();
                }
            }
            set
            {
                cboFatherNationalityCode.SelectedValue = value;
            }
        }

        public string FatherNRCNo
        {
            get { return txtFatherNRCNo.Text; }
            set { this.txtFatherNRCNo.Text = value; }
        }

        public IList<StateDTO> StateCodeList { get; set; }
        public IList<StateDTO> FatherStateCodeList { get; set; }
        public IList<SAMDTO00054> NRCCodeList { get; set; }//For FormLoad
        public IList<SAMDTO00054> NRCCodes { get; set; }//ForNRCCombo

        public IList<SAMDTO00054> FatherNRCCodes { get; set; }//ForFatherNRCCombo

        #endregion

        #region Private Variables
        private int largestSize = 800;//400;
        private string custPhotoName = string.Empty;
        ErrorProvider errorProvider = new ErrorProvider();
        PFMDTO00001 Initial_CustomerInfo = new PFMDTO00001();
        public bool IsInitialStateForNRC { get; set; }
        public bool IsInitialStateForFatherNRC { get; set; }
        #endregion

        #region Entities
        /// <summary>
        /// CustomerId ViewData 
        /// </summary>     
        private PFMDTO00001 viewData;
        public PFMDTO00001 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new PFMDTO00001();
                this.viewData.CustomerId = this.CustomerId;
                this.viewData.Name = this.Initial + " " + this.NameOnly;
                this.viewData.StateCodeForNRC = this.StateCodeForNRC;
                this.viewData.TownshipCodeForNRC = this.TownshipCodeForNRC;
                this.viewData.NationalityCodeForNRC = this.NationalityCodeForNRC;
                this.viewData.NRCNo = this.NRCNo;
                //For NRC
                if (this.rdoNRC.Checked)
                {
                    this.viewData.NRC = this.StateCodeForNRC + this.TownshipCodeForNRC + this.NationalityCodeForNRC + this.NRCNo;
                    this.viewData.IsNRC = true;
                }
                else if (this.rdoOther.Checked)
                {
                    this.viewData.NRC = this.NRC;
                    this.viewData.IsNRC = false;
                }
                //For Father NRC
                if (this.rdoFatherNRC.Checked)
                {
                    this.viewData.GuardianNRCNo = this.FatherStateCodeForNRC + this.FatherTownshipCodeForNRC + this.FatherNationalityCodeForNRC + this.FatherNRCNo;
                    this.viewData.IsGuardianNRC = true;
                }
                else if (this.rdoFatherOther.Checked)
                {
                    this.viewData.GuardianNRCNo = this.GuardianNRCNo;
                    this.viewData.IsGuardianNRC = false;
                }
                //this.viewData.NRC = this.NRC;
                this.viewData.GuardianName = this.GuardianName;
                //this.viewData.GuardianNRCNo = this.GuardianNRCNo;
                this.viewData.FatherName = this.FatherName;
                this.viewData.Address = this.Address;
                this.viewData.PhoneNo = this.PhoneNo;
                this.viewData.FaxNo = this.FaxNo;
                this.viewData.Email = this.Email;
                if (this.Signature != null)
                {
                    this.viewData.Signature = this.CreateThumbnail(CXClientGlobal.ImageToByteArray(this.Signature), this.largestSize);
                }
                else
                {
                    this.viewData.Signature = null;
                }
                this.viewData.IsVIP = this.IsVIP;
                this.viewData.Gender = this.Gender;
                this.viewData.Remark = this.Remark;
                this.viewData.PassportNo = this.PassportNo;
                this.viewData.DateOfBirth = this.DateOfBirth.Date;
                this.viewData.NickName = this.NickName;
                this.viewData.StateCode = this.StateCode;
                this.viewData.CityCode = this.CityCode;
                this.viewData.TownshipCode = this.TownshipCode;
                this.viewData.Initial = this.Initial;
                this.viewData.OccupationCode = this.OccupationCode;
                this.viewData.Nationality = this.Nationality;
                this.viewData.CustPhoto.CustomerId = this.CustomerId;
                this.viewData.USERNO = CurrentUserEntity.CurrentUserID.ToString();
                if (this.Photo != null)
                {
                    this.viewData.CustPhoto.CustPhotos = this.CreateThumbnail(CXClientGlobal.ImageToByteArray(this.Photo), this.largestSize);
                }

                else
                {
                    this.viewData.CustPhoto.CustPhotos = null;
                }
                this.viewData.CustPhoto.CustPhotoName = this.custPhotoName;
                this.viewData.NameOnly = this.NameOnly;
                if (this.DateOfBirth < DateTime.Now.AddYears(-18))
                {
                    this.viewData.NRCCheckStatus = true;
                }
                else
                {
                    this.viewData.NRCCheckStatus = false;
                }
                return this.viewData;
            }

            set { this.viewData = value; }
        }

        /// <summary>
        /// CustomerPhoto ViewData 
        /// </summary>     
        private PFMDTO00010 photoviewData;
        public PFMDTO00010 PhotoViewData
        {
            get
            {
                if (this.photoviewData == null) this.photoviewData = new PFMDTO00010();
                if (this.Photo != null)
                {
                    this.photoviewData.CustPhotos = CXClientGlobal.ImageToByteArray(this.Photo);
                }
                this.photoviewData.CustPhotoName = this.custPhotoName;
                this.photoviewData.CustomerId = this.CustomerId;
                this.photoviewData.SourceBranch = CurrentUserEntity.BranchCode;
                return this.photoviewData;
            }

            set { this.photoviewData = value; }
        }

        #endregion

        #region Presenter/Controller

        /// <summary>
        /// CustomerIdController 
        /// </summary>     

        private IPFMCTL00004 customerIdController;
        public IPFMCTL00004 CustomerIdController
        {
            set
            {
                this.customerIdController = value;
                customerIdController.CustomerIdView = this;
            }
            get
            {
                return this.customerIdController;
            }
        }

        #endregion

        #region Public Methods
        /// <summary>
        ///Successful Message
        /// </summary>     
        public void Successful(string message, string customerId)
        {
            CXUIMessageUtilities.ShowMessageByCode(message, new object[] { customerId });

            if (this.isMainMenu)
            {
                this.InitializeControls();
                this.cboNationality.Enabled = true;
                if (this.FormState == FormState.New)
                {
                    this.cboInitial.Focus();
                }
                else if (this.FormState == FormState.Edit)
                {
                    this.mtxtCustomerId.Focus();
                }
            }
        }

        /// <summary>
        ///Failure Message
        /// </summary>
        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        public void RebindCustomerId(string customerId)
        {
            this.CustomerId = customerId;
        }

        public void RebindCustomerInformation(PFMDTO00001 customerId)
        {
            if (this.FormState == FormState.Edit)
            {
                if (customerId != null)
                {
                    this.mtxtCustomerId.Enabled = false;
                    this.EnableControls("CustomerId.Enable");
                    this.CustomerId = customerId.CustomerId;
                    this.Name = customerId.NameOnly;
                    this.FatherName = customerId.FatherName;
                    //For CustNRC
                    if (customerId.IsNRC)
                    {
                        if (!string.IsNullOrEmpty(customerId.NRC.ToString()))
                        {
                            string NRC = customerId.NRC;
                            int StateCodeIndex = 0;
                            int StateCodeLength = 0;

                            int TownshipCodeIndex = 0;
                            int TownshipCodeLength = 0;

                            int NationalityCodeIndex = 0;
                            int NationalityCodeLength = 0;

                            int NRCNoLength = 0;
                            int NRCNoIndex = 0;

                            StateCodeIndex = StateCodeLength = NRC.IndexOf("/") + 1;// start from 0= 3
                            this.StateCodeForNRC = NRC.Substring(0, StateCodeLength);
                            this.Initial_CustomerInfo.StateCodeForNRC = NRC.Substring(0, StateCodeLength); //For radio_button CheckChange


                            TownshipCodeIndex = NRC.IndexOf("(");
                            TownshipCodeLength = TownshipCodeIndex - StateCodeLength;
                            this.TownshipCodeForNRC = NRC.Substring(StateCodeLength, TownshipCodeLength);
                            this.Initial_CustomerInfo.TownshipCodeForNRC = NRC.Substring(StateCodeLength, TownshipCodeLength);//For radio_button CheckChange


                            NationalityCodeIndex = NRC.IndexOf(")") + 1;
                            NationalityCodeLength = NationalityCodeIndex - TownshipCodeIndex;
                            this.NationalityCodeForNRC = NRC.Substring(TownshipCodeIndex, NationalityCodeLength);
                            this.Initial_CustomerInfo.NationalityCodeForNRC = NRC.Substring(TownshipCodeIndex, NationalityCodeLength);//For radio_button CheckChange

                            NRCNoIndex = NRC.IndexOf(")") + 1;
                            NRCNoLength = NRC.Length - NRCNoIndex;
                            this.NRCNo = NRC.Substring(NRCNoIndex, NRCNoLength);
                            this.Initial_CustomerInfo.NRCNo = NRC.Substring(NRCNoIndex, NRCNoLength);//For radio_button CheckChange
                        }
                        else
                        {
                            this.StateCodeForNRC = null;
                            this.TownshipCodeForNRC = null;
                            this.NationalityCodeForNRC = null;
                            this.NRCNo = string.Empty;
                        }
                        this.rdoNRC.Checked = true;
                        this.txtNRC.Enabled = false;
                    }
                    else if (!customerId.IsNRC)
                    {
                        this.rdoOther.Checked = true;
                        this.txtNRC.Enabled = true;

                        this.txtNRCNo.Enabled = false;
                        this.cboStateCode.Enabled = false;
                        this.cboTownshipCode.Enabled = false;
                        this.cboNationalityCode.Enabled = false;
                        this.NRC = customerId.NRC;
                        this.Initial_CustomerInfo.NRC = customerId.NRC;
                    }
                    //For FatherNRC
                    if (customerId.IsGuardianNRC)
                    {
                        if (!string.IsNullOrEmpty(customerId.GuardianNRCNo.ToString()))
                        {
                            string GuardianNRCNo = customerId.GuardianNRCNo;
                            int FatherStateCodeIndex = 0;
                            int FatherStateCodeLength = 0;

                            int FatherTownshipCodeIndex = 0;
                            int FatherTownshipCodeLength = 0;

                            int FatherNationalityCodeIndex = 0;
                            int FatherNationalityCodeLength = 0;

                            int FatherNRCNoLength = 0;
                            int FatherNRCNoIndex = 0;

                            FatherStateCodeIndex = FatherStateCodeLength = GuardianNRCNo.IndexOf("/") + 1;// start from 0= 3
                            this.FatherStateCodeForNRC = GuardianNRCNo.Substring(0, FatherStateCodeLength);
                            this.Initial_CustomerInfo.FatherStateCodeForNRC = GuardianNRCNo.Substring(0, FatherStateCodeLength); //For radio_button CheckChange


                            FatherTownshipCodeIndex = GuardianNRCNo.IndexOf("(");
                            FatherTownshipCodeLength = FatherTownshipCodeIndex - FatherStateCodeLength;
                            this.FatherTownshipCodeForNRC = GuardianNRCNo.Substring(FatherStateCodeLength, FatherTownshipCodeLength);
                            this.Initial_CustomerInfo.FatherTownshipCodeForNRC = GuardianNRCNo.Substring(FatherStateCodeLength, FatherTownshipCodeLength);//For radio_button CheckChange


                            FatherNationalityCodeIndex = GuardianNRCNo.IndexOf(")") + 1;
                            FatherNationalityCodeLength = FatherNationalityCodeIndex - FatherTownshipCodeIndex;
                            this.FatherNationalityCodeForNRC = GuardianNRCNo.Substring(FatherTownshipCodeIndex, FatherNationalityCodeLength);
                            this.Initial_CustomerInfo.FatherNationalityCodeForNRC = GuardianNRCNo.Substring(FatherTownshipCodeIndex, FatherNationalityCodeLength);//For radio_button CheckChange

                            FatherNRCNoIndex = GuardianNRCNo.IndexOf(")") + 1;
                            FatherNRCNoLength = GuardianNRCNo.Length - FatherNRCNoIndex;
                            this.FatherNRCNo = GuardianNRCNo.Substring(FatherNRCNoIndex, FatherNRCNoLength);
                            this.Initial_CustomerInfo.FatherNRCNo = GuardianNRCNo.Substring(FatherNRCNoIndex, FatherNRCNoLength);//For radio_button CheckChange
                        }
                        else
                        {
                            this.FatherStateCodeForNRC = null;
                            this.FatherTownshipCodeForNRC = null;
                            this.FatherNationalityCodeForNRC = null;
                            this.FatherNRCNo = string.Empty;
                        }
                        this.rdoFatherNRC.Checked = true;
                        this.txtFatherGuardianNRC.Enabled = false;
                    }
                    else if (!customerId.IsGuardianNRC)
                    {
                        this.rdoFatherOther.Checked = true;
                        this.txtFatherGuardianNRC.Enabled = true;

                        this.txtFatherNRCNo.Enabled = false;
                        this.cboFatherStateCode.Enabled = false;
                        this.cboFatherTownshipCode.Enabled = false;
                        this.cboFatherNationalityCode.Enabled = false;
                        this.GuardianNRCNo = customerId.GuardianNRCNo;
                        this.Initial_CustomerInfo.GuardianNRCNo = customerId.GuardianNRCNo;
                    }
                    this.GuardianName = customerId.GuardianName;
                    this.FatherName = customerId.FatherName;
                    this.Address = customerId.Address;
                    this.PhoneNo = customerId.PhoneNo;
                    this.FaxNo = customerId.FaxNo;
                    this.Email = customerId.Email;
                    if (customerId.Signature != null)
                    {
                        this.Signature = CXClientGlobal.GetImage(customerId.Signature);
                        //this.Signature = CXClientGlobal.GetImage(this.CreateThumbnail(customerId.Signature, this.largestSize));
                    }
                    this.IsVIP = customerId.IsVIP;
                    this.Gender = customerId.Gender;
                    this.Remark = customerId.Remark;
                    this.PassportNo = customerId.PassportNo;
                    this.DateOfBirth = customerId.DateOfBirth;
                    this.NameOnly = customerId.NameOnly;
                    this.NickName = customerId.NickName;
                    this.CityCode = customerId.CityCode;
                    this.StateCode = customerId.StateCode;
                    this.TownshipCode = customerId.TownshipCode;
                    this.Initial = customerId.Initial;
                    this.OccupationCode = customerId.OccupationCode;
                    // this.NationalityCode = customerId.Nationality;
                    this.Nationality = customerId.Nationality;
                    if (customerId.CustPhotos != null && customerId.Active == true)
                    {
                        this.Photo = CXClientGlobal.GetImage(customerId.CustPhotos);
                        this.custPhotoName = customerId.CustPhotoName;
                        //this.Photo = CXClientGlobal.GetImage(this.CreateThumbnail(customerId.CustPhotos,this.largestSize));
                    }
                    this.ViewData = customerId;
                    butPhoto.Enabled = true;
                    butClearPhoto.Enabled = true;
                    butClearSignaturePhoto.Enabled = true;
                    btnViewPhoto.Enabled = true;
                    btnSignatureView.Enabled = true;
                    if (this.DateOfBirth < DateTime.Now.AddYears(-18))
                    {
                        this.viewData.NRCCheckStatus = true;
                    }
                    else
                    {
                        this.viewData.NRCCheckStatus = false;
                    }
                }
            }
            //else
            //{
            //    this.Failure("MV00044");
            //}
        }


        public string NRCCode()
        {
            string NRCCode = string.Empty;
            if (this.rdoNRC.Checked)
            {
                NRCCode = this.StateCodeForNRC + this.TownshipCodeForNRC + this.NationalityCodeForNRC + this.NRCNo;
            }
            else if (this.rdoOther.Checked)
            {
                NRCCode = this.NRC;
            }
            return NRCCode;

        }

        #endregion

        #region Private Method

        /// <summary>
        /// InitializeControls
        /// </summary>
        private void InitializeControls()
        {
            this.mtxtCustomerId.Text = string.Empty;
            this.cboInitial.SelectedIndex = -1;
            this.txtName.Text = string.Empty;
            this.dtpDOB.Value = DateTime.Now;//DateTime.Now.AddYears(-10);
            this.txtNRC.Enabled = true;
            this.txtNRC.Text = string.Empty;
            this.cboOccupation.SelectedIndex = -1;
            this.cboNationality.SelectedIndex = -1;
            this.cboNationality.Text = string.Empty;
            this.txtAddress.Text = string.Empty;
            this.cboCity.SelectedIndex = -1;
            this.cboTownship.SelectedIndex = -1;
            this.cboState.SelectedIndex = -1;
            this.txtNickName.Text = string.Empty;
            this.txtFatherName.Text = string.Empty; ;
            this.txtGuardianshipName.Text = string.Empty;
            this.txtFatherGuardianNRC.Text = string.Empty;
            this.cboGender.SelectedIndex = -1;
            this.txtRemark.Text = string.Empty;
            this.txtPassportNo.Text = string.Empty;
            this.txtPhone.Text = string.Empty;
            this.txtFax.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.Photo = null;
            this.Signature = null;
            this.chkVIPCustomer.Checked = false;

            //NRC
            this.rdoNRC.Enabled = true;
            this.rdoNRC.Checked = true;
            this.cboStateCode.Enabled = true;
            this.cboTownshipCode.Enabled = true;
            this.cboNationalityCode.Enabled = true;
            this.txtNRCNo.Enabled = true;
            this.cboStateCode.SelectedIndex = -1;
            this.cboTownshipCode.SelectedIndex = -1;
            this.cboNationalityCode.SelectedIndex = -1;
            this.txtNRCNo.Text = string.Empty;

            //For Other
            this.rdoOther.Enabled = true;
            this.rdoOther.Checked = false;
            this.txtNRC.Enabled = false;

            //FatherNRC
            this.rdoFatherNRC.Enabled = true;
            this.rdoFatherNRC.Checked = true;
            this.cboFatherStateCode.Enabled = true;
            this.cboFatherTownshipCode.Enabled = true;
            this.cboFatherNationalityCode.Enabled = true;
            this.txtFatherNRCNo.Enabled = true;
            this.cboFatherStateCode.SelectedIndex = -1;
            this.cboFatherTownshipCode.SelectedIndex = -1;
            this.cboFatherNationalityCode.SelectedIndex = -1;
            this.txtFatherNRCNo.Text = string.Empty;

            //For FatherOther
            this.rdoFatherOther.Enabled = true;
            this.rdoFatherOther.Checked = false;
            this.txtFatherGuardianNRC.Enabled = false;

            this.Initial_CustomerInfo = new PFMDTO00001();
            this.IsInitialStateForNRC = false;
            this.IsInitialStateForFatherNRC = false;

        }

        /// <summary>
        /// Bind City Code Combobox
        /// </summary>
        private void BindCityCodeCombobox()
        {
            IList<CityDTO> CityCodeList = CXCLE00002.Instance.GetListObject<CityDTO>("CityCode.Client.Select", new object[] { true });
            cboCity.ValueMember = "CityCode";
            cboCity.DisplayMember = "Description";
            cboCity.DataSource = CityCodeList;
            cboCity.SelectedIndex = -1;

        }

        /// <summary>
        /// Bind State CodeCombobox
        /// </summary>
        private void BindStateCodeCombobox()
        {
            IList<StateDTO> StateCodeList = CXCLE00002.Instance.GetListObject<StateDTO>("StateCode.Client.Select", new object[] { true });
            cboState.ValueMember = "StateCode";
            cboState.DisplayMember = "Description";
            cboState.DataSource = StateCodeList;
            cboState.SelectedIndex = -1;

        }

        /// <summary>
        /// Bind Initial Combobox
        /// </summary>
        private void BindInitialCombobox()
        {
            IList<PFMDTO00003> InitialCodeList = CXCLE00002.Instance.GetListObject<PFMDTO00003>("InitialCode.Client.Select", new object[] { true });
            cboInitial.ValueMember = "Initial";
            cboInitial.DisplayMember = "Description";
            cboInitial.DataSource = InitialCodeList;
            cboInitial.SelectedIndex = -1;

        }

        /// <summary>
        /// Bind Occupation Code Combobox
        /// </summary>
        private void BindOccupationCodeCombobox()
        {
            IList<PFMDTO00004> OccupationCodeList = CXCLE00002.Instance.GetListObject<PFMDTO00004>("OccupationCode.Client.Select", new object[] { true });
            cboOccupation.ValueMember = "Occupation_Code";
            cboOccupation.DisplayMember = "Description";
            cboOccupation.DataSource = OccupationCodeList;
            cboOccupation.SelectedIndex = -1;


        }

        /// <summary>
        /// Bind Township Code Combobox
        /// </summary>
        private void BindTownshipCodeCombobox()
        {
            IList<TownshipDTO> TownshipCodeList = CXCLE00002.Instance.GetListObject<TownshipDTO>("TownshipCode.Client.Select", new object[] { true });

            cboTownship.ValueMember = "TownshipCode";
            cboTownship.DisplayMember = "Description";
            cboTownship.DataSource = TownshipCodeList;
            cboTownship.SelectedIndex = -1;

        }

        /// <summary>
        /// Bind Gender Combobox
        /// </summary>
        private void BindGenderCombobox()
        {
            Dictionary<string, string> Gender = SpringApplicationContext.Instance.Resolve<Dictionary<string, string>>(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Gender));
            BindingSource genderDS = new BindingSource(Gender, null);
            cboGender.DisplayMember = "Key";
            cboGender.ValueMember = "Value";
            cboGender.DataSource = genderDS;
            cboGender.SelectedIndex = -1;
        }

        /// <summary>
        /// Bind Nationality Code Combobox
        /// </summary>
        private void BindNationalityCodeCombobox()  //Added by ASDA
        {
            IList<SAMDTO00053> NationalityCodeList = CXCLE00002.Instance.GetListObject<SAMDTO00053>("NationalityCode.Client.Select", new object[] { true });

            cboNationality.ValueMember = "Nationality_Code";
            cboNationality.DisplayMember = "Description";
            cboNationality.DataSource = NationalityCodeList;
            cboNationality.SelectedIndex = -1;
        }

        /// <summary>
        /// Bind State CodeCombobox For NRC
        /// </summary>
        private void BindStateCombobox()
        {
            StateCodeList = CXCLE00002.Instance.GetListObject<StateDTO>("StateCode.Client.Select", new object[] { true });
            for (int i = 0; i < StateCodeList.Count; i++)
            {
                StateCodeList[i].StateCode = StateCodeList[i].StateCode + "/";
            }

            cboStateCode.ValueMember = "StateCode";
            cboStateCode.DisplayMember = "StateCode";
            cboStateCode.DataSource = StateCodeList;
            cboStateCode.SelectedIndex = -1;

        }

        /// <summary>
        /// Bind FatherStateCode Combobox For NRC
        /// </summary>
        private void BindFatherStateCombobox()
        {
            FatherStateCodeList = CXCLE00002.Instance.GetListObject<StateDTO>("StateCode.Client.Select", new object[] { true });
            for (int i = 0; i < FatherStateCodeList.Count; i++)
            {
                FatherStateCodeList[i].StateCode = FatherStateCodeList[i].StateCode + "/";
            }
            cboFatherStateCode.ValueMember = "StateCode";
            cboFatherStateCode.DisplayMember = "StateCode";
            cboFatherStateCode.DataSource = FatherStateCodeList;
            cboFatherStateCode.SelectedIndex = -1;

        }

        /// <summary>
        /// Bind Township CodeCombobox For NRC
        /// </summary>
        private void BindTownshipCombobox()
        {
            cboTownshipCode.ValueMember = "TownshipCode";
            cboTownshipCode.DisplayMember = "TownshipCode";
            cboTownshipCode.DataSource = NRCCodes;
            cboTownshipCode.SelectedIndex = -1;

        }

        /// <summary>
        /// Bind FatherTownship CodeCombobox For NRC
        /// </summary>
        private void BindFatherTownshipCombobox()
        {
            cboFatherTownshipCode.ValueMember = "TownshipCode";
            cboFatherTownshipCode.DisplayMember = "TownshipCode";
            cboFatherTownshipCode.DataSource = FatherNRCCodes;
            cboFatherTownshipCode.SelectedIndex = -1;

        }

        /// <summary>
        /// Bind Nationality CodeCombobox For NRC
        /// </summary>
        private void BindNationalityCombobox()
        {
            IList<SAMDTO00053> NationalityList = new List<SAMDTO00053>();
            NationalityList.Add(new SAMDTO00053("(N)", null));
            NationalityList.Add(new SAMDTO00053("(E)", null));
            NationalityList.Add(new SAMDTO00053("(T)", null));
            NationalityList.Add(new SAMDTO00053("(P)", null));
            cboNationalityCode.ValueMember = "Nationality_Code";
            cboNationalityCode.DisplayMember = "Nationality_Code";
            cboNationalityCode.DataSource = NationalityList;
            cboNationalityCode.SelectedIndex = -1;

        }

        /// <summary>
        /// Bind FatherNationality CodeCombobox For NRC
        /// </summary>
        private void BindFatherNationalityCombobox()
        {
            IList<SAMDTO00053> NationalityList = new List<SAMDTO00053>();
            NationalityList.Add(new SAMDTO00053("(N)", null));
            NationalityList.Add(new SAMDTO00053("(E)", null));
            NationalityList.Add(new SAMDTO00053("(T)", null));
            NationalityList.Add(new SAMDTO00053("(P)", null));
            cboFatherNationalityCode.ValueMember = "Nationality_Code";
            cboFatherNationalityCode.DisplayMember = "Nationality_Code";
            cboFatherNationalityCode.DataSource = NationalityList;
            cboFatherNationalityCode.SelectedIndex = -1;

        }

        private void RefreshControls()
        {
            if (this.FormState == FormState.New)
            {
                mtxtCustomerId.Enabled = false;
                //cboInitial.Focus();
                mtxtCustomerId.TabStop = false;
                //butCustomerSearch.TabStop = false;                
                //butCustomerSearch.Visible = false;
                //chkVIPCustomer.TabStop = false;
                this.chkVIPCustomer.Location = new System.Drawing.Point(231, 17);
                this.chkVIPCustomer.Focus();
            }
            else if (this.FormState == FormState.Edit)
            {
                this.Text = "Customer Editing";
                mtxtCustomerId.Enabled = true;                
                //mtxtCustomerId.Select();
                this.Initial_CustomerInfo = new PFMDTO00001();
                this.DisableControls("CustomerId.Disable");               
                this.mtxtCustomerId.Focus();

            }
        }

        #endregion

        #region Event
        private void butClearSignaturePhoto_Click(object sender, EventArgs e)
        {
            picSignature.Image = null;
        }

        //private void FormName_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        this.SelectNextControl(this.ActiveControl, true, true, true, true);
        //    }
        //}
        //When CustomerId Entry Menu Clicked
        private void frmPFMVEW00004_Load(object sender, EventArgs e)
        {
            this.BindCityCodeCombobox();

            this.BindStateCodeCombobox();

            this.BindInitialCombobox();

            this.BindOccupationCodeCombobox();

            this.BindTownshipCodeCombobox();

            this.BindNationalityCodeCombobox();   //Added by ASDA

            this.BindGenderCombobox();

            this.BindStateCombobox();//For NRC Format
            this.BindNationalityCombobox();//For NRC Format

            this.BindFatherStateCombobox();//For FatherNRC Format
            this.BindFatherNationalityCombobox();//For FatherNRC Format

            NRCCodeList = CXCLE00002.Instance.GetListObject<SAMDTO00054>("NRCCode.Client.Select", new object[] { true });//Bind NRC Code

            //DateTime date =Convert.ToDateTime(DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + (DateTime.Now.Year - 10));
            //DateTime date = DateTime.Now.AddYears(-10);
            //this.dtpDOB.Text = Convert.ToString(DateTime.Now.AddYears(-10));   //Added by ASDA
            this.dtpDOB.Text = Convert.ToString(DateTime.Now);// Added by HMW (30-04-2019)

            //For NRC
            this.txtNRC.Enabled = false;
            this.cboStateCode.Enabled = true;
            this.cboTownshipCode.Enabled = true;
            this.cboNationalityCode.Enabled = true;
            this.txtNRCNo.Enabled = true;
            // this.chkVIPCustomer.Checked = false;

            //FatherNRC
            this.txtFatherGuardianNRC.Enabled = false;
            this.cboFatherStateCode.Enabled = true;
            this.cboFatherTownshipCode.Enabled = true;
            this.cboFatherNationalityCode.Enabled = true;
            this.txtFatherNRCNo.Enabled = true;

            tlspCommon.ButtonEnableDisabled(false, false, true, false, true, false, true);

            //this.chkVIPCustomer.Focus();
            if (this.FormState == FormState.Edit)
            {
                //this.mtxtCustomerId.Focus();
                //btnViewPhoto.Enabled = false;
                //btnSignatureView.Enabled = false;
                //butClearPhoto.Enabled = false;
                //butClearSignaturePhoto.Enabled = false;
                this.mtxtCustomerId.Focus();
            }

            RefreshControls();
        }

        private void tlspCommon_ExitButtonClick(object sender, EventArgs e)
        {
            this.mtxtCustomerId.CausesValidation = false;
            this.AutoValidate = AutoValidate.Disable;
            this.Close();
        }

        private void tlspCommon_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            //this.dtpDOB.Text = Convert.ToString(DateTime.Now.AddYears(-10));
            this.dtpDOB.Text = Convert.ToString(DateTime.Now); //Added by HMW at 30-04-2019

            this.RefreshControls();
            this.errorProvider.Clear();
            this.CustomerIdController.ClearErrors();
            this.customerIdController.ClearCustomErrorMessage();
            errorProviderForPhoto.Clear();
            errorProviderForNRC.Clear();
        }

        //To upload Photo Image
        private void butPhoto_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();

                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        picPhoto.Image = new Bitmap(open.FileName);
                        errorProviderForPhoto.Clear();
                    }
                    catch
                    {
                        // Invalid file format.Please re-choose again.
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00018);
                        return;
                    }
                }

                this.custPhotoName = open.FileName.ToString();
            }
            catch (Exception)
            {

                this.Failure("Failed loading image");
            }
        }

        //To upload Signature Image 
        private void butSignatureFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();

                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        picSignature.Image = new Bitmap(open.FileName);
                        errorProviderForNRC.Clear();
                    }
                    catch
                    {
                        //  Invalid file format.Please re-choose again.
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00018);
                        return;
                    }
                }

            }
            catch (Exception)
            {
                this.Failure("Failed loading image");
            }
        }

        //To clear Photo
        private void butClearPhoto_Click(object sender, EventArgs e)
        {
            picPhoto.Image = null;
        }
        
        private void tlspCommon_SaveButtonClick(object sender, EventArgs e)
        {
            CurrentUserEntity.IsIgnoreDataValidating = false;

            if (this.FormState == FormState.New)
            {
                if(this.ViewData.Signature == null )
                {
                    errorProviderForNRC.SetError(picSignature, CXMessage.MV00233);
                    return;
                }
                if(this.ViewData.CustPhoto.CustPhotos == null )
                {
                    errorProviderForPhoto.SetError(picPhoto, CXMessage.MV00232);
                    return;
                }
                if (this.customerIdController.Save(this.ViewData) == false)
                {
                    return;
                }
                if (IsMainMenu == false)
                {
                    this.viewData.CustomerId = this.CustomerId;
                    this.viewData.CityDesp = this.cboCity.Text;
                    this.viewData.OccupationDesp = this.cboOccupation.Text;
                    this.viewData.StateDesp = this.cboState.Text;
                    this.viewData.TownshipDesp = this.cboTownship.Text;
                    this.TransitEntity = this.viewData;
                    CXUIScreenTransit.SetData("frmPFMVEW00005Transit", this.TransitEntity);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else if (this.FormState == FormState.Edit)
            {
                if (!String.IsNullOrEmpty(this.CustomerId) && this.customerIdController.Update(this.ViewData, this.PhotoViewData) == true)
                {
                    CurrentUserEntity.IsIgnoreDataValidating = true;
                    mtxtCustomerId.Enabled = true;
                    this.DisableControls("CustomerId.Disable");
                    //this.butCustomerSearch.Focus();
                    CurrentUserEntity.IsIgnoreDataValidating = false;
                    this.mtxtCustomerId.Focus();
                }
                else
                {
                    //CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00016);
                    //mtxtCustomerId.Focus();
                }
            }
        }

        //private void butCustomerSearch_Click(object sender, EventArgs e)   //requested by Ma AMMK , comment by ASDA
        //{
        //    this.customerIdController.AddCustomer();
        //}

        private void dtpDOB_Leave(object sender, EventArgs e)
        {
            if (this.DateOfBirth.Date <= DateTime.Now.AddYears(-18).Date)//18+
            {
                this.viewData.NRCCheckStatus = true;
            }
            else
            {
                this.viewData.NRCCheckStatus = false;
            }
        }
        #endregion

        #region Capter Letter

        private void txtName_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //private void txtCustNRC_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        //{
        //    e.KeyChar = char.ToUpper(e.KeyChar);
        //}

        //private void txtNationality_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        //{
        //    e.KeyChar = char.ToUpper(e.KeyChar);
        //    if (char.IsDigit(e.KeyChar))
        //    {
        //        e.Handled = true;
        //    }
        //}

        private void txtAddress_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);

        }

        private void txtNickName_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtFatherName_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtGuardianshipName_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtFatherGuardianNRC_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtPassportNo_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);

        }

        private void txtPhone_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtFax_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtRemark_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        //private void txtNRC_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    e.KeyChar = char.ToUpper(e.KeyChar);
        //}

        private void txtFatherGuardianNRC_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
        #endregion

        private void mtxtCustomerId_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if ((Keys)e.KeyCode == Keys.Enter)
            {
                PFMDTO00001 customerId = this.customerIdController.SelectByCustomerId(this.CustomerId);

                if (customerId != null)
                    this.RebindCustomerInformation(customerId);
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00016);
                    mtxtCustomerId.Focus();
                }

            }
        }

        //private void mtxtCustomerId_Validated(object sender, EventArgs e)   
        //{
        //        PFMDTO00001 customerId = this.customerIdController.SelectByCustomerId(this.CustomerId);
        //        if (customerId != null)
        //            this.RebindCustomerInformation(customerId);
        //        else
        //        {
        //            CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00016);
        //            mtxtCustomerId.Focus();
        //        }

        //}

        // Create a thumbnail in byte array format from the image encoded in the passed byte array.  
        // (RESIZE an image in a byte[] variable.)  
        public byte[] CreateThumbnail(byte[] PassedImage, int LargestSide)
        {
            byte[] ReturnedThumbnail;

            using (System.IO.MemoryStream StartMemoryStream = new System.IO.MemoryStream(),
                                NewMemoryStream = new System.IO.MemoryStream())
            {
                // write the string to the stream  
                StartMemoryStream.Write(PassedImage, 0, PassedImage.Length);

                // create the start Bitmap from the MemoryStream that contains the image  
                Bitmap startBitmap = new Bitmap(StartMemoryStream);

                // set thumbnail height and width proportional to the original image.  
                int newHeight;
                int newWidth;
                double HW_ratio;
                if (startBitmap.Height > startBitmap.Width)
                {
                    newHeight = LargestSide;
                    HW_ratio = (double)((double)LargestSide / (double)startBitmap.Height);
                    newWidth = (int)(HW_ratio * (double)startBitmap.Width);
                }
                else
                {
                    newWidth = LargestSide;
                    HW_ratio = (double)((double)LargestSide / (double)startBitmap.Width);
                    newHeight = (int)(HW_ratio * (double)startBitmap.Height);
                }

                // create a new Bitmap with dimensions for the thumbnail.  
                Bitmap newBitmap = new Bitmap(newWidth, newHeight);

                // Copy the image from the START Bitmap into the NEW Bitmap.  
                // This will create a thumnail size of the same image.  
                newBitmap = ResizeImage(startBitmap, newWidth, newHeight);

                // Save this image to the specified stream in the specified format.  
                newBitmap.Save(NewMemoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);

                // Fill the byte[] for the thumbnail from the new MemoryStream.  
                ReturnedThumbnail = NewMemoryStream.ToArray();
            }

            // return the resized image as a string of bytes.  
            return ReturnedThumbnail;
        }

        // Resize a Bitmap  
        private static Bitmap ResizeImage(Bitmap image, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics gfx = Graphics.FromImage(resizedImage))
            {
                gfx.DrawImage(image, new Rectangle(0, 0, width, height),
                    new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
            }
            return resizedImage;
        }

        private void mtxtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            { e.Handled = true; }
        }

        private void mtxtFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            { e.Handled = true; }
        }

        private void txtNRC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (18 > DateTime.Now.Year - DateOfBirth.Year)
            //if (this.DateOfBirth < DateTime.Now.AddYears(+18))
            {
                if (e.KeyChar == '-')
                {
                    e.Handled = false;
                }

            }

            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtNRCNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (18 > DateTime.Now.Year - DateOfBirth.Year)
            {
                if (e.KeyChar == '-')
                {
                    e.Handled = false;
                }

            }
            else if (18 < DateTime.Now.Year - DateOfBirth.Year)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                if (e.KeyChar == '-')
                {
                    e.Handled = true;
                }
            }

        }

        private void txtFatherNRCNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (18 < DateTime.Now.Year - DateOfBirth.Year)
            {
                if (e.KeyChar == '-')
                {
                    e.Handled = false;
                }

            }
            else if (18 > DateTime.Now.Year - DateOfBirth.Year)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                if (e.KeyChar == '-')
                {
                    e.Handled = true;
                }
            }
        }

        private void cboStateCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboStateCode.SelectedIndex != -1)
            {
                if (this.cboStateCode.SelectedValue != null && this.NRCCodeList != null)
                {
                    string StateCode = string.Empty;
                    StateCode = this.cboStateCode.SelectedValue.ToString().Substring(0, this.cboStateCode.SelectedValue.ToString().Length - 1);
                    NRCCodes = (from x in this.NRCCodeList where x.StateCode == StateCode select x).ToList();
                    this.BindTownshipCombobox();
                }
            }
        }

        private void cboFatherStateCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboFatherStateCode.SelectedIndex != -1)
            {
                if (this.cboFatherStateCode.SelectedValue != null && this.NRCCodeList != null)
                {
                    string StateCode = string.Empty;
                    StateCode = this.cboFatherStateCode.SelectedValue.ToString().Substring(0, this.cboFatherStateCode.SelectedValue.ToString().Length - 1);
                    FatherNRCCodes = (from x in this.NRCCodeList where x.StateCode == StateCode select x).ToList();
                    this.BindFatherTownshipCombobox();
                }
            }

        }

        private void rdoNRC_CheckedChanged(object sender, EventArgs e)
        {
            this.customerIdController.ClearErrors();
            if (this.FormState == FormState.New)
            {
                this.viewData.NRCCheckStatus = true;
                if (this.txtNRC.Text != null || this.txtNRC.Text.ToString() != string.Empty)
                {
                    this.txtNRC.Text = "";
                }
                this.txtNRC.Enabled = false;

                this.cboStateCode.Enabled = true;
                this.cboTownshipCode.Enabled = true;
                this.cboNationalityCode.Enabled = true;
                this.txtNRCNo.Enabled = true;
            }
            else if (this.FormState == FormState.Edit)
            {
                this.viewData.NRCCheckStatus = true;
                if (this.txtNRC.Text != null || this.txtNRC.Text.ToString() != string.Empty)
                {
                    this.txtNRC.Text = "";
                }

                //Rebind For NRC
                if (this.rdoNRC.Checked)
                {
                    if (this.IsInitialStateForNRC)
                    {
                        if (this.cboStateCode.SelectedIndex == -1 || this.cboTownshipCode.SelectedIndex == -1 || this.cboNationalityCode.SelectedIndex == -1 || this.txtNRCNo.Text.ToString() == string.Empty)
                        {
                            if (Initial_CustomerInfo.StateCodeForNRC != null && Initial_CustomerInfo.TownshipCodeForNRC != null && Initial_CustomerInfo.NationalityCodeForNRC != null && Initial_CustomerInfo.NRCNo != null)
                            {
                                this.StateCodeForNRC = Initial_CustomerInfo.StateCodeForNRC;
                                this.TownshipCodeForNRC = Initial_CustomerInfo.TownshipCodeForNRC;
                                this.NationalityCodeForNRC = Initial_CustomerInfo.NationalityCodeForNRC;
                                this.NRCNo = Initial_CustomerInfo.NRCNo;
                                //this.IsInitialStateForNRC = false;
                            }

                        }
                    }
                }

                this.txtNRC.Enabled = false;

                this.cboStateCode.Enabled = true;
                this.cboTownshipCode.Enabled = true;
                this.cboNationalityCode.Enabled = true;
                this.txtNRCNo.Enabled = true;
            }
        }

        private void rdoOther_CheckedChanged(object sender, EventArgs e)
        {
            this.customerIdController.ClearErrors();
            if (this.FormState == FormState.New)
            {
                this.viewData.NRCCheckStatus = true;
                if (this.cboStateCode.SelectedIndex > -1 || this.cboStateCode.SelectedValue != null)
                {
                    this.cboStateCode.SelectedIndex = -1;
                }
                if (this.cboTownshipCode.SelectedIndex > -1 || this.cboTownshipCode.SelectedValue != null)
                {
                    this.cboTownshipCode.SelectedIndex = -1;
                }
                if (this.cboNationalityCode.SelectedIndex > -1 || this.cboNationalityCode.SelectedValue != null)
                {
                    this.cboNationalityCode.SelectedIndex = -1;
                }
                if (this.txtNRCNo.Text != null || this.txtNRCNo.Text.ToString() != string.Empty)
                {
                    this.txtNRCNo.Text = "";
                }
                this.txtNRC.Enabled = true;

                this.cboStateCode.Enabled = false;
                this.cboTownshipCode.Enabled = false;
                this.cboNationalityCode.Enabled = false;
                this.txtNRCNo.Enabled = false;
            }
            else if (this.FormState == FormState.Edit)
            {
                this.viewData.NRCCheckStatus = true;
                if (this.cboStateCode.SelectedIndex > -1 || this.cboStateCode.SelectedValue != null)
                {
                    this.cboStateCode.SelectedIndex = -1;
                }
                if (this.cboTownshipCode.SelectedIndex > -1 || this.cboTownshipCode.SelectedValue != null)
                {
                    this.cboTownshipCode.SelectedIndex = -1;
                }
                if (this.cboNationalityCode.SelectedIndex > -1 || this.cboNationalityCode.SelectedValue != null)
                {
                    this.cboNationalityCode.SelectedIndex = -1;
                }
                if (this.txtNRCNo.Text != null || this.txtNRCNo.Text.ToString() != string.Empty)
                {
                    this.txtNRCNo.Text = "";
                }

                //Rebind For NRC
                if (this.rdoOther.Checked)
                {
                    if (this.IsInitialStateForNRC)
                    {
                        if (string.IsNullOrEmpty(this.txtNRC.Text.ToString()))
                        {
                            if (this.Initial_CustomerInfo.NRC != null)
                            {
                                this.NRC = this.Initial_CustomerInfo.NRC;
                                //this.IsInitialStateForNRC = false;
                            }
                        }
                    }
                }
                this.txtNRC.Enabled = true;

                this.cboStateCode.Enabled = false;
                this.cboTownshipCode.Enabled = false;
                this.cboNationalityCode.Enabled = false;
                this.txtNRCNo.Enabled = false;
            }
        }
        private void rdoFatherNRC_CheckedChanged(object sender, EventArgs e)
        {
            this.customerIdController.ClearErrors();
            if (this.FormState == FormState.New)
            {
                if (this.txtFatherGuardianNRC.Text != null || this.txtFatherGuardianNRC.Text.ToString() != string.Empty)
                {
                    this.txtFatherGuardianNRC.Text = "";
                }
                this.txtFatherGuardianNRC.Enabled = false;
                this.cboFatherStateCode.Enabled = true;
                this.cboFatherTownshipCode.Enabled = true;
                this.cboFatherNationalityCode.Enabled = true;
                this.txtFatherNRCNo.Enabled = true;
            }
            else if (this.FormState == FormState.Edit)
            {
                //Rebind For FatherNRC
                if (this.rdoFatherNRC.Checked)
                {
                    if (this.IsInitialStateForFatherNRC)
                    {
                        if (this.cboFatherStateCode.SelectedIndex == -1 || this.cboFatherTownshipCode.SelectedIndex == -1 || this.cboFatherNationalityCode.SelectedIndex == -1 || this.txtFatherNRCNo.Text.ToString() == string.Empty)
                        {
                            if (Initial_CustomerInfo.FatherStateCodeForNRC != null && Initial_CustomerInfo.FatherTownshipCodeForNRC != null && Initial_CustomerInfo.FatherNationalityCodeForNRC != null && Initial_CustomerInfo.FatherNRCNo != null)
                            {
                                this.FatherStateCodeForNRC = Initial_CustomerInfo.FatherStateCodeForNRC;
                                this.FatherTownshipCodeForNRC = Initial_CustomerInfo.FatherTownshipCodeForNRC;
                                this.FatherNationalityCodeForNRC = Initial_CustomerInfo.FatherNationalityCodeForNRC;
                                this.FatherNRCNo = Initial_CustomerInfo.FatherNRCNo;
                                //this.IsInitialStateForFatherNRC = false;
                            }

                        }
                    }
                }
                if (this.txtFatherGuardianNRC.Text != null || this.txtFatherGuardianNRC.Text.ToString() != string.Empty)
                {
                    this.txtFatherGuardianNRC.Text = "";
                }
                this.txtFatherGuardianNRC.Enabled = false;

                this.cboFatherStateCode.Enabled = true;
                this.cboFatherTownshipCode.Enabled = true;
                this.cboFatherNationalityCode.Enabled = true;
                this.txtFatherNRCNo.Enabled = true;
            }
        }

        private void rdoFatherOther_CheckedChanged(object sender, EventArgs e)
        {
            this.customerIdController.ClearErrors();
            if (this.FormState == FormState.New)
            {
                if (this.cboFatherStateCode.SelectedIndex > -1 || this.cboFatherStateCode.SelectedValue != null)
                {
                    this.cboFatherStateCode.SelectedIndex = -1;
                }
                if (this.cboFatherTownshipCode.SelectedIndex > -1 || this.cboFatherTownshipCode.SelectedValue != null)
                {
                    this.cboFatherTownshipCode.SelectedIndex = -1;
                }
                if (this.cboFatherNationalityCode.SelectedIndex > -1 || this.cboFatherNationalityCode.SelectedValue != null)
                {
                    this.cboFatherNationalityCode.SelectedIndex = -1;
                }
                if (this.txtFatherNRCNo.Text != null || this.txtFatherNRCNo.Text.ToString() != string.Empty)
                {
                    this.txtFatherNRCNo.Text = "";
                }
                this.txtFatherGuardianNRC.Enabled = true;

                this.cboFatherStateCode.Enabled = false;
                this.cboFatherTownshipCode.Enabled = false;
                this.cboFatherNationalityCode.Enabled = false;
                this.txtFatherNRCNo.Enabled = false;
            }
            else if (this.FormState == FormState.Edit)
            {
                if (this.cboFatherStateCode.SelectedIndex > -1 || this.cboFatherStateCode.SelectedValue != null)
                {
                    this.cboFatherStateCode.SelectedIndex = -1;
                }
                if (this.cboFatherTownshipCode.SelectedIndex > -1 || this.cboFatherTownshipCode.SelectedValue != null)
                {
                    this.cboFatherTownshipCode.SelectedIndex = -1;
                }
                if (this.cboFatherNationalityCode.SelectedIndex > -1 || this.cboFatherNationalityCode.SelectedValue != null)
                {
                    this.cboFatherNationalityCode.SelectedIndex = -1;
                }
                if (this.txtFatherNRCNo.Text != null || this.txtFatherNRCNo.Text.ToString() != string.Empty)
                {
                    this.txtFatherNRCNo.Text = "";
                }
                //Rebind For FatherNRC
                if (this.rdoFatherOther.Checked)
                {
                    if (this.IsInitialStateForFatherNRC)
                    {
                        if (string.IsNullOrEmpty(this.txtFatherGuardianNRC.Text.ToString()))
                        {
                            if (this.Initial_CustomerInfo.GuardianNRCNo != null)
                            {
                                this.GuardianNRCNo = this.Initial_CustomerInfo.GuardianNRCNo;
                                //this.IsInitialStateForFatherNRC = false;
                            }
                        }
                    }
                }
                this.txtFatherGuardianNRC.Enabled = true;

                this.cboFatherStateCode.Enabled = false;
                this.cboFatherTownshipCode.Enabled = false;
                this.cboFatherNationalityCode.Enabled = false;
                this.txtFatherNRCNo.Enabled = false;
            }
        }

        private void rdoOther_Leave(object sender, EventArgs e)
        {
            if (this.ActiveControl.Name == "tlspCommon")
            {
                this.txtNRC.Focus();
            }
        }

        private void rdoFatherOther_Leave(object sender, EventArgs e)
        {

        }

        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
        }

        private void txtFax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
        }

        private void cboStateCode_TabIndexChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.cboStateCode.Text))
            {

            }
        }
        private void btnViewPhoto_Click(object sender, EventArgs e)
        {
            if (this.Photo != null)
            {
                //CXUIScreenTransit.Transit("frmPFMVEW00080", true, new object[] { this.CreateThumbnail(CXClientGlobal.ImageToByteArray(this.Photo), this.largestSize) });
                CXUIScreenTransit.Transit("frmPFMVEW00080", true, new object[] { this.CreateThumbnail(CXClientGlobal.ImageToByteArray(this.Photo), this.largestSize), "Customer Photo" });
            }

            //if (this.Photo != null)
            //{
            //    CXUIScreenTransit.Transit("frmPFMVEW00080", true, new object[] { this.custPhotoName });
            //}

        }
        private void btnSignatureView_Click(object sender, EventArgs e)
        {
            if (this.Signature != null)
            {
                //CXUIScreenTransit.Transit("frmPFMVEW00080", true, new object[] { this.CreateThumbnail(CXClientGlobal.ImageToByteArray(this.Photo), this.largestSize) });
                CXUIScreenTransit.Transit("frmPFMVEW00080", true, new object[] { this.CreateThumbnail(CXClientGlobal.ImageToByteArray(this.Signature), this.largestSize), "Signature" });
            }
        }
        public void ClearNRC()
        {
            //cboStateCode.SelectedIndex = -1;
            //cboTownshipCode.SelectedIndex = -1;
            //cboNationalityCode.SelectedIndex = -1;
            txtNRCNo.Text = "";
            txtNRC.Text = "";
            //cboStateCode.Focus();
            //this.cboNationalityCode.Focus();
        }

        private void gvCustomerInfo_Enter(object sender, EventArgs e)
        {

        }

        private void picPhoto_Click(object sender, EventArgs e)
        {

        }
    }
}
