using ArticleStore.Domain.Models.Entities;
using ArticleStore.Domain.Models.Users;
using ArticleStore.Domain.Models.UserUtilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleStore.Infrasturucture.Dtos.Users.Post
{
    public class EditProfileDTO
    {
        public string Bio { get; set; }
        public int? CountyId { get; set; }
        public ICollection<int>? ProfessionIds { get; set; }
        public int? GenderId { get; set; }
        public ICollection<int>? InterestIds { get; set; }
        public IFormFile PictureSource { get; set; }
        public DateTime? BirthDate { get; set; }

        //public static AppUser ToAppUser(EditProfileDTO editProfile)
        //{
        //    return new AppUser()
        //    {
        //        Bio = editProfile.Bio,
        //        BirthDate = editProfile.BirthDate.HasValue ? editProfile.BirthDate.Value :,
        //        GenderId = editProfile.GenderId.Value,
        //        CountryId = editProfile.CountyId.Value,
        //        PictureSource = editProfile.PictureSource,
        //    };
        //}
    }
}
