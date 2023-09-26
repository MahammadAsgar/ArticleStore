using ArticleStore.Infrasturucture.Dtos.Users.Post;
using ArticleStore.SharedLibrary.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleStore.Infrasturucture.Services.Users.Abstractions
{
    public interface IUserService
    {
        Task<Response<NoDataDto>> FollowUser(int userId);
        Task<Response<NoDataDto>> UnFollowUser(int userId);
        Task<Response<NoDataDto>> EditProfile(EditProfileDTO editProfile);
        Task<Response<NoDataDto>> PostArticle();
        Task<Response<NoDataDto>> DeletePost();
        Task<Response<NoDataDto>> CommentToPost(string text, int postId);
        Task<Response<NoDataDto>> LikePost(int postId);
        Task<Response<NoDataDto>> DisLikePost(int postId);
        Task<Response<NoDataDto>> SavePosts(int postId);
    }
}
