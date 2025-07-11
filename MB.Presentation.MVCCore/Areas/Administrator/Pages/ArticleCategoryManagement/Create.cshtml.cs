using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.ArticleCategoryManagement
{
    public class CreateModel : PageModel
    {

        private readonly IArticleCategoryApplication _iarticleCategoryApplication;

        public CreateModel(IArticleCategoryApplication iarticleCategoryApplication)
        {
            _iarticleCategoryApplication = iarticleCategoryApplication;
        }

        public void OnGet()
        {
        }

        public RedirectToPageResult OnPost(CreateArticleCategory command)
        {
            _iarticleCategoryApplication.Create(command);

            return RedirectToPage("./List");
        }
    }
}
