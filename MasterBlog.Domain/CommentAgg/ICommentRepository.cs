using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Contract.Shared;

namespace MB.Domain.CommentAgg
{
    public interface ICommentRepository
    {
        void AddComment(Comment  entity);
        List<CommentViewModel> GetComments();
        Comment Get(long id);
        void Save();
    }
}
