using MasterBlog.Domain.ArticleCategoryAgg;

namespace MB.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository
    {
        List<ArticleCategory> GetAll();
        void Create(ArticleCategory? entity);

        ArticleCategory? GetById(long id);
        void Save();

        bool ExistTitle(string title);

    }
}
