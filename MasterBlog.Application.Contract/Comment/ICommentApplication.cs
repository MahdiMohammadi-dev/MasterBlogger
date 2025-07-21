using MB.Contract.Shared;

namespace MB.Application.Contracts.Comment
{
    public interface ICommentApplication
    {
        void AddComment(CreateComment command);
        List<CommentViewModel> GetComments();
        void Confirmed(long  id);
        void Canceled(long  id);
    }
}
