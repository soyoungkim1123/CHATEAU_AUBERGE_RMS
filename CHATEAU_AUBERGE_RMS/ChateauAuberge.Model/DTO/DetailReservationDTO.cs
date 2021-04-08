using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChateauAuberge.Model
{
    public class DetailReservationDTO
    {
        public string GuestName { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int RoomNumber { get; set; }
        public string RoomName { get; set; }
        public int NumOfAdults { get; set; }
        public int NumOfChildren { get; set; }
        public decimal BaseRate { get; set; }
        public decimal DailyRate { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
