using ArticleStore.Application.Repositories.Abstractions;
using ArticleStore.Domain.Models.UserUtilities;
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
    public class ProfessionController : ControllerBase
    {
        readonly IGenericRepository<Profession> genericRepository;
        readonly IProfessionService professionService;
        public ProfessionController(IGenericRepository<Profession> genericRepository, IProfessionService professionService)
        {
            this.genericRepository = genericRepository;
            this.professionService = professionService;
        }

        [HttpPost]
        public async Task<ActionResult<Response<NoDataDto>>> AddProfession(PostPorfessionDto porfessionDto)
        {
            var response = await professionService.AddProfession(porfessionDto);
            return Ok(response);
        }

        [HttpGet]
        [Route("id")]
        public async Task<ActionResult<Response<GetProfessionDto>>> GetProfession(int id)
        {
            var response = await professionService.GetProfessionById(id);
            return Ok(response);
        }

        [HttpGet]
        [Route("text")]
        public async Task<ActionResult<Response<IEnumerable<GetProfessionDto>>>> Profession(string text)
        {
            var response = await professionService.GetProfession(text);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<Response<IEnumerable<GetProfessionDto>>>> GetProfessions()
        {
            var response = await professionService.GetProfessions();
            return Ok(response);
        }
    }
}
