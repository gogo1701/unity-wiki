using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnityWiki.Web.Models
{
    public class DetailArticleViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string[] Tags { get; set; }

        public DateTime DateCreated { get; set; }
    }
}