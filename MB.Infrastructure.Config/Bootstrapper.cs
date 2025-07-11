using MB.Application;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Infrasturcture.EfCore;
using MB.Infrasturcture.EfCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MB.Infrastructure.Core
{
    public class Bootstrapper
    {
        public static void Config(IServiceCollection builder, string conncetionStrings )
        {
            
            builder.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            builder.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            builder.AddDbContext<MasterBloggerContext>(options =>
                options.UseSqlServer(conncetionStrings));
        }
    }
}
