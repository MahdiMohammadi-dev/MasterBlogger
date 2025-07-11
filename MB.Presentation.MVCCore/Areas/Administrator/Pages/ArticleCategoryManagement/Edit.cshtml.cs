using MasterBlog.Domain.ArticleCategoryAgg;
using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.ArticleCategoryManagement
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public RenameArticleCategory RenameArticleCategory { get; set; }

        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public EditModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(long id)
        {
           RenameArticleCategory= _articleCategoryApplication.getRenameArticleCategory(id);
        }

        public RedirectToPageResult OnPost()
        {
            _articleCategoryApplication.Rename(RenameArticleCategory);
            return RedirectToPage("./List");
        }

    }
}
