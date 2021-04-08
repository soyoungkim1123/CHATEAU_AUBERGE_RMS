using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChateauAuberge.Model
{
    public class ReservationCreationEntity : BaseEntity
    {
        public Reservation Reservation { get; set; }
        public string ConfirmMessage { get; set; }
    }
}
