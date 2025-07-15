using MB.Domain.ArticleCategoryAgg;
using MB.Domain.Exception;

namespace MB.Domain.ArticleCategoryAgg.Service;

public class ArticleCategoryValidatorService : IArticleCategoryValidatorService
{
    private readonly IArticleCategoryRepository _articleCategoryRepository;

    public ArticleCategoryValidatorService(IArticleCategoryRepository articleCategoryRepository)
    {
        _articleCategoryRepository = articleCategoryRepository;
    }

    public void CheckDuplicatedRecord(string title)
    {
        if (_articleCategoryRepository.ExistTitle(title))
        {
            throw new DuplicatedTitleCategoryException("Duplicated Title,Change It...!");
        }
    }
}