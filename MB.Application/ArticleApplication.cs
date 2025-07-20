using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleAgg.Services;

namespace MB.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleValidatorServices _articleValidatorServices;

        public ArticleApplication(IArticleRepository articleRepository, IArticleValidatorServices articleValidatorServices)
        {
            _articleRepository = articleRepository;
            _articleValidatorServices = articleValidatorServices;
        }


        public List<ArticleViewModel> GetList()
        {
            return _articleRepository.GetList();
        }

        public void Create(CreateArticle commandCreateArticle)
        {
            _articleValidatorServices.StringValidator(commandCreateArticle.Title,commandCreateArticle.ArticleCategoryId);
            var article = new Article(commandCreateArticle.Title,commandCreateArticle.ShortDescription,commandCreateArticle.Image,commandCreateArticle.Content,commandCreateArticle.ArticleCategoryId);

            _articleRepository.Create(article);
            _articleRepository.Save();

        }

        public void Edit(EditArticle command)
        {
            var article = _articleRepository.Get(command.Id);
            _articleValidatorServices.StringValidator(command.Title,command.ArticleCategoryId);
            article.Edit(command.Title,command.ShortDescription,command.Image,command.Content,command.ArticleCategoryId);
            _articleRepository.Save();
        }

        public EditArticle Get(long id)
        {
            var article = _articleRepository.Get(id);
            return new EditArticle
            {
                Id = article.Id,
                Title = article.Title,
                ShortDescription = article.ShortDescription,
                Image = article.Image,
                Content = article.Content,
                ArticleCategoryId = article.ArticleCategoryId
            };
        }

        public void Remove(long id)
        {
            var article = _articleRepository.Get(id);
            article.Remove();
            _articleRepository.Save();
        }

        public void Activate(long id)
        {
            var article = _articleRepository.Get(id);
            article.Activate();
            _articleRepository.Save();
        }
    }
}