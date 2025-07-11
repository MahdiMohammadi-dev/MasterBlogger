namespace MB.Application.Contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        List<ArticleCategoryViewModel> GetArticleCategoriesList();


        void Create(CreateArticleCategory command);
        void Rename(RenameArticleCategory command);

        RenameArticleCategory getRenameArticleCategory(long id);

        public void Remove(long id);
        public void Activate(long id);
    }
}
