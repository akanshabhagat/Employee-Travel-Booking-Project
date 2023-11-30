using API_TravelBooking_Project.Repository;
using ClassLibrary_API_TravelBooking_Project;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_TravelBooking_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _repository;
        public AuthController(IUserRepository repository)
        {
            _repository = repository;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] RegisterViewModels model)
        {
            if (ModelState.IsValid)
            {
                var result = await _repository.RegisterUserAsync(model);
                if (result.IsSuccess)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest("Some Properties are not valid");
        }
        //api/auth/login
        [HttpPost("Login")]
        public async Task<IActionResult> LoginUserAsync([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _repository.LoginUserAsync(model);
                if (result.IsSuccess)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest();
        }
    }
}
