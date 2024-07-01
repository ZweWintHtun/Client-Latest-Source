using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Sam.Ctr.SVE;
using Ace.Cbs.Sam.Dmd.DTO;
using Ace.Windows.Admin.Contracts.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Sam.Sve
{
    public class SAMSVE00055 : BaseService, ISAMSVE00055
    {
        #region DAO
        private ITownshipDAO townshipCodeDAO;
        public ITownshipDAO TownshipCodeDAO
        {
            get { return this.townshipCodeDAO; }
            set { this.townshipCodeDAO = value; }
        }


        private IStateDAO stateCodeDAO;
        public IStateDAO StateCodeDAO
        {
            get { return this.stateCodeDAO; }
            set { this.stateCodeDAO = value; }
        }

        private ICityDAO cityCodeDAO;
        public ICityDAO CityCodeDAO
        {
            get { return this.cityCodeDAO; }
            set { this.cityCodeDAO = value; }
        }

        private IPFMDAO00003 initialDAO;
        public IPFMDAO00003 InitialDAO
        {
            get { return this.initialDAO; }
            set { this.initialDAO = value; }
        }

        private IPFMDAO00004 occupationCodeDAO;
        public IPFMDAO00004 OccupationCodeDAO
        {
            get { return this.occupationCodeDAO; }
            set { this.occupationCodeDAO = value; }
        }

        private IUserDAO userDAO;
        public IUserDAO UserDAO
        {
            get { return this.userDAO; }
            set { this.userDAO = value; }
        }
        #endregion


        #region Public Methods

        public string SelectUserName(int createdUserId)
        {
            UserDTO user = this.UserDAO.SelectById(createdUserId);
            if (user != null)
            {
                return user.UserName;
            }
            else
                return string.Empty;
 
        }
        public IList<PFMDTO00004> SelectOccupationListing()
        {
          return this.OccupationCodeDAO.SelectAll();            
        }

        public IList<StateDTO> SelectStateListing()
        {
            IList < StateDTO > state = this.StateCodeDAO.SelectAll();
            foreach (var item in state)
            {
                item.UserNo = this.SelectUserName(item.CreatedUserId);
            }

            return state;            
        }

        public IList<CityDTO> SelectCityListing()
        {

            IList<CityDTO> city = this.CityCodeDAO.SelectAll();
            foreach (var item in city)
            {
                item.UserNo = this.SelectUserName(item.CreatedUserId);
            }

            return city;            
        }

        public IList<TownshipDTO> SelectTownshipListing()
        {
            IList < TownshipDTO > township = this.TownshipCodeDAO.SelectAll();

            foreach (var item in township)
            {
                item.UserNo = this.SelectUserName(item.CreatedUserId);
            }
            return township;     
        }

        public IList<PFMDTO00003> SelectInitialListing()
        {
           return this.InitialDAO.SelectAll();
            
        }
        #endregion
    }
}
