﻿using System.Globalization;
using System.Runtime.CompilerServices;
using MB.Infrasturcture.EfCore;
using Microsoft.EntityFrameworkCore;


namespace MB.Infrastructure.Query;

public class ArticleQuery : IArticleQuery
{
    private readonly MasterBloggerContext _context;

    public ArticleQuery(MasterBloggerContext context)
    {
        _context = context;
    }

    public List<ArticleQueryView> GetArticles()
    {
        return _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryView
        {
            Id = x.Id,
            Title = x.Title,
            ArticleCategory = x.ArticleCategory.Title,
            CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
            ShortDescription = x.ShortDescription
        }).ToList();
    }

    public ArticleQueryView GetArticle(long id)
    {
        return _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryView
        {
            Id = x.Id,
            Title = x.Title,
            ArticleCategory = x.ArticleCategory.Title,
            CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
            ShortDescription = x.ShortDescription,
            Content = x.Content
        }).FirstOrDefault(x=>x.Id==id)!;
    }
}