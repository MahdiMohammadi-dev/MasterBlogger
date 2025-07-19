using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleAgg.Services
{
    public interface IArticleValidatorServices
    { 
        void StringValidator(string title, long articleCategoryId);
    }
}
