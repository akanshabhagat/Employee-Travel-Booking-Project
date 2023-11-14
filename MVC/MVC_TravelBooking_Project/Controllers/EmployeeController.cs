using Microsoft.AspNetCore.Mvc;
using MVC_TravelBooking_Project.Models;
using MVC_TravelBooking_Project.Repository;

namespace MVC_TravelBooking_Project.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IActionResult Index()
        {
            IEnumerable<Employee> employee =  _employeeRepository.GetEmployees();
            return View(employee);
        }

        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee e)
        {
            if(ModelState.IsValid)
            {
                _employeeRepository.AddEmployee(e);
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteEmployee(int id)
        {
            if(ModelState.IsValid)
            {
                _employeeRepository.DeleteEmployee(id);
            }
            return RedirectToAction("Index");
        }

        public IActionResult UpdateEmployee(int id)
        {
            Employee e = _employeeRepository.GetEmployeeById(id);

            if(e != null)
            {
                return View(e);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateEmployee(Employee e, int id)
        {
            if(ModelState.IsValid)
            {
                _employeeRepository.UpdateEmployee(e, id);
            }
            return RedirectToAction("Index");
        }

    }
}
