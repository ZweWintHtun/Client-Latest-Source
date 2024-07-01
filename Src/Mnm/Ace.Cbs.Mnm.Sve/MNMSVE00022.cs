using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Mnm.Sve
{
    public class MNMSVE00022 : BaseService, IMNMSVE00022
    {
        string M_Type1, M_Type2;
        string RegCur1, RegCur2;
        string Error_Msg;
        string LCuNum, TCuNum, Ctype, CType;
        int Position, ICuNum;
        bool Zero;
        string NotSingle;
        string Ctype2, Ctype1;
        decimal DCuNum, KKn, TDCuNum;
        string TDCuNum2, TDCuNum1, XCuNum, ZLT, ACuNum;
        string In_Word1 = null, In_Word2 = null;
        string Sign_of_Amount = null;
        string[] WholeArray = new string[10];
        string[] TenArray = new string[10];
        string[] Eleven_to_NineTeen = new string[10];
        int[] NumArray = new int[13];
        string Digit1, Digit2;
        string Cut_Ext;  

        ITLMDAO00017 RDDAO { get; set; }
        ITLMDAO00021 DrawingPrintingDAO { get; set; }
        ITLMDAO00009 DepoDenoDAO { get; set; }

        public TLMDTO00017 GetRDInfo(string registerNo, string sourceBr)
        {
            return this.RDDAO.SelectByRegisterNo(registerNo, sourceBr);
        }

        [Transaction(TransactionPropagation.Required)]
        public TLMDTO00017 UpdateRDInfo(TLMDTO00017 entity, int workstationId)
        {
            try
            {
                //Update RD Personal Info
                this.RDDAO.UpdateRDPersonalInformation(entity.Name, entity.NRC, entity.Address, entity.PhoneNo, entity.Narration, entity.ToAccountNo, entity.ToName, entity.ToNRC, entity.ToAddress, entity.ToPhoneNo, entity.UpdatedUserId.Value, entity.RegisterNo, entity.SourceBranchCode);
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MC90003"; //Update Fail. Try Again?
                throw new Exception(this.ServiceResult.MessageCode);
            }

            TLMDTO00017 returnEntity = this.RDDAO.SelectByRegisterNo(entity.RegisterNo, entity.SourceBranchCode);
            returnEntity.AmountByLetter = this.AmountDesp(returnEntity.Amount.Value, entity.Currency);
            entity.AmountByLetter = returnEntity.AmountByLetter;

            //Delete DrawingPrinting
            this.DrawingPrintingDAO.DeleteByWorkStation(workstationId.ToString(), entity.SourceBranchCode);
            //Insert DrawingPrinting
            this.DrawingPrintingDAO.Save(this.ConvertToDrawingPrintingORM(entity, workstationId));

            string groupNo = this.DepoDenoDAO.SelectGroupNoByAcType(entity.RegisterNo, entity.SourceBranchCode);
            returnEntity.GroupNo = groupNo;

            return returnEntity;


        }

        #region Methods For DrawingPrinting
        public string AmountDesp(decimal CuNum, string CurType)
        {
            Initialize();
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

        private void Initialize()
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

        private TLMORM00021 ConvertToDrawingPrintingORM(TLMDTO00017 entity, int workstationId)
        {
            TLMORM00021 drawingPrintORM = new TLMORM00021();
            drawingPrintORM.Id = this.DrawingPrintingDAO.SelectMaxId() + 1;
            drawingPrintORM.RegisterNo = entity.RegisterNo;
            drawingPrintORM.RAmount = entity.AmountByLetter;
            drawingPrintORM.WorkStation = workstationId.ToString();
            drawingPrintORM.SourceBranchCode = entity.SourceBranchCode;
            drawingPrintORM.UniqueId = null;
            drawingPrintORM.Active = true;
            drawingPrintORM.CreatedDate = DateTime.Now;
            drawingPrintORM.CreatedUserId = entity.UpdatedUserId.Value;

            return drawingPrintORM;
        }
        #endregion
    }
}
