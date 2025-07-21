using System.Diagnostics.Eventing.Reader;
using MB.Application.Contracts.Article;
using MB.Application.Contracts.Comment;
using MB.Contract.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.CommentManagement
{
    public class ListModel : PageModel
    {
        private readonly ICommentApplication _commentApplication;
        public List<CommentViewModel> Comments { get; set; }
        public ListModel(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;
        }

        public void OnGet()
        {
            Comments = _commentApplication.GetComments();
        }

        public RedirectToPageResult OnPostConfirm(long id)
        {
            _commentApplication.Confirmed(id);
            return RedirectToPage("./List");
        }

        public RedirectToPageResult OnPostCancel(long id)
        {
            _commentApplication.Canceled(id);
            return RedirectToPage("./List");
        }
    }
}
