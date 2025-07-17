using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg.Service;

namespace MasterBlog.Domain.ArticleCategoryAgg
{
    public class ArticleCategory
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreationDate { get; private set; }
        public ICollection<Article> Articles { get; private set; }

        protected ArticleCategory(){}
        public ArticleCategory(string title,IArticleCategoryValidatorService validatorService)
        {
            validatorService.CheckDuplicatedRecord(title);
            Title = title;
            IsDeleted = false;
            CreationDate = DateTime.Now;
            Articles = new List<Article>();
        }

        public void Rename(string title)
        {
            Title = title;
        }

        public void Delete()
        {
            IsDeleted = true;
        }

        public void Activate()
        {
            IsDeleted = false;
        }
    }
}
