using ArticleStore.Application.Repositories.Abstractions;
using ArticleStore.Domain.Models.Entities;
using ArticleStore.Domain.Models.PostUtilities;
using ArticleStore.Domain.Models.Users;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleStore.Infrasturucture.Dtos.Entities.Post
{
    public class PostArticleDto
    {
        public string name { get; set; }
        public string description { get; set; }
        public int categoryId { get; set; }
        public ICollection<int> tagIds { get; set; }
        public ICollection<IFormFile> Images { get; set; }
    }
}
