using System;
using System.ComponentModel.DataAnnotations;

namespace MVC5.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Please enter customer's name")]
        public string Name { get; set; }

        [Display(Name = "Date of birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewLetter { get; set; }
        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")] public byte MembershipTypeId { get; set; }
    }
}