using MVC_TravelBooking_Project.Models;

namespace MVC_TravelBooking_Project.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly Emp_Travel_BookingContext _context;

        public EmployeeRepository(Emp_Travel_BookingContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees;
        }

        public void AddEmployee(Employee e)
        {
            if(e != null)
            {
                _context.Employees.Add(e);
                _context.SaveChanges();
            }
        }

        public void DeleteEmployee(int id)
        {
            Employee? e  = _context.Employees.FirstOrDefault(x=>x.EmpId == id);

            if(e != null)
            {
                _context.Employees.Remove(e);
                _context.SaveChanges();
            }
        }

        public Employee GetEmployeeById(int id)
        {
            Employee? e = _context.Employees.FirstOrDefault(x => x.EmpId == id);
            return e;
        }


        public void UpdateEmployee(Employee e, int id)
        {
            Employee? employee = _context.Employees.FirstOrDefault(x => x.EmpId == id);

            if(employee != null)
            {
                employee.EmpFirstName = e.EmpFirstName;
                employee.EmpLastName = e.EmpLastName;
                employee.EmpDob = e.EmpDob;
                employee.EmpAddress = e.EmpAddress;
                employee.EmpContact = e.EmpContact;
                _context.SaveChanges();
            }
           
        }

        
    }
}
