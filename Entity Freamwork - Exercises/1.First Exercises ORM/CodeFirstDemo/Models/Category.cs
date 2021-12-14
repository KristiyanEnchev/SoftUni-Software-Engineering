using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodeFirstDemo.Models
{
    public class Category
    {
        public Category()
        {
            this.News = new HashSet<News>();
        }

        public int Id { get; set; }

        [MaxLength(300)]
        public string Title { get; set; }

        public virtual ICollection<News> News { get; set; }
    }
}
