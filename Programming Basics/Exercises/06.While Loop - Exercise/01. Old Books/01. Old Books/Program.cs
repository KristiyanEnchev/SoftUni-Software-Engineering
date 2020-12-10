using System;

class Program
{
    static void Main(string[] args)
    {
        string book = Console.ReadLine();
        int bookCount = 0;
        string input = "";
        while (input != "No More Books")
        {
            input = Console.ReadLine();
            bookCount += 1;
            if (input == book)
            {
                Console.WriteLine($"You checked {bookCount - 1} books and found it.");
                break;
            }
        }
        if (input == "No More Books")
        {
            Console.WriteLine($"The book you search is not here!");
            Console.WriteLine($"You checked {bookCount - 1} books.");
        }
    }
}
