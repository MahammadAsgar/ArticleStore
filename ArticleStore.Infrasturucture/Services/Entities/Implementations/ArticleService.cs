using ArticleStore.Application.Repositories.Abstractions;
using ArticleStore.Application.UnitOfWorks;
using ArticleStore.Domain.Models.Entities;
using ArticleStore.Domain.Models.Users;
using ArticleStore.Infrasturucture.Dtos.Entities.Post;
using ArticleStore.Infrasturucture.Services.Entities.Abstractions;
using ArticleStore.SharedLibrary.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleStore.Infrasturucture.Services.Entities.Implementations
{
    public class ArticleService : IArticleService
    {
        readonly IGenericRepository<Article> articleRepository;
        readonly IGenericRepository<Tag> tagRepository;
        readonly UserManager<AppUser> userManager;
        readonly IHttpContextAccessor httpContextAccessor;
        readonly IGenericRepository<PictureSource> pictureSourceRepository;
        readonly IUnitOfWork unitOfWork;

        public ArticleService(IGenericRepository<Article> articleRepository, IGenericRepository<Tag> tagRepository,
            IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager,
            IGenericRepository<PictureSource> pictureSourceRepository, IUnitOfWork unitOfWork)
        {
            this.articleRepository = articleRepository;
            this.tagRepository = tagRepository;
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
            this.pictureSourceRepository = pictureSourceRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<NoDataDto>> AddArticle(PostArticleDto postArticleDto)
        {
            var currentUser = await userManager.Users.FirstOrDefaultAsync(x => x.Id == 5);// await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);
            var article = new Article();
            article.AppUser = currentUser;
            article.CategoryId = postArticleDto.categoryId;
            article.Description = postArticleDto.description;
            article.Name = postArticleDto.name;
            article.Tags = tagRepository.Where(x => postArticleDto.tagIds.Contains(x.Id)).ToList();
            PictureSource picture;
            article.Images = new List<PictureSource>();
            if (postArticleDto.Images != null)
            {
                foreach (var item in postArticleDto.Images)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        picture = new PictureSource();
                        await item.CopyToAsync(memoryStream);
                        picture.Bytes = memoryStream.ToArray();
                    }
                    await pictureSourceRepository.AddAsync(picture);
                    await unitOfWork.CommitAsync();
                    article.Images.Add(picture);
                }
            }
            await articleRepository.AddAsync(article); 
            await unitOfWork.CommitAsync();
            return Response<NoDataDto>.Success("great");
        }

        public Task<Response<NoDataDto>> GetArticle(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoDataDto>> GetArticles()
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoDataDto>> GetArticlesByUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
