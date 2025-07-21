using MB.Application.Contracts.Comment;
using MB.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Pages
{
    public class ArticlesDetailsModel : PageModel
    {
        private readonly IArticleQuery _articleQuery;
        private readonly ICommentApplication _commentApplication;
        public ArticleQueryView ArticleQueryView { get; set; }

        public ArticlesDetailsModel(IArticleQuery articleQuery, ICommentApplication commentApplication)
        {
            _articleQuery = articleQuery;
            _commentApplication = commentApplication;
        }

        public void OnGet(long id)
        {
            ArticleQueryView = _articleQuery.GetArticle(id);
        }

        public RedirectToPageResult OnPostSubmitComment(CreateComment command)
        {
            _commentApplication.AddComment(command);
            return RedirectToPage("./ArticlesDetails",new {id = command.ArticleId});
        }
    }
}
