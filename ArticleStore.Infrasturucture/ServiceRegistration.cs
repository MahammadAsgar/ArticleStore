using ArticleStore.Infrasturucture.Helpers.Abstractions;
using ArticleStore.Infrasturucture.Helpers.Implementations;
using ArticleStore.Infrasturucture.Services.Entities.Abstractions;
using ArticleStore.Infrasturucture.Services.Entities.Implementations;
using ArticleStore.Infrasturucture.Services.Users.Abstractions;
using ArticleStore.Infrasturucture.Services.Users.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleStore.Infrasturucture
{
    public static class ServiceRegistration
    {
        public static void AddInfrastuructureServices(this IServiceCollection services)
        {
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IProfessionService, ProfessionService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IArticleService, ArticleService>();
        }
    }
}
