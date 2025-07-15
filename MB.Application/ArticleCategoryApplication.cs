using System.Globalization;
using MasterBlog.Domain.ArticleCategoryAgg;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Service;

namespace MB.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _iarticleCategoryRepository;
        private readonly IArticleCategoryValidatorService _iarticleCategoryValidatorService;
        public ArticleCategoryApplication(IArticleCategoryRepository iarticleCategoryRepository, IArticleCategoryValidatorService iarticleCategoryValidatorService)
        {
            _iarticleCategoryRepository = iarticleCategoryRepository;
            _iarticleCategoryValidatorService = iarticleCategoryValidatorService;
        }

        public List<ArticleCategoryViewModel> GetArticleCategoriesList()
        {
            var articleCategories = _iarticleCategoryRepository.GetAll();
            var result = new List<ArticleCategoryViewModel>();
            foreach (var articleCategory in articleCategories)
            {
                result.Add(new ArticleCategoryViewModel
                {
                    Id = articleCategory.Id,
                    Title = articleCategory.Title,
                    IsDeleted = articleCategory.IsDeleted,
                    CreationDate = articleCategory.CreationDate.ToString(CultureInfo.InvariantCulture)
                });
            }
            return result;
        }

        public void Create(CreateArticleCategory command)
        {
            var articleCategory = new ArticleCategory(command.Title,_iarticleCategoryValidatorService);
            _iarticleCategoryRepository.Create(articleCategory);
        }

        public void Rename(RenameArticleCategory command)
        {
            var articleCategory = _iarticleCategoryRepository.GetById(command.Id);
            if (articleCategory!=null)
            {
                articleCategory.Rename(command.Title);
                _iarticleCategoryRepository.Save();
            }
        }

        public RenameArticleCategory? getRenameArticleCategory(long id)
        {
            var articleCategory = _iarticleCategoryRepository.GetById(id);
            return new RenameArticleCategory
            {
                Id = articleCategory.Id,
                Title = articleCategory.Title,
            };
        }

        public void Remove(long id)
        {
            var articaleCategory = _iarticleCategoryRepository.GetById(id);
            articaleCategory.Delete();
            _iarticleCategoryRepository.Save();
        }

        public void Activate(long id)
        {

            var articaleCategory = _iarticleCategoryRepository.GetById(id);
            articaleCategory.Activate();
            _iarticleCategoryRepository.Save();
        }
    }
}
