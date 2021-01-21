using System;
using System.Collections.Generic;
using System.Linq;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(", ");
                string titel = tokens[0];
                string content = tokens[1];
                string autor = tokens[2];
                Article article = new Article(titel, content, autor);
                articles.Add(article);
            }

            string criteria = Console.ReadLine();

            if (criteria == "title")
            {
                articles = articles.OrderBy(a => a.Title).ToList();
            }
            else if (criteria == "content")
            {
                articles.Sort((c1, c2) => c1.Content.CompareTo(c2.Content));
            }
            else if (criteria == "author")
            {
                articles = articles.OrderBy(a => a.Autor).ToList();
            }

            Console.WriteLine(string.Join(Environment.NewLine, articles));
        }
    }
    class Article
    {
        public Article(string title, string content, string autor)
        {
            Title = title;
            Content = content;
            Autor = autor;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Autor { get; set; }

        public void Edit(string content)
        {
            Content = content;
        }

        public void ChangeAutor(string autor)
        {
            Autor = autor;
        }

        public void Rename(string title)
        {
            Title = title;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Autor}";
        }
    }
}
