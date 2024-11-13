using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Mini_Libary
{
    [Serializable]
    public class Libary
    {
        private List<Book> books;
        static int OneObj = 0;

        public Libary()
        {
            OneObj++;
            books = new List<Book>();
            if (OneObj != 1)
                throw new Exception("Только один экзампляр класса!!!");
        }

        public void Add(Book book)
        {
            books.Add(book);
        }

        public void AddMore(Book[] book)
        {
            for (int i = 0; i < book.Length; i++)
                Add(book[i]);
        }

        public void Clear()
        {
            books.Clear();
        }

        public void Remove(Book book)
        {
            books.Remove(book);
        }

        public List<Book> GetBooks()
        {
            return books;
        }

        public static void GetBookOnYear(int year)
        {
            JArray books = JArray.Parse(File.ReadAllText("C:\\Users\\user\\source\\repos\\Mini-Libary\\libary.json"));

            var BooksYear = books.Where(b => (int)b["YearB"] == year)
                .Select(b => new Book(
                                   (string?)b["TitleB"],
                                   (int)b["YearB"],
                                   new Author(
                                       (string?)b["AuthorB"]["NameA"],
                                       (string?)b["AuthorB"]["SurNameA"]
                                   )
                               ))
                               .Distinct(new BookComparer())
                               .ToList();

            foreach (var book in BooksYear)
            {
                book.DisplayInfo();
            }
        }

        public static void GetBookOnAuthor(Author author)
        {
            JArray books = JArray.Parse(File.ReadAllText("C:\\Users\\user\\source\\repos\\Mini-Libary\\libary.json"));

            var BooksAuthor = books.Where(b => (string)b["AuthorB"]["NameA"] == author.NameA
                                               && (string)b["AuthorB"]["SurNameA"] == author.SurNameA)
                                   .Select(b => new Book(
                                       (string?)b["TitleB"],
                                       (int)b["YearB"],
                                       new Author(
                                           (string?)b["AuthorB"]["NameA"],
                                           (string?)b["AuthorB"]["SurNameA"]
                                       )
                                   ))
                                   .Distinct(new BookComparer())
                                   .ToList();
            foreach (var book in BooksAuthor)
            {
                book.DisplayInfo();
            }
        }

        public static void GetBookOnTitle(string title)
        {
            JArray books = JArray.Parse(File.ReadAllText("C:\\Users\\user\\source\\repos\\Mini-Libary\\libary.json"));

            var BooksTitle = books.Where(b => ((string)b["TitleB"]).ToLower() == title.ToLower())
                                  .Select(b => new Book(
                                       (string?)b["TitleB"],
                                       (int)b["YearB"],
                                       new Author(
                                           (string?)b["AuthorB"]["NameA"],
                                           (string?)b["AuthorB"]["SurNameA"]
                                       )
                                   ))
                                  .Distinct(new BookComparer())
                                   .ToList();

            foreach (var book in BooksTitle)
            {
                book.DisplayInfo();
            }
        }

        public static void GetBookOnAuthorSurname(string surname)
        {
            JArray books = JArray.Parse(File.ReadAllText("C:\\Users\\user\\source\\repos\\Mini-Libary\\libary.json"));

            var BooksSurname = books.Where(b => ((string)b["AuthorB"]["SurNameA"]).ToLower() == surname.ToLower())
                                    .Select(b => new Book(
                                        (string?)b["TitleB"],
                                        (int)b["YearB"],
                                        new Author(
                                            (string?)b["AuthorB"]["NameA"],
                                            (string?)b["AuthorB"]["SurNameA"]
                                        )
                                    ))
                                    .Distinct(new BookComparer())
                                    .ToList();

            foreach (var book in BooksSurname)
            {
                book.DisplayInfo();
            }
        }

        public static void GetBookOnYearRange(int startYear, int endYear)
        {
            JArray books = JArray.Parse(File.ReadAllText("C:\\Users\\user\\source\\repos\\Mini-Libary\\libary.json"));

            var BooksRange = books.Where(b => (int)b["YearB"] >= startYear && (int)b["YearB"] <= endYear)
                                  .Select(b => new Book(
                                       (string?)b["TitleB"],
                                       (int)b["YearB"],
                                       new Author(
                                           (string?)b["AuthorB"]["NameA"],
                                           (string?)b["AuthorB"]["SurNameA"]
                                       )
                                   ))
                                  .Distinct(new BookComparer())
                                  .ToList();

            foreach (var book in BooksRange)
            {
                book.DisplayInfo();
            }
        }

        public static void GetBookOnAuthorAndYear(Author author, int year)
        {
            JArray books = JArray.Parse(File.ReadAllText("C:\\Users\\user\\source\\repos\\Mini-Libary\\libary.json"));

            var BooksAuthorAndYear = books.Where(b => (string)b["AuthorB"]["NameA"] == author.NameA
                                                     && (string)b["AuthorB"]["SurNameA"] == author.SurNameA
                                                     && (int)b["YearB"] == year)
                                          .Select(b => new Book(
                                               (string?)b["TitleB"],
                                               (int)b["YearB"],
                                               new Author(
                                                   (string?)b["AuthorB"]["NameA"],
                                                   (string?)b["AuthorB"]["SurNameA"]
                                               )
                                           ))
                                          .Distinct(new BookComparer())
                                          .ToList();

            foreach (var book in BooksAuthorAndYear)
            {
                book.DisplayInfo();
            }
        }
    }
}
