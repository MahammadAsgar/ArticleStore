using ArticleStore.Domain.Models.Entities;

namespace ArticleStore.Infrasturucture.Dtos.Entities.Post
{
    public class PostTagDto
    {
        public string name { get; set; }

        public static Tag ToTag(string name)
        {
            return new Tag()
            {
                Name = name,
            };
        }
    }

}
