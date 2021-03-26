using System;

namespace AuthorProblem
{
    [Author("Kiko")]
    [Author("Ventsi")]
    public class StartUp
    {
        [Author("Shasho")]
        [Author("Gosho")]
        static void Main(string[] args)
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();

        }
    }
}
