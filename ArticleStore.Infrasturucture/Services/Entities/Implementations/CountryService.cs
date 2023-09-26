using ArticleStore.Application.Repositories.Abstractions;
using ArticleStore.Application.UnitOfWorks;
using ArticleStore.Domain.Models.UserUtilities;
using ArticleStore.Infrasturucture.Dtos.Entities.Get;
using ArticleStore.Infrasturucture.Dtos.Entities.Post;
using ArticleStore.Infrasturucture.Services.Entities.Abstractions;
using ArticleStore.SharedLibrary.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ArticleStore.Infrasturucture.Services.Entities.Implementations
{
    public class CountryService : ICountryService
    {
        readonly IGenericRepository<Country> countryRepository;
        readonly IUnitOfWork unitOfWork;
        public CountryService(IGenericRepository<Country> countryRepository, IUnitOfWork unitOfWork)
        {
            this.countryRepository = countryRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<NoDataDto>> AddCountry(PostCountryDto countryDto)
        {
            var country = PostCountryDto.ToCountry(countryDto.name);
            await countryRepository.AddAsync(country);
            await unitOfWork.CommitAsync();
            return Response<NoDataDto>.Success("Successful");
        }

        public async Task<Response<IEnumerable<GetCountryDto>>> GetCountries()
        {
            var response = new List<GetCountryDto>();
            var countries =await countryRepository.GetAll().ToListAsync();
            if (countries.Count() > 0)
            {
                foreach (var item in countries)
                {
                    response.Add(GetCountryDto.ToCountryDto(item));
                }
                return Response<IEnumerable<GetCountryDto>>.Success(response);
            }
            return Response<IEnumerable<GetCountryDto>>.Fail("No found");
        }

        public async Task<Response<IEnumerable<GetCountryDto>>> GetCountry(string text)
        {
            var response = new List<GetCountryDto>();
            var countries =await countryRepository.GetAll().Where(x => x.Name.Contains(text)).ToListAsync();
            if (countries.Count() > 0)
            {
                foreach (var item in countries)
                {
                    response.Add(GetCountryDto.ToCountryDto(item));
                }
                return Response<IEnumerable<GetCountryDto>>.Success(response);
            }
            return Response<IEnumerable<GetCountryDto>>.Fail("No found");

        }

        public async Task<Response<GetCountryDto>> GetCountryById(int id)
        {
            var country = await countryRepository.GetByIdAsync(id);
            if (country != null)
            {
                return Response<GetCountryDto>.Success(GetCountryDto.ToCountryDto(country));
            }
            return Response<GetCountryDto>.Fail("No found");
        }
    }
}
