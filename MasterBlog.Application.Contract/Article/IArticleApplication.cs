﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application.Contracts.Article
{
    public interface  IArticleApplication
    {
        List<ArticleViewModel> GetList();
        void Create(CreateArticle commandCreateArticle);
        void Edit(EditArticle command);
        EditArticle Get(long id);
        void Remove(long id);
        void Activate(long  id);
    }
}
