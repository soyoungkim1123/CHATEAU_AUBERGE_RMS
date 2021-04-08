using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChateauAuberge.Model
{
    public class Guest
    {
        [Required(ErrorMessage = "First name is required")]
        [StringLength(30, ErrorMessage = "First name must be less than 30 characters")]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(30, ErrorMessage = "Last name must be less than 30 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Street is required")]
        [StringLength(40, ErrorMessage = "Street must be less than 50 characters")]
        public string Street { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(40, ErrorMessage = "City must be less than 50 characters")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        [Range(1, int.MaxValue, ErrorMessage = "State is required")]
        public int StateId { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Country is required")]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "Postal code is required")]
        [StringLength(50, ErrorMessage = "City must be less than 50 characters")]
        public string PostalCode { get; set; }

        [StringLength(20, ErrorMessage = "Home phone must be less than 20 characters")]
        public string HomePhone { get; set; }

        [Required(ErrorMessage = "Cell phone number is required")]
        [StringLength(20, ErrorMessage = "Cell phone must be less than 20 characters")]
        public string CellPhone { get; set; }

        [StringLength(255, ErrorMessage = "Email must be less than 255 characters")]
        public string Email { get; set; }

        [DateOfBirthAttribute]
        public DateTime DateOfBirth { get; set; }

    }
}
