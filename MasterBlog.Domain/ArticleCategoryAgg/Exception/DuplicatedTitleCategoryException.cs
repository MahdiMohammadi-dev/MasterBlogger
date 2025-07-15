using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleCategoryAgg.Exception
{
    public class DuplicatedTitleCategoryException : System.Exception
    {
        public DuplicatedTitleCategoryException()
        {

        }

        public DuplicatedTitleCategoryException(string message) : base(message)
        {

        }
    }
}
