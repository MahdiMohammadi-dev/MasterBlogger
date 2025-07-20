using MB.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Pages
{
    public class ArticlesDetailsModel : PageModel
    {
        private readonly IArticleQuery _articleQuery;
        public ArticleQueryView ArticleQueryView { get; set; }

        public ArticlesDetailsModel(IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }

        public void OnGet(long id)
        {
            ArticleQueryView = _articleQuery.GetArticle(id);
        }
    }
}
