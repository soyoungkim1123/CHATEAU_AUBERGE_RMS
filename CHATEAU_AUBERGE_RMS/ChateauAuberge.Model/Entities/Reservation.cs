using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChateauAuberge.Model
{
    public class Reservation : BaseEntity
    {

        [Required(ErrorMessage = "Check in date is required")]
        public DateTime CheckInDate { get; set; }

        [Required(ErrorMessage = "Check out date is required")]
        public DateTime CheckOutDate { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "At least one adult guest is required.")]
        public int NumOfAdults { get; set; }

        public int NumOfChildren { get; set; }

        public int RoomNumber { get; set; }

        public int ClerkId { get; set; }

        public Guest Guest { get; set; }
       
    }
}
