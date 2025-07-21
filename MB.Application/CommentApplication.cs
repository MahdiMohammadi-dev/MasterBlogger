using MB.Application.Contracts.Comment;
using MB.Contract.Shared;
using MB.Domain.CommentAgg;

namespace MB.Application
{
    public class CommentApplication:ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;

        public CommentApplication(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }


        public void AddComment(CreateComment command)
        {
            var comment = new Comment(command.Name, command.Email, command.Message, command.ArticleId);
            _commentRepository.AddComment(comment);
        }

        public List<CommentViewModel> GetComments()
        {
            return _commentRepository.GetComments();
        }

        public void Confirmed(long id)
        {
            var comment = _commentRepository.Get(id);
            comment.Confirm();
            _commentRepository.Save();
        }

        public void Canceled(long id)
        {

            var comment = _commentRepository.Get(id);
            comment.Cancel();
            _commentRepository.Save();

        }
    }
}
