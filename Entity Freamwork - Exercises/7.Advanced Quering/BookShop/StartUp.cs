namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //2
            //string ageRestrictionString = Console.ReadLine();
            //string result = GetBooksByAgeRestriction(db, ageRestrictionString);

            //3
            //string result = GetGoldenBooks(db);

            //4
            //string result = GetBooksByPrice(db);

            //5
            //string result = GetBooksNotReleasedIn(db, 2000);

            //6
            string result = GetBooksByCategory(db, "Drama");

            //7
            //string result = GetBooksReleasedBefore(db, "10-10-2000");

            //8
            //string result = GetAuthorNamesEndingIn(db, "e");

            //9
            //string result = GetBookTitlesContaining(db, "sK");
            //string result = GetBookTitlesContaining(db, "WOR");

            //10
            //string result = GetBooksByAuthor(db, "R");

            //11
            //int result = CountBooks(db, 12);

            //12
            //string result = CountCopiesByAuthor(db);

            //13
            //string result = GetTotalProfitByCategory(db);

            //14
            //string result = GetMostRecentBooks(db);

            //15
            //IncreasePrices(db);
            //foreach (var item in db.Books)
            //{
            //    Console.WriteLine(item.Price);
            //}

            //16
            //int result = RemoveBooks(db);
            //Console.WriteLine(result.Length);
            Console.WriteLine(result);

        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();

            AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            string[] bookTitles = context
                .Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();


            foreach (var title in bookTitles)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            string[] goldenBooksTitle = context
                .Books
                .Where(x => x.EditionType == EditionType.Gold && x.Copies < 5000)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToArray();

            foreach (var title in goldenBooksTitle)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var allBooksMoreThan40 = context
                .Books
                .Select(x => new
                {
                    BookTitle = x.Title,
                    BookPrice = x.Price
                })
                .Where(x => x.BookPrice > 40)
                .OrderByDescending(x => x.BookPrice)
                .ToArray();

            foreach (var item in allBooksMoreThan40)
            {
                sb.AppendLine($"{item.BookTitle} - ${item.BookPrice:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder sb = new StringBuilder();

            string[] booksNotReleasedInTitle = context
                .Books
                .Where(x => x.ReleaseDate.HasValue && x.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            foreach (var item in booksNotReleasedInTitle)
            {
                sb.AppendLine(item);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            string[] catergorisInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => x.ToLower()).ToArray();

            var bookTitltesByCategory = context
                .Books
                .OrderBy(x => x.Title)
                .Where(x => x.BookCategories
                    .Any(x => catergorisInput.Contains(x.Category.Name.ToLower())))
                .Select(x => x.Title)
                .ToArray();

            foreach (var item in bookTitltesByCategory)
            {
                sb.AppendLine(item);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context
                .Books
                .Where(x => x.ReleaseDate < dateTime)
                .Select(x => new
                {
                    Title = x.Title,
                    EditionType = x.EditionType,
                    ReleaseDate = x.ReleaseDate,
                    Price = x.Price
                })
                .OrderByDescending(x => x.ReleaseDate)
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            string[] authorNames = context
                .Authors
                .ToArray()
                .Where(x => x.FirstName.ToLower().EndsWith(input.ToLower()))
                .Select(x => $"{x.FirstName} {x.LastName}")
                .OrderBy(x => x)
                .ToArray();

            foreach (var item in authorNames)
            {
                sb.AppendLine(item);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var booksTitles = context
                .Books
                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToArray();

            foreach (var item in booksTitles)
            {
                sb.AppendLine(item);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var booksInfo = context
                .Books
                .Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(x => new
                {
                    BookId = x.BookId,
                    BookTitlte = x.Title,
                    BookAuthor = x.Author.FirstName + " " + x.Author.LastName
                })
                .OrderBy(x => x.BookId)
                .ToArray();

            foreach (var item in booksInfo)
            {
                sb.AppendLine($"{item.BookTitlte} ({item.BookAuthor})");
            }

            return sb.ToString().TrimEnd();

        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int books = context
                .Books
                .Where(x => x.Title.Length > lengthCheck)
                .Count();

            return books;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var authorWithBookCopies = context
                .Authors
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName,
                    TotalBookCopies = a.Books
                    .Sum(b => b.Copies)
                })
                .OrderByDescending(x => x.TotalBookCopies)
                .ToArray();

            foreach (var item in authorWithBookCopies)
            {
                sb.AppendLine($"{item.FullName} - {item.TotalBookCopies}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categoriesByProfit = context
                .Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    TotalProfit = c.CategoryBooks
                    .Sum(x => x.Book.Copies * x.Book.Price)
                })
                .OrderByDescending(x => x.TotalProfit)
                .ThenBy(c => c.CategoryName)
                .ToArray();

            foreach (var item in categoriesByProfit)
            {
                sb.AppendLine($"{item.CategoryName} ${item.TotalProfit:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categoriesByMostrecentBooks = context
                .Categories
                .Select(x => new
                {
                    CategoruyName = x.Name,
                    MostRecentBooks = x.CategoryBooks
                    .Select(x => x.Book)
                    .OrderByDescending(x => x.ReleaseDate)
                    .Select(x => new
                    {
                        BookTitle = x.Title,
                        RelaseYear = x.ReleaseDate.Value.Year
                    })
                    .Take(3)
                    .ToArray()
                })
                .OrderBy(x => x.CategoruyName)
                .ToArray();

            foreach (var item in categoriesByMostrecentBooks)
            {
                sb.AppendLine($"--{item.CategoruyName}");
                foreach (var book in item.MostRecentBooks)
                {
                    sb.AppendLine($"{book.BookTitle} ({book.RelaseYear})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var booksBefore2010 = context
                .Books
                .Where(x => x.ReleaseDate.HasValue && x.ReleaseDate.Value.Year < 2010)
                .ToArray();

            foreach (var item in booksBefore2010)
            {
                item.Price += 5;
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var booksWithLessThan4200 = context
                .Books
                .Where(x => x.Copies < 4200)
                .ToArray();

            context.RemoveRange(booksWithLessThan4200);

            context.SaveChanges();

            return booksWithLessThan4200.Count();
        }
    }
}
