using System;
using System.Drawing;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.CXClient;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Ctr.PTR
{
    //CustomerId Controller Interface
    public interface IPFMCTL00004 : IPresenter
    {
        IPFMVEW00004 CustomerIdView { set; get; }
        bool Save(PFMDTO00001 entity);
        bool Update(PFMDTO00001 custEntity, PFMDTO00010 custphotoEntity);
        PFMDTO00001 SelectByCustomerId(string customerid);
        void AddCustomer();
        void ClearCustomErrorMessage();

        //PFMDTO00080 CheckNRCForExternalBlackListCustomer(string NRC);
    }

    //CustomerId View Interface
    public interface IPFMVEW00004
    {
        string CustomerId { get; set; }
        string NRC { get; set; }

        string NRCNo { get; set; }
        string NationalityCodeForNRC { get; set; }
        string TownshipCodeForNRC { get; set; }
        string StateCodeForNRC { get; set; }

        string FatherNRCNo { get; set; }
        string FatherNationalityCodeForNRC { get; set; }
        string FatherTownshipCodeForNRC { get; set; }
        string FatherStateCodeForNRC { get; set; }

        string Name { get; set; }
        string GuardianName { get; set; }
        string GuardianNRCNo { get; set; }
        string FatherName { get; set; }
        string Address { get; set; }
        string PhoneNo { get; set; }
        string FaxNo { get; set; }
        string Email { get; set; }
        Image Photo { get; set; }
        Image Signature { get; set; }
        bool IsVIP { get; set; }
        string Gender { get; set; }
        string Remark { get; set; }
        string NameOnly { get; set; }
        string PassportNo { get; set; }
        DateTime DateOfBirth { get; set; }
        string NickName { get; set; }
        string CityCode { get; set; }
        string StateCode { get; set; }
        string TownshipCode { get; set; }
        string Initial { get; set; }
        string OccupationCode { get; set; }
        //string NationalityCode { get; set; }  //edit by ASDA
        string Nationality { get; set; }
        PFMDTO00001 ViewData { get; set; }
        IPFMCTL00004 CustomerIdController { set; get; }
        void Successful(string message, string customerId);
        void Failure(string message);
        void RebindCustomerId(string customerId);
        void RebindCustomerInformation(PFMDTO00001 customerId);
        FormState FormState { set; get; }
        bool IsValidateLessThan18 { get; set; }
        bool IsValidateGreaterThan18 { get; set; }
        bool IsInitialStateForNRC { get; set; }
        bool IsInitialStateForFatherNRC { get; set; }
        string NRCCode();

        void ClearNRC();
    }
}