﻿namespace ArticleStore.Persistance.Jwt
{
    public class Token
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}