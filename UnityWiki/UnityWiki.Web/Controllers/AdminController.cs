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
    public class AdminController : Controller
    {
        private IUnityWikiDbContext context;

        public AdminController(IUnityWikiDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new CreateArticleViewModel());
        }

        [HttpPost]
        public ActionResult Create(CreateArticleViewModel viewModel)
        {
            var article = new Article()
            {
                Id = Guid.NewGuid(),
                DateCreated = DateTime.Now,
                Title = viewModel.Title,
                Description = viewModel.Description
            };

            this.context.Set<Article>().Add(article);
            this.context.SaveChanges();

            return this.RedirectToAction("Index", "Home");
        }
    }
}