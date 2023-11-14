using System;
using System.Collections.Generic;

namespace MVC_TravelBooking_Project.Models
{
    public partial class Employee
    {
        public Employee()
        {
            TravelRequests = new HashSet<TravelRequest>();
        }

        public int EmpId { get; set; }
        public string EmpFirstName { get; set; } = null!;
        public string EmpLastName { get; set; } = null!;
        public DateTime? EmpDob { get; set; }
        public string? EmpAddress { get; set; }
        public string? EmpContact { get; set; }

        public virtual ICollection<TravelRequest> TravelRequests { get; set; }
    }
}
