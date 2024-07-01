using System.Collections.Generic;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{   
    //joint DTO
    [System.Serializable]
    public class PFMDTO00049 : Supportfields<PFMDTO00049>
    {
        public PFMDTO00049() { }

        #region " Entities"
        private PFMDTO00033 balentity;
        public PFMDTO00033 BalEntity
        {
            get { return this.balentity; }
            set { this.balentity = value; }
        }

        private PFMDTO00017 caoflentity;
        public PFMDTO00017 CaOFEntity
        {
            get { return this.caoflentity; }
            set { this.caoflentity = value; }
        }

        private IList<PFMDTO00017> caofentities;
        public IList<PFMDTO00017> CaOFEntities
        {
            get { return this.caofentities; }
            set { this.caofentities = value; }
        }


        private PFMDTO00028 cledgerentity;
        public PFMDTO00028 CledgerEntity
        {
            get { return this.cledgerentity; }
            set { this.cledgerentity = value; }
        }

        private PFMDTO00016 saofentity;
        public PFMDTO00016 SAOFEntity
        {
            get { return this.saofentity; }
            set { this.saofentity = value; }
        }



        private IList<PFMDTO00016> saofentities;
        public IList<PFMDTO00016> SaOFEntities
        {
            get { return this.saofentities; }
            set { this.saofentities = value; }
        }


        private PFMDTO00040 sientity;
        public PFMDTO00040 SIEntity
        {
            get { return this.sientity; }
            set { this.sientity = value; }
        }

        private PFMDTO00006 chequeentity;
        public PFMDTO00006 ChequeEntity
        {
            get { return this.chequeentity; }
            set { this.chequeentity = value; }
        }

        private PFMDTO00021 faofentity;
        public PFMDTO00021 FAOFEntity
        {
            get { return this.faofentity; }
            set { this.faofentity = value; }
        }

        private IList<PFMDTO00021> faofentities;
        public IList<PFMDTO00021> FAOFEntities
        {
            get { return this.faofentities; }
            set { this.faofentities = value; }
        }

        private PFMDTO00032 freceiptentity;
        public PFMDTO00032 FReceiptEntity
        {
            get { return this.freceiptentity; }
            set { this.freceiptentity = value; }
        }

        private PFMDTO00023 fledgerentity;
        public PFMDTO00023 FledgerEntity
        {
            get { return this.fledgerentity; }
            set { this.fledgerentity = value; }
        }


        private PFMDTO00001 customerentity;
        public PFMDTO00001 CustomerEntity
        {

            get { return this.customerentity; }
            set { this.customerentity = value; }
        }

        private IList<PFMDTO00001> customerentities;
        public IList<PFMDTO00001> CustomerEntities
        {

            get { return this.customerentities; }
            set { this.customerentities = value; }
        }


        #endregion
    }
}
