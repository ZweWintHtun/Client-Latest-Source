using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// Saving Account Closing DTO
    /// </summary>
    [Serializable]
    public class PFMDTO00055 : Supportfields<PFMDTO00055>
    {
        private PFMDTO00028 cledgerEntity;
        public PFMDTO00028 CledgerEntity
        {
            get { return this.cledgerEntity; }
            set { this.cledgerEntity = value; }
        }

        private PFMDTO00054 tlfEntity;
        public PFMDTO00054 TlfEntity
        {
            get { return this.tlfEntity; }
            set { this.tlfEntity = value; }
        }

        private PFMDTO00002 closeBalEntity;
        public PFMDTO00002 CloseBalEntity
        {
            get { return this.closeBalEntity; }
            set { this.closeBalEntity = value; }
        }

        private PFMDTO00043 prnFileEntity;
        public PFMDTO00043 PrnFileEntity
        {
            get { return this.prnFileEntity; }
            set { this.prnFileEntity = value; }
        }

        private PFMDTO00033 balEntity;
        public PFMDTO00033 BalEntity
        {
            get { return this.balEntity; }
            set { this.balEntity = value; }
        }

        private PFMDTO00040 siEntity;
        public PFMDTO00040 SiEntity
        {
            get { return this.siEntity; }
            set { this.siEntity = value; }
        }

        private PFMDTO00016 saofEntity;
        public PFMDTO00016 SaofEntity
        {
            get { return this.saofEntity; }
            set { this.saofEntity = value; }
        }

        private PFMDTO00001 customerIdEntity;
        public PFMDTO00001 CustomerIdEntity
        {
            get { return this.customerIdEntity; }
            set { this.customerIdEntity = value; }
        }

    }
}
