using System;
using System.Linq;
using System.Collections.Generic;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> html = new List<string>();

            string title = Console.ReadLine();
            html.Add("<h1>");
            html.Add(title);
            html.Add("</h1>");
            string content = Console.ReadLine();
            html.Add("<article>");
            html.Add(content);
            html.Add("</article>");

            while (true)
            {
                string coments = Console.ReadLine();
                if (coments == "end of comments")
                {
                    break;
                }

                html.Add("<div>");
                html.Add(coments);
                html.Add("</div>");
            }

            Console.WriteLine(string.Join(Environment.NewLine, html));
        }
    }
}
