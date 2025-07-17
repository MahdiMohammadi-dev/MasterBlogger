using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;

namespace MB.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleApplication(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }


        public List<ArticleViewModel> GetList()
        {
            return _articleRepository.GetList();
        }

        public void Create(CreateArticle commandCreateArticle)
        {
            var article = new Article(commandCreateArticle.Title, commandCreateArticle.ShortDescription,
                commandCreateArticle.Image, commandCreateArticle.Content, commandCreateArticle.ArticleCategoryId);

            _articleRepository.Create(article);
            
        }
    }
}