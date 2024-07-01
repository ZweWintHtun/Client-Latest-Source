using Ace.Cbs.Pfm.Dmd;
namespace Ace.Cbs.Pfm.Ctr.Sve
{
    //Passbook->Transitiion Printing ( PrnFile Service )
    public interface IPFMSVE00008
    {
        PFMDTO00016 Save(PFMDTO00045 Entity);
    }
}