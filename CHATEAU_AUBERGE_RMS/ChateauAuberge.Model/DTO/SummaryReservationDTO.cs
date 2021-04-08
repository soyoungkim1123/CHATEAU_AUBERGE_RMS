using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChateauAuberge.Model
{
    public class SummaryReservationDTO
    {
        public DateTime ReservationDate { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public int RoomNumber { get; set; }

        public string GuestLastName { get; set; }

        public string ConfirmationNumber { get; set; }
    }
}
