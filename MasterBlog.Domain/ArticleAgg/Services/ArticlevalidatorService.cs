namespace MB.Domain.ArticleAgg.Services;

public class ArticlevalidatorService:IArticleValidatorServices
{
    public void StringValidator(string title, long articleCategoryId)
    {
        if (string.IsNullOrEmpty(title))
        {
            throw new Exception("نباید خالی باشد");
        }

        if (articleCategoryId == 0)
        {
            throw new Exception("وروردی نا معتبر دریافت شد");
        }
    }
}