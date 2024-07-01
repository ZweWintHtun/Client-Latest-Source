using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Gl.Dmd
{
    [Serializable]
    public class GLMDTO00028
    {
        public GLMDTO00028() { }

        public GLMDTO00028(string acode, string sfpType)
        {
            this.ACode = acode;
            this.SFPType = sfpType;
        }
        
        // Updated by ZMS (25-Jun-2018)
        // Added By AAM(06-Mar-2018)
        public GLMDTO00028(int id,string acType, string desp,string subType,decimal amt)
        {
            this.Id = id;
            ACType = acType;
            rptDesp = desp;
            SubACType = subType;
            Amount = amt;
        }
        public int Id { get; set; }

        public virtual string RequireYear { get; set; }
        public virtual string RequireMonth { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }

        //Assets
        public virtual decimal PPEAmt { get; set; } //Property, plant & equipment
        public virtual decimal SNEAmt { get; set; } //Software & Network Equipment
        public virtual decimal LAmt { get; set; }//Loans //Added by HWKO (22-Dec-2017)
        public virtual decimal HPAmt { get; set; }//HirePurchase //Added by HWKO (22-Dec-2017)
        public virtual decimal ODAmt { get; set; } //Overdraft //Added by HWKO (01-Dec-2017)
        public virtual decimal OSAmt { get; set; }  //Other Assets
        public virtual decimal CCEAmt { get; set; } //Cash & Cash Equipment
        public virtual decimal ICRAmt { get; set; } //Inter Company Receivable

        //Equity and liabilities
        public virtual decimal PUCAmt { get; set; } //Paid Up Capital
        public virtual decimal ORAmt { get; set; }  //Other reserves
        //public virtual decimal CRAmt { get; set; }  //Capital Reserve
        public virtual decimal REAmt { get; set; }  //Retained Earnings
        public virtual decimal PLAmt { get; set; }  //Profit/(Loss)

        //Current Liabilities
        public virtual decimal SDAOPAmt { get; set; } //Sundry Deposit and other payables
        //public virtual decimal STBAMT { get; set; }   //Short-term borrowing

        public virtual string ACode { get; set; }
        public virtual string SFPType { get; set; }

        // Added By AAM (06-Mar-2018)
        public string ACType { get; set; }
        public string rptDesp { get; set; }
        public string SubACType { get; set; }
        public decimal Amount { get; set; }
        public decimal LHIAmt { get; set; }

        // Added By ZMS (04.12.2018)
        public virtual string LastDayofRequirementMonth{ get; set; }
    }    
}
