using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnityWeb.Data.Contracts;
using UnityWiki.DataModels;
using UnityWiki.Web.Models;

namespace UnityWiki.Web.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IUnityWikiDbContext context;

        public ArticleController(IUnityWikiDbContext context)
        {
            this.context = context;
        }

        public ActionResult Detail(Guid id)
        {
            var article = this.context.Set<Article>().Where(a => a.Id == id).FirstOrDefault();
            string[] tags;

            if (article.Tags != null)
            {
                tags = article.Tags.Split(',');
            }
            else
            {
                tags = new string[0];
            }
            

            var viewModel = new DetailArticleViewModel()
            {
                Title = article.Title,
                Category = article.Category,
                Tags = tags,
                DateCreated = article.DateCreated,
                Description = article.Description
            };

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult SearchResult(string title)
        {
            var articles = this.context.Set<Article>().ToList().Where(a => a.Title.ToLower().Contains(title.ToLower())).ToList();

            var viewModel = new HomeIndexViewModel();

            viewModel.Articles = articles;

            return View(viewModel);
        }
    }
}