using ArticleStore.Infrasturucture.Dtos.Users.Post;
using ArticleStore.Infrasturucture.Services.Users.Abstractions;
using ArticleStore.SharedLibrary.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArticleStore.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<Response<NoDataDto>>> EditUser([FromForm]EditProfileDTO editProfileDTO)
        {
            var response= await userService.EditProfile(editProfileDTO);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Response<NoDataDto>>> FollowUser(int userId)
        {
            var response= await userService.FollowUser(userId);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Response<NoDataDto>>> UnFollowUser([FromBody]int userId)
        {
            var response = await userService.FollowUser(userId);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Response<NoDataDto>>> Comment(string text, int postId)
        {
            var response = await userService.CommentToPost(text, postId);
            return Ok(response);    
        }

        [HttpPost]
        public async Task<ActionResult<Response<NoDataDto>>> LikePost(int postId)
        {
            var response = await userService.LikePost(postId);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Response<NoDataDto>>> DisLikePost(int postId)
        {
            var response = await userService.DisLikePost(postId);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Response<NoDataDto>>> SavePost(int postId)
        {
            var response = await userService.SavePosts(postId);
            return Ok(response);
        }
    }
}
