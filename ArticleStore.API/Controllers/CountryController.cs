using ArticleStore.Infrasturucture.Dtos.Entities.Get;
using ArticleStore.Infrasturucture.Dtos.Entities.Post;
using ArticleStore.Infrasturucture.Services.Entities.Abstractions;
using ArticleStore.SharedLibrary.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArticleStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        readonly ICountryService countryService;
        public CountryController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        [HttpPost]
        [Route("AddCountry")]
        public async Task<ActionResult<Response<NoDataDto>>> AddCountry( PostCountryDto countryDto)
        {
            var response = await countryService.AddCountry(countryDto);
            return Ok(response);
        }

        [HttpGet]
        [Route("CountriesViaText")]
        public async Task<ActionResult<Response<IEnumerable<GetCountryDto>>>> GetCountriesWithText(string text)
        {
            var response = await countryService.GetCountry(text);
            return Ok(response);
        }

        [HttpGet]
        [Route("Countries")]
        public async Task<ActionResult<Response<IEnumerable<GetCountryDto>>>> GetCountries()
        {
            var response = await countryService.GetCountries();
            return Ok(response);
        }

        [HttpGet]
        [Route("Country")]
        public async Task<ActionResult<Response<GetCountryDto>>> GetCountry(int id)
        {
            var response = await countryService.GetCountryById(id);
            return Ok(response);
        }
    }
}
