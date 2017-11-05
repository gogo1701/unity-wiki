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
    public class HomeController : Controller
    {
        private readonly IUnityWikiDbContext context;

        public HomeController(IUnityWikiDbContext context)
        {
            this.context = context;
        }

        public ActionResult Index()
        {
            var viewModel = new HomeIndexViewModel();

            viewModel.Articles = this.context.Set<Article>().ToList();

            return View(viewModel);
        }
    }
}