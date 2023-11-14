using MVC_TravelBooking_Project.Models;

namespace MVC_TravelBooking_Project.Repository
{
    public interface ITravelRequestRepository
    {
        IEnumerable<TravelRequest> GetTravelRequests();

        void AddTravelRequest(TravelRequest tr);

        void DeleteTravelRequest(int id);

        void UpdateTravelRequest(TravelRequest tr, int id);

        TravelRequest GetTravelRequestById(int id);

        void ApproveTravelRequest(int id, string status);

        void BookTravelRequest(int id, string status);


    }
}
