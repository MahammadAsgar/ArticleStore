using ArticleStore.Domain.Models.UserUtilities;

namespace ArticleStore.Infrasturucture.Dtos.Entities.Post
{
    public class PostCountryDto
    {
        public string name { get; set; }

        public static Country ToCountry(string name)
        {
            return new Country()
            {
                Name = name
            };
        }
    }

}

