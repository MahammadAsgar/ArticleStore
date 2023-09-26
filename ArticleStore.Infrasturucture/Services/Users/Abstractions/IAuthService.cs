using ArticleStore.Infrasturucture.Dtos.Users.Post;
using ArticleStore.Persistance.Jwt;
using ArticleStore.SharedLibrary.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleStore.Infrasturucture.Services.Users.Abstractions
{
    public interface IAuthService
    {
        Task<Response<NoDataDto>> Register(SignupDTO signupDTO);
        Task<Response<NoDataDto>> Activate(int num, string email);
        Task<Response<Token>> SignIn(LoginDTO loginDTO);
        Task<Response<NoDataDto>> Signout();
    }
}
