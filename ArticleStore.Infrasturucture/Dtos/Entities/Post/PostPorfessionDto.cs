using ArticleStore.Domain.Models.UserUtilities;

namespace ArticleStore.Infrasturucture.Dtos.Entities.Post
{
    public class PostPorfessionDto
    {
        public string name { get; set; }

        public static Profession ToProfession(string name)
        {
            return new Profession()
            {
                Name = name
            };
        }
    }
}
