namespace MB.Domain.Service
{
    public interface IArticleCategoryValidatorService
    {
        void CheckDuplicatedRecord(string title);
    }
}
