using System.Globalization;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrasturcture.EfCore.Repositories
{
    public class ArticleRepository: IArticleRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleRepository(MasterBloggerContext context)
        {
            _context = context;
        }


        public List<ArticleViewModel> GetList()
        {
            return _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleViewModel
            {
                Id = x.Id,
                Title = x.Title,
                ArticleCategory = x.ArticleCategory.Title,
                IsDeleted = x.IsDeleted,
               CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture)
            }).ToList();
        }

        public void Create(Article article)
        {
            var articleEntry = _context.Articles.Add(article);
            Save();
        }

        public Article Get(long id)
        {
           return _context.Articles.FirstOrDefault(x => x.Id == id);

        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
