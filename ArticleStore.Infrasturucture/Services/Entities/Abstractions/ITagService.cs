using ArticleStore.Infrasturucture.Dtos.Entities.Get;
using ArticleStore.Infrasturucture.Dtos.Entities.Post;
using ArticleStore.SharedLibrary.Dtos;

namespace ArticleStore.Infrasturucture.Services.Entities.Abstractions
{
    public interface ITagService
    {
        Task<Response<NoDataDto>> AddTag(PostTagDto tagDto);
        Task<Response<GetTagDto>> GetTagById(int id);
        Task<Response<IEnumerable<GetTagDto>>> GetTag(string text);
        Task<Response<IEnumerable<GetTagDto>>> GetTags();
    }
}
