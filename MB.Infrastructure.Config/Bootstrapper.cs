using MB.Application;
using MB.Application.Contracts.Article;
using MB.Application.Contracts.ArticleCategory;
using MB.Application.Contracts.Comment;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleAgg.Services;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Service;
using MB.Domain.CommentAgg;
using MB.Infrastructure.Query;
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
            builder.AddTransient<IArticleCategoryValidatorService, ArticleCategoryValidatorService>();
            builder.AddTransient<IArticleValidatorServices, ArticlevalidatorService>();
            builder.AddTransient<IArticleQuery, ArticleQuery>();
            builder.AddTransient<IArticleApplication, ArticleApplication>();
            builder.AddTransient<IArticleRepository, ArticleRepository>();
            builder.AddTransient<ICommentApplication, CommentApplication>();
            builder.AddTransient<ICommentRepository, CommentRepository>();


            builder.AddDbContext<MasterBloggerContext>(options =>
                options.UseSqlServer(conncetionStrings));
        }
    }
}
