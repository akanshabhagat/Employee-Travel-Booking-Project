using API_TravelBooking_Project.Models;
using API_TravelBooking_Project.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_TravelBooking_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelRequestController : ControllerBase
    {
        private readonly ITravelRequestRepository _repository;
        public TravelRequestController(ITravelRequestRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TravelRequest>>> Get()
        {
            IEnumerable<TravelRequest> lsttravelreq = await _repository.GetTravelRequests();
            if (lsttravelreq != null)
            {
                return Ok(lsttravelreq);
            }
            return BadRequest();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TravelRequest>> GetTravelRequestById(int id)
        {
            TravelRequest lsttravelreq = await _repository.GetTravelRequestById(id);
            if (lsttravelreq != null)
            {
                return Ok(lsttravelreq);
            }
            return BadRequest();
        }
        [HttpPost]
        public async Task<ActionResult<TravelRequest>> PostTravelRequest([FromBody] TravelRequest tr)
        {
            if (tr == null)
            {
                return BadRequest();
            }
            await _repository.AddTravelRequest(tr);
            return CreatedAtAction(nameof(GetTravelRequestById), new { id = tr.RequestId }, tr);

        }

        //PUT: api/Movies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTravelRequest(int id, [FromBody] TravelRequest tr)
        {
            Console.WriteLine($"{tr.RequestId},{tr.EmpId}, {tr.LocFrom}, {tr.LocTo}, {tr.ReqDate}, {tr.ApprovalStatus}, {tr.BookingStatus}, {tr.CurrentStatus}");
            await _repository.UpdateTravelRequest(tr, id);
            return Ok(tr);

        }
        //Delete: api/Movie/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTravelRequest(int id)
        {
            TravelRequest tr = await _repository.GetTravelRequestById(id);
            if (tr != null)
            {
                _repository.DeleteTravelRequest(id);
                //return NoContent();
                return Ok();
            }
            return NotFound();
        }


        //PUT: api/Movies/5
        [HttpPut("Approve/{id}")]
        public async Task<IActionResult> PutTravelRequestAppproveStatus(int id,  [FromBody]TravelRequest tr)
        {
            await _repository.ApproveTravelRequest(id,tr);
            return Ok();

        }

        //PUT: api/Movies/5
        [HttpPut("Book/{id}")]
        public async Task<IActionResult> PutTravelRequestBookStatus(int id, [FromBody]TravelRequest tr)
        {
            await _repository.BookTravelRequest(id,tr);
            return Ok();

        }
    }
}
