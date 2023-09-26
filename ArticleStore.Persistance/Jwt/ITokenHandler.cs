using ArticleStore.Domain.Models.Users;

namespace ArticleStore.Persistance.Jwt
{
    public interface ITokenHandler
    {
        Task<Token> CreateAccessToken(AppUser user);
    }
}
