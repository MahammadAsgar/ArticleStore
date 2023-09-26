using ArticleStore.Infrasturucture.Dtos.Entities.Get;
using ArticleStore.Infrasturucture.Dtos.Entities.Post;
using ArticleStore.SharedLibrary.Dtos;

namespace ArticleStore.Infrasturucture.Services.Entities.Abstractions
{
    public interface ICountryService
    {
        Task<Response<NoDataDto>> AddCountry(PostCountryDto countryDto);
        Task<Response<GetCountryDto>> GetCountryById(int id);
        Task<Response<IEnumerable<GetCountryDto>>> GetCountry(string text);
        Task<Response<IEnumerable<GetCountryDto>>> GetCountries();
    }
}
