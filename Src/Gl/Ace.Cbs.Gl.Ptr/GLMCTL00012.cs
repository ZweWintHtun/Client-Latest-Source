using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Ser;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Gl.Ctr.Sve;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Gl.Ctr.Ptr;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Gl.Ptr
{
    public class GLMCTL00012 : AbstractPresenter, IGLMCTL00012
    {
        IList<ChargeOfAccountDTO> DTOList { get; set; }
        string aCode { get; set; }

        private IGLMVEW00012 view;
        public IGLMVEW00012 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(IGLMVEW00012 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetEntity());
            }
        }
                
        public ChargeOfAccountDTO GetEntity()
        {
            ChargeOfAccountDTO ViewData = new ChargeOfAccountDTO();
            ViewData.AccountName = this.View.PLAccount;
            ViewData.AccountNo = this.View.PITAccount;

            return ViewData;
        }

        public override bool ValidateForm(object validationContext)
        {
            return base.ValidateForm(validationContext);
        } 

        public IList<ChargeOfAccountDTO> SelectCOAData()
        {
            DTOList = CXClientWrapper.Instance.Invoke<IGLMSVE00012, IList<ChargeOfAccountDTO>>(x => x.SelectCOAAccountNameByACTypeL());

            IList<ChargeOfAccountDTO> COADTOList = new List<ChargeOfAccountDTO>();
            
            foreach(ChargeOfAccountDTO dto in DTOList)
            {
                if (dto.ACode != aCode)
                {
                    ChargeOfAccountDTO BindDTO = new ChargeOfAccountDTO();

                    BindDTO.ACode = dto.ACode;
                    BindDTO.DCODE = dto.DCODE;
                    aCode = dto.ACode;

                    COADTOList.Add(BindDTO);
                }                
            }

            return COADTOList;
        }

        public IList<ChargeOfAccountDTO> SelectCOADataByAcode(string acode)
        {
            IList<ChargeOfAccountDTO> DTODataList = CXClientWrapper.Instance.Invoke<IGLMSVE00012, IList<ChargeOfAccountDTO>>(x => x.SelectCOAAccountNameByACode(acode));

            return DTODataList;
        }

        public void clickonOK()
        {
            if (this.ValidateForm(GetEntity()))
            {
                CXUIScreenTransit.Transit("frmGLMVEW00006.ReportStatement", true, new object[] { });
            }
        }
    }
}
