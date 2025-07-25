﻿using MasterBlog.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleAgg.Services;
using MB.Domain.CommentAgg;

namespace MB.Domain.ArticleAgg
{
    public class Article
    {

        private readonly IArticleValidatorServices _services;
        public long Id { get; private set; }
        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Image { get; private set; }
        public string Content { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreationDate { get; private set; }
        public long  ArticleCategoryId { get; private set; }
        public ArticleCategory ArticleCategory { get; private set; }
        public ICollection<Comment> Comments { get; private set; }
        protected Article()
        {

        }

        public Article(string title, string shortDescription, string image, string content, long articleCategoryId)
        {
            Title = title;
            ShortDescription = shortDescription;
            Image = image;
            Content = content;
            ArticleCategoryId = articleCategoryId;
            IsDeleted = false;
            CreationDate = DateTime.Now;
            Comments = new List<Comment>();

        }

       

        public void Edit(string title, string shortDescription, string image, string content, long articleCategoryId)
        {
            _services.StringValidator(title, articleCategoryId);
            Title = title;
            ShortDescription = shortDescription;
            Image = image;
            Content = content;
            ArticleCategoryId = articleCategoryId;
        }


        public void Activate()
        {
            IsDeleted = false;
        }

        public void Remove()
        {
            IsDeleted = true;
        }


       
    }
}
