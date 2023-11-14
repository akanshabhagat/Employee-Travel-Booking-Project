using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_TravelBooking_Project.Models;
using MVC_TravelBooking_Project.Repository;

namespace MVC_TravelBooking_Project.Controllers
{
    public class TravelRequestController : Controller
    {
        private readonly ITravelRequestRepository _travelRequestRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public TravelRequestController(ITravelRequestRepository travelRequestRepository, IEmployeeRepository employeeRepository)
        {
            _travelRequestRepository = travelRequestRepository;
            _employeeRepository = employeeRepository;
        }
        public IActionResult Index()
        {
            IEnumerable<TravelRequest> travelRequests = _travelRequestRepository.GetTravelRequests();
            return View(travelRequests);
        }

        public IActionResult AddTravelRequest()
        {
            ViewBag.Employees = new SelectList(_employeeRepository.GetEmployees(), "EmpId","EmpFirstName", "EmpLastName");
            return View();
        }

        [HttpPost]
        public IActionResult AddTravelRequest( TravelRequest tr)
        {
            if(ModelState.IsValid)
            {
                _travelRequestRepository.AddTravelRequest(tr);
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteTravelRequest(int id)
        {
            _travelRequestRepository.DeleteTravelRequest(id);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateTravelRequest(int id)
        {

           TravelRequest tr = _travelRequestRepository.GetTravelRequestById(id);
            ViewBag.Employees = new SelectList(_employeeRepository.GetEmployees(), "EmpId", "EmpFirstName");

            if (tr != null)
            {
                return View(tr);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateTravelRequest(TravelRequest tr, int id)
        {
            //ViewBag.Employees = new SelectList(_employeeRepository.GetEmployees(), "EmpId", "EmpFirstName", "EmpLastName");
            if (ModelState.IsValid)
            {
                _travelRequestRepository.UpdateTravelRequest(tr, id);
            }
            return RedirectToAction("Index");
        }

        public IActionResult ApproveTravelRequest(int id)
        {
           TravelRequest tr =  _travelRequestRepository.GetTravelRequestById(id);
            return View(tr);
        }

        [HttpPost]
        public IActionResult ApproveTravelRequest(int RequestId, string ApprovalStatus)
        {
            if(ModelState.IsValid)
            {
                _travelRequestRepository.ApproveTravelRequest(RequestId, ApprovalStatus);
            }
            return RedirectToAction("Index");
        }

        public IActionResult BookTravelRequest(int id)
        {
            TravelRequest tr = _travelRequestRepository.GetTravelRequestById(id);
            return View(tr);
        }

        [HttpPost]
        public IActionResult BookTravelRequest(int RequestId, string BookingStatus)
        {
            if (ModelState.IsValid)
            {
                _travelRequestRepository.BookTravelRequest(RequestId, BookingStatus);
            }
            return RedirectToAction("Index");
        }


    }
}
