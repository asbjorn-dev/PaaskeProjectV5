using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace sheltermini.Shared
{
    public class Booking
    {
        public Booking(Shelter shelter)
        {
            this.Shelter = shelter;
        }
        public Shelter Shelter { get; set;}
        [Required (ErrorMessage = "Udfyld start dato")]
        public string Startdate { get; set;}
        [Required(ErrorMessage = "Udfyld slut dato")]
        public string Slutdate { get; set;}
        public int NumberOfPeople { get; set; }
        public int BookingId { get; set; }
        public string ShelterId { get; set; }
        [Required(ErrorMessage ="Udfyld navn boks")]
        public string FullName { get; set;} = "";
        [Required, EmailAddress (ErrorMessage = "Emailen er ikke korrekt")]
        [StringLength(50, ErrorMessage = "Email må ikke være over 50 tegn")]
        public string Email { get; set; }
      //  [Required, Phone, Range(8,9) ]
        public string Phone { get; set;}

    }
}
