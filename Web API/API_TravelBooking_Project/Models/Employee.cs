using System.ComponentModel.DataAnnotations;

namespace API_TravelBooking_Project.Models
{
    public class Employee
    {
        [Key]
        //public Employee()
        //{
        //    TravelRequests = new HashSet<TravelRequest>();
        //}

        public int EmpId { get; set; }

        [Required(ErrorMessage = "First Name Required")]
        [MaxLength(20)]
        public string EmpFirstName { get; set; } = null!;

        [Required(ErrorMessage = "Last Name Required")]
        [MaxLength(20)]
        public string EmpLastName { get; set; } = null!;

        [Required(ErrorMessage = "Date of Birth Required")]
        public DateTime? EmpDob { get; set; }

        [Required(ErrorMessage = "Address Required")]
        [MaxLength(20)]
        public string? EmpAddress { get; set; }

        [Required(ErrorMessage = "Contact  Required")]
        [MaxLength(20)]
        public string? EmpContact { get; set; }

        public virtual ICollection<TravelRequest>? TravelRequests { get; set; }

    }
}
