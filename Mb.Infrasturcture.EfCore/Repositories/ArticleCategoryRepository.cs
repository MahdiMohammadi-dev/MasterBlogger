using MasterBlog.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg;

namespace MB.Infrasturcture.EfCore.Repositories
{
    public class ArticleCategoryRepository:IArticleCategoryRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleCategoryRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        public List<ArticleCategory> GetAll()
        {
            var model = _context.ArticleCategory.OrderBy(x=>x.Id).ToList();
            return model;
        }

        public void Create(ArticleCategory? entity)
        {
            _context.ArticleCategory.Add(entity);
            Save();
        }

        public ArticleCategory? GetById(long id)
        {
            return _context.ArticleCategory.FirstOrDefault(x => x.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool ExistTitle(string title)
        {
            return  _context.ArticleCategory.Any(x => x.Title == title);

        }
    }
}
