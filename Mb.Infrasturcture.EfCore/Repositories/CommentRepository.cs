using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Application.Contracts.Article;
using MB.Contract.Shared;
using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrasturcture.EfCore.Repositories
{
    public class CommentRepository:ICommentRepository
    {
        private readonly MasterBloggerContext _context;

        public CommentRepository(MasterBloggerContext context)
        {
            _context = context;
        }


        public void AddComment(Comment entity)
        {
            _context.Comments.Add(entity);
            Save();
        }

        public List<CommentViewModel> GetComments()
        {
            return _context.Comments.Include(x => x.Article).Select(x => new CommentViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Message = x.Message,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Article = x.Article.Title,
                Email = x.Email,
                Status = x.Status
            }).ToList();
        }

        public Comment Get(long id)
        {
            return _context.Comments.FirstOrDefault(x => x.Id == id);
        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
