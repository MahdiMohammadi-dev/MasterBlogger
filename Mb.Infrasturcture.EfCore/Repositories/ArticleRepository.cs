using MB.Domain.ArticleAgg;

namespace MB.Infrasturcture.EfCore.Repositories
{
    public class ArticleRepository: IArticleRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleRepository(MasterBloggerContext context)
        {
            _context = context;
        }


    }
}
