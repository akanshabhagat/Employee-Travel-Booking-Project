using Microsoft.EntityFrameworkCore;
using MVC_TravelBooking_Project.Models;

namespace MVC_TravelBooking_Project.Repository
{
    public class TravelRequestRepository: ITravelRequestRepository
    {
        private readonly Emp_Travel_BookingContext _context;

        public TravelRequestRepository(Emp_Travel_BookingContext context)
        {
            _context = context;
        }
        public IEnumerable<TravelRequest> GetTravelRequests()
        {
            IEnumerable<TravelRequest> tr =_context.TravelRequests.Include(x=>x.Emp);
            return tr;
        }

        public void AddTravelRequest(TravelRequest tr)
        {
            if(tr != null)
            {
                
               
                tr.ApprovalStatus = "Pending";
                tr.BookingStatus = "Pending";
                tr.CurrentStatus = "Open";
                _context.TravelRequests.Add(tr);
                _context.SaveChanges();
            }
        }

        public void DeleteTravelRequest(int id)
        {
            TravelRequest tr = _context.TravelRequests.FirstOrDefault(x=>x.RequestId == id);

            if(tr != null)
            {
                _context.TravelRequests.Remove(tr);
                _context.SaveChanges();
            }
        }

        public TravelRequest GetTravelRequestById(int id)
        {
            TravelRequest tr = _context.TravelRequests.FirstOrDefault(x => x.RequestId == id); 
            return tr;
            
        }

        public void UpdateTravelRequest(TravelRequest tr, int id)
        {
            TravelRequest travelreq_old = _context.TravelRequests.FirstOrDefault(x => x.RequestId == id);

            if(travelreq_old != null)
            {
                travelreq_old.LocFrom = tr.LocFrom;
                travelreq_old.LocTo = tr.LocTo;
                travelreq_old.ReqDate = tr.ReqDate;
                _context.SaveChanges(true);
            }

        }

        public void ApproveTravelRequest(int id, string status)
        {
            TravelRequest tr = _context.TravelRequests.FirstOrDefault(x => x.RequestId == id);

            if(tr != null)
            {
                
                   tr.ApprovalStatus = status;
                if(tr.ApprovalStatus == "NotApproved")
                {
                    tr.CurrentStatus = "Close";
                }
                   _context.SaveChanges(true);
                
            }
        }

        public void BookTravelRequest(int id, string status)
        {

            TravelRequest tr = _context.TravelRequests.FirstOrDefault(x => x.RequestId == id);

            if (tr != null)
            {

                tr.BookingStatus = status;
                tr.CurrentStatus = "Close";
                
                _context.SaveChanges(true);

            }


        }



    }
}
