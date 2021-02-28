using System;

namespace IteratorsAndComparators
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Book bookOne = new Book("Book One Name", 1991, "KIKO");
            Book bookTwo = new Book("Book Two Name", 1992, "AZ");
            Book bookThree = new Book("Book Three Name", 1993, "TOI");

            Library fires = new Library();
            Library second = new Library(bookOne, bookTwo, bookThree);

            foreach (var book in second)
            {
                Console.WriteLine($"{book.Title} - {book.Year} - {book.Authors[0]}");
            }
        }
    }
}
