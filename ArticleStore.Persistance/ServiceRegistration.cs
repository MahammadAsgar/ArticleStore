using ArticleStore.Persistance.Jwt;
using Microsoft.Extensions.DependencyInjection;

namespace ArticleStore.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();
        }
    }
}
