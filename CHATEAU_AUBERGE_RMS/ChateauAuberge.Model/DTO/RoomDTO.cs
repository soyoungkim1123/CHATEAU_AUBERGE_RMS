using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChateauAuberge.Model
{
    public class RoomDTO
    {
        public int RoomNumber { get; set; }

        public string RoomName { get; set; }

        public int MaxOccupancy { get; set; }

        public decimal BaseRate { get; set; }

        public string BedType { get; set; }

        public string RoomType { get; set; }
    }
}
