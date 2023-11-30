using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_TravelBooking_Project.Models
{
    public partial class TravelRequest
    {
        public int RequestId { get; set; }
        public int? EmpId { get; set; }

        [Required(ErrorMessage = "From Location Required")]
        [MaxLength(20)]
        public string LocFrom { get; set; } = null!;

        [Required(ErrorMessage = "To Location Required")]
        [MaxLength(20)]
        public string LocTo { get; set; } = null!;
        public string? ApprovalStatus { get; set; }
        public string? BookingStatus { get; set; }
        public string? CurrentStatus { get; set; }

        [Required(ErrorMessage = "Request Date Required")]
        public DateTime? ReqDate { get; set; }

        public virtual Employee? Emp { get; set; }
    }
}
