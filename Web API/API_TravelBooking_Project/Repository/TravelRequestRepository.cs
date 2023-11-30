using API_TravelBooking_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace API_TravelBooking_Project.Repository
{
    public class TravelRequestRepository: ITravelRequestRepository
    {
        private readonly ApplicationDbContext _context;
        public TravelRequestRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public  async Task<IEnumerable<TravelRequest>> GetTravelRequests()
        {
            return await _context.TravelRequests.ToListAsync();
        }
        public async Task<TravelRequest> GetTravelRequestById(int id)
        {
            var tr = await _context.TravelRequests.FirstOrDefaultAsync(m => m.RequestId == id);
            return tr;
        }
        public async Task<TravelRequest> AddTravelRequest(TravelRequest tr)
        {
            if (tr != null)
            {
                await _context.AddAsync(tr);
                tr.ApprovalStatus = "Pending";
                tr.BookingStatus = "Pending";
                tr.CurrentStatus = "Open";
                await _context.SaveChangesAsync();
            }
            return tr;
        }

        public async Task<TravelRequest> UpdateTravelRequest(TravelRequest tr, int id)
        {
            TravelRequest? travelreq_old = _context.TravelRequests.FirstOrDefault(x => x.RequestId == id);

            if (travelreq_old != null)
            {
                travelreq_old.LocFrom = tr.LocFrom;
                travelreq_old.LocTo = tr.LocTo;
                travelreq_old.ReqDate = tr.ReqDate;
                await _context.SaveChangesAsync(true);
            }
            return travelreq_old;
        }

        public void DeleteTravelRequest(int id)
        {
            TravelRequest? tr = _context.TravelRequests.FirstOrDefault(x => x.RequestId == id);

            if (tr != null)
            {
                _context.TravelRequests.Remove(tr);
                _context.SaveChanges();
            }
            
        }

        public async Task  ApproveTravelRequest(int id, TravelRequest tr)
        {
            TravelRequest? trold = _context.TravelRequests.FirstOrDefault(x => x.RequestId == id);

            if (trold != null)
            {

                /*.ApprovalStatus = status;
                if (tr.ApprovalStatus == "NotApproved")
                {
                    tr.CurrentStatus = "Close";
                }
                _context.SaveChanges(true);*/

                trold.ApprovalStatus = tr.ApprovalStatus;
                if (trold.ApprovalStatus == "NotApproved")
                {
                    trold.CurrentStatus = "Close";
                }
                await _context.SaveChangesAsync(true);

            }
            
        }

        public async Task BookTravelRequest(int id, TravelRequest tr)
        {
            TravelRequest? trold = _context.TravelRequests.FirstOrDefault(x => x.RequestId == id);

            if (trold != null)
            {

                trold.BookingStatus =   tr.BookingStatus;
                trold.CurrentStatus = "Close";

                await _context.SaveChangesAsync(true);

            }
        }
    }
}
