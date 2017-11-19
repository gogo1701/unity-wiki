using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityWiki.DataModels
{
    public class Article
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Tags { get; set; }

        public string Description { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
