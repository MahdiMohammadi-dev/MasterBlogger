using MB.Application.Contracts.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.ArticleManagement
{
    public class ListModel : PageModel
    {
        public List<ArticleViewModel> ArticleViewModels { get; set; }
        private readonly IArticleApplication _articleApplication;

        public ListModel(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }

        public void OnGet()
        {
          ArticleViewModels=_articleApplication.GetList();

        }

        public RedirectToPageResult OnPostRemove(long id)
        {
            _articleApplication.Remove(id);
            return RedirectToPage("./List");
        }

        public RedirectToPageResult OnPostActivate(long id)
        {
            _articleApplication.Activate(id);
            return RedirectToPage("./List");
        }
    }
}
