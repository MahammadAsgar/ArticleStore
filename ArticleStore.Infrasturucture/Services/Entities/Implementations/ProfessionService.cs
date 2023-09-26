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
    public class ProfessionService : IProfessionService
    {
        readonly IGenericRepository<Profession> professionRepository;
        readonly IUnitOfWork unitOfWork;
        public ProfessionService(IGenericRepository<Profession> professionRepository, IUnitOfWork unitOfWork)
        {
            this.professionRepository = professionRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<NoDataDto>> AddProfession(PostPorfessionDto porfessionDto)
        {
            var profession = PostPorfessionDto.ToProfession(porfessionDto.name);
            await professionRepository.AddAsync(profession);
            await unitOfWork.CommitAsync();
            return Response<NoDataDto>.Success("Success");
        }

        public async Task<Response<IEnumerable<GetProfessionDto>>> GetProfession(string text)
        {
            var response = new List<GetProfessionDto>();
            var professions = professionRepository.GetAll().Where(x=>x.Name.Contains(text));
            if (professions.Count() > 0)
            {
                foreach (var item in professions)
                {
                    response.Add(GetProfessionDto.ToProfessionDto(item));
                }
                return Response<IEnumerable<GetProfessionDto>>.Success(response);
            }
            return Response<IEnumerable<GetProfessionDto>>.Fail("No found");
        }

        public async Task<Response<GetProfessionDto>> GetProfessionById(int id)
        {
            var response = new GetProfessionDto();
            var profession = await professionRepository.GetByIdAsync(id);
            if (profession != null)
            {
                response = GetProfessionDto.ToProfessionDto(profession);
                return Response<GetProfessionDto>.Success(response);
            }
            return Response<GetProfessionDto>.Fail("No found");
        }

        public async Task<Response<IEnumerable<GetProfessionDto>>> GetProfessions()
        {
            var response = new List<GetProfessionDto>();
            var professions =  await professionRepository.GetAll().ToListAsync();
            if (professions.Count() > 0)
            {
                foreach (var item in professions)
                {
                    response.Add(GetProfessionDto.ToProfessionDto(item));
                }
                return Response<IEnumerable<GetProfessionDto>>.Success(response);
            }
            return Response<IEnumerable<GetProfessionDto>>.Fail("No found");
        }
    }
}
