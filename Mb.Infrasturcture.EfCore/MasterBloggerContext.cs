using MasterBlog.Domain.ArticleCategoryAgg;
using MasterBLog.Infrasturcture.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrasturcture.EfCore
{
    public class MasterBloggerContext:DbContext
    {
        public MasterBloggerContext(DbContextOptions<MasterBloggerContext> options):base(options)
        {
            
        }
        
        public DbSet<ArticleCategory?> ArticleCategory { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleCategoryMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
