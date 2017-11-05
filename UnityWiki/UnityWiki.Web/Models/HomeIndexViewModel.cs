using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnityWiki.DataModels;

namespace UnityWiki.Web.Models
{
    public class HomeIndexViewModel
    {
        public List<Article> Articles { get; set; }
    }
}