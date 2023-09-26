using ArticleStore.Domain.Models.UserUtilities;

namespace ArticleStore.Infrasturucture.Dtos.Entities.Get
{
    public class GetProfessionDto
    {
        public int id { get; set; }
        public string name { get; set; }

        public static GetProfessionDto ToProfessionDto(Profession profession)
        {
            return new GetProfessionDto()
            {
                name = profession.Name
            };
        }
    }
}
