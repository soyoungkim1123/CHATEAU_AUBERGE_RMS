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
    public class RoomRepo
    {
        private DataAccess db;

        public RoomRepo()
        {
            db = new DataAccess();
        }

        #region Methods

        public List<RoomDTO> SearchAvailableRoomByDate(DateTime startDate, DateTime endDate)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@StartDate", SqlDbType.DateTime2, 0, startDate, ParameterDirection.Input));
            parms.Add(new ParmStruct("@EndDate", SqlDbType.DateTime2, 0, endDate, ParameterDirection.Input));

            DataTable dt = db.GetData("spSearchAvailableRoom", parms);

            List<RoomDTO> availableRooms = new List<RoomDTO>();

            foreach (DataRow row in dt.Rows)
            {
                availableRooms.Add(
                    new RoomDTO
                    {
                       RoomNumber = Convert.ToInt32(row["RoomNumber"]),
                       RoomName = row["RoomName"].ToString()
                    }
                );
            }

            return availableRooms;
        }

        public RoomDTO GetRoomDetail(int roomNumber)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@RoomNumer", SqlDbType.Int, 0, roomNumber, ParameterDirection.Input));

            DataTable dt = db.GetData("spGetRoomDetail", parms);

            RoomDTO room = new RoomDTO();
            room.RoomNumber = Convert.ToInt32(dt.Rows[0]["RoomNumber"]);
            room.RoomName = dt.Rows[0]["RoomName"].ToString();
            room.MaxOccupancy = Convert.ToInt32(dt.Rows[0]["MaxOccupancy"]);
            room.BaseRate = Convert.ToDecimal(dt.Rows[0]["BaseRate"]);
            room.BedType = dt.Rows[0]["BedType"].ToString();
            room.RoomType = dt.Rows[0]["RoomType"].ToString();


            return room;
        }
        #endregion
    }
}
