using API_TravelBooking_Project.Models;

namespace API_TravelBooking_Project.Repository
{
    public interface ITravelRequestRepository
    {
        Task<IEnumerable<TravelRequest>> GetTravelRequests();
        Task<TravelRequest> GetTravelRequestById(int id);
        Task<TravelRequest> AddTravelRequest(TravelRequest tr);

        Task<TravelRequest> UpdateTravelRequest(TravelRequest tr, int id);

        void DeleteTravelRequest(int id);

        Task ApproveTravelRequest(int id, TravelRequest tr);

        Task BookTravelRequest(int id, TravelRequest tr);
    }
}
