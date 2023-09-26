using ArticleStore.Infrasturucture.Dtos.Entities.Post;
using ArticleStore.SharedLibrary.Dtos;

namespace ArticleStore.Infrasturucture.Services.Entities.Abstractions
{
    public  interface IArticleService
    {
        Task<Response<NoDataDto>> AddArticle(PostArticleDto postArticleDto);
        Task<Response<NoDataDto>> GetArticle(int id);
        Task<Response<NoDataDto>> GetArticles();
        Task<Response<NoDataDto>> GetArticlesByUser(int userId);
    }
}
