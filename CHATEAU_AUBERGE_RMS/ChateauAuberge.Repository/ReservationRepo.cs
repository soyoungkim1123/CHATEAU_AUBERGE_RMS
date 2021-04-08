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
    public class ReservationRepo
    {
        private DataAccess db;

        public ReservationRepo()
        {
            db = new DataAccess();
        }

        #region Methods
        public List<SummaryReservationDTO> RetrieveReservationList()
        {
            DataTable dt = db.GetData("spRetrieveReservationList");
            
            List<SummaryReservationDTO> reservations = new List<SummaryReservationDTO>();

            foreach(DataRow row in dt.Rows)
            {
                reservations.Add(
                    new SummaryReservationDTO
                    {
                        ReservationDate = Convert.ToDateTime(row["ReservationDate"]),
                        CheckInDate = Convert.ToDateTime(row["CheckInDate"]),
                        CheckOutDate = Convert.ToDateTime(row["CheckOutDate"]),
                        RoomNumber = Convert.ToInt32(row["RoomNumber"]),
                        GuestLastName = row["LastName"].ToString(),
                        ConfirmationNumber = row["ConfirmationNumber"].ToString()
                    }
                );
            }

            return reservations;
        }

        public List<SummaryReservationDTO> RetrieveReservationListByDate(DateTime date)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@Date", SqlDbType.DateTime2, 0, date, ParameterDirection.Input));

            DataTable dt = db.GetData("spRetrieveReservationByDate", parms);

            List<SummaryReservationDTO> reservations = new List<SummaryReservationDTO>();

            foreach (DataRow row in dt.Rows)
            {
                reservations.Add(
                    new SummaryReservationDTO
                    {
                        ReservationDate = Convert.ToDateTime(row["ReservationDate"]),
                        CheckInDate = Convert.ToDateTime(row["CheckInDate"]),
                        CheckOutDate = Convert.ToDateTime(row["CheckOutDate"]),
                        RoomNumber = Convert.ToInt32(row["RoomNumber"]),
                        GuestLastName = row["LastName"].ToString(),
                        ConfirmationNumber = row["ConfirmationNumber"].ToString()
                    }
                );
            }

            return reservations;
        }

        public List<SummaryReservationDTO> RetrieveReservationListByRoomNumber(int roomNumber)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@RoomNumber", SqlDbType.Int, 0, roomNumber, ParameterDirection.Input));

            DataTable dt = db.GetData("spRetrieveReservationByRoomNumber", parms);

            List<SummaryReservationDTO> reservations = new List<SummaryReservationDTO>();

            foreach (DataRow row in dt.Rows)
            {
                reservations.Add(
                    new SummaryReservationDTO
                    {
                        ReservationDate = Convert.ToDateTime(row["ReservationDate"]),
                        CheckInDate = Convert.ToDateTime(row["CheckInDate"]),
                        CheckOutDate = Convert.ToDateTime(row["CheckOutDate"]),
                        RoomNumber = Convert.ToInt32(row["RoomNumber"]),
                        GuestLastName = row["LastName"].ToString(),
                        ConfirmationNumber = row["ConfirmationNumber"].ToString()
                    }
                );
            }

            return reservations;
        }

        public List<SummaryReservationDTO> RetrieveReservationListByRoomName(string roomName)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@RoomName", SqlDbType.NVarChar, 20, roomName, ParameterDirection.Input));

            DataTable dt = db.GetData("spRetrieveReservationByRoomName", parms);

            List<SummaryReservationDTO> reservations = new List<SummaryReservationDTO>();

            foreach (DataRow row in dt.Rows)
            {
                reservations.Add(
                    new SummaryReservationDTO
                    {
                        ReservationDate = Convert.ToDateTime(row["ReservationDate"]),
                        CheckInDate = Convert.ToDateTime(row["CheckInDate"]),
                        CheckOutDate = Convert.ToDateTime(row["CheckOutDate"]),
                        RoomNumber = Convert.ToInt32(row["RoomNumber"]),
                        GuestLastName = row["LastName"].ToString(),
                        ConfirmationNumber = row["ConfirmationNumber"].ToString()
                    }
                );
            }

            return reservations;
        }

        public List<SummaryReservationDTO> RetrieveReservationListByLastName(string lastName)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@LastName", SqlDbType.NVarChar, 30, lastName, ParameterDirection.Input));

            DataTable dt = db.GetData("spRetrieveReservationByLastName", parms);

            List<SummaryReservationDTO> reservations = new List<SummaryReservationDTO>();

            foreach (DataRow row in dt.Rows)
            {
                reservations.Add(
                    new SummaryReservationDTO
                    {
                        ReservationDate = Convert.ToDateTime(row["ReservationDate"]),
                        CheckInDate = Convert.ToDateTime(row["CheckInDate"]),
                        CheckOutDate = Convert.ToDateTime(row["CheckOutDate"]),
                        RoomNumber = Convert.ToInt32(row["RoomNumber"]),
                        GuestLastName = row["LastName"].ToString(),
                        ConfirmationNumber = row["ConfirmationNumber"].ToString()
                    }
                );
            }

            return reservations;
        }

        public List<SummaryReservationDTO> RetrieveReservationListByConfirmationNumber(string confirmationNumber)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@ConfirmationNumber", SqlDbType.NVarChar, 12, confirmationNumber, ParameterDirection.Input));

            DataTable dt = db.GetData("spRetrieveReservationByConfirmationNumber", parms);

            List<SummaryReservationDTO> reservations = new List<SummaryReservationDTO>();

            foreach (DataRow row in dt.Rows)
            {
                reservations.Add(
                    new SummaryReservationDTO
                    {
                        ReservationDate = Convert.ToDateTime(row["ReservationDate"]),
                        CheckInDate = Convert.ToDateTime(row["CheckInDate"]),
                        CheckOutDate = Convert.ToDateTime(row["CheckOutDate"]),
                        RoomNumber = Convert.ToInt32(row["RoomNumber"]),
                        GuestLastName = row["LastName"].ToString(),
                        ConfirmationNumber = row["ConfirmationNumber"].ToString()
                    }
                );
            }

            return reservations;
        }

        public bool Insert(ReservationCreationEntity r)
        {
            List<ParmStruct> parms = new List<ParmStruct>();

            parms.Add(new ParmStruct("@ConfirmMsg", SqlDbType.NVarChar, 500, "", ParameterDirection.Output));
            parms.Add(new ParmStruct("@CheckInDate", SqlDbType.DateTime2, 0, r.Reservation.CheckInDate, ParameterDirection.Input));
            parms.Add(new ParmStruct("@CheckOutDate", SqlDbType.DateTime2, 0, r.Reservation.CheckOutDate, ParameterDirection.Input));
            parms.Add(new ParmStruct("@NumOfAdults", SqlDbType.Int, 0, r.Reservation.NumOfAdults, ParameterDirection.Input));
            parms.Add(new ParmStruct("@NumOfChildren", SqlDbType.Int, 0, r.Reservation.NumOfChildren, ParameterDirection.Input));
            parms.Add(new ParmStruct("@RoomNumber", SqlDbType.Int, 0, r.Reservation.RoomNumber, ParameterDirection.Input));
            parms.Add(new ParmStruct("@FirstName", SqlDbType.NVarChar, 30, r.Reservation.Guest.FirstName, ParameterDirection.Input));
            parms.Add(new ParmStruct("@MiddleName", SqlDbType.NVarChar, 20, r.Reservation.Guest.MiddleName, ParameterDirection.Input));
            parms.Add(new ParmStruct("@LastName", SqlDbType.NVarChar, 50, r.Reservation.Guest.LastName, ParameterDirection.Input));
            parms.Add(new ParmStruct("@Street", SqlDbType.NVarChar, 50, r.Reservation.Guest.Street, ParameterDirection.Input));
            parms.Add(new ParmStruct("@City", SqlDbType.NVarChar, 50, r.Reservation.Guest.City, ParameterDirection.Input));
            parms.Add(new ParmStruct("@StateId", SqlDbType.Int, 0, r.Reservation.Guest.StateId, ParameterDirection.Input));
            parms.Add(new ParmStruct("@CountryId", SqlDbType.Int, 0, r.Reservation.Guest.CountryId, ParameterDirection.Input));
            parms.Add(new ParmStruct("@PostalCode", SqlDbType.NVarChar, 20, r.Reservation.Guest.PostalCode, ParameterDirection.Input));
            parms.Add(new ParmStruct("@HomePhone", SqlDbType.NVarChar, 20, r.Reservation.Guest.HomePhone, ParameterDirection.Input));
            parms.Add(new ParmStruct("@CellPhone", SqlDbType.NVarChar, 20, r.Reservation.Guest.CellPhone, ParameterDirection.Input));
            parms.Add(new ParmStruct("@Email", SqlDbType.NVarChar, 20, r.Reservation.Guest.Email, ParameterDirection.Input));
            parms.Add(new ParmStruct("@DateOfBirth", SqlDbType.NVarChar, 20, r.Reservation.Guest.DateOfBirth, ParameterDirection.Input));
            parms.Add(new ParmStruct("@ClerkId", SqlDbType.Int, 00, r.Reservation.ClerkId, ParameterDirection.Input));
            
            if(db.SendData("spInsertReservation", parms) > 0)
            {
                r.ConfirmMessage = parms[0].Value.ToString();
                return true;
            }
            return false;
        }
        
        public DetailReservationDTO ReservationDetail(string confirmationNumber)
        {
            List<ParmStruct> parms = new List<ParmStruct>();

            parms.Add(new ParmStruct("@ConfirmationNumber", SqlDbType.NVarChar, 12, confirmationNumber, ParameterDirection.Input));

            DataTable dt = db.GetData("spGetReservationDetail", parms);

            DetailReservationDTO detailReservation = new DetailReservationDTO()
            {
                GuestName = dt.Rows[0][0].ToString(),
                Address = dt.Rows[0][1].ToString(),
                HomePhone = dt.Rows[0][2].ToString(),
                CellPhone = dt.Rows[0][3].ToString(),
                Email = dt.Rows[0][4].ToString(),
                CheckInDate = (DateTime)dt.Rows[0][5],
                CheckOutDate = (DateTime)dt.Rows[0][6],
                RoomNumber = Convert.ToInt32(dt.Rows[0][7]),
                RoomName = dt.Rows[0][8].ToString(),
                NumOfAdults = Convert.ToInt32(dt.Rows[0][9]),
                NumOfChildren = Convert.ToInt32(dt.Rows[0][10]),
                BaseRate = Convert.ToDecimal(dt.Rows[0][11]),
                DailyRate = Convert.ToDecimal(dt.Rows[0][12]),
                TotalPrice = Convert.ToDecimal(dt.Rows[0][13]),
            };

            return detailReservation;
        }

        #endregion
    }
}
