using ArticleStore.Application.Repositories.Abstractions;
using ArticleStore.Application.Repositories.Implementations;
using ArticleStore.Application.UnitOfWorks;
using ArticleStore.Domain.Models.Base;
using ArticleStore.Domain.Models.Entities;
using ArticleStore.Domain.Models.PostUtilities;
using ArticleStore.Domain.Models.Users;
using ArticleStore.Domain.Models.UserUtilities;
using ArticleStore.Infrasturucture.Dtos.Users.Post;
using ArticleStore.Infrasturucture.Services.Users.Abstractions;
using ArticleStore.SharedLibrary.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleStore.Infrasturucture.Services.Users.Implementations
{
    public class UserService : IUserService
    {
        readonly UserManager<AppUser> userManager;
        readonly IHttpContextAccessor httpContextAccessor;
        readonly IGenericRepository<Profession> professionRepository;
        readonly IGenericRepository<Category> categoryRepository;
        readonly IGenericRepository<PictureSource> picRepository;
        readonly IGenericRepository<Article> articleRepository;
        readonly IGenericRepository<Comment> commentRepository;
        readonly IUnitOfWork unitOfWork;
        public UserService(UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor, IGenericRepository<Profession> professionRepository,
          IGenericRepository<Category> categoryRepository, IGenericRepository<PictureSource> picRepository, IUnitOfWork unitOfWork,
          IGenericRepository<Article> articleRepository, IGenericRepository<Comment> commentRepository)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
            this.professionRepository = professionRepository;
            this.categoryRepository = categoryRepository;
            this.picRepository = picRepository;
            this.unitOfWork = unitOfWork;
            this.articleRepository = articleRepository;
            this.commentRepository = commentRepository;
        }

        public Task<Response<NoDataDto>> DeletePost()
        {
            throw new NotImplementedException();
        }

        public async Task<Response<NoDataDto>> EditProfile(EditProfileDTO editProfile)
        {
            var currentUser = await userManager.Users.FirstOrDefaultAsync(x => x.Id == 5); //await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);
            currentUser.Professions = new List<Profession>();
            currentUser.Interests = new List<Category>();
            currentUser.Bio = editProfile.Bio;
            currentUser.Professions = professionRepository.Where(x => editProfile.ProfessionIds.Contains(x.Id)).ToList();
            currentUser.Interests = categoryRepository.Where(x => editProfile.InterestIds.Contains(x.Id)).ToList();

            if (editProfile.CountyId.HasValue)
            {
                currentUser.CountryId = editProfile.CountyId.Value;
            }

            if (editProfile.GenderId.HasValue)
            {
                currentUser.GenderId = editProfile.GenderId.Value;
            }

            if (editProfile.BirthDate.HasValue)
            {
                currentUser.BirthDate = editProfile.BirthDate.Value;
            }
            if (editProfile.PictureSource != null)
            {
                PictureSource picture = new PictureSource();
                using (var memoryStream = new MemoryStream())
                {
                    await editProfile.PictureSource.CopyToAsync(memoryStream);
                    picture.Bytes = memoryStream.ToArray();
                }
                await picRepository.AddAsync(picture);
                await unitOfWork.CommitAsync();
                currentUser.PictureSource = picture;
            }
            await userManager.UpdateAsync(currentUser);
            return Response<NoDataDto>.Success("successful");
        }

        public async Task<Response<NoDataDto>> FollowUser(int userId)
        {
            //var currentUser = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);
            var currentUser = await userManager.Users.FirstOrDefaultAsync(x => x.Id == 5);
            var user = await userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);
            currentUser.Followings = new List<AppUser>();
            currentUser.Followings.Add(user);
            user.Followers = new List<AppUser>();
            user.Followers.Add(currentUser);
            await userManager.UpdateAsync(currentUser);
            await userManager.UpdateAsync(user);
            return Response<NoDataDto>.Success("Successful");
        }

        public Task<Response<NoDataDto>> PostArticle()
        {
            throw new NotImplementedException();
        }

        public async Task<Response<NoDataDto>> UnFollowUser(int userId)
        {
            //var currentUser = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);
            var currentUser = await userManager.Users.FirstOrDefaultAsync(x => x.Id == 5);
            var user = await userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);
            currentUser.Followings = new List<AppUser>();
            user.Followers = new List<AppUser>();
            currentUser.Followings.Remove(user);
            user.Followers.Remove(user);
            await userManager.UpdateAsync(currentUser);
            await userManager.UpdateAsync(user);
            return Response<NoDataDto>.Success("Sucessful");
        }

        public async Task<Response<NoDataDto>> CommentToPost(string text, int postId)
        {
            var currentUser = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);
            var post = await articleRepository.GetByIdAsync(postId);
            var comment = new Comment()
            {
                ArticleId = postId,
                Text = text,
                AppUserId = currentUser.Id
            };
            await commentRepository.AddAsync(comment);
            await unitOfWork.CommitAsync();
            post.Comments = new List<Comment>();
            post.Comments.Add(comment);
            articleRepository.Update(post);
            unitOfWork.Commit();
            return Response<NoDataDto>.Success("Successfull comment");
        }

        public async Task<Response<NoDataDto>> LikePost(int postId)
        {
            var currentUser = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);
            var post = await articleRepository.GetByIdAsync(postId);
            post.Likes++;
            post.LikedBy = new List<AppUser>();
            post.LikedBy.Add(currentUser);
            currentUser.LikedPosts = new List<Article>();
            currentUser.LikedPosts.Add(post);
            articleRepository.Update(post);
            unitOfWork.Commit();
            userManager.UpdateAsync(currentUser);
            return Response<NoDataDto>.Success("Successful like");
        }

        public async Task<Response<NoDataDto>> DisLikePost(int postId)
        {
            var currentUser = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);
            var post = await articleRepository.GetByIdAsync(postId);
            post.DisLikes++;
            post.DisLikedBy = new List<AppUser>();
            post.DisLikedBy.Add(currentUser);
            currentUser.DisLikedPosts = new List<Article>();
            currentUser.DisLikedPosts.Add(post);
            articleRepository.Update(post);
            unitOfWork.Commit();
            userManager.UpdateAsync(currentUser);
            return Response<NoDataDto>.Success("Successful like");
        }

        public async Task<Response<NoDataDto>> SavePosts(int postId)
        {
            var currentUser = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);
            var post = await articleRepository.GetByIdAsync(postId);
            currentUser.SavedPosts = new List<Article>();
            currentUser.SavedPosts.Add(post);
            userManager.UpdateAsync(currentUser);
            return Response<NoDataDto>.Success("Successful save");
        }

    }
}
