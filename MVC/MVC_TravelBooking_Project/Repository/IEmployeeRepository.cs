using MVC_TravelBooking_Project.Models;

namespace MVC_TravelBooking_Project.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();

        void AddEmployee(Employee e);

        void DeleteEmployee(int id);

        void UpdateEmployee(Employee e, int id);

        Employee GetEmployeeById(int id);
    }
}
