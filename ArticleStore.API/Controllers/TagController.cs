using ArticleStore.Application.Repositories.Abstractions;
using ArticleStore.Domain.Models.Entities;
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
    public class TagController : ControllerBase
    {
        readonly IGenericRepository<Tag> genericRepository;
        readonly ITagService tagService;
        public TagController(IGenericRepository<Tag> genericRepository, ITagService tagService)
        {
            this.genericRepository = genericRepository;
            this.tagService = tagService;
        }

        [HttpPost]
        public async Task<ActionResult<Response<NoDataDto>>> AddTag(PostTagDto tagDto)
        {
            var response = await tagService.AddTag(tagDto);
            return Ok(response);
        }

        [HttpGet]
        [Route("id")]
        public async Task<ActionResult<Response<GetTagDto>>> GetTag(int id)
        {
            var response = await tagService.GetTagById(id);
            return Ok(response);
        }

        [HttpGet]
        [Route("text")]
        public async Task<ActionResult<Response<IEnumerable<GetTagDto>>>> Tags(string text)
        {
            var response = await tagService.GetTag(text);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<Response<IEnumerable<GetTagDto>>>> Tags()
        {
            var response = await tagService.GetTags();
            return Ok(response);
        }
    }
}
