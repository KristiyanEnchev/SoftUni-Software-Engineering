using CodeFirstDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new ApplicationDBContext();

            db.Database.EnsureCreated();

            var news = db.News.Select(x => new
            {
                Name = x.Title,
                Category = x.Category.Title,

            });

            foreach (var singleNews in news)
            {
                Console.WriteLine(singleNews.Category + " => " + singleNews.Name);
            }

            db.SaveChanges();


            //db.Categories.Add(new Category
            //{
            //    Title = "Sport",
            //    News = new List<News>
            //    {
            //        new News
            //        {
            //            Title = "Neshto stanalo",
            //            Content = "Nekakuv kontent bal bala",
            //            Coments = new List<Coment>
            //            {
            //                new Coment
            //                {
            //                    Author = "Az", Content = "Ala bala",
            //                },
            //                new Coment
            //                {
            //                    Author = "Ti", Content = "oshte ala bala ",
            //                }
            //            }
            //        }
            //    }
            //});

            //db.SaveChanges();

        }
    }
}
