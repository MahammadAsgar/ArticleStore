using ArticleStore.Domain.Models.Users;
using ArticleStore.Infrasturucture.Dtos.Users.Post;
using ArticleStore.Infrasturucture.Helpers.Abstractions;
using ArticleStore.Infrasturucture.Services.Users.Abstractions;
using ArticleStore.Persistance.Jwt;
using ArticleStore.SharedLibrary.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleStore.Infrasturucture.Services.Users.Implementations
{
    public class AuthService : IAuthService
    {
        readonly UserManager<AppUser> userManager;
        readonly IMailService mail;
        readonly IHttpContextAccessor httpContextAccessor;
        readonly SignInManager<AppUser> signInManager;
        readonly ITokenHandler tokenHandler;

        public AuthService(UserManager<AppUser> userManager, IMailService mail, IHttpContextAccessor httpContextAccessor, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler)
        {
            this.userManager = userManager;
            this.mail = mail;
            this.httpContextAccessor = httpContextAccessor;
            this.signInManager = signInManager;
            this.tokenHandler = tokenHandler;
        }

        public async Task<Response<NoDataDto>> Register(SignupDTO signupDTO)
        {
            var user = SignupDTO.ToAppUser(signupDTO);
            var rand = new Random();
            int num = rand.Next(1000, 9999);
            user.Number = num;
            var response = await userManager.CreateAsync(user, signupDTO.password);
            if (response.Succeeded)
            {
                await mail.Activate(signupDTO.email, num);
               // signInManager.CheckPasswordSignInAsync(user, signupDTO.password, false);
                return Response<NoDataDto>.Success("register successfully");
            }
            return Response<NoDataDto>.Fail("register unsuccessfully");
        }

        //private void Activate(int num)
        //{

        //}
        public async Task<Response<NoDataDto>> Activate(int num, string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (num == user.Number)
            {
                user.EmailConfirmed = true;
                await userManager.AddToRoleAsync(user, "User");
                await userManager.UpdateAsync(user);
                return Response<NoDataDto>.Success("Great weocome");
            }
            return Response<NoDataDto>.Fail("Number is false");
        }

        public async Task<Response<Token>> SignIn(LoginDTO loginDTO)
        {
            var user = await userManager.FindByEmailAsync(loginDTO.emailusername);
            if (user == null)
            {
                user = await userManager.FindByNameAsync(loginDTO.emailusername);
            }

            if (user != null)
            {
                var response = signInManager.CheckPasswordSignInAsync(user, loginDTO.password, false);
                if (response.IsCompletedSuccessfully)
                {
                    Token token = await tokenHandler.CreateAccessToken(user);
                    return Response<Token>.Success(token);
                }
            }
            return Response<Token>.Fail("Unsuccessful login");
        }


        public async Task<Response<NoDataDto>> Signout()
        {
            await signInManager.SignOutAsync();
            return Response<NoDataDto>.Success("Great signout");
        }
    }
}
