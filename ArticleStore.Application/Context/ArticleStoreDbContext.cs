using ArticleStore.Application.EntitiesConfiguration;
using ArticleStore.Domain.Models.Base;
using ArticleStore.Domain.Models.Entities;
using ArticleStore.Domain.Models.PostUtilities;
using ArticleStore.Domain.Models.Users;
using ArticleStore.Domain.Models.UserUtilities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;

namespace ArticleStore.Application.Context
{
    public class ArticleStoreDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public ArticleStoreDbContext(DbContextOptions<ArticleStoreDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new GenderConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new CountryConfiguration());


            builder.Entity<Article>()
                .HasMany(a => a.DisLikedBy)
                .WithMany(u => u.DisLikedPosts)
                .UsingEntity(j => j.ToTable("ArticleDisLikes"));

            builder.Entity<Article>()
                .HasMany(a => a.LikedBy)
                .WithMany(u => u.LikedPosts)
                .UsingEntity(j => j.ToTable("ArticleLikes"));

            builder.Entity<Article>()
                .HasMany(a => a.SavedBy)
                .WithMany(u => u.SavedPosts)
                .UsingEntity(j => j.ToTable("ArticleSaved"));


            builder.Entity<Article>()
                .HasOne(a => a.AppUser)
                .WithMany(a=>a.Posts)
                .HasForeignKey(a => a.AppUserId)
                .OnDelete(DeleteBehavior.NoAction);

            //builder.Entity<AppUser>()
            //    .HasMany(a => a.Posts)
            //    .WithOne(a => a.AppUser)
            //    .HasForeignKey(a => a.AppUserId);


            base.OnModelCreating(builder);
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<PictureSource> PictureSources { get; set; }
    }
}
