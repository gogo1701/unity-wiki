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
            var tags = article.Tags.Split(',');

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
    }
}