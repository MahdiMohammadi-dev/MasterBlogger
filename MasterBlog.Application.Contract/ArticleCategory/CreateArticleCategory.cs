using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application.Contracts.ArticleCategory
{
    /// <summary>
    /// چیزی که قراره از کاربر دریافت بشه برای ساخت مقاله رو
    /// اینچا تعریف میکنیم که ما در این سناریو فقط تایتل رو قراره بگیریم.
    /// </summary>
    public class CreateArticleCategory
    {
        public string Title { get; set; }
    }
}
