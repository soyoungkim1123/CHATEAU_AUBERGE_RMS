using ChateauAuberge.Model;
using ChateauAuberge.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChateauAuberge.Service
{
    public class LookupsService
    {
        private LookupsRepo repo;

        public LookupsService()
        {
            repo = new LookupsRepo();
        }

        public List<CountryLookupsDTO> GetCountries()
        {
            return repo.RetreveCountriesList();
        }

        public List<StateLookupsDTO> GetStates(int countryId)
        {
            return repo.RetreveStatesList(countryId);
        }
        
    }
}
