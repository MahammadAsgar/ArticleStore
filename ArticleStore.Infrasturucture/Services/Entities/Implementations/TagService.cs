using ArticleStore.Application.Repositories.Abstractions;
using ArticleStore.Application.UnitOfWorks;
using ArticleStore.Domain.Models.Entities;
using ArticleStore.Infrasturucture.Dtos.Entities.Get;
using ArticleStore.Infrasturucture.Dtos.Entities.Post;
using ArticleStore.Infrasturucture.Services.Entities.Abstractions;
using ArticleStore.SharedLibrary.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ArticleStore.Infrasturucture.Services.Entities.Implementations
{
    public class TagService : ITagService
    {
        readonly IGenericRepository<Tag> tagRepository;
        readonly IUnitOfWork unitOfWork;
        public TagService(IGenericRepository<Tag> tagRepository, IUnitOfWork unitOfWork)
        {
            this.tagRepository = tagRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<NoDataDto>> AddTag(PostTagDto tagDto)
        {
            var tag = PostTagDto.ToTag(tagDto.name);
            await tagRepository.AddAsync(tag);
            await unitOfWork.CommitAsync();
            return Response<NoDataDto>.Success("Successful");
        }

        public async Task<Response<IEnumerable<GetTagDto>>> GetTag(string text)
        {
            var response = new List<GetTagDto>();
            var tags = await tagRepository.GetAll().Where(x => x.Name.Contains(text)).ToListAsync();
            if (tags.Count() > 0)
            {
                foreach (var item in tags)
                {
                    response.Add(GetTagDto.ToTagDto(item));
                }
                return Response<IEnumerable<GetTagDto>>.Success(response);
            }
            return Response<IEnumerable<GetTagDto>>.Fail("No found");
        }

        public async Task<Response<GetTagDto>> GetTagById(int id)
        {
            var response = new GetTagDto();
            var tag = await tagRepository.GetByIdAsync(id);
            if (tag != null)
            {
                return Response<GetTagDto>.Success(response);
            }
            return Response<GetTagDto>.Fail("No found");
        }

        public async Task<Response<IEnumerable<GetTagDto>>> GetTags()
        {
            var response = new List<GetTagDto>();
            var tags =await tagRepository.GetAll().ToListAsync();
            if (tags.Count() > 0)
            {
                foreach (var item in tags)
                {
                    response.Add(GetTagDto.ToTagDto(item));
                }
                return Response<IEnumerable<GetTagDto>>.Success(response);
            }
            return Response<IEnumerable<GetTagDto>>.Fail("No found");
        }
    }
}
