using ArticleStore.Domain.Models.Entities;

namespace ArticleStore.Infrasturucture.Dtos.Entities.Get
{
    public class GetTagDto
    {

        public int id { get; set; }
        public string name { get; set; }

        public static GetTagDto ToTagDto(Tag tag)
        {
            return new GetTagDto() { id = tag.Id, name = tag.Name };
        }
    }
}
