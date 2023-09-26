using ArticleStore.Infrasturucture.Dtos.Users.Post;
using ArticleStore.Infrasturucture.Services.Users.Abstractions;
using ArticleStore.Persistance.Jwt;
using ArticleStore.SharedLibrary.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArticleStore.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IAuthService authService;
        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost]
        public async Task<ActionResult<Response<NoDataDto>>> Register( SignupDTO signupDTO)
        {
            var response = await authService.Register(signupDTO);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<NoDataDto>> Activate(int num, string email)
        {
            var response = await authService.Activate(num, email);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<NoDataDto>> Signout()
        {
            var response = await authService.Signout();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Token>> SignIn(LoginDTO loginDTO)
        {
            var response = await authService.SignIn(loginDTO);
            return Ok(response);
        }
    }
}
