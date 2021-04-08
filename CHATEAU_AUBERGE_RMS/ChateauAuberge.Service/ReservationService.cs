using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChateauAuberge.Model;
using ChateauAuberge.Repository;
using System.ComponentModel.DataAnnotations;

namespace ChateauAuberge.Service
{
    public class ReservationService
    {
        private ReservationRepo repo;

        public ReservationService()
        {
            repo = new ReservationRepo();
        }

        public List<SummaryReservationDTO> GetReservationList()
        {
            return repo.RetrieveReservationList();
        }

        public List<SummaryReservationDTO> GetReservationListByDate(DateTime date)
        {
            return repo.RetrieveReservationListByDate(date);
        }

        public List<SummaryReservationDTO> GetReservationListByRoomNumber(int roomNumber)
        {
            return repo.RetrieveReservationListByRoomNumber(roomNumber);
        }

        public List<SummaryReservationDTO> GetReservationListByRoomName(string roomName)
        {
            return repo.RetrieveReservationListByRoomName(roomName);
        }

        public List<SummaryReservationDTO> GetReservationListByLastName(string lastName)
        {
            return repo.RetrieveReservationListByLastName(lastName);
        }

        public List<SummaryReservationDTO> GetReservationListByConfirmationNumber(string confirmationNumber)
        {
            return repo.RetrieveReservationListByConfirmationNumber(confirmationNumber);
        }

        public bool AddReservation(ReservationCreationEntity r)
        {
            if(Validate(r.Reservation, r.Reservation.Guest))
                return repo.Insert(r);

            return false;
        }

        public DetailReservationDTO GetReservationDetail(string confirmationNumber)
        {
            return repo.ReservationDetail(confirmationNumber);
        }

        private bool Validate(Reservation reservationToValidate, Guest guestToValidate)
        {
            ValidationContext context = new ValidationContext(reservationToValidate);

            List<ValidationResult> results = new List<ValidationResult>();

            Validator.TryValidateObject(reservationToValidate, context, results, true);

            foreach (ValidationResult r in results)
            {
                reservationToValidate.AddError(new ValidationError(r.ErrorMessage));
            }

            context = new ValidationContext(guestToValidate);
            results = new List<ValidationResult>();

            Validator.TryValidateObject(guestToValidate, context, results, true);

            foreach (ValidationResult g in results)
            {
                reservationToValidate.AddError(new ValidationError(g.ErrorMessage));
            }

            return reservationToValidate.Errors.Count == 0;
        }

    }
}
