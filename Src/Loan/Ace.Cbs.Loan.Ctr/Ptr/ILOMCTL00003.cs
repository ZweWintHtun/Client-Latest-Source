using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00003 : IPresenter
    {

        ILOMVEW00003 CharacterCodeView { set; get; }
        IList<LOMDTO00001> GetAll();
        void Save(LOMDTO00001 entity);
        void Delete(IList<LOMDTO00001> itemList);
        LOMDTO00001 SelectByCode(string characterCode);

    }

    public interface ILOMVEW00003
    {
        string CharacterCode { get; set; }
        string Description { get; set; }
        string Status { get; set; }

        LOMDTO00001 ViewData { get; set; }
        LOMDTO00001 PreviousCharacterCodeDto { get; set; }
        IList<LOMDTO00001> CharacterCodes { get; set; }
        ILOMCTL00003 Controller { set; get; }
        void Successful(string message);
        void Failure(string message);
    }
}
