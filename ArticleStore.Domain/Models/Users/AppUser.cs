using ArticleStore.Domain.Models.Entities;
using ArticleStore.Domain.Models.UserUtilities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArticleStore.Domain.Models.Users
{
    public class AppUser : IdentityUser<int>
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Bio { get; set; }
        //[ForeignKey("CountryId")]
        public int CountryId { get; set; }
        public Country County { get; set; }
        public ICollection<Profession>? Professions { get; set; }
        //[ForeignKey("GenderId")]
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public ICollection<Category>? Interests { get; set; }
        public int Number { get; set; }
        public ICollection<AppUser> Followings { get; set; }
        public ICollection<AppUser> Followers { get; set; }

        public PictureSource? PictureSource { get; set; }


        public ICollection<Article> LikedPosts { get; set; }
        public ICollection<Article> DisLikedPosts { get; set; }
        public ICollection<Article> SavedPosts { get; set; }

        public ICollection<Article> Posts { get; set; }
    }

    public class Gender
    {
        public int Id { get; set; }
        public string GenderName { get; set; }
    }
}
