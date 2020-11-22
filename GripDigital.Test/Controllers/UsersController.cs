using System.Net;
using System.Threading.Tasks;
using GripDigital.Test.Authentication.Interfaces;
using GripDigital.Test.Core.Repositories.Interfaces;
using GripDigital.Test.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GripDigital.Test.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordProvider _passwordProvider;
        private readonly ITokenProvider _tokenProvider;

        public UsersController(IUserRepository userRepository, IPasswordProvider passwordProvider, ITokenProvider tokenProvider)
        {
            _userRepository = userRepository;
            _passwordProvider = passwordProvider;
            _tokenProvider = tokenProvider;
        }

        // Is there some special reason that bool value is needed?
        // I would personally prefer the option with 200 or 401 response below, that's what I normally expect to get from APIs
        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(LoginResponse), (int)HttpStatusCode.OK)]
        public async Task<LoginResponse> Login([FromBody] LoginRequest request)
        {
            var user = await _userRepository.GetByUserName(request.UserName);
            if (user == null || !_passwordProvider.ValidatePassword(request.Password, user.PasswordHash))
                return LoginResponse.Unauthorized();

            var token = _tokenProvider.GenerateToken(user.UserName);
            return LoginResponse.Authorized(token);
        }
        
        [HttpPost("login401")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(LoginResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> Login401([FromBody] LoginRequest request)
        {
            var user = await _userRepository.GetByUserName(request.UserName);
            if (user == null || !_passwordProvider.ValidatePassword(request.Password, user.PasswordHash))
                return Unauthorized();

            var token = _tokenProvider.GenerateToken(user.UserName);
            return Ok(token);
        }
    }
}