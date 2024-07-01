using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Utt;
using System.Windows.Forms;
using System.Configuration;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Mnm.Ptr
{
    public class MNMCTL00021 : AbstractPresenter, IMNMCTL00021
    {
        #region Private  Variables

        string M_Type1,M_Type2;
        string RegCur1, RegCur2;
        string Error_Msg;
        string LCuNum,TCuNum,Ctype,CType;        
        int Position,ICuNum;
        bool Zero;        
        string NotSingle;
        string Ctype2, Ctype1;        
        decimal DCuNum,KKn,TDCuNum;   
        string TDCuNum2,TDCuNum1,XCuNum,ZLT,ACuNum;   
        string In_Word1 = null, In_Word2 = null;
        string Sign_of_Amount = null;
        string[] WholeArray = new string[10];
        string[] TenArray = new string[10];
        string[] Eleven_to_NineTeen = new string[10];
        int[] NumArray = new int[13];
        string Digit1, Digit2;
        string Cut_Ext;
        TLMDTO00017 RdDTO;
        private bool isValidateForm{get;set;}
        DateTime Date1;
        DateTime Date2;

        #endregion

        #region public variables
        public bool isFinish { get; set; }
        #endregion

        #region View

        private IMNMVEW00021 view;
        public IMNMVEW00021 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(IMNMVEW00021 view)
        {
            this.view = view;
            this.Initialize(this.view, this.getEntity());
        }

        private TLMDTO00017 getEntity()
        {
            TLMDTO00017 entity = new TLMDTO00017();
            entity.RegisterNo = this.View.RegisterNo1;
            entity.RegisterNo = this.View.RegisterNo2;
            return entity;
           
        }

        #endregion

        #region Validation Logic

        public void ClearCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }

        public void txtRegisterNo1_CustomValidating(object sender, ValidationEventArgs e)
        {          
            if (e.HasXmlBaseError == false)
            {
                string RegisterNo1 = this.view.RegisterNo1.Trim();

                if (string.IsNullOrEmpty(RegisterNo1))
                {
                    this.SetCustomErrorMessage(this.GetControl("txtRegisterNo1"), CXMessage.MV00168);    //Invalid Register No             
                }

                else if (RegisterNo1 == this.view.RegisterNo2)
                {
                    // Duplicate Register No
                    this.SetCustomErrorMessage(this.GetControl("txtRegisterNo2"), CXMessage.MV00108);  
                }

                else if (this.Checking_Remittance_Register(RegisterNo1, "D")) // Check Register No is Remittance Register
                {
                    if (RdDTO.SourceBranchCode == CurrentUserEntity.BranchCode) //Check Equal Source Branch Code
                    {
                        RegCur1 = RdDTO.Currency;
                        M_Type1 = RdDTO.Type;
                        this.view.Currency1 = RegCur1;
                        this.view.DraweBankCode1 = RdDTO.Dbank;
                        this.view.DraweBankName1 = RdDTO.Br_Alias;
                        this.Date1 = Convert.ToDateTime(RdDTO.DateTime);

                        //Check Two Register No are  Same DrawBank,Type And Currency
                        if (this.view.RegisterNo2.Trim() != "")
                        {
                            if (this.Same_Type(M_Type1, M_Type2, this.view.DraweBankName1, this.view.DraweBankName2, RegCur1, RegCur2, ref Error_Msg))
                            {
                                this.view.Amount1 = RdDTO.Amount.ToString();
                                this.view.PayerName1 = RdDTO.Name;
                                this.view.PayeeName1 = RdDTO.ToName;
                                this.SetFocus("txtRegisterNo2");
                            }
                            else
                            {
                                this.view.Failure(Error_Msg);
                                this.SetFocus("txtRegisterNo1");
                            }
                           
                        }
                        if (this.view.RegisterNo2.Trim() == "")
                        {
                            this.view.Amount1 = RdDTO.Amount.ToString();
                            this.view.PayerName1 = RdDTO.Name;
                            this.view.PayeeName1 = RdDTO.ToName;
                            //this.SetFocus("txtRegisterNo2");
                        }

                    }
                }
                else
                {
                    //Show Msg Register No Not Found
                    this.SetCustomErrorMessage(this.GetControl("txtRegisterNo1"), CXMessage.MV00218); 
                    this.SetFocus("txtRegisterNo1");
                }

            }

        }

        public void txtRegisterNo2_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError == false)
            {
                string RegisterNo2 = this.view.RegisterNo2.Trim();
                this.Date2 = Convert.ToDateTime(RdDTO.DateTime);

                if (string.IsNullOrEmpty(RegisterNo2))                 
                    this.SetCustomErrorMessage(this.GetControl("txtRegisterNo2"), CXMessage.MV00168);    //Invalid Register No            

                else if (this.view.RegisterNo1.Trim() == this.view.RegisterNo2.Trim())
                    this.SetCustomErrorMessage(this.GetControl("txtRegisterNo2"), CXMessage.MV00108);    // Duplicate Register No
                

                else if (this.Checking_Remittance_Register(RegisterNo2, "D"))
                {
                    if (RdDTO.SourceBranchCode == CurrentUserEntity.BranchCode) //Check Two Register are same Source Branch Code
                    {
                        RegCur2 = RdDTO.Currency;
                        M_Type2 = RdDTO.Type;
                 
                       
                        //Check Two Register No are  Same DrawBank,Type And Currency
                        if (this.Same_Type(M_Type1, M_Type2, this.view.DraweBankName1, RdDTO.Br_Alias, RegCur1, RegCur2, ref Error_Msg))
                        {
                            this.view.DraweBankCode2 = RdDTO.Dbank;
                            this.view.DraweBankName2 = RdDTO.Br_Alias;
                            this.view.Currency2 = RegCur2;
                            this.view.Amount2 = RdDTO.Amount.ToString();
                            this.view.PayerName2 = RdDTO.Name;
                            this.view.PayeeName2 = RdDTO.ToName;
                            if (!this.isFinish)
                                this.SetFocus("tsbCRUD");                            
                        }
                        else
                        {
                            this.view.Failure(Error_Msg);
                            this.SetFocus("txtRegisterNo2");
                        }
                    }
                }
                else
                {
                    //Show msg Register No Not Found
                    this.SetCustomErrorMessage(this.GetControl("txtRegisterNo2"), CXMessage.MV00218); 
                    this.SetFocus("txtRegisterNo2");
                }
            }
        }
             
        #endregion

        #region Main Method

        public void Save()
        {
            //try
            //{
                if (this.ValidateForm())
                {
                    if (string.IsNullOrEmpty(View.Amount1))
                    {
                        throw new Exception(CXMessage.ME90018);
                    }
                    if (string.IsNullOrEmpty(View.Amount2))
                    {
                        throw new Exception(CXMessage.ME90018);
                    }
                    //Get Description For Amount
                    In_Word1 = this.AmountDesp(Convert.ToDecimal(this.View.Amount1), this.View.Currency1);
                    In_Word2 = this.AmountDesp(Convert.ToDecimal(this.view.Amount2), this.view.Currency2);

                    //TLMDTO00017 entity = CXClientWrapper.Instance.Invoke<IMNMSVE00021,TLMDTO00017>(x => x.Save_CrossChange(this.view.RegisterNo1, this.view.RegisterNo2, RegCur1, RegCur2, In_Word1, In_Word2,Environment.MachineName, CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID));  comment by ASDA
                    TLMDTO00017 entity = CXClientWrapper.Instance.Invoke<IMNMSVE00021, TLMDTO00017>(x => x.Save_CrossChange(this.view.RegisterNo1, this.view.RegisterNo2, RegCur1, RegCur2, In_Word1, In_Word2, this.Date1, this.Date2, Environment.MachineName, CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID));

                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                        this.view.Failure("Saving Error.");
                    else
                    {                    
                        CXUIMessageUtilities.ShowMessageByCode("MI90002");  //Update Successful
                        string registerNo1 = this.view.RegisterNo1;
                        this.view.RegisterNo1 = this.view.RegisterNo2;
                        this.view.RegisterNo2 = registerNo1;

                                                                      
                        if (CXUIMessageUtilities.ShowMessageByCode("MC00002") == DialogResult.Yes)  // Are you sure to print?
                        {
                            entity.status = "CrossChange";
                            CXUIScreenTransit.Transit("frmMNMVEW00130DrawintPrintingReport", true, new object[] { entity });
                        }
                        this.isFinish = true;
                        this.view.ClearControls();
                        this.SetFocus("txtRegisterNo1");
                    }

                }
            //}
                
            //catch(Exception ex)
            //{
            //    this.SetCustomErrorMessage(this.GetControl("txtRegisterNo1"), ex.Message);
            //}

            this.isValidateForm = false;
        }

        #endregion

        #region Helper Methods
        //Convert Amount into Description Amount
        private string AmountDesp(decimal CuNum, string CurType)
        {
            InitializeControls();
            if (CuNum < 0)
            {
                CuNum = CuNum * (-1);
                Sign_of_Amount = "(-)";
            }
            else
                Sign_of_Amount = "";

            WholeArray[1] = "One";
            WholeArray[2] = "Two";
            WholeArray[3] = "Three";
            WholeArray[4] = "Four";
            WholeArray[5] = "Five";
            WholeArray[6] = "Six";
            WholeArray[7] = "Seven";
            WholeArray[8] = "Eight";
            WholeArray[9] = "Nine";

            TenArray[1] = "Ten";
            TenArray[2] = "Twenty";
            TenArray[3] = "Thirty";
            TenArray[4] = "Fourty";
            TenArray[5] = "Fifty";
            TenArray[6] = "Sixty";
            TenArray[7] = "Seventy";
            TenArray[8] = "Eighty";
            TenArray[9] = "Ninety";

            Eleven_to_NineTeen[1] = "Eleven";
            Eleven_to_NineTeen[2] = "Twelve";
            Eleven_to_NineTeen[3] = "Thirteen";
            Eleven_to_NineTeen[4] = "Fourteen";
            Eleven_to_NineTeen[5] = "Fifteen";
            Eleven_to_NineTeen[6] = "Sixteen";
            Eleven_to_NineTeen[7] = "Seventeen";
            Eleven_to_NineTeen[8] = "Eighteen";
            Eleven_to_NineTeen[9] = "Nineteen";

            CType = CurType.ToUpper();
            NotSingle = CuNum > 1 ? "s" : "";

            ICuNum = Convert.ToInt32(CuNum);
            DCuNum = Convert.ToDecimal((CuNum - ICuNum));
            KKn = DCuNum + 1;
            TDCuNum = KKn * 100;
            TDCuNum1 = TDCuNum.ToString();
            TDCuNum2 = TDCuNum1.Trim();
            XCuNum = TDCuNum2.Substring(1, 2);


            if (XCuNum == "00")
                Ctype2 = "";

            //For Tally Table
            for (int i = 0; i <= 1; i++)
            {
                ZLT = XCuNum.Substring(i, 1);
                NumArray[i] = Convert.ToInt32(ZLT);
            }

            Position = 0;



            Digit2 = Digit1;
            Digit1 = "";

            ACuNum = ICuNum.ToString();
            TCuNum = ACuNum.Trim();
            LCuNum = TCuNum.Length.ToString();

            if (LCuNum == "0")
            {
                Digit1 = Digit2 + Ctype2 + " Only";
                Cut_Ext = Digit1 + Sign_of_Amount;

                if (Cut_Ext.Trim() == "Only")
                    Cut_Ext = null;

            }

            for (int i = 0; i <= 12; i++)
            {
                NumArray[i] = 0;
            }

            switch (LCuNum)
            {
                case "1":
                    if (CuNum == 0)
                        Digit1 = Digit1;
                    else
                    {
                        ICuNum = Convert.ToInt32(ACuNum);
                        Digit1 = Digit1 + WholeArray[ICuNum];
                    }
                    Cut_Ext = Digit1 + Ctype1 + Digit2 + Ctype2 + " " + CType + " Only" + Sign_of_Amount;
                    if (Cut_Ext.Trim() == "Only")
                        Cut_Ext = null;
                    break;

                case "2":
                    Fill_NumArray();
                    Position = 0;
                    Check_Two_digit();
                    Cut_Ext = Digit1 + Ctype1 + Digit2 + Ctype2 + " " + CType + " Only" + Sign_of_Amount;
                    if (Cut_Ext.Trim() == "Only")
                        Cut_Ext = null;
                    break;

                case "3":
                    Fill_NumArray();
                    Position = 0;
                    Digit1 = Digit1 + WholeArray[NumArray[Position]] + Sign_of_Amount;
                    Position = Position + 1;
                    Check_Two_digit();
                    Cut_Ext = Digit1 + Ctype1 + Digit2 + Ctype2 + " " + CType + " Only" + Sign_of_Amount;
                    if (Cut_Ext.Trim() == "Only")
                        Cut_Ext = null;
                    break;

                case "4":
                    Fill_NumArray();
                    Position = 0;
                    Digit1 = Digit1 + WholeArray[NumArray[Position]] + " Thousand";
                    Position = Position + 1;
                    ChkHundred();
                    Position = Position + 1;
                    Check_and();
                    Cut_Ext = Digit1 + Ctype1 + Digit2 + Ctype2 + " " + CType + " Only " + Sign_of_Amount;
                    if (Cut_Ext.Trim() == "Only")
                        Cut_Ext = null;
                    break;

                case "5":
                    Fill_NumArray();
                    Position = 0;
                    Check_Two_digit();
                    Digit1 = Digit1 + " Thousand";
                    Position = Position + 2;
                    ChkHundred();
                    Position = Position + 1;
                    Check_and();
                    Cut_Ext = Digit1 + Ctype1 + Digit2 + Ctype2 + " " + CType + " Only " + Sign_of_Amount;
                    if (Cut_Ext.Trim() == "Only")
                        Cut_Ext = null;
                    break;

                case "6":
                    Fill_NumArray();
                    Position = 0;
                    Digit1 = Digit1 + WholeArray[NumArray[Position]] + " Hundred";
                    Position = Position + 1;
                    ChkThousandHundred();
                    Position = Position + 1;
                    Check_and();
                    Cut_Ext = Digit1 + Ctype1 + Digit2 + Ctype2 + " " + CType + " Only " + Sign_of_Amount;
                    if (Cut_Ext.Trim() == "Only")
                        Cut_Ext = null;
                    break;

                case "7":
                    Fill_NumArray();
                    Position = 0;
                    Digit1 = Digit1 + WholeArray[NumArray[Position]] + " Million";
                    Position = Position + 1;
                    if (NumArray[Position] == 0 && NumArray[Position + 1] == 0 && NumArray[Position + 2] == 0)
                    {
                        Digit1 = Digit1;
                        Position = Position + 3;
                        ChkHundred();
                        Position = Position + 1;
                        Check_and();
                        Cut_Ext = Digit1 + Ctype1 + Digit2 + Ctype2 + " " + CType + " Only" + Sign_of_Amount;
                        if (Cut_Ext.Trim() == "Only")
                            Cut_Ext = null;
                    }
                    ChkHundred();
                    Position = Position + 1;
                    ChkThousandHundred();
                    Position = Position + 1;
                    ChkPosition2();
                    Cut_Ext = Digit1 + Ctype1 + Digit2 + Ctype2 + " " + CType + " Only" + Sign_of_Amount;
                    if (Cut_Ext.Trim() == "Only")
                        Cut_Ext = null;
                    break;

                case "8":
                    Fill_NumArray();
                    Position = 0;
                    Check_Two_digit();
                    Digit1 = Digit1 + " Million";
                    Position = Position + 2;
                    if (NumArray[Position] == 0 && NumArray[Position + 1] == 0 && NumArray[Position + 2] == 0)
                    {
                        Digit1 = Digit1;
                        Position = Position + 3;
                        ChkHundred();
                        Position = Position + 1;
                        Check_and();
                        Cut_Ext = Digit1 + Ctype1 + Digit2 + Ctype2 + " " + CType + " Only" + Sign_of_Amount;
                        if (Cut_Ext.Trim() == "Only")
                            Cut_Ext = null;

                    }
                    ChkHundred();
                    Position = Position + 1;
                    ChkThousandHundred();
                    Position = Position + 1;
                    ChkPosition2();
                    Cut_Ext = Digit1 + Ctype1 + Digit2 + Ctype2 + " " + CType + " Only" + Sign_of_Amount;
                    if (Cut_Ext.Trim() == "Only")
                        Cut_Ext = null;
                    break;

                case "9":
                    Fill_NumArray();
                    Position = 0;
                    Digit1 = Digit1 + WholeArray[NumArray[Position]] + " Billion";
                    Position = Position + 1;
                    if (NumArray[Position] > 0 || NumArray[Position + 1] > 0)
                    {
                        Digit1 = Digit1 + ",";
                        Check_Two_digit();
                        Digit1 = Digit1 + " Million";

                    }
                    Position = Position + 2;
                    if (NumArray[Position] == 0 && NumArray[Position + 1] == 0 && NumArray[Position + 2] == 0)
                    {
                        Digit1 = Digit1;
                        Position = Position + 3;
                        ChkHundred();
                        Position = Position + 1;
                        Check_and();
                        Cut_Ext = Digit1 + Ctype1 + Digit2 + Ctype2 + " " + CType + " Only" + Sign_of_Amount;
                        if (Cut_Ext.Trim() == "Only")
                            Cut_Ext = null;
                    }
                    ChkHundred();
                    Position = Position + 1;
                    ChkThousandHundred();
                    Position = Position + 1;
                    ChkPosition2();
                    Cut_Ext = Digit1 + Ctype1 + Digit2 + Ctype2 + " " + CType + " Only" + Sign_of_Amount;
                    if (Cut_Ext.Trim() == "Only")
                        Cut_Ext = null;
                    break;

                case "10":
                    Fill_NumArray();
                    Position = 0;
                    Check_Two_digit();
                    Digit1 = Digit1 + " Billion";
                    Position = Position + 2;
                    if (NumArray[Position] == 0 && NumArray[Position + 1] == 0 && NumArray[Position + 2] == 0)
                    {
                        Digit1 = Digit1;
                        Position = Position + 3;
                        ChkHundred();
                        Position = Position + 1;
                        Check_and();
                        Cut_Ext = Digit1 + Ctype1 + Digit2 + Ctype2 + " " + CType + " Only" + Sign_of_Amount;
                        if (Cut_Ext.Trim() == "Only")
                            Cut_Ext = null;
                    }
                    ChkHundred();
                    Position = Position + 1;
                    ChkThousandHundred();
                    Position = Position + 1;
                    ChkPosition2();
                    Cut_Ext = Digit1 + Ctype1 + Digit2 + Ctype2 + " " + CType + " Only" + Sign_of_Amount;
                    if (Cut_Ext.Trim() == "Only")
                        Cut_Ext = null;
                    break;


            }
            return Cut_Ext;


        }

        //Check Remittance Register No
        private bool Checking_Remittance_Register(string RegisterNo,string remitType)
        {
            //string Error_Msg=null;
            bool IsRemittanceReg = false;

            if (RegisterNo.Trim() == "")
            {
                //Invalid Register No
            }
            RdDTO = CXClientWrapper.Instance.Invoke<IMNMSVE00021, TLMDTO00017>(x => x.GetDrawingData(RegisterNo,CurrentUserEntity.BranchCode));
            if(RdDTO != null)
            {
                IsRemittanceReg = true;

            }
            return IsRemittanceReg;
        }

        private bool Same_Type(string Type1, string Type2, string DrawBank1, string DrawBank2, string Cur1, string Cur2, ref string Error_Msg)
        {
            bool isSameType = false;

            if (Cur1.Trim() != "" && Cur2.Trim() != "" && Cur1.Trim() != Cur2.Trim())
            {
                Error_Msg = "Currency Should be the same.";
            }

            if (Type1.Trim() != "" && Type2.Trim() != "" && Type1.Trim() != Type2.Trim())
            {
                Error_Msg = "Remittance Type should be the same.";
            }

            if (DrawBank1.Trim() != "" && DrawBank2.Trim() != "" && DrawBank1.Trim() != DrawBank2.Trim())
            {
               
                Error_Msg = "Both Remittance Type and Drawee Banks should be the same.";
            }

            if (Error_Msg == null)
            {
                isSameType = true;
            }

            return isSameType;


        }

        private void Fill_NumArray()
        {
            string CCuNum;
            for (int i = 0; i < Convert.ToInt32(LCuNum); i++)
            {
                CCuNum = TCuNum.Substring(i, 1);
                NumArray[i] = Convert.ToInt32(CCuNum);
            }
        }

        private void Check_Two_digit()
        {
            if (NumArray[Position] > 0)
            {
                if (NumArray[Position + 1] == 0)
                {
                    Digit1 = Digit1 + TenArray[NumArray[Position]];
                }

                if (NumArray[Position + 1] > 0 && NumArray[Position] == 1)
                {
                    Digit1 = Digit1 + Eleven_to_NineTeen[NumArray[Position + 1]];
                }

                if (NumArray[Position + 1] > 0 && NumArray[Position] > 1)
                {
                    Digit1 = Digit1 + TenArray[NumArray[Position]] + WholeArray[NumArray[Position + 1]];
                }

            }
            else
            {
                Position = Position + 1;
                if (NumArray[Position] == 0)
                {
                    Digit1 = Digit1;
                }
                else
                {
                    Digit1 = Digit1 + WholeArray[NumArray[Position]];
                }

            }
        }

        private void Check_and()
        {
            if (NumArray[Position] > 0)
            {
                if (NumArray[Position + 1] == 0)
                    Digit1 = Digit1 + " and " + TenArray[NumArray[Position]];
                if (NumArray[Position + 1] > 0 && NumArray[Position] == 1)
                    Digit1 = Digit1 + " and " + Eleven_to_NineTeen[NumArray[Position + 1]];
                if (NumArray[Position + 1] > 0 && NumArray[Position] > 1)
                    Digit1 = Digit1 + " and " + TenArray[NumArray[Position]] + WholeArray[NumArray[Position + 1]];
            }
            else
            {
                Position = Position + 1;
                if (NumArray[Position] == 0)
                    Digit1 = Digit1;
                else
                    Digit1 = Digit1 + " and " + WholeArray[Position];

            }

        }

        private void ChkHundred()
        {
            if (NumArray[Position] > 0)
            {
                for (int i = Position + 1; i < Convert.ToInt32(LCuNum); i++)
                {
                    if (NumArray[i] > 0)
                        Zero = true;

                }

                if (Zero)
                    Digit1 = Digit1 + "," + WholeArray[NumArray[Position]] + " Hundred";
                else
                    Digit1 = Digit1 + " and " + WholeArray[NumArray[Position]] + " Hundred";

            }

            else
            {
                Digit1 = Digit1;
            }

        }

        private void ChkThousandHundred()
        {
            if (NumArray[Position] == 0)
            {
                Position = Position + 1;
                if (NumArray[Position] == 0)
                    Digit1 = Digit1 + " Thousand";
                else
                    Digit1 = Digit1 + " and " + WholeArray[NumArray[Position]] + " Thousand";
            }
            else
            {
                Check_and();
                Digit1 = Digit1 + " Thousand";
                ChkComma();
                Position = Position + 1;
            }
            Position = Position + 1;
            if (NumArray[Position] == 0)
                Digit1 = Digit1;
            else
                Digit1 = Digit1 + WholeArray[NumArray[Position]] + " Hundred";
        }

        private void ChkComma()
        {

        }

        private void ChkPosition2()
        {
            if (NumArray[Position] == 0)
            {
                Position = Position + 1;
                if (NumArray[Position] == 0)
                {
                    Digit1 = Digit1;
                }
                else
                    Digit1 = Digit1 + " and " + WholeArray[NumArray[Position]];
            }
            else
                Check_and();

        }

        private void InitializeControls()
        {
            for (int i = 0; i < 13; i++)
            {
                NumArray[i] = 0;
            }


            //DecArray = New Collection
            //Set WholeArray = New Collection
            //Set TensArray = New Collection
            //Set Eleven_to_NineTeen = New Collection
            Digit1 = "";
            Digit2 = "";
            Position = 0;
            Zero = false;

            Ctype = "";
            Ctype1 = "";
            Ctype2 = "";
            NotSingle = "";

            ICuNum = 0;
            DCuNum = 0;
            KKn = 0;
            TDCuNum = 0;
            TDCuNum1 = "";
            TDCuNum2 = "";
            XCuNum = "";

            ZLT = "";

            ACuNum = "";
            TCuNum = "";
            LCuNum = "0";
        }

        #endregion

    }
}
     
                 
        
   
  

      

