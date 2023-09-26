﻿using ArticleStore.Domain.Models.Base;

namespace ArticleStore.Domain.Models.Entities
{
    public class Category 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
