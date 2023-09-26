using ArticleStore.Domain.Models.UserUtilities;

namespace ArticleStore.Infrasturucture.Dtos.Entities.Get
{
    public class GetCountryDto
    {
        public int id { get; set; }
        public string name { get; set; }

        public static GetCountryDto ToCountryDto(Country county)
        {
            return new GetCountryDto() { id = county.Id, name = county.Name };
        }
    }
}
