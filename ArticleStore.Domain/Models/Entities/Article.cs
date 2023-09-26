using ArticleStore.Domain.Models.Base;
using ArticleStore.Domain.Models.PostUtilities;
using ArticleStore.Domain.Models.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArticleStore.Domain.Models.Entities
{
    public class Article : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<PictureSource> Images { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<AppUser> LikedBy { get; set; }
        public ICollection<AppUser> DisLikedBy { get; set; }
        public ICollection<AppUser> SavedBy { get; set; }
        public int Likes { get; set; } = 0;
        public int DisLikes { get; set; } = 0;
        public int? AppUserId { get; set; }    
        public AppUser AppUser { get; set; }    
    }

    public class PictureSource
    {
        public int Id { get; set; }
        public byte[] Bytes { get; set; }
    }
}
