using ChateauAuberge.Model;
using ChateauAuberge.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChateauAuberge.Service
{
    public class RoomService
    {
        private RoomRepo repo;

        public RoomService()
        {
            repo = new RoomRepo();
        }

        public List<RoomDTO> SearchAvailableRoomByDate(DateTime startDate, DateTime endDate)
        {
            return repo.SearchAvailableRoomByDate(startDate, endDate);
        }

        public RoomDTO GetRoomDetail(int roomNumber)
        {
            return repo.GetRoomDetail(roomNumber);
        }
    }
}
