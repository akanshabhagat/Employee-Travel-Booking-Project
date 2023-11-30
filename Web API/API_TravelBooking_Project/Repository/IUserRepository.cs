using ClassLibrary_API_TravelBooking_Project;

namespace API_TravelBooking_Project.Repository
{
    public interface IUserRepository
    {
        Task<UserManagerResponse> RegisterUserAsync(RegisterViewModels model);
        Task<UserManagerResponse> LoginUserAsync(LoginViewModel model);
    }
}
