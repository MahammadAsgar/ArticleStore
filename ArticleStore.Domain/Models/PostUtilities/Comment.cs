using ArticleStore.Domain.Models.Base;
using ArticleStore.Domain.Models.Entities;
using ArticleStore.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleStore.Domain.Models.PostUtilities
{
    public class Comment : BaseEntity
    {
        public string Text { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
