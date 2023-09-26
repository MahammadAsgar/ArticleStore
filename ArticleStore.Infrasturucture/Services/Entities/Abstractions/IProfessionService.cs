using ArticleStore.Infrasturucture.Dtos.Entities.Get;
using ArticleStore.Infrasturucture.Dtos.Entities.Post;
using ArticleStore.SharedLibrary.Dtos;

namespace ArticleStore.Infrasturucture.Services.Entities.Abstractions
{
    public interface IProfessionService
    {
        Task<Response<NoDataDto>> AddProfession(PostPorfessionDto porfessionDto);
        Task<Response<GetProfessionDto>> GetProfessionById(int id);
        Task<Response<IEnumerable<GetProfessionDto>>> GetProfession(string text);
        Task<Response<IEnumerable<GetProfessionDto>>> GetProfessions();


    }
}
