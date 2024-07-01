using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Tcm.Dmd
{
     [Serializable]
    public class TCMDTO00052 : EntityBase<TCMDTO00052>
    {
        public TCMDTO00052() { }

        public TCMDTO00052(int id)
        {
            this.Id = id;
        }
        public TCMDTO00052(DateTime Date_time, string currency)
        {
            this.DATE_TIME = Date_time;
            this.CUR = currency;
        }

        public TCMDTO00052(string cur, decimal receiptCash, decimal receiptCashVou, decimal receiptTransfer, decimal receiptTransferVou, decimal receiptClearing, decimal receiptClearingVou, decimal paymentCash, decimal paymentCashVouch, decimal paymentTransfer, decimal paymentTransferVouch, decimal paymentclearing, decimal paymentclearingVouch, decimal drawingcash, decimal drawingcashVouch, decimal drawingTransfer, decimal drawingTransferVouch, decimal encashCash, decimal encashCashVouch, decimal encashTransfer, decimal encashTransferVou, decimal cashinHand, decimal cashwithCBM, decimal acwithotherBank, decimal curOpen, decimal curClose, decimal curTotal, decimal curObal, decimal curDesp, decimal curWith, decimal savOpen, decimal savClosed, decimal savTotal, decimal savObal, decimal savDep, decimal savWith, decimal calOpen, decimal calClose, decimal calTotal, decimal calObal, decimal calDep, decimal calWith, decimal fixOpen, decimal fixclosed, decimal fixtotal, decimal fixObal, decimal fixdep, decimal fixwith, DateTime datetime)
        {
            this.CUR = cur;
            this.RECEIPTCASH = receiptCash;
            this.RECEIPTCASHVOU = receiptCashVou;
            this.RECEIPTTRANSFER = receiptTransfer;
            this.RECEIPTTRANSFERVOU = receiptTransferVou;
            this.RECEIPTCLEARING = receiptClearing;
            this.RECEIPTCLEARINGVOU = receiptClearingVou;
            this.PAYMENTCASH = paymentCash;
            this.PAYMENTCASHVOU = paymentCashVouch;
            this.PAYMENTTRANSFER = paymentTransfer;
            this.PAYMENTTRANSFERVOU = paymentTransferVouch;
            this.PAYMENTCLEARING = paymentclearing;
            this.PAYMENTCLEARINGVOU = paymentclearingVouch;
            this.DRAWINGCASH = drawingcash;
            this.DRAWINGCASHVOU = drawingcashVouch;
            this.DRAWINGTRANSFER = drawingTransfer;
            this.DRAWINGTRANSFERVOU = drawingTransferVouch;
            this.ENCASHCASH = encashCash;
            this.ENCASHCASHVOU = encashCashVouch;
            this.ENCASHTRANSFER = encashTransfer;
            this.ENCASHTRANSFERVOU = encashTransferVou;
            this.CASHINHAND = cashinHand;
            this.CASHWITHCBM = cashwithCBM;
            this.ACWITHOTHBANK = acwithotherBank;
            this.CUROPENED = curOpen;
            this.CURCLOSED = curClose;
            this.CUROBAL = curObal;
            this.CURTOTAL = curTotal;
            this.CURDEP = curDesp;
            this.CURWITH = curWith;
            this.SAVOPENED = savOpen;
            this.SAVCLOSED = savClosed;
            this.SAVOBAL = savObal;
            this.SAVDEP = savDep;
            this.SAVWITH = savWith;
            this.CALOPENED = calOpen;
            this.CALCLOSED = calClose;
            this.CALOBAL = calObal;
            this.CALDEP = calDep;
            this.CALTOTAL = calTotal;
            this.CALWITH = calWith;
            this.FIXOPENED = fixOpen;
            this.FIXCLOSED = fixclosed;
            this.FIXDEP = fixdep;
            this.FIXOBAL = fixObal;
            this.FIXTOTAL = fixtotal;
            this.FIXWITH = fixwith;
            this.DATE_TIME = datetime;
        }

        public TCMDTO00052(string Cur, decimal ReceiptCash, decimal ReceiptCashVou, decimal ReceiptTransfer,
            decimal ReceiptTransferVou, decimal ReceiptClearing, decimal ReceiptClearingVou, decimal PaymentCash, decimal PaymentCashVou, decimal PaymentTransfer, decimal PaymentTransferVou, decimal PaymentClearing,
            decimal PaymentClearingVou, decimal DrawingCash, decimal DrawingCashVou, decimal DrawingTransfer, decimal DrawingTransferVou, decimal EncashCash, decimal EncashCashVou, decimal EncashTransfer, decimal EncashTransferVou,
            decimal CashInHand, decimal CashWithCBM, decimal ACWithOthBank, decimal CurOpened, decimal CurClosed, decimal CurTotal, decimal CurOBal, decimal CurDep, decimal CurWith, decimal SavOpened, decimal SavClosed,
            decimal SavTotal, decimal SavOBal, decimal SavDep, decimal SavWith, decimal CalOpened, decimal CalClosed,decimal CalTotal, decimal CalOBal, decimal CalDep, decimal CalWith, decimal FixOpened, decimal FixClosed,
            decimal FixTotal, decimal FixOBal, decimal FixDep, decimal FixWith, DateTime Date_Time, string D1_OtherLoan, string D1_CNGLoan, string D1_OD, string D1_StaffLoan, int B_OtherLoan, int B_CNGLoan, int B_OD, int B_StaffLoan,
            decimal R_0_OtherLoan, decimal R_0_CNGLoan, decimal R_0_OD, decimal R_0_StaffLoan, decimal R_1_OtherLoan, decimal R_1_CNGLoan, decimal R_1_OD, decimal R_1_StaffLoan, decimal R_2_OtherLoan,
            decimal R_2_CNGLoan, decimal R_2_OD, decimal R_2_StaffLoan, decimal A1_Outstanding, decimal A2_CNGLoan, decimal A3_OD, decimal A4_Outstanding)
        {
            this.CUR = Cur;
            this.RECEIPTCASH = ReceiptCash;
            this.RECEIPTCASHVOU = ReceiptCashVou;
            this.RECEIPTTRANSFER = ReceiptTransfer;
            this.RECEIPTTRANSFERVOU = ReceiptTransferVou;
            this.RECEIPTCLEARING = ReceiptClearing;
            this.RECEIPTCLEARINGVOU = ReceiptClearingVou;
            this.PAYMENTCASH = PaymentCash;
            this.PAYMENTCASHVOU = PaymentCashVou;
            this.PAYMENTTRANSFER = PaymentTransfer;
            this.PAYMENTTRANSFERVOU = PaymentTransferVou;
            this.PAYMENTCLEARING = PaymentClearing;
            this.PAYMENTCLEARINGVOU = PaymentClearingVou;
            this.DRAWINGCASH = DrawingCash;
            this.DRAWINGCASHVOU = DrawingCashVou;
            this.DRAWINGTRANSFER = DrawingTransfer;
            this.DRAWINGTRANSFERVOU = DrawingTransferVou;
            this.ENCASHCASH =EncashCash;
            this.ENCASHCASHVOU = EncashCashVou;
            this.ENCASHTRANSFER = EncashTransfer;
            this.ENCASHTRANSFERVOU = EncashTransferVou;
            this.CASHINHAND = CashInHand;
            this.CASHWITHCBM = CashWithCBM;
            this.ACWITHOTHBANK = ACWithOthBank;
            this.CUROPENED = CurOpened;
            this.CURCLOSED = CurClosed;
            this.CURTOTAL = CurTotal;
            this.CUROBAL = CurOBal;
            this.CURDEP = CurDep;
            this.CURWITH = CurWith;
            this.SAVOPENED = SavOpened;
            this.SAVCLOSED = SavClosed;
            this.SAVTOTAL = SavTotal;
            this.SAVOBAL = SavOBal;
            this.SAVDEP = SavDep;
            this.SAVWITH = SavWith;
            this.CALOPENED = CalOpened;
            this.CALCLOSED = CalClosed;
            this.CALTOTAL = CalTotal;
            this.CALOBAL = CalOBal;
            this.CALDEP = CalDep;
            this.CALWITH = CalWith;
            this.FIXOPENED = FixOpened;
            this.FIXCLOSED = FixClosed;
            this.FIXTOTAL = FixTotal;
            this.FIXOBAL = FixOBal;
            this.FIXDEP = FixDep;
            this.FIXWITH = FixWith;
            this.DATE_TIME = Date_Time;
            this.D1_OTHERLOAN = D1_OtherLoan;
            this.D1_CNGLOAN = D1_OtherLoan;
            this.D1_OD = D1_OD;
            this.D1_STAFFLOAN = D1_StaffLoan;
            this.B_OTHERLOAN = B_OtherLoan;
            this.B_CNGLOAN = B_CNGLoan;
            this.B_OD = B_OD;
            this.B_STAFFLOAN = B_StaffLoan;
            this.R_0_OTHERLOAN = R_0_OtherLoan;
            this.R_0_CNGLOAN = R_0_CNGLoan;
            this.R_0_OD = R_0_OD;
            this.R_0_STAFFLOAN = R_0_StaffLoan;
            this.R_1_OTHERLOAN = R_1_OtherLoan;
            this.R_1_CNGLOAN = R_1_CNGLoan;
            this.R_1_OD = R_1_OD;
            this.R_1_STAFFLOAN = R_1_StaffLoan;
            this.R_2_OTHERLOAN = R_2_OtherLoan;
            this.R_2_CNGLOAN = R_2_CNGLoan;
            this.R_2_OD = R_2_OD;
            this.R_2_STAFFLOAN = R_2_StaffLoan;
            this.A1_OUTSTANDING = A1_Outstanding;
            this.A2_CNGLOAN = A2_CNGLoan;
            this.A3_OD = A3_OD;
            this.A4_OUTSTANDING = A4_Outstanding;
        }

        public TCMDTO00052(string Cur, decimal ReceiptCash, decimal ReceiptCashVou, decimal ReceiptTransfer,
            decimal ReceiptTransferVou, decimal ReceiptClearing, decimal ReceiptClearingVou, decimal PaymentCash,
            decimal PaymentCashVou, decimal PaymentTransfer, decimal PaymentTransferVou, decimal PaymentClearing,
            decimal PaymentClearingVou, decimal DrawingCash, decimal DrawingCashVou, decimal DrawingTransfer,
            decimal DrawingTransferVou, decimal EncashCash, decimal EncashCashVou, decimal EncashTransfer, decimal EncashTransferVou,
            decimal CashInHand, decimal CashWithCBM, decimal ACWithOthBank, decimal CurOpened, decimal CurClosed,
            decimal CurTotal, decimal CurOBal, decimal CurDep, decimal CurWith, decimal SavOpened, decimal SavClosed,
            decimal SavTotal, decimal SavOBal, decimal SavDep, decimal SavWith, decimal CalOpened, decimal CalClosed,
            decimal CalTotal, decimal CalOBal, decimal CalDep, decimal CalWith, decimal FixOpened, decimal FixClosed,
            decimal FixTotal, decimal FixOBal, decimal FixDep, decimal FixWith)
        {
            this.CUR = Cur;
            this.RECEIPTCASH = ReceiptCash;
            this.RECEIPTCASHVOU = ReceiptCashVou;
            this.RECEIPTTRANSFER = ReceiptTransfer;
            this.RECEIPTTRANSFERVOU = ReceiptTransferVou;
            this.RECEIPTCLEARING = ReceiptClearing;
            this.RECEIPTCLEARINGVOU = ReceiptClearingVou;
            this.PAYMENTCASH = PaymentCash;
            this.PAYMENTCASHVOU = PaymentCashVou;
            this.PAYMENTTRANSFER = PaymentTransfer;
            this.PAYMENTTRANSFERVOU = PaymentTransferVou;
            this.PAYMENTCLEARING = PaymentClearing;
            this.PAYMENTCLEARINGVOU = PaymentClearingVou;
            this.DRAWINGCASH = DrawingCash;
            this.DRAWINGCASHVOU = DrawingCashVou;
            this.DRAWINGTRANSFER = DrawingTransfer;
            this.DRAWINGTRANSFERVOU = DrawingTransferVou;
            this.ENCASHCASH = EncashCash;
            this.ENCASHCASHVOU = EncashCashVou;
            this.ENCASHTRANSFER = EncashTransfer;
            this.ENCASHTRANSFERVOU = EncashTransferVou;
            this.CASHINHAND = CashInHand;
            this.CASHWITHCBM = CashWithCBM;
            this.ACWITHOTHBANK = ACWithOthBank;
            this.CUROPENED = CurOpened;
            this.CURCLOSED = CurClosed;
            this.CURTOTAL = CurTotal;
            this.CUROBAL = CurOBal;
            this.CURDEP = CurDep;
            this.CURWITH = CurWith;
            this.SAVOPENED = SavOpened;
            this.SAVCLOSED = SavClosed;
            this.SAVTOTAL = SavTotal;
            this.SAVOBAL = SavOBal;
            this.SAVDEP = SavDep;
            this.SAVWITH = SavWith;
            this.CALOPENED = CalOpened;
            this.CALCLOSED = CalClosed;
            this.CALTOTAL = CalTotal;
            this.CALOBAL = CalOBal;
            this.CALDEP = CalDep;
            this.CALWITH = CalWith;
            this.FIXOPENED = FixOpened;
            this.FIXCLOSED = FixClosed;
            this.FIXTOTAL = FixTotal;
            this.FIXOBAL = FixOBal;
            this.FIXDEP = FixDep;
            this.FIXWITH = FixWith;
        }

        public TCMDTO00052(string Cur, decimal ReceiptCash, decimal ReceiptCashVou, decimal ReceiptTransfer,
            decimal ReceiptTransferVou, decimal ReceiptClearing, decimal ReceiptClearingVou, decimal PaymentCash,
            decimal PaymentCashVou, decimal PaymentTransfer, decimal PaymentTransferVou, decimal PaymentClearing,
            decimal PaymentClearingVou, decimal DrawingCash, decimal DrawingCashVou, decimal DrawingTransfer,
            decimal DrawingTransferVou, decimal EncashCash, decimal EncashCashVou, decimal EncashTransfer, decimal EncashTransferVou,
            decimal CashInHand, decimal CashWithCBM, decimal ACWithOthBank, decimal CurOpened, decimal CurClosed,
            decimal CurTotal, decimal CurOBal, decimal CurDep, decimal CurWith, decimal SavOpened, decimal SavClosed,
            decimal SavTotal, decimal SavOBal, decimal SavDep, decimal SavWith, decimal CalOpened, decimal CalClosed,
            decimal CalTotal, decimal CalOBal, decimal CalDep, decimal CalWith, decimal FixOpened, decimal FixClosed,
            decimal FixTotal, decimal FixOBal, decimal FixDep, decimal FixWith, DateTime Date_Time, bool Active, DateTime CreatedUserdate,
            int CreatedUserID, DateTime UpdatedUserdate, int UpdatedUserID)
        {
            this.CUR = Cur;
            this.RECEIPTCASH = ReceiptCash;
            this.RECEIPTCASHVOU = ReceiptCashVou;
            this.RECEIPTTRANSFER = ReceiptTransfer;
            this.RECEIPTTRANSFERVOU = ReceiptTransferVou;
            this.RECEIPTCLEARING = ReceiptClearing;
            this.RECEIPTCLEARINGVOU = ReceiptClearingVou;
            this.PAYMENTCASH = PaymentCash;
            this.PAYMENTCASHVOU = PaymentCashVou;
            this.PAYMENTTRANSFER = PaymentTransfer;
            this.PAYMENTTRANSFERVOU = PaymentTransferVou;
            this.PAYMENTCLEARING = PaymentClearing;
            this.PAYMENTCLEARINGVOU = PaymentClearingVou;
            this.DRAWINGCASH = DrawingCash;
            this.DRAWINGCASHVOU = DrawingCashVou;
            this.DRAWINGTRANSFER = DrawingTransfer;
            this.DRAWINGTRANSFERVOU = DrawingTransferVou;
            this.ENCASHCASH = EncashCash;
            this.ENCASHCASHVOU = EncashCashVou;
            this.ENCASHTRANSFER = EncashTransfer;
            this.ENCASHTRANSFERVOU = EncashTransferVou;
            this.CASHINHAND = CashInHand;
            this.CASHWITHCBM = CashWithCBM;
            this.ACWITHOTHBANK = ACWithOthBank;
            this.CUROPENED = CurOpened;
            this.CURCLOSED = CurClosed;
            this.CURTOTAL = CurTotal;
            this.CUROBAL = CurOBal;
            this.CURDEP = CurDep;
            this.CURWITH = CurWith;
            this.SAVOPENED = SavOpened;
            this.SAVCLOSED = SavClosed;
            this.SAVTOTAL = SavTotal;
            this.SAVOBAL = SavOBal;
            this.SAVDEP = SavDep;
            this.SAVWITH = SavWith;
            this.CALOPENED = CalOpened;
            this.CALCLOSED = CalClosed;
            this.CALTOTAL = CalTotal;
            this.CALOBAL = CalOBal;
            this.CALDEP = CalDep;
            this.CALWITH = CalWith;
            this.FIXOPENED = FixOpened;
            this.FIXCLOSED = FixClosed;
            this.FIXTOTAL = FixTotal;
            this.FIXOBAL = FixOBal;
            this.FIXDEP = FixDep;
            this.FIXWITH = FixWith;
            this.DATE_TIME = Date_Time;
            this.Active = Active;
            this.CreatedDate = CreatedUserdate;
            this.CreatedUserId = CreatedUserID;
            this.UpdatedDate = UpdatedUserdate;
            this.UpdatedUserId = UpdatedUserID;
        }

        public virtual string CUR { get; set; }
        public virtual decimal RECEIPTCASH { get; set; }
        public virtual decimal RECEIPTCASHVOU { get; set; }
        public virtual decimal RECEIPTTRANSFER { get; set; }
        public virtual decimal RECEIPTTRANSFERVOU { get; set; }
        public virtual decimal RECEIPTCLEARING { get; set; }
        public virtual decimal RECEIPTCLEARINGVOU { get; set; }
        public virtual decimal PAYMENTCASH { get; set; }
        public virtual decimal PAYMENTCASHVOU { get; set; }
        public virtual decimal PAYMENTTRANSFER { get; set; }
        public virtual decimal PAYMENTTRANSFERVOU { get; set; }
        public virtual decimal PAYMENTCLEARING { get; set; }
        public virtual decimal PAYMENTCLEARINGVOU { get; set; }
        public virtual decimal DRAWINGCASH { get; set; }
        public virtual decimal DRAWINGCASHVOU { get; set; }
        public virtual decimal DRAWINGTRANSFER { get; set; }
        public virtual decimal DRAWINGTRANSFERVOU { get; set; }
        public virtual decimal ENCASHCASH { get; set; }
        public virtual decimal ENCASHCASHVOU { get; set; }
        public virtual decimal ENCASHTRANSFER { get; set; }
        public virtual decimal ENCASHTRANSFERVOU { get; set; }
        public virtual decimal CASHINHAND { get; set; }
        public virtual decimal CASHWITHCBM { get; set; }
        public virtual decimal ACWITHOTHBANK { get; set; }
        public virtual decimal CUROPENED { get; set; }
        public virtual decimal CURCLOSED { get; set; }
        public virtual decimal CURTOTAL { get; set; }
        public virtual decimal CUROBAL { get; set; }
        public virtual decimal CURDEP { get; set; }
        public virtual decimal CURWITH { get; set; }
        public virtual decimal SAVOPENED { get; set; }
        public virtual decimal SAVCLOSED { get; set; }
        public virtual decimal SAVTOTAL { get; set; }
        public virtual decimal SAVOBAL { get; set; }
        public virtual decimal SAVDEP { get; set; }
        public virtual decimal SAVWITH { get; set; }
        public virtual decimal CALOPENED { get; set; }
        public virtual decimal CALCLOSED { get; set; }
        public virtual decimal CALTOTAL { get; set; }
        public virtual decimal CALOBAL { get; set; }
        public virtual decimal CALDEP { get; set; }
        public virtual decimal CALWITH { get; set; }
        public virtual decimal FIXOPENED { get; set; }
        public virtual decimal FIXCLOSED { get; set; }
        public virtual decimal FIXTOTAL { get; set; }
        public virtual decimal FIXOBAL { get; set; }
        public virtual decimal FIXDEP { get; set; }
        public virtual decimal FIXWITH { get; set; }
        public virtual DateTime DATE_TIME { get; set; }
        public virtual string D1_OTHERLOAN { get; set; }
        public virtual string D1_CNGLOAN { get; set; }
        public virtual string D1_OD { get; set; }
        public virtual string D1_STAFFLOAN { get; set; }
        public virtual Int32 B_OTHERLOAN { get; set; }
        public virtual Int32 B_CNGLOAN { get; set; }
        public virtual Int32 B_OD { get; set; }
        public virtual Int32 B_STAFFLOAN { get; set; }
        public virtual decimal R_0_OTHERLOAN { get; set; }
        public virtual decimal R_0_CNGLOAN { get; set; }
        public virtual decimal R_0_OD { get; set; }
        public virtual decimal R_0_STAFFLOAN { get; set; }
        public virtual decimal R_1_OTHERLOAN { get; set; }
        public virtual decimal R_1_CNGLOAN { get; set; }
        public virtual decimal R_1_OD { get; set; }
        public virtual decimal R_1_STAFFLOAN { get; set; }
        public virtual decimal R_2_OTHERLOAN { get; set; }
        public virtual decimal R_2_CNGLOAN { get; set; }
        public virtual decimal R_2_OD { get; set; }
        public virtual decimal R_2_STAFFLOAN { get; set; }
        public virtual decimal A1_OUTSTANDING { get; set; }
        public virtual decimal A2_CNGLOAN { get; set; }
        public virtual decimal A3_OD { get; set; }
        public virtual decimal A4_OUTSTANDING { get; set; }
    }
}
