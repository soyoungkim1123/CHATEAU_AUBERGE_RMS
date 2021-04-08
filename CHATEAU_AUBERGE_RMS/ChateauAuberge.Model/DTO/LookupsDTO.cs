using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChateauAuberge.Model
{
    public class BedTypeLookupsDTO
    {
        public int BedTypeId { get; set; }
        public string TypeDesc { get; set; }
    }

    public class RoomTypeLookupsDTO
    {
        public int RoomTypeId { get; set; }
        public string TypeDesc { get; set; }
    }

    public class CountryLookupsDTO
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }

    public class StateLookupsDTO
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
    }

}
