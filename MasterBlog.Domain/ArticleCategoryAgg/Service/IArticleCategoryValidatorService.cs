namespace MB.Domain.ArticleCategoryAgg.Service
{
    public interface IArticleCategoryValidatorService
    {
        void CheckDuplicatedRecord(string title);
    }
}
