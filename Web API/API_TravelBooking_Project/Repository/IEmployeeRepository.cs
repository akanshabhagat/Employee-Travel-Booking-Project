using API_TravelBooking_Project.Models;

namespace API_TravelBooking_Project.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployeeById(int id);
        Task<Employee> AddEmployee(Employee emp);

        Task<Employee> UpdateEmployee(Employee emp, int id);

        void DeleteEmployee(int id);
    }
}
