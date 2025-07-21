using MasterBlog.Domain.ArticleCategoryAgg;
using MasterBLog.Infrasturcture.EfCore.Mapping;
using MB.Domain.ArticleAgg;
using MB.Domain.CommentAgg;
using MB.Infrasturcture.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrasturcture.EfCore
{
    public class MasterBloggerContext:DbContext
    {
        public MasterBloggerContext(DbContextOptions<MasterBloggerContext> options):base(options)
        {
            
        }
        
        public DbSet<ArticleCategory?> ArticleCategory { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ArticleMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
