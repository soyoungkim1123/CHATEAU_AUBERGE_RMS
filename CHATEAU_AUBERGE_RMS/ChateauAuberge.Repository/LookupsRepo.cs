using ChateauAuberge.Model;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Types;

namespace ChateauAuberge.Repository
{
    public class LookupsRepo
    {
        private DataAccess db;
        public LookupsRepo()
        {
            db = new DataAccess();
        }

        public List<CountryLookupsDTO> RetreveCountriesList()
        {
            DataTable dt = db.GetData("spGetCountry");

            List<CountryLookupsDTO> countries = new List<CountryLookupsDTO>();

            foreach(DataRow row in dt.Rows)
            {
                countries.Add(
                    new CountryLookupsDTO
                    {
                        CountryId = Convert.ToInt32(row["CountryId"]),
                        CountryName = row["CountryName"].ToString()
                    }
                );
            }

            return countries;
        }

        public List<StateLookupsDTO> RetreveStatesList(int countryId)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@CountryId", SqlDbType.Int, 0, countryId, ParameterDirection.Input));

            DataTable dt = db.GetData("spGetStateByCountry", parms);

            List<StateLookupsDTO> states = new List<StateLookupsDTO>();

            foreach (DataRow row in dt.Rows)
            {
                states.Add(
                    new StateLookupsDTO
                    {
                        StateId = Convert.ToInt32(row["StateId"]),
                        StateName = row["StateName"].ToString()
                    }
                );
            }

            return states;
        }
    }
}
