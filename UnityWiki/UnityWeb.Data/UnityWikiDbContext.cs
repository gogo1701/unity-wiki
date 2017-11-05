﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityWeb.Data.Contracts;
using UnityWiki.DataModels;

namespace UnityWeb.Data
{
    public class UnityWikiDbContext : IdentityDbContext<User>, IUnityWikiDbContext
    {
        public UnityWikiDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        public IDbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public static UnityWikiDbContext Create()
        {
            return new UnityWikiDbContext();
        }
    }
}